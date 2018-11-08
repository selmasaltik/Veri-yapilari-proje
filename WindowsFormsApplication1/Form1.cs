using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        İkiliAramaAgaci aramaAgaci = new İkiliAramaAgaci();

        private void btnKayit_Click(object sender, EventArgs e)
        {
            
            KisiBilgileri kisi = new KisiBilgileri();

            kisi.Adi = txtAdSoyad.Text;
            kisi.Adres = txtAdres.Text;
            kisi.Telefon = Convert.ToInt64(txtTelefon.Text);
            kisi.e_posta = txtPosta.Text;
            kisi.Uyruk = txtUyruk.Text;
            kisi.Dogum_Yeri = txtDogumYeri.Text;
            kisi.Dogum_Tarihi = Convert.ToDateTime(dtpDogumTarihi.Text);
            kisi.MedeniDurum = txtMedeniDurum.Text;
            kisi.YabanciDil = txtYabanciDil.Text;
            kisi.İlgiAlanlari = txtIlgiAlani.Text;
            kisi.Referans_Kisileri = txtReferanslar.Text;

            aramaAgaci.Ekle(kisi);
            MessageBox.Show("Kayıt Başarılı ...");

            txtAdSoyad.Text = "";
            txtAdres.Text = "";
            txtTelefon.Text = "";
            txtPosta.Text = "";
            txtUyruk.Text = "";
            txtDogumYeri.Text = "";
            txtMedeniDurum.Text = "";
            txtYabanciDil.Text = "";
            txtIlgiAlani.Text = "";
            txtReferanslar.Text = "";
        }

        private void btnKayitEskiIs_Click(object sender, EventArgs e)
        {
            EskiIsBilgileri eski_is = new EskiIsBilgileri();
            LListEskiIs ll = new LListEskiIs();

            eski_is.Adi = txtAd.Text;
            eski_is.Adres = txtIsAdres.Text;
            eski_is.Pozisyon = txtPozisyon.Text;

            ll.InsertFirst(eski_is);

            MessageBox.Show("Kayıt Başarılı ...");

            txtAd.Text = "";
            txtIsAdres.Text = "";
            txtPozisyon.Text = "";
        }

        private void btnKayitOkul_Click(object sender, EventArgs e)
        {
            LListOkul ll2 = new LListOkul();
            MezunOlunan_Okullar okullar = new MezunOlunan_Okullar();

            okullar.Okul_Adi = txtOkulAdi.Text;
            okullar.Bolum = txtBolum.Text;
            okullar.Baslangic_Tarihi =Convert.ToInt32(txtBaslangic.Text);
            okullar.Bitis_Tarihi = Convert.ToInt32(txtBitis.Text);
            okullar.Not_Ortalamasi =Convert.ToDouble(txtNotOrtalamasi.Text);

            ll2.InsertFirst(okullar);
            MessageBox.Show("Kayıt Başarılı ...");

        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            txtOkulAdi.Text = "";
            txtBolum.Text = "";
            txtBaslangic.Text = "";
            txtBitis.Text = "";
            txtNotOrtalamasi.Text = "";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }


        private void btnBilgiSil_Click(object sender, EventArgs e)
        {

            KisiBilgileri kisi = new KisiBilgileri();


            if (aramaAgaci == null)
            {
                MessageBox.Show("Öncelikle Ağacı Oluşturunuz ...");
                return;
            }
            else
            {
                aramaAgaci.Sil(txtBilgileriSilinecekKisi.Text);
                MessageBox.Show(txtBilgileriSilinecekKisi.Text + " adlı kişi başarıyla silindi ...");
            }
        }

        private void btnKisiBul_Click(object sender, EventArgs e)
        {
            İkiliAramaAgacDugumu kk = new İkiliAramaAgacDugumu();
            kk = aramaAgaci.Ara(txtArananKisi.Text);

            if (kk == null)
                MessageBox.Show("Aradığınız kişi bulunamadı ...");
            else
            {
                //Bulduğumuz kişinin bilgilerini ilgili textbox lara yazdırdık.
                txtGuncelAdSoyad.Text = ((KisiBilgileri)kk.veri).Adi;
                txtGuncelAdres.Text = ((KisiBilgileri)kk.veri).Adres;
                txtGuncelDogumYeri.Text = ((KisiBilgileri)kk.veri).Dogum_Yeri;
                txtGuncelIlgiAlani.Text = ((KisiBilgileri)kk.veri).İlgiAlanlari;
                txtGuncelMedeniDurum.Text = ((KisiBilgileri)kk.veri).MedeniDurum;
                txtGuncelPosta.Text = ((KisiBilgileri)kk.veri).e_posta;
                txtGuncelReferans.Text = ((KisiBilgileri)kk.veri).Referans_Kisileri;
                txtGuncelTelefon.Text = (((KisiBilgileri)kk.veri).Telefon).ToString();
                txtGuncelUyruk.Text = ((KisiBilgileri)kk.veri).Uyruk;
                txtGuncelYabanciDil.Text = ((KisiBilgileri)kk.veri).YabanciDil;
                dtpDogumTarihi.Value = ((KisiBilgileri)kk.veri).Dogum_Tarihi;
            }
               
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            İkiliAramaAgacDugumu kk = new İkiliAramaAgacDugumu();
            kk = aramaAgaci.Ara(txtArananKisi.Text);
            string temp;

            if (((KisiBilgileri)kk.veri).Adi != txtGuncelAdSoyad.Text)
            {
                temp=((KisiBilgileri)kk.veri).Adi;
                ((KisiBilgileri)kk.veri).Adi=txtGuncelAdSoyad.Text;
            }
            else
                txtGuncelAdSoyad.Text = ((KisiBilgileri)kk.veri).Adi;

            if (((KisiBilgileri)kk.veri).Adres != txtGuncelAdres.Text)
            {
                temp = ((KisiBilgileri)kk.veri).Adres;
                ((KisiBilgileri)kk.veri).Adres = txtGuncelAdres.Text;
            }
            else
                txtGuncelAdres.Text = ((KisiBilgileri)kk.veri).Adres;

            if (((KisiBilgileri)kk.veri).Dogum_Yeri != txtGuncelDogumYeri.Text)
            {
                temp = ((KisiBilgileri)kk.veri).Dogum_Yeri;
                ((KisiBilgileri)kk.veri).Dogum_Yeri = txtGuncelDogumYeri.Text;
            }
            else
                txtGuncelDogumYeri.Text = ((KisiBilgileri)kk.veri).Dogum_Yeri;

            if (((KisiBilgileri)kk.veri).e_posta != txtGuncelPosta.Text)
            {
                temp = ((KisiBilgileri)kk.veri).e_posta;
                ((KisiBilgileri)kk.veri).e_posta = txtGuncelPosta.Text;
            }
            else
                txtGuncelPosta.Text = ((KisiBilgileri)kk.veri).e_posta;

            if (((KisiBilgileri)kk.veri).İlgiAlanlari != txtGuncelIlgiAlani.Text)
            {
                temp = ((KisiBilgileri)kk.veri).İlgiAlanlari;
                ((KisiBilgileri)kk.veri).İlgiAlanlari = txtGuncelIlgiAlani.Text;
            }
            else
                txtGuncelIlgiAlani.Text = ((KisiBilgileri)kk.veri).İlgiAlanlari;

            if (((KisiBilgileri)kk.veri).MedeniDurum != txtGuncelMedeniDurum.Text)
            {
                temp = ((KisiBilgileri)kk.veri).MedeniDurum;
                ((KisiBilgileri)kk.veri).MedeniDurum= txtGuncelMedeniDurum.Text;
            }
            else
                txtGuncelMedeniDurum.Text = ((KisiBilgileri)kk.veri).MedeniDurum;

            if (((KisiBilgileri)kk.veri).Referans_Kisileri != txtGuncelReferans.Text)
            {
                temp = ((KisiBilgileri)kk.veri).Referans_Kisileri;
                ((KisiBilgileri)kk.veri).Referans_Kisileri = txtGuncelReferans.Text;
            }
            else
                txtGuncelReferans.Text = ((KisiBilgileri)kk.veri).Referans_Kisileri;

            if (((KisiBilgileri)kk.veri).Telefon.ToString() != txtGuncelTelefon.Text)
            {
                temp = ((KisiBilgileri)kk.veri).Telefon.ToString();
                ((KisiBilgileri)kk.veri).Telefon = Convert.ToInt64(txtGuncelTelefon.Text);
            }
            else
                txtGuncelTelefon.Text = ((KisiBilgileri)kk.veri).Telefon.ToString();

            if (((KisiBilgileri)kk.veri).Uyruk != txtGuncelUyruk.Text)
            {
                temp = ((KisiBilgileri)kk.veri).Uyruk;
                ((KisiBilgileri)kk.veri).Uyruk= txtGuncelUyruk.Text;
            }
            else
                txtGuncelUyruk.Text = ((KisiBilgileri)kk.veri).Uyruk;

            if (((KisiBilgileri)kk.veri).YabanciDil != txtGuncelYabanciDil.Text)
            {
                temp = ((KisiBilgileri)kk.veri).YabanciDil;
                ((KisiBilgileri)kk.veri).YabanciDil = txtGuncelYabanciDil.Text;
            }
            else
                txtGuncelYabanciDil.Text = ((KisiBilgileri)kk.veri).YabanciDil;

            if (((KisiBilgileri)kk.veri).Dogum_Tarihi != dtpGuncelTarih.Value)
            {
                temp = ((KisiBilgileri)kk.veri).Dogum_Tarihi.ToShortDateString();
                ((KisiBilgileri)kk.veri).Dogum_Tarihi = dtpGuncelTarih.Value; ;
            }
            else
                dtpGuncelTarih.Value = ((KisiBilgileri)kk.veri).Dogum_Tarihi;

            MessageBox.Show("Güncelleme Başarılı ...");

            txtGuncelAdres.Text = "";
            txtGuncelAdSoyad.Text = "";
            txtGuncelDogumYeri.Text = "";
            txtGuncelIlgiAlani.Text = "";
            txtGuncelMedeniDurum.Text = "";
            txtGuncelPosta.Text = "";
            txtGuncelReferans.Text = "";
            txtGuncelTelefon.Text = "";
            txtGuncelUyruk.Text = "";
            txtGuncelYabanciDil.Text = "";
        }
    }
}
