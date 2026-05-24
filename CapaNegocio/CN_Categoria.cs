using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        //---------------------------- METODO REGISTRAR CATEGORIA------------------------------//
        public void RegistrarCategoria(string nombreCateg)
        {
            CD_Categoria objCateg = new CD_Categoria();
            objCateg.CD_RegistrarCategoria(nombreCateg);
        }
        //----------------------------- METODO EDITAR CATEGORIA--------------------------------//
        public void EditarCategoria(int idCateg, string nombreCateg)
        {
            CD_Categoria objCateg = new CD_Categoria();
            objCateg.CD_EditarCategoria(idCateg, nombreCateg);
        }
        //----------------------------- METODO LISTAR CATEGORIA--------------------------------//
        public DataTable ListarCategorias()
        {
            CD_Categoria objCateg = new CD_Categoria();
            return objCateg.CD_ListarCategoria();
        }
    }
}

