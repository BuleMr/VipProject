using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class tools_Server_md : System.Web.UI.Page
{
    //关键字显示门店
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["searchText"] != null)
        {
            if (Request.QueryString["searchText"].ToString().Trim().Length > 0)
            {
                #region
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(
                     ConfigHelper.GetValueByKey("ConnectionString")))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format(
                         "Select distinct title From ps_depot Where category_id=" + Convert.ToInt32(Session["DepotCatID"]) + " and title like '%{0}%'",
                         Request.QueryString["searchText"]);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt);
                }
                string returnText = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        returnText += dt.Rows[i][0].ToString() + "\n";
                    }
                }
                Response.Write(returnText);
                #endregion
            }
        }
    }
}
