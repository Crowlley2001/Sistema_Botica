using System;
using System.Globalization;

namespace CapaPresentacion.Comprobantes
{
    internal static class QrSunatContenido
    {
        public static string Construir(
            string rucEmisor,
            string tipoComprobante,
            string numeroDocumento,
            decimal igv,
            decimal total,
            DateTime fechaEmision,
            string documentoCliente,
            string valorResumen)
        {
            string[] numeracion = SepararNumeracion(numeroDocumento);
            string tipoDocumentoSunat = ObtenerTipoComprobante(tipoComprobante);
            string documentoNormalizado = SoloDigitos(documentoCliente);
            string tipoDocumentoCliente = ObtenerTipoDocumentoCliente(documentoNormalizado);

            return string.Join("|", new[]
            {
                SoloDigitos(rucEmisor),
                tipoDocumentoSunat,
                numeracion[0],
                numeracion[1],
                igv.ToString("0.00", CultureInfo.InvariantCulture),
                total.ToString("0.00", CultureInfo.InvariantCulture),
                fechaEmision.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                tipoDocumentoCliente,
                documentoNormalizado,
                valorResumen ?? string.Empty
            });
        }

        public static bool EsComprobanteElectronico(string tipoComprobante)
        {
            return string.Equals(tipoComprobante, "Factura", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(tipoComprobante, "Boleta", StringComparison.OrdinalIgnoreCase);
        }

        private static string ObtenerTipoComprobante(string tipoComprobante)
        {
            if (string.Equals(tipoComprobante, "Factura", StringComparison.OrdinalIgnoreCase))
                return "01";

            if (string.Equals(tipoComprobante, "Boleta", StringComparison.OrdinalIgnoreCase))
                return "03";

            throw new ArgumentException(
                "El formato QR SUNAT solo corresponde a factura o boleta.",
                nameof(tipoComprobante));
        }

        private static string ObtenerTipoDocumentoCliente(string documento)
        {
            if (documento.Length == 8)
                return "1";

            if (documento.Length == 11)
                return "6";

            return "0";
        }

        private static string[] SepararNumeracion(string numeroDocumento)
        {
            string[] partes = (numeroDocumento ?? string.Empty).Trim().Split('-');
            if (partes.Length != 2 ||
                string.IsNullOrWhiteSpace(partes[0]) ||
                string.IsNullOrWhiteSpace(partes[1]))
            {
                throw new FormatException(
                    "El comprobante debe tener el formato SERIE-NÚMERO.");
            }

            return new[] { partes[0].Trim(), partes[1].Trim() };
        }

        private static string SoloDigitos(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return string.Empty;

            char[] resultado = Array.FindAll(valor.ToCharArray(), char.IsDigit);
            return new string(resultado);
        }
    }
}
