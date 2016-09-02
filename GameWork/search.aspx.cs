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

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            searchinfo();
        }
    }

    private int GetID()
    {
        try
        {
            int id = 0;
            DataTable dt;
            if (Request.QueryString["id"] != null)
                id = coreGW.FmtInt(Request.QueryString["id"].ToString());
            if (id == 0 && edtName.Text == "")
                return 0;
            if (id > 0)
                coreGW.MemberSearch(id, "", "", out dt);
            else
            {
                coreGW.MemberSearch(0, edtName.Text, "", out dt);
                if (dt.Rows.Count > 0)
                    id = coreGW.FmtInt(dt.Rows[0]["ID"].ToString());
            }
            if (id > 0 && dt.Rows.Count > 0)
                edtName.Text = dt.Rows[0]["UName"].ToString();
            
            return id;
        }
        catch
        {
            return 0;
        }
    }

    private void searchinfo()
    {
        int id = GetID(),
            type = coreGW.FmtInt(RadioButtonList1.SelectedValue.ToString());
        if(id == 0)
        {
            //Response.Write("获取用户ID失败，请确认查询地址是否正确！");
            edtName.Focus();
            return;
        }
        DataTable dt;
        coreGW.MemberBillSearch(id, type, out dt);
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
        //计算合计
        double dAmount = 0, dTotal = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dAmount = coreGW.FmtAmount(dt.Rows[i]["Amount"].ToString());
                dTotal = dTotal + dAmount;
            }
        }
        lbTotal.Text = "合计：" + dTotal.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        searchinfo();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        searchinfo();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        searchinfo();
    }
}
