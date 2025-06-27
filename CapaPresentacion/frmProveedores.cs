using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cboestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombrecompleto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Índices y nombres de las columnas a exportar según la estructura de proveedores
            int[] indices = { 1, 2, 3, 4, 5, 6, 7 }; // Id, Documento, RazonSocial, Correo, Telefono, EstadoValor, Estado
            string[] nombresColumnas = { "ID", "Documento", "Razón Social", "Correo", "Teléfono", "Estado Valor", "Estado" };

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
            savefile.FileName = string.Format("ReporteProveedores_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wb = new XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Proveedores");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(savefile.FileName);
                    MessageBox.Show("Archivo exportado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
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

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtindice.Text) != 0)
            {
                if (MessageBox.Show("¿Desas eliminar el Proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Proveedor obj = new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Proveedor().Eliminar(obj, out Mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar(); // Llamar al método para limpiar los campos después de eliminar un usuario
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(); // Llamar al método para limpiar los campos
        }

        private void btnguargar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Proveedor obj = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                RazonSocial = txtrazonsocial.Text,
                Correo = txtcorreo.Text,
                Telefono = txttelefono.Text,
                Estado = Convert.ToInt32(((ObcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdProveedor == 0)
            {
                //Configuracion para el registro de un usuario 
                int idgenerado = new CN_Proveedor().Registrar(obj, out Mensaje);

                if (idgenerado != 0)
                {
                    // Configuracion para que se manden y se muestre el texto en el datagridview
                    dgvdata.Rows.Add(new object[] { "",idgenerado, txtdocumento.Text, txtrazonsocial.Text, txtcorreo.Text, txttelefono.Text,

                    ((ObcionCombo)cboestado.SelectedItem).Valor.ToString(),
                    ((ObcionCombo)cboestado.SelectedItem).Texto.ToString()
                    });

                    Limpiar(); // Llamar al método para limpiar los campos después de agregar un nuevo usuario
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }

            }
            else
            {
                // Configuracion para editar un usuario
                bool resultado = new CN_Proveedor().Editar(obj, out Mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["RazonSocial"].Value = txtrazonsocial.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;
                    row.Cells["EstadoValor"].Value = ((ObcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((ObcionCombo)cboestado.SelectedItem).Texto.ToString();
                    Limpiar(); // Llamar al método para limpiar los campos después de agregar un nuevo usuario

                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
        }

        private void Limpiar()
        {
            // Limpiar los campos de texto y restablecer los combobox
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtrazonsocial.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cboestado.SelectedIndex = 0;
            txtindice.Text = "-1";
            txtdocumento.Select();
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnselecionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtrazonsocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (ObcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void txtindice_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            // configuracion de los roles y estados en los combobox
            cboestado.Items.Add(new ObcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new ObcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0; // Selecciona el primer elemento por defecto

            //configuracion de la busqueda de Clientes 
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {

                if (columna.Visible == true && columna.Name != "btnselecionar")
                {
                    cbobusqueda.Items.Add(new ObcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;


            //Mostrar todos los Clientes 
            List<Proveedor> lista = new CN_Proveedor().Listar();
            foreach (Proveedor item in lista)
            {

                dgvdata.Rows.Add(new object[] { "",item.IdProveedor, item.Documento, item.RazonSocial, item.Correo, item.Telefono,
                    item.Estado ? 1 : 0,
                    item.Estado ? "Activo" : "No Activo"
                });

            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Este evento se usa para personalizar la celda de selección
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                txtindice.Text = e.RowIndex.ToString();

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Ajustar la imagen al tamaño de la celda
                e.Graphics.DrawImage(
                    Properties.Resources.comprobado,
                    new Rectangle(
                        e.CellBounds.Left,
                        e.CellBounds.Top,
                        e.CellBounds.Width,
                        e.CellBounds.Height
                    )
                );
                e.Handled = true;
            }
        }
    }
}
