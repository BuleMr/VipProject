<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_info.aspx.cs" Inherits="sysmanager_my_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的信息</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../JS/layout.js"></script>
    <script type="text/javascript" src="../JS/pinyin.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../home.aspx">首页</a></li>
                <li><a href="#">我的信息</a></li>
            </ul>
        </div>

        <div class="formbody">
            <div class="formtitle"><span>我的信息</span></div>

            <!--/我的信息-->
            <div class="tab-content">
                <dl>
                    <dl>
                        <dt>真实姓名</dt>
                        <dd>
                            <asp:Literal ID="Litreal_name" runat="server"></asp:Literal></dd>
                    </dl>

                    <dl>
                        <dt>登录账号</dt>
                        <dd>
                            <asp:Literal ID="Lituser_name" runat="server"></asp:Literal></dd>
                    </dl>

                    <dl>
                        <dt>旧登录密码</dt>
                        <dd>
                            <asp:TextBox ID="txtOldPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*4-20" nullmsg="请输入旧密码" errormsg="密码范围在6-20位之间" sucmsg=" "></asp:TextBox>
                            <span class="Validform_checktip">*</span></dd>
                    </dl>

                    <dl>
                        <dt>新登录密码</dt>
                        <dd>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="请输入新密码" errormsg="密码范围在6-20位之间" sucmsg=" "></asp:TextBox>
                            <span class="Validform_checktip">*</span></dd>
                    </dl>

                    <dl>
                        <dt>新确认密码</dt>
                        <dd>
                            <asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="请再输入一次新密码" errormsg="两次输入的密码不一致" sucmsg=" "></asp:TextBox>
                            <span class="Validform_checktip">*</span></dd>
                    </dl>

                    <dl>
                        <dt>联系手机</dt>
                        <dd>
                            <asp:TextBox ID="txtmobile" runat="server" CssClass="input normal"></asp:TextBox></dd>
                    </dl>

                    <dl id="bmxx" runat="server" visible="false">
                        <dt>所属地区</dt>
                        <dd>
                            <asp:Literal ID="Litdepot_category_name" runat="server"></asp:Literal></dd>
                    </dl>
                    <div id="mdxx" runat="server" visible="false">

                        <dl>
                            <dt>所属门店</dt>
                            <dd>
                                <asp:Literal ID="Litdepotname" runat="server"></asp:Literal></dd>
                        </dl>

                        <dl>
                            <dt>联系人姓名</dt>
                            <dd>
                                <asp:Literal ID="Litcontact_name" runat="server"></asp:Literal></dd>
                        </dl>

                        <dl id="tel" runat="server" visible="false">
                            <dt>联系电话</dt>
                            <dd>
                                <asp:Literal ID="Litcontact_tel" runat="server"></asp:Literal></dd>
                        </dl>

                        <dl>
                            <dt>门店地址</dt>
                            <dd>
                                <asp:TextBox ID="txtcontact_address" runat="server" CssClass="input normal"></asp:TextBox><asp:Literal ID="Litdepot_id" runat="server" Visible="false"></asp:Literal></dd>
                        </dl>
                    </div>
            </div>
            <!--/我的信息-->
        </div>

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>

