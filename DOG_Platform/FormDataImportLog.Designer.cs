namespace DOGPlatform
{
    partial class FormDataImportLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataImportLog));
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.tbxUserFilePath = new System.Windows.Forms.TextBox();
            this.cbbLogFormat = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.logName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logNameNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logSUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImport = new System.Windows.Forms.Button();
            this.tbxView = new System.Windows.Forms.TextBox();
            this.btnShowLogHead = new System.Windows.Forms.Button();
            this.btnOpenFileDir = new System.Windows.Forms.Button();
            this.btnClearUnit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(642, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件格式";
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(12, 15);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDir.TabIndex = 1;
            this.btnOpenDir.Text = "选择文件";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenEX_Click);
            // 
            // tbxUserFilePath
            // 
            this.tbxUserFilePath.Location = new System.Drawing.Point(107, 17);
            this.tbxUserFilePath.Name = "tbxUserFilePath";
            this.tbxUserFilePath.Size = new System.Drawing.Size(529, 21);
            this.tbxUserFilePath.TabIndex = 2;
            // 
            // cbbLogFormat
            // 
            this.cbbLogFormat.FormattingEnabled = true;
            this.cbbLogFormat.Location = new System.Drawing.Point(701, 15);
            this.cbbLogFormat.Name = "cbbLogFormat";
            this.cbbLogFormat.Size = new System.Drawing.Size(121, 20);
            this.cbbLogFormat.TabIndex = 3;
            this.cbbLogFormat.SelectedIndexChanged += new System.EventHandler(this.cbbLogFormat_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(126, 556);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除系列";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.logName,
            this.logNum,
            this.logNameNew,
            this.logSUnit});
            this.dgvLog.Location = new System.Drawing.Point(12, 60);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.RowTemplate.Height = 23;
            this.dgvLog.Size = new System.Drawing.Size(447, 473);
            this.dgvLog.TabIndex = 6;
            // 
            // logName
            // 
            this.logName.HeaderText = "曲线名";
            this.logName.Name = "logName";
            this.logName.Width = 80;
            // 
            // logNum
            // 
            this.logNum.HeaderText = "所在列";
            this.logNum.Name = "logNum";
            this.logNum.Width = 80;
            // 
            // logNameNew
            // 
            this.logNameNew.HeaderText = "新名称";
            this.logNameNew.Name = "logNameNew";
            this.logNameNew.Width = 80;
            // 
            // logSUnit
            // 
            this.logSUnit.HeaderText = "单位";
            this.logSUnit.Name = "logSUnit";
            this.logSUnit.Width = 80;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(354, 556);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(91, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "导入系列";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tbxView
            // 
            this.tbxView.Location = new System.Drawing.Point(485, 60);
            this.tbxView.Multiline = true;
            this.tbxView.Name = "tbxView";
            this.tbxView.ReadOnly = true;
            this.tbxView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxView.Size = new System.Drawing.Size(556, 473);
            this.tbxView.TabIndex = 8;
            this.tbxView.Text = "预览";
            // 
            // btnShowLogHead
            // 
            this.btnShowLogHead.Location = new System.Drawing.Point(841, 14);
            this.btnShowLogHead.Name = "btnShowLogHead";
            this.btnShowLogHead.Size = new System.Drawing.Size(75, 23);
            this.btnShowLogHead.TabIndex = 9;
            this.btnShowLogHead.Text = "系列分析";
            this.btnShowLogHead.UseVisualStyleBackColor = true;
            this.btnShowLogHead.Click += new System.EventHandler(this.btnShowLogHead_Click);
            // 
            // btnOpenFileDir
            // 
            this.btnOpenFileDir.Location = new System.Drawing.Point(12, 556);
            this.btnOpenFileDir.Name = "btnOpenFileDir";
            this.btnOpenFileDir.Size = new System.Drawing.Size(91, 23);
            this.btnOpenFileDir.TabIndex = 10;
            this.btnOpenFileDir.Text = "打开文件目录";
            this.btnOpenFileDir.UseVisualStyleBackColor = true;
            this.btnOpenFileDir.Click += new System.EventHandler(this.btnOpenFileDir_Click);
            // 
            // btnClearUnit
            // 
            this.btnClearUnit.Location = new System.Drawing.Point(240, 556);
            this.btnClearUnit.Name = "btnClearUnit";
            this.btnClearUnit.Size = new System.Drawing.Size(91, 23);
            this.btnClearUnit.TabIndex = 11;
            this.btnClearUnit.Text = "删除单位";
            this.btnClearUnit.UseVisualStyleBackColor = true;
            this.btnClearUnit.Click += new System.EventHandler(this.btnClearUnit_Click);
            // 
            // FormDataImportLog
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 596);
            this.Controls.Add(this.btnClearUnit);
            this.Controls.Add(this.btnOpenFileDir);
            this.Controls.Add(this.btnShowLogHead);
            this.Controls.Add(this.tbxView);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbbLogFormat);
            this.Controls.Add(this.tbxUserFilePath);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDataImportLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测井曲线导入";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormDataImportLog_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormDataImportLog_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.TextBox tbxUserFilePath;
        private System.Windows.Forms.ComboBox cbbLogFormat;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox tbxView;
        private System.Windows.Forms.Button btnShowLogHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn logName;
        private System.Windows.Forms.DataGridViewTextBoxColumn logNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn logNameNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn logSUnit;
        private System.Windows.Forms.Button btnOpenFileDir;
        private System.Windows.Forms.Button btnClearUnit;
    }
}