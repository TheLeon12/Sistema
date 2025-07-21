using CapaEntidades;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace CapaPresentacion
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtbuscar.Text);

            if (oCompra.IdCompra != 0)
            {
                txtnumerodocumento.Text = oCompra.NumeroDocumento;
                txtfecha.Text = oCompra.FechaRegistro;
                txttipodocumento.Text = oCompra.TipoDocumento;
                txtusuario.Text = oCompra.oUsuario.NombreCompleto;
                txtdocproveedor.Text = oCompra.oProveedor.Documento;
                txtnombreproveedor.Text = oCompra.oProveedor.RazonSocial;

                dgvdata.Rows.Clear();
                foreach (DetalleCompra dc in oCompra.oDetalleCompra)
                {
                    dgvdata.Rows.Add(dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal);
                }

                txtmontototal.Text = oCompra.MontoTotal.ToString("0.00");
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbuscar.Clear();
            txtfecha.Clear();
            txttipodocumento.Clear();
            txtusuario.Clear();
            txtdocproveedor.Clear();
            txtnombreproveedor.Clear();
            dgvdata.Rows.Clear();
            txtmontototal.Text = "0.00";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnumerodocumento.Text))
            {
                MessageBox.Show("No se encontró el número de documento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txttipodocumento.Text.Equals("Factura", StringComparison.OrdinalIgnoreCase))
            {
                PrintDocument printDoc = new PrintDocument();

                // Tamaño de ticket 60mm x 80mm en hundredths of an inch
                PaperSize ticketSize = new PaperSize("TicketCompra", 236, 315); // 60mm x 80mm aprox
                printDoc.DefaultPageSettings.PaperSize = ticketSize;
                printDoc.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);

                printDoc.PrintPage += PrintFacturaTicket;
                PrintPreviewDialog previewDialog = new PrintPreviewDialog { Document = printDoc };
                previewDialog.ShowDialog(); // O usa printDoc.Print(); para imprimir directamente
                return;
            }

            // PDF si no es factura
            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);
            Texto_Html = Texto_Html.Replace("@docproveedor", txtdocproveedor.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtnombreproveedor.Text);

            string filas = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += $"<tr><td>{row.Cells["Producto"].Value}</td><td>{row.Cells["PrecioCompra"].Value}</td><td>{row.Cells["Cantidad"].Value}</td><td>{row.Cells["SubTotal"].Value}</td></tr>";
            }

            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);

            using (SaveFileDialog sfd = new SaveFileDialog { FileName = $"Compra_{txtnumerodocumento.Text}.pdf", Filter = "pdf Files|*.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document pdf = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdf, stream);
                        pdf.Open();

                        bool ok = true;
                        byte[] logo = new CN_Negocio().ObtenerLogo(out ok);
                        if (ok)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(logo);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdf.Left, pdf.GetTop(51));
                            pdf.Add(img);
                        }

                        using (StringReader sr = new StringReader(Texto_Html))
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdf, sr);

                        pdf.Close();
                    }
                    MessageBox.Show("PDF generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                }
            }
        }

        private void PrintFacturaTicket(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            float y = 10f;

            // LOGO
            bool obtenido = true;
            byte[] logoBytes = new CN_Negocio().ObtenerLogo(out obtenido);
            if (obtenido)
            {
                using (MemoryStream ms = new MemoryStream(logoBytes))
                {
                    System.Drawing.Image logo = System.Drawing.Image.FromStream(ms);
                    g.DrawImage(logo, new System.Drawing.Rectangle(40, (int)y, 160, 60)); // Ajusta posición
                    y += 65;
                }
            }

            // DATOS NEGOCIO
            Negocio negocio = new CN_Negocio().ObtenerDatos();
            var font = new Font("Courier New", 9);
            var boldFont = new Font("Courier New", 10, FontStyle.Bold);

            g.DrawString(negocio.Nombre, boldFont, Brushes.Black, 10, y); y += 15;
            g.DrawString("RNC: " + negocio.RUC, font, Brushes.Black, 10, y); y += 15;
            g.DrawString(negocio.Direccion, font, Brushes.Black, 10, y); y += 15;
            g.DrawString("Tel: 809-000-0000", font, Brushes.Black, 10, y); y += 20;

            // ENCABEZADO
            g.DrawString("**** COMPRA ****", boldFont, Brushes.Black, 40, y); y += 20;
            g.DrawString($"Fecha: {txtfecha.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"Documento: {txtnumerodocumento.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"Proveedor: {txtnombreproveedor.Text}", font, Brushes.Black, 10, y); y += 20;

            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 15;
            g.DrawString("CANT  PRECIO   TOTAL", font, Brushes.Black, 10, y); y += 15;
            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 15;

            // DETALLES
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                string producto = row.Cells["Producto"].Value.ToString();
                string cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value).ToString("0");
                string precio = Convert.ToDecimal(row.Cells["PrecioCompra"].Value).ToString("0.00");
                string subtotal = Convert.ToDecimal(row.Cells["SubTotal"].Value).ToString("0.00");

                g.DrawString($"{producto}", font, Brushes.Black, 10, y); y += 15;
                g.DrawString($"  {cantidad.PadRight(4)} {precio.PadRight(8)} {subtotal.PadLeft(6)}", font, Brushes.Black, 10, y); y += 15;
            }

            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"TOTAL: {txtmontototal.Text}", boldFont, Brushes.Black, 10, y); y += 20;
            g.DrawString("Gracias por su compra", font, Brushes.Black, 20, y); y += 20;
        }

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
        }
    }
}
