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
using System.Data.SqlClient;
using System.Text;

/// <summary>
///article 的摘要说明
/// </summary>
public class mod_article
{
    private int _id = 0;
    public int ID { get { return _id; } set { _id = value; } }

    private string _title = "";
    public string Title { get { return _title; } set { _title = value; } }

    private string _content = "";
    public string Content { get { return _content; } set { _content = value; } }

    private int _cid = 0;
    public int CID { get { return _cid; } set { _cid = value; } }

    private string _userid = "";
    public string UserID { get { return _userid; } set { _userid = value; } }

    private string _fdate = "";
    public string FDate { get { return _fdate; } set { _fdate = value; } }

    private int _istop = 0;
    public int IsTop { get { return _istop; } set { _istop = value; } }

    public mod_article(int iID)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        iniData(iID);
	}

    private void iniData(int iID)
    {
        if (iID == 0)
            return;
        string sql = "select * from smcms_article where ID = " + iID.ToString(), 
            err = "";
        DataTable dt;
        if (ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt, out err))
        {
            ID = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["ID"].ToString());
            Title = dt.Rows[0]["Title"].ToString();
            Content = dt.Rows[0]["Content"].ToString();
            CID = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["CID"].ToString());
            UserID = dt.Rows[0]["UserID"].ToString();
            FDate = dt.Rows[0]["FDate"].ToString();
            IsTop = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["IsTop"].ToString());
        }
    }

    public string Last()
    {
        string ret = "没有了", err;
        string sql = "select top 1 * from smcms_article where CID = "+CID.ToString()+" and ID < "+ID.ToString() + " order by ID DESC ";
        DataTable dt;
        if(ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt,out err))
        {
            ret = "上一篇：<a href=\"./article.aspx?id="+dt.Rows[0]["ID"].ToString()+"\">"+dt.Rows[0]["Title"].ToString()+"</a>";
        }
        return ret;
    }

    public string Next()
    {
        string ret = "没有了", err;
        string sql = "select top 1 * from smcms_article where CID = " + CID.ToString() + " and ID > " + ID.ToString() + " order by ID ";
        DataTable dt;
        if (ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt, out err))
        {
            ret = "下一篇：<a href=\"./article.aspx?id=" + dt.Rows[0]["ID"].ToString() + "\">" + dt.Rows[0]["Title"].ToString() + "</a>";
        }
        return ret;
    }

    public string Save()
    {
        string sql = "proc_smcms_article_Edit";
        SqlParameter[] p = new SqlParameter[]{
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@ID", ID),
          ulLinnStudio.ulSqlHelper.AddInVarcharParameter("@Title", Title),
          ulLinnStudio.ulSqlHelper.AddInTextParameter("@Content", Content),
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@CID", CID),
          ulLinnStudio.ulSqlHelper.AddInVarcharParameter("@UserID", UserID),
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@IsTop", IsTop)
        };
        return ulLinnStudio.ulSqlHelper.ExecuteSQLErrorINFO(sql, p);
    }

    public static string Delete(int iID)
    {
        string sql = "delete from smcms_article where ID = " + iID.ToString();
        return ulLinnStudio.ulSqlHelper.ExecuteSQLErrorINFO(sql);
    }

    public static DataTable Search(int classID, int iCount, string str)
    {
        string sql = "proc_smcms_article_Search",
            err = "";
        SqlParameter[] p = new SqlParameter[] { 
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@CID", classID),
          ulLinnStudio.ulSqlHelper.AddInVarcharParameter("@Str", str),
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@Count", iCount)
        };
        DataTable dt;
        ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt, out err, p);
        return dt;
    }

    public static string GetListString(int classID, int iCount, int titleLength)
    {
        string ret = "", title = "", id = "0", shortTitle = "";
        DataTable dt = Search(classID, iCount, "");
        if (dt.Rows.Count > 0)
        {
            for(int i = 0; i < dt.Rows.Count ; i ++)
            {
                id = dt.Rows[i]["ID"].ToString();
                title = dt.Rows[i]["Title"].ToString();
                shortTitle = title;
                if (titleLength > 0)
                    shortTitle = CutTitle(shortTitle, titleLength);
                ret = ret + "<li><a href=\"./article.aspx?id=" + id + "\" title=\""+title+"\">" + shortTitle + "</a></li>";
            }
        }
        return ret;
    }

    public static DataTable SearchPage(int classID, int page, int pageSize)
    {
        string sql = "proc_smcms_article_SearchPage",
            err = "";
        SqlParameter[] p = new SqlParameter[] {
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@CID", classID),
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@Page", page),
          ulLinnStudio.ulSqlHelper.AddInIntParameter("@PageSize", pageSize)
        };
        DataTable dt;
        ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt, out err, p);
        return dt;
    }

    /// <summary>  
    /// 截取指定长度中英文字符串(宽度一样)  
    /// </summary>  
    /// <param name="str">要截取的字符串</param>  
    /// <param name="length">截取长度,中文字符长度</param>  
    /// <returns>截取后的字符串</returns>  
    public static string CutTitle(string str, int length)
    {
        if (str == null)
            return string.Empty;

        int len = length * 2;
        int j = 0, k = 0;
        Encoding encoding = Encoding.GetEncoding("gb2312");

        for (int i = 0; i < str.Length; i++)
        {
            byte[] bytes = encoding.GetBytes(str.Substring(i, 1));
            if (bytes.Length == 2)//不是英文  
                j += 2;
            else
                j++;

            if (j <= len)
                k += 1;

            if (j >= len)
                return str.Substring(0, k) + "...";
        }
        return str;
    } 
}
