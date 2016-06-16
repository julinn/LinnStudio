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

public partial class admin_admLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            lbCode.Text = GetCode();
        if (Request.QueryString["act"] != null)
            Session.Clear();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (edtUID.Text == "")
        {
            lbMsg.Text = "用户名不能为空";
            return;
        }
        if (edtPwd.Text == "")
        {
            lbMsg.Text = "密码不能为空";
            return;
        }
        if (edtCode.Text != lbCode.Text)
        {
            lbMsg.Text = "验证码错误";
            return;
        }
        if (cms.adminLogin(edtUID.Text, edtPwd.Text))
        {
            Session["UserID"] = edtUID.Text;
            Response.Redirect("admCenter.aspx");
        }
        else
            lbMsg.Text = "用户名或密码错误！";
    }
    private string GetCode()
    {
        Random rd = new Random();
        return rd.Next(1000, 9999).ToString();
    }
}
