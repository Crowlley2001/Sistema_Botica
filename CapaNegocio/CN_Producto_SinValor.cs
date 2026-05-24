using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto_SinValor
    {
        public DataTable CN_Cargar_Producto_sinVenta_porStock_porRango(DateTime dia1, DateTime dia2)
        {
            CD_Producto_SinValor obj = new CD_Producto_SinValor();
            return obj.CD_Cargar_Producto_sinVenta_porStock_porRango(dia1, dia2);
        }

        public DataTable CN_Cargar_Producto_sinVenta_porStock_deldia(DateTime dia)
        {
            CD_Producto_SinValor obj = new CD_Producto_SinValor();
            return obj.CD_Cargar_Producto_sinVenta_porStock_deldia(dia);
        }

        public void CN_Registrar_Producto_sinValor(string idprod, int idusu, string motivo)
        {
            CD_Producto_SinValor obj = new CD_Producto_SinValor();
            obj.CD_Registrar_Producto_sinValor(idprod, idusu, motivo);
        }
    }
}
