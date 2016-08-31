namespace DOGPlatform
{
    partial class FormCalWellDistance
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
            this.label12 = new System.Windows.Forms.Label();
            this.cbbJH = new System.Windows.Forms.ComboBox();
            this.btnCalResult = new System.Windows.Forms.Button();
            this.dgvWellDistance = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbXCM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxJH = new System.Windows.Forms.ListBox();
            this.btnSelectNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "井号";
            // 
            // cbbJH
            // 
            this.cbbJH.FormattingEnabled = true;
            this.cbbJH.Location = new System.Drawing.Point(14, 25);
            this.cbbJH.Name = "cbbJH";
            this.cbbJH.Size = new System.Drawing.Size(99, 20);
            this.cbbJH.TabIndex = 28;
            // 
            // btnCalResult
            // 
            this.btnCalResult.Location = new System.Drawing.Point(162, 4);
            this.btnCalResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalResult.Name = "btnCalResult";
            this.btnCalResult.Size = new System.Drawing.Size(95, 28);
            this.btnCalResult.TabIndex = 27;
            this.btnCalResult.Text = "计算";
            this.btnCalResult.UseVisualStyleBackColor = true;
            this.btnCalResult.Click += new System.EventHandler(this.btnCalResult_Click);
            // 
            // dgvWellDistance
            // 
            this.dgvWellDistance.AllowUserToOrderColumns = true;
            this.dgvWellDistance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWellDistance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvWellDistance.Location = new System.Drawing.Point(162, 37);
            this.dgvWellDistance.Name = "dgvWellDistance";
            this.dgvWellDistance.RowTemplate.Height = 23;
            this.dgvWellDistance.Size = new System.Drawing.Size(493, 388);
            this.dgvWellDistance.TabIndex = 35;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "小层名";
            this.Column4.Name = "Column4";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "基准井";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "对应井";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "井距(m)";
            this.Column3.Name = "Column3";
            // 
            // cbbXCM
            // 
            this.cbbXCM.FormattingEnabled = true;
            this.cbbXCM.Location = new System.Drawing.Point(14, 63);
            this.cbbXCM.Name = "cbbXCM";
            this.cbbXCM.Size = new System.Drawing.Size(99, 20);
            this.cbbXCM.TabIndex = 31;
            this.cbbXCM.SelectedIndexChanged += new System.EventHandler(this.cbbXCM_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "小层名";
            // 
            // listBoxJH
            // 
            this.listBoxJH.FormattingEnabled = true;
            this.listBoxJH.ItemHeight = 12;
            this.listBoxJH.Location = new System.Drawing.Point(11, 105);
            this.listBoxJH.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxJH.Name = "listBoxJH";
            this.listBoxJH.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxJH.Size = new System.Drawing.Size(127, 292);
            this.listBoxJH.TabIndex = 23;
            // 
            // btnSelectNo
            // 
            this.btnSelectNo.Location = new System.Drawing.Point(14, 402);
            this.btnSelectNo.Name = "btnSelectNo";
            this.btnSelectNo.Size = new System.Drawing.Size(66, 23);
            this.btnSelectNo.TabIndex = 37;
            this.btnSelectNo.Text = "全不选";
            this.btnSelectNo.UseVisualStyleBackColor = true;
            this.btnSelectNo.Click += new System.EventHandler(this.btnSelectNo_Click);
            // 
            // FormCalWellDistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 470);
            this.Controls.Add(this.btnSelectNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvWellDistance);
            this.Controls.Add(this.cbbXCM);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbbJH);
            this.Controls.Add(this.btnCalResult);
            this.Controls.Add(this.listBoxJH);
            this.Name = "FormCalWellDistance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "井距计算";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbJH;
        private System.Windows.Forms.Button btnCalResult;
        private System.Windows.Forms.DataGridView dgvWellDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox cbbXCM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxJH;
        private System.Windows.Forms.Button btnSelectNo;
    }
}