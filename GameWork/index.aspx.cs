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

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack) iniConn();
        if (!IsPostBack)
            loadinfo();
    }

    private void iniConn()
    {
        string ret = GW.iniConnection();
        if (ret != "")
            Response.Write(ret);
    }

    private void loadinfo()
    {
        lbGuildName.Text = GW.GetGuildName(Page);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string uname = GW.FmtStr(edtstr.Text);
        if (uname == "")
            return;
        int gid = GW.GetGuildID(Page);
        if (gid == 0)
            lbGuildName.Text = "获取公会名称失败，请确认查询地址是否正确！";
        else
            Response.Redirect("./search.aspx?gid=" + gid.ToString() + "&str=" + uname);
    }
}
