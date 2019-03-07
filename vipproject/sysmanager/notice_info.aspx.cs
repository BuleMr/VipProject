using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sysmanager_notice_info : System.Web.UI.Page
{
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

        if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
        {
            mym.JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
            return;
        }

        if (!Page.IsPostBack)
        {
            ShowInfo(this.id);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_article model = new ps_article();
        model.GetModel(_id);
        Littitle.Text = model.title;
        LitContent.Text = model.content;
        LitAddTime.Text = Convert.ToDateTime(model.add_time).ToString("yyyy-MM-dd HH:mm:ss");
        LitClickCount.Text = model.click.ToString();

        //更新浏览次数
        int click = int.Parse(model.click.ToString()) + 1;
        model.UpdateField(id, "click=" + click);

    }
    #endregion

}
