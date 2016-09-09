using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
///mms 的摘要说明
/// </summary>
public class mms
{
	public mms()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static int FmtInt(string str)
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

    public static string FmtDate(string str)
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

    public static string FmtDatetime(string str)
    {
        try
        {
            return DateTime.Parse(str).ToString("yyyy-MM-dd HH:mm:ss");
        }
        catch
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

    public static double FmtAmount(string str)
    {
        try
        {
            return double.Parse(double.Parse(str).ToString("0.00"));
        }
        catch
        {
            return 0;
        }
    }

    public static string FmtStr(string str)
    {
        return str.Replace("'", "");
    }

    /// <summary>
    /// 登录检测
    /// </summary>
    /// <param name="page"></param>
    public static void checkLogin(Page page)
    {
        bool b = true;
        if (page.Session.Count == 0 || page.Session["UID"] == null || page.Session["UserID"] == null)
            b = false;
        //return b;
        if (!b)
            page.Response.Redirect("login.aspx");
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="page"></param>
    /// <param name="userid"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public static string userLogin(Page page, string userid, string pwd)
    {
        userid = FmtStr(userid);
        pwd = FmtStr(pwd);
        string ret = "", err = "用户名或密码错误！",
            sql = "call proc_userLogin('"+userid+"','"+pwd+"')";
        DataTable dt;
        if (ulMySqlHelper.GetaDatatable(sql, out dt, out err))
        {
            page.Session["UID"] = dt.Rows["UID"].ToString();
            page.Session["UserID"] = dt.Rows["UserID"].ToString();
        }
        else
        {
            if (err != "")
                ret = err;
        }
        return ret;
    }



}
