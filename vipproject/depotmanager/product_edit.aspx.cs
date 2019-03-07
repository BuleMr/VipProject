using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class depotmanager_product_edit : System.Web.UI.Page
{
    protected int page;
    private string action = ""; //操作类型
    protected string dw = ""; //计量单位
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
        int nav_id = 11;
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
        if (!Page.IsPostBack)
        {
            if (action == "Edit") //修改
            {
                QDBind();
                ShowInfo(this.id);
                //Focus myFocus = new Focus();
                //myFocus.SetEnterControl(this.txtexp);
                //myFocus.SetFocus(txtexp.Page, "txtexp");
            }
        }
    }


    #region 绑定会员级别=================================
    private void QDBind()
    {
        ps_user_groups bll = new ps_user_groups();
        DataTable dt = bll.GetList("1=1 order by sort_id").Tables[0];
        this.ddlproduct_category_id.Items.Clear();
        this.ddlproduct_category_id.Items.Add(new ListItem("请选择会员级别...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlproduct_category_id.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 赋值操作=====================================
    private void ShowInfo(int _id)
    {
        ps_users model1 = new ps_users();
        model1.GetModel(_id);

        this.ddlproduct_category_id.SelectedValue = model1.group_id.ToString();

        this.txtUserName.Text = model1.user_name;
        this.txtEmail.Text = model1.email;
        this.txtNickName.Text = model1.nick_name;
        this.txtsfz.Text = model1.sfz;
        this.txtBirthday.Text = Convert.ToDateTime(model1.birthday).ToString("d");
        this.rblSex.SelectedValue = model1.sex;
        this.txtTelphone.Text = model1.telphone;
        this.txtMobile.Text = model1.mobile;
        this.txtQQ.Text = model1.qq;
        this.txtAddress.Text = model1.address;
        this.txtPoint.Text = model1.point.ToString();
        this.txtExp.Text = model1.exp.ToString();
        this.txtMobile.Text = model1.mobile;
    }
    #endregion

    #region 修改操作=====================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        ps_users model = new ps_users();
        model.GetModel(_id);

        model.group_id = int.Parse(ddlproduct_category_id.SelectedValue);
        //检测会员卡号是否重复
        if (model.ExistsE(txtUserName.Text.Trim(), _id))
        {
            mym.JscriptMsg(this.Page, "会员卡号已经存在，请更换！", "", "Error");
            return false;
        }

        model.user_name = Utils.DropHTML(txtUserName.Text.Trim());

        model.email = Utils.DropHTML(txtEmail.Text);
        model.nick_name = Utils.DropHTML(txtNickName.Text);
        model.sfz = Utils.DropHTML(txtsfz.Text);
        model.sex = rblSex.SelectedValue;
        DateTime _birthday;
        if (DateTime.TryParse(txtBirthday.Text.Trim(), out _birthday))
        {
            model.birthday = _birthday;
        }
        model.telphone = Utils.DropHTML(txtTelphone.Text.Trim());
        model.mobile = Utils.DropHTML(txtMobile.Text.Trim());
        model.qq = Utils.DropHTML(txtQQ.Text);
        model.address = Utils.DropHTML(txtAddress.Text.Trim());

        model.point = int.Parse(txtPoint.Text.Trim());
        model.exp = int.Parse(txtExp.Text.Trim());
        model.reg_time = DateTime.Now;
        model.m_id = Convert.ToInt32(Session["AID"]);

        if (model.Update())
        {
            mym.AddAdminLog("修改会员", "修改会员，会员卡号：" + txtUserName.Text); //记录日志
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
            mym.JscriptMsg(this.Page, "修改会员信息成功！", Utils.CombUrlTxt("depot_manager.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //发生错误
        {
            mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
            return;
        }
    }
}
