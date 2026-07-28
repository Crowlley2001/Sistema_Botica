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

namespace CapaPresentacion.Producto
{
    public partial class frm_Menu_Producto : Form
    {
        public frm_Menu_Producto()
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
            lis.Columns.Add("ID", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Descripción del Articulo", 240, HorizontalAlignment.Left);
            lis.Columns.Add("Cant", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Precio", 100, HorizontalAlignment.Right);
            lis.Columns.Add("Importe", 100, HorizontalAlignment.Right);
            lis.Columns.Add("Utilidad Unitaria", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Importe Utilitario", 0, HorizontalAlignment.Left);
            lis.Columns.Add("TotalDscto", 132, HorizontalAlignment.Left);
        }

        //----------------------------- LLENAR LISTVIEW PRODUCTO-------------------------------//
        private void LLenar_Lisview_Producto(DataTable data)
        {
            lsv_prod.Items.Clear();
            double preventa = 0;
            double precompra = 0;
            double valoralmacen = 0;
            double utili = 0;
            for (int i = 0; i < data.Rows.Count; i++) 
            {
                DataRow dr = data.Rows[i];
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[6].ToString());

                item.SubItems.Add(dr["Stock_Actual"].ToString());
                precompra = Convert.ToDouble(dr["Pre_CompraS"].ToString());
                item.SubItems.Add(precompra.ToString("###0.00"));
                preventa = Convert.ToDouble(dr["Pre_venta"]);
                item.SubItems.Add(preventa.ToString("###0.00"));
                utili = Convert.ToDouble(dr["UtilidadUnit"]);
                item.SubItems.Add(utili.ToString("###0.00"));
                valoralmacen = Convert.ToDouble(dr["Valor_porCant"]);
                item.SubItems.Add(valoralmacen.ToString("###0.00"));
                item.SubItems.Add(dr["Estado_Pro"].ToString());
                item.SubItems.Add(dr["Laboratorio"].ToString());
                item.SubItems.Add(dr["Prin_Acti"].ToString());
                item.SubItems.Add(dr["Foto"].ToString());

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
            string valor = txt_buscar.Text.Trim();
            if (valor.Length == 0)
            {
                Mostrar_Producto();
            }
            else if (valor.Length >= 2)
            {
                Buscar_ProductoID(valor);
            }
        }

        //---------------------------- EVENTO KEYDOWN DEL LISTVIEW-----------------------------//
        private void lsv_prod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscar.Text.Trim().Length >= 2)
                {
                    Buscar_ProductoID(txt_buscar.Text);
                }
                else
                {
                    Mostrar_Producto();
                }
            }
        }

        //------------------------- BOTON MOSTRAR TODOS LOS PRODUCTOS--------------------------//
        private void bt_mostrarTodosLosProductosTool_Click(object sender, EventArgs e)
        {
            Mostrar_Producto();
        }

        //------------------------- BOTON REGISTRAR NUEVO PRODUCTO-----------------------------//
        private void bt_registrarNuevoProductoTool_Click(object sender, EventArgs e)
        {
            frmProducto pro = new frmProducto();
            pro.ShowDialog();
        }

        //----------------------------- BOTON EDITAR ESTE PRODUCTO-----------------------------//
        private void bt_editarEsteProductoTool_Click(object sender, EventArgs e)
        {
            frmEditarProducto pro = new frmEditarProducto();
            if (lsv_prod.SelectedItems.Count == 0) return;
            string idproducto = "";
            var lis = lsv_prod.SelectedItems[0];
            idproducto = lis.SubItems[0].Text;
            pro.Tag = idproducto;
            pro.ShowDialog();

        }

        //--------------------------- BOTON COPIAR ID DEL PRODUCTO-----------------------------//
        private void bt_copiarIdDelProductoTool_Click(object sender, EventArgs e)
        {
            if (lsv_prod.SelectedItems.Count == 0) return;
            var lis = lsv_prod.SelectedItems[0];
            string idproducto = "";
            idproducto = lis.SubItems[0].Text;

            Clipboard.Clear();
            Clipboard.SetText(idproducto);
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
    }
}
