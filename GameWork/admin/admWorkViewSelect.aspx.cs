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
            load();
    }

    private int getWorkID()
    {
        int id = 0;
        if (Request.QueryString["id"] != null)
            id = GW.StrToInt(Request.QueryString["id"].ToString());
        return id;
    }

    private void load()
    {
        int workid = getWorkID();
        if (workid == 0)
        {
            Response.Write("获取分红单ID失败");
            return;
        }
        DataTable dt;
        if (GW.WorkUserSearch(GW.GetSessionUID(Page), GW.GetSessionGuildID(Page), workid, out dt))
        {
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
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
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string users = GetUsers();
        int uid = GW.GetSessionUID(Page),
            gid = GW.GetSessionGuildID(Page),
            workid = getWorkID();
        string ret = GW.WorkUserAddMore(uid, gid, workid, users);
        if (ret == "")
            Response.Redirect("./admWorkView.aspx?id=" + workid.ToString());
        else
            Response.Write("保存失败：<br/>"+ret +"<hr />");
    }
}
