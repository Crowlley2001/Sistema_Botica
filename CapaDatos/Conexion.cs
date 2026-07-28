using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {


        public string conectar()
        {
            return ObtenerCadenaConexion();
        }


        public static string conectar2()
        {
            return ObtenerCadenaConexion();
        }

        private static string ObtenerCadenaConexion()
        {
            ConnectionStringSettings configuracion =
                ConfigurationManager.ConnectionStrings["BoticaDb"];

            if (configuracion == null ||
                string.IsNullOrWhiteSpace(configuracion.ConnectionString))
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la conexión 'BoticaDb' en App.config.");
            }

            return configuracion.ConnectionString;
        }

    }
}
