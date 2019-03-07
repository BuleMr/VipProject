using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class depotmanager_back_go_add : System.Web.UI.Page
{
    protected int page;
    private string action = ""; //操作类型
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
        //获取指定url参数值
        string _action = AXRequest.GetQueryString("action");
        //获取指定url参数的int值
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
                ShowInfo(this.id);
                Focus myFocus = new Focus();
                myFocus.SetEnterControl(this.txtnum);
                myFocus.SetFocus(txtnum.Page, "txtnum");
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_users model1 = new ps_users();
        model1.GetModel(_id);

        this.ddlproduct_category_id.Text = new ps_user_groups().GetTitle(Convert.ToInt32(model1.group_id));

        this.txtUserName.Text = model1.user_name;
        this.txtEmail.Text = model1.email;
        this.txtNickName.Text = model1.nick_name;
        this.txtsfz.Text = model1.sfz;
        this.txtBirthday.Text = Convert.ToDateTime(model1.birthday).ToString("d");
        this.rblSex.Text = model1.sex;
        this.txtTelphone.Text = model1.telphone;
        this.txtMobile.Text = model1.mobile;
        this.txtQQ.Text = model1.qq;
        this.txtAddress.Text = model1.address;
        this.txtPoint.Text = MyZF(model1.point);
        this.txtExp.Text = model1.exp.ToString();
        this.txtMobile.Text = model1.mobile;
        this.LitTime.Text = model1.reg_time.ToString();
        this.LitMid.Text = new ps_manager().GetTitle(Convert.ToInt32(model1.m_id));

    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {

        bool result = false;
        ps_users model = new ps_users();
        model.GetModel(_id);
        model.exp = int.Parse(txtExp.Text) + int.Parse(txtnum.Text);

        if (model.Update())
        {
            mym.AddAdminLog("增加消费次数", "增加消费次数" + txtnum.Text + "次，会员卡号:" + txtUserName.Text); //记录日志
            result = true;
        }

        return result;
    }
    #endregion


    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            if (!DoEdit(this.id))
            {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "增加消费次数成功！", Utils.CombUrlTxt("depot_manager.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //发生错误
        {
            mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
            return;
        }
    }

    //负数红色显示
    public string MyZF(object d)
    {
        string myNum = d.ToString();
        if (Convert.ToInt32(d.ToString()) <= 0)
        {
            myNum = "<font color=red> " + d.ToString() + "</font>";
        }
        return myNum;
    }
}
