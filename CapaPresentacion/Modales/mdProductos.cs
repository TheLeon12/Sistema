using CapaEntidades;
using CapaNegocio;
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

namespace CapaPresentacion.Modales
{
    public partial class mdProductos : Form
    {
        public Producto _producto { get; set; }
        public mdProductos()
        {
            InitializeComponent();
            dgvdata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvdata.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Elige el color que prefieras
            dgvdata.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void mdProductos_Load(object sender, EventArgs e)
        {
            // configuración de la búsqueda de producto 
            // configuración de la búsqueda de producto 
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {

                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new ObcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;


            //Mostrar todos los producto 
            List<Producto> lista = new CN_Producto().Listar();
            foreach (Producto item in lista)
            {
                dgvdata.Rows.Add();
                int rowIndex = dgvdata.Rows.Count - 1;
                dgvdata.Rows[rowIndex].Cells["Id"].Value = item.IdProducto;
                dgvdata.Rows[rowIndex].Cells["Codigo"].Value = item.Codigo;
                dgvdata.Rows[rowIndex].Cells["Nombre"].Value = item.Nombre;
                dgvdata.Rows[rowIndex].Cells["Categoria"].Value = item.oCategoria.Descripcion;
                dgvdata.Rows[rowIndex].Cells["Stock"].Value = item.Stock;
                dgvdata.Rows[rowIndex].Cells["PrecioCompra"].Value = item.PrecioCompra;
                dgvdata.Rows[rowIndex].Cells["PrecioVenta"].Value = item.PrecioVenta;
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int icolum = e.ColumnIndex;
            if (iRow >= 0 && icolum > 0)
            {
                _producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Id"].Value.ToString()),
                    Codigo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvdata.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(dgvdata.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvdata.Rows[iRow].Cells["PrecioVenta"].Value.ToString())
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // configuracion para filtrar los proveedores
            string ColumnaFiltro = ((ObcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[ColumnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            // Limpiar la busqueda
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
