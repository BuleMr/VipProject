<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_info.aspx.cs" Inherits="depotmanager_product_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员信息</title>
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../JS/layout.js"></script>
    <script type="text/javascript" src="../JS/pinyin.js"></script>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">


        <div class="formbody">
            <div class="formtitle"><span>会员信息</span></div>
            <!--/会员信息-->
            <div class="tab-content">


                <dl>
                    <dt>会员卡号</dt>
                    <dd>
                        <asp:Literal ID="txtUserName" runat="server"></asp:Literal>

                    </dd>
                </dl>
                <dl>
                    <dt>当前消费次数</dt>
                    <dd>
                        <asp:Literal ID="txtExp" runat="server"></asp:Literal>
                    </dd>
                </dl>
                <dl>
                    <dt>当前积分</dt>
                    <dd>
                        <asp:Literal ID="txtPoint" runat="server"></asp:Literal>
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

    </form>
</body>
</html>


