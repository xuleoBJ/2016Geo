namespace DOGPlatform
{
    partial class FormSectionAddSymbol
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
            this.tbxBackText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxGetNextDepthTop = new System.Windows.Forms.CheckBox();
            this.cbxGetLastDepthBot = new System.Windows.Forms.CheckBox();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.lblBot = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(276, 328);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbxBackText);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbxGetNextDepthTop);
            this.tabPage1.Controls.Add(this.cbxGetLastDepthBot);
            this.tabPage1.Controls.Add(this.cbbType);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nTBXBotDepth);
            this.tabPage1.Controls.Add(this.nTBXTopDepth);
            this.tabPage1.Controls.Add(this.lblBot);
            this.tabPage1.Controls.Add(this.lblTop);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(268, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbxBackText
            // 
            this.tbxBackText.Location = new System.Drawing.Point(48, 136);
            this.tbxBackText.Multiline = true;
            this.tbxBackText.Name = "tbxBackText";
            this.tbxBackText.Size = new System.Drawing.Size(172, 54);
            this.tbxBackText.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 103;
            this.label4.Text = "备注";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxGetNextDepthTop
            // 
            this.cbxGetNextDepthTop.AutoSize = true;
            this.cbxGetNextDepthTop.Location = new System.Drawing.Point(136, 50);
            this.cbxGetNextDepthTop.Name = "cbxGetNextDepthTop";
            this.cbxGetNextDepthTop.Size = new System.Drawing.Size(84, 16);
            this.cbxGetNextDepthTop.TabIndex = 102;
            this.cbxGetNextDepthTop.Text = "连接下段顶";
            this.cbxGetNextDepthTop.UseVisualStyleBackColor = true;
            this.cbxGetNextDepthTop.CheckedChanged += new System.EventHandler(this.cbxGetNextDepthTop_CheckedChanged);
            // 
            // cbxGetLastDepthBot
            // 
            this.cbxGetLastDepthBot.AutoSize = true;
            this.cbxGetLastDepthBot.Location = new System.Drawing.Point(136, 14);
            this.cbxGetLastDepthBot.Name = "cbxGetLastDepthBot";
            this.cbxGetLastDepthBot.Size = new System.Drawing.Size(84, 16);
            this.cbxGetLastDepthBot.TabIndex = 101;
            this.cbxGetLastDepthBot.Text = "承接上段底";
            this.cbxGetLastDepthBot.UseVisualStyleBackColor = true;
            this.cbxGetLastDepthBot.CheckedChanged += new System.EventHandler(this.cbxGetLastDepthBot_CheckedChanged);
            // 
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Location = new System.Drawing.Point(48, 93);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(172, 20);
            this.cbbType.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 97;
            this.label2.Text = "类别";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 94;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nTBXBotDepth
            // 
            this.nTBXBotDepth.Location = new System.Drawing.Point(48, 51);
            this.nTBXBotDepth.Name = "nTBXBotDepth";
            this.nTBXBotDepth.Size = new System.Drawing.Size(73, 21);
            this.nTBXBotDepth.TabIndex = 93;
            this.nTBXBotDepth.Text = "100";
            // 
            // nTBXTopDepth
            // 
            this.nTBXTopDepth.Location = new System.Drawing.Point(48, 14);
            this.nTBXTopDepth.Name = "nTBXTopDepth";
            this.nTBXTopDepth.Size = new System.Drawing.Size(73, 21);
            this.nTBXTopDepth.TabIndex = 92;
            this.nTBXTopDepth.Text = "0";
            // 
            // lblBot
            // 
            this.lblBot.AutoSize = true;
            this.lblBot.Location = new System.Drawing.Point(19, 54);
            this.lblBot.Name = "lblBot";
            this.lblBot.Size = new System.Drawing.Size(29, 12);
            this.lblBot.TabIndex = 90;
            this.lblBot.Text = "底深";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(19, 18);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(29, 12);
            this.lblTop.TabIndex = 91;
            this.lblTop.Text = "顶深";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(145, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(21, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 87;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormSectionAddSymbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 328);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSectionAddSymbol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "符号设置";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbxGetNextDepthTop;
        private System.Windows.Forms.CheckBox cbxGetLastDepthBot;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private controls.NumericTextBox nTBXBotDepth;
        private controls.NumericTextBox nTBXTopDepth;
        private System.Windows.Forms.Label lblBot;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxBackText;
    }
}