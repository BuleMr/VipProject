using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }

        if (!Page.IsPostBack)
        {
            articleBind();
        }
    }

    #region 绑定菜单=================================
    protected void articleBind()
    {
        ps_manager_role_value myrv = new ps_manager_role_value();
        string sqlstr = "parent_id=0 and(1=2 or ";
        //获取存储在session中的RoleID，再去获取数据列表
        DataTable dt = myrv.GetList("role_id=" + Convert.ToInt32(Session["RoleID"]) + "").Tables[0];
        if (dt.DefaultView.Count > 0)
        {
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                sqlstr = sqlstr + "id=" + dt.Rows[i]["nav_id"].ToString() + " or ";
            }
        }
        sqlstr = sqlstr + "1=2) order by sort_id";
        ps_navigation bll = new ps_navigation();
        this.repCategory.DataSource = bll.GetList(sqlstr);
        this.repCategory.DataBind();
    }

    protected void bsClassList(object sender, RepeaterItemEventArgs e)
    {
        //AlternatingItem -------------交替（从零开始的偶数索引）单元格中的项
        //Item                  ------------列表控件中的项。它是数据绑定的
        //指触发的类型为DadaList中的基本行或内容行
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //获取对应的ID
            int ID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row["ID"].ToString());
            //找到要绑定数据的Repeater
            Repeater sClass = (Repeater)e.Item.FindControl("childCategory");
            if (sClass != null)
            {
                ps_manager_role_value myrv = new ps_manager_role_value();
                string sqlstr = "parent_id=" + ID + "  and(1=2 or ";
                DataTable dt = myrv.GetList("role_id=" + Convert.ToInt32(Session["RoleID"]) + "").Tables[0];
                if (dt.DefaultView.Count > 0)
                {
                    for (int i = 0; i < dt.DefaultView.Count; i++)
                    {
                        sqlstr = sqlstr + "id=" + dt.Rows[i]["nav_id"].ToString() + " or ";
                    }
                }
                sqlstr = sqlstr + "1=2) order by sort_id";
                ps_navigation bll = new ps_navigation();
                sClass.DataSource = bll.GetList(sqlstr);
                sClass.DataBind();
            }
        }
    }

    #endregion
}
