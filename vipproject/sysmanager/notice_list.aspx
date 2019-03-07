<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notice_list.aspx.cs" Inherits="sysmanager_notice_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>通知公告</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/layout.js"></script>
    <script type="text/javascript">
        function opdg(s_type, s_url) {
            var t_width, t_height, t_title, t_url, t_id;
            t_id = 'w_1';
            switch (s_type) {
                case 'info':
                    t_width = 980;
                    t_height = 500;
                    t_title = '查看通知公告';
                    t_url = s_url;
                    break;
            }
            $.dialog({
                width: t_width,
                height: t_height,
                title: t_title,
                max: false,
                content: 'url:' + t_url
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../home.aspx">首页</a></li>
                <li><a href="#">通知公告</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table class="tablelist">
                        <thead>
                            <tr>
                                <th>序号</th>
                                <th>标题</th>
                                <th>发布时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
                        <td><%# Eval("title")%></td>
                        <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
                        <td><a href="javascript:opdg('info','notice_info.aspx?id=<%#Eval("id")%>');" class="tablelink">查看</a> </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
                </FooterTemplate>
            </asp:Repeater>

            <div class="pagelist">
                <div class="l-btns">
                    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
                </div>
                <div id="PageContent" runat="server" class="default"></div>
            </div>

        </div>
    </form>
</body>
</html>

