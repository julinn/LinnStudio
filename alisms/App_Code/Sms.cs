using System;
//
using System.Web;
using System.Collections.Generic;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

/// <summary>
///Sms 的摘要说明
/// </summary>
public class Sms
{
    public static string Furl = "";
    public static string Fappkey = "";
    public static string Fappsecret = "";
    //缓存，1个号码一天只能获取 3次验证码
    public static int FismsCount = 3;
    //短信验证码间隔时间，默认60秒，一分钟只能获取一次验证码
    public static int Fispantime = 60;

	public Sms()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
    }

    #region GetCache 读取缓存
    /// <summary>
    /// 读取缓存对象
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <returns></returns>
    public static object GetCache(string cacheKey)
    {
        System.Web.Caching.Cache obj = HttpRuntime.Cache;
        return obj[cacheKey];
    }

    /// <summary>
    /// 读取缓存字符串
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <returns></returns>
    public static string GetCacheString(string cacheKey)
    {
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            if (obj[cacheKey] == null)
                return "";
            else
                return (string)obj[cacheKey];
        }
        catch
        {
            return "";
        }
    }
    #endregion

    #region SetCache 设置缓存
    /// <summary>
    /// 设置绝对过期时间缓存
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <param name="cacheObject"></param>
    /// <param name="absoluteExpiration"></param>
    /// <returns></returns>
    public static bool SetCache(string cacheKey, object cacheObject, DateTime absoluteExpiration)
    {
        bool b = false;
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            obj.Insert(cacheKey, cacheObject, null, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        catch
        {
            b = false;
        }
        return b;
    }
    /// <summary>
    /// 设置相对过期时间缓存
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <param name="cacheObject"></param>
    /// <param name="slidingExpiration"></param>
    /// <returns></returns>
    public static bool SetCache(string cacheKey, object cacheObject, TimeSpan slidingExpiration)
    {
        bool b = false;
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            obj.Insert(cacheKey, cacheObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration);
        }
        catch
        {
            b = false;
        }
        return b;
    }
    /// <summary>
    /// 设置相对过期时间缓存（秒）
    /// </summary>
    /// <param name="cacheKey"></param>
    /// <param name="cacheObject"></param>
    /// <param name="ExpirationSeconds"></param>
    /// <returns></returns>
    public static bool SetCache(string cacheKey, object cacheObject, int ExpirationSeconds)
    {
        bool b = false;
        try
        {
            System.Web.Caching.Cache obj = HttpRuntime.Cache;
            obj.Insert(cacheKey, cacheObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(ExpirationSeconds));
        }
        catch
        {
            b = false;
        }
        return b;
    }
    #endregion 

    //检查手机号码是否可发送验证码
    public static string CheckTelValid(string telNo)
    {
        string ret = "";
        if (!CheckIsTel(telNo))
            return "手机号码错误";
        string flag = GetCacheString("log_" + telNo);
        if (flag != "")
            ret = "1分钟内不可重复获取验证码";
        return ret;
    }

    //检查是否是手机号码
    public static bool CheckIsTel(string telNo)
    {
        bool b = false;
        try
        {
            if (telNo.Length == 11 && Int64.Parse(telNo) > 0)
                b = true;
        }
        catch
        {
            return false;
        }
        return b;
    }

    //检查是否没有超过每天最大数量
    public static string CheckTelCount(string telNo)
    {
        string ret = "";
        telNo = telNo + DateTime.Now.ToString("yyyy-MM-dd");
        int iCount = StrToInt(GetCacheString(telNo));
        if (iCount >= FismsCount)
            ret = "一天只能获取"+FismsCount.ToString()+"次验证码";
        return ret;
    }

    //验证码发送成功后，设置缓存
    public static void SendOk(string telNo)
    {
        try
        {
            SetCache("log_" + telNo, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Fispantime);
            string key = telNo + DateTime.Now.ToString("yyyy-MM-dd");
            int iCount = StrToInt(GetCacheString(key)) + 1;
            DateTime dtDay = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            SetCache(key, iCount.ToString(), dtDay);
        }
        catch
        {
            //
        }
    }

    //字符串转整数
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

    #region Send 发送短信
    /// <summary>
    /// 发送短信
    /// </summary>
    /// <param name="extend">公共回传参数（可选，如会员ID）</param>
    /// <param name="smsType">短信类型，默认值：normal</param>
    /// <param name="smsSignName">短信签名，必须是阿里大鱼管理中心可用签名</param>
    /// <param name="smsParas">短信模板变量，传参规则{"key":"value"}，key的名字须和申请模板中的变量名一致，多个变量之间以逗号隔开，示例：{"code":"1234","product":"alidayu"}</param>
    /// <param name="telNo">短信接收号码（11位手机号码，不能加0或+86）群发短信需传入多个号码，以英文逗号分隔，一次调用最多传入200个号码</param>
    /// <param name="smsTemplateCode">短信模板ID，必须是阿里大鱼管理中心可用模板ID</param>
    /// <returns></returns>
    public static string Send(string extend, string smsType, string smsSignName, string smsParas,string telNo, string smsTemplateCode)
    {
        string ret = "";
        try
        {
            ITopClient client = new DefaultTopClient(Furl, Fappkey, Fappsecret);
            AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
            req.Extend = extend;
            req.SmsType = smsType;
            req.SmsFreeSignName = smsSignName;
            req.SmsParam = smsParas;
            req.RecNum = telNo;
            req.SmsTemplateCode = smsTemplateCode;
            AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
            if (rsp.IsError)
            {
                ret = rsp.ErrMsg;
                if (ret == "")
                    ret = rsp.SubErrMsg;
                if (ret == "")
                    ret = "发送失败";
            }
        }
        catch(Exception ex)
        {
            ret = "发送失败："+ex.Message;
        }
        return ret;
    }
    #endregion 

    /// <summary>
    /// 发送验证码（默认模板：身份验证）
    /// </summary>
    /// <param name="telNo">手机号码</param>
    /// <param name="Code">验证码</param>
    /// <param name="ProductName">产品名称</param>
    /// <param name="err">错误信息</param>
    /// <returns></returns>
    public static bool SendCode_sfyz(string telNo, string Code, string ProductName, out string err)
    {
        err = "";
        bool b = false;
        err = CheckTelValid(telNo);
        if (err != "")
            return false;
        err = CheckTelCount(telNo);
        if (err != "")
            return false;
        //
        string paras = "{\"code\":\"" + Code + "\",\"product\":\"" + ProductName + "\"}";
        err = Send("", "normal", "身份验证", paras, telNo, "SMS_2005049");
        if (err == "")
        {
            b = true;
            SendOk(telNo);
        }
        return b;
    }
}
