using System;
using System.Xml;
using System.Web.Security;

/// <summary>
/// ulwxMsgXML 的摘要说明
/// Author: julinn
/// update: 2014-12-01 15:26:15
/// Webnet: www.liuju.net
/// GitHub: https://github.com/julinn/LinnStudio
/// </summary>
public class ulwxMsgXML
{
	public ulwxMsgXML(string GetPostXmlString)
	{
        iniMsgData(GetPostXmlString);
    }

    #region 消息原型结构定义
    private string _DevpID = "";
    /// <summary>
    /// 公众号ID
    /// </summary>
    public string DevpID { get { return _DevpID; } set { _DevpID = value; } }

    private string _UserID = "";
    /// <summary>
    /// 用户ID
    /// </summary>
    public string UserID { get { return _UserID; } set { _UserID = value; } }

    private string _CreateTime = "";
    /// <summary>  
    /// 创建时间  
    /// </summary>  
    public string CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }

    private string _CreateTimeStr = "";
    /// <summary>  
    /// 创建时间String 格式  
    /// </summary>  
    public string CreateTimeStr { get { return _CreateTimeStr; } set { _CreateTimeStr = value; } }

    private string _MsgType = "";
    /// <summary>
    /// 消息类型
    /// </summary>
    public string MsgType { get { return _MsgType; } set { _MsgType = value; } }
        
    private string _MsgID = "";
    /// <summary>
    /// 消息ID
    /// </summary>
    public string MsgID { get { return _MsgID; } set { _MsgID = value; } }

    private string _MediaId = "";
    /// <summary>
    /// 语音图像视频信息ID
    /// </summary>
    public string MediaId { get { return _MediaId; } set { _MediaId = value; } }

    private string _Content = "";
    /// <summary>
    /// 文本消息内容
    /// </summary>
    public string Content { get { return _Content; } set { _Content = value; } }

    private string _PicUrl = "";
    /// <summary>
    /// 图片URL
    /// </summary>
    public string PicUrl { get { return _PicUrl; } set { _PicUrl = value; } }

    private string _Format = "";
    /// <summary>
    /// 语音格式，如amr，speex等
    /// </summary>
    public string Format { get { return _Format; } set { _Format = value; } }

    private string _ThumbMediaId = "";
    /// <summary>
    /// 视频消息缩略图的媒体id
    /// </summary>
    public string ThumbMediaId { get { return _ThumbMediaId; } set { _ThumbMediaId = value; } }

    private string _Location_X = "";
    /// <summary>
    /// 地理位置_X
    /// </summary>
    public string Location_X { get { return _Location_X; } set { _Location_X = value; } }

    private string _Location_Y = "";
    /// <summary>
    /// 地理位置_Y
    /// </summary>
    public string Location_Y { get { return _Location_Y; } set { _Location_Y = value; } }

    private string _Scale = "";
    /// <summary>
    /// 地图缩放大小
    /// </summary>
    public string Scale { get { return _Scale; } set { _Scale = value; } }

    private string _Label = "";
    /// <summary>
    /// 地理位置信息
    /// </summary>
    public string Label { get { return _Label; } set { _Label = value; } }

    private string _Title = "";
    /// <summary>
    /// 链接消息-消息标题
    /// </summary>
    public string Title { get { return _Title; } set { _Title = value; } }

    private string _Description = "";
    /// <summary>
    /// 链接消息-消息描述
    /// </summary>
    public string Description { get { return _Description; } set { _Description = value; } }

    private string _Url = "";
    /// <summary>
    /// 链接消息-消息链接
    /// </summary>
    public string Url { get { return _Url; } set { _Url = value; } }

    private string _Event = "";
    /// <summary>
    /// 事件类型，subscribe(订阅)、unsubscribe(取消订阅)
    /// </summary>
    public string Event { get { return _Event; } set { _Event = value; } }

    private string _eventKey = "";
    /// <summary>
    /// CLICK事件KEY值，与自定义菜单接口中KEY值对应
    /// </summary>
    public string EventKey { get { return _eventKey; } set { _eventKey = value; } }

    #endregion 

    #region unix时间转换为datetime
    /// <summary>
    /// unix时间转换为datetime
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public static DateTime UnixTimeToTime(string timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dtStart.Add(toNow);
    }
    #endregion 

    #region datetime转换为unixtime
    /// <summary>
    /// datetime转换为unixtime
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static int ConvertDateTimeInt(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (int)(time - startTime).TotalSeconds;
    }
    #endregion 

    #region 初始化接收到的消息对象各属性值
    /// <summary>
    /// 初始化接收到的消息对象各属性值
    /// </summary>
    /// <param name="GetPostXmlString"></param>
    private void iniMsgData(string GetPostXmlString)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(GetPostXmlString);
        XmlElement root = doc.DocumentElement;
        DevpID = root.SelectSingleNode("ToUserName").InnerText;
        UserID = root.SelectSingleNode("FromUserName").InnerText;
        CreateTime = root.SelectSingleNode("CreateTime").InnerText;
        CreateTimeStr = UnixTimeToTime(CreateTime).ToString();
        MsgType = root.SelectSingleNode("MsgType").InnerText;
        switch (MsgType)
        {
            case "event":
                {
                    Event = root.SelectSingleNode("Event").InnerText;
                    if(Event.ToUpper() == "CLICK")
                        EventKey = root.SelectSingleNode("EventKey").InnerText;
                    break;
                }
            case "text":
                {
                    Content = root.SelectSingleNode("Content").InnerText;
                    break;
                }
            case "image":
                {
                    PicUrl = root.SelectSingleNode("PicUrl").InnerText;
                    MediaId = root.SelectSingleNode("MediaId").InnerText;
                    break;
                }
            case "voice":
                {
                    MediaId = root.SelectSingleNode("MediaId").InnerText;
                    Format = root.SelectSingleNode("Format").InnerText;
                    break;
                }               
            case "video":
                {
                    MediaId = root.SelectSingleNode("MediaId").InnerText;
                    ThumbMediaId = root.SelectSingleNode("ThumbMediaId").InnerText;
                    break;
                }              
            case "location":
                {
                    Location_X = root.SelectSingleNode("Location_X").InnerText;
                    Location_Y = root.SelectSingleNode("Location_Y").InnerText;
                    Scale = root.SelectSingleNode("Scale").InnerText; ;
                    Label = root.SelectSingleNode("Label").InnerText;
                    break;
                }
            case "link":
                {
                    Title = root.SelectSingleNode("Title").InnerText;
                    Description = root.SelectSingleNode("Description").InnerText;
                    Url = root.SelectSingleNode("Url").InnerText; ;
                    break;
                }
        }
    }
    #endregion 

    #region 验证签名
    /// <summary>
    /// 验证签名
    /// </summary>
    /// <param name="signature">签名字符串</param>
    /// <param name="timestamp">时间戳</param>
    /// <param name="nonce">随机数</param>
    /// <param name="token">Your Token</param>
    /// <returns></returns>
    public static bool CheckSignature(string signature, string timestamp, string nonce, string token)
    {
        string[] ArrTmp = { token, timestamp, nonce };
        Array.Sort(ArrTmp);
        string tmpStr = string.Join("", ArrTmp);
        tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
        tmpStr = tmpStr.ToLower();
        if (tmpStr == signature)
        {
            return true;
        }
        else
            return false;
    }
    #endregion 

    /************************************ 消息回复内容参数格式化 ************************************/
    /// <summary>
    /// 格式化回复消息头
    /// </summary>
    public string GetFormatHead()
    {
        return "<xml>"
                   + "<ToUserName><![CDATA[" + UserID + "]]></ToUserName>"
                   + "<FromUserName><![CDATA[" + DevpID + "]]></FromUserName>"
                   + "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
    }

    /// <summary>
    /// 格式化转接客户服务
    /// </summary>
    /// <returns></returns>
    public string GetFormatTransferCustomerService()
    {

        return "<xml>"
                   + "<ToUserName><![CDATA[" + UserID + "]]></ToUserName>"
                   + "<FromUserName><![CDATA[" + DevpID + "]]></FromUserName>"
                   + "<CreateTime>" + CreateTime + "</CreateTime>"
                   + "<MsgType><![CDATA[transfer_customer_service]]></MsgType>"
                   + "</xml>";

     
        /*
        return GetFormatHead()
            + "<MsgType><![CDATA[transfer_customer_service]]></MsgType>";
         */
    }

    /// <summary>
    /// 格式化文本消息
    /// </summary>
    /// <param name="sMsg">回复的消息内容 换行:\n</param>
    /// <returns></returns>
    public string GetFormatText(string sMsg)
    {
        return GetFormatHead()
               + "<MsgType><![CDATA[text]]></MsgType>"
               + "<Content><![CDATA[" + sMsg + "]]></Content>"
               + "</xml>";
    }

    /// <summary>
    /// 格式化图片消息
    /// </summary>
    /// <param name="MediaId">通过上传多媒体文件，得到的id</param>
    /// <returns></returns>
    public string GetFormatImage(string MediaId)
    {
        return GetFormatHead()
               + "<MsgType><![CDATA[image]]></MsgType>"
               + "<Image>"
               + "<MediaId><![CDATA[" + MediaId + "]]></MediaId>"
               + "</Image>"
               + "</xml>";
    }

    /// <summary>
    /// 格式化语音消息
    /// </summary>
    /// <param name="MediaId">通过上传多媒体文件，得到的id</param>
    /// <returns></returns>
    public string GetFormatVoice(string MediaId)
    {
        return GetFormatHead()
               + "<MsgType><![CDATA[voice]]></MsgType>"
               + "<Voice>"
               + "<MediaId><![CDATA[" + MediaId + "]]></MediaId>"
               + "</Voice>"
               + "</xml>";
    }

    /// <summary>
    /// 格式化视频消息
    /// </summary>
    /// <param name="MediaId">通过上传多媒体文件，得到的id</param>
    /// <param name="ThumbMediaId">缩略图的媒体id，通过上传多媒体文件，得到的id</param>
    /// <returns></returns>
    public string GetFormatVideo(string MediaId, string ThumbMediaId)
    {
        return GetFormatHead()
               + "<MsgType><![CDATA[video]]></MsgType>"
               + "<Video>"
               + "<MediaId><![CDATA[" + MediaId + "]]></MediaId>"
               + "<ThumbMediaId><![CDATA[" + ThumbMediaId + "]]></ThumbMediaId>"
               + "</Video>"
               + "</xml>";
    }

    /// <summary>
    /// 格式化音乐消息
    /// </summary>
    /// <param name="Title">音乐标题</param>
    /// <param name="Description">音乐描述</param>
    /// <param name="MusicUrl">音乐链接</param>
    /// <param name="HQMusicUrl">高质量音乐链接，WIFI环境优先使用该链接播放音乐</param>
    /// <param name="ThumbMediaId">缩略图的媒体id，通过上传多媒体文件，得到的id</param>
    /// <returns></returns>
    public string GetFormatMusic(string Title, string Description, string MusicUrl, string HQMusicUrl, string ThumbMediaId)
    {
        return GetFormatHead()
               + "<MsgType><![CDATA[music]]></MsgType>"
               + "<Music>"
               + "<Title><![CDATA[" + Title + "]]></Title>"
               + "<Description><![CDATA[" + Description + "]]></Description>"
               + "<MusicUrl><![CDATA[" + MusicUrl + "]]></MusicUrl>"
               + "<HQMusicUrl><![CDATA[" + HQMusicUrl + "]]></HQMusicUrl>"
               + "<ThumbMediaId><![CDATA[" + ThumbMediaId + "]]></ThumbMediaId>"
               + "</Music>"
               + "</xml>";
    }

    /// <summary>
    /// 格式化单条图文消息
    /// </summary>
    /// <param name="Title">图文消息标题</param>
    /// <param name="Description">图文消息描述</param>
    /// <param name="picUrl">图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200</param>
    /// <param name="Url">点击图文消息跳转链接</param>
    /// <returns></returns>
    public string GetFormatSingleImageText(string Title, string Description, string picUrl, string Url)
    {
        return GetFormatHead()
               + "<MsgType><![CDATA[news]]></MsgType>"
               + "<ArticleCount>1</ArticleCount>"
               + "<Articles>"
               + "<item>"
               + "<Title><![CDATA[" + Title + "]]></Title>"
               + "<Description><![CDATA[" + Description + "]]></Description>"
               + "<PicUrl><![CDATA[" + picUrl + "]]></PicUrl>"
               + "<Url><![CDATA[" + Url + "]]></Url>"
               + "</item>"
               + "</Articles>"
               + "</xml>";
    }

    /// <summary>
    /// 格式化多图文消息单条明细（单独不可直接发送，需要和GetFormatMultiImageText组合使用）
    /// </summary>
    /// <param name="Title">图文消息标题</param>
    /// <param name="Description">图文消息描述</param>
    /// <param name="picUrl">图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200</param>
    /// <param name="Url">点击图文消息跳转链接</param>
    /// <returns></returns>
    public static string GetFormatMultiImageTextItem(string Title, string Description, string picUrl, string Url)
    {
        return "<item>"
               + "<Title><![CDATA[" + Title + "]]></Title>"
               + "<Description><![CDATA[" + Description + "]]></Description>"
               + "<PicUrl><![CDATA[" + picUrl + "]]></PicUrl>"
               + "<Url><![CDATA[" + Url + "]]></Url>"
               + "</item>";
    }

    /// <summary>
    /// 格式化多条图文消息（需要搭配GetFormatMultiImageTextItem来格式化单条记录）
    /// </summary>
    /// <param name="ItemList">消息明细列表，通过 GetFormatMultiImageTextItem 格式化</param>
    /// <param name="Count">消息明细项数量</param>  
    /// <returns></returns>
    public string GetFormatMultiImageText(string ItemList,string Count)
    {
        return GetFormatHead()
               + "<MsgType><![CDATA[news]]></MsgType>"
               + "<ArticleCount>" + Count + "</ArticleCount>"
               + "<Articles>"
               + ItemList
               + "</Articles>"
               + "</xml>";
    }
}
