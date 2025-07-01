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
using CapaNegocio;
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
            //Configuracion para que se muestren los botones mediante el rol y los permisos del usuario actual
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconMenu.Name);

                if (encontrado == false)
                {
                    iconMenu.Visible = false;
                }
            
            }

            Lblusuario.Text = usuarioActual.NombreCompleto;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            // Codigo para abrir el formulario y cambiar el color del menu seleccionado
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
            // Codigo para abrir el formulario de usuario y cambiar el color del menu seleccionado
            AbrirFormulario((IconMenuItem)sender, new fmrUsuario());
        }

        private void Submenucategoria_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de categoria y cambiar el color del menu seleccionado
            AbrirFormulario(Menumantenedor, new frmCategoria());
        }

        private void Submenuproducto_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de producto y cambiar el color del menu seleccionado
            AbrirFormulario(Menumantenedor, new frmProducto());
        }

        private void Submenuregistrarventa_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de ventas y cambiar el color del menu seleccionado
            AbrirFormulario(Menuventas, new frmVentas());
        }

        private void Submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de detalle de ventas y cambiar el color del menu seleccionado
            AbrirFormulario(Menuventas, new frmDetalleVenta());
        }

        private void Submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de compras y cambiar el color del menu seleccionado
            AbrirFormulario(Menucompras, new frmCompras());
        }

        private void Submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de detalle de compras y cambiar el color del menu seleccionado
            AbrirFormulario(Menucompras, new frmDetalleCompra());
        }

        private void Menuclientes_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de clientes y cambiar el color del menu seleccionado
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void Menuproveedor_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de proveedores y cambiar el color del menu seleccionado
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void Menureporte_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de reportes y cambiar el color del menu seleccionado
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            // Codigo para abrir el formulario de Negocio y cambiar el color del menu seleccionado
            AbrirFormulario(Menumantenedor, new frmNegocio());
        }
    }
}
