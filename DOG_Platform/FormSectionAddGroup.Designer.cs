namespace DOGPlatform
{
    partial class FormSectionAddGroup
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
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxJH = new System.Windows.Forms.ListBox();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btn_deleteWell = new System.Windows.Forms.Button();
            this.btn_addWell = new System.Windows.Forms.Button();
            this.lbxJHSeclected = new System.Windows.Forms.ListBox();
            this.lblChooseModle = new System.Windows.Forms.Label();
            this.btnDataPre = new System.Windows.Forms.Button();
            this.cbbSelectTemplate = new System.Windows.Forms.ComboBox();
            this.rdbWellPositionABS = new System.Windows.Forms.RadioButton();
            this.rbsWellPositionRelative = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectAll.Location = new System.Drawing.Point(156, 132);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(42, 26);
            this.btnSelectAll.TabIndex = 46;
            this.btnSelectAll.Text = "=>";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, -45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 45;
            // 
            // lbxJH
            // 
            this.lbxJH.FormattingEnabled = true;
            this.lbxJH.ItemHeight = 12;
            this.lbxJH.Location = new System.Drawing.Point(12, 15);
            this.lbxJH.Margin = new System.Windows.Forms.Padding(2);
            this.lbxJH.Name = "lbxJH";
            this.lbxJH.Size = new System.Drawing.Size(114, 244);
            this.lbxJH.TabIndex = 44;
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectNone.Location = new System.Drawing.Point(156, 172);
            this.btnSelectNone.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(42, 26);
            this.btnSelectNone.TabIndex = 43;
            this.btnSelectNone.Text = "<=";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btn_deleteWell
            // 
            this.btn_deleteWell.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deleteWell.Location = new System.Drawing.Point(156, 96);
            this.btn_deleteWell.Margin = new System.Windows.Forms.Padding(2);
            this.btn_deleteWell.Name = "btn_deleteWell";
            this.btn_deleteWell.Size = new System.Drawing.Size(42, 26);
            this.btn_deleteWell.TabIndex = 41;
            this.btn_deleteWell.Text = "<-";
            this.btn_deleteWell.UseVisualStyleBackColor = true;
            this.btn_deleteWell.Click += new System.EventHandler(this.btn_deleteWell_Click);
            // 
            // btn_addWell
            // 
            this.btn_addWell.Font = new System.Drawing.Font("SimHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_addWell.Location = new System.Drawing.Point(156, 58);
            this.btn_addWell.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addWell.Name = "btn_addWell";
            this.btn_addWell.Size = new System.Drawing.Size(42, 26);
            this.btn_addWell.TabIndex = 42;
            this.btn_addWell.Text = "->";
            this.btn_addWell.UseVisualStyleBackColor = true;
            this.btn_addWell.Click += new System.EventHandler(this.btn_addWell_Click);
            // 
            // lbxJHSeclected
            // 
            this.lbxJHSeclected.FormattingEnabled = true;
            this.lbxJHSeclected.ItemHeight = 12;
            this.lbxJHSeclected.Location = new System.Drawing.Point(233, 15);
            this.lbxJHSeclected.Margin = new System.Windows.Forms.Padding(2);
            this.lbxJHSeclected.Name = "lbxJHSeclected";
            this.lbxJHSeclected.Size = new System.Drawing.Size(114, 244);
            this.lbxJHSeclected.TabIndex = 40;
            // 
            // lblChooseModle
            // 
            this.lblChooseModle.AutoSize = true;
            this.lblChooseModle.Location = new System.Drawing.Point(5, 290);
            this.lblChooseModle.Name = "lblChooseModle";
            this.lblChooseModle.Size = new System.Drawing.Size(53, 12);
            this.lblChooseModle.TabIndex = 65;
            this.lblChooseModle.Text = "选择模板";
            // 
            // btnDataPre
            // 
            this.btnDataPre.Location = new System.Drawing.Point(233, 330);
            this.btnDataPre.Name = "btnDataPre";
            this.btnDataPre.Size = new System.Drawing.Size(96, 26);
            this.btnDataPre.TabIndex = 70;
            this.btnDataPre.Text = "确认";
            this.btnDataPre.UseVisualStyleBackColor = true;
            this.btnDataPre.Click += new System.EventHandler(this.btnDataPre_Click);
            // 
            // cbbSelectTemplate
            // 
            this.cbbSelectTemplate.FormattingEnabled = true;
            this.cbbSelectTemplate.Location = new System.Drawing.Point(60, 288);
            this.cbbSelectTemplate.Name = "cbbSelectTemplate";
            this.cbbSelectTemplate.Size = new System.Drawing.Size(287, 20);
            this.cbbSelectTemplate.TabIndex = 72;
            // 
            // rdbWellPositionABS
            // 
            this.rdbWellPositionABS.AutoSize = true;
            this.rdbWellPositionABS.Checked = true;
            this.rdbWellPositionABS.Location = new System.Drawing.Point(24, 335);
            this.rdbWellPositionABS.Name = "rdbWellPositionABS";
            this.rdbWellPositionABS.Size = new System.Drawing.Size(71, 16);
            this.rdbWellPositionABS.TabIndex = 73;
            this.rdbWellPositionABS.TabStop = true;
            this.rdbWellPositionABS.Text = "绝对井位";
            this.rdbWellPositionABS.UseVisualStyleBackColor = true;
            // 
            // rbsWellPositionRelative
            // 
            this.rbsWellPositionRelative.AutoSize = true;
            this.rbsWellPositionRelative.Location = new System.Drawing.Point(127, 335);
            this.rbsWellPositionRelative.Name = "rbsWellPositionRelative";
            this.rbsWellPositionRelative.Size = new System.Drawing.Size(71, 16);
            this.rbsWellPositionRelative.TabIndex = 74;
            this.rbsWellPositionRelative.Text = "相对井位";
            this.rbsWellPositionRelative.UseVisualStyleBackColor = true;
            // 
            // FormSectionAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 393);
            this.Controls.Add(this.rbsWellPositionRelative);
            this.Controls.Add(this.rdbWellPositionABS);
            this.Controls.Add(this.cbbSelectTemplate);
            this.Controls.Add(this.btnDataPre);
            this.Controls.Add(this.lblChooseModle);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxJH);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btn_deleteWell);
            this.Controls.Add(this.btn_addWell);
            this.Controls.Add(this.lbxJHSeclected);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSectionAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建剖面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxJH;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btn_deleteWell;
        private System.Windows.Forms.Button btn_addWell;
        protected System.Windows.Forms.ListBox lbxJHSeclected;
        private System.Windows.Forms.Label lblChooseModle;
        private System.Windows.Forms.Button btnDataPre;
        private System.Windows.Forms.ComboBox cbbSelectTemplate;
        private System.Windows.Forms.RadioButton rdbWellPositionABS;
        private System.Windows.Forms.RadioButton rbsWellPositionRelative;
    }
}