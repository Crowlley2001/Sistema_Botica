using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaPresentacion.Informes
{
    public partial class frm_print_Ticket : Form
    {
        public frm_print_Ticket()
        {
            InitializeComponent();
        }

        public string NrDoc;
        public string TipoDoc="";

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CrearQR_Fisico(string textoQR, string nroDoc)
        {
            string ruta = Path.Combine(
                Application.StartupPath, "CPE_2", "QR_TEMP");

            // 1. Si la carpeta no existe, la crea
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            // 2. Generador QR
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 1200,
                    Height = 1200,
                    Margin = 3
                }
            };

            // 3. Crear y guardar BMP
            using (Bitmap bmp = writer.Write(textoQR))
            {
                bmp.Save(
                    Path.Combine(ruta, nroDoc + ".BMP"),
                    ImageFormat.Bmp);
            }
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            Imprimir_TicketVenta(NrDoc);
        }
       

        private void Imprimir_TicketVenta(string NrDoc)
        {
            try
            {
                // El QR SUNAT/interno ya fue generado con todos sus datos al
                // registrar el temporal. Aquí solo se prepara el reporte.
                CN_Temporal objNegocio = new CN_Temporal();
                DataTable dt = objNegocio.CN_Buscar_TemporalId(NrDoc);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!dt.Columns.Contains("CodTem") ||
                        dt.AsEnumerable().Any(fila =>
                            !string.Equals(
                                Convert.ToString(fila["CodTem"]).Trim(),
                                NrDoc.Trim(),
                                StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException(
                            "Los datos recuperados no corresponden al comprobante " +
                            NrDoc.Trim() + ".");
                    }

                    // --- AQUÍ VA EL CÓDIGO DE LA RUTA ---
                    Crys_Print_Ticket ticket = new Crys_Print_Ticket();

                    // Construimos la ruta dinámica a la carpeta Informes
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Print_Ticket.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // La vista heredada contiene una ruta fija del equipo donde se
                    // creó el reporte. Se reemplaza por la ruta portátil del QR actual.
                    string rutaQrActual = Path.Combine(
                        Application.StartupPath,
                        "CPE_2",
                        "QR_TEMP",
                        NrDoc.Trim() + ".png");

                    if (dt.Columns.Contains("CodigoQr"))
                    {
                        foreach (DataRow fila in dt.Rows)
                            fila["CodigoQr"] = rutaQrActual;
                    }

                    AplicarMonedaDocumento(ticket, dt, NrDoc);

                    // Limpiar conexiones y trabajar exclusivamente con los datos
                    // filtrados del comprobante solicitado.
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "V_Temporales_Detalle";
                    ticket.SetDataSource(dt);

                    // Mostrar en el visor. No usar RefreshReport(): ese método
                    // vuelve a consultar el origen antiguo guardado dentro del RPT.
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.Refresh();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }
        private void frm_print_Ticket_Load(object sender, EventArgs e)
        {
            // La vista previa debe cargarse al abrirse para cualquier comprobante.
            // Anteriormente solo se cargaba cuando TipoDoc era exactamente "nota";
            // desde ventas llegan valores como "Nota Venta", "Boleta" o "Factura".
            if (string.IsNullOrWhiteSpace(NrDoc))
            {
                MessageBox.Show(
                    "No se recibió el número del comprobante.",
                    "Vista previa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Close();
                return;
            }

            Imprimir_TicketVenta(NrDoc.Trim());
        }

        private static void AplicarMonedaDocumento(
            Crys_Print_Ticket ticket, DataTable datosReporte, string numeroDocumento)
        {
            DataTable moneda = new CN_Documento()
                .CN_ObtenerMonedaDocumento(numeroDocumento);
            if (moneda == null || moneda.Rows.Count == 0)
                return;

            DataRow filaMoneda = moneda.Rows[0];
            string codigo = Convert.ToString(filaMoneda["CodigoMoneda"]).Trim();
            decimal tipoCambio = Convert.ToDecimal(filaMoneda["TipoCambio"]);
            decimal importeMoneda = Convert.ToDecimal(filaMoneda["ImporteMoneda"]);
            decimal importeSoles = Convert.ToDecimal(filaMoneda["ImporteSoles"]);

            CrystalDecisions.CrystalReports.Engine.TextObject etiquetaTotal =
                ticket.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text15"]
                    as CrystalDecisions.CrystalReports.Engine.TextObject;

            if (string.Equals(codigo, "USD", StringComparison.OrdinalIgnoreCase))
            {
                if (etiquetaTotal != null)
                    etiquetaTotal.Text = "TOTAL US$";

                foreach (DataRow fila in datosReporte.Rows)
                {
                    if (datosReporte.Columns.Contains("TotalT"))
                        fila["TotalT"] = importeMoneda.ToString("0.00");
                    if (datosReporte.Columns.Contains("SonT"))
                        fila["SonT"] = string.Format(
                            "US$ {0:0.00} | T.C. {1:0.000000} | Equiv. S/ {2:0.00}",
                            importeMoneda, tipoCambio, importeSoles);
                }
            }
            else if (etiquetaTotal != null)
            {
                etiquetaTotal.Text = "TOTAL S/";
            }
        }

        private void btn_reimprimir_Click(object sender, EventArgs e)
        {
            Crys_visor.ExportReport();
        }

        private void frm_print_Ticket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }
    }
}
