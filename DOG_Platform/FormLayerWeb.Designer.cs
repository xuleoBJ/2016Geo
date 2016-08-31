namespace DOGPlatform
{
    partial class FormLayerWeb
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
            this.wellPanel1 = new DOGPlatform.wellPanel();
            this.SuspendLayout();
            // 
            // wellPanel1
            // 
            this.wellPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wellPanel1.Location = new System.Drawing.Point(0, 0);
            this.wellPanel1.Name = "wellPanel1";
            this.wellPanel1.Size = new System.Drawing.Size(463, 480);
            this.wellPanel1.TabIndex = 0;
            // 
            // FormLayerWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 480);
            this.Controls.Add(this.wellPanel1);
            this.Name = "FormLayerWeb";
            this.Text = "单井综合";
            this.ResumeLayout(false);

        }

        #endregion

        private wellPanel wellPanel1;
    }
}