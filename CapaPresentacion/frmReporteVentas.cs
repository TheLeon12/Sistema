using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
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
            List<ReporteVenta> lista = new CN_Reporte().Ventas(
                dtpfechainicio.Value.ToString("yyyy-MM-dd"),
                dtpfechafin.Value.ToString("yyyy-MM-dd")
            );

            dgvdata.Rows.Clear();

            foreach (ReporteVenta item in lista)
            {
                dgvdata.Rows.Add(new object[]
                {
                    item.FechaRegistro,
                    item.TipoDocumento,
                    item.NumeroDocumento,
                    item.MontoTotal,
                    item.UsuarioRegistrado,
                    item.DocumentoCliente,
                    item.NombreClientes,
                    item.CodigoProducto,
                    item.NombreProducto,
                    item.Categoria,
                    item.PrecioVenta,
                    item.Cantidad,
                    item.Subtotal
                });
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

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Índices y nombres de las columnas a exportar (ajusta según tu estructura de ventas)
            int[] indices = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            string[] nombresColumnas = {
              "Fecha Registro", "Tipo Documento", "Número Documento", "Monto Total", "Usuario Registrado",
               "Documento Cliente", "Nombre Cliente", "Código Producto", "Nombre Producto", "Categoría",
                 "Precio Venta", "Cantidad", "Subtotal"
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
            savefile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Ventas");
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
    }
}
