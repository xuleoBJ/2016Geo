namespace DOGPlatform
{
    partial class FormCalArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalArea));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelDgvLine = new System.Windows.Forms.Button();
            this.btnCal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.dgv.Location = new System.Drawing.Point(12, 103);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(311, 437);
            this.dgv.TabIndex = 4;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 23);
            this.btnCopy.TabIndex = 21;
            this.btnCopy.Text = "粘贴";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelDgvLine
            // 
            this.btnDelDgvLine.Location = new System.Drawing.Point(123, 12);
            this.btnDelDgvLine.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelDgvLine.Name = "btnDelDgvLine";
            this.btnDelDgvLine.Size = new System.Drawing.Size(90, 23);
            this.btnDelDgvLine.TabIndex = 23;
            this.btnDelDgvLine.Text = "删除行";
            this.btnDelDgvLine.UseVisualStyleBackColor = true;
            this.btnDelDgvLine.Click += new System.EventHandler(this.btnDelDgvLine_Click);
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(233, 12);
            this.btnCal.Margin = new System.Windows.Forms.Padding(2);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(90, 23);
            this.btnCal.TabIndex = 24;
            this.btnCal.Text = "计算面积周长";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SimSun", 12F);
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 60);
            this.label1.TabIndex = 25;
            this.label1.Text = "提示：输入数据为坐标数据,数据应该按照顺或者逆时针方向采集";
            // 
            // FormCalArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 552);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.btnDelDgvLine);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalArea";
            this.Text = "计算面积周长";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelDgvLine;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.Label label1;

    }
}