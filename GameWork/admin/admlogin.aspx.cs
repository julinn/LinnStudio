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

public partial class admin_admlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["act"] != null)
            {
                if (Request.QueryString["act"].ToString() == "out")
                    Session.Clear();
            }
            if (ulMySqlHelper.GetAppSetting("WXCode") != "1")
            {
                lbCode.Text = GetCode();
            }
        }
    }

    private string GetCode()
    {
        Random dr = new Random();
        return dr.Next(1000, 9999).ToString();
    }

    private void login()
    {
        string userid = edtUserID.Text,
            passwd = edtPasswd.Text,
            keycode = edtKeycode.Text;
        keycode = coreGW.FmtStr(keycode).Replace(" ", "");
        //注释用于调试 跳过验证码
        /**/        
        if (keycode.Length < 4)
        {
            lbMsg.Text = "验证码错误！";
            return;
        }
        if (ulMySqlHelper.GetAppSetting("WXCode") != "1")
        {
            if (edtKeycode.Text != lbCode.Text)
            {
                lbMsg.Text = "验证码错误！";
                return;
            }
            keycode = "";
        }
        //跳过结束=========

        string ret = coreGW.admLogin(this.Page, userid, passwd, keycode); 
        if (ret == "")
        {
            Response.Redirect("admCenter.aspx");
        }
        else
        {
            lbMsg.Text = ret;
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("../search.aspx");
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        login();
    }
}
