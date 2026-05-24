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
    public class CN_TipoDoc
    {
        private static CD_TipoDoc obj_dato = new CD_TipoDoc();
        //----------------------------- METODO GENERAR NRO CORRELATIVO -------------------------------//
        public static string CN_Generar_NroCorrelativo(int idtipo)
        {
            return CD_TipoDoc.CD_Generar_NroCorrelativo(idtipo);
        }
        //----------------------------- METODO ACTUALIZAR CORRELATIVO --------------------------------//
        public static void CN_Actualizar_Correlativo(int idtipo)
        {
            CD_TipoDoc.CD_Actualizar_Correlativo(idtipo);
        }
        //----------------------------- METODO LISTAR TIPO DOCUMENTO --------------------------------//
        public DataTable CN_Listar_Tipo_Doc()
        {
            return obj_dato.CD_Listar_Tipo_Doc();
        }
        //--------------------- METODO LISTAR TIPO DOCUMENTO ESPECIAL VENTAS ------------------------//
        public DataTable CN_Listar_Tipo_Doc_Especial_Ventas()
        {
            return obj_dato.CD_Listar_Tipo_Doc_Especial_Ventas();
        }
        //----------------------------- METODO EDITAR TIPO DOCUMENTO --------------------------------//
        public void CN_Editar_Tipo_Doc(int id, string doc, string serie, string num)
        {
            obj_dato.CD_Editar_Tipo_Doc(id, doc, serie, num);
        }

        public DataTable CN_Cargar_Correlativo_porId(int idtipo)
        {
            return obj_dato.CD_Cargar_Correlativo_porId(idtipo);
        }

        public DataTable CN_Cargar_Todos_Los_Correlativos()
        {
            return obj_dato.CD_Cargar_Todos_Los_Correlativos();
        }

        public void CN_Editar_Correlativo(TipoDoc cja)
        {
            obj_dato.CD_Editar_Correlativo(cja);
        }
    }
}
