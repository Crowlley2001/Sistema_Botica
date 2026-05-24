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
    public class CN_Temporal
    {
        //---------------------------- METODO REGISTRAR TEMPORAL-----------------------------//
        public void CN_RegistrarTemporal(Temporal objTem) 
        {
            CD_Temporal obj = new CD_Temporal();
            obj.CD_RegistrarTemporal(objTem);
        }

        //------------------------ METODO REGISTRAR DETALLETEMPORAL--------------------------//
        public void CN_DetalleTemporal(Detalle_Temporal objDet)
        {
            CD_Temporal obj = new CD_Temporal();
            obj.CD_DetalleTemporal(objDet);
        }

        //----------------------------- METODO ELIMINAR TEMPORAL-----------------------------//
        public void CN_Eliminar_Temporal(string idtemp)
        {
            CD_Temporal obj = new CD_Temporal();
            obj.CD_Eliminar_Temporal(idtemp);
        }

        //--------------------------- METODO BUSCAR TEMPORAL POR ID--------------------------//
        public DataTable CN_Buscar_TemporalId(string idtemp)
        {
            CD_Temporal obj = new CD_Temporal();
            return obj.CD_Buscar_TemporalId(idtemp);
        }
    }
}
