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
    public partial class frm_AnularVenta : Form
    {
        public frm_AnularVenta()
        {
            InitializeComponent();
        }

        private void frm_AnularVenta_Load(object sender, EventArgs e)
        {
            Configura_ListViewDetalle();
            Llenar_Combo_TipoDoc();
      
            //         FECHA - ACTUAL         //
            dtp_fechadoc.Value = DateTime.Now;
        }

        //--------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA ---------------------//
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

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
            lis.Columns.Add("ID Prod", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Descripción del Articulo", 420, HorizontalAlignment.Left);
            lis.Columns.Add("Cant", 64, HorizontalAlignment.Center);
            lis.Columns.Add("Precio", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Importe", 177, HorizontalAlignment.Center);
            lis.Columns.Add("Utili unit", 0, HorizontalAlignment.Left);
            lis.Columns.Add("ImporUtili", 0, HorizontalAlignment.Left);
            lis.Columns.Add("TotalDscto", 0, HorizontalAlignment.Left);
        }


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
                    igv = totalventa * 0.18;

                    GanaciaTotal = GanaciaTotal + Convert.ToDouble(lsv_Det.Items[i].SubItems[6].Text);
                }

                txt_subtotal.Text = subtotal.ToString("###0.00");
                txt_igv.Text = igv.ToString("###0.00");
                txt_totalpagar.Text = totalventa.ToString("###0.00");

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }


        private void Buscar_Documento_ParaReimprimir(string nroDoc)
        {
            CN_Documento obj = new CN_Documento();
            DataTable data = new DataTable();
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            string estadoDoc = "";
            try
            {
                data = obj.CN_Buscar_DocumentoDetalleId(nroDoc);
                if (data.Rows.Count > 0)
                {
                    var dt = data.Rows[0];
                    estadoDoc = Convert.ToString(dt["Estado_doc"]);
                    if (estadoDoc.Trim() == "Anulado")
                    {
                        fil.Show();
                        ver.lbl_msm.Text = "¡El documento seleccionado ya se encuentra anulado!";
                        ver.ShowDialog(this);
                        fil.Hide();
                        return;
                    }
                    else
                    {
                        //Llenar datos del documento en el formulario
                        txt_nroDoc.Text = Convert.ToString(dt["Id_Doc"]);
                        txt_nroPedido.Text = Convert.ToString(dt["id_Ped"]);
                        cbo_tipodoc.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
                        dtp_fechadoc.Value = Convert.ToDateTime(dt["Fecha_Emi"]);
                        cbo_tipopago.Text = Convert.ToString(dt["TipoPago"]);
                        lbl_id.Text = Convert.ToString(dt["id_cliente"]);
                        txt_nomcliente.Text = Convert.ToString(dt["Razon_Social_Nombres"]);
                        txt_direccion.Text = Convert.ToString(dt["Direccion"]);
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
                    }
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

        private bool ValidarVenta()
        {
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            if (lsv_Det.Items.Count == 0) { filtro.Show(); ver.lbl_msm.Text = "Por favor, ingresa un producto al carrito"; ver.ShowDialog(this); filtro.Hide(); return false; }
            if (lbl_id.Text.Trim().Length < 2) { filtro.Show(); ver.lbl_msm.Text = "Por favor, ingresa un cliente para la venta"; ver.ShowDialog(this); filtro.Hide(); return false; }
            if (cbo_tipodoc.SelectedIndex == -1) { filtro.Show(); ver.lbl_msm.Text = "Por favor, seleciona el tipo de documento a emitir"; ver.ShowDialog(this); filtro.Hide(); cbo_tipodoc.Focus(); return false; }
            return true;

        }


        private void btn_Anular_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            CN_Documento obj = new CN_Documento();
            CN_Caja objCaja = new CN_Caja();

            try
            {
                if(ValidarVenta())
                {
                    obj.CN_AnulaDocumento(txt_nroDoc.Text, "Anulado");
                    if(CD_Documento.doc_saved == true)
                    {
                        objCaja.CN_Anular_Movimiento_Caja(txt_nroDoc.Text, "Anulado");
                        if(CD_Caja.cajaSaved == true)
                        {
                            if (lbl_opt.Text.Trim() == "Devol")
                            {
                                Registrar_MovimientoKardex();
                            }

                            fil.Show();
                            ok.Lbl_msm1.Text = "El Documento fue Anulado Exitosamente";
                            ok.ShowDialog(this);
                            fil.Hide();

                            pnl_sinProd.Visible = true;
                            this.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw; 
            }
        }





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
                            kar.Doc_soporte = txt_nroDoc.Text;
                            kar.Det_Operacion = "Anulado Por Venta : nroDoc:" + txt_nroDoc.Text;
                            //Entrada
                            kar.Cantidad_In = xcantvendida;
                            kar.Precio_In = precioCompraProd;
                            kar.Total_In = xcantvendida * precioCompraProd;
                            //Salida
                            kar.Cantidad_Out = 0;
                            kar.Precio_Out = 0;
                            kar.Total_Out = 0;
                            //Saldos
                            kar.Cantidad_saldo = stockprod + xcantvendida;
                            kar.Promedio = precioCompraProd;
                            kar.Total_saldo = precioCompraProd * kar.Cantidad_saldo;
                            kar.Idusu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                            kar.Tipo_operacion = "Anulacion";
                            kar.Cant_diferencial = "-";
                            kar.ImporteDiferente = 0;

                            obj.Registrar_DetalleKardex(kar);
                            objpro.SumarStock_Producto(xidprod.Trim(), xcantvendida);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reg Kardex Capa Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }





        private void rb_devolverStock_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_devolverStock.Checked == true)
            {
                lbl_opt.Text = "Devol";
            }
        }

        private void rb_sindevolverStock_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sindevolverStock.Checked == true)
            {
                lbl_opt.Text = "Nodevol";
            }
        }

        private void btn_Nuevo_Buscarprod_Click(object sender, EventArgs e)
        {
            if(txt_buscar.Text.Trim().Length > 6)
            {
                Buscar_Documento_ParaReimprimir(txt_buscar.Text);
            }
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Nuevo_Buscarprod_Click(sender, e);
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
    }
}
