
using OtelOtomasyon.DAL.New;
using OtelOtomasyon.WinForm.UI.KimlikDogrulama;
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
    public partial class FormKimlikSorgulama : Form
    {
        public static KimlikSorgulamaClass ks;
        public FormKimlikSorgulama()
        {
            InitializeComponent();
        }

        private void FormKimlikSorgulama_Load(object sender, EventArgs e)
        {

        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            KPSPublicSoapClient servis = new KPSPublicSoapClient();
            bool varmi = false;
            varmi = servis.TCKimlikNoDogrula(Convert.ToInt64(txtKimlikNo.Text), txtAd.Text.ToUpper(), txtSoyad.Text.ToUpper(), Convert.ToInt32(txtDogum.Text));
            if (varmi)
            {
                MessageBox.Show("TC Doğru ");
                ks = new KimlikSorgulamaClass()
                {
                    Ad = txtAd.Text.Substring(0, 1).ToUpper() + txtAd.Text.Substring(1).ToLower(),
                    Soyad = txtSoyad.Text.Substring(0, 1).ToUpper() + txtSoyad.Text.Substring(1).ToLower(),
                    KimlikNo = txtKimlikNo.Text
                };
                this.Close();
            }
            else
            {
                MessageBox.Show("TC Yanlış  ");
                txtAd.Focus();
            }
        }
    }
}
