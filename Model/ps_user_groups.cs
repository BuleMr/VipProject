using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 类ps_user_groups。
/// </summary>
[Serializable]
public partial class ps_user_groups
{
    public ps_user_groups()
    { }
    #region Model
    private int _id;
    private string _title = "";
    private int? _sort_id = 0;
    private int? _is_lock = 0;
    /// <summary>
    /// 会员级别自增ID
    /// </summary>
    public int id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 会员级别名称
    /// </summary>
    public string title
    {
        set { _title = value; }
        get { return _title; }
    }
    /// <summary>
    /// 排序
    /// </summary>
    public int? sort_id
    {
        set { _sort_id = value; }
        get { return _sort_id; }
    }
    /// <summary>
    /// 是否禁用
    /// </summary>
    public int? is_lock
    {
        set { _is_lock = value; }
        get { return _is_lock; }
    }
    #endregion Model

    #region 方法
    /// <summary>
    /// 获取数据列表
    /// </summary>
    /// <param name="strWhere"></param>
    /// <returns></returns>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [ps_user_groups] ");
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
        strSql.Append("select * FROM  ps_user_groups");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }


    /// <summary>
    /// 返回会员类别名称
    /// </summary>
    public string GetTitle(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 title from [ps_user_groups]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }

    /// <summary>
    /// 修改一列数据
    /// </summary>
    public void UpdateField(int id, string strValue)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update ps_user_groups set " + strValue);
        strSql.Append(" where id=" + id);
        DbHelperSQL.ExecuteSql(strSql.ToString());
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public void GetModel(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select id,title,sort_id,is_lock ");
        strSql.Append(" FROM [ps_user_groups] ");
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
            if (ds.Tables[0].Rows[0]["title"] != null)
            {
                this.title = ds.Tables[0].Rows[0]["title"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
            {
                this.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
            {
                this.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
            }
        }
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into [ps_user_groups] (");
        strSql.Append("title,sort_id,is_lock)");
        strSql.Append(" values (");
        strSql.Append("@title,@sort_id,@is_lock)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1)};
        parameters[0].Value = title;
        parameters[1].Value = sort_id;
        parameters[2].Value = is_lock;

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
    /// 更新一条数据
    /// </summary>
    public bool Update()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [ps_user_groups] set ");
        strSql.Append("title=@title,");
        strSql.Append("sort_id=@sort_id,");
        strSql.Append("is_lock=@is_lock");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
        parameters[0].Value = title;
        parameters[1].Value = sort_id;
        parameters[2].Value = is_lock;
        parameters[3].Value = id;

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

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool Delete(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete from [ps_user_groups] ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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

    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [ps_user_groups]");
        strSql.Append(" where id=@id ");

        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
        parameters[0].Value = id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 查询名称是否存在
    /// </summary>
    public bool Exists(string title)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  ps_user_groups");
        strSql.Append(" where title=@title ");
        SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100)};
        parameters[0].Value = title;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 查询排除自己名称是否存在
    /// </summary>
    public bool Exists(string title, int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  ps_user_groups");
        strSql.Append(" where  id<>@id and  title=@title ");
        SqlParameter[] parameters = {
                     new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100)};
        parameters[0].Value = id;
        parameters[1].Value = title;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }

    #endregion
}