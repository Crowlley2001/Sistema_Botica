using CapaPresentacion.Cajas;
using CapaPresentacion.Compras;
using CapaPresentacion.Modales;
using CapaPresentacion.Producto;
using CapaPresentacion.Reportes;
using CapaPresentacion.Usuario;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DiagnosticoAplicacion.Configurar();

            string problema = VerificadorSistema.Verificar();
            if (!String.IsNullOrWhiteSpace(problema))
            {
                MessageBox.Show(
                    problema,
                    "Verificación del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (VerificadorSistema.EsEntornoPruebas())
            {
                MessageBox.Show(
                    "ENTORNO DE PRUEBAS\n\n" +
                    "Todas las operaciones se guardarán en " +
                    "BDSISTEMA_BOTICA_PRUEBA.\n" +
                    "La base original no será utilizada.",
                    "Sistema Botica Profesional",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            Application.Run(new Login());
        }
    }
}
