using CapaDatos;
using CapaEntidad;
using System;

namespace CapaNegocio
{
    public class CN_CompraCompleta
    {
        public string Registrar(CompraCompleta compra)
        {
            if (compra == null)
                throw new ArgumentNullException(nameof(compra));

            if (compra.Detalles == null || compra.Detalles.Count == 0)
                throw new InvalidOperationException("La compra no contiene productos.");

            if (String.IsNullOrWhiteSpace(compra.NroFacturaFisica))
                throw new InvalidOperationException(
                    "Debe indicar el comprobante físico del proveedor.");

            return new CD_CompraCompleta().Registrar(compra);
        }
    }
}
