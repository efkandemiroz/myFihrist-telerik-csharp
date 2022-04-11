using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Xml;
using System.Linq;
using System.Xml.Linq;


namespace myFihrist.Formlar
{
    public partial class TumKayitlar : Telerik.WinControls.UI.RadForm
    {
        public TumKayitlar()
        {
            InitializeComponent();
        }
        // Aramada kullanılacak global değişkenler

        public XmlDocument doc;
        public XmlElement elm;
        public XmlNodeList liste, altListe;
        public int sayi;


        private void btnAra_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.ClearSelection();
                int kayitBulundu=0;
                int kayitSayi = dataGridView1.RowCount;
                string isim = txtIsim.Text;
                string soyIsim = txtSoyIsim.Text;
                int[] bulunan = new int[kayitSayi];
               
         
                for (int i = 0; i <= kayitSayi-1; i++)
                {
                   
                    if ((isim == dataGridView1.Rows[i].Cells[0].Value.ToString() & (txtIsim.Text !="")) &  ( soyIsim == dataGridView1.Rows[i].Cells[1].Value.ToString() & (txtSoyIsim.Text != "")))
                    {
                   
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        kayitBulundu += 1;
                        bulunan[kayitBulundu] = i;
                    }
                    else if ((isim == dataGridView1.Rows[i].Cells[0].Value.ToString()) & (txtSoyIsim.Text == ""))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        kayitBulundu += 1;
                        bulunan[kayitBulundu] = i;
                    }
                    else if ((soyIsim == dataGridView1.Rows[i].Cells[1].Value.ToString()) & (txtIsim.Text == ""))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
                        kayitBulundu += 1;
                        bulunan[kayitBulundu] = i;
                    }
                    if (kayitSayi - 1 == i)
                    {
                       
                        lblBulunanKayit.Text = kayitBulundu.ToString();
                    }
                   
                  
                }

                if (kayitBulundu == 0)
                {
                    RadMessageBox.ThemeName = "Desert";
                    RadMessageBox.Show("Kayıt Bulunamadı", "Eksik Bilgi");
                    lblBulunanKayit.Text = "0";

                }

                for (int i = 1; i <= kayitBulundu; i++) // Bulunan kayıtları seçili hale getir
		        {
            
                dataGridView1.Rows[bulunan[i]].Selected = true; 
                }


              if ((txtIsim.Text == String.Empty) &  (txtSoyIsim.Text == String.Empty))
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {

                RadMessageBox.Show("Hata Kodu : \n" + ex.ToString());  
            }


        }

        private void TumKayitlar_Load(object sender, EventArgs e)
        {
            try
            {

                XmlDocument i = new XmlDocument();

                DataSet ds = new DataSet();

                //xml dosyamızı okumak için ir reader oluşturuyoruz.

                XmlReader xmlFile;

                //readerin içine pathini verdiğimiz dosyayı dolduruyoruz.burada önemli olan bir nokta var.ya path imizin başına @ yazacağız ya da çift kullanacağız.

                xmlFile = XmlReader.Create(ProgramAyar.Default.veriYolu, new XmlReaderSettings());

                //içeriği Dataset e aktarıyoruz.

                ds.ReadXml(xmlFile);

                //gridviewin kaynağı olarak dataseti gösteriyoruz.

                dataGridView1.DataSource = ds.Tables[0];

                xmlFile.Close();
                lblToplamKayit.Text = dataGridView1.RowCount.ToString();
            }
            catch (Exception  ex)
            {
                RadMessageBox.Show("Kayıtlar Yüklenemedi \n  Hata Kodu : " + ex.ToString(), "HATA");
             
            }
        }

       
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int satirNo = e.RowIndex;
                Siniflar.GelenVeriler.Ad = dataGridView1.Rows[satirNo].Cells[0].Value.ToString();
                Siniflar.GelenVeriler.Soyad = dataGridView1.Rows[satirNo].Cells[1].Value.ToString();
                Siniflar.GelenVeriler.DogumTarihi = Convert.ToDateTime(dataGridView1.Rows[satirNo].Cells[2].Value.ToString());
                Siniflar.GelenVeriler.KanGrubu = dataGridView1.Rows[satirNo].Cells[3].Value.ToString();
                Siniflar.GelenVeriler.Notlar = dataGridView1.Rows[satirNo].Cells[4].Value.ToString();
                Siniflar.GelenVeriler.CepTel = dataGridView1.Rows[satirNo].Cells[5].Value.ToString();
                Siniflar.GelenVeriler.EvTel = dataGridView1.Rows[satirNo].Cells[6].Value.ToString();
                Siniflar.GelenVeriler.IsTel = dataGridView1.Rows[satirNo].Cells[7].Value.ToString();
                Siniflar.GelenVeriler.Faks = dataGridView1.Rows[satirNo].Cells[8].Value.ToString();
                Siniflar.GelenVeriler.Sirket = dataGridView1.Rows[satirNo].Cells[9].Value.ToString();
                Siniflar.GelenVeriler.IsUnvani = dataGridView1.Rows[satirNo].Cells[10].Value.ToString();
                Siniflar.GelenVeriler.EvAdres = dataGridView1.Rows[satirNo].Cells[11].Value.ToString();
                Siniflar.GelenVeriler.IsAdres = dataGridView1.Rows[satirNo].Cells[12].Value.ToString();
                Siniflar.GelenVeriler.EMail = dataGridView1.Rows[satirNo].Cells[13].Value.ToString();
                Siniflar.GelenVeriler.WebAdres = dataGridView1.Rows[satirNo].Cells[14].Value.ToString();
                Siniflar.GelenVeriler.Facebook = dataGridView1.Rows[satirNo].Cells[15].Value.ToString();
                Siniflar.GelenVeriler.Twitter = dataGridView1.Rows[satirNo].Cells[16].Value.ToString();
                Siniflar.GelenVeriler.KullaniciId = dataGridView1.Rows[satirNo].Cells[17].Value.ToString();

                Formlar.kayitBilgileri kayitBilgileri = new kayitBilgileri();
                kayitBilgileri.ShowDialog();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("HATA : Veriler Forma Aktarılamadı \n Hata Kodu : " + ex.Message.ToString());
                    
             
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Formlar.hakkimda hakkimda = new hakkimda();
            hakkimda.ShowDialog();
        }
          
     
    }
}
