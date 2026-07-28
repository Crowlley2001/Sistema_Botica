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
    public class CN_Compra
    {
        public static bool CN_Existe_NroFactura_Fisica(string nroFactura)
        {
            if (string.IsNullOrWhiteSpace(nroFactura))
                return false;

            CD_Compra obj = new CD_Compra();
            return obj.CD_Existe_NroFactura_Fisica(nroFactura.Trim());
        }

        CD_Compra obj = new CD_Compra();
        public void CN_Registrar_Compras(Documento_Compras pro)
        {
            CapaDatos.CD_Compra obj = new CapaDatos.CD_Compra();
            obj.CD_Registrar_Compras(pro);
        }
        public void CN_Registrar_Detalle_Compras(Detalle_DocumentoCompra pro)
        {
            CD_Compra obj = new CD_Compra();
            obj.CD_Registrar_Detalle_Compras(pro);
        }
        public DataTable CN_Buscar_CompraconDetalle(string idpro)
        {
            CD_Compra obj = new CD_Compra();
            return obj.CD_Buscar_CompraconDetalle(idpro);
        }
        public void CN_Eliminar_RegistrarCompra(string NroId)
        {
            CD_Compra obj = new CD_Compra();
            obj.CD_Eliminar_RegistrarCompra(NroId);
        }

        public DataTable RN_cargar_Todas_Compras()
        {
            return obj.CD_cargar_Todas_Compras();
        }

        public DataTable RN_buscar_Compras_Explorador(string valor)
        {
            return obj.CD_buscar_Compras(valor);
        }

        public DataTable RN_buscar_Compras_Explorador_Pormes_Dia(string tipo, DateTime fecha)
        {
            return obj.CD_buscar_Compras_PorFecha(tipo, fecha);
        }

        public DataTable CN_Listar_Comprobantes_Emitidos_Mes(DateTime fecha, int idTipo)
        {
            CD_Documento objDatos = new CD_Documento();
            return objDatos.CD_Listar_Comprobantes_Emitidos_Mes(fecha, idTipo);
        }


    }
}
