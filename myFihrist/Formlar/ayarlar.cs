using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace myFihrist.Formlar
{
    public partial class ayarlar : Telerik.WinControls.UI.RadForm
    {
        public ayarlar()
        {
            InitializeComponent();
        }
        
        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult sifirla;
                RadMessageBox.ThemeName = this.ThemeName.ToString();
                sifirla = RadMessageBox.Show("Verileri Sıfırlamak İstediğinizden Eminmisiniz", "Sıfırlama Uyarısı", MessageBoxButtons.YesNo);

                if (sifirla == DialogResult.Yes)
                {
                    ProgramAyar.Default.ilkKurulum = true;
                    ProgramAyar.Default.veriYolu = String.Empty;
                    ProgramAyar.Default.Save();
                }
            }
            catch (Exception)
            {

               
            }
            
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            txtAdres.Text = ProgramAyar.Default.veriYolu;
        }
       

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = "Veri_Kayitlari";
                openFileDialog1.Filter = "XML Dosyası (*.XML)|*.XML";
                openFileDialog1.Title = "Veri Dosyasının Kayıt Edilmesini İstediğiniz Dizini Seçin";
                openFileDialog1.InitialDirectory = "D:\\";
                openFileDialog1.DefaultExt = "XML";


                DialogResult basilanTus;
                basilanTus = openFileDialog1.ShowDialog();
                if (basilanTus == System.Windows.Forms.DialogResult.OK)
                {

                    txtAdres.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ProgramAyar.Default.veriYolu = txtAdres.Text;
                ProgramAyar.Default.Save();
                RadMessageBox.ThemeName = this.ThemeName.ToString();
                RadMessageBox.Show("Ayarlar Başarı İle Kaydedildi", "Ayarlar Kayıt Edildi", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                  RadMessageBox.ThemeName = this.ThemeName.ToString();
                   RadMessageBox.Show("Ayarlar Kaydedilemedi", "Kayıt Hatası", MessageBoxButtons.OK);
            
             
            }

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Formlar.hakkimda hakkinda = new hakkimda();
            hakkinda.ShowDialog();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
