using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyon.WinForm.UI
{
    public partial class FormAnasayfa : Form
    {
        string Role;
        public FormAnasayfa(string Role)
        {
            this.Role = Role;
            InitializeComponent();
        }

        private void btnOdaIslemleri_Click(object sender, EventArgs e)
        {
            FormOdaIslemleri frmOdaIslemleri = new FormOdaIslemleri();
            frmOdaIslemleri.ShowDialog();
        }

        private void btnPersonelIslemleri_Click(object sender, EventArgs e)
        {
            FormPersonelIslemleri frmPersonel = new FormPersonelIslemleri();
            frmPersonel.ShowDialog();
        }

        private void btnResepsiyon_Click(object sender, EventArgs e)
        {
            FormResepsiyon frmResepsiyon = new FormResepsiyon();
            frmResepsiyon.ShowDialog();
        }

        private void btnSatinAlma_Click(object sender, EventArgs e)
        {

        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            FormFatura frmFatura = new FormFatura();
            frmFatura.ShowDialog();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {

        }

        private void btnOturumKapat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkış yapmak istiyor musunuz ? ", "Uyarı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close() ;
            }
        }

        private void FormAnasayfa_Load(object sender, EventArgs e)
        {
            lblKullanici.Text =  "Oturum : " +FormLogin.kullanici;
            if (Role !="Admin")
            {
                btnPersonelIslemleri.Enabled = false;
                btnOdaIslemleri.Enabled = false;
                btnSatinAlma.Enabled = false;
            }
        }

        private void FormAnasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin frmLog = new FormLogin();
            frmLog.Show();
        }
    }
}
