namespace DOGPlatform
{
    partial class FormSettingSectionLog
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
            this.btnSeleclFillColor = new System.Windows.Forms.Button();
            this.tbxFillColor = new System.Windows.Forms.TextBox();
            this.btnLeftRightCov = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.tbxLogColor = new System.Windows.Forms.TextBox();
            this.tbxLogname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nTBXrightValue = new DOGPlatform.controls.NumericTextBox();
            this.nTBXleftValue = new DOGPlatform.controls.NumericTextBox();
            this.nUDLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label42 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbgSet = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.nUDDrawInterval = new System.Windows.Forms.NumericUpDown();
            this.cbbTypeMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxLog = new System.Windows.Forms.CheckBox();
            this.cbxGrid = new System.Windows.Forms.CheckBox();
            this.cbbLineType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxLogSunit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbgSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDrawInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeleclFillColor
            // 
            this.btnSeleclFillColor.Location = new System.Drawing.Point(129, 132);
            this.btnSeleclFillColor.Name = "btnSeleclFillColor";
            this.btnSeleclFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnSeleclFillColor.TabIndex = 100;
            this.btnSeleclFillColor.Text = "填充颜色";
            this.btnSeleclFillColor.UseVisualStyleBackColor = true;
            this.btnSeleclFillColor.Click += new System.EventHandler(this.btnSeleclFillColor_Click);
            // 
            // tbxFillColor
            // 
            this.tbxFillColor.Location = new System.Drawing.Point(214, 133);
            this.tbxFillColor.MaxLength = 7;
            this.tbxFillColor.Name = "tbxFillColor";
            this.tbxFillColor.Size = new System.Drawing.Size(61, 21);
            this.tbxFillColor.TabIndex = 99;
            // 
            // btnLeftRightCov
            // 
            this.btnLeftRightCov.Location = new System.Drawing.Point(227, 45);
            this.btnLeftRightCov.Name = "btnLeftRightCov";
            this.btnLeftRightCov.Size = new System.Drawing.Size(60, 23);
            this.btnLeftRightCov.TabIndex = 92;
            this.btnLeftRightCov.Text = "左<->右";
            this.btnLeftRightCov.UseVisualStyleBackColor = true;
            this.btnLeftRightCov.Click += new System.EventHandler(this.btnLeftRightCov_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(129, 86);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(73, 23);
            this.btnColor.TabIndex = 91;
            this.btnColor.Text = "曲线颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // tbxLogColor
            // 
            this.tbxLogColor.Location = new System.Drawing.Point(214, 87);
            this.tbxLogColor.MaxLength = 7;
            this.tbxLogColor.Name = "tbxLogColor";
            this.tbxLogColor.Size = new System.Drawing.Size(61, 21);
            this.tbxLogColor.TabIndex = 90;
            this.tbxLogColor.Text = "#000000";
            // 
            // tbxLogname
            // 
            this.tbxLogname.Location = new System.Drawing.Point(55, 15);
            this.tbxLogname.Name = "tbxLogname";
            this.tbxLogname.Size = new System.Drawing.Size(83, 21);
            this.tbxLogname.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "曲线";
            // 
            // nTBXrightValue
            // 
            this.nTBXrightValue.Location = new System.Drawing.Point(150, 47);
            this.nTBXrightValue.Name = "nTBXrightValue";
            this.nTBXrightValue.Size = new System.Drawing.Size(59, 21);
            this.nTBXrightValue.TabIndex = 76;
            // 
            // nTBXleftValue
            // 
            this.nTBXleftValue.Location = new System.Drawing.Point(55, 47);
            this.nTBXleftValue.Name = "nTBXleftValue";
            this.nTBXleftValue.Size = new System.Drawing.Size(54, 21);
            this.nTBXleftValue.TabIndex = 75;
            // 
            // nUDLineWidth
            // 
            this.nUDLineWidth.AllowDrop = true;
            this.nUDLineWidth.DecimalPlaces = 1;
            this.nUDLineWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDLineWidth.Location = new System.Drawing.Point(343, 87);
            this.nUDLineWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDLineWidth.Name = "nUDLineWidth";
            this.nUDLineWidth.Size = new System.Drawing.Size(43, 21);
            this.nUDLineWidth.TabIndex = 34;
            this.nUDLineWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nUDLineWidth.ValueChanged += new System.EventHandler(this.nUDLineWidth_ValueChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(281, 91);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 12);
            this.label42.TabIndex = 33;
            this.label42.Text = "曲线宽度";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(115, 51);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 27;
            this.label33.Text = "右值";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(20, 51);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 27;
            this.label34.Text = "左值";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(225, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(69, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbgSet);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 257);
            this.tabControl1.TabIndex = 67;
            // 
            // tbgSet
            // 
            this.tbgSet.Controls.Add(this.label5);
            this.tbgSet.Controls.Add(this.nUDDrawInterval);
            this.tbgSet.Controls.Add(this.cbbTypeMode);
            this.tbgSet.Controls.Add(this.btnCancel);
            this.tbgSet.Controls.Add(this.label4);
            this.tbgSet.Controls.Add(this.btnSeleclFillColor);
            this.tbgSet.Controls.Add(this.btnOK);
            this.tbgSet.Controls.Add(this.tbxFillColor);
            this.tbgSet.Controls.Add(this.btnColor);
            this.tbgSet.Controls.Add(this.btnLeftRightCov);
            this.tbgSet.Controls.Add(this.label34);
            this.tbgSet.Controls.Add(this.label33);
            this.tbgSet.Controls.Add(this.tbxLogColor);
            this.tbgSet.Controls.Add(this.label42);
            this.tbgSet.Controls.Add(this.tbxLogname);
            this.tbgSet.Controls.Add(this.nUDLineWidth);
            this.tbgSet.Controls.Add(this.label3);
            this.tbgSet.Controls.Add(this.label1);
            this.tbgSet.Controls.Add(this.tbxLogSunit);
            this.tbgSet.Controls.Add(this.cbbLineType);
            this.tbgSet.Controls.Add(this.cbxGrid);
            this.tbgSet.Controls.Add(this.cbxLog);
            this.tbgSet.Controls.Add(this.label2);
            this.tbgSet.Controls.Add(this.nTBXleftValue);
            this.tbgSet.Controls.Add(this.nTBXrightValue);
            this.tbgSet.Location = new System.Drawing.Point(4, 22);
            this.tbgSet.Name = "tbgSet";
            this.tbgSet.Padding = new System.Windows.Forms.Padding(3);
            this.tbgSet.Size = new System.Drawing.Size(404, 231);
            this.tbgSet.TabIndex = 0;
            this.tbgSet.Text = "设置";
            this.tbgSet.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 103;
            this.label5.Text = "绘制间隔";
            // 
            // nUDDrawInterval
            // 
            this.nUDDrawInterval.AllowDrop = true;
            this.nUDDrawInterval.Location = new System.Drawing.Point(343, 133);
            this.nUDDrawInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDDrawInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDDrawInterval.Name = "nUDDrawInterval";
            this.nUDDrawInterval.Size = new System.Drawing.Size(43, 21);
            this.nUDDrawInterval.TabIndex = 104;
            this.nUDDrawInterval.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDDrawInterval.ValueChanged += new System.EventHandler(this.nUDDrawInterval_ValueChanged);
            // 
            // cbbTypeMode
            // 
            this.cbbTypeMode.BackColor = System.Drawing.Color.White;
            this.cbbTypeMode.FormattingEnabled = true;
            this.cbbTypeMode.Items.AddRange(new object[] {
            "曲线",
            "散点",
            "杆状"});
            this.cbbTypeMode.Location = new System.Drawing.Point(227, 15);
            this.cbbTypeMode.Name = "cbbTypeMode";
            this.cbbTypeMode.Size = new System.Drawing.Size(61, 20);
            this.cbbTypeMode.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 101;
            this.label4.Text = "显示模式";
            // 
            // cbxLog
            // 
            this.cbxLog.AutoSize = true;
            this.cbxLog.Location = new System.Drawing.Point(310, 51);
            this.cbxLog.Name = "cbxLog";
            this.cbxLog.Size = new System.Drawing.Size(48, 16);
            this.cbxLog.TabIndex = 74;
            this.cbxLog.Text = "对数";
            this.cbxLog.UseVisualStyleBackColor = true;
            this.cbxLog.CheckedChanged += new System.EventHandler(this.cbxLog_CheckedChanged);
            // 
            // cbxGrid
            // 
            this.cbxGrid.AutoSize = true;
            this.cbxGrid.Checked = true;
            this.cbxGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxGrid.Location = new System.Drawing.Point(310, 17);
            this.cbxGrid.Name = "cbxGrid";
            this.cbxGrid.Size = new System.Drawing.Size(48, 16);
            this.cbxGrid.TabIndex = 73;
            this.cbxGrid.Text = "网格";
            this.cbxGrid.UseVisualStyleBackColor = true;
            this.cbxGrid.CheckedChanged += new System.EventHandler(this.cbxGrid_CheckedChanged);
            // 
            // cbbLineType
            // 
            this.cbbLineType.BackColor = System.Drawing.Color.White;
            this.cbbLineType.FormattingEnabled = true;
            this.cbbLineType.Items.AddRange(new object[] {
            "实线",
            "----",
            " - - ",
            "-.-."});
            this.cbbLineType.Location = new System.Drawing.Point(52, 87);
            this.cbbLineType.Name = "cbbLineType";
            this.cbbLineType.Size = new System.Drawing.Size(61, 20);
            this.cbbLineType.TabIndex = 72;
            this.cbbLineType.Text = "实线";
            this.cbbLineType.SelectedIndexChanged += new System.EventHandler(this.cbbLineType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "线型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "单位";
            // 
            // tbxLogSunit
            // 
            this.tbxLogSunit.Location = new System.Drawing.Point(54, 133);
            this.tbxLogSunit.Name = "tbxLogSunit";
            this.tbxLogSunit.Size = new System.Drawing.Size(61, 21);
            this.tbxLogSunit.TabIndex = 78;
            // 
            // FormSettingSectionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 257);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingSectionLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "曲线设置";
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbgSet.ResumeLayout(false);
            this.tbgSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDrawInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDLineWidth;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private controls.NumericTextBox nTBXleftValue;
        private controls.NumericTextBox nTBXrightValue;
        private System.Windows.Forms.TextBox tbxLogname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox tbxLogColor;
        private System.Windows.Forms.Button btnLeftRightCov;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgSet;
        private System.Windows.Forms.Button btnSeleclFillColor;
        private System.Windows.Forms.TextBox tbxFillColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDDrawInterval;
        private System.Windows.Forms.ComboBox cbbTypeMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLogSunit;
        private System.Windows.Forms.ComboBox cbbLineType;
        private System.Windows.Forms.CheckBox cbxGrid;
        private System.Windows.Forms.CheckBox cbxLog;
        private System.Windows.Forms.Label label2;
    }
}