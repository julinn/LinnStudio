using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSData
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string result = Data.user_login_mac(edtTel.Text, edtpwd.Text);
            if (result == "")
            {
                Data.SaveLocalConfig(edtTel.Text, edtpwd.Text, chkPwd.Checked);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //
            try
            {
                Dictionary<string, string> cfg = Data.GetLocalConfig();
                edtTel.Text = cfg["uid"];
                edtpwd.Text = cfg["pwd"];
                chkPwd.Checked = cfg["select"] == "1";
            }
            catch
            {
                //
            }
        }
    }
}
