namespace DOGPlatform
{
    partial class wellPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webBrowserBody = new System.Windows.Forms.WebBrowser();
            this.cmsWBBody = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDataItemAdjustTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataItemAdjustBot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBodyLogSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataItemInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataItemSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBodyLogValue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectDel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCrossPlot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIntervalStastics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRulerMarkShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRulerMarkHide = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowserHead = new System.Windows.Forms.WebBrowser();
            this.cmsWBHead = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiHeadTrackSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadTrackDataLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadTrackRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadTrackCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadTrackHide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadLogSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadTrackAddLogCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadLogDataLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadLogTrackFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadLogRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadLayerStastics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadSVG = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHeadRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCrossH = new System.Windows.Forms.Label();
            this.statusStripWellPanel = new System.Windows.Forms.StatusStrip();
            this.tsslblDepth = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCurTrack = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCurItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblAna = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCrossV = new System.Windows.Forms.Label();
            this.lblDrawMove = new System.Windows.Forms.Label();
            this.lblmarker = new System.Windows.Forms.Label();
            this.tsmiDataFromWellNeighbor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsWBBody.SuspendLayout();
            this.cmsWBHead.SuspendLayout();
            this.statusStripWellPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserBody
            // 
            this.webBrowserBody.ContextMenuStrip = this.cmsWBBody;
            this.webBrowserBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserBody.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserBody.Location = new System.Drawing.Point(0, 0);
            this.webBrowserBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBody.Name = "webBrowserBody";
            this.webBrowserBody.Size = new System.Drawing.Size(450, 623);
            this.webBrowserBody.TabIndex = 0;
            this.webBrowserBody.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserBody_DocumentCompleted);
            this.webBrowserBody.SizeChanged += new System.EventHandler(this.webBrowserBody_SizeChanged);
            // 
            // cmsWBBody
            // 
            this.cmsWBBody.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDataItemAdjustTop,
            this.tsmiDataItemAdjustBot,
            this.tsmiBodyLogSet,
            this.tsmiDataItemInsert,
            this.tsmiDataFromWellNeighbor,
            this.tsmiDataItemSet,
            this.tsmiBodyLogValue,
            this.tsmiSelectDel,
            this.tsmiCrossPlot,
            this.tsmiIntervalStastics,
            this.tsmiMark});
            this.cmsWBBody.Name = "cmsWebSVG";
            this.cmsWBBody.Size = new System.Drawing.Size(125, 246);
            // 
            // tsmiDataItemAdjustTop
            // 
            this.tsmiDataItemAdjustTop.Name = "tsmiDataItemAdjustTop";
            this.tsmiDataItemAdjustTop.Size = new System.Drawing.Size(124, 22);
            this.tsmiDataItemAdjustTop.Text = "顶深设置";
            this.tsmiDataItemAdjustTop.Click += new System.EventHandler(this.tsmiDataItemAdjustTop_Click);
            // 
            // tsmiDataItemAdjustBot
            // 
            this.tsmiDataItemAdjustBot.Name = "tsmiDataItemAdjustBot";
            this.tsmiDataItemAdjustBot.Size = new System.Drawing.Size(124, 22);
            this.tsmiDataItemAdjustBot.Text = "底深设置";
            this.tsmiDataItemAdjustBot.Click += new System.EventHandler(this.tsmiDataItemAdjustBot_Click);
            // 
            // tsmiBodyLogSet
            // 
            this.tsmiBodyLogSet.Name = "tsmiBodyLogSet";
            this.tsmiBodyLogSet.Size = new System.Drawing.Size(124, 22);
            this.tsmiBodyLogSet.Text = "曲线设置";
            this.tsmiBodyLogSet.Click += new System.EventHandler(this.tsmiLogSet_Click);
            // 
            // tsmiDataItemInsert
            // 
            this.tsmiDataItemInsert.Name = "tsmiDataItemInsert";
            this.tsmiDataItemInsert.Size = new System.Drawing.Size(124, 22);
            this.tsmiDataItemInsert.Text = "插入新段";
            this.tsmiDataItemInsert.Click += new System.EventHandler(this.tsmiDataItemInsert_Click);
            // 
            // tsmiDataItemSet
            // 
            this.tsmiDataItemSet.Name = "tsmiDataItemSet";
            this.tsmiDataItemSet.Size = new System.Drawing.Size(124, 22);
            this.tsmiDataItemSet.Text = "层段设置";
            this.tsmiDataItemSet.Click += new System.EventHandler(this.tsmiDataItemSet_Click);
            // 
            // tsmiBodyLogValue
            // 
            this.tsmiBodyLogValue.Name = "tsmiBodyLogValue";
            this.tsmiBodyLogValue.Size = new System.Drawing.Size(124, 22);
            this.tsmiBodyLogValue.Text = "曲线读值";
            this.tsmiBodyLogValue.Click += new System.EventHandler(this.tsmiBodyLogValue_Click);
            // 
            // tsmiSelectDel
            // 
            this.tsmiSelectDel.Name = "tsmiSelectDel";
            this.tsmiSelectDel.Size = new System.Drawing.Size(124, 22);
            this.tsmiSelectDel.Text = "删除选中";
            this.tsmiSelectDel.Click += new System.EventHandler(this.tsmiSelectDel_Click);
            // 
            // tsmiCrossPlot
            // 
            this.tsmiCrossPlot.Name = "tsmiCrossPlot";
            this.tsmiCrossPlot.Size = new System.Drawing.Size(124, 22);
            this.tsmiCrossPlot.Text = "交汇分析";
            this.tsmiCrossPlot.Click += new System.EventHandler(this.tsmiCrossPlot_Click);
            // 
            // tsmiIntervalStastics
            // 
            this.tsmiIntervalStastics.Name = "tsmiIntervalStastics";
            this.tsmiIntervalStastics.Size = new System.Drawing.Size(124, 22);
            this.tsmiIntervalStastics.Text = "截断统计";
            this.tsmiIntervalStastics.ToolTipText = "用标尺截断统计测井段值";
            this.tsmiIntervalStastics.Click += new System.EventHandler(this.tsmiIntervalStastics_Click);
            // 
            // tsmiMark
            // 
            this.tsmiMark.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRulerMarkShow,
            this.tsmiRulerMarkHide});
            this.tsmiMark.Name = "tsmiMark";
            this.tsmiMark.Size = new System.Drawing.Size(124, 22);
            this.tsmiMark.Text = "移动标尺";
            // 
            // tsmiRulerMarkShow
            // 
            this.tsmiRulerMarkShow.Name = "tsmiRulerMarkShow";
            this.tsmiRulerMarkShow.Size = new System.Drawing.Size(100, 22);
            this.tsmiRulerMarkShow.Text = "显示";
            this.tsmiRulerMarkShow.Click += new System.EventHandler(this.tsmiRulerMarkShow_Click);
            // 
            // tsmiRulerMarkHide
            // 
            this.tsmiRulerMarkHide.Name = "tsmiRulerMarkHide";
            this.tsmiRulerMarkHide.Size = new System.Drawing.Size(100, 22);
            this.tsmiRulerMarkHide.Text = "隐藏";
            this.tsmiRulerMarkHide.Click += new System.EventHandler(this.tsmiRulerMarkHide_Click);
            // 
            // webBrowserHead
            // 
            this.webBrowserHead.ContextMenuStrip = this.cmsWBHead;
            this.webBrowserHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.webBrowserHead.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserHead.Location = new System.Drawing.Point(0, 0);
            this.webBrowserHead.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserHead.Name = "webBrowserHead";
            this.webBrowserHead.ScrollBarsEnabled = false;
            this.webBrowserHead.Size = new System.Drawing.Size(450, 102);
            this.webBrowserHead.TabIndex = 1;
            this.webBrowserHead.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserHead_DocumentCompleted);
            // 
            // cmsWBHead
            // 
            this.cmsWBHead.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHeadTrackSet,
            this.tsmiHeadTrackDataLoad,
            this.tsmiHeadTrackRemove,
            this.tsmiHeadTrackCopy,
            this.tsmiHeadTrackHide,
            this.tsmiHeadLogSet,
            this.tsmiHeadTrackAddLogCurve,
            this.tsmiHeadLogDataLoad,
            this.tsmiHeadLogTrackFill,
            this.tsmiHeadLogRemove,
            this.tsmiHeadLayerStastics,
            this.tsmiLoadSVG,
            this.tsmiHeadRefresh});
            this.cmsWBHead.Name = "cmsWBHead";
            this.cmsWBHead.Size = new System.Drawing.Size(125, 290);
            // 
            // tsmiHeadTrackSet
            // 
            this.tsmiHeadTrackSet.Name = "tsmiHeadTrackSet";
            this.tsmiHeadTrackSet.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadTrackSet.Text = "图道设置";
            this.tsmiHeadTrackSet.Click += new System.EventHandler(this.tsmiTrackSetting_Click);
            // 
            // tsmiHeadTrackDataLoad
            // 
            this.tsmiHeadTrackDataLoad.Name = "tsmiHeadTrackDataLoad";
            this.tsmiHeadTrackDataLoad.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadTrackDataLoad.Text = "图道数据";
            this.tsmiHeadTrackDataLoad.Click += new System.EventHandler(this.tsmiTrackDataLoad_Click);
            // 
            // tsmiHeadTrackRemove
            // 
            this.tsmiHeadTrackRemove.Name = "tsmiHeadTrackRemove";
            this.tsmiHeadTrackRemove.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadTrackRemove.Text = "图道移除";
            this.tsmiHeadTrackRemove.Click += new System.EventHandler(this.tsmiTrackRemove_Click);
            // 
            // tsmiHeadTrackCopy
            // 
            this.tsmiHeadTrackCopy.Name = "tsmiHeadTrackCopy";
            this.tsmiHeadTrackCopy.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadTrackCopy.Text = "图道复制";
            this.tsmiHeadTrackCopy.Click += new System.EventHandler(this.tsmiHeadTrackCopy_Click);
            // 
            // tsmiHeadTrackHide
            // 
            this.tsmiHeadTrackHide.Name = "tsmiHeadTrackHide";
            this.tsmiHeadTrackHide.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadTrackHide.Text = "图道隐藏";
            this.tsmiHeadTrackHide.Click += new System.EventHandler(this.tsmiTrackHide_Click);
            // 
            // tsmiHeadLogSet
            // 
            this.tsmiHeadLogSet.Name = "tsmiHeadLogSet";
            this.tsmiHeadLogSet.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadLogSet.Text = "曲线设置";
            this.tsmiHeadLogSet.Click += new System.EventHandler(this.tsmiTrackSetLogCurve_Click);
            // 
            // tsmiHeadTrackAddLogCurve
            // 
            this.tsmiHeadTrackAddLogCurve.Name = "tsmiHeadTrackAddLogCurve";
            this.tsmiHeadTrackAddLogCurve.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadTrackAddLogCurve.Text = "曲线增加";
            this.tsmiHeadTrackAddLogCurve.Click += new System.EventHandler(this.tsmiTrackAddLogCurve_Click);
            // 
            // tsmiHeadLogDataLoad
            // 
            this.tsmiHeadLogDataLoad.Name = "tsmiHeadLogDataLoad";
            this.tsmiHeadLogDataLoad.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadLogDataLoad.Text = "曲线数据";
            this.tsmiHeadLogDataLoad.Click += new System.EventHandler(this.tsmiLogDataLoad_Click);
            // 
            // tsmiHeadLogTrackFill
            // 
            this.tsmiHeadLogTrackFill.Name = "tsmiHeadLogTrackFill";
            this.tsmiHeadLogTrackFill.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadLogTrackFill.Text = "曲线填充";
            this.tsmiHeadLogTrackFill.Click += new System.EventHandler(this.tsmiHeadLogTrackFill_Click);
            // 
            // tsmiHeadLogRemove
            // 
            this.tsmiHeadLogRemove.Name = "tsmiHeadLogRemove";
            this.tsmiHeadLogRemove.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadLogRemove.Text = "曲线移除";
            this.tsmiHeadLogRemove.Click += new System.EventHandler(this.tsmiHeadLogRemove_Click);
            // 
            // tsmiHeadLayerStastics
            // 
            this.tsmiHeadLayerStastics.Name = "tsmiHeadLayerStastics";
            this.tsmiHeadLayerStastics.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadLayerStastics.Text = "层段汇总";
            this.tsmiHeadLayerStastics.ToolTipText = "图道层段数据分层统计";
            this.tsmiHeadLayerStastics.Click += new System.EventHandler(this.tsmiLayerStastics_Click);
            // 
            // tsmiLoadSVG
            // 
            this.tsmiLoadSVG.Name = "tsmiLoadSVG";
            this.tsmiLoadSVG.Size = new System.Drawing.Size(124, 22);
            this.tsmiLoadSVG.Text = "井图加载";
            this.tsmiLoadSVG.Click += new System.EventHandler(this.tsmiLoadSVG_Click);
            // 
            // tsmiHeadRefresh
            // 
            this.tsmiHeadRefresh.Name = "tsmiHeadRefresh";
            this.tsmiHeadRefresh.Size = new System.Drawing.Size(124, 22);
            this.tsmiHeadRefresh.Text = "井图刷新";
            this.tsmiHeadRefresh.Click += new System.EventHandler(this.tsmiHeadRefresh_Click);
            // 
            // lblCrossH
            // 
            this.lblCrossH.BackColor = System.Drawing.Color.Black;
            this.lblCrossH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCrossH.Location = new System.Drawing.Point(3, 222);
            this.lblCrossH.Name = "lblCrossH";
            this.lblCrossH.Size = new System.Drawing.Size(200, 1);
            this.lblCrossH.TabIndex = 2;
            // 
            // statusStripWellPanel
            // 
            this.statusStripWellPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblDepth,
            this.tssCurTrack,
            this.tssCurItem,
            this.tsslblAna});
            this.statusStripWellPanel.Location = new System.Drawing.Point(0, 623);
            this.statusStripWellPanel.Name = "statusStripWellPanel";
            this.statusStripWellPanel.Size = new System.Drawing.Size(450, 22);
            this.statusStripWellPanel.TabIndex = 6;
            this.statusStripWellPanel.Text = "statusStripWellPanel";
            // 
            // tsslblDepth
            // 
            this.tsslblDepth.Name = "tsslblDepth";
            this.tsslblDepth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsslblDepth.Size = new System.Drawing.Size(32, 17);
            this.tsslblDepth.Text = "深度";
            // 
            // tssCurTrack
            // 
            this.tssCurTrack.Name = "tssCurTrack";
            this.tssCurTrack.Size = new System.Drawing.Size(32, 17);
            this.tssCurTrack.Text = "图道";
            // 
            // tssCurItem
            // 
            this.tssCurItem.Name = "tssCurItem";
            this.tssCurItem.Size = new System.Drawing.Size(32, 17);
            this.tssCurItem.Text = "数据";
            // 
            // tsslblAna
            // 
            this.tsslblAna.Name = "tsslblAna";
            this.tsslblAna.Size = new System.Drawing.Size(32, 17);
            this.tsslblAna.Text = "分析";
            // 
            // lblCrossV
            // 
            this.lblCrossV.BackColor = System.Drawing.Color.Black;
            this.lblCrossV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCrossV.Location = new System.Drawing.Point(5, 245);
            this.lblCrossV.Name = "lblCrossV";
            this.lblCrossV.Size = new System.Drawing.Size(1, 800);
            this.lblCrossV.TabIndex = 7;
            // 
            // lblDrawMove
            // 
            this.lblDrawMove.BackColor = System.Drawing.Color.DarkGray;
            this.lblDrawMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrawMove.Location = new System.Drawing.Point(0, 0);
            this.lblDrawMove.Name = "lblDrawMove";
            this.lblDrawMove.Size = new System.Drawing.Size(1, 200);
            this.lblDrawMove.TabIndex = 8;
            this.lblDrawMove.Visible = false;
            // 
            // lblmarker
            // 
            this.lblmarker.AutoSize = true;
            this.lblmarker.Location = new System.Drawing.Point(0, 0);
            this.lblmarker.Name = "lblmarker";
            this.lblmarker.Size = new System.Drawing.Size(0, 12);
            this.lblmarker.TabIndex = 9;
            // 
            // tsmiDataFromWellNeighbor
            // 
            this.tsmiDataFromWellNeighbor.Name = "tsmiDataFromWellNeighbor";
            this.tsmiDataFromWellNeighbor.Size = new System.Drawing.Size(124, 22);
            this.tsmiDataFromWellNeighbor.Text = "邻井采样";
            // 
            // wellPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblmarker);
            this.Controls.Add(this.lblDrawMove);
            this.Controls.Add(this.lblCrossV);
            this.Controls.Add(this.lblCrossH);
            this.Controls.Add(this.webBrowserHead);
            this.Controls.Add(this.webBrowserBody);
            this.Controls.Add(this.statusStripWellPanel);
            this.Name = "wellPanel";
            this.Size = new System.Drawing.Size(450, 645);
            this.cmsWBBody.ResumeLayout(false);
            this.cmsWBHead.ResumeLayout(false);
            this.statusStripWellPanel.ResumeLayout(false);
            this.statusStripWellPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.WebBrowser webBrowserBody;
        public System.Windows.Forms.WebBrowser webBrowserHead;
        private System.Windows.Forms.ToolStripStatusLabel tssCurTrack;
        private System.Windows.Forms.ToolStripMenuItem tsmiMark;
        private System.Windows.Forms.ToolStripMenuItem tsmiRulerMarkShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiRulerMarkHide;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDepth;
        public System.Windows.Forms.Label lblCrossV;
        public System.Windows.Forms.Label lblCrossH;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataItemSet;
        private System.Windows.Forms.ContextMenuStrip cmsWBHead;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadTrackSet;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadTrackRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadTrackHide;
        private System.Windows.Forms.ToolStripMenuItem tsmiBodyLogSet;
        private System.Windows.Forms.ToolStripStatusLabel tssCurItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectDel;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadTrackAddLogCurve;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadTrackDataLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadLogDataLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataItemAdjustTop;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataItemAdjustBot;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataItemInsert;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadLogSet;
        private System.Windows.Forms.ToolStripStatusLabel tsslblAna;
        public System.Windows.Forms.ToolStripMenuItem tsmiLoadSVG;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadLogTrackFill;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadTrackCopy;
        public System.Windows.Forms.ContextMenuStrip cmsWBBody;
        public System.Windows.Forms.StatusStrip statusStripWellPanel;
        public System.Windows.Forms.Label lblDrawMove;
        private System.Windows.Forms.ToolStripMenuItem tsmiIntervalStastics;
        private System.Windows.Forms.ToolStripMenuItem tsmiCrossPlot;
        private System.Windows.Forms.ToolStripMenuItem tsmiBodyLogValue;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadLogRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiHeadLayerStastics;
        private System.Windows.Forms.Label lblmarker;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataFromWellNeighbor;

    }
}
