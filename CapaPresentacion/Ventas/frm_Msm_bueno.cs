using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ventas
{
    public partial class frm_Msm_bueno : Form
    {
        public frm_Msm_bueno()
        {
            InitializeComponent();
        }




        private void tocar_timbreCaja()
        {
            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\timbre1.wav");
            son.Play();
        }

        private void frm_Msm_bueno_Load(object sender, EventArgs e)
        {
            tocar_timbreCaja();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Msm_bueno_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }
    }
}
