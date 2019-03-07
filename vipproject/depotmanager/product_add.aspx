<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_add.aspx.cs" Inherits="depotmanager_product_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>增加新会员</title>
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../JS/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../JS/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../JS/swfupload/swfupload.queue.js"></script>
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
                <li><a href="#">增加新会员</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div id="usual1" class="usual">
                <div class="itab">
                    <ul>
                        <li><a href="product_add.aspx" class="selected">增加新会员</a></li>

                    </ul>
                </div>
                <!--增加新会员信息-->

                <div class="tab-content">
                    <dl>
                        <dt>会员卡号</dt>
                        <dd>
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="200" CssClass="input normal" datatype="*" errormsg="" ajaxurl="../tools/admin_ajax.ashx?action=code_validate" Width="300"></asp:TextBox>
                            <span class="Validform_checktip">*</span>
                        </dd>
                    </dl>
                    <dl>
                        <dt>会员级别</dt>
                        <dd>
                            <span class="rule-single-select">
                                <asp:DropDownList ID="ddlproduct_category_id" runat="server" datatype="*" errormsg="请选择会员级别" sucmsg=" "></asp:DropDownList>
                            </span>
                            <span class="Validform_checktip">*</span>
                        </dd>
                    </dl>

                    <dl>
                        <dt>会员姓名</dt>
                        <dd>
                            <asp:TextBox ID="txtNickName" runat="server" MaxLength="100" CssClass="input normal" datatype="*" errormsg="" Width="100"></asp:TextBox>
                            <span class="Validform_checktip">*</span>
                        </dd>
                    </dl>
                    <dl>
                        <dt>证件号码</dt>
                        <dd>
                            <asp:TextBox ID="txtsfz" runat="server" MaxLength="100" CssClass="input normal" datatype="*" errormsg="" Width="200"></asp:TextBox>
                            <span class="Validform_checktip">*</span>
                        </dd>
                    </dl>
                    <dl>
                        <dt>性别</dt>
                        <dd>
                            <div class="rule-multi-radio">
                                <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="保密" Selected="True">保密</asp:ListItem>
                                    <asp:ListItem Value="男">男</asp:ListItem>
                                    <asp:ListItem Value="女">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </dd>
                    </dl>
                    <dl>
                        <dt>生日日期</dt>
                        <dd>
                            <div class="input-date">
                                <asp:TextBox ID="txtBirthday" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                                <i>日期</i>
                            </div>
                            <span class="Validform_checktip">*</span>
                        </dd>
                    </dl>
                    <dl>
                        <dt>手机号码</dt>
                        <dd>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="input normal" datatype="n" errormsg="" MaxLength="11"></asp:TextBox>
                            <span class="Validform_checktip">*</span></dd>
                    </dl>
                    <dl>
                        <dt>固话号码</dt>
                        <dd>
                            <asp:TextBox ID="txtTelphone" runat="server" CssClass="input normal"></asp:TextBox></dd>
                    </dl>
                    <dl>
                        <dt>QQ号码</dt>
                        <dd>
                            <asp:TextBox ID="txtQQ" runat="server" CssClass="input normal"></asp:TextBox></dd>
                    </dl>
                    <dl>
                        <dt>邮箱账号</dt>
                        <dd>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="input normal"></asp:TextBox>
                        </dd>
                    </dl>
                    <dl>
                        <dt>地址</dt>
                        <dd>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
                    </dl>
                    <dl>
                        <dt>消费次数</dt>
                        <dd>
                            <asp:TextBox ID="txtExp" runat="server" CssClass="input small" datatype="n"
                                sucmsg=" " MaxLength="5"></asp:TextBox>
                            <span class="Validform_checktip">*</span></dd>
                    </dl>
                    <dl>
                        <dt>积分</dt>
                        <dd>
                            <asp:TextBox ID="txtPoint" runat="server" CssClass="input small"
                                datatype="n" sucmsg=" " MaxLength="5"></asp:TextBox>
                            <span class="Validform_checktip">*</span></dd>
                    </dl>
                </div>
                <!--/增加新会员信息-->
            </div>

            <!--工具栏-->
            <div class="page-footer">
                <div class="btn-list">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交保存 " CssClass="btn" OnClick="btnSubmit_Click" />
                </div>
                <div class="clear"></div>
            </div>
            <!--/工具栏-->
        </div>
    </form>
</body>
</html>
