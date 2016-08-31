namespace DOGPlatform
{
    partial class FormSectionAddItemLitho
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
            this.cbxGetNextDepthTop = new System.Windows.Forms.CheckBox();
            this.cbxGetLastDepthBot = new System.Windows.Forms.CheckBox();
            this.nUDGrainSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.cbbColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.lblBot = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.cbbItemLitho = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblProperty = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGrainSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(255, 290);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxGetNextDepthTop);
            this.tabPage1.Controls.Add(this.cbxGetLastDepthBot);
            this.tabPage1.Controls.Add(this.nUDGrainSize);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbbType);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnColor);
            this.tabPage1.Controls.Add(this.cbbColor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nTBXBotDepth);
            this.tabPage1.Controls.Add(this.nTBXTopDepth);
            this.tabPage1.Controls.Add(this.lblBot);
            this.tabPage1.Controls.Add(this.lblTop);
            this.tabPage1.Controls.Add(this.cbbItemLitho);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Controls.Add(this.lblProperty);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(247, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // nUDGrainSize
            // 
            this.nUDGrainSize.AllowDrop = true;
            this.nUDGrainSize.DecimalPlaces = 2;
            this.nUDGrainSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUDGrainSize.Location = new System.Drawing.Point(182, 172);
            this.nUDGrainSize.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDGrainSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDGrainSize.Name = "nUDGrainSize";
            this.nUDGrainSize.Size = new System.Drawing.Size(50, 21);
            this.nUDGrainSize.TabIndex = 100;
            this.nUDGrainSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 99;
            this.label3.Text = "粒径";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbType
            // 
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Location = new System.Drawing.Point(48, 93);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(172, 20);
            this.cbbType.TabIndex = 98;
            this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 97;
            this.label2.Text = "品类";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(3, 168);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(52, 23);
            this.btnColor.TabIndex = 96;
            this.btnColor.Text = "颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // cbbColor
            // 
            this.cbbColor.FormattingEnabled = true;
            this.cbbColor.Location = new System.Drawing.Point(61, 170);
            this.cbbColor.Name = "cbbColor";
            this.cbbColor.Size = new System.Drawing.Size(80, 20);
            this.cbbColor.TabIndex = 95;
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
            // cbbItemLitho
            // 
            this.cbbItemLitho.FormattingEnabled = true;
            this.cbbItemLitho.Location = new System.Drawing.Point(48, 127);
            this.cbbItemLitho.Name = "cbbItemLitho";
            this.cbbItemLitho.Size = new System.Drawing.Size(172, 20);
            this.cbbItemLitho.TabIndex = 89;
            this.cbbItemLitho.SelectedIndexChanged += new System.EventHandler(this.cbbItemLitho_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(134, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(27, 217);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 87;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Location = new System.Drawing.Point(19, 130);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(29, 12);
            this.lblProperty.TabIndex = 86;
            this.lblProperty.Text = "名称";
            this.lblProperty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSectionAddItemLitho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 290);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSectionAddItemLitho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "岩性设置";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDGrainSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private controls.NumericTextBox nTBXBotDepth;
        private controls.NumericTextBox nTBXTopDepth;
        private System.Windows.Forms.Label lblBot;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.ComboBox cbbItemLitho;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cbbColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUDGrainSize;
        private System.Windows.Forms.CheckBox cbxGetNextDepthTop;
        private System.Windows.Forms.CheckBox cbxGetLastDepthBot;
    }
}