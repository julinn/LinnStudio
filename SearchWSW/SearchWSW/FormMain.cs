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
        //
        private static DataTable FdtDetail;
        private static int FiDetailCurr;
        private static int FiDetailTotal;
        private static bool FbDetailDoing;
        private static int FiDetailRecID;
        private static bool FbIsDetailArticle;
        //
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
            string data = wsCore.GetList(dataStr, cmbClass.Text);
            if (mmData.Text == "")
                mmData.Text = data;
            else
                mmData.AppendText("@" + data);
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
        private void msgDetail(string str)
        {
            lbDetail.Text = str;
            wsCore.Delay(50);
        }

        private void DetailLog(string str)
        {
            mmDetail.AppendText(str + "\r\n");
        }
        private void btnDetail_Click(object sender, EventArgs e)
        {
            //明细更新开始            
            FdtDetail = wsCore.GetNoDetailList();
            if (FdtDetail.Rows.Count == 0)
                return;
            FbIsDetailArticle = chkIsArticle.Checked;
            //第一次触发
            FiDetailTotal = FdtDetail.Rows.Count;
            FiDetailRecID = wsCore.StrToInt(FdtDetail.Rows[FiDetailCurr]["RecID"].ToString());
            string url = FdtDetail.Rows[FiDetailCurr]["Url"].ToString();
            if (FiDetailRecID == 0 || url == "")
            {
                lbDetail.Text = "ID 或 URL 为空";
                return;
            }
            FbDetailDoing = true;
            FiDetailCurr = 0;       
            wbDetail.Navigate(url);
        }

        private void wbDetail_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //
            if (!FbDetailDoing)
                return;
            if (e.Url != wbDetail.Document.Url)
                return;
            string str = wbDetail.Document.Body.InnerHtml;
            DetailDoing(str);
        }

        private void DetailDoing(string html)
        {
            //解析数据
            msgDetail("更新进度：" + (FiDetailCurr + 1).ToString() + " / " + FiDetailTotal.ToString() + " ......");
            string result = "";
            if (FbIsDetailArticle)
                result = wsCore.GetDetailArticleInfo(html, FiDetailRecID);
            else
                result = wsCore.GetDetailInfo(html, FiDetailRecID);
            //mmDetail.Text = result;
            DetailLog(result);
            //下一轮准备
            FiDetailCurr = FiDetailCurr + 1;
            if(FiDetailCurr < FdtDetail.Rows.Count)
            {
                string url = FdtDetail.Rows[FiDetailCurr]["Url"].ToString();
                FiDetailRecID = wsCore.StrToInt(FdtDetail.Rows[FiDetailCurr]["RecID"].ToString());
                wbDetail.Navigate(url);
            }
        }

        /// <summary>
        /// 下载图片；1微信二维码； 2展示图
        /// </summary>
        /// <param name="type">1微信二维码； 2展示图</param>
        private void ImageDownload(int type)
        {
            //下载图片
            if (type != 1)
                type = 2;
            mmDown.Text = "";
            //string url = "http://www.wshangw.net/uploads/allimg/161212/1-1612121I5550-L.png";
            //url = wsCore.ImageDownload(url);
            //mmDown.AppendText(url);

            //正式
            DataTable dt = wsCore.GetDonwImgList(type);
            int iCount = dt.Rows.Count;
            if (iCount == 0)
            {
                lbDown.Text = "没有找到记录";
                return;
            }
            string url = "";
            for (int i = 0; i < iCount; i++)
            {
                lbDown.Text = "正在下载：" + (i + 1).ToString() + " / " + iCount + " ......";
                wsCore.Delay(10);
                url = dt.Rows[i]["URL"].ToString();
                if (!url.Contains("http://"))
                    url = "http://" + url;
                url = wsCore.ImageDownload(url);
                mmDown.AppendText(url + "\r\n");
            }
        }

        private void btnImgDownload_Click(object sender, EventArgs e)
        {
            /*
            //下载图片
            mmDown.Text = "";
            //string url = "http://www.wshangw.net/uploads/allimg/161212/1-1612121I5550-L.png";
            //url = wsCore.ImageDownload(url);
            //mmDown.AppendText(url);

            //正式
            DataTable dt = wsCore.GetDonwImgList(1);
            int iCount = dt.Rows.Count;
            if (iCount == 0)
            {
                lbDown.Text = "没有找到记录";
                return;
            }
            string url = "";
            for (int i = 0; i < iCount; i++)
            {
                lbDown.Text = "正在下载：" + (i + 1).ToString() + " / " + iCount + " ......";
                wsCore.Delay(10);
                url = dt.Rows[i]["URL"].ToString();
                url = wsCore.ImageDownload(url);
                mmDown.AppendText(url + "\r\n");
            }
             */
            ImageDownload(1);
        }

        private void btnImageDownShowimg_Click(object sender, EventArgs e)
        {
            ImageDownload(2);
        }

        private void btnUpdateArticle_Click(object sender, EventArgs e)
        {

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbClass.SelectedIndex;
            if (i < 0)
                return;
            switch (i)
            {
                case 0:
                    edtUrl.Text = "http://www.wshangw.net/a/nvzhuang_nanzhuang/";
                    break;
                case 1:
                    edtUrl.Text = "http://www.wshangw.net/a/nanxie_nvxie/";
                    break;
                case 2:
                    edtUrl.Text = "http://www.wshangw.net/a/huazhuangpin/";
                    break;
                case 3:
                    edtUrl.Text = "http://www.wshangw.net/a/shechipinpai/";
                    break;
                case 4:
                    edtUrl.Text = "http://www.wshangw.net/a/qitahuoyuan/";
                    break;
                case 5:
                    edtUrl.Text = "http://www.wshangw.net/a/weixinyingxiao/";
                    break;
            }
        }
    }
}
