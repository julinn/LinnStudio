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
            GW.GetProfession(GW.GetSessionGuildID(Page), ddlProfession);
            SearchUser();
            pnlEdit.Visible = false;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {        
        CleanEdit();
    }
    private void CleanEdit()
    {
        pnlEdit.Visible = false;
        edtName.ToolTip = "0";
        edtName.Text = "";
        edtLevel.Text = "";
        edtQQ.Text = "";
        if(ddlProfession.Items.Count > 0)
            ddlProfession.SelectedIndex = 0;
        edtRemark.Text = "";
        edtTel.Text = "";
    }

    private void SearchUser()
    {
        int iGid = GW.GetSessionGuildID(Page),//GW.GetGuildID(Page),
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
        int iGid = GW.GetSessionGuildID(Page),
            iUID = GW.GetSessionUID(Page);
        if (iGid == 0 || iUID == 0)
            return;   
        DataTable dt;
        if (GW.GuildUserSearch(iUID, iGid, iID, "", out dt))
        {
            edtName.ToolTip = dt.Rows[0]["ID"].ToString();
            edtName.Text = dt.Rows[0]["UName"].ToString();
            edtLevel.Text = dt.Rows[0]["Level"].ToString();
            edtTel.Text = dt.Rows[0]["Tel"].ToString();
            edtQQ.Text = dt.Rows[0]["QQ"].ToString();
            edtRemark.Text = dt.Rows[0]["Remark"].ToString();
            SetProfession(dt.Rows[0]["Profession"].ToString());
            pnlEdit.Visible = true;
        }
    }

    private void SetProfession(string value)
    {
        try
        {
            ddlProfession.SelectedValue = value;
        }
        catch
        {
            ddlProfession.SelectedIndex = -1;
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
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchUser();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //保存
        int id = GW.StrToInt(edtName.ToolTip),
            gid = GW.GetSessionGuildID(Page);
        string ret = GW.GuildUserEdit(id, gid, edtName.Text, ddlProfession.SelectedValue, edtLevel.Text, edtTel.Text, edtQQ.Text, edtRemark.Text);
        if (ret == "")
        {
            CleanEdit();
            SearchUser();
        }
        else
            lbMsg.Text = ret;
    }
    protected void btnAddNewUser_Click(object sender, EventArgs e)
    {
        //add new
        CleanEdit();
        pnlEdit.Visible = true;
    }
}
