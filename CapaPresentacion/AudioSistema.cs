using System;
using System.IO;
using System.Media;
using System.Reflection;

namespace CapaPresentacion
{
    internal static class AudioSistema
    {
        private static readonly object Sincronizacion = new object();
        private static SoundPlayer reproductor;
        private static MemoryStream audioActual;

        public static void Reproducir(string nombreArchivo)
        {
            try
            {
                lock (Sincronizacion)
                {
                    string archivoExterno = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);

                    if (File.Exists(archivoExterno))
                    {
                        ReproducirDesdeArchivo(archivoExterno);
                        return;
                    }

                    string recurso = "CapaPresentacion.Audio." + nombreArchivo;
                    using (Stream origen = Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(recurso))
                    {
                        if (origen == null)
                            return;

                        LiberarReproductor();
                        audioActual = new MemoryStream();
                        origen.CopyTo(audioActual);
                        audioActual.Position = 0;

                        reproductor = new SoundPlayer(audioActual);
                        reproductor.Load();
                        reproductor.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "No se pudo reproducir el audio: " + ex.Message);
            }
        }

        private static void ReproducirDesdeArchivo(string archivo)
        {
            LiberarReproductor();
            reproductor = new SoundPlayer(archivo);
            reproductor.Load();
            reproductor.Play();
        }

        private static void LiberarReproductor()
        {
            if (reproductor != null)
            {
                reproductor.Stop();
                reproductor.Dispose();
                reproductor = null;
            }

            if (audioActual != null)
            {
                audioActual.Dispose();
                audioActual = null;
            }
        }
    }
}
