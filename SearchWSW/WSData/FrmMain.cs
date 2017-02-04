using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSData
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gb2.Text = Data.GetMac() // + ";cpu:" + uMAC.GetCpuID() 
                + ";disk:" + ulMAC.GetHardDiskID()
                + ";host:" + ulMAC.GetHostName()
                ;
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            //登录
            FrmLogin fmlogin = new FrmLogin();
            fmlogin.ShowDialog();
            if (fmlogin.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            //显示基本信息
            string lev = "用户级别：分销商";
            tlbUID.Text = "用户：" + Data.GetFdtUserInfo("Tel");
            tlbUID.ToolTipText = Data.GetFdtUserInfo("Name");
            if (Data.GetFdtUserInfo("LevID") == "2")
                lev = "用户级别：代理商";
            tlbLeave.Text = lev;
            tlbPoint.Text = "可用点数：" + Data.GetFdtUserInfo("ValidPoint");
        }
    }
}
