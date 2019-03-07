using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sysmanager_depot_rep : System.Web.UI.Page
{
    protected int status;
    protected int category_id;
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
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);
        int nav_id = 28;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            this.status = AXRequest.GetQueryInt("status");
            this.category_id = AXRequest.GetQueryInt("category_id");
            this.keywords = AXRequest.GetQueryString("keywords");
            binddr();
        }

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("门店信息表" + DateTime.Now.ToString("d") + ".xls", Encoding.UTF8).ToString());
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _status, int _category_id, string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        if (_status > 0)
        {
            strTemp.Append(" and status=" + _status);
        }
        if (_category_id > 0)
        {
            strTemp.Append(" and category_id=" + _category_id);
        }
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (title like  '%" + _keywords + "%' or code like '%" + _keywords + "%' or  contact_name like '%" + _keywords + "%' or  contact_tel like '%" + _keywords + "%' or  contact_mobile like '%" + _keywords + "%' or  contact_address like '%" + _keywords + "%')");
        }
        return strTemp.ToString();
    }
    #endregion

    //绑定记录
    public void binddr()
    {
        ps_depot bll = new ps_depot();
        string sqlstr = "id>0 ";
        sqlstr = sqlstr + CombSqlTxt(this.status, this.category_id, this.keywords);
        sqlstr = sqlstr + " order by category_id asc,sort_id asc,id desc ";
        DataView dv = bll.GetList(sqlstr).Tables[0].DefaultView;
        repCategory.DataSource = dv;
        repCategory.DataBind();
    }
}
