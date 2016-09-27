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
    public static int FLoginErrorCount = FmtInt(ulMySqlHelper.GetAppSetting("LoginErrorCount"));
    public static string FDomain = ulMySqlHelper.GetAppSetting("Domain");
    public static Dictionary<string, int> FLoginErr = new Dictionary<string, int>();
	public coreGW()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    #region MD5 加密（返回大写）
    /// <summary>
    ///  MD5 加密（返回大写）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GetMD5String(string str)
    {
        try
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
        }
        catch
        {
            return str;
        }
    }
    #endregion 

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

    public static string GetIP()
    {
        string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(result))
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        if (string.IsNullOrEmpty(result))
        {
            result = HttpContext.Current.Request.UserHostAddress;
        }
        if (string.IsNullOrEmpty(result))
        {
            return "0.0.0.0";
        }
        return result;
    }

    public static string GetIP(Page page)
    {
        string result = "0.0.0.0";
        try
        {
            result = page.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = page.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = page.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "0.0.0.0";
            }
        }
        catch
        {
            result = "0.0.0.0";
        }
        return result;
    }

    /// <summary>
    /// 管理登录
    /// </summary>
    /// <param name="page">网页</param>
    /// <param name="userid">用户名</param>
    /// <param name="passwd">密码</param>
    /// <returns></returns>
    public static string admLogin(Page page, string userid, string passwd, string keycode)
    {
        userid = FmtStr(userid);
        passwd = FmtStr(passwd);
        keycode = FmtStr(keycode);
        if (!LoginErrCheck(userid))
            return "账号因连续 "+FLoginErrorCount.ToString()+" 次账号或密码错误被锁定！";
        string sql = "call proc_gw_User_Login('" + userid + "','" + passwd + "')",
            err = "", ret = "用户名或密码错误！", code = "";
        DataTable dt;
        if (ulMySqlHelper.GetaDatatable(sql, out dt, out err))
        {
            if (keycode != "")
            {
                code = dt.Rows[0]["KeyCode"].ToString();
                DateTime time = DateTime.Parse(FmtDatetime(dt.Rows[0]["CodeValid"].ToString()));
                if (keycode != code || time < DateTime.Now)
                    return "验证码错误";
            }
            page.Session["ID"] = dt.Rows[0]["ID"].ToString();
            page.Session["UserID"] = dt.Rows[0]["UserID"].ToString();
            page.Session["UserName"] = dt.Rows[0]["UserName"].ToString();
            page.Session["LevID"] = dt.Rows[0]["LevID"].ToString();
            LoginErrClear(userid);
            LogWrite(FmtInt(dt.Rows[0]["ID"].ToString()), 1, "登录IP：" + GetIP(page));
            ret = "";
        }
        else
        {
            if (err != "")
                ret = err;
           LoginErrAdd(userid);
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
    public static string MemberEdit(int id, string uname, string profession, string remark, string keycode, string pym, string state)
    {
        uname = FmtStr(uname);
        profession = FmtStr(profession);
        remark = FmtStr(remark);
        keycode = FmtStr(keycode);
        pym = FmtStr(pym);
        state = FmtInt(state).ToString();
        if (uname.Replace(" ", "") == "")
            return "角色名不能为空";
        string sql = "call proc_gw_Member_Edit(" + id.ToString() + ",'" + uname + "','" + profession + "','" + remark + "','" + keycode + "','"+pym+"',"+state+")",
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

    /// <summary>
    /// 成员检索
    /// </summary>
    /// <param name="id"></param>
    /// <param name="str"></param>
    /// <param name="profession"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 账单检索
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="fromdate"></param>
    /// <param name="todate"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string BillSearch(int id, string title, string fromdate, string todate, bool userDateQuery, string sellflag, string auditflag, out DataTable dt)
    {
        title = FmtStr(title);
        fromdate = FmtDate(fromdate) + " 00:00:00";
        todate = FmtDatetime(DateTime.Parse(FmtDate(todate)).AddDays(1).ToString());
        if (!userDateQuery)
        {
            fromdate = "";
            todate = "";
        }
        sellflag = FmtInt(sellflag).ToString();
        auditflag = FmtInt(auditflag).ToString();
        string err = "",sql = "call proc_gw_Bill_Search("+id.ToString()+",'" + title + "',"+sellflag+","+auditflag+",'" + fromdate + "','" + todate + "')";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        return err;
    }

    /// <summary>
    /// 账单明细查询
    /// </summary>
    /// <param name="billID"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string BillDetailSearch(int billID, out DataTable dt)
    {
        string err = "",
            sql = "call proc_gw_BillDetail_Search(" + billID.ToString() + ")";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        return err;
    }

    /// <summary>
    /// 账单明细查询
    /// </summary>
    /// <param name="billID"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 获取最后一张账单ID
    /// </summary>
    /// <returns></returns>
    public static int GetLastBillID()
    {
        string sql = "select max(ID) from gw_Bill";
        string ret = ulMySqlHelper.GetFirstVar(sql);
        return FmtInt(ret);
    }

    /// <summary>
    /// 账单添加成员检索（排除已经添加过的成员）
    /// </summary>
    /// <param name="id"></param>
    /// <param name="str"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string BillMemberSearch(int id, string str, out DataTable dt)
    {
        str = FmtStr(str);
        string sql = "call proc_gw_Bill_MemSearch(" + id.ToString() + ",'"+str+"')",
            err = "";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        return err;
    }

    /// <summary>
    /// 微信会员检测
    /// </summary>
    /// <param name="wxopenid"></param>
    /// <returns></returns>
    public static string wxMemberCheck(string wxopenid)
    {
        string sql = "select ID from gw_Member where wxOpenID = '" + wxopenid + "'",
            sid = "",
            ret = "还没有绑定账号信息，回复【编号-验证码】，绑定个人角色； 例如：001-888888";
        sid = ulMySqlHelper.GetFirstVar(sql);
        int id = FmtInt(sid);
        if (id > 0)
            ret = "<a href=\"http://"+FDomain+"/search.aspx?id=" + id.ToString() + "\">点击这里查询分红信息</a>";
        return ret;
    }

    /// <summary>
    /// 微信会员绑定
    /// </summary>
    /// <param name="wxOpenID"></param>
    /// <param name="cmd"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 微信管理员绑定
    /// </summary>
    /// <param name="wxOpenID"></param>
    /// <param name="cmd"></param>
    /// <returns></returns>
    public static string wxAdminBind(string wxOpenID, string cmd)
    {
        string ret = "",
            sql = "call proc_gw_User_wxBind('"+wxOpenID+"','"+cmd+"')";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
        {
            ret = wxAdminGetKeyCode(wxOpenID);
        }
        return ret;
    }

    /// <summary>
    /// 获取微信管理员登录验证码
    /// </summary>
    /// <param name="wxOpenID"></param>
    /// <returns></returns>
    public static string wxAdminGetKeyCode(string wxOpenID)
    {
        string ret = "",
            sql = "call proc_gw_User_wxKeyCode('" + wxOpenID + "')";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "")
            ret = "还没有绑定账号，回复【账号;密码】进行绑定，例如：account;password";
        else
            ret = "验证码：" + ret + " \n 5分钟内有效，安全棒棒哒~";
        return ret;
    }

    /// <summary>
    /// 会员账单查询（会员查询自己的账单）
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 获取结算编号
    /// </summary>
    /// <returns></returns>
    public static string GetPayCode()
    {
        try
        {
            Random rd = new Random();
            string s = rd.Next(100000, 999999).ToString();
            return DateTime.Now.ToString("yyyyMMddHHmmss") + s;
        }
        catch
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }

    public static string MemberBillPay(int memID, string remark, double total)
    {
        //IN `_MemID` int,IN `_PayCode` varchar(60), IN `_Remark` varchar(1000), IN `_Amount` decimal(12,2)
        remark = FmtStr(remark);
        total = FmtAmount(total.ToString());
        if (total == 0)
            return "结算金额合计不能为0";
        string ret = "结算失败，请稍后再重试。",
            paycode = GetPayCode(),
            sql = "call proc_gw_Member_Pay(" + memID.ToString() + ",'" + paycode+"','" + remark + "'," + total.ToString() + ")";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

    public static string UserChangePassword(int iUID, string oldPwd, string newPwd, string Newpwd1)
    {
        string ret = "";
        oldPwd = FmtStr(oldPwd);
        if (newPwd.Length == 0)
            return "新密码不能为空";
        if (newPwd != Newpwd1)
            return "两次输入的密码不一致";
        newPwd = FmtStr(newPwd);
        string sql = "call proc_gw_User_ChangePwd(" + iUID.ToString() + ",'" + oldPwd + "','"+newPwd+"')";
        ret = ulMySqlHelper.GetFirstVar(sql);
        if (ret == "1")
            ret = "";
        return ret;
    }

    /// <summary>
    /// 获取解锁码
    /// </summary>
    /// <param name="userid">解锁账号</param>
    /// <param name="nonstr">随机码</param>
    /// <returns></returns>
    public static string GetUserUnlockCode(string userid, string nonstr)
    {
        string ret = "";
        userid = GetMD5String(userid + nonstr);
        nonstr = GetMD5String(nonstr);
        ret = GetMD5String(userid + nonstr);
        return ret;
    }

    public static string UnlockUser(string userid, string nonstr, string code)
    {
        string ret = "解锁码错误！",
        ucode = GetUserUnlockCode(userid, nonstr);
        if (ucode == code)
        {
            LoginErrClear(userid);
            ret = "";
        }
        else
            ret = "解锁码错误！";
        return ret;
    }

    /// <summary>
    /// 写入日志
    /// </summary>
    /// <param name="uid">用户ID</param>
    /// <param name="classid">类型 1登录 2修改单据 3审核单据</param>    
    /// <param name="content">日志内容</param>
    /// <param name="billid">关联单据ID</param>
    public static void LogWrite(int uid, int classid, string content, int billid)
    {
        content = FmtStr(content);
        string sql = "call proc_gw_UserLog_Add("+uid.ToString()+","+classid.ToString()+","+billid.ToString()+",'"+content+"')";
        ulMySqlHelper.ExecuteSql(sql);
    }
    /// <summary>
    /// 写入日志
    /// </summary>
    /// <param name="uid">用户ID</param>
    /// <param name="classid">类型 1登录 2修改单据 3审核单据</param>
    /// <param name="content">日志内容</param>
    public static void LogWrite(int uid, int classid, string content)
    {
        LogWrite(uid, classid, content, 0);
    }

    /// <summary>
    /// 查询日志
    /// </summary>
    /// <param name="uid">用户ID</param>
    /// <param name="classID">类型 0 单据日志； 1登录日志； > 1 各类型日志</param>
    /// <param name="billID">单据ID</param>
    /// <returns></returns>
    public static DataTable LogSearch(int uid, int classID, int billID)
    {
        string sql = "call proc_gw_UserLog_Search("+uid.ToString()+","+classID.ToString()+","+billID.ToString()+")",
            err = "";
        DataTable dt;
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        return dt;
    }

    /// <summary>
    /// 查询日志
    /// </summary>
    /// <param name="uid">用户</param>
    /// <param name="classID">类型 0 单据日志； 1登录日志； > 1 各类型日志</param>
    /// <returns></returns>
    public static DataTable LogSearch(int uid, int classID)
    {
        return LogSearch(uid, classID, 0);
    }


}
