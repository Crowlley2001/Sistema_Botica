using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {


        public string conectar()
        {
            return "Data Source=DANIEL-ESTRADA\\SQLEXPRESS;Initial Catalog=BDSISTEMA_BOTICA;Integrated Security=True;TrustServerCertificate=True";
        }


        public static string conectar2()
        {
            return "Data Source=DANIEL-ESTRADA\\SQLEXPRESS;Initial Catalog=BDSISTEMA_BOTICA;Integrated Security=True;TrustServerCertificate=True";
        }


    }
}
