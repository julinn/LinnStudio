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

/// <summary>
///mod_class 的摘要说明
/// </summary>
public class mod_class
{
    private int _ID = 0;
    public int ID { get { return _ID; } set { _ID = value; } }

    private string _Name = "";
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    private int _PID = 0;
    public int PID { get { return _PID; } set { _PID = value; } }

	public mod_class(int iID)
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
        string sql = "select * from smcms_class where ID = " + iID.ToString(),
            errmsg = "";
        DataTable dt;
        if (ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt, out errmsg))
        {
            ID = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["ID"].ToString());
            Name = dt.Rows[0]["Name"].ToString();
            PID = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["PID"].ToString());
        }
    }

    public string Save()
    {
        string ret = "";
        Name = Name.Replace("'", "").Replace(" ", "");
        //string sql = "exec proc_smcms_class_Edit " + ID.ToString() + ",'" + Name + "'," + PID.ToString();
        string sql = "proc_smcms_class_Edit";
        SqlParameter[] p = new SqlParameter[] { 
           ulLinnStudio.ulSqlHelper.AddInIntParameter("@ID", ID),
           ulLinnStudio.ulSqlHelper.AddInVarcharParameter("@Name", Name, 30),
           ulLinnStudio.ulSqlHelper.AddInIntParameter("@PID", PID)
        };
        ret = ulLinnStudio.ulSqlHelper.ExecuteSQLErrorINFO(sql, p);
        return ret;
    }

    public static DataTable GetData()
    {
        DataTable dt;
        string sql = "select * from smcms_class",
            errmsg = "";
        ulLinnStudio.ulSqlHelper.GetDatatable(sql, out dt, out errmsg);
        return dt;
    }

    public static string GetDataLi()
    {
        string ret = "", temp = "";
        DataTable dt = GetData();
        if (dt.Rows.Count > 0)
        {
            temp = "<li><a href=\"./class.aspx?id="+dt.Rows[0]["ID"].ToString()+"\">" + dt.Rows[0]["Name"].ToString() + "</a></li>";
            if (ret == "")
                ret = temp;
            else
                ret = ret + temp;
        }
        return ret;
    }

    public static string Delete(int iID)
    {
        string sql = "delete from smcms_class where ID = " + iID.ToString();
        return ulLinnStudio.ulSqlHelper.ExecuteSQLErrorINFO(sql);
    }

    public bool AddNavigar()
    {
        string navgar = cms.GetNavigar(),
            page = "class.aspx?id=" + ID.ToString();
        if (!navgar.Contains(page))
        {
            navgar = navgar + "<li><a href=\"" + page + "\">" + Name + "</a></li>";
            cms.FgConfig.Clear();
            return cms.SaveConfig("Navigar", navgar);            
        }
        else
            return true;
    }
}
