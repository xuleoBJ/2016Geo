namespace DOGPlatform
{
    partial class colorTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxColor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxColor
            // 
            this.tbxColor.Location = new System.Drawing.Point(13, 19);
            this.tbxColor.MaxLength = 7;
            this.tbxColor.Name = "tbxColor";
            this.tbxColor.Size = new System.Drawing.Size(98, 21);
            this.tbxColor.TabIndex = 120;
            // 
            // colorTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbxColor);
            this.Name = "colorTextBox";
            this.Size = new System.Drawing.Size(151, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxColor;
    }
}
