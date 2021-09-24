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
    public partial class Moulo5 : Form
    {
        public Moulo5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Texto = " ";
            char[] Array;
            List<String> datos = new List<string>();
            string res = string.Empty;
            Texto = textBox1.Text.Replace(" ", "");
            int iguales = 32;
            for (int j = 'A'; j <= 'z'; j++)//recorre los caracteres de la A la z en acsii
            {
                if (j < 91 || j > 96)//Omite los queno partene al abcedario entre Z y a
                {
                    string str = j.ToString();
                    datos.Add(str);//Se añade a la lista los numeros del abecedario
                }

            }
            for (int i = 0; i < Texto.Length; i++)// Se recorre el texto
            {
                int inp = Texto[i];// Se con vierte a entero
                if (datos.Contains(inp.ToString()))//Mira si el numero correspondiente a su letra esta en la lista
                {
                    int igu = 0;
                    if (inp < 91) //valida si la letra es mayuscula
                    {
                        igu = inp + iguales; //si es mayuscula, le suma 32 para borrar su semejante en minuscula
                    }
                    else
                    {
                        igu = inp - iguales; //si es mayor a 91, quiere decir que es minuscula y le resta 32 para borrar su semejante en mayuscula
                    }
                    datos.Remove(inp.ToString());// se remueve la letra correspondiente
                    datos.Remove(igu.ToString());//Se remueve el semenjante en mayuscula o minuscula segun corresponda

                }
            }
            if (datos.Count == 0)//Mira lo que sobra en la lista y lo compara si es igual a 0, la lista esta vacia por ende tiene todo el abc
            {
                label1.Text = ("Cumple");
            }
            else
            {
                label1.Text = ("No cumple");
            }
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
