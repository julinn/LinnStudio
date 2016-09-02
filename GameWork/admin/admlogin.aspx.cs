using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class admin_admlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["act"] != null)
            {
                if (Request.QueryString["act"].ToString() == "out")
                    Session.Clear();
            }
        }
    }

    private void login()
    {
        string userid = edtUserID.Text,
            passwd = edtPasswd.Text;
        string ret = coreGW.admLogin(this.Page, userid, passwd); 
        if (ret == "")
        {
            Response.Redirect("admCenter.aspx");
        }
        else
        {
            lbMsg.Text = ret;
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../index.aspx");
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        login();
    }
}
