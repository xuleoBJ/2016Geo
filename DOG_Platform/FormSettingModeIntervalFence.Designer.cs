namespace DOGPlatform
{
    partial class FormSettingModeIntervalFence
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
            this.btnClearConnectLayer = new System.Windows.Forms.Button();
            this.btnConnectLayerByTop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nUDbottomDepthDown = new System.Windows.Forms.NumericUpDown();
            this.nUDtopDepthUp = new System.Windows.Forms.NumericUpDown();
            this.cbbTopXCM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbBottomXCM = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSectionShowDepth = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDbottomDepthDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDtopDepthUp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClearConnectLayer
            // 
            this.btnClearConnectLayer.Location = new System.Drawing.Point(207, 159);
            this.btnClearConnectLayer.Name = "btnClearConnectLayer";
            this.btnClearConnectLayer.Size = new System.Drawing.Size(128, 23);
            this.btnClearConnectLayer.TabIndex = 81;
            this.btnClearConnectLayer.Text = "清除所有层段连接";
            this.btnClearConnectLayer.UseVisualStyleBackColor = true;
            // 
            // btnConnectLayerByTop
            // 
            this.btnConnectLayerByTop.Location = new System.Drawing.Point(44, 210);
            this.btnConnectLayerByTop.Name = "btnConnectLayerByTop";
            this.btnConnectLayerByTop.Size = new System.Drawing.Size(128, 23);
            this.btnConnectLayerByTop.TabIndex = 80;
            this.btnConnectLayerByTop.Text = "同名层段连接";
            this.btnConnectLayerByTop.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nUDbottomDepthDown);
            this.groupBox3.Controls.Add(this.nUDtopDepthUp);
            this.groupBox3.Controls.Add(this.cbbTopXCM);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbbBottomXCM);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(44, 33);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(303, 106);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "层段选择";
            // 
            // nUDbottomDepthDown
            // 
            this.nUDbottomDepthDown.AllowDrop = true;
            this.nUDbottomDepthDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDbottomDepthDown.Location = new System.Drawing.Point(215, 67);
            this.nUDbottomDepthDown.Name = "nUDbottomDepthDown";
            this.nUDbottomDepthDown.Size = new System.Drawing.Size(40, 21);
            this.nUDbottomDepthDown.TabIndex = 10;
            this.nUDbottomDepthDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nUDtopDepthUp
            // 
            this.nUDtopDepthUp.AllowDrop = true;
            this.nUDtopDepthUp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDtopDepthUp.Location = new System.Drawing.Point(215, 29);
            this.nUDtopDepthUp.Name = "nUDtopDepthUp";
            this.nUDtopDepthUp.Size = new System.Drawing.Size(40, 21);
            this.nUDtopDepthUp.TabIndex = 8;
            this.nUDtopDepthUp.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // cbbTopXCM
            // 
            this.cbbTopXCM.FormattingEnabled = true;
            this.cbbTopXCM.Location = new System.Drawing.Point(56, 29);
            this.cbbTopXCM.Name = "cbbTopXCM";
            this.cbbTopXCM.Size = new System.Drawing.Size(137, 20);
            this.cbbTopXCM.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "米";
            // 
            // cbbBottomXCM
            // 
            this.cbbBottomXCM.FormattingEnabled = true;
            this.cbbBottomXCM.Location = new System.Drawing.Point(56, 68);
            this.cbbBottomXCM.Name = "cbbBottomXCM";
            this.cbbBottomXCM.Size = new System.Drawing.Size(137, 20);
            this.cbbBottomXCM.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "米";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "顶层";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 8;
            this.label13.Text = "底层";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(195, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "+";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(194, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "-";
            // 
            // btnSectionShowDepth
            // 
            this.btnSectionShowDepth.Location = new System.Drawing.Point(44, 159);
            this.btnSectionShowDepth.Name = "btnSectionShowDepth";
            this.btnSectionShowDepth.Size = new System.Drawing.Size(128, 23);
            this.btnSectionShowDepth.TabIndex = 76;
            this.btnSectionShowDepth.Text = "选择层位显示";
            this.btnSectionShowDepth.UseVisualStyleBackColor = true;
            this.btnSectionShowDepth.Click += new System.EventHandler(this.btnSectionShowDepth_Click);
            // 
            // FormSettingModeIntervalFence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 277);
            this.Controls.Add(this.btnClearConnectLayer);
            this.Controls.Add(this.btnConnectLayerByTop);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSectionShowDepth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettingModeIntervalFence";
            this.Text = "层段操作";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDbottomDepthDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDtopDepthUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClearConnectLayer;
        private System.Windows.Forms.Button btnConnectLayerByTop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nUDbottomDepthDown;
        private System.Windows.Forms.NumericUpDown nUDtopDepthUp;
        private System.Windows.Forms.ComboBox cbbTopXCM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbBottomXCM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSectionShowDepth;
    }
}