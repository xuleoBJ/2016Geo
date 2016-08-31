namespace DOGPlatform
{
    partial class FormWellHorizon
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
            this.lbxJH = new System.Windows.Forms.ListBox();
            this.btn_deleteWell = new System.Windows.Forms.Button();
            this.btn_addWell = new System.Windows.Forms.Button();
            this.lbxJHSeclected = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.nUDABFontSizeHorizonalInterval = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.cbbColorHorizonalInterval = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.nUDLineWidthHorizonalInterval = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.cbxAddHorizonWell = new System.Windows.Forms.CheckBox();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDABFontSizeHorizonalInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidthHorizonalInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxJH
            // 
            this.lbxJH.FormattingEnabled = true;
            this.lbxJH.ItemHeight = 12;
            this.lbxJH.Location = new System.Drawing.Point(56, 69);
            this.lbxJH.Margin = new System.Windows.Forms.Padding(2);
            this.lbxJH.Name = "lbxJH";
            this.lbxJH.Size = new System.Drawing.Size(102, 184);
            this.lbxJH.TabIndex = 41;
            // 
            // btn_deleteWell
            // 
            this.btn_deleteWell.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deleteWell.Location = new System.Drawing.Point(168, 127);
            this.btn_deleteWell.Margin = new System.Windows.Forms.Padding(2);
            this.btn_deleteWell.Name = "btn_deleteWell";
            this.btn_deleteWell.Size = new System.Drawing.Size(28, 26);
            this.btn_deleteWell.TabIndex = 43;
            this.btn_deleteWell.Text = "←";
            this.btn_deleteWell.UseVisualStyleBackColor = true;
            // 
            // btn_addWell
            // 
            this.btn_addWell.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addWell.Location = new System.Drawing.Point(168, 92);
            this.btn_addWell.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addWell.Name = "btn_addWell";
            this.btn_addWell.Size = new System.Drawing.Size(28, 24);
            this.btn_addWell.TabIndex = 42;
            this.btn_addWell.Text = "→";
            this.btn_addWell.UseVisualStyleBackColor = true;
            // 
            // lbxJHSeclected
            // 
            this.lbxJHSeclected.FormattingEnabled = true;
            this.lbxJHSeclected.ItemHeight = 12;
            this.lbxJHSeclected.Location = new System.Drawing.Point(215, 71);
            this.lbxJHSeclected.Margin = new System.Windows.Forms.Padding(2);
            this.lbxJHSeclected.Name = "lbxJHSeclected";
            this.lbxJHSeclected.Size = new System.Drawing.Size(102, 184);
            this.lbxJHSeclected.TabIndex = 44;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.nUDABFontSizeHorizonalInterval);
            this.groupBox7.Controls.Add(this.label52);
            this.groupBox7.Controls.Add(this.cbbColorHorizonalInterval);
            this.groupBox7.Controls.Add(this.label47);
            this.groupBox7.Controls.Add(this.nUDLineWidthHorizonalInterval);
            this.groupBox7.Controls.Add(this.label51);
            this.groupBox7.Location = new System.Drawing.Point(56, 278);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(237, 93);
            this.groupBox7.TabIndex = 40;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "标识设置";
            // 
            // nUDABFontSizeHorizonalInterval
            // 
            this.nUDABFontSizeHorizonalInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nUDABFontSizeHorizonalInterval.Location = new System.Drawing.Point(59, 59);
            this.nUDABFontSizeHorizonalInterval.Name = "nUDABFontSizeHorizonalInterval";
            this.nUDABFontSizeHorizonalInterval.Size = new System.Drawing.Size(37, 21);
            this.nUDABFontSizeHorizonalInterval.TabIndex = 22;
            this.nUDABFontSizeHorizonalInterval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(5, 63);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(53, 12);
            this.label52.TabIndex = 21;
            this.label52.Text = "标识字号";
            // 
            // cbbColorHorizonalInterval
            // 
            this.cbbColorHorizonalInterval.BackColor = System.Drawing.Color.Red;
            this.cbbColorHorizonalInterval.FormattingEnabled = true;
            this.cbbColorHorizonalInterval.Location = new System.Drawing.Point(162, 30);
            this.cbbColorHorizonalInterval.Name = "cbbColorHorizonalInterval";
            this.cbbColorHorizonalInterval.Size = new System.Drawing.Size(52, 20);
            this.cbbColorHorizonalInterval.TabIndex = 18;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(103, 34);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 19;
            this.label47.Text = "井段颜色";
            // 
            // nUDLineWidthHorizonalInterval
            // 
            this.nUDLineWidthHorizonalInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nUDLineWidthHorizonalInterval.Location = new System.Drawing.Point(41, 31);
            this.nUDLineWidthHorizonalInterval.Name = "nUDLineWidthHorizonalInterval";
            this.nUDLineWidthHorizonalInterval.Size = new System.Drawing.Size(45, 21);
            this.nUDLineWidthHorizonalInterval.TabIndex = 17;
            this.nUDLineWidthHorizonalInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(6, 34);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(29, 12);
            this.label51.TabIndex = 12;
            this.label51.Text = "线宽";
            // 
            // cbxAddHorizonWell
            // 
            this.cbxAddHorizonWell.AutoSize = true;
            this.cbxAddHorizonWell.Location = new System.Drawing.Point(346, 83);
            this.cbxAddHorizonWell.Name = "cbxAddHorizonWell";
            this.cbxAddHorizonWell.Size = new System.Drawing.Size(96, 16);
            this.cbxAddHorizonWell.TabIndex = 39;
            this.cbxAddHorizonWell.Text = "增加水平井段";
            this.cbxAddHorizonWell.UseVisualStyleBackColor = true;
            // 
            // FormWellHorizon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 441);
            this.Controls.Add(this.lbxJH);
            this.Controls.Add(this.btn_deleteWell);
            this.Controls.Add(this.btn_addWell);
            this.Controls.Add(this.lbxJHSeclected);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.cbxAddHorizonWell);
            this.Name = "FormWellHorizon";
            this.Text = "FormWellHorizon";
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDABFontSizeHorizonalInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLineWidthHorizonalInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxJH;
        private System.Windows.Forms.Button btn_deleteWell;
        private System.Windows.Forms.Button btn_addWell;
        private System.Windows.Forms.ListBox lbxJHSeclected;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown nUDABFontSizeHorizonalInterval;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox cbbColorHorizonalInterval;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.NumericUpDown nUDLineWidthHorizonalInterval;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.CheckBox cbxAddHorizonWell;
    }
}