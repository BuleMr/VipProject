using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
///ManagePage
///判断用户是否登陆成功
/// </summary>
public class ManagePage : System.Web.UI.Page
{
    public ManagePage()
    {
    }
    /// <summary>
    /// 判断管理员是否已经登录(解决Session超时问题)
    /// </summary>
    public bool IsAdminLogin()
    {
        //如果Session为Null
        if (Session["AdminName"] != null)
        {
            return true;
        }
        else
        {
            //检查Cookies
            string adminname = Utils.GetCookie("AdminName");
            if (adminname != "")
            {
                Session["RememberName"] = Utils.GetCookie("RememberName");
                Session["AdminName"] = Utils.GetCookie("AdminName");
                Session["RoleID"] = Utils.GetCookie("RoleID");
                Session["AID"] = Utils.GetCookie("AID");
                Session["RealName"] = Utils.GetCookie("RealName");
                Session["DepotID"] = Utils.GetCookie("DepotID");
                Session["DepotCatID"] = Utils.GetCookie("DepotCatID");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 写入管理日志
    /// </summary>
    /// <param name="action_type"></param>
    /// <param name="remark"></param>
    /// <returns></returns>
    public bool AddAdminLog(string action_type, string remark)
    {
           //写入日志
            ps_manager_log mylog = new ps_manager_log();
            mylog.user_id = Convert.ToInt32(Session["AID"]);
            mylog.user_name = Session["RememberName"].ToString();
            mylog.action_type = action_type;
            mylog.add_time = DateTime.Now;
            mylog.remark = remark;
            mylog.user_ip = AXRequest.GetIP();
            int newId = mylog.Add();
                   
            if (newId > 0)
            {
                return true;
            }
     
        return false;
    }


    #region JS提示============================================
    /// <summary>
    /// 添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    public void JscriptMsg(System.Web.UI.Page page,string msgtitle, string url, string msgcss)
    {
        string msbox = "jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
        page.RegisterStartupScript("message", "<script language='javascript'>"+msbox+"</script>");
        //ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    /// <summary>
    /// 带回传函数的添加编辑删除提示
    /// </summary>
    /// <param name="msgtitle">提示文字</param>
    /// <param name="url">返回地址</param>
    /// <param name="msgcss">CSS样式</param>
    /// <param name="callback">JS回调函数</param>
    public void JscriptMsg(System.Web.UI.Page page, string msgtitle, string url, string msgcss, string callback)
    {
        string msbox = "jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
        page.RegisterStartupScript("message", "<script language='javascript'>" + msbox + "</script>");
        //ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
    }
    #endregion

}