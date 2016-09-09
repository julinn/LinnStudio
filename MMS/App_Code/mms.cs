using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
///mms 的摘要说明
/// </summary>
public class mms
{
	public mms()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static bool checkLogin(Page page)
    {
        bool b = true;
        if (page.Session.Count == 0 || page.Session["UID"] == null || page.Session["UserID"] == null)
            b = false;
        return b;
    }
}
