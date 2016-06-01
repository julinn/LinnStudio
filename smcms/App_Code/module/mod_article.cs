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
            CID = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["Content"].ToString());
            UserID = dt.Rows[0]["UserID"].ToString();
            FDate = dt.Rows[0]["FDate"].ToString();
            IsTop = ulLinnStudio.ulSqlHelper.GetIntValue(dt.Rows[0]["IsTop"].ToString());
        }
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
}
