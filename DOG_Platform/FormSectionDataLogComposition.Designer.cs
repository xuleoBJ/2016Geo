namespace DOGPlatform
{
    partial class FormSectionDataLogComposition
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddColum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCilpCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAllAndCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteCurrentLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport2Txt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tbgData = new System.Windows.Forms.TabPage();
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.tbcLogDeal = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tbgData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.tbcLogDeal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据ToolStripMenuItem,
            this.tsmiDataImport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(584, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddColum,
            this.tsmiDelColumn,
            this.tsmiCilpCopy,
            this.tsmiCopyData,
            this.tsmiSelectAllAndCopy,
            this.toolStripSeparator1,
            this.tsmiDeleteCurrentLine,
            this.tsmiDataExport});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.数据ToolStripMenuItem.Text = "数据";
            // 
            // tsmiAddColum
            // 
            this.tsmiAddColum.Name = "tsmiAddColum";
            this.tsmiAddColum.Size = new System.Drawing.Size(203, 22);
            this.tsmiAddColum.Text = "增加列";
            this.tsmiAddColum.Click += new System.EventHandler(this.tsmiAddColum_Click);
            // 
            // tsmiDelColumn
            // 
            this.tsmiDelColumn.Name = "tsmiDelColumn";
            this.tsmiDelColumn.Size = new System.Drawing.Size(203, 22);
            this.tsmiDelColumn.Text = "删除列";
            this.tsmiDelColumn.Click += new System.EventHandler(this.tsmiDelColumn_Click);
            // 
            // tsmiCilpCopy
            // 
            this.tsmiCilpCopy.Name = "tsmiCilpCopy";
            this.tsmiCilpCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmiCilpCopy.Size = new System.Drawing.Size(203, 22);
            this.tsmiCilpCopy.Text = "粘贴";
            this.tsmiCilpCopy.Click += new System.EventHandler(this.tsmiCilpCopy_Click);
            // 
            // tsmiCopyData
            // 
            this.tsmiCopyData.Name = "tsmiCopyData";
            this.tsmiCopyData.Size = new System.Drawing.Size(203, 22);
            this.tsmiCopyData.Text = "复制";
            // 
            // tsmiSelectAllAndCopy
            // 
            this.tsmiSelectAllAndCopy.Name = "tsmiSelectAllAndCopy";
            this.tsmiSelectAllAndCopy.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.tsmiSelectAllAndCopy.Size = new System.Drawing.Size(203, 22);
            this.tsmiSelectAllAndCopy.Text = "全选复制";
            this.tsmiSelectAllAndCopy.Click += new System.EventHandler(this.tsmiSelectAllAndCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // tsmiDeleteCurrentLine
            // 
            this.tsmiDeleteCurrentLine.Name = "tsmiDeleteCurrentLine";
            this.tsmiDeleteCurrentLine.Size = new System.Drawing.Size(203, 22);
            this.tsmiDeleteCurrentLine.Text = "删除行";
            this.tsmiDeleteCurrentLine.Click += new System.EventHandler(this.tsmiDeleteCurrentLine_Click);
            // 
            // tsmiDataExport
            // 
            this.tsmiDataExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExport2Txt,
            this.tsmiExportExcel});
            this.tsmiDataExport.Name = "tsmiDataExport";
            this.tsmiDataExport.Size = new System.Drawing.Size(203, 22);
            this.tsmiDataExport.Text = "数据导出";
            // 
            // tsmiExport2Txt
            // 
            this.tsmiExport2Txt.Name = "tsmiExport2Txt";
            this.tsmiExport2Txt.Size = new System.Drawing.Size(105, 22);
            this.tsmiExport2Txt.Text = "txt";
            // 
            // tsmiExportExcel
            // 
            this.tsmiExportExcel.Name = "tsmiExportExcel";
            this.tsmiExportExcel.Size = new System.Drawing.Size(105, 22);
            this.tsmiExportExcel.Text = "excel";
            // 
            // tsmiDataImport
            // 
            this.tsmiDataImport.Name = "tsmiDataImport";
            this.tsmiDataImport.Size = new System.Drawing.Size(44, 21);
            this.tsmiDataImport.Text = "加载";
            this.tsmiDataImport.Click += new System.EventHandler(this.tsmiDataImport_Click);
            // 
            // tbgData
            // 
            this.tbgData.Controls.Add(this.dgvDataTable);
            this.tbgData.Location = new System.Drawing.Point(4, 22);
            this.tbgData.Name = "tbgData";
            this.tbgData.Padding = new System.Windows.Forms.Padding(3);
            this.tbgData.Size = new System.Drawing.Size(576, 446);
            this.tbgData.TabIndex = 3;
            this.tbgData.Text = "数据";
            this.tbgData.UseVisualStyleBackColor = true;
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataTable.Location = new System.Drawing.Point(3, 3);
            this.dgvDataTable.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowTemplate.Height = 27;
            this.dgvDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTable.Size = new System.Drawing.Size(570, 440);
            this.dgvDataTable.TabIndex = 3;
            // 
            // tbcLogDeal
            // 
            this.tbcLogDeal.Controls.Add(this.tbgData);
            this.tbcLogDeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcLogDeal.Location = new System.Drawing.Point(0, 25);
            this.tbcLogDeal.Name = "tbcLogDeal";
            this.tbcLogDeal.SelectedIndex = 0;
            this.tbcLogDeal.Size = new System.Drawing.Size(584, 472);
            this.tbcLogDeal.TabIndex = 14;
            // 
            // FormSectionDataLogComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 497);
            this.Controls.Add(this.tbcLogDeal);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormSectionDataLogComposition";
            this.Text = "组分数据导入";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbgData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.tbcLogDeal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCilpCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyData;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAllAndCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCurrentLine;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport2Txt;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataImport;
        private System.Windows.Forms.TabPage tbgData;
        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.TabControl tbcLogDeal;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddColum;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelColumn;
    }
}