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
            nombreCateg = NormalizarNombre(nombreCateg);
            CD_Categoria objCateg = new CD_Categoria();
            objCateg.CD_RegistrarCategoria(nombreCateg);
        }
        //----------------------------- METODO EDITAR CATEGORIA--------------------------------//
        public void EditarCategoria(int idCateg, string nombreCateg)
        {
            nombreCateg = NormalizarNombre(nombreCateg);
            CD_Categoria objCateg = new CD_Categoria();
            objCateg.CD_EditarCategoria(idCateg, nombreCateg);
        }
        //----------------------------- METODO LISTAR CATEGORIA--------------------------------//
        public DataTable ListarCategorias()
        {
            CD_Categoria objCateg = new CD_Categoria();
            return objCateg.CD_ListarCategoria();
        }

        private static string NormalizarNombre(string nombreCateg)
        {
            string nombre = (nombreCateg ?? string.Empty).Trim();
            if (nombre.Length == 0)
                throw new ArgumentException(
                    "Debe ingresar el nombre de la categoría.", "nombreCateg");
            if (nombre.Length > 50)
                throw new ArgumentException(
                    "La categoría no puede superar los 50 caracteres.",
                    "nombreCateg");
            return nombre;
        }
    }
}

