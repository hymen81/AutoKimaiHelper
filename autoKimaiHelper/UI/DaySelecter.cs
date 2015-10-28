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
    public partial class DaySelecter : MaterialForm
    {
        List<MaterialRaisedButton> buttons = new List<MaterialRaisedButton>();
        TextBox textBox;
        public DaySelecter(TextBox tb,int selectYear,int selectMouth)
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
            buttons.Add(materialRaisedButton25);
            buttons.Add(materialRaisedButton26);
            buttons.Add(materialRaisedButton27);
            buttons.Add(materialRaisedButton28);
            buttons.Add(materialRaisedButton29);
            buttons.Add(materialRaisedButton30);
            buttons.Add(materialRaisedButton31);

            int daysInMouth = DateTime.DaysInMonth(selectYear, selectMouth);
             
            UInt16 mouth = 1;
            foreach (MaterialRaisedButton bt in buttons)
            {              
                if (daysInMouth == 0)
                    break;
                bt.Click += new System.EventHandler(this.bt_Click);
                bt.Text = mouth.ToString().PadLeft(2, '0'); 
                bt.Visible = true;
                mouth++;
                daysInMouth--;
            }
        }
        private void bt_Click(object sender, EventArgs e)
        {
            Button wt = (Button)sender;
            textBox.Text = wt.Text;
            this.Close();
        }
       
    }
}
