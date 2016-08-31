namespace DOGPlatform
{
    partial class FormMakeNewLog
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
            this.progressBarCalc = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxFunctionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxParameters = new System.Windows.Forms.TextBox();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.clmHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHeadNameExpr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmHeadPara = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUse = new System.Windows.Forms.Button();
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.cbbLog = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectLog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nTBXbot = new DOGPlatform.controls.NumericTextBox();
            this.nTBXtop = new DOGPlatform.controls.NumericTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarCalc
            // 
            this.progressBarCalc.Location = new System.Drawing.Point(114, 191);
            this.progressBarCalc.Name = "progressBarCalc";
            this.progressBarCalc.Size = new System.Drawing.Size(366, 21);
            this.progressBarCalc.TabIndex = 61;
            this.progressBarCalc.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxFunctionName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxParameters);
            this.panel1.Controls.Add(this.progressBarCalc);
            this.panel1.Controls.Add(this.dgvDataTable);
            this.panel1.Controls.Add(this.textBoxFunction);
            this.panel1.Controls.Add(this.buttonRun);
            this.panel1.Location = new System.Drawing.Point(7, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 494);
            this.panel1.TabIndex = 58;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(347, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 41;
            this.button1.Text = "入库";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "函数名称";
            // 
            // tbxFunctionName
            // 
            this.tbxFunctionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFunctionName.Location = new System.Drawing.Point(84, 40);
            this.tbxFunctionName.Name = "tbxFunctionName";
            this.tbxFunctionName.Size = new System.Drawing.Size(880, 22);
            this.tbxFunctionName.TabIndex = 39;
            this.tbxFunctionName.Text = "泥质含量计算";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "函数 y=f(x)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "参数设置及赋值:";
            // 
            // textBoxParameters
            // 
            this.textBoxParameters.AcceptsReturn = true;
            this.textBoxParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxParameters.Location = new System.Drawing.Point(114, 68);
            this.textBoxParameters.Multiline = true;
            this.textBoxParameters.Name = "textBoxParameters";
            this.textBoxParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxParameters.Size = new System.Drawing.Size(227, 117);
            this.textBoxParameters.TabIndex = 31;
            this.textBoxParameters.Text = "GRmax=4.0\r\nGRmin=0.1";
            this.textBoxParameters.WordWrap = false;
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFunction.Location = new System.Drawing.Point(84, 12);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(880, 22);
            this.textBoxFunction.TabIndex = 30;
            this.textBoxFunction.Text = "GRmax*(x)/(GrMax-GRmin)";
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.Location = new System.Drawing.Point(347, 74);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(120, 31);
            this.buttonRun.TabIndex = 29;
            this.buttonRun.Text = "计算";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmHeaderType,
            this.clmHeadName,
            this.clmHeadNameExpr,
            this.clmHeadPara});
            this.lvHistory.Location = new System.Drawing.Point(1, 25);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(464, 333);
            this.lvHistory.TabIndex = 41;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            // 
            // clmHeaderType
            // 
            this.clmHeaderType.Text = "公式类别";
            // 
            // clmHeadName
            // 
            this.clmHeadName.Text = "公式名称";
            this.clmHeadName.Width = 75;
            // 
            // clmHeadNameExpr
            // 
            this.clmHeadNameExpr.Text = "表达式";
            this.clmHeadNameExpr.Width = 157;
            // 
            // clmHeadPara
            // 
            this.clmHeadPara.Text = "参数变量";
            this.clmHeadPara.Width = 346;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(96, 364);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(85, 21);
            this.buttonDelete.TabIndex = 38;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUse
            // 
            this.buttonUse.Location = new System.Drawing.Point(6, 364);
            this.buttonUse.Name = "buttonUse";
            this.buttonUse.Size = new System.Drawing.Size(84, 21);
            this.buttonUse.TabIndex = 34;
            this.buttonUse.Text = "使用";
            this.buttonUse.UseVisualStyleBackColor = true;
            this.buttonUse.Click += new System.EventHandler(this.buttonUse_Click);
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.Location = new System.Drawing.Point(3, 218);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowTemplate.Height = 23;
            this.dgvDataTable.Size = new System.Drawing.Size(477, 241);
            this.dgvDataTable.TabIndex = 62;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(250, 18);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 105;
            this.label33.Text = "底深";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(150, 18);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 106;
            this.label34.Text = "顶深";
            // 
            // cbbLog
            // 
            this.cbbLog.FormattingEnabled = true;
            this.cbbLog.Location = new System.Drawing.Point(47, 14);
            this.cbbLog.Name = "cbbLog";
            this.cbbLog.Size = new System.Drawing.Size(83, 20);
            this.cbbLog.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 109;
            this.label3.Text = "曲线";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvHistory);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonUse);
            this.groupBox1.Location = new System.Drawing.Point(499, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 391);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "公式库";
            // 
            // btnSelectLog
            // 
            this.btnSelectLog.Location = new System.Drawing.Point(341, 14);
            this.btnSelectLog.Name = "btnSelectLog";
            this.btnSelectLog.Size = new System.Drawing.Size(66, 21);
            this.btnSelectLog.TabIndex = 42;
            this.btnSelectLog.Text = "选择";
            this.btnSelectLog.UseVisualStyleBackColor = true;
            this.btnSelectLog.Click += new System.EventHandler(this.btnSelectLog_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 112;
            this.label5.Text = "计算结果:";
            // 
            // nTBXbot
            // 
            this.nTBXbot.Location = new System.Drawing.Point(281, 13);
            this.nTBXbot.Name = "nTBXbot";
            this.nTBXbot.Size = new System.Drawing.Size(54, 21);
            this.nTBXbot.TabIndex = 108;
            this.nTBXbot.Text = "100";
            // 
            // nTBXtop
            // 
            this.nTBXtop.Location = new System.Drawing.Point(188, 14);
            this.nTBXtop.Name = "nTBXtop";
            this.nTBXtop.Size = new System.Drawing.Size(56, 21);
            this.nTBXtop.TabIndex = 107;
            this.nTBXtop.Text = "0";
            // 
            // FormMakeNewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 547);
            this.Controls.Add(this.btnSelectLog);
            this.Controls.Add(this.cbbLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.nTBXbot);
            this.Controls.Add(this.nTBXtop);
            this.Controls.Add(this.panel1);
            this.Name = "FormMakeNewLog";
            this.Text = "曲线计算";
            this.Load += new System.EventHandler(this.FormMakeNewLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarCalc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxParameters;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private controls.NumericTextBox nTBXbot;
        private controls.NumericTextBox nTBXtop;
        private System.Windows.Forms.ComboBox cbbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxFunctionName;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader clmHeadName;
        private System.Windows.Forms.ColumnHeader clmHeadNameExpr;
        private System.Windows.Forms.ColumnHeader clmHeadPara;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader clmHeaderType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSelectLog;
        private System.Windows.Forms.Label label5;
    }
}