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
    public partial class Modulo3 : Form
    {
        public Modulo3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> datos = new List<string>();
            string Texto = " ";
            int Contador = 0;
            char[] Array;
            string res = string.Empty;
            Texto = textBox1.Text.Replace(" ", "");
            Array = Texto.ToCharArray();
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length; j++)
                {
                    if (Array[i] == Array[j])
                    {
                        Contador++;
                    }
                }
                datos.Add(Array[i] + " " + Contador + "\n");
                Console.WriteLine(res);
                Contador = 0;
            }
            HashSet<string> datossin = new HashSet<string>(datos);
            foreach (String var in datossin)
            {
                res = res + var.ToString();
            }
            label1.Text = (res);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
