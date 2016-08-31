namespace DOGPlatform
{
    partial class FormVoronoiAna
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
            this.components = new System.ComponentModel.Container();
            this.tbcVoronoi = new System.Windows.Forms.TabControl();
            this.tbgVoronoiMap = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxMax = new System.Windows.Forms.TextBox();
            this.tbxMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbFile = new System.Windows.Forms.ComboBox();
            this.btnReadFileHead = new System.Windows.Forms.Button();
            this.panelVoronoi = new System.Windows.Forms.Panel();
            this.cmsPanelVor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbXCM = new System.Windows.Forms.ComboBox();
            this.cbbData = new System.Windows.Forms.ComboBox();
            this.btnData = new System.Windows.Forms.Button();
            this.tbcVoronoi.SuspendLayout();
            this.tbgVoronoiMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmsPanelVor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcVoronoi
            // 
            this.tbcVoronoi.Controls.Add(this.tbgVoronoiMap);
            this.tbcVoronoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcVoronoi.Location = new System.Drawing.Point(0, 0);
            this.tbcVoronoi.Name = "tbcVoronoi";
            this.tbcVoronoi.SelectedIndex = 0;
            this.tbcVoronoi.Size = new System.Drawing.Size(1190, 625);
            this.tbcVoronoi.TabIndex = 2;
            // 
            // tbgVoronoiMap
            // 
            this.tbgVoronoiMap.Controls.Add(this.splitContainer2);
            this.tbgVoronoiMap.Location = new System.Drawing.Point(4, 22);
            this.tbgVoronoiMap.Name = "tbgVoronoiMap";
            this.tbgVoronoiMap.Padding = new System.Windows.Forms.Padding(3);
            this.tbgVoronoiMap.Size = new System.Drawing.Size(1182, 599);
            this.tbgVoronoiMap.TabIndex = 5;
            this.tbgVoronoiMap.Text = "Voronoi分布图";
            this.tbgVoronoiMap.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv);
            this.splitContainer2.Size = new System.Drawing.Size(1176, 593);
            this.splitContainer2.SplitterDistance = 825;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbbXCM);
            this.splitContainer1.Panel1.Controls.Add(this.cbbData);
            this.splitContainer1.Panel1.Controls.Add(this.btnData);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.tbxMax);
            this.splitContainer1.Panel1.Controls.Add(this.tbxMin);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnDraw);
            this.splitContainer1.Panel1.Controls.Add(this.pnlColor);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.cbbFile);
            this.splitContainer1.Panel1.Controls.Add(this.btnReadFileHead);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelVoronoi);
            this.splitContainer1.Size = new System.Drawing.Size(825, 593);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "最小";
            // 
            // tbxMax
            // 
            this.tbxMax.Location = new System.Drawing.Point(641, 46);
            this.tbxMax.Name = "tbxMax";
            this.tbxMax.Size = new System.Drawing.Size(71, 21);
            this.tbxMax.TabIndex = 37;
            // 
            // tbxMin
            // 
            this.tbxMin.Location = new System.Drawing.Point(550, 47);
            this.tbxMin.Name = "tbxMin";
            this.tbxMin.Size = new System.Drawing.Size(63, 21);
            this.tbxMin.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "最大";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(718, 44);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(90, 22);
            this.btnDraw.TabIndex = 31;
            this.btnDraw.Text = "绘制";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.Blue;
            this.pnlColor.Location = new System.Drawing.Point(473, 48);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(41, 18);
            this.pnlColor.TabIndex = 30;
            this.pnlColor.Click += new System.EventHandler(this.pnlColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "色系";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "文件";
            // 
            // cbbFile
            // 
            this.cbbFile.FormattingEnabled = true;
            this.cbbFile.Location = new System.Drawing.Point(51, 14);
            this.cbbFile.Name = "cbbFile";
            this.cbbFile.Size = new System.Drawing.Size(650, 20);
            this.cbbFile.TabIndex = 18;
            // 
            // btnReadFileHead
            // 
            this.btnReadFileHead.Location = new System.Drawing.Point(718, 12);
            this.btnReadFileHead.Name = "btnReadFileHead";
            this.btnReadFileHead.Size = new System.Drawing.Size(90, 23);
            this.btnReadFileHead.TabIndex = 16;
            this.btnReadFileHead.Text = "选择";
            this.btnReadFileHead.UseVisualStyleBackColor = true;
            this.btnReadFileHead.Click += new System.EventHandler(this.btnReadFileHead_Click);
            // 
            // panelVoronoi
            // 
            this.panelVoronoi.BackColor = System.Drawing.Color.White;
            this.panelVoronoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVoronoi.ContextMenuStrip = this.cmsPanelVor;
            this.panelVoronoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVoronoi.Location = new System.Drawing.Point(0, 0);
            this.panelVoronoi.Name = "panelVoronoi";
            this.panelVoronoi.Size = new System.Drawing.Size(825, 509);
            this.panelVoronoi.TabIndex = 2;
            this.panelVoronoi.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVoronoi_Paint);
            this.panelVoronoi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelVoronoi_MouseDown);
            this.panelVoronoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelVoronoi_MouseMove);
            this.panelVoronoi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelVoronoi_MouseUp);
            // 
            // cmsPanelVor
            // 
            this.cmsPanelVor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiZoomIn,
            this.tsmiZoomOut});
            this.cmsPanelVor.Name = "cmsPanelVor";
            this.cmsPanelVor.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiZoomIn
            // 
            this.tsmiZoomIn.Name = "tsmiZoomIn";
            this.tsmiZoomIn.Size = new System.Drawing.Size(100, 22);
            this.tsmiZoomIn.Text = "放大";
            this.tsmiZoomIn.Click += new System.EventHandler(this.tsmiZoomIn_Click);
            // 
            // tsmiZoomOut
            // 
            this.tsmiZoomOut.Name = "tsmiZoomOut";
            this.tsmiZoomOut.Size = new System.Drawing.Size(100, 22);
            this.tsmiZoomOut.Text = "缩小";
            this.tsmiZoomOut.Click += new System.EventHandler(this.tsmiZoomOut_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(347, 593);
            this.dgv.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "井号";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "小层名";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "层位";
            // 
            // cbbXCM
            // 
            this.cbbXCM.FormattingEnabled = true;
            this.cbbXCM.Location = new System.Drawing.Point(241, 46);
            this.cbbXCM.Name = "cbbXCM";
            this.cbbXCM.Size = new System.Drawing.Size(112, 20);
            this.cbbXCM.TabIndex = 41;
            // 
            // cbbData
            // 
            this.cbbData.FormattingEnabled = true;
            this.cbbData.Location = new System.Drawing.Point(44, 46);
            this.cbbData.Name = "cbbData";
            this.cbbData.Size = new System.Drawing.Size(143, 20);
            this.cbbData.TabIndex = 40;
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(362, 44);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(57, 22);
            this.btnData.TabIndex = 39;
            this.btnData.Text = "确定";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // FormVoronoiAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 625);
            this.Controls.Add(this.tbcVoronoi);
            this.Name = "FormVoronoiAna";
            this.Text = "Voronoi分析";
            this.tbcVoronoi.ResumeLayout(false);
            this.tbgVoronoiMap.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmsPanelVor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcVoronoi;
        private System.Windows.Forms.TabPage tbgVoronoiMap;
        private System.Windows.Forms.Panel panelVoronoi;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbFile;
        private System.Windows.Forms.Button btnReadFileHead;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip cmsPanelVor;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoomIn;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoomOut;
        private System.Windows.Forms.TextBox tbxMax;
        private System.Windows.Forms.TextBox tbxMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbXCM;
        private System.Windows.Forms.ComboBox cbbData;
        private System.Windows.Forms.Button btnData;
    }
}