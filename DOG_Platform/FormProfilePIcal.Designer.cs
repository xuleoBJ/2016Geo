namespace DOGPlatform
{
    partial class FormProfilePIcal
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tbcAdjustProfile = new System.Windows.Forms.TabControl();
            this.tbgPI = new System.Windows.Forms.TabPage();
            this.btnDelDgvLinePI = new System.Windows.Forms.Button();
            this.btnCopyFromExcelPI = new System.Windows.Forms.Button();
            this.btnImportPI = new System.Windows.Forms.Button();
            this.dgvPI = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDraw = new System.Windows.Forms.Button();
            this.chartPI = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbgResult = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcAdjustProfile.SuspendLayout();
            this.tbgPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPI)).BeginInit();
            this.tbgResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcAdjustProfile
            // 
            this.tbcAdjustProfile.Controls.Add(this.tbgPI);
            this.tbcAdjustProfile.Controls.Add(this.tbgResult);
            this.tbcAdjustProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcAdjustProfile.Location = new System.Drawing.Point(0, 0);
            this.tbcAdjustProfile.Name = "tbcAdjustProfile";
            this.tbcAdjustProfile.SelectedIndex = 0;
            this.tbcAdjustProfile.Size = new System.Drawing.Size(880, 552);
            this.tbcAdjustProfile.TabIndex = 11;
            // 
            // tbgPI
            // 
            this.tbgPI.Controls.Add(this.btnDelDgvLinePI);
            this.tbgPI.Controls.Add(this.btnCopyFromExcelPI);
            this.tbgPI.Controls.Add(this.btnImportPI);
            this.tbgPI.Controls.Add(this.dgvPI);
            this.tbgPI.Controls.Add(this.btnDraw);
            this.tbgPI.Controls.Add(this.chartPI);
            this.tbgPI.Location = new System.Drawing.Point(4, 22);
            this.tbgPI.Name = "tbgPI";
            this.tbgPI.Padding = new System.Windows.Forms.Padding(3);
            this.tbgPI.Size = new System.Drawing.Size(872, 526);
            this.tbgPI.TabIndex = 1;
            this.tbgPI.Text = "压降曲线";
            this.tbgPI.UseVisualStyleBackColor = true;
            // 
            // btnDelDgvLinePI
            // 
            this.btnDelDgvLinePI.Location = new System.Drawing.Point(131, 16);
            this.btnDelDgvLinePI.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelDgvLinePI.Name = "btnDelDgvLinePI";
            this.btnDelDgvLinePI.Size = new System.Drawing.Size(90, 23);
            this.btnDelDgvLinePI.TabIndex = 28;
            this.btnDelDgvLinePI.Text = "删除选中行";
            this.btnDelDgvLinePI.UseVisualStyleBackColor = true;
            this.btnDelDgvLinePI.Click += new System.EventHandler(this.btnDelDgvLinePI_Click);
            // 
            // btnCopyFromExcelPI
            // 
            this.btnCopyFromExcelPI.Location = new System.Drawing.Point(22, 16);
            this.btnCopyFromExcelPI.Name = "btnCopyFromExcelPI";
            this.btnCopyFromExcelPI.Size = new System.Drawing.Size(90, 23);
            this.btnCopyFromExcelPI.TabIndex = 27;
            this.btnCopyFromExcelPI.Text = "从Excel粘贴";
            this.btnCopyFromExcelPI.UseVisualStyleBackColor = true;
            this.btnCopyFromExcelPI.Click += new System.EventHandler(this.btnCopyFromExcelPI_Click);
            // 
            // btnImportPI
            // 
            this.btnImportPI.Location = new System.Drawing.Point(238, 16);
            this.btnImportPI.Name = "btnImportPI";
            this.btnImportPI.Size = new System.Drawing.Size(90, 23);
            this.btnImportPI.TabIndex = 26;
            this.btnImportPI.Text = "入库";
            this.btnImportPI.UseVisualStyleBackColor = true;
            this.btnImportPI.Click += new System.EventHandler(this.btnImportPI_Click);
            // 
            // dgvPI
            // 
            this.dgvPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvPI.Location = new System.Drawing.Point(8, 44);
            this.dgvPI.Name = "dgvPI";
            this.dgvPI.RowTemplate.Height = 23;
            this.dgvPI.Size = new System.Drawing.Size(396, 421);
            this.dgvPI.TabIndex = 25;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "井号";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "时间(分)";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "测压(Mpa)";
            this.Column3.Name = "Column3";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(455, 16);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(154, 23);
            this.btnDraw.TabIndex = 24;
            this.btnDraw.Text = "绘制压降曲线";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // chartPI
            // 
            chartArea3.Name = "ChartArea1";
            this.chartPI.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPI.Legends.Add(legend3);
            this.chartPI.Location = new System.Drawing.Point(435, 55);
            this.chartPI.Name = "chartPI";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartPI.Series.Add(series3);
            this.chartPI.Size = new System.Drawing.Size(439, 400);
            this.chartPI.TabIndex = 23;
            this.chartPI.Text = "压降分析曲线";
            // 
            // tbgResult
            // 
            this.tbgResult.Controls.Add(this.dgvResult);
            this.tbgResult.Location = new System.Drawing.Point(4, 22);
            this.tbgResult.Name = "tbgResult";
            this.tbgResult.Padding = new System.Windows.Forms.Padding(3);
            this.tbgResult.Size = new System.Drawing.Size(872, 526);
            this.tbgResult.TabIndex = 2;
            this.tbgResult.Text = "分析计算";
            this.tbgResult.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvResult.Location = new System.Drawing.Point(8, 6);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(847, 465);
            this.dgvResult.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "井号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "注入压力(Mpa)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "PI指数";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "PI压力校正";
            this.Column8.Name = "Column8";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "吸水%";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "非均质系数";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "当前注入压力";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "对应油井含水率";
            this.Column7.Name = "Column7";
            // 
            // FormProfilePIcal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 552);
            this.Controls.Add(this.tbcAdjustProfile);
            this.Name = "FormProfilePIcal";
            this.Text = "PI分析";
            this.tbcAdjustProfile.ResumeLayout(false);
            this.tbgPI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPI)).EndInit();
            this.tbgResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcAdjustProfile;
        private System.Windows.Forms.TabPage tbgPI;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPI;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TabPage tbgResult;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridView dgvPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnDelDgvLinePI;
        private System.Windows.Forms.Button btnCopyFromExcelPI;
        private System.Windows.Forms.Button btnImportPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}