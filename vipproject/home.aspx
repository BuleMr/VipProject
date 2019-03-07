<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统首页</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="JS/jsapi.js"></script>
    <script type="text/javascript" src="JS/corechart.js"></script>
    <script type="text/javascript" src="JS/format+zh_CN,default,corechart.I.js"></script>
    <script type="text/javascript" src="JS/jquery.gvChart-1.0.1.min.js"></script>
    <script type="text/javascript" src="JS/jquery.ba-resize.min.js"></script>
    <script type="text/javascript" src="JS/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        gvChartInit();
        $(document).ready(function () {

            $('#myTable5').gvChart({
                chartType: 'PieChart',/*PieChart饼状图，LineChart折线图*/
                gvSettings: {
                    vAxis: { title: 'No of players' },
                    hAxis: { title: 'Month' },
                    width: 1100,
                    height: 350
                }
            });
        });
    </script>

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

        function opdgss(s_type, s_url) {
            var t_width, t_height, t_title, t_url, t_id;
            t_id = 'w_1';
            switch (s_type) {
                case 'info':
                    t_width = 980;
                    t_height = 500;
                    t_title = '查询天气';
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
                <li><a href="#">系统首页</a></li>
                <li style="float: right;">
                    <a href="javascript:opdgss('info','paymentmanager/select_weather.aspx');" class="more1"><b>查询天气</b>
                    </a>
                </li>
            </ul>
        </div>
        <div class="mainbox">
            <div class="mainleft">
                <div class="leftinfo">
                    <div class="listtitle"><a href="#" class="more1">更多</a>各店会员统计</div>
                    <div class="maintj">
                        <table id='myTable5'>
                            <caption>各店会员统计</caption>
                            <thead>
                                <tr>
                                    <th></th>
                                    <asp:Repeater ID="rptList_salesTop" runat="server">
                                        <ItemTemplate>
                                            <th>
                                                <%#new ps_depot().GetTitle(Convert.ToInt32(Eval("depot_id")))%>  &nbsp;&nbsp;办卡会员总数：<%# Eval("zongcount")%> 积分总数：<%# Eval("zongpoint")%> 总消费次数：<%# Eval("zongexp")%>

                                            </th>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th></th>
                                    <asp:Repeater ID="rptList_salesTop_price" runat="server">
                                        <ItemTemplate>
                                            <td><%# Eval("zongcount")%></td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
                <!--leftinfo end-->

            </div>
            <!--mainleft end-->
            <div class="mainright">
                <div class="dflist">
                    <div class="listtitle"><a href="sysmanager/notice_list.aspx" class="more1">更多</a>通知公告</div>
                    <ul class="newlist">
                        <asp:Repeater ID="rptList_notice" runat="server">
                            <ItemTemplate>
                                <li><a href="javascript:opdg('info','sysmanager/notice_info.aspx?id=<%# Eval("id")%>');" title="<%# Eval("title")%>"><%# Eval("title").ToString().Length > 18 ? Eval("title").ToString().Substring(0, 18) + "..." : Eval("title").ToString()%></a></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%# rptList_notice.Items.Count == 0 ? "<li><font color=red>暂无记录</font></li>" : ""%>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!--mainright end-->
        </div>

    </form>
</body>
</html>
