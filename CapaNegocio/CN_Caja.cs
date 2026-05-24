using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Caja
    {
        private CD_Caja objDato = new CD_Caja();

        //----------------------------------REGISTRAR MOVIMIENTO EN CAJA----------------------------------
        public void CN_Registrar_Mov_Caja(Caja cja)
        {
            objDato.CD_Registrar_Mov_Caja(cja);
        }

        //----------------------------------ACTUALIZAR TOTAL DE CAJA-------------------------------------
        public void CN_Actualizar_Total_Caja(string nroDoc, double total, double totalUtili, string tipoPago)
        {
            objDato.CD_Actualizar_Total_Caja(nroDoc, total, totalUtili, tipoPago);
        }

        //----------------------------------LISTAR TODAS LAS CAJAS---------------------------------------
        public DataTable CN_Listar_Todas_Cajas()
        {
            return objDato.CD_Listar_Todas_Cajas();
        }

        //-----------------------------------LISTAR CAJAS DEL DÍA----------------------------------------
        public DataTable CN_Listar_Cajas_DelDia(DateTime dia)
        {
            return objDato.CD_listar_Cajas_DelDia(dia);
        }

        //----------------------------------LISTAR CAJAS DEL MES-----------------------------------------
        public DataTable CN_Listar_Cajas_DelMes(DateTime mes)
        {
            return objDato.CD_listar_Cajas_Delmes(mes);
        }

        //-------------------------------LISTAR CAJAS POR RANGO DE FECHAS--------------------------------
        public DataTable CN_Listar_Cajas_PorRangoFecha(DateTime desde, DateTime hasta)
        {
            return objDato.CD_listar_Cajas_porRangoFecha(desde, hasta);
        }

        //--------------------------LISTAR CAJAS POR MES Y TIPO DE DOCUMENTO-----------------------------
        public DataTable CN_Listar_Cajas_PorMes_TipoDoc(DateTime mes, string tipoDoc)
        {
            return objDato.CD_listar_Cajas_pormes_tipoDoc(mes, tipoDoc);
        }

        //----------------------------------BUSCADOR GENERAL DE CAJAS------------------------------------
        public DataTable CN_Buscador_General_Cajas(string valor)
        {
            return objDato.CD_buscador_General_Cajas(valor);
        }

        //----------------------------------ANULAR MOVIMIENTO DE CAJA------------------------------------
        public void CN_Anular_Movimiento_Caja(string nroDoc, string estado)
        {
            objDato.CD_anular_Movimiento_Caja(nroDoc,estado);
        }

        //----------------------------------CAMBIAR MODO DE CIERRE DE CAJA-------------------------------
        public void CN_CambiarModo_Caja(int idCaja)
        {
            objDato.CD_CambiarModo_Caja(idCaja);
        }

        //-------------------------------LISTAR GASTOS DEL DÍA PARA REPORTE------------------------------
        public DataTable CN_Listar_GastosDelDia_Reporte(DateTime dia)
        {
            return objDato.CD_listar_GastosdelDia_paraReporte(dia);
        }
    }
}
