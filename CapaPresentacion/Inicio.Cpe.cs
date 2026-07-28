using CapaPresentacion.Comprobantes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Inicio
    {
        private ToolStripMenuItem menuCentroCpe;

        private void InicializarMenuCpe()
        {
            if (menuCentroCpe != null)
                return;

            menuCentroCpe = new ToolStripMenuItem
            {
                Name = "menuCentroCpe",
                Text = "Centro de Facturación Electrónica (Prueba)",
                ForeColor = Color.FromArgb(40, 40, 40),
                Image = CrearIconoFacturacionElectronica(),
                ImageScaling = ToolStripItemImageScaling.None,
                Enabled = Bt_VentasTool.Enabled ||
                    string.Equals(
                        Cls_ModalCategoria.Nomerol,
                        "Administrador",
                        StringComparison.OrdinalIgnoreCase)
            };
            menuCentroCpe.Click += menuCentroCpe_Click;

            int indice = bt_venta_menu.DropDownItems.IndexOf(
                verComprobantesEmitidosToolStripMenuItem);
            if (indice < 0)
                bt_venta_menu.DropDownItems.Add(menuCentroCpe);
            else
            {
                bt_venta_menu.DropDownItems.Insert(indice + 1, new ToolStripSeparator());
                bt_venta_menu.DropDownItems.Insert(indice + 2, menuCentroCpe);
            }
        }

        private static Image CrearIconoFacturacionElectronica()
        {
            Bitmap icono = new Bitmap(24, 24);

            using (Graphics grafico = Graphics.FromImage(icono))
            using (Pen borde = new Pen(Color.FromArgb(125, 125, 125), 1.6f))
            using (Pen linea = new Pen(Color.FromArgb(150, 150, 150), 1.2f))
            using (SolidBrush sello = new SolidBrush(Color.FromArgb(78, 151, 191)))
            using (Pen visto = new Pen(Color.White, 1.5f))
            {
                grafico.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                grafico.Clear(Color.Transparent);

                PointF[] documento =
                {
                    new PointF(4.5f, 2.5f),
                    new PointF(14.5f, 2.5f),
                    new PointF(19.5f, 7.5f),
                    new PointF(19.5f, 21.5f),
                    new PointF(4.5f, 21.5f)
                };

                grafico.DrawPolygon(borde, documento);
                grafico.DrawLine(borde, 14.5f, 2.5f, 14.5f, 7.5f);
                grafico.DrawLine(borde, 14.5f, 7.5f, 19.5f, 7.5f);
                grafico.DrawLine(linea, 7.5f, 10.5f, 16.5f, 10.5f);
                grafico.DrawLine(linea, 7.5f, 13.5f, 14.5f, 13.5f);

                grafico.FillEllipse(sello, 13.5f, 14.5f, 9f, 9f);
                grafico.DrawLines(
                    visto,
                    new[]
                    {
                        new PointF(15.7f, 19f),
                        new PointF(17.4f, 20.5f),
                        new PointF(20.4f, 17.2f)
                    });
            }

            return icono;
        }

        private void menuCentroCpe_Click(object sender, EventArgs e)
        {
            using (frm_CentroCpe centro = new frm_CentroCpe())
                centro.ShowDialog(this);
        }
    }
}
