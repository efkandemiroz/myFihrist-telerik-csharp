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
    public partial class KayitSil : Telerik.WinControls.UI.RadForm
    {
        public KayitSil()
        {
            InitializeComponent();
        }

        private void KayitSil_Load(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                RadMessageBox.SetThemeName(this.ThemeName.ToString());
                RadMessageBox.Show("Kayıtlar Yüklenemedi \n  Hata Kodu : \n " + ex.Message.ToString(), "HATA");
                throw;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                RadMessageBox.SetThemeName(this.ThemeName.ToString());
                RadMessageBox.Show("Kayıtlar Yüklenemedi \n  Hata Kodu : \n " + ex.Message.ToString(), "HATA");
                throw;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.ClearSelection();
                int kayitBulundu = 0;
                int kayitSayi = dataGridView1.RowCount;
                string isim = txtIsim.Text;
                string soyIsim = txtSoyIsim.Text;
                int[] bulunan = new int[kayitSayi];


                for (int i = 0; i <= kayitSayi - 1; i++)
                {

                    if ((isim == dataGridView1.Rows[i].Cells[0].Value.ToString() & (txtIsim.Text != "")) & (soyIsim == dataGridView1.Rows[i].Cells[1].Value.ToString() & (txtSoyIsim.Text != "")))
                    {

                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        kayitBulundu += 1;
                        bulunan[kayitBulundu] = i;
                        Siniflar.GelenVeriler.KullaniciId = dataGridView1.Rows[i].Cells[17].Value.ToString(); // Aranan bilginini id numarasını bulur
                      
                    }
                    else if ((isim == dataGridView1.Rows[i].Cells[0].Value.ToString()) & (txtSoyIsim.Text == ""))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                        kayitBulundu += 1;
                        bulunan[kayitBulundu] = i;
                        Siniflar.GelenVeriler.KullaniciId = dataGridView1.Rows[i].Cells[17].Value.ToString();
                        MessageBox.Show(Siniflar.GelenVeriler.KullaniciId);
                    }
                    else if ((soyIsim == dataGridView1.Rows[i].Cells[1].Value.ToString()) & (txtIsim.Text == ""))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
                        kayitBulundu += 1;
                        bulunan[kayitBulundu] = i;
                        Siniflar.GelenVeriler.KullaniciId = dataGridView1.Rows[i].Cells[17].Value.ToString();
                    
                    }
                    if (kayitSayi - 1 == i)
                    {

                        lblBulunanKayit.Text = kayitBulundu.ToString();
                    }


                }

                if (kayitBulundu == 0)
                {
                    RadMessageBox.SetThemeName(this.ThemeName.ToString());
                    RadMessageBox.Show("Kayıt Bulunamadı", "Eksik Bilgi");
                    lblBulunanKayit.Text = "0";

                }

                for (int i = 1; i <= kayitBulundu; i++) // Bulunan kayıtları seçili hale getir
                {

                    dataGridView1.Rows[bulunan[i]].Selected = true;
                }


                if ((txtIsim.Text == String.Empty) & (txtSoyIsim.Text == String.Empty))
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {

                RadMessageBox.Show("Hata Kodu : \n" + ex.ToString());
            }
        }

        private void btnKayitSil_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument xDoc = XDocument.Load(ProgramAyar.Default.veriYolu);  // XML Dosyasını yükle

                var silinecek = from bilgi in xDoc.Element("Kayitlar").Elements("Kayit")
                                where bilgi.Attribute("id").Value == Siniflar.GelenVeriler.KullaniciId
                                select bilgi;

                RadMessageBox.SetThemeName(this.ThemeName.ToString());
                DialogResult silinsinmi = RadMessageBox.Show("Seçili Bilgi Silinsin mi ?", "Bilgi Silme Uyarısı", MessageBoxButtons.YesNo);



                if (silinsinmi == System.Windows.Forms.DialogResult.Yes) // Silme uyarısı onaylandığında verileri sil
                {
                    silinecek.Remove();
                    xDoc.Save(ProgramAyar.Default.veriYolu);
                    RadMessageBox.SetThemeName(this.ThemeName.ToString());
                    RadMessageBox.Show("Bilgiler Başarı İle Silindi", "Silme İşlemi");

                    #region Bilgileri Yenile
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
                    #endregion      // bilgi sinilince grid view güncelleniyor

                }
                else
                {

                    RadMessageBox.SetThemeName(this.ThemeName.ToString());
                    RadMessageBox.Show("Silme İşlemi İptal Edildi", "Silme İşlemi");
                }

            }
            catch (Exception)
            {

                throw;
            }
         
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Datagrid'e tıklandığında idyi al
        {
            try
            {
                int satirNo = e.RowIndex;
                Siniflar.GelenVeriler.KullaniciId = dataGridView1.Rows[satirNo].Cells[17].Value.ToString();
            }
            catch (Exception)
            {

              
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Formlar.hakkimda hakkimda = new hakkimda();
            hakkimda.ShowDialog();
        }
    }
}
