namespace DOGPlatform
{
    partial class FormExportLog
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageWellLog = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbxFullLogSeriers = new System.Windows.Forms.ListBox();
            this.btnEmportLog = new System.Windows.Forms.Button();
            this.btn_downLog = new System.Windows.Forms.Button();
            this.btn_upLog = new System.Windows.Forms.Button();
            this.btn_deleteLog = new System.Windows.Forms.Button();
            this.btn_addLog = new System.Windows.Forms.Button();
            this.lbxLogSeriersSeclected = new System.Windows.Forms.ListBox();
            this.tbxLogSavePath = new System.Windows.Forms.TextBox();
            this.logDirChoose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbFormatTxt = new System.Windows.Forms.RadioButton();
            this.rdbFormatLas = new System.Windows.Forms.RadioButton();
            this.tabControlMain.SuspendLayout();
            this.tabPageWellLog.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageWellLog);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(695, 531);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageWellLog
            // 
            this.tabPageWellLog.Controls.Add(this.groupBox3);
            this.tabPageWellLog.Controls.Add(this.groupBox2);
            this.tabPageWellLog.Controls.Add(this.tbxLogSavePath);
            this.tabPageWellLog.Controls.Add(this.btnEmportLog);
            this.tabPageWellLog.Controls.Add(this.logDirChoose);
            this.tabPageWellLog.Location = new System.Drawing.Point(4, 25);
            this.tabPageWellLog.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageWellLog.Name = "tabPageWellLog";
            this.tabPageWellLog.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageWellLog.Size = new System.Drawing.Size(687, 502);
            this.tabPageWellLog.TabIndex = 12;
            this.tabPageWellLog.Text = "测井曲线";
            this.tabPageWellLog.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lbxFullLogSeriers);
            this.groupBox2.Controls.Add(this.btn_downLog);
            this.groupBox2.Controls.Add(this.btn_upLog);
            this.groupBox2.Controls.Add(this.btn_deleteLog);
            this.groupBox2.Controls.Add(this.btn_addLog);
            this.groupBox2.Controls.Add(this.lbxLogSeriersSeclected);
            this.groupBox2.Location = new System.Drawing.Point(21, 161);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(280, 308);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测井曲线选择";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 15);
            this.label26.TabIndex = 13;
            // 
            // lbxFullLogSeriers
            // 
            this.lbxFullLogSeriers.FormattingEnabled = true;
            this.lbxFullLogSeriers.ItemHeight = 15;
            this.lbxFullLogSeriers.Location = new System.Drawing.Point(17, 38);
            this.lbxFullLogSeriers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxFullLogSeriers.Name = "lbxFullLogSeriers";
            this.lbxFullLogSeriers.Size = new System.Drawing.Size(84, 244);
            this.lbxFullLogSeriers.TabIndex = 1;
            // 
            // btnEmportLog
            // 
            this.btnEmportLog.Location = new System.Drawing.Point(395, 392);
            this.btnEmportLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmportLog.Name = "btnEmportLog";
            this.btnEmportLog.Size = new System.Drawing.Size(128, 28);
            this.btnEmportLog.TabIndex = 7;
            this.btnEmportLog.Text = "测井文件导出";
            this.btnEmportLog.UseVisualStyleBackColor = true;
            // 
            // btn_downLog
            // 
            this.btn_downLog.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_downLog.Location = new System.Drawing.Point(114, 194);
            this.btn_downLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_downLog.Name = "btn_downLog";
            this.btn_downLog.Size = new System.Drawing.Size(37, 30);
            this.btn_downLog.TabIndex = 5;
            this.btn_downLog.Text = "↓";
            this.btn_downLog.UseVisualStyleBackColor = true;
            this.btn_downLog.Click += new System.EventHandler(this.btn_downLog_Click);
            // 
            // btn_upLog
            // 
            this.btn_upLog.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_upLog.Location = new System.Drawing.Point(114, 151);
            this.btn_upLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_upLog.Name = "btn_upLog";
            this.btn_upLog.Size = new System.Drawing.Size(37, 34);
            this.btn_upLog.TabIndex = 4;
            this.btn_upLog.Text = "↑";
            this.btn_upLog.UseVisualStyleBackColor = true;
            this.btn_upLog.Click += new System.EventHandler(this.btn_upLog_Click);
            // 
            // btn_deleteLog
            // 
            this.btn_deleteLog.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deleteLog.Location = new System.Drawing.Point(114, 100);
            this.btn_deleteLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_deleteLog.Name = "btn_deleteLog";
            this.btn_deleteLog.Size = new System.Drawing.Size(37, 32);
            this.btn_deleteLog.TabIndex = 3;
            this.btn_deleteLog.Text = "←";
            this.btn_deleteLog.UseVisualStyleBackColor = true;
            this.btn_deleteLog.Click += new System.EventHandler(this.btn_deleteLog_Click);
            // 
            // btn_addLog
            // 
            this.btn_addLog.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addLog.Location = new System.Drawing.Point(114, 57);
            this.btn_addLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_addLog.Name = "btn_addLog";
            this.btn_addLog.Size = new System.Drawing.Size(37, 30);
            this.btn_addLog.TabIndex = 2;
            this.btn_addLog.Text = "→";
            this.btn_addLog.UseVisualStyleBackColor = true;
            this.btn_addLog.Click += new System.EventHandler(this.btn_addLog_Click);
            // 
            // lbxLogSeriersSeclected
            // 
            this.lbxLogSeriersSeclected.FormattingEnabled = true;
            this.lbxLogSeriersSeclected.ItemHeight = 15;
            this.lbxLogSeriersSeclected.Location = new System.Drawing.Point(170, 38);
            this.lbxLogSeriersSeclected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxLogSeriersSeclected.Name = "lbxLogSeriersSeclected";
            this.lbxLogSeriersSeclected.Size = new System.Drawing.Size(75, 244);
            this.lbxLogSeriersSeclected.TabIndex = 6;
            // 
            // tbxLogSavePath
            // 
            this.tbxLogSavePath.Location = new System.Drawing.Point(165, 18);
            this.tbxLogSavePath.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLogSavePath.Name = "tbxLogSavePath";
            this.tbxLogSavePath.Size = new System.Drawing.Size(469, 25);
            this.tbxLogSavePath.TabIndex = 13;
            // 
            // logDirChoose
            // 
            this.logDirChoose.Location = new System.Drawing.Point(21, 18);
            this.logDirChoose.Margin = new System.Windows.Forms.Padding(4);
            this.logDirChoose.Name = "logDirChoose";
            this.logDirChoose.Size = new System.Drawing.Size(123, 25);
            this.logDirChoose.TabIndex = 12;
            this.logDirChoose.Text = "保存目录";
            this.logDirChoose.UseVisualStyleBackColor = true;
            this.logDirChoose.Click += new System.EventHandler(this.logDirChoose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbFormatTxt);
            this.groupBox3.Controls.Add(this.rdbFormatLas);
            this.groupBox3.Location = new System.Drawing.Point(20, 80);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(273, 61);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "保存数据格式";
            // 
            // rdbFormatTxt
            // 
            this.rdbFormatTxt.AutoSize = true;
            this.rdbFormatTxt.Location = new System.Drawing.Point(86, 30);
            this.rdbFormatTxt.Margin = new System.Windows.Forms.Padding(4);
            this.rdbFormatTxt.Name = "rdbFormatTxt";
            this.rdbFormatTxt.Size = new System.Drawing.Size(52, 19);
            this.rdbFormatTxt.TabIndex = 23;
            this.rdbFormatTxt.Text = "txt";
            this.rdbFormatTxt.UseVisualStyleBackColor = true;
            // 
            // rdbFormatLas
            // 
            this.rdbFormatLas.AutoSize = true;
            this.rdbFormatLas.Checked = true;
            this.rdbFormatLas.Location = new System.Drawing.Point(20, 30);
            this.rdbFormatLas.Margin = new System.Windows.Forms.Padding(4);
            this.rdbFormatLas.Name = "rdbFormatLas";
            this.rdbFormatLas.Size = new System.Drawing.Size(52, 19);
            this.rdbFormatLas.TabIndex = 18;
            this.rdbFormatLas.TabStop = true;
            this.rdbFormatLas.Text = "las";
            this.rdbFormatLas.UseVisualStyleBackColor = true;
            // 
            // FormExportLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 531);
            this.Controls.Add(this.tabControlMain);
            this.Name = "FormExportLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测井曲线导出";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageWellLog.ResumeLayout(false);
            this.tabPageWellLog.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageWellLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ListBox lbxFullLogSeriers;
        private System.Windows.Forms.Button btnEmportLog;
        private System.Windows.Forms.Button btn_downLog;
        private System.Windows.Forms.Button btn_upLog;
        private System.Windows.Forms.Button btn_deleteLog;
        private System.Windows.Forms.Button btn_addLog;
        private System.Windows.Forms.ListBox lbxLogSeriersSeclected;
        private System.Windows.Forms.TextBox tbxLogSavePath;
        private System.Windows.Forms.Button logDirChoose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbFormatTxt;
        private System.Windows.Forms.RadioButton rdbFormatLas;
    }
}