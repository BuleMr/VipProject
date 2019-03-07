<%@ WebHandler Language="C#" Class="admin_ajax" %>

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

public class admin_ajax : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string action = AXRequest.GetQueryString("action");

        switch (action)
        {
            case "manager_validate": //验证管理员用户名是否重复
                manager_validate(context);
                break;
            case "code_validate": //验证管理员用户名是否重复
                code_validate(context);
                break;
        }
    }

    #region 验证会员卡号是否重复========================
    private void manager_validate(HttpContext context)
    {
        string user_name = AXRequest.GetString("param");
        if (string.IsNullOrEmpty(user_name))
        {
            context.Response.Write("{ \"info\":\"请输入用户名\", \"status\":\"n\" }");
            return;
        }
        ps_manager bll = new ps_manager();
        if (bll.Exists(user_name))
        {
            context.Response.Write("{ \"info\":\"用户名已被占用，请更换！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"用户名可使用\", \"status\":\"y\" }");
        return;
    }
    #endregion

    #region 验证会员姓名是否重复========================
    private void code_validate(HttpContext context)
    {
        string user_name = AXRequest.GetString("param");
        if (string.IsNullOrEmpty(user_name))
        {
            context.Response.Write("{ \"info\":\"请输入会员卡号\", \"status\":\"n\" }");
            return;
        }

        ps_users bll = new ps_users();
        if (bll.Exists(user_name))
        {
            context.Response.Write("{ \"info\":\"会员卡号已被占用，请更换！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"会员卡号可使用\", \"status\":\"y\" }");
        return;
    }
    #endregion

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}