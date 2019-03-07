using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sysmanager_manager_edit : System.Web.UI.Page
{
    protected int page;
    string defaultpassword = "0|0|0|0"; //默认显示密码
    private string action = "Add"; //操作类型
    private int id = 0;
    ManagePage mym = new ManagePage();

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../index.aspx'</script>");
            Response.End();
        }
        //判断权限
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);
        int nav_id = 29;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        string _action = AXRequest.GetQueryString("action");
        this.page = AXRequest.GetQueryInt("page", 1);
        if (!string.IsNullOrEmpty(_action) && _action == "Edit")
        {
            this.action = "Edit";//修改类型
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                mym.JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
                return;
            }

        }
        if (action == "Edit") //修改
        {
            txtUserName.Attributes.Remove("ajaxurl");
        }
        if (!Page.IsPostBack)
        {
            RoleBind(ddlRoleId, Convert.ToInt32(Session["RoleID"]));//绑定角色


            CategoryBind(0); //绑定地区
            //this.ddlCategoryId.SelectedValue = Session["DepotCatID"].ToString();
            DepotBind(0); //绑定门店
            //this.ddlDepotId.SelectedValue = Session["DepotID"].ToString();

            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
            }
        }
    }



    #region 绑定地区=================================
    private void CategoryBind(int _category_id)
    {
        ps_depot_category bll = new ps_depot_category();
        DataTable dt = bll.GetList(_category_id);
        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("请选择所属地区...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 绑定门店=================================
    private void DepotBind(int _category_id)
    {
        ps_depot bll = new ps_depot();
        DataTable dt = bll.GetList(_category_id);
        this.ddlDepotId.Items.Clear();
        this.ddlDepotId.Items.Add(new ListItem("请选择所属门店...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlDepotId.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 角色类型=================================
    private void RoleBind(DropDownList ddl, int role_type)
    {
        ps_manager_role bll = new ps_manager_role();
        DataTable dt = bll.GetList("").Tables[0];

        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("请选择角色...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            if (Convert.ToInt32(dr["role_type"]) < role_type)
            {
                ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
            }
        }
    }
    #endregion

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_manager model = new ps_manager();
        model.GetModel(_id);
        ddlRoleId.SelectedValue = model.role_id.ToString();

        if (model.role_id == 2 || model.role_id == 3)
        {
            bm.Visible = false;
            md.Visible = false;

        }
        if (model.role_id == 4)
        {
            bm.Visible = true;
            md.Visible = true;
            CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定地区
            DepotBind(Convert.ToInt32(model.depot_category_id.ToString())); //绑定门店

        }
        ddlCategoryId.SelectedValue = model.depot_category_id.ToString();
        ddlDepotId.SelectedValue = model.depot_id.ToString();

        txtUserName.Text = model.user_name;
        if (_id == 1)//admin账号不能修改
        {
            txtUserName.ReadOnly = true;
        }

        if (!string.IsNullOrEmpty(model.password))
        {
            txtPassword.Attributes["value"] = txtPassword1.Attributes["value"] = defaultpassword;
        }
        txtRealName.Text = model.real_name;
        txtmobile.Text = model.mobile;
        txtremark.Text = model.remark;
        if (model.is_lock == 1)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        ps_manager model = new ps_manager();

        model.role_id = int.Parse(ddlRoleId.SelectedValue);
        if (ddlCategoryId.SelectedValue != "")
        {
            model.depot_category_id = int.Parse(ddlCategoryId.SelectedValue);
        }
        else
        {
            model.depot_category_id = 0;
        }

        if (ddlDepotId.SelectedValue != "")
        {
            model.depot_id = int.Parse(ddlDepotId.SelectedValue);
        }
        else
        {
            model.depot_id = 0;
        }

        //检测用户名是否重复
        if (model.Exists(txtUserName.Text.Trim()))
        {
            mym.JscriptMsg(this.Page, "用户名已经存在，请更换！", "", "Error");
            return false;
        }
        model.user_name = txtUserName.Text.Trim();

        model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        model.real_name = txtRealName.Text.Trim();
        model.add_time = DateTime.Now;
        model.mobile = txtmobile.Text.Trim();
        model.remark = txtremark.Text.Trim();


        if (cbIsLock.Checked == true)
        {
            model.is_lock = 1;
        }
        else
        {
            model.is_lock = 2;
        }
        if (model.Add() > 0)
        {
            mym.AddAdminLog("增加", "添加用户：" + txtRealName.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ps_manager model = new ps_manager();
        model.GetModel(_id);

        model.role_id = int.Parse(ddlRoleId.SelectedValue);
        if (ddlCategoryId.SelectedValue != "")
        {
            model.depot_category_id = int.Parse(ddlCategoryId.SelectedValue);
        }
        else
        {
            model.depot_category_id = 0;
        }

        if (ddlDepotId.SelectedValue != "")
        {
            model.depot_id = int.Parse(ddlDepotId.SelectedValue);
        }
        else
        {
            model.depot_id = 0;
        }

        //检测用户名是否重复
        if (model.ExistsE(txtUserName.Text.Trim(), _id))
        {
            mym.JscriptMsg(this.Page, "用户名已经存在，请更换！", "", "Error");
            return false;
        }
        model.user_name = txtUserName.Text.Trim();

        //判断密码是否更改
        if (txtPassword.Text.Trim() != defaultpassword)
        {
            model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        }
        model.real_name = txtRealName.Text.Trim();
        //model.add_time = DateTime.Now;
        model.mobile = txtmobile.Text.Trim();
        model.remark = txtremark.Text.Trim();


        if (cbIsLock.Checked == true)
        {
            model.is_lock = 1;
        }
        else
        {
            model.is_lock = 2;
        }

        if (model.Update())
        {
            mym.AddAdminLog("修改", "修改用户:" + txtRealName.Text); //记录日志
            result = true;
        }

        return result;
    }
    #endregion




    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            if (!DoEdit(this.id))
            {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "修改用户信息成功！", Utils.CombUrlTxt("manager_list.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //添加
        {
            if (!DoAdd())
            {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "添加用户信息成功！", "manager_list.aspx", "Success");
        }
    }

    //筛选角色
    protected void ddlRoleId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoleId.SelectedValue != "")
        {

            if (Convert.ToInt32(ddlRoleId.SelectedValue) == 2)
            {
                bm.Visible = true;
                md.Visible = true;
                CategoryBind(0); //绑定地区
                this.ddlDepotId.Items.Clear();
                this.ddlDepotId.Items.Add(new ListItem("请选择所属门店...", ""));
            }
        }
    }

    //筛选地区
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategoryId.SelectedValue != "")
        {
            DepotBind(Convert.ToInt32(ddlCategoryId.SelectedValue));
        }
        else
        {
            this.ddlDepotId.Items.Clear();
            this.ddlDepotId.Items.Add(new ListItem("请选择所属门店...", ""));
        }
    }
}
