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

public partial class admin_admArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            load();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (edtTitle.Text == "")
        {
            Label1.Text = "标题不能为空";
            return;
        }
        if (txtContent.Text == "")
        {
            Label1.Text = "内容不能为空";
            return;
        }
        int id = GetID();
        mod_article art = new mod_article(id);
        art.Title = edtTitle.Text;
        art.Content = txtContent.Text;
        art.IsTop = 0;
        art.CID = cms.StrToInt(ddlClass.SelectedValue);
        if (chkIstop.Checked)
            art.IsTop = 1;
        string ret = art.Save();
        if (ret == "")
            Response.Redirect("admArticleList.aspx");
        else
            Label1.Text = "保存失败：" + ret;
    }

    private int GetID()
    {
        int id = 0;
        if (Request.QueryString["id"] != null)
            id = cms.StrToInt(Request.QueryString["id"].ToString());
        return id;
    }

    private void load()
    {
        int id = GetID();
        loadClass();
        mod_article art = new mod_article(id);
        edtTitle.Text = art.Title;
        ddlClass.SelectedValue = art.CID.ToString();
        chkIstop.Checked = art.IsTop == 1;
        txtContent.Text = art.Content;
        lbFlag.Text = "添加文章";
        if (id > 0)
            lbFlag.Text = "编辑文章";
        Button2.Visible = id > 0;
    }

    private void loadClass()
    {
        ddlClass.Items.Clear();
        DataTable dt = mod_class.GetData();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem li = new ListItem();
                li.Text = dt.Rows[i]["Name"].ToString();
                li.Value = dt.Rows[i]["ID"].ToString();
                ddlClass.Items.Add(li);
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (mod_article.AddNavigar(GetID(), edtTitle.Text))
            Label1.Text = "加入导航成功";
        else
            Label1.Text = "加入导航失败，请稍候再试";
    }
}
