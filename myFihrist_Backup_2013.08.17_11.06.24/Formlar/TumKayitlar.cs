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
                   
                    if ((isim == dataGridView1.Rows[i].Cells[0].Value.ToString()) && (soyIsim == dataGridView1.Rows[i].Cells[1].Value.ToString()))
                    {
                   
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
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


                if (txtIsim.Text == String.Empty)
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
          
     
    }
}
