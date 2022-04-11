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
    public partial class kayitBilgileri : Telerik.WinControls.UI.RadForm
    {
        public kayitBilgileri()
        {
            InitializeComponent();
        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kayitBilgileri_Load(object sender, EventArgs e)
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

        private void btnvCard_Click(object sender, EventArgs e)
        {
            Formlar.vCardOlustur vcard = new vCardOlustur();
            vcard.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
            Formlar.hakkimda hakkimda = new hakkimda();
            hakkimda.ShowDialog();
        }
    }
}
