using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// SqlParameter 参数操作类
/// Author: julinn
/// update: 2014-05-15 17:52:45
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

    /// <summary>
    /// 添加输入、输出参数 -- int
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <returns></returns>
    public static SqlParameter AddInOutIntPara(string parameterName, object parameterValue)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.Int, 0, ParameterDirection.InputOutput);
    }

    /// <summary>
    /// 添加输入、输出参数 -- Decimal
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <returns></returns>
    public static SqlParameter AddInOutDecimalPara(string parameterName, object parameterValue)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.Decimal, 0, ParameterDirection.InputOutput);
    }

    /// <summary>
    /// 添加输入、输出参数 -- varchar（最大8K）
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <param name="parameterSize"></param>
    /// <returns></returns>
    public static SqlParameter AddInOutVarcharPara(string parameterName, object parameterValue, int parameterSize)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, parameterSize, ParameterDirection.InputOutput);
    }

    /// <summary>
    /// 添加输入、输出参数 -- varchar（默认最大8K）
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <returns></returns>
    public static SqlParameter AddInOutVarcharPara(string parameterName, object parameterValue)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, 8000, ParameterDirection.InputOutput);
    }

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

    /// <summary>
    /// 添加输出参数 -- int
    /// </summary>
    /// <param name="parameterName"></param>
    /// <returns></returns>
    public static SqlParameter AddOutIntPara(string parameterName)
    {
        return AddParameter(parameterName, DBNull.Value, SqlDbType.Int, 0, ParameterDirection.Output);
    }

    /// <summary>
    /// 添加输出参数 -- Decimal
    /// </summary>
    /// <param name="parameterName"></param>
    /// <returns></returns>
    public static SqlParameter AddOutDecimalPara(string parameterName)
    {
        return AddParameter(parameterName, DBNull.Value, SqlDbType.Decimal, 0, ParameterDirection.Output);
    }

    /// <summary>
    /// 添加输出参数 -- Varchar（最大8K）
    /// </summary>
    /// <param name="parameterName"></param>
    /// <returns></returns>
    public static SqlParameter AddOutVarcharPara(string parameterName)
    {
        return AddParameter(parameterName, DBNull.Value, SqlDbType.VarChar, 8000, ParameterDirection.Output);
    }

    /// <summary>
    /// 添加输入参数 -- varchar（最大8K）
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <param name="parameterSize"></param>
    /// <returns></returns>
    public static SqlParameter AddInVarcharPara(string parameterName, object parameterValue, int parameterSize)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, parameterSize, ParameterDirection.Input);
    }

    /// <summary>
    /// 添加输入参数 -- varchar（最大8K）
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <returns></returns>
    public static SqlParameter AddInVarcharPara(string parameterName, string parameterValue)
    {
        int parameterSize = parameterValue.Length;
        if (parameterSize > 8000)
            parameterSize = 8000;
        return AddParameter(parameterName, parameterValue, SqlDbType.VarChar, parameterSize, ParameterDirection.Input);
    }

    /// <summary>
    /// 添加输入参数 -- Text 最大2G
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <returns></returns>
    public static SqlParameter AddInTextPara(string parameterName, string parameterValue)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.Text, 0, ParameterDirection.Input);
    }

    /// <summary>
    /// 添加输入参数 -- int
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <returns></returns>
    public static SqlParameter AddInIntPara(string parameterName, object parameterValue)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.Int, 0, ParameterDirection.Input);
    }

    /// <summary>
    /// 添加输入参数 -- Decimal
    /// </summary>
    /// <param name="parameterName"></param>
    /// <param name="parameterValue"></param>
    /// <returns></returns>
    public static SqlParameter AddInDecimalPara(string parameterName, object parameterValue)
    {
        return AddParameter(parameterName, parameterValue, SqlDbType.Decimal, 0, ParameterDirection.Input);
    }
}
