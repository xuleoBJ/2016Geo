namespace DOGPlatform
{
    partial class FormSectionDataLog
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tbcLogDeal = new System.Windows.Forms.TabControl();
            this.tbgData = new System.Windows.Forms.TabPage();
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.tbgStatics = new System.Windows.Forms.TabPage();
            this.nUDnum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nTBXrightValue = new DOGPlatform.controls.NumericTextBox();
            this.nTBXleftValue = new DOGPlatform.controls.NumericTextBox();
            this.ctlStatisticInfor1 = new DOGPlatform.ctlStatisticInfor();
            this.ctlLogInforStatistic1 = new DOGPlatform.ctlLogInforStatistic();
            this.tbgOperation = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteInvalue = new System.Windows.Forms.Button();
            this.nTBXmaxInvalid = new DOGPlatform.controls.NumericTextBox();
            this.lblValeInvalidMax = new System.Windows.Forms.Label();
            this.nTBXminInvalid = new DOGPlatform.controls.NumericTextBox();
            this.lblValeInvalidMin = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nUDIntervalResample = new System.Windows.Forms.NumericUpDown();
            this.btnResample = new System.Windows.Forms.Button();
            this.lblValeSparce = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCilpCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAllAndCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteCurrentLine = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport2Txt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataImport = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteInvalid = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbcLogDeal.SuspendLayout();
            this.tbgData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.tbgStatics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tbgOperation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIntervalResample)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcLogDeal
            // 
            this.tbcLogDeal.Controls.Add(this.tbgData);
            this.tbcLogDeal.Controls.Add(this.tbgStatics);
            this.tbcLogDeal.Controls.Add(this.tbgOperation);
            this.tbcLogDeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcLogDeal.Location = new System.Drawing.Point(0, 25);
            this.tbcLogDeal.Name = "tbcLogDeal";
            this.tbcLogDeal.SelectedIndex = 0;
            this.tbcLogDeal.Size = new System.Drawing.Size(714, 547);
            this.tbcLogDeal.TabIndex = 3;
            this.tbcLogDeal.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbgData
            // 
            this.tbgData.Controls.Add(this.dgvDataTable);
            this.tbgData.Location = new System.Drawing.Point(4, 22);
            this.tbgData.Name = "tbgData";
            this.tbgData.Padding = new System.Windows.Forms.Padding(3);
            this.tbgData.Size = new System.Drawing.Size(706, 521);
            this.tbgData.TabIndex = 3;
            this.tbgData.Text = "数据";
            this.tbgData.UseVisualStyleBackColor = true;
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataTable.Location = new System.Drawing.Point(3, 3);
            this.dgvDataTable.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowTemplate.Height = 27;
            this.dgvDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTable.Size = new System.Drawing.Size(700, 515);
            this.dgvDataTable.TabIndex = 3;
            // 
            // tbgStatics
            // 
            this.tbgStatics.Controls.Add(this.nUDnum);
            this.tbgStatics.Controls.Add(this.label1);
            this.tbgStatics.Controls.Add(this.label33);
            this.tbgStatics.Controls.Add(this.label34);
            this.tbgStatics.Controls.Add(this.btnDraw);
            this.tbgStatics.Controls.Add(this.chart1);
            this.tbgStatics.Controls.Add(this.nTBXrightValue);
            this.tbgStatics.Controls.Add(this.nTBXleftValue);
            this.tbgStatics.Controls.Add(this.ctlStatisticInfor1);
            this.tbgStatics.Controls.Add(this.ctlLogInforStatistic1);
            this.tbgStatics.Location = new System.Drawing.Point(4, 22);
            this.tbgStatics.Name = "tbgStatics";
            this.tbgStatics.Padding = new System.Windows.Forms.Padding(3);
            this.tbgStatics.Size = new System.Drawing.Size(706, 521);
            this.tbgStatics.TabIndex = 1;
            this.tbgStatics.Text = "统计";
            this.tbgStatics.UseVisualStyleBackColor = true;
            // 
            // nUDnum
            // 
            this.nUDnum.Location = new System.Drawing.Point(492, 17);
            this.nUDnum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nUDnum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDnum.Name = "nUDnum";
            this.nUDnum.Size = new System.Drawing.Size(40, 21);
            this.nUDnum.TabIndex = 106;
            this.nUDnum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 105;
            this.label1.Text = "区间个数";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(324, 22);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 101;
            this.label33.Text = "右值";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(223, 22);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 102;
            this.label34.Text = "左值";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(569, 17);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 100;
            this.btnDraw.Text = "频率分析";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // chart1
            // 
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(170, 58);
            this.chart1.Name = "chart1";
            series2.BorderColor = System.Drawing.Color.Black;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Salmon;
            series2.Name = "Series1";
            series2.YValuesPerPoint = 2;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(498, 431);
            this.chart1.TabIndex = 99;
            this.chart1.Text = "chart1";
            // 
            // nTBXrightValue
            // 
            this.nTBXrightValue.Location = new System.Drawing.Point(362, 18);
            this.nTBXrightValue.Name = "nTBXrightValue";
            this.nTBXrightValue.Size = new System.Drawing.Size(59, 21);
            this.nTBXrightValue.TabIndex = 104;
            this.nTBXrightValue.Text = "100";
            // 
            // nTBXleftValue
            // 
            this.nTBXleftValue.Location = new System.Drawing.Point(261, 18);
            this.nTBXleftValue.Name = "nTBXleftValue";
            this.nTBXleftValue.Size = new System.Drawing.Size(54, 21);
            this.nTBXleftValue.TabIndex = 103;
            this.nTBXleftValue.Text = "0";
            // 
            // ctlStatisticInfor1
            // 
            this.ctlStatisticInfor1.Location = new System.Drawing.Point(8, 150);
            this.ctlStatisticInfor1.Name = "ctlStatisticInfor1";
            this.ctlStatisticInfor1.Size = new System.Drawing.Size(189, 339);
            this.ctlStatisticInfor1.TabIndex = 98;
            // 
            // ctlLogInforStatistic1
            // 
            this.ctlLogInforStatistic1.Location = new System.Drawing.Point(8, 17);
            this.ctlLogInforStatistic1.Name = "ctlLogInforStatistic1";
            this.ctlLogInforStatistic1.Size = new System.Drawing.Size(146, 127);
            this.ctlLogInforStatistic1.TabIndex = 97;
            // 
            // tbgOperation
            // 
            this.tbgOperation.Controls.Add(this.groupBox1);
            this.tbgOperation.Controls.Add(this.groupBox2);
            this.tbgOperation.Location = new System.Drawing.Point(4, 22);
            this.tbgOperation.Name = "tbgOperation";
            this.tbgOperation.Padding = new System.Windows.Forms.Padding(3);
            this.tbgOperation.Size = new System.Drawing.Size(706, 521);
            this.tbgOperation.TabIndex = 4;
            this.tbgOperation.Text = "操作";
            this.tbgOperation.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteInvalue);
            this.groupBox1.Controls.Add(this.nTBXmaxInvalid);
            this.groupBox1.Controls.Add(this.lblValeInvalidMax);
            this.groupBox1.Controls.Add(this.nTBXminInvalid);
            this.groupBox1.Controls.Add(this.lblValeInvalidMin);
            this.groupBox1.Location = new System.Drawing.Point(36, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 79);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "截断值";
            // 
            // btnDeleteInvalue
            // 
            this.btnDeleteInvalue.Location = new System.Drawing.Point(266, 27);
            this.btnDeleteInvalue.Name = "btnDeleteInvalue";
            this.btnDeleteInvalue.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteInvalue.TabIndex = 109;
            this.btnDeleteInvalue.Text = "计算";
            this.btnDeleteInvalue.UseVisualStyleBackColor = true;
            this.btnDeleteInvalue.Click += new System.EventHandler(this.btnDeleteInvalid_Click);
            // 
            // nTBXmaxInvalid
            // 
            this.nTBXmaxInvalid.Location = new System.Drawing.Point(170, 28);
            this.nTBXmaxInvalid.Name = "nTBXmaxInvalid";
            this.nTBXmaxInvalid.Size = new System.Drawing.Size(59, 21);
            this.nTBXmaxInvalid.TabIndex = 108;
            this.nTBXmaxInvalid.Text = "999";
            // 
            // lblValeInvalidMax
            // 
            this.lblValeInvalidMax.AutoSize = true;
            this.lblValeInvalidMax.Location = new System.Drawing.Point(135, 32);
            this.lblValeInvalidMax.Name = "lblValeInvalidMax";
            this.lblValeInvalidMax.Size = new System.Drawing.Size(29, 12);
            this.lblValeInvalidMax.TabIndex = 106;
            this.lblValeInvalidMax.Text = "值>=";
            // 
            // nTBXminInvalid
            // 
            this.nTBXminInvalid.Location = new System.Drawing.Point(51, 28);
            this.nTBXminInvalid.Name = "nTBXminInvalid";
            this.nTBXminInvalid.Size = new System.Drawing.Size(54, 21);
            this.nTBXminInvalid.TabIndex = 107;
            this.nTBXminInvalid.Text = "-999";
            // 
            // lblValeInvalidMin
            // 
            this.lblValeInvalidMin.AutoSize = true;
            this.lblValeInvalidMin.Location = new System.Drawing.Point(16, 32);
            this.lblValeInvalidMin.Name = "lblValeInvalidMin";
            this.lblValeInvalidMin.Size = new System.Drawing.Size(29, 12);
            this.lblValeInvalidMin.TabIndex = 106;
            this.lblValeInvalidMin.Text = "值<=";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nUDIntervalResample);
            this.groupBox2.Controls.Add(this.btnResample);
            this.groupBox2.Controls.Add(this.lblValeSparce);
            this.groupBox2.Location = new System.Drawing.Point(36, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 79);
            this.groupBox2.TabIndex = 112;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据抽稀";
            // 
            // nUDIntervalResample
            // 
            this.nUDIntervalResample.Location = new System.Drawing.Point(75, 27);
            this.nUDIntervalResample.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nUDIntervalResample.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDIntervalResample.Name = "nUDIntervalResample";
            this.nUDIntervalResample.Size = new System.Drawing.Size(48, 21);
            this.nUDIntervalResample.TabIndex = 110;
            this.nUDIntervalResample.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnResample
            // 
            this.btnResample.Location = new System.Drawing.Point(266, 27);
            this.btnResample.Name = "btnResample";
            this.btnResample.Size = new System.Drawing.Size(75, 23);
            this.btnResample.TabIndex = 109;
            this.btnResample.Text = "数据抽稀";
            this.btnResample.UseVisualStyleBackColor = true;
            this.btnResample.Click += new System.EventHandler(this.btnResample_Click);
            // 
            // lblValeSparce
            // 
            this.lblValeSparce.AutoSize = true;
            this.lblValeSparce.Location = new System.Drawing.Point(16, 29);
            this.lblValeSparce.Name = "lblValeSparce";
            this.lblValeSparce.Size = new System.Drawing.Size(53, 12);
            this.lblValeSparce.TabIndex = 106;
            this.lblValeSparce.Text = "抽稀间隔";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据ToolStripMenuItem,
            this.tsmiDataImport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(714, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCilpCopy,
            this.tsmiCopyData,
            this.tsmiSelectAllAndCopy,
            this.toolStripSeparator1,
            this.tsmiDeleteCurrentLine,
            this.ToolStripMenuItem3});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.数据ToolStripMenuItem.Text = "数据";
            // 
            // tsmiCilpCopy
            // 
            this.tsmiCilpCopy.Name = "tsmiCilpCopy";
            this.tsmiCilpCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmiCilpCopy.Size = new System.Drawing.Size(203, 22);
            this.tsmiCilpCopy.Text = "粘贴";
            this.tsmiCilpCopy.Click += new System.EventHandler(this.tsmiCilpCopy_Click);
            // 
            // tsmiCopyData
            // 
            this.tsmiCopyData.Name = "tsmiCopyData";
            this.tsmiCopyData.Size = new System.Drawing.Size(203, 22);
            this.tsmiCopyData.Text = "复制";
            this.tsmiCopyData.Click += new System.EventHandler(this.tsmiCopyData_Click);
            // 
            // tsmiSelectAllAndCopy
            // 
            this.tsmiSelectAllAndCopy.Name = "tsmiSelectAllAndCopy";
            this.tsmiSelectAllAndCopy.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.tsmiSelectAllAndCopy.Size = new System.Drawing.Size(203, 22);
            this.tsmiSelectAllAndCopy.Text = "全选复制";
            this.tsmiSelectAllAndCopy.Click += new System.EventHandler(this.tsmiSelectAllAndCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // tsmiDeleteCurrentLine
            // 
            this.tsmiDeleteCurrentLine.Name = "tsmiDeleteCurrentLine";
            this.tsmiDeleteCurrentLine.Size = new System.Drawing.Size(203, 22);
            this.tsmiDeleteCurrentLine.Text = "删除行";
            this.tsmiDeleteCurrentLine.Click += new System.EventHandler(this.tsmiDeleteCurrentLine_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExport2Txt,
            this.tsmiExportExcel});
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(203, 22);
            this.ToolStripMenuItem3.Text = "数据导出";
            // 
            // tsmiExport2Txt
            // 
            this.tsmiExport2Txt.Name = "tsmiExport2Txt";
            this.tsmiExport2Txt.Size = new System.Drawing.Size(152, 22);
            this.tsmiExport2Txt.Text = "txt";
            this.tsmiExport2Txt.Click += new System.EventHandler(this.tsmiExport2Txt_Click);
            // 
            // tsmiExportExcel
            // 
            this.tsmiExportExcel.Name = "tsmiExportExcel";
            this.tsmiExportExcel.Size = new System.Drawing.Size(152, 22);
            this.tsmiExportExcel.Text = "excel";
            this.tsmiExportExcel.Click += new System.EventHandler(this.tsmiExportExcel_Click);
            // 
            // tsmiDataImport
            // 
            this.tsmiDataImport.Name = "tsmiDataImport";
            this.tsmiDataImport.Size = new System.Drawing.Size(44, 21);
            this.tsmiDataImport.Text = "加载";
            this.tsmiDataImport.Click += new System.EventHandler(this.tsmiDataImport_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(714, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 106;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 106;
            // 
            // btnDeleteInvalid
            // 
            this.btnDeleteInvalid.Location = new System.Drawing.Point(266, 27);
            this.btnDeleteInvalid.Name = "btnDeleteInvalid";
            this.btnDeleteInvalid.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteInvalid.TabIndex = 109;
            this.btnDeleteInvalid.Text = "删除无效值";
            this.btnDeleteInvalid.UseVisualStyleBackColor = true;
            this.btnDeleteInvalid.Click += new System.EventHandler(this.btnDeleteInvalid_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 106;
            // 
            // FormSectionDataLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 594);
            this.Controls.Add(this.tbcLogDeal);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSectionDataLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "曲线数据";
            this.tbcLogDeal.ResumeLayout(false);
            this.tbgData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.tbgStatics.ResumeLayout(false);
            this.tbgStatics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tbgOperation.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIntervalResample)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcLogDeal;
        private System.Windows.Forms.TabPage tbgStatics;
        private System.Windows.Forms.TabPage tbgData;
        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCilpCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataImport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ctlLogInforStatistic ctlLogInforStatistic1;
        private ctlStatisticInfor ctlStatisticInfor1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnDraw;
        private controls.NumericTextBox nTBXrightValue;
        private controls.NumericTextBox nTBXleftValue;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDnum;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCurrentLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport2Txt;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyData;
        private System.Windows.Forms.TabPage tbgOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAllAndCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteInvalid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nUDIntervalResample;
        private System.Windows.Forms.Button btnResample;
        private System.Windows.Forms.Label lblValeSparce;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteInvalue;
        private controls.NumericTextBox nTBXmaxInvalid;
        private System.Windows.Forms.Label lblValeInvalidMax;
        private controls.NumericTextBox nTBXminInvalid;
        private System.Windows.Forms.Label lblValeInvalidMin;

    }
}