using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 角色-类
/// </summary>
[Serializable]
public partial class ps_manager_role
{
    public ps_manager_role()
    { }
    #region Model
    private int _id;
    private string _role_name = "";
    private int? _role_type = 0;
    private int? _is_sys = 0;
    /// <summary>
    /// 角色id
    /// </summary>
    public int id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 角色名称
    /// </summary>
    public string role_name
    {
        set { _role_name = value; }
        get { return _role_name; }
    }
    /// <summary>
    /// 角色类型
    /// </summary>
    public int? role_type
    {
        set { _role_type = value; }
        get { return _role_type; }
    }
    /// <summary>
    /// 是否为系统管理员
    /// </summary>
    public int? is_sys
    {
        set { _is_sys = value; }
        get { return _is_sys; }
    }
    #endregion Model

    #region 方法
    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public void GetModel(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select id,role_name,role_type,is_sys ");
        strSql.Append(" FROM [ps_manager_role] ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
        parameters[0].Value = id;

        DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
            {
                this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["role_name"] != null)
            {
                this.role_name = ds.Tables[0].Rows[0]["role_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["role_type"] != null && ds.Tables[0].Rows[0]["role_type"].ToString() != "")
            {
                this.role_type = int.Parse(ds.Tables[0].Rows[0]["role_type"].ToString());
            }
            if (ds.Tables[0].Rows[0]["is_sys"] != null && ds.Tables[0].Rows[0]["is_sys"].ToString() != "")
            {
                this.is_sys = int.Parse(ds.Tables[0].Rows[0]["is_sys"].ToString());
            }
        }
    }

    /// <summary>
    /// 返回角色名称
    /// </summary>
    public string GetTitle(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 role_name from [ps_manager_role]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [ps_manager_role] ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }

    #endregion
}