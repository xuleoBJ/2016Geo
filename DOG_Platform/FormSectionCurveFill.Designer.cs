namespace DOGPlatform
{
    partial class FormSectionCurveFill
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbgFill = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.nUDFillOpacity = new System.Windows.Forms.NumericUpDown();
            this.rdbCutOff = new System.Windows.Forms.RadioButton();
            this.rdbSubLog = new System.Windows.Forms.RadioButton();
            this.nTBXcutOffvalue = new DOGPlatform.controls.NumericTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbxIDTrackFill = new System.Windows.Forms.TextBox();
            this.btn_downItem = new System.Windows.Forms.Button();
            this.btn_upItem = new System.Windows.Forms.Button();
            this.btn_deleteItem = new System.Windows.Forms.Button();
            this.btn_addItem = new System.Windows.Forms.Button();
            this.lbxFillItems = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbLogMain = new System.Windows.Forms.ComboBox();
            this.cbbLogSub = new System.Windows.Forms.ComboBox();
            this.nTBXBotDepth = new DOGPlatform.controls.NumericTextBox();
            this.nTBXTopDepth = new DOGPlatform.controls.NumericTextBox();
            this.lblBot = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSeleclFillColor = new System.Windows.Forms.Button();
            this.tbxFillColor = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tbgFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFillOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbgFill);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(302, 331);
            this.tabControl1.TabIndex = 68;
            // 
            // tbgFill
            // 
            this.tbgFill.Controls.Add(this.label3);
            this.tbgFill.Controls.Add(this.nUDFillOpacity);
            this.tbgFill.Controls.Add(this.rdbCutOff);
            this.tbgFill.Controls.Add(this.rdbSubLog);
            this.tbgFill.Controls.Add(this.nTBXcutOffvalue);
            this.tbgFill.Controls.Add(this.btnSave);
            this.tbgFill.Controls.Add(this.tbxIDTrackFill);
            this.tbgFill.Controls.Add(this.btn_downItem);
            this.tbgFill.Controls.Add(this.btn_upItem);
            this.tbgFill.Controls.Add(this.btn_deleteItem);
            this.tbgFill.Controls.Add(this.btn_addItem);
            this.tbgFill.Controls.Add(this.lbxFillItems);
            this.tbgFill.Controls.Add(this.btnCancel);
            this.tbgFill.Controls.Add(this.btnOK);
            this.tbgFill.Controls.Add(this.label2);
            this.tbgFill.Controls.Add(this.cbbLogMain);
            this.tbgFill.Controls.Add(this.cbbLogSub);
            this.tbgFill.Controls.Add(this.nTBXBotDepth);
            this.tbgFill.Controls.Add(this.nTBXTopDepth);
            this.tbgFill.Controls.Add(this.lblBot);
            this.tbgFill.Controls.Add(this.lblTop);
            this.tbgFill.Controls.Add(this.label1);
            this.tbgFill.Controls.Add(this.label4);
            this.tbgFill.Controls.Add(this.btnSeleclFillColor);
            this.tbgFill.Controls.Add(this.tbxFillColor);
            this.tbgFill.Location = new System.Drawing.Point(4, 22);
            this.tbgFill.Name = "tbgFill";
            this.tbgFill.Padding = new System.Windows.Forms.Padding(3);
            this.tbgFill.Size = new System.Drawing.Size(294, 305);
            this.tbgFill.TabIndex = 1;
            this.tbgFill.Text = "填充";
            this.tbgFill.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 117;
            this.label3.Text = "透明度";
            // 
            // nUDFillOpacity
            // 
            this.nUDFillOpacity.AllowDrop = true;
            this.nUDFillOpacity.DecimalPlaces = 1;
            this.nUDFillOpacity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDFillOpacity.Location = new System.Drawing.Point(206, 214);
            this.nUDFillOpacity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDFillOpacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDFillOpacity.Name = "nUDFillOpacity";
            this.nUDFillOpacity.Size = new System.Drawing.Size(57, 21);
            this.nUDFillOpacity.TabIndex = 118;
            this.nUDFillOpacity.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // rdbCutOff
            // 
            this.rdbCutOff.AutoSize = true;
            this.rdbCutOff.Location = new System.Drawing.Point(142, 139);
            this.rdbCutOff.Name = "rdbCutOff";
            this.rdbCutOff.Size = new System.Drawing.Size(59, 16);
            this.rdbCutOff.TabIndex = 116;
            this.rdbCutOff.Text = "cutOff";
            this.rdbCutOff.UseVisualStyleBackColor = true;
            this.rdbCutOff.CheckedChanged += new System.EventHandler(this.rdbCutOff_CheckedChanged);
            // 
            // rdbSubLog
            // 
            this.rdbSubLog.AutoSize = true;
            this.rdbSubLog.Checked = true;
            this.rdbSubLog.Location = new System.Drawing.Point(142, 106);
            this.rdbSubLog.Name = "rdbSubLog";
            this.rdbSubLog.Size = new System.Drawing.Size(59, 16);
            this.rdbSubLog.TabIndex = 115;
            this.rdbSubLog.TabStop = true;
            this.rdbSubLog.Text = "从曲线";
            this.rdbSubLog.UseVisualStyleBackColor = true;
            this.rdbSubLog.CheckedChanged += new System.EventHandler(this.rdbSubLog_CheckedChanged);
            // 
            // nTBXcutOffvalue
            // 
            this.nTBXcutOffvalue.Enabled = false;
            this.nTBXcutOffvalue.Location = new System.Drawing.Point(206, 139);
            this.nTBXcutOffvalue.Name = "nTBXcutOffvalue";
            this.nTBXcutOffvalue.Size = new System.Drawing.Size(71, 21);
            this.nTBXcutOffvalue.TabIndex = 114;
            this.nTBXcutOffvalue.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 264);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 113;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // tbxIDTrackFill
            // 
            this.tbxIDTrackFill.Location = new System.Drawing.Point(206, 16);
            this.tbxIDTrackFill.Name = "tbxIDTrackFill";
            this.tbxIDTrackFill.Size = new System.Drawing.Size(70, 21);
            this.tbxIDTrackFill.TabIndex = 112;
            this.tbxIDTrackFill.Text = "填充方案1";
            // 
            // btn_downItem
            // 
            this.btn_downItem.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_downItem.Location = new System.Drawing.Point(10, 158);
            this.btn_downItem.Margin = new System.Windows.Forms.Padding(2);
            this.btn_downItem.Name = "btn_downItem";
            this.btn_downItem.Size = new System.Drawing.Size(28, 24);
            this.btn_downItem.TabIndex = 111;
            this.btn_downItem.Text = "↓";
            this.btn_downItem.UseVisualStyleBackColor = true;
            this.btn_downItem.Click += new System.EventHandler(this.btn_downItem_Click);
            // 
            // btn_upItem
            // 
            this.btn_upItem.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_upItem.Location = new System.Drawing.Point(9, 121);
            this.btn_upItem.Margin = new System.Windows.Forms.Padding(2);
            this.btn_upItem.Name = "btn_upItem";
            this.btn_upItem.Size = new System.Drawing.Size(28, 27);
            this.btn_upItem.TabIndex = 110;
            this.btn_upItem.Text = "↑";
            this.btn_upItem.UseVisualStyleBackColor = true;
            this.btn_upItem.Click += new System.EventHandler(this.btn_upItem_Click);
            // 
            // btn_deleteItem
            // 
            this.btn_deleteItem.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deleteItem.Location = new System.Drawing.Point(9, 85);
            this.btn_deleteItem.Margin = new System.Windows.Forms.Padding(2);
            this.btn_deleteItem.Name = "btn_deleteItem";
            this.btn_deleteItem.Size = new System.Drawing.Size(28, 26);
            this.btn_deleteItem.TabIndex = 109;
            this.btn_deleteItem.Text = "-";
            this.btn_deleteItem.UseVisualStyleBackColor = true;
            this.btn_deleteItem.Click += new System.EventHandler(this.btn_deleteItem_Click);
            // 
            // btn_addItem
            // 
            this.btn_addItem.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addItem.Location = new System.Drawing.Point(9, 51);
            this.btn_addItem.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(28, 24);
            this.btn_addItem.TabIndex = 108;
            this.btn_addItem.Text = "+";
            this.btn_addItem.UseVisualStyleBackColor = true;
            this.btn_addItem.Click += new System.EventHandler(this.btn_addItem_Click);
            // 
            // lbxFillItems
            // 
            this.lbxFillItems.FormattingEnabled = true;
            this.lbxFillItems.ItemHeight = 12;
            this.lbxFillItems.Location = new System.Drawing.Point(43, 51);
            this.lbxFillItems.Name = "lbxFillItems";
            this.lbxFillItems.Size = new System.Drawing.Size(93, 184);
            this.lbxFillItems.TabIndex = 107;
            this.lbxFillItems.SelectedIndexChanged += new System.EventHandler(this.lbxFillItems_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(206, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 106;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(108, 264);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 105;
            this.btnOK.Text = "应用并关闭";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 104;
            this.label2.Text = "曲线";
            // 
            // cbbLogMain
            // 
            this.cbbLogMain.BackColor = System.Drawing.Color.White;
            this.cbbLogMain.FormattingEnabled = true;
            this.cbbLogMain.Items.AddRange(new object[] {
            "道边",
            "cutOff值",
            "曲线"});
            this.cbbLogMain.Location = new System.Drawing.Point(43, 16);
            this.cbbLogMain.Name = "cbbLogMain";
            this.cbbLogMain.Size = new System.Drawing.Size(93, 20);
            this.cbbLogMain.TabIndex = 103;
            // 
            // cbbLogSub
            // 
            this.cbbLogSub.BackColor = System.Drawing.Color.White;
            this.cbbLogSub.FormattingEnabled = true;
            this.cbbLogSub.Items.AddRange(new object[] {
            "道边",
            "cutOff值",
            "曲线"});
            this.cbbLogSub.Location = new System.Drawing.Point(207, 106);
            this.cbbLogSub.Name = "cbbLogSub";
            this.cbbLogSub.Size = new System.Drawing.Size(70, 20);
            this.cbbLogSub.TabIndex = 103;
            // 
            // nTBXBotDepth
            // 
            this.nTBXBotDepth.Location = new System.Drawing.Point(206, 75);
            this.nTBXBotDepth.Name = "nTBXBotDepth";
            this.nTBXBotDepth.Size = new System.Drawing.Size(70, 21);
            this.nTBXBotDepth.TabIndex = 102;
            this.nTBXBotDepth.Text = "3000";
            // 
            // nTBXTopDepth
            // 
            this.nTBXTopDepth.Location = new System.Drawing.Point(206, 43);
            this.nTBXTopDepth.Name = "nTBXTopDepth";
            this.nTBXTopDepth.Size = new System.Drawing.Size(70, 21);
            this.nTBXTopDepth.TabIndex = 101;
            this.nTBXTopDepth.Text = "0";
            // 
            // lblBot
            // 
            this.lblBot.AutoSize = true;
            this.lblBot.Location = new System.Drawing.Point(152, 75);
            this.lblBot.Name = "lblBot";
            this.lblBot.Size = new System.Drawing.Size(53, 12);
            this.lblBot.TabIndex = 99;
            this.lblBot.Text = "填充底深";
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(152, 46);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(53, 12);
            this.lblTop.TabIndex = 100;
            this.lblTop.Text = "填充顶深";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 95;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 94;
            this.label4.Text = "填充方案名";
            // 
            // btnSeleclFillColor
            // 
            this.btnSeleclFillColor.Location = new System.Drawing.Point(142, 175);
            this.btnSeleclFillColor.Name = "btnSeleclFillColor";
            this.btnSeleclFillColor.Size = new System.Drawing.Size(63, 23);
            this.btnSeleclFillColor.TabIndex = 93;
            this.btnSeleclFillColor.Text = "颜色填充";
            this.btnSeleclFillColor.UseVisualStyleBackColor = true;
            this.btnSeleclFillColor.Click += new System.EventHandler(this.btnSeleclFillColor_Click);
            // 
            // tbxFillColor
            // 
            this.tbxFillColor.Location = new System.Drawing.Point(207, 177);
            this.tbxFillColor.MaxLength = 7;
            this.tbxFillColor.Name = "tbxFillColor";
            this.tbxFillColor.Size = new System.Drawing.Size(66, 21);
            this.tbxFillColor.TabIndex = 92;
            this.tbxFillColor.Text = "#FF0000";
            // 
            // FormSectionCurveFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 331);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormSectionCurveFill";
            this.Text = "填充管理";
            this.tabControl1.ResumeLayout(false);
            this.tbgFill.ResumeLayout(false);
            this.tbgFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFillOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbgFill;
        private System.Windows.Forms.ComboBox cbbLogSub;
        private controls.NumericTextBox nTBXBotDepth;
        private controls.NumericTextBox nTBXTopDepth;
        private System.Windows.Forms.Label lblBot;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSeleclFillColor;
        private System.Windows.Forms.TextBox tbxFillColor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox lbxFillItems;
        private System.Windows.Forms.Button btn_downItem;
        private System.Windows.Forms.Button btn_upItem;
        private System.Windows.Forms.Button btn_deleteItem;
        private System.Windows.Forms.Button btn_addItem;
        private System.Windows.Forms.TextBox tbxIDTrackFill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbLogMain;
        private System.Windows.Forms.Label label1;
        private controls.NumericTextBox nTBXcutOffvalue;
        private System.Windows.Forms.RadioButton rdbCutOff;
        private System.Windows.Forms.RadioButton rdbSubLog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUDFillOpacity;
    }
}