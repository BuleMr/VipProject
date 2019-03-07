<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager_rep.aspx.cs" Inherits="sysmanager_manager_rep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户信息报表</title>
    <style type="text/css">
        body {
            OVERFLOW: SCROLL;
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            font-family: "宋体";
            font-size: 14px;
            line-height: 20px;
            color: #000000;
        }

        table {
            font-family: "宋体";
            font-size: 14px;
            line-height: 20px;
            color: #000000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="98%" border="1" align="center" cellpadding="5" cellspacing="1" bgcolor="#CACACA">
            <tr bgcolor="#EAEAEA">
                <td height="30" colspan="8" align="center" bgcolor="#FFFFFF">
                    <span style="font-size: 18px; line-height: 25px;"><b>用户信息表</b></span></td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" bgcolor="#C0C0C0"><b>序号</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>登录账号</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>真实姓名</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>手机号</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>角色</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>所属地区</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>所属门店</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>状态</b></td>
            </tr>
            <asp:Repeater ID="repCategory" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#FFFFFF">

                        <td align="center"><%# Container.ItemIndex + 1%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("user_name")%></td>
                        <td align="center"><%# Eval("real_name")%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("mobile")%></td>
                        <td align="center"><%#new ps_manager_role().GetTitle(Convert.ToInt32(Eval("role_id")))%></td>
                        <td align="center"><%#Convert.ToInt32(Eval("depot_category_id")) == 0 ? "<font color=red>所有地区</font>" : new ps_depot_category().GetTitle(Convert.ToInt32(Eval("depot_category_id")))%></td>
                        <td align="center"><%# Convert.ToInt32(Eval("depot_id")) == 0 ? "<font color=red>下级所有门店</font>" : new ps_depot().GetTitle(Convert.ToInt32(Eval("depot_id")))%></td>
                        <td align="center"><%# Convert.ToInt32(Eval("is_lock")) == 2 ? "<font color=red>已注销</font>" : "在用"%></td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </form>
</body>
</html>

