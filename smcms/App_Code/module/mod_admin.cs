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
///mod_admin 的摘要说明
/// </summary>
public class mod_admin
{
    private string _userid = "";
    public string UserID
    {
        get { return _userid; }
        set { _userid = value; }
    }

    private string _username = "";
    public string UserName
    {
        get { return _username; }
        set { _username = value; }
    }

    private string _Passwd = "";
    public string Passwd
    {
        get { return _Passwd; }
        set { _Passwd = value; }
    }

    private int _LevID = 0;
    public int LevID
    {
        get { return _LevID; }
        set { _LevID = value; }
    }

	public mod_admin(string uid)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        iniData(uid);
	}

    private void iniData(string uid)
    {
        uid = uid.Replace("'", "").Replace(" ", "");
        if (uid == "")
            return;
        string sql = "select * from smcms_admin where UserID = '" + uid + "'",
            err = "";
        DataTable dt;
        if (ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt, out err))
        {
            UserID = dt.Rows[0]["UserID"].ToString();
            UserName = dt.Rows[0]["UserName"].ToString();
            Passwd = dt.Rows[0]["Passwd"].ToString();
            LevID = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["LevID"].ToString());
        }
    }

    public string Save()
    {
        string sql = "exec proc_smcms_admin_Edit '" + UserID + "','" + UserName + "','" + Passwd + "'," + LevID.ToString();
        return ulLinnStudio.ulSqlHelper.ExecuteSQLErrorINFO(sql);
    }

    public static string Delete(string uid)
    {
        if (uid == "admin")
            return "管理员账号不可删除";
        uid = uid.Replace("'", "").Replace(" ", "");
        string sql = "delete from smcms_admin where UserID = '"+uid.ToString()+"'";
        return ulLinnStudio.ulSqlHelper.ExecuteSQLErrorINFO(sql);
    }
}
