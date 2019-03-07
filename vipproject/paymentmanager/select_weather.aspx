<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select_weather.aspx.cs" Inherits="paymentmanager_select_weather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查询天气</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/layout.js"></script>
    <script type="text/javascript" src="../JS/pinyin.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="formbody">
            <div class="formtitle"><span>天气信息</span></div>
            <!--查询信息-->
            <div class="tab-content">
                <dl>
                    <dt>请输入城市名称：</dt>
                    <dd>
                        <asp:TextBox ID="txtcity" CssClass="input normal" runat="server" sucmsg=" " ></asp:TextBox>
                        <span class="Validform_checktip">*如 ：上海</span>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click"  />
                    </dd>
                </dl>
                <dl>
                    <dt>天气概况 ：</dt>
                    <dd>
                        <asp:Label ID="lbtianqi" CssClass="input normal" runat="server" style="" BorderColor="Red" Text=""></asp:Label>
                    </dd>
                </dl>
                <dl>
                    <dt>天气实况 ：</dt>
                    <dd>
                        <asp:TextBox ID="txtcityweather" CssClass="input normal" runat="server" TextMode="MultiLine" ></asp:TextBox>
                    </dd>
                </dl>
            </div>
        </div>
    </form>
</body>
</html>
