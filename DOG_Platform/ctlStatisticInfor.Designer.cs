namespace DOGPlatform
{
    partial class ctlStatisticInfor
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
            this.lblMean = new System.Windows.Forms.Label();
            this.lblValueMin = new System.Windows.Forms.Label();
            this.lblValueMax = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataNum = new System.Windows.Forms.Label();
            this.lblVariance = new System.Windows.Forms.Label();
            this.lblQ2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Location = new System.Drawing.Point(34, 96);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(35, 12);
            this.lblMean.TabIndex = 100;
            this.lblMean.Text = "均值=";
            // 
            // lblValueMin
            // 
            this.lblValueMin.AutoSize = true;
            this.lblValueMin.Location = new System.Drawing.Point(26, 63);
            this.lblValueMin.Name = "lblValueMin";
            this.lblValueMin.Size = new System.Drawing.Size(47, 12);
            this.lblValueMin.TabIndex = 99;
            this.lblValueMin.Text = "最小值=";
            // 
            // lblValueMax
            // 
            this.lblValueMax.AutoSize = true;
            this.lblValueMax.Location = new System.Drawing.Point(22, 30);
            this.lblValueMax.Name = "lblValueMax";
            this.lblValueMax.Size = new System.Drawing.Size(47, 12);
            this.lblValueMax.TabIndex = 98;
            this.lblValueMax.Text = "最大值=";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(34, 131);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(35, 12);
            this.lblSum.TabIndex = 101;
            this.lblSum.Text = "总和=";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQ2);
            this.groupBox1.Controls.Add(this.lblVariance);
            this.groupBox1.Controls.Add(this.lblMean);
            this.groupBox1.Controls.Add(this.lblDataNum);
            this.groupBox1.Controls.Add(this.lblSum);
            this.groupBox1.Controls.Add(this.lblValueMax);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 275);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计信息";
            // 
            // lblDataNum
            // 
            this.lblDataNum.AutoSize = true;
            this.lblDataNum.Location = new System.Drawing.Point(10, 165);
            this.lblDataNum.Name = "lblDataNum";
            this.lblDataNum.Size = new System.Drawing.Size(59, 12);
            this.lblDataNum.TabIndex = 103;
            this.lblDataNum.Text = "数据个数=";
            // 
            // lblVariance
            // 
            this.lblVariance.AutoSize = true;
            this.lblVariance.Location = new System.Drawing.Point(34, 201);
            this.lblVariance.Name = "lblVariance";
            this.lblVariance.Size = new System.Drawing.Size(35, 12);
            this.lblVariance.TabIndex = 104;
            this.lblVariance.Text = "方差=";
            // 
            // lblQ2
            // 
            this.lblQ2.AutoSize = true;
            this.lblQ2.Location = new System.Drawing.Point(46, 239);
            this.lblQ2.Name = "lblQ2";
            this.lblQ2.Size = new System.Drawing.Size(23, 12);
            this.lblQ2.TabIndex = 105;
            this.lblQ2.Text = "Q2=";
            // 
            // ctlStatisticInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValueMin);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctlStatisticInfor";
            this.Size = new System.Drawing.Size(176, 292);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Label lblValueMin;
        private System.Windows.Forms.Label lblValueMax;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDataNum;
        private System.Windows.Forms.Label lblVariance;
        private System.Windows.Forms.Label lblQ2;
    }
}
