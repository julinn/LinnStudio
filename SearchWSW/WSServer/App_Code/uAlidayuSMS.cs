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
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
/// <summary>
///uAlidayuSMS 的摘要说明
///2017-02-05 13:31:14
///需要使用 TopSdk.dll
/// </summary>
public class uAlidayuSMS
{
    private static string FURL = "http://gw.api.taobao.com/router/rest"; //http://gw.api.tbsandbox.com/router/rest
    private static string FAppKey = "23263149";
    private static string FAppSecret = "f2ba08a64cc145c8a4ee87910aaeac0c";
    private static string FSignName = "信誉微商";

    public uAlidayuSMS()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static string SendNonstrCode(string tel, string code)
    {
        string ret = "";
        ITopClient client = new DefaultTopClient(FURL, FAppKey, FAppSecret);
        AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
        //req.Extend = "123456";
        req.SmsType = "normal";
        req.SmsFreeSignName = FSignName;
        req.SmsParam = "{\"code\":\"" + code + "\"}";
        req.RecNum = tel;
        req.SmsTemplateCode = "SMS_44320055";
        AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
        //Console.WriteLine(rsp.Body);
        //return rsp.Body;
        if (!rsp.Result.Success)
            ret = rsp.Result.Msg;
        return ret;
    }
}
