<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎登录会员综合管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery-1.8.2.min.js"></script>

    <script type="text/javascript">
        $(function () {
            //检测IE
            if ('undefined' == typeof (document.body.style.maxHeight)) {
                window.location.href = 'ie6update.html';
            }
        });
        $(function () {
            //得到焦点
            $("#txtPassword").focus(function () {
                $("#left_hand").animate({
                    left: "150",
                    top: " -38"
                }, {
                    step: function () {
                        if (parseInt($("#left_hand").css("left")) > 140) {
                            $("#left_hand").attr("class", "left_hand");
                        }
                    }
                }, 2000);
                $("#right_hand").animate({
                    right: "-64",
                    top: "-38px"
                }, {
                    step: function () {
                        if (parseInt($("#right_hand").css("right")) > -70) {
                            $("#right_hand").attr("class", "right_hand");
                        }
                    }
                }, 2000);
            });
            //失去焦点
            $("#txtPassword").blur(function () {
                $("#left_hand").attr("class", "initial_left_hand");
                $("#left_hand").attr("style", "left:100px;top:-12px;");
                $("#right_hand").attr("class", "initial_right_hand");
                $("#right_hand").attr("style", "right:-112px;top:-12px");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top_div">
            <h1>欢迎登录会员综合管理系统</h1>
        </div>
        <div style="width: 400px; height: 200px; margin: auto auto; background: #ffffff; text-align: center; margin-top: -100px; border: 1px solid #e7e7e7">
            <div style="width: 165px; height: 96px; position: absolute">
                <div class="tou"></div>
                <div id="left_hand" class="initial_left_hand"></div>
                <div id="right_hand" class="initial_right_hand"></div>
            </div>

            <p style="padding: 30px 0px 10px 0px; position: relative;">
                <span class="u_logo"></span>
                <input name="txtUserName" id="txtUserName" runat="server" type="text" class="login" value="" placeholder="请输入用户名"/>
            </p>
            <p style="position: relative;">
                <span class="p_logo"></span>
                <input name="txtPassword" id="txtPassword" runat="server" type="password" class="login" value="" placeholder="请输入密码"/>
            </p>

            <div style="height: 50px; line-height: 50px; margin-top: 30px; border-top: 1px solid #e7e7e7;">
                <p style="margin: 0px 35px 20px 45px;">
                    <span style="float: right">
                        <asp:Button ID="btnSubmit" Style="background: #008ead; padding: 7px 10px; border-radius: 4px; border: 1px solid #1a7598; color: #FFF; font-weight: bold;" runat="server" Text="登 录" CssClass="loginbtn" OnClick="btnSubmit_Click" OnClientClick="return Check();" />
                    </span>
                </p>
            </div>

        </div>

        <div style="position: fixed; bottom: 0px; text-align: center; width: 100%;">
            Copyright ©2015 <a style="margin-left: 10px; color: #000000; text-decoration: underline" href="http://www.codefamer.com">http://www.codefamer.com</a>
        </div>
    </form>
</body>
</html>

<%--<body style="background-color: #1c77ac; background-image: url(images/light.png); background-repeat: no-repeat; background-position: center top; overflow: hidden;">
    <form id="form1" runat="server">
        <div id="mainBody">
            <div id="cloud1" class="cloud"></div>
            <div id="cloud2" class="cloud"></div>
        </div>

        <div class="logintop">
            <span>欢迎登会员综合管理系统</span>
        </div>

        <div class="loginbody">
            <span class="systemlogo"></span>
            <div class="loginbox">
                <ul>
                    <li>
                        <input name="txtUserName" ID="txtUserName" runat="server" type="text" class="loginuser" value="" /></li>
                    <li>
                        <input name="txtPassword" ID="txtPassword" runat="server" type="password" class="loginpwd" value="" /></li>
                    <li>
                        <asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="loginbtn" OnClick="btnSubmit_Click" OnClientClick="return Check();" /></li>
                </ul>
            </div>
        </div>
        <div class="loginbm">版权所有 街角盒饭&copy;   &nbsp;&nbsp;&nbsp;&nbsp;技术支持：  &nbsp;&nbsp;地址： &nbsp;&nbsp;电话：</div>
    </form>
</body>
</html>--%>
