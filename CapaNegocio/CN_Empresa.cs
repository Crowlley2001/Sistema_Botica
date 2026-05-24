using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Empresa
    {
        CD_Empresa obj = new CD_Empresa();

        public void EditarDatosEmpresa(
            string nombre,
            string ruc,
            string direccion,
            string correo,
            string usuariosol,
            string clavesol,
            string clavecertificado,
            string obs) 
        {
       
            string rutaFinal = string.IsNullOrEmpty(obs) ? "" : obs;

            // Llamamos a la Capa de Datos
            obj.EditarDatosEmpresa(
                nombre,
                ruc,
                direccion,
                correo,
                usuariosol,
                clavesol,
                clavecertificado,
                rutaFinal);
        }

        public DataTable MostrarDatosEmpresa()
        {
            return obj.MostrarDatosEmpresa();
        }
    }
}
