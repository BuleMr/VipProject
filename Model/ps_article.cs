using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 通知公告-类
/// </summary>
[Serializable]
public partial class ps_article
{
    public ps_article()
    { }
    #region Model
    private int _id;
    private int _category_id = 0;
    private string _title = "";
    private string _img_url = "";
    private string _content = "";
    private int? _sort_id = 0;
    private int? _click = 0;
    private int? _status = 1;
    private string _user_name;
    private DateTime? _add_time = DateTime.Now;
    /// <summary>
    /// 文章id
    /// </summary>
    public int id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 文章分类id
    /// </summary>
    public int category_id
    {
        set { _category_id = value; }
        get { return _category_id; }
    }
    /// <summary>
    /// 标题
    /// </summary>
    public string title
    {
        set { _title = value; }
        get { return _title; }
    }
    /// <summary>
    /// 图片路径
    /// </summary>
    public string img_url
    {
        set { _img_url = value; }
        get { return _img_url; }
    }
    /// <summary>
    /// 内容
    /// </summary>
    public string content
    {
        set { _content = value; }
        get { return _content; }
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
    /// 点击率
    /// </summary>
    public int? click
    {
        set { _click = value; }
        get { return _click; }
    }
    /// <summary>
    /// 是否启用
    /// </summary>
    public int? status
    {
        set { _status = value; }
        get { return _status; }
    }
    /// <summary>
    /// 发布人
    /// </summary>
    public string user_name
    {
        set { _user_name = value; }
        get { return _user_name; }
    }
    /// <summary>
    /// 发布时间
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
        strSql.Append("insert into [ps_article] (");
        strSql.Append("category_id,title,img_url,content,sort_id,click,status,user_name,add_time)");
        strSql.Append(" values (");
        strSql.Append("@category_id,@title,@img_url,@content,@sort_id,@click,@status,@user_name,@add_time)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@add_time", SqlDbType.DateTime)};
        parameters[0].Value = category_id;
        parameters[1].Value = title;
        parameters[2].Value = img_url;
        parameters[3].Value = content;
        parameters[4].Value = sort_id;
        parameters[5].Value = click;
        parameters[6].Value = status;
        parameters[7].Value = user_name;
        parameters[8].Value = add_time;

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
        strSql.Append("update [ps_article] set ");
        strSql.Append("category_id=@category_id,");
        strSql.Append("title=@title,");
        strSql.Append("img_url=@img_url,");
        strSql.Append("content=@content,");
        strSql.Append("sort_id=@sort_id,");
        strSql.Append("click=@click,");
        strSql.Append("status=@status,");
        strSql.Append("user_name=@user_name,");
        strSql.Append("add_time=@add_time");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@category_id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@click", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
        parameters[0].Value = category_id;
        parameters[1].Value = title;
        parameters[2].Value = img_url;
        parameters[3].Value = content;
        parameters[4].Value = sort_id;
        parameters[5].Value = click;
        parameters[6].Value = status;
        parameters[7].Value = user_name;
        parameters[8].Value = add_time;
        parameters[9].Value = id;

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
    /// 修改一列数据
    /// </summary>
    public void UpdateField(int id, string strValue)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update ps_article set " + strValue);
        strSql.Append(" where id=" + id);
        DbHelperSQL.ExecuteSql(strSql.ToString());
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool Delete(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete from [ps_article] ");
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
    /// 得到一个对象实体
    /// </summary>
    public void GetModel(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select id,category_id,title,img_url,content,sort_id,click,status,user_name,add_time ");
        strSql.Append(" FROM [ps_article] ");
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
            if (ds.Tables[0].Rows[0]["category_id"] != null && ds.Tables[0].Rows[0]["category_id"].ToString() != "")
            {
                this.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["title"] != null)
            {
                this.title = ds.Tables[0].Rows[0]["title"].ToString();
            }
            if (ds.Tables[0].Rows[0]["img_url"] != null)
            {
                this.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
            }
            if (ds.Tables[0].Rows[0]["content"] != null)
            {
                this.content = ds.Tables[0].Rows[0]["content"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
            {
                this.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["click"] != null && ds.Tables[0].Rows[0]["click"].ToString() != "")
            {
                this.click = int.Parse(ds.Tables[0].Rows[0]["click"].ToString());
            }
            if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
            {
                this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["user_name"] != null)
            {
                this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
            {
                this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
            }
        }
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [ps_article] ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 获得前几行数据
    /// </summary>
    public DataSet GetList(int Top, string strWhere, string filedOrder)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select ");
        if (Top > 0)
        {
            strSql.Append(" top " + Top.ToString());
        }
        strSql.Append(" * ");
        strSql.Append(" FROM  ps_article");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        strSql.Append(" order by " + filedOrder);
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * FROM  ps_article");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }
	

    #endregion
}
