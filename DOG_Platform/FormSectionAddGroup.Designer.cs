namespace DOGPlatform
{
    partial class FormSectionAddGroup
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
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxJH = new System.Windows.Forms.ListBox();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btn_deleteWell = new System.Windows.Forms.Button();
            this.btn_addWell = new System.Windows.Forms.Button();
            this.lbxJHSeclected = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nUDbottomDepthDown = new System.Windows.Forms.NumericUpDown();
            this.nUDtopDepthUp = new System.Windows.Forms.NumericUpDown();
            this.btnSetLayerDepth = new System.Windows.Forms.Button();
            this.cbbTopXCM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbBottomXCM = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblChooseModle = new System.Windows.Forms.Label();
            this.btnDataPre = new System.Windows.Forms.Button();
            this.cbbSelectTemplate = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDbottomDepthDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDtopDepthUp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectAll.Location = new System.Drawing.Point(156, 132);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(42, 26);
            this.btnSelectAll.TabIndex = 46;
            this.btnSelectAll.Text = "=>";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, -45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 45;
            // 
            // lbxJH
            // 
            this.lbxJH.FormattingEnabled = true;
            this.lbxJH.ItemHeight = 12;
            this.lbxJH.Location = new System.Drawing.Point(12, 15);
            this.lbxJH.Margin = new System.Windows.Forms.Padding(2);
            this.lbxJH.Name = "lbxJH";
            this.lbxJH.Size = new System.Drawing.Size(114, 244);
            this.lbxJH.TabIndex = 44;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectNone.Location = new System.Drawing.Point(156, 172);
            this.btnSelectNone.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(42, 26);
            this.btnSelectNone.TabIndex = 43;
            this.btnSelectNone.Text = "<=";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btn_deleteWell
            // 
            this.btn_deleteWell.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deleteWell.Location = new System.Drawing.Point(156, 96);
            this.btn_deleteWell.Margin = new System.Windows.Forms.Padding(2);
            this.btn_deleteWell.Name = "btn_deleteWell";
            this.btn_deleteWell.Size = new System.Drawing.Size(42, 26);
            this.btn_deleteWell.TabIndex = 41;
            this.btn_deleteWell.Text = "<-";
            this.btn_deleteWell.UseVisualStyleBackColor = true;
            this.btn_deleteWell.Click += new System.EventHandler(this.btn_deleteWell_Click);
            // 
            // btn_addWell
            // 
            this.btn_addWell.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addWell.Location = new System.Drawing.Point(156, 58);
            this.btn_addWell.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addWell.Name = "btn_addWell";
            this.btn_addWell.Size = new System.Drawing.Size(42, 26);
            this.btn_addWell.TabIndex = 42;
            this.btn_addWell.Text = "->";
            this.btn_addWell.UseVisualStyleBackColor = true;
            this.btn_addWell.Click += new System.EventHandler(this.btn_addWell_Click);
            // 
            // lbxJHSeclected
            // 
            this.lbxJHSeclected.FormattingEnabled = true;
            this.lbxJHSeclected.ItemHeight = 12;
            this.lbxJHSeclected.Location = new System.Drawing.Point(233, 15);
            this.lbxJHSeclected.Margin = new System.Windows.Forms.Padding(2);
            this.lbxJHSeclected.Name = "lbxJHSeclected";
            this.lbxJHSeclected.Size = new System.Drawing.Size(114, 244);
            this.lbxJHSeclected.TabIndex = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nUDbottomDepthDown);
            this.groupBox3.Controls.Add(this.nUDtopDepthUp);
            this.groupBox3.Controls.Add(this.btnSetLayerDepth);
            this.groupBox3.Controls.Add(this.cbbTopXCM);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbbBottomXCM);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(12, 272);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(342, 102);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "根据层位设置井段绘制深度";
            // 
            // nUDbottomDepthDown
            // 
            this.nUDbottomDepthDown.AllowDrop = true;
            this.nUDbottomDepthDown.DecimalPlaces = 1;
            this.nUDbottomDepthDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nUDbottomDepthDown.Location = new System.Drawing.Point(200, 57);
            this.nUDbottomDepthDown.Name = "nUDbottomDepthDown";
            this.nUDbottomDepthDown.Size = new System.Drawing.Size(40, 21);
            this.nUDbottomDepthDown.TabIndex = 26;
            this.nUDbottomDepthDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // nUDtopDepthUp
            // 
            this.nUDtopDepthUp.AllowDrop = true;
            this.nUDtopDepthUp.DecimalPlaces = 1;
            this.nUDtopDepthUp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nUDtopDepthUp.Location = new System.Drawing.Point(200, 27);
            this.nUDtopDepthUp.Name = "nUDtopDepthUp";
            this.nUDtopDepthUp.Size = new System.Drawing.Size(40, 21);
            this.nUDtopDepthUp.TabIndex = 26;
            this.nUDtopDepthUp.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // btnSetLayerDepth
            // 
            this.btnSetLayerDepth.Location = new System.Drawing.Point(267, 39);
            this.btnSetLayerDepth.Name = "btnSetLayerDepth";
            this.btnSetLayerDepth.Size = new System.Drawing.Size(64, 23);
            this.btnSetLayerDepth.TabIndex = 63;
            this.btnSetLayerDepth.Text = "层位确认";
            this.btnSetLayerDepth.UseVisualStyleBackColor = true;
            this.btnSetLayerDepth.Click += new System.EventHandler(this.btnCollectWells_Click);
            // 
            // cbbTopXCM
            // 
            this.cbbTopXCM.FormattingEnabled = true;
            this.cbbTopXCM.Location = new System.Drawing.Point(56, 28);
            this.cbbTopXCM.Name = "cbbTopXCM";
            this.cbbTopXCM.Size = new System.Drawing.Size(122, 20);
            this.cbbTopXCM.TabIndex = 7;
            this.cbbTopXCM.SelectedIndexChanged += new System.EventHandler(this.cbbTopXCM_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "米";
            // 
            // cbbBottomXCM
            // 
            this.cbbBottomXCM.FormattingEnabled = true;
            this.cbbBottomXCM.Location = new System.Drawing.Point(56, 58);
            this.cbbBottomXCM.Name = "cbbBottomXCM";
            this.cbbBottomXCM.Size = new System.Drawing.Size(122, 20);
            this.cbbBottomXCM.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "米";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "最上层";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "最下层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "+";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(184, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "-";
            // 
            // lblChooseModle
            // 
            this.lblChooseModle.AutoSize = true;
            this.lblChooseModle.Location = new System.Drawing.Point(12, 389);
            this.lblChooseModle.Name = "lblChooseModle";
            this.lblChooseModle.Size = new System.Drawing.Size(53, 12);
            this.lblChooseModle.TabIndex = 65;
            this.lblChooseModle.Text = "选择模板";
            // 
            // btnDataPre
            // 
            this.btnDataPre.Location = new System.Drawing.Point(258, 383);
            this.btnDataPre.Name = "btnDataPre";
            this.btnDataPre.Size = new System.Drawing.Size(96, 26);
            this.btnDataPre.TabIndex = 70;
            this.btnDataPre.Text = "确认";
            this.btnDataPre.UseVisualStyleBackColor = true;
            this.btnDataPre.Click += new System.EventHandler(this.btnDataPre_Click);
            // 
            // cbbSelectTemplate
            // 
            this.cbbSelectTemplate.FormattingEnabled = true;
            this.cbbSelectTemplate.Location = new System.Drawing.Point(67, 387);
            this.cbbSelectTemplate.Name = "cbbSelectTemplate";
            this.cbbSelectTemplate.Size = new System.Drawing.Size(176, 20);
            this.cbbSelectTemplate.TabIndex = 72;
            // 
            // FormSectionAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 437);
            this.Controls.Add(this.cbbSelectTemplate);
            this.Controls.Add(this.btnDataPre);
            this.Controls.Add(this.lblChooseModle);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxJH);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btn_deleteWell);
            this.Controls.Add(this.btn_addWell);
            this.Controls.Add(this.lbxJHSeclected);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSectionAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建剖面";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDbottomDepthDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDtopDepthUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxJH;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btn_deleteWell;
        private System.Windows.Forms.Button btn_addWell;
        protected System.Windows.Forms.ListBox lbxJHSeclected;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nUDbottomDepthDown;
        private System.Windows.Forms.NumericUpDown nUDtopDepthUp;
        protected System.Windows.Forms.ComboBox cbbTopXCM;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ComboBox cbbBottomXCM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblChooseModle;
        private System.Windows.Forms.Button btnSetLayerDepth;
        private System.Windows.Forms.Button btnDataPre;
        private System.Windows.Forms.ComboBox cbbSelectTemplate;
    }
}