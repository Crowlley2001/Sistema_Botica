using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Producto;
using CapaPresentacion.Ventas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec.Util;

namespace CapaPresentacion.Compras
{
    public partial class frm_EntradasProd : Form
    {
        public frm_EntradasProd()
        {
            InitializeComponent();
        }
        private void frm_EntradasProd_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            cbo_tipo.SelectedIndex = 0;
            cbo_tipoDoc.SelectedIndex = 2;
            //         FECHA - ACTUAL         //
            dtp_FechaCom.Value = DateTime.Now;
            dtp_FechaVenc.Value = DateTime.Now;
        }
     
        private void Configurar_listView()
        {
            var lis = lsv_Det;
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
        private void PintasFilas()
        {
            int cont = 1;
            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                if (cont % 2 == 0)
                {

                }
                else
                {
                    lsv_Det.Items[i].BackColor = System.Drawing.Color.WhiteSmoke;
                }
                cont += 1;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
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

        private void Calcular()
        {
            double xtotal = 0;
            double xcant = 0;
            double xpreciocompra = 0;
            double ximportecompra = 0;
            double xsubtotal = 0;
            double xigv = 0;

            for (int i = 0; i < lsv_Det.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_Det.Items[i].SubItems[2].Text);
                xpreciocompra = Convert.ToDouble(lsv_Det.Items[i].SubItems[3].Text);

                //calculo del IMporte de Compra:
                ximportecompra = xpreciocompra * xcant;
                lsv_Det.Items[i].SubItems[4].Text = ximportecompra.ToString("###0.00");

                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[4].Text);

            }
            //calcular el IGV: IVA
            xsubtotal = xtotal / 1.18;
            xigv = xsubtotal * 0.18;

            txt_subtotal.Text = xsubtotal.ToString("###0.00");
            txt_igv.Text = xigv.ToString("###0.00");
            txt_TotalPagar.Text = xtotal.ToString("###0.00");

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

                    txt_Frank.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(9);
                    txt_NroFisico.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(9);
                }
            }
        }


        private void Agregar_Productos_alCarrito(string xidprod, string xnomprod, double xcant, double xprecio, double ximporte, double preventa)
        {
            try
            {
                if (lsv_Det.Items.Count == 0)
                {
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(preventa.ToString("###0.00"));
                    Calcular();
                    PintasFilas();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                    pnl_sinProd.Visible = false;
                }
                else
                {
                    //validar de que el producvto no se ingrese dos veces
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        if (lsv_Det.Items[i].Text.Trim() == xidprod.Trim())
                        {
                            MessageBox.Show("El Producvto ya fue Agregado al Carrito de Compras", "ADveretencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    //lo añadimos:
                    ListViewItem item = new ListViewItem();
                    item = lsv_Det.Items.Add(xidprod);
                    item.SubItems.Add(xnomprod.Trim());
                    item.SubItems.Add(xcant.ToString());
                    item.SubItems.Add(xprecio.ToString("###0.00"));
                    item.SubItems.Add(ximporte.ToString("###0.00"));
                    item.SubItems.Add(preventa.ToString("###0.00"));
                    Calcular();
                    PintasFilas();
                    lsv_Det.Focus();
                    lsv_Det.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    txt_Frank.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(9);
                    txt_NroFisico.Text = CN_TipoDoc.CN_Generar_NroCorrelativo(9);
                }
            }
        }

        private void bt_editPre_Click(object sender, EventArgs e)
        {
            //Evento para Editar el Precio de Compra y Venta:
            Filtro fil = new Filtro();
            frm_PrecompraVenta compa = new frm_PrecompraVenta();

            if (lsv_Det.SelectedIndices.Count == 0)
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


                preCompra_leido = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[3].Text);
                preVenta_leido = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[5].Text);
                cantidad_comprar = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                compa.idProdcto = lsv_Det.SelectedItems[0].SubItems[0].Text;
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

                    lsv_Det.SelectedItems[0].SubItems[3].Text = preCompra_ingresado.ToString("###0.00");
                    lsv_Det.SelectedItems[0].SubItems[5].Text = preVenta_ingresado.ToString("###0.00");
                    lsv_Det.SelectedItems[0].SubItems[2].Text = cantidad_comprar.ToString("###0.00");
                    Calcular();
                }

            }
        }

        private void bt_editCant_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Solo_Canti solo = new frm_Solo_Canti();

            if (lsv_Det.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Seleccionar el Producto a Editar su Cantidad", "Editar Precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double cant_Ingresado = 0;
                double cant_Editado = 0;
                cant_Ingresado = Convert.ToDouble(lsv_Det.SelectedItems[0].SubItems[2].Text);

                fil.Show();
                solo.txt_cant.Text = cant_Ingresado.ToString();
                solo.ShowDialog(this);
                fil.Hide();


                if (solo.Tag.ToString() == "A")
                {
                    cant_Editado = Convert.ToDouble(solo.txt_cant.Text);
                    lsv_Det.SelectedItems[0].SubItems[2].Text = cant_Editado.ToString("###0.00");
                    Calcular();
                }

            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Si_No sino = new frm_Si_No();

            if (lsv_Det.SelectedIndices.Count == 0)
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
                    var lis = lsv_Det.SelectedItems[0];
                    for (i = lsv_Det.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        lsv_Det.Items.Remove(lsv_Det.SelectedItems[i]);
                    }
                    Calcular();
                }

            }
        }

        private void btn_Procesar_Click(object sender, EventArgs e)
        {
            if (Validar_Compras() == true)
            {
                Registrar_Compra();
            }
        }

        private bool Validar_Compras()
        {
            Filtro fil = new Filtro();

            if (lsv_Det.Items.Count == 0) { fil.Show(); MessageBox.Show("INgresa Almenos un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); lsv_Det.Focus(); return false; }
            // if (cbo_provee.SelectedIndex == -1) { fil.Show(); MessageBox.Show("INgresa Almenos un Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_provee.Focus(); return false; }
            if (txt_NroFisico.Text.Trim().Length < 2) { fil.Show(); MessageBox.Show("INgresa el Nro de FActura Fisica", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_NroFisico.Focus(); return false; }
            if (txt_procedencia.Text.Trim().Length == 0) { fil.Show(); MessageBox.Show("POr Favor, ingresa la Procedencia de la Mercaderia, Ayudará a tener un mejor control", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); txt_procedencia.Focus(); return false; }

            // if (cbo_tipoPago.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoPago.Focus(); return false; }
            if (cbo_tipoDoc.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipoDoc.Focus(); return false; }
            if (cbo_tipo.SelectedIndex == -1) { fil.Show(); MessageBox.Show("Selecciona el Tipo de Registro de esta Operacion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); fil.Hide(); cbo_tipo.Focus(); return false; }

            return true;
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
                com.Id_DocComp = txt_Frank.Text;
                com.NroFac_Fisico = txt_NroFisico.Text;
                com.SubTotal_ingre = Convert.ToDouble(txt_subtotal.Text);
                com.Total_Ingre = Convert.ToDouble(txt_TotalPagar.Text);
                com.Fecha_Ingre = dtp_FechaCom.Value;
                com.id_Usu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                com.ModalidadPago = cbo_TipoPago.Text;
                com.TiempoEspera = 0;
                com.Fecha_Vencimiento = dtp_FechaVenc.Value;
                com.Estado_Ingre = "Activo";
                com.Datos_Adicional = txt_obser.Text;
                com.TipoDoc_Compra = cbo_tipoDoc.Text;
                com.Tiporegistro = cbo_tipo.Text;
                com.LugarSalida = txt_procedencia.Text; 
                com.TipoProceso = "Entrada";

                obj.CN_Registrar_Compras(com);

                if (CD_Compra.saved == true)
                {
                    CN_TipoDoc.CN_Actualizar_Correlativo(9);

                    //vamos a guardar el Detalle:
                    for (int i = 0; i < lsv_Det.Items.Count; i++)
                    {
                        var item = lsv_Det.Items[i];

                        det.Id_DocComp = txt_Frank.Text;
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

                        //ahora actualizamos el precio del producvto:
                        double utilidad = 0;
                        double valorAlmacen = 0;
                        utilidad = preventa2 - precompra2;
                        valorAlmacen = det.Cantidad * precompra2;
                        pro.CN_Actualizar_PrecioCompra_Producto(idProd1, precompra2, preventa2, utilidad, valorAlmacen);
                        Registrar_MoviemtoKardex(idProd1.Trim(), canti2, precompra2, prodNom);

                    }

                    //temrinar,os:
                    Filtro fil = new Filtro();
                    frm_Msm_bueno ok = new frm_Msm_bueno();


                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos dela Compra se han Registrado Exitosamente";
                    ok.ShowDialog(this);
                    fil.Hide();

                    lsv_Det.Items.Clear();
                    txt_NroFisico.Text = "";
                    cbo_tipoDoc.Text = "";


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
                        kar.Doc_soporte = txt_NroFisico.Text;
                        kar.Det_Operacion = "Compra de Mercaderia ";
                        //Entrada:
                        kar.Cantidad_In = xcant;
                        kar.Precio_In = xpreCompra;
                        kar.Total_In = xcant * xpreCompra;
                        //salida:
                        kar.Cantidad_Out = 0;
                        kar.Precio_Out= 0;
                        kar.Total_Out = 0;
                        //saldos:
                        kar.Cantidad_saldo = stockProd + xcant;
                        kar.Promedio = xpreCompra;
                        kar.Total_saldo = xpreCompra * kar.Cantidad_saldo;
                        kar.Idusu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                        kar.Tipo_operacion = cbo_tipo.Text;
                        kar.Cant_diferencial = "-";
                        kar.ImporteDiferente = 0;

                        obj.Registrar_DetalleKardex(kar);

                        //ahora acrtalizamos nuestro stock de la tabla productos:
                        objpro.SumarStock_Producto(idprod.Trim(), xcant);
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
