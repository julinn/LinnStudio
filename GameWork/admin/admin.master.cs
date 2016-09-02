using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class admin_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkAdmin();
    }

    private void checkAdmin()
    {
        if (Session.Count < 1 || Session["ID"] == null || Session["ID"].ToString() == "" || Session["LevID"] == null || Session["LevID"].ToString() == ""
            || Session["UserName"] == null || Session["UserName"].ToString() == "" || Session["UserID"] == null || Session["UserID"].ToString() == "")
            Response.Redirect("admlogin.aspx");
    }

    private int GetGID()
    {
        int gid = 0;
        try
        {
            if (Request.QueryString["gid"] != null)
                gid = int.Parse(Request.QueryString["gid"].ToString());
        }
        catch
        {
            gid = 0;
        }
        return gid;
    }
}
