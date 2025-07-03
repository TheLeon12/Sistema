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
    public partial class mdProveedor : Form
    {
        public Proveedor _proveedor { get; set; }
        public mdProveedor()
        {
            InitializeComponent();
            dgvdata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvdata.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Elige el color que prefieras
            dgvdata.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            // configuración de la búsqueda de proveedores
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                cbobusqueda.Items.Add(new ObcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // Mostrar todos los proveedores 
            List<Proveedor> lista = new CN_Proveedor().Listar();
            foreach (Proveedor item in lista)
            {
                dgvdata.Rows.Add();
                int rowIndex = dgvdata.Rows.Count - 1;
                dgvdata.Rows[rowIndex].Cells["Id"].Value = item.IdProveedor;
                dgvdata.Rows[rowIndex].Cells["Documento"].Value = item.Documento;
                dgvdata.Rows[rowIndex].Cells["RazonSocial"].Value = item.RazonSocial;
            }
            // Ocultar la columna Id, no eliminarla
            if (dgvdata.Columns.Contains("Id"))
                dgvdata.Columns["Id"].Visible = false;

        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int icolum = e.ColumnIndex;

            if (iRow >= 0 && icolum > 0)
            {
                _proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Id"].Value),
                    Documento = dgvdata.Rows[iRow].Cells["Documento"].Value?.ToString() ?? string.Empty,
                    RazonSocial = dgvdata.Rows[iRow].Cells["RazonSocial"].Value?.ToString() ?? string.Empty
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
