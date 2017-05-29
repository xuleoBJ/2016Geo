namespace DOGPlatform
{
    partial class FormLayerSettingPage
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
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nUDiNumExtendGrid = new System.Windows.Forms.NumericUpDown();
            this.cbbUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nUDPageHeight = new System.Windows.Forms.NumericUpDown();
            this.button26 = new System.Windows.Forms.Button();
            this.nUDPageWidth = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbxScaleRulerShowed = new System.Windows.Forms.CheckBox();
            this.cbxGrid = new System.Windows.Forms.CheckBox();
            this.cbxCompassShowed = new System.Windows.Forms.CheckBox();
            this.cbxMapFrame = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nUDGridSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDiNumExtendGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGridSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(67, 33);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(415, 21);
            this.tbxTitle.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 65;
            this.label8.Text = "文件名";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbUnit);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nUDPageHeight);
            this.groupBox3.Controls.Add(this.nUDPageWidth);
            this.groupBox3.Controls.Add(this.label67);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(14, 74);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(449, 61);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "页面大小设置";
            // 
            // nUDiNumExtendGrid
            // 
            this.nUDiNumExtendGrid.AllowDrop = true;
            this.nUDiNumExtendGrid.Location = new System.Drawing.Point(217, 150);
            this.nUDiNumExtendGrid.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDiNumExtendGrid.Name = "nUDiNumExtendGrid";
            this.nUDiNumExtendGrid.Size = new System.Drawing.Size(66, 21);
            this.nUDiNumExtendGrid.TabIndex = 42;
            this.nUDiNumExtendGrid.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDiNumExtendGrid.ValueChanged += new System.EventHandler(this.nUDiNumExtendGrid_ValueChanged);
            // 
            // cbbUnit
            // 
            this.cbbUnit.FormattingEnabled = true;
            this.cbbUnit.Location = new System.Drawing.Point(307, 22);
            this.cbbUnit.Name = "cbbUnit";
            this.cbbUnit.Size = new System.Drawing.Size(75, 20);
            this.cbbUnit.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "图幅单位";
            // 
            // nUDPageHeight
            // 
            this.nUDPageHeight.AllowDrop = true;
            this.nUDPageHeight.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDPageHeight.Location = new System.Drawing.Point(180, 23);
            this.nUDPageHeight.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nUDPageHeight.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDPageHeight.Name = "nUDPageHeight";
            this.nUDPageHeight.Size = new System.Drawing.Size(50, 21);
            this.nUDPageHeight.TabIndex = 39;
            this.nUDPageHeight.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nUDPageHeight.ValueChanged += new System.EventHandler(this.nUDPageHeight_ValueChanged);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(95, 202);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(75, 23);
            this.button26.TabIndex = 26;
            this.button26.Text = "坐标字体";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // nUDPageWidth
            // 
            this.nUDPageWidth.AllowDrop = true;
            this.nUDPageWidth.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDPageWidth.Location = new System.Drawing.Point(66, 22);
            this.nUDPageWidth.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nUDPageWidth.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDPageWidth.Name = "nUDPageWidth";
            this.nUDPageWidth.Size = new System.Drawing.Size(50, 21);
            this.nUDPageWidth.TabIndex = 38;
            this.nUDPageWidth.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDPageWidth.ValueChanged += new System.EventHandler(this.nUDPageWidth_ValueChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(150, 154);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 8;
            this.label35.Text = "区域扩边 X";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(19, 26);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(41, 12);
            this.label67.TabIndex = 37;
            this.label67.Text = "页面宽";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "页面高";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cbxScaleRulerShowed);
            this.groupBox1.Controls.Add(this.cbxCompassShowed);
            this.groupBox1.Location = new System.Drawing.Point(12, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 79);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "平面图信息";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(193, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "绘制图例";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbxScaleRulerShowed
            // 
            this.cbxScaleRulerShowed.AutoSize = true;
            this.cbxScaleRulerShowed.Checked = true;
            this.cbxScaleRulerShowed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxScaleRulerShowed.Location = new System.Drawing.Point(19, 36);
            this.cbxScaleRulerShowed.Name = "cbxScaleRulerShowed";
            this.cbxScaleRulerShowed.Size = new System.Drawing.Size(60, 16);
            this.cbxScaleRulerShowed.TabIndex = 2;
            this.cbxScaleRulerShowed.Text = "比例尺";
            this.cbxScaleRulerShowed.UseVisualStyleBackColor = true;
            // 
            // cbxGrid
            // 
            this.cbxGrid.AutoSize = true;
            this.cbxGrid.Checked = true;
            this.cbxGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxGrid.Location = new System.Drawing.Point(289, 153);
            this.cbxGrid.Name = "cbxGrid";
            this.cbxGrid.Size = new System.Drawing.Size(72, 16);
            this.cbxGrid.TabIndex = 4;
            this.cbxGrid.Text = "绘制网格";
            this.cbxGrid.UseVisualStyleBackColor = true;
            this.cbxGrid.CheckedChanged += new System.EventHandler(this.cbxGrid_CheckedChanged);
            // 
            // cbxCompassShowed
            // 
            this.cbxCompassShowed.AutoSize = true;
            this.cbxCompassShowed.Location = new System.Drawing.Point(110, 35);
            this.cbxCompassShowed.Name = "cbxCompassShowed";
            this.cbxCompassShowed.Size = new System.Drawing.Size(60, 16);
            this.cbxCompassShowed.TabIndex = 2;
            this.cbxCompassShowed.Text = "指南针";
            this.cbxCompassShowed.UseVisualStyleBackColor = true;
            // 
            // cbxMapFrame
            // 
            this.cbxMapFrame.AutoSize = true;
            this.cbxMapFrame.Checked = true;
            this.cbxMapFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMapFrame.Location = new System.Drawing.Point(17, 206);
            this.cbxMapFrame.Name = "cbxMapFrame";
            this.cbxMapFrame.Size = new System.Drawing.Size(72, 16);
            this.cbxMapFrame.TabIndex = 2;
            this.cbxMapFrame.Text = "绘制图框";
            this.cbxMapFrame.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 72;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(305, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 71;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nUDGridSize
            // 
            this.nUDGridSize.AllowDrop = true;
            this.nUDGridSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDGridSize.Location = new System.Drawing.Point(70, 149);
            this.nUDGridSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDGridSize.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDGridSize.Name = "nUDGridSize";
            this.nUDGridSize.Size = new System.Drawing.Size(66, 21);
            this.nUDGridSize.TabIndex = 43;
            this.nUDGridSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nUDGridSize.ValueChanged += new System.EventHandler(this.nUDGridSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "网格宽度";
            // 
            // FormLayerSettingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 391);
            this.Controls.Add(this.nUDiNumExtendGrid);
            this.Controls.Add(this.nUDGridSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMapFrame);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.cbxGrid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormLayerSettingPage";
            this.Text = "页面设置";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDiNumExtendGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGridSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nUDiNumExtendGrid;
        private System.Windows.Forms.ComboBox cbbUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUDPageHeight;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.NumericUpDown nUDPageWidth;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cbxScaleRulerShowed;
        private System.Windows.Forms.CheckBox cbxGrid;
        private System.Windows.Forms.CheckBox cbxCompassShowed;
        private System.Windows.Forms.CheckBox cbxMapFrame;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nUDGridSize;
        private System.Windows.Forms.Label label1;
    }
}