using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;

namespace autoKimaiHelper
{
    public partial class LogOut : MaterialForm
    {
        private Form1 ui;
        public LogOut(Form1 f)
        {
            InitializeComponent();
            ui = f;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
          //  ui.LoginButton = true;
            ui.LoginButton = true;
            ui.PostDataButton = false;
            ui.uName = true;
            ui.Pass = true;
            ui.TabIndex = 0;

            ui.Enabled = true;
         
            this.Hide();
        }
    }
}
