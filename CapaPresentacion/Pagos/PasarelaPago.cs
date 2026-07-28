using System;

namespace CapaPresentacion
{
    /// <summary>
    /// Contrato preparado para reemplazar la confirmación manual por el SDK
    /// de un POS o pasarela (Niubiz, Izipay, Culqi, etc.).
    /// Nunca debe recibir ni almacenar PIN, CVV o el número completo de tarjeta.
    /// </summary>
    public interface IPasarelaPago
    {
        ResultadoPago Validar(
            string metodo,
            string referencia,
            decimal importe,
            string codigoMoneda);
    }

    public sealed class ResultadoPago
    {
        public bool Aprobado { get; private set; }
        public string Mensaje { get; private set; }

        public static ResultadoPago Aprobar()
        {
            return new ResultadoPago { Aprobado = true, Mensaje = string.Empty };
        }

        public static ResultadoPago Rechazar(string mensaje)
        {
            return new ResultadoPago { Aprobado = false, Mensaje = mensaje };
        }
    }

    /// <summary>
    /// Operación confirmada por el vendedor mirando el voucher o la aplicación
    /// del proveedor. Es el modo correcto mientras no exista un SDK de POS.
    /// </summary>
    public sealed class PasarelaPagoManual : IPasarelaPago
    {
        public ResultadoPago Validar(
            string metodo,
            string referencia,
            decimal importe,
            string codigoMoneda)
        {
            if (string.IsNullOrWhiteSpace(metodo))
                return ResultadoPago.Rechazar("Seleccione un método de pago.");

            if (importe <= 0)
                return ResultadoPago.Rechazar("El importe del cobro debe ser mayor a cero.");

            if (EsEfectivo(metodo))
                return ResultadoPago.Aprobar();

            string operacion = (referencia ?? string.Empty).Trim();
            if (operacion.Length < 4 ||
                operacion.Equals("Nro. Operacion", StringComparison.OrdinalIgnoreCase))
            {
                return ResultadoPago.Rechazar(
                    "Ingrese el código de operación o número de voucher que confirma el pago.");
            }

            if (operacion.Length > 20)
                return ResultadoPago.Rechazar(
                    "El código de operación admite como máximo 20 caracteres.");

            return ResultadoPago.Aprobar();
        }

        public static bool EsEfectivo(string metodo)
        {
            return string.Equals(
                (metodo ?? string.Empty).Trim(),
                "Efectivo",
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
