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
    public partial class frm_Inicio_Caja : Form
    {
        public frm_Inicio_Caja()
        {
            InitializeComponent();
        }

        private void frm_Inicio_Caja_Load(object sender, EventArgs e)
        {
            txt_importe.Focus();
        }
        private void Registrar_Inicio_Caja() 
        {
            Filtro filtro = new Filtro();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            frm_Advertencia ver = new frm_Advertencia();
            CN_CierreCaja obj = new CN_CierreCaja();
            Cierre_Caja ca = new Cierre_Caja();

            string idCierre = "-";
            try
            {
                idCierre = CN_TipoDoc.CN_Generar_NroCorrelativo(10);

                ca.Id_cierre = idCierre;
                ca.Apertura_Caja = Convert.ToDouble(txt_importe.Text);

                ca.Total_Ingreso = 0;
                ca.TotalEgreso = 0;
                ca.Id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                ca.TodoDeposito = 0;
                ca.Gananciadeldia = 0;
                ca.TotalEntregado = 0;
                ca.SaldoSiguiente = 0;
                ca.TotalFactura = 0;
                ca.TotalBoleta = 0;
                ca.TotalNotaVenta = 0;
                ca.TotalCreditoCobrado = 0;
                ca.TotalCreditoEmitido = 0;

                obj.CN_Registrar_Inicio_Caja(ca);
                if(CD_CierreCaja.saved == true)
                {
                    CN_TipoDoc.CN_Actualizar_Correlativo(10);
                    filtro.Show();
                    ok.Lbl_msm1.Text = "¡Caja iniciada con éxito!";
                    ok.ShowDialog(this);
                    filtro.Hide();

                    txt_importe.Text = "";

                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ver.lbl_Nomalgo.Text =
                    "¡Error al iniciar caja!\n" + ex.Message;
                ver.ShowDialog(this);
            }
        }


        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

        private void frm_Inicio_Caja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_importe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btrn_aceptar_Click(sender, e);
            }
        }

        private void btrn_aceptar_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            frm_Advertencia ver = new frm_Advertencia();
            CN_CierreCaja obj = new CN_CierreCaja();

            if (txt_importe.Text.Trim().Length == 0)
            {
                filtro.Show();
                ver.lbl_msm.Text = "¡Ingrese el importe de apertura!";
                ver.ShowDialog(this);
                filtro.Hide();
                txt_importe.Focus();
                return;
            }
            if (obj.CN_validar_InicioDoble_caja() == true)
            {
                filtro.Show();
                ver.lbl_msm.Text = "¡Ya hay una caja abierta!";
                ver.ShowDialog(this);
                filtro.Hide();
                txt_importe.Focus();
                return;
            }
            else
            {
                Registrar_Inicio_Caja();

            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
