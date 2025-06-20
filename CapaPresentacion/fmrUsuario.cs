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


        }

        private void btnguargar_Click(object sender, EventArgs e)
        {

        }

        private void btneditar_Click(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
