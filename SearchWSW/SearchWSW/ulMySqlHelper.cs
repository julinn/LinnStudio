using System;
using System.Data;
using System.Configuration;
//using System.Web;
//using System.Web.Configuration;
//
using MySql.Data.MySqlClient;
using System.Collections; 
using System.Collections.Generic;

/// <summary>
/// ulMySqlHelper 的摘要说明
/// 作者：julinn 
/// 更新日期：2016-05-22 12:03:44
/// 需要配套 MySql.Data.dll 使用
/// </summary>
public class ulMySqlHelper
{
    public static string FConnString = ReadConnString();
	public ulMySqlHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
    }

    #region SimpleEncStr 简单加密 base64
    /// <summary>
    /// 简单加密 base64
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SimpleEncStr(string str)
    {
        byte[] b = System.Text.Encoding.Default.GetBytes(str);
        return Convert.ToBase64String(b);
    }
    #endregion

    #region SimpleDecStr 简单解密 base64
    /// <summary>
    /// 简单解密 base64
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SimpleDecStr(string str)
    {
        byte[] b = Convert.FromBase64String(str);
        return System.Text.Encoding.Default.GetString(b);
    }
    #endregion

    #region FormatConnString 格式化连接字符串
    /// <summary>
    /// 格式化连接字符串
    /// </summary>
    /// <param name="ServerIP">服务器IP或域名</param>
    /// <param name="UserID">用户名</param>
    /// <param name="Passwd">密码</param>
    /// <param name="DataBase">数据库名</param>
    /// <param name="PortNo">服务器端口号，为空默认 3306</param>
    /// <param name="charSet">字符编码，为空默认 utf8 </param>
    /// <returns></returns>
    public static string FormatConnString(string ServerIP, string UserID, string Passwd, string DataBase, string PortNo, string charSet)
    {
        try
        {
            if (PortNo == "" || PortNo == null)
                PortNo = "3306";
            if (charSet == "" || charSet == null)
                charSet = "utf8";
            return "Database=" + DataBase + ";Data Source=" + ServerIP + ";port=" + PortNo + ";User ID=" + UserID 
                + ";Password=" + Passwd + ";CharSet=" + charSet;
        }
        catch
        {
            return "";
        }
    }
    public static string FormatConnString(string ServerIP, string UserID, string Passwd, string DataBase, string PortNo)
    {
        try
        {
            if (PortNo == "" || PortNo == null)
                PortNo = "3306";
            string charSet = "utf8";
            return "Database=" + DataBase + ";Data Source=" + ServerIP + ";port=" + PortNo + ";User ID=" + UserID
                + ";Password=" + Passwd + ";CharSet=" + charSet;
        }
        catch
        {
            return "";
        }
    }
    public static string FormatConnString(string ServerIP, string UserID, string Passwd, string DataBase)
    {
        try
        {
            string PortNo = "3306", charSet = "utf8";
            return "Database=" + DataBase + ";Data Source=" + ServerIP + ";port=" + PortNo + ";User ID=" + UserID 
                + ";Password=" + Passwd + ";CharSet=" + charSet;
        }
        catch
        {
            return "";
        }
    }
    #endregion 

    #region FormatQueryString 格式化查询字符串（去单引号)
    /// <summary>
    /// 格式化查询字符串（去单引号)
    /// </summary>
    /// <param name="queryString"></param>
    /// <returns></returns>
    public static string FormatQueryString(string queryString)
    {
        return queryString.Replace("'", "");
    }
    #endregion 

    #region ReadConnString 读取连接字符串 MySQL
    public static string ReadConnString()
    {
        try
        {
            return FormatConnString("55c95f1838fa8.gz.cdb.myqcloud.com", "uid_SearchData", "LinnsSearchData_xyws", "SearchData", "15305");
            //return SimpleDecStr(System.Configuration.ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
        }
        catch
        {
            return "";
        }
    }
    #endregion

    #region SaveConnString 保存连接字符串,配置节点：MySQL
    /// <summary>
    /// 保存连接字符串,配置节点：MySQL
    /// </summary>
    /// <param name="ConnStr"></param>
    public static bool SaveConnString(string ConnStr)
    {
        try
        {
            /*
            bool isModified = false;
            if (ConfigurationManager.ConnectionStrings["MySQL"] != null)
                isModified = true;
            ConnStr = SimpleEncStr(ConnStr);
            ConnectionStringSettings mySettings = new ConnectionStringSettings("MySQL", ConnStr);
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            if (isModified)
                config.ConnectionStrings.ConnectionStrings.Remove("MySQL");
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("ConnectionStrings");
            FConnString = ReadConnString();
             */
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region TestConnString 测试连接字符串
    public static bool TestConnString(string connStr)
    {
        if (connStr == "")
            connStr = ReadConnString();
        using (MySqlConnection connection = new MySqlConnection(connStr))
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }
    }
    #endregion 

    #region GetAppSetting 读取webConfig AppSettings Key值
    /// <summary>
    /// GetAppSetting 读取webConfig AppSettings Key值
    /// </summary>
    /// <param name="keyName"></param>
    /// <returns></returns>
    public static string GetAppSetting(string keyName)
    {
        try
        {
            return "";
            //return System.Configuration.ConfigurationManager.AppSettings[keyName].ToString();
        }
        catch
        {
            return "";
        }
    }
    #endregion 

    //====== 执行 SQL 、 存储过程

    #region ExecuteStoreProcedure 执行带参数存储过程
    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="procedureName">存储过程名称</param>
    /// <param name="cmdParms">参数</param>
    /// <returns></returns>
    public static string ExecuteStoreProcedure(string procedureName, params MySqlParameter[] cmdParms)
    {
        string ret = "";
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(cmdParms);
                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                connection.Close();
                ret = "错误信息：" + e.Message;
            }
        }
        return ret;
    }
    #endregion 

    #region ExecuteSql 执行SQL语句，返回影响的记录数
    /// <summary>  
    /// 执行SQL语句，返回影响的记录数  
    /// </summary>  
    /// <param name="SQLString">SQL语句</param>  
    /// <returns>影响的记录数，错误返回 -1</returns>  
    public static int ExecuteSql(string SQLString)
    {
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rows;
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    connection.Close();
                    return -1;
                }
            }
        }
    }

    /// <summary>
    /// 执行SQL语句，返回影响的记录数 
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <param name="errMsg">错误信息</param>
    /// <returns>影响的记录数，错误返回 -1</returns>
    public static int ExecuteSql(string SQLString, out string errMsg)
    {
        errMsg = "";
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rows;
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    connection.Close();
                    errMsg = e.Message;
                    return -1;
                }
            }
        }
    }
    #endregion 

    #region ExecuteSql 执行带参数的SQL语句

    /// <summary>
    /// 执行带参数的SQL语句
    /// </summary>
    /// <param name="SQLString"></param>
    /// <param name="cmdParms"></param>
    /// <returns></returns>
    public static int ExecuteSql(string SQLString, params MySqlParameter[] cmdParms)
    {
        int rows = 0;
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = SQLString;        
                 cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(cmdParms);
                rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                connection.Close();
                rows = -1;
            }
        }
        return rows;
    }

    /// <summary>
    /// 执行带参数的SQL语句
    /// </summary>
    /// <param name="SQLString"></param>
    /// <param name="Errmsg"></param>
    /// <param name="cmdParms"></param>
    /// <returns></returns>
    public static int ExecuteSql(string SQLString, out string Errmsg, params MySqlParameter[] cmdParms)
    {
        Errmsg = "";
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    Errmsg = "错误信息：" + e.Message;
                   // throw e;
                    return -1;
                }
            }
        }
    }

    private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        if (trans != null)
            cmd.Transaction = trans;
        cmd.CommandType = CommandType.Text;//cmdType;  
        if (cmdParms != null)
        {
            foreach (MySqlParameter parameter in cmdParms)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                cmd.Parameters.Add(parameter);
            }
        }
    }
    #endregion 

    #region GetFirstVar 读取第一行第一列值
    /// <summary>
    /// GetFirstVar 读取第一行第一列值
    /// </summary>
    /// <param name="SQLString"></param>
    /// <returns></returns>
    public static string GetFirstVar(string SQLString)
    {
        string ret = "";
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    MySqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.HasRows)
                    {
                        if (myReader.Read())
                            ret = myReader[0].ToString();
                    }
                    myReader.Close();
                    connection.Close();
                }
                catch //(MySql.Data.MySqlClient.MySqlException e)
                {
                    connection.Close();
                    ret = "";
                    //throw e;
                }
            }
        }
        return ret;
    }

    /// <summary>
    /// GetFirstVar 读取第一行第一列值
    /// </summary>
    /// <param name="procName">存储过程名</param>
    /// <param name="cmdParms">参数列表</param>
    /// <returns></returns>
    public static string GetFirstVar(string procName, params MySqlParameter[] cmdParms)
    {
        string ret = "";
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(cmdParms);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "ds");
                connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    ret = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                string Errmsg = ex.Message;
                ret = "";
                connection.Close();
                //throw new Exception(ex.Message);
            }
            return ret;
        }
    }

    #endregion     

    #region GetDataset 获取数据集 DataSet
    /// <summary>
    /// 获取数据集 DataSet
    /// </summary>
    /// <param name="SQLString"></param>
    /// <param name="Errmsg"></param>
    /// <returns></returns>
    public static DataSet GetDataset(string SQLString, out string Errmsg)
    {
        Errmsg = "";
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Errmsg = ex.Message;
                connection.Close();
                //throw new Exception(ex.Message);
            }
            return ds;
        }
    }

    public static DataSet GetDataset(string SQLString)
    {
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
                connection.Close();
            }
            catch //(MySql.Data.MySqlClient.MySqlException ex)
            {
                connection.Close();
                //throw new Exception(ex.Message);
            }
            return ds;
        }
    }

    public static bool GetDataset(string SQLString, out DataSet ds)
    {
        bool ret = false;
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            ds = new DataSet();
            try
            {
                connection.Open();
                MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
                connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    ret = true;
            }
            catch //(MySql.Data.MySqlClient.MySqlException ex)
            {
                //Errmsg = ex.Message;
                ret = false;
                connection.Close();
                //throw new Exception(ex.Message);
            }
            return ret;
        }
    }

    public static bool GetDataset(string SQLString, out DataSet ds, params MySqlParameter[] cmdParms)
    {
        bool ret = false;
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            ds = new DataSet();
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = SQLString;
                cmd.Parameters.AddRange(cmdParms);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "ds");
                connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    ret = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                string Errmsg = ex.Message;
                ret = false;
                connection.Close();
                //throw new Exception(ex.Message);
            }
            return ret;
        }
    }
    #endregion 

    #region GetaDatatable 获取datatalbe
    /// <summary>
    /// 获取datatalbe
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="dt"></param>
    /// <param name="err"></param>
    /// <returns></returns>
    public static bool GetaDatatable(string sql, out DataTable dt, out string err)
    {
        dt = new DataTable();
        err = "";
        bool b = false;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(FConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    MySqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(myReader);
                    if (dt.Rows.Count > 0)
                        b = true;
                }
            }
        }
        catch (Exception ex)
        {
            err = ex.Message;
        }
        return b;
    }
    #endregion 

    #region GetDatasetByProcdure 获取数据集（存储过程）
    /// <summary>
    /// 获取数据集（存储过程）
    /// </summary>
    /// <param name="procName">存储过程名</param>
    /// <param name="ds">返回数据集</param>
    /// <param name="cmdParms">参数</param>
    /// <returns>是否有记录</returns>
    public static bool GetDatasetByProcdure(string procName, out DataSet ds, params MySqlParameter[] cmdParms)
    {
        bool ret = false;
        using (MySqlConnection connection = new MySqlConnection(FConnString))
        {
            ds = new DataSet();
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand(); // new MySqlCommand();//connection.CreateCommand();
                //cmd.Connection = connection;
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddRange(cmdParms);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "ds");
                connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    ret = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                string Errmsg = ex.Message;
                ret = false;
                connection.Close();
                //throw new Exception(ex.Message);
            }
            return ret;
        }
    }
    #endregion 

    #region 获取 SqlParameter[] 全部参数名称和类型
    /// <summary>
    /// 获取 SqlParameter[] 全部参数名称和类型
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static string GetAllParametersName(params MySqlParameter[] parameters)
    {
        string ret = "", sItem = "";
        int i = 0, iCount = parameters.Length;
        for (i = 0; i < iCount; i++)
        {
            sItem = parameters[i].ParameterName;            
            //if (parameters[i].Direction == ParameterDirection.Output || parameters[i].Direction == ParameterDirection.InputOutput)
            //{
              //  sItem = "out " + sItem;// +" out";
            //}            
            if (ret == "")
                ret = sItem;
            else
                ret = ret + "," + sItem;
        }
        return ret;
    }
    #endregion

    #region 增加SQL命令参数 AddParameter AddIntParameter AddDecimalParameter AddVarcharParameter
    /// <summary>
    /// 增加SQL命令参数
    /// </summary>
    /// <param name="paraName">参数名</param>
    /// <param name="paraValue">参数值</param>
    /// <param name="paraDbType">数据类型</param>
    /// <param name="paraSize">参数长度</param>
    /// <param name="paraDirection">参数类型（in, out, inout)</param>
    /// <returns></returns>
    public static MySqlParameter AddParameter(string paraName, object paraValue, MySqlDbType paraDbType, int paraSize, ParameterDirection paraDirection)
    {
        MySqlParameter par = new MySqlParameter();
        par.ParameterName = paraName;
        par.Value = paraValue;
        par.Direction = paraDirection;
        par.MySqlDbType = paraDbType;
        if (paraSize > 0)
            par.Size = paraSize;
        return par;
    }

    //=== 整数参数 ===
    public static MySqlParameter AddIntParameter(string paraName, int paraValue, ParameterDirection paraDirection)
    {
        return AddParameter(paraName, paraValue, MySqlDbType.Int32, 0, paraDirection);
    }
    public static MySqlParameter AddIntParameter(string paraName, int paraValue)
    {
        return AddParameter(paraName, paraValue, MySqlDbType.Int32, 0, ParameterDirection.Input);
    }
    public static MySqlParameter AddIntOutParameter(string paraName)
    {
        return AddParameter(paraName, 0, MySqlDbType.Int32, 0, ParameterDirection.Output);
    }

    // == 小数类型 == 
    public static MySqlParameter AddDecimalParameter(string paraName, decimal paraValue, ParameterDirection paraDirection)
    {
        return AddParameter(paraName, paraValue, MySqlDbType.Decimal, 0, paraDirection);
    }
    public static MySqlParameter AddDecimalParameter(string paraName, decimal paraValue)
    {
        return AddParameter(paraName, paraValue, MySqlDbType.Decimal, 0, ParameterDirection.Input);
    }
    public static MySqlParameter AddDecimalOutParameter(string paraName)
    {
        return AddParameter(paraName, 0, MySqlDbType.Decimal, 0, ParameterDirection.Output);
    }

    // == 字符串类型 ==
    public static MySqlParameter AddVarcharParameter(string paraName, string paraValue, int paraSize, ParameterDirection paraDirection)
    {
        return AddParameter(paraName, paraValue, MySqlDbType.VarChar, paraSize, paraDirection);
    }
    public static MySqlParameter AddVarcharParameter(string paraName, string paraValue, int paraSize)
    {
        return AddParameter(paraName, paraValue, MySqlDbType.VarChar, paraSize, ParameterDirection.Input);
    }
    public static MySqlParameter AddVarcharParameter(string paraName, string paraValue)
    {
        int paraSize = paraValue.Length;
        if (paraSize > 8000)
            paraSize = 8000;
        return AddParameter(paraName, paraValue, MySqlDbType.VarChar, paraSize, ParameterDirection.Input);
    }
    public static MySqlParameter AddVarcharOutParameter(string paraName, int paraSize)
    {
        return AddParameter(paraName, "", MySqlDbType.VarChar, paraSize, ParameterDirection.Output);
    }

    #endregion 

    //=== 事务 SQL ===

    #region ExecuteSqlTran 执行多条SQL语句，实现数据库事务。
    /// <summary>  
    /// 执行多条SQL语句，实现数据库事务。  
    /// </summary>  
    /// <param name="SQLStringList">多条SQL语句</param>       
    public static bool ExecuteSqlTran(List<String> SQLStringList)
    {
        //bool ret = false;
        using (MySqlConnection conn = new MySqlConnection(FConnString))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            MySqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                int count = 0;
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n];
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        count += cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
                conn.Close();
                //if (SQLStringList.Count == count)
                //    ret = true;
                return true;
            }
            catch
            {
                tx.Rollback();
                conn.Close();
                return false;
            }
        }
    }

    /// <summary>  
    /// 执行多条SQL语句，实现数据库事务。  
    /// </summary>  
    /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的MySqlParameter[]）</param>  
    public static bool ExecuteSqlTran(Hashtable SQLStringList)
    {
        //bool ret = false;
        using (MySqlConnection conn = new MySqlConnection(FConnString))
        {
            conn.Open();
            using (MySqlTransaction trans = conn.BeginTransaction())
            {
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    //循环  
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string cmdText = myDE.Key.ToString();
                        MySqlParameter[] cmdParms = (MySqlParameter[])myDE.Value;
                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
    #endregion 

    //===/********************** 数据转换 **********************/

    #region SqlParameter value  to int
    /// <summary>
    /// SqlParameter value  to int
    /// </summary>
    /// <param name="para"></param>
    /// <returns></returns>
    public static int GetIntValue(MySqlParameter para)
    {
        try
        { return int.Parse(para.Value.ToString()); }
        catch
        { return 0; }
    }
    #endregion

    #region SqlParameter value to string
    /// <summary>
    /// SqlParameter value to string
    /// </summary>
    /// <param name="para"></param>
    /// <returns></returns>
    public static string GetStrValue(MySqlParameter para)
    {
        try
        { return para.Value.ToString(); }
        catch
        { return ""; }
    }
    #endregion

    #region SqlParameter value to decimal
    /// <summary>
    /// SqlParameter value to decimal
    /// </summary>
    /// <param name="para"></param>
    /// <returns></returns>
    public static decimal GetDecimalValue(MySqlParameter para)
    {
        try
        { return decimal.Parse(para.Value.ToString()); }
        catch
        { return 0; }
    }
    #endregion

    #region string to int
    /// <summary>
    /// string to int
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int GetIntValue(string str)
    {
        try
        { return int.Parse(str.ToString()); }
        catch
        { return 0; }
    }
    #endregion

    #region string to decimal
    /// <summary>
    /// string to decimal
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static decimal GetDecimalValue(string str)
    {
        try
        { return decimal.Parse(str.ToString()); }
        catch
        { return 0; }
    }
    #endregion
}
