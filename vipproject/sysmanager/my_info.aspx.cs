using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sysmanager_my_info : System.Web.UI.Page
{
    ManagePage mym = new ManagePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../index.aspx'</script>");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            ShowInfo(Convert.ToInt32(Session["AID"]));
        }
    }


    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_manager model = new ps_manager();
        model.GetModel(_id);
        Lituser_name.Text = model.user_name;
        Litreal_name.Text = model.real_name;
        txtmobile.Text = model.mobile;
        Litdepot_id.Text = model.depot_id.ToString();

        if (Convert.ToInt32(model.depot_id) != 0)
        {
            mdxx.Visible = true;
            ps_depot model1 = new ps_depot();
            model1.GetModel(Convert.ToInt32(model.depot_id));

            Litdepotname.Text = model1.title;
            Litcontact_name.Text = model1.contact_name;
            Litcontact_tel.Text = model1.contact_mobile;
            txtcontact_address.Text = model1.contact_address;
        }

        if (Convert.ToInt32(model.depot_category_id) != 0)
        {
            bmxx.Visible = true;
            ps_depot_category model2 = new ps_depot_category();
            model2.GetModel(Convert.ToInt32(model.depot_category_id));
            Litdepot_category_name.Text = model2.title;
        }
    }
    #endregion


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ps_manager model = new ps_manager();
        model.GetModel(Convert.ToInt32(Session["AID"]));

        string userPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPassword.Text.Trim(), "MD5");
        if (userPwd != model.password)
        {
            mym.JscriptMsg(this.Page, "旧密码不正确！", "", "Warning");
            return;
        }
        if (txtPassword.Text.Trim() != txtPassword1.Text.Trim())
        {
            mym.JscriptMsg(this.Page, "两次密码不一致！", "", "Warning");
            return;
        }
        model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        model.mobile = txtmobile.Text.Trim();


        model.id = Convert.ToInt32(Session["AID"]);

        if (!model.UpdateMY())
        {
            ps_depot model1 = new ps_depot();
            model1.id = Convert.ToInt32(Litdepot_id.Text);
            model1.contact_address = txtcontact_address.Text.Trim();
            model1.UpdateAddress();

            mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
            return;
        }
        mym.AddAdminLog("修改", "修改个人信息：用户名:" + Lituser_name.Text); //记录日志
        mym.JscriptMsg(this.Page, "个人信息修改成功！请下次用新密码登陆！", "", "Success");
    }
}
