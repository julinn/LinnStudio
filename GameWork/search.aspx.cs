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

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["str"] != null)
            {
                edtStr.Text = Request.QueryString["str"].ToString();
                searchinfo();
            }
        }
    }

    private void searchinfo()
    {
        int gid = GW.GetGuildID(Page);
        if(gid == 0)
        {
            Response.Write("获取公会ID失败，请确认查询地址是否正确！");
            return;
        }
        GW.SearchSelf(gid, edtStr.Text, GridView1);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        searchinfo();
    }
}
