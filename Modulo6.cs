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
        char[] PalabrasAdivinadas; int Oportunidades;
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
            label2.Visible = false;
            Oportunidades = 0;//fallar

            string Palabras = (txtPalabra.Text);
            Alfabeto = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ ".ToCharArray();
            PalabrasSeleccionada = Palabras.ToUpper().ToCharArray();
            PalabrasAdivinadas = PalabrasSeleccionada;

            
            foreach (char LetraAlfabeto in Alfabeto)
            {
                Button btnLetra = new Button();
                btnLetra.Tag = " ";
                btnLetra.Text = LetraAlfabeto.ToString();
                btnLetra.Width = 60;
                btnLetra.Height = 40;
                btnLetra.Click += Compara;
                btnLetra.ForeColor = Color.White;
                btnLetra.Font = new Font(btnLetra.Font.Name, 15, FontStyle.Bold);
                btnLetra.BackgroundImageLayout = ImageLayout.Center;
                btnLetra.BackColor = Color.Black;
                btnLetra.Name = LetraAlfabeto.ToString();
                flowLayoutPanel1.Controls.Add(btnLetra);
            }

            flowLayoutPanel2.Controls.Clear();
            for (int ValorLetra = 0; ValorLetra < PalabrasSeleccionada.Length; ValorLetra++)
            {
                Button Letra = new Button();
                Letra.Tag = PalabrasSeleccionada[ValorLetra].ToString();
                Letra.Width = 46;
                Letra.Height = 80;
                Letra.ForeColor = Color.Purple;
                Letra.Text = "-";
                Letra.Font = new Font(Letra.Font.Name, 32, FontStyle.Bold);
                Letra.BackgroundImageLayout = ImageLayout.Center;
                Letra.BackColor = Color.White;
                Letra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                Letra.Name = "Adivinaste" + ValorLetra.ToString();
                Letra.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.juego));
                flowLayoutPanel2.Controls.Add(Letra);
            }
        }

        void Compara(object sender, EventArgs e)
        {
            bool encontrada = false;
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Enabled = false;
            for (int Revisar = 0; Revisar < PalabrasAdivinadas.Length; Revisar++)
            {
                if (PalabrasAdivinadas[Revisar] == Char.Parse(btn.Text))
                {
                  
                    Button tbx = this.Controls.Find("Adivinaste" + Revisar, true).FirstOrDefault() as Button;
                    tbx.Text = PalabrasAdivinadas[Revisar].ToString();
                    PalabrasAdivinadas[Revisar] = '-';
                    encontrada = true;
                }
            }
            bool Ganaste = true;
            for (int AnalizarGanador = 0; AnalizarGanador < PalabrasAdivinadas.Length; AnalizarGanador++)
            { 
                if (PalabrasAdivinadas[AnalizarGanador] != '-')
                {
                    Ganaste = false;
                }
            }
            if (Ganaste)
            {
                MessageBox.Show("Ganaste");
            }
            if (!encontrada)
            {
                Oportunidades = Oportunidades + 1;
                pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("ahorcado" + Oportunidades);
                if (Oportunidades == 7)
                { 
                    label2.Visible = true;
                    for (int ValorLetra = 0; ValorLetra < PalabrasSeleccionada.Length; ValorLetra++)
                    {
                        Button btnLetra = this.Controls.Find("Adivinaste" + ValorLetra, true).FirstOrDefault() as Button;
                        btnLetra.Text = btnLetra.Tag.ToString();
                    }
                    flowLayoutPanel1.Enabled = false;
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
