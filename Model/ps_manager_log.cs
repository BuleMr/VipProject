using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
///操作日志-类
/// </summary>
[Serializable]
public partial class ps_manager_log
{
    public ps_manager_log()
    { }
    #region Model
    private long _id;
    private int? _user_id;
    private string _user_name;
    private string _action_type;
    private string _remark;
    private string _user_ip;
    private DateTime? _add_time = DateTime.Now;
    /// <summary>
    /// 
    /// </summary>
    public long id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int? user_id
    {
        set { _user_id = value; }
        get { return _user_id; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string user_name
    {
        set { _user_name = value; }
        get { return _user_name; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string action_type
    {
        set { _action_type = value; }
        get { return _action_type; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string remark
    {
        set { _remark = value; }
        get { return _remark; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string user_ip
    {
        set { _user_ip = value; }
        get { return _user_ip; }
    }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? add_time
    {
        set { _add_time = value; }
        get { return _add_time; }
    }
    #endregion Model

    #region 方法

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into [ps_manager_log] (");
        strSql.Append("user_id,user_name,action_type,remark,user_ip,add_time)");
        strSql.Append(" values (");
        strSql.Append("@user_id,@user_name,@action_type,@remark,@user_ip,@add_time)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@action_type", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,255),
					new SqlParameter("@user_ip", SqlDbType.NVarChar,30),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
        parameters[0].Value = user_id;
        parameters[1].Value = user_name;
        parameters[2].Value = action_type;
        parameters[3].Value = remark;
        parameters[4].Value = user_ip;
        parameters[5].Value = add_time;

        object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        if (obj == null)
        {
            return 0;
        }
        else
        {
            return Convert.ToInt32(obj);
        }
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [ps_manager_log] ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * FROM  ps_manager_log");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool Delete(long id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete from [ps_manager_log] ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
        parameters[0].Value = id;

        int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        if (rows > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion
}