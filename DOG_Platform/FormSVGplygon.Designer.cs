namespace DOGPlatform
{
    partial class FormSVGplygon
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
            this.tbgSet = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSeleclFillColor = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxFillColor = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.tbxLogColor = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.nUDLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbLineType = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tbgSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbgSet);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 220);
            this.tabControl1.TabIndex = 68;
            // 
            // tbgSet
            // 
            this.tbgSet.Controls.Add(this.btnCancel);
            this.tbgSet.Controls.Add(this.btnSeleclFillColor);
            this.tbgSet.Controls.Add(this.btnOK);
            this.tbgSet.Controls.Add(this.tbxFillColor);
            this.tbgSet.Controls.Add(this.btnColor);
            this.tbgSet.Controls.Add(this.tbxLogColor);
            this.tbgSet.Controls.Add(this.label42);
            this.tbgSet.Controls.Add(this.nUDLineWidth);
            this.tbgSet.Controls.Add(this.label1);
            this.tbgSet.Controls.Add(this.cbbLineType);
            this.tbgSet.Location = new System.Drawing.Point(4, 22);
            this.tbgSet.Name = "tbgSet";
            this.tbgSet.Padding = new System.Windows.Forms.Padding(3);
            this.tbgSet.Size = new System.Drawing.Size(340, 194);
            this.tbgSet.TabIndex = 0;
            this.tbgSet.Text = "设置";
            this.tbgSet.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(181, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSeleclFillColor
            // 
            this.btnSeleclFillColor.Location = new System.Drawing.Point(137, 72);
            this.btnSeleclFillColor.Name = "btnSeleclFillColor";
            this.btnSeleclFillColor.Size = new System.Drawing.Size(75, 23);
            this.btnSeleclFillColor.TabIndex = 100;
            this.btnSeleclFillColor.Text = "填充颜色";
            this.btnSeleclFillColor.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(77, 126);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxFillColor
            // 
            this.tbxFillColor.Location = new System.Drawing.Point(222, 73);
            this.tbxFillColor.MaxLength = 7;
            this.tbxFillColor.Name = "tbxFillColor";
            this.tbxFillColor.Size = new System.Drawing.Size(61, 21);
            this.tbxFillColor.TabIndex = 99;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(137, 26);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(73, 23);
            this.btnColor.TabIndex = 91;
            this.btnColor.Text = "曲线颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // tbxLogColor
            // 
            this.tbxLogColor.Location = new System.Drawing.Point(222, 27);
            this.tbxLogColor.MaxLength = 7;
            this.tbxLogColor.Name = "tbxLogColor";
            this.tbxLogColor.Size = new System.Drawing.Size(61, 21);
            this.tbxLogColor.TabIndex = 90;
            this.tbxLogColor.Text = "#000000";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(16, 76);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 12);
            this.label42.TabIndex = 33;
            this.label42.Text = "曲线宽度";
            // 
            // nUDLineWidth
            // 
            this.nUDLineWidth.AllowDrop = true;
            this.nUDLineWidth.DecimalPlaces = 1;
            this.nUDLineWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDLineWidth.Location = new System.Drawing.Point(78, 72);
            this.nUDLineWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDLineWidth.Name = "nUDLineWidth";
            this.nUDLineWidth.Size = new System.Drawing.Size(43, 21);
            this.nUDLineWidth.TabIndex = 34;
            this.nUDLineWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "线型";
            // 
            // cbbLineType
            // 
            this.cbbLineType.BackColor = System.Drawing.Color.White;
            this.cbbLineType.FormattingEnabled = true;
            this.cbbLineType.Items.AddRange(new object[] {
            "实线",
            "----",
            " - - ",
            "-.-."});
            this.cbbLineType.Location = new System.Drawing.Point(60, 27);
            this.cbbLineType.Name = "cbbLineType";
            this.cbbLineType.Size = new System.Drawing.Size(61, 20);
            this.cbbLineType.TabIndex = 72;
            this.cbbLineType.Text = "实线";
            // 
            // FormItemAppearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 220);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormItemAppearance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "外观设置";
            this.tabControl1.ResumeLayout(false);
            this.tbgSet.ResumeLayout(false);
            this.tbgSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgSet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSeleclFillColor;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxFillColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox tbxLogColor;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.NumericUpDown nUDLineWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbLineType;
    }
}