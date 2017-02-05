using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSData
{
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //
            string ret = Data.user_changePasswd(edtoldPwd.Text, edtPwd1.Text, edtPwd2.Text);
            if (ret == "")
            {
                MessageBox.Show("密码修改成功");
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(ret);
        }
    }
}
