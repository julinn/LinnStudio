using System;
using System.Data;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Xml;

/// <summary>
///ulwxPayApi 的摘要说明
/// </summary>
public class ulwxPayApi
{
    protected Dictionary<string, string> parameters;

    private string _appID;
    public string appID { get { return _appID; } set { _appID = value; } }

    private string _mchID;
    public string mchID { get { return _mchID; } set { _mchID = value; } }

    private string _appKey;
    public string appKey { get { return _appKey; } set { _appKey = value; } }

    private string _partnerID;
    public string partnerID { get { return _partnerID; } set { _partnerID = value; } }

    private string _partnerKey;
    public string partnerKey { get { return _partnerKey; } set { _partnerKey = value; } }

    //通知URL
    private string _notifyUrl;
    public string notifyUrl { get { return _notifyUrl; } set { _notifyUrl = value; } }

    //订单类型 JSAPI、NATIVE、APP
    private string _tradeType;
    public string tradeType { get { return _tradeType; } set { _tradeType = value; } }

    //签名
    private string _paySign;
    public string paySign { get { return _paySign; } set { _paySign = value; } }

    //提交返回结果
    private Dictionary<string, string> _postResult;
    public Dictionary<string, string> postResult { get { return _postResult; } set { _postResult = value; } }

	public ulwxPayApi(Dictionary<string, string> wxConfig)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        parameters = new Dictionary<string, string>();
        ini(wxConfig);
	}

    /*=====================================公共基础参数部分=====================================*/
    #region MD5String MD5 加密（返回大写）
    /// <summary>
    ///  MD5 加密（返回大写）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string MD5String(string str)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
    }
    #endregion 

    #region  UnixTimeToTime unix时间转换为datetime
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

    #region DateTimeToUnixtime datetime转换为unixtime
    /// <summary>
    /// datetime转换为unixtime
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static int DateTimeToUnixtime(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (int)(time - startTime).TotalSeconds;
    }
    #endregion 

    #region IsNumeric 检测是否数字
    public static bool IsNumeric(String str)
    {
        try
        {
            int.Parse(str);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion 

    #region  CreateNoncestr 生成随机码
    public static string CreateNoncestr()
    {
        String chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        String res = "";
        Random rd = new Random();
        for (int i = 0; i < 16; i++)
        {
            res += chars[rd.Next(chars.Length - 1)];
        }
        return res;
    }

    public static String CreateNoncestr(int length)
    {
        String chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        String res = "";
        Random rd = new Random();
        for (int i = 0; i < length; i++)
        {
            res += chars[rd.Next(chars.Length - 1)];
        }
        return res;
    }

    public static string CreateNonceNum(int length)
    {
        string chars = "0123456789";
        string ret = "";
        Random rd = new Random();
        for (int i = 0; i < length; i++)
        {
            ret += chars[rd.Next(chars.Length - 1)];
        }
        return ret;
    }
    public static string CreateNonceNum()
    {
        string chars = "0123456789";
        string ret = "";
        Random rd = new Random();
        for (int i = 0; i < 4; i++)
        {
            ret += chars[rd.Next(chars.Length - 1)];
        }
        return ret;
    }
    public static string CreateTimestamp()
    {
        return DateTimeToUnixtime(DateTime.Now).ToString();
    }

    #endregion

    #region CreateBillNo 生成订单号 (25)
    /// <summary>
    /// 生成订单号 (25)
    /// </summary>
    /// <returns></returns>
    public static string CreateBillNo()
    {
        string ret = "";
        string dt = DateTime.Now.ToString("yyyyMMddHHmmssffffff");//20位
        ret = dt + CreateNonceNum(5);
        return ret;
    }    
    #endregion 


    #region GetUrlData Http Get 获取网页内容
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

    #region PostUrlData Http Post 获取网页内容
    /// <summary>
    /// Http Post 获取网页内容
    /// </summary>
    /// <param name="TheURL">url</param>
    /// <param name="postData">postData</param>
    /// <returns></returns>
    public static string PostUrlData(string TheURL, string postData)
    {
        try
        {
            Uri uri = new Uri(TheURL);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            request.Timeout = 5000;
            request.ContentLength = data.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            //
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

    #region ListSort  List排序 Dictionary<string, string> parameters
    /// <summary>
    /// List排序 Dictionary<string, string> parameters
    /// </summary>
    /// <param name="inList"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ListSort(Dictionary<string, string> inList)
    {
        string listnames = "";
        Dictionary<string, string> ret = new Dictionary<string, string>();
        foreach (KeyValuePair<string, string> kvp in inList)
        {
            listnames += kvp.Key + ",";
        }
        if (listnames.Length == 0 == false)
        {
            listnames = listnames.Substring(0, (listnames.Length - 1));
        }
        string[] listname = listnames.Split(',');
        Array.Sort(listname);
        int i = 0, iCount = listname.Length;
        string name = "", value = "";
        for (i = 0; i < iCount; i++)
        {
            name = listname[i];
            value = inList[name].ToString();
            ret.Add(name, value);
        }
        return ret;
    }
    #endregion 

    #region ListToXML List 转为 XML （Dictionary<string, string> arr）
    /// <summary>
    /// List 转为 XML （Dictionary<string, string> arr）
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static string ListToXML(Dictionary<string, string> arr)
    {
        String xml = "<xml>";
        foreach (KeyValuePair<string, string> pair in arr)
        {
            String key = pair.Key;
            String val = pair.Value;
            if (IsNumeric(val))
            {
                xml += "<" + key + ">" + val + "</" + key + ">";

            }
            else
                xml += "<" + key + "><![CDATA[" + val + "]]></" + key + ">";
        }
        xml += "</xml>";
        return xml;
    }
    #endregion 

    #region ListToUrl 格式化查询参数 Dictionary<string, string> parameters
    /// <summary>
    /// 格式化查询参数 Dictionary<string, string> parameters
    /// </summary>
    /// <param name="Parameters">Dictionary<string, string> parameters</param>
    /// <param name="urlencode">是否采用 UrlEncode</param>
    /// <returns></returns>
    public static string ListToUrl(Dictionary<string, string> Parameters, bool urlencode)
    {

        string buff = "";
        try
        {
            Dictionary<string, string> ret = ListSort(Parameters);
            foreach (KeyValuePair<string, string> pair in ret)
            {
                if (pair.Key != "")
                {

                    string key = pair.Key;
                    string val = pair.Value;
                    if (urlencode)
                    {
                        val = System.Web.HttpUtility.UrlEncode(val);
                    }
                    buff += key.ToLower() + "=" + val + "&";

                }
            }

            if (buff.Length == 0 == false)
            {
                buff = buff.Substring(0, (buff.Length - 1) - (0));
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return buff;
    }
    #endregion 

    /*=====================================内置函数=====================================*/
    //参数设置
    public void SetParameter(string parameterName, string parameterValue)
    {
        if (parameterName != null && parameterName != "")
        {
            if (parameters.ContainsKey(parameterName))
                parameters.Remove(parameterName);
            parameters.Add(parameterName, parameterValue);
        }
    }

    //初始化设置，读取wxConfig参数设置
    private void ini(Dictionary<string, string> wxConfig)
    {
        appID = wxConfig["AppID"];//wxConfig.AppID;
        appKey = wxConfig["MchKey"];//wxConfig.AppKey;
        mchID = wxConfig["MchID"];//wxConfig.Mch_ID;
        partnerID = "";// wxConfig["AppID"];//wxConfig.PartnerID;
        partnerKey = "";// wxConfig["AppID"];//wxConfig.PartnerKey;
        notifyUrl = wxConfig["NotifyUrl"];//wxConfig.Notify_Url;
    }

    //初始化参数
    private void iniParameters()
    {        
        parameters.Add("appid", appID);
        parameters.Add("mch_id", mchID);
        parameters.Add("nonce_str", CreateNoncestr());        
        parameters.Add("notify_url", notifyUrl);
        parameters.Add("trade_type", tradeType);        
    }

    //获取Navtive订单签名
    public string GetNativePaySign()
    {
        string ret = "";
        try
        {
            string s1 = ListToUrl(parameters, false);
            s1 = s1 + "&key=" + appKey;
            ret = MD5String(s1);
        }
        catch
        {
            ret = "";
        }
        return ret;
    }


    /*=====================================创建订单=====================================*/

    //设置订单参数
    /// <summary>
    /// 设置订单参数,成功返回""
    /// </summary>
    /// <param name="billNo"></param>
    /// <param name="GoodsDescription"></param>
    /// <param name="totalFee"></param>
    /// <param name="ClientIP"></param>
    /// <returns></returns>
    public string SetNativeParameter(string billNo, string GoodsDescription, double totalFee, string ClientIP)
    {
        string ret = "";
        if (billNo == "")
            return "单号不能为空";
        if (totalFee <= 0)
            return "收费金额必须大于0";
        try
        {
            parameters.Clear();
            tradeType = "NATIVE";
            parameters.Add("product_id", "0");
            iniParameters();
            parameters.Add("body", GoodsDescription);
            parameters.Add("out_trade_no", billNo);
            totalFee = totalFee * 100;            
            parameters.Add("total_fee", int.Parse(totalFee.ToString()).ToString());
            parameters.Add("spbill_create_ip", ClientIP);
            paySign = GetNativePaySign();
            parameters.Add("sign", paySign);
        }
        catch(Exception ex)
        {
            ret = "设置订单参数失败：" + ex.Message;
        }
        return ret;
    }

    /// <summary>
    /// 设置订单参数,成功返回""
    /// </summary>
    /// <param name="billNo"></param>
    /// <param name="GoodsDescription"></param>
    /// <param name="totalFee"></param>
    /// <param name="ClientIP"></param>
    /// <param name="OpenID"></param>
    /// <returns></returns>
    public string SetJSAPIParameter(string billNo, string GoodsDescription, double totalFee, string ClientIP, string OpenID)
    {
        string ret = "";
        if (billNo == "")
            return "单号不能为空";
        if (totalFee <= 0)
            return "收费金额必须大于0";
        try
        {
            parameters.Clear();
            tradeType = "JSAPI";
            iniParameters();
            parameters.Add("body", GoodsDescription);
            parameters.Add("out_trade_no", billNo);
            totalFee = totalFee * 100;
            parameters.Add("total_fee", int.Parse(totalFee.ToString()).ToString());
            parameters.Add("spbill_create_ip", ClientIP);
            parameters.Add("openid", OpenID);
            paySign = GetNativePaySign();
            parameters.Add("sign", paySign);
        }
        catch (Exception ex)
        {
            ret = "设置订单参数失败：" + ex.Message;
        }
        return ret;
    }

    //提交订单
    public bool PostBill()
    {
        bool  ret = false;
        postResult = new Dictionary<string, string>();
        try
        {
            string xml = ListToXML(parameters);
            string postUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            string getXML = PostUrlData(postUrl, xml);
            if (getXML == "")
                return false;
            postResult = GetPostResult(getXML);
            if (postResult["result_code"] == "SUCCESS")
                ret = true;
        }
        catch
        {
            ret = false;
        }
        return ret;
    }

    public bool PostBill(out string errmsg)
    {
        bool ret = false;
        errmsg = "创建订单失败，请稍后再试";
        postResult = new Dictionary<string, string>();
        try
        {
            string xml = ListToXML(parameters);
            string postUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            string getXML = PostUrlData(postUrl, xml);
            if (getXML == "")
                return false;
            postResult = GetPostResult(getXML);
            if (postResult["result_code"] == "SUCCESS")
                ret = true;
            else
                errmsg = "创建订单失败：" + postResult["return_msg"].ToString();
        }
        catch(Exception ex)
        {
            ret = false;
            errmsg = "创建订单失败：" + ex.Message.Replace("'","");
        }
        return ret;
    }

    #region GetPostResult 格式化订单提交结果-返回 Key - Value 数组
    /// <summary>
    /// 格式化订单提交结果-返回 Key - Value 数组
    /// </summary>
    /// <param name="returnXML">提交订单，微信服务器返回的XML</param>
    /// <returns></returns>
    private  Dictionary<string, string> GetPostResult(string returnXML)
    {
        string return_code = "", return_msg = "",
            appid = "", mch_id = "", nonce_str = "", sign = "", result_code = "",
            prepay_id = "", trade_type = "", code_url = "";
        Dictionary<string, string> ret = new Dictionary<string, string>();
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(returnXML);
            XmlElement root = doc.DocumentElement;
            //获取调用结果
            return_code = root.SelectSingleNode("return_code").InnerText;
            return_msg = root.SelectSingleNode("return_msg").InnerText;
            if (return_code == "SUCCESS")
            {
                //获取返回参数
                appid = root.SelectSingleNode("appid").InnerText;
                mch_id = root.SelectSingleNode("mch_id").InnerText;
                nonce_str = root.SelectSingleNode("nonce_str").InnerText;
                sign = root.SelectSingleNode("sign").InnerText;
                result_code = root.SelectSingleNode("result_code").InnerText;
                if (return_code == "SUCCESS")
                {
                    //获取返回的单据结果
                    prepay_id = root.SelectSingleNode("prepay_id").InnerText;
                    trade_type = root.SelectSingleNode("trade_type").InnerText;
                    code_url = root.SelectSingleNode("code_url").InnerText;
                }
            }
        }
        catch(Exception ex)
        {
            return_code = "FAIL";
            return_msg = "获取结果失败：" + ex.Message;
        }
        ret.Add("return_code", return_code);
        ret.Add("return_msg", return_msg);
        ret.Add("appid", appid);
        ret.Add("mch_id", mch_id);
        ret.Add("nonce_str", nonce_str);
        ret.Add("sign", sign);
        ret.Add("result_code", result_code);
        ret.Add("prepay_id", prepay_id);
        ret.Add("trade_type", trade_type);
        ret.Add("code_url", code_url);
        return ret;
    }
    #endregion 

    /*=====================================订单查询=====================================*/
    //QueryBill 查询订单是否支付成功
    #region QueryBill 查询订单是否支付成功
    /// <summary>
    /// 查询订单是否支付成功
    /// </summary>
    /// <param name="billNo">商户订单编号</param>
    /// <param name="BillInfo">订单详情</param>
    /// <returns>是否支付成功</returns>
    public bool QueryBill(string billNo, out Dictionary<string, string> BillInfo)
    {
        bool  ret = false;
        string queryUrl = "https://api.mch.weixin.qq.com/pay/orderquery";
        BillInfo = new Dictionary<string, string>();
        try
        {
            //定义查询结构体
            string xml = "";
            string tempSign = "";
            string tempAppid = appID;// wxConfig.AppID;// wxHOCRM.ReadSysConfig("AppID");
            string tempMch_id = mchID;// wxConfig.Mch_ID;// wxHOCRM.ReadSysConfig("MchID");
            string tempAppKey = appKey;// wxConfig.AppKey;// wxHOCRM.ReadSysConfig("AppKey");
            string tempNonce_str = CreateNoncestr();
            string content = "appid=" + tempAppid + "&mch_id=" + tempMch_id + "&nonce_str=" + tempNonce_str
                + "&out_trade_no=" + billNo + "&key=" + tempAppKey;
            tempSign = MD5String(content);

            xml = "<xml><appid>" + tempAppid + "</appid>"
                + "<mch_id>" + tempMch_id + "</mch_id>"
                + "<out_trade_no>" + billNo + "</out_trade_no>"
                + "<nonce_str>" + tempNonce_str + "</nonce_str>"
                + "<sign>" + tempSign + "</sign>"
                + "</xml>";
            //
            string getXML = PostUrlData(queryUrl, xml);
            BillInfo = FormatQueryResult(getXML);
            if (BillInfo["return_code"] == "SUCCESS" && BillInfo["result_code"] == "SUCCESS" && BillInfo["trade_state"] == "SUCCESS")
                ret = true;
            return ret;
        }
        catch
        {
            return false;
        }
    }

    public bool QueryBill(string billNo, out string payDatetime)
    {
        bool ret = false;
        payDatetime = "";
        string queryUrl = "https://api.mch.weixin.qq.com/pay/orderquery";
        Dictionary<string, string> BillInfo = new Dictionary<string, string>();
        try
        {
            //定义查询结构体
            string xml = "";
            string tempSign = "";
            string tempAppid = appID;// wxConfig.AppID;// wxHOCRM.ReadSysConfig("AppID");
            string tempMch_id = mchID;// ;// wxConfig.Mch_ID;// wxHOCRM.ReadSysConfig("MchID");
            string tempAppKey = appKey;// wxConfig.AppKey;// wxHOCRM.ReadSysConfig("AppKey");
            string tempNonce_str = CreateNoncestr();
            string content = "appid=" + tempAppid + "&mch_id=" + tempMch_id + "&nonce_str=" + tempNonce_str
                + "&out_trade_no=" + billNo + "&key=" + tempAppKey;
            tempSign = MD5String(content);

            xml = "<xml><appid>" + tempAppid + "</appid>"
                + "<mch_id>" + tempMch_id + "</mch_id>"
                + "<out_trade_no>" + billNo + "</out_trade_no>"
                + "<nonce_str>" + tempNonce_str + "</nonce_str>"
                + "<sign>" + tempSign + "</sign>"
                + "</xml>";
            //
            string getXML = PostUrlData(queryUrl, xml);
            BillInfo = FormatQueryResult(getXML);
            if (BillInfo["return_code"] == "SUCCESS" && BillInfo["result_code"] == "SUCCESS" && BillInfo["trade_state"] == "SUCCESS")
            {
                ret = true;
                payDatetime = BillInfo["time_end"];
            }
            return ret;
        }
        catch
        {
            return false;
        }
    }
    #endregion 

    #region ForamtPayDate 格式化微信支付返回的日期；yyyyMMddhhmmss  => yyyy-MM-dd hh:mm:ss
    /// <summary>
    /// 格式化微信支付返回的日期；yyyyMMddhhmmss  => yyyy-MM-dd hh:mm:ss
    /// </summary>
    /// <param name="dateStr">微信支付返回的日期字符串</param>
    /// <returns></returns>
    private static string ForamtPayDate(string dateStr)
    {
        string yyyy = dateStr.Substring(0, 4),
            MM = dateStr.Substring(4, 2),
            dd = dateStr.Substring(6, 2),
            hh = dateStr.Substring(8, 2),
            mm = dateStr.Substring(10, 2),
            ss = dateStr.Substring(12, 2);
        return yyyy + "-" + MM + "-" + dd + " " + hh + ":" + mm + ":" + ss;
    }
    #endregion 

    #region FormatQueryResult 格式化订单支付状态查询结果，返回 Key  - value 数组
    /// <summary>
    /// 格式化订单支付状态查询结果，返回 Key  - value 数组
    /// </summary>
    /// <param name="queryResultXML">订单查询返回的XML</param>
    /// <returns></returns>
    private static Dictionary<string, string> FormatQueryResult(string queryResultXML)
    {
        Dictionary<string, string> ret = new Dictionary<string, string>();
        string return_code = "", return_msg = "";
        string appid = "", mch_id = "", nonce_str = "", sign = "", result_code = "";
        string trade_state = "",
            openid = "", is_subscribe = "", trade_type = "", bank_type = "",
            total_fee = "", fee_type = "", transaction_id = "", out_trade_no = "",
            time_end = "", cash_fee = "";
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(queryResultXML);
            XmlElement root = doc.DocumentElement;
            //
            return_code = root.SelectSingleNode("return_code").InnerText;
            return_msg = root.SelectSingleNode("return_msg").InnerText;
            if (return_code.ToUpper() == "SUCCESS")
            {
                appid = root.SelectSingleNode("appid").InnerText;
                mch_id = root.SelectSingleNode("mch_id").InnerText;
                nonce_str = root.SelectSingleNode("nonce_str").InnerText;
                sign = root.SelectSingleNode("sign").InnerText;
                result_code = root.SelectSingleNode("result_code").InnerText;
                //
                if (result_code.ToUpper() == "SUCCESS")
                {
                    trade_state = root.SelectSingleNode("trade_state").InnerText;
                    if (trade_state.ToUpper() == "SUCCESS")
                    {
                        openid = root.SelectSingleNode("openid").InnerText;
                        is_subscribe = root.SelectSingleNode("is_subscribe").InnerText;
                        trade_type = root.SelectSingleNode("trade_type").InnerText;
                        bank_type = root.SelectSingleNode("bank_type").InnerText;
                        total_fee = root.SelectSingleNode("total_fee").InnerText;
                        fee_type = root.SelectSingleNode("fee_type").InnerText;
                        transaction_id = root.SelectSingleNode("transaction_id").InnerText;
                        out_trade_no = root.SelectSingleNode("out_trade_no").InnerText;
                        time_end = root.SelectSingleNode("time_end").InnerText;
                        time_end = ForamtPayDate(time_end);
                        cash_fee = root.SelectSingleNode("cash_fee").InnerText;
                        cash_fee = FeeIntToDouble(cash_fee).ToString();
                    }
                }
            }
        }
        catch(Exception ex)
        {
            return_code = "FAIL";
            return_msg = "查询失败：" + ex.Message;
        }
        //
        ret.Add("return_code", return_code);
        ret.Add("return_msg", return_msg);
        //
        ret.Add("appid", appid);
        ret.Add("mch_id", mch_id);
        ret.Add("nonce_str", nonce_str);
        ret.Add("sign", sign);
        ret.Add("result_code", result_code);
        //
        ret.Add("trade_state", trade_state);
        ret.Add("openid", openid);
        ret.Add("is_subscribe", is_subscribe);
        ret.Add("trade_type", trade_type);
        ret.Add("bank_type", bank_type);
        ret.Add("total_fee", total_fee);
        ret.Add("fee_type", fee_type);
        ret.Add("transaction_id", transaction_id);
        ret.Add("out_trade_no", out_trade_no);
        ret.Add("time_end", time_end);
        ret.Add("cash_fee", cash_fee);
        return ret;
    }
    #endregion 

    public static double FeeIntToDouble(string sFee)
    {
        double dFee = 0;
        try
        {
            dFee = double.Parse(sFee) / 100;
        }
        catch
        {
            dFee = 0;
        }
        return dFee;
    }

    /*=====================================JS签名=====================================*/
    public static string GetJSAPIPaySign(string appID, string appKey, string packageValue, string Noncestr, string Timestamp)
    {
        string ret = "";
        try
        {
            string str = "appId=" + appID + "&nonceStr=" + Noncestr + "&package=" + packageValue
                + "&signType=MD5&timeStamp=" + Timestamp + "&key=" + appKey;
            return MD5String(str);
        }
        catch
        {
            //
        }
        return ret;
    }

}
