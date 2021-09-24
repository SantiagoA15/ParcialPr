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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modulo2 Modulo1 = new Modulo2();
            Modulo1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Modulo2 = new Form2();
            Modulo2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modulo3 Modulo3 = new Modulo3();
            Modulo3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modulo4 Modulo4 = new Modulo4();
            Modulo4.Show();
        }
    }
}

