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
            // Configuracion para que se manden y se muestre el texto en el datagridview
            dgvdata.Rows.Add(new object[] { "",txtid.Text, txtdocumento.Text, txtnombrecompleto.Text, txtcorreo.Text, txtclave.Text,
            ((ObcionCombo)cborol.SelectedItem).Valor.ToString(),
            ((ObcionCombo)cborol.SelectedItem).Texto.ToString(),
             ((ObcionCombo)cboestado.SelectedItem).Valor.ToString(),
            ((ObcionCombo)cboestado.SelectedItem).Texto.ToString()
            });

            Limpiar(); // Llamar al método para limpiar los campos después de agregar un nuevo usuario
        }

        private void Limpiar() 
        {
            // Limpiar los campos de texto y restablecer los combobox
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;

        }

        private void btneditar_Click(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
