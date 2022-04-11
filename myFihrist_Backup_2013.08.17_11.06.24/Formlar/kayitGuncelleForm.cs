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
    }
}
