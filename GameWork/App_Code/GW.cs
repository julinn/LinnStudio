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
using MySql.Data.MySqlClient;
using System.Collections.Generic;

/// <summary>
///GW 的摘要说明
/// </summary>
public class GW
{
    public static int FLoginErrorCount = StrToInt(ulMySqlHelper.GetAppSetting("LoginErrorCount"));
    public static Dictionary<string, int> FLoginErr = new Dictionary<string, int>();
	public GW()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
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

    public static string FmtStr(string str)
    {
        return str.Replace("'", "");
    }

    public static int GetGuildID(Page page)
    {
        int gid = 0;
        if (page.Request.QueryString["gid"] != null)
            gid = StrToInt(page.Request.QueryString["gid"].ToString());
        return gid;
    }

    public static int GetGuildUID(Page page)
    {
        int guid = 0;
        if (page.Request.QueryString["guid"] != null)
            guid = StrToInt(page.Request.QueryString["guid"].ToString());
        return guid;
    }

    public static int GetSessionUID(Page page)
    {
        string ret = "0";
        if(page.Session.Count > 0 && page.Session["UID"] != null)
            ret = page.Session["UID"].ToString();
        return StrToInt(ret);
    }
    public static string GetSessionUserID(Page page)
    {
        string ret = "";
        if (page.Session.Count > 0 && page.Session["UserID"] != null)
            ret = page.Session["UserID"].ToString();
        return ret;
    }

    public static void LoginErrAdd(string userid)
    {
        if (FLoginErrorCount == 0)
            return;
        if (FLoginErr.ContainsKey(userid))
        {
            int iErr = FLoginErr[userid] + 1;
            FLoginErr[userid] = iErr;
        }
        else
            FLoginErr.Add(userid, 1);
    }
    public static void LoginErrClear(string userid)
    {
        if (FLoginErrorCount == 0)
            return;
        if (FLoginErr.ContainsKey(userid))
            FLoginErr.Remove(userid);
    }
    public static bool LoginErrCheck(string userid)
    {
        if (FLoginErrorCount == 0)
            return true;
        bool b = true;
        if (FLoginErr.ContainsKey(userid))
        {
            if (FLoginErr[userid] >= FLoginErrorCount)
                b = false;
        }
        return b;
    }

    public static string adm_Login(string userid, string pwd, out DataTable dt)
    {
        string ret = "用户名或密码错误！", err = "";
        dt = new DataTable();        
        userid = userid.Replace("'", "");
        pwd = pwd.Replace("'", "");
        if (!LoginErrCheck(userid))
            return "账号因多次输入密码错误被锁定！";
        string sql = "call proc_UserLogin('" + userid + "','" + pwd + "')";
        if (ulMySqlHelper.GetaDatatable(sql, out dt, out err))
        {
            ret = "";
            LoginErrClear(userid);
        }
        else
        {
            if (err != "")
                ret = err;
            LoginErrAdd(userid);
        }
        return ret;
    }

    public static void GetProfession(int GuildID, DropDownList ddl)
    {
        string sql = "call proc_GetGameProfessions(" + GuildID.ToString() + ",0)", 
            err = "";
        ddl.Items.Clear();
        DataTable dt;
        if (ulMySqlHelper.GetaDatatable(sql, out dt, out err))
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl.Items.Add(dt.Rows[i]["Name"].ToString());
            }
        }
    }

    public static string GuildUserEdit(int iID, int GuildID, string name, string profession, string lev, string tel, string qq, string remark)
    {
        string ret = "";
        name = FmtStr(name);
        lev = StrToInt(lev).ToString();
        tel = FmtStr(tel);
        qq = FmtStr(qq);
        remark = FmtStr(remark);
        profession = FmtStr(profession);
        //
        string sql = "call proc_GuildUserEdit(" + iID.ToString() + "," + GuildID.ToString() + ",'" + name + "','" + profession + "'," + lev + ",'" + tel + "','" + qq + "','" + remark + "')";
        int i = ulMySqlHelper.ExecuteSql(sql, out ret);
        return ret;
    }

    public static bool GuildUserSearch(int UID, int GuildID, int iID, string str, out DataTable dt)
    {
        str = FmtStr(str);
        string err = "";
        string sql = "call proc_GuildUserSearch(" + UID.ToString() + "," + GuildID + "," + iID.ToString() + ",'" + str + "')";
        return ulMySqlHelper.GetaDatatable(sql, out dt, out err);
    }

    public static string iniConnection()
    {
        string ret = "", 
            conn = ulMySqlHelper.FormatConnString("55c95f1838fa8.gz.cdb.myqcloud.com", "gamework", "Linnsgw00!", "GameWork", "15305");
        if (ulMySqlHelper.TestConnString(conn))
        {
            if (!ulMySqlHelper.SaveConnString(conn))
                ret = "数据库连接失败！";
        }
        else
            ret = "连接数据库失败！";
        return ret;
    }
}
