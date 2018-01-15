using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.DAL;
using OtelOtomasyon.Repository.Abstract;
using OtelOtomasyon.Repository.UOW.Abstract;
using OtelOtomasyon.WinForm.UI.Ninject;
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
    public partial class FormResepsiyon : Form
    {
        int turId, ozellikId, fiyatId, katId, odaId, modId, rezervasyonId, musteriId, personelId, tarihMod;
        int bilgiRezerveId, kontrolBilgiRezerveId;
        int kacGun;
        IEnumerable<string> odalar;
        Satis sorgu = new Satis();
        string sagTus;

        protected IUnitOfWork _uow;
        protected IMusteriService _musteriService;
        protected IMusteriRepository _musteriRepo;
        public FormResepsiyon()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _uow = container.Get<IUnitOfWork>();
            _musteriService = container.Get<IMusteriService>();
            _musteriRepo = container.Get<IMusteriRepository>();
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private async void FormResepsiyon_Load(object sender, EventArgs e)
        {
            #region Tarih ayarları
            dtpTarih.MinDate = DateTime.Today;
            dtpTarih.MaxDate = dtpTarih.MinDate.AddDays(5);
            dtpGiris.Value = DateTime.Today;
            dtpGiris.MinDate = DateTime.Today;
            dtpCikis.MinDate = dtpGiris.MinDate.AddDays(1);
            txtGiris.Text = dtpGiris.Value.ToShortDateString();
            txtCikis.Text = dtpCikis.Value.ToShortDateString();
            kacGun = (dtpCikis.Value - dtpGiris.Value).Days;
            #endregion
            #region TarihModu
            tarihMod = dtpTarih.Value.Day % 6;
            if (tarihMod == 0)
            {
                tarihMod = 6;
            }
            #endregion
            #region ContextMenuItemControl
            if (odalar == null)
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
            #endregion

            Task task = new Task(FormLoadItems);
            task.Start();
            await task;

        }


        #region ComboboxFill
        private void OdaTurDoldur()
        {
            cbOdaTur.DataSource = _uow.GetRepo<OdaTur>().GetList().Select(x => new
            {
                x.Id,
                x.TurAd
            }).ToList();
            cbOdaTur.DisplayMember = "TurAd";
            cbOdaTur.ValueMember = "Id";
        }


        private void OdaOpsiyonDoldur()
        {

            cbOpsiyon.DataSource = _uow.GetRepo<Ozellik>().GetList().Select(x => new
            {
                x.Id,
                x.OzellikAd
            }).ToList();
            cbOpsiyon.DisplayMember = "OzellikAd";
            cbOpsiyon.ValueMember = "Id";
        }


        private void KatDoldur()
        {
            cbKat.DataSource = _uow.GetRepo<Kat>().GetList().Select(x => new
            {
                x.Id,
                x.KatNo
            }).ToList();
            cbKat.DisplayMember = "KatNo";
            cbKat.ValueMember = "Id";
        }


        private void CinsiyetDoldur()
        {
            cbCinsiyet.DataSource = _uow.GetRepo<Cinsiyet>().GetList().Select(x => new
            {
                x.Id,
                x.Ad
            }).ToList();
            cbCinsiyet.DisplayMember = "Ad";
            cbCinsiyet.ValueMember = "Id";
        }



        private void MedeniHalDoldur()
        {
            cbMedeniHal.DataSource = _uow.GetRepo<MedeniDurum>().GetList().Select(x => new
            {
                x.Id,
                x.MedeniDurum1
            }).ToList();
            cbMedeniHal.DisplayMember = "MedeniDurum1";
            cbMedeniHal.ValueMember = "Id";
        }

        #endregion
        #region Combobox Index Changed
        private void cbOdaTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOdaBilgisi.Text = cbOdaTur.Text;
        }

        private void cbOpsiyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOdaOpsiyon.Text = cbOpsiyon.Text;
        }

        private void cbKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKat.Text = cbKat.Text;


        }
        #endregion
        #region DateTimePickerChanged
        private void dtpGiris_ValueChanged(object sender, EventArgs e)
        {
            dtpGiris.MaxDate = DateTime.Today.AddDays(5);
            txtGiris.Text = dtpGiris.Value.ToShortDateString();
            dtpCikis.MinDate = dtpGiris.Value.AddDays(1);
        }
        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            tarihMod = dtpTarih.Value.Day % 6;
            if (tarihMod == 0)
            {
                tarihMod = 6;
            }
            OdaBosalt();
            DoluOdaKontrol();
            RezerveOdaKontrol();
            BosOdaSayisiHesapla();
        }
        private void dtpCikis_ValueChanged(object sender, EventArgs e)
        {
            txtCikis.Text = dtpCikis.Value.ToShortDateString();
            kacGun = (dtpCikis.Value - dtpGiris.Value).Days;
        }
        private void dtpDogum_ValueChanged(object sender, EventArgs e)
        {
            txtDogum.Text = dtpDogum.Value.ToShortDateString();
        }
        #endregion
        #region MouseActions
        private void btn1101_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ToolTip tt = new ToolTip();
            if (btn.Text == "BOŞ")
            {
                tt.SetToolTip(btn, btn.Text);
            }
            else if (btn.Text == "REZERVE" || btn.Text == "DOLU")
            {
                #region ToolTips
                int rezerveModId = dtpTarih.Value.Day % 6;
                if (rezervasyonId == 0)
                {
                    rezervasyonId = 6;
                }

                bilgiRezerveId = _uow.GetRepo<Rezervasyon>()
                    .WhereByQuery(x => x.Oda.OdaAd == btn.Name && x.Mod.Ad == rezerveModId.ToString())
                    .FirstOrDefault()
                    .Id;

                bool varmi = Convert.ToBoolean(_uow.GetRepo<Satis>()
               .WhereByQuery(x => x.RezervasyonId == bilgiRezerveId)
               .Count());

                if (varmi)
                {
                    sorgu = _uow.GetRepo<Satis>()
                        .WhereByQuery(x => x.RezervasyonId == bilgiRezerveId)
                        .FirstOrDefault();
                }
                else
                {
                    if (bilgiRezerveId != kontrolBilgiRezerveId && kontrolBilgiRezerveId != 0)
                    {
                        bilgiRezerveId = kontrolBilgiRezerveId;
                    }
                    kontrolBilgiRezerveId = bilgiRezerveId;
                    sorgu = _uow.GetRepo<Satis>()
                                  .WhereByQuery(x => x.RezervasyonId == kontrolBilgiRezerveId)
                                  .FirstOrDefault();
                }

                tt.SetToolTip(btn, "Müşteri Adı ve Soyadı: \n" + (sorgu.Musteri.Ad + " " + sorgu.Musteri.Soyad));
                #endregion
            }
        }



        private void btn1101_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                sagTus = btn.Name;
            }
        }
        #endregion
        #region ContextMenuActions
        private void seçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control[] ctrl = Controls.Find(sagTus, true);
            Button bt = (Button)ctrl.FirstOrDefault();
            if (bt.BackColor != Color.Red && bt.BackColor != Color.Orange)
            {
                if (bt.BackColor == Color.Green)
                {
                    bt.BackColor = Color.Yellow;
                }

                if (odalar != null)
                {
                    foreach (string item in odalar)
                    {
                        Button btn = new Button();
                        btn = (Button)this.Controls[item];
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Silver;
                        }
                    }
                    cbKat.Text = sagTus.Substring(3, 1);
                    if (bt.BackColor != Color.Red && bt.BackColor != Color.Orange)
                    {
                        txtOdaNo.Text = sagTus.Substring(3, 4);
                    }
                }
            }
        }
        private void RezerveIptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int iptalEdilecekRezId = 0;
            Control[] ctrl = Controls.Find(sagTus, true);
            Button bt = (Button)ctrl.FirstOrDefault();
            if (bt.BackColor == Color.Orange)
            {
                var RezerveIptalEdilecekOdalar = _uow.GetRepo<Rezervasyon>()
                      .Where(x => x.Oda.OdaAd == sagTus && x.RezerveMi == true)
                      .Select(x => new
                      {
                          x.GirisTarihi,
                          x.CikisTarihi,
                      });
                foreach (var item in RezerveIptalEdilecekOdalar)
                {
                    for (int i = item.GirisTarihi.Day; i <= item.CikisTarihi.Day; i++)
                    {
                        int iptalMod = i % 6;
                        if (i == 0)
                        {
                            i = 6;
                        }
                        iptalEdilecekRezId = _uow.GetRepo<Rezervasyon>()
                            .Where(x => x.Oda.OdaAd == sagTus && x.Mod.Ad == iptalMod.ToString())
                            .FirstOrDefault()
                            .Id;
                        _uow.GetRepo<Rezervasyon>().GetById(iptalEdilecekRezId).RezerveMi = false;
                    }
                }
                if (iptalEdilecekRezId != 0)
                {
                    int iptalEdilecekSatisId = _uow.GetRepo<Satis>()
                         .Where(x => x.RezervasyonId == iptalEdilecekRezId)
                         .FirstOrDefault()
                         .Id;
                    _uow.GetRepo<Satis>().GetById(iptalEdilecekSatisId).SatildiMi = false;
                    if (_uow.Commit() > 0)
                    {
                        MessageBox.Show("Rezervasyon başarıyla iptal edilmiştir.");
                    }
                }
                else
                {
                    MessageBox.Show("Hata");
                }
                OdaBosalt();
                RezerveOdaKontrol();
                DoluOdaKontrol();
                BosOdaSayisiHesapla();
            }
            else
            {
                MessageBox.Show("Seçilen oda rezerve değil!", "Hata");
            }
        }
        private void seçimiBırakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odalar = new List<string>();
            foreach (Button item in this.Controls.OfType<Button>())
            {
                if (item.BackColor != Color.Red && item.BackColor != Color.Orange)
                {
                    item.BackColor = Color.Silver;
                }

            }
        }
        private void odaİptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iptalEdilecekRezId = 0;
            Control[] ctrl = Controls.Find(sagTus, true);
            Button bt = (Button)ctrl.FirstOrDefault();
            if (bt.BackColor == Color.Red)
            {
                var IptalEdilecekOdalar = _uow.GetRepo<Rezervasyon>()
                      .Where(x => x.Oda.OdaAd == sagTus && x.DoluMu == true)
                      .Select(x => new
                      {
                          x.GirisTarihi,
                          x.CikisTarihi,
                      });
                foreach (var item in IptalEdilecekOdalar)
                {
                    for (int i = item.GirisTarihi.Day; i <= item.CikisTarihi.Day; i++)
                    {
                        int iptalMod = i % 6;
                        if (i == 0)
                        {
                            i = 6;
                        }
                        iptalEdilecekRezId = _uow.GetRepo<Rezervasyon>()
                            .Where(x => x.Oda.OdaAd == sagTus && x.Mod.Ad == iptalMod.ToString())
                            .FirstOrDefault()
                            .Id;
                        _uow.GetRepo<Rezervasyon>().GetById(iptalEdilecekRezId).DoluMu = false;
                    }
                }
                if (iptalEdilecekRezId != 0)
                {
                    int iptalEdilecekSatisId = _uow.GetRepo<Satis>()
                         .Where(x => x.RezervasyonId == iptalEdilecekRezId)
                         .FirstOrDefault()
                         .Id;
                    _uow.GetRepo<Satis>().GetById(iptalEdilecekSatisId).SatildiMi = false;
                    if (_uow.Commit() > 0)
                    {
                        MessageBox.Show("Rezervasyon başarıyla iptal edilmiştir.");
                    }
                }
                DoluOdaKontrol();
                RezerveOdaKontrol();
                BosOdaSayisiHesapla();
            }
            else
            {
                MessageBox.Show("Seçilen oda dolu değil!", "Hata");
            }
        }
        #endregion


        private void FormLoadItems()
        {
            
            OdaTurDoldur();
            OdaOpsiyonDoldur();
            KatDoldur();
            CinsiyetDoldur();
            MedeniHalDoldur();
            OdaBosalt();
            DoluOdaKontrol();
            RezerveOdaKontrol();
            BosalacakOdaKontrol();
            BosOdaSayisiHesapla();
            BosalacakRezerveKontrol();
            OturumAcanPersonel();

            
        }

        

        private void btnGetir_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[0].Enabled = true;
            odalar = new List<string>();
            foreach (Button item in this.Controls.OfType<Button>())
            {
                if (item.BackColor == Color.Green)
                {
                    item.BackColor = Color.Silver;
                }
            }

            turId = (int)cbOdaTur.SelectedValue;
            ozellikId = (int)cbOpsiyon.SelectedValue;
            katId = (int)cbKat.SelectedValue;

            fiyatId = _uow.GetRepo<Fiyat>()
                .Where(x => x.OdaTurId == turId && x.OzellikId == ozellikId)
                .FirstOrDefault()
                .Id;
            odalar = _uow.GetRepo<Oda>()
                .Where(x => x.FiyatId == fiyatId)
                .Select(x => x.OdaAd);

            foreach (string item in odalar)
            {
                Button btn = new Button();
                btn = (Button)this.Controls[item];
                if (btn.BackColor != Color.Red && btn.BackColor != Color.Orange)
                {
                    btn.BackColor = Color.Green;
                }

            }

            FiyatHesapla();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (OdaBilgileriKontrol() && MusteriBilgiAlaniKontrol())
            {
                if (OdaDatabaseKayit())
                {
                    if (SatisDatabaseOlustur())
                    {
                        DoluOdaKontrol();
                        BosOdaSayisiHesapla();
                    }
                    else
                    {
                        OdaBosalt();
                        Temizle();
                    }
                }
            }
            else if (!OdaBilgileriKontrol())
            {
                MessageBox.Show("Bir oda seçiniz");
            }

        }



        private void btnRezervasyon_Click(object sender, EventArgs e)
        {

            if (OdaBilgileriKontrol() && MusteriBilgiAlaniKontrol())
            {
                if (RezerveKayit())
                {
                    if (SatisDatabaseOlustur())
                    {
                        RezerveOdaKontrol();
                        BosOdaSayisiHesapla();
                    }
                    else
                    {
                        OdaBosalt();
                    }
                }
            }
            else if (!OdaBilgileriKontrol())
            {
                MessageBox.Show("Bir oda seçiniz");
            }
        }



        #region OKButtonControls
        private bool MusteriBilgiAlaniKontrol()
        {
            Musteri m = new Musteri()
            {
                Ad = txtAd.Text.Substring(0, 1).ToUpper() + txtAd.Text.Substring(1).ToLower(),
                Soyad = txtSoyad.Text.Substring(0, 1).ToUpper() + txtSoyad.Text.Substring(1).ToLower(),
                TCNo = txtKimlikNo.Text,
                Adres = txtAdres.Text,
                Telefon = txtTelefon.Text,
                CinsiyetId = (int)cbCinsiyet.SelectedValue,
                MedeniDurumId = (int)cbMedeniHal.SelectedValue,
                DogumTarihi = dtpDogum.Value,
            };

            var result = _musteriService.MusteriValidate(m);
            if (result.IsValid)
            {
                //MessageBox.Show("Müşteri kaydı başarıyla gerçekleşmiştir");
                return true;
            }
            else
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
                return false;
            }
        }
        private bool OdaBilgileriKontrol()
        {
            if (string.IsNullOrEmpty(txtOdaNo.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool OdaDatabaseKayit()
        {
            string odaAd = "btn" + txtOdaNo.Text;
            odaId = _uow.GetRepo<Oda>()
                .Where(x => x.OdaAd == odaAd)
                .FirstOrDefault()
                .Id;
            for (int i = dtpGiris.Value.Day; i <= dtpCikis.Value.Day; i++)
            {
                int tarihModAyar = i % 6;
                if (tarihModAyar == 0)
                {
                    tarihModAyar = 6;
                }
                rezervasyonId = _uow.GetRepo<Rezervasyon>()
                    .Where(x => x.Mod.Id == tarihModAyar && x.OdaId == odaId)
                    .FirstOrDefault()
                    .Id;
                var rezSorgu = _uow.GetRepo<Rezervasyon>().GetById(rezervasyonId);
                rezSorgu.DoluMu = true;
                rezSorgu.GirisTarihi = dtpGiris.Value;
                rezSorgu.CikisTarihi = dtpCikis.Value;
            }
            if (_uow.Commit() > 0)
            {
                //MessageBox.Show("Oda kaydı başarıyla gerçekleşmiştir.");
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool SatisDatabaseOlustur()
        {
            musteriId = _musteriRepo.SonMusteriIdBul();
            Satis s = new Satis()
            {
                SatisTarihi = DateTime.Now,
                PersonelId = personelId,
                MusteriId = musteriId,
                SatildiMi = true,
                RezervasyonId = rezervasyonId,
                Fiyat = Convert.ToDecimal(txtFiyat.Text.Substring(0, 3))
            };
            _uow.GetRepo<Satis>().Add(s);
            if (_uow.Commit() > 0)
            {
                MessageBox.Show("Satış kaydı başarıyla gerçekleşmiştir.");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region DoluOdaKontrol
        private void DoluOdaKontrol()
        {
            IEnumerable<string> doluOdalar = new List<string>();
            doluOdalar = _uow.GetRepo<Rezervasyon>()
                .Where(x => x.Mod.Id == tarihMod && x.DoluMu == true)
                .Select(x => x.Oda.OdaAd);

            foreach (string item in doluOdalar)
            {
                Button dolubtn = new Button();
                dolubtn = (Button)Controls[item];
                dolubtn.BackColor = Color.Red;
                if (dolubtn.BackColor == Color.Red)
                {
                    dolubtn.Text = "DOLU";
                }
            }
        }
        #endregion
        #region BosalacakOdaKontrol
        private void BosalacakOdaKontrol()
        {
            IEnumerable<int> bosalacakOda = _uow.GetRepo<Rezervasyon>()
                .Where(x => x.CikisTarihi < DateTime.Today)
                .Select(x => x.Id);

            foreach (int item in bosalacakOda)
            {
                _uow.GetRepo<Rezervasyon>().GetById(item).DoluMu = false;
            }
            _uow.Commit();
        }



        #endregion
        #region OdaBosalt
        private void OdaBosalt()
        {
            foreach (Button item in this.Controls.OfType<Button>())
            {
                item.BackColor = Color.Silver;
                if (item.BackColor == Color.Silver && item.Text == "REZERVE")
                {
                    item.Text = "BOŞ";
                }
                else if (item.BackColor == Color.Silver && item.Text == "DOLU")
                {
                    item.Text = "BOŞ";
                }
            }
        }
        #endregion
        #region BosOdaSayisiHesapla
        private void BosOdaSayisiHesapla()
        {
            int count = 0;
            foreach (Button button in this.Controls.OfType<Button>())
            {
                if (button.BackColor == Color.Red || button.BackColor == Color.Orange)
                {
                    count++;
                }
            }
            int toplamOdaSayisi = 32 - count;
            lblOturum.Text = FormLogin.kullanici;
            lblMusteri.Text = count.ToString();
            lblBosOda.Text = toplamOdaSayisi.ToString();
        }
        #endregion
        #region FiyatHesapla
        private void FiyatHesapla()
        {

            int fiyat = _uow.GetRepo<Fiyat>()
            .Where(x => x.Id == fiyatId)
            .FirstOrDefault().FiyatTutar;
            txtFiyat.Text = (kacGun * fiyat).ToString() + " TL";

        }
        #endregion
        #region RezerveOdaKontrol
        private void RezerveOdaKontrol()
        {
            IEnumerable<string> rezerveliOdalar = new List<string>();
            rezerveliOdalar = _uow.GetRepo<Rezervasyon>()
                .Where(x => x.Mod.Id == tarihMod && x.RezerveMi == true)
                .Select(x => x.Oda.OdaAd);

            foreach (string item in rezerveliOdalar)
            {
                Button dolubtn = new Button();
                dolubtn = (Button)Controls[item];
                dolubtn.BackColor = Color.Orange;
                if (dolubtn.BackColor == Color.Orange)
                {
                    dolubtn.Text = "REZERVE";
                }
            }
        }
        #endregion
        #region BosalacakRezerveKontrol
        private void BosalacakRezerveKontrol()
        {
            IEnumerable<int> bosalacakRezerve = _uow.GetRepo<Rezervasyon>()
                .Where(x => x.CikisTarihi < DateTime.Today)
                .Select(x => x.Id);

            foreach (int item in bosalacakRezerve)
            {
                _uow.GetRepo<Rezervasyon>().GetById(item).RezerveMi = false;
            }
            _uow.Commit();
        }
        #endregion
        #region RezerveKayıt
        private bool RezerveKayit()
        {
            string odaAd = "btn" + txtOdaNo.Text;
            odaId = _uow.GetRepo<Oda>()
                .Where(x => x.OdaAd == odaAd)
                .FirstOrDefault()
                .Id;
            for (int i = dtpGiris.Value.Day; i <= dtpCikis.Value.Day; i++)
            {
                int rezerveMod = i % 6;
                if (i == 0)
                {
                    i = 6;
                }
                modId = _uow.GetRepo<Mod>()
                .Where(x => x.Ad == rezerveMod.ToString())
                .FirstOrDefault()
                .Id;
                rezervasyonId = _uow.GetRepo<Rezervasyon>()
                    .Where(x => x.ModId == modId && x.OdaId == odaId)
                    .FirstOrDefault()
                    .Id;

                var sorgu = _uow.GetRepo<Rezervasyon>().GetById(rezervasyonId);
                sorgu.RezerveMi = true;
                sorgu.GirisTarihi = dtpGiris.Value;
                sorgu.CikisTarihi = dtpCikis.Value;
            }
            if (_uow.Commit() > 0)
            {
                MessageBox.Show(txtOdaNo.Text + " numaralı oda" + dtpGiris.Value.Day + "-" + dtpCikis.Value.ToShortDateString() + " tarihleri arasında rezerve edilmiştir.");
                RezerveOdaKontrol();
                return true;
            }
            return false;
        }
        #endregion
        #region InputClear
        private void Temizle()
        {
            txtOdaBilgisi.Clear();
            txtOdaNo.Clear();
            txtOdaOpsiyon.Clear();
            txtKat.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtKimlikNo.Clear();
            txtPlaka.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtCheckIn.Clear();
            txtDogum.Clear();
        }
        #endregion
        #region OturumAçanPersonel
        private void OturumAcanPersonel()
        {
            personelId =
            _uow.GetRepo<Personel>()
            .Where(x => x.Login.UserName == FormLogin.kullanici)
            .FirstOrDefault()
            .Id;
        }
        #endregion
        #region Çıkış
        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkış yapmak istiyor musunuz ? ", "Uyarı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion


        #region Kimlik Doğrulama Alanı
        private void pbKimlikDogrula_Click(object sender, EventArgs e)
        {
            FormKimlikSorgulama frmKimlik = new FormKimlikSorgulama();
            frmKimlik.ShowDialog();
            if (FormKimlikSorgulama.ks != null)
            {
                txtAd.Text = FormKimlikSorgulama.ks.Ad;
                txtSoyad.Text = FormKimlikSorgulama.ks.Soyad;
                txtKimlikNo.Text = FormKimlikSorgulama.ks.KimlikNo;
                dtpDogum.Focus();
            }
            else
            {
                txtAd.Focus();
            }
        }
        #endregion

    }
}
