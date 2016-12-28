namespace DOGPlatform
{
    partial class FormSettingShowState
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
            this.nUDShowedBottom = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDPageHeight = new System.Windows.Forms.NumericUpDown();
            this.nUDPageWidth = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nUDMapTitleHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nUDTrackHeadHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nUDTrackHeadFontSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDShowedBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMapTitleHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadHeight)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // nUDShowedBottom
            // 
            this.nUDShowedBottom.AllowDrop = true;
            this.nUDShowedBottom.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDShowedBottom.Location = new System.Drawing.Point(85, 69);
            this.nUDShowedBottom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUDShowedBottom.Name = "nUDShowedBottom";
            this.nUDShowedBottom.Size = new System.Drawing.Size(57, 21);
            this.nUDShowedBottom.TabIndex = 34;
            this.nUDShowedBottom.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDShowedBottom.ValueChanged += new System.EventHandler(this.nUDShowedBottom_ValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(26, 71);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 8;
            this.label30.Text = "显示底深";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(216, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(79, 363);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(61, 26);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(294, 21);
            this.tbxTitle.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 67;
            this.label1.Text = "标题";
            // 
            // nUDPageHeight
            // 
            this.nUDPageHeight.AllowDrop = true;
            this.nUDPageHeight.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDPageHeight.Location = new System.Drawing.Point(171, 30);
            this.nUDPageHeight.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nUDPageHeight.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDPageHeight.Name = "nUDPageHeight";
            this.nUDPageHeight.Size = new System.Drawing.Size(56, 21);
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
            this.nUDPageWidth.Location = new System.Drawing.Point(54, 30);
            this.nUDPageWidth.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nUDPageWidth.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDPageWidth.Name = "nUDPageWidth";
            this.nUDPageWidth.Size = new System.Drawing.Size(58, 21);
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
            this.label20.Location = new System.Drawing.Point(17, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 37;
            this.label20.Text = "页宽";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(131, 34);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(29, 12);
            this.label60.TabIndex = 27;
            this.label60.Text = "页高";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nUDPageHeight);
            this.groupBox1.Controls.Add(this.label60);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.nUDPageWidth);
            this.groupBox1.Location = new System.Drawing.Point(12, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 78);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "页面尺寸(px)";
            // 
            // nUDMapTitleHeight
            // 
            this.nUDMapTitleHeight.AllowDrop = true;
            this.nUDMapTitleHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDMapTitleHeight.Location = new System.Drawing.Point(101, 159);
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
            this.nUDMapTitleHeight.TabIndex = 70;
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
            this.label3.Location = new System.Drawing.Point(181, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "道头框高";
            // 
            // nUDTrackHeadHeight
            // 
            this.nUDTrackHeadHeight.AllowDrop = true;
            this.nUDTrackHeadHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDTrackHeadHeight.Location = new System.Drawing.Point(240, 158);
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
            this.nUDTrackHeadHeight.TabIndex = 69;
            this.nUDTrackHeadHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDTrackHeadHeight.ValueChanged += new System.EventHandler(this.nUDTrackHeadHeight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "标题框高";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nUDShowedBottom);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.tbxTitle);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 117);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "显示设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nUDTrackHeadFontSize);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(13, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 100);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图头布局";
            // 
            // nUDTrackHeadFontSize
            // 
            this.nUDTrackHeadFontSize.AllowDrop = true;
            this.nUDTrackHeadFontSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.Location = new System.Drawing.Point(164, 59);
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
            this.nUDTrackHeadFontSize.Size = new System.Drawing.Size(54, 21);
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
            this.label4.Location = new System.Drawing.Point(30, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 72;
            this.label4.Text = "统一设置道头字体大小";
            // 
            // FormSettingShowState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 419);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nUDMapTitleHeight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nUDTrackHeadHeight);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormSettingShowState";
            this.Text = "布局设置";
            ((System.ComponentModel.ISupportInitialize)(this.nUDShowedBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPageWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMapTitleHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadHeight)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDShowedBottom;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDPageHeight;
        private System.Windows.Forms.NumericUpDown nUDPageWidth;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nUDMapTitleHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUDTrackHeadHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nUDTrackHeadFontSize;
        private System.Windows.Forms.Label label4;
    }
}