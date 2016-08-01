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

public partial class admin_admUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GW.GetProfession(GW.GetGuildID(Page), ddlProfession);
            SearchUser();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlEdit.Visible = false;
        CleanEdit();
    }
    private void CleanEdit()
    {
        edtName.Text = "";
        edtLevel.Text = "";
        edtQQ.Text = "";
        ddlProfession.SelectedIndex = 0;
        edtRemark.Text = "";
        edtTel.Text = "";
    }

    private void SearchUser()
    {
        int iGid = GW.GetGuildID(Page),
            iUID = GW.GetSessionUID(Page);
        if (iGid == 0 || iUID == 0)
            return;   
        DataTable dt;
        GW.GuildUserSearch(iUID, iGid, 0, edtStr.Text, out dt);
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
    }

    private void loadEdit(int iID)
    {
        int iGid = GW.GetGuildID(Page),
            iUID = GW.GetSessionUID(Page);
        if (iGid == 0 || iUID == 0)
            return;   
        DataTable dt;
        if (GW.GuildUserSearch(iUID, iGid, iID, "", out dt))
        {
            edtName.Text = dt.Rows[0]["UName"].ToString();
            edtLevel.Text = dt.Rows[0]["Level"].ToString();
            edtTel.Text = dt.Rows[0]["Tel"].ToString();
            edtQQ.Text = dt.Rows[0]["QQ"].ToString();
            edtRemark.Text = dt.Rows[0]["Remark"].ToString();
            ddlProfession.SelectedValue = dt.Rows[0]["Profession"].ToString();
            pnlEdit.Visible = true;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //
        try
        {
            int ID = GW.StrToInt( GridView1.SelectedDataKey[0].ToString());
            if (ID == 0)
                return;
            loadEdit(ID);
        }
        catch
        {
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchUser();
    }
}
