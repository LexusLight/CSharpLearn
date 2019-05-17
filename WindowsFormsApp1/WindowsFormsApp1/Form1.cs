using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int scifernum;//НОМЕР ОПЕРАЦИИ
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //вызываем шифровку
        {
            if (textBox1.Text == "") textBox1.Text = "МАТЕМАТИКА";
            Chifer(true);
             
        }

        private void button2_Click(object sender, EventArgs e) //вызываем дешифровку
        {
            if (textBox1.Text == "") textBox1.Text = "МАТЕМАТИКА";
            Chifer(false);
        }


        private void check(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { textBox1.Visible = false; scifernum = 1; button2.Visible = true; } 
            if (radioButton2.Checked) { textBox1.Visible = false; scifernum = 2; button2.Visible = true; }
            if (radioButton3.Checked) { textBox1.Visible = false; scifernum = 3; button2.Visible = true; }
            if (radioButton4.Checked) { textBox1.Visible = true; scifernum = 4; button2.Visible = true; }
            if (radioButton5.Checked) { textBox1.Visible = true; scifernum = 5; button2.Visible = false; }
            if (radioButton6.Checked) { textBox1.Visible = true; scifernum = 6; button2.Visible = true; }
            if (radioButton7.Checked) { textBox1.Visible = true; scifernum = 7; button2.Visible = true; }
            if (radioButton8.Checked) { textBox1.Visible = true; scifernum = 8; button2.Visible = true; }
            if (radioButton9.Checked) { textBox1.Visible = true; scifernum = 9; button2.Visible = false; }
            if (radioButton10.Checked) { textBox1.Visible = true; scifernum = 10; button2.Visible = false; }
            if (radioButton11.Checked) { textBox1.Visible = false; scifernum = 11; button2.Visible = false; }
            if (radioButton12.Checked) { textBox1.Visible = true; scifernum = 12; button2.Visible = false; }
            if (radioButton13.Checked) { textBox1.Visible = false; scifernum = 13; button2.Visible = false; }

        }


        private void Chifer(bool flagShif)
        {
            Change.key = textBox1.Text;
            Change.firstWord = textBox2.Text;
            switch (scifernum) {
                    case 1:
                   textBox3.Text = Change.Czeesar(flagShif);
                        break;
                    case 2:
                   textBox3.Text = Change.Adbash(flagShif);
                        break;
                    case 3:
                    textBox3.Text = Change.Polibian(flagShif);
                        break;
                    case 4:
                    textBox3.Text = Change.Trisemus(flagShif);
                        break;
                    case 5:
                    textBox3.Text = Change.Playfair(flagShif);
                        break;
                    case 6:
                    textBox3.Text = Change.Variantniy(flagShif);
                        break;
                    case 7:
                    textBox3.Text = Change.Vijiner(flagShif);
                        break;
                    case 8:
                    textBox3.Text = Change.Sovmesh(flagShif);
                        break;
                    case 9:
                    textBox3.Text = Transpos.MonoTrans();
                        break;
                    case 10:
                    textBox3.Text = Transpos.BlockTrans();
                        break;
                    case 11:
                    textBox3.Text = Transpos.Marchrut();
                        break;
                    case 12:
                    textBox3.Text = Transpos.Vertical();
                        break;
            }
      
        }


 
    }
}
