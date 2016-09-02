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
using System.Xml;

public partial class wxapi : System.Web.UI.Page
{
    //Token
    protected static string FsToken = "token";
    //签名信息
    protected string Fsignature = "", Ftimestamp = "", Fnonce = "", Fechostr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string postStr = "";
        try
        {
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
                if (CheckSignature())
                    Response.Write(Fechostr);
                else
                    Response.Write("Check Signatrue Error!");
            }
        }
        catch
        {
            Response.Write("服务端设置成功，请按操作文档继续进行后续配置");
        }
    }

    #region 微信签名认证
    /// <summary>
    /// 验证微信签名
    /// </summary>
    /// <returns></returns>
    private bool CheckSignature()
    {
        //获取传来的值
        Fsignature = this.Page.Request.QueryString["signature"].ToString();
        Ftimestamp = this.Page.Request.QueryString["timestamp"].ToString();
        Fnonce = this.Page.Request.QueryString["nonce"].ToString();
        Fechostr = this.Page.Request.QueryString["echostr"].ToString();
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
            return true;
        }
        else
            return false;
    }
    #endregion

    #region 解析微信POST过来的XML
    /// <summary>
    /// 解析微信POST过来的XML
    /// </summary>
    private void AnalysisXML(string sGetXml)
    {
        string sMessage = "没有找到该类型消息回复内容！";
        string sXML = "";
        try
        {
            ulwxMsgXML msgXml = new ulwxMsgXML(sGetXml);
            switch (msgXml.MsgType)
            {
                case "event":
                    {
                        sXML = DoEvent(msgXml);
                        break;
                    }
                case "text":
                    {
                        sXML = DoText(msgXml);
                        break;
                    }
                /*
                case "image":
                    {
                        sXML = GetTranserMessage(msgXml);
                        if (sXML == "")
                            sXML = msgXml.GetFormatText(sMessage);
                        break;
                    }
                case "voice":
                    {
                        sXML = GetTranserMessage(msgXml);
                        if (sXML == "")
                            sXML = msgXml.GetFormatText(sMessage);
                        break;
                    }

                case "video":
                    {
                        sXML = GetTranserMessage(msgXml);
                        if (sXML == "")
                            sXML = msgXml.GetFormatText(sMessage);
                        break;
                    }

                case "location":
                    {
                        sXML = GetTranserMessage(msgXml);
                        if (sXML == "")
                            sXML = msgXml.GetFormatText(sMessage);
                        break;
                    }

                case "link":
                    {
                        sXML = GetTranserMessage(msgXml);
                        if (sXML == "")
                            sXML = msgXml.GetFormatText(sMessage);
                        break;
                    }
                 */
                default:
                    {
                        sXML = msgXml.GetFormatText(sMessage);
                        break;
                    }
            }
            Response.Write(sXML);
            Response.End();
        }
        catch
        {
            //
        }
    }

    #endregion

    #region 事件处理（关注，取消）
    /// <summary>
    /// 事件处理（关注，取消）
    /// </summary>
    /// <param name="msgXml"></param>
    /// <returns></returns>
    private string DoEvent(ulwxMsgXML msgXml)
    {
        string resultxml = "";
        //关注
        if (msgXml.Event == "subscribe")
        {
            resultxml = "欢迎关注！" + " \n " + "回复【1】，查询个人分红账单" + " \n " 
                + "回复【编号-验证码】，绑定个人角色； 例如：001-888888" ;
        }
        //取消关注
        if (msgXml.Event == "unsubscribe")
        {
            resultxml = "感谢您的关注！";
        }
        //Click 事件
        if (msgXml.Event.ToUpper() == "CLICK")
        {
            string eventKey = msgXml.EventKey;
            switch (eventKey)
            {
                case "1000": //签到
                    {
                        //wxHOCRM.GetEventReply(msgXml.UserID, 1);
                        resultxml = "签到成功！" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    }
                case "1001"://刷新当日订单支付状态
                    {
                        resultxml = "no cmd";// MyClass_UnifiedOrder.RefreshTodayBill(msgXml.UserID);
                        break;
                    }
                case "1002"://获取Wechat验证码
                    {
                        resultxml = "no cmd";// wxHOCRM.GetHowechatCode(msgXml.UserID);
                        break;
                    }
                case "2001"://获取排队情况
                    {
                        resultxml = "no cmd";//wxHOCRM.GetLineupCount(msgXml.UserID);
                        break;
                    }
                default:
                    {
                        resultxml = "没有定义的事件回复内容";
                        break;
                    }
            }
        }

        return msgXml.GetFormatText(resultxml);
    }
    #endregion 

    #region 回复文本消息
    /// <summary>
    /// 回复文本消息
    /// </summary>
    /// <param name="msgXml"></param>
    /// <returns></returns>
    private string DoText(ulwxMsgXML msgXml)
    {
        string resultxml = "",
            msg = "";
        if (!string.IsNullOrEmpty(msgXml.Content))
        {
            msg = msgXml.Content;
            if (msg == "1")
            {
                msg = coreGW.wxMemberCheck(msgXml.UserID);
            }
            else if (msg.Contains("-"))
            {
                msg = coreGW.wxMemberBind(msgXml.UserID, msg);
            }
            resultxml = msgXml.GetFormatText(msg);
        }
        return resultxml;
    }
    #endregion 

    #region 获取个人账单地址
    /// <summary>
    /// 获取登记个人信息地址
    /// </summary>
    /// <param name="sOpenID"></param>
    /// <returns></returns>
    private string GetUserUrl(string sOpenID)
    {
        string ret = "";// CRM.ReadSysConfig("RegUrl");
        ret = "http://1.smasp.net/index.aspx";
        ret = ret + "?OpenID=" + sOpenID;
        return "<a href=\"" + ret + "\">点击这里登记个人信息</a>";
    }
    #endregion
}
