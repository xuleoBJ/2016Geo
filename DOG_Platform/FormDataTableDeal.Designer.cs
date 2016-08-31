namespace DOGPlatform
{
    partial class FormDataTableDeal
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDelDgvLine = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 555);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCopy);
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "删除重复数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(463, 523);
            this.dgv.TabIndex = 0;
            // 
            // btnDelDgvLine
            // 
            this.btnDelDgvLine.Location = new System.Drawing.Point(18, 139);
            this.btnDelDgvLine.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelDgvLine.Name = "btnDelDgvLine";
            this.btnDelDgvLine.Size = new System.Drawing.Size(90, 23);
            this.btnDelDgvLine.TabIndex = 25;
            this.btnDelDgvLine.Text = "删除行";
            this.btnDelDgvLine.UseVisualStyleBackColor = true;
            this.btnDelDgvLine.Click += new System.EventHandler(this.btnDelDgvLine_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(501, 57);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 23);
            this.btnCopy.TabIndex = 24;
            this.btnCopy.Text = "粘贴";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdb3);
            this.groupBox1.Controls.Add(this.rdb2);
            this.groupBox1.Controls.Add(this.rdb1);
            this.groupBox1.Controls.Add(this.btnDelDgvLine);
            this.groupBox1.Location = new System.Drawing.Point(501, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 182);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "删除列值相同的数据行";
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Checked = true;
            this.rdb1.Location = new System.Drawing.Point(18, 35);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(71, 16);
            this.rdb1.TabIndex = 26;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "首列相同";
            this.rdb1.UseVisualStyleBackColor = true;
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(18, 66);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(77, 16);
            this.rdb2.TabIndex = 27;
            this.rdb2.Text = "首2列相同";
            this.rdb2.UseVisualStyleBackColor = true;
            // 
            // rdb3
            // 
            this.rdb3.AutoSize = true;
            this.rdb3.Location = new System.Drawing.Point(18, 101);
            this.rdb3.Name = "rdb3";
            this.rdb3.Size = new System.Drawing.Size(77, 16);
            this.rdb3.TabIndex = 28;
            this.rdb3.Text = "首3列相同";
            this.rdb3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(133, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 125);
            this.label1.TabIndex = 29;
            this.label1.Text = "提示：预先在Excel排好序";
            // 
            // FormDataTableDeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 555);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormDataTableDeal";
            this.Text = "数据处理工具";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDelDgvLine;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.Label label1;
    }
}