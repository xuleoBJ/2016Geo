namespace DOGPlatform
{
    partial class FormLayerGeologicalValue
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
            this.label6 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.nUDLayerGeologyProperyFontSize = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLayerGeologyProperyFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "渗透率";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(52, 52);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(29, 12);
            this.label58.TabIndex = 24;
            this.label58.Text = "砂厚";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(40, 36);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(53, 12);
            this.label57.TabIndex = 23;
            this.label57.Text = "有效厚度";
            // 
            // nUDLayerGeologyProperyFontSize
            // 
            this.nUDLayerGeologyProperyFontSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nUDLayerGeologyProperyFontSize.Location = new System.Drawing.Point(196, 43);
            this.nUDLayerGeologyProperyFontSize.Name = "nUDLayerGeologyProperyFontSize";
            this.nUDLayerGeologyProperyFontSize.Size = new System.Drawing.Size(37, 21);
            this.nUDLayerGeologyProperyFontSize.TabIndex = 17;
            this.nUDLayerGeologyProperyFontSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(161, 46);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 12;
            this.label29.Text = "字号";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(41, 124);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 67;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormGeologicalValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 179);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.nUDLayerGeologyProperyFontSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGeologicalValue";
            this.Text = "井点属性";
            ((System.ComponentModel.ISupportInitialize)(this.nUDLayerGeologyProperyFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.NumericUpDown nUDLayerGeologyProperyFontSize;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}