using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class sysmanager_manager_rep : System.Web.UI.Page
{
    protected int status;
    protected int category_id;
    protected int depot_id;
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
        int nav_id = 29;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            this.status = AXRequest.GetQueryInt("status");
            this.category_id = AXRequest.GetQueryInt("category_id");
            this.depot_id = AXRequest.GetQueryInt("depot_id");
            this.keywords = AXRequest.GetQueryString("keywords");
            binddr();
        }

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("用户信息表" + DateTime.Now.ToString("d") + ".xls", Encoding.UTF8).ToString());
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _status, int _category_id, int _depot_id, string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
        if (_status > 0)
        {
            strTemp.Append(" and is_lock=" + _status);
        }
        if (_category_id > 0)
        {
            strTemp.Append(" and depot_category_id=" + _category_id);
        }
        if (_depot_id > 0)
        {
            strTemp.Append(" and  depot_id=" + _depot_id);
        }
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (user_name like  '%" + _keywords + "%' or real_name like '%" + _keywords + "%' or  mobile like '%" + _keywords + "%' or  remark like '%" + _keywords + "%'  )");
        }
        return strTemp.ToString();
    }
    #endregion

    //绑定记录
    public void binddr()
    {

        ps_manager bll = new ps_manager();
        string sqlstr = "";
        string _strWhere = "";
        if (Convert.ToInt32(Session["DepotID"]) == 0 && Convert.ToInt32(Session["DepotCatID"]) == 0)
        {
            _strWhere = "id>0 ";
        }
        else if (Convert.ToInt32(Session["DepotID"]) == 0 && Convert.ToInt32(Session["DepotCatID"]) > 0)
        {
            _strWhere = "depot_category_id=" + Convert.ToInt32(Session["DepotCatID"]);
        }
        else if (Convert.ToInt32(Session["DepotID"]) > 0 && Convert.ToInt32(Session["DepotCatID"]) > 0)
        {
            _strWhere = "depot_id=" + Convert.ToInt32(Session["DepotID"]) + " and depot_category_id=" + Convert.ToInt32(Session["DepotCatID"]);

        }

        sqlstr = _strWhere + CombSqlTxt(this.status, this.category_id, this.depot_id, this.keywords);
        sqlstr = sqlstr + " order by add_time desc,id desc ";
        DataView dv = bll.GetList(sqlstr).Tables[0].DefaultView;
        repCategory.DataSource = dv;
        repCategory.DataBind();

    }

}
