using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Usuario;
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
        public bool RequiereRuc { get; set; }
        private Guna.UI2.WinForms.Guna2Button btnDesactivarCliente;
        private Guna.UI2.WinForms.Guna2Button btnEditarCliente;

        public frm_Lista_Clientes()
        {
            InitializeComponent();
            ConstruirBotonesMantenimiento();
            pnl_newCli.VisibleChanged += pnl_newCli_VisibleChanged;
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
            dt = obj_Cliente.Vertodos_los_Clientes("Activo");
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
            string valor = txt_buscar.Text.Trim();
            if (valor.Length == 0)
            {
                Cargar_Todos_LosClientes();
            }
            else if (valor.Length >= 2)
            {
                Buscar_Cliente(valor);
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
                Lsv_Cliente.Items[0].Selected = true;
                Lsv_Cliente.Items[0].Focused = true;
                Lsv_Cliente.EnsureVisible(0);
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
                MostrarAdvertencia("Seleccione un cliente de la lista.");
            }
            else
            {
                var lis = Lsv_Cliente.SelectedItems[0];
                string documento = new string(lis.SubItems[2].Text.Where(char.IsDigit).ToArray());
                if (RequiereRuc &&
                    (documento.Length != 11 || !ValidadorDocumentoPeru.EsRucValido(documento)))
                {
                    MostrarAdvertencia(
                        "Para emitir una factura debe elegir o registrar un cliente con RUC válido de 11 dígitos.");
                    return;
                }

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
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string ruc = new string(txt_ruc.Text.Where(char.IsDigit).ToArray());
            if (ruc.Length != 11)
            {
                MessageBox.Show(
                    "La consulta de prueba corresponde únicamente a un RUC de 11 dígitos.",
                    "Consulta RUC simulada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txt_ruc.Focus();
                return;
            }

            if (!ValidadorDocumentoPeru.EsRucValido(ruc))
            {
                MessageBox.Show(
                    "El RUC no supera la validación del dígito verificador.",
                    "Consulta RUC simulada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txt_ruc.Focus();
                return;
            }

            txt_nombre.Text = "EMPRESA DE PRUEBA " + ruc.Substring(7);
            txt_direccion.Text = "DIRECCIÓN FISCAL SIMULADA - NO OFICIAL";
            bunifuMaterialTextbox2.Text = "HABIDO (SIMULADO)";
            bunifuMaterialTextbox1.Text = "CONTRIBUYENTE DE PRUEBA";

            MessageBox.Show(
                "Datos generados por el simulador local.\n" +
                "No se realizó ninguna consulta real a SUNAT.",
                "Consulta RUC simulada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        //------------------------------------- METODO VALIDAR TEXBOX ---------------------------------------//
        private bool Validar_TexToBox()
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            if (txt_id.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Ingresa o Genera el Id del Cliente"; ver.ShowDialog();filtro.Hide();return false; }
            if (txt_nombre.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Ingresa el nombre del Cliente"; ver.ShowDialog(); filtro.Hide();txt_nombre.Focus(); return false; }
            if (txt_ruc.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Ingresa el Nro de DNI o RUC del Cliente"; ver.ShowDialog(); filtro.Hide();txt_ruc.Focus(); return false; }
            string documento = new string(
                txt_ruc.Text.Where(char.IsDigit).ToArray());
            if (documento.Length == 11 &&
                !ValidadorDocumentoPeru.EsRucValido(documento))
            {
                filtro.Show();
                ver.lbl_msm.Text = "El RUC ingresado no es válido.";
                ver.ShowDialog();
                filtro.Hide();
                txt_ruc.Focus();
                return false;
            }
            if (documento.Length != 8 && documento.Length != 11)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Ingrese un DNI de 8 dígitos o un RUC de 11 dígitos.";
                ver.ShowDialog();
                filtro.Hide();
                txt_ruc.Focus();
                return false;
            }
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
            Seleccionar_Cliente();
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

        private void ConstruirBotonesMantenimiento()
        {
            btnEditarCliente = new Guna.UI2.WinForms.Guna2Button
            {
                Name = "btnEditarCliente",
                Text = "Editar",
                Location = new Point(168, 731),
                Size = new Size(96, 22),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BorderRadius = 6,
                BorderThickness = 1,
                BorderColor = Color.White,
                FillColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnEditarCliente.Click += btnEditarCliente_Click;
            Controls.Add(btnEditarCliente);
            btnEditarCliente.BringToFront();

            btnDesactivarCliente = new Guna.UI2.WinForms.Guna2Button
            {
                Name = "btnDesactivarCliente",
                Text = "Desactivar",
                Location = new Point(276, 731),
                Size = new Size(96, 22),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BorderRadius = 6,
                BorderThickness = 1,
                BorderColor = Color.White,
                FillColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDesactivarCliente.Click += btnDesactivarCliente_Click;
            Controls.Add(btnDesactivarCliente);
            btnDesactivarCliente.BringToFront();

            // Centrado dentro del panel de registro.
            guna2Button2.Location = new Point(
                (pnl_newCli.ClientSize.Width - guna2Button2.Width) / 2,
                guna2Button2.Location.Y);
            guna2Button2.Text = "Consultar RUC";
        }

        private void pnl_newCli_VisibleChanged(object sender, EventArgs e)
        {
            bool mostrarMantenimiento = !pnl_newCli.Visible;
            btnEditarCliente.Visible = mostrarMantenimiento;
            btnDesactivarCliente.Visible = mostrarMantenimiento;

            if (pnl_newCli.Visible)
                pnl_newCli.BringToFront();
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (Lsv_Cliente.SelectedItems.Count == 0)
            {
                MostrarAdvertencia("Seleccione el cliente que desea editar.");
                return;
            }

            string idCliente = Lsv_Cliente.SelectedItems[0].SubItems[0].Text.Trim();
            frm_Editar_Cliente editar = new frm_Editar_Cliente
            {
                idcliente = idCliente
            };

            Filtro filtro = new Filtro();
            filtro.Show();
            editar.ShowDialog(this);
            filtro.Hide();

            if (editar.Tag != null && editar.Tag.ToString() == "A")
            {
                Cargar_Todos_LosClientes();
                SeleccionarClientePorId(idCliente);
            }
        }

        private void btnDesactivarCliente_Click(object sender, EventArgs e)
        {
            if (Lsv_Cliente.SelectedItems.Count == 0)
            {
                MostrarAdvertencia("Seleccione el cliente que desea desactivar.");
                return;
            }

            ListViewItem seleccionado = Lsv_Cliente.SelectedItems[0];
            string idCliente = seleccionado.SubItems[0].Text.Trim();
            string nombreCliente = seleccionado.SubItems[1].Text.Trim();

            if (idCliente.Equals("C01", StringComparison.OrdinalIgnoreCase))
            {
                MostrarAdvertencia(
                    "El cliente predeterminado para venta al público no se puede desactivar.");
                return;
            }

            Filtro filtro = new Filtro();
            frm_Si_No confirmar = new frm_Si_No();
            filtro.Show();
            confirmar.lbl_msm.Text =
                "¿Desea desactivar al cliente " + nombreCliente + "?\n\n" +
                "Sus ventas anteriores se conservarán.";
            confirmar.ShowDialog(this);
            filtro.Hide();

            if (confirmar.Tag == null || confirmar.Tag.ToString() != "Si")
                return;

            try
            {
                new CN_Cliente().DarBajaCliente(idCliente);
                Cargar_Todos_LosClientes();

                Filtro filtroOk = new Filtro();
                frm_Msm_bueno ok = new frm_Msm_bueno();
                filtroOk.Show();
                ok.Lbl_msm1.Text = "El cliente fue desactivado correctamente.";
                ok.ShowDialog(this);
                filtroOk.Hide();
            }
            catch (Exception ex)
            {
                MostrarAdvertencia("No se pudo desactivar el cliente: " + ex.Message);
            }
        }

        private void SeleccionarClientePorId(string idCliente)
        {
            foreach (ListViewItem item in Lsv_Cliente.Items)
            {
                if (item.SubItems[0].Text.Trim()
                    .Equals(idCliente, StringComparison.OrdinalIgnoreCase))
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    return;
                }
            }
        }

        private void MostrarAdvertencia(string mensaje)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia advertencia = new frm_Advertencia();
            filtro.Show();
            advertencia.lbl_msm.Text = mensaje;
            advertencia.ShowDialog(this);
            filtro.Hide();
        }

    }
}


