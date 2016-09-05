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

public partial class admin_admChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        //修改密码
        int uid = coreGW.GetSessionID(this.Page);
        if(uid == 0)
        {
            lbMsg.Text = "获取用户ID失败，请重新登录后再试";
            return;
        }
        string ret = coreGW.UserChangePassword(uid, edtOld.Text, edtPwd.Text, edtPwd1.Text);
        if (ret == "")
            coreGW.MsgLableOK("密码修改成功！", lbMsg);
        else
            coreGW.MsgLableErr(ret, lbMsg);
    }
}
