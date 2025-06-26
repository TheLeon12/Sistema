using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class fmrUsuario : Form
    {
        public fmrUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fmrUsuario_Load(object sender, EventArgs e)
        {
            // configuracion de los roles y estados en los combobox
            cboestado.Items.Add(new ObcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new ObcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0; // Selecciona el primer elemento por defecto

            List<Rol>listarol = new CN_Rol().Listar();
            foreach (Rol item in listarol) {
                cborol.Items.Add(new ObcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;

            //configuracion de la busqueda de usuarios 
            foreach (DataGridViewColumn columna in dgvdata.Columns) {

                if (columna.Visible == true && columna.Name != "btnselecionar") {
                cbobusqueda.Items.Add(new ObcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;


            //Mostrar todos los usuarios 
            List<Usuario> listausuario = new CN_Usuario().Listar();
            foreach (Usuario item in listausuario)
            {

                dgvdata.Rows.Add(new object[] { "",item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                    item.oRol.IdRol,
                    item.oRol.Descripcion,
                    item.Estado ? 1 : 0,
                    item.Estado ? "Activo" : "No Activo"
                });

            }
        }

        private void btnguargar_Click(object sender, EventArgs e)
        {

           string Mensaje = string.Empty;

            Usuario objusuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo = txtcorreo.Text,
                Clave = txtclave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((ObcionCombo)cborol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((ObcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (objusuario.IdUsuario == 0)
            {
                //Configuracion para el registro de un usuario 
                int idusuariogenerado = new CN_Usuario().Registrar(objusuario, out Mensaje);

                if (idusuariogenerado != 0)
                {
                    // Configuracion para que se manden y se muestre el texto en el datagridview
                    dgvdata.Rows.Add(new object[] { "",idusuariogenerado, txtdocumento.Text, txtnombrecompleto.Text, txtcorreo.Text, txtclave.Text,
                    ((ObcionCombo)cborol.SelectedItem).Valor.ToString(),
                    ((ObcionCombo)cborol.SelectedItem).Texto.ToString(),
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
                bool resultado = new CN_Usuario().Editar(objusuario, out Mensaje);
                if (resultado) 
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Clave"].Value = txtclave.Text;
                    row.Cells["IdRol"].Value = ((ObcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((ObcionCombo)cborol.SelectedItem).Texto.ToString();
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
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
            txtindice.Text = "-1";
            txtdocumento.Select();

        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            // Configuracio para eliminar un usuario
            if (Convert.ToInt32(txtindice.Text) != 0)
            {
                if (MessageBox.Show("¿Desas eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Usuario().Eliminar(objusuario, out Mensaje);

                    if (respuesta) 
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
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

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnselecionar") {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfirmarclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (ObcionCombo oc in cborol.Items) 
                    { 
                        if(Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value)){
                            int indice_combo = cborol.Items.IndexOf(oc);
                            cborol.SelectedIndex = indice_combo;
                            break;
                        }
                    }

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

                foreach(DataGridViewRow row in dgvdata.Rows)
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

            // Índices y nombres de las columnas a exportar (ajusta según tu estructura)
            int[] indices = { 2, 3, 4, 5, 7, 8, 9 }; // Documento, Nombre Completo, Correo, Clave, Rol, EstadoValor, Estado
            string[] nombresColumnas = { "Documento", "Nombre Completo", "Correo", "Clave", "Rol", "Estado Valor", "Estado" };

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
            savefile.FileName = string.Format("ReporteUsuarios_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Usuarios");
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
