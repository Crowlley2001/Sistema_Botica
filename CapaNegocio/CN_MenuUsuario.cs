using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_MenuUsuario
    {
        private readonly MenuUsuario menuUsuario = new MenuUsuario();

        // Registrar privilegios
        public void CN_RegistrarPrivilegios(string nomMenu, int idUsu)
        {
            menuUsuario.CD_Registrar_Privilegios_Usuario(nomMenu, idUsu);
        }

        // Eliminar privilegios
        public void CN_EliminarPrivilegios(int idUsu)
        {
            menuUsuario.CD_Eliminar_privilegios_Usuario(idUsu);
        }

        // Leer privilegios (retorna DataTable)
        public DataTable CN_LeerPrivilegios(int idUsu)
        {
            return menuUsuario.CD_Leer_Privilegio_Usuario(idUsu);
        }

        // Verificar si el usuario tiene menú
        public bool CN_VerificarSiTieneMenu(int idUsu)
        {
            return menuUsuario.CD_Verificar_sitiene_menu(idUsu);
        }

        // Listar Id del menú por nombre
        public string CN_ListarIdMenuSys(string nomMenu, int idUsu)
        {
            return MenuUsuario.CD_Listar_Id_MenuSys(nomMenu, idUsu);
        }
    }

}
