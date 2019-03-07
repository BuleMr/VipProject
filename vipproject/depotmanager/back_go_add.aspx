<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="back_go_add.aspx.cs" Inherits="depotmanager_back_go_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>增加消费次数</title>
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../JS/layout.js"></script>
    <script type="text/javascript" src="../JS/pinyin.js"></script>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
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
                <li><a href="depot_manager.aspx">会员管理</a></li>
                <li><a href="#">增加消费次数</a></li>
            </ul>
        </div>

        <div class="formbody">
            <div class="formtitle"><span>增加消费次数</span></div>
            <!--/会员信息-->
            <div class="tab-content">
                <dl>
                    <dt>增加消费次数</dt>
                    <dd>
                        <asp:TextBox ID="txtnum" runat="server" CssClass="input small" datatype="n" sucmsg=" " MaxLength="8"></asp:TextBox>
                        <span class="Validform_checktip">*</span></dd>
                </dl>
                <dl>
                    <dt>当前消费次数</dt>
                    <dd>
                        <asp:Literal ID="txtExp" runat="server"></asp:Literal>
                    </dd>
                </dl>
                <dl>
                    <dt>积分</dt>
                    <dd>
                        <asp:Literal ID="txtPoint" runat="server"></asp:Literal>
                    </dd>
                </dl>
                <dl>
                    <dt>会员卡号</dt>
                    <dd>
                        <asp:Literal ID="txtUserName" runat="server"></asp:Literal>

                    </dd>
                </dl>
                <dl>
                    <dt>会员级别</dt>
                    <dd>
                        <asp:Literal ID="ddlproduct_category_id" runat="server"></asp:Literal>


                    </dd>
                </dl>

                <dl>
                    <dt>会员姓名</dt>
                    <dd>
                        <asp:Literal ID="txtNickName" runat="server"></asp:Literal>

                    </dd>
                </dl>
                <dl>
                    <dt>证件号码</dt>
                    <dd>
                        <asp:Literal ID="txtsfz" runat="server"></asp:Literal>

                    </dd>
                </dl>
                <dl>
                    <dt>性别</dt>
                    <dd>
                        <asp:Literal ID="rblSex" runat="server"></asp:Literal>

                    </dd>
                </dl>
                <dl>
                    <dt>生日日期</dt>
                    <dd>

                        <asp:Literal ID="txtBirthday" runat="server"></asp:Literal>


                    </dd>
                </dl>
                <dl>
                    <dt>手机号码</dt>
                    <dd>
                        <asp:Literal ID="txtMobile" runat="server"></asp:Literal>
                    </dd>
                </dl>
                <dl>
                    <dt>固话号码</dt>
                    <dd>
                        <asp:Literal ID="txtTelphone" runat="server"></asp:Literal></dd>
                </dl>
                <dl>
                    <dt>QQ号码</dt>
                    <dd>
                        <asp:Literal ID="txtQQ" runat="server"></asp:Literal></dd>
                </dl>
                <dl>
                    <dt>邮箱账号</dt>
                    <dd>
                        <asp:Literal ID="txtEmail" runat="server"></asp:Literal>
                    </dd>
                </dl>
                <dl>
                    <dt>地址</dt>
                    <dd>
                        <asp:Literal ID="txtAddress" runat="server"></asp:Literal></dd>
                </dl>

                <dl>
                    <dt>会员录入时间</dt>
                    <dd>
                        <asp:Literal ID="LitTime" runat="server"></asp:Literal>
                    </dd>
                </dl>
                <dl>
                    <dt>会员录入人</dt>
                    <dd>
                        <asp:Literal ID="LitMid" runat="server"></asp:Literal>
                    </dd>
                </dl>


            </div>
            <!--/会员信息-->
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


