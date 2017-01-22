using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SearchWSW
{
    public partial class FormMain : Form
    {
        private static bool FbIniCount;
        private static int FiPage;
        private static int FiRecord;
        private static string FsPageList;
        private static int FiCurr;
        private static string[] FList;
        private static bool FbDoing;
        public FormMain()
        {
            InitializeComponent();
        }

        private bool WaitWebPageLoad()
        {
            int i = 0;
            string sUrl;
            while (true)
            {
                wsCore.Delay(50);  //系统延迟50毫秒，够少了吧！               
                if (wbGet.ReadyState == WebBrowserReadyState.Complete) //先判断是否发生完成事件。  
                {
                    if (!wbGet.IsBusy) //再判断是浏览器是否繁忙                    
                    {
                        i = i + 1;
                        if (i == 2)   //为什么 是2呢？因为每次加载frame完成时就会置IsBusy为false,未完成就就置IsBusy为false，你想一想，加载一次，然后再一次，再一次...... 最后一次.......  
                        {
                            sUrl = wbGet.Url.ToString();
                            if (sUrl.Contains("res")) //这是判断没有网络的情况下                             
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        continue;
                    }
                    i = 0;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //测试读取
            //string path = Application.StartupPath + @"\list.txt";
            //string str = System.IO.File.ReadAllText(path);
            if (edtUrl.Text == "")
                return;
            //
            showInfo("开始任务");
            btnTest.Enabled = false;
            FbIniCount = false;
            FiPage = 0;
            FiRecord = 0;
            FsPageList = "";
            FiCurr = 0;
            FbDoing = true;
            mmData.Text = "";
            //数据实测
            //string url = "http://www.wshangw.net/a/nvzhuang_nanzhuang/";
            wbGet.Url = new Uri(edtUrl.Text);
            wbGet.Navigate(edtUrl.Text);
            
            //结果
            //string s = wsCore.GetList(str);
            //mmData.Text = s;
            //if (WaitWebPageLoad())
            //{
            //    string str = wbGet.Document.Body.InnerHtml;
            //    mmData.Text = wsCore.GetList(str);
            //}
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tMain.SelectedIndex = 1;
        }

        private void wbGet_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!FbDoing)
                return;
            if (e.Url != wbGet.Document.Url)
                return;
            string str = wbGet.Document.Body.InnerHtml;
            if (!FbIniCount)
            {
                showInfo("正在初始化分页信息......");
                FsPageList = wsCore.GetPageInfo(str, wbGet.Url.ToString(), out FiPage, out FiRecord);
                if (FsPageList.Contains("|"))
                    FList = FsPageList.Split('|');
                gbDoing.Text = "找到【" + FiRecord.ToString() + "】条记录";
                FbIniCount = true;
            }
            Doing(str);
        }

        private void showInfo(string str)
        {
            lbDoingInfo.Text = str;
            wsCore.Delay(50);
        }

        private void Doing(string dataStr)
        {
            if (!FbDoing)
                return;
            FiCurr = FiCurr + 1;
            showInfo("正在执行：" + FiCurr.ToString() + " / " + FiPage.ToString() + " ......");
            string data = wsCore.GetList(dataStr);
            if (mmData.Text == "")
                mmData.Text = data;
            else
                mmData.Text = mmData.Text + "@" + data;
            if (FiPage > 1 && FiCurr < FiPage && FList.Length == FiPage)
            {
                wbGet.Navigate(FList[FiCurr]);
            }
            if (FiCurr >= FiPage)
            {
                showInfo("采集结束！");
                mmData.SaveFile(Application.StartupPath + "data.txt");
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            wbGet.Navigate(edtUrl.Text);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //停止
            FbDoing = false;
            btnTest.Enabled = true;
        }
    }
}
