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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            // configuracion de los estados en los combobox
            cboestado.Items.Add(new ObcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new ObcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0; // Selecciona el primer elemento por defecto

            //configuracion de la busqueda de categoria
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


            //Mostrar todaslas categorias
            List<Categoria> lista = new CN_Categoria().Listar();
            foreach (Categoria item in lista)
            {

                dgvdata.Rows.Add(new object[] { "",item.IdCategoria,
                    item.Descripcion,
                    item.Estado ? 1 : 0,
                    item.Estado ? "Activo" : "No Activo"
                });

            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            // Configuracio para eliminar una categoria
            if (Convert.ToInt32(txtindice.Text) != 0)
            {
                if (MessageBox.Show("¿Desas eliminar la categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Categoria obj = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Categoria().Eliminar(obj, out Mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
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
            Limpiar();
        }

        private void btnguargar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Categoria obj = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtid.Text),
                Descripcion = txtdescripcion.Text,
                Estado = Convert.ToInt32(((ObcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdCategoria == 0)
            {
                //Configuracion para el registro de una categoria 
                int idgenerado = new CN_Categoria().Registrar(obj, out Mensaje);

                if (idgenerado != 0)
                {
                    // Configuracion para que se manden y se muestre el texto en el datagridview
                    dgvdata.Rows.Add(new object[] { "",idgenerado, txtdescripcion.Text,
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
                bool resultado = new CN_Categoria().Editar(obj, out Mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
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
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = 0;

            txtdescripcion.Select();

        }

        private void cboestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtdocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnselecionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
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

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Índices y nombres de las columnas a exportar (ajusta si tu estructura cambia)
            int[] indices = { 1, 2, 4 }; // IdCategoria, Descripcion, Estado
            string[] nombresColumnas = { "ID", "Descripción", "Estado" };

            DataTable dt = new DataTable();
            foreach (var nombre in nombresColumnas)
            {
                dt.Columns.Add(nombre, typeof(string));
            }

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Visible)
                {
                    object[] valores = indices.Select(i => row.Cells[i].Value?.ToString() ?? "").ToArray();
                    dt.Rows.Add(valores);
                }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("ReporteCategorias_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Categorias");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(savefile.FileName);
                    MessageBox.Show("Archivo exportado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error al exportar el archivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
