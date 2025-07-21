using CapaEntidades;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace CapaPresentacion
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtbuscar.Select();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Venta oventa = new CN_Venta().ObtenerVenta(txtbuscar.Text);
            if (oventa.IdVenta != 0)
            {
                txtidcliente.Text = oventa.NumeroDocumento;
                txtfecha.Text = oventa.FechaRegistro;
                txttipodocumento.Text = oventa.TipoDocumento;
                txtusuario.Text = oventa.oUsuario.NombreCompleto;
                txtdoccliente.Text = oventa.DocumentoCliente;
                txtnombrecliente.Text = oventa.NombreCliente;

                dgvdata.Rows.Clear();
                foreach (DetalleVenta dv in oventa.oDetalleVenta)
                    dgvdata.Rows.Add(dv.oProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.Subtotal);

                txtmontototal.Text = oventa.MontoTotal.ToString("0.00");
                txtmontopago.Text = oventa.MontoPago.ToString("0.00");
                txtmontocambio.Text = oventa.MontoCambio.ToString("0.00");
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbuscar.Clear();
            txtfecha.Clear();
            txttipodocumento.Clear();
            txtusuario.Clear();
            txtdoccliente.Clear();
            txtnombrecliente.Clear();
            txtmontototal.Clear();
            txtmontopago.Clear();
            txtmontocambio.Clear();
            dgvdata.Rows.Clear();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttipodocumento.Text))
            {
                MessageBox.Show("No se encontró resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txttipodocumento.Text.Equals("Factura", StringComparison.OrdinalIgnoreCase))
            {
                PrintDocument pd = new PrintDocument();

                // Tamaño personalizado 60mm x 80mm
                PaperSize customSize = new PaperSize("Ticket", 240, 315);
                pd.DefaultPageSettings.PaperSize = customSize;
                pd.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);

                pd.PrintPage += PrintVentaTicket;
                pd.Print(); // Imprimir directamente
                return;
            }

            // Si no es factura, se genera PDF
            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);
            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtidcliente.Text);
            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            string filas = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += $"<tr><td>{row.Cells["Producto"].Value}</td><td>{row.Cells["Precio"].Value}</td><td>{row.Cells["Cantidad"].Value}</td><td>{row.Cells["SubTotal"].Value}</td></tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtmontopago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtmontocambio.Text);

            using (SaveFileDialog sfd = new SaveFileDialog { FileName = $"Venta_{txtidcliente.Text}.pdf", Filter = "pdf Files|*.pdf" })
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

        private void PrintVentaTicket(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            float y = 10f;

            // Logo del negocio
            bool obtenido = true;
            byte[] logoBytes = new CN_Negocio().ObtenerLogo(out obtenido);
            if (obtenido)
            {
                using (MemoryStream ms = new MemoryStream(logoBytes))
                {
                    System.Drawing.Image logo = System.Drawing.Image.FromStream(ms);
                    g.DrawImage(logo, new System.Drawing.Rectangle(50, (int)y, 180, 60));
                    y += 65;
                }
            }

            // Datos del negocio
            Negocio negocio = new CN_Negocio().ObtenerDatos();
            var font = new Font("Courier New", 9);
            var boldFont = new Font("Courier New", 10, FontStyle.Bold);

            g.DrawString(negocio.Nombre, boldFont, Brushes.Black, 10, y); y += 15;
            g.DrawString("RNC: " + negocio.RUC, font, Brushes.Black, 10, y); y += 15;
            g.DrawString(negocio.Direccion, font, Brushes.Black, 10, y); y += 15;
            g.DrawString("Tel: 809-870-8886", font, Brushes.Black, 10, y); y += 20;

            g.DrawString($"NCF: -", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"Fecha: {txtfecha.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"Hora: {DateTime.Now:hh:mm tt}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"No. Factura: {txtidcliente.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"Cliente: {txtnombrecliente.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"RNC/Cédula: {txtdoccliente.Text}", font, Brushes.Black, 10, y); y += 20;

            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 15;
            g.DrawString("CANT  PRECIO  ITBIS  TOTAL", font, Brushes.Black, 10, y); y += 15;
            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 15;

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                string cant = row.Cells["Cantidad"].Value.ToString();
                string precio = Convert.ToDecimal(row.Cells["Precio"].Value).ToString("0.00");
                string itbis = "$0.00"; // Ajusta si usas ITBIS real
                string total = Convert.ToDecimal(row.Cells["SubTotal"].Value).ToString("0.00");

                g.DrawString($"{cant.PadRight(5)} {precio.PadRight(7)} {itbis.PadRight(6)} {total.PadLeft(6)}", font, Brushes.Black, 10, y);
                y += 15;
            }

            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"SUBTOTAL:      {txtmontototal.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"TOTAL ITBIS:   $0.00", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"TOTAL:         {txtmontototal.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"PAGADO:        {txtmontopago.Text}", font, Brushes.Black, 10, y); y += 15;
            g.DrawString($"CAMBIO:        {txtmontocambio.Text}", font, Brushes.Black, 10, y); y += 20;

            g.DrawString("Pago en: Efectivo", font, Brushes.Black, 10, y); y += 20;

            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 15;
            g.DrawString("Gracias por su compra", font, Brushes.Black, 20, y); y += 20;
        }
    }
}
