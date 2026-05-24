using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Pedido
    {
        //----------------- METODO REGISTRAR PEDIDO ----------------//
        public void CN_Registrar_Pedido(Pedido pro)
        {
            CD_Pedido obj = new CD_Pedido();
            obj.CD_RegistrarPedido(pro);
        }

        //------------- METODO REGISTRARDETALLE PEDIDO -------------//
        public void CN_Registrar_DetallePedido(Detalle_Pedido det) 
        {
            CD_Pedido obj = new CD_Pedido();
            obj.CD_DetallePedido(det);
        }

        //------------- METODO ELIMINAR DETALLEPEDIDO --------------//
        public bool CN_Eliminar_DetallePedido(string idPed)
        {
            CD_Pedido obj = new CD_Pedido();
            obj.CD_Eliminar_DetallePedido(idPed);   
            return CD_Pedido.elminado_temp;        
        }

        //----------------- METODO BUSCAR PEDIDOID -----------------//
        public DataTable CN_Buscar_PedidoId(string idPed)
        {
            CD_Pedido obj = new CD_Pedido();
            return obj.CD_Buscar_PedidoId(idPed);
        }

        //----------------- METODO ELIMINAR PEDIDO -----------------//
        public bool CN_Eliminar_Pedido(string idPed)
        {
            CD_Pedido obj = new CD_Pedido();
            obj.CD_Eliminar_Pedido(idPed);          
            return CD_Pedido.elminado_temp;         
        }

        //-------------- METODO CAMBIARESTADO PEDIDO ---------------//
        public void CN_Cambiar_EstadoPedido(string idpedido)
        {
            CD_Pedido obj = new CD_Pedido();
            obj.CD_Cambiar_EstadoPedido(idpedido);
        }

        //------- METODO VERIFICAR SI PRODUCTO TIENE VENTA --------//
        public bool CN_Verificar_siProducto_TieneVenta(string idprod, DateTime fecha)
        {
            CD_Pedido obj = new CD_Pedido();
            return obj.CD_Verificar_siProducto_TieneVenta(idprod, fecha);
        }
    }
}
