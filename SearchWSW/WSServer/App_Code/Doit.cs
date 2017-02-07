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
using System.IO;

/// <summary>
///Doit 的摘要说明
/// </summary>
public class Doit
{
    public static string FAccessTokenValidTime = "";
    public static string FAccessTokenString = "";
    public static string FAppID = "";
    public static string FAppSecret = "";

    public Doit()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region 检查是否微信浏览器
    /// <summary>
    /// 检查是否微信浏览器
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static bool CheckBrowserIsWeixin(Page page)
    {
        string ua = page.Request.UserAgent;
        return ua.Contains("MicroMessenger");
    }
    #endregion

    #region 获取字符串指定位置的字符
    /// <summary>
    /// 获取字符串指定位置的字符
    /// </summary>
    /// <param name="sStr">字符</param>
    /// <param name="sBegin">起始字符</param>
    /// <param name="sEnd">结束字符</param>
    /// <returns></returns>
    private static string GetMiddleString(string sStr, string sBegin, string sEnd)
    {
        string ret = "";
        try
        {
            int iBegin = sStr.IndexOf(sBegin) + sBegin.Length;
            int iEnd = sStr.IndexOf(sEnd);
            ret = sStr.Substring(iBegin, iEnd - iBegin);
        }
        catch
        {
            return "";
        }
        return ret;
    }
    #endregion

    #region Http Get 获取网页内容
    /// <summary>
    /// Http Get 获取网页内容
    /// </summary>
    /// <param name="TheURL">url</param>
    /// <returns></returns>
    public static string GetUrlData(string TheURL)
    {
        try
        {
            Uri uri = new Uri(TheURL);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            request.Timeout = 5000;
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            string retext = readStream.ReadToEnd().ToString();
            readStream.Close();
            return retext;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
    #endregion 

    public static string FmtStr(string str)
    {
        return str.Replace("'", "").Replace(" ", "");
    }

    public static string GetAccessToken()
    {
        string ret = "";
        if (FAccessTokenValidTime == "")
            FAccessTokenValidTime = DateTime.Now.AddDays(-1).ToString();
        DateTime dtValid = DateTime.Parse(FAccessTokenValidTime);
        if (dtValid > DateTime.Now && FAccessTokenString != "")
        {
            return FAccessTokenString;
        }
        string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid="
            + FAppID + "&secret=" + FAppSecret;
        string sHtml = GetUrlData(url);
        if (sHtml.Contains("access_token"))
        {
            ret = GetMiddleString(sHtml, "{\"access_token\":\"", "\",\"expires_in");
            if (ret != "")
            {
                FAccessTokenString = ret;//("AccessToken", ret);
                FAccessTokenValidTime = DateTime.Now.AddHours(2).ToString();
            }
        }
        return ret;
    }

    //
    public static void wxLog(string data)
    {
        data = FmtStr(data);
        string sql = "call proc_wxlog_add('"+data+"')";
        ulMySqlHelper.GetFirstVar(sql);
    }
    //
    
    //==================== 回复业务处理 =================
    public static string DoText(string str, string openID)
    {
        string result = "未定义回复",
            sql = "";
        if (str.Contains("bd,"))
        {
            string[] sbd = str.Split(',');
            if (sbd.Length == 3)
            {
                sql = "call proc_user_wxBind('"+openID+"','"+FmtStr(sbd[1]) + "','"+FmtStr(sbd[2])+"')";
                result = ulMySqlHelper.GetFirstVar(sql);
                if (result == "1")
                    result = "绑定成功";
            }
        }
        else if (str == "wjmm")
        {
            sql = "call proc_wx_user_resetPwd('" + openID + "')";
            result = ulMySqlHelper.GetFirstVar(sql);
        }
        else
        {
            FmtStr(str);
            sql = "call proc_wx_userTextCmd('" + openID + "','"+str+"')";
            result = ulMySqlHelper.GetFirstVar(sql);
        }
        return result;
    }

    /*
 {
     "button":[
     {	
          "type":"click",
          "name":"账号信息",
          "key":"1001"
      },
      {	
          "type":"click",
          "name":"一键登录",
          "key":"1002"
      },
      {
           "name":"更多...",
           "sub_button":[
           {	
               "type":"view",
               "name":"百度一下",
               "url":"http://m.baidu.com/"
            },
            {
               "type":"click",
               "name":"忘记密码",
               "key":"1003"
            }]
       }]
 }    
     
     */

    public static string DoEvent(string eve, string evekey, string openID)
    {
        string result = "未定义事件",
            sql = "";
        switch (eve)
        {
            case "subscribe": //订阅
                {
                    if (evekey.Contains("qrscene_"))//事件KEY值，qrscene_为前缀，后面为二维码的参数值
                    {
                        result = "";
                    }
                    else
                        result = "欢迎关注";
                    break;
                }
            case "unsubscribe"://取消订阅
                {
                    break;
                }
            case "SCAN": //事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id
                {
                    break;
                }
            case "CLICK": //自定义菜单接口中KEY值对应
                {  
                    if (evekey == "1001")
                    {
                        sql = "call proc_wx_userInfo('" + openID + "')";
                        result = ulMySqlHelper.GetFirstVar(sql);
                    }
                    if (evekey == "1002")
                    {
                        result = "暂不支持，敬请期待";
                    }
                    if (evekey == "1003")
                    {
                        result = "请回复：wjmm \n系统自动为您重设一个新密码";
                    }
                    break;
                }
            case "VIEW": //事件KEY值，设置的跳转URL
                {
                    break;
                }
        }
        return result;
    }
}
