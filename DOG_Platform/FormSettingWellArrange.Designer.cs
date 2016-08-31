namespace DOGPlatform
{
    partial class FormSettingWellArrange
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDWellDistanceScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdbPlaceBYWellDistance = new System.Windows.Forms.RadioButton();
            this.rdbPlaceByEqual = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWellDistanceScale)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nUDWellDistanceScale);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 99);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(218, 54);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "井距缩放";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "/10";
            // 
            // nUDWellDistanceScale
            // 
            this.nUDWellDistanceScale.AllowDrop = true;
            this.nUDWellDistanceScale.Location = new System.Drawing.Point(89, 24);
            this.nUDWellDistanceScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDWellDistanceScale.Name = "nUDWellDistanceScale";
            this.nUDWellDistanceScale.Size = new System.Drawing.Size(50, 21);
            this.nUDWellDistanceScale.TabIndex = 44;
            this.nUDWellDistanceScale.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDWellDistanceScale.ValueChanged += new System.EventHandler(this.nUDWellDistanceScale_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "缩放比例";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(158, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 23);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(51, 176);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 23);
            this.btnOK.TabIndex = 67;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdbPlaceBYWellDistance);
            this.groupBox6.Controls.Add(this.rdbPlaceByEqual);
            this.groupBox6.Location = new System.Drawing.Point(35, 28);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(218, 62);
            this.groupBox6.TabIndex = 69;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "井排列方式";
            // 
            // rdbPlaceBYWellDistance
            // 
            this.rdbPlaceBYWellDistance.AutoSize = true;
            this.rdbPlaceBYWellDistance.Checked = true;
            this.rdbPlaceBYWellDistance.Location = new System.Drawing.Point(23, 25);
            this.rdbPlaceBYWellDistance.Margin = new System.Windows.Forms.Padding(2);
            this.rdbPlaceBYWellDistance.Name = "rdbPlaceBYWellDistance";
            this.rdbPlaceBYWellDistance.Size = new System.Drawing.Size(71, 16);
            this.rdbPlaceBYWellDistance.TabIndex = 1;
            this.rdbPlaceBYWellDistance.TabStop = true;
            this.rdbPlaceBYWellDistance.Text = "井距等比";
            this.rdbPlaceBYWellDistance.UseVisualStyleBackColor = true;
            this.rdbPlaceBYWellDistance.CheckedChanged += new System.EventHandler(this.rdbPlaceBYWellDistance_CheckedChanged);
            // 
            // rdbPlaceByEqual
            // 
            this.rdbPlaceByEqual.AutoSize = true;
            this.rdbPlaceByEqual.Location = new System.Drawing.Point(113, 25);
            this.rdbPlaceByEqual.Margin = new System.Windows.Forms.Padding(2);
            this.rdbPlaceByEqual.Name = "rdbPlaceByEqual";
            this.rdbPlaceByEqual.Size = new System.Drawing.Size(71, 16);
            this.rdbPlaceByEqual.TabIndex = 0;
            this.rdbPlaceByEqual.Text = "等距排列";
            this.rdbPlaceByEqual.UseVisualStyleBackColor = true;
            this.rdbPlaceByEqual.CheckedChanged += new System.EventHandler(this.rdbPlaceByEqual_CheckedChanged);
            // 
            // FormSettingWellArrange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 250);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSettingWellArrange";
            this.Text = "井距排列";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWellDistanceScale)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDWellDistanceScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdbPlaceBYWellDistance;
        private System.Windows.Forms.RadioButton rdbPlaceByEqual;
    }
}