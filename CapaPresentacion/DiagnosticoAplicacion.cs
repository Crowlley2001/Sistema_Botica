using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class DiagnosticoAplicacion
    {
        public static void Configurar()
        {
            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, args) =>
                RegistrarYMostrar(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                RegistrarYMostrar(args.ExceptionObject as Exception);
        }

        public static void RegistrarYMostrar(Exception error)
        {
            try
            {
                string directorio = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "BoticaElicler",
                    "Logs");
                Directory.CreateDirectory(directorio);

                string archivo = Path.Combine(
                    directorio,
                    "errores-" + DateTime.Now.ToString("yyyy-MM") + ".log");
                StringBuilder contenido = new StringBuilder();
                contenido.AppendLine(new string('-', 70));
                contenido.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                contenido.AppendLine(
                    error == null ? "Error no identificado" : error.ToString());
                File.AppendAllText(archivo, contenido.ToString(), Encoding.UTF8);
            }
            catch
            {
                // El registro nunca debe provocar un segundo fallo.
            }

            MessageBox.Show(
                "Ocurrió un error inesperado. La operación no pudo completarse.\n\n" +
                "Se guardó información técnica en la carpeta local de registros.",
                "Sistema Botica",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
