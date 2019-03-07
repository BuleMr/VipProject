<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_edit.aspx.cs" ValidateRequest="false" Inherits="sysmanager_article_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑公告</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../JS/layout.js"></script>
    <script type="text/javascript" src="../JS/pinyin.js"></script>
    <script type="text/javascript" charset="utf-8" src="../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../editor/lang/zh_CN.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化编辑器
            var editor = KindEditor.create('#txtContent', {
                width: '80%',
                height: '350px',
                resizeType: 1,
                uploadJson: '../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '../tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../home.aspx">首页</a></li>
                <li><a href="article_list.aspx">通知公告管理</a></li>
                <li><a href="#">编辑通知公告</a></li>
            </ul>
        </div>

        <div class="formbody">
            <div class="formtitle"><span>通知公告信息</span></div>
            <!--/公告信息-->
            <div class="tab-content">

                <dl>
                    <dt>公告标题</dt>
                    <dd>
                        <asp:TextBox ID="txttitle" runat="server" Width="600" CssClass="input normal" datatype="*2-100" sucmsg=" " />
                        <span class="Validform_checktip">*公告标题最多100个字符</span>
                    </dd>
                </dl>
                <dl>
                    <dt>公告内容</dt>
                    <dd>
                        <textarea id="txtContent" class="editor" style="visibility: hidden;" runat="server"></textarea>
                    </dd>
                </dl>
                <dl>
                    <dt>发布时间</dt>
                    <dd>
                        <div class="input-date">
                            <asp:TextBox ID="txtAddTime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                            <i>日期</i>
                        </div>
                        <span class="Validform_checktip">不选择默认当前发布时间</span>
                    </dd>
                </dl>
                <dl>
                    <dt>是否显示</dt>
                    <dd>
                        <div class="rule-single-checkbox">
                            <asp:CheckBox ID="cbIsLock" runat="server" Checked="True" />
                        </div>
                        <span class="Validform_checktip">*不显示该公告在系统首页不在显示</span>
                    </dd>
                </dl>
                <dl>
                    <dt>排序数字</dt>
                    <dd>
                        <asp:TextBox ID="txtSortId" runat="server" Height="25" CssClass="input small" datatype="n" sucmsg=" ">1</asp:TextBox>
                        <span class="Validform_checktip">*数字，越小越向前</span>
                    </dd>
                </dl>


            </div>
            <!--/公告信息-->

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
