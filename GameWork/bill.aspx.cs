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

public partial class bill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            info();
    }

    private void info()
    {
        int id = GetID();
        if(id == 0)
        {
            Response.Write("获取记录ID失败！请稍后再试。 <hr />");
            return;
        }
        DataTable dtMain;
        string ret = coreGW.BillSearch(id, "", "", "",false, "2", "2", out dtMain);
        if (dtMain.Rows.Count == 0)
        {
            Response.Write("获取详情失败！请稍后再试。 <hr />");
            return;
        }
        lbDate.Text = dtMain.Rows[0]["FDate"].ToString();
        lbTitle.Text = dtMain.Rows[0]["Title"].ToString();
        lbContent.Text = dtMain.Rows[0]["Content"].ToString();
        lbAmount.Text = dtMain.Rows[0]["Amount"].ToString();
        lbCount.Text = dtMain.Rows[0]["Count"].ToString();
        lbRemark.Text = dtMain.Rows[0]["Remark"].ToString();
        lbList.Text = coreGW.BillDetailSearch(id);
    }

    private int GetID()
    {
        int id = 0;
        if (Request.QueryString["id"] != null)
            id = coreGW.FmtInt(Request.QueryString["id"].ToString());
        return id;
    }
}
