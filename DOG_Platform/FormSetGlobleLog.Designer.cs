namespace DOGPlatform
{
    partial class FormSetGlobleLog
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbgSet = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tbxLogColor = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tbxLogname = new System.Windows.Forms.TextBox();
            this.nUDLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxLogSunit = new System.Windows.Forms.TextBox();
            this.cbbLineType = new System.Windows.Forms.ComboBox();
            this.cbxLog = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nTBXleftValue = new DOGPlatform.controls.NumericTextBox();
            this.nTBXrightValue = new DOGPlatform.controls.NumericTextBox();
            this.tabControl1.SuspendLayout();
            this.tbgSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbgSet);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(321, 243);
            this.tabControl1.TabIndex = 68;
            // 
            // tbgSet
            // 
            this.tbgSet.Controls.Add(this.btnCancel);
            this.tbgSet.Controls.Add(this.btnOK);
            this.tbgSet.Controls.Add(this.btnColor);
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
            this.tbgSet.Controls.Add(this.cbxLog);
            this.tbgSet.Controls.Add(this.label2);
            this.tbgSet.Controls.Add(this.nTBXleftValue);
            this.tbgSet.Controls.Add(this.nTBXrightValue);
            this.tbgSet.Location = new System.Drawing.Point(4, 22);
            this.tbgSet.Name = "tbgSet";
            this.tbgSet.Padding = new System.Windows.Forms.Padding(3);
            this.tbgSet.Size = new System.Drawing.Size(313, 217);
            this.tbgSet.TabIndex = 0;
            this.tbgSet.Text = "设置";
            this.tbgSet.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(53, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(22, 87);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(73, 23);
            this.btnColor.TabIndex = 91;
            this.btnColor.Text = "曲线颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(21, 53);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 27;
            this.label34.Text = "左值";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(148, 53);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 27;
            this.label33.Text = "右值";
            // 
            // tbxLogColor
            // 
            this.tbxLogColor.Location = new System.Drawing.Point(101, 89);
            this.tbxLogColor.MaxLength = 7;
            this.tbxLogColor.Name = "tbxLogColor";
            this.tbxLogColor.Size = new System.Drawing.Size(83, 21);
            this.tbxLogColor.TabIndex = 90;
            this.tbxLogColor.Text = "#000000";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(21, 130);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 12);
            this.label42.TabIndex = 33;
            this.label42.Text = "曲线宽度";
            // 
            // tbxLogname
            // 
            this.tbxLogname.Location = new System.Drawing.Point(53, 14);
            this.tbxLogname.Name = "tbxLogname";
            this.tbxLogname.Size = new System.Drawing.Size(89, 21);
            this.tbxLogname.TabIndex = 80;
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
            this.nUDLineWidth.Location = new System.Drawing.Point(89, 126);
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
            this.nUDLineWidth.Size = new System.Drawing.Size(53, 21);
            this.nUDLineWidth.TabIndex = 34;
            this.nUDLineWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "曲线";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "线型";
            // 
            // tbxLogSunit
            // 
            this.tbxLogSunit.Location = new System.Drawing.Point(183, 14);
            this.tbxLogSunit.Name = "tbxLogSunit";
            this.tbxLogSunit.Size = new System.Drawing.Size(89, 21);
            this.tbxLogSunit.TabIndex = 78;
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
            this.cbbLineType.Location = new System.Drawing.Point(190, 124);
            this.cbbLineType.Name = "cbbLineType";
            this.cbbLineType.Size = new System.Drawing.Size(61, 20);
            this.cbbLineType.TabIndex = 72;
            this.cbbLineType.Text = "实线";
            // 
            // cbxLog
            // 
            this.cbxLog.AutoSize = true;
            this.cbxLog.Location = new System.Drawing.Point(203, 91);
            this.cbxLog.Name = "cbxLog";
            this.cbxLog.Size = new System.Drawing.Size(48, 16);
            this.cbxLog.TabIndex = 74;
            this.cbxLog.Text = "对数";
            this.cbxLog.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "单位";
            // 
            // nTBXleftValue
            // 
            this.nTBXleftValue.Location = new System.Drawing.Point(53, 49);
            this.nTBXleftValue.Name = "nTBXleftValue";
            this.nTBXleftValue.Size = new System.Drawing.Size(89, 21);
            this.nTBXleftValue.TabIndex = 75;
            // 
            // nTBXrightValue
            // 
            this.nTBXrightValue.Location = new System.Drawing.Point(183, 49);
            this.nTBXrightValue.Name = "nTBXrightValue";
            this.nTBXrightValue.Size = new System.Drawing.Size(89, 21);
            this.nTBXrightValue.TabIndex = 76;
            // 
            // FormSetGlobleLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 243);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetGlobleLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "全局测井曲线配置";
            this.tabControl1.ResumeLayout(false);
            this.tbgSet.ResumeLayout(false);
            this.tbgSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgSet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbxLogColor;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox tbxLogname;
        private System.Windows.Forms.NumericUpDown nUDLineWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLogSunit;
        private System.Windows.Forms.ComboBox cbbLineType;
        private System.Windows.Forms.CheckBox cbxLog;
        private System.Windows.Forms.Label label2;
        private controls.NumericTextBox nTBXleftValue;
        private controls.NumericTextBox nTBXrightValue;
    }
}