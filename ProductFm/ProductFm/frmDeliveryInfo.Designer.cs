namespace ProductFm
{
    partial class FmProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboQuan_Huyen = new System.Windows.Forms.ComboBox();
            this.cboPhuong_Xa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtReciever = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quận/Huyện";
            // 
            // cboQuan_Huyen
            // 
            this.cboQuan_Huyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuan_Huyen.FormattingEnabled = true;
            this.cboQuan_Huyen.Location = new System.Drawing.Point(103, 24);
            this.cboQuan_Huyen.Name = "cboQuan_Huyen";
            this.cboQuan_Huyen.Size = new System.Drawing.Size(219, 21);
            this.cboQuan_Huyen.TabIndex = 1;
            this.cboQuan_Huyen.SelectedIndexChanged += new System.EventHandler(this.cboQuan_Huyen_SelectedIndexChanged);
            // 
            // cboPhuong_Xa
            // 
            this.cboPhuong_Xa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuong_Xa.FormattingEnabled = true;
            this.cboPhuong_Xa.Location = new System.Drawing.Point(103, 70);
            this.cboPhuong_Xa.Name = "cboPhuong_Xa";
            this.cboPhuong_Xa.Size = new System.Drawing.Size(219, 21);
            this.cboPhuong_Xa.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phường/Xã";
            // 
            // txtDChi
            // 
            this.txtDChi.Location = new System.Drawing.Point(103, 114);
            this.txtDChi.Name = "txtDChi";
            this.txtDChi.Size = new System.Drawing.Size(219, 20);
            this.txtDChi.TabIndex = 3;
            this.txtDChi.TextChanged += new System.EventHandler(this.txtDChi_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Họ tên";
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(103, 158);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(219, 20);
            this.txtHoten.TabIndex = 4;
            this.txtHoten.TextChanged += new System.EventHandler(this.txtHoten_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số ĐT";
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(103, 209);
            this.txtSdt.MaxLength = 10;
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(219, 20);
            this.txtSdt.TabIndex = 5;
            this.txtSdt.TextChanged += new System.EventHandler(this.txtSdt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Thông tin người nhận";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(31, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReciever
            // 
            this.txtReciever.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtReciever.Enabled = false;
            this.txtReciever.ForeColor = System.Drawing.SystemColors.Window;
            this.txtReciever.Location = new System.Drawing.Point(31, 275);
            this.txtReciever.Multiline = true;
            this.txtReciever.Name = "txtReciever";
            this.txtReciever.ReadOnly = true;
            this.txtReciever.Size = new System.Drawing.Size(291, 104);
            this.txtReciever.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(245, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 431);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtReciever);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDChi);
            this.Controls.Add(this.cboPhuong_Xa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboQuan_Huyen);
            this.Controls.Add(this.label1);
            this.Name = "FmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmProduct_FormClosing);
            this.Load += new System.EventHandler(this.FmProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboQuan_Huyen;
        private System.Windows.Forms.ComboBox cboPhuong_Xa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtReciever;
        private System.Windows.Forms.Button btnClose;
    }
}

