namespace DOGPlatform
{
    partial class FormSettingSectionLayer
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
            this.lblBot = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.cbxUpdateLayerData = new System.Windows.Forms.CheckBox();
            this.btnSeleclFillColor = new System.Windows.Forms.Button();
            this.tbxLayerColor = new System.Windows.Forms.TextBox();
            this.cbxGetNextDepthTop = new System.Windows.Forms.CheckBox();
            this.cbxGetLastDepthBot = new System.Windows.Forms.CheckBox();
            this.cbbConformity = new System.Windows.Forms.ComboBox();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(173, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 72;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(70, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 71;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblBot
            // 
            this.lblBot.AutoSize = true;
            this.lblBot.Location = new System.Drawing.Point(22, 65);
            this.lblBot.Name = "lblBot";
            this.lblBot.Size = new System.Drawing.Size(29, 12);
            this.lblBot.TabIndex = 78;
            this.lblBot.Text = "底深";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(22, 25);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(29, 12);
            this.lblTop.TabIndex = 79;
            this.lblTop.Text = "顶深";
            // 
            // cbxUpdateLayerData
            // 
            this.cbxUpdateLayerData.AutoSize = true;
            this.cbxUpdateLayerData.Location = new System.Drawing.Point(173, 147);
            this.cbxUpdateLayerData.Name = "cbxUpdateLayerData";
            this.cbxUpdateLayerData.Size = new System.Drawing.Size(156, 16);
            this.cbxUpdateLayerData.TabIndex = 83;
            this.cbxUpdateLayerData.Text = "同步更新数据库地层数据";
            this.cbxUpdateLayerData.UseVisualStyleBackColor = true;
            // 
            // btnSeleclFillColor
            // 
            this.btnSeleclFillColor.Location = new System.Drawing.Point(23, 98);
            this.btnSeleclFillColor.Name = "btnSeleclFillColor";
            this.btnSeleclFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnSeleclFillColor.TabIndex = 102;
            this.btnSeleclFillColor.Text = "设置颜色";
            this.btnSeleclFillColor.UseVisualStyleBackColor = true;
            this.btnSeleclFillColor.Click += new System.EventHandler(this.btnSeleclFillColor_Click);
            // 
            // tbxLayerColor
            // 
            this.tbxLayerColor.Location = new System.Drawing.Point(108, 98);
            this.tbxLayerColor.MaxLength = 7;
            this.tbxLayerColor.Name = "tbxLayerColor";
            this.tbxLayerColor.Size = new System.Drawing.Size(61, 21);
            this.tbxLayerColor.TabIndex = 101;
            // 
            // cbxGetNextDepthTop
            // 
            this.cbxGetNextDepthTop.AutoSize = true;
            this.cbxGetNextDepthTop.Location = new System.Drawing.Point(173, 61);
            this.cbxGetNextDepthTop.Name = "cbxGetNextDepthTop";
            this.cbxGetNextDepthTop.Size = new System.Drawing.Size(84, 16);
            this.cbxGetNextDepthTop.TabIndex = 104;
            this.cbxGetNextDepthTop.Text = "连接下段顶";
            this.cbxGetNextDepthTop.UseVisualStyleBackColor = true;
            this.cbxGetNextDepthTop.CheckedChanged += new System.EventHandler(this.cbxGetNextDepthTop_CheckedChanged);
            // 
            // cbxGetLastDepthBot
            // 
            this.cbxGetLastDepthBot.AutoSize = true;
            this.cbxGetLastDepthBot.Location = new System.Drawing.Point(173, 25);
            this.cbxGetLastDepthBot.Name = "cbxGetLastDepthBot";
            this.cbxGetLastDepthBot.Size = new System.Drawing.Size(84, 16);
            this.cbxGetLastDepthBot.TabIndex = 103;
            this.cbxGetLastDepthBot.Text = "承接上段底";
            this.cbxGetLastDepthBot.UseVisualStyleBackColor = true;
            this.cbxGetLastDepthBot.CheckedChanged += new System.EventHandler(this.cbxGetLastDepthBot_CheckedChanged);
            // 
            // cbbConformity
            // 
            this.cbbConformity.FormattingEnabled = true;
            this.cbbConformity.Location = new System.Drawing.Point(24, 145);
            this.cbbConformity.Name = "cbbConformity";
            this.cbbConformity.Size = new System.Drawing.Size(121, 20);
            this.cbbConformity.TabIndex = 105;
            // 
            // nTBXBotDepth
            // 
            this.nTBXBotDepth.Location = new System.Drawing.Point(57, 62);
            this.nTBXBotDepth.Name = "nTBXBotDepth";
            this.nTBXBotDepth.Size = new System.Drawing.Size(98, 21);
            this.nTBXBotDepth.TabIndex = 81;
            // 
            // nTBXTopDepth
            // 
            this.nTBXTopDepth.Location = new System.Drawing.Point(57, 22);
            this.nTBXTopDepth.Name = "nTBXTopDepth";
            this.nTBXTopDepth.Size = new System.Drawing.Size(98, 21);
            this.nTBXTopDepth.TabIndex = 80;
            // 
            // FormSettingSectionLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 247);
            this.Controls.Add(this.cbbConformity);
            this.Controls.Add(this.cbxGetNextDepthTop);
            this.Controls.Add(this.cbxGetLastDepthBot);
            this.Controls.Add(this.btnSeleclFillColor);
            this.Controls.Add(this.tbxLayerColor);
            this.Controls.Add(this.cbxUpdateLayerData);
            this.Controls.Add(this.nTBXBotDepth);
            this.Controls.Add(this.nTBXTopDepth);
            this.Controls.Add(this.lblBot);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingSectionLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地层设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private controls.NumericTextBox nTBXBotDepth;
        private controls.NumericTextBox nTBXTopDepth;
        private System.Windows.Forms.Label lblBot;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.CheckBox cbxUpdateLayerData;
        private System.Windows.Forms.Button btnSeleclFillColor;
        private System.Windows.Forms.TextBox tbxLayerColor;
        private System.Windows.Forms.CheckBox cbxGetNextDepthTop;
        private System.Windows.Forms.CheckBox cbxGetLastDepthBot;
        private System.Windows.Forms.ComboBox cbbConformity;
    }
}