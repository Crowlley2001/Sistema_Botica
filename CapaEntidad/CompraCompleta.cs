using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class CompraCompleta
    {
        public string NroFacturaFisica { get; set; }
        public decimal SubTotalSoles { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal TotalSoles { get; set; }
        public int IdUsuario { get; set; }
        public string ModalidadPago { get; set; }
        public int TiempoEspera { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string DatosAdicionales { get; set; }
        public string TipoDocumentoCompra { get; set; }
        public string TipoRegistro { get; set; }
        public string LugarSalida { get; set; }
        public string TipoProceso { get; set; }
        public string CodigoMoneda { get; set; } = "PEN";
        public decimal TipoCambio { get; set; } = 1m;
        public decimal TotalMoneda { get; set; }
        public List<Detalle_DocumentoCompra> Detalles { get; set; } =
            new List<Detalle_DocumentoCompra>();
    }
}
