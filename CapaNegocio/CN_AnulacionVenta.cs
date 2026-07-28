using CapaDatos;
using System;

namespace CapaNegocio
{
    public class CN_AnulacionVenta
    {
        public void Anular(string idDocumento, bool devolverStock, int idUsuario)
        {
            if (String.IsNullOrWhiteSpace(idDocumento))
                throw new InvalidOperationException(
                    "Debe seleccionar un comprobante para anular.");

            new CD_AnulacionVenta().Anular(idDocumento, devolverStock, idUsuario);
        }
    }
}
