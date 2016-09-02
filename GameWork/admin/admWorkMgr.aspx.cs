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

public partial class admin_admWorkMgr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            edtFrom.Text = DateTime.Now.ToString("yyyy-MM") + "-01";
            edtTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
            search();
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("./admWorkEdit.aspx");
    }

    private void search()
    {
        DataTable dt;
        coreGW.BillSearch(0, edtstr.Text, edtFrom.Text, edtTo.Text, out dt);
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = GW.StrToInt(GridView1.SelectedDataKey[0].ToString());
            if (id > 0)
                Response.Redirect("./admWorkView.aspx?id=" + id.ToString());
        }
        catch
        {
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search();
    }
}
