namespace DOGPlatform
{
    partial class FormExport2Map
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
            this.nUDShowedBottom.Location = new System.Drawing.Point(204, 40);
            this.nUDShowedBottom.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDShowedBottom.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDShowedBottom.Name = "nUDShowedBottom";
            this.nUDShowedBottom.Size = new System.Drawing.Size(57, 21);
            this.nUDShowedBottom.TabIndex = 2;
            this.nUDShowedBottom.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(145, 42);
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
            this.nUDShowedTop.Location = new System.Drawing.Point(81, 38);
            this.nUDShowedTop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDShowedTop.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDShowedTop.Name = "nUDShowedTop";
            this.nUDShowedTop.Size = new System.Drawing.Size(57, 21);
            this.nUDShowedTop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "显示顶深";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(163, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(40, 94);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormExport2Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 149);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nUDShowedTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUDShowedBottom);
            this.Controls.Add(this.label30);
            this.Name = "FormExport2Map";
            this.Text = "显示深度";
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
    }
}