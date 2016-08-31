namespace DOGPlatform
{
    partial class FormSettingSplitFactor
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
            this.dgvLayerSplitFactor = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.属性 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbYM = new System.Windows.Forms.ComboBox();
            this.btnSetSelectedJH = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbJH = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.dgvGroupSplitFactor = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbJHGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbbYMGroup = new System.Windows.Forms.ComboBox();
            this.cbbLayerGroup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCalSplitFactor = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayerSplitFactor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupSplitFactor)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLayerSplitFactor
            // 
            this.dgvLayerSplitFactor.AllowUserToOrderColumns = true;
            this.dgvLayerSplitFactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLayerSplitFactor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.属性,
            this.Column5,
            this.Column4,
            this.Column6});
            this.dgvLayerSplitFactor.Location = new System.Drawing.Point(12, 66);
            this.dgvLayerSplitFactor.Name = "dgvLayerSplitFactor";
            this.dgvLayerSplitFactor.RowTemplate.Height = 23;
            this.dgvLayerSplitFactor.Size = new System.Drawing.Size(790, 184);
            this.dgvLayerSplitFactor.TabIndex = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "井号";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "小层号";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "年月";
            this.Column3.Name = "Column3";
            // 
            // 属性
            // 
            this.属性.HeaderText = "劈分系数";
            this.属性.Name = "属性";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "砂厚(h)";
            this.Column5.Name = "Column5";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "渗透率(K)";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "垂向产液(吸水)比值";
            this.Column6.Name = "Column6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 49;
            this.label3.Text = "选择年月";
            // 
            // cbbYM
            // 
            this.cbbYM.FormattingEnabled = true;
            this.cbbYM.Location = new System.Drawing.Point(298, 40);
            this.cbbYM.Name = "cbbYM";
            this.cbbYM.Size = new System.Drawing.Size(114, 20);
            this.cbbYM.TabIndex = 48;
            // 
            // btnSetSelectedJH
            // 
            this.btnSetSelectedJH.Location = new System.Drawing.Point(433, 34);
            this.btnSetSelectedJH.Name = "btnSetSelectedJH";
            this.btnSetSelectedJH.Size = new System.Drawing.Size(89, 23);
            this.btnSetSelectedJH.TabIndex = 47;
            this.btnSetSelectedJH.Text = "确认井号";
            this.btnSetSelectedJH.UseVisualStyleBackColor = true;
            this.btnSetSelectedJH.Click += new System.EventHandler(this.btnSetSelectedJH_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 43;
            this.label12.Text = "井号";
            // 
            // cbbJH
            // 
            this.cbbJH.FormattingEnabled = true;
            this.cbbJH.Location = new System.Drawing.Point(21, 36);
            this.cbbJH.Name = "cbbJH";
            this.cbbJH.Size = new System.Drawing.Size(108, 20);
            this.cbbJH.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.dgvGroupSplitFactor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbJHGroup);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.cbbYMGroup);
            this.groupBox1.Controls.Add(this.cbbLayerGroup);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(30, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 324);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "井组劈分系数";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(132, 289);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 23);
            this.button4.TabIndex = 63;
            this.button4.Text = "删除注采关系";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 290);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 23);
            this.button5.TabIndex = 64;
            this.button5.Text = "添加注采关系";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(542, 39);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(119, 16);
            this.radioButton3.TabIndex = 61;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "更新选择月后全部";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(542, 17);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(95, 16);
            this.radioButton4.TabIndex = 62;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "只更新所选月";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // dgvGroupSplitFactor
            // 
            this.dgvGroupSplitFactor.AllowUserToOrderColumns = true;
            this.dgvGroupSplitFactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupSplitFactor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvGroupSplitFactor.Location = new System.Drawing.Point(9, 65);
            this.dgvGroupSplitFactor.Name = "dgvGroupSplitFactor";
            this.dgvGroupSplitFactor.RowTemplate.Height = 23;
            this.dgvGroupSplitFactor.Size = new System.Drawing.Size(790, 213);
            this.dgvGroupSplitFactor.TabIndex = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "注水井";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "对应井";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "劈分系数";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "砂厚(h)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "渗透率";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "平面比值";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 59;
            this.label1.Text = "选择年月";
            // 
            // cbbJHGroup
            // 
            this.cbbJHGroup.FormattingEnabled = true;
            this.cbbJHGroup.Location = new System.Drawing.Point(9, 38);
            this.cbbJHGroup.Name = "cbbJHGroup";
            this.cbbJHGroup.Size = new System.Drawing.Size(83, 20);
            this.cbbJHGroup.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "选择小层";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "更新系数";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(308, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 23);
            this.button3.TabIndex = 57;
            this.button3.Text = "注采分析";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cbbYMGroup
            // 
            this.cbbYMGroup.FormattingEnabled = true;
            this.cbbYMGroup.Location = new System.Drawing.Point(206, 38);
            this.cbbYMGroup.Name = "cbbYMGroup";
            this.cbbYMGroup.Size = new System.Drawing.Size(83, 20);
            this.cbbYMGroup.TabIndex = 58;
            // 
            // cbbLayerGroup
            // 
            this.cbbLayerGroup.FormattingEnabled = true;
            this.cbbLayerGroup.Location = new System.Drawing.Point(113, 38);
            this.cbbLayerGroup.Name = "cbbLayerGroup";
            this.cbbLayerGroup.Size = new System.Drawing.Size(79, 20);
            this.cbbLayerGroup.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "注水井号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.dgvLayerSplitFactor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbbJH);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnSetSelectedJH);
            this.groupBox2.Controls.Add(this.cbbYM);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(30, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 263);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "层间劈分系数调整";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(649, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(119, 16);
            this.radioButton2.TabIndex = 51;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "更新选择月后全部";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(649, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 51;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "只更新所选月";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "更新系数";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCalSplitFactor
            // 
            this.btnCalSplitFactor.Location = new System.Drawing.Point(39, 12);
            this.btnCalSplitFactor.Name = "btnCalSplitFactor";
            this.btnCalSplitFactor.Size = new System.Drawing.Size(137, 23);
            this.btnCalSplitFactor.TabIndex = 53;
            this.btnCalSplitFactor.Text = "计算垂向劈分系数";
            this.btnCalSplitFactor.UseVisualStyleBackColor = true;
            this.btnCalSplitFactor.Click += new System.EventHandler(this.btnCalSplitFactor_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(199, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(137, 23);
            this.button6.TabIndex = 53;
            this.button6.Text = "计算平面劈分系数";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnCalSplitFactor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "选择小层";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(193, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 20);
            this.comboBox1.TabIndex = 65;
            // 
            // FormSettingSplitFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 668);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnCalSplitFactor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormSettingSplitFactor";
            this.Text = "劈分系数设置";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLayerSplitFactor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupSplitFactor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLayerSplitFactor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbYM;
        private System.Windows.Forms.Button btnSetSelectedJH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbJH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.DataGridView dgvGroupSplitFactor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbJHGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbbYMGroup;
        private System.Windows.Forms.ComboBox cbbLayerGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnCalSplitFactor;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 属性;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}