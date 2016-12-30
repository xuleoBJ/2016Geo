namespace DOGPlatform
{
    partial class FormFileManagerGeo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileManagerGeo));
            this.tbcSection = new System.Windows.Forms.TabControl();
            this.tbgViewEdit = new System.Windows.Forms.TabPage();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tvFileManage = new System.Windows.Forms.TreeView();
            this.cmsTV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTVaddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTVautoFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReSelectDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectedDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTVopenDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTVcollapse2Well = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTVrefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListFoldManage = new System.Windows.Forms.ImageList(this.components);
            this.statusStripTV = new System.Windows.Forms.StatusStrip();
            this.tsslPathCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerShow = new System.Windows.Forms.SplitContainer();
            this.statusStripView = new System.Windows.Forms.StatusStrip();
            this.tsslViewInfor = new System.Windows.Forms.ToolStripStatusLabel();
            this.picBoxView = new System.Windows.Forms.PictureBox();
            this.richTBXview = new System.Windows.Forms.RichTextBox();
            this.webBrowserFile = new System.Windows.Forms.WebBrowser();
            this.statusStripLV = new System.Windows.Forms.StatusStrip();
            this.tssInfor = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvFileGeo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsLV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenDir = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcSection.SuspendLayout();
            this.tbgViewEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.cmsTV.SuspendLayout();
            this.statusStripTV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShow)).BeginInit();
            this.splitContainerShow.Panel1.SuspendLayout();
            this.splitContainerShow.Panel2.SuspendLayout();
            this.splitContainerShow.SuspendLayout();
            this.statusStripView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxView)).BeginInit();
            this.statusStripLV.SuspendLayout();
            this.cmsLV.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcSection
            // 
            this.tbcSection.AllowDrop = true;
            this.tbcSection.Controls.Add(this.tbgViewEdit);
            this.tbcSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSection.Location = new System.Drawing.Point(0, 0);
            this.tbcSection.Name = "tbcSection";
            this.tbcSection.SelectedIndex = 0;
            this.tbcSection.Size = new System.Drawing.Size(757, 608);
            this.tbcSection.TabIndex = 3;
            // 
            // tbgViewEdit
            // 
            this.tbgViewEdit.Controls.Add(this.splitContainerMain);
            this.tbgViewEdit.Location = new System.Drawing.Point(4, 22);
            this.tbgViewEdit.Name = "tbgViewEdit";
            this.tbgViewEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tbgViewEdit.Size = new System.Drawing.Size(749, 582);
            this.tbgViewEdit.TabIndex = 3;
            this.tbgViewEdit.Text = "井管理";
            this.tbgViewEdit.UseVisualStyleBackColor = true;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tvFileManage);
            this.splitContainerMain.Panel1.Controls.Add(this.statusStripTV);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerShow);
            this.splitContainerMain.Size = new System.Drawing.Size(743, 576);
            this.splitContainerMain.SplitterDistance = 140;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tvFileManage
            // 
            this.tvFileManage.CheckBoxes = true;
            this.tvFileManage.ContextMenuStrip = this.cmsTV;
            this.tvFileManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFileManage.ImageIndex = 0;
            this.tvFileManage.ImageList = this.imageListFoldManage;
            this.tvFileManage.Location = new System.Drawing.Point(0, 0);
            this.tvFileManage.Margin = new System.Windows.Forms.Padding(2);
            this.tvFileManage.Name = "tvFileManage";
            this.tvFileManage.SelectedImageIndex = 0;
            this.tvFileManage.Size = new System.Drawing.Size(140, 554);
            this.tvFileManage.TabIndex = 49;
            this.tvFileManage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvFileManage_MouseUp);
            // 
            // cmsTV
            // 
            this.cmsTV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTVaddFile,
            this.tsmiTVautoFind,
            this.tsmiTVopenDir,
            this.tsmiTVcollapse2Well,
            this.tsmiTVrefresh});
            this.cmsTV.Name = "cmsTV";
            this.cmsTV.Size = new System.Drawing.Size(125, 114);
            // 
            // tsmiTVaddFile
            // 
            this.tsmiTVaddFile.Name = "tsmiTVaddFile";
            this.tsmiTVaddFile.Size = new System.Drawing.Size(124, 22);
            this.tsmiTVaddFile.Text = "添加文件";
            this.tsmiTVaddFile.Click += new System.EventHandler(this.tsmiTVaddFile_Click);
            // 
            // tsmiTVautoFind
            // 
            this.tsmiTVautoFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReSelectDir,
            this.tsmiSelectedDir});
            this.tsmiTVautoFind.Name = "tsmiTVautoFind";
            this.tsmiTVautoFind.Size = new System.Drawing.Size(124, 22);
            this.tsmiTVautoFind.Text = "智能查找";
            this.tsmiTVautoFind.Click += new System.EventHandler(this.tsmiTVautoFind_Click);
            // 
            // tsmiReSelectDir
            // 
            this.tsmiReSelectDir.Name = "tsmiReSelectDir";
            this.tsmiReSelectDir.Size = new System.Drawing.Size(124, 22);
            this.tsmiReSelectDir.Text = "选择目录";
            this.tsmiReSelectDir.Click += new System.EventHandler(this.tsmiReSelectDir_Click);
            // 
            // tsmiSelectedDir
            // 
            this.tsmiSelectedDir.Name = "tsmiSelectedDir";
            this.tsmiSelectedDir.Size = new System.Drawing.Size(124, 22);
            this.tsmiSelectedDir.Text = "已选目录";
            this.tsmiSelectedDir.Click += new System.EventHandler(this.tsmiSelectedDir_Click);
            // 
            // tsmiTVopenDir
            // 
            this.tsmiTVopenDir.Name = "tsmiTVopenDir";
            this.tsmiTVopenDir.Size = new System.Drawing.Size(124, 22);
            this.tsmiTVopenDir.Text = "打开目录";
            this.tsmiTVopenDir.Click += new System.EventHandler(this.tsmiTVOpenDir_Click);
            // 
            // tsmiTVcollapse2Well
            // 
            this.tsmiTVcollapse2Well.Name = "tsmiTVcollapse2Well";
            this.tsmiTVcollapse2Well.Size = new System.Drawing.Size(124, 22);
            this.tsmiTVcollapse2Well.Text = "折叠到井";
            this.tsmiTVcollapse2Well.Click += new System.EventHandler(this.tsmiTVcollapseWell_Click);
            // 
            // tsmiTVrefresh
            // 
            this.tsmiTVrefresh.Name = "tsmiTVrefresh";
            this.tsmiTVrefresh.Size = new System.Drawing.Size(124, 22);
            this.tsmiTVrefresh.Text = "刷新";
            this.tsmiTVrefresh.Click += new System.EventHandler(this.tsmiTVRefresh_Click);
            // 
            // imageListFoldManage
            // 
            this.imageListFoldManage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFoldManage.ImageStream")));
            this.imageListFoldManage.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFoldManage.Images.SetKeyName(0, "Folder-Closed.ico");
            this.imageListFoldManage.Images.SetKeyName(1, "Folder.ico");
            // 
            // statusStripTV
            // 
            this.statusStripTV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslPathCurrent});
            this.statusStripTV.Location = new System.Drawing.Point(0, 554);
            this.statusStripTV.Name = "statusStripTV";
            this.statusStripTV.Size = new System.Drawing.Size(140, 22);
            this.statusStripTV.TabIndex = 50;
            this.statusStripTV.Text = "statusStrip1";
            // 
            // tsslPathCurrent
            // 
            this.tsslPathCurrent.Name = "tsslPathCurrent";
            this.tsslPathCurrent.Size = new System.Drawing.Size(44, 17);
            this.tsslPathCurrent.Text = "路径：";
            this.tsslPathCurrent.Click += new System.EventHandler(this.tsmiOpenDir_Click);
            // 
            // splitContainerShow
            // 
            this.splitContainerShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerShow.Location = new System.Drawing.Point(0, 0);
            this.splitContainerShow.Name = "splitContainerShow";
            // 
            // splitContainerShow.Panel1
            // 
            this.splitContainerShow.Panel1.AutoScroll = true;
            this.splitContainerShow.Panel1.Controls.Add(this.statusStripView);
            this.splitContainerShow.Panel1.Controls.Add(this.picBoxView);
            this.splitContainerShow.Panel1.Controls.Add(this.richTBXview);
            this.splitContainerShow.Panel1.Controls.Add(this.webBrowserFile);
            // 
            // splitContainerShow.Panel2
            // 
            this.splitContainerShow.Panel2.Controls.Add(this.statusStripLV);
            this.splitContainerShow.Panel2.Controls.Add(this.lvFileGeo);
            this.splitContainerShow.Size = new System.Drawing.Size(599, 576);
            this.splitContainerShow.SplitterDistance = 199;
            this.splitContainerShow.TabIndex = 52;
            // 
            // statusStripView
            // 
            this.statusStripView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslViewInfor});
            this.statusStripView.Location = new System.Drawing.Point(0, 554);
            this.statusStripView.Name = "statusStripView";
            this.statusStripView.Size = new System.Drawing.Size(199, 22);
            this.statusStripView.TabIndex = 52;
            this.statusStripView.Text = "statusStrip1";
            // 
            // tsslViewInfor
            // 
            this.tsslViewInfor.Name = "tsslViewInfor";
            this.tsslViewInfor.Size = new System.Drawing.Size(56, 17);
            this.tsslViewInfor.Text = "预览窗口";
            // 
            // picBoxView
            // 
            this.picBoxView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxView.Location = new System.Drawing.Point(0, 0);
            this.picBoxView.Name = "picBoxView";
            this.picBoxView.Size = new System.Drawing.Size(199, 576);
            this.picBoxView.TabIndex = 13;
            this.picBoxView.TabStop = false;
            // 
            // richTBXview
            // 
            this.richTBXview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTBXview.Location = new System.Drawing.Point(0, 0);
            this.richTBXview.Name = "richTBXview";
            this.richTBXview.Size = new System.Drawing.Size(199, 576);
            this.richTBXview.TabIndex = 12;
            this.richTBXview.Text = "";
            // 
            // webBrowserFile
            // 
            this.webBrowserFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserFile.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserFile.Location = new System.Drawing.Point(0, 0);
            this.webBrowserFile.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowserFile.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowserFile.Name = "webBrowserFile";
            this.webBrowserFile.ScriptErrorsSuppressed = true;
            this.webBrowserFile.Size = new System.Drawing.Size(199, 576);
            this.webBrowserFile.TabIndex = 11;
            // 
            // statusStripLV
            // 
            this.statusStripLV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssInfor});
            this.statusStripLV.Location = new System.Drawing.Point(0, 554);
            this.statusStripLV.Name = "statusStripLV";
            this.statusStripLV.Size = new System.Drawing.Size(396, 22);
            this.statusStripLV.TabIndex = 52;
            this.statusStripLV.Text = "statusStrip1";
            // 
            // tssInfor
            // 
            this.tssInfor.Name = "tssInfor";
            this.tssInfor.Size = new System.Drawing.Size(32, 17);
            this.tssInfor.Text = "信息";
            // 
            // lvFileGeo
            // 
            this.lvFileGeo.AllowDrop = true;
            this.lvFileGeo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvFileGeo.ContextMenuStrip = this.cmsLV;
            this.lvFileGeo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFileGeo.Location = new System.Drawing.Point(0, 0);
            this.lvFileGeo.Name = "lvFileGeo";
            this.lvFileGeo.Size = new System.Drawing.Size(396, 576);
            this.lvFileGeo.TabIndex = 0;
            this.lvFileGeo.UseCompatibleStateImageBehavior = false;
            this.lvFileGeo.View = System.Windows.Forms.View.Details;
            this.lvFileGeo.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFileGeo_DragDrop);
            this.lvFileGeo.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFileGeo_DragEnter);
            this.lvFileGeo.DoubleClick += new System.EventHandler(this.lvFileGeo_DoubleClick);
            this.lvFileGeo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFileGeo_KeyDown);
            this.lvFileGeo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvFileGeo_KeyPress);
            this.lvFileGeo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvFileGeo_MouseClick);
            this.lvFileGeo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvFileGeo_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 292;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "信息";
            this.columnHeader2.Width = 254;
            // 
            // cmsLV
            // 
            this.cmsLV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiRename,
            this.tsmiAdd,
            this.tsmiDelete,
            this.tsmiRefreshDir,
            this.tsmiOpenDir});
            this.cmsLV.Name = "cmsLV";
            this.cmsLV.Size = new System.Drawing.Size(149, 136);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(148, 22);
            this.tsmiOpen.Text = "打开";
            this.tsmiOpen.Click += new System.EventHandler(this.lvFileGeo_DoubleClick);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(148, 22);
            this.tsmiRename.Text = "重命名";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(148, 22);
            this.tsmiAdd.Text = "添加到目录";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(148, 22);
            this.tsmiDelete.Text = "目录中移除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiRefreshDir
            // 
            this.tsmiRefreshDir.Name = "tsmiRefreshDir";
            this.tsmiRefreshDir.Size = new System.Drawing.Size(148, 22);
            this.tsmiRefreshDir.Text = "刷新目录";
            this.tsmiRefreshDir.Click += new System.EventHandler(this.tsmiRefreshDir_Click);
            // 
            // tsmiOpenDir
            // 
            this.tsmiOpenDir.Name = "tsmiOpenDir";
            this.tsmiOpenDir.Size = new System.Drawing.Size(148, 22);
            this.tsmiOpenDir.Text = "打开所在目录";
            this.tsmiOpenDir.Click += new System.EventHandler(this.tsmiOpenDir_Click);
            // 
            // FormFileManagerGeo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 608);
            this.Controls.Add(this.tbcSection);
            this.Name = "FormFileManagerGeo";
            this.Text = "井资料管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tbcSection.ResumeLayout(false);
            this.tbgViewEdit.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.cmsTV.ResumeLayout(false);
            this.statusStripTV.ResumeLayout(false);
            this.statusStripTV.PerformLayout();
            this.splitContainerShow.Panel1.ResumeLayout(false);
            this.splitContainerShow.Panel1.PerformLayout();
            this.splitContainerShow.Panel2.ResumeLayout(false);
            this.splitContainerShow.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShow)).EndInit();
            this.splitContainerShow.ResumeLayout(false);
            this.statusStripView.ResumeLayout(false);
            this.statusStripView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxView)).EndInit();
            this.statusStripLV.ResumeLayout(false);
            this.statusStripLV.PerformLayout();
            this.cmsLV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcSection;
        private System.Windows.Forms.ImageList imageListFoldManage;
        private System.Windows.Forms.ContextMenuStrip cmsLV;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenDir;
        private System.Windows.Forms.TabPage tbgViewEdit;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TreeView tvFileManage;
        private System.Windows.Forms.StatusStrip statusStripTV;
        private System.Windows.Forms.ToolStripStatusLabel tsslPathCurrent;
        private System.Windows.Forms.SplitContainer splitContainerShow;
        private System.Windows.Forms.StatusStrip statusStripView;
        private System.Windows.Forms.ToolStripStatusLabel tsslViewInfor;
        private System.Windows.Forms.PictureBox picBoxView;
        private System.Windows.Forms.RichTextBox richTBXview;
        private System.Windows.Forms.WebBrowser webBrowserFile;
        private System.Windows.Forms.StatusStrip statusStripLV;
        private System.Windows.Forms.ListView lvFileGeo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip cmsTV;
        private System.Windows.Forms.ToolStripMenuItem tsmiTVrefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiTVopenDir;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshDir;
        private System.Windows.Forms.ToolStripMenuItem tsmiTVaddFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiTVcollapse2Well;
        private System.Windows.Forms.ToolStripMenuItem tsmiTVautoFind;
        private System.Windows.Forms.ToolStripMenuItem tsmiReSelectDir;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectedDir;
        private System.Windows.Forms.ToolStripStatusLabel tssInfor;
    }
}