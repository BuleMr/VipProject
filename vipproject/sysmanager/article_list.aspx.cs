using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sysmanager_article_list : System.Web.UI.Page
{
    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected string keywords = string.Empty;

    ManagePage mym = new ManagePage();

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../index.aspx'</script>");
            Response.End();
        }
        //判断权限
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);
        int nav_id = 31;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        this.keywords = AXRequest.GetQueryString("keywords");
        this.pageSize = GetPageSize(10); //每页数量
        this.page = AXRequest.GetQueryInt("page", 1);
        if (!Page.IsPostBack)
        {

            RptBind(CombSqlTxt(this.keywords), "sort_id asc,id desc");
        }
    }



    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        txtKeywords.Text = this.keywords;
        ps_article bll = new ps_article();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("article_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" title like  '%" + _keywords + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("article_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion



    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("article_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("article_list.aspx", "keywords={0}", this.keywords));
    }

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("article_list.aspx", "keywords={0}", txtKeywords.Text));
    }

    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ps_article bll = new ps_article();
        Repeater rptList = new Repeater();
        rptList = this.rptList;

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            bll.UpdateField(id, "sort_id=" + sortId.ToString());
        }
        mym.JscriptMsg(this.Page, " 排序保存成功", Utils.CombUrlTxt("article_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");
    }
    //批量删除
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int sucCount = 0; //成功数量
        int errorCount = 0; //失败数量
        ps_article bll = new ps_article();
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            if (cb.Checked)
            {
                if (bll.Delete(id))
                {
                    sucCount++;
                }
                else
                {
                    errorCount++;
                }
            }
        }
        mym.AddAdminLog("删除", "删除公告成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
        mym.JscriptMsg(this.Page, " 删除公告成功" + sucCount + "条，失败" + errorCount + "条", Utils.CombUrlTxt("article_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");
    }

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_article bll = new ps_article();
        bll.GetModel(caId);
        string title = bll.title;
        bll.Delete(caId);
        mym.AddAdminLog("删除", "删除公告：" + title + ""); //记录日志
        mym.JscriptMsg(this.Page, " 成功删除公告：" + title + "", Utils.CombUrlTxt("article_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");

    }
}
