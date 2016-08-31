namespace DOGPlatform
{
    partial class ctlLogInforStatistic
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblDepthBot = new System.Windows.Forms.Label();
            this.lblDepthTop = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(17, 92);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(35, 12);
            this.lblInterval.TabIndex = 96;
            this.lblInterval.Text = "间隔=";
            // 
            // lblDepthBot
            // 
            this.lblDepthBot.AutoSize = true;
            this.lblDepthBot.Location = new System.Drawing.Point(17, 58);
            this.lblDepthBot.Name = "lblDepthBot";
            this.lblDepthBot.Size = new System.Drawing.Size(35, 12);
            this.lblDepthBot.TabIndex = 93;
            this.lblDepthBot.Text = "底深=";
            // 
            // lblDepthTop
            // 
            this.lblDepthTop.AutoSize = true;
            this.lblDepthTop.Location = new System.Drawing.Point(17, 23);
            this.lblDepthTop.Name = "lblDepthTop";
            this.lblDepthTop.Size = new System.Drawing.Size(35, 12);
            this.lblDepthTop.TabIndex = 92;
            this.lblDepthTop.Text = "顶深=";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInterval);
            this.groupBox1.Controls.Add(this.lblDepthBot);
            this.groupBox1.Controls.Add(this.lblDepthTop);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 124);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "深度段信息";
            // 
            // ctlLogInforStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctlLogInforStatistic";
            this.Size = new System.Drawing.Size(146, 127);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label lblDepthBot;
        private System.Windows.Forms.Label lblDepthTop;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
