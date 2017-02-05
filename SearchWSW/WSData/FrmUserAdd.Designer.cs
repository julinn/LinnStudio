namespace WSData
{
    partial class FrmUserAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserAdd));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.edtName = new System.Windows.Forms.TextBox();
            this.edtTel = new System.Windows.Forms.TextBox();
            this.edtPwd1 = new System.Windows.Forms.TextBox();
            this.edtPwd2 = new System.Windows.Forms.TextBox();
            this.edtuTel = new System.Windows.Forms.TextBox();
            this.edtuPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbt2 = new System.Windows.Forms.RadioButton();
            this.rbt1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(113, 327);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 37);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(233, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(154, 17);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(134, 21);
            this.edtName.TabIndex = 2;
            // 
            // edtTel
            // 
            this.edtTel.Location = new System.Drawing.Point(154, 55);
            this.edtTel.Name = "edtTel";
            this.edtTel.Size = new System.Drawing.Size(134, 21);
            this.edtTel.TabIndex = 3;
            // 
            // edtPwd1
            // 
            this.edtPwd1.Location = new System.Drawing.Point(154, 93);
            this.edtPwd1.Name = "edtPwd1";
            this.edtPwd1.Size = new System.Drawing.Size(134, 21);
            this.edtPwd1.TabIndex = 4;
            // 
            // edtPwd2
            // 
            this.edtPwd2.Location = new System.Drawing.Point(154, 131);
            this.edtPwd2.Name = "edtPwd2";
            this.edtPwd2.Size = new System.Drawing.Size(134, 21);
            this.edtPwd2.TabIndex = 5;
            // 
            // edtuTel
            // 
            this.edtuTel.Location = new System.Drawing.Point(154, 248);
            this.edtuTel.Name = "edtuTel";
            this.edtuTel.ReadOnly = true;
            this.edtuTel.Size = new System.Drawing.Size(134, 21);
            this.edtuTel.TabIndex = 6;
            // 
            // edtuPwd
            // 
            this.edtuPwd.Location = new System.Drawing.Point(154, 286);
            this.edtuPwd.Name = "edtuPwd";
            this.edtuPwd.PasswordChar = '*';
            this.edtuPwd.Size = new System.Drawing.Size(134, 21);
            this.edtuPwd.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "手机号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "密码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "确认密码";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "姓名";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "推荐人";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "管理密码";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbt2);
            this.groupBox1.Controls.Add(this.rbt1);
            this.groupBox1.Location = new System.Drawing.Point(113, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 64);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类型";
            // 
            // rbt2
            // 
            this.rbt2.AutoSize = true;
            this.rbt2.Location = new System.Drawing.Point(96, 30);
            this.rbt2.Name = "rbt2";
            this.rbt2.Size = new System.Drawing.Size(59, 16);
            this.rbt2.TabIndex = 1;
            this.rbt2.Text = "代理商";
            this.rbt2.UseVisualStyleBackColor = true;
            // 
            // rbt1
            // 
            this.rbt1.AutoSize = true;
            this.rbt1.Checked = true;
            this.rbt1.Location = new System.Drawing.Point(14, 30);
            this.rbt1.Name = "rbt1";
            this.rbt1.Size = new System.Drawing.Size(59, 16);
            this.rbt1.TabIndex = 0;
            this.rbt1.TabStop = true;
            this.rbt1.Text = "分销商";
            this.rbt1.UseVisualStyleBackColor = true;
            // 
            // FrmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtuPwd);
            this.Controls.Add(this.edtuTel);
            this.Controls.Add(this.edtPwd2);
            this.Controls.Add(this.edtPwd1);
            this.Controls.Add(this.edtTel);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建用户";
            this.Load += new System.EventHandler(this.FrmUserAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox edtName;
        private System.Windows.Forms.TextBox edtTel;
        private System.Windows.Forms.TextBox edtPwd1;
        private System.Windows.Forms.TextBox edtPwd2;
        private System.Windows.Forms.TextBox edtuTel;
        private System.Windows.Forms.TextBox edtuPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbt2;
        private System.Windows.Forms.RadioButton rbt1;
    }
}