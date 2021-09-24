using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialPr
{
    public partial class Modulo4 : Form
    {
        public Modulo4()
        {
            InitializeComponent();
        }
        public string Reverse(string textBox1)
        {
            char[] cArray = textBox1.ToCharArray();
            string invertir = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                invertir += cArray[i];
            }
            return invertir;
            textBox2.Text = invertir.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
