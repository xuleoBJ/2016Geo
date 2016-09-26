namespace DOGPlatform
{
    partial class FormSettingPageSection
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
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.nUDPageHeight = new System.Windows.Forms.NumericUpDown();
            this.nUDPageWidth = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.nUDpageTopElevation = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nUDFirstWellPosition = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTrackRect = new System.Windows.Forms.CheckBox();
            this.cbxTrackHeadRect = new System.Windows.Forms.CheckBox();
            this.cbxTitleRect = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nUDMapTitleHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nUDTrackHeadHeight = new System.Windows.Forms.NumericUpDown();
            this.nUDTrackHeadFontSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDpageTopElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFirstWellPosition)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMapTitleHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.nUDPageHeight);
            this.groupBox18.Controls.Add(this.nUDPageWidth);
            this.groupBox18.Controls.Add(this.label20);
            this.groupBox18.Controls.Add(this.label60);
            this.groupBox18.Location = new System.Drawing.Point(25, 315);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox18.Size = new System.Drawing.Size(346, 74);
            this.groupBox18.TabIndex = 61;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "页面尺寸设置(单位:px)";
            // 
            // nUDPageHeight
            // 
            this.nUDPageHeight.AllowDrop = true;
            this.nUDPageHeight.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDPageHeight.Location = new System.Drawing.Point(233, 30);
            this.nUDPageHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUDPageHeight.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDPageHeight.Name = "nUDPageHeight";
            this.nUDPageHeight.Size = new System.Drawing.Size(66, 21);
            this.nUDPageHeight.TabIndex = 39;
            this.nUDPageHeight.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nUDPageHeight.ValueChanged += new System.EventHandler(this.nUDPageHeight_ValueChanged);
            // 
            // nUDPageWidth
            // 
            this.nUDPageWidth.AllowDrop = true;
            this.nUDPageWidth.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDPageWidth.Location = new System.Drawing.Point(66, 29);
            this.nUDPageWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUDPageWidth.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDPageWidth.Name = "nUDPageWidth";
            this.nUDPageWidth.Size = new System.Drawing.Size(67, 21);
            this.nUDPageWidth.TabIndex = 38;
            this.nUDPageWidth.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDPageWidth.ValueChanged += new System.EventHandler(this.nUDPageWidth_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 37;
            this.label20.Text = "页面宽";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(176, 35);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(41, 12);
            this.label60.TabIndex = 27;
            this.label60.Text = "页面高";
            // 
            // nUDpageTopElevation
            // 
            this.nUDpageTopElevation.AllowDrop = true;
            this.nUDpageTopElevation.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDpageTopElevation.Location = new System.Drawing.Point(166, 31);
            this.nUDpageTopElevation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDpageTopElevation.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDpageTopElevation.Name = "nUDpageTopElevation";
            this.nUDpageTopElevation.Size = new System.Drawing.Size(50, 21);
            this.nUDpageTopElevation.TabIndex = 41;
            this.nUDpageTopElevation.ValueChanged += new System.EventHandler(this.nUDpageTopElevation_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "页面顶部海拔(深度单位)";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(203, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 24);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(94, 411);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 24);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nUDFirstWellPosition
            // 
            this.nUDFirstWellPosition.AllowDrop = true;
            this.nUDFirstWellPosition.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDFirstWellPosition.Location = new System.Drawing.Point(166, 79);
            this.nUDFirstWellPosition.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDFirstWellPosition.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUDFirstWellPosition.Name = "nUDFirstWellPosition";
            this.nUDFirstWellPosition.Size = new System.Drawing.Size(50, 21);
            this.nUDFirstWellPosition.TabIndex = 68;
            this.nUDFirstWellPosition.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUDFirstWellPosition.ValueChanged += new System.EventHandler(this.nUDFirstWellPosition_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 67;
            this.label2.Text = "首口井位置(深度单位)";
            // 
            // cbxTrackRect
            // 
            this.cbxTrackRect.AutoSize = true;
            this.cbxTrackRect.Location = new System.Drawing.Point(238, 78);
            this.cbxTrackRect.Name = "cbxTrackRect";
            this.cbxTrackRect.Size = new System.Drawing.Size(72, 16);
            this.cbxTrackRect.TabIndex = 69;
            this.cbxTrackRect.Text = "显示道框";
            this.cbxTrackRect.UseVisualStyleBackColor = true;
            // 
            // cbxTrackHeadRect
            // 
            this.cbxTrackHeadRect.AutoSize = true;
            this.cbxTrackHeadRect.Location = new System.Drawing.Point(238, 119);
            this.cbxTrackHeadRect.Name = "cbxTrackHeadRect";
            this.cbxTrackHeadRect.Size = new System.Drawing.Size(84, 16);
            this.cbxTrackHeadRect.TabIndex = 70;
            this.cbxTrackHeadRect.Text = "显示道头框";
            this.cbxTrackHeadRect.UseVisualStyleBackColor = true;
            // 
            // cbxTitleRect
            // 
            this.cbxTitleRect.AutoSize = true;
            this.cbxTitleRect.Location = new System.Drawing.Point(238, 31);
            this.cbxTitleRect.Name = "cbxTitleRect";
            this.cbxTitleRect.Size = new System.Drawing.Size(84, 16);
            this.cbxTitleRect.TabIndex = 71;
            this.cbxTitleRect.Text = "显示标题框";
            this.cbxTitleRect.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nUDMapTitleHeight);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.nUDTrackHeadHeight);
            this.groupBox3.Controls.Add(this.nUDTrackHeadFontSize);
            this.groupBox3.Controls.Add(this.cbxTitleRect);
            this.groupBox3.Controls.Add(this.cbxTrackHeadRect);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbxTrackRect);
            this.groupBox3.Location = new System.Drawing.Point(25, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 157);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图头布局";
            // 
            // nUDMapTitleHeight
            // 
            this.nUDMapTitleHeight.AllowDrop = true;
            this.nUDMapTitleHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDMapTitleHeight.Location = new System.Drawing.Point(151, 31);
            this.nUDMapTitleHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDMapTitleHeight.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nUDMapTitleHeight.Name = "nUDMapTitleHeight";
            this.nUDMapTitleHeight.Size = new System.Drawing.Size(57, 21);
            this.nUDMapTitleHeight.TabIndex = 76;
            this.nUDMapTitleHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDMapTitleHeight.ValueChanged += new System.EventHandler(this.nUDMapTitleHeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "统一设置道头框高";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 73;
            this.label5.Text = "统一设置标题框高";
            // 
            // nUDTrackHeadHeight
            // 
            this.nUDTrackHeadHeight.AllowDrop = true;
            this.nUDTrackHeadHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDTrackHeadHeight.Location = new System.Drawing.Point(151, 75);
            this.nUDTrackHeadHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDTrackHeadHeight.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nUDTrackHeadHeight.Name = "nUDTrackHeadHeight";
            this.nUDTrackHeadHeight.Size = new System.Drawing.Size(57, 21);
            this.nUDTrackHeadHeight.TabIndex = 75;
            this.nUDTrackHeadHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDTrackHeadHeight.ValueChanged += new System.EventHandler(this.nUDTrackHeadHeight_ValueChanged);
            // 
            // nUDTrackHeadFontSize
            // 
            this.nUDTrackHeadFontSize.AllowDrop = true;
            this.nUDTrackHeadFontSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.Location = new System.Drawing.Point(151, 114);
            this.nUDTrackHeadFontSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.Name = "nUDTrackHeadFontSize";
            this.nUDTrackHeadFontSize.Size = new System.Drawing.Size(57, 21);
            this.nUDTrackHeadFontSize.TabIndex = 72;
            this.nUDTrackHeadFontSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.ValueChanged += new System.EventHandler(this.nUDTrackHeadFontSize_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 72;
            this.label4.Text = "统一设置道头字体大小";
            // 
            // FormSettingPageSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 462);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.nUDFirstWellPosition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nUDpageTopElevation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettingPageSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "页面设置";
            this.Load += new System.EventHandler(this.FormSettingPage_Load);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDpageTopElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFirstWellPosition)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMapTitleHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.NumericUpDown nUDPageHeight;
        private System.Windows.Forms.NumericUpDown nUDPageWidth;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nUDpageTopElevation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDFirstWellPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxTrackRect;
        private System.Windows.Forms.CheckBox cbxTrackHeadRect;
        private System.Windows.Forms.CheckBox cbxTitleRect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nUDTrackHeadFontSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nUDMapTitleHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDTrackHeadHeight;
    }
}