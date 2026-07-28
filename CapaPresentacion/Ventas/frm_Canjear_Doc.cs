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
    public partial class frm_Canjear_Doc : Form
    {
        public frm_Canjear_Doc()
        {
            InitializeComponent();
            Configura_ListViewDetalle();
            Llenar_Combo_TipoDoc();
        }

        private void frm_Canjear_Doc_Load(object sender, EventArgs e)
        {
            //         FECHA - ACTUAL         //
            dtp_fechadoc.Value = DateTime.Now;
            dtp_fechaemi.Value = DateTime.Now;
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
                var cbo = cbo_tipodocumento;

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
            string tipodoc = "";
            try
            {
                data = obj.CN_Buscar_DocumentoDetalleId(nroDoc);
                if (data.Rows.Count > 0)
                {
                    var dt = data.Rows[0];
                    estadoDoc = Convert.ToString(dt["Estado_doc"]);
                    tipodoc = Convert.ToString(dt["Documento"]);

                    if (tipodoc.Trim() != "Nota Venta") { MessageBox.Show("El Comprobante que has cargado no es valido para Canje", "Canje de Documento"); return; }

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
                        cbo_tipodocumento.SelectedValue = Convert.ToInt32(dt["Id_Tipo"]);
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
            if (cbo_tipodocumento.SelectedIndex == -1) { filtro.Show(); ver.lbl_msm.Text = "Por favor, seleciona el tipo de documento a emitir"; ver.ShowDialog(this); filtro.Hide(); cbo_tipodocumento.Focus(); return false; }

            if (cbo_tipodocumento.SelectedIndex == 0) { filtro.Show(); ver.lbl_msm.Text = "Por favor, no Selecciones Nota de Venta"; ver.ShowDialog(this); filtro.Hide(); cbo_tipodocumento.Focus(); return false; }

            int tipoDocumento = Convert.ToInt32(
                cbo_tipodocumento.SelectedValue);
            string documentoCliente = new string(
                txt_dni.Text.Where(Char.IsDigit).ToArray());

            if (tipoDocumento == 1 && documentoCliente.Length != 11)
            {
                MessageBox.Show(
                    "Para emitir una factura el cliente debe tener un RUC válido de 11 dígitos.",
                    "Datos del cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            decimal total;
            if (tipoDocumento == 2 &&
                decimal.TryParse(txt_totalpagar.Text, out total) &&
                total > 700m &&
                documentoCliente.Length != 8 &&
                documentoCliente.Length != 11)
            {
                MessageBox.Show(
                    "Una boleta mayor a S/ 700 requiere DNI o RUC del cliente.",
                    "Datos del cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }



        private string Guardar_Documento()
        {
            string nuevo = new CN_CanjeDocumento().Canjear(
                txt_nroDoc.Text,
                Convert.ToInt32(cbo_tipodocumento.SelectedValue),
                dtp_fechaemi.Value,
                Convert.ToInt32(Cls_ModalCategoria.IdUsu));
            txt_newnro_Doc.Text = nuevo;
            return nuevo;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Nuevo_Buscarprod_Click(sender, e);
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


        private void btn_Nuevo_Buscarprod_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Trim().Length > 6)
            {
                Buscar_Documento_ParaReimprimir(txt_buscar.Text);
            }

        }

        private void btn_Canjear_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            CN_Documento obj = new CN_Documento();
            CN_Caja objCaja = new CN_Caja();
            try
            {
                if (ValidarVenta())
                {
                    string documentoNuevo = Guardar_Documento();
                    fil.Show();
                    ok.Lbl_msm1.Text =
                        "Documento canjeado correctamente: " + documentoNuevo;
                    ok.ShowDialog(this);
                    fil.Hide();
                    Tag = "A";
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
    }
}
