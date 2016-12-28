namespace DOGPlatform
{
    partial class FormSettingSectionGeoShowDepth
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
            this.nUDShowedTop = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdbMD = new System.Windows.Forms.RadioButton();
            this.rdbEle = new System.Windows.Forms.RadioButton();
            this.cbxShowWellBase = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDShowedBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDShowedTop)).BeginInit();
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
            this.nUDShowedBottom.Location = new System.Drawing.Point(70, 94);
            this.nUDShowedBottom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUDShowedBottom.Name = "nUDShowedBottom";
            this.nUDShowedBottom.Size = new System.Drawing.Size(110, 21);
            this.nUDShowedBottom.TabIndex = 36;
            this.nUDShowedBottom.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 96);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 35;
            this.label30.Text = "显示底深";
            // 
            // nUDShowedTop
            // 
            this.nUDShowedTop.AllowDrop = true;
            this.nUDShowedTop.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDShowedTop.Location = new System.Drawing.Point(70, 58);
            this.nUDShowedTop.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nUDShowedTop.Name = "nUDShowedTop";
            this.nUDShowedTop.Size = new System.Drawing.Size(110, 21);
            this.nUDShowedTop.TabIndex = 38;
            this.nUDShowedTop.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "显示顶深";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(124, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(32, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 67;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdbMD
            // 
            this.rdbMD.AutoSize = true;
            this.rdbMD.Checked = true;
            this.rdbMD.Location = new System.Drawing.Point(17, 23);
            this.rdbMD.Name = "rdbMD";
            this.rdbMD.Size = new System.Drawing.Size(47, 16);
            this.rdbMD.TabIndex = 69;
            this.rdbMD.TabStop = true;
            this.rdbMD.Text = "测深";
            this.rdbMD.UseVisualStyleBackColor = true;
            // 
            // rdbEle
            // 
            this.rdbEle.AutoSize = true;
            this.rdbEle.Location = new System.Drawing.Point(79, 23);
            this.rdbEle.Name = "rdbEle";
            this.rdbEle.Size = new System.Drawing.Size(47, 16);
            this.rdbEle.TabIndex = 70;
            this.rdbEle.Text = "海拔";
            this.rdbEle.UseVisualStyleBackColor = true;
            // 
            // cbxShowWellBase
            // 
            this.cbxShowWellBase.AutoSize = true;
            this.cbxShowWellBase.Location = new System.Drawing.Point(201, 99);
            this.cbxShowWellBase.Name = "cbxShowWellBase";
            this.cbxShowWellBase.Size = new System.Drawing.Size(48, 16);
            this.cbxShowWellBase.TabIndex = 71;
            this.cbxShowWellBase.Text = "井底";
            this.cbxShowWellBase.UseVisualStyleBackColor = true;
            this.cbxShowWellBase.CheckedChanged += new System.EventHandler(this.cbxShowWellBase_CheckedChanged);
            // 
            // FormSettingSectionGeoShowDepth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 182);
            this.Controls.Add(this.cbxShowWellBase);
            this.Controls.Add(this.rdbEle);
            this.Controls.Add(this.rdbMD);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nUDShowedTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUDShowedBottom);
            this.Controls.Add(this.label30);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingSectionGeoShowDepth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置显示深度";
            ((System.ComponentModel.ISupportInitialize)(this.nUDShowedBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDShowedTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDShowedBottom;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown nUDShowedTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rdbMD;
        private System.Windows.Forms.RadioButton rdbEle;
        private System.Windows.Forms.CheckBox cbxShowWellBase;
    }
}