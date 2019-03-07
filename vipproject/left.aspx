<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>左导航</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //导航切换
            $(".menuson li").click(function () {
                $(".menuson li.active").removeClass("active")
                $(this).addClass("active");
            });

            $('.title').click(function () {
                var $ul = $(this).next('ul');
                $('dd').find('ul').slideUp();
                if ($ul.is(':visible')) {
                    $(this).next('ul').slideUp();
                } else {
                    $(this).next('ul').slideDown();
                }
            });
        })
    </script>
</head>
<body style="background: #F0FFFF;">
    <form id="form1" runat="server">
        <div class="lefttop"><span></span>系统导航</div>
        <dl class="leftmenu">
            <asp:Repeater ID="repCategory" runat="server" OnItemDataBound="bsClassList">
                <ItemTemplate>
                    <dd>
                        <div class="title">
                            <span>
                                <img src="images/leftico0<%#Eval("ID")%>.png" /></span><%#Eval("Title")%>
                        </div>
                        <ul class="menuson">
                            <asp:Repeater ID="childCategory" runat="server">
                                <ItemTemplate>
                                    <li><cite></cite><a href="<%#Eval("link_url")%>" target="rightFrame"><%#Eval("Title")%></a><i></i></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </ItemTemplate>
            </asp:Repeater>
        </dl>
    </form>
</body>
</html>
