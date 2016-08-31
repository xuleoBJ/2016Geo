namespace DOGPlatform
{
    partial class FormSettingSectionDepthRuler
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nUDTrackFontSize = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.nUDmainTick = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDminTick = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbRulerType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDmainTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDminTick)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 67;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(51, 154);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 66;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nUDTrackFontSize
            // 
            this.nUDTrackFontSize.AllowDrop = true;
            this.nUDTrackFontSize.Location = new System.Drawing.Point(84, 110);
            this.nUDTrackFontSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nUDTrackFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTrackFontSize.Name = "nUDTrackFontSize";
            this.nUDTrackFontSize.Size = new System.Drawing.Size(54, 21);
            this.nUDTrackFontSize.TabIndex = 32;
            this.nUDTrackFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDTrackFontSize.ValueChanged += new System.EventHandler(this.nUDTrackFontSize_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(25, 114);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(53, 12);
            this.label50.TabIndex = 31;
            this.label50.Text = "刻度字号";
            // 
            // nUDmainTick
            // 
            this.nUDmainTick.AllowDrop = true;
            this.nUDmainTick.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDmainTick.Location = new System.Drawing.Point(71, 29);
            this.nUDmainTick.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDmainTick.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDmainTick.Name = "nUDmainTick";
            this.nUDmainTick.Size = new System.Drawing.Size(55, 21);
            this.nUDmainTick.TabIndex = 17;
            this.nUDmainTick.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nUDmainTick.ValueChanged += new System.EventHandler(this.nUDMainTick_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(25, 33);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 12);
            this.label26.TabIndex = 17;
            this.label26.Text = "主刻度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 69;
            this.label1.Text = "次刻度";
            // 
            // nUDminTick
            // 
            this.nUDminTick.AllowDrop = true;
            this.nUDminTick.Location = new System.Drawing.Point(190, 29);
            this.nUDminTick.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nUDminTick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDminTick.Name = "nUDminTick";
            this.nUDminTick.Size = new System.Drawing.Size(55, 21);
            this.nUDminTick.TabIndex = 68;
            this.nUDminTick.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDminTick.ValueChanged += new System.EventHandler(this.nUDminTick_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "尺类型";
            // 
            // cbbRulerType
            // 
            this.cbbRulerType.FormattingEnabled = true;
            this.cbbRulerType.Location = new System.Drawing.Point(71, 71);
            this.cbbRulerType.Name = "cbbRulerType";
            this.cbbRulerType.Size = new System.Drawing.Size(174, 20);
            this.cbbRulerType.TabIndex = 71;
            // 
            // FormSettingSectionDepthRuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 206);
            this.Controls.Add(this.cbbRulerType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUDminTick);
            this.Controls.Add(this.nUDTrackFontSize);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.nUDmainTick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettingSectionDepthRuler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "深度尺";
            ((System.ComponentModel.ISupportInitialize)(this.nUDTrackFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDmainTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDminTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nUDTrackFontSize;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.NumericUpDown nUDmainTick;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDminTick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbRulerType;
    }
}