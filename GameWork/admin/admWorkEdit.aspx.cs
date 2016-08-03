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

public partial class admWorkEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            load();
    }

    private void load()
    {
        int id = 0;
        if (Request.QueryString["id"] != null)
            id = GW.StrToInt(Request.QueryString["id"].ToString());
        if (id == 0)
            lbFlag.Text = "新建分红";
        else
            lbFlag.Text = "编辑分红";
        lbFlag.ToolTip = id.ToString();
        if (id == 0)
        {
            edtTitle.Text = "(" + DateTime.Now.ToString("yyyy-MM-dd") + ")";
            edtWorkDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
            loadEdit(id);
    }

    private void loadEdit(int id)
    {
        int iUID = GW.GetSessionUID(Page),
            iGID = GW.GetSessionGuildID(Page);
        string  err= "",
            sql = "select * from core_GuildsWorks where ID = " + id.ToString() + " and UID = " + iUID.ToString() + " and GuildID = " + iGID.ToString();
        DataTable dt;
        if(ulMySqlHelper.GetaDatatable(sql, out dt, out err))
        {
            edtTitle.Text = dt.Rows[0]["Title"].ToString();
            edtContent.Text = dt.Rows[0]["Content"].ToString();
            edtTotal.Text = dt.Rows[0]["TotalAmount"].ToString();
            edtAmount.Text = dt.Rows[0]["Amount"].ToString();
            edtCount.Text = dt.Rows[0]["Count"].ToString();
            edtWorkDate.Text = GW.FmtDate(dt.Rows[0]["WorkDate"].ToString());
            edtRemark.Text = dt.Rows[0]["Remark"].ToString();
        }
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("./admWorkMgr.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int iID = GW.StrToInt(lbFlag.ToolTip),
            iGID = GW.GetSessionGuildID(Page),
            iUID = GW.GetSessionUID(Page);
        string ret = GW.GuildWorkEdit(iID, iUID, iGID, edtTitle.Text, edtContent.Text, edtWorkDate.Text, edtTotal.Text, edtCount.Text,
            edtAmount.Text, edtRemark.Text);
        if (ret == "")
            Response.Redirect("./admWorkView.aspx");
        else
            lbMsg.Text = ret;
    }
}
