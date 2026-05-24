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
            string ruta = @"F:\PORTAFOLIO\SISTEMA_BOTICA\CPE_2\QR_TEMP\";

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
                bmp.Save(ruta + nroDoc + ".BMP", ImageFormat.Bmp);
            }
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Temporal objNegocio = new CN_Temporal();
                DataTable dt = objNegocio.CN_Buscar_TemporalId(NrDoc);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Crys_Print_Ticket ticket = new Crys_Print_Ticket();
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "V_Temporales_Detalle";
                    // Pasamos los datos
                    ticket.SetDataSource(dt);

                    // Vinculamos al visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No hay datos para el documento: " + NrDoc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }
       

        private void Imprimir_TicketVenta(string NrDoc)
        {
            try
            {
                // 1. Generar el QR
                CrearQR_Fisico(NrDoc, NrDoc);

                // 2. Obtener datos de la BD
                CN_Temporal objNegocio = new CN_Temporal();
                DataTable dt = objNegocio.CN_Buscar_TemporalId(NrDoc);

                if (dt != null && dt.Rows.Count > 0)
                {
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

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "V_Temporales_Detalle";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
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
            if(TipoDoc.Trim() == "nota")
            {
                Imprimir_TicketVenta(NrDoc);
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
