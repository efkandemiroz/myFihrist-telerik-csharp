using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace myFihrist.Formlar
{
    public partial class kayitGuncelleForm : Telerik.WinControls.UI.RadForm
    {
        public kayitGuncelleForm()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kayitGuncelleForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtIsim.Text = Siniflar.GelenVeriler.Ad;
                txtSoyIsim.Text = Siniflar.GelenVeriler.Soyad;
                dateTarih.Value = Siniflar.GelenVeriler.DogumTarihi;
                txtNotlar.Text = Siniflar.GelenVeriler.Notlar;
                cbKanGrubu.Text = Siniflar.GelenVeriler.KanGrubu;
                txtNotlar.Text = Siniflar.GelenVeriler.Notlar;
                txtCepTel.Text = Siniflar.GelenVeriler.CepTel;
                txtEvAdres.Text = Siniflar.GelenVeriler.EvAdres;
                txtEvTel.Text = Siniflar.GelenVeriler.EvTel;
                txtIsTel.Text = Siniflar.GelenVeriler.IsTel;
                txtFaks.Text = Siniflar.GelenVeriler.Faks;
                txtSirket.Text = Siniflar.GelenVeriler.Sirket;
                txtIsUnvan.Text = Siniflar.GelenVeriler.IsUnvani;
                txtIsAdres.Text = Siniflar.GelenVeriler.IsAdres;
                txtEPosta.Text = Siniflar.GelenVeriler.EMail;
                txtWebAdres.Text = Siniflar.GelenVeriler.WebAdres;
                txtFacebook.Text = Siniflar.GelenVeriler.Facebook;
                txtTwitter.Text = Siniflar.GelenVeriler.Twitter;
            }
            catch (Exception)
            {

            }
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                XDocument xDoc = XDocument.Load(ProgramAyar.Default.veriYolu);  // XML Dosyasını yükle


                var bilgiler = from bilgi in xDoc.Element("Kayitlar").Elements("Kayit") 
                               where bilgi.Attribute("id").Value == Siniflar.GelenVeriler.KullaniciId 
                               select bilgi;

                if (bilgiler != null)
                {
                    foreach (var bilgi in bilgiler) // Döngü ile bilgiler günceli ile değiştiriliyor.
                    {

                        bilgi.Element("Ad").SetValue(txtIsim.Text);
                        bilgi.Element("Soyad").SetValue(txtSoyIsim.Text);
                        bilgi.Element("DogumTarihi").SetValue(dateTarih.Value.ToString());
                        bilgi.Element("KanGrubu").SetValue(cbKanGrubu.Text);
                        bilgi.Element("Notlar").SetValue(txtNotlar.Text);
                        bilgi.Element("CepTel").SetValue(txtCepTel.Text);
                        bilgi.Element("EvTel").SetValue(txtEvTel.Text);
                        bilgi.Element("IsTel").SetValue(txtIsTel.Text);
                        bilgi.Element("Faks").SetValue(txtFaks.Text);
                        bilgi.Element("Sirket").SetValue(txtSirket.Text);
                        bilgi.Element("IsUnvani").SetValue(txtIsUnvan.Text);
                        bilgi.Element("EvAdresi").SetValue(txtEvAdres.Text);
                        bilgi.Element("IsAdresi").SetValue(txtIsAdres.Text);
                        bilgi.Element("EPosta").SetValue(txtEPosta.Text);
                        bilgi.Element("WebAdresi").SetValue(txtWebAdres.Text);
                        bilgi.Element("Facebook").SetValue(txtFaks.Text);
                        bilgi.Element("Twitter").SetValue(txtTwitter.Text);

                    }
                    xDoc.Save(ProgramAyar.Default.veriYolu);
                    RadMessageBox.SetThemeName(this.ThemeName.ToString());
                    RadMessageBox.Show("Bilgiler Başarı İle Güncellendi");

                    btnvCard.Enabled = true;
                }
                else
                {
                   
                    RadMessageBox.SetThemeName(this.ThemeName.ToString());
                    RadMessageBox.Show("Bilgiler Güncellenemedi");
                }
                
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("Bilgiler Güncellenemedi \n \t" + ex.Message.ToString() );
            }
        }

        private void btnvCard_Click(object sender, EventArgs e)
        {
            Formlar.vCardOlustur vcard = new vCardOlustur();
            vcard.ShowDialog();
        }
    }
}
