namespace DOGPlatform
{
    partial class FormGridDefine
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
            this.lblXstep = new System.Windows.Forms.Label();
            this.tbxXstepIncrement = new System.Windows.Forms.TextBox();
            this.lblYstep = new System.Windows.Forms.Label();
            this.tbxYstepIncrement = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSettingGrid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblXstep
            // 
            this.lblXstep.AutoSize = true;
            this.lblXstep.Location = new System.Drawing.Point(43, 46);
            this.lblXstep.Name = "lblXstep";
            this.lblXstep.Size = new System.Drawing.Size(41, 12);
            this.lblXstep.TabIndex = 0;
            this.lblXstep.Text = "I 步长";
            // 
            // tbxXstepIncrement
            // 
            this.tbxXstepIncrement.Location = new System.Drawing.Point(90, 43);
            this.tbxXstepIncrement.Name = "tbxXstepIncrement";
            this.tbxXstepIncrement.Size = new System.Drawing.Size(72, 21);
            this.tbxXstepIncrement.TabIndex = 1;
            this.tbxXstepIncrement.Text = "30";
            // 
            // lblYstep
            // 
            this.lblYstep.AutoSize = true;
            this.lblYstep.Location = new System.Drawing.Point(43, 85);
            this.lblYstep.Name = "lblYstep";
            this.lblYstep.Size = new System.Drawing.Size(41, 12);
            this.lblYstep.TabIndex = 0;
            this.lblYstep.Text = "J 步长";
            // 
            // tbxYstepIncrement
            // 
            this.tbxYstepIncrement.Location = new System.Drawing.Point(90, 82);
            this.tbxYstepIncrement.Name = "tbxYstepIncrement";
            this.tbxYstepIncrement.Size = new System.Drawing.Size(72, 21);
            this.tbxYstepIncrement.TabIndex = 1;
            this.tbxYstepIncrement.Text = "30";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSettingGrid
            // 
            this.btnSettingGrid.Location = new System.Drawing.Point(158, 147);
            this.btnSettingGrid.Name = "btnSettingGrid";
            this.btnSettingGrid.Size = new System.Drawing.Size(75, 23);
            this.btnSettingGrid.TabIndex = 2;
            this.btnSettingGrid.Text = "设置确定";
            this.btnSettingGrid.UseVisualStyleBackColor = true;
            this.btnSettingGrid.Click += new System.EventHandler(this.btnSettingGrid_Click);
            // 
            // FormGridDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 219);
            this.Controls.Add(this.btnSettingGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxYstepIncrement);
            this.Controls.Add(this.tbxXstepIncrement);
            this.Controls.Add(this.lblYstep);
            this.Controls.Add(this.lblXstep);
            this.Name = "FormGridDefine";
            this.Text = "网格设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXstep;
        private System.Windows.Forms.TextBox tbxXstepIncrement;
        private System.Windows.Forms.Label lblYstep;
        private System.Windows.Forms.TextBox tbxYstepIncrement;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSettingGrid;
    }
}