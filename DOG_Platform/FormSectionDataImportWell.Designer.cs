namespace DOGPlatform
{
    partial class FormDataImportWell
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
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCilpCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFromDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFromSectionWell = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAllAndCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteCurrentLine = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport2Txt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcDataImportSingleWell = new System.Windows.Forms.TabControl();
            this.tbgData = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tbcDataImportSingleWell.SuspendLayout();
            this.tbgData.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvDataTable.Size = new System.Drawing.Size(586, 408);
            this.dgvDataTable.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据ToolStripMenuItem,
            this.tsmiDataImport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 25);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCilpCopy,
            this.tsmiFromDB,
            this.tsmiFromSectionWell,
            this.tsmiCopyData,
            this.tsmiSelectAllAndCopy,
            this.toolStripSeparator1,
            this.tsmiDeleteCurrentLine,
            this.ToolStripMenuItem3});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.数据ToolStripMenuItem.Text = "数据";
            // 
            // tsmiCilpCopy
            // 
            this.tsmiCilpCopy.Name = "tsmiCilpCopy";
            this.tsmiCilpCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmiCilpCopy.Size = new System.Drawing.Size(209, 22);
            this.tsmiCilpCopy.Text = "粘贴";
            this.tsmiCilpCopy.Click += new System.EventHandler(this.tsmiCilpCopy_Click);
            // 
            // tsmiFromDB
            // 
            this.tsmiFromDB.Name = "tsmiFromDB";
            this.tsmiFromDB.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmiFromDB.Size = new System.Drawing.Size(209, 22);
            this.tsmiFromDB.Text = "工区";
            this.tsmiFromDB.Click += new System.EventHandler(this.tsmiFromDB_Click);
            // 
            // tsmiFromSectionWell
            // 
            this.tsmiFromSectionWell.Name = "tsmiFromSectionWell";
            this.tsmiFromSectionWell.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiFromSectionWell.Size = new System.Drawing.Size(209, 22);
            this.tsmiFromSectionWell.Text = "单井综合图导入";
            this.tsmiFromSectionWell.Click += new System.EventHandler(this.tsmiFromSectionWell_Click);
            // 
            // tsmiCopyData
            // 
            this.tsmiCopyData.Name = "tsmiCopyData";
            this.tsmiCopyData.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiCopyData.Size = new System.Drawing.Size(209, 22);
            this.tsmiCopyData.Text = "复制选中";
            this.tsmiCopyData.Click += new System.EventHandler(this.tsmiCopyData_Click);
            // 
            // tsmiSelectAllAndCopy
            // 
            this.tsmiSelectAllAndCopy.Name = "tsmiSelectAllAndCopy";
            this.tsmiSelectAllAndCopy.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.tsmiSelectAllAndCopy.Size = new System.Drawing.Size(209, 22);
            this.tsmiSelectAllAndCopy.Text = "全选复制";
            this.tsmiSelectAllAndCopy.Click += new System.EventHandler(this.tsmiSelectAllAndCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // tsmiDeleteCurrentLine
            // 
            this.tsmiDeleteCurrentLine.Name = "tsmiDeleteCurrentLine";
            this.tsmiDeleteCurrentLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDeleteCurrentLine.Size = new System.Drawing.Size(209, 22);
            this.tsmiDeleteCurrentLine.Text = "删除行";
            this.tsmiDeleteCurrentLine.Click += new System.EventHandler(this.tsmiDeleteCurrentLine_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExport2Txt,
            this.tsmiExportExcel});
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(209, 22);
            this.ToolStripMenuItem3.Text = "数据导出";
            // 
            // tsmiExport2Txt
            // 
            this.tsmiExport2Txt.Name = "tsmiExport2Txt";
            this.tsmiExport2Txt.Size = new System.Drawing.Size(105, 22);
            this.tsmiExport2Txt.Text = "txt";
            this.tsmiExport2Txt.Click += new System.EventHandler(this.tsmiExport2Txt_Click);
            // 
            // tsmiExportExcel
            // 
            this.tsmiExportExcel.Name = "tsmiExportExcel";
            this.tsmiExportExcel.Size = new System.Drawing.Size(105, 22);
            this.tsmiExportExcel.Text = "excel";
            this.tsmiExportExcel.Click += new System.EventHandler(this.tsmiExportExcel_Click);
            // 
            // tsmiDataImport
            // 
            this.tsmiDataImport.Name = "tsmiDataImport";
            this.tsmiDataImport.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.tsmiDataImport.Size = new System.Drawing.Size(44, 21);
            this.tsmiDataImport.Text = "加载";
            this.tsmiDataImport.Click += new System.EventHandler(this.tsmiDataImport_Click);
            // 
            // tbcDataImportSingleWell
            // 
            this.tbcDataImportSingleWell.Controls.Add(this.tbgData);
            this.tbcDataImportSingleWell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcDataImportSingleWell.Location = new System.Drawing.Point(0, 25);
            this.tbcDataImportSingleWell.Name = "tbcDataImportSingleWell";
            this.tbcDataImportSingleWell.SelectedIndex = 0;
            this.tbcDataImportSingleWell.Size = new System.Drawing.Size(600, 440);
            this.tbcDataImportSingleWell.TabIndex = 12;
            // 
            // tbgData
            // 
            this.tbgData.Controls.Add(this.dgvDataTable);
            this.tbgData.Location = new System.Drawing.Point(4, 22);
            this.tbgData.Name = "tbgData";
            this.tbgData.Padding = new System.Windows.Forms.Padding(3);
            this.tbgData.Size = new System.Drawing.Size(592, 414);
            this.tbgData.TabIndex = 1;
            this.tbgData.Text = "数据";
            this.tbgData.UseVisualStyleBackColor = true;
            // 
            // FormDataImportWell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 465);
            this.Controls.Add(this.tbcDataImportSingleWell);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormDataImportWell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单井数据导入";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbcDataImportSingleWell.ResumeLayout(false);
            this.tbgData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataImport;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCilpCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiFromDB;
        private System.Windows.Forms.TabControl tbcDataImportSingleWell;
        private System.Windows.Forms.TabPage tbgData;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCurrentLine;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport2Txt;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyData;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAllAndCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiFromSectionWell;
    }
}