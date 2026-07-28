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
    public class CN_Cliente
    {
        //----------------------------- METODO REGISTRAR CLIENTE-----------------------------//
        public void Registrar_Cliente(CapaEntidad.Cliente cli)
        {
            CD_Cliente objCli = new CD_Cliente();
            objCli.CD_RegistrarCliente(cli);
        }
        //----------------------------- METODO VALIDAR DNI-RUC-------------------------------//
        public bool Validar_NroDNI_RUC(string nroDni)
        {
            CD_Cliente objCli = new CD_Cliente();
            return objCli.Verificar_Nro_DNIRUC(nroDni);
        }
        //----------------------------- METODO LISTAR CLIENTE--------------------------------//
        public DataTable  Vertodos_los_Clientes(string estadox)
        {
            CD_Cliente objCli = new CD_Cliente();
            return objCli.CD_Vertodos_Los_Clientes(estadox);
        }
        //--------------------------- METODO BUSCAR CLIENTEVALOR-----------------------------//
        public DataTable Buscar_Clientes_PorValor(string valor)
        {
            CD_Cliente objCli = new CD_Cliente();
            return objCli.CD_Buscar_Clientes_PorValor(valor);
        }

        public void Editar_Cliente(Cliente cli)
        {
            CD_Cliente obj = new CD_Cliente();
            obj.CD_EditarCliente(cli);
        }

        public void DarBajaCliente(string idCliente)
        {
            if (string.IsNullOrWhiteSpace(idCliente))
                throw new ArgumentException("Debe seleccionar un cliente.");

            if (idCliente.Trim().Equals("C01", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(
                    "El cliente predeterminado para venta al público no se puede desactivar.");

            CD_Cliente obj = new CD_Cliente();
            obj.CD_CambiarEstadoCliente(idCliente.Trim(), "Eliminado");
        }
    }
}
