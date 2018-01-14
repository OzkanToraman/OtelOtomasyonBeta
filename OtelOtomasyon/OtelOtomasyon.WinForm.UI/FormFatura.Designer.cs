namespace OtelOtomasyon.WinForm.UI
{
    partial class FormFatura
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
            this.lblBiletSatis = new System.Windows.Forms.Label();
            this.cbBiletSatis = new System.Windows.Forms.ComboBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvFatura = new System.Windows.Forms.DataGridView();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFatura)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBiletSatis
            // 
            this.lblBiletSatis.AutoSize = true;
            this.lblBiletSatis.BackColor = System.Drawing.Color.Transparent;
            this.lblBiletSatis.ForeColor = System.Drawing.Color.White;
            this.lblBiletSatis.Location = new System.Drawing.Point(379, 116);
            this.lblBiletSatis.Name = "lblBiletSatis";
            this.lblBiletSatis.Size = new System.Drawing.Size(0, 15);
            this.lblBiletSatis.TabIndex = 51;
            this.lblBiletSatis.Visible = false;
            // 
            // cbBiletSatis
            // 
            this.cbBiletSatis.FormattingEnabled = true;
            this.cbBiletSatis.Items.AddRange(new object[] {
            "Satılanlar",
            "İptal Edilenler"});
            this.cbBiletSatis.Location = new System.Drawing.Point(382, 134);
            this.cbBiletSatis.Name = "cbBiletSatis";
            this.cbBiletSatis.Size = new System.Drawing.Size(121, 23);
            this.cbBiletSatis.TabIndex = 50;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(753, 132);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(108, 21);
            this.dtpTarih.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(750, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Fatura Tarih:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(55, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 15);
            this.label16.TabIndex = 48;
            this.label16.Text = "Fatura No:";
            // 
            // dgvFatura
            // 
            this.dgvFatura.AllowUserToAddRows = false;
            this.dgvFatura.AllowUserToDeleteRows = false;
            this.dgvFatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFatura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFatura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFatura.Location = new System.Drawing.Point(58, 180);
            this.dgvFatura.MultiSelect = false;
            this.dgvFatura.Name = "dgvFatura";
            this.dgvFatura.ReadOnly = true;
            this.dgvFatura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFatura.Size = new System.Drawing.Size(803, 278);
            this.dgvFatura.TabIndex = 46;
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(58, 134);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(82, 21);
            this.txtFaturaNo.TabIndex = 45;
            // 
            // FormFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 551);
            this.Controls.Add(this.lblBiletSatis);
            this.Controls.Add(this.cbBiletSatis);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvFatura);
            this.Controls.Add(this.txtFaturaNo);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFatura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatura İşlemleri";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFatura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBiletSatis;
        private System.Windows.Forms.ComboBox cbBiletSatis;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvFatura;
        private System.Windows.Forms.TextBox txtFaturaNo;
    }
}