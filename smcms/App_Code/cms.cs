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
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
///cms 的摘要说明
/// </summary>
public class cms
{
    private static string FsFooter = "";
    private static string FsHeader = "";
    private static string FsIndex = "";
    private static Dictionary<string, string> FgArticleList = new Dictionary<string, string>();
    public static Dictionary<string, string> FgConfig = new Dictionary<string, string>();
	public cms()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// CleanAllCache 清空所有缓存
    /// </summary>
    public static void CleanAllCache()
    {
        FsHeader = "";
        FsFooter = "";
        FsIndex = "";
        FgArticleList.Clear();
        FgConfig.Clear();
    }

    public static string GetPath(string FileName)
    {
        return System.Web.HttpContext.Current.Server.MapPath(FileName);
    }

    #region GetTemplateContent 获取模板内容（格式化）
    /// <summary>
    /// 获取模板内容（格式化）
    /// </summary>
    /// <param name="templateName"></param>
    /// <returns></returns>
    public static string GetTemplateContent(string templateName)
    {
        try
        {
            string content = GetTemplate(templateName);
            content = FmtTemplate(content);
            content = content.Replace("<@header>", GetHeader());
            content = content.Replace("<@footer>", GetFooter());
            content = FmtArticleList(content);
            return content;
        }
        catch
        {
            return "";
        }
    }
    //获取模板
    private static string GetTemplate(string templateName)
    {
        try
        {
            string file = GetPath("~/template/" + templateName + ".htm");
            return System.IO.File.ReadAllText(file);
        }
        catch
        {
            return "";
        }
    }
    //格式化模板内路径
    private static string FmtTemplate(string templateContent)
    {
        //image
        if (templateContent.Contains("./image/"))
            templateContent = templateContent.Replace("./image/", "./template/image/");
        else if (templateContent.Contains("image/"))
            templateContent = templateContent.Replace("image/", "./template/image/");
        //css
        if (templateContent.Contains("./css/"))
            templateContent = templateContent.Replace("./css/", "./template/css/");
        else if (templateContent.Contains("css/"))
            templateContent = templateContent.Replace("css/", "./template/css/");
        //js
        if (templateContent.Contains("./js/"))
            templateContent = templateContent.Replace("./js/", "./template/js/");
        else if (templateContent.Contains("js/"))
            templateContent = templateContent.Replace("js/", "./template/js/");
        return templateContent;
    }
    //获取底部信息
    private static string GetFooter()
    {
        if (FsFooter == "")
        {
            FsFooter = GetTemplate("footer");
            FsFooter = FmtTemplate(FsFooter);
        }
        return FsFooter;
    }
    //获取头部信息
    private static string GetHeader()
    {
        if (FsHeader == "")
        {
            FsHeader = GetTemplate("header");
            FsHeader = FmtTemplate(FsHeader);
            if (FsHeader.Contains("<@navigar>"))
                FsHeader = FsHeader.Replace("<@navigar>", GetNavigar());
        }
        return FsHeader;
    }
    //获取导航条
    public static string GetNavigar()
    {
        return GetConfig("Navigar");
    }
    //格式化文章标签列表
    private static string FmtArticleList(string templateContent)
    {
        int iCount = 0;
        string Ret = templateContent,
            key = "";
        string pat = @"<@class=[A-Za-z0-9;].*@>";
        Regex reg = new Regex(pat, RegexOptions.IgnoreCase);
        MatchCollection matches = reg.Matches(templateContent);
        iCount = matches.Count;
        if (iCount == 0)
            return templateContent;
        foreach (Match mc in matches)
        {
            key = mc.Value;
            GetArticleList(key);
            if (FgArticleList.ContainsKey(key))
                Ret = Ret.Replace(key, FgArticleList[key]);
        }
        return Ret;
    }
    //根据文章标签获取文章列表
    private static void GetArticleList(string listTag)
    {
        string cmd = listTag.Replace("<@", "").Replace("@>", "").Replace("class=", "").Replace("count=", "").Replace("length=", "");
        string[] list = cmd.Split(';');
        int iClass = 0,
            iCount = 0,
            iLength = 0;
        if (list.Length > 0)
            iClass = StrToInt(list[0]);
        if (list.Length > 1)
            iCount = StrToInt(list[1]);
        if (list.Length > 2)
            iLength = StrToInt(list[2]);

        if (iClass > 0 && iClass > 0)
        {
            if (!FgArticleList.ContainsKey(listTag))
            {
                string data = mod_article.GetListString(iClass, iCount, iLength);
                FgArticleList.Add(listTag, data);
            }
        }
    }
    #endregion 

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
    public static string StrToDate(string str)
    {
        try
        {
            return DateTime.Parse(str).ToString("yyyy-MM-dd");
        }
        catch
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    //读取系统配置
    public static string GetConfig(string key)
    {
        string ret = "";
        key = key.Replace("'", "");
        if (key == "")
            return "";
        if (!FgConfig.ContainsKey(key))
        {
            string sql = "exec proc_smcms_config '" + key + "'";
            ret = ulLinnStudio.ulSqlHelper.GetFirstData(sql);
            FgConfig.Add(key, ret);
        }
        return FgConfig[key];
    }

    //保存系统配置
    public static bool SaveConfig(string key, string value)
    {
        string sql = "proc_smcms_config";
        SqlParameter[] p = new SqlParameter[] { 
          ulLinnStudio.ulSqlHelper.AddInVarcharParameter("@key", key),
          ulLinnStudio.ulSqlHelper.AddInTextParameter("@value", value),
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@IsEdit", 1)
        };
        return ulLinnStudio.ulSqlHelper.ExecuteSQL(sql, p);
    }

    //===================================== 业务部分 ===============================

    //获取首页内容
    public static string GetIndex()
    {
        string index = GetTemplateContent("index");
        /*
        index = FmtTemplate(index);
        string head = GetHeader(),
            foot = GetFooter();
        //
        index = index.Replace("<@header>", head);
        index = index.Replace("<@footer>", foot);
        //<@class=1;count=5@>
        index = FmtArticleList(index);
        */
        //
        return index;
    }

    //获取分类列表
    public static string GetClass(Page page)
    {
        string sClass = GetTemplateContent("class");
        int classID = 1,
            pageIndex = 1,
            pageSize = 20,
            iCount = 0,
            iPageCount = 1;
        if (page.Request.QueryString["id"] != null)
            classID = StrToInt(page.Request.QueryString["id"].ToString());
        if (page.Request.QueryString["page"] != null)
            pageIndex = StrToInt(page.Request.QueryString["page"].ToString());
        if (page.Request.QueryString["size"] != null)
            pageSize = StrToInt(page.Request.QueryString["size"].ToString());
        if (classID == 0)
            classID = 1;
        if (pageIndex == 0)
            pageIndex = 1;
        if (pageSize == 0)
            pageSize = 20;
        //获取文章列表和页码内容
        string list = "", li = "", date = "", pageInfo = "";
        DataTable dt = mod_article.SearchPage(classID, pageIndex, pageSize);
        if (dt.Rows.Count > 0)
        {
            iCount = StrToInt(dt.Rows[0]["Count"].ToString());
            iPageCount = StrToInt(dt.Rows[0]["PageCount"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                date = "["+StrToDate(dt.Rows[i]["FDate"].ToString())+"]";                
                li = "<li>"+date+"<a href=\"./article.aspx?id="+dt.Rows[i]["ID"].ToString()+"\">"
                    +dt.Rows[i]["Title"].ToString()+"</a></li>";
                list = list + li;
            }
        }
        pageInfo = GetPageInfo(classID, pageIndex, iPageCount, pageSize);
        sClass = FmtArticleList(sClass);
        if (sClass.Contains("<@article>"))
            sClass = sClass.Replace("<@article>", list);
        if (sClass.Contains("<@page>"))
            sClass = sClass.Replace("<@page>", pageInfo);
        //
        return sClass;
    }

    private static string GetPageInfo(int classID, int currPage, int pageCount, int pageSize)
    {
        string info = "第 "+currPage.ToString() + " 页 / 共 " + pageCount.ToString() + " 页", p1 = "", p2 = "";
        if (currPage > 1)
            p1 = "<a href=\"./class.aspx?id=" + classID.ToString() + "&page=" + (currPage - 1).ToString() 
                + "&size=" + pageSize + "\">上一页</a>";
        if (currPage < pageCount)
            p2 = "<a href=\"./class.aspx?id=" + classID.ToString() + "&page=" + (currPage + 1).ToString() 
                + "&size=" + pageSize + "\">下一页</a>";
        return p1 + " " + info + " " + p2;
    }

    //显示文章
    public static void GetArticle(Page page)
    {
        int id = 0;
        if (page.Request.QueryString["id"] != null)
            id = StrToInt(page.Request.QueryString["id"].ToString());
        if (id == 0)
        {
            page.Response.Redirect("./index.aspx");
            return;
        }
        string str = GetTemplateContent("article");
        mod_article art = new mod_article(id);
        str = str.Replace("<@title>", art.Title);
        str = str.Replace("<@date>", art.FDate);
        str = str.Replace("<@content>", art.Content);
        str = str.Replace("<@last>", art.Last());
        str = str.Replace("<@next>", art.Next());
        page.Response.Write(str);
    }

    public static bool adminLogin(string uid, string pwd)
    {
        bool b = false;
        uid = uid.Replace("'", "").Replace(" ", "");
        pwd = ulLinnStudio.ulSqlHelper.GetMD5String(pwd);
        string sql = "select UserID from smcms_admin where UserID = '" + uid + "' and Passwd = '" + pwd + "'";
        if (ulLinnStudio.ulSqlHelper.GetFirstData(sql).ToLower() == "admin")
            b = true;
        return b;
    }
}
