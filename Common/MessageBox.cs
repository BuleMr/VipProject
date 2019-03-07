using System;
using System.Text;

/// <summary>
/// MessageBox 的摘要说明
/// </summary>
public class MessageBox
{
    public MessageBox()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 显示消息提示对话框
    /// </summary>
    /// <param name="page">当前页面指针，一般为this</param>
    /// <param name="msg">提示信息</param>
    public static void Show(System.Web.UI.Page page, string msg)
    {
        page.RegisterStartupScript("message", "<script language='javascript' defer>win.alert('" + msg.ToString() + "',null,null,'提示');</script>");
    }
    public static void alert(System.Web.UI.Page page, string msg)
    {
        page.RegisterStartupScript("message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
    }
    public static void errorShow(System.Web.UI.Page page, string msg)
    {
        page.RegisterStartupScript("message", "<script language='javascript' defer>win.errorInfo('" + msg.ToString() + "',null,null,'提示');</script>");
    }
    public static void succeedShow(System.Web.UI.Page page, string msg)
    {
        page.RegisterStartupScript("message", "<script language='javascript' defer>win.succeedInfo('" + msg.ToString() + "',null,null,'提示');</script>");
    }
    public static void succeedTZShow(System.Web.UI.Page page, string msg, string tzpage)
    {
        page.RegisterStartupScript("message", "<script language='javascript' defer>alert('" + msg.ToString() + "');window.open( '" + tzpage.ToString() + "',target= 'main');</script>");
    }
    public static void confirmShow(System.Web.UI.Page page, string msg)
    {
        page.RegisterStartupScript("message", "<script language='javascript' defer>win.confirmInfo('" + msg.ToString() + "',null,null,'提示');</script>");
    }
    public static void ResponseScript(System.Web.UI.Page page, string script)
    {
        page.RegisterStartupScript("message", "<script language='javascript' defer>" + script + "</script>");
    }
    public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
    {
        StringBuilder Builder = new StringBuilder();
        Builder.Append("<script language='javascript' defer>");
        Builder.AppendFormat("alert('{0}');", msg);
        Builder.AppendFormat("top.location.href='{0}'", url);
        Builder.Append("</script>");
        page.RegisterStartupScript("message", Builder.ToString());

    }
}
