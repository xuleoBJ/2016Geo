namespace DOGPlatform
{
    partial class FormFunctionCal
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
            this.progressBarCalc = new System.Windows.Forms.ProgressBar();
            this.labelScaleX = new System.Windows.Forms.Label();
            this.labelScaleY = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonUse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxParameters = new System.Windows.Forms.TextBox();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.panelPlot = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarCalc
            // 
            this.progressBarCalc.Location = new System.Drawing.Point(12, 515);
            this.progressBarCalc.Name = "progressBarCalc";
            this.progressBarCalc.Size = new System.Drawing.Size(328, 21);
            this.progressBarCalc.TabIndex = 52;
            this.progressBarCalc.Visible = false;
            // 
            // labelScaleX
            // 
            this.labelScaleX.AutoSize = true;
            this.labelScaleX.Location = new System.Drawing.Point(852, 515);
            this.labelScaleX.Name = "labelScaleX";
            this.labelScaleX.Size = new System.Drawing.Size(23, 12);
            this.labelScaleX.TabIndex = 51;
            this.labelScaleX.Text = "1:8";
            // 
            // labelScaleY
            // 
            this.labelScaleY.AutoSize = true;
            this.labelScaleY.Location = new System.Drawing.Point(849, 23);
            this.labelScaleY.Name = "labelScaleY";
            this.labelScaleY.Size = new System.Drawing.Size(23, 12);
            this.labelScaleY.TabIndex = 50;
            this.labelScaleY.Text = "1:8";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonDeleteAll);
            this.panel1.Controls.Add(this.listBoxHistory);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.buttonUse);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxParameters);
            this.panel1.Controls.Add(this.textBoxFunction);
            this.panel1.Controls.Add(this.buttonRun);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 462);
            this.panel1.TabIndex = 49;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(6, 423);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(85, 21);
            this.buttonDelete.TabIndex = 38;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Location = new System.Drawing.Point(119, 423);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(84, 21);
            this.buttonDeleteAll.TabIndex = 37;
            this.buttonDeleteAll.Text = "DeleteAll";
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.ItemHeight = 12;
            this.listBoxHistory.Items.AddRange(new object[] {
            "A*sin(x)/x",
            "x**3 - x",
            "x**2 - C",
            "x+(4/x)",
            "A*x/(x**2+1)",
            "e**x/(e**x+1)",
            "x*e**(-x**2)",
            "2*x-x*log(x)",
            "x*sqrt(16-2*x**2)",
            "A*sin(x)*(cos(x)**2)",
            "A*sin(x-a)"});
            this.listBoxHistory.Location = new System.Drawing.Point(6, 245);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(306, 172);
            this.listBoxHistory.TabIndex = 36;
            this.listBoxHistory.DoubleClick += new System.EventHandler(this.listBoxHistory_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "Recently used functions:";
            // 
            // buttonUse
            // 
            this.buttonUse.Location = new System.Drawing.Point(228, 423);
            this.buttonUse.Name = "buttonUse";
            this.buttonUse.Size = new System.Drawing.Size(84, 21);
            this.buttonUse.TabIndex = 34;
            this.buttonUse.Text = "Use";
            this.buttonUse.UseVisualStyleBackColor = true;
            this.buttonUse.Click += new System.EventHandler(this.buttonUse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "Function y=f(x)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "Parameters:";
            // 
            // textBoxParameters
            // 
            this.textBoxParameters.AcceptsReturn = true;
            this.textBoxParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxParameters.Location = new System.Drawing.Point(6, 89);
            this.textBoxParameters.Multiline = true;
            this.textBoxParameters.Name = "textBoxParameters";
            this.textBoxParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxParameters.Size = new System.Drawing.Size(168, 86);
            this.textBoxParameters.TabIndex = 31;
            this.textBoxParameters.Text = "A=4.0\r\nB=0.1\r\nC=3.0\r\na=pi/4";
            this.textBoxParameters.WordWrap = false;
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFunction.Location = new System.Drawing.Point(6, 25);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(306, 22);
            this.textBoxFunction.TabIndex = 30;
            this.textBoxFunction.Text = "A*sin(x)/x";
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.Location = new System.Drawing.Point(190, 143);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(120, 31);
            this.buttonRun.TabIndex = 29;
            this.buttonRun.Text = "Plot";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // trackBarY
            // 
            this.trackBarY.LargeChange = 1;
            this.trackBarY.Location = new System.Drawing.Point(852, 38);
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarY.Size = new System.Drawing.Size(45, 462);
            this.trackBarY.TabIndex = 48;
            this.trackBarY.Value = 3;
            this.trackBarY.ValueChanged += new System.EventHandler(this.trackBarY_ValueChanged);
            // 
            // trackBarX
            // 
            this.trackBarX.LargeChange = 1;
            this.trackBarX.Location = new System.Drawing.Point(346, 515);
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(500, 45);
            this.trackBarX.TabIndex = 47;
            this.trackBarX.Value = 3;
            this.trackBarX.ValueChanged += new System.EventHandler(this.trackBarX_ValueChanged);
            // 
            // panelPlot
            // 
            this.panelPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlot.Location = new System.Drawing.Point(346, 38);
            this.panelPlot.Name = "panelPlot";
            this.panelPlot.Size = new System.Drawing.Size(500, 462);
            this.panelPlot.TabIndex = 46;
            this.panelPlot.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlot_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(803, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 45;
            this.label8.Text = "y scale:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 502);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "x scale:";
            // 
            // FormFunctionCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 567);
            this.Controls.Add(this.progressBarCalc);
            this.Controls.Add(this.labelScaleX);
            this.Controls.Add(this.labelScaleY);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.panelPlot);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Name = "FormFunctionCal";
            this.Text = "FormFunctionCal";
            this.Load += new System.EventHandler(this.FormFunctionCal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarCalc;
        private System.Windows.Forms.Label labelScaleX;
        private System.Windows.Forms.Label labelScaleY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonUse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxParameters;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.Panel panelPlot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
    }
}