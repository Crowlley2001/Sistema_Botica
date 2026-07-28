using CapaDatos;
using System;

namespace CapaNegocio
{
    public class CN_CanjeDocumento
    {
        public string Canjear(
            string idDocumentoOrigen,
            int idTipoDocumentoNuevo,
            DateTime fechaEmision,
            int idUsuario)
        {
            if (String.IsNullOrWhiteSpace(idDocumentoOrigen))
                throw new InvalidOperationException(
                    "Debe seleccionar la nota que desea canjear.");

            if (idTipoDocumentoNuevo != 1 &&
                idTipoDocumentoNuevo != 2)
                throw new InvalidOperationException(
                    "Seleccione factura o boleta.");

            return new CD_CanjeDocumento().Canjear(
                idDocumentoOrigen,
                idTipoDocumentoNuevo,
                fechaEmision,
                idUsuario);
        }
    }
}
