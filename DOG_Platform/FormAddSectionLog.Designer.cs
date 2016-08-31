namespace DOGPlatform
{
    partial class FormAddSectionLog
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
            this.tpgInfor = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddLog = new System.Windows.Forms.Button();
            this.cbbLog = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.tbxJH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.nUDLogRightValue = new System.Windows.Forms.NumericUpDown();
            this.nUDLogLeftValue = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbLogColor = new System.Windows.Forms.ComboBox();
            this.tpgInfor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLogRightValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLogLeftValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tpgInfor
            // 
            this.tpgInfor.Controls.Add(this.groupBox1);
            this.tpgInfor.Location = new System.Drawing.Point(4, 22);
            this.tpgInfor.Name = "tpgInfor";
            this.tpgInfor.Padding = new System.Windows.Forms.Padding(3);
            this.tpgInfor.Size = new System.Drawing.Size(534, 191);
            this.tpgInfor.TabIndex = 0;
            this.tpgInfor.Text = "增加曲线";
            this.tpgInfor.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nUDLogRightValue);
            this.groupBox1.Controls.Add(this.nUDLogLeftValue);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbbLogColor);
            this.groupBox1.Controls.Add(this.btnAddLog);
            this.groupBox1.Controls.Add(this.cbbLog);
            this.groupBox1.Controls.Add(this.label64);
            this.groupBox1.Controls.Add(this.tbxJH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(21, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 139);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // btnAddLog
            // 
            this.btnAddLog.Location = new System.Drawing.Point(323, 75);
            this.btnAddLog.Name = "btnAddLog";
            this.btnAddLog.Size = new System.Drawing.Size(73, 23);
            this.btnAddLog.TabIndex = 84;
            this.btnAddLog.Text = "增加曲线";
            this.btnAddLog.UseVisualStyleBackColor = true;
            this.btnAddLog.Click += new System.EventHandler(this.btnAddLog_Click);
            // 
            // cbbLog
            // 
            this.cbbLog.BackColor = System.Drawing.SystemColors.Window;
            this.cbbLog.FormattingEnabled = true;
            this.cbbLog.Location = new System.Drawing.Point(183, 31);
            this.cbbLog.Name = "cbbLog";
            this.cbbLog.Size = new System.Drawing.Size(79, 20);
            this.cbbLog.TabIndex = 83;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(136, 34);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(41, 12);
            this.label64.TabIndex = 77;
            this.label64.Text = "曲线名";
            // 
            // tbxJH
            // 
            this.tbxJH.Location = new System.Drawing.Point(56, 32);
            this.tbxJH.Name = "tbxJH";
            this.tbxJH.Size = new System.Drawing.Size(70, 21);
            this.tbxJH.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "井名";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgInfor);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 217);
            this.tabControl1.TabIndex = 5;
            // 
            // nUDLogRightValue
            // 
            this.nUDLogRightValue.AllowDrop = true;
            this.nUDLogRightValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDLogRightValue.Location = new System.Drawing.Point(234, 75);
            this.nUDLogRightValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDLogRightValue.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nUDLogRightValue.Name = "nUDLogRightValue";
            this.nUDLogRightValue.Size = new System.Drawing.Size(40, 21);
            this.nUDLogRightValue.TabIndex = 89;
            this.nUDLogRightValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nUDLogLeftValue
            // 
            this.nUDLogLeftValue.AllowDrop = true;
            this.nUDLogLeftValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDLogLeftValue.Location = new System.Drawing.Point(154, 74);
            this.nUDLogLeftValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDLogLeftValue.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nUDLogLeftValue.Name = "nUDLogLeftValue";
            this.nUDLogLeftValue.Size = new System.Drawing.Size(40, 21);
            this.nUDLogLeftValue.TabIndex = 90;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(200, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 88;
            this.label22.Text = "右值";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(124, 79);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 87;
            this.label21.Text = "左值";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 86;
            this.label6.Text = "颜色";
            // 
            // cbbLogColor
            // 
            this.cbbLogColor.BackColor = System.Drawing.Color.Blue;
            this.cbbLogColor.FormattingEnabled = true;
            this.cbbLogColor.Location = new System.Drawing.Point(56, 75);
            this.cbbLogColor.Name = "cbbLogColor";
            this.cbbLogColor.Size = new System.Drawing.Size(61, 20);
            this.cbbLogColor.TabIndex = 85;
            this.cbbLogColor.Click += new System.EventHandler(this.cbbLogColor_Click);
            // 
            // FormAddSectionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 217);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormAddSectionLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddSectionLog";
            this.tpgInfor.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDLogRightValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLogLeftValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpgInfor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbLog;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox tbxJH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnAddLog;
        private System.Windows.Forms.NumericUpDown nUDLogRightValue;
        private System.Windows.Forms.NumericUpDown nUDLogLeftValue;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbLogColor;
    }
}