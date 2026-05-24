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
    public partial class frm_BuscarProducto : Form
    {
        public frm_BuscarProducto()
        {
            InitializeComponent();
        }

        public string tipobusqueda = "";
        private void Menu_Producto_Load(object sender, EventArgs e)
        {
            Configura_ListView();
            Mostrar_Producto();
        }
        //------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA LLAMADO ---------------------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }


        //-------------------------------------- METODO CONFIGURAR LISTVIEW ---------------------------------------//
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
            lis.Columns.Add("ID", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Descripción del Producto", 240, HorizontalAlignment.Left);
            lis.Columns.Add("Presentacion", 130, HorizontalAlignment.Left);
            lis.Columns.Add("Stock", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Pre-Compra", 0, HorizontalAlignment.Right);
            lis.Columns.Add("Precio-Venta", 120, HorizontalAlignment.Right);
            lis.Columns.Add("Utilidad", 0, HorizontalAlignment.Right);
            lis.Columns.Add("Costo Total", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Estado", 105, HorizontalAlignment.Left);
            lis.Columns.Add("Principio Activo", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Laboratorio", 147, HorizontalAlignment.Left);
            lis.Columns.Add("Foto", 0, HorizontalAlignment.Left);
        }

        private void PintasFilas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_prod.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_prod.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;
            }
        }
        //----------------------------------------- METODO LLENAR LISTVIEW ----------------------------------------//
        private void LLenar_Lisview_Producto(DataTable data)
        {
            lsv_prod.Items.Clear();
            double preventa = 0;
            double precompra = 0;
            double valoralmacen = 0;
            double frank = 0;
            double utili = 0;
            double xstock = 0;
            for (int i = 0; i < data.Rows.Count; i++) 
            {
                DataRow dr = data.Rows[i];
                xstock = Convert.ToDouble(dr["Stock_Actual"]);
                if (chk_todo.Checked == true) 
                {
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
                else 
                {
                    if(xstock > 0)
                    {
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
                }
        
            }
            pnl_resul.Visible = false;
            PintasFilas();
        }


        //-------------------------------------- METODO MOSTRAR PRODUCTOS -----------------------------------------//
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


        //----------------------------- METODO LLAMAR DESDE EL LBL MOSTRAR PRODUCTO -------------------------------//
        private void lbl_new_Click(object sender, EventArgs e)
        {
            Mostrar_Producto();
        }


        //--------------------------------------- METODO BUSCAR PRODUCTOID ----------------------------------------//
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


        //---------------------------------------- METODO BUSCAR PRODUCTO -----------------------------------------//
        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_ProductoID(txt_buscar.Text);
                
            }
        }


        //---------------------------------------- METODO CERRAR PRODUCTO -----------------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //----------------------------- EVENTO MOUSEDOBLECLICK SELECIONAR PRODUCTO --------------------------------//
        private void lsv_prod_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SeleccionarProducto();
        }


        //------------------------------------ METODO SELECIONAR PRODUCTO -----------------------------------------//
        private void SeleccionarProducto()
        {
            if (lsv_prod.SelectedItems.Count == 0) return;
            var lis = lsv_prod.SelectedItems[0];
            string idproducto = "";
            double xstock = 0;
            idproducto = lis.SubItems[0].Text;
            xstock = Convert.ToDouble(lis.SubItems[3].Text);
            lbl_idprod.Text = idproducto;
            if(tipobusqueda.Trim() == "compra") 
            {
                this.Tag = "A";
                this.Close();
            }
            else
            {
                if (xstock > 0)
                {
                    this.Tag = "A";
                    this.Close();
                }
            }
        }


        //-------------------------------- EVENTO KEYDOWN PARA SELECIONAR PRODUCTOS--------------------------------//
        private void lsv_prod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
            }
        }


        //------------------------------- METODO BUSCAR PRODUCTO DESDE EL EVENTO ----------------------------------//
        private void frm_BuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1) 
            {
                txt_buscar.Text ="";
                txt_buscar.Focus();
            }
        }

        //---------------------------- METODO EVENTO KEYDOWN PARA BUSCAR UN PRODUCTOS------------------------------//
        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                if (txt_buscar.Text.Trim().Length > 2)
                {
                    Buscar_ProductoID(txt_buscar.Text);
                    if (lsv_prod.Items.Count > 0)
                    {
                        lsv_prod.Items[0].Selected = true;
                        lsv_prod.Focus();
                    }
                }
                else
                {
                    Mostrar_Producto();
                    if (lsv_prod.Items.Count > 0)
                    {
                        lsv_prod.Items[0].Selected = true;
                        lsv_prod.Focus();
                    }
                }
            }


            if(e.KeyCode == Keys.Down) 
            {
                if (lsv_prod.Items.Count > 0)
                {
                    lsv_prod.Items[0].Selected = true;
                    lsv_prod.Focus();
                }
            }
        }


        //----------------------------- METODO MOSTRAR TODOS LOS PRODUCTOS DESDE EL CHK ---------------------------//
        private void chk_todo_CheckedChanged_1(object sender, EventArgs e)
        {
            Mostrar_Producto();
        }

        private void pnl_resul_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
