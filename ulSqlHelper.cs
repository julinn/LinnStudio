using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// ulSqlHelper 的摘要说明
/// 配置文件的连接字符串必须包含节点名称 【ConnectionString】，如下所示：
/// <connectionStrings><add name="ConnectionString" connectionString="" providerName="System.Data.SqlClient"/></connectionStrings>
/// Author: julinn
/// update: 2014-05-22 11:07:05
/// Webnet: www.liuju.net
/// GitHub: https://github.com/julinn/LinnStudio
/// </summary>
public class ulSqlHelper
{
    public static string FConnString = ReadConnString();
	public ulSqlHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //基础操作部分
    #region 添加设置节点
    /// <summary>
    /// 添加设置节点
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sValue"></param>
    public static void AddAppSettingsSection(string sKey, string sValue)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
        appSection.Settings.Add(sKey, sValue);
        config.Save();
    }
    #endregion

    #region 删除设置节点
    /// <summary>
    /// 删除设置节点
    /// </summary>
    /// <param name="sKey"></param>
    public static void DelAppSettingsSection(string sKey)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
        appSection.Settings.Remove(sKey);
        config.Save();
    }
    #endregion

    #region 编辑设置节点
    /// <summary>
    /// 编辑设置节点
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sValue"></param>
    public static void EditAppSettingsSection(string sKey, string sValue)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
        appSection.Settings[sKey].Value = sValue;
        config.Save();
    }
    #endregion

    #region 读取AppSettings节点配置
    /// <summary>
    /// 读取AppSettings节点配置
    /// </summary>
    /// <param name="sKey"></param>
    /// <returns></returns>
    public static string ReadAppSettingsSection(string sKey)
    {
        return ConfigurationManager.AppSettings[sKey].ToString();
    }
    #endregion

    #region 简单加密 base64
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

    #region 简单解密 base64
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

    #region 读取连接字符串
    public static string ReadConnString()
    {
        try
        {
            return SimpleDecStr(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        catch
        {
            return "";
        }
    }
    #endregion

    #region 保存连接字符串,配置节点：ConnectionString
    /// <summary>
    /// 保存连接字符串,配置节点：ConnectionString
    /// </summary>
    /// <param name="ConnStr"></param>
    public static bool SaveConnString(string ConnStr)
    {
        try
        {
            bool isModified = false;
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
                isModified = true;
            ConnStr = SimpleEncStr(ConnStr);
            ConnectionStringSettings mySettings = new ConnectionStringSettings("ConnectionString", ConnStr);
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            if (isModified)
                config.ConnectionStrings.ConnectionStrings.Remove("ConnectionString");
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("ConnectionStrings");
            FConnString = ReadConnString();
            return true;
        }
        catch
        {            
            return false;
        }
    }
    #endregion

    #region 简单的版权信息（底部）
    /// <summary>
    /// 简单的版权信息（底部）
    /// </summary>
    /// <param name="str"></param>
    /// <param name="page"></param>
    public static string LinnSign(string str)
    {
        string ret = "<div style=\"position:fixed; right:0px; _position:absolute; bottom:0px; width:100%; display:block; text-align:center\">"
            + str + "</div>";
        return ret;
    }
    #endregion

    //数据库操作部分
    #region 格式化连接字符串
    /// <summary>
    /// 格式化连接字符串
    /// </summary>
    /// <param name="Server"></param>
    /// <param name="User"></param>
    /// <param name="Pwd"></param>
    /// <param name="DBName"></param>
    /// <returns></returns>
    public static string FormatConnStr(string Server, string User, string Pwd, string DBName)
    {
        return "server=" + Server + ";uid=" + User + ";pwd=" + Pwd + ";database=" + DBName;
    }
    #endregion

    #region 测试连接字符串
    /// <summary>
    /// 测试连接字符串
    /// </summary>
    /// <param name="ConnStr"></param>
    /// <returns></returns>
    public static bool TestConnstring(string ConnStr)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            conn.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region 读取第一行第一列记录
    /// <summary>
    /// 读取第一行第一列记录
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static string GetFirstData(string sql)
    {
        string ret = "";
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                if (dr.Read())
                    ret = dr[0].ToString();
                else
                    ret = "";
            else
                ret = "";
            dr.Close();
            conn.Close();
            return ret;
        }
        catch
        {
            return "";
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion

    #region 执行SQL语句
    /// <summary>
    /// 执行SQL语句
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static bool ExecuteSQL(string sql)
    {
        bool ret = false;
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ret = true;
        }
        catch
        {
            ret = false;
        }
        finally
        {
            conn.Close();
        }
        return ret;
    }
    #endregion

    #region 执行SQL语句,返回受影响行数，异常返回-1
    /// <summary>
    /// 执行SQL语句,返回受影响行数，异常返回-1
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static int ExecuteNonQuery(string sql)
    {
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }
        catch
        {
            return -1;
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion

    #region 执行SQL语句,返回受影响行数，异常返回-1
    /// <summary>
    /// 执行SQL语句,返回受影响行数，异常返回-1
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
    {
        int ret = 0;
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
        catch
        {
            ret = -1;
        }
        finally
        {
            conn.Close();
        }
        return ret;
    }
    #endregion

    #region 执行SQL语句,失败返回错误信息
    /// <summary>
    ///  执行SQL语句,失败返回错误信息
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static string ExecuteSQLErrorINFO(string sql)
    {
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion  

    #region 执行SQL语句,失败返回错误信息
    /// <summary>
    /// 执行SQL语句,失败返回错误信息
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static string ExecuteSQLErrorINFO(string sql, params SqlParameter[] parameters)
    {
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
            conn.Close();
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion

    #region 获取数据集
    /// <summary>
    /// 获取数据集，True：有行；False没有行/异常
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static bool GetDataset(DataSet ds, string sql)
    {
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
        finally
        {
            conn.Close();
        }
    }

    #region 获取数据集
    /// <summary>
    /// 获取数据集，True：有行；False没有行/异常
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static bool GetDataset(DataSet ds, string sql, params SqlParameter[] parameters)
    {
        SqlConnection conn = new SqlConnection(FConnString);
        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion


    #endregion

}
