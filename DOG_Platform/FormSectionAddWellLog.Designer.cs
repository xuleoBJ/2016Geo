namespace DOGPlatform
{
    partial class FormSectionAddWellLog
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnNewLog = new System.Windows.Forms.Button();
            this.tbxNewLogName = new System.Windows.Forms.TextBox();
            this.tbxJH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbLog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnSelect);
            this.tabPage1.Controls.Add(this.btnNewLog);
            this.tabPage1.Controls.Add(this.tbxNewLogName);
            this.tabPage1.Controls.Add(this.tbxJH);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbbLog);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(319, 138);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "增加曲线";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 89;
            this.label1.Text = "新增";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(180, 58);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 88;
            this.btnSelect.Text = "确定";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNewLog
            // 
            this.btnNewLog.Location = new System.Drawing.Point(180, 88);
            this.btnNewLog.Name = "btnNewLog";
            this.btnNewLog.Size = new System.Drawing.Size(75, 23);
            this.btnNewLog.TabIndex = 87;
            this.btnNewLog.Text = "增加";
            this.btnNewLog.UseVisualStyleBackColor = true;
            this.btnNewLog.Click += new System.EventHandler(this.btnNewLog_Click);
            // 
            // tbxNewLogName
            // 
            this.tbxNewLogName.Location = new System.Drawing.Point(54, 90);
            this.tbxNewLogName.Name = "tbxNewLogName";
            this.tbxNewLogName.Size = new System.Drawing.Size(103, 21);
            this.tbxNewLogName.TabIndex = 86;
            this.tbxNewLogName.Text = "新曲线名";
            // 
            // tbxJH
            // 
            this.tbxJH.Location = new System.Drawing.Point(54, 24);
            this.tbxJH.Name = "tbxJH";
            this.tbxJH.Size = new System.Drawing.Size(103, 21);
            this.tbxJH.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "井名";
            // 
            // cbbLog
            // 
            this.cbbLog.BackColor = System.Drawing.SystemColors.Window;
            this.cbbLog.FormattingEnabled = true;
            this.cbbLog.Location = new System.Drawing.Point(54, 56);
            this.cbbLog.Name = "cbbLog";
            this.cbbLog.Size = new System.Drawing.Size(103, 20);
            this.cbbLog.TabIndex = 83;
            this.cbbLog.SelectedIndexChanged += new System.EventHandler(this.cbbLog_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 77;
            this.label3.Text = "选择";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(327, 164);
            this.tabControl1.TabIndex = 0;
            // 
            // FormSectionAddWellLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 164);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSectionAddWellLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加曲线";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbxJH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxNewLogName;
        private System.Windows.Forms.Button btnNewLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;

    }
}