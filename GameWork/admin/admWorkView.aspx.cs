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

public partial class admWorkView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            load();
    }


    private int GetWorkID()
    {
        int id = coreGW.FmtInt(lbTitle.ToolTip);
        if (id == 0)
        {
            if (Request.QueryString["id"] != null)
                id = coreGW.FmtInt(Request.QueryString["id"].ToString());
            if (id == 0)
                id = coreGW.GetLastBillID();
            if (id > 0)
                lbTitle.ToolTip = id.ToString();
        }        
        return id;
    }

    private void load()
    {
        int id = GetWorkID();
        if (id == 0)
            coreGW.MsgLableErr("获取分红单ID失败，请稍后再重新查询编辑", lbMsg);
        else
        {
            //主信息
            DataTable dtMain,
                dtDetail;
            string audit = "";
            if (coreGW.BillSearch(id,"", "", "", out dtMain) == "")
            {
                lbTitle.Text = dtMain.Rows[0]["Title"].ToString();
                lbContent.Text = dtMain.Rows[0]["Content"].ToString();
                lbRemark.Text = dtMain.Rows[0]["Remark"].ToString();
                //lbTotal.Text = dtMain.Rows[0]["TotalAmount"].ToString();
                lbCount.Text = dtMain.Rows[0]["Count"].ToString();
                lbAmount.Text = dtMain.Rows[0]["Amount"].ToString();
                lbWorkDate.Text = coreGW.FmtDate(dtMain.Rows[0]["FDate"].ToString());
                audit = dtMain.Rows[0]["AuditFlag"].ToString();
                if (audit == "1")
                {
                    btnAddMore.Enabled = false;
                    btnAudit.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }
            //明细内容
            if (coreGW.BillDetailSearch(id, out dtDetail) == "")
            {
                GridView1.DataSource = dtDetail.DefaultView;
                GridView1.DataBind();
                //
                ShowUsers(dtDetail);
                if(audit == "1")
                    GridView1.Columns[5].Visible = false;
            }
        }
    }

    private void ShowUsers(DataTable dt)
    {
        string ret = "", item = "", name = "", flag = ""; 
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i]["UName"].ToString();
                flag = dt.Rows[i]["PayFlag"].ToString();
                item = name;
                if (flag == "1")
                    item = name + "1";
                if (ret == "")
                    ret = item;
                else
                    ret = ret + " " + item;
            }
        }
        lbUsers.Text = ret;
    }

    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        int id = GetWorkID();
        if (id == 0)
            return;
        Response.Redirect("admWorkViewSelect.aspx?id="+id.ToString());
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int memid = coreGW.FmtInt(GridView1.DataKeys[e.RowIndex].Values[1].ToString()),
                workid = GetWorkID();
            if (memid == 0)
                return;
            string ret = coreGW.BillDetailOption(workid, memid, 1);// GW.WorkUserOpt(iuid, igid, workid, id, 1);
            if (ret == "")
                load();
            else
                coreGW.MsgLableErr(ret, lbMsg);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int id = GetWorkID();
        if (id > 0)
            Response.Redirect("./admWorkEdit.aspx?id=" + id.ToString());
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        int id = GetWorkID(),
            uid = coreGW.GetSessionID(this.Page);
        if (id == 0)
        {
            coreGW.MsgLableErr("获取单据ID失败，不能审核", lbMsg);
            return;
        }
        string ret = coreGW.BillAudit(id, uid);
        if (ret == "")
        {
            lbMsg.Text = "";
            load();
        }
        else
        {
            coreGW.MsgLableErr(ret, lbMsg);
        }
    }
}
