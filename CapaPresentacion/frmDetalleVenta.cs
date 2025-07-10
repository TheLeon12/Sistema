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
                pd.PrintPage += PrintVentaTicket;
                PrintPreviewDialog preview = new PrintPreviewDialog { Document = pd };
                preview.ShowDialog(); // O `pd.Print()` para imprimir directamente
                return;
            }

            // PDF
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
            var font = new Font("Courier New", 10);
            float y = 20f;
            g.DrawString("***** FACTURA *****", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, 10, y); y += 25;
            g.DrawString($"Fecha: {txtfecha.Text}", font, Brushes.Black, 10, y); y += 20;
            g.DrawString($"N° Documento: {txtidcliente.Text}", font, Brushes.Black, 10, y); y += 20;
            g.DrawString($"Cliente: {txtnombrecliente.Text}", font, Brushes.Black, 10, y); y += 20;
            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 20;
            g.DrawString("Producto       Cnt   Sub", font, Brushes.Black, 10, y); y += 20;
            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 20;

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                string prod = row.Cells["Producto"].Value.ToString();
                string cnt = row.Cells["Cantidad"].Value.ToString();
                string sub = row.Cells["SubTotal"].Value.ToString();
                g.DrawString($"{prod,-15} {cnt,3} {sub,8}", font, Brushes.Black, 10, y);
                y += 20;
            }

            g.DrawString(new string('-', 32), font, Brushes.Black, 10, y); y += 20;
            g.DrawString($"TOTAL: {txtmontototal.Text}", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, 10, y);
        }
    }
}
