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
        int id = 0;
        if (Request.QueryString["id"] != null)
            id = GW.StrToInt(Request.QueryString["id"].ToString());
        if (id == 0)
        {
            id = GW.GetLastWorkID(GW.GetSessionUID(Page), GW.GetSessionGuildID(Page));
        }
        return id;
    }

    private void load()
    {
        int id = 0,
            iuid = GW.GetSessionUID(Page),
            igid = GW.GetSessionGuildID(Page);
        if (Request.QueryString["id"] != null)
            id = GW.StrToInt(Request.QueryString["id"].ToString());
        if (id == 0)
        {
            id = GW.GetLastWorkID(iuid, igid);
        }
        if (id == 0)
            Response.Write("获取分红单ID失败，请稍后再重新查询编辑");
        else
        {
            //主信息
            DataTable dtMain,
                dtDetail;
            if (GW.GetWorkMain(iuid, igid, id, out dtMain))
            {
                lbTitle.Text = dtMain.Rows[0]["Title"].ToString();
                lbContent.Text = dtMain.Rows[0]["Content"].ToString();
                lbRemark.Text = dtMain.Rows[0]["Remark"].ToString();
                lbTotal.Text = dtMain.Rows[0]["TotalAmount"].ToString();
                lbCount.Text = dtMain.Rows[0]["Count"].ToString();
                lbAmount.Text = dtMain.Rows[0]["Amount"].ToString();
                lbWorkDate.Text = GW.FmtDate(dtMain.Rows[0]["WorkDate"].ToString());
            }
            //明细内容
            if (GW.GetWorkDetail(iuid, igid, id, out dtDetail))
            {
                GridView1.DataSource = dtDetail.DefaultView;
                GridView1.DataBind();
            }
        }
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
            int id = GW.StrToInt(GridView1.DataKeys[e.RowIndex].Value.ToString()),
                iuid = GW.GetSessionUID(Page),
                igid = GW.GetSessionGuildID(Page),
                workid = GetWorkID();
            if (id == 0)
                return;
            string ret = GW.WorkUserOpt(iuid, igid, workid, id, 1);
            if (ret == "")
                load();
            else
                Response.Write("错误：<br/>" + ret + "<hr />");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
