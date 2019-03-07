using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class depotmanager_product_add : System.Web.UI.Page
{
    ManagePage mym = new ManagePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登陆
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../index.aspx'</script>");
            Response.End();
        }
        //判断权限
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);
        int nav_id = 5;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            QDBind();
            Focus myFocus = new Focus();
            myFocus.SetEnterControl(this.txtUserName);
            myFocus.SetFocus(txtUserName.Page, "txtUserName");
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

    #region 增加操作=================================
    private bool DoAdd()
    {

        ps_users model = new ps_users();

        model.group_id = int.Parse(ddlproduct_category_id.SelectedValue);

        model.status = 0;
        //检测会员卡号是否重复
        if (model.Exists(txtUserName.Text.Trim()))
        {
            return false;
        }
        model.user_name = Utils.DropHTML(txtUserName.Text.Trim());

        model.password = "888888";
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
        model.depot_id = Convert.ToInt32(Session["DepotID"]);
        if (model.Add() > 0)
        {
            mym.AddAdminLog("新增会员", "新增会员，会员卡号：" + txtUserName.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!DoAdd())
        {
            mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
            return;
        }
        mym.JscriptMsg(this.Page, "增加新会员成功！", "", "Success");


        this.txtUserName.Text = "";
        this.txtEmail.Text = "";
        this.txtNickName.Text = "";
        this.txtsfz.Text = "";
        this.txtBirthday.Text = "";

        this.txtTelphone.Text = "";
        this.txtMobile.Text = "";
        this.txtQQ.Text = "";
        this.txtAddress.Text = "";
        this.txtPoint.Text = "";
        this.txtExp.Text = "";
        this.txtMobile.Text = "";
    }
}
