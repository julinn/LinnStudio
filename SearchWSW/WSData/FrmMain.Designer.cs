namespace WSData
{
    partial class FmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvData = new System.Windows.Forms.DataGridView();
            this.RecTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wxID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wxImg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mmData = new System.Windows.Forms.RichTextBox();
            this.picwxImg = new System.Windows.Forms.PictureBox();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btndataSearch = new System.Windows.Forms.Button();
            this.edtSearchStr = new System.Windows.Forms.TextBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvUsers = new System.Windows.Forms.DataGridView();
            this.RecID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.edtUserstr = new System.Windows.Forms.TextBox();
            this.btnUserSearch = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.wbArticleContent = new System.Windows.Forms.WebBrowser();
            this.gvArticle = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articleContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPages = new System.Windows.Forms.GroupBox();
            this.btnArticelNext = new System.Windows.Forms.Button();
            this.btnArticleBefore = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPages = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlbUID = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbLeave = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbValidTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picwxImg)).BeginInit();
            this.gbData.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.gb2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvArticle)).BeginInit();
            this.gbPages.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(827, 544);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvData);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.gbData);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(819, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "货源信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gvData
            // 
            this.gvData.AllowUserToAddRows = false;
            this.gvData.AllowUserToDeleteRows = false;
            this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecTime,
            this.wxID,
            this.Title,
            this.wxImg,
            this.Content});
            this.gvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvData.Location = new System.Drawing.Point(3, 69);
            this.gvData.MultiSelect = false;
            this.gvData.Name = "gvData";
            this.gvData.ReadOnly = true;
            this.gvData.RowTemplate.Height = 23;
            this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvData.Size = new System.Drawing.Size(613, 434);
            this.gvData.TabIndex = 2;
            this.gvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvData_CellClick);
            // 
            // RecTime
            // 
            this.RecTime.DataPropertyName = "RecTime";
            this.RecTime.HeaderText = "收录时间";
            this.RecTime.Name = "RecTime";
            this.RecTime.ReadOnly = true;
            // 
            // wxID
            // 
            this.wxID.DataPropertyName = "wxID";
            this.wxID.HeaderText = "微信号";
            this.wxID.Name = "wxID";
            this.wxID.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "标题";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 400;
            // 
            // wxImg
            // 
            this.wxImg.DataPropertyName = "wxImg";
            this.wxImg.HeaderText = "图片地址";
            this.wxImg.Name = "wxImg";
            this.wxImg.ReadOnly = true;
            this.wxImg.Visible = false;
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            this.Content.HeaderText = "内容";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mmData);
            this.groupBox2.Controls.Add(this.picwxImg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(616, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 434);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "展示图";
            // 
            // mmData
            // 
            this.mmData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmData.Location = new System.Drawing.Point(3, 211);
            this.mmData.Name = "mmData";
            this.mmData.ReadOnly = true;
            this.mmData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.mmData.Size = new System.Drawing.Size(194, 220);
            this.mmData.TabIndex = 1;
            this.mmData.Text = "";
            // 
            // picwxImg
            // 
            this.picwxImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.picwxImg.Location = new System.Drawing.Point(3, 17);
            this.picwxImg.Name = "picwxImg";
            this.picwxImg.Size = new System.Drawing.Size(194, 194);
            this.picwxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picwxImg.TabIndex = 0;
            this.picwxImg.TabStop = false;
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.label2);
            this.gbData.Controls.Add(this.btndataSearch);
            this.gbData.Controls.Add(this.edtSearchStr);
            this.gbData.Controls.Add(this.cmbClass);
            this.gbData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbData.Location = new System.Drawing.Point(3, 3);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(813, 66);
            this.gbData.TabIndex = 0;
            this.gbData.TabStop = false;
            this.gbData.Text = "货源查询";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "类别";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btndataSearch
            // 
            this.btndataSearch.Location = new System.Drawing.Point(426, 29);
            this.btndataSearch.Name = "btndataSearch";
            this.btndataSearch.Size = new System.Drawing.Size(75, 23);
            this.btndataSearch.TabIndex = 2;
            this.btndataSearch.Text = "查询";
            this.btndataSearch.UseVisualStyleBackColor = true;
            this.btndataSearch.Click += new System.EventHandler(this.btndataSearch_Click);
            // 
            // edtSearchStr
            // 
            this.edtSearchStr.Location = new System.Drawing.Point(201, 29);
            this.edtSearchStr.Name = "edtSearchStr";
            this.edtSearchStr.Size = new System.Drawing.Size(206, 21);
            this.edtSearchStr.TabIndex = 1;
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "全部",
            "服装",
            "鞋子",
            "化妆品",
            "奢侈品牌",
            "其他"});
            this.cmbClass.Location = new System.Drawing.Point(74, 29);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 20);
            this.cmbClass.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvUsers);
            this.tabPage2.Controls.Add(this.gb2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(819, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "分销代理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gvUsers
            // 
            this.gvUsers.AllowUserToAddRows = false;
            this.gvUsers.AllowUserToDeleteRows = false;
            this.gvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecID,
            this.Tel,
            this.uName,
            this.LevName,
            this.CreateTime});
            this.gvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvUsers.Location = new System.Drawing.Point(3, 66);
            this.gvUsers.MultiSelect = false;
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.ReadOnly = true;
            this.gvUsers.RowTemplate.Height = 23;
            this.gvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvUsers.Size = new System.Drawing.Size(813, 437);
            this.gvUsers.TabIndex = 1;
            // 
            // RecID
            // 
            this.RecID.DataPropertyName = "RecID";
            this.RecID.HeaderText = "RecID";
            this.RecID.Name = "RecID";
            this.RecID.ReadOnly = true;
            this.RecID.Visible = false;
            // 
            // Tel
            // 
            this.Tel.DataPropertyName = "Tel";
            this.Tel.HeaderText = "手机号";
            this.Tel.Name = "Tel";
            this.Tel.ReadOnly = true;
            // 
            // uName
            // 
            this.uName.DataPropertyName = "Name";
            this.uName.HeaderText = "姓名";
            this.uName.Name = "uName";
            this.uName.ReadOnly = true;
            // 
            // LevName
            // 
            this.LevName.DataPropertyName = "LevName";
            this.LevName.HeaderText = "类型";
            this.LevName.Name = "LevName";
            this.LevName.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "加入日期";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.btnCreateUser);
            this.gb2.Controls.Add(this.label1);
            this.gb2.Controls.Add(this.edtUserstr);
            this.gb2.Controls.Add(this.btnUserSearch);
            this.gb2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb2.Location = new System.Drawing.Point(3, 3);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(813, 63);
            this.gb2.TabIndex = 0;
            this.gb2.TabStop = false;
            this.gb2.Text = "代理查询";
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(316, 27);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(75, 23);
            this.btnCreateUser.TabIndex = 9;
            this.btnCreateUser.Text = "新建用户";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "手机号/姓名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtUserstr
            // 
            this.edtUserstr.Location = new System.Drawing.Point(94, 29);
            this.edtUserstr.Name = "edtUserstr";
            this.edtUserstr.Size = new System.Drawing.Size(126, 21);
            this.edtUserstr.TabIndex = 1;
            // 
            // btnUserSearch
            // 
            this.btnUserSearch.Location = new System.Drawing.Point(226, 27);
            this.btnUserSearch.Name = "btnUserSearch";
            this.btnUserSearch.Size = new System.Drawing.Size(75, 23);
            this.btnUserSearch.TabIndex = 0;
            this.btnUserSearch.Text = "查询";
            this.btnUserSearch.UseVisualStyleBackColor = true;
            this.btnUserSearch.Click += new System.EventHandler(this.btnUserSearch_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.wbArticleContent);
            this.tabPage3.Controls.Add(this.gvArticle);
            this.tabPage3.Controls.Add(this.gbPages);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(819, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "微信营销";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // wbArticleContent
            // 
            this.wbArticleContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbArticleContent.Location = new System.Drawing.Point(451, 88);
            this.wbArticleContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbArticleContent.Name = "wbArticleContent";
            this.wbArticleContent.ScriptErrorsSuppressed = true;
            this.wbArticleContent.Size = new System.Drawing.Size(365, 415);
            this.wbArticleContent.TabIndex = 3;
            // 
            // gvArticle
            // 
            this.gvArticle.AllowUserToAddRows = false;
            this.gvArticle.AllowUserToDeleteRows = false;
            this.gvArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvArticle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.articleContent});
            this.gvArticle.Dock = System.Windows.Forms.DockStyle.Left;
            this.gvArticle.Location = new System.Drawing.Point(3, 88);
            this.gvArticle.MultiSelect = false;
            this.gvArticle.Name = "gvArticle";
            this.gvArticle.ReadOnly = true;
            this.gvArticle.RowTemplate.Height = 23;
            this.gvArticle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvArticle.Size = new System.Drawing.Size(448, 415);
            this.gvArticle.TabIndex = 2;
            this.gvArticle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvArticle_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RecID";
            this.dataGridViewTextBoxColumn1.HeaderText = "RecID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RecTime";
            this.dataGridViewTextBoxColumn3.HeaderText = "收录时间";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn5.HeaderText = "标题";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // articleContent
            // 
            this.articleContent.DataPropertyName = "Content";
            this.articleContent.HeaderText = "内容";
            this.articleContent.Name = "articleContent";
            this.articleContent.ReadOnly = true;
            this.articleContent.Visible = false;
            // 
            // gbPages
            // 
            this.gbPages.Controls.Add(this.btnArticelNext);
            this.gbPages.Controls.Add(this.btnArticleBefore);
            this.gbPages.Controls.Add(this.label3);
            this.gbPages.Controls.Add(this.cmbPages);
            this.gbPages.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPages.Location = new System.Drawing.Point(3, 3);
            this.gbPages.Name = "gbPages";
            this.gbPages.Size = new System.Drawing.Size(813, 85);
            this.gbPages.TabIndex = 0;
            this.gbPages.TabStop = false;
            // 
            // btnArticelNext
            // 
            this.btnArticelNext.Location = new System.Drawing.Point(324, 33);
            this.btnArticelNext.Name = "btnArticelNext";
            this.btnArticelNext.Size = new System.Drawing.Size(75, 23);
            this.btnArticelNext.TabIndex = 11;
            this.btnArticelNext.Text = "下一页";
            this.btnArticelNext.UseVisualStyleBackColor = true;
            this.btnArticelNext.Click += new System.EventHandler(this.btnArticelNext_Click);
            // 
            // btnArticleBefore
            // 
            this.btnArticleBefore.Location = new System.Drawing.Point(229, 33);
            this.btnArticleBefore.Name = "btnArticleBefore";
            this.btnArticleBefore.Size = new System.Drawing.Size(75, 23);
            this.btnArticleBefore.TabIndex = 10;
            this.btnArticleBefore.Text = "上一页";
            this.btnArticleBefore.UseVisualStyleBackColor = true;
            this.btnArticleBefore.Click += new System.EventHandler(this.btnArticleBefore_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "当前页";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPages
            // 
            this.cmbPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPages.FormattingEnabled = true;
            this.cmbPages.Location = new System.Drawing.Point(91, 34);
            this.cmbPages.Name = "cmbPages";
            this.cmbPages.Size = new System.Drawing.Size(112, 20);
            this.cmbPages.TabIndex = 0;
            this.cmbPages.SelectedIndexChanged += new System.EventHandler(this.cmbPages_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbUID,
            this.tlbLeave,
            this.tlbPoint,
            this.tlbValidTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(827, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlbUID
            // 
            this.tlbUID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlbUID.Name = "tlbUID";
            this.tlbUID.Size = new System.Drawing.Size(49, 21);
            this.tlbUID.Text = "tlbUID";
            // 
            // tlbLeave
            // 
            this.tlbLeave.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlbLeave.Name = "tlbLeave";
            this.tlbLeave.Size = new System.Drawing.Size(60, 21);
            this.tlbLeave.Text = "tlbLeave";
            // 
            // tlbPoint
            // 
            this.tlbPoint.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlbPoint.Name = "tlbPoint";
            this.tlbPoint.Size = new System.Drawing.Size(56, 21);
            this.tlbPoint.Text = "tlbPoint";
            // 
            // tlbValidTime
            // 
            this.tlbValidTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tlbValidTime.Name = "tlbValidTime";
            this.tlbValidTime.Size = new System.Drawing.Size(647, 21);
            this.tlbValidTime.Spring = true;
            this.tlbValidTime.Text = "tlbValidTime";
            this.tlbValidTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(819, 506);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "帐户信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangePwd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(55, 32);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 23);
            this.btnChangePwd.TabIndex = 0;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 570);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微商数据管理系统";
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picwxImg)).EndInit();
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvArticle)).EndInit();
            this.gbPages.ResumeLayout(false);
            this.gbPages.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gvData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picwxImg;
        private System.Windows.Forms.RichTextBox mmData;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.GroupBox gbPages;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlbUID;
        private System.Windows.Forms.ToolStripStatusLabel tlbPoint;
        private System.Windows.Forms.ToolStripStatusLabel tlbLeave;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Button btndataSearch;
        private System.Windows.Forms.TextBox edtSearchStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn wxID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn wxImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtUserstr;
        private System.Windows.Forms.Button btnUserSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn uName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.DataGridView gvArticle;
        private System.Windows.Forms.ComboBox cmbPages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnArticelNext;
        private System.Windows.Forms.Button btnArticleBefore;
        private System.Windows.Forms.WebBrowser wbArticleContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn articleContent;
        private System.Windows.Forms.ToolStripStatusLabel tlbValidTime;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChangePwd;
    }
}

