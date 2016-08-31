namespace DOGPlatform
{
    partial class FormSettingElevationRuler
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblTrackWidth = new System.Windows.Forms.Label();
            this.nUDElevationRulerBottom = new System.Windows.Forms.NumericUpDown();
            this.nUDElevationRulerTop = new System.Windows.Forms.NumericUpDown();
            this.nUDElevationFontSize = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.nUDElevationScale = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxRulerElavationVisible = new System.Windows.Forms.CheckBox();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationRulerBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationRulerTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationScale)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbxRulerElavationVisible);
            this.groupBox8.Controls.Add(this.numericUpDown1);
            this.groupBox8.Controls.Add(this.lblTrackWidth);
            this.groupBox8.Controls.Add(this.nUDElevationRulerBottom);
            this.groupBox8.Controls.Add(this.nUDElevationRulerTop);
            this.groupBox8.Controls.Add(this.nUDElevationFontSize);
            this.groupBox8.Controls.Add(this.label50);
            this.groupBox8.Controls.Add(this.nUDElevationScale);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Location = new System.Drawing.Point(19, 11);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(429, 138);
            this.groupBox8.TabIndex = 62;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "设置海拔尺";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AllowDrop = true;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(325, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 21);
            this.numericUpDown1.TabIndex = 36;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblTrackWidth
            // 
            this.lblTrackWidth.AutoSize = true;
            this.lblTrackWidth.Location = new System.Drawing.Point(292, 36);
            this.lblTrackWidth.Name = "lblTrackWidth";
            this.lblTrackWidth.Size = new System.Drawing.Size(29, 12);
            this.lblTrackWidth.TabIndex = 35;
            this.lblTrackWidth.Text = "道宽";
            // 
            // nUDElevationRulerBottom
            // 
            this.nUDElevationRulerBottom.AllowDrop = true;
            this.nUDElevationRulerBottom.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDElevationRulerBottom.Location = new System.Drawing.Point(69, 70);
            this.nUDElevationRulerBottom.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDElevationRulerBottom.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDElevationRulerBottom.Name = "nUDElevationRulerBottom";
            this.nUDElevationRulerBottom.Size = new System.Drawing.Size(57, 21);
            this.nUDElevationRulerBottom.TabIndex = 34;
            this.nUDElevationRulerBottom.Value = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.nUDElevationRulerBottom.ValueChanged += new System.EventHandler(this.nUDElevationRulerBottom_ValueChanged);
            // 
            // nUDElevationRulerTop
            // 
            this.nUDElevationRulerTop.AllowDrop = true;
            this.nUDElevationRulerTop.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDElevationRulerTop.Location = new System.Drawing.Point(70, 32);
            this.nUDElevationRulerTop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDElevationRulerTop.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDElevationRulerTop.Name = "nUDElevationRulerTop";
            this.nUDElevationRulerTop.Size = new System.Drawing.Size(58, 21);
            this.nUDElevationRulerTop.TabIndex = 33;
            this.nUDElevationRulerTop.ValueChanged += new System.EventHandler(this.nUDElevationRulerTop_ValueChanged);
            this.nUDElevationRulerTop.Click += new System.EventHandler(this.nUDElevationRulerTop_ValueChanged);
            // 
            // nUDElevationFontSize
            // 
            this.nUDElevationFontSize.AllowDrop = true;
            this.nUDElevationFontSize.Location = new System.Drawing.Point(325, 74);
            this.nUDElevationFontSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDElevationFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDElevationFontSize.Name = "nUDElevationFontSize";
            this.nUDElevationFontSize.Size = new System.Drawing.Size(54, 21);
            this.nUDElevationFontSize.TabIndex = 32;
            this.nUDElevationFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDElevationFontSize.ValueChanged += new System.EventHandler(this.nUDElevationFontSize_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(291, 78);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(29, 12);
            this.label50.TabIndex = 31;
            this.label50.Text = "字号";
            // 
            // nUDElevationScale
            // 
            this.nUDElevationScale.AllowDrop = true;
            this.nUDElevationScale.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDElevationScale.Location = new System.Drawing.Point(208, 34);
            this.nUDElevationScale.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nUDElevationScale.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDElevationScale.Name = "nUDElevationScale";
            this.nUDElevationScale.Size = new System.Drawing.Size(55, 21);
            this.nUDElevationScale.TabIndex = 17;
            this.nUDElevationScale.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDElevationScale.ValueChanged += new System.EventHandler(this.nUDElevationScale_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(161, 36);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 12);
            this.label26.TabIndex = 17;
            this.label26.Text = "主刻度";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(132, 74);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 12);
            this.label27.TabIndex = 14;
            this.label27.Text = "米";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(132, 36);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 14;
            this.label28.Text = "米";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 8;
            this.label29.Text = "海拔顶深";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 74);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 8;
            this.label30.Text = "海拔底深";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(106, 177);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 63;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(233, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 64;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbxRulerElavationVisible
            // 
            this.cbxRulerElavationVisible.AutoSize = true;
            this.cbxRulerElavationVisible.Location = new System.Drawing.Point(163, 74);
            this.cbxRulerElavationVisible.Name = "cbxRulerElavationVisible";
            this.cbxRulerElavationVisible.Size = new System.Drawing.Size(48, 16);
            this.cbxRulerElavationVisible.TabIndex = 37;
            this.cbxRulerElavationVisible.Text = "显示";
            this.cbxRulerElavationVisible.UseVisualStyleBackColor = true;
            this.cbxRulerElavationVisible.CheckedChanged += new System.EventHandler(this.cbxRulerElavationVisible_CheckedChanged);
            // 
            // FormSettingElevationRuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 230);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox8);
            this.Name = "FormSettingElevationRuler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "海拔尺设置";
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationRulerBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationRulerTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElevationScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown nUDElevationRulerBottom;
        private System.Windows.Forms.NumericUpDown nUDElevationRulerTop;
        private System.Windows.Forms.NumericUpDown nUDElevationFontSize;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.NumericUpDown nUDElevationScale;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblTrackWidth;
        private System.Windows.Forms.CheckBox cbxRulerElavationVisible;
    }
}