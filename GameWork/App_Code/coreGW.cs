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
///coreGW 的摘要说明
/// </summary>
public class coreGW
{
	public coreGW()
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

    public static void DataBind(DataTable dt, GridView gv)
    {
        gv.DataSource = dt.DefaultView;
        gv.DataBind();
    }

    public static int GetSessionID(Page page)
    {
        try
        {
            return FmtInt(page.Session["ID"].ToString());
        }
        catch
        {
            return 0;
        }
    }

    public static void MsgLableOK(string msg, Label lb)
    {
        lb.Text = msg;
        lb.Font.Bold = true;
        lb.ForeColor = System.Drawing.Color.Green;
    }
    public static void MsgLableErr(string msg, Label lb)
    {
        lb.Text = msg;
        lb.Font.Bold = true;
        lb.ForeColor = System.Drawing.Color.Red;
    }

    /// <summary>
    /// 管理登录
    /// </summary>
    /// <param name="page">网页</param>
    /// <param name="userid">用户名</param>
    /// <param name="passwd">密码</param>
    /// <returns></returns>
    public static string admLogin(Page page, string userid, string passwd)
    {
        userid = FmtStr(userid);
        passwd = FmtStr(passwd);
        string sql = "call proc_gw_User_Login('" + userid + "','" + passwd + "')",
            err = "", ret = "用户名或密码错误！";
        DataTable dt;
        if (ulMySqlHelper.GetaDatatable(sql, out dt, out err))
        {
            page.Session["ID"] = dt.Rows[0]["ID"].ToString();
            page.Session["UserID"] = dt.Rows[0]["UserID"].ToString();
            page.Session["UserName"] = dt.Rows[0]["UserName"].ToString();
            page.Session["LevID"] = dt.Rows[0]["LevID"].ToString();
            ret = "";
        }
        else
        {
            if (err != "")
                ret = err;
        }
        return ret;
    }

    /// <summary>
    /// 加载职业信息
    /// </summary>
    /// <param name="ddl"></param>
    public static void GetProfession(DropDownList ddl)
    {
        /*
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
        }*/
        ddl.Items.Clear();
        ddl.Items.Add("战士");
        ddl.Items.Add("道士");
        ddl.Items.Add("法师");
    }

    /// <summary>
    /// 用户编辑
    /// </summary>
    /// <param name="id"></param>
    /// <param name="uname"></param>
    /// <param name="profession"></param>
    /// <param name="remark"></param>
    /// <param name="keycode"></param>
    /// <returns></returns>
    public static string MemberEdit(int id, string uname, string profession, string remark, string keycode)
    {
        uname = FmtStr(uname);
        profession = FmtStr(profession);
        remark = FmtStr(remark);
        keycode = FmtStr(keycode);
        if (uname.Replace(" ", "") == "")
            return "角色名不能为空";
        string sql = "call proc_gw_Member_Edit(" + id.ToString() + ",'" + uname + "','" + profession + "','" + remark + "','" + keycode + "')",
            ret = "保存失败";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

   /// <summary>
   /// 单据编辑
   /// </summary>
   /// <param name="id"></param>
   /// <param name="title"></param>
   /// <param name="content"></param>
   /// <param name="remark"></param>
   /// <param name="fdate"></param>
   /// <param name="amount"></param>
   /// <param name="sellflag"></param>
   /// <param name="createid"></param>
   /// <returns></returns>
    public static string BillEdit(int id, string title, string content, string remark, string fdate, string amount, string count, int sellflag, int createid)
    {
        title = FmtStr(title);
        content = FmtStr(content);
        remark = FmtStr(remark);
        fdate = FmtDatetime(fdate);
        amount = FmtAmount(amount).ToString();
        count = FmtInt(count).ToString();
        string ret = "", 
            sql = "call proc_gw_Bill_Edit(" + id.ToString() + ",'" + title + "','" + content + "','" + remark + "','" + fdate + "'," + amount + "," + count+"," + sellflag.ToString() + "," + createid + ")";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

    /// <summary>
    /// 单据审核
    /// </summary>
    /// <param name="id"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public static string BillAudit(int id, int uid)
    {
        string ret = "",
            sql = "call proc_gw_Bill_Audit(" + id.ToString() + "," + uid.ToString() + ")";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

    public static string BillDetailAddMore(int id, string uids)
    {
        uids = FmtStr(uids).Replace(" ", "");
        string ret = "",
            sql = "call proc_gw_BillDetail_AddMore("+id.ToString()+",'"+uids+"')";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

    /// <summary>
    /// 单据明细用户操作
    /// </summary>
    /// <param name="id">单据ID，BillID</param>
    /// <param name="memid">会员ID</param>
    /// <param name="optFlag">操作类型0增加1删除2清空</param>
    /// <returns></returns>
    public static string BillDetailOption(int id, int memid, int optFlag)
    {
        string ret = "",
            sql = "call proc_gw_BillDetail_Option("+id.ToString()+","+memid.ToString()+","+optFlag.ToString()+")";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

    public static string MemberSearch(int id, string str, string profession, out DataTable dt)
    {
        str = FmtStr(str);
        profession = FmtStr(profession);
        string err = "",
            ret = "",
            sql = "call proc_gw_Member_Search("+id.ToString()+",'"+str+"','"+profession+"')";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        if (err != "")
            ret = err;
        return ret;
    }

    //IN `_Str` varchar(100), IN `_SellFlag` int, IN `_AuditFlag` int,IN `_FromDate` datetime,IN `_ToDate` datetime
    public static string BillSearch(int id, string title, string fromdate, string todate, out DataTable dt)
    {
        title = FmtStr(title);
        fromdate = FmtDate(fromdate) + " 00:00:00";
        todate = FmtDatetime(DateTime.Parse(FmtDate(todate)).AddDays(1).ToString());
        string err = "",sql = "call proc_gw_Bill_Search("+id.ToString()+",'" + title + "',0,0,'" + fromdate + "','" + todate + "')";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        return err;
    }

    public static string BillDetailSearch(int billID, out DataTable dt)
    {
        string err = "",
            sql = "call proc_gw_BillDetail_Search(" + billID.ToString() + ")";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        return err;
    }

    public static string BillDetailSearch(int billID)
    {
        string ret = "", err = "", item = "", name = "", flag = "";
        DataTable dt;
        err = BillDetailSearch(billID, out dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i]["UName"].ToString();
                flag = dt.Rows[i]["PayFlag"].ToString();
                item = name;
                if (flag == "1")
                    item = name + "1";
                if (ret == "")
                    ret = item;
                else
                    ret = ret + " " + item;
            }
        }
        return ret;
    }

    public static int GetLastBillID()
    {
        string sql = "select max(ID) from gw_Bill";
        string ret = ulMySqlHelper.GetFirstVar(sql);
        return FmtInt(ret);
    }

    public static string BillMemberSearch(int id, string str, out DataTable dt)
    {
        str = FmtStr(str);
        string sql = "call proc_gw_Bill_MemSearch(" + id.ToString() + ",'"+str+"')",
            err = "";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        return err;
    }

    public static string wxMemberCheck(string wxopenid)
    {
        string sql = "select ID from gw_Member where wxOpenID = '" + wxopenid + "'",
            sid = "",
            ret = "还没有绑定账号信息，回复【编号-验证码】，绑定个人角色； 例如：001-888888";
        sid = ulMySqlHelper.GetFirstVar(sql);
        int id = FmtInt(sid);
        if (id > 0)
            ret = "<a href=\"http://1.smasp.net/search.aspx?id=" + id.ToString() + "\">点击这里查询分红信息</a>";
        return ret;
    }

    public static string wxMemberBind(string wxOpenID, string cmd)
    {
        cmd = FmtStr(cmd).Replace(" ","");
        string ret = "",
            sql = "call proc_gw_Member_WXBind('" + wxOpenID + "','" + cmd + "')";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
        {
            ret = wxMemberCheck(wxOpenID);
        }
        return ret;
    }

    public static string wxAdminBind(string wxOpenID, string cmd)
    {
    }

    public static string wxAdminGetKeyCode(string wxOpenID)
    {

    }

    public static string MemberBillSearch(int id, int type, out DataTable dt)
    {
        string sql = "call proc_gw_Member_BillSearch(" + id.ToString() + "," + type.ToString() + ")",
            ret = "";
        ulMySqlHelper.GetaDatatable(sql, out dt, out ret);
        return ret;
    }

    #region 检查是否微信浏览器
    /// <summary>
    /// 检查是否微信浏览器
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static bool CheckBrowserIsWeixin(Page page)
    {
        string ua = page.Request.UserAgent;
        return ua.Contains("MicroMessenger");
    }
    #endregion
}
