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

namespace CapaPresentacion.Modales
{
    public partial class md_Cambio : Form
    {
        public md_Cambio()
        {
            InitializeComponent();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void md_Cambio_Load(object sender, EventArgs e)
        {
            var dt = CN_TipoCambio.CN_Listar_TipoCambio();
            dgvTipoCambio.DataSource = null; 
            dgvTipoCambio.DataSource = dt;
            //         FECHA - ACTUAL         //
            dtFecha.Value = DateTime.Now;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // INSTANCIAS
            frm_Advertencia ver = new frm_Advertencia();
            frm_Msm_bueno ok = new frm_Msm_bueno();

            try
            {
                // 🔴 VALIDAR CAMPOS VACÍOS
                if (txtCompra.Text.Trim() == "" || txtVenta.Text.Trim() == "")
                {
                    ver.lbl_msm.Text = "Ingrese los valores de compra y venta";
                    ver.ShowDialog();
                    return;
                }

                // 🔴 VALIDAR NÚMEROS
                double compra, venta;

                if (!double.TryParse(txtCompra.Text, out compra) || !double.TryParse(txtVenta.Text, out venta))
                {
                    ver.lbl_msm.Text = "Ingrese valores numéricos válidos";
                    ver.ShowDialog();
                    return;
                }

                // 🔴 VALIDAR VALORES MAYORES A 0
                if (compra <= 0 || venta <= 0)
                {
                    ver.lbl_msm.Text = "El tipo de cambio debe ser mayor a 0";
                    ver.ShowDialog();
                    return;
                }

                if (CN_TipoCambio.ExisteTipoCambio(dtFecha.Value))
                {
                    ver.lbl_msm.Text = "Ya existe tipo de cambio para esta fecha";
                    ver.ShowDialog();
                    return;
                }
                // 🟢 GUARDAR DIRECTO (SIN SI/NO)
                CN_TipoCambio.CN_Guardar_TipoCambio(
                    dtFecha.Value,
                    compra,
                    venta,
                    Convert.ToInt32(Cls_ModalCategoria.IdUsu)
                );

                // 🔄 ACTUALIZAR GRID
                ListarTipoCambio();

                // 🟢 MENSAJE OK
                ok.Lbl_msm1.Text = "Tipo de cambio guardado correctamente";
                ok.ShowDialog();
            }
            catch (Exception ex)
            {
                // 🔴 ERROR
                ver.lbl_msm.Text = ex.Message;
                ver.ShowDialog();
            }
        }

        private void ListarTipoCambio()
        {
            var dt = CN_TipoCambio.CN_Listar_TipoCambio();

            dgvTipoCambio.AutoGenerateColumns = true;
            dgvTipoCambio.DataSource = null;
            dgvTipoCambio.DataSource = dt;
        }

        private void BuscarTipoCambioPorFecha()
        {
            DataTable dt = CN_TipoCambio.CN_Buscar_TipoCambio_Fecha(dtFecha.Value);

            if (dt.Rows.Count > 0)
            {
                // 👉 YA EXISTE → CARGA DATOS
                txtCompra.Text = dt.Rows[0]["Compra"].ToString();
                txtVenta.Text = dt.Rows[0]["Venta"].ToString();
            }
            else
            {
                // 👉 NO EXISTE → LIMPIA
                txtCompra.Text = "";
                txtVenta.Text = "";
            }
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            BuscarTipoCambioPorFecha();
        }
        private void Limpiar_Cambio()
        {
            txtCompra.Text = "";
            txtVenta.Text = "";

            dtFecha.Value = DateTime.Now;

            txtCompra.Focus();
        }
        private void btnlimpiar_cambios_Click(object sender, EventArgs e)
        {
            Limpiar_Cambio();
        }
    }
    
}
