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

public partial class admin_admArticleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mod_class.GetList(ddlClass);
            loadList();
        }
    }
    private void loadList()
    {
        int iclass = cms.StrToInt(ddlClass.SelectedValue);
        string str = edtStr.Text.Replace("'", "").Replace(" ", "");
        GridView1.DataSource = mod_article.Search(iclass, 0, str).DefaultView;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = cms.StrToInt(GridView1.SelectedDataKey[0].ToString());
            if (id == 0)
                return;
            Response.Redirect("admArticle.aspx?id="+id.ToString());
        }
        catch
        {
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('确定删除吗？')");
            }
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)GridView1.DataKeys[e.RowIndex].Value;
            //int id = cms.StrToInt(e.Keys["ID"].ToString());
            //int id = cms.StrToInt(GridView1.DataKeyNames[0].ToString());
            if (id > 0)
            {                
               string ret = mod_article.Delete(id);
               if (ret == "")
               {
                   lbMsg.Text = "";
                   loadList();
               }
               else
                   lbMsg.Text = ret;
            }
        }
        catch(Exception ex)
        {
            lbMsg.Text = ex.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        loadList();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loadList();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("admArticle.aspx");
    }
}
