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
    public partial class Modulo6 : Form
    {
        char[] PalabrasAdivinadas; int oportunidades;
        char[] PalabrasSeleccionada;
        char[] Alfabeto;
        String[] Palabras;
        public Modulo6()
        {
            InitializeComponent();
        }
        public void IniciarJuego()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Enabled = true;
            pictureBox1.Image = null;
            label1.Visible = false;
            oportunidades = 0;

            pictureBox1.Image = Properties.Resources.Jugando;
            Palabras = new string[] { "MATERIAS", "UNIVERSIDAD", "ESTUDIANTES", "PROGRAMACION" };
            Alfabeto = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ".ToCharArray();


            Random random = new Random();
            int IndicePalabra = random.Next(0, Palabras.Length);
            PalabrasSeleccionada = Palabras[IndicePalabra].ToCharArray();
            PalabrasAdivinadas = PalabrasSeleccionada;


            foreach (char letraAl in Alfabeto)
            {
                Button btnLetra = new Button();
                btnLetra.Tag = "";
                btnLetra.Text = letraAl.ToString();
                btnLetra.Width = 60;
                btnLetra.Height = 40;
                btnLetra.ForeColor = Color.White;
                btnLetra.Font = new Font(btnLetra.Font.Name, 15, FontStyle.Bold);
                btnLetra.BackgroundImageLayout = ImageLayout.Center;
                btnLetra.BackColor = Color.Black;
                btnLetra.Name = letraAl.ToString();
                flowLayoutPanel1.Controls.Add(btnLetra);
            }
            flowLayoutPanel2.Controls.Clear();
            for (int indicevalor = 0; indicevalor < PalabrasSeleccionada.Length; indicevalor++)
            {
                Button letra = new Button();
                letra.Tag = PalabrasSeleccionada[indicevalor].ToString();
                letra.Width = 60;
                letra.Height = 40;
                letra.ForeColor = Color.Purple;
                letra.Text = "-";
                letra.Font = new Font(letra.Font.Name, 32, FontStyle.Bold);
                letra.BackgroundImageLayout = ImageLayout.Center;
                letra.BackColor = Color.White;
                letra.Name = "Adivinado" + letra.ToString();
                letra.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.acertijo));
                flowLayoutPanel2.Controls.Add(letra);
            }
        }
        void compara(object sender, EventArgs e)
        {
            bool encontrado = false;
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Enabled = false;
            for (int indicerevisar = 0; indicerevisar < PalabrasAdivinadas.Length; indicerevisar++)
            {
                if (PalabrasAdivinadas[indicerevisar] == char.Parse(btn.Text))
                {
                    Button tbx = this.Controls.Find("Adivinado" + indicerevisar, true).FirstOrDefault() as Button;
                    tbx.Text = PalabrasAdivinadas[indicerevisar].ToString();
                    PalabrasAdivinadas[indicerevisar] = '-';
                    encontrado = true;
                }
            }
            bool Ganaste = true;
            for (int indiceganador = 0; indiceganador < PalabrasAdivinadas.Length; indiceganador++)
            {
                if (PalabrasAdivinadas[indiceganador] != '-')
                {
                    Ganaste = false;
                }
            }
            if (Ganaste)
            {
                MessageBox.Show("Ganaste");
                pictureBox3.Image = Properties.Resources.btnStart;
            }
            if (!encontrado)
            {
                oportunidades = oportunidades + 1;
                pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Ahorcado" + oportunidades);
                if (oportunidades == 8)
                {
                    label2.Visible = true;
                    for (int indicevalor = 0; indicevalor < PalabrasSeleccionada.Length; indicevalor++)
                    {
                        Button btnLetra = this.Controls.Find("Adivinado" + indicevalor, true).FirstOrDefault() as Button;
                        btnLetra.Text = PalabrasSeleccionada[indicevalor].ToString();
                    }
                    flowLayoutPanel1.Enabled = false;
                    pictureBox3.Image = Properties.Resources.btnStart;
                }
            }
        }
        private void Modulo6_Load(object sender, EventArgs e)
        {
            IniciarJuego();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            IniciarJuego();
        }
    }
}
