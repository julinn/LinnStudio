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
            coreGW.GetProfession(ddlProfession);
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
        edtKeycode.Text = "";
        if(ddlProfession.Items.Count > 0)
            ddlProfession.SelectedIndex = 0;
        edtRemark.Text = "";
        lbUNo.Text = "自动生成";
        lbMsg.Text = "";
    }

    private void SearchUser()
    { 
        DataTable dt;
        coreGW.MemberSearch(0, edtStr.Text, rblProfession.SelectedValue, out dt);
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
        edtStr.Focus();
    }

    private void loadEdit(int iID)
    {  
        DataTable dt;
        if (coreGW.MemberSearch(iID, "", "", out dt) == "")
        {
            edtName.ToolTip = dt.Rows[0]["ID"].ToString();
            edtName.Text = dt.Rows[0]["UName"].ToString();
            edtKeycode.Text = dt.Rows[0]["KeyCode"].ToString();
            edtRemark.Text = dt.Rows[0]["Remark"].ToString();
            SetProfession(dt.Rows[0]["Profession"].ToString());
            lbUNo.Text = dt.Rows[0]["UNo"].ToString();
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
        int id = coreGW.FmtInt(edtName.ToolTip);
        string ret = coreGW.MemberEdit(id, edtName.Text, ddlProfession.SelectedValue, edtRemark.Text, edtKeycode.Text);
        if (ret == "")
        {
            CleanEdit();
            if (chkContinue.Checked)
                pnlEdit.Visible = true;
            else
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
