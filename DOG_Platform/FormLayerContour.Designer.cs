namespace DOGPlatform
{
    partial class FormLayerContour
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
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.dgvCoutour = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.cbxAddCoutourLine = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoutour)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(226, 156);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 71;
            this.button5.Text = "增加图层";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(91, 157);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(129, 21);
            this.textBox2.TabIndex = 69;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(44, 161);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(41, 12);
            this.label40.TabIndex = 70;
            this.label40.Text = "图层名";
            // 
            // dgvCoutour
            // 
            this.dgvCoutour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoutour.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvCoutour.Location = new System.Drawing.Point(338, 29);
            this.dgvCoutour.Name = "dgvCoutour";
            this.dgvCoutour.RowTemplate.Height = 23;
            this.dgvCoutour.Size = new System.Drawing.Size(311, 466);
            this.dgvCoutour.TabIndex = 68;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "X";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Y";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Z";
            this.Column5.Name = "Column5";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.numericUpDown3);
            this.groupBox9.Controls.Add(this.comboBox6);
            this.groupBox9.Controls.Add(this.label46);
            this.groupBox9.Controls.Add(this.label48);
            this.groupBox9.Location = new System.Drawing.Point(47, 58);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(240, 68);
            this.groupBox9.TabIndex = 67;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "线型设置";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown3.Location = new System.Drawing.Point(157, 20);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(57, 21);
            this.numericUpDown3.TabIndex = 17;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBox6
            // 
            this.comboBox6.BackColor = System.Drawing.Color.Red;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(46, 21);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(61, 20);
            this.comboBox6.TabIndex = 10;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(7, 24);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(29, 12);
            this.label46.TabIndex = 12;
            this.label46.Text = "颜色";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(122, 25);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(29, 12);
            this.label48.TabIndex = 12;
            this.label48.Text = "线宽";
            // 
            // cbxAddCoutourLine
            // 
            this.cbxAddCoutourLine.AutoSize = true;
            this.cbxAddCoutourLine.Location = new System.Drawing.Point(47, 29);
            this.cbxAddCoutourLine.Name = "cbxAddCoutourLine";
            this.cbxAddCoutourLine.Size = new System.Drawing.Size(60, 16);
            this.cbxAddCoutourLine.TabIndex = 66;
            this.cbxAddCoutourLine.Text = "等值线";
            this.cbxAddCoutourLine.UseVisualStyleBackColor = true;
            // 
            // FormLayerContour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 657);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.dgvCoutour);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.cbxAddCoutourLine);
            this.Name = "FormLayerContour";
            this.Text = "等值线";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoutour)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DataGridView dgvCoutour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.CheckBox cbxAddCoutourLine;

    }
}