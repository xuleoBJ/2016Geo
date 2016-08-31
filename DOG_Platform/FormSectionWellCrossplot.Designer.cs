namespace DOGPlatform
{
    partial class FormSectionWellCrossplot
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbgStatics = new System.Windows.Forms.TabPage();
            this.rdbTypeValue = new System.Windows.Forms.RadioButton();
            this.rdbLogValue = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxGridMinY = new System.Windows.Forms.CheckBox();
            this.cbxGridMainY = new System.Windows.Forms.CheckBox();
            this.cbxGridMinX = new System.Windows.Forms.CheckBox();
            this.cbxGridMainX = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ntbxYInterval = new DOGPlatform.controls.NumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ntbxXInterval = new DOGPlatform.controls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ntbxYRight = new DOGPlatform.controls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ntbxYLeft = new DOGPlatform.controls.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ntbxXRight = new DOGPlatform.controls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ntbxXLeft = new DOGPlatform.controls.NumericTextBox();
            this.cbxYlog = new System.Windows.Forms.CheckBox();
            this.cbxXlog = new System.Windows.Forms.CheckBox();
            this.cbbYLog = new System.Windows.Forms.ComboBox();
            this.cbbXLog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nTBXbot = new DOGPlatform.controls.NumericTextBox();
            this.nTBXtop = new DOGPlatform.controls.NumericTextBox();
            this.tbgData = new System.Windows.Forms.TabPage();
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tbgStatics.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tbgData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbgStatics);
            this.tabControl1.Controls.Add(this.tbgData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 734);
            this.tabControl1.TabIndex = 4;
            // 
            // tbgStatics
            // 
            this.tbgStatics.Controls.Add(this.rdbTypeValue);
            this.tbgStatics.Controls.Add(this.rdbLogValue);
            this.tbgStatics.Controls.Add(this.groupBox2);
            this.tbgStatics.Controls.Add(this.groupBox1);
            this.tbgStatics.Controls.Add(this.cbxYlog);
            this.tbgStatics.Controls.Add(this.cbxXlog);
            this.tbgStatics.Controls.Add(this.cbbYLog);
            this.tbgStatics.Controls.Add(this.cbbXLog);
            this.tbgStatics.Controls.Add(this.label3);
            this.tbgStatics.Controls.Add(this.label2);
            this.tbgStatics.Controls.Add(this.label33);
            this.tbgStatics.Controls.Add(this.label34);
            this.tbgStatics.Controls.Add(this.btnDraw);
            this.tbgStatics.Controls.Add(this.chart1);
            this.tbgStatics.Controls.Add(this.nTBXbot);
            this.tbgStatics.Controls.Add(this.nTBXtop);
            this.tbgStatics.Location = new System.Drawing.Point(4, 22);
            this.tbgStatics.Name = "tbgStatics";
            this.tbgStatics.Padding = new System.Windows.Forms.Padding(3);
            this.tbgStatics.Size = new System.Drawing.Size(876, 708);
            this.tbgStatics.TabIndex = 1;
            this.tbgStatics.Text = "统计";
            this.tbgStatics.UseVisualStyleBackColor = true;
            // 
            // rdbTypeValue
            // 
            this.rdbTypeValue.AutoSize = true;
            this.rdbTypeValue.Location = new System.Drawing.Point(388, 50);
            this.rdbTypeValue.Name = "rdbTypeValue";
            this.rdbTypeValue.Size = new System.Drawing.Size(71, 16);
            this.rdbTypeValue.TabIndex = 117;
            this.rdbTypeValue.TabStop = true;
            this.rdbTypeValue.Text = "分类分析";
            this.rdbTypeValue.UseVisualStyleBackColor = true;
            // 
            // rdbLogValue
            // 
            this.rdbLogValue.AutoSize = true;
            this.rdbLogValue.Checked = true;
            this.rdbLogValue.Location = new System.Drawing.Point(388, 23);
            this.rdbLogValue.Name = "rdbLogValue";
            this.rdbLogValue.Size = new System.Drawing.Size(71, 16);
            this.rdbLogValue.TabIndex = 116;
            this.rdbLogValue.TabStop = true;
            this.rdbLogValue.Text = "曲线数值";
            this.rdbLogValue.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxGridMinY);
            this.groupBox2.Controls.Add(this.cbxGridMainY);
            this.groupBox2.Controls.Add(this.cbxGridMinX);
            this.groupBox2.Controls.Add(this.cbxGridMainX);
            this.groupBox2.Location = new System.Drawing.Point(668, 498);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 118);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网格显示";
            // 
            // cbxGridMinY
            // 
            this.cbxGridMinY.AutoSize = true;
            this.cbxGridMinY.Location = new System.Drawing.Point(104, 70);
            this.cbxGridMinY.Name = "cbxGridMinY";
            this.cbxGridMinY.Size = new System.Drawing.Size(66, 16);
            this.cbxGridMinY.TabIndex = 119;
            this.cbxGridMinY.Text = "Y次网格";
            this.cbxGridMinY.UseVisualStyleBackColor = true;
            // 
            // cbxGridMainY
            // 
            this.cbxGridMainY.AutoSize = true;
            this.cbxGridMainY.Location = new System.Drawing.Point(18, 70);
            this.cbxGridMainY.Name = "cbxGridMainY";
            this.cbxGridMainY.Size = new System.Drawing.Size(66, 16);
            this.cbxGridMainY.TabIndex = 118;
            this.cbxGridMainY.Text = "Y主网格";
            this.cbxGridMainY.UseVisualStyleBackColor = true;
            // 
            // cbxGridMinX
            // 
            this.cbxGridMinX.AutoSize = true;
            this.cbxGridMinX.Location = new System.Drawing.Point(104, 39);
            this.cbxGridMinX.Name = "cbxGridMinX";
            this.cbxGridMinX.Size = new System.Drawing.Size(66, 16);
            this.cbxGridMinX.TabIndex = 117;
            this.cbxGridMinX.Text = "X次网格";
            this.cbxGridMinX.UseVisualStyleBackColor = true;
            // 
            // cbxGridMainX
            // 
            this.cbxGridMainX.AutoSize = true;
            this.cbxGridMainX.Location = new System.Drawing.Point(18, 39);
            this.cbxGridMainX.Name = "cbxGridMainX";
            this.cbxGridMainX.Size = new System.Drawing.Size(66, 16);
            this.cbxGridMainX.TabIndex = 116;
            this.cbxGridMainX.Text = "X主网格";
            this.cbxGridMainX.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ntbxYInterval);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ntbxXInterval);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ntbxYRight);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ntbxYLeft);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ntbxXRight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ntbxXLeft);
            this.groupBox1.Location = new System.Drawing.Point(668, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 312);
            this.groupBox1.TabIndex = 114;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "坐标范围";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 125;
            this.label8.Text = "Y轴间隔";
            // 
            // ntbxYInterval
            // 
            this.ntbxYInterval.Location = new System.Drawing.Point(69, 261);
            this.ntbxYInterval.Name = "ntbxYInterval";
            this.ntbxYInterval.Size = new System.Drawing.Size(81, 21);
            this.ntbxYInterval.TabIndex = 126;
            this.ntbxYInterval.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 123;
            this.label7.Text = "X轴间隔";
            // 
            // ntbxXInterval
            // 
            this.ntbxXInterval.Location = new System.Drawing.Point(69, 119);
            this.ntbxXInterval.Name = "ntbxXInterval";
            this.ntbxXInterval.Size = new System.Drawing.Size(81, 21);
            this.ntbxXInterval.TabIndex = 124;
            this.ntbxXInterval.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 121;
            this.label6.Text = "Y轴上值";
            // 
            // ntbxYRight
            // 
            this.ntbxYRight.Location = new System.Drawing.Point(69, 222);
            this.ntbxYRight.Name = "ntbxYRight";
            this.ntbxYRight.Size = new System.Drawing.Size(81, 21);
            this.ntbxYRight.TabIndex = 122;
            this.ntbxYRight.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 119;
            this.label5.Text = "Y轴下值";
            // 
            // ntbxYLeft
            // 
            this.ntbxYLeft.Location = new System.Drawing.Point(69, 180);
            this.ntbxYLeft.Name = "ntbxYLeft";
            this.ntbxYLeft.Size = new System.Drawing.Size(81, 21);
            this.ntbxYLeft.TabIndex = 120;
            this.ntbxYLeft.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 117;
            this.label4.Text = "X轴右值";
            // 
            // ntbxXRight
            // 
            this.ntbxXRight.Location = new System.Drawing.Point(69, 76);
            this.ntbxXRight.Name = "ntbxXRight";
            this.ntbxXRight.Size = new System.Drawing.Size(81, 21);
            this.ntbxXRight.TabIndex = 118;
            this.ntbxXRight.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 115;
            this.label1.Text = "X轴左值";
            // 
            // ntbxXLeft
            // 
            this.ntbxXLeft.Location = new System.Drawing.Point(69, 35);
            this.ntbxXLeft.Name = "ntbxXLeft";
            this.ntbxXLeft.Size = new System.Drawing.Size(81, 21);
            this.ntbxXLeft.TabIndex = 116;
            this.ntbxXLeft.Text = "0";
            // 
            // cbxYlog
            // 
            this.cbxYlog.AutoSize = true;
            this.cbxYlog.Location = new System.Drawing.Point(317, 50);
            this.cbxYlog.Name = "cbxYlog";
            this.cbxYlog.Size = new System.Drawing.Size(48, 16);
            this.cbxYlog.TabIndex = 113;
            this.cbxYlog.Text = "对数";
            this.cbxYlog.UseVisualStyleBackColor = true;
            // 
            // cbxXlog
            // 
            this.cbxXlog.AutoSize = true;
            this.cbxXlog.Location = new System.Drawing.Point(317, 24);
            this.cbxXlog.Name = "cbxXlog";
            this.cbxXlog.Size = new System.Drawing.Size(48, 16);
            this.cbxXlog.TabIndex = 110;
            this.cbxXlog.Text = "对数";
            this.cbxXlog.UseVisualStyleBackColor = true;
            // 
            // cbbYLog
            // 
            this.cbbYLog.FormattingEnabled = true;
            this.cbbYLog.Location = new System.Drawing.Point(228, 48);
            this.cbbYLog.Name = "cbbYLog";
            this.cbbYLog.Size = new System.Drawing.Size(83, 20);
            this.cbbYLog.TabIndex = 109;
            this.cbbYLog.SelectedIndexChanged += new System.EventHandler(this.cbbYLog_SelectedIndexChanged);
            // 
            // cbbXLog
            // 
            this.cbbXLog.FormattingEnabled = true;
            this.cbbXLog.Location = new System.Drawing.Point(228, 22);
            this.cbbXLog.Name = "cbbXLog";
            this.cbbXLog.Size = new System.Drawing.Size(83, 20);
            this.cbbXLog.TabIndex = 108;
            this.cbbXLog.SelectedIndexChanged += new System.EventHandler(this.cbbXLog_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 107;
            this.label3.Text = "纵轴";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 105;
            this.label2.Text = "横轴";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(49, 53);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 101;
            this.label33.Text = "底深";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(50, 23);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 102;
            this.label34.Text = "顶深";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(553, 26);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(89, 29);
            this.btnDraw.TabIndex = 100;
            this.btnDraw.Text = "交汇分析";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(18, 95);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Salmon;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(644, 600);
            this.chart1.TabIndex = 99;
            this.chart1.Text = "chart1";
            // 
            // nTBXbot
            // 
            this.nTBXbot.Location = new System.Drawing.Point(87, 49);
            this.nTBXbot.Name = "nTBXbot";
            this.nTBXbot.Size = new System.Drawing.Size(93, 21);
            this.nTBXbot.TabIndex = 104;
            this.nTBXbot.Text = "100";
            // 
            // nTBXtop
            // 
            this.nTBXtop.Location = new System.Drawing.Point(88, 19);
            this.nTBXtop.Name = "nTBXtop";
            this.nTBXtop.Size = new System.Drawing.Size(92, 21);
            this.nTBXtop.TabIndex = 103;
            this.nTBXtop.Text = "0";
            // 
            // tbgData
            // 
            this.tbgData.Controls.Add(this.dgvDataTable);
            this.tbgData.Location = new System.Drawing.Point(4, 22);
            this.tbgData.Name = "tbgData";
            this.tbgData.Padding = new System.Windows.Forms.Padding(3);
            this.tbgData.Size = new System.Drawing.Size(876, 708);
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
            this.dgvDataTable.Size = new System.Drawing.Size(870, 702);
            this.dgvDataTable.TabIndex = 3;
            // 
            // FormSectionWellCrossplot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 734);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSectionWellCrossplot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "测井交汇图";
            this.tabControl1.ResumeLayout(false);
            this.tbgStatics.ResumeLayout(false);
            this.tbgStatics.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tbgData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgData;
        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.TabPage tbgStatics;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private controls.NumericTextBox nTBXbot;
        private controls.NumericTextBox nTBXtop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbYLog;
        private System.Windows.Forms.ComboBox cbbXLog;
        private System.Windows.Forms.CheckBox cbxXlog;
        private System.Windows.Forms.CheckBox cbxYlog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private controls.NumericTextBox ntbxYRight;
        private System.Windows.Forms.Label label5;
        private controls.NumericTextBox ntbxYLeft;
        private System.Windows.Forms.Label label4;
        private controls.NumericTextBox ntbxXRight;
        private System.Windows.Forms.Label label1;
        private controls.NumericTextBox ntbxXLeft;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxGridMinY;
        private System.Windows.Forms.CheckBox cbxGridMainY;
        private System.Windows.Forms.CheckBox cbxGridMinX;
        private System.Windows.Forms.CheckBox cbxGridMainX;
        private System.Windows.Forms.Label label8;
        private controls.NumericTextBox ntbxYInterval;
        private System.Windows.Forms.Label label7;
        private controls.NumericTextBox ntbxXInterval;
        private System.Windows.Forms.RadioButton rdbTypeValue;
        private System.Windows.Forms.RadioButton rdbLogValue;
    }
}