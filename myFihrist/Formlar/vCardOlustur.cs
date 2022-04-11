using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using System.Drawing.Imaging;

namespace myFihrist.Formlar
{
    public partial class vCardOlustur : Telerik.WinControls.UI.RadForm
    {
        public vCardOlustur()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        string adsoyadDosya;
        private Image QRCodeOlustur(string veriAl, int QrCodeDuzey)
        {
            try
            {
                string veri = veriAl;
                MessagingToolkit.QRCode.Codec.QRCodeEncoder Kodlayici = new QRCodeEncoder();
                Kodlayici.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                Kodlayici.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                Kodlayici.QRCodeVersion = QrCodeDuzey;
                System.Drawing.Bitmap Bitmap = Kodlayici.Encode(veri);
                return Bitmap;
            }
            catch (Exception)
            {
               throw;
            }
        }

        private void vCardOlustur_Load(object sender, EventArgs e)
        {
            try
            {
                string basla = "BEGIN:VCARD" + "\n";

                string versiyon = "VERSION:2.1" + "\n";

                string ad = Siniflar.GelenVeriler.Ad + " ";

                string soy = Siniflar.GelenVeriler.Soyad;

                string adi = "N;LANGUAGE=tr-TR;CHARSET=UTF-8:" + ad + ";" + soy + " \n";

                string tamad = ad + " " + soy;

                adsoyadDosya = tamad;

                string ad_soy = "FN;LANGUAGE=tr-TR;CHARSET=UTF-8:" + tamad + "\n";

                string is_yeri = "ORG:" + Siniflar.GelenVeriler.Sirket + "\n";

                string is_unvani = "TITLE:" + Siniflar.GelenVeriler.IsUnvani + "\n";

                string is_tel = "TEL;TYPE=work,voice;VALUE=uri:" + Siniflar.GelenVeriler.IsTel + "\n";

                string cep_tel = "TEL;TYPE=cell,voice;VALUE=uri:" + Siniflar.GelenVeriler.CepTel + "\n";

                string ev_tel = "TEL;TYPE=home,voice;VALUE=uri:" + Siniflar.GelenVeriler.EvTel + "\n";

                string mail = "EMAIL;PREF;INTERNET:" + Siniflar.GelenVeriler.EMail + "\n";



                string bitir = "END:VCARD";

                string kodMetin;

                string toplam = basla + versiyon + adi + ad_soy + is_yeri + is_unvani + is_tel +cep_tel + ev_tel + mail + bitir;

                Siniflar.trKarakter karakterCevir = new Siniflar.trKarakter();
                kodMetin = karakterCevir.karakterCevir(toplam);

                pictureBox2.Image = QRCodeOlustur((kodMetin), 13);
                btnKaydet.Enabled = true;
            }
            catch (Exception)
            {
                RadMessageBox.Show("Karekod Oluştururken Hata Oluştu ", "HATA");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                saveFileDialog1.FileName = adsoyadDosya;
                saveFileDialog1.Filter = "JPEG Dosyası (*.jpeg) |*.jpg|PNG Dosyası (*.png)|*.png";
                saveFileDialog1.Title = " Karekod Dosyasını Kaydedin";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3, 3))
                    {
                        case "jpg":
                            pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                            break;
                        case "png":
                            pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception )
            {

                RadMessageBox.Show("Karekod Kaydedilemedi", "Hata");
            }
        }
    }
}
