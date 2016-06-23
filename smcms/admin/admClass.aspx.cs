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
        if (!IsPostBack)
        {
            pnlEidt.Visible = false;
            load();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (edtName.Text == "")
        {
            lbMsg.Text = "名称不能为空";
            return;
        }
        int id = ulLinnStudio.ulSqlHelper.GetIntValue(edtID.Text);
        int pid = 0;// ulLinnStudio.ulSqlHelper.GetIntValue(edtPID.Text);
        mod_class cls = new mod_class(id);
        cls.ID = id;
        cls.Name = edtName.Text;
        cls.PID = pid;
        string ret = cls.Save();
        if (ret == "")
        {
            //lbMsg.Text = "保存成功";
            load();
            pnlEidt.Visible = false;
            lbMsg.Text = "";
        }
        else
            lbMsg.Text = "保存失败：" + ret;
    }

    private void load()
    {
        DataTable dt = mod_class.GetData();
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = cms.StrToInt(GridView1.SelectedDataKey[0].ToString());            
            if (id == 0)
                return;
            lbFlag.Text = "编辑";
            mod_class cls = new mod_class(id);
            edtID.Text = cls.ID.ToString();
            edtName.Text = cls.Name;
            pnlEidt.Visible = true;
            //edtPID.Text = cls.PID.ToString();
        }
        catch
        {
        }
    }
    protected void btnAddNavigar_Click(object sender, EventArgs e)
    {
        int iID = cms.StrToInt(edtID.Text);
        if (iID == 0)
        {
            lbMsg.Text = "还未添加分类不能加入导航";
            return;
        }
        mod_class cls = new mod_class(iID);
        if(cls.AddNavigar())
            lbMsg.Text = "添加导航成功";
        else
            lbMsg.Text = "添加导航失败";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        edtID.Text = "0";
        lbFlag.Text = "添加";
        edtName.Text = "";
        pnlEidt.Visible = true;
    }
}
