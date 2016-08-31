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

public partial class baili : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //
        search();
    }

    private void search()
    {
        DataTable dt;
        string sql = "call proc_baili_list_search('"+TextBox1.Text+"',"+RadioButtonList1.SelectedValue.ToString()+")",
            err = "";
        ulMySqlHelper.GetaDatatable(sql, out dt, out err);
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
        //计算合计
        decimal dAmount = 0, dTotal = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dAmount = StrtoAmount(dt.Rows[i]["Amount"].ToString());
                dTotal = dTotal + dAmount;
            }
        }
        lbTotal.Text = "合计：" + dTotal.ToString()+"<hr />";
    }

    public static decimal StrtoAmount(string str)
    {
        try
        {
            return decimal.Parse(str);
        }
        catch
        {
            return 0;
        }
    }
}
