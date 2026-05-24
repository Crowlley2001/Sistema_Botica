using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Cajas
{
    public partial class frm_Otros_Gastos : Form
    {
        public frm_Otros_Gastos()
        {
            InitializeComponent();
        }

        private void frm_Otros_Gastos_Load(object sender, EventArgs e)
        {
            //         FECHA - ACTUAL         //
            dtp_Salida.Value = DateTime.Now;
        }

        private void pnl_Ingreso_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }
        private void Guardar_Salida()
        {
            CN_Caja obj = new CN_Caja();
            Caja cja = new Caja();

            try
            {
                cja.Fecha_Caja = dtp_Salida.Value;
                cja.Tipo_Caja = "Salida";
                cja.Concepto = txt_detalle_Salida.Text;
                cja.De_Para = txt_Recibi_Salida.Text;
                cja.Nro_Doc = txt_Documento_Salida.Text;
                cja.ImporteCaja = Convert.ToDouble(txt_Importe_Salida.Text);
                cja.Id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                cja.TotalUti = 0;
                cja.TipoPago = cbo_Salida.Text;
                cja.GeneradoPor = "Otros";
                cja.Total_Dscuentos = 0;
                obj.CN_Registrar_Mov_Caja(cja);

                if (CD_Caja.cajaSaved == true)
                {
                    Filtro filtro = new Filtro();
                    frm_Msm_bueno ok = new frm_Msm_bueno();

                    filtro.Show();
                    ok.Lbl_msm1.Text = "Salida registrada correctamente";
                    ok.ShowDialog(this);
                    filtro.Hide();
                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el ingreso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btn_registrar_Salida_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_detalle_Salida.Text))
            {
                MessageBox.Show("Ingrese el detalle", "Aviso");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Importe_Salida.Text))
            {
                MessageBox.Show("Ingrese el importe", "Aviso");
                return;
            }
            Guardar_Salida();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar_Salida()
        {
            txt_detalle_Salida.Text = "";
            txt_Recibi_Salida.Text = "";
            txt_Documento_Salida.Text = "";
            txt_Importe_Salida.Text = "";

            cbo_Salida.SelectedIndex = -1;

            dtp_Salida.Value = DateTime.Now;

            txt_detalle_Salida.Focus();
        }

        private void btnLimpiarar_Salida_Click(object sender, EventArgs e)
        {
            Limpiar_Salida();
        }
    }
}
