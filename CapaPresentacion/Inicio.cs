using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidades;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        private static Usuario usuarioActual;
        private static IconMenuItem MenuActual = null;
        public static Form FormularioActivo = null;

        public Inicio(Usuario objusuario)
        {
            usuarioActual = objusuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            Lblusuario.Text = usuarioActual.NombreCompleto;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActual != null)
            {
                MenuActual.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActual = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            FormularioActivo.TopLevel = false;
            FormularioActivo.FormBorderStyle = FormBorderStyle.None;
            FormularioActivo.Dock = DockStyle.Fill;
            FormularioActivo.BackColor = Color.SteelBlue;

            Contenedor.Controls.Add(formulario);
            formulario.Show();



        }

        private void Menuusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new fmrUsuario());
        }

        private void Submenucategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Menumantenedor, new frmCategoria());
        }

        private void Submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Menumantenedor, new frmProducto());
        }

        private void Submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Menuventas, new frmVentas());
        }

        private void Submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Menuventas, new frmDetalleVenta());
        }

        private void Submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Menucompras, new frmCompras());
        }

        private void Submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Menucompras, new frmDetalleCompra());
        }

        private void Menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void Menuproveedor_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void Menureporte_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }
    }
}
