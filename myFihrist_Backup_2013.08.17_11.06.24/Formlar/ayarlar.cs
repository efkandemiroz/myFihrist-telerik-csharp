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
            ProgramAyar.Default.ilkKurulum = true;
            ProgramAyar.Default.veriYolu = String.Empty;
            ProgramAyar.Default.Save();
        }
    }
}
