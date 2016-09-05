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
            id = coreGW.FmtInt(Request.QueryString["id"].ToString());
        if (id == 0)
            lbFlag.Text = "新建分红";
        else
            lbFlag.Text = "编辑分红";
        lbFlag.ToolTip = id.ToString();
        if (id == 0)
        {
            edtTitle.Text = "";
            edtWorkDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        else
            loadEdit(id);
    }

    private void loadEdit(int id)
    {
        string err = "";
        DataTable dt;
        err = coreGW.BillSearch(id, "", "", "", false, "2", "2", out dt);
        if(err == "")
        {
            edtTitle.Text = dt.Rows[0]["Title"].ToString();
            edtContent.Text = dt.Rows[0]["Content"].ToString();
            edtAmount.Text = dt.Rows[0]["Amount"].ToString();
            edtWorkDate.Text = GW.FmtDate(dt.Rows[0]["FDate"].ToString());
            edtRemark.Text = dt.Rows[0]["Remark"].ToString();
            RadioButtonList1.SelectedValue = dt.Rows[0]["SellFlag"].ToString();
            edtCount.Text = dt.Rows[0]["Count"].ToString();
            string audit = dt.Rows[0]["AuditFlag"].ToString();
            if (audit == "1")
            {
                btnSave.Enabled = false;
                //lbMsg.Text = "已审核的分红单不能再修改了";
                coreGW.MsgLableErr("已审核的分红单不能再修改了", lbMsg);
            }
        }
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["id"] != null)
            id = coreGW.FmtInt(Request.QueryString["id"].ToString());
        if (id == 0)
            Response.Redirect("./admWorkMgr.aspx");
        else
            Response.Redirect("./admWorkView.aspx?id="+id.ToString());
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int iID = coreGW.FmtInt(lbFlag.ToolTip),
            isellflag = coreGW.FmtInt(RadioButtonList1.SelectedValue),
            createid = GetCreateID();
        string ret = coreGW.BillEdit(iID, edtTitle.Text, edtContent.Text, edtRemark.Text, edtWorkDate.Text, edtAmount.Text, edtCount.Text, isellflag, createid) ;
        if (ret == "")
            Response.Redirect("./admWorkView.aspx");
        else
            lbMsg.Text = ret;
    }
    private int GetCreateID()
    {
        try
        {
            int i = 0;
            if (Session["ID"] != null)
                i = coreGW.FmtInt(Session["ID"].ToString());
            return i;
        }
        catch
        {
            return 0;
        }
    }
}
