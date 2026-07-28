using CapaDatos;
using CapaEntidad;
using System;

namespace CapaNegocio
{
    public class CN_Venta
    {
        public void RegistrarVentaCompleta(
            VentaCompleta venta,
            out string idPedido,
            out string idDocumento)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            if (venta.Detalles == null || venta.Detalles.Count == 0)
                throw new InvalidOperationException("La venta no contiene productos.");

            string metodo = (venta.TipoPago ?? string.Empty).Trim();
            if (metodo.Length == 0)
                throw new InvalidOperationException("La venta no tiene un método de pago.");

            bool esEfectivo = metodo.Equals(
                "Efectivo",
                StringComparison.OrdinalIgnoreCase);
            string referencia = (venta.NroOperacion ?? string.Empty).Trim();
            if (!esEfectivo && (referencia.Length < 4 || referencia.Length > 20))
            {
                throw new InvalidOperationException(
                    "El pago electrónico requiere un código de operación válido de 4 a 20 caracteres.");
            }

            venta.TipoPago = metodo;
            venta.NroOperacion = esEfectivo ? string.Empty : referencia;

            CD_Venta datos = new CD_Venta();
            datos.RegistrarVentaCompleta(venta, out idPedido, out idDocumento);
        }
    }
}
