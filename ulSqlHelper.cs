using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ulLinnStudio
{
    /// <summary>
    /// ulSqlHelper 的摘要说明
    /// 配置文件的连接字符串必须包含节点名称 【ConnectionString】，示例如下：
    /// <connectionStrings>
    /// <add name="ConnectionString" connectionString="" providerName="System.Data.SqlClient"/>
    /// </connectionStrings>
    /// Author: julinn
    /// update: 2016-06-02 00:10:24
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
        #region AddAppSettingsSection 添加设置节点
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

        #region DelAppSettingsSection 删除设置节点
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

        #region EditAppSettingsSection 编辑设置节点
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

        #region ReadAppSettingsSection 读取AppSettings节点配置
        /// <summary>
        /// 读取AppSettings节点配置
        /// </summary>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string ReadAppSettingsSection(string sKey)
        {
            try
            {
                return ConfigurationManager.AppSettings[sKey].ToString();
            }
            catch
            {
                return "";
            }
        }
        #endregion

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

        #region ReadConnString 读取连接字符串
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

        #region SaveConnString 保存连接字符串,配置节点：ConnectionString
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

        #region LinnSign 简单的版权信息（底部）
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

        #region IsLetter_Number 检查字符串是否只包含字母和数字
        /// <summary>
        /// 检查字符串是否只包含字母和数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLetter_Number(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9]+$");
            return reg1.IsMatch(str);
        }
        #endregion 

        #region StrToInt 字符串转整形
        public static int StrToInt(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return 0;
            }
        }

        public static int StrToInt(string str, int DefValue)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return DefValue;
            }
        }
        #endregion 

        #region GetMD5String 获取MD5加密字符串（大写）
        /// <summary>
        /// 获取MD5加密字符串（大写）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5String(string str)
        {
            try
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
            }
            catch
            {
                return str.Replace("'", "").Replace(" ", "");
            }
        }
        #endregion 

        //数据库操作部分
        #region FormatConnStr 格式化连接字符串
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

        #region TestConnstring 测试连接字符串
        /// <summary>
        /// 测试连接字符串
        /// </summary>
        /// <param name="ConnStr"></param>
        /// <returns></returns>
        public static bool TestConnstring(string ConnStr)
        {
            try
            {
                if (ConnStr == "")
                    ConnStr = ReadConnString();
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GetFirstData 读取第一行第一列记录
        /// <summary>
        /// 读取第一行第一列记录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string GetFirstData(string sql)
        {
            string ret = "";            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                                if (dr.Read())
                                    ret = dr[0].ToString();
                                else
                                    ret = "";
                            else
                                ret = "";
                            dr.Close();
                        }
                    }
                }
            }
            catch
            {
                return "";
            }
            return ret;
        }
        #endregion

        #region ExecuteSQL 执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteSQL(string sql)
        {
            bool ret = false;            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {                        
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        ret = true;
                    }
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        #endregion 

        #region ExecuteSQL 执行SQL语句
        public static bool ExecuteSQL(string sql, params SqlParameter[] parameters)
        {
            bool ret = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {                    
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        ret = true;
                    }
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        #endregion

        #region ExecuteNonQuery 执行SQL语句,返回受影响行数，异常返回-1
        /// <summary>
        /// 执行SQL语句,返回受影响行数，异常返回-1
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region ExecuteNonQuery 执行SQL语句,返回受影响行数，异常返回-1
        /// <summary>
        /// 执行SQL语句,返回受影响行数，异常返回-1
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            int ret = 0;            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {                    
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                ret = -1;
            }
            return ret;
        }
        #endregion

        #region ExecuteSQLErrorINFO 执行SQL语句,失败返回错误信息
        /// <summary>
        ///  执行SQL语句,失败返回错误信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string ExecuteSQLErrorINFO(string sql)
        {            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return "";
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region ExecuteSQLErrorINFO 执行SQL语句,失败返回错误信息
        /// <summary>
        /// 执行SQL语句,失败返回错误信息
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string ExecuteSQLErrorINFO(string sql, params SqlParameter[] parameters)
        {            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {                    
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cmd.CommandText = sql;                        
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return "";
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        #endregion

        #region GetDataset 获取数据集
        /// <summary>
        /// 获取数据集，True：有行；False没有行/异常
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool GetDataset(DataSet ds, string sql)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            conn.Close();
                            if (ds.Tables[0].Rows.Count > 0)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }     

        #endregion

        #region GetDataset 获取数据集
        /// <summary>
        /// 获取数据集，True：有行；False没有行/异常
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool GetDataset(DataSet ds, string sql, params SqlParameter[] parameters)
        {            
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {                    
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            conn.Close();
                            if (ds.Tables[0].Rows.Count > 0)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GetDatatable 获取DataTable
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dt"></param>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        public static bool GetDatatable(string sql, out DataTable dt, out string errmsg)
        {
            bool b = false;
            errmsg = "";
            dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dt.Load(dr);
                            if (dt.Rows.Count > 0)
                                b = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
            }
            return b;
        }
        #endregion 

        #region GetDatatable 获取DataTable
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dt"></param>
        /// <param name="errmsg"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool GetDatatable(string sql, out DataTable dt, out string errmsg, params SqlParameter[] parameters)
        {
            bool b = false;
            errmsg = "";
            dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(FConnString))
                {                    
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dt.Load(dr);
                            if (dt.Rows.Count > 0)
                                b = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
            }
            return b;
        }
        #endregion 

        //执行SQL脚本文件
        #region ExecuteSqlFile 执行SQL脚本文件
        /// <summary>
        /// 执行SQL脚本文件
        /// </summary>
        /// <param name="fileMapServerPath">文件完整路径，示例：Server.MapPath("~") + "\\Doc\\Sql.sql"</param>
        /// <param name="ServerIP">SQL服务器地址</param>
        /// <param name="UserID">用户名</param>
        /// <param name="Passwd">密码</param>
        /// <param name="DBName">数据库名称</param>
        /// <returns></returns>
        public static string ExecuteSqlFile(string fileMapServerPath, string ServerIP, string UserID, string Passwd, string DBName)
        {
            string ret = "";
            try
            {
                System.Diagnostics.Process sqlprocess = new System.Diagnostics.Process();
                sqlprocess.StartInfo.FileName = "osql.exe";
                //U为用户名,P为密码,S为目标服务器的ip,infile为数据库脚本所在的路径
                sqlprocess.StartInfo.Arguments = String.Format("-U {0} -P {1} -S {2} -i {3} -d {4}",
                    UserID, Passwd, ServerIP, fileMapServerPath, DBName);
                sqlprocess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                sqlprocess.Start();
                //等待程序执行.Sql脚本
                sqlprocess.WaitForExit();
                sqlprocess.Close();
                //File.Delete(sPath);
                //Response.Write("执行初始化脚本成功！");               
            }
            catch (Exception ex)
            {
                ret = "执行失败：" + ex.Message;
            }
            return ret;
        }
        #endregion 

        #region CreateDataBase 创建数据库
        public static string CreateDataBase(string ServerIP, string UID, string Pwd, string CreatedbName)
        {
            string ret = "";
            try
            {
                if (!IsLetter_Number(CreatedbName))
                    return "数据库名字只能包含字母和数字";
                string conn = FormatConnStr(ServerIP, UID, Pwd, "master");
                string sql = "IF NOT EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = '" + CreatedbName
                    + "') CREATE DATABASE " + CreatedbName;
                ret = ExecuteSQLErrorINFO(sql);
            }
            catch (Exception ex)
            {
                ret = "创建数据库失败：" + ex.Message;
            }
            return ret;
        }
        #endregion 
        
        //================================================= 参数部分 =================================================
        #region AddParameter 函数原型
        /// <summary>
        /// 函数原型
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterSize"></param>
        /// <param name="Direction"></param>
        /// <returns></returns>
        public static SqlParameter AddParameter(string parameterName, object parameterValue, SqlDbType dbType, int parameterSize, ParameterDirection Direction)
        {
            SqlParameter par = new SqlParameter();
            par.ParameterName = parameterName;
            par.Value = parameterValue;
            par.Direction = Direction;
            par.SqlDbType = dbType;
            if (parameterSize > 0)
                par.Size = parameterSize;
            return par;
        }
        #endregion

        #region GetAllParametersName 获取 SqlParameter[] 全部参数名称和类型
        /// <summary>
        /// 获取 SqlParameter[] 全部参数名称和类型
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetAllParametersName(params SqlParameter[] parameters)
        {
            string ret = "", sItem = "";
            int i = 0, iCount = parameters.Length;
            for (i = 0; i < iCount; i++)
            {
                sItem = parameters[i].ParameterName;
                if (parameters[i].Direction == ParameterDirection.Output || parameters[i].Direction == ParameterDirection.InputOutput)
                {
                    sItem = sItem + " out";
                }
                if (ret == "")
                    ret = sItem;
                else
                    ret = ret + "," + sItem;
            }
            return ret;
        }
        #endregion

        /********************** 输入参数 **********************/

        #region AddInParameter 添加输入参数 -- 完整类型
        /// <summary>
        /// 添加输入参数 -- 完整类型
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterSize"></param>
        /// <returns></returns>
        public static SqlParameter AddInParameter(string parameterName, object parameterValue, SqlDbType dbType, int parameterSize)
        {
            return AddParameter(parameterName, parameterValue, dbType, parameterSize, ParameterDirection.Input);
        }
        #endregion

        #region AddInParameter 添加输入参数 -- 省略长度
        /// <summary>
        /// 添加输入参数 -- 省略长度
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static SqlParameter AddInParameter(string parameterName, object parameterValue, SqlDbType dbType)
        {
            return AddParameter(parameterName, parameterValue, dbType, 0, ParameterDirection.Input);
        }
        #endregion

        #region  AddInVarcharParameter 添加输入参数 -- varchar（最大8K）
        /// <summary>
        /// 添加输入参数 -- varchar（最大8K）
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="parameterSize"></param>
        /// <returns></returns>
        public static SqlParameter AddInVarcharParameter(string parameterName, object parameterValue, int parameterSize)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, parameterSize, ParameterDirection.Input);
        }
        #endregion

        #region AddInVarcharParameter 添加输入参数 -- varchar（最大8K）
        /// <summary>
        /// 添加输入参数 -- varchar（最大8K）
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter AddInVarcharParameter(string parameterName, string parameterValue)
        {
            int parameterSize = parameterValue.Length;
            if (parameterSize > 8000)
                parameterSize = 8000;
            return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, parameterSize, ParameterDirection.Input);
        }
        #endregion

        #region AddInTextParameter 添加输入参数 -- Text 最大2G
        /// <summary>
        /// 添加输入参数 -- Text 最大2G
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter AddInTextParameter(string parameterName, string parameterValue)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.Text, 0, ParameterDirection.Input);
        }
        #endregion

        #region AddInIntParameter 添加输入参数 -- int
        /// <summary>
        /// 添加输入参数 -- int
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter AddInIntParameter(string parameterName, object parameterValue)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.Int, 0, ParameterDirection.Input);
        }
        #endregion

        #region AddInDecimalParameter 添加输入参数 -- Decimal
        /// <summary>
        /// 添加输入参数 -- Decimal
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter AddInDecimalParameter(string parameterName, object parameterValue)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.Decimal, 0, ParameterDirection.Input);
        }
        #endregion

        /********************** 输入、输出参数 **********************/

        #region AddInOutParameter 添加输入、输出参数 -- 完整类型
        /// <summary>
        /// 添加输入、输出参数 -- 完整类型
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterSize"></param>
        /// <returns></returns>
        public static SqlParameter AddInOutParameter(string parameterName, object parameterValue, SqlDbType dbType, int parameterSize)
        {
            return AddParameter(parameterName, parameterValue, dbType, parameterSize, ParameterDirection.InputOutput);
        }
        #endregion

        #region AddInOutParameter 添加输入、输出参数 -- 省略长度
        /// <summary>
        /// 添加输入、输出参数 -- 省略长度
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static SqlParameter AddInOutParameter(string parameterName, object parameterValue, SqlDbType dbType)
        {
            return AddParameter(parameterName, parameterValue, dbType, 0, ParameterDirection.InputOutput);
        }
        #endregion

        #region AddInOutIntParameter 添加输入、输出参数 -- int
        /// <summary>
        /// 添加输入、输出参数 -- int
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter AddInOutIntParameter(string parameterName, object parameterValue)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.Int, 0, ParameterDirection.InputOutput);
        }
        #endregion

        #region  AddInOutDecimalParameter 添加输入、输出参数 -- Decimal
        /// <summary>
        /// 添加输入、输出参数 -- Decimal
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter AddInOutDecimalParameter(string parameterName, object parameterValue)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.Decimal, 0, ParameterDirection.InputOutput);
        }
        #endregion

        #region AddInOutVarcharParameter 添加输入、输出参数 -- varchar（最大8K）
        /// <summary>
        /// 添加输入、输出参数 -- varchar（最大8K）
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="parameterSize"></param>
        /// <returns></returns>
        public static SqlParameter AddInOutVarcharParameter(string parameterName, object parameterValue, int parameterSize)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, parameterSize, ParameterDirection.InputOutput);
        }
        #endregion

        #region AddInOutVarcharParameter 添加输入、输出参数 -- varchar（默认最大8K）
        /// <summary>
        /// 添加输入、输出参数 -- varchar（默认最大8K）
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static SqlParameter AddInOutVarcharParameter(string parameterName, object parameterValue)
        {
            return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, 8000, ParameterDirection.InputOutput);
        }
        #endregion

        /********************** 输出参数 **********************/

        #region AddOutParameter 添加输出参数
        /// <summary>
        /// 添加输出参数
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static SqlParameter AddOutParameter(string parameterName, SqlDbType dbType)
        {
            return AddParameter(parameterName, DBNull.Value, dbType, 0, ParameterDirection.Output);
        }
        #endregion

        #region AddOutIntParameter 添加输出参数 -- int
        /// <summary>
        /// 添加输出参数 -- int
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static SqlParameter AddOutIntParameter(string parameterName)
        {
            return AddParameter(parameterName, DBNull.Value, SqlDbType.Int, 0, ParameterDirection.Output);
        }
        #endregion

        #region AddOutDecimalParameter 添加输出参数 -- Decimal
        /// <summary>
        /// 添加输出参数 -- Decimal
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static SqlParameter AddOutDecimalParameter(string parameterName)
        {
            return AddParameter(parameterName, DBNull.Value, SqlDbType.Decimal, 0, ParameterDirection.Output);
        }
        #endregion

        #region AddOutVarcharParameter 添加输出参数 -- Varchar（最大8K）
        /// <summary>
        /// 添加输出参数 -- Varchar（最大8K）
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static SqlParameter AddOutVarcharParameter(string parameterName)
        {
            return AddParameter(parameterName, DBNull.Value, SqlDbType.VarChar, 8000, ParameterDirection.Output);
        }
        #endregion

        /********************** 数据转换 **********************/

        #region GetIntValue SqlParameter value  to int
        /// <summary>
        /// SqlParameter value  to int
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static int GetIntValue(SqlParameter para)
        {
            try
            { return int.Parse(para.Value.ToString()); }
            catch
            { return 0; }
        }
        #endregion

        #region GetIntValue string to int
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

        #region GetStrValue SqlParameter value to string
        /// <summary>
        /// SqlParameter value to string
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static string GetStrValue(SqlParameter para)
        {
            try
            { return para.Value.ToString(); }
            catch
            { return ""; }
        }
        #endregion

        #region GetDecimalValue SqlParameter value to decimal
        /// <summary>
        /// SqlParameter value to decimal
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static decimal GetDecimalValue(SqlParameter para)
        {
            try
            { return decimal.Parse(para.Value.ToString()); }
            catch
            { return 0; }
        }
        #endregion

        #region GetDecimalValue string to decimal
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
}