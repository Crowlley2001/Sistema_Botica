using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class VentaCompleta
    {
        public string IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal TotalSoles { get; set; }
        public string TipoPago { get; set; }
        public string NroOperacion { get; set; }
        public int IdUsuario { get; set; }
        public decimal TotalGanancia { get; set; }
        public decimal TotalDescuento { get; set; }
        public string CodigoMoneda { get; set; } = "PEN";
        public decimal TipoCambio { get; set; } = 1m;
        public decimal ImporteMoneda { get; set; }
        public List<Detalle_Pedido> Detalles { get; set; } = new List<Detalle_Pedido>();
    }
}
