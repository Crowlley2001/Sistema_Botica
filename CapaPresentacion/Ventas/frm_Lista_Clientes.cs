using CapaDatos;
using CapaEntidad;
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

namespace CapaPresentacion.Ventas
{
    public partial class frm_Lista_Clientes : Form
    {
        public frm_Lista_Clientes()
        {
            InitializeComponent();
        }
        //----------------------------- METODO LLAMAR FUNCIONES DESDE INICIO --------------------------------//
        public static string tipo = "";
        private void frm_Lista_Clientes_Load_1(object sender, EventArgs e)
        {
            Configura_ListView();
            Cargar_Todos_LosClientes();
            txt_buscar.Focus();
            //         FECHA - ACTUAL         //
            dtp_fn.Value = DateTime.Now;
        }

        //--------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA ---------------------//
        private void pnl_titu_MouseMove_1(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }


        //------------------------ EVENTO KEYDOWN LISTVIEW PARA SELECCIONAR CLIENTE -------------------------//
        private void Lsv_Cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar_Cliente();
            }
        }


        //-------------------- EVENTO MOUSEDOBLECLICK LISTVIEW PARA SELECCIONAR CLIENTE ---------------------//
        private void Lsv_Cliente_MouseDoubleClick_2(object sender, MouseEventArgs e)
        {
            Seleccionar_Cliente();
        }


        //------------------------------- METODO CONFIGURAR LISTVIEW CLIENTE --------------------------------//
        private void Configura_ListView()
        {
            var lis = Lsv_Cliente;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            //Aggar columnas a mi ListView
            lis.Columns.Add("ID", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Nomnbre o Razon Social", 380, HorizontalAlignment.Left);
            lis.Columns.Add("RUC", 130, HorizontalAlignment.Center);
            lis.Columns.Add("Estado", 78, HorizontalAlignment.Center);
            lis.Columns.Add("Direccion", 0, HorizontalAlignment.Left);
        }


        //--------------------------------- METODO LLENAR LISTVIEW CLIENTE ----------------------------------//
        private void LLenar_Lisview_Producto(DataTable data)
        {
            Lsv_Cliente.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem item = new ListViewItem(dr[0].ToString());
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr["Estado_Cli"].ToString());
                item.SubItems.Add(dr["Direccion"].ToString());
                Lsv_Cliente.Items.Add(item);
            }
            PintasFilas();
            //pnl_resul.Visible = false;
        }


        //--------------------------------- METODO PINTAR LISVIW CLIENTE ------------------------------------//
        private void PintasFilas()
        {
            int cont = 1;
            for (int i = 0; i < Lsv_Cliente.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {
                   
                }
                else
                {
                    Lsv_Cliente.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont+= 1;
            }
        }


        //------------------------------- METODO CARGAR TODOS LOS CLIENTES ----------------------------------//
        private void Cargar_Todos_LosClientes()
        {
            CN_Cliente obj_Cliente = new CN_Cliente();
            DataTable dt = new DataTable();
            dt = obj_Cliente.Vertodos_los_Clientes("Todos");
            if(dt.Rows.Count > 0)
            {
                LLenar_Lisview_Producto(dt);
                if(Lsv_Cliente.Items.Count > 0)
                {
                    Lsv_Cliente.Items[0].Selected = true;
                    Lsv_Cliente.Focus();
                }
            }
            else
            {
                Lsv_Cliente.Items.Clear();
            }
        }

        //----------------------------------- METODO PARA BUSCAR CLIENTE ------------------------------------//
        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 2)
            {
                Buscar_Cliente(txt_buscar.Text);
            }
        }


        //------------------------------------- METODO BUSCAR CLIENTE ---------------------------------------//
        public void Buscar_Cliente(string valor)
        {
            CN_Cliente obj_Cliente = new CN_Cliente();
            DataTable dt = new DataTable();
            dt = obj_Cliente.Buscar_Clientes_PorValor(valor);
            if (dt.Rows.Count > 0)
            {
                LLenar_Lisview_Producto(dt);
            }
            else
            {
                Lsv_Cliente.Items.Clear();
            }
        }



        //----------------------------------- METODO SELECIONAR CLIENTE -------------------------------------//
        private void Seleccionar_Cliente()
        {
            if(Lsv_Cliente.SelectedIndices.Count == 0)
            {

            }
            else
            {
                var lis = Lsv_Cliente.SelectedItems[0];
                lbl_id.Text = lis.SubItems[0].Text;       
                lbl_nom.Text = lis.SubItems[1].Text;       
                lbl_ruc.Text = lis.SubItems[2].Text;      
                lbl_direccion.Text = lis.SubItems[4].Text; 
                this.Tag = "A";
                this.Close();
            }
        }


        //------------------------------------ METODO GENERARID CLIENTE -------------------------------------//
        private string GenerarIdCliente(string estadox)
        {
            CN_Cliente obj_Cliente = new CN_Cliente();
            DataTable dt = new DataTable();

            dt = obj_Cliente.Vertodos_los_Clientes(estadox);
            string idcliente = "";
            string nroextraido = txt_ruc.Text.Substring(1, 6);

            if (dt.Rows.Count > 0)
            {
                idcliente = "C-" + nroextraido + (dt.Rows.Count + 1);
            }
            else
            {
                idcliente = "C-" + nroextraido + "1";
            }
            return idcliente;

        }


        //------------------------------------- METODO LIMPIAR CLIENTE --------------------------------------//
        private void LimpiarForm()
        {
            txt_id.Text = "";
            txt_nombre.Text = "";
            txt_ruc.Text = "";
            txt_direccion.Text = "";
        }


        //------------------------------------- METODO VALIDAR TEXBOX ---------------------------------------//
        private bool Validar_TexToBox()
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            if (txt_id.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Ingresa o Genera el Id del Cliente"; ver.ShowDialog();filtro.Hide();return false; }
            if (txt_nombre.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Ingresa el nombre del Cliente"; ver.ShowDialog(); filtro.Hide();txt_nombre.Focus(); return false; }
            if (txt_ruc.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Ingresa el Nro de DNI o RUC del Cliente"; ver.ShowDialog(); filtro.Hide();txt_ruc.Focus(); return false; }
            return true;
        }


        //------------------------------------ METODO REGISTRAR CLIENTE -------------------------------------//
        private void Registrar_cliente()
        {
            CN_Cliente obj = new CN_Cliente();
            Cliente cli = new Cliente();
            try
            {
                cli.Idcliente = txt_id.Text;
                cli.Nombre = txt_nombre.Text;
                cli.Dniruc = txt_ruc.Text;
                cli.Direccion = txt_direccion.Text;
                cli.Email = "-";
                cli.FechaAniver = dtp_fn.Value;
                cli.Telefono = "0";


                obj.Registrar_Cliente(cli);
                if (CD_Cliente.cli_saved == true)
                {
                    MessageBox.Show("El Cliente se ha registrado correctamente", "Registro cliente form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbl_id.Text = txt_id.Text;
                    lbl_nom.Text = txt_nombre.Text;
                    lbl_ruc.Text = txt_ruc.Text;
                    lbl_direccion.Text = txt_direccion.Text;
                    LimpiarForm();
                    pnl_newCli.Visible = false;
                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //------------------------------------- METODO AGREGAR CLIENTE --------------------------------------//
        private void lbl_nuevo_Click_1(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_nombre.Text = "";
            txt_ruc.Text = "";
            txt_direccion.Text = "";
            pnl_newCli.Visible = true;
            txt_ruc.Focus();
        }


        //------------------------------------ METODO CANCELAR CLIENTE --------------------------------------//
        private void btn_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }


        //------------------------------------- METODO ELEGIR CLIENTE ---------------------------------------//
        private void btn_elegir_Click(object sender, EventArgs e)
        {

        }

        //------------------------------------ METODO CANCELAR2 CLIENTE -------------------------------------//
        private void btn_cancelar2_Click_1(object sender, EventArgs e)
        {
            LimpiarForm();
            pnl_newCli.Visible = true;
        }


        //--------------------------- METODO REGISTRAR CLIENTE DESDE EL BOTON -------------------------------//
        private void btrn_registrar_Click_1(object sender, EventArgs e)
        {
            if (Validar_TexToBox())
            {
                Registrar_cliente();
            }
        }


        //------------------------------------- METODO CERRAR CLIENTE ---------------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //------------------------------ METODO TEXTRUC SE LLENA POR DEFECTO --------------------------------//
        private void txt_ruc_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txt_ruc.Text.Trim().Length > 7)
            {
                txt_id.Text = GenerarIdCliente("Todos");
            }
            else if (txt_ruc.Text.Trim().Length == 0)
            {
                txt_id.Text = "";
            }
        }

    }
}


