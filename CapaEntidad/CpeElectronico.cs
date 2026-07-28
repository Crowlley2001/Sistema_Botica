using System;

namespace CapaEntidad
{
    public sealed class CpeSolicitud
    {
        public string IdDocumento { get; set; }
        public string TipoComprobante { get; set; }
        public DateTime FechaEmision { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoMoneda { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public VentaCompleta Venta { get; set; }
    }

    public sealed class CpeResultado
    {
        public string Ambiente { get; set; }
        public string Estado { get; set; }
        public string CodigoRespuesta { get; set; }
        public string Mensaje { get; set; }
        public string Hash { get; set; }
        public string XmlGenerado { get; set; }
        public string CdrContenido { get; set; }
        public DateTime FechaProceso { get; set; }
    }
}
