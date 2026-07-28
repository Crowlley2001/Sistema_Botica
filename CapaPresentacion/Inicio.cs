using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Cajas;
using CapaPresentacion.Comprobantes;
using CapaPresentacion.Compras;
using CapaPresentacion.Factura;
using CapaPresentacion.Informes;
using CapaPresentacion.Modales;
using CapaPresentacion.Producto;
using CapaPresentacion.Reportes;
using CapaPresentacion.Usuario;
using CapaPresentacion.Ventas;
using Guna.UI2.WinForms;
using Krypton.Navigator;
using MSistemaBotica_C.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using static System.Net.WebRequestMethods;
namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        /* METODO PARA LLAMAR VENTAS*/
        TabPage tabVentaGuardada;
        TabPage tabDocsGuardada;
        TabPage tabAlmacenGuardada;
        TabPage tabMovimientiosGuardada;
        TabPage tabCajadeCirres;
        private Guna2ComboBox cbo_monedaVenta;
        private Guna2TextBox txt_resumenMonedaVenta;
        private decimal tipoCambioVenta = 1m;
        private string codigoMonedaVenta = "PEN";
        private VentaCompleta ultimaVentaRegistrada;
        private string hashCpeActual = string.Empty;
        private string estadoCpeActual = "NO APLICA";
        private string advertenciaCpeActual = string.Empty;
        private readonly IPasarelaPago pasarelaPago = new PasarelaPagoManual();
        private readonly ImageList imagenesProductosAlmacen = new ImageList();
        private Guna2Panel panelCargaProductos;
        private Guna2CircleProgressBar circuloCargaProductos;
        private Label etiquetaCargaProductos;

        public Inicio()
        {
            InitializeComponent();
            ConstruirCapaCargaProductos();
            txt_dni.MaxLength = 11;
            txt_dni.KeyPress += txt_dni_KeyPress_Documento;
            cbo_tipodoc.SelectedIndexChanged += cbo_tipodoc_SelectedIndexChanged_Documento;
        }


        //----------------------------- METODO LLAMAR FUNCIONES DESDE INICIO ---------------------------------//
        private void Inicio_Load(object sender, EventArgs e)
        {

            tabVentaGuardada = tabpage_venta;
            tabDocsGuardada = tabpage_docs;
            tabAlmacenGuardada = tabpage_almacen;
            tabMovimientiosGuardada = tabpage_movimiento;
            tabCajadeCirres = tabCajaCierre;



            if (tabVentaGuardada != null) ElTab1.TabPages.Remove(tabpage_venta);
            if (tabDocsGuardada != null) ElTab1.TabPages.Remove(tabpage_docs);
            if (tabAlmacenGuardada != null) ElTab1.TabPages.Remove(tabpage_almacen);
            if (tabMovimientiosGuardada != null) ElTab1.TabPages.Remove(tabpage_movimiento);
            if (tabCajadeCirres != null) ElTab1.TabPages.Remove(tabCajaCierre);



            foreach (TabPage pagina in ElTab1.TabPages)
            {
                Padding = new Padding(0);
                pagina.Margin = new Padding(0);
                pagina.BackColor = Color.Transparent;
                ElTab1.ItemSize = new Size(120, 28);
                ElTab1.TabButtonSize = new Size(120, 28);
                ElTab1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            }
            Configura_ListViewDetalle();
            Configura_ListViewProductoDetalle();
            Configura_ListView_Docs();
            Llenar_Combo_TipoDoc();
            InicializarControlesMoneda();
            InicializarMetodosPago();
            Configura_ListView_Productos_Almacen();
            Configura_ListView_Productos_Movimiento();
            Configurar_listView_CierreCaja();
            Cargar_Todos_Usuarios();
            Cargar_Todos_Cierres();
            Construir_Menu();
            InicializarMenuCpe();
            cargo = true;

            ConstruirDashboardProfesional();

            lsv_Pdet.Visible = false;

        }


        //--------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA ----------------------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        //------------------------------ METODO CARGAR DATOS USUARIOS INICIO ---------------------------------//
        public void Cargar_DatosUsuarios()
        {
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();

            CN_CierreCaja obj = new CN_CierreCaja();
            frm_Inicio_Caja caja = new frm_Inicio_Caja();


            fil.Show();
            MessageBox.Show(
            this,
            "Bienvenido Sr(a): " + Cls_ModalCategoria.Nombre,
            "Bienvenido",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
            fil.Hide();

            //Vamos a verificar e inicio de Caja
            if (obj.CN_validar_InicioDoble_caja() == false)
            {
                fil.Show();
                caja.ShowDialog(this);
                fil.Hide();
            }
            ActualizarEncabezadoUsuario();
        }

        private void ActualizarEncabezadoUsuario()
        {
            lbl_nomUser.Text =
                (Cls_ModalCategoria.Nombre + " " + Cls_ModalCategoria.Apellido).Trim();
            lbl_Rol.Text = Cls_ModalCategoria.Nomerol;

            string foto = Cls_ModalCategoria.Foto;
            if (!string.IsNullOrWhiteSpace(foto) && System.IO.File.Exists(foto))
            {
                using (Image imagen = Image.FromFile(foto))
                    pic_user.Image = new Bitmap(imagen);
            }
            else
            {
                pic_user.Image = Properties.Resources.circulo_login;
            }
            pic_user.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private static string NormalizarTextoMovimiento(string texto)
        {
            string valor = (texto ?? string.Empty).Trim();
            if (valor.IndexOf("Ventas al", StringComparison.OrdinalIgnoreCase) >= 0 &&
                valor.IndexOf("blico", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Por Ventas al Público";
            return valor;
        }


        private void Construir_Menu()
        {
            var objme = new CN_MenuUsuario();
            var data = new DataTable();

            string xMenu = "";
            int xid = 0;
            int idmenu;

            data = objme.CN_LeerPrivilegios(Convert.ToInt32(Cls_ModalCategoria.IdUsu));
            if (data.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in data.Rows)
            {
                xMenu = dr["Nombre_menu"].ToString();
                idmenu = Convert.ToInt32(dr["Id_menuxusu"].ToString());
                xid = Convert.ToInt32(objme.CN_ListarIdMenuSys(xMenu, Cls_ModalCategoria.IdUsu));

                if (xMenu.Trim().ToString() == "Aperturar Caja") { if (xid == idmenu) { aperturarCajaToolStripMenuItem.Enabled = true; } else { aperturarCajaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Cierre de Caja") { if (xid == idmenu) { cerrarCajaToolStripMenuItem.Enabled = true; } else { cerrarCajaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ventas") { if (xid == idmenu) { Bt_VentasTool.Enabled = true; } else { Bt_VentasTool.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Tipo de Cambio") { if (xid == idmenu) { tipoCambioToolStripMenuItem.Enabled = true; } else { tipoCambioToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Administrador de Correlativos") { if (xid == idmenu) { administradorDeCorrelativosToolStripMenuItem.Enabled = true; } else { administradorDeCorrelativosToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Productos sin Stock por Venta del Dia") { if (xid == idmenu) { productosSinStockPorVentaDelDiaToolStripMenuItem.Enabled = true; } else { productosSinStockPorVentaDelDiaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Venta Perdida por falta de Stock") { if (xid == idmenu) { ventaPerdidaPorFaltaDeStockToolStripMenuItem.Enabled = true; } else { ventaPerdidaPorFaltaDeStockToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ver movimiento de Caja") { if (xid == idmenu) { verMovimientoDeCajaToolStripMenuItem.Enabled = true; } else { verMovimientoDeCajaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Otros Ingresos") { if (xid == idmenu) { otrosIngresosToolStripMenuItem.Enabled = true; } else { otrosIngresosToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Gastos del Dia") { if (xid == idmenu) { gastosDelDiaToolStripMenuItem.Enabled = true; } else { gastosDelDiaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ver Comprobantes Emitidos") { if (xid == idmenu) { verComprobantesEmitidosToolStripMenuItem.Enabled = true; } else { verComprobantesEmitidosToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ver Cierres de Caja") { if (xid == idmenu) { verCierresDeCajaToolStripMenuItem.Enabled = true; } else { verCierresDeCajaToolStripMenuItem.Enabled = false; } }

                if (xMenu.Trim().ToString() == "Crear Nuevo Producto") { if (xid == idmenu) { crearNuevoProductoToolStripMenuItem.Enabled = true; } else { crearNuevoProductoToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Crear Nuevo Cliente") { if (xid == idmenu) { crearNuevoClienteToolStripMenuItem.Enabled = true; } else { crearNuevoClienteToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Mantenimiento de Familias") { if (xid == idmenu) { mantenimientoDeFamiliasToolStripMenuItem.Enabled = true; } else { mantenimientoDeFamiliasToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Productos sin Rotacion") { if (xid == idmenu) { producToolStripMenuItem.Enabled = true; } else { producToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Productos para Reposicion") { if (xid == idmenu) { productosParaReposicionToolStripMenuItem.Enabled = true; } else { productosParaReposicionToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Catalogo de Productos") { if (xid == idmenu) { catalogoDeProductosToolStripMenuItem.Enabled = true; } else { catalogoDeProductosToolStripMenuItem.Enabled = false; } }

                if (xMenu.Trim().ToString() == "Traspaso de Salida") { if (xid == idmenu) { traspasoDeSalidaToolStripMenuItem.Enabled = true; } else { traspasoDeSalidaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Traspaso de Ingreso") { if (xid == idmenu) { traspasoDeIngresoToolStripMenuItem.Enabled = true; } else { traspasoDeIngresoToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ajuste de Inventario") { if (xid == idmenu) { ajusteDeInventarioToolStripMenuItem.Enabled = true; } else { ajusteDeInventarioToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Reporte Inventario Valorizado") { if (xid == idmenu) { reporteInventarioValorizadoToolStripMenuItem.Enabled = true; } else { reporteInventarioValorizadoToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ver Kardex  de Producto") { if (xid == idmenu) { verKArdexToolStripMenuItem.Enabled = true; } else { verKArdexToolStripMenuItem.Enabled = false; } }

                if (xMenu.Trim().ToString() == "Administrador de Usuario") { if (xid == idmenu) { administradorDeUsuarioToolStripMenuItem.Enabled = true; } else { administradorDeUsuarioToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Actualizacion de Precio") { if (xid == idmenu) { actualizacionDePrecioToolStripMenuItem.Enabled = true; } else { actualizacionDePrecioToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Canjear Nota de Venta") { if (xid == idmenu) { canjearNotaToolStripMenuItem.Enabled = true; } else { canjearNotaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Anular Comprobante de Venta") { if (xid == idmenu) { anularComprobanteDeVentaToolStripMenuItem.Enabled = true; } else { anularComprobanteDeVentaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Eliminar Guia de Ingreso") { if (xid == idmenu) { eliminarGuiaDeIngresoToolStripMenuItem.Enabled = true; } else { eliminarGuiaDeIngresoToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Eliminar Guia de Salida") { if (xid == idmenu) { eliminarGuiaDeSalidaToolStripMenuItem.Enabled = true; } else { eliminarGuiaDeSalidaToolStripMenuItem.Enabled = false; } }

                if (xMenu.Trim().ToString() == "Editar datos de Local") { if (xid == idmenu) { editarDatosDeLocalToolStripMenuItem.Enabled = true; } else { editarDatosDeLocalToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Exportar Base de Datos") { if (xid == idmenu) { exportarBaseDeDatosToolStripMenuItem.Enabled = true; } else { exportarBaseDeDatosToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Importar Base de Datos") { if (xid == idmenu) { importarBaseDeDatosToolStripMenuItem.Enabled = true; } else { importarBaseDeDatosToolStripMenuItem.Enabled = false; } }

                if (xMenu.Trim().ToString() == "Record Mensual de Ventas") { if (xid == idmenu) { recordMensualDeVentasToolStripMenuItem.Enabled = true; } else { recordMensualDeVentasToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Record general de Ventas") { if (xid == idmenu) { recordGeneralDeVentasToolStripMenuItem.Enabled = true; } else { recordGeneralDeVentasToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Reporte de Productos mas Vendidos") { if (xid == idmenu) { reporteDeProductosMasVendidosToolStripMenuItem.Enabled = true; } else { reporteDeProductosMasVendidosToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Imprimir Movimiento caja por dia") { if (xid == idmenu) { imprimirMovimientoCajaPorDiaToolStripMenuItem.Enabled = true; } else { imprimirMovimientoCajaPorDiaToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ver guias Registradas") { if (xid == idmenu) { verGuiasRegistradasToolStripMenuItem.Enabled = true; } else { verGuiasRegistradasToolStripMenuItem.Enabled = false; } }
                if (xMenu.Trim().ToString() == "Ver Clientes Registrados") { if (xid == idmenu) { verClientesRegistradosToolStripMenuItem.Enabled = true; } else { verClientesRegistradosToolStripMenuItem.Enabled = false; } }

            }

        }





        //------------------------------------- METODO MINIMIZAR INICIO --------------------------------------//
        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //-------------------------------------- METODO CERRAR INICIO ----------------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //----------------------------------- METODO HORA Y FECHA INICIO -------------------------------------//
        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }


        #region "HacerVentas:"

        //---------------------------------- METODO LLENAR COMBO TIPODOC -------------------------------------//
        private void Llenar_Combo_TipoDoc()
        {
            CN_TipoDoc obj = new CN_TipoDoc();
            DataTable data = new DataTable();

            data = obj.CN_Listar_Tipo_Doc_Especial_Ventas();
            if (data.Rows.Count > 0)
            {
                var cbo = cbo_tipodoc;
                cbo.DataSource = data;
                cbo.DisplayMember = "Documento";
                cbo.ValueMember = "Id_Tipo";
            }
            cbo_tipopago.SelectedIndex = 0;
        }



        public void Tocar_audioError()
        {
            AudioSistema.Reproducir("ErrorWin.wav");
        }
        public void Tocar_audioCaja()
        {
            AudioSistema.Reproducir("Efectocaja.wav");
        }
        public void Tocar_Timbre()
        {
            AudioSistema.Reproducir("timbre1.wav");
        }



        //------------------------ METODO CONFIGURAR LISTVIEW DETALLE HACER VENTA ----------------------------//
        private void Configura_ListViewDetalle()
        {
            var lis = lsv_Det;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            lis.HeaderStyle = ColumnHeaderStyle.None;
            //Aggar columnas a mi ListView
            lis.Columns.Add("ID Prod", 180, HorizontalAlignment.Left);
            lis.Columns.Add("Descripción del Articulo", 620, HorizontalAlignment.Left);
            lis.Columns.Add("Cant", 80, HorizontalAlignment.Center);
            lis.Columns.Add("Precio", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Importe", 110, HorizontalAlignment.Center);
            lis.Columns.Add("Utili unit", 0, HorizontalAlignment.Left);
            lis.Columns.Add("ImporUtili", 0, HorizontalAlignment.Left);
            lis.Columns.Add("TotalDscto", 0, HorizontalAlignment.Left);
        }



        //--------------------- METODO CONFIGURAR LISTVIEW PRODUCTODETALLE HACER VENTA -----------------------//
        private void Configura_ListViewProductoDetalle()
        {
            var lis = lsv_Pdet;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            //Aggar columnas a mi ListView
            lis.Columns.Add("ID Prod", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Descripción del Articulo", 223, HorizontalAlignment.Left);
            lis.Columns.Add("Cant", 69, HorizontalAlignment.Center);
            lis.Columns.Add("PreVenta", 70, HorizontalAlignment.Center);
            lis.Columns.Add("precompra", 0, HorizontalAlignment.Right);
            lis.Columns.Add("estadoProd", 0, HorizontalAlignment.Left);
        }



        //------------------------------------ METODO LISTAR PRODUCTOS ---------------------------------------//
        private void Configura_ListView_ProductoVender(DataTable data, string tipo)
        {
            lsv_Pdet.Items.Clear();
            double stockactual = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                stockactual = Convert.ToDouble(dr["Stock_Actual"]);
                if (tipo == "todo")
                {

                    if (chk_todoventa.Checked == true)
                    {
                        ListViewItem lis = new ListViewItem(dr[0].ToString());
                        lis.SubItems.Add(dr["Descripcion_Larga"].ToString());
                        lis.SubItems.Add(stockactual.ToString());
                        double preventa = Convert.ToDouble(dr["Pre_venta"]);
                        lis.SubItems.Add(preventa.ToString("###0.00"));
                        double precompra = Convert.ToDouble(dr["Pre_CompraS"]);
                        lis.SubItems.Add(precompra.ToString("###0.00"));
                        lis.SubItems.Add(dr["Estado_Pro"].ToString());
                        lsv_Pdet.Items.Add(lis);
                    }

                    else
                    {
                        if (stockactual > 0)
                        {
                            ListViewItem lis = new ListViewItem(dr[0].ToString());
                            lis.SubItems.Add(dr["Descripcion_Larga"].ToString());
                            lis.SubItems.Add(stockactual.ToString());
                            double preventa = Convert.ToDouble(dr["Pre_venta"]);
                            lis.SubItems.Add(preventa.ToString("###0.00"));
                            double precompra = Convert.ToDouble(dr["Pre_CompraS"]);
                            lis.SubItems.Add(precompra.ToString("###0.00"));
                            lis.SubItems.Add(dr["Estado_Pro"].ToString());
                            lsv_Pdet.Items.Add(lis);
                        }
                    }
                }
                else
                {
                    ListViewItem lis = new ListViewItem(dr[0].ToString());
                    lis.SubItems.Add(dr["Descripcion_Larga"].ToString());
                    lis.SubItems.Add(stockactual.ToString());
                    double preventa = Convert.ToDouble(dr["Pre_venta"]);
                    lis.SubItems.Add(preventa.ToString("###0.00"));
                    double precompra = Convert.ToDouble(dr["Pre_CompraS"]);
                    lis.SubItems.Add(precompra.ToString("###0.00"));
                    lis.SubItems.Add(dr["Estado_Pro"].ToString());
                    lsv_Pdet.Items.Add(lis);
                }
            }
            lsv_Pdet.Visible = true;

        }



        //---------------------------------- METODO PINTAR LISVIW VENTA --------------------------------------//
        private void PintasFilas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_Pdet.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_Pdet.Items[i].BackColor = Color.WhiteSmoke;
                }
                cont += 1;
            }
        }
        private void PintasFilas2()
        {
            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                if (i % 2 == 0)
                    lsv_Det.Items[i].BackColor = Color.White;
                else
                    lsv_Det.Items[i].BackColor = Color.WhiteSmoke;
            }
            lsv_Det.SelectedItems.Clear();
        }


        //------------------------------- METODO LLENAR PRODUCTOS AL LISVIW ----------------------------------//
        private void LLenarProducto_Vender()
        {
            CN_Producto objProd = new CN_Producto();
            DataTable data = new DataTable();
            data = objProd.CargarTodos_Productos();
            if (data.Rows.Count > 0)
            {
                Configura_ListView_ProductoVender(data, "todo");
                if (lsv_Pdet.Items.Count > 0)
                {
                    lsv_Pdet.Items[0].Selected = true;
                    lsv_Pdet.Focus();
                }
            }
            else
            {
                lsv_Pdet.Visible = false;
                lsv_Pdet.Items.Clear();
            }
            PintasFilas();
        }

        private void ElTab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si la pestaña seleccionada es la de Ventas
            if (ElTab1.SelectedTab == tabpage_venta)
            {
                LLenarProducto_Vender();
            }
        }

        //-------------------------- METODO LLENAR PRODUCTO AL CARRITO DE VENTA ------------------------------//
        private void LLenarProducto_Carrito(string idprod, string productodes, double cantidad, double preciounit,
                                            double importe, double utiliUnit, double importeUtili, double dscto)
        {


            if (lsv_Det.Items.Count == 0)
            {
                ListViewItem item = new ListViewItem();
                item = lsv_Det.Items.Add(idprod.Trim());

                item.SubItems.Add(productodes.Trim());
                item.SubItems.Add(cantidad.ToString());
                item.SubItems.Add(preciounit.ToString("###0.00"));
                item.SubItems.Add(importe.ToString("###0.00"));
                item.SubItems.Add(utiliUnit.ToString("###0.00"));
                item.SubItems.Add(importeUtili.ToString("###0.00"));
                item.SubItems.Add(dscto.ToString("###0.00"));
                Calcular_ImportePagar();
                PintasFilas2();
                pnl_sinProd.Visible = false;
            }
            else
            {
                //Validar si el producto ya existe en el carrito
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    if (lsv_Det.Items[i].Text.Trim() == idprod.Trim())
                    {
                        MessageBox.Show("El producto ya existe en el carrito de ventas", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                ListViewItem item = new ListViewItem();
                item = lsv_Det.Items.Add(idprod.Trim());

                item.SubItems.Add(productodes.Trim());
                item.SubItems.Add(cantidad.ToString());
                item.SubItems.Add(preciounit.ToString("###0.00"));
                item.SubItems.Add(importe.ToString("###0.00"));
                item.SubItems.Add(utiliUnit.ToString("###0.00"));
                item.SubItems.Add(importeUtili.ToString("###0.00"));
                item.SubItems.Add(dscto.ToString("###0.00"));
                Calcular_ImportePagar();
                PintasFilas2();
            }

        }


        //------------------------------- METODO BUSCAR PRODUCTO PARA VENDER ---------------------------------//
        private void BuscarProducto_ParaVender(string valor)
        {
            CN_Producto objProd = new CN_Producto();
            DataTable data = new DataTable();
            frm_Agregar_Cantidad cant = new frm_Agregar_Cantidad();
            Filtro filtro = new Filtro();
            frm_Si_No sino = new frm_Si_No();
            frm_Advertencia ver = new frm_Advertencia();

            string xidprod = "";
            string xproducto = "";
            double cantidad = 1;
            double PreVenta = 0;
            double ImporteVenta = 0;
            double PreCompra = 0;
            double UtiLiUnitaria = 0;
            double ImporteUtilidad = 0;
            double dscto = 0;
            double xstock = 0;
            try
            {
                data = objProd.BuscarProductoID(valor);
                if (data.Rows.Count == 1)
                {
                    xidprod = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    xproducto = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                    xstock = Convert.ToDouble(data.Rows[0]["Stock_Actual"]);
                    PreCompra = Convert.ToDouble(data.Rows[0]["Pre_CompraS"]);
                    PreVenta = Convert.ToDouble(data.Rows[0]["Pre_venta"]);
                    UtiLiUnitaria = PreVenta - PreCompra;

                    DateTime fechaVencimiento;
                    string fechaTexto = data.Columns.Contains("FechaVncmnto")
                        ? Convert.ToString(data.Rows[0]["FechaVncmnto"]).Trim()
                        : string.Empty;
                    if (DateTime.TryParse(fechaTexto, out fechaVencimiento) &&
                        fechaVencimiento.Date < DateTime.Today)
                    {
                        filtro.Show();
                        ver.lbl_msm.Text =
                            "No se puede vender este producto porque venció el " +
                            fechaVencimiento.ToString("dd/MM/yyyy") + ".";
                        ver.ShowDialog(this);
                        filtro.Hide();
                        return;
                    }

                    if (xstock > 0)
                    {
                        filtro.Show();
                        cant.lbl_Stock1.Text = xstock.ToString();
                        cant.Lbl_Producto.Text = xidprod;
                        DialogResult result = cant.ShowDialog(this);
                        filtro.Hide();
                        if (result == DialogResult.OK)
                        {
                            cantidad = Convert.ToDouble(cant.txt_cant.Text);
                            LLenarProducto_Carrito(
                                xidprod,
                                xproducto,
                                cantidad,
                                PreVenta,
                                ImporteVenta,
                                UtiLiUnitaria,
                                ImporteUtilidad,
                                dscto
                            );
                        }
                    }
                    else
                    {
                        filtro.Show();
                        ver.lbl_msm.Text = "El producto seleccionado no tiene stock disponible";
                        ver.ShowDialog(this);
                        filtro.Hide();

                        filtro.Show();
                        sino.lbl_msm.Text = "¿Desea agregar el producto al carrito de ventas?";
                        sino.ShowDialog(this);
                        filtro.Hide();

                        CN_Producto_SinValor obj = new CN_Producto_SinValor();
                        frm_softmsm msm = new frm_softmsm();
                        if (sino.Tag.ToString() == "Si")
                        {
                            obj.CN_Registrar_Producto_sinValor(xidprod, Convert.ToInt32(Cls_ModalCategoria.IdUsu), "Perdida");
                            msm.tipo = "Good";
                            msm.Lbl_msm.Text = "La operacion se ha registrado con exito";
                            msm.ShowDialog(this);
                        }
                    }

                }
                else if (data.Rows.Count > 1)
                {
                    Configura_ListView_ProductoVender(data, "buscar");
                    PintasFilas();
                    if (lsv_Pdet.Items.Count > 0)
                    {
                        lsv_Pdet.Items[0].Selected = true;
                        lsv_Pdet.Items[0].EnsureVisible();
                    }
                    lsv_Pdet.Focus();
                }
                else
                {
                    MessageBox.Show("El producto no existe en el sistema", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        //-------------------------------- METODO CALCULAR IMPORTE A PAGAR -----------------------------------//
        private void Calcular_ImportePagar()
        {
            double preventa = 0;
            double cantidad = 0;
            double importeventa = 0;
            double totalventa = 0;
            double subtotal = 0;
            double igv = 0;
            double xdscto = 0;
            double UtiliTnit = 0;
            double ImporteUtilidad = 0;
            double totalDscto = 0;
            double GanaciaTotal = 0;

            try
            {
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    //Obtner valores de las columnas
                    preventa = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);
                    cantidad = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                    UtiliTnit = Convert.ToDouble(lsv_Det.Items[i].SubItems[5].Text);
                    xdscto = Convert.ToDouble(lsv_Det.Items[i].SubItems[7].Text);

                    //Calcular importe venta
                    importeventa = preventa * cantidad;
                    lsv_Det.Items[i].SubItems[4].Text = importeventa.ToString("###0.00");

                    //Calcular importe Utilidad
                    ImporteUtilidad = cantidad * UtiliTnit;
                    lsv_Det.Items[i].SubItems[6].Text = ImporteUtilidad.ToString("###0.00");

                    //Cacular PAGO TOTAL
                    totalventa = totalventa + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);
                    subtotal = totalventa / 1.18;
                    igv = totalventa - subtotal;

                    GanaciaTotal = GanaciaTotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[6].Text);
                }

                lbl_subtotal.Text = subtotal.ToString("###0.00");
                lbl_igv.Text = igv.ToString("###0.00");
                txt_totalpagar.Text = totalventa.ToString("###0.00");
                lbl_totalDscto.Text = totalDscto.ToString("###0.00");
                lbl_TotalGanancia.Text = GanaciaTotal.ToString("###0.00");
                ActualizarResumenMoneda();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }



        //---------------------------- EVENTO CLICK BUSCAR PRODUCTO PARA VENDER ------------------------------//
        private void lbl_buscarProd_Click(object sender, EventArgs e)
        {
            lsv_Pdet.Visible = true;
            lsv_Pdet.BringToFront();
            if (txt_buscarProd.Text.Trim().Length == 0)
            {
                LLenarProducto_Vender();
            }
            else
            {
                BuscarProducto_ParaVender(txt_buscarProd.Text);
            }
        }



        //-------------------------- EVENTO KEYDOWN BUSCAR PRODUCTO PARA VENDER ------------------------------//
        private void txt_buscarProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbl_buscarProd_Click(sender, e);
            }
        }



        //------------------------ EVENTO DOBLE CLICK LISTVIEW PRODUCTO PARA VENDER --------------------------//
        private void lsv_Pdet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SeleccionarProducto_Carrito();
        }


        //------------------------------ METODO ADVERTENCIA Y AGREGARCANTIDAD --------------------------------//
        private void SeleccionarProducto_Carrito()
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Agregar_Cantidad cant = new frm_Agregar_Cantidad();

            double stock2 = 0;

            if (lsv_Pdet.SelectedItems.Count == 0) { filtro.Show(); ver.lbl_msm.Text = "Seleccione un producto para vender"; ver.ShowDialog(this); filtro.Hide(); return; }
            string idproducto = "";
            idproducto = lsv_Pdet.SelectedItems[0].SubItems[0].Text;
            stock2 = Convert.ToDouble(lsv_Pdet.SelectedItems[0].SubItems[2].Text);
            BuscarProducto_ParaVender(idproducto);
        }



        //------------------------ EVENTO KEYDOWN LISTVIEW PARA SELECCIONAR PRODUCTO -------------------------//
        private void lsv_Pdet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto_Carrito();
            }
        }



        //-------------------------------- METODO QUITAR PRODUCTO DEL CARRITO --------------------------------//
        private void btn_Quitar_Prod_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Si_No sino = new frm_Si_No();
            if (lsv_Det.SelectedItems.Count == 0)
            {
                filtro.Show(); ver.lbl_msm.Text = "Seleccione un producto para quitar del carrito"; ver.ShowDialog(this); filtro.Hide(); return;
            }
            else
            {
                filtro.Show();
                sino.lbl_msm.Text = "¿Está seguro de quitar el producto del carrito?";
                sino.ShowDialog(this);
                filtro.Hide();
                if (sino.Tag != null && sino.Tag.ToString() == "Si")
                {
                    int i;
                    var lis = lsv_Det.SelectedItems[0];
                    for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)

                    {
                        lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);
                    }
                    Calcular_ImportePagar();
                }
            }
        }



        //---------------------- METODO PARA AUMENTAR Y DISMINUI LA CANTIDAD CON + Y - -----------------------//
        private void lsv_Det_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                btn_Quitar_Prod_Click(sender, e);
                e.SuppressKeyPress = true;
            }

            // AUMENTAR (+)
            if (
                e.KeyCode == Keys.Add ||
                e.KeyCode == Keys.Oemplus
            )
            {
                AumentarCantidad();
                e.SuppressKeyPress = true;
                return;
            }


            // DISMINUIR (-)
            if (
                e.KeyCode == Keys.Subtract ||
                e.KeyCode == Keys.OemMinus
            )
            {
                DisminuirCantidad();
                e.SuppressKeyPress = true;
                return;
            }
        }



        //----------------------------------- METODO AUMENTAR LA CANTIDAD ------------------------------------//
        private void AumentarCantidad()
        {
            CN_Producto objProd = new CN_Producto();
            DataTable Datos = new DataTable();
            frm_Advertencia ver = new frm_Advertencia();
            Filtro filtro = new Filtro();

            double Cant_Edit = 0;
            string Id_Prod = "";
            double Cant_added = 0;
            double Stock_Actual = 0;
            if (lsv_Det.SelectedItems.Count == 0)
            {
                filtro.Show(); ver.lbl_msm.Text = "Seleccione un producto para aumentar cantidad"; ver.ShowDialog(this); filtro.Hide(); return;
            }
            Id_Prod = lsv_Det.SelectedItems[0].SubItems[0].Text;
            Cant_Edit = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);
            Cant_added = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

            Datos = objProd.BuscarProductoID(Id_Prod);
            if (Datos.Rows.Count > 0)
            {
                Stock_Actual = Convert.ToDouble(Datos.Rows[0]["Stock_Actual"]);
            }
            else
            {
                filtro.Show();
                ver.lbl_msm.Text = "No se puede leer los datos de este producto: Utilize otro metodo"; ver.ShowDialog(this); filtro.Hide(); return;
            }
            if (Cant_Edit >= Stock_Actual)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Ups!! - Has Llegado al tope del Stock Disponible [ " + Stock_Actual + " ]";
                ver.ShowDialog(this);
                filtro.Hide();

                lsv_Det.SelectedItems[0].SubItems[2].Text = Cant_added.ToString("###0.00");
                Calcular_ImportePagar();
                return;
            }
            else
            {
                double newcanti = Cant_Edit + 1;
                lsv_Det.SelectedItems[0].SubItems[2].Text = newcanti.ToString("###0.00");
                Calcular_ImportePagar();
            }
        }


        //----------------------------------- METODO DISMINUIR LA CANTIDAD -----------------------------------//
        private void DisminuirCantidad()
        {
            CN_Producto objProd = new CN_Producto();
            DataTable Datos = new DataTable();
            frm_Advertencia ver = new frm_Advertencia();
            Filtro filtro = new Filtro();

            double Cant_Edit = 0;
            string Id_Prod = "";
            double Cant_added = 0;
            double Stock_Actual = 0;
            if (lsv_Det.SelectedItems.Count == 0)
            {
                filtro.Show(); ver.lbl_msm.Text = "Seleccione un producto para aumentar cantidad"; ver.ShowDialog(this); filtro.Hide(); return;
            }
            Id_Prod = lsv_Det.SelectedItems[0].SubItems[0].Text;
            Cant_Edit = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);
            Cant_added = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

            Datos = objProd.BuscarProductoID(Id_Prod);
            if (Datos.Rows.Count > 0)
            {
                Stock_Actual = Convert.ToDouble(Datos.Rows[0]["Stock_Actual"]);
            }
            else
            {
                filtro.Show();
                ver.lbl_msm.Text = "No se puede leer los datos de este producto: Utilize otro metodo"; ver.ShowDialog(this); filtro.Hide(); return;
            }
            if (Cant_Edit <= 1)
            {
            }
            else
            {
                double newcanti = Cant_Edit - 1;
                lsv_Det.SelectedItems[0].SubItems[2].Text = newcanti.ToString("###0.00");
                Calcular_ImportePagar();
            }
        }





        //-------------------------- METODO PARA ENTRAR A VENTAS DESDE EL TABPAGE ----------------------------//
        private void Bt_VentasTool_Click(object sender, EventArgs e)
        {
            if (tabVentaGuardada != null)
            {
                if (!ElTab1.TabPages.Contains(tabVentaGuardada))
                {
                    ElTab1.TabPages.Insert(1, tabVentaGuardada);
                }
                ElTab1.SelectedTab = tabVentaGuardada;
                ElTab1.SelectedIndex = ElTab1.TabPages.IndexOf(tabVentaGuardada);
                ElTab1.Refresh();
                Buscar_Cliente_ParalaVenta("C-1222223");
                txt_buscarProd.Focus();
                //         FECHA - ACTUAL         //
                dtp_fechaEmision.Value = DateTime.Now;

            }
        }



        //------------------------------------- METODO BUSCAR CLIENTES ---------------------------------------//
        private void Buscar_Cliente_ParalaVenta(string valor)
        {
            CN_Cliente objCli = new CN_Cliente();
            DataTable data = new DataTable();

            data = objCli.Buscar_Clientes_PorValor(valor);
            if (data.Rows.Count > 0)
            {
                lbl_idcliente.Text = data.Rows[0]["Id_Cliente"].ToString();
                txt_cliente.Text = data.Rows[0]["Razon_Social_Nombres"].ToString();
                txt_dni.Text = data.Rows[0]["DNI"].ToString();
                lbl_direccion.Text = data.Rows[0]["Direccion"].ToString();

            }
        }


        //--------------------------- METODO LISTAR CLIENTES DESDE LISTA_CLIENTES ----------------------------//
        private void btn_Cliente_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Lista_Clientes lis = new frm_Lista_Clientes
            {
                RequiereRuc = cbo_tipodoc.Text.Trim()
                    .Equals("Factura", StringComparison.OrdinalIgnoreCase)
            };
            filtro.Show();
            lis.ShowDialog(this);
            filtro.Hide();
            if (lis.Tag != null && lis.Tag.ToString() == "A")
            {
                lbl_idcliente.Text = lis.lbl_id.Text;
                txt_cliente.Text = lis.lbl_nom.Text;
                txt_dni.Text = lis.lbl_ruc.Text;
                lbl_direccion.Text = lis.lbl_direccion.Text;
            }
        }

        private void cbo_tipodoc_SelectedIndexChanged_Documento(object sender, EventArgs e)
        {
            bool esFactura = cbo_tipodoc.Text.Trim()
                .Equals("Factura", StringComparison.OrdinalIgnoreCase);

            txt_dni.MaxLength = esFactura ? 11 : 11;
            txt_dni.PlaceholderText = esFactura
                ? "RUC de 11 dígitos"
                : "DNI (8) o RUC (11)";

            string documento = SoloDigitos(txt_dni.Text);
            if (!esFactura || documento.Length == 0 || documento.Length == 11)
                return;

            lbl_idcliente.Text = string.Empty;
            txt_cliente.Text = string.Empty;
            txt_dni.Text = string.Empty;
            lbl_direccion.Text = string.Empty;

            Filtro filtro = new Filtro();
            frm_Advertencia advertencia = new frm_Advertencia();
            filtro.Show();
            advertencia.lbl_msm.Text =
                "La factura requiere un cliente con RUC válido de 11 dígitos. " +
                "Seleccione uno existente o registre uno nuevo.";
            advertencia.ShowDialog(this);
            filtro.Hide();
            txt_cliente.Focus();
        }

        private void txt_dni_KeyPress_Documento(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        //----------------------------------- METODO VALIDAR VENTA -------------------------------------------//
        private bool ValidarVenta()
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            if (lsv_Det.Items.Count == 0) { filtro.Show(); ver.lbl_msm.Text = "Por favor, ingresa un producto al carrito"; ver.ShowDialog(this); filtro.Hide(); return false; }
            if (lbl_idcliente.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Por favor, ingresa un cliente para la venta"; ver.ShowDialog(this); filtro.Hide(); return false; }
            if (cbo_tipodoc.SelectedIndex == -1) { filtro.Show(); ver.lbl_msm.Text = "Por favor, seleciona el tipo de documento a emitir"; ver.ShowDialog(this); filtro.Hide(); cbo_tipodoc.Focus(); return false; }
            string tipoComprobante = cbo_tipodoc.Text.Trim();
            string documentoCliente = SoloDigitos(txt_dni.Text);

            if (tipoComprobante.Equals("Factura", StringComparison.OrdinalIgnoreCase) &&
                documentoCliente.Length != 11)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Para emitir una factura debe seleccionar un cliente con RUC de 11 dígitos.";
                ver.ShowDialog(this);
                filtro.Hide();
                return false;
            }

            if (tipoComprobante.Equals("Factura", StringComparison.OrdinalIgnoreCase) &&
                !ValidadorDocumentoPeru.EsRucValido(documentoCliente))
            {
                filtro.Show();
                ver.lbl_msm.Text =
                    "El RUC del cliente no supera la validación del dígito verificador.";
                ver.ShowDialog(this);
                filtro.Hide();
                return false;
            }

            decimal totalVenta;
            if (!decimal.TryParse(txt_totalpagar.Text, out totalVenta))
            {
                filtro.Show();
                ver.lbl_msm.Text = "El total de la venta no tiene un formato válido.";
                ver.ShowDialog(this);
                filtro.Hide();
                return false;
            }

            if (tipoComprobante.Equals("Boleta", StringComparison.OrdinalIgnoreCase) &&
                totalVenta > 700m &&
                documentoCliente.Length != 8 &&
                documentoCliente.Length != 11)
            {
                filtro.Show();
                ver.lbl_msm.Text = "En una boleta mayor a S/ 700 debe identificar al cliente con DNI o RUC.";
                ver.ShowDialog(this);
                filtro.Hide();
                return false;
            }

            if (QrSunatContenido.EsComprobanteElectronico(tipoComprobante) &&
                SoloDigitos(ObtenerRucEmisor()).Length != 11)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Configure el RUC de 11 dígitos de la empresa antes de emitir boletas o facturas.";
                ver.ShowDialog(this);
                filtro.Hide();
                return false;
            }

            ResultadoPago validacionPago = pasarelaPago.Validar(
                cbo_tipopago.Text,
                txt_NroOperacion.Text,
                ObtenerImporteMoneda(totalVenta),
                codigoMonedaVenta);
            if (!validacionPago.Aprobado)
            {
                filtro.Show();
                ver.lbl_msm.Text = validacionPago.Mensaje;
                ver.ShowDialog(this);
                filtro.Hide();
                txt_NroOperacion.Focus();
                return false;
            }

            return true;

        }

        private void InicializarMetodosPago()
        {
            cbo_tipopago.Items.Clear();
            cbo_tipopago.Items.AddRange(new object[]
            {
                "Efectivo",
                "Tarjeta débito",
                "Tarjeta crédito",
                "Yape",
                "Plin",
                "Transferencia bancaria"
            });
            cbo_tipopago.MaxDropDownItems = 6;
            cbo_tipopago.SelectedIndexChanged -= cbo_tipopago_SelectedIndexChanged;
            cbo_tipopago.SelectedIndexChanged += cbo_tipopago_SelectedIndexChanged;
            cbo_tipopago.SelectedIndex = 0;
            ActualizarReferenciaPago();
        }

        private void cbo_tipopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarReferenciaPago();
        }

        private void ActualizarReferenciaPago()
        {
            bool requiereReferencia = !PasarelaPagoManual.EsEfectivo(cbo_tipopago.Text);
            txt_NroOperacion.Enabled = requiereReferencia;
            txt_NroOperacion.PlaceholderText = requiereReferencia
                ? "Código de operación / voucher"
                : "No aplica para efectivo";
            txt_NroOperacion.Text = string.Empty;
        }

        private void InicializarControlesMoneda()
        {
            Label lblMoneda = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DimGray,
                Location = new Point(823, 514),
                Text = "Moneda de cobro:"
            };

            Label lblResumen = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DimGray,
                Location = new Point(960, 514),
                Text = "T.C. / equivalente:"
            };

            cbo_monedaVenta = new Guna2ComboBox
            {
                BorderColor = Color.DimGray,
                BorderRadius = 6,
                DrawMode = DrawMode.OwnerDrawFixed,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DimGray,
                ItemHeight = 30,
                Location = new Point(823, 537),
                Size = new Size(130, 36)
            };
            cbo_monedaVenta.Items.AddRange(new object[] { "PEN - Soles", "USD - Dólares" });
            cbo_monedaVenta.SelectedIndexChanged += cbo_monedaVenta_SelectedIndexChanged;

            txt_resumenMonedaVenta = new Guna2TextBox
            {
                BorderColor = Color.DimGray,
                BorderRadius = 6,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DimGray,
                Location = new Point(960, 537),
                ReadOnly = true,
                Size = new Size(134, 36),
                TextAlign = HorizontalAlignment.Center
            };

            guna2GroupBox1.Controls.Add(lblMoneda);
            guna2GroupBox1.Controls.Add(lblResumen);
            guna2GroupBox1.Controls.Add(cbo_monedaVenta);
            guna2GroupBox1.Controls.Add(txt_resumenMonedaVenta);
            cbo_monedaVenta.BringToFront();
            txt_resumenMonedaVenta.BringToFront();

            dtp_fechaEmision.ValueChanged += dtp_fechaEmision_ValueChanged_Moneda;
            cbo_monedaVenta.SelectedIndex = 0;
        }

        private void cbo_monedaVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_monedaVenta.SelectedIndex != 1)
            {
                codigoMonedaVenta = "PEN";
                tipoCambioVenta = 1m;
                ActualizarResumenMoneda();
                return;
            }

            DataTable cambio = CN_TipoCambio.CN_Buscar_TipoCambio_Fecha(
                dtp_fechaEmision.Value.Date);

            decimal venta;
            if (cambio == null ||
                cambio.Rows.Count == 0 ||
                !decimal.TryParse(Convert.ToString(cambio.Rows[0]["Venta"]), out venta) ||
                venta <= 0)
            {
                MessageBox.Show(
                    "No existe un tipo de cambio de venta válido para la fecha seleccionada.",
                    "Moneda de la venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cbo_monedaVenta.SelectedIndex = 0;
                return;
            }

            codigoMonedaVenta = "USD";
            tipoCambioVenta = venta;
            ActualizarResumenMoneda();
        }

        private void dtp_fechaEmision_ValueChanged_Moneda(object sender, EventArgs e)
        {
            if (cbo_monedaVenta != null && cbo_monedaVenta.SelectedIndex == 1)
                cbo_monedaVenta_SelectedIndexChanged(sender, e);
        }

        private void ActualizarResumenMoneda()
        {
            if (txt_resumenMonedaVenta == null)
                return;

            decimal totalSoles;
            if (!decimal.TryParse(txt_totalpagar.Text, out totalSoles))
                totalSoles = 0m;

            if (codigoMonedaVenta == "USD" && tipoCambioVenta > 0)
            {
                decimal totalDolares = Math.Round(totalSoles / tipoCambioVenta, 2);
                txt_resumenMonedaVenta.Text =
                    tipoCambioVenta.ToString("0.000") + " / $ " + totalDolares.ToString("0.00");
            }
            else
            {
                txt_resumenMonedaVenta.Text = "1.000 / S/ " + totalSoles.ToString("0.00");
            }
        }

        private decimal ObtenerImporteMoneda(decimal totalSoles)
        {
            if (codigoMonedaVenta == "USD" && tipoCambioVenta > 0)
                return Math.Round(totalSoles / tipoCambioVenta, 2);

            return Math.Round(totalSoles, 2);
        }

        private static string SoloDigitos(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return string.Empty;

            return new string(valor.Where(char.IsDigit).ToArray());
        }

        private string ObtenerRucEmisor()
        {
            CN_Empresa empresa = new CN_Empresa();
            DataTable datos = empresa.MostrarDatosEmpresa();
            if (datos == null || datos.Rows.Count == 0)
                return string.Empty;

            return Convert.ToString(datos.Rows[0]["nroRuc"]);
        }

        //---------------------------------- METODO PARA TERMINAR LA VENTA -----------------------------------//
        private void btn_terminarVenta_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            frm_TerminarVenta fin = new frm_TerminarVenta();
            frm_print_Ticket imprimir = new frm_print_Ticket();

            int idUsuario = Cls_ModalCategoria.IdUsu;
            if (idUsuario <= 0 ||
                !new CN_CierreCaja().CN_TieneCajaAbiertaUsuario(idUsuario))
            {
                using (Filtro fondoAviso = new Filtro())
                using (frm_Advertencia aviso = new frm_Advertencia())
                {
                    aviso.lbl_msm.Text =
                        "¡Caja requerida!\n\n" +
                        "Su usuario no tiene una caja abierta.\n" +
                        "Abra la caja para continuar con la venta.";
                    fondoAviso.Show();
                    aviso.ShowDialog(this);
                    fondoAviso.Hide();
                }
                return;
            }

            if (!ValidarVenta())
                return;

            // La venta no debe registrarse hasta que el usuario confirme el cobro.
            filtro.Show();
            decimal totalCobroSoles = Convert.ToDecimal(txt_totalpagar.Text);
            fin.txt_Total_acobrar.Text = ObtenerImporteMoneda(totalCobroSoles).ToString("0.00");
            fin.TipoPago = cbo_tipopago.Text;
            fin.NroOperacion = txt_NroOperacion.Text.Trim();
            fin.CodigoMoneda = codigoMonedaVenta;
            fin.TipoCambio = tipoCambioVenta;
            fin.ShowDialog(this);
            filtro.Hide();

            if (fin.Tag == null || fin.Tag.ToString() != "A")
                return;

            try
            {
                RegistrarVentaAtomica();
                EmitirCpeSimulado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "La venta no fue registrada. No se aplicó ningún cambio.\n\n" + ex.Message,
                    "Error al registrar venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Registrar_Archivos_Temporales();

            filtro.Show();
            imprimir.NrDoc = lbl_NroDocu.Text;
            imprimir.lbl_nroDoc.Text = lbl_NroDocu.Text;
            imprimir.TipoDoc = cbo_tipodoc.Text;
            imprimir.ShowDialog(this);
            filtro.Hide();

            tocar_timbreCaja();
            ok.Lbl_msm1.Text = string.IsNullOrWhiteSpace(advertenciaCpeActual)
                ? "¡La venta se ha registrado con éxito! CPE: " + estadoCpeActual
                : "¡Venta registrada! " + advertenciaCpeActual;
            ok.ShowDialog(this);

            Limpiar_venta();
            pnl_sinProd.Visible = true;
            lsv_Pdet.Visible = false;
            CargarDashboardProfesional();
        }

        private void RegistrarVentaAtomica()
        {
            decimal totalSoles = Convert.ToDecimal(txt_totalpagar.Text);
            VentaCompleta venta = new VentaCompleta
            {
                IdCliente = lbl_idcliente.Text.Trim(),
                IdTipoDocumento = Convert.ToInt32(cbo_tipodoc.SelectedValue),
                FechaEmision = dtp_fechaEmision.Value,
                SubTotal = Convert.ToDecimal(lbl_subtotal.Text),
                Igv = Convert.ToDecimal(lbl_igv.Text),
                TotalSoles = totalSoles,
                TipoPago = cbo_tipopago.Text,
                NroOperacion = txt_NroOperacion.Text.Trim(),
                IdUsuario = Convert.ToInt32(Cls_ModalCategoria.IdUsu),
                TotalGanancia = Convert.ToDecimal(lbl_TotalGanancia.Text),
                TotalDescuento = Convert.ToDecimal(lbl_totalDscto.Text),
                CodigoMoneda = codigoMonedaVenta,
                TipoCambio = tipoCambioVenta,
                ImporteMoneda = ObtenerImporteMoneda(totalSoles)
            };

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                ListViewItem item = lsv_Det.Items[i];
                venta.Detalles.Add(new Detalle_Pedido
                {
                    Id_Pro = item.SubItems[0].Text.Trim(),
                    Precio = Convert.ToDouble(item.SubItems[3].Text),
                    Cantidad = Convert.ToDouble(item.SubItems[2].Text),
                    Importe = Convert.ToDouble(item.SubItems[4].Text),
                    Utilidad_Unit = Convert.ToDouble(item.SubItems[5].Text),
                    TotalUtilidad = Convert.ToDouble(item.SubItems[6].Text),
                    DescuentoDet = Convert.ToDouble(item.SubItems[7].Text)
                });
            }

            CN_Venta negocio = new CN_Venta();
            string idPedido;
            string idDocumento;
            negocio.RegistrarVentaCompleta(venta, out idPedido, out idDocumento);

            lbl_NrPedido.Text = idPedido;
            lbl_NroDocu.Text = idDocumento;
            ultimaVentaRegistrada = venta;
        }

        private void EmitirCpeSimulado()
        {
            hashCpeActual = string.Empty;
            advertenciaCpeActual = string.Empty;
            estadoCpeActual = "NO APLICA";

            if (!QrSunatContenido.EsComprobanteElectronico(cbo_tipodoc.Text))
                return;

            try
            {
                decimal totalSoles = Convert.ToDecimal(txt_totalpagar.Text);
                CpeSolicitud solicitud = new CpeSolicitud
                {
                    IdDocumento = lbl_NroDocu.Text.Trim(),
                    TipoComprobante = cbo_tipodoc.Text.Trim(),
                    FechaEmision = dtp_fechaEmision.Value,
                    DocumentoCliente = SoloDigitos(txt_dni.Text),
                    NombreCliente = txt_cliente.Text.Trim(),
                    CodigoMoneda = codigoMonedaVenta,
                    SubTotal = codigoMonedaVenta == "USD"
                        ? ObtenerImporteMoneda(Convert.ToDecimal(lbl_subtotal.Text))
                        : Convert.ToDecimal(lbl_subtotal.Text),
                    Igv = codigoMonedaVenta == "USD"
                        ? ObtenerImporteMoneda(Convert.ToDecimal(lbl_igv.Text))
                        : Convert.ToDecimal(lbl_igv.Text),
                    Total = ObtenerImporteMoneda(totalSoles),
                    Venta = ultimaVentaRegistrada
                };

                CpeResultado resultado =
                    new CN_CpeElectronico().EmitirYGuardar(solicitud);
                hashCpeActual = resultado.Hash;
                estadoCpeActual = resultado.Estado;
            }
            catch (Exception ex)
            {
                estadoCpeActual = "PENDIENTE_SIMULACION";
                advertenciaCpeActual =
                    "El CPE simulado quedó pendiente: " + ex.Message;
            }
        }


        //----------------------------------- METODO LIMPIAR VENTA -------------------------------------------//
        private void Limpiar_venta()
        {
            // 1. LIMPIEZA DE LISTAS
            lsv_Pdet.Items.Clear();
            lsv_Det.Items.Clear();
            cbo_tipopago.SelectedIndex = 0;
            cbo_tipodoc.SelectedIndex = 0;
            ultimaVentaRegistrada = null;
            hashCpeActual = string.Empty;
            estadoCpeActual = "NO APLICA";
            advertenciaCpeActual = string.Empty;
            txt_buscarProd.Text = "";
            txt_buscarProd.Focus();
            Buscar_Cliente_ParalaVenta("C01");
            pnl_sinProd.Visible = true;
            txt_totalpagar.Text = "0.00";
            lbl_igv.Text = "0.00";
            lbl_subtotal.Text = "0.00";
            lbl_NrPedido.Text = "";
            if (cbo_monedaVenta != null)
                cbo_monedaVenta.SelectedIndex = 0;
            btn_reimprimir.Enabled = false;
            btn_terminarVenta.Enabled = true;
            btn_atenderotro.Enabled = true;
        }

        //-------------------------------------- METODO TIMBRE  PEDIDO ---------------------------------------//
        private void tocar_timbreCaja()
        {
            AudioSistema.Reproducir("timbre1.wav");
        }


        //-------------------------------------- METODO GUARDAR PEDIDO ---------------------------------------//
        private void GuardarPedido()
        {
            CN_Pedido obj = new CN_Pedido();
            Pedido ped = new Pedido();
            Detalle_Pedido det = new Detalle_Pedido();
            try
            {
                lbl_NrPedido.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(4);
                ped.Id_Ped = lbl_NrPedido.Text;
                ped.Id_Cliente = lbl_idcliente.Text;
                ped.SubTotal = Convert.ToDouble(lbl_subtotal.Text);
                ped.IgvPed = Convert.ToDouble(lbl_igv.Text);
                ped.TotalPed = Convert.ToDouble(txt_totalpagar.Text);
                ped.Id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                ped.TotalGancia = Convert.ToDouble(lbl_TotalGanancia.Text);
                ped.Total_Dscuento = Convert.ToDouble(lbl_totalDscto.Text);

                obj.CN_Registrar_Pedido(ped);
                if (CD_Pedido.temp_saved == true)
                {
                    CN_TipoDoc.CN_Actualizar_Correlativo(4);
                    det.Id_Ped = lbl_NrPedido.Text;
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];
                        det.Id_Pro = lis.SubItems[0].Text;
                        det.Precio = Convert.ToDouble(lis.SubItems[3].Text);
                        det.Cantidad = Convert.ToDouble(lis.SubItems[2].Text);
                        det.Importe = Convert.ToDouble(lis.SubItems[4].Text);
                        det.Utilidad_Unit = Convert.ToDouble(lis.SubItems[5].Text);
                        det.TotalUtilidad = Convert.ToDouble(lis.SubItems[6].Text);
                        det.DescuentoDet = Convert.ToDouble(lis.SubItems[7].Text);
                        obj.CN_Registrar_DetallePedido(det);

                        if (!CD_Pedido.det_saved)
                        {
                            throw new InvalidOperationException(
                                "No se pudo registrar el producto " + det.Id_Pro +
                                " en el detalle de la venta.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al guardar:" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //------------------------------------ METODO GUARDAR DOCUMENTO --------------------------------------//
        private void Guardar_Documento()
        {
            CN_Documento obj = new CN_Documento();
            Documento doc = new Documento();
            try
            {
                lbl_NroDocu.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(Convert.ToInt32(cbo_tipodoc.SelectedValue));
                doc.Id_Doc = lbl_NroDocu.Text;
                doc.Id_Ped = lbl_NrPedido.Text;
                doc.Id_Tipo = Convert.ToInt32(cbo_tipodoc.SelectedValue);
                doc.Fecha_Emi = dtp_fechaEmision.Value;
                doc.ImporteDoc = Convert.ToDouble(txt_totalpagar.Text);
                doc.TipoPago = cbo_tipopago.Text;
                doc.Nro_Operation = txt_NroOperacion.Text;
                doc.Id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                doc.TotalGanancia = Convert.ToDouble(lbl_TotalGanancia.Text);
                doc.TotalDscuento = Convert.ToDouble(lbl_totalDscto.Text);
                decimal totalSoles = Convert.ToDecimal(txt_totalpagar.Text);
                doc.CodigoMoneda = codigoMonedaVenta;
                doc.TipoCambio = tipoCambioVenta;
                doc.ImporteSoles = Math.Round(totalSoles, 2);
                doc.ImporteMoneda = ObtenerImporteMoneda(totalSoles);

                obj.RegistrarDocumento(doc);
                if (CD_Pedido.temp_saved == true)
                {
                    CN_TipoDoc.CN_Actualizar_Correlativo(Convert.ToInt32(cbo_tipodoc.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                string msm = ex.Message;
                MessageBox.Show("Error al guardar:" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //----------------------------------- METODO GUARDAR INGRESOCAJA -------------------------------------//
        private void Guardar_InresoCaja()
        {
            CN_Caja obj = new CN_Caja();
            Caja caja = new Caja();
            try
            {
                caja.Fecha_Caja = dtp_fechaEmision.Value;
                caja.Tipo_Caja = "Entrada";
                caja.Concepto = "Por Ventas al Publico";
                caja.De_Para = txt_cliente.Text;
                caja.Nro_Doc = lbl_NroDocu.Text;
                caja.ImporteCaja = Convert.ToDouble(txt_totalpagar.Text);
                caja.Id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                caja.TotalUti = Convert.ToDouble(lbl_TotalGanancia.Text);
                caja.TipoPago = cbo_tipopago.Text;
                caja.GeneradoPor = cbo_tipodoc.Text;
                caja.Total_Dscuentos = Convert.ToDouble(lbl_totalDscto.Text);
                decimal totalSoles = Convert.ToDecimal(txt_totalpagar.Text);
                caja.CodigoMoneda = codigoMonedaVenta;
                caja.TipoCambio = tipoCambioVenta;
                caja.ImporteSoles = Math.Round(totalSoles, 2);
                caja.ImporteMoneda = ObtenerImporteMoneda(totalSoles);
                obj.CN_Registrar_Mov_Caja(caja);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //------------------------------------- METODO REGISTRAR KARDEX --------------------------------------//
        private void Registrar_MovimientoKardex()
        {
            CN_Kardex obj = new CN_Kardex();
            Detalle_Kardex kar = new Detalle_Kardex();
            CN_Producto objpro = new CN_Producto();
            DataTable dato = new DataTable();
            DataTable datopro = new DataTable();
            DataTable datapro2 = new DataTable();


            string xidkardex = "";
            int xitem = 0;
            double stockprod = 0;
            double precioCompraProd = 0;
            string xidprod = "";
            double xcantvendida = 0;
            try
            {
                for (int i = 0; i < lsv_Det.Items.Count; i++)
                {
                    var lis = lsv_Det.Items[i];
                    xidprod = lis.SubItems[0].Text;
                    xcantvendida = Convert.ToDouble(lis.SubItems[2].Text);
                    if (obj.Verificar_Kardex_Producto(xidprod) == true)
                    {
                        dato = obj.BuscarKardexPorValor(xidprod.Trim());
                        if (dato.Rows.Count > 0)
                        {
                            xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                            xitem = dato.Rows.Count;

                            datopro = objpro.BuscarProductoID(xidprod.Trim());
                            stockprod = Convert.ToDouble(datopro.Rows[0]["Stock_Actual"]);

                            precioCompraProd = Convert.ToDouble(datopro.Rows[0]["Pre_CompraS"]);

                            //Registramos el detalle de Kardex
                            kar.IdKardex = xidkardex;
                            kar.Item = xitem + 1;
                            kar.Doc_soporte = lbl_NroDocu.Text;
                            kar.Det_Operacion = "Por Ventas al Publico";
                            //Entrada
                            kar.Cantidad_In = 0;
                            kar.Precio_In = 0;
                            kar.Total_In = 0;
                            //Salida
                            kar.Cantidad_Out = xcantvendida;
                            kar.Precio_Out = precioCompraProd;
                            kar.Total_Out = xcantvendida * precioCompraProd;
                            //Saldos
                            kar.Cantidad_saldo = stockprod - xcantvendida;
                            kar.Promedio = precioCompraProd;
                            kar.Total_saldo = precioCompraProd * kar.Cantidad_saldo;
                            kar.Idusu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                            kar.Tipo_operacion = "Ventas";
                            kar.Cant_diferencial = "-";
                            kar.ImporteDiferente = 0;

                            obj.Registrar_DetalleKardex(kar);
                            objpro.RestarStock_Producto(xidprod.Trim(), xcantvendida);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //---------------------------------------- METODO GENERAR QR -----------------------------------------//
        private void GenerarQR(string tipodoc, string totaldoc, string cliente, string nrodoc)
        {
            string ruta = Path.Combine(Application.StartupPath, "CPE_2", "QR_TEMP");

            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            string archivo = Path.Combine(ruta, nrodoc + ".png");

            decimal total;
            decimal igv;
            if (!decimal.TryParse(totaldoc, out total) ||
                !decimal.TryParse(lbl_igv.Text, out igv))
            {
                throw new InvalidOperationException(
                    "No se pudo interpretar el total o el IGV para generar el QR.");
            }

            decimal totalComprobante = codigoMonedaVenta == "USD"
                ? ObtenerImporteMoneda(total)
                : total;
            decimal igvComprobante = codigoMonedaVenta == "USD"
                ? ObtenerImporteMoneda(igv)
                : igv;

            string contenido;
            if (QrSunatContenido.EsComprobanteElectronico(tipodoc))
            {
                contenido = QrSunatContenido.Construir(
                    ObtenerRucEmisor(),
                    tipodoc,
                    nrodoc,
                    igvComprobante,
                    totalComprobante,
                    dtp_fechaEmision.Value,
                    txt_dni.Text,
                    hashCpeActual);
            }
            else
            {
                contenido =
                    "Nro: " + nrodoc + "\n" +
                    "Documento interno: " + tipodoc + "\n" +
                    "Moneda: " + codigoMonedaVenta + "\n" +
                    "Importe cobrado: " + totalComprobante.ToString("0.00") + "\n" +
                    (codigoMonedaVenta == "USD"
                        ? "Tipo de cambio: " + tipoCambioVenta.ToString("0.000000") + "\n" +
                          "Equivalente soles: " + total.ToString("0.00") + "\n"
                        : string.Empty) +
                    "Cliente: " + cliente;
            }

            var generador = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 1200,
                    Height = 1200,
                    Margin = 4,
                    PureBarcode = true
                }
            };

            using (Bitmap imgQR = generador.Write(contenido))
            {
                imgQR.SetResolution(96, 96);
                imgQR.Save(archivo, ImageFormat.Png);
                Image anterior = pic_QR.Image;
                pic_QR.Image = new Bitmap(imgQR);
                if (anterior != null)
                    anterior.Dispose();
            }
        }


        //------------------------------------- METODO CONVERTIR IMAGEN --------------------------------------//
        public static byte[] Convertir_Imagen_Bytes(Image img)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));

            using (MemoryStream memoria = new MemoryStream())
            {
                img.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                return memoria.ToArray();
            }
        }


        //------------------------------ METODO REGISTRAR ARCHIVOS TEMPORALES --------------------------------//
        private void Registrar_Archivos_Temporales()
        {

            CN_Temporal obj = new CN_Temporal();
            string RutaQR = Path.Combine(
                Application.StartupPath,
                "CPE_2",
                "QR_TEMP",
                lbl_NroDocu.Text + ".png");
            // 1️⃣ GENERAR QR
            GenerarQR(
                cbo_tipodoc.Text,
                txt_totalpagar.Text,
                txt_cliente.Text,
                lbl_NroDocu.Text
            );
            try
            {
                // 2️⃣ CABECERA (TEMPORAL)
                Temporal temp = new Temporal();
                temp.CodTem = lbl_NroDocu.Text;
                temp.FechaEmi = dtp_fechaEmision.Value.ToString();
                temp.Cliente = txt_cliente.Text;
                temp.Ruc = txt_dni.Text;
                temp.Direccion = lbl_direccion.Text;
                temp.SubTtal = lbl_subtotal.Text;
                temp.IgvT = lbl_igv.Text;
                temp.TotalT = txt_totalpagar.Text;
                temp.SonT = Lbl_Son.Text;
                temp.Vendedor = "Vendedor: " + Cls_ModalCategoria.Nombre;
                temp.CodigoQr = RutaQR;   // SOLO la ruta
                temp.HashCpe = string.IsNullOrWhiteSpace(hashCpeActual)
                    ? "-" : hashCpeActual;
                temp.MotivoEmi = "Ventas";
                temp.TipoPago = cbo_tipopago.Text;

                string tipocomprobante = cbo_tipodoc.Text.Trim();
                if (tipocomprobante == "Factura")
                    temp.Tipocomprobante = "Factura";
                else if (tipocomprobante == "Boleta")
                    temp.Tipocomprobante = "Boleta Venta";
                else
                    temp.Tipocomprobante = "Nota de Venta";

                obj.CN_RegistrarTemporal(temp);
                // 4️⃣ GUARDAR DETALLE
                if (CD_Temporal.temp_saved)
                {
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var lis = lsv_Det.Items[i];

                        Detalle_Temporal detalle = new Detalle_Temporal();
                        detalle.CodTem = lbl_NroDocu.Text;
                        detalle.CodPro = lis.SubItems[0].Text;
                        detalle.Producto = lis.SubItems[1].Text;
                        detalle.Cantidad = lis.SubItems[2].Text;
                        detalle.Pre_Unt = lis.SubItems[3].Text;
                        detalle.ImporteT = lis.SubItems[4].Text;

                        obj.CN_DetalleTemporal(detalle);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la cabecera del comprobante");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar comprobante: " + ex.Message);
            }

        }


        //----------------------------- EVENTO CREAR NUEVO PRODUCTO ------------------------------------------//
        private void crearNuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto pro = new frmProducto();
            pro.ShowDialog(this);
        }

        //------------------------------ EVENTO ATENDER OTRO PEDIDO ------------------------------------------//
        private bool ValidarPedido()
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            if (lsv_Det.Items.Count == 0) { filtro.Show(); ver.lbl_msm.Text = "Por favor, ingresa un producto al carrito"; ver.ShowDialog(this); filtro.Hide(); return false; }
            if (lbl_idcliente.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Por favor, ingresa un cliente para la venta"; ver.ShowDialog(this); filtro.Hide(); return false; }

            return true;

        }

        //------------------------------ EVENTO ATENDER OTRO PEDIDO ------------------------------------------//
        private void btn_atenderotro_Click(object sender, EventArgs e)
        {
            if (ValidarPedido() == true)
            {
                GuardarPedido();
                if (CD_Pedido.temp_saved == true && CD_Pedido.det_saved == true)
                {
                    txt_buscarcomprobante.Text = lbl_NrPedido.Text;
                    Limpiar_venta();
                    pnl_sinProd.Visible = false;
                }
            }
        }

        //--------------------------- EVENTO BUSCAR DOCUMENTO PARA REIMPRIMIR --------------------------------//
        private void lbl_buscarDoc_Click(object sender, EventArgs e)
        {
            if (chk_coti.Checked == true)
            {
                Buscar_Pedido_ParaAtender(txt_buscarcomprobante.Text);
            }
            else
            {
                Buscar_Documento_ParaReimprimir(txt_buscarcomprobante.Text);
            }
        }

        //---------------------------- METODO BUSCAR PEDIDO PARA ATENDER -------------------------------------//
        private void Buscar_Pedido_ParaAtender(string idpedido)
        {
            CN_Pedido obj = new CN_Pedido();
            DataTable data = new DataTable();
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();

            string EstadoPed = "";
            double cantidad = 0;
            double CantBD = 0;
            string idprod = "";

            data = obj.CN_Buscar_PedidoId(idpedido);
            if (data.Rows.Count > 0)
            {
                var dt = data.Rows[0];
                lbl_NrPedido.Text = dt["Id_Ped"].ToString();
                lbl_idcliente.Text = dt["id_cliente"].ToString();
                txt_cliente.Text = dt["Razon_Social_Nombres"].ToString();
                txt_dni.Text = dt["DNI"].ToString();
                lbl_direccion.Text = dt["Direccion"].ToString();
                EstadoPed = dt["Estado_Ped"].ToString();

                if (EstadoPed.Trim() == "ATENDIDO")
                {
                    fil.Show();
                    ver.lbl_msm.Text = "Este pedido ya fue atendido y no se puede modificar.";
                    ver.ShowDialog(this);
                    fil.Hide();
                    return;
                }
                lsv_Det.Items.Clear();
                foreach (DataRow xitem in data.Rows)
                {
                    ListViewItem xlist;
                    cantidad = Convert.ToDouble(xitem["Cantidad"]);
                    idprod = xitem["Id_Pro"].ToString();
                    CantBD = get_StockProducto(idprod);

                    if (CantBD <= 0)
                    {
                        fil.Show();
                        ver.lbl_msm.Text = $"El producto {xitem["Descripcion_Larga"]} no tiene stock disponible.";
                        ver.ShowDialog(this);
                        fil.Hide();
                    }
                    else if (CantBD >= cantidad)
                    {
                        // Stock suficiente → carga normal
                        xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                        xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                        xlist.SubItems.Add(cantidad.ToString());
                        xlist.SubItems.Add(xitem["Precio"].ToString());
                        xlist.SubItems.Add(xitem["Importe"].ToString());
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                        xlist.SubItems.Add(xitem["DescuentoDet"].ToString());
                    }
                    else
                    {
                        // Stock insuficiente → carga lo que hay
                        fil.Show();
                        ver.lbl_msm.Text = $"Stock insuficiente para {xitem["Descripcion_Larga"]}. Se cargará solo {CantBD}.";
                        ver.ShowDialog(this);
                        fil.Hide();

                        xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                        xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                        xlist.SubItems.Add(CantBD.ToString());
                        xlist.SubItems.Add(xitem["Precio"].ToString());
                        xlist.SubItems.Add(xitem["Importe"].ToString());
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                        xlist.SubItems.Add(xitem["DescuentoDet"].ToString());
                    }
                }
                Calcular_ImportePagar();
                pnl_sinProd.Visible = false;
            }
        }

        //---------------------------- METODO OBTENER STOCK PRODUCTO -----------------------------------------//
        private double get_StockProducto(string idprod)
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();
            double cantidad = 0;
            data = obj.BuscarProductoID(idprod);
            if (data.Rows.Count > 0)
            {
                cantidad = Convert.ToDouble(data.Rows[0]["Stock_Actual"]);
            }
            return cantidad;
        }

        //---------------------- METODO BUSCAR DOCUMENTO PARA REIMPRIMIR -------------------------------------//
        private void anularComprobanteDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_AnularVenta anular = new frm_AnularVenta();
            anular.ShowDialog(this);
        }

        #endregion

        #region Sesccion_Explorador_Docs
        private void Configura_ListView_Docs()
        {
            var lis = lsv_docs;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lis.Columns.Add("ID Doc", 160, HorizontalAlignment.Center);
            lis.Columns.Add("Fecha Emi", 190, HorizontalAlignment.Center);
            lis.Columns.Add("Nombre Cliente", 250, HorizontalAlignment.Center);
            lis.Columns.Add("Tipo Doc", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Nro Pedido", 130, HorizontalAlignment.Center);
            lis.Columns.Add("Tipo Pago", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Total S/", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Estado", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Estado CPE", 160, HorizontalAlignment.Center);
        }

        private void LLenarProducto_Carrito(DataTable data)
        {
            Dictionary<string, string> estadosCpe =
                new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                DataTable estados = new CN_CpeElectronico().ListarEstados();
                foreach (DataRow estado in estados.Rows)
                {
                    estadosCpe[Convert.ToString(estado["IdDocumento"]).Trim()] =
                        Convert.ToString(estado["EstadoCpe"]).Trim();
                }
            }
            catch
            {
                // La instalación puede estar todavía pendiente de la migración CPE.
            }

            lsv_docs.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem lis = new ListViewItem(dr["id_Doc"].ToString());
                lis.SubItems.Add(dr["Fecha_Emi"].ToString());
                lis.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                lis.SubItems.Add(dr["Documento"].ToString());
                lis.SubItems.Add(dr["id_Ped"].ToString());
                lis.SubItems.Add(dr["TipoPago"].ToString());
                lis.SubItems.Add(dr["ImporteDoc"].ToString());
                lis.SubItems.Add(dr["Estado_Doc"].ToString());
                string idDocumento = dr["id_Doc"].ToString().Trim();
                string estadoCpe;
                if (!estadosCpe.TryGetValue(idDocumento, out estadoCpe))
                {
                    string tipo = dr["Documento"].ToString().Trim();
                    estadoCpe = QrSunatContenido.EsComprobanteElectronico(tipo)
                        ? "PENDIENTE" : "NO APLICA";
                }
                lis.SubItems.Add(estadoCpe);
                lis.SubItems.Add(dr["Nombres"].ToString());

                lsv_docs.Items.Add(lis);
            }
            PintasFila();
            pnl_msmDoc.Visible = false;
            lbl_TotalDocs.Text = lsv_docs.Items.Count.ToString();
        }

        private void PintasFila()
        {
            string tipoDoc = "";
            int cont = 1;
            for (int i = 0; i < lsv_docs.Items.Count; i++)
            {
                tipoDoc = lsv_docs.Items[i].SubItems[3].Text;

                if (tipoDoc.Trim() == "Factura")
                {
                    lsv_docs.Items[i].BackColor = Color.WhiteSmoke;
                }
                else if (tipoDoc.Trim() == "Boleta")
                {
                    lsv_docs.Items[i].BackColor = Color.MistyRose;
                }
                else if (tipoDoc.Trim() == "Nota Venta")
                {
                    lsv_docs.Items[i].BackColor = Color.Gainsboro;
                }
                cont += 1;
            }
        }

        private void btn_cerrarVenta_Click(object sender, EventArgs e)
        {
            if (ElTab1.TabPages.Contains(tabpage_venta))
            {
                ElTab1.TabPages.Remove(tabpage_venta);
            }
        }

        private void Cargar_Todos_Ventas()
        {
            CN_Documento obj = new CN_Documento();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Documentos();
            if (data.Rows.Count > 0)
            {
                LLenarProducto_Carrito(data);
            }
            else
            {
                lsv_docs.Items.Clear();
                pnl_msmDoc.Visible = true;

            }
        }

        private void Buscar_General_Documentos(string valor)
        {
            CN_Documento obj = new CN_Documento();
            DataTable data = new DataTable();
            data = obj.CN_Buscar_DocumentoId(valor);
            if (data.Rows.Count > 0)
            {
                LLenarProducto_Carrito(data);
            }
            else
            {
                lsv_docs.Items.Clear();
                pnl_msmDoc.Visible = true;
            }

        }

        private void Buscar_Documentos_Pordia(DateTime xdia)
        {
            CN_Documento obj = new CN_Documento();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Documentos_Pordia(xdia);
            if (data.Rows.Count > 0)
            {
                LLenarProducto_Carrito(data);
            }
            else
            {
                lsv_docs.Items.Clear();
                pnl_msmDoc.Visible = true;
            }

        }

        private void Buscar_Documentos_PorMes(DateTime fechaMes)
        {
            CN_Documento obj = new CN_Documento();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Facturas_Emitidas_Mes(fechaMes);

            if (data.Rows.Count > 0)
            {
                LLenarProducto_Carrito(data);
            }
            else
            {
                lsv_docs.Items.Clear();
                pnl_msmDoc.Visible = true;
            }
        }

        private void Buscar_Documentos_PorRangoFecha(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
            {
                MessageBox.Show("La fecha inicio no puede ser mayor que la fecha fin",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CN_Documento obj = new CN_Documento();
            DataTable data = obj.CN_Listar_Facturas_Emitidas_Rango(inicio, fin);

            if (data.Rows.Count > 0)
            {
                LLenarProducto_Carrito(data);
            }
            else
            {
                lsv_docs.Items.Clear();
                pnl_msmDoc.Visible = true;
            }
        }

        private void Buscar_Documentos_PorMes_Tipo(DateTime fechaMes, int tipoDoc)
        {
            CN_Documento obj = new CN_Documento();
            DataTable data =
                obj.CN_Listar_Comprobantes_Emitidos_Mes(fechaMes, tipoDoc);

            if (data.Rows.Count > 0)
            {
                LLenarProducto_Carrito(data);
            }
            else
            {
                lsv_docs.Items.Clear();
                pnl_msmDoc.Visible = true;
            }
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Ventas();
            lsv_docs.ContextMenuStrip = ConsultarFechaMenuStrip1;
        }

        private void ConsultarDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_SoloFecha fecha = new frm_SoloFecha();
            DateTime dia;
            fil.Show();
            fecha.ShowDialog(this);
            fil.Hide();
            if (fecha.Tag.ToString() == "A")
            {
                dia = fecha.dtp_fn.Value;
                Buscar_Documentos_Pordia(dia);
            }
        }

        private void txt_buscarDocs_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscarDocs.Text.Trim().Length > 2)
            {
                Buscar_General_Documentos(txt_buscarDocs.Text);
            }
        }

        private void CopiarNroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_softmsm msm = new frm_softmsm();
            if (lsv_docs.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Seleciona el Item que desea Copiar";
                ver.ShowDialog(this);
                fil.Hide();
            }
            else
            {
                var lis = lsv_docs.SelectedItems[0];
                string idDoc = lis.SubItems[0].Text;
                Clipboard.Clear();
                Clipboard.SetText(idDoc.Trim());
                msm.Lbl_msm.Text = "El item fue Copiado al Portapaeles";
                msm.ShowDialog(this);
            }
        }

        private void verComprobantesEmitidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (tabDocsGuardada != null)
            {
                if (!ElTab1.TabPages.Contains(tabDocsGuardada))
                {
                    ElTab1.TabPages.Add(tabDocsGuardada);
                }
                ElTab1.SelectedTab = tabDocsGuardada;
                Configura_ListView_Docs();
                Buscar_Documentos_Pordia(DateTime.Now);
                txt_buscarDocs.Focus();
            }
            else
            {
                MessageBox.Show("No se encontró la pestaña de documentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ConsultarMesTool_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frmSoloMes mes = new frmSoloMes();
            DateTime fechaMes;

            fil.Show();
            mes.ShowDialog(this);
            fil.Hide();

            if (mes.Tag != null && mes.Tag.ToString() == "A")
            {
                fechaMes = mes.dtp_mes.Value;
                Buscar_Documentos_PorMes(fechaMes);
            }
        }

        private void ConsultarFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Fecha_InicioFin rango = new frm_Fecha_InicioFin();
            DateTime fechaInicio, fechaFin;

            fil.Show();
            rango.ShowDialog(this);
            fil.Hide();

            if (rango.Tag != null && rango.Tag.ToString() == "A")
            {
                fechaInicio = rango.dtp_inicio.Value.Date;
                fechaFin = rango.dtp_fin.Value.Date;

                Buscar_Documentos_PorRangoFecha(fechaInicio, fechaFin);
            }
        }

        private void ConsultarDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Mes_Doc doc = new frm_Mes_Doc();
            DateTime fechaMes;
            int tipoDoc;

            fil.Show();
            doc.ShowDialog(this);
            fil.Hide();

            if (doc.Tag != null && doc.Tag.ToString() == "A")
            {
                fechaMes = doc.dtp_mes.Value.Date;
                tipoDoc = Convert.ToInt32(doc.cbo_tipoDoC.SelectedValue);

                Buscar_Documentos_PorMes_Tipo(fechaMes, tipoDoc);
            }
        }

        private void canjearNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Canjear_Doc canje = new frm_Canjear_Doc();
            fil.Show();
            canje.ShowDialog(this);
            fil.Hide();

        }

        private void reimprimirDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_softmsm msm = new frm_softmsm();
            if (lsv_docs.SelectedItems.Count > 0)
            {
                var lis = lsv_docs.SelectedItems[0];
                string idDoc = lis.SubItems[0].Text;

                Limpiar_venta();
                Buscar_Documento_ParaReimprimir(idDoc);
                if (lsv_Det.Items.Count > 0)
                {
                    pnl_sinProd.Visible = false;
                }
                // --------------------------

                btn_reimprimir_Click(sender, e);
                Limpiar_venta();
                pnl_sinProd.Visible = true; 

                ElTab1.SelectedTab = tabVentaGuardada;
                txt_buscarProd.Focus();
            }
        }

        private void Buscar_Documento_ParaReimprimir(string nroDoc)
        {
            CN_Documento obj = new CN_Documento();
            DataTable data = new DataTable();
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            string estadoDoc = "";
            string tipodoc = "";
            try
            {
                data = obj.CN_Buscar_DocumentoDetalleId(nroDoc);
                if (data.Rows.Count > 0)
                {
                    var dt = data.Rows[0];
                    estadoDoc = Convert.ToString(dt["Estado_doc"]);
                    tipodoc = Convert.ToString(dt["Documento"]);

                    //Llenar datos del documento en el formulario
                    lbl_NroDocu.Text = Convert.ToString(dt["Id_Doc"]);
                    lbl_NrPedido.Text = Convert.ToString(dt["id_Ped"]);
                    cbo_tipodoc.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
                    dtp_fechaEmision.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                    cbo_tipopago.Text = Convert.ToString(dt["TipoPago"]);
                    lbl_idcliente.Text = Convert.ToString(dt["id_cliente"]);
                    txt_cliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                    lbl_direccion.Text = Convert.ToString(dt["Direccion"]);
                    txt_dni.Text = Convert.ToString(dt["DNI"]);

                    //Llenar detalle del documento
                    foreach (DataRow xitem in data.Rows)
                    {
                        ListViewItem xlist;
                        xlist = lsv_Det.Items.Add(xitem["Id_Pro"].ToString());
                        xlist.SubItems.Add(xitem["Descripcion_Larga"].ToString());
                        xlist.SubItems.Add(xitem["Cantidad"].ToString());
                        xlist.SubItems.Add(xitem["Precio"].ToString());
                        xlist.SubItems.Add(xitem["Importe"].ToString());
                        xlist.SubItems.Add(xitem["Utilidad_Unit"].ToString());
                        xlist.SubItems.Add(xitem["TotalUtilidad"].ToString());
                        xlist.SubItems.Add(xitem["DescuentoDet"].ToString());
                    }
                    Calcular_ImportePagar();
                    pnl_sinProd.Visible = false;
                    btn_reimprimir.Enabled = true;
                    btn_terminarVenta.Enabled = false;
                    btn_atenderotro.Enabled = false;

                }

                else
                {
                    fil.Show();
                    ver.lbl_msm.Text = "¡No se encontró ningún documento con el número ingresado!";
                    ver.ShowDialog(this);
                    fil.Hide();
                    return;
                }
            }
            catch (Exception ex)
            {
                fil.Show();
                ver.lbl_msm.Text = "¡Ocurrió un error al buscar el documento! \n" + ex.Message;
                ver.ShowDialog(this);
                fil.Hide();
                return;
            }
        }

        private void btn_reimprimir_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_print_Ticket imprimir = new frm_print_Ticket();
            if (ValidarVenta())
            {
                Registrar_Archivos_Temporales();
                fill.Show();
                imprimir.NrDoc = lbl_NroDocu.Text;
                imprimir.lbl_nroDoc.Text = lbl_NroDocu.Text;
                imprimir.TipoDoc = "nota";
                imprimir.ShowDialog(this);
                fill.Hide();
                Limpiar_venta();
                pnl_sinProd.Visible = false;
            }
        }

        private void traspasoDeIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_EntradasProd entrada = new frm_EntradasProd();
            fill.Show();
            entrada.ShowDialog(this);
            fill.Hide();
            if (entrada.Tag != null && entrada.Tag.ToString() == "A")
            {
                // Solo procesar si el usuario seleccionó algo y el Tag es "A"
            }
        }
        private void btn_cerrarFactura_Click(object sender, EventArgs e)
        {
            if (ElTab1.TabPages.Contains(tabDocsGuardada))
            {
                ElTab1.TabPages.Remove(tabDocsGuardada);
            }
        }


        #endregion

        #region explorador de Productos

        private void PintasFilaAlmacen()
        {
            for (int i = 0; i < lsvAlmacen.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lsvAlmacen.Items[i].BackColor = Color.White;
                }
                else
                {
                    lsvAlmacen.Items[i].BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void Configura_ListView_Productos_Almacen()
        {
            var lis = lsvAlmacen;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            imagenesProductosAlmacen.ImageSize = new Size(64, 52);
            imagenesProductosAlmacen.ColorDepth = ColorDepth.Depth32Bit;
            lis.SmallImageList = imagenesProductosAlmacen;
            lis.Columns.Add("ID / Foto", 185, HorizontalAlignment.Left);
            lis.Columns.Add("Nombre del Producto", 290, HorizontalAlignment.Left);
            lis.Columns.Add("Categoría", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Presentación", 90, HorizontalAlignment.Center);
            lis.Columns.Add("Stock", 75, HorizontalAlignment.Center);
            lis.Columns.Add("Pre-Compra", 85, HorizontalAlignment.Center);
            lis.Columns.Add("Pre-Venta", 85, HorizontalAlignment.Center);
            lis.Columns.Add("Utilidad", 75, HorizontalAlignment.Center);
            lis.Columns.Add("Costo Total", 90, HorizontalAlignment.Center);
            lis.Columns.Add("Estado", 75, HorizontalAlignment.Center);
            lis.Columns.Add("Laboratorio", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Fecha Ingreso", 125, HorizontalAlignment.Center);
            lis.Columns.Add("Vencimiento", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Foto", 0, HorizontalAlignment.Center);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ElTab1.TabPages.Contains(tabpage_almacen))
            {
                ElTab1.TabPages.Remove(tabpage_almacen);
            }
        }
        private void LLenar_Producto_Almacen(DataTable data)
        {
            MostrarCargaProductos(data.Rows.Count);
            lsvAlmacen.BeginUpdate();
            try
            {
                pnl_almacen.Visible = false;
                lsvAlmacen.Items.Clear();
                imagenesProductosAlmacen.Images.Clear();

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    ListViewItem lis = new ListViewItem(dr["Id_Pro"].ToString());
                    string rutaFoto = Convert.ToString(dr["Foto"]);
                    string claveImagen = "producto_" + i;
                    imagenesProductosAlmacen.Images.Add(
                        claveImagen, CargarMiniaturaProducto(rutaFoto));
                    lis.ImageKey = claveImagen;
                    lis.SubItems.Add(dr["Descripcion_Larga"].ToString());
                    lis.SubItems.Add(dr["Categoria"].ToString());
                    lis.SubItems.Add(dr["Frmto_Compra"].ToString());
                    lis.SubItems.Add(dr["Stock_Actual"].ToString());
                    lis.SubItems.Add(Convert.ToDouble(dr["Pre_CompraS"]).ToString("###0.00"));
                    lis.SubItems.Add(Convert.ToDouble(dr["Pre_venta"]).ToString("###0.00"));
                    lis.SubItems.Add(Convert.ToDouble(dr["UtilidadUnit"]).ToString("###0.00"));
                    lis.SubItems.Add(Convert.ToDouble(dr["Valor_porCant"]).ToString("###0.00"));
                    lis.SubItems.Add(dr["Estado_Pro"].ToString());
                    lis.SubItems.Add(dr["Laboratorio"].ToString());
                    lis.SubItems.Add(dr["FechaIngreso"].ToString());
                    lis.SubItems.Add(dr["FechaVncmnto"].ToString());
                    lis.SubItems.Add(dr["Foto"].ToString());
                    lsvAlmacen.Items.Add(lis);

                    if (i % 10 == 0 || i == data.Rows.Count - 1)
                    {
                        circuloCargaProductos.Value = i + 1;
                        etiquetaCargaProductos.Text =
                            "Cargando productos... " + (i + 1) + " de " + data.Rows.Count;
                        panelCargaProductos.Refresh();
                        Application.DoEvents();
                    }
                }
                PintasFilaAlmacen();
                pnl_movim.Visible = false;
                lbl_totalAlmacen.Text = lsvAlmacen.Items.Count.ToString();
            }
            finally
            {
                lsvAlmacen.EndUpdate();
                OcultarCargaProductos();
            }
        }

        private Image CargarMiniaturaProducto(string rutaFoto)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(rutaFoto) &&
                    rutaFoto != "-" &&
                    System.IO.File.Exists(rutaFoto))
                {
                    using (Image original = Image.FromFile(rutaFoto))
                    {
                        return CrearMiniaturaAjustada(original, new Size(64, 52));
                    }
                }
            }
            catch
            {
                // Una foto dañada no debe impedir mostrar todo el catálogo.
            }

            return CrearMiniaturaAjustada(Properties.Resources.Imagen7, new Size(64, 52));
        }

        private Image CrearMiniaturaAjustada(Image imagen, Size tamaño)
        {
            Bitmap miniatura = new Bitmap(tamaño.Width, tamaño.Height);
            using (Graphics grafico = Graphics.FromImage(miniatura))
            {
                grafico.Clear(Color.White);
                grafico.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // El catálogo usa una miniatura rectangular para aprovechar
                // completamente la altura de la fila y evitar franjas vacías.
                grafico.DrawImage(imagen, 0, 0, tamaño.Width, tamaño.Height);
            }
            return miniatura;
        }

        private void ConstruirCapaCargaProductos()
        {
            panelCargaProductos = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Visible = false
            };
            circuloCargaProductos = new Guna2CircleProgressBar
            {
                Size = new Size(120, 120),
                Location = new Point(
                    (guna2GroupBox7.ClientSize.Width - 120) / 2,
                    180),
                FillColor = Color.Gainsboro,
                ProgressColor = Color.FromArgb(156, 39, 176),
                ProgressColor2 = Color.FromArgb(255, 128, 0),
            };
            circuloCargaProductos.ShadowDecoration.Mode =
                Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            etiquetaCargaProductos = new Label
            {
                AutoSize = false,
                Size = new Size(420, 36),
                Location = new Point(
                    (guna2GroupBox7.ClientSize.Width - 420) / 2,
                    315),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Semibold", 13F),
                ForeColor = Color.DimGray,
                Text = "Cargando productos..."
            };
            panelCargaProductos.Controls.Add(circuloCargaProductos);
            panelCargaProductos.Controls.Add(etiquetaCargaProductos);
            guna2GroupBox7.Controls.Add(panelCargaProductos);
        }

        private void MostrarCargaProductos(int total)
        {
            circuloCargaProductos.Minimum = 0;
            circuloCargaProductos.Maximum = Math.Max(1, total);
            circuloCargaProductos.Value = 0;
            etiquetaCargaProductos.Text = "Cargando productos...";
            panelCargaProductos.Visible = true;
            panelCargaProductos.BringToFront();
            panelCargaProductos.Refresh();
            Application.DoEvents();
        }

        private void OcultarCargaProductos()
        {
            panelCargaProductos.Visible = false;
        }

        private void Cargar_Todos_Productos_Almacen()
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();
            data = obj.CargarTodos_Productos();
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Almacen(data);
            }
            else
            {
                lsvAlmacen.Items.Clear();
                pnl_almacen.Visible = true;
            }
        }
        private void Buscar_Producto_Almacen(string valor)
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();
            data = obj.BuscarProductoID(valor);
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Almacen(data);
            }
            else
            {
                lsvAlmacen.Items.Clear();
                pnl_almacen.Visible = true;
            }
        }
        private void txt_buscarAlmacen_TextChanged(object sender, EventArgs e)
        {
            string valor = txt_buscarAlmacen.Text.Trim();
            if (valor.Length == 0)
            {
                Cargar_Todos_Productos_Almacen();
            }
            else if (valor.Length >= 2)
            {
                Buscar_Producto_Almacen(valor);
            }
        }
        private void txt_buscarAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscarAlmacen.Text.Trim().Length >= 2)
                {
                    Buscar_Producto_Almacen(txt_buscarAlmacen.Text);
                }
                else
                {
                    Cargar_Todos_Productos_Almacen();
                }
            }
        }
        private void Mostrar_AlmacenesStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Productos_Almacen();
            lsvAlmacen.ContextMenuStrip = Consultar_Almacen_MenuStrip1;
        }
        private void Copiar_IdAlmacenStripMenuItem2_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_softmsm msm = new frm_softmsm();

            if (lsvAlmacen.SelectedIndices.Count == 0)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Seleciona el Item que desea Copiar";
                ver.ShowDialog(this);
                filtro.Hide();
            }
            else
            {
                var lis = lsvAlmacen.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                Clipboard.Clear();
                Clipboard.SetText(idProd.Trim());
                msm.Lbl_msm.Text = "El item fue Copiado al Portapapeles";
                msm.ShowDialog(this);
            }
        }
        private void btn_AgregarAlmacen_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frmProducto pro = new frmProducto();
            filtro.Show();
            pro.ShowDialog(this);
            filtro.Hide();

        }
        private void btn_editarAlmacen_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_softmsm msm = new frm_softmsm();
            frmEditarProducto editar = new frmEditarProducto();

            if (lsvAlmacen.SelectedIndices.Count == 0)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Seleciona el Item que desea Editar";
                ver.ShowDialog(this);
                filtro.Hide();
            }
            else
            {
                var lis = lsvAlmacen.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                filtro.Show();
                editar.Tag = idProd;
                editar.ShowDialog(this);
                filtro.Hide();

                if (editar.Tag.ToString() == "A")
                {
                    Buscar_Producto_Almacen(idProd);
                }

            }
        }
        private void btn_eliminarAlmacen_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            CN_Producto obj = new CN_Producto();
            CN_Kardex kardex = new CN_Kardex();
            DataTable datakar = new DataTable();
            frm_Si_No sino = new frm_Si_No();

            string idKard = "";
            string descripcion = "";

            if (lsvAlmacen.SelectedItems.Count == 0)
            {
                filtro.Show();
                ver.lbl_msm.Text = "Seleciona el Item que desea Eliminar";
                ver.ShowDialog(this);
                filtro.Hide();
            }
            else
            {
                var lis = lsvAlmacen.SelectedItems[0];
                string idProd = lis.SubItems[0].Text;
                descripcion = lis.SubItems[1].Text;

                filtro.Show();
                sino.lbl_msm.Text = $"¿Estás seguro de eliminar el producto {descripcion}?";
                sino.ShowDialog(this);
                filtro.Hide();

                if (sino.Tag.ToString() == "Si")
                {
                    datakar = kardex.BuscarKardexPorValor(idProd.Trim());
                    if (datakar.Rows.Count > 0)
                    {
                        idKard = datakar.Rows[0]["Id_Krdx"].ToString();
                        obj.EliminarProducto(idProd, idKard);
                        Buscar_Producto_Almacen(idProd);
                    }
                    else
                    {
                        obj.EliminarProducto(idProd, idKard);
                    }

                }

            }
        }
        private void catalogoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (tabAlmacenGuardada != null)
            {
                if (!ElTab1.TabPages.Contains(tabAlmacenGuardada))
                {
                    ElTab1.TabPages.Add(tabAlmacenGuardada);
                }
                ElTab1.SelectedTab = tabAlmacenGuardada;
                Cargar_Todos_Productos_Almacen();
                txt_buscarAlmacen.Focus();
            }
            else
            {
                MessageBox.Show(
                    "No se encontró la pestaña de Almacén",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #endregion

        #region Explorador de movimiento de caja


        private void PintasFilaMovimiento()
        {
            for (int i = 0; i < lsv_movim.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lsv_movim.Items[i].BackColor = Color.White;
                }
                else
                {
                    lsv_movim.Items[i].BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void Configura_ListView_Productos_Movimiento()
        {
            var lis = lsv_movim;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lis.Columns.Add("ID", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Nro Doc", 160, HorizontalAlignment.Center);
            lis.Columns.Add("Nombre del Cliente", 147, HorizontalAlignment.Center);
            lis.Columns.Add("Fecha", 140, HorizontalAlignment.Center);
            lis.Columns.Add("Tipo Caja", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Concepto", 170, HorizontalAlignment.Center);
            lis.Columns.Add("Total S/", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Utilid S/", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Tipo Pago", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Generado Por", 160, HorizontalAlignment.Center);
            lis.Columns.Add("Estado", 160, HorizontalAlignment.Center);
        }

        private void LLenar_Producto_Movimiento(DataTable data)
        {
            lsv_movim.Items.Clear();
            double TotalCoti = 0;
            double saldocred = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem lis = new ListViewItem(dr["Idcaja"].ToString());
                lis.SubItems.Add(dr["Nro_Doc"].ToString());
                lis.SubItems.Add(dr["De_Para"].ToString());
                lis.SubItems.Add(dr["Fecha_Caja"].ToString());
                lis.SubItems.Add(dr["Tipo_Caja"].ToString());
                lis.SubItems.Add(NormalizarTextoMovimiento(dr["Concepto"].ToString()));
                TotalCoti = Convert.ToDouble(dr["ImporteCaja"]);
                lis.SubItems.Add(TotalCoti.ToString("###0.00"));

                saldocred = Convert.ToDouble(dr["TotalUti"]);
                lis.SubItems.Add(saldocred.ToString("###0.00"));

                lis.SubItems.Add(dr["TipoPago"].ToString());
                lis.SubItems.Add(dr["GeneradoPor"].ToString());
                lis.SubItems.Add(dr["EstadoCaja"].ToString());
                lsv_movim.Items.Add(lis);
            }
            PintasFilaMovimiento();
            pnl_movim.Visible = false;
            lbl_totalmovi.Text = lsv_movim.Items.Count.ToString();
        }


        private void Cargar_Todos_Movimiento()
        {
            CN_Caja obj = new CN_Caja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Todas_Cajas();
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Movimiento(data);
            }
            else
            {
                lsv_movim.Items.Clear();
                pnl_movim.Visible = true;
            }
        }


        private void Buscar_Producto_Movimiento(string valor)
        {
            CN_Caja obj = new CN_Caja();
            DataTable data = new DataTable();
            data = obj.CN_Buscador_General_Cajas(valor);
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Movimiento(data);
            }
            else
            {
                lsv_movim.Items.Clear();
                pnl_movim.Visible = true;
            }
        }



        private void Buscar_Producto_MovimientoporDia(DateTime xdia)
        {
            CN_Caja obj = new CN_Caja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cajas_DelDia(xdia);
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Movimiento(data);
            }
            else
            {
                lsv_movim.Items.Clear();
                pnl_movim.Visible = true;
            }
        }



        private void Buscar_Producto_MovimientoporMes(DateTime xdia)
        {
            CN_Caja obj = new CN_Caja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cajas_DelMes(xdia);
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Movimiento(data);
            }
            else
            {
                lsv_movim.Items.Clear();
                pnl_movim.Visible = true;
            }
        }

        private void Buscar_Caja_porRangoFecha(DateTime xdesde, DateTime hastax)
        {
            CN_Caja obj = new CN_Caja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cajas_PorRangoFecha(xdesde, hastax);
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Movimiento(data);
            }
            else
            {
                lsv_movim.Items.Clear();
                pnl_movim.Visible = true;
            }
        }


        private void Buscar_Caja_porMes_TipoDoc(DateTime xdesde, string tipodoc)
        {
            CN_Caja obj = new CN_Caja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cajas_PorMes_TipoDoc(xdesde, tipodoc);
            if (data.Rows.Count > 0)
            {
                LLenar_Producto_Movimiento(data);
            }
            else
            {
                lsv_movim.Items.Clear();
                pnl_movim.Visible = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cargar_Todos_Movimiento();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_softmsm msm = new frm_softmsm();
            if (lsv_movim.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Seleciona el Item que desea Copiar";
                ver.ShowDialog(this);
                fil.Hide();
            }
            else
            {
                var lis = lsv_movim.SelectedItems[0];
                string idDoc = lis.SubItems[1].Text;
                Clipboard.Clear();
                Clipboard.SetText(idDoc.Trim());
                msm.Lbl_msm.Text = "El item fue Copiado al Portapaeles";
                msm.ShowDialog(this);
            }
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_SoloFecha fecha = new frm_SoloFecha();
            DateTime dia;
            fil.Show();
            fecha.ShowDialog(this);
            fil.Hide();
            if (fecha.Tag.ToString() == "A")
            {
                dia = fecha.dtp_fn.Value;
                Buscar_Producto_MovimientoporDia(dia);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_SoloFecha fecha = new frm_SoloFecha();
            DateTime dia;
            fil.Show();
            fecha.ShowDialog(this);
            fil.Hide();
            if (fecha.Tag.ToString() == "A")
            {
                dia = fecha.dtp_fn.Value;
                Buscar_Producto_MovimientoporMes(dia);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Fecha_InicioFin fecha = new frm_Fecha_InicioFin();
            DateTime desde;
            DateTime hasta;
            fil.Show();
            fecha.ShowDialog(this);
            fil.Hide();
            if (fecha.Tag.ToString() == "A")
            {
                desde = fecha.dtp_inicio.Value;
                hasta = fecha.dtp_fin.Value;
                Buscar_Caja_porRangoFecha(desde, hasta);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Mes_Doc fecha = new frm_Mes_Doc();
            DateTime desde;
            fil.Show();
            fecha.ShowDialog(this);
            fil.Hide();
            if (fecha.Tag.ToString() == "A")
            {
                desde = fecha.dtp_mes.Value;
                string tipodoc = fecha.cbo_tipoDoC.Text;
                Buscar_Caja_porMes_TipoDoc(desde, tipodoc);
            }
        }

        private void verMovimientoDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabpage_movimiento != null)
            {
                if (!ElTab1.TabPages.Contains(tabpage_movimiento))
                {
                    ElTab1.TabPages.Add(tabpage_movimiento);
                }
                ElTab1.SelectedTab = tabpage_movimiento;
                Configura_ListView_Productos_Movimiento();
                Buscar_Producto_MovimientoporDia(DateTime.Now);
                txt_movimiento.Focus();
            }
            else
            {
                MessageBox.Show("No se encontró la pestaña de documentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_movimiento_TextChanged(object sender, EventArgs e)
        {
            if (txt_movimiento.Text.Trim().Length > 3)
            {
                Buscar_Producto_Movimiento(txt_movimiento.Text);
            }
        }

        private void btn_Cerrar_Movimiento_Click(object sender, EventArgs e)
        {
            if (ElTab1.TabPages.Contains(tabpage_movimiento))
            {
                ElTab1.TabPages.Remove(tabpage_movimiento);
            }
        }


        private void otrosIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Otros_Ingresos ingreso = new frm_Otros_Ingresos();
            filtro.Show();
            ingreso.ShowDialog(this);
            filtro.Hide();
        }


        private void gastosDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Otros_Gastos ingreso = new frm_Otros_Gastos();
            filtro.Show();
            ingreso.ShowDialog(this);
            filtro.Hide();
        }

        private void eliminarGuiaDeIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Solo_Numero solo = new frm_Solo_Numero();
            frm_Eliminar_Guias guias = new frm_Eliminar_Guias();

            filtro.Show();
            solo.ShowDialog(this);
            filtro.Hide();
            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                string nroGuia = solo.txt_numero.Text.Trim();
                guias.Tag = nroGuia;
                filtro.Show();
                guias.ShowDialog(this);
                filtro.Hide();
            }
        }

        private void eliminarGuiaDeSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Solo_Numero solo = new frm_Solo_Numero();
            frm_Eliminar_Guias guias = new frm_Eliminar_Guias();

            filtro.Show();
            solo.ShowDialog(this);
            filtro.Hide();
            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                string nroGuia = solo.txt_numero.Text.Trim();
                guias.Tag = nroGuia;
                filtro.Show();
                guias.ShowDialog(this);
                filtro.Hide();
            }

        }

        private void traspasoDeSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Guia_Salida guias = new frm_Guia_Salida();

            filtro.Show();
            guias.ShowDialog(this);
            filtro.Hide();
        }

        private void aperturarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Inicio_Caja inicio = new frm_Inicio_Caja();

            filtro.Show();
            inicio.ShowDialog(this);
            filtro.Hide();
        }

        #endregion

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Cierre_Caja cierre = new frm_Cierre_Caja();

            fil.Show();
            cierre.ShowDialog(this);
            fil.Hide();
        }

        private void administradorDeCorrelativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            mdCorrelativo caja = new mdCorrelativo();

            fill.Show();
            caja.ShowDialog(this);
            fill.Hide();
        }

        private void verKArdexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Menu_Kardex caja = new frm_Menu_Kardex();

            fill.Show();
            caja.ShowDialog(this);
            fill.Hide();
        }

        private void ajusteDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Ajuste_Kardex_Inventario caja = new frm_Ajuste_Kardex_Inventario();
            filtro.Show();
            caja.ShowDialog(this);
            filtro.Hide();
        }

        private void productosSinStockPorVentaDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_SoloFecha solo = new frm_SoloFecha();
            Filtro filtro = new Filtro();
            CN_Kardex obj = new CN_Kardex();
            DataTable data = new DataTable();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Menu_Kardex movi = new frm_Menu_Kardex();

            filtro.Show();
            solo.ShowDialog(this);
            filtro.Hide();

            DateTime fechacon;
            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                fechacon = solo.dtp_fn.Value;
                data = obj.CN_Listar_Productos_SinStock_porVenta(fechacon);
                if (data.Rows.Count > 0)
                {
                    filtro.Show();
                    movi.directo = "desde";
                    movi.fechadia = fechacon;
                    movi.ShowDialog(this);
                    filtro.Hide();
                }
                else
                {
                    filtro.Show();
                    ver.lbl_msm.Text = "No se encontraron productos sin stock por venta en la fecha seleccionada.";
                    ver.ShowDialog(this);
                    filtro.Hide();
                    return;
                }
            }
        }

        private void ventaPerdidaPorFaltaDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CN_Producto_SinValor obj = new CN_Producto_SinValor();
            DataTable data = new DataTable();
            frm_Advertencia ver = new frm_Advertencia();
            Filtro fill = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();
            frm_print_Informe prin = new frm_print_Informe();

            DateTime FechaElegida;

            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                FechaElegida = solo.dtp_fn.Value;
                data = obj.CN_Cargar_Producto_sinVenta_porStock_deldia(FechaElegida);
                if (data.Rows.Count > 0)
                {
                    fill.Show();
                    prin.TipoDoc = "sinventa";
                    prin.fechadia = FechaElegida;
                    prin.ShowDialog(this);
                    fill.Hide();
                }
                else
                {
                    fill.Show();
                    ver.lbl_msm.Text = "No se encontraron ventas perdidas por falta de stock en la fecha seleccionada.";
                    ver.ShowDialog(this);
                    fill.Hide();
                    return;
                }


            }
        }

        private void crearNuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frmCliente cliente = new frmCliente();
            fill.Show();
            cliente.ShowDialog(this);
            fill.Hide();
        }

        private void mantenimientoDeFamiliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            mdCategoria categoria = new mdCategoria();

            filtro.Show();
            categoria.ShowDialog(this);
            filtro.Hide();
        }

        private void producToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();
            CN_Pedido objped = new CN_Pedido();
            Filtro fill = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();
            frm_print_Informe informe = new frm_print_Informe();

            string idProd = "";
            DateTime fechaconsulta;
            int cont = 0;

            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                fechaconsulta = solo.dtp_fn.Value;

                try
                {
                    data = obj.CargarTodos_Productos();
                    if (data.Rows.Count == 0) return;

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        DataRow dr = data.Rows[i];
                        idProd = dr["Id_Pro"].ToString();
                        if (objped.CN_Verificar_siProducto_TieneVenta(idProd.Trim(), fechaconsulta) == false)
                        {
                            obj.CN_Cambiar_campo_estadoReporte(idProd, "Sinrotacion");
                            cont += 1;
                        }
                    }
                    if (cont > 0)
                    {
                        fill.Show();
                        informe.TipoDoc = "sinrota";
                        informe.ShowDialog(this);
                        fill.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el informe: " + ex.Message);
                }


            }
        }

        private void actualizacionDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Editar_Precios_CompraVenta caja = new frm_Editar_Precios_CompraVenta();

            fill.Show();
            caja.ShowDialog(this);
            fill.Hide();
        }

        private void administradorDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Registrar_Usuario caja = new frm_Registrar_Usuario();

            fill.Show();
            caja.ShowDialog(this);
            fill.Hide();
            ActualizarEncabezadoUsuario();
        }

        private void asignarPrivilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Registro_Privilegio cli = new frm_Registro_Privilegio();
            frm_Solo_Numero solo = new frm_Solo_Numero();

            solo.ShowDialog();

            int idusu = 0;

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                idusu = Convert.ToInt32(solo.txt_numero.Text.Trim());

                fill.Show();
                cli.Tag = idusu;
                cli.ShowDialog(this);
                fill.Hide();
            }
        }

        private void importarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_ImportarProducto caja = new frm_ImportarProducto();

            fill.Show();
            caja.ShowDialog(this);
            fill.Hide();
        }

        private void exportarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_print_Informe caja = new frm_print_Informe();

            fill.Show();
            caja.TipoDoc = "exportBD";
            caja.ShowDialog(this);
            fill.Hide();
        }

        private void Calcular_Valor_AlmacenStripMenuItem3_Click(object sender, EventArgs e)
        {
            string idprod = "-";
            int contador = 0;

            CN_Producto obj = new CN_Producto();
            Filtro fill = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            try
            {
                for (int i = 0; i < lsvAlmacen.Items.Count; i++)
                {
                    idprod = lsvAlmacen.Items[i].SubItems[0].Text;
                    obj.Cn_Calcular_Valor_Almacen(idprod.Trim());
                    obj.CN_Calcular_Utilidad_deAlamacen(idprod.Trim());
                    contador += 1;
                }
                fill.Show();
                ok.Lbl_msm1.Text = $"Se calculó el valor del almacen para {contador} productos.";
                ok.ShowDialog(this);
                fill.Hide();
                Cargar_Todos_Productos_Almacen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el valor del almacen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void reporteInventarioValorizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CN_Producto obj = new CN_Producto();
            CN_Reporte_Kardex objrep = new CN_Reporte_Kardex();
            DataTable data = new DataTable();
            frm_print_Informe informe = new frm_print_Informe();
            frm_Advertencia ver = new frm_Advertencia();
            Filtro fill = new Filtro();

            double _stock = 0;
            double _precompra = 0;
            double _compra_x_stock = 0;
            double _preventa = 0;
            double _venta_x_stock = 0;
            double _utilidad = 0;
            double _utilidad_xstock = 0;
            string id_Prod = "";
            string nomProd = "";
            int count = 0;

            try
            {
                data = obj.CargarTodos_Productos();
                if (data.Rows.Count > 0)
                {
                    objrep.CN_Eliminar_ReporteKardex();
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        DataRow dr = data.Rows[i];
                        _stock = Convert.ToDouble(dr["Stock_Actual"]);
                        if (_stock > 0)
                        {
                            id_Prod = dr["Id_Pro"].ToString();
                            nomProd = dr["Descripcion_Larga"].ToString();
                            _precompra = Convert.ToDouble(dr["Pre_CompraS"]);
                            _compra_x_stock = _precompra * _stock;

                            //ventas
                            _preventa = Convert.ToDouble(dr["Pre_venta"]);
                            _venta_x_stock = _preventa * _stock;

                            //Utilidad
                            _utilidad = Convert.ToDouble(dr["UtilidadUnit"]);
                            _utilidad_xstock = _utilidad * _stock;

                            objrep.CN_Registrar_Reporte(id_Prod, nomProd, _stock, _precompra, _compra_x_stock, _preventa, _venta_x_stock, _utilidad, _utilidad_xstock, "Valor Almacen");
                            count = +1;

                        }
                    }

                    if (count > 0)
                    {
                        fill.Show();
                        informe.TipoDoc = "reporteKardex";
                        informe.ShowDialog(this);
                        fill.Hide();
                    }
                    else
                    {
                        fill.Show();
                        ver.lbl_msm.Text = "No se encontraron productos con stock para generar el reporte.";
                        ver.ShowDialog(this);
                        fill.Hide();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }


        #region Explorador de Cierres de Caja

        private void Configurar_listView_CierreCaja()
        {
            var lis = lsv_Caja;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            //Aggar columnas a mi ListView
            lis.Columns.Add("ID", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Fecha", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Vendedor", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Inicio", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Total Gastos", 110, HorizontalAlignment.Center);
            lis.Columns.Add("Utilidad", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Entregado", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Saldo Siguiente", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Vnt. Factura", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Vnt. Boleta", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Vnt. Notas", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Vnt. Credito", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Vnt. Tarjeta", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Total Venta S/", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Estado Cierre", 100, HorizontalAlignment.Left);
        }


        private void LLenar_Lisview_CierraCaja(DataTable data)
        {
            if (lsv_Caja.Items.Count == 0)
            {
                lsv_Caja.Items.Clear();
                DateTime FechaCierre;
                double TotalCierre = 0;
                double saldoCred = 0;
                double TotalCierre2 = 0;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    ListViewItem item = new ListViewItem(dr["Id_Cierre"].ToString());
                    FechaCierre = Convert.ToDateTime(dr["Fecha_Cierre"]);
                    item.SubItems.Add(FechaCierre.ToString("dd/MM/yyyy"));

                    item.SubItems.Add(dr["Nombres"].ToString().Trim());
                    item.SubItems.Add(dr["Apertura_Caja"].ToString().Trim());
                    item.SubItems.Add(dr["TotalEgreso"].ToString());
                    item.SubItems.Add(dr["Gananciadeldia"].ToString());

                    //saldo
                    saldoCred = Convert.ToDouble(dr["TotalEntregado"]);
                    item.SubItems.Add(saldoCred.ToString("###0.00"));
                    item.SubItems.Add(dr["SaldoSiguiente"].ToString());
                    item.SubItems.Add(dr["TotalFactura"].ToString());
                    item.SubItems.Add(dr["TotalBoleta"].ToString());
                    item.SubItems.Add(dr["TotalNotaVenta"].ToString());
                    item.SubItems.Add(dr["TotalCreditoEmitido"].ToString());
                    item.SubItems.Add(dr["TodoDeposito"].ToString());
                    TotalCierre = Convert.ToDouble(dr["Total_Ingreso"]);

                    item.SubItems.Add(TotalCierre.ToString("###0.00"));
                    item.SubItems.Add(dr["Estado_Cierre"].ToString());

                    lsv_Caja.Items.Add(item);
                    TotalCierre2 = TotalCierre2 + TotalCierre;
                }

                PintasFilas_Cierre_Caja();
                pnl_caja.Visible = false;
                lbl_cierre_caja.Text = lsv_Caja.Items.Count.ToString();
                txt_total_ingreso.Text = TotalCierre2.ToString("###0.00");

            }
        }

        private void PintasFilas_Cierre_Caja()
        {
            int cont = 1;

            for (int i = 0; i < lsv_Caja.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_Caja.Items[i].BackColor = Color.WhiteSmoke;
                }

                cont += 1;
            }
        }

        private void Cargar_Todos_Usuarios()
        {
            CN_Usuario obj = new CN_Usuario();
            DataTable data = new DataTable();
            data = obj.CN_Cargar_todos_Usuarios();
            if (data.Rows.Count > 0)
            {
                var cbo = cbo_users;
                cbo.DataSource = data;
                cbo.DisplayMember = "Nombres";
                cbo.ValueMember = "Id_Usu";
                cbo.SelectedIndex = -1;
            }
        }



        private void Cargar_Todos_Cierres()
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Todo_cierres();
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_CierraCaja(data);
            }
            else
            {
                lsv_Caja.Items.Clear();
                pnl_caja.Visible = true;
            }
        }



        private void Buscar_Cierre_porDia(DateTime xdia, string estado)
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cierre_Caja_DelDia(xdia, estado);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_CierraCaja(data);
            }
            else
            {
                lsv_Caja.Items.Clear();
                pnl_caja.Visible = true;
            }
        }



        private void Buscar_Cierre_porMes(DateTime xdia)
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cierre_Caja_delMes(xdia);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_CierraCaja(data);
            }
            else
            {
                lsv_Caja.Items.Clear();
                pnl_caja.Visible = true;
            }
        }




        private void Buscar_Cierre_por_Usuario(int idUsu, DateTime fechax)
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cierre_Caja_porUsu_Mes(idUsu, fechax);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_CierraCaja(data);
            }
            else
            {
                lsv_Caja.Items.Clear();
                pnl_caja.Visible = true;
            }
        }


        private void Buscar_Cierre_porUsuario(int IdUsu)
        {
            CN_CierreCaja obj = new CN_CierreCaja();
            DataTable data = new DataTable();
            data = obj.CN_Listar_Cierre_Caja_porUsuario(IdUsu);
            if (data.Rows.Count > 0)
            {
                LLenar_Lisview_CierraCaja(data);
            }
            else
            {
                lsv_Caja.Items.Clear();
                pnl_caja.Visible = true;
            }
        }
        private void btn_Cierre_delDia_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();

            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                DateTime dia = solo.dtp_fn.Value;
                Buscar_Cierre_porDia(dia, "Cerrado");
            }
        }

        private void btn_VerCierre_Mes_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();

            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                DateTime mes = solo.dtp_fn.Value;
                Buscar_Cierre_porMes(mes);
            }
        }

        private void btn_usu_mes_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Solo_Usuario solo = new frm_Solo_Usuario();

            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                DateTime mes = solo.dtp_fn_Usu.Value;
                int idUsu = Convert.ToInt32(solo.cbo_users.SelectedValue);
                Buscar_Cierre_por_Usuario(idUsu, mes);
            }
        }


        bool cargo = false;
        private void cbo_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargo == false) return;
            if (cbo_users.SelectedIndex == -1)
            {

            }
            else
            {
                int idUsu = Convert.ToInt32(cbo_users.SelectedValue);
                Buscar_Cierre_porUsuario(idUsu);
            }
        }

        private void verCierresDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabCajadeCirres != null)
            {
                if (!ElTab1.TabPages.Contains(tabCajaCierre))
                {
                    ElTab1.TabPages.Add(tabCajaCierre);
                }
                ElTab1.SelectedTab = tabCajaCierre;
                Cargar_Todos_Usuarios();
                Cargar_Todos_Cierres();
                Refrescar_CheckCaja();

            }
            else
            {
                MessageBox.Show(
                    "No se encontró la pestaña de Cierre",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_CierreCaja_Click(object sender, EventArgs e)
        {
            if (ElTab1.TabPages.Contains(tabCajaCierre))
            {
                ElTab1.TabPages.Remove(tabCajaCierre);
            }
        }


        private void Refrescar_CheckCaja()
        {
            try
            {
                CN_CierreCaja obj = new CN_CierreCaja();

                // Validar estado de la caja
                bool estadoCaja = obj.CN_validar_InicioDoble_caja();

                if (estadoCaja == true)
                {
                    chk_caja.Checked = true;
                }
                else
                {
                    chk_caja.Checked = false;
                }

                // Volver a cargar cierres
                Cargar_Todos_Cierres();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar caja: " + ex.Message);
            }
        }
        private void tipoCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            md_Cambio frm = new md_Cambio();

            fil.Show();
            frm.ShowDialog(this);
            fil.Hide();
        }

        #endregion

        private void verClientesRegistradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Menu_Clientes cli = new frm_Menu_Clientes();
            fill.Show();
            cli.ShowDialog(this);
            fill.Hide();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Si_No sino = new frm_Si_No();

            fill.Show();
            sino.lbl_msm.Text = "¿Desea cerrar la aplicación?";
            sino.ShowDialog(this);
            fill.Hide();

            if (sino.Tag != null && sino.Tag.ToString() == "Si")
            {
                Application.ExitThread(); 
            }
            else
            {
                e.Cancel = true;
            }
        }



        private void recordMensualDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Mes_Doc filtro = new frm_Mes_Doc();
            frm_print_Informe informe = new frm_print_Informe();

            fill.Show();
            filtro.ShowDialog(this);
            fill.Hide();

            if (filtro.Tag != null && filtro.Tag.ToString() == "A")
            {
                int idTipoDoc = Convert.ToInt32(filtro.cbo_tipoDoC.SelectedValue);

                fill.Show();

                informe.fechadia = filtro.dtp_mes.Value;
                informe.TipoDoc = "mes_doc";
                informe.Tag = idTipoDoc;
                informe.ShowDialog(this);

                fill.Hide();
            }
        }


        private void recordGeneralDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();
            frm_print_Informe informe = new frm_print_Informe();
            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                DateTime fecha = solo.dtp_fn.Value;

                fill.Show();
                informe.fechadia = fecha;
                informe.TipoDoc = "venta_mes";
                informe.ShowDialog(this);
                fill.Hide();
            }
        }



        private void imprimirMovimientoCajaPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Filtro fill = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();
            frm_print_Informe informe = new frm_print_Informe();

            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                DateTime fecha = solo.dtp_fn.Value;

                fill.Show();

                informe.fechadia = fecha;
                informe.TipoDoc = "movcaja_dia";
                informe.ShowDialog(this);

                fill.Hide();
            }

        }



        private void reporteDeProductosMasVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();
            frm_print_Informe informe = new frm_print_Informe();

            fill.Show();
            solo.ShowDialog(this);
            fill.Hide();

            if (solo.Tag != null && solo.Tag.ToString() == "A")
            {
                DateTime fecha = solo.dtp_fn.Value;

                fill.Show();

                informe.fechadia = fecha;
                informe.TipoDoc = "prod_masvendidos";
                informe.ShowDialog(this);

                fill.Hide();
            }
        }


        private void verGuiasRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Explorador_Compras ver = new frm_Explorador_Compras();

            fil.Show();
            ver.ShowDialog(this);
            fil.Hide();
        }
       
        private void editarDatosDeLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Editar_DatosLocal empresa = new frm_Editar_DatosLocal();

            fill.Show();
            empresa.ShowDialog(this);
            fill.Hide();
        }

        private void productosParaReposicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fill = new Filtro();
            frm_Productos_paraReposicion empresa = new frm_Productos_paraReposicion();

            fill.Show();
            empresa.ShowDialog(this);
            fill.Hide();
        }
    }
}
