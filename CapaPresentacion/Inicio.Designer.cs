namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.Menuusuario = new FontAwesome.Sharp.IconMenuItem();
            this.Menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.Menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.Menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.Menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.Menuproveedor = new FontAwesome.Sharp.IconMenuItem();
            this.Menureporte = new FontAwesome.Sharp.IconMenuItem();
            this.Menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menuusuario,
            this.Menumantenedor,
            this.Menuventas,
            this.Menucompras,
            this.Menuclientes,
            this.Menuproveedor,
            this.Menureporte,
            this.Menuacercade});
            this.menu.Location = new System.Drawing.Point(0, 60);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1000, 57);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // Menuusuario
            // 
            this.Menuusuario.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.Menuusuario.IconColor = System.Drawing.Color.Black;
            this.Menuusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuusuario.IconSize = 50;
            this.Menuusuario.Name = "Menuusuario";
            this.Menuusuario.Size = new System.Drawing.Size(92, 53);
            this.Menuusuario.Text = "Usuiario";
            this.Menuusuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menumantenedor
            // 
            this.Menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.Menumantenedor.IconColor = System.Drawing.Color.Black;
            this.Menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menumantenedor.IconSize = 50;
            this.Menumantenedor.Name = "Menumantenedor";
            this.Menumantenedor.Size = new System.Drawing.Size(125, 53);
            this.Menumantenedor.Text = "Mantenedor";
            this.Menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menuventas
            // 
            this.Menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.Menuventas.IconColor = System.Drawing.Color.Black;
            this.Menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuventas.IconSize = 50;
            this.Menuventas.Name = "Menuventas";
            this.Menuventas.Size = new System.Drawing.Size(80, 53);
            this.Menuventas.Text = "Ventas";
            this.Menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menucompras
            // 
            this.Menucompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.Menucompras.IconColor = System.Drawing.Color.Black;
            this.Menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menucompras.IconSize = 50;
            this.Menucompras.Name = "Menucompras";
            this.Menucompras.Size = new System.Drawing.Size(100, 53);
            this.Menucompras.Text = "Compras";
            this.Menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menuclientes
            // 
            this.Menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.Menuclientes.IconColor = System.Drawing.Color.Black;
            this.Menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuclientes.IconSize = 50;
            this.Menuclientes.Name = "Menuclientes";
            this.Menuclientes.Size = new System.Drawing.Size(89, 53);
            this.Menuclientes.Text = "Clientes";
            this.Menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menuproveedor
            // 
            this.Menuproveedor.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.Menuproveedor.IconColor = System.Drawing.Color.Black;
            this.Menuproveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuproveedor.IconSize = 50;
            this.Menuproveedor.Name = "Menuproveedor";
            this.Menuproveedor.Size = new System.Drawing.Size(110, 53);
            this.Menuproveedor.Text = "Proveedor";
            this.Menuproveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menureporte
            // 
            this.Menureporte.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.Menureporte.IconColor = System.Drawing.Color.Black;
            this.Menureporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menureporte.IconSize = 50;
            this.Menureporte.Name = "Menureporte";
            this.Menureporte.Size = new System.Drawing.Size(90, 53);
            this.Menureporte.Text = "Reporte";
            this.Menureporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Menuacercade
            // 
            this.Menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.Menuacercade.IconColor = System.Drawing.Color.Black;
            this.Menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuacercade.IconSize = 50;
            this.Menuacercade.Name = "Menuacercade";
            this.Menuacercade.Size = new System.Drawing.Size(110, 53);
            this.Menuacercade.Text = "Acerca de ";
            this.Menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menutitulo.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menutitulo.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1000, 60);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menutitulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de ventas ";
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 117);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1000, 337);
            this.Contenedor.TabIndex = 3;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 454);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.Text = "Form1";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private FontAwesome.Sharp.IconMenuItem Menuusuario;
        private FontAwesome.Sharp.IconMenuItem Menumantenedor;
        private FontAwesome.Sharp.IconMenuItem Menuventas;
        private FontAwesome.Sharp.IconMenuItem Menucompras;
        private FontAwesome.Sharp.IconMenuItem Menuclientes;
        private FontAwesome.Sharp.IconMenuItem Menuproveedor;
        private FontAwesome.Sharp.IconMenuItem Menureporte;
        private FontAwesome.Sharp.IconMenuItem Menuacercade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Contenedor;
    }
}

