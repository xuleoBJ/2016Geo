namespace DOGPlatform
{
    partial class FormSettingSectionText
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
            this.tbxStext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxBackColor = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.cbxGetNextDepthTop = new System.Windows.Forms.CheckBox();
            this.cbxGetLastDepthBot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(195, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(90, 288);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblBot
            // 
            this.lblBot.AutoSize = true;
            this.lblBot.Location = new System.Drawing.Point(12, 75);
            this.lblBot.Name = "lblBot";
            this.lblBot.Size = new System.Drawing.Size(29, 12);
            this.lblBot.TabIndex = 82;
            this.lblBot.Text = "底深";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(12, 35);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(29, 12);
            this.lblTop.TabIndex = 83;
            this.lblTop.Text = "顶深";
            // 
            // tbxStext
            // 
            this.tbxStext.Location = new System.Drawing.Point(40, 151);
            this.tbxStext.Multiline = true;
            this.tbxStext.Name = "tbxStext";
            this.tbxStext.Size = new System.Drawing.Size(314, 115);
            this.tbxStext.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 87;
            this.label1.Text = "文本";
            // 
            // tbxBackColor
            // 
            this.tbxBackColor.Location = new System.Drawing.Point(90, 113);
            this.tbxBackColor.MaxLength = 7;
            this.tbxBackColor.Name = "tbxBackColor";
            this.tbxBackColor.Size = new System.Drawing.Size(81, 21);
            this.tbxBackColor.TabIndex = 88;
            this.tbxBackColor.Text = "#FFFFFF";
            this.tbxBackColor.TextChanged += new System.EventHandler(this.tbxBackColor_TextChanged);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(12, 112);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 89;
            this.btnColor.Text = "背景颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // nTBXBotDepth
            // 
            this.nTBXBotDepth.Location = new System.Drawing.Point(44, 71);
            this.nTBXBotDepth.Name = "nTBXBotDepth";
            this.nTBXBotDepth.Size = new System.Drawing.Size(79, 21);
            this.nTBXBotDepth.TabIndex = 85;
            // 
            // nTBXTopDepth
            // 
            this.nTBXTopDepth.Location = new System.Drawing.Point(44, 31);
            this.nTBXTopDepth.Name = "nTBXTopDepth";
            this.nTBXTopDepth.Size = new System.Drawing.Size(79, 21);
            this.nTBXTopDepth.TabIndex = 84;
            // 
            // cbxGetNextDepthTop
            // 
            this.cbxGetNextDepthTop.AutoSize = true;
            this.cbxGetNextDepthTop.Location = new System.Drawing.Point(149, 69);
            this.cbxGetNextDepthTop.Name = "cbxGetNextDepthTop";
            this.cbxGetNextDepthTop.Size = new System.Drawing.Size(84, 16);
            this.cbxGetNextDepthTop.TabIndex = 91;
            this.cbxGetNextDepthTop.Text = "连接下段顶";
            this.cbxGetNextDepthTop.UseVisualStyleBackColor = true;
            this.cbxGetNextDepthTop.CheckedChanged += new System.EventHandler(this.cbxGetNextDepthTop_CheckedChanged);
            // 
            // cbxGetLastDepthBot
            // 
            this.cbxGetLastDepthBot.AutoSize = true;
            this.cbxGetLastDepthBot.Location = new System.Drawing.Point(149, 33);
            this.cbxGetLastDepthBot.Name = "cbxGetLastDepthBot";
            this.cbxGetLastDepthBot.Size = new System.Drawing.Size(84, 16);
            this.cbxGetLastDepthBot.TabIndex = 90;
            this.cbxGetLastDepthBot.Text = "承接上段底";
            this.cbxGetLastDepthBot.UseVisualStyleBackColor = true;
            this.cbxGetLastDepthBot.CheckedChanged += new System.EventHandler(this.cbxGetLastDepthBot_CheckedChanged);
            // 
            // FormSettingSectionText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 320);
            this.Controls.Add(this.cbxGetNextDepthTop);
            this.Controls.Add(this.cbxGetLastDepthBot);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.tbxBackColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxStext);
            this.Controls.Add(this.nTBXBotDepth);
            this.Controls.Add(this.nTBXTopDepth);
            this.Controls.Add(this.lblBot);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettingSectionText";
            this.Text = "文本设置";
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
        private System.Windows.Forms.TextBox tbxStext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxBackColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.CheckBox cbxGetNextDepthTop;
        private System.Windows.Forms.CheckBox cbxGetLastDepthBot;
    }
}