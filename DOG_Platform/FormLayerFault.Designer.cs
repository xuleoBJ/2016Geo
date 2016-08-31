namespace DOGPlatform
{
    partial class FormLayerFault
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
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.nUDFaultLineWidth = new System.Windows.Forms.NumericUpDown();
            this.cbbCorlorFaultLine = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxAddFaultLine = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFaultLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.nUDFaultLineWidth);
            this.groupBox24.Controls.Add(this.cbbCorlorFaultLine);
            this.groupBox24.Controls.Add(this.label11);
            this.groupBox24.Controls.Add(this.cbxAddFaultLine);
            this.groupBox24.Controls.Add(this.label9);
            this.groupBox24.Location = new System.Drawing.Point(27, 35);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(258, 93);
            this.groupBox24.TabIndex = 23;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "断层线设置";
            // 
            // nUDFaultLineWidth
            // 
            this.nUDFaultLineWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nUDFaultLineWidth.Location = new System.Drawing.Point(161, 43);
            this.nUDFaultLineWidth.Name = "nUDFaultLineWidth";
            this.nUDFaultLineWidth.Size = new System.Drawing.Size(57, 21);
            this.nUDFaultLineWidth.TabIndex = 17;
            this.nUDFaultLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbbCorlorFaultLine
            // 
            this.cbbCorlorFaultLine.BackColor = System.Drawing.Color.Red;
            this.cbbCorlorFaultLine.FormattingEnabled = true;
            this.cbbCorlorFaultLine.Location = new System.Drawing.Point(45, 44);
            this.cbbCorlorFaultLine.Name = "cbbCorlorFaultLine";
            this.cbbCorlorFaultLine.Size = new System.Drawing.Size(61, 20);
            this.cbbCorlorFaultLine.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "颜色";
            // 
            // cbxAddFaultLine
            // 
            this.cbxAddFaultLine.AutoSize = true;
            this.cbxAddFaultLine.Location = new System.Drawing.Point(11, 22);
            this.cbxAddFaultLine.Name = "cbxAddFaultLine";
            this.cbxAddFaultLine.Size = new System.Drawing.Size(84, 16);
            this.cbxAddFaultLine.TabIndex = 21;
            this.cbxAddFaultLine.Text = "层位断层线";
            this.cbxAddFaultLine.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "线宽";
            // 
            // FormLayerFault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 352);
            this.Controls.Add(this.groupBox24);
            this.Name = "FormLayerFault";
            this.Text = "断层";
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFaultLineWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.NumericUpDown nUDFaultLineWidth;
        private System.Windows.Forms.ComboBox cbbCorlorFaultLine;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbxAddFaultLine;
        private System.Windows.Forms.Label label9;
    }
}