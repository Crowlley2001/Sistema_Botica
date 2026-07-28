using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Compras;
using CapaPresentacion.Informes;
using CapaPresentacion.Producto;
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
    public partial class frm_Guia_Salida : Form
    {
        public frm_Guia_Salida()
        {
            InitializeComponent();
        }
        private void frm_Guia_Salida_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            cbo_tipoGuia.SelectedIndex = 0;
            //         FECHA - ACTUAL         //
            dtp_FechaCom.Value = DateTime.Now;

        }
        private void btn_Guia_Click(object sender, EventArgs e)
        {
            if (Validar_Compras() == true)
            {
                Registrar_Compra();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

        private void Configurar_listView()
        {
            var lis = lsv_Guia;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            lis.HeaderStyle = ColumnHeaderStyle.None;
            //configurar las columnas:
            lis.Columns.Add("ID producto", 150, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 400, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 60, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Compra", 90, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Venta", 100, HorizontalAlignment.Center);  //1          
        }
        private void Calcular()
        {
            double xtotal = 0;
            double xcant = 0;
            double xpreciocompra = 0;
            double ximportecompra = 0;
            double xsubtotal = 0;
            double xigv = 0;

            for (int i = 0; i < lsv_Guia.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Guia.Items[i].SubItems[2].Text);
                xpreciocompra = Convert.ToDouble(lsv_Guia.Items[i].SubItems[3].Text);

                //calculo del IMporte de Compra:
                ximportecompra = xpreciocompra * xcant;
                lsv_Guia.Items[i].SubItems[4].Text = ximportecompra.ToString("###0.00");

                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Guia.Items[i].SubItems[4].Text);

            }
            //calcular el IGV: IVA
            xsubtotal = xtotal / 1.18;
            xigv = xtotal - xsubtotal;

            txt_subtotalGuia.Text = xsubtotal.ToString("###0.00");
            txt_igvGuia.Text = xigv.ToString("###0.00");
            txt_TotalPagarGuia.Text = xtotal.ToString("###0.00");

        }
        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte, double preventa)
        {
            try
            {
                if (lsv_Guia.Items.Count == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item = lsv_Guia.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(preventa.ToString("###0.00"));
                    Calcular();
                    PintasFilas();
                    lsv_Guia.Focus();
                    lsv_Guia.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                }
                else
                {
                    //validar de que el producvto no se ingrese dos veces
                    for (int i = 0; i < lsv_Guia.Items.Count; i++)
                    {
                        if (lsv_Guia.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            MessageBox.Show("El Producvto ya fue Agregado al Carrito de Compras", "ADveretencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    //lo añadimos:
                    ListViewItem item = new ListViewItem();
                    item = lsv_Guia.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(preventa.ToString("###0.00"));
                    Calcular();
                    PintasFilas();
                    lsv_Guia.Focus();
                    lsv_Guia.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Nuevo_Buscarprod_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_BuscarProducto pro = new frm_BuscarProducto();
            DataTable data = new DataTable();
            CN_Producto objProd = new CN_Producto();
            string xidprod = "";
            string xproducto = "";
            double cantidad = 1;
            double PreVenta = 0;
            double PreCompra = 0;
            double _importe = 0;
            fil.Show();
            pro.chk_todo.Checked = true;
            pro.tipobusqueda = "compra";
            pro.ShowDialog(this);
            fil.Hide();

            if (pro.Tag != null && pro.Tag.ToString() == "A")
            {
                string _idprod = pro.lbl_idprod.Text;
                data = objProd.BuscarProductoID(_idprod);

                if (data.Rows.Count == 1)
                {
                    xidprod = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    xproducto = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                    PreCompra = Convert.ToDouble(data.Rows[0]["Pre_CompraS"]);
                    PreVenta = Convert.ToDouble(data.Rows[0]["Pre_venta"]);

                    Agregar_Productos_alCarrito(
                        _idprod.Trim(),
                        xproducto,
                        cantidad,
                        PreCompra,
                        _importe,
                        PreVenta
                    );

                    txt_idComp.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(9);
                }
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_BuscarProducto pro = new frm_BuscarProducto();
            DataTable data = new DataTable();
            CN_Producto objProd = new CN_Producto();
            string xidprod = "";
            string xproducto = "";
            double cantidad = 1;
            double PreVenta = 0;
            double PreCompra = 0;
            double _importe = 0;


            fil.Show();
            pro.chk_todo.Checked = true;
            pro.tipobusqueda = "compra";
            pro.ShowDialog(this);
            fil.Hide();

            if (pro.Tag != null && pro.Tag.ToString() == "A")
            {
                string _idprod = pro.lbl_idprod.Text;
                if (string.IsNullOrEmpty(_idprod)) return;
                data = objProd.BuscarProductoID(_idprod);

                if (data != null && data.Rows.Count == 1)
                {
                    xidprod = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    xproducto = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                    PreCompra = Convert.ToDouble(data.Rows[0]["Pre_CompraS"]);
                    PreVenta = Convert.ToDouble(data.Rows[0]["Pre_venta"]);

                    // Agregamos al carrito
                    Agregar_Productos_alCarrito(_idprod.Trim(), xproducto, cantidad, PreCompra, _importe, PreVenta);

                    // Generar correlativos
                    txt_idComp.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(9);
                }
            }
        }

        private void bt_editPre_Click(object sender, EventArgs e)
        {
            //Evento para Editar el Precio de Compra y Venta:
            Filtro fil = new Filtro();
            frm_PrecompraVenta compa = new frm_PrecompraVenta();

            if (lsv_Guia.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Precio", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double preCompra_leido = 0;
                double preCompra_ingresado = 0;
                double preVenta_leido = 0;
                double preVenta_ingresado = 0;
                double cantidad_comprar = 0;


                preCompra_leido = Convert.ToDouble(lsv_Guia.SelectedItems[0].SubItems[3].Text);
                preVenta_leido = Convert.ToDouble(lsv_Guia.SelectedItems[0].SubItems[5].Text);
                cantidad_comprar = Convert.ToDouble(lsv_Guia.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                compa.idProdcto = lsv_Guia.SelectedItems[0].SubItems[0].Text;
                compa.txt_preciocompra.Text = preCompra_leido.ToString();
                compa.txt_preventa.Text = preCompra_leido.ToString();
                compa.txt_cantidad.Text = cantidad_comprar.ToString();
                compa.ShowDialog(this);
                fil.Hide();


                if (compa.Tag.ToString() == "A")
                {
                    preCompra_ingresado = Convert.ToDouble(compa.txt_preciocompra.Text);
                    preVenta_ingresado = Convert.ToDouble(compa.txt_preventa.Text);
                    cantidad_comprar = Convert.ToDouble(compa.txt_cantidad.Text);

                    lsv_Guia.SelectedItems[0].SubItems[3].Text = preCompra_ingresado.ToString("###0.00");
                    lsv_Guia.SelectedItems[0].SubItems[5].Text = preVenta_ingresado.ToString("###0.00");
                    lsv_Guia.SelectedItems[0].SubItems[2].Text = cantidad_comprar.ToString("###0.00");
                    Calcular();
                }

            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Si_No sino = new frm_Si_No();

            if (lsv_Guia.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Quitar", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                fil.Show();
                sino.lbl_msm.Text = "Estas Seguro de Quitar este producto del Carrito?";
                sino.ShowDialog(this);
                fil.Hide();

                if (sino.Tag.ToString() == "Si")
                {
                    int i;
                    var lis = lsv_Guia.SelectedItems[0];
                    for (i = lsv_Guia.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_Guia.Items.Remove(lsv_Guia.SelectedItems[i]);
                    }
                    Calcular();
                }

            }
        }
     

        private bool Validar_Compras()
        {
            Filtro fil = new Filtro();

            if (lsv_Guia.Items.Count == 0) { fil.Show(); MessageBox.Show("INgresa Almenos un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); lsv_Guia.Focus(); return false; }
            // if (cbo_provee.SelectedIndex == -1) { fil.Show(); MessageBox.Show("INgresa Almenos un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_provee.Focus(); return false; }
            if (txt_origen.Text.Trim().Length == 0) { fil.Show(); MessageBox.Show("POr Favor, ingresa la Procedencia de la Mercaderia, Ayudará a tener un mejor control", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_origen.Focus(); return false; }

            // if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            if (cbo_tipoGuia.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoGuia.Focus(); return false; }
            if (cbo_tipoGuia.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Registro de esta Operacion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoGuia.Focus(); return false; }

            return true;
        }


        private void PintasFilas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_Guia.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_Guia.Items[i].BackColor = System.Drawing.Color.WhiteSmoke;
                }
                cont += 1;
            }
        }

        private void Registrar_Compra()
        {

            Documento_Compras com = new Documento_Compras();
            Detalle_DocumentoCompra det = new Detalle_DocumentoCompra();
            CN_Compra obj = new CN_Compra();
            CN_Producto pro = new CN_Producto();

            string prodNom = "";
            string idProd1 = "";
            Double canti2 = 0;
            double precompra2 = 0;
            double preventa2 = 0;

            try
            {
                com.Id_DocComp = txt_idComp.Text;
                com.NroFac_Fisico = txt_idComp.Text;
                com.SubTotal_ingre = Convert.ToDouble(txt_subtotalGuia.Text);
                com.Total_Ingre = Convert.ToDouble(txt_TotalPagarGuia.Text);
                com.Fecha_Ingre = dtp_FechaCom.Value;
                com.id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                com.ModalidadPago = "Efectivo";
                com.TiempoEspera = 0;
                com.Fecha_Vencimiento = dtp_FechaCom.Value;
                com.Estado_Ingre = "Activo";
                com.Datos_Adicional = txt_destino.Text;
                com.TipoDoc_Compra = "Otro";
                com.Tiporegistro = cbo_tipoGuia.Text;
                com.LugarSalida = txt_origen.Text;
                com.TipoProceso = "Salida";

                obj.CN_Registrar_Compras(com);

                if (CD_Compra.saved == true)
                {
                    CN_TipoDoc.CN_Actualizar_Correlativo(9);

                    //vamos a guardar el Detalle:
                    for (int i = 0; i < lsv_Guia.Items.Count; i++)
                    {
                        var item = lsv_Guia.Items[i];

                        det.Id_DocComp = txt_idComp.Text;
                        det.Id_Pro = item.SubItems[0].Text;
                        idProd1 = item.SubItems[0].Text;
                        prodNom = Convert.ToString(item.SubItems[1].Text);
                        det.Cantidad = Convert.ToDouble(item.SubItems[2].Text);
                        canti2 = Convert.ToDouble(item.SubItems[2].Text);
                        det.PrecioUnit = Convert.ToDouble(item.SubItems[3].Text);
                        precompra2 = Convert.ToDouble(item.SubItems[3].Text);
                        det.Importe = Convert.ToDouble(item.SubItems[4].Text);
                        det.Preventa = Convert.ToDouble(item.SubItems[5].Text);
                        preventa2 = Convert.ToDouble(item.SubItems[5].Text);

                        obj.CN_Registrar_Detalle_Compras(det);
                        Registrar_MoviemtoKardex(idProd1.Trim(), canti2, precompra2, prodNom);

                    }

                    //temrinar,os:
                    Filtro fil = new Filtro();
                    frm_Msm_bueno ok = new frm_Msm_bueno();


                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos dela Compra se han Registrado Exitosamente";
                    ok.ShowDialog(this);
                    fil.Hide();

                    //Imprimir
                    frm_print_Informe informe = new frm_print_Informe();
                    informe.NrDoc = txt_idComp.Text;
                    informe.TipoDoc = "salidAlmacen";
                    informe.ShowDialog(this);
                    fil.Hide();

                    lsv_Guia.Items.Clear();

                    this.Tag = "A";
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }



        private void Registrar_MoviemtoKardex(string idprod, double xcant, double xpreCompra, string nomprod)
        {
            CN_Kardex obj = new CN_Kardex();
            Detalle_Kardex kar = new Detalle_Kardex();
            CN_Producto objpro = new CN_Producto();
            DataTable dato = new DataTable();
            DataTable datoprod = new DataTable();

            string xidkardex = "";
            int xitem = 0;
            double stockProd = 0;
            double precioCompraProd = 0;

            try
            {
                if (obj.Verificar_Kardex_Producto(idprod) == true)
                {
                    //si tiene kardex es valido:
                    dato = obj.BuscarKardexPorValor(idprod.Trim());
                    if (dato.Rows.Count > 0)
                    {
                        xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                        xitem = dato.Rows.Count;
                        //leemos los datos del producto:
                        datoprod = objpro.BuscarProductoID(idprod.Trim());
                        stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                        precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

                        //registramos el Detalle del Kardex:
                        kar.IdKardex = xidkardex;
                        kar.Item = xitem + 1;
                        kar.Doc_soporte = txt_idComp.Text;
                        kar.Det_Operacion = cbo_tipoGuia + "de Mercaderia ";
                        //Entrada:
                        kar.Cantidad_In = 0;
                        kar.Precio_In = 0;
                        kar.Total_In = 0;
                        //salida:
                        kar.Cantidad_Out = xcant;
                        kar.Precio_Out = xpreCompra;
                        kar.Total_Out = xcant * xpreCompra;
                        //saldos:
                        kar.Cantidad_saldo = stockProd - xcant;
                        kar.Promedio = xpreCompra;
                        kar.Total_saldo = xpreCompra * kar.Cantidad_saldo;
                        kar.Idusu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                        kar.Tipo_operacion = cbo_tipoGuia.Text;
                        kar.Cant_diferencial = "-";
                        kar.ImporteDiferente = 0;

                        obj.Registrar_DetalleKardex(kar);

                        //ahora acrtalizamos nuestro stock de la tabla productos:
                        objpro.RestarStock_Producto(idprod.Trim(), xcant);
                    }
                    else
                    {
                        MessageBox.Show("El Producto: " + nomprod + " No Tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("El Producto: " + nomprod + " No Tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
