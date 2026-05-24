using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSistemaBotica_C.Utilitarios
{
    public partial class frm_softmsm : Form
    {
        public frm_softmsm()
        {
            InitializeComponent();
        }

        public string tipo = "Good";
        private void Frm_LightMsmcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape )
            {
                this.Close();
            }
        }

        private void tocar_timbre()
        {
            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\tono_mensaje_3.wav");
            son.Play();

        }


        private int seg = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            seg += 1;

            if (seg==5)
            {
                seg = 0;
                timer1.Stop();
                this.Close();
            }
        }

        private void frm_softmsm_Load(object sender, EventArgs e)
        {
            if (tipo.Trim()=="Good")
            {
                this.BackColor = Color.YellowGreen;
            }
            else if (tipo.Trim()=="Warning")
            {
                this.BackColor = Color.Orange;
            }
            else if (tipo.Trim()=="Error")
            {
                this.BackColor = Color.Red;
            }
            tocar_timbre();
            timer1.Start();

        }
    }
}
