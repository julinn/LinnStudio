using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSData
{
    public partial class FrmUserAdd : Form
    {
        public FrmUserAdd()
        {
            InitializeComponent();
        }

        private void FrmUserAdd_Load(object sender, EventArgs e)
        {
            //
            edtuTel.Text = Data.GetFdtUserInfo("Tel");
            if (Data.GetFdtUserInfo("LevID") != "2")
                rbt2.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string tel = edtTel.Text;
            if (tel.Length != 11 || !ulSystem.IsNumber(tel))
            {
                MessageBox.Show("手机号码格式错误");
                edtTel.Focus();
                edtTel.SelectAll();
                return;
            }
            if (Data.FmtStr(edtPwd1.Text) == "")
            {
                MessageBox.Show("密码不能为空");
                edtPwd1.Focus();
                edtPwd1.SelectAll();
                return;
            }
            if (edtPwd1.Text != edtPwd2.Text)
            {
                MessageBox.Show("两次输入的密码不一致");
                edtPwd1.Focus();
                edtPwd1.SelectAll();
                return;
            }
            int iLev = 1;
            if (rbt2.Checked)
                iLev = 2;
            string ret = Data.user_create(tel, edtPwd1.Text, edtName.Text, iLev, edtuTel.Text, edtuPwd.Text);
            if (ret == "")
            {
                MessageBox.Show("恭喜，新建用户成功！");
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(ret);
        }
    }
}
