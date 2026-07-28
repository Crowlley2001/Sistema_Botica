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
    public class CN_CierreCaja
    {
        private CD_CierreCaja objCapaDatos = new CD_CierreCaja();

        //----------------------------------METODO REGISTRAR MOVIMIENTO EN CAJA----------------------------------//
        public void CN_Registrar_Inicio_Caja(Cierre_Caja obj)
        {
            objCapaDatos.CD_Registrar_Inicio_Caja(obj);
        }

        //------------------------------ MÉTODO PARA REGISTRAR EL CIERRE DE CAJA --------------------------------//
        public void CN_Registrar_Cierre_Caja(Cierre_Caja obj)
        {
            objCapaDatos.CD_Registrar_Cierre_Caja(obj);
        }

        //----------------------------- MÉTODO PARA LISTAR CIERRES DE CAJA DEL DÍA ------------------------------//
        public DataTable CN_Listar_Cierre_Caja_DelDia(DateTime xdia, string estadocierre)
        {
            return objCapaDatos.CD_Listar_Cierre_Caja_DelDia(xdia, estadocierre);
        }

        //---------------------------- MÉTODO PARA LISTAR CIERRE DE CAJA POR ID ---------------------------------//
        public DataTable CN_Listar_Cierre_Caja_porID(string idcierre)
        {
            return objCapaDatos.CD_Listar_Cierre_Caja_porID(idcierre);
        }

        //---------------------------- MÉTODO PARA LISTAR TODOS LOS CIERRES DE CAJA -----------------------------//
        public DataTable CN_Listar_Todo_cierres()
        {
            return objCapaDatos.CD_Listar_Todo_cierres();
        }

        //-------------------------- MÉTODO PARA LISTAR CIERRE DE CAJA POR USUARIO ------------------------------//
        public DataTable CN_Listar_Cierre_Caja_porUsuario(int idusu)
        {
            return objCapaDatos.CD_Listar_Cierre_Caja_porUsuario(idusu);
        }

        //------------------------ MÉTODO PARA LISTAR CIERRE DE CAJA POR USUARIO Y MES --------------------------//
        public DataTable CN_Listar_Cierre_Caja_porUsu_Mes(int usuId, DateTime mes)
        {
            return objCapaDatos.CD_Listar_Cierre_Caja_porUsu_Mes(usuId, mes);
        }

        //------------------------------ MÉTODO PARA LISTAR CIERRE DE CAJA DEL MES ------------------------------//
        public DataTable CN_Listar_Cierre_Caja_delMes(DateTime xmes)
        {
            return objCapaDatos.BD_Listar_Cierre_Caja_delMes(xmes);
        }

        //----------------------- MÉTODO PARA LISTAR CIERRE DE CAJA POR RANGO DE FECHA --------------------------//
        public DataTable CN_Cargar_CierreCaja_porRangoFecha(DateTime desde, DateTime hasta)
        {
            return objCapaDatos.CD_Cargar_CierreCaja_porRangoFecha(desde, hasta);
        }

        //------------------------------ MÉTODO PARA VALIDAR INICIO DOBLE DE CAJA -------------------------------//
        public bool CN_validar_InicioDoble_caja()
        {
            return objCapaDatos.CD_validar_InicioDoble_caja();
        }

        public bool CN_TieneCajaAbiertaUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(idUsuario), "El usuario de caja no es válido.");

            return objCapaDatos.CD_TieneCajaAbiertaUsuario(idUsuario);
        }

        //------------------------ MÉTODO PARA CALCULAR VENTAS POR TIPO DE DOCUMENTO ----------------------------//
        public DataTable CN_Calcular_Ventas_PorTipo_Doc(string nomTipoDoc)
        {
            return objCapaDatos.CD_Calcular_Ventas_PorTipo_Doc(nomTipoDoc);
        }

        //----------------------------- MÉTODO PARA CALCULAR VENTAS A CRÉDITO -----------------------------------//
        public DataTable CN_Calcular_ventas_Acredito()
        {
            return objCapaDatos.CD_Calcular_ventas_Acredito();
        }

        //----------------------------- MÉTODO PARA CALCULAR VENTAS A DEPÓSITO ----------------------------------//
        public DataTable CN_Calcular_ventas_ADeposito()
        {
            return objCapaDatos.CD_Calcular_ventas_ADeposito();
        }

        //--------------------------- MÉTODO PARA CALCULAR GANANCIAS DEL DÍA ------------------------------------//
        public DataTable CN_Calcular_Ganancias_deldia()
        {
            return objCapaDatos.CD_Calcular_Ganancias_deldia();
        }

        public DataTable CN_Calcular_Gastos_TipoPago(string tipopago)
        {
            return objCapaDatos.CD_Calcular_Gastos_TipoPago(tipopago);
        }

        public void CN_Cerrar_Movimiento_Masivo()
        {
            objCapaDatos.CD_Cerrar_Movimientos_Masivo();
        }
    }
}
