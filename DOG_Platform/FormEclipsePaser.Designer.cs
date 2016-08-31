namespace DOGPlatform
{
    partial class FormEclipsePaser
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
            this.tbcVoronoi = new System.Windows.Forms.TabControl();
            this.tbgVoronoiMap = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbxFilepath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxNumJ = new System.Windows.Forms.TextBox();
            this.tbxNumI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReadFileECL = new System.Windows.Forms.Button();
            this.panelEclipse = new System.Windows.Forms.Panel();
            this.tbxInfor = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // tbcVoronoi
            // 
            this.tbcVoronoi.Controls.Add(this.tbgVoronoiMap);
            this.tbcVoronoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcVoronoi.Location = new System.Drawing.Point(0, 0);
            this.tbcVoronoi.Name = "tbcVoronoi";
            this.tbcVoronoi.SelectedIndex = 0;
            this.tbcVoronoi.Size = new System.Drawing.Size(1204, 703);
            this.tbcVoronoi.TabIndex = 3;
            // 
            // tbgVoronoiMap
            // 
            this.tbgVoronoiMap.Controls.Add(this.splitContainer2);
            this.tbgVoronoiMap.Location = new System.Drawing.Point(4, 22);
            this.tbgVoronoiMap.Name = "tbgVoronoiMap";
            this.tbgVoronoiMap.Padding = new System.Windows.Forms.Padding(3);
            this.tbgVoronoiMap.Size = new System.Drawing.Size(1196, 677);
            this.tbgVoronoiMap.TabIndex = 5;
            this.tbgVoronoiMap.Text = "解析eclipse相";
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
            this.splitContainer2.Panel2.Controls.Add(this.tbxInfor);
            this.splitContainer2.Size = new System.Drawing.Size(1190, 671);
            this.splitContainer2.SplitterDistance = 834;
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
            this.splitContainer1.Panel1.Controls.Add(this.tbxFilepath);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.tbxNumJ);
            this.splitContainer1.Panel1.Controls.Add(this.tbxNumI);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnDraw);
            this.splitContainer1.Panel1.Controls.Add(this.pnlColor);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnReadFileECL);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelEclipse);
            this.splitContainer1.Size = new System.Drawing.Size(834, 671);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 3;
            // 
            // tbxFilepath
            // 
            this.tbxFilepath.Location = new System.Drawing.Point(52, 12);
            this.tbxFilepath.Name = "tbxFilepath";
            this.tbxFilepath.Size = new System.Drawing.Size(651, 21);
            this.tbxFilepath.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "I";
            // 
            // tbxNumJ
            // 
            this.tbxNumJ.Location = new System.Drawing.Point(234, 50);
            this.tbxNumJ.Name = "tbxNumJ";
            this.tbxNumJ.Size = new System.Drawing.Size(71, 21);
            this.tbxNumJ.TabIndex = 37;
            // 
            // tbxNumI
            // 
            this.tbxNumI.Location = new System.Drawing.Point(129, 51);
            this.tbxNumI.Name = "tbxNumI";
            this.tbxNumI.Size = new System.Drawing.Size(63, 21);
            this.tbxNumI.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "J";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(516, 52);
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
            this.pnlColor.Location = new System.Drawing.Point(52, 52);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(41, 18);
            this.pnlColor.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 55);
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
            // btnReadFileECL
            // 
            this.btnReadFileECL.Location = new System.Drawing.Point(720, 10);
            this.btnReadFileECL.Name = "btnReadFileECL";
            this.btnReadFileECL.Size = new System.Drawing.Size(90, 23);
            this.btnReadFileECL.TabIndex = 16;
            this.btnReadFileECL.Text = "选择";
            this.btnReadFileECL.UseVisualStyleBackColor = true;
            this.btnReadFileECL.Click += new System.EventHandler(this.btnReadFileECL_Click);
            // 
            // panelEclipse
            // 
            this.panelEclipse.BackColor = System.Drawing.Color.White;
            this.panelEclipse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEclipse.Location = new System.Drawing.Point(0, 0);
            this.panelEclipse.Name = "panelEclipse";
            this.panelEclipse.Size = new System.Drawing.Size(500, 500);
            this.panelEclipse.TabIndex = 2;
            this.panelEclipse.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVoronoi_Paint);
            // 
            // tbxInfor
            // 
            this.tbxInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxInfor.Location = new System.Drawing.Point(0, 0);
            this.tbxInfor.Multiline = true;
            this.tbxInfor.Name = "tbxInfor";
            this.tbxInfor.Size = new System.Drawing.Size(352, 671);
            this.tbxInfor.TabIndex = 0;
            // 
            // FormEclipsePaser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 703);
            this.Controls.Add(this.tbcVoronoi);
            this.Name = "FormEclipsePaser";
            this.Text = "Eclipse解析";
            this.tbcVoronoi.ResumeLayout(false);
            this.tbgVoronoiMap.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcVoronoi;
        private System.Windows.Forms.TabPage tbgVoronoiMap;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxNumJ;
        private System.Windows.Forms.TextBox tbxNumI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReadFileECL;
        private System.Windows.Forms.Panel panelEclipse;
        private System.Windows.Forms.TextBox tbxFilepath;
        private System.Windows.Forms.TextBox tbxInfor;

    }
}