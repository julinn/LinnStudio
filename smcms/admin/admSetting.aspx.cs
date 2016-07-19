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

public partial class admin_admSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            loadData();
    }

    private void loadData()
    {
        edtNavigar.Text = cms.GetNavigar();
    }

    protected void btnNavigarSave_Click(object sender, EventArgs e)
    {
        if (cms.SaveConfig("Navigar", edtNavigar.Text))
        {
            cms.CleanAllCache();
            loadData();
        }
    }
}
