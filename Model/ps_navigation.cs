using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 类ps_navigation。
/// </summary>
[Serializable]
public partial class ps_navigation
{
    public ps_navigation()
    { }
    #region Model
    private int _id;
    private string _title;
    private string _link_url = "";
    private int? _sort_id = 1;
    private int? _parent_id = 0;
    /// <summary>
    /// 系统栏目id
    /// </summary>
    public int id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 栏目名称
    /// </summary>
    public string title
    {
        set { _title = value; }
        get { return _title; }
    }
    /// <summary>
    /// 链接
    /// </summary>
    public string link_url
    {
        set { _link_url = value; }
        get { return _link_url; }
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
    /// 父级id
    /// </summary>
    public int? parent_id
    {
        set { _parent_id = value; }
        get { return _parent_id; }
    }
    #endregion Model

    #region 方法

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [ps_navigation] ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }

    #endregion
}