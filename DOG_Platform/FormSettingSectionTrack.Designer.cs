namespace DOGPlatform
{
    partial class FormSettingSectionTrack
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
            this.label2 = new System.Windows.Forms.Label();
            this.nUDTrackHeadFontSize = new System.Windows.Forms.NumericUpDown();
            this.tbxTrackTitle = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.nUDTrackWidth = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxTextWriteMode = new System.Windows.Forms.CheckBox();
            this.nUDTrackTextFontSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbAlign = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackTextFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "标题字号";
            // 
            // nUDTrackHeadFontSize
            // 
            this.nUDTrackHeadFontSize.AllowDrop = true;
            this.nUDTrackHeadFontSize.Location = new System.Drawing.Point(289, 17);
            this.nUDTrackHeadFontSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.Name = "nUDTrackHeadFontSize";
            this.nUDTrackHeadFontSize.Size = new System.Drawing.Size(38, 21);
            this.nUDTrackHeadFontSize.TabIndex = 48;
            this.nUDTrackHeadFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDTrackHeadFontSize.ValueChanged += new System.EventHandler(this.nUDTrackHeadFontSize_ValueChanged);
            // 
            // tbxTrackTitle
            // 
            this.tbxTrackTitle.Location = new System.Drawing.Point(47, 16);
            this.tbxTrackTitle.Name = "tbxTrackTitle";
            this.tbxTrackTitle.Size = new System.Drawing.Size(183, 21);
            this.tbxTrackTitle.TabIndex = 45;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(12, 19);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(29, 12);
            this.label51.TabIndex = 35;
            this.label51.Text = "标题";
            // 
            // nUDTrackWidth
            // 
            this.nUDTrackWidth.AllowDrop = true;
            this.nUDTrackWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDTrackWidth.Location = new System.Drawing.Point(47, 48);
            this.nUDTrackWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDTrackWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDTrackWidth.Name = "nUDTrackWidth";
            this.nUDTrackWidth.Size = new System.Drawing.Size(60, 21);
            this.nUDTrackWidth.TabIndex = 28;
            this.nUDTrackWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nUDTrackWidth.ValueChanged += new System.EventHandler(this.nUDTrackWidth_ValueChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(12, 50);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(29, 12);
            this.label44.TabIndex = 27;
            this.label44.Text = "道宽";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(188, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(71, 129);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxTextWriteMode
            // 
            this.cbxTextWriteMode.AutoSize = true;
            this.cbxTextWriteMode.Location = new System.Drawing.Point(233, 51);
            this.cbxTextWriteMode.Name = "cbxTextWriteMode";
            this.cbxTextWriteMode.Size = new System.Drawing.Size(72, 16);
            this.cbxTextWriteMode.TabIndex = 89;
            this.cbxTextWriteMode.Text = "垂直文本";
            this.cbxTextWriteMode.UseVisualStyleBackColor = true;
            this.cbxTextWriteMode.CheckedChanged += new System.EventHandler(this.cbxTextVertical_CheckedChanged);
            // 
            // nUDTrackTextFontSize
            // 
            this.nUDTrackTextFontSize.AllowDrop = true;
            this.nUDTrackTextFontSize.Location = new System.Drawing.Point(174, 50);
            this.nUDTrackTextFontSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDTrackTextFontSize.Name = "nUDTrackTextFontSize";
            this.nUDTrackTextFontSize.Size = new System.Drawing.Size(38, 21);
            this.nUDTrackTextFontSize.TabIndex = 90;
            this.nUDTrackTextFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDTrackTextFontSize.ValueChanged += new System.EventHandler(this.nUDTrackTextFontSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 91;
            this.label1.Text = "道内字号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 93;
            this.label3.Text = "对齐";
            // 
            // cbbAlign
            // 
            this.cbbAlign.FormattingEnabled = true;
            this.cbbAlign.Items.AddRange(new object[] {
            "居中",
            "左上"});
            this.cbbAlign.Location = new System.Drawing.Point(47, 88);
            this.cbbAlign.Name = "cbbAlign";
            this.cbbAlign.Size = new System.Drawing.Size(60, 20);
            this.cbbAlign.TabIndex = 92;
            this.cbbAlign.SelectedIndexChanged += new System.EventHandler(this.cbbAlign_SelectedIndexChanged);
            // 
            // FormSettingSectionTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 193);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbAlign);
            this.Controls.Add(this.nUDTrackTextFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTextWriteMode);
            this.Controls.Add(this.nUDTrackHeadFontSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nUDTrackWidth);
            this.Controls.Add(this.tbxTrackTitle);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label51);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingSectionTrack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图道设置";
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackHeadFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackTextFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown nUDTrackWidth;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxTrackTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDTrackHeadFontSize;
        private System.Windows.Forms.CheckBox cbxTextWriteMode;
        private System.Windows.Forms.NumericUpDown nUDTrackTextFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbAlign;
    }
}