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
    public class CN_Producto
    {
        //----------------------------- METODO REGISTRAR PRODUCTO-------------------------------//
        public void RegistrarProducto(Producto objProd)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_RegistrarProducto(objProd);
        }

        //----------------------------- METODO EDITAR PRODUCTO----------------------------------//
        public void EditarProducto(Producto objProd)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_EditarProducto(objProd);
        }

        //----------------------------- METODO BUSCAR PRODUCTO ID-------------------------------//
        public DataTable BuscarProductoID(string idprod)
        {
            CD_Producto obj = new CD_Producto();
            return obj.CD_Buscar_ProductoID(idprod);
        }

        //----------------------------- METODO DAR BAJA PRODUCTO--------------------------------//
        public void DarBajaProducto(string idProd)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_DarBaja_Producto(idProd);
        }

        //----------------------------- METODO ELIMINAR PRODUCTO--------------------------------//
        public void EliminarProducto(string idProd,string idkardex)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_Eliminar_Producto(idProd, idkardex);
        }

        //-------------------------- METODO MOSTRAR TODOS PRODUCTOS-----------------------------//
        public DataTable CargarTodos_Productos()
        {
            CD_Producto obj = new CD_Producto();
            return obj.CD_Mostrar_Producto();
        }

        //-------------------------- METODO RESTAR STOCK PRODUCTOS------------------------------//
        public void RestarStock_Producto(string idprod, double stock)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_RestarStock_Producto(idprod, stock);
        }

        //---------------------------- METODO SUMAR STOCK PRODUCTOS-----------------------------//
        public void SumarStock_Producto(string idprod, double stock)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_SumarStock_Producto(idprod,stock);
        }

        public void CN_Actualizar_PrecioCompra_Producto(string idpro, double precomprasol, double preventa_menor, double utilidad, double valoralmacen)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_Actualizar_PrecioCompra_Producto(idpro, precomprasol, preventa_menor, utilidad, valoralmacen);
        }

        //--------------------------- METODO IGUALAR STOCK PRODUCTOS----------------------------//
        public void CN_Igualar_Stock_Producto(string idpro, double stock)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_Igualar_Stock_Producto(idpro, stock);
        }

        //---------------------- METODO CAMBIAR ESTADO REPORTE PRODUCTOS------------------------//
        public void CN_Cambiar_campo_estadoReporte(string idprod, string palabra)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_Cambiar_campo_estadoReporte(idprod, palabra);
        }

        //------------------- METODO LISTAR TODOS LOS PRODUCTOS SIN ROTACION--------------------//
        public DataTable CN_Listar_todos_Los_productos_sinRotacion(string palabra)
        {
            CD_Producto obj = new CD_Producto();
            return obj.CD_Listar_todos_Los_productos_sinRotacion(palabra);
        }


        public void Cn_Calcular_Valor_Almacen(string idpro)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_Calcular_Valor_Almacen(idpro);
        }

        public void CN_Calcular_Utilidad_deAlamacen(string idpro)
        {
            CD_Producto obj = new CD_Producto();
            obj.CD_Calcular_Utilidad_deAlamacen(idpro);
        }

        public DataTable CN_Listar_Productos_MasVendidos(DateTime fecha)
        {
            CD_Producto obj = new CD_Producto();
            return obj.CD_Listar_Productos_MasVendidos(fecha);
        }

        public DataTable CN_ProductosReposicion()
        {
            CD_Producto obj = new CD_Producto();
            return obj.CD_ProductosReposicion();
        }

        public bool ExisteProducto(string nombre)
        {
            CD_Producto obj = new CD_Producto();
            return obj.CD_ExisteProducto(nombre);
        }
    }
}
