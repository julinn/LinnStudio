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

    public static string GetTemplateContent(string templateName)
    {
        try
        {
            string file = GetPath("~/template/"+templateName+".htm");
            return System.IO.File.ReadAllText(file);
        }
        catch
        {
            return "";
        }
    }

    public static string FmtTemplate(string templateContent)
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

    public static string GetFooter()
    {
        if (FsFooter == "")
        {
            FsFooter = GetTemplateContent("footer");
            FsFooter = FmtTemplate(FsFooter);
        }
        return FsFooter;
    }

    public static string GetHeader()
    {
        if (FsHeader == "")
        {
            FsHeader = GetTemplateContent("header");
            FsHeader = FmtTemplate(FsHeader);
            if (FsHeader.Contains("<@navigar>"))
                FsHeader = FsHeader.Replace("<@navigar>", GetNavigar());
        }
        return FsHeader;
    }

    public static string GetNavigar()
    {
        return GetConfig("Navigar");
    }

    public static string GetIndex()
    {
        string index = GetTemplateContent("index");
        index = FmtTemplate(index);
        string head = GetHeader(),
            foot = GetFooter();
        //
        index = index.Replace("<@header>", head);
        index = index.Replace("<@footer>", foot);
        //<@class=1;count=5@>
        index = FmtArticleList(index);
        //
        return index;
    }

    private static string FmtArticleList(string index)
    {
        int iCount = 0;
        string Ret = index,
            key = "";
        string pat = @"<@class=[A-Za-z0-9;].*@>";
        Regex reg = new Regex(pat, RegexOptions.IgnoreCase);
        MatchCollection matches = reg.Matches(index);
        iCount = matches.Count;
        if (iCount == 0)
            return index;
        foreach (Match mc in matches)
        {
            key = mc.Value;
            GetArticleList(key);
            if (FgArticleList.ContainsKey(key))
                Ret = Ret.Replace(key, FgArticleList[key]);
        }
        return Ret;
    }

    private static void GetArticleList(string listTag)
    {
        string cmd = listTag.Replace("<@", "").Replace("@>", "").Replace("class=", "").Replace("count=", "").Replace("length=", "");
        string[] list = cmd.Split(';');
        int iClass = 0,
            iCount = 0,
            iLength = 0;
        if (list.Length > 0)
            iClass = StrToInt(list[0]);
        if(list.Length > 1)
            iCount = StrToInt(list[1]);
        if (list.Length > 2 )
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

    public static string GetConfig(string key)
    {
        string ret = "";
        key = key.Replace("'","");
        if(key == "")
            return "";
        if (!FgConfig.ContainsKey(key))
        {
            string sql = "exec proc_smcms_config '" + key + "'";
            ret = ulLinnStudio.ulSqlHelper.GetFirstData(sql);
            FgConfig.Add(key, ret);
        }
        return FgConfig[key];
    }
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
}
