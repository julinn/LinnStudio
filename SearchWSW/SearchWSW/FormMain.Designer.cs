namespace SearchWSW
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tMain = new System.Windows.Forms.TabControl();
            this.tp1 = new System.Windows.Forms.TabPage();
            this.wbGet = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.edtUrl = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mmData = new System.Windows.Forms.RichTextBox();
            this.gbDoing = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.lbDoingInfo = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mmDetail = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbDetail = new System.Windows.Forms.WebBrowser();
            this.btnDetail = new System.Windows.Forms.Button();
            this.lbDetail = new System.Windows.Forms.Label();
            this.tMain.SuspendLayout();
            this.tp1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbDoing.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tMain
            // 
            this.tMain.Controls.Add(this.tp1);
            this.tMain.Controls.Add(this.tabPage2);
            this.tMain.Controls.Add(this.tabPage1);
            this.tMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tMain.Location = new System.Drawing.Point(0, 0);
            this.tMain.Name = "tMain";
            this.tMain.SelectedIndex = 0;
            this.tMain.Size = new System.Drawing.Size(929, 729);
            this.tMain.TabIndex = 0;
            // 
            // tp1
            // 
            this.tp1.Controls.Add(this.wbGet);
            this.tp1.Controls.Add(this.groupBox1);
            this.tp1.Location = new System.Drawing.Point(4, 22);
            this.tp1.Name = "tp1";
            this.tp1.Padding = new System.Windows.Forms.Padding(3);
            this.tp1.Size = new System.Drawing.Size(921, 703);
            this.tp1.TabIndex = 0;
            this.tp1.Text = "网址设置";
            this.tp1.UseVisualStyleBackColor = true;
            // 
            // wbGet
            // 
            this.wbGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbGet.Location = new System.Drawing.Point(3, 51);
            this.wbGet.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGet.Name = "wbGet";
            this.wbGet.ScriptErrorsSuppressed = true;
            this.wbGet.Size = new System.Drawing.Size(915, 649);
            this.wbGet.TabIndex = 1;
            this.wbGet.Url = new System.Uri("", System.UriKind.Relative);
            this.wbGet.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbGet_DocumentCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.edtUrl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(659, 18);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(120, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "打开网址";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // edtUrl
            // 
            this.edtUrl.Location = new System.Drawing.Point(6, 20);
            this.edtUrl.Name = "edtUrl";
            this.edtUrl.Size = new System.Drawing.Size(636, 21);
            this.edtUrl.TabIndex = 0;
            this.edtUrl.Text = "http://www.wshangw.net/a/nanxie_nvxie/";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mmData);
            this.tabPage2.Controls.Add(this.gbDoing);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(921, 703);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据采集";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mmData
            // 
            this.mmData.Location = new System.Drawing.Point(6, 107);
            this.mmData.Name = "mmData";
            this.mmData.Size = new System.Drawing.Size(907, 476);
            this.mmData.TabIndex = 1;
            this.mmData.Text = "";
            // 
            // gbDoing
            // 
            this.gbDoing.Controls.Add(this.btnStop);
            this.gbDoing.Controls.Add(this.lbDoingInfo);
            this.gbDoing.Controls.Add(this.btnTest);
            this.gbDoing.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDoing.Location = new System.Drawing.Point(3, 3);
            this.gbDoing.Name = "gbDoing";
            this.gbDoing.Size = new System.Drawing.Size(915, 78);
            this.gbDoing.TabIndex = 0;
            this.gbDoing.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(132, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(121, 41);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lbDoingInfo
            // 
            this.lbDoingInfo.AutoSize = true;
            this.lbDoingInfo.Location = new System.Drawing.Point(10, 60);
            this.lbDoingInfo.Name = "lbDoingInfo";
            this.lbDoingInfo.Size = new System.Drawing.Size(53, 12);
            this.lbDoingInfo.TabIndex = 1;
            this.lbDoingInfo.Text = "准备就绪";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(5, 14);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(121, 41);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "开始";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.wbDetail);
            this.tabPage1.Controls.Add(this.mmDetail);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(921, 703);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "明细更新";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mmDetail
            // 
            this.mmDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.mmDetail.Location = new System.Drawing.Point(3, 103);
            this.mmDetail.Name = "mmDetail";
            this.mmDetail.Size = new System.Drawing.Size(915, 161);
            this.mmDetail.TabIndex = 1;
            this.mmDetail.Text = " ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbDetail);
            this.groupBox2.Controls.Add(this.btnDetail);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(915, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "`";
            // 
            // wbDetail
            // 
            this.wbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbDetail.Location = new System.Drawing.Point(3, 264);
            this.wbDetail.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDetail.Name = "wbDetail";
            this.wbDetail.ScriptErrorsSuppressed = true;
            this.wbDetail.Size = new System.Drawing.Size(915, 436);
            this.wbDetail.TabIndex = 2;
            this.wbDetail.Url = new System.Uri("http://www.wshangw.net/a/nvzhuang_nanzhuang/2016/1212/9235.html", System.UriKind.Absolute);
            this.wbDetail.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbDetail_DocumentCompleted);
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(6, 20);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(121, 41);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "开始";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // lbDetail
            // 
            this.lbDetail.AutoSize = true;
            this.lbDetail.Location = new System.Drawing.Point(6, 73);
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.Size = new System.Drawing.Size(53, 12);
            this.lbDetail.TabIndex = 2;
            this.lbDetail.Text = "准备就绪";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 729);
            this.Controls.Add(this.tMain);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据采集";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tMain.ResumeLayout(false);
            this.tp1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbDoing.ResumeLayout(false);
            this.gbDoing.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tMain;
        private System.Windows.Forms.TabPage tp1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser wbGet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbDoing;
        private System.Windows.Forms.RichTextBox mmData;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lbDoingInfo;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox edtUrl;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox mmDetail;
        private System.Windows.Forms.WebBrowser wbDetail;
        private System.Windows.Forms.Label lbDetail;
        private System.Windows.Forms.Button btnDetail;
    }
}

