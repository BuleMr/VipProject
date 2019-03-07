using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sysmanager_depot_category_list : System.Web.UI.Page
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
        int nav_id = 27;
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
        ps_depot_category bll = new ps_depot_category();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
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
        if (int.TryParse(Utils.GetCookie("depot_category_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}", txtKeywords.Text));
    }

    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ps_depot_category bll = new ps_depot_category();
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

        mym.JscriptMsg(this.Page, " 排序保存成功", Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");
    }

    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("depot_category_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}", this.keywords));
    }

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_depot_category bll = new ps_depot_category();
        bll.GetModel(caId);
        string title = bll.title;
        ps_depot bllpp = new ps_depot();
        bllpp.category_id = caId;
        if (!bllpp.ExistsBM())//查找是否存在下级门店
        {
            bll.Delete(caId);
            mym.AddAdminLog("删除", "删除地区：" + title + ""); //记录日志
            mym.JscriptMsg(this.Page, " 成功删除地区：" + title + "", Utils.CombUrlTxt("depot_category_list.aspx", "keywords={0}&page={1}", this.keywords, this.page.ToString()), "Success");
        }
        else
        {
            mym.JscriptMsg(this.Page, "有门店属于该地区，不能删除！", "", "Error");
            return;
        }
    }
}
