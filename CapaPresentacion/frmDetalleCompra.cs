using CapaEntidades;
using CapaNegocio;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
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
                    dgvdata.Rows.Add(new object[] {dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal});
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
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontro resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);

            Texto_Html = Texto_Html.Replace("@docproveedor", txtdocproveedor.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtnombreproveedor.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

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
                    MessageBox.Show("El archivo PDF se ha generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
