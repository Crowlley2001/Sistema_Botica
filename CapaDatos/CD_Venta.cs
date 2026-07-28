using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Venta : Conexion
    {
        public void RegistrarVentaCompleta(
            VentaCompleta venta,
            out string idPedido,
            out string idDocumento)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            DataTable detalles = CrearTablaDetalles(venta);

            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand("Sp_Registrar_Venta_Completa", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;

                cmd.Parameters.Add("@Id_Cliente", SqlDbType.Char, 10).Value = venta.IdCliente;
                cmd.Parameters.Add("@Id_TipoDocumento", SqlDbType.Int).Value = venta.IdTipoDocumento;
                cmd.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = venta.FechaEmision;
                AgregarDecimal(cmd, "@SubTotal", venta.SubTotal, 18, 2);
                AgregarDecimal(cmd, "@Igv", venta.Igv, 18, 2);
                AgregarDecimal(cmd, "@TotalSoles", venta.TotalSoles, 18, 2);
                cmd.Parameters.Add("@TipoPago", SqlDbType.VarChar, 50).Value = venta.TipoPago;
                cmd.Parameters.Add("@NroOperacion", SqlDbType.NChar, 20).Value =
                    (object)venta.NroOperacion ?? DBNull.Value;
                cmd.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = venta.IdUsuario;
                AgregarDecimal(cmd, "@TotalGanancia", venta.TotalGanancia, 18, 2);
                AgregarDecimal(cmd, "@TotalDescuento", venta.TotalDescuento, 18, 2);
                cmd.Parameters.Add("@CodigoMoneda", SqlDbType.Char, 3).Value = venta.CodigoMoneda;
                AgregarDecimal(cmd, "@TipoCambio", venta.TipoCambio, 18, 6);
                AgregarDecimal(cmd, "@ImporteMoneda", venta.ImporteMoneda, 18, 2);

                SqlParameter parametroDetalles = cmd.Parameters.AddWithValue("@Detalles", detalles);
                parametroDetalles.SqlDbType = SqlDbType.Structured;
                parametroDetalles.TypeName = "dbo.VentaDetalleType";

                SqlParameter pedidoSalida =
                    cmd.Parameters.Add("@Id_PedidoGenerado", SqlDbType.VarChar, 11);
                pedidoSalida.Direction = ParameterDirection.Output;

                SqlParameter documentoSalida =
                    cmd.Parameters.Add("@Id_DocumentoGenerado", SqlDbType.VarChar, 11);
                documentoSalida.Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                idPedido = Convert.ToString(pedidoSalida.Value).Trim();
                idDocumento = Convert.ToString(documentoSalida.Value).Trim();
            }
        }

        private static DataTable CrearTablaDetalles(VentaCompleta venta)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id_Pro", typeof(string));
            tabla.Columns.Add("Precio", typeof(decimal));
            tabla.Columns.Add("Cantidad", typeof(decimal));
            tabla.Columns.Add("Importe", typeof(decimal));
            tabla.Columns.Add("Utilidad_Unit", typeof(decimal));
            tabla.Columns.Add("TotalUtilidad", typeof(decimal));
            tabla.Columns.Add("DescuentoDet", typeof(decimal));

            foreach (Detalle_Pedido detalle in venta.Detalles)
            {
                tabla.Rows.Add(
                    detalle.Id_Pro,
                    Convert.ToDecimal(detalle.Precio),
                    Convert.ToDecimal(detalle.Cantidad),
                    Convert.ToDecimal(detalle.Importe),
                    Convert.ToDecimal(detalle.Utilidad_Unit),
                    Convert.ToDecimal(detalle.TotalUtilidad),
                    Convert.ToDecimal(detalle.DescuentoDet));
            }

            return tabla;
        }

        private static void AgregarDecimal(
            SqlCommand cmd,
            string nombre,
            decimal valor,
            byte precision,
            byte escala)
        {
            SqlParameter parametro = cmd.Parameters.Add(nombre, SqlDbType.Decimal);
            parametro.Precision = precision;
            parametro.Scale = escala;
            parametro.Value = valor;
        }
    }
}
