using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TipoCambio
    {
        //-------------------------- GUARDAR -----------------------------//
        public static void CN_Guardar_TipoCambio(DateTime fecha, double compra, double venta, int idUsu)
        {
            if (compra <= 0 || venta <= 0)
            {
                throw new Exception("El tipo de cambio debe ser mayor a 0");
            }

            CD_TipoCambio.CD_Guardar_TipoCambio(fecha, compra, venta, idUsu);
        }

        //-------------------------- BUSCAR -----------------------------//
        public static DataTable CN_Buscar_TipoCambio_Fecha(DateTime fecha)
        {
            return CD_TipoCambio.CD_Buscar_TipoCambio_Fecha(fecha);
        }

        //-------------------------- LISTAR -----------------------------//
        public static DataTable CN_Listar_TipoCambio()
        {
            return CD_TipoCambio.CD_Listar_TipoCambio();
        }

        
        public static bool ExisteTipoCambio(DateTime fecha)
        {
            return CD_TipoCambio.ExisteTipoCambio(fecha);
        }

        public static DataTable CN_TipoCambio_Actual()
        {
            return CD_TipoCambio.ObtenerTipoCambioActual();
        }
    }
}
