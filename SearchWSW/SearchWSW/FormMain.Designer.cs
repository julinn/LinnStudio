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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wbGet = new System.Windows.Forms.WebBrowser();
            this.gbDoing = new System.Windows.Forms.GroupBox();
            this.mmData = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lbDoingInfo = new System.Windows.Forms.Label();
            this.edtUrl = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tMain.SuspendLayout();
            this.tp1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbDoing.SuspendLayout();
            this.SuspendLayout();
            // 
            // tMain
            // 
            this.tMain.Controls.Add(this.tp1);
            this.tMain.Controls.Add(this.tabPage2);
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
            this.tp1.Text = "tabPage1";
            this.tp1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // wbGet
            // 
            this.wbGet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbGet.Location = new System.Drawing.Point(3, 51);
            this.wbGet.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGet.Name = "wbGet";
            this.wbGet.Size = new System.Drawing.Size(915, 649);
            this.wbGet.TabIndex = 1;
            this.wbGet.Url = new System.Uri("", System.UriKind.Relative);
            this.wbGet.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbGet_DocumentCompleted);
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
            // mmData
            // 
            this.mmData.Location = new System.Drawing.Point(6, 107);
            this.mmData.Name = "mmData";
            this.mmData.Size = new System.Drawing.Size(907, 476);
            this.mmData.TabIndex = 1;
            this.mmData.Text = "";
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
            // lbDoingInfo
            // 
            this.lbDoingInfo.AutoSize = true;
            this.lbDoingInfo.Location = new System.Drawing.Point(10, 60);
            this.lbDoingInfo.Name = "lbDoingInfo";
            this.lbDoingInfo.Size = new System.Drawing.Size(53, 12);
            this.lbDoingInfo.TabIndex = 1;
            this.lbDoingInfo.Text = "准备就绪";
            // 
            // edtUrl
            // 
            this.edtUrl.Location = new System.Drawing.Point(6, 20);
            this.edtUrl.Name = "edtUrl";
            this.edtUrl.Size = new System.Drawing.Size(636, 21);
            this.edtUrl.TabIndex = 0;
            this.edtUrl.Text = "http://www.wshangw.net/a/nanxie_nvxie/";
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
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDoing.ResumeLayout(false);
            this.gbDoing.PerformLayout();
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
    }
}

