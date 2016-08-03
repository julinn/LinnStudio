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

    public static double StrToAmount(string str)
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
    public static int GetSessionGuildID(Page page)
    {
        int gid = 0;
        if (page.Session["GuildID"] != null)
            gid = StrToInt(page.Session["GuildID"].ToString());
        return gid;
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
        if (name == "")
            return "角色名不能为空";
        //
        string sql = "call proc_GuildUserEdit(" + iID.ToString() + "," + GuildID.ToString() + ",'" + name + "','" + profession + "'," + lev + ",'" + tel + "','" + qq + "','" + remark + "')";
        //int i = ulMySqlHelper.ExecuteSql(sql, out ret);
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
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

    public static string GuildWorkEdit(int id, int uid, int guildid, string title, string content, string workdate, string total, string count, string amount, string remark)
    {
        string ret = "保存失败!";
        title = FmtStr(title);
        content = FmtStr(content);
        remark = FmtStr(remark);
        workdate = FmtDate(workdate);
        double dTotal = StrToAmount(total),
            dAmount = StrToAmount(amount);
        int iCount = StrToInt(count);
        if (title == "")
            return "主题不能为空";
        if (dTotal == 0)
            return "总金额不能为0";
        if(dAmount == 0)
            return "人均不能为0";
        if (iCount == 0)
            return "人数不能为0";
        string sql = "call proc_GuildWorkEdit(" + id.ToString() + "," + uid.ToString() + "," + guildid.ToString() + ",'" + title + "','" + content + "','" + workdate + "'," + dTotal.ToString("0.00") + "," + iCount.ToString() + "," + dAmount.ToString("0.00") + ",'" + remark + "')";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

    public static int GetLastWorkID(int uid, int guildID)
    {
        string sql = "select max(ID) from core_GuildsWorks where UID = " + uid.ToString() + " and GuildID = " + guildID.ToString();
        string ret = ulMySqlHelper.GetFirstVar(sql);
        return StrToInt(ret);
    }

    public static bool GetWorkMain(int uid, int guildID, int workID, out DataTable dt)
    {
        string sql = "select * from core_GuildsWorks where ID = " + workID.ToString() + " and UID = " 
            + uid.ToString() + " and GuildID=" + guildID.ToString(),
            err = "";
        return ulMySqlHelper.GetaDatatable(sql, out dt, out err);
    }

    public static bool GetWorkDetail(int uid, int guildID, int workID, out DataTable dt)
    {
        string err = "",
            sql = "select m.*,u.UName,u.Profession from core_GuildsWorksDetail m left join core_GuildsUsers u on u.ID = m.GUID where m.WorkID = "
            + workID.ToString() + " and u.UID = " + uid.ToString() + " and m.GuildID=" + guildID.ToString();
        return ulMySqlHelper.GetaDatatable(sql, out dt, out err);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="guildID"></param>
    /// <param name="workID"></param>
    /// <param name="GUID">isDel = 0 用户GUID, isDel = 1 WorkDetail_ID</param>
    /// <param name="isDel"></param>
    /// <returns></returns>
    public static string WorkUserOpt(int uid, int guildID, int workID, int GUID, int isDel)
    {
        string ret = "", 
            sql = "call proc_GuildWorkUserOpt(" + uid.ToString() + "," + guildID.ToString() + "," + workID.ToString() + "," + GUID.ToString() + "," + isDel.ToString() + ")";
        ulMySqlHelper.ExecuteSql(sql, out ret).ToString();
        return ret;
    }

    public static bool WorkUserSearch(int uid, int guildID, int workID, out DataTable dt)
    {
        string err = "",
            sql = "call proc_GuildWorkUserSearch(" + uid.ToString() + "," + guildID.ToString() + "," + workID.ToString() + ")";
        return ulMySqlHelper.GetaDatatable(sql, out dt, out err); 
    }

    public static string WorkUserAddMore(int uid, int guildID, int workID, string GUIDS)
    {
        if (uid == 0)
            return "获取登录用户ID失败";
        if (guildID == 0)
            return "获取公会ID失败";
        if (workID == 0)
            return "获取分红单ID失败";
        if (GUIDS == "")
            return "没有选择任何用户";
        string ret = "", err = "",
            sql = "call proc_GuildWorkUserAddMore(" + uid.ToString() + "," + guildID.ToString() + "," + workID.ToString() + ",'" + GUIDS + "')";
        ulMySqlHelper.ExecuteSql(sql, out err);
        if (err != "")
            ret = err;
        return ret;
    }

    public static bool WorkSearch(int uid, int guildID, string str, string FromDate, string ToDate, out DataTable dt)
    {
        string err = "",
            sql = "select * from core_GuildsWorks where UID = "+uid.ToString()+" and GuildID = "+guildID.ToString();
        if (str != "")
            sql += " and (Title like '%" + str + "%' or Remark like '%" + str + "%')";
        if (FromDate != "" && ToDate != "")
        {
            FmtDate(FromDate);
            FmtDate(ToDate);
            DateTime.Parse(ToDate).AddDays(1);
            FmtDate(ToDate);
            sql += " and WorkDate >= '" + FromDate + "' and WorkDate < '" + ToDate + "'";
        }
        sql += " order by WorkDate Desc";
        return ulMySqlHelper.GetaDatatable(sql, out dt, out err);
    }

    public static void SearchSelf(int guildID, string uname, GridView gv)
    {
        uname = FmtStr(uname);
        string err = "",
            sql = "call proc_GuildUserSearchSelf("+guildID.ToString()+",'"+uname+"')";
        DataTable dt;
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        gv.DataSource = dt.DefaultView;
        gv.DataBind();
    }

    public static string GetGuildName(Page page)
    {
        string ret = "";
        int gid = GetGuildID(page);
        if (gid == 0)
            return "获取公会名称失败，请确认查询地址是否正确！";
        string sql = "select Name from core_Guilds where ID = "+gid.ToString();
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "")
            ret = "获取公会名称失败，请确认查询地址是否正确！";
        else
            ret = "【" + ret + "】<br/>财务查询系统";
        return ret;
    }
}
