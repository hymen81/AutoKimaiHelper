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
    public partial class NetWorkError : MaterialForm
    {
        public NetWorkError()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            NetWorkCheck nwc= new NetWorkCheck();
            if (nwc.dnsName.IndexOf("acer") != -1)
                this.Close();
        }
    }
}
