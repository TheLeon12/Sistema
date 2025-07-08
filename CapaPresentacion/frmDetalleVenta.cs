using CapaEntidades;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                foreach(DetalleVenta dv in oventa.oDetalleVenta)
                {
                    dgvdata.Rows.Add(new object[] { dv.oProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.Subtotal });
                }

                txtmontototal.Text = oventa.MontoTotal.ToString("0.00");
                txtmontopago.Text = oventa.MontoPago.ToString("0.00");
                txtmontocambio.Text = oventa.MontoCambio.ToString("0.00");
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbuscar.Text = string.Empty;
            txtfecha.Text = string.Empty;
            txtidcliente.Text = string.Empty;
            txttipodocumento.Text = string.Empty;
            txtusuario.Text = string.Empty;
            txtdoccliente.Text = string.Empty;
            txtnombrecliente.Text = string.Empty;
            txtmontototal.Text = string.Empty;
            txtmontopago.Text = string.Empty;
            txtmontocambio.Text = string.Empty;
            dgvdata.Rows.Clear();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontro resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtmontopago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtmontocambio.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtidcliente.Text);
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
                    MessageBox.Show("El archivo PDF se ha generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
