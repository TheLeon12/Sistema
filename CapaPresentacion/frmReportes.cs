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

namespace CapaPresentacion
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            List<Proveedor> lista = new CN_Proveedor().Listar();

            cbobusquedaproveedor.Items.Add(new ObcionCombo() { Valor = 0, Texto = "Todos" });
            foreach(Proveedor item in lista)
            {
                cbobusquedaproveedor.Items.Add(new ObcionCombo() { Valor = item.IdProveedor, Texto = item.RazonSocial });
            }
            cbobusquedaproveedor.SelectedIndex = 0;
            cbobusquedaproveedor.DisplayMember = "Texto";
            cbobusquedaproveedor.ValueMember = "Valor";

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
               cbobusqueda.Items.Add(new ObcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbobusqueda.SelectedIndex = 0;
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            int idproveedor = Convert.ToInt32(((ObcionCombo)cbobusquedaproveedor.SelectedItem).Valor);

            List<ReporteCompra> Lista = new CN_Reporte().Compra(
                dtpfechainicio.Value.Date,
                dtpfechafin.Value.Date,
                idproveedor
            );

            dgvdata.Rows.Clear();

            foreach (ReporteCompra item in Lista)
            {
                dgvdata.Rows.Add(new object[]
                {
            item.FechaRegistro,
            item.TipoDocumento,
            item.NumeroDocumento,
            item.MontoTotal,
            item.UsuarioRegistro,
            item.DocumentoProveedor,
            item.RazonSocial,
            item.CodigoProducto,
            item.NombreProducto,
            item.Categoria,
            item.PrecioCompra,
            item.PrecioVenta,
            item.Cantidad,
            item.Subtotal
                });
            }

            if (Lista.Count == 0)
            {
                MessageBox.Show("No se encontraron registros para los filtros seleccionados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define los índices y nombres de las columnas a exportar (ajusta según tu estructura de reporte)
            int[] indices = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            string[] nombresColumnas = {
                "Fecha Registro", "Tipo Documento", "Número Documento", "Monto Total", "Usuario Registro",
                "Documento Proveedor", "Razón Social", "Código Producto", "Nombre Producto", "Categoría",
                "Precio Compra", "Precio Venta", "Cantidad", "Subtotal"
            };

            DataTable dt = new DataTable();
            foreach (var nombre in nombresColumnas)
            {
                dt.Columns.Add(nombre, typeof(string));
            }

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Visible && !row.IsNewRow)
                {
                    object[] valores = indices.Select(i => row.Cells[i].Value?.ToString() ?? "").ToArray();
                    dt.Rows.Add(valores);
                }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Compras");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(savefile.FileName);
                    MessageBox.Show("Archivo exportado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtbuscar2_Click(object sender, EventArgs e)
        {
            // configuracion para filtrar los usuarios 
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
