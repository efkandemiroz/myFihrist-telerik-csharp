using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Xml;
using System.IO;
using System.Threading;

namespace myFihrist.Formlar
{
    public partial class yeniKayit : Telerik.WinControls.UI.RadForm
    {
        public yeniKayit()
        {
            InitializeComponent();
           
        }
        public string yol;
        
        private void btnKapat_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void txtSirket_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Siniflar.VeriKaydetme veriler = new Siniflar.VeriKaydetme();

                veriler.Ad = txtIsim.Text;
                veriler.Soyad = txtSoyIsim.Text;
                veriler.DogumTarihi = dateTarih.Value;
                veriler.Notlar = txtNotlar.Text;
                veriler.CepTel = txtCepTel.Text;
                veriler.EvTel = txtEvTel.Text;
                veriler.IsTel = txtIsTel.Text;
                veriler.Faks = txtFaks.Text;
                veriler.Sirket = txtSirket.Text;
                veriler.IsUnvani = txtIsUnvan.Text;
                veriler.EvAdres = txtEvAdres.Text;
                veriler.IsAdres = txtIsAdres.Text;
                veriler.EMail = txtEPosta.Text;
                veriler.WebAdres = txtWebAdres.Text;
                veriler.Facebook = txtFacebook.Text;
                veriler.Twitter = txtTwitter.Text;
                veriler.KanGrubu = cbKanGrubu.SelectedItem.Text;


                #region XML İşlemleri
                if (File.Exists(yol))
                {


                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(yol);  // Daha önceden oluşturduğumuz xml çağırıldı


                        XmlElement Kayit = doc.CreateElement("Kayit");//element ekledik
                        Kayit.SetAttribute("id", Guid.NewGuid().ToString()); // her kayıt  elementine bir attribute atadık

                        XmlElement ad = doc.CreateElement("Ad");//Ad elementi içine bir kayıt ekledik
                        ad.InnerText = veriler.Ad;//kayıt için değer atadık
                        Kayit.AppendChild(ad);//kayıt için parent atadık (Kayit parenti)

                        XmlElement soyAd = doc.CreateElement("Soyad");
                        soyAd.InnerText = veriler.Soyad;
                        Kayit.AppendChild(soyAd);

                        XmlElement dogumTarihi = doc.CreateElement("DogumTarihi");
                        dogumTarihi.InnerText = veriler.DogumTarihi.ToShortDateString();
                        Kayit.AppendChild(dogumTarihi);

                        XmlElement kanGrubu = doc.CreateElement("KanGrubu");
                        kanGrubu.InnerText = veriler.KanGrubu;
                        Kayit.AppendChild(kanGrubu);

                        XmlElement notlar = doc.CreateElement("Notlar");
                        notlar.InnerText = veriler.Notlar;
                        Kayit.AppendChild(notlar);

                        XmlElement cepTel = doc.CreateElement("CepTel");
                        cepTel.InnerText = veriler.CepTel;
                        Kayit.AppendChild(cepTel);

                        XmlElement evTel = doc.CreateElement("EvTel");
                        evTel.InnerText = veriler.EvTel;
                        Kayit.AppendChild(evTel);

                        XmlElement isTel = doc.CreateElement("IsTel");
                        isTel.InnerText = veriler.IsTel;
                        Kayit.AppendChild(isTel);

                        XmlElement faksNo = doc.CreateElement("Faks");
                        faksNo.InnerText = veriler.Faks;
                        Kayit.AppendChild(faksNo);

                        XmlElement sirket = doc.CreateElement("Sirket");
                        sirket.InnerText = veriler.Sirket;
                        Kayit.AppendChild(sirket);

                        XmlElement isUnvani = doc.CreateElement("IsUnvani");
                        isUnvani.InnerText = veriler.IsUnvani;
                        Kayit.AppendChild(isUnvani);

                        XmlElement evAdresi = doc.CreateElement("EvAdresi");
                        evAdresi.InnerText = veriler.EvAdres;
                        Kayit.AppendChild(evAdresi);

                        XmlElement isAdresi = doc.CreateElement("IsAdresi");
                        isAdresi.InnerText = veriler.IsAdres;
                        Kayit.AppendChild(isAdresi);

                        XmlElement ePosta = doc.CreateElement("EPosta");
                        ePosta.InnerText = veriler.EMail;
                        Kayit.AppendChild(ePosta);

                        XmlElement webAdresi = doc.CreateElement("WebAdresi");
                        webAdresi.InnerText = veriler.WebAdres;
                        Kayit.AppendChild(webAdresi);

                        XmlElement facebook = doc.CreateElement("Facebook");
                        facebook.InnerText = veriler.Facebook;
                        Kayit.AppendChild(facebook);

                        XmlElement twitter = doc.CreateElement("Twitter");
                        twitter.InnerText = veriler.Twitter;
                        Kayit.AppendChild(twitter);





                        doc.DocumentElement.AppendChild(Kayit);//xml dosyamıza element ve kayıtları ekledik

                        XmlTextWriter xmleEkle = new XmlTextWriter(yol, null);//xml dosyamıza fiziksel olarak kayıtları yazıyoruz
                        xmleEkle.Formatting = Formatting.Indented;
                        doc.WriteContentTo(xmleEkle);//kayıtlar eklendi
                        xmleEkle.Close();//dosya kapatıldı


                        RadMessageBox.SetThemeName(this.ThemeName.ToString());
                        RadMessageBox.Show("Kayıt Başarı İle Eklendi");
                    }
                    catch (Exception ex)
                    {
                        RadMessageBox.Show(ex.ToString());
                        throw;
                    }
                }

                #endregion
            }
            catch (Exception)
            {

             
            }
        }

        private void yeniKayit_Load(object sender, EventArgs e)
        {
            yol = ProgramAyar.Default.veriYolu;
            dateTarih.Value = DateTime.Now.Date;
            
        }

       
    }
}
