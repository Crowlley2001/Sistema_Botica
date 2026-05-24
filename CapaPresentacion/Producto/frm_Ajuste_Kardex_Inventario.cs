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

namespace CapaPresentacion.Producto
{
    public partial class frm_Ajuste_Kardex_Inventario : Form
    {
        public frm_Ajuste_Kardex_Inventario()
        {
            InitializeComponent();
        }

        private void Menu_Producto_Load(object sender, EventArgs e)
        {
            Configura_ListView();
            Mostrar_Producto();
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
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            //Aggar columnas a mi ListView
            lis.Columns.Add("ID", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Descripción del Producto", 265, HorizontalAlignment.Center);
            lis.Columns.Add("Stock", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Pre-Venta", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Pre-Compra", 132, HorizontalAlignment.Center);
        }

        //----------------------------- LLENAR LISTVIEW PRODUCTO-------------------------------//
        private void LLenar_Lisview_Producto(DataTable data)
        {
            lsv_prod.Items.Clear();
            double preventa = 0;
            double precompra = 0;
            for (int i = 0; i < data.Rows.Count; i++) 
            {
                DataRow dr = data.Rows[i];
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
     

                item.SubItems.Add(dr["Stock_Actual"].ToString());
                preventa = Convert.ToDouble(dr["Pre_venta"]);
                item.SubItems.Add(preventa.ToString("###0.00"));
                item.SubItems.Add(dr["Estado_Pro"].ToString());
                precompra = Convert.ToDouble(dr["Pre_CompraS"]);
                item.SubItems.Add(precompra.ToString("###0.00"));
              
                lsv_prod.Items.Add(item);
            }
            pnl_resul.Visible = false;
        }

        //-------------------------------- MOSTRAR PRODUCTO------------------------------------//
        private void Mostrar_Producto()
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();
            data = obj.CargarTodos_Productos();
            if(data.Rows.Count > 0)
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
        private void Buscar_ProductoID(string valor)
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();
            data = obj.BuscarProductoID(valor);
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

        //------------------------ EVENTO TEXTCHANGED DEL TEXBOX BUSCAR------------------------//
        private void txt_buscar_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_ProductoID(txt_buscar.Text);
            }
        }

        //---------------------------- EVENTO KEYDOWN DEL LISTVIEW-----------------------------//
        private void lsv_prod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
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

        //--------------------------- CHK NUEVO PRODUCTO LISTA TODO----------------------------//
        private void chk_todo_CheckedChanged(object sender, EventArgs e)
        {
            Mostrar_Producto();
        }

        private void SeleccionarProducto()
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            CN_Producto obj = new CN_Producto();
            frm_editCant cant = new frm_editCant();

            double xcant = 0;
            if(lsv_prod.SelectedIndices.Count == 0)
            {
                filtro.Show();
                ver.lbl_msm.Text = "¿Desea realizar un ajuste de inventario para el producto seleccionado?";
                ver.ShowDialog(this);
                filtro.Hide();
            }
            else
            {
                var lis = lsv_prod.SelectedItems[0];
                string idprod = lis.SubItems[0].Text;
                double stockProd = Convert.ToDouble(lis.SubItems[2].Text);
                double precompra = Convert.ToDouble(lis.SubItems[5].Text);

                filtro.Show();
                cant.txt_stockActual.Text = stockProd.ToString();
                cant.txt_precompra.Text = precompra.ToString();
                cant.ShowDialog(this);
                filtro.Hide();

                if (cant.Tag != null && cant.Tag.ToString() == "A")
                {
                    double importe = Convert.ToDouble(cant.txt_importe.Text);
                    string cantDiferencia = cant.txt_dife.Text;

                    xcant = Convert.ToDouble(cant.txt_cantStock.Text);
                    obj.CN_Igualar_Stock_Producto(idprod, xcant);
                    Registrar_MovimientoKardex(idprod, xcant, cantDiferencia, importe);
                   
                    int i;
                    var liv = lsv_prod.SelectedItems[0];
                    for (i = lsv_prod.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_prod.Items.Remove(lsv_prod.SelectedItems[i]);
                    }
                }
            }

        }


        private void Registrar_MovimientoKardex(string xidprod, double xcant, string cantDiferen, double precioDiferen)
        {
            CN_Kardex obj = new CN_Kardex();
            Detalle_Kardex kar = new Detalle_Kardex();
            CN_Producto objpro = new CN_Producto();
            DataTable dato = new DataTable();
            DataTable datopro = new DataTable();
            DataTable datapro2 = new DataTable();



            string xidkardex = "";
            int item = 0;
            double stockprod = 0;
            double precioCompraProd = 0;
            try
            {
                if (obj.Verificar_Kardex_Producto(xidprod) == true)
                {
                    dato = obj.BuscarKardexPorValor(xidprod.Trim());
                    if (dato.Rows.Count > 0)
                    {
                        xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                        item = dato.Rows.Count;

                        datopro = objpro.BuscarProductoID(xidprod.Trim());
                        stockprod = Convert.ToDouble(datopro.Rows[0]["Stock_Actual"]);
                        precioCompraProd = Convert.ToDouble(datopro.Rows[0]["Pre_CompraS"]);

                        //Registramos el detalle de Kardex
                        kar.IdKardex = xidkardex;
                        kar.Item = item + 1;
                        kar.Doc_soporte = "D000-001";
                        kar.Det_Operacion = "Ajuste de Kardex Manual";
                        //Entrada
                        kar.Cantidad_In = 0;
                        kar.Precio_In = 0;
                        kar.Total_In = 0;
                        //Salida
                        kar.Cantidad_Out = xcant;
                        kar.Precio_Out = precioCompraProd;
                        kar.Total_Out = xcant * precioCompraProd;
                        //Saldos
                        kar.Cantidad_saldo = xcant;
                        kar.Promedio = precioCompraProd;
                        kar.Total_saldo = precioCompraProd * kar.Cantidad_saldo;
                        kar.Idusu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                        kar.Tipo_operacion = "Reset";

                        kar.Cant_diferencial = cantDiferen;
                        kar.ImporteDiferente = precioCompraProd;
                        obj.Registrar_DetalleKardex(kar);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lsv_prod_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SeleccionarProducto();
        }
    }
}
