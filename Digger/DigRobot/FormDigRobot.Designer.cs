namespace DigRobot
{
    partial class FormDigRobot
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDigRobot));
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenPic = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSet3Points = new System.Windows.Forms.ToolStripMenuItem();
            this.ptbOriginalPic = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_infor = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip_function = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcDig = new System.Windows.Forms.TabControl();
            this.tbgPic = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelall = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelDgvLine = new System.Windows.Forms.Button();
            this.tbxProperty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiColorPic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDigitier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCaptureScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbOriginalPic)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip_function.SuspendLayout();
            this.tbcDig.SuspendLayout();
            this.tbgPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenPic,
            this.tsmiCaptureScreen,
            this.退出ToolStripMenuItem});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(44, 21);
            this.tsmiFile.Text = "文件";
            // 
            // tsmiOpenPic
            // 
            this.tsmiOpenPic.Name = "tsmiOpenPic";
            this.tsmiOpenPic.Size = new System.Drawing.Size(152, 22);
            this.tsmiOpenPic.Text = "打开";
            this.tsmiOpenPic.Click += new System.EventHandler(this.openPicToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助文档ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助文档ToolStripMenuItem
            // 
            this.帮助文档ToolStripMenuItem.Name = "帮助文档ToolStripMenuItem";
            this.帮助文档ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.帮助文档ToolStripMenuItem.Text = "帮助文档";
            this.帮助文档ToolStripMenuItem.Click += new System.EventHandler(this.帮助文档ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.操作ToolStripMenuItem,
            this.tsmiSet3Points,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1269, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSet3Points
            // 
            this.tsmiSet3Points.Enabled = false;
            this.tsmiSet3Points.Name = "tsmiSet3Points";
            this.tsmiSet3Points.Size = new System.Drawing.Size(44, 21);
            this.tsmiSet3Points.Text = "定位";
            this.tsmiSet3Points.Click += new System.EventHandler(this.OperationToolStripMenuItem_Click);
            // 
            // ptbOriginalPic
            // 
            this.ptbOriginalPic.BackColor = System.Drawing.SystemColors.Control;
            this.ptbOriginalPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbOriginalPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbOriginalPic.Location = new System.Drawing.Point(0, 0);
            this.ptbOriginalPic.Name = "ptbOriginalPic";
            this.ptbOriginalPic.Size = new System.Drawing.Size(947, 676);
            this.ptbOriginalPic.TabIndex = 1;
            this.ptbOriginalPic.TabStop = false;
            this.ptbOriginalPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_OriginalPic_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_infor});
            this.statusStrip1.Location = new System.Drawing.Point(0, 733);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1269, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_infor
            // 
            this.toolStripStatusLabel_infor.AutoSize = false;
            this.toolStripStatusLabel_infor.Name = "toolStripStatusLabel_infor";
            this.toolStripStatusLabel_infor.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel_infor.Text = "ready";
            this.toolStripStatusLabel_infor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip_function
            // 
            this.contextMenuStrip_function.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip_function.Name = "contextMenuStrip_function";
            this.contextMenuStrip_function.Size = new System.Drawing.Size(113, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem1.Text = "井位";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItem2.Text = "等值线";
            // 
            // tbcDig
            // 
            this.tbcDig.Controls.Add(this.tbgPic);
            this.tbcDig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcDig.Location = new System.Drawing.Point(0, 25);
            this.tbcDig.Name = "tbcDig";
            this.tbcDig.SelectedIndex = 0;
            this.tbcDig.Size = new System.Drawing.Size(1269, 708);
            this.tbcDig.TabIndex = 3;
            // 
            // tbgPic
            // 
            this.tbgPic.Controls.Add(this.splitContainer1);
            this.tbgPic.Location = new System.Drawing.Point(4, 22);
            this.tbgPic.Name = "tbgPic";
            this.tbgPic.Padding = new System.Windows.Forms.Padding(3);
            this.tbgPic.Size = new System.Drawing.Size(1261, 682);
            this.tbgPic.TabIndex = 0;
            this.tbgPic.Text = "图形";
            this.tbgPic.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ptbOriginalPic);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlColor);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelall);
            this.splitContainer1.Panel2.Controls.Add(this.btnExport);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelDgvLine);
            this.splitContainer1.Panel2.Controls.Add(this.tbxProperty);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.dgv);
            this.splitContainer1.Size = new System.Drawing.Size(1255, 676);
            this.splitContainer1.SplitterDistance = 947;
            this.splitContainer1.TabIndex = 4;
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.Blue;
            this.pnlColor.Location = new System.Drawing.Point(247, 18);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(28, 18);
            this.pnlColor.TabIndex = 28;
            this.pnlColor.Click += new System.EventHandler(this.pnlColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "采点颜色";
            // 
            // btnDelall
            // 
            this.btnDelall.Location = new System.Drawing.Point(198, 53);
            this.btnDelall.Name = "btnDelall";
            this.btnDelall.Size = new System.Drawing.Size(90, 23);
            this.btnDelall.TabIndex = 25;
            this.btnDelall.Text = "清空数据";
            this.btnDelall.UseVisualStyleBackColor = true;
            this.btnDelall.Click += new System.EventHandler(this.btnDelall_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(102, 53);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 23);
            this.btnExport.TabIndex = 24;
            this.btnExport.Text = "导出文件";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelDgvLine
            // 
            this.btnDelDgvLine.Location = new System.Drawing.Point(5, 53);
            this.btnDelDgvLine.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelDgvLine.Name = "btnDelDgvLine";
            this.btnDelDgvLine.Size = new System.Drawing.Size(92, 23);
            this.btnDelDgvLine.TabIndex = 23;
            this.btnDelDgvLine.Text = "删除选中行";
            this.btnDelDgvLine.UseVisualStyleBackColor = true;
            this.btnDelDgvLine.Click += new System.EventHandler(this.btnDelDgvLine_Click);
            // 
            // tbxProperty
            // 
            this.tbxProperty.Location = new System.Drawing.Point(61, 18);
            this.tbxProperty.Margin = new System.Windows.Forms.Padding(2);
            this.tbxProperty.Name = "tbxProperty";
            this.tbxProperty.Size = new System.Drawing.Size(122, 21);
            this.tbxProperty.TabIndex = 14;
            this.tbxProperty.Text = "Point1";
            this.tbxProperty.TextChanged += new System.EventHandler(this.tbxProperty_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "点属性";
            // 
            // dgv
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(5, 82);
            this.dgv.Name = "dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(290, 597);
            this.dgv.TabIndex = 3;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "属性名";
            this.Column1.Name = "Column1";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiColorPic,
            this.tsmiDigitier});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // tsmiColorPic
            // 
            this.tsmiColorPic.Name = "tsmiColorPic";
            this.tsmiColorPic.Size = new System.Drawing.Size(152, 22);
            this.tsmiColorPic.Text = "颜色采集";
            this.tsmiColorPic.Click += new System.EventHandler(this.tsmiColorPic_Click);
            // 
            // tsmiDigitier
            // 
            this.tsmiDigitier.Name = "tsmiDigitier";
            this.tsmiDigitier.Size = new System.Drawing.Size(152, 22);
            this.tsmiDigitier.Text = "数字化";
            this.tsmiDigitier.Click += new System.EventHandler(this.tsmiDigitier_Click);
            // 
            // tsmiCaptureScreen
            // 
            this.tsmiCaptureScreen.Name = "tsmiCaptureScreen";
            this.tsmiCaptureScreen.Size = new System.Drawing.Size(152, 22);
            this.tsmiCaptureScreen.Text = "抓屏";
            this.tsmiCaptureScreen.Click += new System.EventHandler(this.tsmiCaptureScreen_Click);
            // 
            // FormDigRobot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 755);
            this.Controls.Add(this.tbcDig);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormDigRobot";
            this.Text = "DigRobot图形工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDigRobot_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDigRobot_FormClosed);
            this.Load += new System.EventHandler(this.FormDigRobot_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbOriginalPic)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip_function.ResumeLayout(false);
            this.tbcDig.ResumeLayout(false);
            this.tbgPic.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox ptbOriginalPic;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_infor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_function;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSet3Points;
        private System.Windows.Forms.ToolStripMenuItem 帮助文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenPic;
        private System.Windows.Forms.TabControl tbcDig;
        private System.Windows.Forms.TabPage tbgPic;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbxProperty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDelDgvLine;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDelall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiColorPic;
        private System.Windows.Forms.ToolStripMenuItem tsmiDigitier;
        private System.Windows.Forms.ToolStripMenuItem tsmiCaptureScreen;

    }
}

