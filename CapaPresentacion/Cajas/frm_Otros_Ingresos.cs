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
    public partial class frm_Otros_Ingresos : Form
    {
        public frm_Otros_Ingresos()
        {
            InitializeComponent();
        }

        private void frm_Otros_Ingresos_Load(object sender, EventArgs e)
        {
            //         FECHA - ACTUAL         //
            dtp_Ingreso.Value = DateTime.Now;
        }

        private void pnl_Ingreso_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

        private void Guardar_Ingreso()
        {
            CN_Caja obj = new CN_Caja();
            Caja cja = new Caja();

            try
            {
                cja.Fecha_Caja = dtp_Ingreso.Value;
                cja.Tipo_Caja = "Entrada";
                cja.Concepto = txt_detalle_Ingreso.Text;
                cja.De_Para = txt_Recibi_Ingreso.Text;
                cja.Nro_Doc = txt_Documento_Ingreso.Text;
                cja.ImporteCaja = Convert.ToDouble(txt_Importe_Ingreso.Text);
                cja.Id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                cja.TotalUti = 0; 
                cja.TipoPago = cbo_Ingreso.Text;
                cja.GeneradoPor = "Otros";
                cja.Total_Dscuentos = 0;
                obj.CN_Registrar_Mov_Caja(cja);

                if(CD_Caja.cajaSaved == true)
                {
                    Filtro filtro = new Filtro();
                    frm_Msm_bueno ok = new frm_Msm_bueno();

                    filtro.Show();
                    ok.Lbl_msm1.Text = "Ingreso registrado correctamente";   
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

     

        private void btn_registrar_Ingreso_Click(object sender, EventArgs e)
        {
            if(txt_detalle_Ingreso.Text.Trim().Length == 0) return;
            if(txt_Importe_Ingreso.Text.Trim().Length == 0) return;
            Guardar_Ingreso();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Limpiar_Ingreso()
        {
            txt_detalle_Ingreso.Text = "";
            txt_Recibi_Ingreso.Text = "";
            txt_Documento_Ingreso.Text = "";
            txt_Importe_Ingreso.Text = "";

            cbo_Ingreso.SelectedIndex = -1;

            dtp_Ingreso.Value = DateTime.Now;

            txt_detalle_Ingreso.Focus();
        }
        private void btnLimpiarar_Ingreso_Click(object sender, EventArgs e)
        {
            Limpiar_Ingreso();
        }
    }
}
