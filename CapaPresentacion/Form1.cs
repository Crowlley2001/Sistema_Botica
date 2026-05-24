using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_prueba.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(1);
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            txt_prueba.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(1);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            CN_TipoDoc.CN_Actualizar_Correlativo(1);
        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }
    }
}
