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

public partial class admin_conn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string conn = ulLinnStudio.ulSqlHelper.FormatConnStr(edtIP.Text, edtUID.Text, edtPWd.Text, edtDb.Text);
        if (ulLinnStudio.ulSqlHelper.TestConnstring(conn))
        {
            if (ulLinnStudio.ulSqlHelper.SaveConnString(conn))
            {
                Response.Write("保存成功");
            }
            else
            {
                conn = ulLinnStudio.ulSqlHelper.SimpleEncStr(conn);
                Response.Write("手动设置连接字符串：<br/>" + conn);
            }
        }
        else
        {
            Response.Write("连接参数错误");
        }
    }
}
