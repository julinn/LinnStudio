using System;
using System.Collections.Generic;
using System.Text;
//
using System.Data;
using System.Net;
using System.IO;

namespace SearchWSW
{    
    class wsCore
    {
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="sBegin">开始标识</param>
        /// <param name="sEnd">结束标识</param>
        /// <returns></returns>
        public static string GetMiddleString(string str, string sBegin, string sEnd)
        {
            try
            {
                int iFrom = str.IndexOf(sBegin) + sBegin.Length,
                    iTo = str.IndexOf(sEnd);
                return str.Substring(iFrom, iTo - iFrom);
            }
            catch
            {
                return "";
            }
        }

        public static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；  
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                System.Windows.Forms.Application.DoEvents();//转让控制权              
            }
            return;
        }

        public static string FmtStr(string s)
        {
            return s.Replace("'", "").Replace(" ", "");
        }

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

        public static string GetPageInfo(string Html, string classUrl, out int iPageCount, out int iRecordCount)
        {
            string tempStr = "", result = "";
            iPageCount = 0;
            iRecordCount = 0;
            if (!classUrl.Contains("http://"))
                classUrl = "http://" + classUrl;
            if (classUrl.Contains(".html"))
            {
                classUrl = "http://" + GetMiddleString(classUrl, "http://", "/list_") + "/";
            }
            Html = Html.Replace(" ", "");
            Html = GetMiddleString(Html, "dede_pages>", "</SPAN></LI></UL>");
            //
            string sCount = GetMiddleString(Html, "共<STRONG>", "</STRONG>页"),
                sTotal = GetMiddleString(Html, "页<STRONG>", "</STRONG>条");
            iPageCount = StrToInt(sCount);
            iRecordCount = StrToInt(sTotal);

            //
            if (iPageCount > 1)
            {
                //list_3_1.html
                string pageFmt = GetMiddleString(Html, "<OPTIONselectedvalue=", "1.html>1</OPTION>");
                for (int i = 1; i <= iPageCount; i++)
                {
                    tempStr = classUrl + pageFmt + i.ToString() + ".html";
                    if (result == "")
                        result = tempStr;
                    else
                        result = result + "|" + tempStr;
                }
            }

            return result;
        }

        public static void SaveData(string wxID, string title, string showimg, string url)
        {
            wxID = FmtStr(wxID);
            title = FmtStr(title);
            showimg = FmtStr(showimg);
            url = FmtStr(url);
            if (wxID == "" || url == "")
                return;
            string sql = "call proc_xyws_Huoyuan_AutoExportIn('" + wxID + "','" + title + "','" + showimg + "','" + url + "')";
            ulMySqlHelper.GetFirstVar(sql);
        }

        /// <summary>
        /// 获取列表信息
        /// </summary>
        /// <param name="listHtml"></param>
        /// <returns></returns>
        public static string GetList(string listHtml)
        {
            string result = "", tempResult = "", sDomain = "www.wshangw.net",
                sFrom = "center-ctr-box>", sTo = "dede_pages";
            int iFrom = listHtml.IndexOf(sFrom) + sFrom.Length,
                iTo = listHtml.IndexOf(sTo);
            tempResult = listHtml.Substring(iFrom, iTo - iFrom);
            //
            tempResult = GetMiddleString(tempResult, "<!-- 观点列表 -->", "<!-- 观点列表/ -->");
            //分隔符 @
            tempResult = tempResult.Replace("<DIV class=opinions-list>", "@");
            //替换全部空格，去掉第一个 @
            tempResult = tempResult.Replace(" ", "");
            tempResult = tempResult.Replace("\n", "");
            tempResult = tempResult.Replace("\r", "");
            tempResult = tempResult.Replace("\t", "");
            tempResult = tempResult.Remove(0, 1);
            //载入数组， @分隔            
            string[] list = tempResult.Split('@');
            //循环数组
            string ls = "", wxID = "", showImg = "", url = "", title;
            for (int i = 0; i < list.Length; i++)
            {
                ls = list[i];
                showImg = sDomain + GetMiddleString(ls, "<LI><Ahref=\"", "\"target=_blank><IMG");
                wxID = GetMiddleString(ls, ">微信号：", "</P><!--<p");
                ls = GetMiddleString(ls, "<H4>", "</H4>");
                url = sDomain + GetMiddleString(ls, "href=\"", "\"target=_blank>");
                title = GetMiddleString(ls, "\"target=_blank>", "</A>");
                tempResult = wxID + "|" + title + "|" + showImg + "|" + url;
                //保存
                SaveData(wxID, title, showImg, url);
                if (result == "")
                    result = tempResult;
                else
                    result = result + "@" + tempResult;
            }            
            return result;
        }

        //获取待更新列表
        public static DataTable GetNoDetailList()
        {
            string sql = "call proc_xyws_Huoyuan_AutoUpdateSearch()",
                err = "";
            DataTable dt = new DataTable();
            ulMySqlHelper.GetaDatatable(sql, out dt, out err);
            return dt;
        }

        private static string FmtTimeStr(string str)
        {
            //2016-12-1217:51
            try
            {
                return str.Substring(0, 10);
            }
            catch
            {
                return "";
            }
        }
        public static void SaveDetail(int recID, string wxImg, string RecTime,  string content, string imagelist)
        {
            string sql = "call proc_xyws_Huoyuan_AutoUpdateDetail(";
            MySql.Data.MySqlClient.MySqlParameter[] paras = new MySql.Data.MySqlClient.MySqlParameter[]
            {
                //IN `_RecID` int, IN `_RecTime` datetime, IN `_wxImg` varchar(300),IN `_Content` text,IN `_ImageList` text
                ulMySqlHelper.AddIntParameter("@_RecID", recID),
                ulMySqlHelper.AddVarcharParameter("@_RecTime", RecTime),
                ulMySqlHelper.AddVarcharParameter("@_wxImg", wxImg),
                ulMySqlHelper.AddVarcharParameter("@_Content", content),
                ulMySqlHelper.AddVarcharParameter("@_ImageList", imagelist)
            };
            sql = sql + ulMySqlHelper.GetAllParametersName(paras) + ")";
           //string result =  ulMySqlHelper.GetFirstVar(sql, paras);
            //ulMySqlHelper.ExecuteStoreProcedure(sql, paras);
            ulMySqlHelper.ExecuteSql(sql, paras);
        }

        public static string GetDetailInfo(string Html, int recID)
        {
            string result = "", tempResult = "", sTime = "", swxImg = "", sContent = "", sImageList = "",
                sDomain = "http://www.wshangw.net";
            tempResult = GetMiddleString(Html, "center-ctr-box", "links");
            //tempResult = tempResult.Replace(" ", "");
            tempResult = tempResult.Replace("\n", "");
            tempResult = tempResult.Replace("\r", "");
            tempResult = tempResult.Replace("\t", "");
            sContent = GetMiddleString(tempResult, "<TBODY>", "</TBODY>");
            sContent = sContent.Replace("\"/uploads/", "\"" + sDomain + "/uploads/");
            tempResult = tempResult.Replace(" ", "");
            sTime = GetMiddleString(tempResult, "收录时间：", "</LI></UL>");
            sTime = FmtTimeStr(sTime);
            swxImg = sDomain + GetMiddleString(tempResult, "wxrighter2><IMGsrc=\"", "\"></DIV></DIV><DIVstyle=");            
            SaveDetail(recID, swxImg, sTime, sContent, sImageList);
            result = sTime + "|" + swxImg;// +"|" + sContent;
            //
            return result;
        }

        public static string HttpGet(string Url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET"; request.ContentType = "text/html";//;charset=UTF-8
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream);//, Encoding.GetEncoding("utf-8")
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }   
}
