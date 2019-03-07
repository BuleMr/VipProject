using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class depotmanager_product_rep : System.Web.UI.Page
{
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
        if (!Page.IsPostBack)
        {
            this.product_category_id = AXRequest.GetQueryInt("product_category_id");

            this.note_no = AXRequest.GetQueryString("note_no");
            this.nick_name = AXRequest.GetQueryString("nick_name");
            this.sfz = AXRequest.GetQueryString("sfz");
            this.mobile = AXRequest.GetQueryString("mobile");
            binddr();
        }

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("会员信息表" + DateTime.Now.ToString("d") + ".xls", Encoding.UTF8).ToString());
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
    }

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


    //绑定记录
    public void binddr()
    {

        ps_users bll = new ps_users();
        string sqlstr = "";
        string _strWhere = "";

        _strWhere = "id>0 ";

        sqlstr = _strWhere + CombSqlTxt(this.product_category_id, this.note_no, this.nick_name, this.sfz, this.mobile);
        sqlstr = sqlstr + " order by reg_time desc,id desc ";
        DataView dv = bll.GetList(sqlstr).Tables[0].DefaultView;
        repCategory.DataSource = dv;
        repCategory.DataBind();

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
