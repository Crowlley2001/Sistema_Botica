using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_CompraCompleta : Conexion
    {
        public string Registrar(CompraCompleta compra)
        {
            if (compra == null)
                throw new ArgumentNullException(nameof(compra));

            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand("Sp_Registrar_Compra_Completa", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;

                cmd.Parameters.Add("@NroFacturaFisica", SqlDbType.Char, 20).Value =
                    compra.NroFacturaFisica.Trim();
                AgregarDecimal(cmd, "@SubTotalSoles", compra.SubTotalSoles, 18, 2);
                cmd.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = compra.FechaIngreso;
                AgregarDecimal(cmd, "@TotalSoles", compra.TotalSoles, 18, 2);
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = compra.IdUsuario;
                cmd.Parameters.Add("@ModalidadPago", SqlDbType.VarChar, 50).Value =
                    compra.ModalidadPago ?? String.Empty;
                cmd.Parameters.Add("@TiempoEspera", SqlDbType.Int).Value = compra.TiempoEspera;
                cmd.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value =
                    compra.FechaVencimiento.Date;
                cmd.Parameters.Add("@DatosAdicionales", SqlDbType.NVarChar, 150).Value =
                    compra.DatosAdicionales ?? String.Empty;
                cmd.Parameters.Add("@TipoDocumentoCompra", SqlDbType.VarChar, 12).Value =
                    compra.TipoDocumentoCompra ?? String.Empty;
                cmd.Parameters.Add("@TipoRegistro", SqlDbType.VarChar, 15).Value =
                    compra.TipoRegistro ?? String.Empty;
                cmd.Parameters.Add("@LugarSalida", SqlDbType.VarChar, 250).Value =
                    compra.LugarSalida ?? String.Empty;
                cmd.Parameters.Add("@TipoProceso", SqlDbType.VarChar, 15).Value =
                    compra.TipoProceso ?? String.Empty;
                cmd.Parameters.Add("@CodigoMoneda", SqlDbType.Char, 3).Value =
                    compra.CodigoMoneda;
                AgregarDecimal(cmd, "@TipoCambio", compra.TipoCambio, 18, 6);
                AgregarDecimal(cmd, "@TotalMoneda", compra.TotalMoneda, 18, 2);

                SqlParameter detalles = cmd.Parameters.AddWithValue(
                    "@Detalles", CrearTablaDetalles(compra));
                detalles.SqlDbType = SqlDbType.Structured;
                detalles.TypeName = "dbo.CompraDetalleType";

                SqlParameter idSalida =
                    cmd.Parameters.Add("@IdCompraGenerado", SqlDbType.VarChar, 11);
                idSalida.Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToString(idSalida.Value).Trim();
            }
        }

        private static DataTable CrearTablaDetalles(CompraCompleta compra)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id_Pro", typeof(string));
            tabla.Columns.Add("PrecioCompraSoles", typeof(decimal));
            tabla.Columns.Add("Cantidad", typeof(decimal));
            tabla.Columns.Add("ImporteSoles", typeof(decimal));
            tabla.Columns.Add("PrecioVentaSoles", typeof(decimal));

            foreach (Detalle_DocumentoCompra detalle in compra.Detalles)
            {
                tabla.Rows.Add(
                    detalle.Id_Pro,
                    Convert.ToDecimal(detalle.PrecioUnit),
                    Convert.ToDecimal(detalle.Cantidad),
                    Convert.ToDecimal(detalle.Importe),
                    Convert.ToDecimal(detalle.Preventa));
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
