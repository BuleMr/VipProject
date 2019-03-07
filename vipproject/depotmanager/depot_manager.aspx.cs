using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class depotmanager_depot_manager : System.Web.UI.Page
{
    //分页数据
    protected int totalCount;
    protected int page;
    protected int pageSize;

    protected int product_category_id;
    protected string note_no = string.Empty;
    protected string nick_name = string.Empty;
    protected string sfz = string.Empty;
    protected string mobile = string.Empty;

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
        int nav_id = 11;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        this.product_category_id = AXRequest.GetQueryInt("product_category_id");

        this.note_no = AXRequest.GetQueryString("note_no");
        this.nick_name = AXRequest.GetQueryString("nick_name");
        this.sfz = AXRequest.GetQueryString("sfz");
        this.mobile = AXRequest.GetQueryString("mobile");

        this.pageSize = GetPageSize(10); //每页数量

        if (!Page.IsPostBack)
        {
            ZYBind();//绑定会员级别

            RptBind("id>0" + CombSqlTxt(this.product_category_id, this.note_no, this.nick_name, this.sfz, this.mobile), "reg_time desc,id desc");
        }
    }

    #region 绑定会员级别=============================
    private void ZYBind()
    {
        ps_user_groups bll = new ps_user_groups();
        DataTable dt = bll.GetList("1=1").Tables[0];
        this.ddlproduct_category_id.Items.Clear();
        this.ddlproduct_category_id.Items.Add(new ListItem("==全部==", "0"));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlproduct_category_id.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);

        if (this.product_category_id > 0)
        {
            this.ddlproduct_category_id.SelectedValue = this.product_category_id.ToString();
        }

        txtNote_no.Text = this.note_no;
        txtnick_name.Text = this.nick_name;
        txtsfz.Text = this.sfz;
        txtmobile.Text = this.mobile;
        ps_users bll = new ps_users();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}&nick_name={2}&sfz={3}&mobile={4}&page={5}", this.product_category_id.ToString(), this.note_no, this.nick_name, this.sfz, this.mobile, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _product_category_id, string _note_no, string _nick_name, string _sfz, string _mobile)
    {
        StringBuilder strTemp = new StringBuilder();

        if (_product_category_id > 0)
        {
            strTemp.Append(" and group_id=" + _product_category_id);
        }

        _note_no = _note_no.Replace("'", "");
        if (!string.IsNullOrEmpty(_note_no))
        {
            strTemp.Append(" and user_name like  '%" + _note_no + "%' ");
        }
        _nick_name = _nick_name.Replace("'", "");
        if (!string.IsNullOrEmpty(_nick_name))
        {
            strTemp.Append(" and nick_name like  '%" + _nick_name + "%' ");
        }
        _sfz = _sfz.Replace("'", "");
        if (!string.IsNullOrEmpty(_sfz))
        {
            strTemp.Append(" and sfz like  '%" + _sfz + "%' ");
        }
        _mobile = _mobile.Replace("'", "");
        if (!string.IsNullOrEmpty(_mobile))
        {
            strTemp.Append(" and mobile like  '%" + _mobile + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("depot_manager_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}&nick_name={2}&sfz={3}&mobile={4}", this.product_category_id.ToString(), txtNote_no.Text, txtnick_name.Text, txtsfz.Text, txtmobile.Text));
    }

    /// <summary>
    /// 单个删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_users bll = new ps_users();
        bll.GetModel(caId);
        string title = bll.user_name;
        bll.Delete(caId);
        mym.AddAdminLog("删除会员", "删除会员，会员卡号：" + title + ""); //记录日志
        Response.Redirect(Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}&nick_name={2}&sfz={3}&mobile={4}", this.product_category_id.ToString(), txtNote_no.Text, txtnick_name.Text, txtsfz.Text, txtmobile.Text));


    }
    /// <summary>
    /// 导出报表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("product_rep.aspx", "product_category_id={0}&note_no={1}&nick_name={2}&sfz={3}&mobile={4}", this.product_category_id.ToString(), txtNote_no.Text, txtnick_name.Text, txtsfz.Text, txtmobile.Text));
    }
    /// <summary>
    /// 筛选会员级别
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlproduct_category_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}&nick_name={2}&sfz={3}&mobile={4}", this.ddlproduct_category_id.SelectedValue, txtNote_no.Text, txtnick_name.Text, txtsfz.Text, txtmobile.Text));
    }
    /// <summary>
    /// 设置分页数量
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("depot_manager_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}&nick_name={2}&sfz={3}&mobile={4}", this.product_category_id.ToString(), txtNote_no.Text, txtnick_name.Text, txtsfz.Text, txtmobile.Text));
    }

    //负数红色显示
    public string MyZF(object d)
    {
        string myNum = d.ToString();
        if (Convert.ToInt32(d.ToString()) <= 0)
        {
            myNum = "<font color=red> " + d.ToString() + "</font>";
        }
        return myNum;
    }
}
