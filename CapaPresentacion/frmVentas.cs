using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
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
    public partial class frmVentas : Form
    {
        private Usuario _usuario;
        public frmVentas(Usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cbotipodocumento.Items.Add(new ObcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new ObcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";

            txtcambio.Text = "";
            txtpagarcon.Text = "";
            txttotalapagar.Text = "0";

            // Configurar columnas del DataGridView si no están en el diseñador
            if (dgvdata.Columns.Count == 0)
            {
                dgvdata.Columns.Add("IdProducto", "IdProducto");
                dgvdata.Columns.Add("Producto", "Producto");
                dgvdata.Columns.Add("Precio", "Precio");
                dgvdata.Columns.Add("Cantidad", "Cantidad");
                dgvdata.Columns.Add("SubTotal", "SubTotal");

                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "btneliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgvdata.Columns.Add(btnEliminar);
            }

            dgvdata.Columns["IdProducto"].Visible = false;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdClientes())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtdoccliente.Text = modal._cliente.Documento;
                    txtnombrecliente.Text = modal._cliente.NombreCompleto;
                    txtcodproducto.Select();
                }
                else
                {
                    txtdoccliente.Select();
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
                    txtprecio.Text = modal._producto.PrecioVenta.ToString("0.00");
                    txtstock.Text = modal._producto.Stock.ToString();
                    txtcantidad.Select();
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
                    txtprecio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtstock.Text = oProducto.Stock.ToString();
                    txtcantidad.Select();
                }
                else
                {
                    txtcodproducto.BackColor = System.Drawing.Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                    txtprecio.Text = "0.00";
                    txtstock.Text = "0";
                    txtcantidad.Text = "1";
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;

            if (!dgvdata.Columns.Contains("Precio"))
            {
                MessageBox.Show("La columna 'Precio' no existe en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtprecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(txtstock.Text) < Convert.ToInt32(txtcantidad.Value.ToString()))
            {
                MessageBox.Show("No hay suficiente stock del producto.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                decimal subtotal = precio * Convert.ToDecimal(txtcantidad.Value);

                int rowIndex = dgvdata.Rows.Add();
                DataGridViewRow row = dgvdata.Rows[rowIndex];

                row.Cells["IdProducto"].Value = txtidproducto.Text;
                row.Cells["Producto"].Value = txtproducto.Text;
                row.Cells["Precio"].Value = precio.ToString("0.00");
                row.Cells["Cantidad"].Value = txtcantidad.Value.ToString();
                row.Cells["SubTotal"].Value = subtotal.ToString("0.00");

                calcularTotal();
                limpiarProducto();
            }
        }

        private void calcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells["SubTotal"].Value != null)
                {
                    decimal subtotal;
                    if (decimal.TryParse(row.Cells["SubTotal"].Value.ToString(), out subtotal))
                    {
                        total += subtotal;
                    }
                }
            }

            txttotalapagar.Text = total.ToString("0.00");
        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "0.00";
            txtstock.Text = "0";
            txtcantidad.Value = 1;
            txtcodproducto.Select();
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

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtpagarcon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagarcon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void calcularcambio()
        {
            decimal total = 0;
            decimal pagacon = 0;

            // Validar total a pagar
            if (!decimal.TryParse(txttotalapagar.Text.Trim(), out total))
            {
                MessageBox.Show("Debe ingresar el total a pagar correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcambio.Text = "0.00";
                return;
            }

            // Si el campo está vacío, lo ponemos en 0 para evitar errores
            if (string.IsNullOrWhiteSpace(txtpagarcon.Text))
            {
                txtpagarcon.Text = "0";
            }

            // Validar el monto con el que se paga
            if (!decimal.TryParse(txtpagarcon.Text.Trim(), out pagacon))
            {
                MessageBox.Show("Monto con el que paga no es válido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcambio.Text = "0.00";
                return;
            }

            // Calcular cambio
            if (pagacon < total)
            {
                txtcambio.Text = "0.00";
            }
            else
            {
                decimal cambio = pagacon - total;
                txtcambio.Text = cambio.ToString("0.00");
            }
        }

        private void txtpagarcon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calcularcambio();
                e.Handled = true;
                e.SuppressKeyPress = true; // evita el sonido de Enter
            }
        }
    }
}
