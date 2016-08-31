namespace DOGPlatform
{
    partial class FormLogEditor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._scriptEditor = new System.Windows.Forms.RichTextBox();
            this._output = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miRunScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._miLoadScript = new System.Windows.Forms.ToolStripMenuItem();
            this._miSaveScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._miClearScript = new System.Windows.Forms.ToolStripMenuItem();
            this._miClearOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveScriptDlg = new System.Windows.Forms.SaveFileDialog();
            this._openScriptDlg = new System.Windows.Forms.OpenFileDialog();
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd2Project = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelectSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.cmsDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this._scriptEditor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._output);
            this.splitContainer1.Size = new System.Drawing.Size(793, 634);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 10;
            // 
            // _scriptEditor
            // 
            this._scriptEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scriptEditor.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._scriptEditor.Location = new System.Drawing.Point(0, 0);
            this._scriptEditor.Name = "_scriptEditor";
            this._scriptEditor.Size = new System.Drawing.Size(793, 313);
            this._scriptEditor.TabIndex = 3;
            this._scriptEditor.Text = "";
            // 
            // _output
            // 
            this._output.Dock = System.Windows.Forms.DockStyle.Fill;
            this._output.Location = new System.Drawing.Point(0, 0);
            this._output.Name = "_output";
            this._output.ReadOnly = true;
            this._output.Size = new System.Drawing.Size(793, 317);
            this._output.TabIndex = 0;
            this._output.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 25);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRunScript,
            this.toolStripSeparator2,
            this._miLoadScript,
            this._miSaveScript,
            this.toolStripSeparator1,
            this._miClearScript,
            this._miClearOutput});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // _miRunScript
            // 
            this._miRunScript.Name = "_miRunScript";
            this._miRunScript.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._miRunScript.Size = new System.Drawing.Size(199, 22);
            this._miRunScript.Text = "Run Script";
            this._miRunScript.Click += new System.EventHandler(this._miRunScript_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // _miLoadScript
            // 
            this._miLoadScript.Name = "_miLoadScript";
            this._miLoadScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._miLoadScript.Size = new System.Drawing.Size(199, 22);
            this._miLoadScript.Text = "Load Script";
            this._miLoadScript.Click += new System.EventHandler(this._miLoadScript_Click);
            // 
            // _miSaveScript
            // 
            this._miSaveScript.Name = "_miSaveScript";
            this._miSaveScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._miSaveScript.Size = new System.Drawing.Size(199, 22);
            this._miSaveScript.Text = "Save Script";
            this._miSaveScript.Click += new System.EventHandler(this._miSaveScript_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // _miClearScript
            // 
            this._miClearScript.Name = "_miClearScript";
            this._miClearScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this._miClearScript.Size = new System.Drawing.Size(199, 22);
            this._miClearScript.Text = "Clear Script";
            this._miClearScript.Click += new System.EventHandler(this._miClearScript_Click);
            // 
            // _miClearOutput
            // 
            this._miClearOutput.Name = "_miClearOutput";
            this._miClearOutput.Size = new System.Drawing.Size(199, 22);
            this._miClearOutput.Text = "Clear Output (ESC)";
            this._miClearOutput.Click += new System.EventHandler(this._miClearOutput_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // _saveScriptDlg
            // 
            this._saveScriptDlg.Filter = "Iron Python Files|*.py|All Files|*.*";
            // 
            // _openScriptDlg
            // 
            this._openScriptDlg.Filter = "Iron Python Files|*.py|All Files|*.*";
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvDataTable.ContextMenuStrip = this.cmsDGV;
            this.dgvDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataTable.Location = new System.Drawing.Point(0, 0);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowTemplate.Height = 23;
            this.dgvDataTable.Size = new System.Drawing.Size(225, 634);
            this.dgvDataTable.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "深度";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            // 
            // cmsDGV
            // 
            this.cmsDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd2Project,
            this.tsmiDelectSelected});
            this.cmsDGV.Name = "cmsDGV";
            this.cmsDGV.Size = new System.Drawing.Size(125, 48);
            // 
            // tsmiAdd2Project
            // 
            this.tsmiAdd2Project.Name = "tsmiAdd2Project";
            this.tsmiAdd2Project.Size = new System.Drawing.Size(124, 22);
            this.tsmiAdd2Project.Text = "入项目库";
            this.tsmiAdd2Project.Click += new System.EventHandler(this.tsmiAdd2Project_Click);
            // 
            // tsmiDelectSelected
            // 
            this.tsmiDelectSelected.Name = "tsmiDelectSelected";
            this.tsmiDelectSelected.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelectSelected.Text = "删除选中";
            this.tsmiDelectSelected.Click += new System.EventHandler(this.tsmiDelectSelected_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDataTable);
            this.splitContainer2.Size = new System.Drawing.Size(1022, 634);
            this.splitContainer2.SplitterDistance = 793;
            this.splitContainer2.TabIndex = 13;
            // 
            // FormLogEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 659);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormLogEditor";
            this.Text = "曲线计算";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.cmsDGV.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox _scriptEditor;
        private System.Windows.Forms.RichTextBox _output;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _miRunScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _miLoadScript;
        private System.Windows.Forms.ToolStripMenuItem _miSaveScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _miClearScript;
        private System.Windows.Forms.ToolStripMenuItem _miClearOutput;
        private System.Windows.Forms.SaveFileDialog _saveScriptDlg;
        private System.Windows.Forms.OpenFileDialog _openScriptDlg;
        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsDGV;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd2Project;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelectSelected;
    }
}