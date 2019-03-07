using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class top : System.Web.UI.Page
{
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
            Lit_Name.Text = Session["RealName"].ToString();
        }
    }
    //安全退出
    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("AdminName", "AoXiang", -14400);
        Utils.WriteCookie("RoleID", "AoXiang", -14400);
        Utils.WriteCookie("AID", "AoXiang", -14400);
        Utils.WriteCookie("RealName", "AoXiang", -14400);
        Utils.WriteCookie("DepotID", "AoXiang", -14400);

        Session["RememberName"] = null;
        Session["AdminName"] = null;
        Session["RoleID"] = null;
        Session["AID"] = null;
        Session["RealName"] = null;
        Session["DepotID"] = null;

        Response.Write("<script>parent.location.href='index.aspx'</script>");
        Response.End();
    }
}
