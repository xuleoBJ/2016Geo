namespace DOGPlatform
{
    partial class FormDataAnalysis
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
            this.cbxScaleRulerShowed = new System.Windows.Forms.CheckBox();
            this.cbxGrid = new System.Windows.Forms.CheckBox();
            this.cbxCompassShowed = new System.Windows.Forms.CheckBox();
            this.cbxMapFrame = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.btnDrawPieMap = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tbxMapTitleName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 609);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxScaleRulerShowed);
            this.tabPage1.Controls.Add(this.cbxGrid);
            this.tabPage1.Controls.Add(this.cbxCompassShowed);
            this.tabPage1.Controls.Add(this.cbxMapFrame);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dgvDataTable);
            this.tabPage1.Controls.Add(this.btnDrawPieMap);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(630, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据读入";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbxScaleRulerShowed
            // 
            this.cbxScaleRulerShowed.AutoSize = true;
            this.cbxScaleRulerShowed.Location = new System.Drawing.Point(208, 25);
            this.cbxScaleRulerShowed.Name = "cbxScaleRulerShowed";
            this.cbxScaleRulerShowed.Size = new System.Drawing.Size(60, 16);
            this.cbxScaleRulerShowed.TabIndex = 7;
            this.cbxScaleRulerShowed.Text = "比例尺";
            this.cbxScaleRulerShowed.UseVisualStyleBackColor = true;
            // 
            // cbxGrid
            // 
            this.cbxGrid.AutoSize = true;
            this.cbxGrid.Location = new System.Drawing.Point(481, 24);
            this.cbxGrid.Name = "cbxGrid";
            this.cbxGrid.Size = new System.Drawing.Size(72, 16);
            this.cbxGrid.TabIndex = 8;
            this.cbxGrid.Text = "绘制网格";
            this.cbxGrid.UseVisualStyleBackColor = true;
            // 
            // cbxCompassShowed
            // 
            this.cbxCompassShowed.AutoSize = true;
            this.cbxCompassShowed.Location = new System.Drawing.Point(299, 24);
            this.cbxCompassShowed.Name = "cbxCompassShowed";
            this.cbxCompassShowed.Size = new System.Drawing.Size(60, 16);
            this.cbxCompassShowed.TabIndex = 5;
            this.cbxCompassShowed.Text = "指南针";
            this.cbxCompassShowed.UseVisualStyleBackColor = true;
            // 
            // cbxMapFrame
            // 
            this.cbxMapFrame.AutoSize = true;
            this.cbxMapFrame.Location = new System.Drawing.Point(388, 24);
            this.cbxMapFrame.Name = "cbxMapFrame";
            this.cbxMapFrame.Size = new System.Drawing.Size(72, 16);
            this.cbxMapFrame.TabIndex = 6;
            this.cbxMapFrame.Text = "绘制图框";
            this.cbxMapFrame.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "导入数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.Location = new System.Drawing.Point(8, 58);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowTemplate.Height = 23;
            this.dgvDataTable.Size = new System.Drawing.Size(598, 490);
            this.dgvDataTable.TabIndex = 2;
            // 
            // btnDrawPieMap
            // 
            this.btnDrawPieMap.Location = new System.Drawing.Point(110, 21);
            this.btnDrawPieMap.Name = "btnDrawPieMap";
            this.btnDrawPieMap.Size = new System.Drawing.Size(75, 23);
            this.btnDrawPieMap.TabIndex = 1;
            this.btnDrawPieMap.Text = "绘制饼图";
            this.btnDrawPieMap.UseVisualStyleBackColor = true;
            this.btnDrawPieMap.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(630, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "高级";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.tbxMapTitleName);
            this.groupBox1.Location = new System.Drawing.Point(28, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 141);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "平面图信息";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(21, 41);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 3;
            this.label34.Text = "图名";
            // 
            // tbxMapTitleName
            // 
            this.tbxMapTitleName.Location = new System.Drawing.Point(56, 34);
            this.tbxMapTitleName.Name = "tbxMapTitleName";
            this.tbxMapTitleName.Size = new System.Drawing.Size(230, 21);
            this.tbxMapTitleName.TabIndex = 0;
            // 
            // FormDataAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 609);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormDataAnalysis";
            this.Text = "井点数据平面分析";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.Button btnDrawPieMap;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tbxMapTitleName;
        private System.Windows.Forms.CheckBox cbxScaleRulerShowed;
        private System.Windows.Forms.CheckBox cbxGrid;
        private System.Windows.Forms.CheckBox cbxCompassShowed;
        private System.Windows.Forms.CheckBox cbxMapFrame;
    }
}