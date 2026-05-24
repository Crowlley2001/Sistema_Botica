using CapaNegocio;
using CapaPresentacion.Factura;
using CapaPresentacion.Ventas;
using MSistemaBotica_C.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void Menu_Producto_Load(object sender, EventArgs e)
        {
            dtp_fechaKardex.Value = dtp_hoy.Value;
            if (directo.Trim() == "desde")
            {
                Configura_ListView();
                Listar_Producto_SinStock_PorVenta(fechadia);
            }
            else
            {
                Configura_ListView();
            }

            //         FECHA - ACTUAL         //
            dtp_fechaKardex.Value = DateTime.Now;
            dtp_hoy.Value = DateTime.Now;
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
                item.SubItems.Add(dr[5].ToString());
                item.SubItems.Add(dr[6].ToString());
                item.SubItems.Add(dr[9].ToString());
                item.SubItems.Add(dr[12].ToString());
                item.SubItems.Add(dr[18].ToString());
                item.SubItems.Add(dr[15].ToString());

                if (chk_mostrar_todo.Checked == true)
                {
                    item.SubItems.Add(dr["Cant_Difncial"].ToString());
                    item.SubItems.Add(dr["ImportDiferen"].ToString());
                  
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
            int cont = 1;
            double cant = 0;
            double importPosito = 0;
            double importNegativo = 0;

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
                    // 🔹 Validar que existan las columnas necesarias
                    if (lsv_prod.Items[i].SubItems.Count <= 11)
                        continue;

                    string txtCant = lsv_prod.Items[i].SubItems[10].Text.Trim();
                    string txtImporte = lsv_prod.Items[i].SubItems[11].Text.Trim();

                    // 🔹 Validar que no estén vacíos
                    if (string.IsNullOrEmpty(txtCant) || string.IsNullOrEmpty(txtImporte))
                        continue;

                    // 🔹 Validar conversión segura
                    if (!double.TryParse(txtCant, out cant))
                        continue;

                    double importe = 0;
                    if (!double.TryParse(txtImporte, out importe))
                        continue;

                    if (cant > 0)
                    {
                        importPosito += importe;
                    }
                    else
                    {
                        importNegativo += importe;
                    }

                    cont += 1;
                }

                txt_totalnegativo.Text = importNegativo.ToString("###0.00");
                txt_totalpositivo.Text = importPosito.ToString("###0.00");

                group_totales.Visible = true;
                btn_save.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular totales: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_Movmiento_de_ProductoID(txt_buscar.Text);
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
            Buscar_Kardex_delDia(dtp_fechaKardex.Value = DateTime.Now);
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
