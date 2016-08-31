namespace DOGPlatform
{
    partial class FormWellManager
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
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageWellHead = new System.Windows.Forms.TabPage();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dgvWellHead = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageWellPath = new System.Windows.Forms.TabPage();
            this.dgvWellPath = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageWellHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellHead)).BeginInit();
            this.tabPageWellPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellPath)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.BottomToolStripPanel
            // 
            this.ToolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.tabControlMain);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1043, 603);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(1043, 653);
            this.ToolStripContainer1.TabIndex = 0;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            // 
            // ToolStripContainer1.TopToolStripPanel
            // 
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageWellHead);
            this.tabControlMain.Controls.Add(this.tabPageWellPath);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1043, 603);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageWellHead
            // 
            this.tabPageWellHead.Controls.Add(this.splitter2);
            this.tabPageWellHead.Controls.Add(this.dgvWellHead);
            this.tabPageWellHead.Location = new System.Drawing.Point(4, 25);
            this.tabPageWellHead.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageWellHead.Name = "tabPageWellHead";
            this.tabPageWellHead.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageWellHead.Size = new System.Drawing.Size(1035, 574);
            this.tabPageWellHead.TabIndex = 0;
            this.tabPageWellHead.Text = "井位数据";
            this.tabPageWellHead.UseVisualStyleBackColor = true;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(4, 4);
            this.splitter2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 566);
            this.splitter2.TabIndex = 15;
            this.splitter2.TabStop = false;
            // 
            // dgvWellHead
            // 
            this.dgvWellHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWellHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column11});
            this.dgvWellHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWellHead.Location = new System.Drawing.Point(4, 4);
            this.dgvWellHead.Margin = new System.Windows.Forms.Padding(4);
            this.dgvWellHead.Name = "dgvWellHead";
            this.dgvWellHead.RowTemplate.Height = 23;
            this.dgvWellHead.Size = new System.Drawing.Size(1027, 566);
            this.dgvWellHead.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "井号";
            this.Column1.Name = "Column1";
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
            // Column4
            // 
            this.Column4.HeaderText = "补心海拔";
            this.Column4.Name = "Column4";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "井别代码";
            this.Column11.Name = "Column11";
            // 
            // tabPageWellPath
            // 
            this.tabPageWellPath.Controls.Add(this.dgvWellPath);
            this.tabPageWellPath.Location = new System.Drawing.Point(4, 25);
            this.tabPageWellPath.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageWellPath.Name = "tabPageWellPath";
            this.tabPageWellPath.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageWellPath.Size = new System.Drawing.Size(1035, 596);
            this.tabPageWellPath.TabIndex = 1;
            this.tabPageWellPath.Text = "井斜数据";
            this.tabPageWellPath.UseVisualStyleBackColor = true;
            // 
            // dgvWellPath
            // 
            this.dgvWellPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWellPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.MD,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvWellPath.Location = new System.Drawing.Point(9, 50);
            this.dgvWellPath.Margin = new System.Windows.Forms.Padding(4);
            this.dgvWellPath.Name = "dgvWellPath";
            this.dgvWellPath.RowTemplate.Height = 23;
            this.dgvWellPath.Size = new System.Drawing.Size(1031, 696);
            this.dgvWellPath.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "井号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // MD
            // 
            this.MD.HeaderText = "测深MD（m）";
            this.MD.Name = "MD";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "井斜角INC（°）";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "方位角AZIM（°）";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1043, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.粘贴ToolStripMenuItem,
            this.删除行ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // 删除行ToolStripMenuItem
            // 
            this.删除行ToolStripMenuItem.Name = "删除行ToolStripMenuItem";
            this.删除行ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.删除行ToolStripMenuItem.Text = "删除行";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1043, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // FormWellManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 653);
            this.Controls.Add(this.ToolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormWellManager";
            this.Text = "数据管理";
            this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageWellHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellHead)).EndInit();
            this.tabPageWellPath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWellPath)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageWellHead;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView dgvWellHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.TabPage tabPageWellPath;
        private System.Windows.Forms.DataGridView dgvWellPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}