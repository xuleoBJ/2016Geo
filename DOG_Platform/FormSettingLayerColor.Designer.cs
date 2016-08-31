namespace DOGPlatform
{
    partial class FormSettingLayerColor
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
            this.dgvLayerColorSetting = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayerColorSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLayerColorSetting
            // 
            this.dgvLayerColorSetting.AllowUserToAddRows = false;
            this.dgvLayerColorSetting.AllowUserToDeleteRows = false;
            this.dgvLayerColorSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLayerColorSetting.Location = new System.Drawing.Point(12, 12);
            this.dgvLayerColorSetting.Name = "dgvLayerColorSetting";
            this.dgvLayerColorSetting.RowTemplate.Height = 23;
            this.dgvLayerColorSetting.Size = new System.Drawing.Size(237, 365);
            this.dgvLayerColorSetting.TabIndex = 31;
            this.dgvLayerColorSetting.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLayerColorSetting_CellClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(92, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 23);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(31, 387);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 23);
            this.btnOK.TabIndex = 67;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormSettingLayerColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 424);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvLayerColorSetting);
            this.Name = "FormSettingLayerColor";
            this.Text = "地层颜色配置";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayerColorSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLayerColorSetting;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;

    }
}