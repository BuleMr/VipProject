using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class home : System.Web.UI.Page
{
    protected string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }

        if (!IsPostBack)
        {
            noticeBind();//通知公告
            MDuserBind();//门店会员排行

        }
    }

    /* http://jingyan.baidu.com/article/ab69b270b0cc3d2ca7189fde.html */
    #region 门店会员排行=================================
    protected void MDuserBind()
    {

        ps_users bll = new ps_users();

        this.rptList_salesTop.DataSource = bll.GetListSql("select top 10 depot_id,zongpoint,zongcount,zongexp from (select depot_id,sum(point) as zongpoint ,count(id) as zongcount ,sum(exp) as zongexp from [ps_users]  group by depot_id) a order by a.zongcount desc");
        this.rptList_salesTop.DataBind();

        this.rptList_salesTop_price.DataSource = bll.GetListSql("select top 10 depot_id,zongpoint,zongcount,zongexp from (select depot_id,sum(point) as zongpoint ,count(id) as zongcount ,sum(exp) as zongexp from [ps_users]  group by depot_id) a order by a.zongcount desc");
        this.rptList_salesTop_price.DataBind();
    }
    #endregion

    #region 绑定通知公告=================================
    protected void noticeBind()
    {
        ps_article bll = new ps_article();
        this.rptList_notice.DataSource = bll.GetList(13, " status=1 ", " sort_id asc, add_time desc");
        this.rptList_notice.DataBind();
    }
    #endregion


}
