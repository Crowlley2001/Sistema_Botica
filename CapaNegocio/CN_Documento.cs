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
    public class CN_Documento
    {
        //----------------------------- METODO REGISTRAR DOCUMENTO --------------------------------//
        public void RegistrarDocumento(Documento pro)
        {
            CD_Documento obj = new CD_Documento();
            obj.CD_RegistrarDocumento(pro);
        }

        //------------------------- METODO BUSCAR DETALLEDOCUMENTO POR ID -------------------------//
        public DataTable CN_Buscar_DocumentoDetalleId(string idtemp)
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_Buscar_DocumentoDetalleId(idtemp);
        }

        //------------------------------------ METODO ANULAR DOCUMENTO ----------------------------//
        public void CN_AnulaDocumento(string idtemp, string estado)
        {
            CD_Documento obj = new CD_Documento();
            obj.CD_AnulaDocumento(idtemp, estado);
        }

        //--------------------------- METODO LISTAR TODOS LOS DOCUMENTOS --------------------------//
        public DataTable CN_Listar_Documentos()
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_Listar_Documentos();
        }

        //---------------------------- METODO LISTAR DOCUMENTOS EMITIDOS --------------------------//
        public DataTable CN_Listar_Documentos_Pordia(DateTime xdia)
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_Listar_Documentos_Pordia(xdia);
        }

        public DataTable CN_ObtenerMonedaDocumento(string idDocumento)
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_ObtenerMonedaDocumento(idDocumento);
        }

        //-------------------------- METODO LISTAR TODOS LOS DOCUMENTOS ID ------------------------//
        public DataTable CN_Buscar_DocumentoId(string idtemp)
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_Buscar_DocumentoId(idtemp);
        }

        //---------------------- METODO LISTAR FACTURAS EMITIDAS EN EL MES ------------------------//
        public DataTable CN_Listar_Facturas_Emitidas_Mes(DateTime fechaMes)
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_Listar_Facturas_Emitidas_Mes(fechaMes);
        }

        //--------------------- METODO LISTAR FACTURAS EMITIDAS EN RANGO --------------------------//
        public DataTable CN_Listar_Facturas_Emitidas_Rango(DateTime fechaInicio, DateTime fechaFin)
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_Listar_Facturas_Emitidas_Rango(fechaInicio, fechaFin);
        }

        //--------------------- METODO LISTAR COMPROBANTES EMITIDOS EN EL MES ---------------------//
        public DataTable CN_Listar_Comprobantes_Emitidos_Mes(DateTime fechaMes, int tipoDoc)
        {
            CD_Documento obj = new CD_Documento();
            return obj.CD_Listar_Comprobantes_Emitidos_Mes(fechaMes, tipoDoc);
        }
      
    }
}
