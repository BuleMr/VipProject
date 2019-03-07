<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_rep.aspx.cs" Inherits="depotmanager_product_rep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员信息报表</title>
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
                <td height="30" colspan="14" align="center" bgcolor="#FFFFFF">
                    <span style="font-size: 18px; line-height: 25px;"><b>会员信息表</b></span></td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" bgcolor="#C0C0C0"><b>序号</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>会员卡号</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>会员级别</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>会员姓名</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>性别</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>证件号</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>手机号码</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>生日</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>消费次数</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>积分</b></td>

                <td align="center" bgcolor="#C0C0C0"><b>固话号码 </b></td>
                <td align="center" bgcolor="#C0C0C0"><b>QQ号码</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>邮箱账号 </b></td>
                <td align="center" bgcolor="#C0C0C0"><b>地址</b></td>
            </tr>
            <asp:Repeater ID="repCategory" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#FFFFFF">
                        <td align="center"><%# Container.ItemIndex + 1%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("user_name")%></td>
                        <td><%#new ps_user_groups().GetTitle(Convert.ToInt32(Eval("group_id")))%></td>
                        <td><%# Eval("nick_name")%></td>
                        <td><%# Eval("sex")%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("sfz")%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("mobile")%></td>
                        <td align="center"><%#string.Format("{0:d}", Eval("birthday"))%></td>
                        <td align="center"><%# Eval("exp")%></td>
                        <td align="center"><%# MyZF(Eval("point"))%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("telphone")%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("qq")%></td>
                        <td align="center"><%# Eval("email")%></td>
                        <td align="center"><%# Eval("address")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </form>
</body>
</html>

