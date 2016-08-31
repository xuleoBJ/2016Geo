namespace DOGPlatform
{
    partial class FormSectionAddImageItem
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbxImageFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.lblBot = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nUDWidthPercent = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidthPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 207);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nUDWidthPercent);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxImageFilePath);
            this.tabPage1.Controls.Add(this.btnSelectImage);
            this.tabPage1.Controls.Add(this.nTBXBotDepth);
            this.tabPage1.Controls.Add(this.nTBXTopDepth);
            this.tabPage1.Controls.Add(this.lblBot);
            this.tabPage1.Controls.Add(this.lblTop);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbxImageFilePath
            // 
            this.tbxImageFilePath.Location = new System.Drawing.Point(21, 93);
            this.tbxImageFilePath.Name = "tbxImageFilePath";
            this.tbxImageFilePath.Size = new System.Drawing.Size(397, 21);
            this.tbxImageFilePath.TabIndex = 95;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(21, 53);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(75, 23);
            this.btnSelectImage.TabIndex = 94;
            this.btnSelectImage.Text = "选择图片";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // lblBot
            // 
            this.lblBot.AutoSize = true;
            this.lblBot.Location = new System.Drawing.Point(128, 22);
            this.lblBot.Name = "lblBot";
            this.lblBot.Size = new System.Drawing.Size(29, 12);
            this.lblBot.TabIndex = 90;
            this.lblBot.Text = "底深";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(19, 22);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(29, 12);
            this.lblTop.TabIndex = 91;
            this.lblTop.Text = "顶深";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(183, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(82, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 87;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nUDWidthPercent
            // 
            this.nUDWidthPercent.AllowDrop = true;
            this.nUDWidthPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDWidthPercent.Location = new System.Drawing.Point(314, 19);
            this.nUDWidthPercent.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDWidthPercent.Name = "nUDWidthPercent";
            this.nUDWidthPercent.Size = new System.Drawing.Size(50, 21);
            this.nUDWidthPercent.TabIndex = 102;
            this.nUDWidthPercent.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 101;
            this.label3.Text = "道宽（%）";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nTBXBotDepth
            // 
            this.nTBXBotDepth.Location = new System.Drawing.Point(170, 18);
            this.nTBXBotDepth.Name = "nTBXBotDepth";
            this.nTBXBotDepth.Size = new System.Drawing.Size(59, 21);
            this.nTBXBotDepth.TabIndex = 93;
            this.nTBXBotDepth.Text = "100";
            // 
            // nTBXTopDepth
            // 
            this.nTBXTopDepth.Location = new System.Drawing.Point(61, 18);
            this.nTBXTopDepth.Name = "nTBXTopDepth";
            this.nTBXTopDepth.Size = new System.Drawing.Size(54, 21);
            this.nTBXTopDepth.TabIndex = 92;
            this.nTBXTopDepth.Text = "0";
            // 
            // FormSectionAddImageItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 207);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSectionAddImageItem";
            this.Text = "图片数据";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidthPercent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private controls.NumericTextBox nTBXBotDepth;
        private controls.NumericTextBox nTBXTopDepth;
        private System.Windows.Forms.Label lblBot;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.TextBox tbxImageFilePath;
        private System.Windows.Forms.NumericUpDown nUDWidthPercent;
        private System.Windows.Forms.Label label3;
    }
}