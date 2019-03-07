<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>头部</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        $(function () {
            //顶部导航切换
            $(".nav li a").click(function () {
                $(".nav li a.selected").removeClass("selected")
                $(this).addClass("selected");
            })
        })

        function About() {
            $.dialog({
                width: 400,
                height: 10,
                title: '系统信息',
                max: false,
                min: false,
                content: '盒饭编译'
            });
        }
    </script>
</head>
<body style="background: url(images/topbg.gif) repeat-x;">
    <form id="form1" runat="server">
        <div class="topleft">
            <a href="main.aspx" target="_parent">
                <img src="images/logo.png" title="系统首页" /></a>
        </div>

        <ul class="nav">
            <li><a href="home.aspx" target="rightFrame" class="selected">
                <img src="images/ico01.png" title="系统首页" width="45" height="45" /><h2>系统首页</h2>
            </a></li>
            <li><a href="depotmanager/product_add.aspx" target="rightFrame">
                <img src="images/icon03.png" title="增加新会员" width="45" height="45" /><h2>增加新会员</h2>
            </a></li>
            <li><a href="depotmanager/depot_manager.aspx" target="rightFrame">
                <img src="images/icon01.png" title="会员管理" width="45" height="45" /><h2>会员管理</h2>
            </a></li>

            <li><a href="sysmanager/notice_list.aspx" target="rightFrame">
                <img src="images/i09.png" title="通知公告" width="45" height="45" /><h2>通知公告</h2>
            </a></li>
            <li><a href="sysmanager/my_info.aspx" target="rightFrame">
                <img src="images/i07.png" title="我的信息" width="45" height="45" /><h2>我的信息</h2>
            </a></li>
        </ul>

        <div class="topright">
            <ul>
                <li><a href="javascript:About();">关于</a></li>
                <li>
                    <asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click">退出</asp:LinkButton></li>
            </ul>

            <div class="user">
                <span>
                    <asp:Literal ID="Lit_Name" runat="server"></asp:Literal></span>
            </div>

        </div>
    </form>
</body>
</html>
