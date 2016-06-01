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

public partial class admin_admClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = ulLinnStudio.ulSqlHelper.GetIntValue(edtID.Text);
        int pid = ulLinnStudio.ulSqlHelper.GetIntValue(edtPID.Text);
        mod_class cls = new mod_class(0);
        cls.ID = id;
        cls.Name = edtName.Text;
        cls.PID = pid;
        string ret = cls.Save();
        if (ret == "")
            lbMsg.Text = "保存成功";
        else
            lbMsg.Text = "保存失败：" + ret;
    }
}
