namespace DOGPlatform
{
    partial class FormLayerWellValue
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
            this.btnCellColor = new System.Windows.Forms.Button();
            this.btnOuterDataLayerDelCol = new System.Windows.Forms.Button();
            this.btnOuterDataLayerAddCol = new System.Windows.Forms.Button();
            this.btnOuterDataLayerDelFromdgv = new System.Windows.Forms.Button();
            this.btnOuterDataLayerCopyFromExcel = new System.Windows.Forms.Button();
            this.btnAddWellValueLayer = new System.Windows.Forms.Button();
            this.dgvOuterDataLayerWellValues = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label41 = new System.Windows.Forms.Label();
            this.tbxDataLayerID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOuterDataLayerWellValues)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCellColor
            // 
            this.btnCellColor.Location = new System.Drawing.Point(354, 12);
            this.btnCellColor.Name = "btnCellColor";
            this.btnCellColor.Size = new System.Drawing.Size(79, 23);
            this.btnCellColor.TabIndex = 96;
            this.btnCellColor.Text = "值颜色";
            this.btnCellColor.UseVisualStyleBackColor = true;
            this.btnCellColor.Click += new System.EventHandler(this.btnCellColor_Click);
            // 
            // btnOuterDataLayerDelCol
            // 
            this.btnOuterDataLayerDelCol.Location = new System.Drawing.Point(184, 12);
            this.btnOuterDataLayerDelCol.Name = "btnOuterDataLayerDelCol";
            this.btnOuterDataLayerDelCol.Size = new System.Drawing.Size(79, 23);
            this.btnOuterDataLayerDelCol.TabIndex = 95;
            this.btnOuterDataLayerDelCol.Text = "删除列";
            this.btnOuterDataLayerDelCol.UseVisualStyleBackColor = true;
            this.btnOuterDataLayerDelCol.Click += new System.EventHandler(this.btnOuterDataLayerDelCol_Click);
            // 
            // btnOuterDataLayerAddCol
            // 
            this.btnOuterDataLayerAddCol.Location = new System.Drawing.Point(97, 12);
            this.btnOuterDataLayerAddCol.Name = "btnOuterDataLayerAddCol";
            this.btnOuterDataLayerAddCol.Size = new System.Drawing.Size(79, 23);
            this.btnOuterDataLayerAddCol.TabIndex = 94;
            this.btnOuterDataLayerAddCol.Text = "添加列";
            this.btnOuterDataLayerAddCol.UseVisualStyleBackColor = true;
            this.btnOuterDataLayerAddCol.Click += new System.EventHandler(this.btnOuterDataLayerAddCol_Click);
            // 
            // btnOuterDataLayerDelFromdgv
            // 
            this.btnOuterDataLayerDelFromdgv.Location = new System.Drawing.Point(269, 12);
            this.btnOuterDataLayerDelFromdgv.Name = "btnOuterDataLayerDelFromdgv";
            this.btnOuterDataLayerDelFromdgv.Size = new System.Drawing.Size(75, 23);
            this.btnOuterDataLayerDelFromdgv.TabIndex = 93;
            this.btnOuterDataLayerDelFromdgv.Text = "删除行";
            this.btnOuterDataLayerDelFromdgv.UseVisualStyleBackColor = true;
            // 
            // btnOuterDataLayerCopyFromExcel
            // 
            this.btnOuterDataLayerCopyFromExcel.Location = new System.Drawing.Point(14, 12);
            this.btnOuterDataLayerCopyFromExcel.Name = "btnOuterDataLayerCopyFromExcel";
            this.btnOuterDataLayerCopyFromExcel.Size = new System.Drawing.Size(79, 23);
            this.btnOuterDataLayerCopyFromExcel.TabIndex = 92;
            this.btnOuterDataLayerCopyFromExcel.Text = "粘贴";
            this.btnOuterDataLayerCopyFromExcel.UseVisualStyleBackColor = true;
            this.btnOuterDataLayerCopyFromExcel.Click += new System.EventHandler(this.btnOuterDataLayerCopyFromExcel_Click);
            // 
            // btnAddWellValueLayer
            // 
            this.btnAddWellValueLayer.Location = new System.Drawing.Point(625, 12);
            this.btnAddWellValueLayer.Name = "btnAddWellValueLayer";
            this.btnAddWellValueLayer.Size = new System.Drawing.Size(73, 23);
            this.btnAddWellValueLayer.TabIndex = 86;
            this.btnAddWellValueLayer.Text = "增加图层";
            this.btnAddWellValueLayer.UseVisualStyleBackColor = true;
            this.btnAddWellValueLayer.Click += new System.EventHandler(this.btnAddWellValueLayer_Click);
            // 
            // dgvOuterDataLayerWellValues
            // 
            this.dgvOuterDataLayerWellValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOuterDataLayerWellValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvOuterDataLayerWellValues.Location = new System.Drawing.Point(13, 41);
            this.dgvOuterDataLayerWellValues.Name = "dgvOuterDataLayerWellValues";
            this.dgvOuterDataLayerWellValues.RowTemplate.Height = 23;
            this.dgvOuterDataLayerWellValues.Size = new System.Drawing.Size(685, 454);
            this.dgvOuterDataLayerWellValues.TabIndex = 84;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "井号";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "数值";
            this.Column2.Name = "Column2";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(442, 17);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 12);
            this.label41.TabIndex = 70;
            this.label41.Text = "图层名";
            // 
            // tbxDataLayerID
            // 
            this.tbxDataLayerID.Location = new System.Drawing.Point(490, 12);
            this.tbxDataLayerID.Name = "tbxDataLayerID";
            this.tbxDataLayerID.Size = new System.Drawing.Size(129, 21);
            this.tbxDataLayerID.TabIndex = 69;
            // 
            // FormLayerWellValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 507);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.btnCellColor);
            this.Controls.Add(this.tbxDataLayerID);
            this.Controls.Add(this.btnOuterDataLayerDelCol);
            this.Controls.Add(this.btnOuterDataLayerAddCol);
            this.Controls.Add(this.btnOuterDataLayerDelFromdgv);
            this.Controls.Add(this.btnOuterDataLayerCopyFromExcel);
            this.Controls.Add(this.btnAddWellValueLayer);
            this.Controls.Add(this.dgvOuterDataLayerWellValues);
            this.Name = "FormLayerWellValue";
            this.Text = "井点值图层";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOuterDataLayerWellValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCellColor;
        private System.Windows.Forms.Button btnOuterDataLayerDelCol;
        private System.Windows.Forms.Button btnOuterDataLayerAddCol;
        private System.Windows.Forms.Button btnOuterDataLayerDelFromdgv;
        private System.Windows.Forms.Button btnOuterDataLayerCopyFromExcel;
        private System.Windows.Forms.Button btnAddWellValueLayer;
        private System.Windows.Forms.DataGridView dgvOuterDataLayerWellValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox tbxDataLayerID;
    }
}