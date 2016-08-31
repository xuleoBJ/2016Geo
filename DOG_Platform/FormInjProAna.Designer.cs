namespace DOGPlatform
{
    partial class FormInjProAna
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
            this.btnCalResult = new System.Windows.Forms.Button();
            this.btnAddConnectWell = new System.Windows.Forms.Button();
            this.btnCalConnectWell = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbWellInject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbSelectedLayerName = new System.Windows.Forms.ComboBox();
            this.btnDelConnectJH = new System.Windows.Forms.Button();
            this.dgvInj2Pro = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbWellProduct = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.属性 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.小层 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInj2Pro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalResult
            // 
            this.btnCalResult.Location = new System.Drawing.Point(470, 54);
            this.btnCalResult.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalResult.Name = "btnCalResult";
            this.btnCalResult.Size = new System.Drawing.Size(114, 26);
            this.btnCalResult.TabIndex = 15;
            this.btnCalResult.Text = "分析计算";
            this.btnCalResult.UseVisualStyleBackColor = true;
            this.btnCalResult.Click += new System.EventHandler(this.btnCalResult_Click);
            // 
            // btnAddConnectWell
            // 
            this.btnAddConnectWell.Location = new System.Drawing.Point(159, 54);
            this.btnAddConnectWell.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddConnectWell.Name = "btnAddConnectWell";
            this.btnAddConnectWell.Size = new System.Drawing.Size(114, 26);
            this.btnAddConnectWell.TabIndex = 14;
            this.btnAddConnectWell.Text = "添加受效井";
            this.btnAddConnectWell.UseVisualStyleBackColor = true;
            this.btnAddConnectWell.Click += new System.EventHandler(this.btnAddConnectWell_Click);
            // 
            // btnCalConnectWell
            // 
            this.btnCalConnectWell.Location = new System.Drawing.Point(309, 11);
            this.btnCalConnectWell.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalConnectWell.Name = "btnCalConnectWell";
            this.btnCalConnectWell.Size = new System.Drawing.Size(114, 26);
            this.btnCalConnectWell.TabIndex = 13;
            this.btnCalConnectWell.Text = "计算受效井";
            this.btnCalConnectWell.UseVisualStyleBackColor = true;
            this.btnCalConnectWell.Click += new System.EventHandler(this.btnCalConnectWell_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(157, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "注入井号";
            // 
            // cbbWellInject
            // 
            this.cbbWellInject.FormattingEnabled = true;
            this.cbbWellInject.Location = new System.Drawing.Point(216, 12);
            this.cbbWellInject.Name = "cbbWellInject";
            this.cbbWellInject.Size = new System.Drawing.Size(79, 20);
            this.cbbWellInject.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "选择小层";
            // 
            // cbbSelectedLayerName
            // 
            this.cbbSelectedLayerName.FormattingEnabled = true;
            this.cbbSelectedLayerName.Location = new System.Drawing.Point(70, 12);
            this.cbbSelectedLayerName.Name = "cbbSelectedLayerName";
            this.cbbSelectedLayerName.Size = new System.Drawing.Size(81, 20);
            this.cbbSelectedLayerName.TabIndex = 18;
            this.cbbSelectedLayerName.SelectedIndexChanged += new System.EventHandler(this.cbbSelectedLayerName_SelectedIndexChanged);
            // 
            // btnDelConnectJH
            // 
            this.btnDelConnectJH.Location = new System.Drawing.Point(309, 54);
            this.btnDelConnectJH.Name = "btnDelConnectJH";
            this.btnDelConnectJH.Size = new System.Drawing.Size(114, 26);
            this.btnDelConnectJH.TabIndex = 20;
            this.btnDelConnectJH.Text = "删除连接井";
            this.btnDelConnectJH.UseVisualStyleBackColor = true;
            this.btnDelConnectJH.Click += new System.EventHandler(this.btnDelConnectJH_Click);
            // 
            // dgvInj2Pro
            // 
            this.dgvInj2Pro.AllowUserToOrderColumns = true;
            this.dgvInj2Pro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInj2Pro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.属性,
            this.小层});
            this.dgvInj2Pro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvInj2Pro.Location = new System.Drawing.Point(0, 97);
            this.dgvInj2Pro.Name = "dgvInj2Pro";
            this.dgvInj2Pro.RowTemplate.Height = 23;
            this.dgvInj2Pro.Size = new System.Drawing.Size(1073, 497);
            this.dgvInj2Pro.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "生产井号";
            // 
            // cbbWellProduct
            // 
            this.cbbWellProduct.FormattingEnabled = true;
            this.cbbWellProduct.Location = new System.Drawing.Point(72, 58);
            this.cbbWellProduct.Name = "cbbWellProduct";
            this.cbbWellProduct.Size = new System.Drawing.Size(79, 20);
            this.cbbWellProduct.TabIndex = 37;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "注入井";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "受效井";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "井距(m)";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "射开厚度";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "吸水%";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "吸水厚度";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "孔隙度";
            this.Column7.Name = "Column7";
            // 
            // 属性
            // 
            this.属性.HeaderText = "渗透率";
            this.属性.Name = "属性";
            // 
            // 小层
            // 
            this.小层.HeaderText = "小层名";
            this.小层.Name = "小层";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(637, 54);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(2);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(114, 26);
            this.btnDraw.TabIndex = 39;
            this.btnDraw.Text = "绘图分析";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // FormInjProAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 594);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbWellProduct);
            this.Controls.Add(this.dgvInj2Pro);
            this.Controls.Add(this.btnDelConnectJH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbSelectedLayerName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbbWellInject);
            this.Controls.Add(this.btnCalResult);
            this.Controls.Add(this.btnAddConnectWell);
            this.Controls.Add(this.btnCalConnectWell);
            this.Name = "FormInjProAna";
            this.Text = "注采对应计算分析";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInj2Pro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalResult;
        private System.Windows.Forms.Button btnAddConnectWell;
        private System.Windows.Forms.Button btnCalConnectWell;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbWellInject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbSelectedLayerName;
        private System.Windows.Forms.Button btnDelConnectJH;
        private System.Windows.Forms.DataGridView dgvInj2Pro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbWellProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn 属性;
        private System.Windows.Forms.DataGridViewTextBoxColumn 小层;
        private System.Windows.Forms.Button btnDraw;
    }
}