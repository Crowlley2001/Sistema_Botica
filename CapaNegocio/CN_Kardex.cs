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
    public class CN_Kardex
    {
        //----------------------------- METODO REGISTRAR KARDEX--------------------------------//
        public void RegistrarKardex(string idkardx, string idproducto)
        {
            CD_Kardex obj = new CD_Kardex();
            obj.RegistrarKardex(idkardx, idproducto);
        }
        //---------------------------- METODO REGISTRAR DETALLEKARDEX--------------------------//
        public void Registrar_DetalleKardex(Detalle_Kardex kr)
        {
            CD_Kardex obj = new CD_Kardex();
            obj.Registrar_DetalleKardex(kr);
        }
        //------------------------- METODO VERIFICAR KARDEX POR PRODUCTO-----------------------//
        public bool Verificar_Kardex_Producto(string idprod)
        {
            CD_Kardex obj = new CD_Kardex();
            return obj.Verificar_Producto_Kardex(idprod);
        }
        //--------------------------- METODO BUSCAR KARDEX POR VALOR---------------------------//
        public DataTable BuscarKardexPorValor(string idprod)
        {
            CD_Kardex obj = new CD_Kardex();
            return obj.CD_Buscar_KARDEXVALOR(idprod);
        }

        //---------------------- METODO BUSCAR DETALLES KARDEX POR DIA------------------------//
        public DataTable CN_Buscar_DetallesKardex_PorDia(DateTime dia)
        {
            CD_Kardex obj = new CD_Kardex();
            return obj.CD_Buscar_DetallesKardex_PorDia(dia);
        }

        //------------------- METODO LISTAR PRODUCTOS SIN STOCK POR VENTA ---------------------//
        public DataTable CN_Listar_Productos_SinStock_porVenta(DateTime dia)
        {
            CD_Kardex obj = new CD_Kardex();
            return obj.CD_Listar_Productos_SinStock_porVenta(dia);
        }

        //--------------- METODO LISTAR PRODUCTOS QUE TUBIERON AJUSTE DE INVENTARIO ---------------//
        public DataTable CN_Listar_Productos_QueTuvieron_ajusteInver(DateTime dia, DateTime hasta, string tipo)
        {
            CD_Kardex obj = new CD_Kardex();
            return obj.CD_Listar_Productos_QueTuvieron_ajusteInver(dia, hasta, tipo);
        }  
            
    }
}
