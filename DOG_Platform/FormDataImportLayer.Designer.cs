namespace DOGPlatform
{
    partial class FormDataImportLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataImportLayer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCurrentLine = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcDataImportLayer = new System.Windows.Forms.TabControl();
            this.tbgLayerDepth = new System.Windows.Forms.TabPage();
            this.dgvLayerDepth = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbJH = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.tbcDataImportLayer.SuspendLayout();
            this.tbgLayerDepth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayerDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiData,
            this.tsmiPaste,
            this.tsmiDataImport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(517, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiData
            // 
            this.tsmiData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFile,
            this.tsmiDeleteCurrentLine,
            this.ToolStripMenuItem3,
            this.ToolStripMenuItem6});
            this.tsmiData.Name = "tsmiData";
            this.tsmiData.Size = new System.Drawing.Size(68, 21);
            this.tsmiData.Text = "数据操作";
            // 
            // tsmiOpenFile
            // 
            this.tsmiOpenFile.Name = "tsmiOpenFile";
            this.tsmiOpenFile.Size = new System.Drawing.Size(136, 22);
            this.tsmiOpenFile.Text = "打开文件";
            this.tsmiOpenFile.Click += new System.EventHandler(this.tsmiOpenFile_Click);
            // 
            // tsmiDeleteCurrentLine
            // 
            this.tsmiDeleteCurrentLine.Name = "tsmiDeleteCurrentLine";
            this.tsmiDeleteCurrentLine.Size = new System.Drawing.Size(136, 22);
            this.tsmiDeleteCurrentLine.Text = "删除选中行";
            this.tsmiDeleteCurrentLine.Click += new System.EventHandler(this.tsmiDeleteCurrentLine_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem4,
            this.ToolStripMenuItem5});
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem3.Text = "数据导出";
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(129, 22);
            this.ToolStripMenuItem4.Text = "导出数据";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(129, 22);
            this.ToolStripMenuItem5.Text = "导入excle";
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem6.Text = "退出";
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(44, 21);
            this.tsmiPaste.Text = "粘贴";
            this.tsmiPaste.Click += new System.EventHandler(this.tsmiPaste_Click);
            // 
            // tsmiDataImport
            // 
            this.tsmiDataImport.Name = "tsmiDataImport";
            this.tsmiDataImport.Size = new System.Drawing.Size(68, 21);
            this.tsmiDataImport.Text = "数据入库";
            this.tsmiDataImport.Click += new System.EventHandler(this.tsmiDataImport_Click);
            // 
            // tbcDataImportLayer
            // 
            this.tbcDataImportLayer.Controls.Add(this.tbgLayerDepth);
            this.tbcDataImportLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcDataImportLayer.Location = new System.Drawing.Point(0, 25);
            this.tbcDataImportLayer.Name = "tbcDataImportLayer";
            this.tbcDataImportLayer.SelectedIndex = 0;
            this.tbcDataImportLayer.Size = new System.Drawing.Size(517, 388);
            this.tbcDataImportLayer.TabIndex = 15;
            // 
            // tbgLayerDepth
            // 
            this.tbgLayerDepth.Controls.Add(this.dgvLayerDepth);
            this.tbgLayerDepth.Location = new System.Drawing.Point(4, 22);
            this.tbgLayerDepth.Name = "tbgLayerDepth";
            this.tbgLayerDepth.Size = new System.Drawing.Size(509, 362);
            this.tbgLayerDepth.TabIndex = 3;
            this.tbgLayerDepth.Text = "分层数据";
            this.tbgLayerDepth.UseVisualStyleBackColor = true;
            // 
            // dgvLayerDepth
            // 
            this.dgvLayerDepth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLayerDepth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn9});
            this.dgvLayerDepth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLayerDepth.Location = new System.Drawing.Point(0, 0);
            this.dgvLayerDepth.Name = "dgvLayerDepth";
            this.dgvLayerDepth.RowTemplate.Height = 23;
            this.dgvLayerDepth.Size = new System.Drawing.Size(509, 362);
            this.dgvLayerDepth.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "井号";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "层名";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "层段顶测深（m）";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // cbbJH
            // 
            this.cbbJH.FormattingEnabled = true;
            this.cbbJH.Location = new System.Drawing.Point(210, 4);
            this.cbbJH.Name = "cbbJH";
            this.cbbJH.Size = new System.Drawing.Size(121, 20);
            this.cbbJH.TabIndex = 16;
            // 
            // FormDataImportLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 413);
            this.Controls.Add(this.cbbJH);
            this.Controls.Add(this.tbcDataImportLayer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDataImportLayer";
            this.Text = "分层数据";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbcDataImportLayer.ResumeLayout(false);
            this.tbgLayerDepth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayerDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiData;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCurrentLine;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.TabControl tbcDataImportLayer;
        private System.Windows.Forms.TabPage tbgLayerDepth;
        private System.Windows.Forms.DataGridView dgvLayerDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ComboBox cbbJH;
    }
}