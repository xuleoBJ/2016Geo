namespace DOGPlatform
{
    partial class FormDataViewProjectSingleWell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataViewProjectSingleWell));
            this.dgvDataTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cbbJH = new System.Windows.Forms.ComboBox();
            this.cbbDataType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataTable
            // 
            this.dgvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataTable.Location = new System.Drawing.Point(0, 24);
            this.dgvDataTable.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDataTable.Name = "dgvDataTable";
            this.dgvDataTable.RowTemplate.Height = 27;
            this.dgvDataTable.Size = new System.Drawing.Size(554, 432);
            this.dgvDataTable.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cbbJH
            // 
            this.cbbJH.FormattingEnabled = true;
            this.cbbJH.Location = new System.Drawing.Point(0, 0);
            this.cbbJH.Name = "cbbJH";
            this.cbbJH.Size = new System.Drawing.Size(95, 20);
            this.cbbJH.TabIndex = 5;
            this.cbbJH.Text = "井号";
            this.cbbJH.SelectedIndexChanged += new System.EventHandler(this.cbbJH_SelectedIndexChanged);
            // 
            // cbbDataType
            // 
            this.cbbDataType.FormattingEnabled = true;
            this.cbbDataType.Location = new System.Drawing.Point(101, 0);
            this.cbbDataType.Name = "cbbDataType";
            this.cbbDataType.Size = new System.Drawing.Size(121, 20);
            this.cbbDataType.TabIndex = 6;
            this.cbbDataType.Text = "选择数据";
            this.cbbDataType.SelectedIndexChanged += new System.EventHandler(this.cbbDataType_SelectedIndexChanged);
            // 
            // FormDataViewSingleWell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 456);
            this.Controls.Add(this.cbbDataType);
            this.Controls.Add(this.cbbJH);
            this.Controls.Add(this.dgvDataTable);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDataViewSingleWell";
            this.Text = "井数据分析";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox cbbJH;
        private System.Windows.Forms.ComboBox cbbDataType;
    }
}