namespace DOGPlatform
{
    partial class FormLayerLog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbbLog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSeleclFillColor = new System.Windows.Forms.Button();
            this.tbxFillColor = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnLeftRightCov = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tbxLogColor = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.nUDLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDfVScale = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDTrackWidth = new System.Windows.Forms.NumericUpDown();
            this.nTBXleftValue = new DOGPlatform.controls.NumericTextBox();
            this.nTBXrightValue = new DOGPlatform.controls.NumericTextBox();
            this.cbxDrawLeft = new System.Windows.Forms.CheckBox();
            this.cbxPolygon = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDfVScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(248, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 70;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(122, 244);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 69;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbbLog
            // 
            this.cbbLog.BackColor = System.Drawing.SystemColors.Window;
            this.cbbLog.FormattingEnabled = true;
            this.cbbLog.Location = new System.Drawing.Point(76, 24);
            this.cbbLog.Name = "cbbLog";
            this.cbbLog.Size = new System.Drawing.Size(103, 20);
            this.cbbLog.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 84;
            this.label3.Text = "曲线";
            // 
            // btnSeleclFillColor
            // 
            this.btnSeleclFillColor.Location = new System.Drawing.Point(45, 112);
            this.btnSeleclFillColor.Name = "btnSeleclFillColor";
            this.btnSeleclFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnSeleclFillColor.TabIndex = 120;
            this.btnSeleclFillColor.Text = "填充颜色";
            this.btnSeleclFillColor.UseVisualStyleBackColor = true;
            this.btnSeleclFillColor.Click += new System.EventHandler(this.btnSeleclFillColor_Click);
            // 
            // tbxFillColor
            // 
            this.tbxFillColor.Location = new System.Drawing.Point(126, 113);
            this.tbxFillColor.MaxLength = 7;
            this.tbxFillColor.Name = "tbxFillColor";
            this.tbxFillColor.Size = new System.Drawing.Size(71, 21);
            this.tbxFillColor.TabIndex = 119;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(45, 156);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(73, 23);
            this.btnColor.TabIndex = 117;
            this.btnColor.Text = "曲线颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnLeftRightCov
            // 
            this.btnLeftRightCov.Location = new System.Drawing.Point(341, 66);
            this.btnLeftRightCov.Name = "btnLeftRightCov";
            this.btnLeftRightCov.Size = new System.Drawing.Size(90, 27);
            this.btnLeftRightCov.TabIndex = 118;
            this.btnLeftRightCov.Text = "左<->右";
            this.btnLeftRightCov.UseVisualStyleBackColor = true;
            this.btnLeftRightCov.Click += new System.EventHandler(this.btnLeftRightCov_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(43, 70);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 105;
            this.label34.Text = "左值";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(197, 70);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 106;
            this.label33.Text = "右值";
            // 
            // tbxLogColor
            // 
            this.tbxLogColor.Location = new System.Drawing.Point(124, 157);
            this.tbxLogColor.MaxLength = 7;
            this.tbxLogColor.Name = "tbxLogColor";
            this.tbxLogColor.Size = new System.Drawing.Size(73, 21);
            this.tbxLogColor.TabIndex = 116;
            this.tbxLogColor.Text = "#000000";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(203, 161);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 12);
            this.label42.TabIndex = 107;
            this.label42.Text = "曲线宽度";
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
            this.nUDLineWidth.Location = new System.Drawing.Point(262, 157);
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
            this.nUDLineWidth.Size = new System.Drawing.Size(61, 21);
            this.nUDLineWidth.TabIndex = 108;
            this.nUDLineWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 123;
            this.label1.Text = "垂向比例";
            // 
            // nUDfVScale
            // 
            this.nUDfVScale.AllowDrop = true;
            this.nUDfVScale.DecimalPlaces = 1;
            this.nUDfVScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDfVScale.Location = new System.Drawing.Point(388, 113);
            this.nUDfVScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDfVScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDfVScale.Name = "nUDfVScale";
            this.nUDfVScale.Size = new System.Drawing.Size(43, 21);
            this.nUDfVScale.TabIndex = 124;
            this.nUDfVScale.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 125;
            this.label2.Text = "绘制宽度";
            // 
            // nUDTrackWidth
            // 
            this.nUDTrackWidth.AllowDrop = true;
            this.nUDTrackWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDTrackWidth.Location = new System.Drawing.Point(262, 113);
            this.nUDTrackWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDTrackWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDTrackWidth.Name = "nUDTrackWidth";
            this.nUDTrackWidth.Size = new System.Drawing.Size(61, 21);
            this.nUDTrackWidth.TabIndex = 126;
            this.nUDTrackWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // nTBXleftValue
            // 
            this.nTBXleftValue.Location = new System.Drawing.Point(78, 66);
            this.nTBXleftValue.Name = "nTBXleftValue";
            this.nTBXleftValue.Size = new System.Drawing.Size(101, 21);
            this.nTBXleftValue.TabIndex = 112;
            // 
            // nTBXrightValue
            // 
            this.nTBXrightValue.Location = new System.Drawing.Point(232, 67);
            this.nTBXrightValue.Name = "nTBXrightValue";
            this.nTBXrightValue.Size = new System.Drawing.Size(91, 21);
            this.nTBXrightValue.TabIndex = 113;
            // 
            // cbxDrawLeft
            // 
            this.cbxDrawLeft.AutoSize = true;
            this.cbxDrawLeft.Location = new System.Drawing.Point(122, 204);
            this.cbxDrawLeft.Name = "cbxDrawLeft";
            this.cbxDrawLeft.Size = new System.Drawing.Size(72, 16);
            this.cbxDrawLeft.TabIndex = 127;
            this.cbxDrawLeft.Text = "左边绘制";
            this.cbxDrawLeft.UseVisualStyleBackColor = true;
            // 
            // cbxPolygon
            // 
            this.cbxPolygon.AutoSize = true;
            this.cbxPolygon.Location = new System.Drawing.Point(220, 204);
            this.cbxPolygon.Name = "cbxPolygon";
            this.cbxPolygon.Size = new System.Drawing.Size(72, 16);
            this.cbxPolygon.TabIndex = 128;
            this.cbxPolygon.Text = "曲线封闭";
            this.cbxPolygon.UseVisualStyleBackColor = true;
            this.cbxPolygon.CheckedChanged += new System.EventHandler(this.cbxPolygon_CheckedChanged);
            // 
            // FormLayerLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 279);
            this.Controls.Add(this.cbxPolygon);
            this.Controls.Add(this.cbxDrawLeft);
            this.Controls.Add(this.nUDTrackWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUDfVScale);
            this.Controls.Add(this.btnSeleclFillColor);
            this.Controls.Add(this.tbxFillColor);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnLeftRightCov);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.tbxLogColor);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.nUDLineWidth);
            this.Controls.Add(this.nTBXleftValue);
            this.Controls.Add(this.nTBXrightValue);
            this.Controls.Add(this.cbbLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLayerLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "曲线图层测井选择";
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDfVScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSeleclFillColor;
        private System.Windows.Forms.TextBox tbxFillColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnLeftRightCov;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbxLogColor;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.NumericUpDown nUDLineWidth;
        private controls.NumericTextBox nTBXleftValue;
        private controls.NumericTextBox nTBXrightValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDfVScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDTrackWidth;
        private System.Windows.Forms.CheckBox cbxDrawLeft;
        private System.Windows.Forms.CheckBox cbxPolygon;
    }
}