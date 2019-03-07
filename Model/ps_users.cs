using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 类ps_users。
/// </summary>
[Serializable]
public partial class ps_users
{
    public ps_users()
    { }
    #region Model
    private int _id;
    private int? _group_id = 0;
    private string _user_name = "";
    private string _password = "";
    private string _email = "";
    private string _nick_name = "";
    private string _sfz = "";
    private string _sex = "保密";
    private DateTime? _birthday;
    private string _telphone = "";
    private string _mobile = "";
    private string _qq = "";
    private string _address = "";
    private int? _exp = 0;
    private int? _point = 0;
    private int? _status = 0;
    private DateTime? _reg_time = DateTime.Now;
    private int? _m_id = 0;
    private int? _depot_id = 0;
    /// <summary>
    /// 用户ID
    /// </summary>
    public int id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 用户组别
    /// </summary>
    public int? group_id
    {
        set { _group_id = value; }
        get { return _group_id; }
    }
    /// <summary>
    /// 用户名（会员卡号）
    /// </summary>
    public string user_name
    {
        set { _user_name = value; }
        get { return _user_name; }
    }
    /// <summary>
    /// 用户密码
    /// </summary>
    public string password
    {
        set { _password = value; }
        get { return _password; }
    }
    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string email
    {
        set { _email = value; }
        get { return _email; }
    }
    /// <summary>
    /// 用户姓名
    /// </summary>
    public string nick_name
    {
        set { _nick_name = value; }
        get { return _nick_name; }
    }
    /// <summary>
    /// 身份证
    /// </summary>
    public string sfz
    {
        set { _sfz = value; }
        get { return _sfz; }
    }
    /// <summary>
    /// 用户性别
    /// </summary>
    public string sex
    {
        set { _sex = value; }
        get { return _sex; }
    }
    /// <summary>
    /// 生日
    /// </summary>
    public DateTime? birthday
    {
        set { _birthday = value; }
        get { return _birthday; }
    }
    /// <summary>
    /// 联系电话
    /// </summary>
    public string telphone
    {
        set { _telphone = value; }
        get { return _telphone; }
    }
    /// <summary>
    /// 手机号码
    /// </summary>
    public string mobile
    {
        set { _mobile = value; }
        get { return _mobile; }
    }
    /// <summary>
    /// QQ号码
    /// </summary>
    public string qq
    {
        set { _qq = value; }
        get { return _qq; }
    }
    /// <summary>
    /// 联系地址
    /// </summary>
    public string address
    {
        set { _address = value; }
        get { return _address; }
    }
    /// <summary>
    /// 消费次数
    /// </summary>
    public int? exp
    {
        set { _exp = value; }
        get { return _exp; }
    }
    /// <summary>
    /// 用户积分
    /// </summary>
    public int? point
    {
        set { _point = value; }
        get { return _point; }
    }
    /// <summary>
    /// 用户状态,0正常,1待验证,2待审核,3锁定
    /// </summary>
    public int? status
    {
        set { _status = value; }
        get { return _status; }
    }
    /// <summary>
    /// 录入时间
    /// </summary>
    public DateTime? reg_time
    {
        set { _reg_time = value; }
        get { return _reg_time; }
    }
    /// <summary>
    /// 增加用户id
    /// </summary>
    public int? m_id
    {
        set { _m_id = value; }
        get { return _m_id; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int? depot_id
    {
        set { _depot_id = value; }
        get { return _depot_id; }
    }
    #endregion Model

    #region 方法
    /// <summary>
    /// 查询用户名-工号是否存在
    /// </summary>
    public bool Exists(string user_name)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  ps_users");
        strSql.Append(" where user_name=@user_name ");
        SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
        parameters[0].Value = user_name;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into [ps_users] (");
        strSql.Append("group_id,user_name,password,email,nick_name,sfz,sex,birthday,telphone,mobile,qq,address,exp,point,status,reg_time,m_id,depot_id)");
        strSql.Append(" values (");
        strSql.Append("@group_id,@user_name,@password,@email,@nick_name,@sfz,@sex,@birthday,@telphone,@mobile,@qq,@address,@exp,@point,@status,@reg_time,@m_id,@depot_id)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@sfz", SqlDbType.VarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,20),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@qq", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@exp", SqlDbType.Int,4),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4)};
        parameters[0].Value = group_id;
        parameters[1].Value = user_name;
        parameters[2].Value = password;
        parameters[3].Value = email;
        parameters[4].Value = nick_name;
        parameters[5].Value = sfz;
        parameters[6].Value = sex;
        parameters[7].Value = birthday;
        parameters[8].Value = telphone;
        parameters[9].Value = mobile;
        parameters[10].Value = qq;
        parameters[11].Value = address;
        parameters[12].Value = exp;
        parameters[13].Value = point;
        parameters[14].Value = status;
        parameters[15].Value = reg_time;
        parameters[16].Value = m_id;
        parameters[17].Value = depot_id;

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
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * FROM  ps_users");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public void GetModel(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select id,group_id,user_name,password,email,nick_name,sfz,sex,birthday,telphone,mobile,qq,address,exp,point,status,reg_time,m_id ");
        strSql.Append(" FROM [ps_users] ");
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
            if (ds.Tables[0].Rows[0]["group_id"] != null && ds.Tables[0].Rows[0]["group_id"].ToString() != "")
            {
                this.group_id = int.Parse(ds.Tables[0].Rows[0]["group_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["user_name"] != null)
            {
                this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["password"] != null)
            {
                this.password = ds.Tables[0].Rows[0]["password"].ToString();
            }
            if (ds.Tables[0].Rows[0]["email"] != null)
            {
                this.email = ds.Tables[0].Rows[0]["email"].ToString();
            }
            if (ds.Tables[0].Rows[0]["nick_name"] != null)
            {
                this.nick_name = ds.Tables[0].Rows[0]["nick_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sfz"] != null)
            {
                this.sfz = ds.Tables[0].Rows[0]["sfz"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sex"] != null)
            {
                this.sex = ds.Tables[0].Rows[0]["sex"].ToString();
            }
            if (ds.Tables[0].Rows[0]["birthday"] != null && ds.Tables[0].Rows[0]["birthday"].ToString() != "")
            {
                this.birthday = DateTime.Parse(ds.Tables[0].Rows[0]["birthday"].ToString());
            }
            if (ds.Tables[0].Rows[0]["telphone"] != null)
            {
                this.telphone = ds.Tables[0].Rows[0]["telphone"].ToString();
            }
            if (ds.Tables[0].Rows[0]["mobile"] != null)
            {
                this.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
            }
            if (ds.Tables[0].Rows[0]["qq"] != null)
            {
                this.qq = ds.Tables[0].Rows[0]["qq"].ToString();
            }
            if (ds.Tables[0].Rows[0]["address"] != null)
            {
                this.address = ds.Tables[0].Rows[0]["address"].ToString();
            }
            if (ds.Tables[0].Rows[0]["exp"] != null && ds.Tables[0].Rows[0]["exp"].ToString() != "")
            {
                this.exp = int.Parse(ds.Tables[0].Rows[0]["exp"].ToString());
            }
            if (ds.Tables[0].Rows[0]["point"] != null && ds.Tables[0].Rows[0]["point"].ToString() != "")
            {
                this.point = int.Parse(ds.Tables[0].Rows[0]["point"].ToString());
            }
            if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
            {
                this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["reg_time"] != null && ds.Tables[0].Rows[0]["reg_time"].ToString() != "")
            {
                this.reg_time = DateTime.Parse(ds.Tables[0].Rows[0]["reg_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["m_id"] != null && ds.Tables[0].Rows[0]["m_id"].ToString() != "")
            {
                this.m_id = int.Parse(ds.Tables[0].Rows[0]["m_id"].ToString());
            }
        }
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public bool Delete(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete from [ps_users] ");
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
    /// 更新一条数据
    /// </summary>
    public bool Update()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [ps_users] set ");
        strSql.Append("group_id=@group_id,");
        strSql.Append("user_name=@user_name,");
        strSql.Append("password=@password,");
        strSql.Append("email=@email,");
        strSql.Append("nick_name=@nick_name,");
        strSql.Append("sfz=@sfz,");
        strSql.Append("sex=@sex,");
        strSql.Append("birthday=@birthday,");
        strSql.Append("telphone=@telphone,");
        strSql.Append("mobile=@mobile,");
        strSql.Append("qq=@qq,");
        strSql.Append("address=@address,");
        strSql.Append("exp=@exp,");
        strSql.Append("point=@point,");
        strSql.Append("status=@status,");
        strSql.Append("reg_time=@reg_time,");
        strSql.Append("m_id=@m_id");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@sfz", SqlDbType.VarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,20),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@qq", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@exp", SqlDbType.Int,4),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
        parameters[0].Value = group_id;
        parameters[1].Value = user_name;
        parameters[2].Value = password;
        parameters[3].Value = email;
        parameters[4].Value = nick_name;
        parameters[5].Value = sfz;
        parameters[6].Value = sex;
        parameters[7].Value = birthday;
        parameters[8].Value = telphone;
        parameters[9].Value = mobile;
        parameters[10].Value = qq;
        parameters[11].Value = address;
        parameters[12].Value = exp;
        parameters[13].Value = point;
        parameters[14].Value = status;
        parameters[15].Value = reg_time;
        parameters[16].Value = m_id;
        parameters[17].Value = id;

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
    /// 排除自己查询用户名-工号是否存在
    /// </summary>
    public bool ExistsE(string user_name, int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  ps_users");
        strSql.Append(" where user_name=@user_name and  id<>@id");
        SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@id", SqlDbType.Int,4)};
        parameters[0].Value = user_name;
        parameters[1].Value = id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [ps_users] ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 获得SQL 查询的数据
    /// </summary>
    public DataSet GetListSql(string strsql)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(strsql);
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool ExistsM(int m_id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [ps_users]");
        strSql.Append(" where m_id=@m_id ");

        SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,4)};
        parameters[0].Value = m_id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }

    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool ExistsG(int group_id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [ps_users]");
        strSql.Append(" where group_id=@group_id ");

        SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.Int,4)};
        parameters[0].Value = group_id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }

    #endregion
}