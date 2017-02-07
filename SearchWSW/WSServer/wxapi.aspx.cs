using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//
using System.IO;
using System.Text;

public partial class wxapi : System.Web.UI.Page
{
    private static string FsToken = "rongzp";
    protected void Page_Load(object sender, EventArgs e)
    {
        //微信API接口，处理自动回复信息
        string postStr = "";
        try
        {
            //调试语句
            /*
            string xml = "<xml><ToUserName><![CDATA[gh_5f788506be4b]]></ToUserName>"
                +"<FromUserName><![CDATA[oJGUItxhOFWSd0xQTUBddxCQ7ljM]]></FromUserName>"
                +"<CreateTime>1486434746</CreateTime><MsgType><![CDATA[text]]></MsgType>"
                +"<Content><![CDATA[1]]></Content><MsgId>6384188622198534618</MsgId></xml>";
            AnalysisXML(xml);
            return;*/
            //
            if (Request.HttpMethod.ToLower() == "post")
            {
                Stream s = System.Web.HttpContext.Current.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int)s.Length);
                postStr = Encoding.UTF8.GetString(b);
                //处理请求
                if (!string.IsNullOrEmpty(postStr))
                {
                    AnalysisXML(postStr);
                }
            }
            else
            {
                //验证签名
                CheckSignature(true);
            }
        }
        catch
        {
            Response.Write("no request");
        }
    }


    private void AnalysisXML(string postxml)
    {
        string signature = this.Page.Request.QueryString["signature"].ToString();
        string timestamp = this.Page.Request.QueryString["timestamp"].ToString();
        string nonce = this.Page.Request.QueryString["nonce"].ToString();
        //string check = CheckSignature(false);
        bool bCheck = ulwxMsgXML.CheckSignature(signature, timestamp, nonce, FsToken);
        string xml = "";
        ulwxMsgXML wxMsg = new ulwxMsgXML(postxml);
        if (!bCheck)
            xml = wxMsg.GetFormatText("非法请求");
        else
        {
            string msg = "未定义回复内容";
            switch (wxMsg.MsgType)
            {
                case "event":
                    {
                        xml = Doit.DoEvent(wxMsg.Event, wxMsg.EventKey, wxMsg.UserID);
                        break;
                    }
                case "text":
                    {
                        xml = Doit.DoText(wxMsg.Content, wxMsg.UserID);
                        break;
                    }
                default:
                    {
                        xml = msg;
                        break;
                    }
            }
            xml = wxMsg.GetFormatText(xml);
        }
        Response.Write(xml);
    }

    #region 微信签名认证
    /// <summary>
    /// 验证微信签名
    /// </summary>
    /// <returns></returns>
    private string CheckSignature(bool onlyCheck)
    {
        string ret = "error";
        //获取传来的值
        //Fsignature = this.Page.Request.QueryString["signature"].ToString();
        //Ftimestamp = this.Page.Request.QueryString["timestamp"].ToString();
        //Fnonce = this.Page.Request.QueryString["nonce"].ToString();
        string Fechostr = this.Page.Request.QueryString["echostr"].ToString();
        //
        string signature = this.Page.Request.QueryString["signature"].ToString();
        string timestamp = this.Page.Request.QueryString["timestamp"].ToString();
        string nonce = this.Page.Request.QueryString["nonce"].ToString();
        string[] ArrTmp = { FsToken, timestamp, nonce };
        Array.Sort(ArrTmp);//字典排序
        string tmpStr = string.Join("", ArrTmp);
        tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");//对该字符串进行sha1加密
        tmpStr = tmpStr.ToLower();//对字符串中的字母部分进行小写转换，非字母字符不作处理

        if (tmpStr == signature)//开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        {
            //return true;
            if (onlyCheck)
                Response.Write(Fechostr);
            else
                ret = "";
        }
        else
            //return false;
            Response.Write("Check Signatrue Error!");
        return ret;
    }
    #endregion
}
