using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Informes;
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
    public partial class frm_Cierre_Caja : Form
    {
        public frm_Cierre_Caja()
        {
            InitializeComponent();
        }

        private void frm_Cierre_Caja_Load(object sender, EventArgs e)
        {
            Configurar_Lisvie();
            Buscar_CajaDia(dtp_fechaHoy.Value = DateTime.Now);
            Listar_CajaDia();

            Buscar_Ventas_PorBoleta();
            Buscar_Ventas_PorFactura();
            Buscar_Ventas_PorNotaVenmta();
            Buscar_Ventas_PorOtrosIngresos();
            Buscar_Ventas_conTarjeta();

            Buscar_Gastos_conTarjeta();
            Buscar_Gastos_conEfectivo();
            Calcular_Utilidad();
          
        }

        private void Configurar_Lisvie()
        {
            var lis = lsv_Caja;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            // Configurar las columnas del ListView
            lis.Columns.Add("ID Caja", 60, HorizontalAlignment.Center);
            lis.Columns.Add("Tipo Caja", 150, HorizontalAlignment.Center);
            lis.Columns.Add("Tipo Pago", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Importe", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Estado", 120, HorizontalAlignment.Center);
        }

        private void Llenar_ListView_Prod(DataTable data)
        {
            lsv_Caja.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];
                ListViewItem item = new ListViewItem(row["Idcaja"].ToString());
                item.SubItems.Add(row["Tipo_Caja"].ToString());
                item.SubItems.Add(row["TipoPago"].ToString());
                item.SubItems.Add(row["ImporteCaja"].ToString());
                item.SubItems.Add(row["EstadoCaja"].ToString());
                lsv_Caja.Items.Add(item);
            }
        }


        private void Buscar_CajaDia(DateTime xdia)
        {
            CN_Caja obj = new CN_Caja();
            DataTable data = new DataTable();

            data = obj.CN_Listar_Cajas_DelDia(xdia);
            if (data.Rows.Count > 0)
            {
                Llenar_ListView_Prod(data);
            }
            else
            {
                lsv_Caja.Items.Clear();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);

            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }


        private void Listar_CajaDia()
        {
            DataTable data = new DataTable();
            CN_CierreCaja obj = new CN_CierreCaja();
            try
            {
                data = obj.CN_Listar_Cierre_Caja_DelDia(dtp_fechaHoy.Value = DateTime.Now, "Abierto");
                if (data.Rows.Count > 0)
                {
                    txt_idCaja.Text = data.Rows[0]["Id_cierre"].ToString();
                    txt_aperturaCaja.Text = data.Rows[0]["Apertura_Caja"].ToString();
                    txt_estado.Text = data.Rows[0]["Estado_cierre"].ToString();
                    txt_fechaCaja.Text = data.Rows[0]["Fecha_Cierre"].ToString();

                    if (txt_estado.Text.Trim() == "Cerrado")
                    {
                        btn_CerarCaja.Enabled = false;
                    }
                    else
                    {
                        btn_CerarCaja.Enabled = true;
                    }

                }
                else
                {
                    Filtro filtro = new Filtro();
                    frm_Advertencia ver = new frm_Advertencia();
                    filtro.Show();
                    ver.lbl_msm.Text = "Por Favor, Tienes que Iniciar Caja, Para poder Acceder al Cierre";
                    ver.ShowDialog(this);
                    filtro.Hide();

                    btn_CerarCaja.Enabled = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //********************************* Cargamos los Cierres de Caja del día seleccionado *********************************//

        private void Buscar_Ventas_PorBoleta()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();

            double subimporte = 0;
            data = obj.CN_Calcular_Ventas_PorTipo_Doc("Boleta");
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    subimporte = subimporte + Convert.ToDouble(dr["ImporteCaja"]);
                }
                txt_boleta.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_boleta.Text = "00";
            }
        }


        private void Buscar_Ventas_PorFactura()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();

            double subimporte = 0;
            data = obj.CN_Calcular_Ventas_PorTipo_Doc("Factura");
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    subimporte = subimporte + Convert.ToDouble(dr["ImporteCaja"]);
                }
                txt_factura.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_factura.Text = "00";
            }
        }



        private void Buscar_Ventas_PorNotaVenmta()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = obj.CN_Calcular_Ventas_PorTipo_Doc("Nota Venta"); // Sin la 'de'

            if (data != null && data.Rows.Count > 0)
            {
                double subimporte = data.AsEnumerable().Sum(r => Convert.ToDouble(r["ImporteCaja"]));
                txt_notaventa.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_notaventa.Text = "0.00";
            }
        }


        private void Buscar_Ventas_conTarjeta()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();

            double subimporte = 0;
            data = obj.CN_Calcular_ventas_ADeposito();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    subimporte = subimporte + Convert.ToDouble(dr["ImporteCaja"]);
                }
                txt_tarjeta.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_tarjeta.Text = "00";
            }
        }


        private void Buscar_Ventas_PorOtrosIngresos()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();

            double subimporte = 0;
            data = obj.CN_Calcular_Ventas_PorTipo_Doc("Otros");
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    subimporte = subimporte + Convert.ToDouble(dr["ImporteCaja"]);
                }
                txt_otros.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_otros.Text = "00";
            }
        }

        private void Buscar_Gastos_conTarjeta()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();

            double subimporte = 0;
            data = obj.CN_Calcular_Gastos_TipoPago("Deposito");
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    subimporte = subimporte + Convert.ToDouble(dr["ImporteCaja"]);
                }
                txt_salida_deposito.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_salida_deposito.Text = "00";
            }
        }


        private void Buscar_Gastos_conEfectivo()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();

            double subimporte = 0;
            data = obj.CN_Calcular_Gastos_TipoPago("Efectivo");
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    subimporte = subimporte + Convert.ToDouble(dr["ImporteCaja"]);
                }
                txt_salida_efectivo.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_salida_efectivo.Text = "00";
            }
        }



        private void Calcular_Utilidad()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();

            double subimporte = 0;
            data = obj.CN_Calcular_Ganancias_deldia();
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    subimporte = subimporte + Convert.ToDouble(dr["TotalUti"]);
                }
                txt_utilidad_calcular.Text = subimporte.ToString("###0.00");
            }
            else
            {
                txt_utilidad_calcular.Text = "00";
            }
        }


        private void btn_CerarCaja_Click(object sender, EventArgs e)
        {
            Registrar_Cierre_Caja();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            double TotalGastos = 0;
            double IngresoBruto = 0;
            double VentaNeto = 0;

            try
            {
                IngresoBruto = Convert.ToDouble(txt_notaventa.Text) + Convert.ToDouble(txt_boleta.Text) + Convert.ToDouble(txt_factura.Text) + Convert.ToDouble(txt_otros.Text);
                txt_total_ingreso.Text = IngresoBruto.ToString("###0.00");

                TotalGastos = Convert.ToDouble(txt_salida_efectivo.Text) + Convert.ToDouble(txt_salida_deposito.Text);
                txt_total_salida.Text = TotalGastos.ToString("###0.00");
                txt_total_egreso.Text = txt_salida_efectivo.Text;

                //La venta Real
                VentaNeto = IngresoBruto - Convert.ToDouble(txt_salida_efectivo.Text);
                txt_ingreso_efectivo.Text = VentaNeto.ToString("###0.00");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void txt_total_entregar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_total_entregar.Text)) return; // Evita el error si está vacío
            try
            {
                double ingresoEfectivo = 0;
                double totalEntregar = 0;

                double.TryParse(txt_ingreso_efectivo.Text, out ingresoEfectivo);
                double.TryParse(txt_total_entregar.Text, out totalEntregar);

                txt_saldo_siguiente.Text = (ingresoEfectivo - totalEntregar).ToString("###0.00");
            }
            catch { /* Manejo de error silencioso o log */ }
        }



        private void Registrar_Cierre_Caja()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            Cierre_Caja ca = new Cierre_Caja();
            CN_Caja objca = new CN_Caja();
            Filtro filtro = new Filtro();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            frm_Advertencia ver = new frm_Advertencia();

            int idCaja = 0;
         
            try
            {

                ca.Id_cierre = txt_idCaja.Text;
                ca.Apertura_Caja = Convert.ToDouble(txt_aperturaCaja.Text);
                ca.Total_Ingreso = Convert.ToDouble(txt_ingreso_efectivo.Text);
                ca.TotalEgreso = Convert.ToDouble(txt_total_salida.Text);
                ca.Id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                ca.TodoDeposito = Convert.ToDouble(txt_tarjeta.Text);
                ca.Gananciadeldia = Convert.ToDouble(txt_utilidad_calcular.Text);
                ca.TotalEntregado = Convert.ToDouble(txt_total_entregar.Text);
                ca.SaldoSiguiente = Convert.ToDouble(txt_saldo_siguiente.Text);
                ca.TotalFactura = Convert.ToDouble(txt_factura.Text); 
                ca.TotalBoleta = Convert.ToDouble(txt_boleta.Text);
                ca.TotalNotaVenta = Convert.ToDouble(txt_notaventa.Text);
                ca.TotalCreditoCobrado = 0;
                ca.TotalCreditoEmitido = 0;

                obj.CN_Registrar_Cierre_Caja(ca);
                if (CD_CierreCaja.saved == true)
                {
                    for (int i = 0; i < lsv_Caja.Items.Count; i++)
                    {
                       var lis = lsv_Caja.Items[i];
                       idCaja = Convert.ToInt32(lis.SubItems[0].Text);
                       objca.CN_CambiarModo_Caja(idCaja);
                    }

                   frm_print_Informe coti = new frm_print_Informe();

                    filtro.Show();
                    coti.NrDoc = txt_idCaja.Text;
                    coti.TipoDoc = "cierrecaja";
                    coti.ShowDialog(this);
                    Limpiar_Totales();
                    lsv_Caja.Items.Clear();
                    filtro.Hide();

                    ok.Lbl_msm1.Text = "¡Caja cerrada con éxito!";
                    ok.ShowDialog(this);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al cerrar caja debe agregar el Total a Entregar: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Limpiar_Totales()
        {
            txt_boleta.Text = "0.00";
            txt_factura.Text = "0.00";
            txt_notaventa.Text = "0.00";
            txt_otros.Text = "0.00";
            txt_tarjeta.Text = "0.00";

            txt_salida_efectivo.Text = "0.00";
            txt_salida_deposito.Text = "0.00";

            txt_total_ingreso.Text = "0.00";
            txt_total_salida.Text = "0.00";
            txt_total_egreso.Text = "0.00";
            txt_ingreso_efectivo.Text = "0.00";

            txt_total_entregar.Text = "0.00";
            txt_saldo_siguiente.Text = "0.00";
            txt_utilidad_calcular.Text = "0.00";
        }
    }
}
