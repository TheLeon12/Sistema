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
                    dgvdata.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }

                txtmontototal.Text = oCompra.MontoTotal.ToString("0.00");
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbuscar.Text = string.Empty;
            txtfecha.Text = string.Empty;
            txttipodocumento.Text = string.Empty;
            txtusuario.Text = string.Empty;
            txtdocproveedor.Text = string.Empty;
            txtnombreproveedor.Text = string.Empty;

            dgvdata.Rows.Clear();
            txtmontototal.Text = "0.00";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtnumerodocumento.Text == "")
            {
                MessageBox.Show("No se encontró el número de documento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txttipodocumento.Text == "Factura")
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintFacturaTicket;
                PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDoc
                };
                previewDialog.ShowDialog(); // Mostrar vista previa antes de imprimir (opcional)
                return;
            }

            // PDF GENERACIÓN (si no es factura)
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

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "pdf Files | *.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(byteImage);
                        imagen.ScaleToFit(60, 60);
                        imagen.Alignment = iTextSharp.text.Image.UNDERLYING;
                        imagen.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(imagen);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("El archivo PDF se ha generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir automáticamente el archivo PDF
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = savefile.FileName,
                    UseShellExecute = true
                });
            }
        }

        private void PrintFacturaTicket(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Courier New", 10);
            float y = 20;

            e.Graphics.DrawString("**** FACTURA ****", new Font("Courier New", 12, FontStyle.Bold), Brushes.Black, new PointF(10, y));
            y += 25;
            e.Graphics.DrawString($"Fecha: {txtfecha.Text}", font, Brushes.Black, 10, y); y += 20;
            e.Graphics.DrawString($"Documento: {txtnumerodocumento.Text}", font, Brushes.Black, 10, y); y += 20;
            e.Graphics.DrawString($"Proveedor: {txtnombreproveedor.Text}", font, Brushes.Black, 10, y); y += 20;

            e.Graphics.DrawString("--------------------------------", font, Brushes.Black, 10, y); y += 20;
            e.Graphics.DrawString("Producto        Cnt  SubTotal", font, Brushes.Black, 10, y); y += 20;
            e.Graphics.DrawString("--------------------------------", font, Brushes.Black, 10, y); y += 20;

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                string producto = row.Cells["Producto"].Value.ToString();
                string cantidad = row.Cells["Cantidad"].Value.ToString();
                string subtotal = row.Cells["SubTotal"].Value.ToString();
                e.Graphics.DrawString($"{producto,-15} {cantidad,3} {subtotal,8}", font, Brushes.Black, 10, y);
                y += 20;
            }

            e.Graphics.DrawString("--------------------------------", font, Brushes.Black, 10, y); y += 20;
            e.Graphics.DrawString($"TOTAL: {txtmontototal.Text}", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, 10, y);
        }
    }
}
