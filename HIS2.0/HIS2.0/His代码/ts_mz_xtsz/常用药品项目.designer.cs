﻿namespace ts_mz_xtsz
{
    partial class FrmItem
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.厂家 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单价 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_ItemType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_NowQuery = new System.Windows.Forms.Button();
            this.txt_NowQuery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Oldquery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_OldQuery = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.lblyplx = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.规格,
            this.厂家,
            this.单价,
            this.Column3,
            this.Column4,
            this.Column1,
            this.Column13});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(445, 465);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "item_name";
            this.Column2.HeaderText = "项目名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // 规格
            // 
            this.规格.DataPropertyName = "ypgg";
            this.规格.HeaderText = "规格";
            this.规格.Name = "规格";
            this.规格.ReadOnly = true;
            this.规格.Width = 80;
            // 
            // 厂家
            // 
            this.厂家.DataPropertyName = "cj";
            this.厂家.HeaderText = "厂家";
            this.厂家.Name = "厂家";
            this.厂家.ReadOnly = true;
            this.厂家.Width = 80;
            // 
            // 单价
            // 
            this.单价.DataPropertyName = "dj";
            this.单价.HeaderText = "单价";
            this.单价.Name = "单价";
            this.单价.ReadOnly = true;
            this.单价.Width = 50;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "py_code";
            this.Column3.HeaderText = "拼音码";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "tcbz";
            this.Column4.HeaderText = "tcbz";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 5;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "item_id";
            this.Column1.HeaderText = "item_id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 50;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "cjid";
            this.Column13.HeaderText = "cjid";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column7,
            this.Column8,
            this.Column5,
            this.Column12});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(409, 465);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.DockChanged += new System.EventHandler(this.dataGridView2_DockChanged);
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "item_name";
            this.Column6.HeaderText = "项目名称";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 160;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "ypgg";
            this.Column9.HeaderText = "规格";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 80;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "cj";
            this.Column10.HeaderText = "厂家";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "dj";
            this.Column11.HeaderText = "单价";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 50;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "py_code";
            this.Column7.HeaderText = "拼音码";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "tcbz";
            this.Column8.HeaderText = "tcbz";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 5;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "item_id";
            this.Column5.HeaderText = "item_id";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 50;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "cjid";
            this.Column12.HeaderText = "cjid";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // cmb_ItemType
            // 
            this.cmb_ItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ItemType.FormattingEnabled = true;
            this.cmb_ItemType.Items.AddRange(new object[] {
            "项目",
            "药品"});
            this.cmb_ItemType.Location = new System.Drawing.Point(65, 11);
            this.cmb_ItemType.Name = "cmb_ItemType";
            this.cmb_ItemType.Size = new System.Drawing.Size(121, 20);
            this.cmb_ItemType.TabIndex = 2;
            this.cmb_ItemType.SelectedIndexChanged += new System.EventHandler(this.cmb_ItemType_SelectedIndexChanged);
            this.cmb_ItemType.TextChanged += new System.EventHandler(this.txt_OldQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目类型";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbyplx);
            this.panel1.Controls.Add(this.lblyplx);
            this.panel1.Controls.Add(this.cmb_ItemType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 40);
            this.panel1.TabIndex = 4;
            // 
            // btn_NowQuery
            // 
            this.btn_NowQuery.Location = new System.Drawing.Point(327, 4);
            this.btn_NowQuery.Name = "btn_NowQuery";
            this.btn_NowQuery.Size = new System.Drawing.Size(53, 24);
            this.btn_NowQuery.TabIndex = 8;
            this.btn_NowQuery.Text = "查询";
            this.btn_NowQuery.UseVisualStyleBackColor = true;
            this.btn_NowQuery.Click += new System.EventHandler(this.btn_NowQuery_Click);
            // 
            // txt_NowQuery
            // 
            this.txt_NowQuery.Location = new System.Drawing.Point(194, 5);
            this.txt_NowQuery.Name = "txt_NowQuery";
            this.txt_NowQuery.Size = new System.Drawing.Size(125, 21);
            this.txt_NowQuery.TabIndex = 7;
            this.txt_NowQuery.Click += new System.EventHandler(this.txt_NowQuery_Click);
            this.txt_NowQuery.TextChanged += new System.EventHandler(this.btn_NowQuery_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "查询";
            // 
            // btn_Oldquery
            // 
            this.btn_Oldquery.Location = new System.Drawing.Point(246, 5);
            this.btn_Oldquery.Name = "btn_Oldquery";
            this.btn_Oldquery.Size = new System.Drawing.Size(56, 23);
            this.btn_Oldquery.TabIndex = 5;
            this.btn_Oldquery.Text = "查询";
            this.btn_Oldquery.UseVisualStyleBackColor = true;
            this.btn_Oldquery.Click += new System.EventHandler(this.btn_Oldquery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "查询";
            // 
            // txt_OldQuery
            // 
            this.txt_OldQuery.Location = new System.Drawing.Point(121, 7);
            this.txt_OldQuery.Name = "txt_OldQuery";
            this.txt_OldQuery.Size = new System.Drawing.Size(121, 21);
            this.txt_OldQuery.TabIndex = 3;
            this.txt_OldQuery.Click += new System.EventHandler(this.txt_OldQuery_Click);
            this.txt_OldQuery.TextChanged += new System.EventHandler(this.btn_Oldquery_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 495);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(445, 465);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btn_Oldquery);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txt_OldQuery);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 30);
            this.panel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(7, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "原有项目";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(445, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 495);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(448, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(409, 495);
            this.panel5.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dataGridView2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 30);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(409, 465);
            this.panel7.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_NowQuery);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txt_NowQuery);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(409, 30);
            this.panel6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(8, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "已有项目";
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.FormattingEnabled = true;
            this.cmbyplx.Items.AddRange(new object[] {
            "项目",
            "药品"});
            this.cmbyplx.Location = new System.Drawing.Point(246, 12);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(121, 20);
            this.cmbyplx.TabIndex = 4;
            this.cmbyplx.SelectedIndexChanged += new System.EventHandler(this.cmbyplx_SelectedIndexChanged);
            // 
            // lblyplx
            // 
            this.lblyplx.AutoSize = true;
            this.lblyplx.Location = new System.Drawing.Point(193, 16);
            this.lblyplx.Name = "lblyplx";
            this.lblyplx.Size = new System.Drawing.Size(53, 12);
            this.lblyplx.TabIndex = 3;
            this.lblyplx.Text = "药品类型";
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(857, 535);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmItem";
            this.Text = "常用项目药品维护";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cmb_ItemType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_NowQuery;
        private System.Windows.Forms.TextBox txt_NowQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Oldquery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_OldQuery;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 规格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 厂家;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单价;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.ComboBox cmbyplx;
        private System.Windows.Forms.Label lblyplx;
    }
}

