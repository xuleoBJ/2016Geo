namespace DOGPlatform
{
    partial class FormSectAddNewWell
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
            this.lblTemplate = new System.Windows.Forms.Label();
            this.cbbSelectWellTemplate = new System.Windows.Forms.ComboBox();
            this.lblJH = new System.Windows.Forms.Label();
            this.cbbJH = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(15, 50);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(29, 12);
            this.lblTemplate.TabIndex = 66;
            this.lblTemplate.Text = "模板";
            // 
            // cbbSelectWellTemplate
            // 
            this.cbbSelectWellTemplate.FormattingEnabled = true;
            this.cbbSelectWellTemplate.Location = new System.Drawing.Point(50, 50);
            this.cbbSelectWellTemplate.Name = "cbbSelectWellTemplate";
            this.cbbSelectWellTemplate.Size = new System.Drawing.Size(139, 20);
            this.cbbSelectWellTemplate.TabIndex = 65;
            // 
            // lblJH
            // 
            this.lblJH.AutoSize = true;
            this.lblJH.Location = new System.Drawing.Point(14, 15);
            this.lblJH.Name = "lblJH";
            this.lblJH.Size = new System.Drawing.Size(29, 12);
            this.lblJH.TabIndex = 31;
            this.lblJH.Text = "井号";
            // 
            // cbbJH
            // 
            this.cbbJH.FormattingEnabled = true;
            this.cbbJH.Location = new System.Drawing.Point(50, 10);
            this.cbbJH.Name = "cbbJH";
            this.cbbJH.Size = new System.Drawing.Size(139, 20);
            this.cbbJH.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(114, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormSectAddNewWell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 140);
            this.Controls.Add(this.cbbSelectWellTemplate);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbbJH);
            this.Controls.Add(this.lblJH);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSectAddNewWell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJH;
        private System.Windows.Forms.ComboBox cbbJH;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.ComboBox cbbSelectWellTemplate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}