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

public partial class admin_admWorkViewSelect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Showuses();
            search();
        }
    }

    private int getWorkID()
    {
        int id = coreGW.FmtInt(lbUsers.ToolTip);
        if (id == 0)
        {
            if (Request.QueryString["id"] != null)
                id = GW.StrToInt(Request.QueryString["id"].ToString());
            if (id > 0)
                lbUsers.ToolTip = id.ToString();
        }
        return id;
    }

    private void search()
    {
        int workid = getWorkID();
        if (workid == 0)
        {
            Response.Write("获取分红单ID失败");
            return;
        }
        DataTable dt;
        string err = coreGW.BillMemberSearch(workid, edtSearch.Text, out dt);
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
    }

    private string GetUsers()
    {
        int iCount = GridView1.Rows.Count;
        string s = "", sid = "";
        for (int i = 0; i < iCount; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
            if (CheckBox.Checked)
            {
                //dPrice = getPrice(GridView1.Rows[i].Cells[2].Text.ToString());
                sid = GridView1.DataKeys[i].Value.ToString();
                if (s == "")
                    s = sid;
                else
                    s += "," + sid;
            }
        }
        //Response.Write(s);
        return s;
    }

    private void Showuses()
    {
        int id = getWorkID();
        if (id > 0)
            lbUsers.Text = coreGW.BillDetailSearch(id);
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string users = GetUsers();
        if (users == "")
        {
            Response.Write("保存失败：<br/>没有选择成员<hr />");
            return;
        }
        int workid = getWorkID();
        string ret = coreGW.BillDetailAddMore(workid, users);
        if (ret == "")
        {
            Showuses();
            search();// Response.Redirect("./admWorkView.aspx?id=" + workid.ToString());
            edtSearch.Focus();
        }
        else
            Response.Write("保存失败：<br/>" + ret + "<hr />");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //
        search();
    }
    protected void btnReurn_Click(object sender, EventArgs e)
    {
        int workid = getWorkID();
        Response.Redirect("./admWorkView.aspx?id=" + workid.ToString());
    }
}
