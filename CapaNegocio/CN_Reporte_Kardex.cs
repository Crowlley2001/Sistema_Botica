using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Reporte_Kardex
    {
        public void CN_Registrar_Reporte(string idprod, string nombreprod, double stock, double compra_xstock, double precompra, double preventa,
                                         double venta_Xstock, double utilidad, double utilidad_xstock, string obs)
        {
            CD_Reporte_Kardex obj = new CD_Reporte_Kardex();
            obj.CD_Registrar_Reporte(idprod, nombreprod, stock, compra_xstock, precompra, preventa, venta_Xstock, utilidad, utilidad_xstock, obs);
        }

        public void CN_Eliminar_ReporteKardex()
        {
            CD_Reporte_Kardex obj = new CD_Reporte_Kardex();
            obj.CD_Eliminar_ReporteKardex();
        }

        public DataTable CN_Listar_Todos_Temporal_Kardex()
        {
            CD_Reporte_Kardex obj = new CD_Reporte_Kardex();
            return obj.CD_Listar_Todos_Temporal_Kardex();
        }
    }
}
