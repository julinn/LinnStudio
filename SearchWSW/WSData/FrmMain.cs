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
        FmMsgbox Ffmmsg = null;
        public FmMain()
        {
            InitializeComponent();
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            //检测是否有新版本需要更新
            if (Data.ExeUpdateCheck())
            {
                FrmUpdate fmupdate = new FrmUpdate();
                fmupdate.ShowDialog();
                return;
            }
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
            tlbValidTime.Text = "有效期至：" + Data.GetFdtUserInfo("ValidTime");
            cmbClass.SelectedIndex = 0;
            //加载文章分页信息
            string sCount = Data.GetPages(cmbPages);
            gbPages.Text = "文章总数："+sCount + " ; 总页数："+cmbPages.Items.Count.ToString() + " ; 每页记录：50";
            //加载货源总数信息
            gbData.Text = Data.data_info();
        }

        private void btndataSearch_Click(object sender, EventArgs e)
        {
            //数据查询
            try
            {
                waitShow("正在查询...");
                DataTable dt = Data.data_search(cmbClass.Text, edtSearchStr.Text);
                gvData.AutoGenerateColumns = false;
                gvData.DataSource = dt.DefaultView;
                gvData.Columns[2].Width = gvData.Width - 220;
            }
            finally
            {
                waitHide();
            }
        }

        private void GetSelectItemData()
        {
            mmData.Text = "";
            picwxImg.Image = null;
            try
            {
                waitShow("正在加载数据...");
                int i = gvData.CurrentRow.Index;
                string wxID = gvData.Rows[i].Cells["wxID"].Value.ToString(),
                    title = gvData.Rows[i].Cells["Title"].Value.ToString(),
                    wxImg = gvData.Rows[i].Cells["wxImg"].Value.ToString(),
                    time = gvData.Rows[i].Cells["RecTime"].Value.ToString(),
                    content = gvData.Rows[i].Cells["Content"].Value.ToString();

                mmData.AppendText("微信号：" + wxID + "\r\n");
                mmData.AppendText("收录时间：" + time + "\r\n");
                mmData.AppendText("标题：" + title);
                //获取图片
                string img = Data.ImageUrlCheckDown(wxImg);
                if (img != "")
                    picwxImg.Image = Image.FromFile(img);
            }
            catch
            {
                //
            }
            finally
            {
                waitHide();
            }
        }

        private void gvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvData.Rows.Count == 0)
                return;
            GetSelectItemData();
        }

        private void btnUserSearch_Click(object sender, EventArgs e)
        {
            //查询用户的代理商/分销商
            try
            {
                waitShow("正在查询...");
                DataTable dt = Data.user_search(edtUserstr.Text);
                gvUsers.AutoGenerateColumns = false;
                gvUsers.DataSource = dt.DefaultView;
            }
            finally
            {
                waitHide();
            }
        }

        #region 等待窗体
        //显示执行等待窗口
        private void waitShow(string msg)
        {
            if (Ffmmsg == null)
            {
                Ffmmsg = new FmMsgbox();
                Ffmmsg.FMsgStr = msg;
                Ffmmsg.TopMost = true;
                Ffmmsg.StartPosition = FormStartPosition.CenterScreen;
                Ffmmsg.Show();
            }
            else
            {
                Ffmmsg.FMsgStr = msg;
                //Ffmmsg.Show();
            }
            Data.Delay(500);
        }
        //关闭执行等待窗口
        private void waitHide()
        {
            if (Ffmmsg != null)
            {
                Ffmmsg.Close();
                Ffmmsg = null;
            }
        }
        #endregion 

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            FrmUserAdd fmuseradd = new FrmUserAdd();
            fmuseradd.ShowDialog();
        }

        private void cmbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Data.article_search(cmbPages.SelectedIndex + 1);
            gvArticle.AutoGenerateColumns = false;
            gvArticle.DataSource = dt.DefaultView;
        }

        private void btnArticleBefore_Click(object sender, EventArgs e)
        {
            //上一页
            if (cmbPages.SelectedIndex > 0)
                cmbPages.SelectedIndex = cmbPages.SelectedIndex - 1;
        }

        private void btnArticelNext_Click(object sender, EventArgs e)
        {
            //下一页
            if (cmbPages.SelectedIndex < cmbPages.Items.Count - 1)
                cmbPages.SelectedIndex = cmbPages.SelectedIndex + 1;
        }

        //显示文章内容
        private void showArticleContent()
        {
            try
            {                
                waitShow("正在加载数据...");
                int i = gvArticle.CurrentRow.Index;
                string content = gvArticle.Rows[i].Cells["articleContent"].Value.ToString();
                wbArticleContent.DocumentText = content;
            }
            catch
            {
                //
            }
            finally
            {
                waitHide();
            }
        }

        private void gvArticle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvArticle.RowCount == 0)
                return;
            showArticleContent();
        }

        //帐户信息页面 =================
        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            //修改密码
            FrmChangePwd fmcp = new FrmChangePwd();
            fmcp.ShowDialog();
        }
    }
}
