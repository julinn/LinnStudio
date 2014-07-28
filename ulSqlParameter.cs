using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
/// SqlParameter 参数操作类
/// Author: julinn
/// update: 2014-05-22 11:19:24
/// Webnet: www.liuju.net
/// GitHub: https://github.com/julinn/LinnStudio
/// </summary>
public class ulSqlParameter
{
    public ulSqlParameter()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region 函数原型
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

<<<<<<< .mine
    #region 获取 SqlParameter[] 全部参数名称和类型
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

=======
    #region 获取 SqlParameter[] 全部参数名称和类型
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
    
>>>>>>> .r18
    /********************** 输入参数 **********************/

    #region 添加输入参数 -- 完整类型
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

    #region 添加输入参数 -- 省略长度
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

    #region  添加输入参数 -- varchar（最大8K）
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

    #region  添加输入参数 -- varchar（最大8K）
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

    #region 添加输入参数 -- Text 最大2G
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

    #region 添加输入参数 -- int
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

    #region  添加输入参数 -- Decimal
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

    #region 添加输入、输出参数 -- 完整类型
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

    #region 添加输入、输出参数 -- 省略长度
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

    #region 添加输入、输出参数 -- int
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

    #region   添加输入、输出参数 -- Decimal
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

    #region 添加输入、输出参数 -- varchar（最大8K）
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

    #region  添加输入、输出参数 -- varchar（默认最大8K）
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

    #region 添加输出参数
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

    #region  添加输出参数 -- int
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

    #region 添加输出参数 -- Decimal
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

    #region  添加输出参数 -- Varchar（最大8K）
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

    #region SqlParameter value  to int
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

    #region SqlParameter value to string
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

    #region SqlParameter value to decimal
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
