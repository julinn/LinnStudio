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

public partial class admin_admPay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        search();
    }

    private int GetMemID()
    {
        try
        {
            int id = 0;
            DataTable dt;
            coreGW.MemberSearch(0, edtStr.Text, "", out dt);
            if (dt.Rows.Count > 0)
            {
                id = coreGW.FmtInt(dt.Rows[0]["ID"].ToString());
                edtStr.Text = dt.Rows[0]["UName"].ToString();
                lbinfo.Text = dt.Rows[0]["UName"].ToString() + " | "+ dt.Rows[0]["Profession"].ToString();
            }
            return id;
        }
        catch
        {
            return 0;
        }
    }

    private void search()
    {
        int itype = coreGW.FmtInt(RadioButtonList1.SelectedValue),
            memid = GetMemID();
        if (memid == 0)
        {
            lbinfo.ToolTip = "";
            lbinfo.Text = "获取用户ID失败，请重新查询用户信息！";
            return;
        }
        lbinfo.ToolTip = memid.ToString();
        DataTable dt;
        coreGW.MemberBillSearch(memid, itype, out dt);
        coreGW.DataBind(dt, GridView1);
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
        lbTotal.Text = dTotal.ToString();
    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        //结算
        int memID = coreGW.FmtInt(lbinfo.ToolTip);
        if (memID == 0)
        {
            coreGW.MsgLableErr("获取成员ID失败，请重新查询", lbMsg);
            return;
        }
        if (RadioButtonList1.SelectedValue != "1")
        {
            coreGW.MsgLableErr("已结算单据不能重复结算，请重新查询", lbMsg);
            return;
        }
        double dAmount = coreGW.FmtAmount(lbTotal.Text);
        string ret = coreGW.MemberBillPay(memID, edtRemark.Text, dAmount);
        if (ret == "")
        {
            coreGW.MsgLableOK("结算成功！", lbMsg);
            search();
        }
        else
        {
            coreGW.MsgLableErr(ret, lbMsg);
        }

    }
}
