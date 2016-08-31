namespace DOGPlatform
{
    partial class FormSectionAddNewDataItem
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
            this.cbbDirType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.lblBot = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.cbbItemSelect = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblProperty = new System.Windows.Forms.Label();
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
            this.tabControl1.Size = new System.Drawing.Size(313, 213);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbbDirType);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nTBXBotDepth);
            this.tabPage1.Controls.Add(this.nTBXTopDepth);
            this.tabPage1.Controls.Add(this.lblBot);
            this.tabPage1.Controls.Add(this.lblTop);
            this.tabPage1.Controls.Add(this.cbbItemSelect);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Controls.Add(this.lblProperty);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(305, 187);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbbDirType
            // 
            this.cbbDirType.FormattingEnabled = true;
            this.cbbDirType.Location = new System.Drawing.Point(48, 48);
            this.cbbDirType.Name = "cbbDirType";
            this.cbbDirType.Size = new System.Drawing.Size(231, 20);
            this.cbbDirType.TabIndex = 95;
            this.cbbDirType.SelectedIndexChanged += new System.EventHandler(this.cbbDirType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 94;
            this.label1.Text = "类别";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nTBXBotDepth
            // 
            this.nTBXBotDepth.Location = new System.Drawing.Point(192, 14);
            this.nTBXBotDepth.Name = "nTBXBotDepth";
            this.nTBXBotDepth.Size = new System.Drawing.Size(87, 21);
            this.nTBXBotDepth.TabIndex = 93;
            this.nTBXBotDepth.Text = "100";
            // 
            // nTBXTopDepth
            // 
            this.nTBXTopDepth.Location = new System.Drawing.Point(48, 14);
            this.nTBXTopDepth.Name = "nTBXTopDepth";
            this.nTBXTopDepth.Size = new System.Drawing.Size(87, 21);
            this.nTBXTopDepth.TabIndex = 92;
            this.nTBXTopDepth.Text = "0";
            // 
            // lblBot
            // 
            this.lblBot.AutoSize = true;
            this.lblBot.Location = new System.Drawing.Point(157, 18);
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
            // cbbItemSelect
            // 
            this.cbbItemSelect.FormattingEnabled = true;
            this.cbbItemSelect.Location = new System.Drawing.Point(48, 81);
            this.cbbItemSelect.Name = "cbbItemSelect";
            this.cbbItemSelect.Size = new System.Drawing.Size(231, 20);
            this.cbbItemSelect.TabIndex = 89;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(159, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(48, 131);
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
            this.lblProperty.Location = new System.Drawing.Point(19, 83);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(29, 12);
            this.lblProperty.TabIndex = 86;
            this.lblProperty.Text = "名称";
            this.lblProperty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSectionAddNewDataItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 213);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSectionAddNewDataItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加数据项";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private controls.NumericTextBox nTBXBotDepth;
        private controls.NumericTextBox nTBXTopDepth;
        private System.Windows.Forms.Label lblBot;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.ComboBox cbbItemSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cbbDirType;
        private System.Windows.Forms.Label label1;
    }
}