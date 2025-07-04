using CapaDato;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        private Usuario _usuario;
        public frmCompras(Usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            // Cargar los tipos de documento en el ComboBox
            cbotipodocumento.Items.Add(new ObcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new ObcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            // Configuración de la fecha 
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtidproveedor.Text = "0";
            txtidproducto.Text = "0";
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._proveedor.IdProveedor.ToString();
                    txtdocproveedor.Text = modal._proveedor.Documento;
                    txtnombreprovedor.Text = modal._proveedor.RazonSocial;
                }
                else
                {
                    txtdocproveedor.Select();
                }
            }
        }

        private void btnbuscar2_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProductos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproducto.Text = modal._producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._producto.Codigo;
                    txtproducto.Text = modal._producto.Nombre;
                    txtpreciocompra.Select();
                }
                else
                {
                    txtcodproducto.Select();
                }
            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    txtcodproducto.BackColor = System.Drawing.Color.Honeydew;
                    txtidproducto.Text = oProducto.IdProducto.ToString();
                    txtproducto.Text = oProducto.Nombre;
                    txtpreciocompra.Select();
                }
                else
                {
                    txtcodproducto.BackColor = System.Drawing.Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            //agregar un producto a la lista de compras
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existente = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debes selecionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtpreciocompra.Text, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Select();
                return;
            }

            if (!decimal.TryParse(txtprecioventa.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null && fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existente = true;
                    break;
                }
            }

            if (!producto_existente)
            {
                dgvdata.Rows.Add(new object[]
                {
                    txtidproducto.Text,
                    txtproducto.Text,
                    preciocompra.ToString("0.00"),
                    precioventa.ToString("0.00"),
                    txtcantidad.Value.ToString(),
                    (txtcantidad.Value * preciocompra).ToString("0.00")
                });
                calcularTotal();
                limpiarproducto();
                txtproducto.Select();
            }
        }

        private void limpiarproducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = string.Empty;
            txtcodproducto.BackColor = System.Drawing.Color.White;
            txtproducto.Text = string.Empty;
            txtpreciocompra.Text = "0.00";
            txtprecioventa.Text = "0.00";
            txtcantidad.Value = 1;

        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            txttotalapagar.Text = total.ToString("0.00");
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Este evento se usa para personalizar la celda de selección
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Tamaño reducido de la imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Centrar la imagen en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(
                    Properties.Resources.borrar,
                    new Rectangle(x, y, iconWidth, iconHeight)
                );
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvdata.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int icolum = e.ColumnIndex;

            if (iRow >= 0 && icolum > 0)
            {
                Proveedor Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Id"].Value),
                    Documento = dgvdata.Rows[iRow].Cells["Documento"].Value?.ToString() ?? string.Empty,
                    RazonSocial = dgvdata.Rows[iRow].Cells["RazonSocial"].Value?.ToString() ?? string.Empty
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpreciocompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true; // No permitir punto al inicio
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false; // Permitir teclas de control y punto
                    }
                    else
                    {
                        e.Handled = true; // No permitir otros caracteres
                    }
                }
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecioventa.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true; // No permitir punto al inicio
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false; // Permitir teclas de control y punto
                    }
                    else
                    {
                        e.Handled = true; // No permitir otros caracteres
                    }
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidproveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnbuscar.Select();
                return;
            }

            // Validación opcional: verificar que el proveedor exista
            if (new CN_Proveedor().Listar().All(p => p.IdProveedor != Convert.ToInt32(txtidproveedor.Text)))
            {
                MessageBox.Show("El proveedor seleccionado no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos un producto a la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnbuscar2.Select();
                return;
            }

            DataTable Detalle_Compra = new DataTable();
            Detalle_Compra.Columns.Add("IdProducto", typeof(int));
            Detalle_Compra.Columns.Add("PrecioCompra", typeof(decimal));
            Detalle_Compra.Columns.Add("PrecioVenta", typeof(decimal));
            Detalle_Compra.Columns.Add("Cantidad", typeof(int));
            Detalle_Compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                Detalle_Compra.Rows.Add(
                    new object[]
                    {
                Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                Convert.ToDecimal(row.Cells["PrecioCompra"].Value.ToString()),
                Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString()),
                Convert.ToInt32(row.Cells["Cantidad"].Value.ToString()),
                Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString())
                    });
            }

            int idcorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtidproveedor.Text) },
                TipoDocumento = ((ObcionCombo)cbotipodocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txttotalapagar.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, Detalle_Compra, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Número de compra generada: \n" + numerodocumento + "\n\n¿Deseas copiarlo al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Clipboard.SetText(numerodocumento);

                // Limpiar campos
                txtidproveedor.Text = "0";
                txtdocproveedor.Text = string.Empty;
                txtnombreprovedor.Text = string.Empty;
                txtidproveedor.BackColor = System.Drawing.Color.White;
                dgvdata.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
