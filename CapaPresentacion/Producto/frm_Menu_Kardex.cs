using CapaNegocio;
using CapaPresentacion.Factura;
using CapaPresentacion.Ventas;
using MSistemaBotica_C.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Producto
{
    public partial class frm_Menu_Kardex : Form
    {
        public string directo = "-";
        public DateTime fechadia;
        public frm_Menu_Kardex()
        {
            InitializeComponent();
            ConfigurarPanelTotales();
        }

        private void Menu_Producto_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            dtp_fechaKardex.Value = hoy;
            dtp_hoy.Value = hoy;
            if (directo.Trim() == "desde")
            {
                Configura_ListView();
                Listar_Producto_SinStock_PorVenta(fechadia);
            }
            else
            {
                chk_mostrar_todo.Checked = true;
                Configura_ListView();
                Buscar_Kardex_delDia(hoy);
            }
        }
        //----------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA LLAMADO----------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        //------------------------------ CONFIGURAR LISTVIEW ----------------------------------//
        private void Configura_ListView()
        {
            var lis = lsv_prod;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            //Aggar columnas a mi ListView
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Item", 60, HorizontalAlignment.Center);
            lis.Columns.Add("Fecha Emision", 160, HorizontalAlignment.Center);
            lis.Columns.Add("Doc Soporte", 140, HorizontalAlignment.Center);
            lis.Columns.Add("Detalle Movimiento", 130, HorizontalAlignment.Center);
            lis.Columns.Add("Entradas", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Salidas", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Saldos", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Id Prod", 0, HorizontalAlignment.Center);
            lis.Columns.Add("Operacion", 100, HorizontalAlignment.Center);

            if(chk_mostrar_todo.Checked == true)
            {
                lis.Columns.Add("Unds In/Out", 100, HorizontalAlignment.Center);
                lis.Columns.Add("Importe", 100, HorizontalAlignment.Center);
            }
            else
            {
                lis.Columns.Add("Producto", 240, HorizontalAlignment.Center);
                lis.Columns.Add("Vendedor", 125, HorizontalAlignment.Center);
            }
        }

        //----------------------------- LLENAR LISTVIEW PRODUCTO-------------------------------//
        private void LLenar_Lisview_Producto(DataTable data)
        {
            lsv_prod.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++) 
            {
                DataRow dr = data.Rows[i];
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                item.SubItems.Add(dr[4].ToString());
                item.SubItems.Add(NormalizarDetalleMovimiento(dr[5].ToString()));
                item.SubItems.Add(FormatearNumeroKardex(dr[6]));
                item.SubItems.Add(FormatearNumeroKardex(dr[9]));
                item.SubItems.Add(FormatearNumeroKardex(dr[12]));
                item.SubItems.Add(dr[18].ToString());
                item.SubItems.Add(dr[15].ToString());

                if (chk_mostrar_todo.Checked == true)
                {
                    item.SubItems.Add(dr["Cant_Difncial"].ToString());
                    item.SubItems.Add(FormatearNumeroKardex(dr["ImportDiferen"]));
                  
                }
                else
                {
                    item.SubItems.Add(dr["Descripcion_Larga"].ToString());
                    item.SubItems.Add(dr["Nombres"].ToString());
                }

                lsv_prod.Items.Add(item);
            }
            pnl_resul.Visible = false;
            lbl_TotalItem.Text = lsv_prod.Items.Count.ToString();
        
           

            // 🔹 Mostrar totales solo cuando está marcado "Ver Todos"
            group_totales.Visible = chk_mostrar_todo.Checked;

            // 🔹 Calcular totales si corresponde
            if (chk_mostrar_todo.Checked)
            {
                Calcular_Totales();
                btn_save.Enabled = lsv_prod.Items.Count > 0;
            }

            // 🔹 ASEGURAR QUE EL BOTÓN QUEDE ENCIMA DEL GROUPBOX
            btn_save.BringToFront();
        }


        private void Calcular_Totales()
        {
            decimal totalEntradas = 0m;
            decimal totalSalidas = 0m;

            try
            {
                // 🔹 Validar que existan items
                if (lsv_prod.Items.Count == 0)
                {
                    MessageBox.Show("No hay datos para calcular.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int i = 0; i < lsv_prod.Items.Count; i++)
                {
                    // Entradas y Salidas ocupan las posiciones 5 y 6.
                    if (lsv_prod.Items[i].SubItems.Count <= 6)
                        continue;

                    totalEntradas += ConvertirDecimalSeguro(
                        lsv_prod.Items[i].SubItems[5].Text);
                    totalSalidas += ConvertirDecimalSeguro(
                        lsv_prod.Items[i].SubItems[6].Text);
                }

                txt_totalpositivo.Text = totalEntradas.ToString("N3");
                txt_totalnegativo.Text = totalSalidas.ToString("N3");
                label5.Text = "Total entradas";
                label4.Text = "Total salidas";

                group_totales.Visible = true;
                btn_save.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular totales: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static decimal ConvertirDecimalSeguro(string texto)
        {
            decimal valor;
            if (decimal.TryParse(texto, NumberStyles.Number,
                CultureInfo.CurrentCulture, out valor))
                return valor;

            if (decimal.TryParse(texto, NumberStyles.Number,
                CultureInfo.InvariantCulture, out valor))
                return valor;

            return 0m;
        }

        private static string FormatearNumeroKardex(object valor)
        {
            if (valor == null || valor == DBNull.Value)
                return "0.000";

            decimal numero;
            string texto = Convert.ToString(valor);
            if (decimal.TryParse(texto, NumberStyles.Any,
                    CultureInfo.CurrentCulture, out numero) ||
                decimal.TryParse(texto, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out numero))
            {
                return numero.ToString("N3");
            }

            return texto;
        }

        private void ConfigurarPanelTotales()
        {
            group_totales.AutoScroll = false;

            txt_totalpositivo.Location = new Point(12, 36);
            txt_totalpositivo.Size = new Size(122, 27);
            txt_totalpositivo.TextAlign = HorizontalAlignment.Center;
            txt_totalpositivo.ReadOnly = true;
            txt_totalpositivo.Cursor = Cursors.Default;

            txt_totalnegativo.Location = new Point(149, 36);
            txt_totalnegativo.Size = new Size(122, 27);
            txt_totalnegativo.TextAlign = HorizontalAlignment.Center;
            txt_totalnegativo.ReadOnly = true;
            txt_totalnegativo.Cursor = Cursors.Default;

            label5.AutoSize = false;
            label5.Location = new Point(12, 19);
            label5.Size = new Size(122, 17);
            label5.TextAlign = ContentAlignment.MiddleCenter;

            label4.AutoSize = false;
            label4.Location = new Point(149, 19);
            label4.Size = new Size(122, 17);
            label4.TextAlign = ContentAlignment.MiddleCenter;
        }


        private void Buscar_Movmiento_de_ProductoID(string valor)
        {
            CN_Kardex obj = new CN_Kardex();
            DataTable data = new DataTable();
            data = obj.BuscarKardexPorValor(valor);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_Producto(data);
            }
            else
            {
                pnl_resul.Visible = true;
                lsv_prod.Items.Clear();
                lbl_TotalItem.Text = "0";
                txt_totalpositivo.Text = "0.00";
                txt_totalnegativo.Text = "0.00";
            }
        }



        //------------------------------- BUSCAR PRODUCTO ID-----------------------------------//
        private void Listar_Producto_SinStock_PorVenta(DateTime fecha)
        {
            CN_Kardex obj = new CN_Kardex();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Productos_SinStock_porVenta(fecha);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_Producto(data);
            }
            else
            {
                pnl_resul.Visible = true;
                lsv_prod.Items.Clear();
            }
        }


        private void Buscar_Kardex_delDia(DateTime dia)
        {
            CN_Kardex obj = new CN_Kardex();
            DataTable data = new DataTable();
            data = obj.CN_Buscar_DetallesKardex_PorDia(dia);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_Producto(data);
            }
            else
            {
                lsv_prod.Items.Clear();
                pnl_resul.Visible = true;
            }
        }

        //------------------------ EVENTO TEXTCHANGED DEL TEXBOX BUSCAR------------------------//
        private void txt_buscar_TextChanged_1(object sender, EventArgs e)
        {
            string valor = txt_buscar.Text.Trim();
            if (valor.Length == 0)
            {
                Buscar_Kardex_delDia(dtp_fechaKardex.Value.Date);
            }
            else if (valor.Length >= 2)
            {
                Buscar_Movmiento_de_ProductoID(valor);
            }
        }

        //---------------------------- EVENTO KEYDOWN DEL LISTVIEW-----------------------------//
        private void lsv_prod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_Movmiento_de_ProductoID(txt_buscar.Text);
                }
            }
        }

        private void dtp_fechaKardex_ValueChanged(object sender, EventArgs e)
        {
            Buscar_Kardex_delDia(dtp_fechaKardex.Value.Date);
        }

        private static string NormalizarDetalleMovimiento(string texto)
        {
            string valor = (texto ?? string.Empty).Trim();
            if (valor.IndexOf("Venta al", StringComparison.OrdinalIgnoreCase) >= 0 &&
                valor.IndexOf("blico", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Venta al Público";
            return valor;
        }


        private void Copiar_IdKardexStripMenuItem2_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_softmsm msm = new frm_softmsm();

            if (lsv_prod.SelectedIndices.Count == 0)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Seleciona el Item que desea Copiar";
                ver.ShowDialog(this);
                filtro.Hide();
            }
            else
            {
                var lis = lsv_prod.SelectedItems[0];
                string idProd = lis.SubItems[8].Text;
                Clipboard.Clear();
                Clipboard.SetText(idProd.Trim());
                msm.Lbl_msm.Text = "El item fue Copiado al Portapapeles";
                msm.ShowDialog(this);
            }
        }


        private void Calcular_Valor_KardexStripMenuItem3_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_softmsm msm = new frm_softmsm();

            if (lsv_prod.SelectedIndices.Count == 0)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Seleciona el Item que desea Copiar";
                ver.ShowDialog(this);
                filtro.Hide();
            }
            else
            {
                var lis = lsv_prod.SelectedItems[0];
                string idProd = lis.SubItems[3].Text;
                Clipboard.Clear();
                Clipboard.SetText(idProd.Trim());
                msm.Lbl_msm.Text = "El item fue Copiado al Portapapeles";
                msm.ShowDialog(this);
            }
        }


        private void Ver_Movimientos_KardexStripMenuItem1_Click(object sender, EventArgs e)
        {
            Buscar_Kardex_delDia(dtp_fechaKardex.Value = DateTime.Now);
        }

        private void verProductosDeNivelacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_SoloFecha_2 solo = new frm_SoloFecha_2();

            filtro.Show();
            solo.ShowDialog(this);
            filtro.Hide();

            if(solo.Tag != null && solo.Tag.ToString() == "A")
            {
                DateTime desde1 = solo.dtp_fn.Value;
                DateTime hasta1 = solo.dtp_ht.Value;

                chk_mostrar_todo.Checked = true;
                Configura_ListView();

                Listar_Producto_conAjuste_Inventario(desde1, hasta1, "Reset");
            }
        }



        private void Listar_Producto_conAjuste_Inventario(DateTime desde, DateTime hasta, string valor)
        {
            CN_Kardex obj = new CN_Kardex();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Productos_QueTuvieron_ajusteInver(desde, hasta, valor);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_Producto(data);
            }
            else
            {
                pnl_resul.Visible = true;
                lsv_prod.Items.Clear();
            }
        }


        //----------------------------- BOTON CERRAR FORMULARIO--------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //----------------------------- BOTON MINIMIZAR FORMULARIO-----------------------------//
        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
    }
}
