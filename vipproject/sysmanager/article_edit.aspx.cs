using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_article_edit : System.Web.UI.Page
{
    protected int page;
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
        int nav_id = 31;
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
                ShowInfo(this.id);
            }
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {

        ps_article model = new ps_article();
        model.GetModel(_id);
        txttitle.Text = model.title;
        txtContent.Value = model.content;
        txtAddTime.Text = Convert.ToDateTime(model.add_time).ToString("yyyy-MM-dd HH:mm:ss");
        txtSortId.Text = model.sort_id.ToString();
        if (model.status == 1)
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
        ps_article model = new ps_article();

        model.title = txttitle.Text.Trim();
        model.content = txtContent.Value;
        model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        if (cbIsLock.Checked == true)
        {
            model.status = 1;
        }
        else
        {
            model.status = 2;
        }
        if (model.Add() > 0)
        {
            mym.AddAdminLog("增加", "添加通知公告：" + txttitle.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ps_article model = new ps_article();
        model.GetModel(_id);

        model.title = txttitle.Text.Trim();
        model.content = txtContent.Value;
        model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
        model.sort_id = int.Parse(txtSortId.Text.Trim());
        if (cbIsLock.Checked == true)
        {
            model.status = 1;
        }
        else
        {
            model.status = 2;
        }
        if (model.Update())
        {
            mym.AddAdminLog("修改", "修改通知公告:" + txttitle.Text); //记录日志
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
            mym.JscriptMsg(this.Page, "修改通知公告成功！", Utils.CombUrlTxt("article_list.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //添加
        {
            if (!DoAdd())
            {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "添加通知公告成功！", "article_list.aspx", "Success");
        }
    }
}