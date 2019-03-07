<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="depot_rep.aspx.cs" Inherits="sysmanager_depot_rep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>门店信息报表</title>
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
                    <span style="font-size: 18px; line-height: 25px;"><b>门店信息表</b></span></td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" bgcolor="#C0C0C0"><b>序号</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>所属地区</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>门店名称</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>联系人姓名</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>联系电话</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>门店地址</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>状态</b></td>
                <td align="center" bgcolor="#C0C0C0"><b>备注</b></td>
            </tr>
            <asp:Repeater ID="repCategory" runat="server">
                <ItemTemplate>
                    <tr bgcolor="#FFFFFF">

                        <td align="center"><%# Container.ItemIndex + 1%></td>
                        <td align="center"><%#new ps_depot_category().GetTitle(Convert.ToInt32(Eval("category_id")))%></td>
                        <td align="center"><%# Eval("title")%></td>
                        <td align="center"><%# Eval("contact_name")%></td>
                        <td align="left" style="vnd.ms-excel.numberformat: @"><%# Eval("contact_mobile")%></td>
                        <td align="center"><%# Eval("contact_address")%></td>
                        <td align="center"><%# Convert.ToInt32(Eval("status")) == 2 ? "已注销" : "在用"%></td>
                        <td align="center"><%# Eval("remark")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </form>
</body>
</html>
