namespace DOGPlatform
{
    partial class FormLayerSetPie
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
            this.label62 = new System.Windows.Forms.Label();
            this.tbxOuterDataLayerPiefR = new System.Windows.Forms.TextBox();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.label61 = new System.Windows.Forms.Label();
            this.numericUpDown12 = new System.Windows.Forms.NumericUpDown();
            this.label63 = new System.Windows.Forms.Label();
            this.nUDLayerOpcity = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLayerOpcity)).BeginInit();
            this.SuspendLayout();
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(19, 36);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(35, 12);
            this.label62.TabIndex = 97;
            this.label62.Text = "R=R x";
            // 
            // tbxOuterDataLayerPiefR
            // 
            this.tbxOuterDataLayerPiefR.Location = new System.Drawing.Point(57, 32);
            this.tbxOuterDataLayerPiefR.Name = "tbxOuterDataLayerPiefR";
            this.tbxOuterDataLayerPiefR.Size = new System.Drawing.Size(37, 21);
            this.tbxOuterDataLayerPiefR.TabIndex = 96;
            this.tbxOuterDataLayerPiefR.Text = "1";
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown11.Location = new System.Drawing.Point(144, 32);
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(37, 21);
            this.numericUpDown11.TabIndex = 101;
            this.numericUpDown11.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(111, 36);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(29, 12);
            this.label61.TabIndex = 100;
            this.label61.Text = "字号";
            // 
            // numericUpDown12
            // 
            this.numericUpDown12.Location = new System.Drawing.Point(235, 32);
            this.numericUpDown12.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown12.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numericUpDown12.Name = "numericUpDown12";
            this.numericUpDown12.Size = new System.Drawing.Size(37, 21);
            this.numericUpDown12.TabIndex = 99;
            this.numericUpDown12.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(200, 36);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(29, 12);
            this.label63.TabIndex = 98;
            this.label63.Text = "偏移";
            // 
            // nUDLayerOpcity
            // 
            this.nUDLayerOpcity.DecimalPlaces = 1;
            this.nUDLayerOpcity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDLayerOpcity.Location = new System.Drawing.Point(93, 78);
            this.nUDLayerOpcity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDLayerOpcity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nUDLayerOpcity.Name = "nUDLayerOpcity";
            this.nUDLayerOpcity.Size = new System.Drawing.Size(37, 21);
            this.nUDLayerOpcity.TabIndex = 103;
            this.nUDLayerOpcity.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.nUDLayerOpcity.ValueChanged += new System.EventHandler(this.nUDLayerOpcity_ValueChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(22, 82);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(65, 12);
            this.label43.TabIndex = 102;
            this.label43.Text = "颜色透明度";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 105;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(77, 136);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 104;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormLayerSetPie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 194);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nUDLayerOpcity);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.numericUpDown11);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.numericUpDown12);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.tbxOuterDataLayerPiefR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLayerSetPie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "饼状图层设置";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLayerOpcity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox tbxOuterDataLayerPiefR;
        private System.Windows.Forms.NumericUpDown numericUpDown11;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.NumericUpDown numericUpDown12;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.NumericUpDown nUDLayerOpcity;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}