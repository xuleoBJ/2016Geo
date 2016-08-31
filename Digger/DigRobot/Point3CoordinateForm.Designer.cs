namespace DigRobot
{
    partial class _3PointCoordinateForm
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
            this.Cancel = new System.Windows.Forms.Button();
            this.btnSetSystem3PointOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxRealPositionY1 = new System.Windows.Forms.TextBox();
            this.tbxRealPositionX1 = new System.Windows.Forms.TextBox();
            this.tbxScreenPositionY1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxScreenPositionX1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxRealPositionY2 = new System.Windows.Forms.TextBox();
            this.tbxRealPositionX2 = new System.Windows.Forms.TextBox();
            this.tbxScreenPositionY2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxScreenPositionX2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbxRealPositionY3 = new System.Windows.Forms.TextBox();
            this.tbxRealPositionX3 = new System.Windows.Forms.TextBox();
            this.tbxScreenPositionY3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxScreenPositionX3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(290, 426);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // btnSetSystem3PointOK
            // 
            this.btnSetSystem3PointOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSetSystem3PointOK.Location = new System.Drawing.Point(159, 426);
            this.btnSetSystem3PointOK.Name = "btnSetSystem3PointOK";
            this.btnSetSystem3PointOK.Size = new System.Drawing.Size(75, 23);
            this.btnSetSystem3PointOK.TabIndex = 4;
            this.btnSetSystem3PointOK.Text = "确定";
            this.btnSetSystem3PointOK.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxRealPositionY1);
            this.groupBox1.Controls.Add(this.tbxRealPositionX1);
            this.groupBox1.Controls.Add(this.tbxScreenPositionY1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxScreenPositionX1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 105);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置作标定位点1";
            // 
            // tbxRealPositionY1
            // 
            this.tbxRealPositionY1.Location = new System.Drawing.Point(111, 61);
            this.tbxRealPositionY1.Name = "tbxRealPositionY1";
            this.tbxRealPositionY1.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionY1.TabIndex = 1;
            // 
            // tbxRealPositionX1
            // 
            this.tbxRealPositionX1.Location = new System.Drawing.Point(111, 24);
            this.tbxRealPositionX1.Name = "tbxRealPositionX1";
            this.tbxRealPositionX1.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionX1.TabIndex = 0;
            // 
            // tbxScreenPositionY1
            // 
            this.tbxScreenPositionY1.Location = new System.Drawing.Point(314, 61);
            this.tbxScreenPositionY1.Name = "tbxScreenPositionY1";
            this.tbxScreenPositionY1.ReadOnly = true;
            this.tbxScreenPositionY1.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionY1.TabIndex = 6;
            this.tbxScreenPositionY1.TextChanged += new System.EventHandler(this.tbxScreenPositionY_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "实际Y轴坐标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "实际X轴坐标";
            // 
            // tbxScreenPositionX1
            // 
            this.tbxScreenPositionX1.Location = new System.Drawing.Point(314, 25);
            this.tbxScreenPositionX1.Name = "tbxScreenPositionX1";
            this.tbxScreenPositionX1.ReadOnly = true;
            this.tbxScreenPositionX1.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionX1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "屏幕X轴坐标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "屏幕Y轴坐标";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxRealPositionY2);
            this.groupBox2.Controls.Add(this.tbxRealPositionX2);
            this.groupBox2.Controls.Add(this.tbxScreenPositionY2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbxScreenPositionX2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 105);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置作标定位点2";
            // 
            // tbxRealPositionY2
            // 
            this.tbxRealPositionY2.Location = new System.Drawing.Point(111, 61);
            this.tbxRealPositionY2.Name = "tbxRealPositionY2";
            this.tbxRealPositionY2.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionY2.TabIndex = 1;
            // 
            // tbxRealPositionX2
            // 
            this.tbxRealPositionX2.Location = new System.Drawing.Point(111, 24);
            this.tbxRealPositionX2.Name = "tbxRealPositionX2";
            this.tbxRealPositionX2.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionX2.TabIndex = 0;
            // 
            // tbxScreenPositionY2
            // 
            this.tbxScreenPositionY2.Location = new System.Drawing.Point(314, 61);
            this.tbxScreenPositionY2.Name = "tbxScreenPositionY2";
            this.tbxScreenPositionY2.ReadOnly = true;
            this.tbxScreenPositionY2.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionY2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "实际Y轴坐标";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "实际X轴坐标";
            // 
            // tbxScreenPositionX2
            // 
            this.tbxScreenPositionX2.Location = new System.Drawing.Point(314, 25);
            this.tbxScreenPositionX2.Name = "tbxScreenPositionX2";
            this.tbxScreenPositionX2.ReadOnly = true;
            this.tbxScreenPositionX2.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionX2.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "屏幕X轴坐标";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(239, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "屏幕Y轴坐标";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbxRealPositionY3);
            this.groupBox3.Controls.Add(this.tbxRealPositionX3);
            this.groupBox3.Controls.Add(this.tbxScreenPositionY3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tbxScreenPositionX3);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(460, 105);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "设置作标定位点3";
            // 
            // tbxRealPositionY3
            // 
            this.tbxRealPositionY3.Location = new System.Drawing.Point(111, 61);
            this.tbxRealPositionY3.Name = "tbxRealPositionY3";
            this.tbxRealPositionY3.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionY3.TabIndex = 1;
            // 
            // tbxRealPositionX3
            // 
            this.tbxRealPositionX3.Location = new System.Drawing.Point(111, 24);
            this.tbxRealPositionX3.Name = "tbxRealPositionX3";
            this.tbxRealPositionX3.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionX3.TabIndex = 0;
            // 
            // tbxScreenPositionY3
            // 
            this.tbxScreenPositionY3.Location = new System.Drawing.Point(314, 61);
            this.tbxScreenPositionY3.Name = "tbxScreenPositionY3";
            this.tbxScreenPositionY3.ReadOnly = true;
            this.tbxScreenPositionY3.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionY3.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "实际Y轴坐标";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "实际X轴坐标";
            // 
            // tbxScreenPositionX3
            // 
            this.tbxScreenPositionX3.Location = new System.Drawing.Point(314, 25);
            this.tbxScreenPositionX3.Name = "tbxScreenPositionX3";
            this.tbxScreenPositionX3.ReadOnly = true;
            this.tbxScreenPositionX3.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionX3.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(239, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "屏幕X轴坐标";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(239, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "屏幕Y轴坐标";
            // 
            // _3PointCoordinateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 479);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.btnSetSystem3PointOK);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "_3PointCoordinateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置坐标定位点";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button btnSetSystem3PointOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxRealPositionY1;
        private System.Windows.Forms.TextBox tbxRealPositionX1;
        private System.Windows.Forms.TextBox tbxScreenPositionY1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxScreenPositionX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxRealPositionY2;
        private System.Windows.Forms.TextBox tbxRealPositionX2;
        private System.Windows.Forms.TextBox tbxScreenPositionY2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxScreenPositionX2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbxRealPositionY3;
        private System.Windows.Forms.TextBox tbxRealPositionX3;
        private System.Windows.Forms.TextBox tbxScreenPositionY3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxScreenPositionX3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}