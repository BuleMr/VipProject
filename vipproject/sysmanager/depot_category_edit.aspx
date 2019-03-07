<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="depot_category_edit.aspx.cs" Inherits="sysmanager_depot_category_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑地区</title>
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
                <li><a href="depot_category_list.aspx">地区管理</a></li>
                <li><a href="#">编辑地区</a></li>
            </ul>
        </div>

        <div class="formbody">
            <div class="formtitle"><span>地区信息</span></div>
            <!--/地区信息-->
            <div class="tab-content">

                <dl>
                    <dt>地区名称</dt>
                    <dd>
                        <asp:TextBox ID="txttitle" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
                        <span class="Validform_checktip">*</span></dd>
                </dl>
                <dl>
                    <dt>排序数字</dt>
                    <dd>
                        <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">1</asp:TextBox>
                        <span class="Validform_checktip">*数字，越小越向前</span>
                    </dd>
                </dl>
                <dl>
                    <dt>备注</dt>
                    <dd>
                        <asp:TextBox ID="txtremark" runat="server" CssClass="input normal"></asp:TextBox></dd>
                </dl>
            </div>
            <!--/地区信息-->

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
