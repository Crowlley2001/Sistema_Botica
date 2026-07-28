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
    public class CN_Usuario
    {
        //------------------------ Verificar Acceso ---------------------------//
        public bool CN_VerificarAcceso(string xusu, string xpass)
        {
            CD_Usuario objUsuario = new CD_Usuario();
            return objUsuario.CD_Verificar_Acceso(xusu, xpass);
        }
        //------------------------ Buscar Usuarios ---------------------------//
        public DataTable CN_BuscarUsuario(string xusu)
        {
            CD_Usuario objUsuario = new CD_Usuario();
            return objUsuario.CD_Buscar_Usuarios(xusu);
        }

        public DataTable CN_Cargar_todos_Roels(string xusu)
        {
            CD_Usuario objUsuario = new CD_Usuario();
            return objUsuario.CD_Cargar_todos_Roels(xusu);
        }

        public DataTable CN_Buscar_Usuario_porId(int idusu)
        {
            CD_Usuario objUsuario = new CD_Usuario();
            return objUsuario.CD_Buscar_Usuario_porId(idusu);
        }

        public void CN_Eliminar_Usuario(int idusu)
        {
            CD_Usuario objUsuario = new CD_Usuario();
            objUsuario.CD_Eliminar_Usuario(idusu);
        }

        public DataTable CN_Cargar_todos_Usuarios()
        {
            CD_Usuario objUsuario = new CD_Usuario();
            return objUsuario.CD_Cargar_todos_Usuarios();
        }

        public int CN_ObtenerSiguienteIdUsuario()
        {
            CD_Usuario objUsuario = new CD_Usuario();
            return objUsuario.CD_ObtenerSiguienteIdUsuario();
        }

        public void CN_Registrar_Usuario(Usuarios obj)
        {
            CD_Usuario objUsuario = new CD_Usuario();
            objUsuario.CD_Registrar_Usuario(obj);
        }

        public void Cn_Modificar_Usaurio(Usuarios obj)
        {
            CD_Usuario objUsuario = new CD_Usuario();
            objUsuario.CD_Modificar_Usaurio(obj);
        }
    }
}
