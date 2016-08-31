namespace DigRobot
{
    partial class coordinateLocationForm
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
            this.tbxRealPositionY = new System.Windows.Forms.TextBox();
            this.tbxRealPositionX = new System.Windows.Forms.TextBox();
            this.tbxScreenPositionY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxScreenPositionX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(369, 77);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // btnSetSystem3PointOK
            // 
            this.btnSetSystem3PointOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSetSystem3PointOK.Location = new System.Drawing.Point(369, 29);
            this.btnSetSystem3PointOK.Name = "btnSetSystem3PointOK";
            this.btnSetSystem3PointOK.Size = new System.Drawing.Size(75, 23);
            this.btnSetSystem3PointOK.TabIndex = 2;
            this.btnSetSystem3PointOK.Text = "确定";
            this.btnSetSystem3PointOK.UseVisualStyleBackColor = true;
            this.btnSetSystem3PointOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxRealPositionY);
            this.groupBox1.Controls.Add(this.tbxRealPositionX);
            this.groupBox1.Controls.Add(this.tbxScreenPositionY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxScreenPositionX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 181);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置点作标";
            // 
            // tbxRealPositionY
            // 
            this.tbxRealPositionY.Location = new System.Drawing.Point(147, 63);
            this.tbxRealPositionY.Name = "tbxRealPositionY";
            this.tbxRealPositionY.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionY.TabIndex = 1;
            // 
            // tbxRealPositionX
            // 
            this.tbxRealPositionX.Location = new System.Drawing.Point(147, 26);
            this.tbxRealPositionX.Name = "tbxRealPositionX";
            this.tbxRealPositionX.Size = new System.Drawing.Size(120, 21);
            this.tbxRealPositionX.TabIndex = 0;
            // 
            // tbxScreenPositionY
            // 
            this.tbxScreenPositionY.Location = new System.Drawing.Point(147, 139);
            this.tbxScreenPositionY.Name = "tbxScreenPositionY";
            this.tbxScreenPositionY.ReadOnly = true;
            this.tbxScreenPositionY.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionY.TabIndex = 6;
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
            // tbxScreenPositionX
            // 
            this.tbxScreenPositionX.Location = new System.Drawing.Point(147, 103);
            this.tbxScreenPositionX.Name = "tbxScreenPositionX";
            this.tbxScreenPositionX.ReadOnly = true;
            this.tbxScreenPositionX.Size = new System.Drawing.Size(120, 21);
            this.tbxScreenPositionX.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "屏幕X轴坐标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "屏幕Y轴坐标";
            // 
            // coordinateLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 202);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.btnSetSystem3PointOK);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "coordinateLocationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "坐标系设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button btnSetSystem3PointOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxRealPositionY;
        private System.Windows.Forms.TextBox tbxRealPositionX;
        private System.Windows.Forms.TextBox tbxScreenPositionY;
        private System.Windows.Forms.TextBox tbxScreenPositionX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}