
namespace GUI_MAIN
{
    partial class frmFormChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormChild));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCloseChild = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdoNG = new System.Windows.Forms.RadioButton();
            this.rdoOK = new System.Windows.Forms.RadioButton();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtResistor = new System.Windows.Forms.TextBox();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cOLUMN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 102);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(472, 42);
            this.label3.TabIndex = 9;
            this.label3.Text = "Danh sách dữ liệu vị trí kệ";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(89, 32);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(69, 25);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "VITRI";
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.panel3);
            this.grpMain.Controls.Add(this.panel2);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMain.Location = new System.Drawing.Point(0, 102);
            this.grpMain.Margin = new System.Windows.Forms.Padding(4);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(4);
            this.grpMain.Size = new System.Drawing.Size(848, 234);
            this.grpMain.TabIndex = 6;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "+++";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCloseChild);
            this.panel3.Controls.Add(this.btnAddChild);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(4, 175);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(840, 55);
            this.panel3.TabIndex = 1;
            // 
            // btnCloseChild
            // 
            this.btnCloseChild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseChild.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChild.Name = "btnCloseChild";
            this.btnCloseChild.Size = new System.Drawing.Size(158, 55);
            this.btnCloseChild.TabIndex = 1;
            this.btnCloseChild.Text = "Đóng";
            this.btnCloseChild.UseVisualStyleBackColor = true;
            this.btnCloseChild.Click += new System.EventHandler(this.btnCloseChild_Click);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddChild.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddChild.Location = new System.Drawing.Point(158, 0);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(682, 55);
            this.btnAddChild.TabIndex = 0;
            this.btnAddChild.Text = "Tiếp Tục Thêm";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblAddress);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.txtNote);
            this.panel2.Controls.Add(this.txtResistor);
            this.panel2.Controls.Add(this.txtVoltage);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 132);
            this.panel2.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(89, 75);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(69, 25);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "VITRI";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.rdoNG);
            this.groupBox5.Controls.Add(this.rdoOK);
            this.groupBox5.Location = new System.Drawing.Point(496, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(121, 109);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Trạng thái:";
            // 
            // rdoNG
            // 
            this.rdoNG.AutoSize = true;
            this.rdoNG.Location = new System.Drawing.Point(29, 66);
            this.rdoNG.Name = "rdoNG";
            this.rdoNG.Size = new System.Drawing.Size(49, 22);
            this.rdoNG.TabIndex = 1;
            this.rdoNG.Text = "NG";
            this.rdoNG.UseVisualStyleBackColor = true;
            // 
            // rdoOK
            // 
            this.rdoOK.AutoSize = true;
            this.rdoOK.Checked = true;
            this.rdoOK.Location = new System.Drawing.Point(29, 38);
            this.rdoOK.Name = "rdoOK";
            this.rdoOK.Size = new System.Drawing.Size(48, 22);
            this.rdoOK.TabIndex = 0;
            this.rdoOK.TabStop = true;
            this.rdoOK.Text = "OK";
            this.rdoOK.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(663, 30);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(153, 88);
            this.txtNote.TabIndex = 3;
            // 
            // txtResistor
            // 
            this.txtResistor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResistor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResistor.Location = new System.Drawing.Point(261, 30);
            this.txtResistor.Name = "txtResistor";
            this.txtResistor.Size = new System.Drawing.Size(204, 29);
            this.txtResistor.TabIndex = 0;
            // 
            // txtVoltage
            // 
            this.txtVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoltage.Location = new System.Drawing.Point(261, 89);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.Size = new System.Drawing.Size(204, 29);
            this.txtVoltage.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(660, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ghi chú:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vị trí:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Điện trở:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Điện thế:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvData);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 336);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(848, 302);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dữ liệu";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cOLUMN1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.SystemColors.Control;
            this.dgvData.Location = new System.Drawing.Point(4, 51);
            this.dgvData.Margin = new System.Windows.Forms.Padding(4);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(840, 247);
            this.dgvData.TabIndex = 1;
            // 
            // cOLUMN1
            // 
            this.cOLUMN1.HeaderText = "Ngày thêm";
            this.cOLUMN1.Name = "cOLUMN1";
            this.cOLUMN1.ReadOnly = true;
            this.cOLUMN1.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Trạng thái";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Điện trở";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Điện thế";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Ghi chú";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 300;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblSum);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 21);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(840, 30);
            this.panel4.TabIndex = 0;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSum.Location = new System.Drawing.Point(758, 0);
            this.lblSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(82, 18);
            this.lblSum.TabIndex = 1;
            this.lblSum.Text = "Số bản ghi:";
            // 
            // frmFormChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 638);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmFormChild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChild";
            this.Load += new System.EventHandler(this.frmFormChild_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOLUMN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdoNG;
        private System.Windows.Forms.RadioButton rdoOK;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtResistor;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnCloseChild;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}