using CapaDatos;
using CapaEntidad;
using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace CapaNegocio
{
    public interface IEmisorCpe
    {
        CpeResultado Emitir(CpeSolicitud solicitud);
    }

    public sealed class CN_CpeElectronico
    {
        private readonly IEmisorCpe emisor;

        public CN_CpeElectronico()
            : this(new EmisorCpeSimulado())
        {
        }

        public CN_CpeElectronico(IEmisorCpe emisorCpe)
        {
            emisor = emisorCpe ??
                throw new ArgumentNullException(nameof(emisorCpe));
        }

        public CpeResultado EmitirYGuardar(CpeSolicitud solicitud)
        {
            CpeResultado resultado = emisor.Emitir(solicitud);
            new CD_CpeElectronico().Guardar(solicitud.IdDocumento, resultado);
            return resultado;
        }

        public DataTable ListarEstados()
        {
            return new CD_CpeElectronico().ListarEstados();
        }

        public DataTable ListarCentro(string filtro, string estado)
        {
            return new CD_CpeElectronico().ListarCentro(filtro, estado);
        }

        public DataRow Obtener(string idDocumento)
        {
            return new CD_CpeElectronico().Obtener(idDocumento);
        }

        public CpeResultado ReintentarSimulacion(string idDocumento)
        {
            CD_CpeElectronico datos = new CD_CpeElectronico();
            DataRow fila = datos.Obtener(idDocumento);
            if (fila == null)
                throw new InvalidOperationException("No se encontró el comprobante CPE.");

            string ambiente = Convert.ToString(fila["Ambiente"]).Trim();
            if (!ambiente.Equals("SIMULACION", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(
                    "Solo se permite reintentar desde este módulo los CPE simulados.");

            string xml = Convert.ToString(fila["XmlGenerado"]);
            if (string.IsNullOrWhiteSpace(xml))
                throw new InvalidOperationException("El comprobante no conserva su XML.");

            string hash;
            using (SHA256 sha = SHA256.Create())
                hash = Convert.ToBase64String(
                    sha.ComputeHash(Encoding.UTF8.GetBytes(xml)));

            DateTime fecha = DateTime.Now;
            string cdr = new XDocument(
                new XElement("RespuestaSimulada",
                    new XElement("Ambiente", "SIMULACION"),
                    new XElement("Documento", idDocumento.Trim()),
                    new XElement("Codigo", "0-SIM"),
                    new XElement("Descripcion",
                        "Reintento aceptado únicamente por el simulador local"),
                    new XElement("Hash", hash),
                    new XElement("FechaProceso",
                        fecha.ToString("O", CultureInfo.InvariantCulture))))
                .ToString(SaveOptions.DisableFormatting);

            CpeResultado resultado = new CpeResultado
            {
                Ambiente = "SIMULACION",
                Estado = "ACEPTADO_SIMULADO",
                CodigoRespuesta = "0-SIM",
                Mensaje =
                    "Reintento aceptado por el simulador local. No fue enviado a SUNAT.",
                Hash = hash,
                XmlGenerado = xml,
                CdrContenido = cdr,
                FechaProceso = fecha
            };
            datos.Guardar(idDocumento, resultado);
            return resultado;
        }
    }

    internal sealed class EmisorCpeSimulado : IEmisorCpe
    {
        // RUC ficticio con dígito verificador matemáticamente válido.
        private const string RucPrueba = "20123456786";

        public CpeResultado Emitir(CpeSolicitud solicitud)
        {
            Validar(solicitud);
            string xml = ConstruirXml(solicitud);
            string hash = CalcularHash(xml);
            DateTime fecha = DateTime.Now;
            string cdr = new XDocument(
                new XElement("RespuestaSimulada",
                    new XElement("Ambiente", "SIMULACION"),
                    new XElement("Documento", solicitud.IdDocumento),
                    new XElement("Codigo", "0-SIM"),
                    new XElement("Descripcion",
                        "Comprobante aceptado únicamente por el simulador local"),
                    new XElement("Hash", hash),
                    new XElement("FechaProceso",
                        fecha.ToString("O", CultureInfo.InvariantCulture))))
                .ToString(SaveOptions.DisableFormatting);

            return new CpeResultado
            {
                Ambiente = "SIMULACION",
                Estado = "ACEPTADO_SIMULADO",
                CodigoRespuesta = "0-SIM",
                Mensaje = "Aceptado únicamente por el simulador local. No fue enviado a SUNAT.",
                Hash = hash,
                XmlGenerado = xml,
                CdrContenido = cdr,
                FechaProceso = fecha
            };
        }

        private static void Validar(CpeSolicitud solicitud)
        {
            if (solicitud == null || solicitud.Venta == null)
                throw new InvalidOperationException("No existen datos para generar el CPE.");
            if (string.IsNullOrWhiteSpace(solicitud.IdDocumento))
                throw new InvalidOperationException("El comprobante no tiene numeración.");
            if (solicitud.Total <= 0 || solicitud.Venta.Detalles.Count == 0)
                throw new InvalidOperationException("El comprobante electrónico no tiene detalle.");
        }

        private static string ConstruirXml(CpeSolicitud s)
        {
            XNamespace inv = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
            XNamespace cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            XNamespace cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            string codigoTipo = s.TipoComprobante.Equals(
                "Factura", StringComparison.OrdinalIgnoreCase) ? "01" : "03";

            XElement raiz = new XElement(inv + "Invoice",
                new XAttribute(XNamespace.Xmlns + "cbc", cbc),
                new XAttribute(XNamespace.Xmlns + "cac", cac),
                new XElement(cbc + "UBLVersionID", "2.1"),
                new XElement(cbc + "CustomizationID", "2.0-SIMULACION"),
                new XElement(cbc + "ID", s.IdDocumento),
                new XElement(cbc + "IssueDate",
                    s.FechaEmision.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                new XElement(cbc + "InvoiceTypeCode", codigoTipo),
                new XElement(cbc + "DocumentCurrencyCode", s.CodigoMoneda),
                new XElement(cac + "AccountingSupplierParty",
                    new XElement(cac + "Party",
                        new XElement(cac + "PartyIdentification",
                            new XElement(cbc + "ID", RucPrueba)),
                        new XElement(cac + "PartyLegalEntity",
                            new XElement(cbc + "RegistrationName",
                                "EMPRESA DE PRUEBA - SIN VALIDEZ TRIBUTARIA")))),
                new XElement(cac + "AccountingCustomerParty",
                    new XElement(cac + "Party",
                        new XElement(cac + "PartyIdentification",
                            new XElement(cbc + "ID",
                                string.IsNullOrWhiteSpace(s.DocumentoCliente)
                                    ? "0" : s.DocumentoCliente)),
                        new XElement(cac + "PartyLegalEntity",
                            new XElement(cbc + "RegistrationName",
                                s.NombreCliente ?? "CLIENTE")))),
                new XElement(cac + "TaxTotal",
                    new XElement(cbc + "TaxAmount",
                        new XAttribute("currencyID", s.CodigoMoneda),
                        Formato(s.Igv))),
                new XElement(cac + "LegalMonetaryTotal",
                    new XElement(cbc + "LineExtensionAmount",
                        new XAttribute("currencyID", s.CodigoMoneda),
                        Formato(s.SubTotal)),
                    new XElement(cbc + "PayableAmount",
                        new XAttribute("currencyID", s.CodigoMoneda),
                        Formato(s.Total))));

            decimal factorMoneda = s.Venta.TotalSoles > 0
                ? s.Total / s.Venta.TotalSoles
                : 1m;
            int linea = 1;
            foreach (Detalle_Pedido detalle in s.Venta.Detalles)
            {
                decimal precio = Math.Round(
                    Convert.ToDecimal(detalle.Precio) * factorMoneda, 2);
                decimal importe = Math.Round(
                    Convert.ToDecimal(detalle.Importe) * factorMoneda, 2);
                raiz.Add(new XElement(cac + "InvoiceLine",
                    new XElement(cbc + "ID", linea++),
                    new XElement(cbc + "InvoicedQuantity",
                        new XAttribute("unitCode", "NIU"),
                        Formato(Convert.ToDecimal(detalle.Cantidad))),
                    new XElement(cbc + "LineExtensionAmount",
                        new XAttribute("currencyID", s.CodigoMoneda),
                        Formato(importe)),
                    new XElement(cac + "Item",
                        new XElement(cbc + "Description", detalle.Id_Pro)),
                    new XElement(cac + "Price",
                        new XElement(cbc + "PriceAmount",
                            new XAttribute("currencyID", s.CodigoMoneda),
                            Formato(precio)))));
            }

            return new XDocument(new XDeclaration("1.0", "UTF-8", null), raiz)
                .ToString(SaveOptions.DisableFormatting);
        }

        private static string CalcularHash(string xml)
        {
            using (SHA256 sha = SHA256.Create())
                return Convert.ToBase64String(
                    sha.ComputeHash(Encoding.UTF8.GetBytes(xml)));
        }

        private static string Formato(decimal valor)
        {
            return valor.ToString("0.00", CultureInfo.InvariantCulture);
        }
    }
}
