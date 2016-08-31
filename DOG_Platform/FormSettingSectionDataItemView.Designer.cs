namespace DOGPlatform
{
    partial class FormSettingSectionDataItemView
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
            this.lblType = new System.Windows.Forms.Label();
            this.cbbSelect = new System.Windows.Forms.ComboBox();
            this.lblBot = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.cbxGetLastDepthBot = new System.Windows.Forms.CheckBox();
            this.cbxGetNextDepthTop = new System.Windows.Forms.CheckBox();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(169, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 80;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(66, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 79;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(31, 96);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 12);
            this.lblType.TabIndex = 74;
            this.lblType.Text = "属性";
            // 
            // cbbSelect
            // 
            this.cbbSelect.FormattingEnabled = true;
            this.cbbSelect.Location = new System.Drawing.Point(66, 93);
            this.cbbSelect.Name = "cbbSelect";
            this.cbbSelect.Size = new System.Drawing.Size(214, 20);
            this.cbbSelect.TabIndex = 81;
            this.cbbSelect.SelectedIndexChanged += new System.EventHandler(this.cbbJSJL_SelectedIndexChanged);
            // 
            // lblBot
            // 
            this.lblBot.AutoSize = true;
            this.lblBot.Location = new System.Drawing.Point(31, 57);
            this.lblBot.Name = "lblBot";
            this.lblBot.Size = new System.Drawing.Size(29, 12);
            this.lblBot.TabIndex = 82;
            this.lblBot.Text = "底深";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(31, 22);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(29, 12);
            this.lblTop.TabIndex = 83;
            this.lblTop.Text = "顶深";
            // 
            // cbxGetLastDepthBot
            // 
            this.cbxGetLastDepthBot.AutoSize = true;
            this.cbxGetLastDepthBot.Location = new System.Drawing.Point(186, 23);
            this.cbxGetLastDepthBot.Name = "cbxGetLastDepthBot";
            this.cbxGetLastDepthBot.Size = new System.Drawing.Size(84, 16);
            this.cbxGetLastDepthBot.TabIndex = 86;
            this.cbxGetLastDepthBot.Text = "承接上段底";
            this.cbxGetLastDepthBot.UseVisualStyleBackColor = true;
            this.cbxGetLastDepthBot.CheckedChanged += new System.EventHandler(this.cbxGetLastDepthBot_CheckedChanged);
            // 
            // cbxGetNextDepthTop
            // 
            this.cbxGetNextDepthTop.AutoSize = true;
            this.cbxGetNextDepthTop.Location = new System.Drawing.Point(186, 59);
            this.cbxGetNextDepthTop.Name = "cbxGetNextDepthTop";
            this.cbxGetNextDepthTop.Size = new System.Drawing.Size(84, 16);
            this.cbxGetNextDepthTop.TabIndex = 87;
            this.cbxGetNextDepthTop.Text = "连接下段顶";
            this.cbxGetNextDepthTop.UseVisualStyleBackColor = true;
            this.cbxGetNextDepthTop.CheckedChanged += new System.EventHandler(this.cbxGetNextDepthTop_CheckedChanged);
            // 
            // nTBXBotDepth
            // 
            this.nTBXBotDepth.Location = new System.Drawing.Point(66, 57);
            this.nTBXBotDepth.Name = "nTBXBotDepth";
            this.nTBXBotDepth.Size = new System.Drawing.Size(101, 21);
            this.nTBXBotDepth.TabIndex = 85;
            // 
            // nTBXTopDepth
            // 
            this.nTBXTopDepth.Location = new System.Drawing.Point(66, 18);
            this.nTBXTopDepth.Name = "nTBXTopDepth";
            this.nTBXTopDepth.Size = new System.Drawing.Size(101, 21);
            this.nTBXTopDepth.TabIndex = 84;
            // 
            // FormSettingSectionDataItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 176);
            this.Controls.Add(this.cbxGetNextDepthTop);
            this.Controls.Add(this.cbxGetLastDepthBot);
            this.Controls.Add(this.nTBXBotDepth);
            this.Controls.Add(this.nTBXTopDepth);
            this.Controls.Add(this.lblBot);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.cbbSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingSectionDataItemView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbbSelect;
        private controls.NumericTextBox nTBXBotDepth;
        private controls.NumericTextBox nTBXTopDepth;
        private System.Windows.Forms.Label lblBot;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.CheckBox cbxGetLastDepthBot;
        private System.Windows.Forms.CheckBox cbxGetNextDepthTop;

    }
}