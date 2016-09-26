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

public partial class admin_admCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            loginLog();
    }

    private void loginLog()
    {
        int id = coreGW.GetSessionID(this.Page);
        DataTable dt = coreGW.LogSearch(id, 1);
        coreGW.DataBind(dt, GridView1);
    }
}
