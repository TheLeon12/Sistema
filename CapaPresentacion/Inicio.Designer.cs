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
            this.Submenucategoria = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuproducto = new FontAwesome.Sharp.IconMenuItem();
            this.Menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuverdetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.Menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.Submenuverdetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.Menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.Menuproveedor = new FontAwesome.Sharp.IconMenuItem();
            this.Menureporte = new FontAwesome.Sharp.IconMenuItem();
            this.Menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Lblusuario = new System.Windows.Forms.Label();
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
            this.menu.Size = new System.Drawing.Size(1255, 57);
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
            this.Menuusuario.Size = new System.Drawing.Size(92, 55);
            this.Menuusuario.Text = "Usuiario";
            this.Menuusuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Menuusuario.Click += new System.EventHandler(this.Menuusuario_Click);
            // 
            // Menumantenedor
            // 
            this.Menumantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Submenucategoria,
            this.Submenuproducto});
            this.Menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.Menumantenedor.IconColor = System.Drawing.Color.Black;
            this.Menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menumantenedor.IconSize = 50;
            this.Menumantenedor.Name = "Menumantenedor";
            this.Menumantenedor.Size = new System.Drawing.Size(125, 55);
            this.Menumantenedor.Text = "Mantenedor";
            this.Menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Submenucategoria
            // 
            this.Submenucategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenucategoria.IconColor = System.Drawing.Color.Black;
            this.Submenucategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenucategoria.Name = "Submenucategoria";
            this.Submenucategoria.Size = new System.Drawing.Size(190, 34);
            this.Submenucategoria.Text = "Categoria";
            this.Submenucategoria.Click += new System.EventHandler(this.Submenucategoria_Click);
            // 
            // Submenuproducto
            // 
            this.Submenuproducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuproducto.IconColor = System.Drawing.Color.Black;
            this.Submenuproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuproducto.Name = "Submenuproducto";
            this.Submenuproducto.Size = new System.Drawing.Size(190, 34);
            this.Submenuproducto.Text = "Producto";
            this.Submenuproducto.Click += new System.EventHandler(this.Submenuproducto_Click);
            // 
            // Menuventas
            // 
            this.Menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Submenuregistrarventa,
            this.Submenuverdetalleventa});
            this.Menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.Menuventas.IconColor = System.Drawing.Color.Black;
            this.Menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuventas.IconSize = 50;
            this.Menuventas.Name = "Menuventas";
            this.Menuventas.Size = new System.Drawing.Size(80, 55);
            this.Menuventas.Text = "Ventas";
            this.Menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Submenuregistrarventa
            // 
            this.Submenuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuregistrarventa.IconColor = System.Drawing.Color.Black;
            this.Submenuregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuregistrarventa.Name = "Submenuregistrarventa";
            this.Submenuregistrarventa.Size = new System.Drawing.Size(198, 34);
            this.Submenuregistrarventa.Text = "Registrar";
            this.Submenuregistrarventa.Click += new System.EventHandler(this.Submenuregistrarventa_Click);
            // 
            // Submenuverdetalleventa
            // 
            this.Submenuverdetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuverdetalleventa.IconColor = System.Drawing.Color.Black;
            this.Submenuverdetalleventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuverdetalleventa.Name = "Submenuverdetalleventa";
            this.Submenuverdetalleventa.Size = new System.Drawing.Size(198, 34);
            this.Submenuverdetalleventa.Text = "Ver Detalle";
            this.Submenuverdetalleventa.Click += new System.EventHandler(this.Submenuverdetalleventa_Click);
            // 
            // Menucompras
            // 
            this.Menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Submenuregistrarcompra,
            this.Submenuverdetallecompra});
            this.Menucompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.Menucompras.IconColor = System.Drawing.Color.Black;
            this.Menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menucompras.IconSize = 50;
            this.Menucompras.Name = "Menucompras";
            this.Menucompras.Size = new System.Drawing.Size(100, 55);
            this.Menucompras.Text = "Compras";
            this.Menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Submenuregistrarcompra
            // 
            this.Submenuregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuregistrarcompra.IconColor = System.Drawing.Color.Black;
            this.Submenuregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuregistrarcompra.Name = "Submenuregistrarcompra";
            this.Submenuregistrarcompra.Size = new System.Drawing.Size(198, 34);
            this.Submenuregistrarcompra.Text = "Registrar";
            this.Submenuregistrarcompra.Click += new System.EventHandler(this.Submenuregistrarcompra_Click);
            // 
            // Submenuverdetallecompra
            // 
            this.Submenuverdetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Submenuverdetallecompra.IconColor = System.Drawing.Color.Black;
            this.Submenuverdetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Submenuverdetallecompra.Name = "Submenuverdetallecompra";
            this.Submenuverdetallecompra.Size = new System.Drawing.Size(198, 34);
            this.Submenuverdetallecompra.Text = "Ver Detalle";
            this.Submenuverdetallecompra.Click += new System.EventHandler(this.Submenuverdetallecompra_Click);
            // 
            // Menuclientes
            // 
            this.Menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.Menuclientes.IconColor = System.Drawing.Color.Black;
            this.Menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuclientes.IconSize = 50;
            this.Menuclientes.Name = "Menuclientes";
            this.Menuclientes.Size = new System.Drawing.Size(89, 55);
            this.Menuclientes.Text = "Clientes";
            this.Menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Menuclientes.Click += new System.EventHandler(this.Menuclientes_Click);
            // 
            // Menuproveedor
            // 
            this.Menuproveedor.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.Menuproveedor.IconColor = System.Drawing.Color.Black;
            this.Menuproveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuproveedor.IconSize = 50;
            this.Menuproveedor.Name = "Menuproveedor";
            this.Menuproveedor.Size = new System.Drawing.Size(110, 55);
            this.Menuproveedor.Text = "Proveedor";
            this.Menuproveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Menuproveedor.Click += new System.EventHandler(this.Menuproveedor_Click);
            // 
            // Menureporte
            // 
            this.Menureporte.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.Menureporte.IconColor = System.Drawing.Color.Black;
            this.Menureporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menureporte.IconSize = 50;
            this.Menureporte.Name = "Menureporte";
            this.Menureporte.Size = new System.Drawing.Size(90, 55);
            this.Menureporte.Text = "Reporte";
            this.Menureporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Menureporte.Click += new System.EventHandler(this.Menureporte_Click);
            // 
            // Menuacercade
            // 
            this.Menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.Menuacercade.IconColor = System.Drawing.Color.Black;
            this.Menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Menuacercade.IconSize = 50;
            this.Menuacercade.Name = "Menuacercade";
            this.Menuacercade.Size = new System.Drawing.Size(110, 55);
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
            this.menutitulo.Size = new System.Drawing.Size(1255, 60);
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
            this.Contenedor.Size = new System.Drawing.Size(1255, 736);
            this.Contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(803, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // Lblusuario
            // 
            this.Lblusuario.AutoSize = true;
            this.Lblusuario.BackColor = System.Drawing.Color.SteelBlue;
            this.Lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblusuario.ForeColor = System.Drawing.Color.White;
            this.Lblusuario.Location = new System.Drawing.Point(880, 21);
            this.Lblusuario.Name = "Lblusuario";
            this.Lblusuario.Size = new System.Drawing.Size(102, 25);
            this.Lblusuario.TabIndex = 0;
            this.Lblusuario.Text = "Lblusuario";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 853);
            this.Controls.Add(this.Lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lblusuario;
        private FontAwesome.Sharp.IconMenuItem Submenucategoria;
        private FontAwesome.Sharp.IconMenuItem Submenuproducto;
        private FontAwesome.Sharp.IconMenuItem Submenuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem Submenuverdetalleventa;
        private FontAwesome.Sharp.IconMenuItem Submenuregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem Submenuverdetallecompra;
    }
}

