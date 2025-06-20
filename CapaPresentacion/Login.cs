using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            // Programacion para cerrar el formulario de login
            this.Close();
        }

        private void Btningresar_Click(object sender, EventArgs e)
        {
            // Validacion de los campos y el rol asignado al usuario
            List<Usuario> TEST = new CN_Usuario().Listar();
            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.Documento == Textdocumento.Text && u.Clave == Textclave.Text).FirstOrDefault();
            // Codigo del boton de inico para que muestre el siguiente formulario
            if (oUsuario != null)
            {
                Inicio form = new Inicio(oUsuario);

                form.Show();
                this.Hide();

                form.FormClosed += fmr_closing;
            }
            else {
                MessageBox.Show("No se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        private void fmr_closing(object sender, FormClosedEventArgs e)
        {
            // Codigo para limpiar los campos de texto del formulario de login
            Textdocumento.Text = "";
                Textclave.Text = "";

            this.Show();
        }
    }
}
