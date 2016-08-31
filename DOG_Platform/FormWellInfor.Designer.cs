namespace DOGPlatform
{
    partial class FormWellInfor
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxWellName = new System.Windows.Forms.TextBox();
            this.tbxDX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxKB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbWellType = new System.Windows.Forms.ComboBox();
            this.btnAddWell = new System.Windows.Forms.Button();
            this.tbxWellBase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "井名";
            // 
            // tbxWellName
            // 
            this.tbxWellName.Location = new System.Drawing.Point(104, 33);
            this.tbxWellName.Name = "tbxWellName";
            this.tbxWellName.Size = new System.Drawing.Size(133, 21);
            this.tbxWellName.TabIndex = 1;
            this.tbxWellName.Text = "NewWell1";
            // 
            // tbxDX
            // 
            this.tbxDX.Location = new System.Drawing.Point(104, 67);
            this.tbxDX.Name = "tbxDX";
            this.tbxDX.Size = new System.Drawing.Size(133, 21);
            this.tbxDX.TabIndex = 3;
            this.tbxDX.Text = "0.0";
            this.tbxDX.TextChanged += new System.EventHandler(this.tbxDX_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // tbxDY
            // 
            this.tbxDY.Location = new System.Drawing.Point(104, 101);
            this.tbxDY.Name = "tbxDY";
            this.tbxDY.Size = new System.Drawing.Size(133, 21);
            this.tbxDY.TabIndex = 5;
            this.tbxDY.Text = "0.0";
            this.tbxDY.TextChanged += new System.EventHandler(this.tbxDY_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y";
            // 
            // tbxKB
            // 
            this.tbxKB.Location = new System.Drawing.Point(104, 137);
            this.tbxKB.Name = "tbxKB";
            this.tbxKB.Size = new System.Drawing.Size(133, 21);
            this.tbxKB.TabIndex = 7;
            this.tbxKB.Text = "0.0";
            this.tbxKB.TextChanged += new System.EventHandler(this.tbxKB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "海拔";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "井别";
            // 
            // cbbWellType
            // 
            this.cbbWellType.FormattingEnabled = true;
            this.cbbWellType.Location = new System.Drawing.Point(104, 176);
            this.cbbWellType.Name = "cbbWellType";
            this.cbbWellType.Size = new System.Drawing.Size(133, 20);
            this.cbbWellType.TabIndex = 9;
            // 
            // btnAddWell
            // 
            this.btnAddWell.Location = new System.Drawing.Point(128, 286);
            this.btnAddWell.Name = "btnAddWell";
            this.btnAddWell.Size = new System.Drawing.Size(75, 23);
            this.btnAddWell.TabIndex = 10;
            this.btnAddWell.Text = "入库";
            this.btnAddWell.UseVisualStyleBackColor = true;
            this.btnAddWell.Click += new System.EventHandler(this.btnAddWell_Click);
            // 
            // tbxWellBase
            // 
            this.tbxWellBase.Location = new System.Drawing.Point(104, 210);
            this.tbxWellBase.Name = "tbxWellBase";
            this.tbxWellBase.Size = new System.Drawing.Size(133, 21);
            this.tbxWellBase.TabIndex = 12;
            this.tbxWellBase.Text = "0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "井底深度";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxWellBase);
            this.groupBox1.Controls.Add(this.tbxWellName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbWellType);
            this.groupBox1.Controls.Add(this.tbxDX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxKB);
            this.groupBox1.Controls.Add(this.tbxDY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(33, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 246);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新井信息输入";
            // 
            // FormAddNewWell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 344);
            this.Controls.Add(this.btnAddWell);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddNewWell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "井信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxWellName;
        private System.Windows.Forms.TextBox tbxDX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxKB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbWellType;
        private System.Windows.Forms.Button btnAddWell;
        private System.Windows.Forms.TextBox tbxWellBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}