namespace DOGPlatform
{
    partial class FormDataTable
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
            this.数据操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataTable.Location = new System.Drawing.Point(0, 25);
            this.dgvDataTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowTemplate.Height = 27;
            this.dgvDataTable.Size = new System.Drawing.Size(516, 376);
            this.dgvDataTable.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据操作ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(516, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据操作ToolStripMenuItem
            // 
            this.数据操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.修改数据ToolStripMenuItem,
            this.数据导出ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.数据操作ToolStripMenuItem.Name = "数据操作ToolStripMenuItem";
            this.数据操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据操作ToolStripMenuItem.Text = "数据操作";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 修改数据ToolStripMenuItem
            // 
            this.修改数据ToolStripMenuItem.Name = "修改数据ToolStripMenuItem";
            this.修改数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改数据ToolStripMenuItem.Text = "保存修改";
            this.修改数据ToolStripMenuItem.Click += new System.EventHandler(this.修改数据ToolStripMenuItem_Click);
            // 
            // 数据导出ToolStripMenuItem
            // 
            this.数据导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportText,
            this.tsmiExportExcel});
            this.数据导出ToolStripMenuItem.Name = "数据导出ToolStripMenuItem";
            this.数据导出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据导出ToolStripMenuItem.Text = "数据导出";
            // 
            // tsmiExportText
            // 
            this.tsmiExportText.Name = "tsmiExportText";
            this.tsmiExportText.Size = new System.Drawing.Size(152, 22);
            this.tsmiExportText.Text = "txt";
            this.tsmiExportText.Click += new System.EventHandler(this.导出数据ToolStripMenuItem_Click);
            // 
            // tsmiExportExcel
            // 
            this.tsmiExportExcel.Name = "tsmiExportExcel";
            this.tsmiExportExcel.Size = new System.Drawing.Size(152, 22);
            this.tsmiExportExcel.Text = "Excel";
            this.tsmiExportExcel.Click += new System.EventHandler(this.tsmiExportExcel_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // FormDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 401);
            this.Controls.Add(this.dgvDataTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDataTable";
            this.Text = "FormDataTable";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportText;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportExcel;
    }
}