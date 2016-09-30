namespace DOGPlatform
{
    partial class FormSettingFenceWellPositionView
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
            this.nUDX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDY = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(143, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 77;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(43, 111);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 76;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nUDX
            // 
            this.nUDX.AllowDrop = true;
            this.nUDX.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDX.Location = new System.Drawing.Point(119, 29);
            this.nUDX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDX.Name = "nUDX";
            this.nUDX.Size = new System.Drawing.Size(110, 21);
            this.nUDX.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 74;
            this.label1.Text = "X东西方向";
            // 
            // nUDY
            // 
            this.nUDY.AllowDrop = true;
            this.nUDY.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDY.Location = new System.Drawing.Point(119, 68);
            this.nUDY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDY.Name = "nUDY";
            this.nUDY.Size = new System.Drawing.Size(110, 21);
            this.nUDY.TabIndex = 73;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(41, 70);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(59, 12);
            this.label30.TabIndex = 72;
            this.label30.Text = "Y南北方向";
            // 
            // FormSettingFenceWellPositionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 157);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nUDX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUDY);
            this.Controls.Add(this.label30);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettingFenceWellPositionView";
            this.Text = "视井位调整";
            ((System.ComponentModel.ISupportInitialize)(this.nUDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nUDX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDY;
        private System.Windows.Forms.Label label30;
    }
}