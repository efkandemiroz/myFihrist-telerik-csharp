using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading;
using System.Xml;

namespace myFihrist
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        int kontrol=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (kontrol == 0)
                {
                    progress.Value1 += 2;
                    if (progress.Value1 == 100)
                    {
                        kontrol = 1;
                        progress.Value1 = 0;
                        progress.Value2 = 100;
                    }
                }
                else
                {
                    progress.Value2 -= 2;
                    if (progress.Value2 == 0)
                    {
                        kontrol = 0;

                    }
                }
            }
            catch (Exception)
            {

            }
             
        }
        
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {

            Formlar.yeniKayit yeniKayit = new Formlar.yeniKayit();
            yeniKayit.Show();
            this.Location = new Point(10, 10);
          
            
        }

        private void btnTumKayitlar_Click(object sender, EventArgs e)
        {
            Formlar.TumKayitlar tumkayitlar = new Formlar.TumKayitlar();
            tumkayitlar.Show();
            this.Location = new Point(10, 10);
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Formlar.KayitGuncelle kayitGuncelle = new Formlar.KayitGuncelle();
            kayitGuncelle.Show();
            this.Location = new Point(10, 10);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Formlar.KayitSil kayitSil = new Formlar.KayitSil();
            kayitSil.Show();
            this.Location = new Point(10, 10);
        }

        private void btnVcard_Click(object sender, EventArgs e)
        {
            Formlar.vCard vCard = new Formlar.vCard();
            vCard.Show();
            this.Location = new Point(10, 10);
           
        }

      

        private void btnAyar_Click(object sender, EventArgs e)
        {
            Formlar.ayarlar ayarlar = new Formlar.ayarlar();
            ayarlar.ShowDialog();
            this.Location = new Point(10, 10);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (ProgramAyar.Default.ilkKurulum == true)
                {

                    saveFileDialog1.FileName = "Veri_Kayitlari";
                    saveFileDialog1.Filter = "XML Dosyası (*.XML)|*.XML";
                    saveFileDialog1.Title = "Veri Dosyasının Kayıt Edilmesini İstediğiniz Dizini Seçin";
                    saveFileDialog1.InitialDirectory = "D:\\";
                    saveFileDialog1.DefaultExt = "XML";
                    saveFileDialog1.ShowDialog();

                    ProgramAyar.Default.veriYolu = saveFileDialog1.FileName.ToString(); // XML verisinin kaydedileceği yer
                    ProgramAyar.Default.ilkKurulum = false;
                    ProgramAyar.Default.Save();

                    // XML OLUŞTURMA

                    XmlTextWriter xmlOlustur = new XmlTextWriter(ProgramAyar.Default.veriYolu, Encoding.UTF8);
                    xmlOlustur.WriteStartDocument(); // XML Dökümanı başlangıç etiketi
                    xmlOlustur.WriteStartElement("Kayitlar"); // Root Elementi Oluştur
                    xmlOlustur.WriteEndElement();
                    xmlOlustur.WriteEndDocument(); // döküman sonu
                    xmlOlustur.Close();

                }
            }
            catch (Exception)
            {

            }
            
        }

        

      
    }
}
