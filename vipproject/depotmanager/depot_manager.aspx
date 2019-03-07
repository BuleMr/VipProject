<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="depot_manager.aspx.cs" Inherits="depotmanager_depot_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会员管理</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../JS/layout.js"></script>
    <script type="text/javascript" src="../JS/lhgcore.min.js"></script>
    <script type="text/javascript" src="../JS/lhgcalendar.min.js"></script>
    <script type="text/javascript">
        J(function () {
            J('#txtstart_time').calendar({ btnBar: true });
            J('#txtstop_time').calendar({ btnBar: true });
        });

        function opdg(s_type, s_url) {
            var t_width, t_height, t_title, t_url, t_id;
            t_id = 'w_1';
            switch (s_type) {
                case 'info':
                    t_width = 1100;
                    t_height = 560;
                    t_title = '查看会员信息';
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
            <span>位置:</span>
            <ul class="placeul">
                <li><a href="../home.aspx">首页</a></li>
                <li><a href="#">会员管理</a></li>
            </ul>
        </div>
        <div class="rightinfo">
            <dl class="seachform">
                <dd>
                    <label>卡号</label><span class="single-select"><asp:TextBox ID="txtNote_no" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>
                <dd>
                    <label>姓名</label><span class="single-select"><asp:TextBox ID="txtnick_name" runat="server" Width="70" CssClass="scinput"></asp:TextBox></span></dd>
                <dd>
                    <label>证件号</label><span class="single-select"><asp:TextBox ID="txtsfz" runat="server" Width="160" CssClass="scinput"></asp:TextBox></span></dd>
                <dd>
                    <label>手机号</label><span class="single-select"><asp:TextBox ID="txtmobile" runat="server" Width="100" CssClass="scinput" MaxLength="11"></asp:TextBox></span></dd>
                <dd>
                    <label>会员级别</label>
                    <span class="rule-single-select">
                        <asp:DropDownList ID="ddlproduct_category_id" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlproduct_category_id_SelectedIndexChanged">
                        </asp:DropDownList>
                    </span>
                </dd>

                <dd class="cx">
                    <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" OnClick="btnSearch_Click" Text="查询"></asp:Button>

                </dd>
                <dd class="toolbar1">
                    <asp:LinkButton ID="btnExport" runat="server" CssClass="save" OnClick="btnExport_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton>
                </dd>
            </dl>
            <!--列表-->
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table class="tablelist">
                        <thead>
                            <tr>
                                <th width="50px;">序号</th>
                                <th>会员卡号</th>
                                <th>会员级别</th>
                                <th>会员姓名</th>
                                <th>性别</th>
                                <th>证件号</th>
                                <th>邮箱</th>
                                <th width="80px;">手机号码</th>
                                <th width="80px;">生日</th>
                                <th width="60px;">消费次数</th>
                                <th width="60px;">积分</th>
                                <th width="380px;">操作</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
                        <td><%# Eval("user_name")%></td>

                        <td><%#new ps_user_groups().GetTitle(Convert.ToInt32(Eval("group_id")))%></td>
                        <td><%# Eval("nick_name")%></td>
                        <td><%# Eval("sex")%></td>
                        <td><%# Eval("sfz")%></td>
                        <td><%# Eval("email")%></td>
                        <td><%# Eval("mobile")%></td>
                        <td><%#string.Format("{0:d}", Eval("birthday"))%></td>
                        <td><%# Eval("exp")%></td>
                        <td><%# MyZF(Eval("point"))%></td>

                        <td>
                            <a href="javascript:opdg('info','product_info.aspx?id=<%#Eval("id")%>');" class="tablelink">查看</a> 
                             &nbsp;&nbsp;
                            <a href="back_go_add.aspx?action=Edit&id=<%#Eval("id")%>&page=<%=page%>" class="tablelink"><font color="green">[增加消费次数]</font></a>&nbsp;&nbsp;
                            <a href="remove_add_add.aspx?action=Edit&id=<%#Eval("id")%>&page=<%=page%>" class="tablelink"><font color="green">[增减积分]</font></a>&nbsp;&nbsp;

                            <a href="product_edit.aspx?action=Edit&id=<%#Eval("id")%>&page=<%=page%>" class="tablelink">
                                <font color ="#066D96">[修改]</font>
                                <%--<%# Convert.ToInt32(Session["AID"]) == 1 ? "<font color =#066D96>[修改]</font>" : ""%>--%>

                            </a>&nbsp;&nbsp;

                            <asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('是否真的要删除该会员？')" OnClick="lbtnDelCa_Click">
                                <font color ="red">[删除]</font>
                                <%--<%# Convert.ToInt32(Session["AID"]) == 1 ? "<font color =red>[删除]</font>" : ""%>--%>

                            </asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\"><font color=red><font color=red>暂无记录</font></font></td></tr>" : ""%>
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
