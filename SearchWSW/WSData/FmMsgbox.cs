using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSData
{
    public partial class FmMsgbox : Form
    {
        private string _msg;
        public string FMsgStr
        {
            get { return _msg; }
            set { _msg = value; lbMsg.Text = value; }
        }
        public FmMsgbox()
        {
            InitializeComponent();
        }

        private void FmMsgbox_Load(object sender, EventArgs e)
        {
            lbMsg.Text = FMsgStr;
        }
    }
}
