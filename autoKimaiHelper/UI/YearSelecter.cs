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
    public partial class YearSelecter : MaterialForm
    {
        List<MaterialRaisedButton> buttons = new List<MaterialRaisedButton>();
        TextBox textBox;
        public YearSelecter(TextBox tb)
        {
            InitializeComponent();
            textBox = tb;
            buttons.Add(materialRaisedButton1);
            buttons.Add(materialRaisedButton2);
            buttons.Add(materialRaisedButton3);
            buttons.Add(materialRaisedButton4);
            buttons.Add(materialRaisedButton5);
            buttons.Add(materialRaisedButton6);
            buttons.Add(materialRaisedButton7);
            buttons.Add(materialRaisedButton8);
            buttons.Add(materialRaisedButton9);
            buttons.Add(materialRaisedButton10);
            buttons.Add(materialRaisedButton11);
            buttons.Add(materialRaisedButton12);
            buttons.Add(materialRaisedButton13);
            buttons.Add(materialRaisedButton14);
            buttons.Add(materialRaisedButton15);
            buttons.Add(materialRaisedButton16);
            buttons.Add(materialRaisedButton17);
            buttons.Add(materialRaisedButton18);
            buttons.Add(materialRaisedButton19);
            buttons.Add(materialRaisedButton20);
            buttons.Add(materialRaisedButton21);
            buttons.Add(materialRaisedButton22);
            buttons.Add(materialRaisedButton23);
            buttons.Add(materialRaisedButton24);

            UInt16 time = 2014;
            foreach (MaterialRaisedButton bt in buttons)
            {    
                bt.Click += new System.EventHandler(this.bt_Click);
                bt.Text = time.ToString();
                time++;
            }
        }
        private void bt_Click(object sender, EventArgs e)
        {
            Button wt = (Button)sender;
            textBox.Text = wt.Text;
            this.Close();
            
            //pctID.Text = wt.Tag.ToString();

        }
       
    }
}
