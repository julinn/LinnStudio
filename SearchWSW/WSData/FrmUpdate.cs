using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.IO;

namespace WSData
{
    public partial class FrmUpdate : Form
    {
        public FrmUpdate()
        {
            InitializeComponent();
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            //           
            timer1.Enabled = true;
        }

        private void update()
        {
            try
            {
                string url = Data.GetSystemConfig("ExeUrl");
                string dir = ulSystem.getCurrpath() + "\\update";
                if (!Directory.Exists(dir))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    dirInfo.Create();
                }
                string filename = dir + "\\WSData.exe";
                string ret = ulSystem.DownloadFile(url, filename, this.progressBar1, this.label1);
                if (ret == "")
                {
                    //MessageBox.Show("更新完成");
                    //DialogResult = DialogResult.OK;
                    label1.Text = "下载更新完成，开始升级更新，请稍候......";
                    Data.Delay(500);
                    string oldfilename = ulSystem.getCurrpath() + "\\WSData.exe";//Assembly.GetExecutingAssembly().Location;
                    string oldback = oldfilename + ".delete";
                    if (File.Exists(oldback))
                        File.Delete(oldback);
                    File.Move(oldfilename, oldfilename + ".delete");                    // 1
                    File.Copy(filename, oldfilename);                // 2
                    Application.Restart();
                }
                else
                    MessageBox.Show(ret);
            }
            catch (Exception ex)
            {
                label1.Text = "更新失败：" + ex.Message;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            update();
        }
    }
}
