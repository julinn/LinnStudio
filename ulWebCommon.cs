using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Net;

/// <summary>
/// ulWebCommon 的摘要说明
/// Author: julinn
/// update: 2020-08-22 15:35:07
/// website: www.julinn.com
/// </summary>
public class ulWebCommon
{
    private static string FsSignKey = "7YCtr0QB95AogNJ8";
    private static char[] constant ={'0','1','2','3','4','5','6','7','8','9',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
    public ulWebCommon()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region GetAppSetting 读取AppSetting节点参数值，错误返回空字符串 ""
    /// <summary>
    /// 读取AppSetting节点参数值，错误返回空字符串 ""
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetAppSetting(string key)
    {
        try
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
        catch
        {
            return "";
        }
    }
    #endregion

    #region MD5 MD5加密（小写）
    /// <summary>
    /// MD5加密（小写）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string MD5(string str)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
    }

    /// <summary>
    /// MD5加密（大写）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string MD5_Upper(string str)
    {
        return MD5(str).ToUpper();
    }

    #endregion

    #region TimeStamp 获取时间戳（yyyyMMddHHmmss）
    /// <summary>
    /// 获取时间戳（yyyyMMddHHmmss）
    /// </summary>
    /// <returns></returns>
    public static string TimeStamp()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmss");
    }
    #endregion

    #region Nonstr 获取随机码
    /// <summary>
    /// 获取随机码（6位）
    /// </summary>
    /// <returns></returns>
    public static string Nonstr()
    {
        return Nonstr(6);
    }
    /// <summary>
    /// 获取随机码（指定长度）
    /// </summary>
    /// <param name="Length"></param>
    /// <returns></returns>
    public static string Nonstr(int Length)
    {
        StringBuilder newRandom = new StringBuilder(62);
        Random rd = new Random();
        for (int i = 0; i < Length; i++)
        {
            newRandom.Append(constant[rd.Next(62)]);
        }
        return newRandom.ToString();
    }
    #endregion

    #region FmtDateTime  格式化日期格式

    /// <summary>
    /// 格式化日期格式，错误返回当前时间 yyyy-MM-dd HH:mm:ss
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string FmtDateTime(string str)
    {
        try
        {
            return DateTime.Parse(str).ToString("yyyy-MM-dd HH:mm:ss");
        }
        catch
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

    /// <summary>
    /// 格式化日期格式 yyyy-MM-dd HH:mm:ss；错误返回空字符串 ""
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string FmtDateTimeEmpty(string str)
    {
        try
        {
            return DateTime.Parse(str).ToString("yyyy-MM-dd HH:mm:ss");
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    ///  格式化日期格式，错误返回当前时间 yyyy-MM-dd HH:mm:ss
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string FmtDateTime(DateTime dt)
    {
        return dt.ToString("yyyy-MM-dd HH:mm:ss");
    }    

    /// <summary>
    /// 字符串转时间，传入非时间格式字符串，返回当前时间（yyyy-MM-dd HH:mm:ss）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static DateTime GetDateTime(string str)
    {
        return DateTime.Parse(FmtDateTime(str));
    }
    #endregion

    #region CheckTimeStamp 检查时间戳是否已过期 
    /// <summary>
    /// 检查时间戳是否已过期
    /// </summary>
    /// <param name="timestamp">时间戳</param>
    /// <param name="iMinutes">分钟数</param>
    /// <returns></returns>
    public static bool CheckTimeStamp(string timestamp, int iMinutes)
    {
        bool b = false;
        if (timestamp.Length != 14)
            return false;
        string sTime = timestamp.Substring(0, 4) + "-" + timestamp.Substring(4, 2) + "-" + timestamp.Substring(6, 2) + " " + timestamp.Substring(8, 2) + ":"
            + timestamp.Substring(10, 2) + ":" + timestamp.Substring(12, 2);
        DateTime dtTime = DateTime.Parse(FmtDateTime(sTime));
        if (dtTime.AddMinutes(iMinutes) > DateTime.Now)
            b = true;
        return b;
    }
    /// <summary>
    /// 检查时间戳是否已过期（10分钟）
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static bool CheckTimeStamp(string timestamp)
    {
        return CheckTimeStamp(timestamp, 10);
    }

    #endregion

    #region GetSignString 获取签名字符串
    /// <summary>
    /// 获取签名字符串
    /// </summary>
    /// <param name="data"></param>
    /// <param name="timestamp"></param>
    /// <param name="nonstr"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetSignString(string data, string timestamp, string nonstr, string key)
    {
        string ret = "", sData = data + timestamp + nonstr,
            sKey = MD5(timestamp+nonstr + key);
        sData = MD5(sData) + timestamp + nonstr + sKey;
        ret = MD5(sData + sKey);
        return ret;
    }
    /// <summary>
    /// 获取签名字符串（使用默认变量： FsSignKey）
    /// </summary>
    /// <param name="data"></param>
    /// <param name="timestamp"></param>
    /// <param name="nonstr"></param>
    /// <returns></returns>
    public static string GetSignString(string data, string timestamp, string nonstr)
    {
        return GetSignString(data, timestamp, nonstr, FsSignKey);
    }

    #endregion

    #region GetNewID 获取唯一ID（yyyyMMddHHmmss+GUID）
    /// <summary>
    /// 获取唯一ID（yyyyMMddHHmmss+GUID）
    /// </summary>
    /// <returns></returns>
    public static string GetNewID()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N");
    }
    #endregion
    
    #region  StrToInt 字符串转整形
    /// <summary>
    /// 字符串转整形，错误返回 0
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 字符串转整形，错误返回预设值（iDefout）
    /// </summary>
    /// <param name="str"></param>
    /// <param name="iDefout"></param>
    /// <returns></returns>
    public static int StrToInt(string str, int iDefout)
    {
        try
        {
            return int.Parse(str);
        }
        catch
        {
            return iDefout;
        }
    }
    #endregion

    #region FmtMoney 格式化金额
    /// <summary>
    ///格式化金额：保留2位小数（四舍五入）
    /// </summary>
    /// <param name="sMoney"></param>
    /// <returns></returns>
    public static double FmtMoney(string sMoney)
    {
        try
        {
            return FmtMoney(double.Parse(sMoney));
        }
        catch
        {
            return 0.00;
        }
    }

    /// <summary>
    /// 格式化金额：保留2位小数（四舍五入）
    /// </summary>
    /// <param name="dMoney"></param>
    /// <returns></returns>
    public static double FmtMoney(double dMoney)
    {
        try
        {
            return Math.Round(dMoney, 2, MidpointRounding.AwayFromZero);
        }
        catch
        {
            return 0.00;
        }
    }

    /// <summary>
    /// 格式化金额：自定义保留小数位数（四舍五入）
    /// </summary>
    /// <param name="dMoney"></param>
    /// <param name="iLen">自定义保留小数位数</param>
    /// <returns></returns>
    public static double FmtMoney(double dMoney, int iLen)
    {
        try
        {
            return Math.Round(dMoney, iLen, MidpointRounding.AwayFromZero);
        }
        catch
        {
            return 0.00;
        }
    }
    /// <summary>
    /// 格式化金额：自定义保留小数位数（四舍五入）
    /// </summary>
    /// <param name="sMoney"></param>
    /// <param name="iLen"></param>
    /// <returns></returns>
    public static double FmtMoney(string sMoney, int iLen)
    {
        try
        {
            return Math.Round(double.Parse(sMoney), iLen, MidpointRounding.AwayFromZero);
        }
        catch
        {
            return 0.00;
        }
    }
    #endregion

    #region ToBase64 简单加密 base64
    /// <summary>
    /// 简单加密 base64
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToBase64(string str)
    {
        byte[] b = System.Text.Encoding.Default.GetBytes(str);
        return Convert.ToBase64String(b);
    }

    /// <summary>
    /// 简单加密 base64（用于保存到配置txt文件， key = value格式，替换=为*）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToBase64_txt(string str)
    {
        return ToBase64(str).Replace("=", "*");
    }

    #endregion

    #region DeBase64 简单解密 base64
    /// <summary>
    /// 简单解密 base64
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string DeBase64(string str)
    {
        byte[] b = Convert.FromBase64String(str);
        return System.Text.Encoding.Default.GetString(b);
    }

    /// <summary>
    ///  简单解密 base64（用于读取配置txt文件，key = value格式，替换*为=）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string DeBase64_txt(string str)
    {
        return DeBase64(str.Replace("*","="));
    }

    #endregion

    #region GetURLData 获取URL数据
    public static bool GetURLData(string url, out string data)
    {
        bool b = false;
        try
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;//获取或设置请求凭据  
            byte[] pageData = client.DownloadData(url); //下载数据  
            data = Encoding.UTF8.GetString(pageData);
            b = true;
        }
        catch (WebException ex)
        {
            data = ex.Message;
        }
        return b;
    }
    #endregion

}