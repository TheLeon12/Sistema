namespace CapaPresentacion
{
    partial class frmCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbotipodocumento = new System.Windows.Forms.ComboBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtidproveedor = new System.Windows.Forms.TextBox();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.txtnombreprovedor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdocproveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtcantidad = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.TextBox();
            this.txtpreciocompra = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtproducto = new System.Windows.Forms.TextBox();
            this.btnbuscar2 = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtidproducto = new System.Windows.Forms.TextBox();
            this.txtcodproducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Idproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.txttotalapagar = new System.Windows.Forms.TextBox();
            this.btnregistrar = new FontAwesome.Sharp.IconButton();
            this.btnagregar = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(144, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1147, 643);
            this.label10.TabIndex = 22;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(628, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 36);
            this.label1.TabIndex = 23;
            this.label1.Text = "Registrar Compra";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbotipodocumento);
            this.groupBox1.Controls.Add(this.txtfecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(278, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 109);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion Compra ";
            // 
            // cbotipodocumento
            // 
            this.cbotipodocumento.FormattingEnabled = true;
            this.cbotipodocumento.Location = new System.Drawing.Point(194, 66);
            this.cbotipodocumento.Name = "cbotipodocumento";
            this.cbotipodocumento.Size = new System.Drawing.Size(206, 28);
            this.cbotipodocumento.TabIndex = 25;
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(11, 68);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(177, 26);
            this.txtfecha.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Fecha:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtidproveedor);
            this.groupBox2.Controls.Add(this.btnbuscar);
            this.groupBox2.Controls.Add(this.txtnombreprovedor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtdocproveedor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(725, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 109);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informacion Proveedor";
            // 
            // txtidproveedor
            // 
            this.txtidproveedor.Location = new System.Drawing.Point(427, 31);
            this.txtidproveedor.Name = "txtidproveedor";
            this.txtidproveedor.Size = new System.Drawing.Size(42, 26);
            this.txtidproveedor.TabIndex = 29;
            this.txtidproveedor.Visible = false;
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.White;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.Color.White;
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 30;
            this.btnbuscar.Location = new System.Drawing.Point(210, 66);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(55, 28);
            this.btnbuscar.TabIndex = 28;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // txtnombreprovedor
            // 
            this.txtnombreprovedor.Location = new System.Drawing.Point(271, 68);
            this.txtnombreprovedor.Name = "txtnombreprovedor";
            this.txtnombreprovedor.Size = new System.Drawing.Size(198, 26);
            this.txtnombreprovedor.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Razon Social";
            // 
            // txtdocproveedor
            // 
            this.txtdocproveedor.Location = new System.Drawing.Point(10, 68);
            this.txtdocproveedor.Name = "txtdocproveedor";
            this.txtdocproveedor.Size = new System.Drawing.Size(194, 26);
            this.txtdocproveedor.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Número Documento:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.txtcantidad);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtprecioventa);
            this.groupBox3.Controls.Add(this.txtpreciocompra);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtproducto);
            this.groupBox3.Controls.Add(this.btnbuscar2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtidproducto);
            this.groupBox3.Controls.Add(this.txtcodproducto);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(166, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1098, 100);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacion Producto";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(935, 55);
            this.txtcantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtcantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(114, 26);
            this.txtcantidad.TabIndex = 34;
            this.txtcantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(931, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 31;
            this.label11.Text = "Cantidad:";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.Location = new System.Drawing.Point(746, 58);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(147, 26);
            this.txtprecioventa.TabIndex = 33;
            this.txtprecioventa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecioventa_KeyPress);
            // 
            // txtpreciocompra
            // 
            this.txtpreciocompra.Location = new System.Drawing.Point(522, 56);
            this.txtpreciocompra.Name = "txtpreciocompra";
            this.txtpreciocompra.Size = new System.Drawing.Size(175, 26);
            this.txtpreciocompra.TabIndex = 32;
            this.txtpreciocompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpreciocompra_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(742, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Precio Venta:";
            // 
            // txtproducto
            // 
            this.txtproducto.Location = new System.Drawing.Point(255, 57);
            this.txtproducto.Name = "txtproducto";
            this.txtproducto.Size = new System.Drawing.Size(252, 26);
            this.txtproducto.TabIndex = 31;
            // 
            // btnbuscar2
            // 
            this.btnbuscar2.BackColor = System.Drawing.Color.White;
            this.btnbuscar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar2.ForeColor = System.Drawing.Color.White;
            this.btnbuscar2.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnbuscar2.IconColor = System.Drawing.Color.Black;
            this.btnbuscar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar2.IconSize = 30;
            this.btnbuscar2.Location = new System.Drawing.Point(194, 55);
            this.btnbuscar2.Name = "btnbuscar2";
            this.btnbuscar2.Size = new System.Drawing.Size(55, 28);
            this.btnbuscar2.TabIndex = 30;
            this.btnbuscar2.UseVisualStyleBackColor = false;
            this.btnbuscar2.Click += new System.EventHandler(this.btnbuscar2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(518, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = " Precio Compra:";
            // 
            // txtidproducto
            // 
            this.txtidproducto.Location = new System.Drawing.Point(168, 25);
            this.txtidproducto.Name = "txtidproducto";
            this.txtidproducto.Size = new System.Drawing.Size(42, 26);
            this.txtidproducto.TabIndex = 29;
            this.txtidproducto.Visible = false;
            // 
            // txtcodproducto
            // 
            this.txtcodproducto.Location = new System.Drawing.Point(11, 56);
            this.txtcodproducto.Name = "txtcodproducto";
            this.txtcodproducto.Size = new System.Drawing.Size(177, 26);
            this.txtcodproducto.TabIndex = 28;
            this.txtcodproducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodproducto_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Producto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Cod. Producto:";
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idproducto,
            this.Producto,
            this.PrecioCompra,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal,
            this.btneliminar});
            this.dgvdata.Location = new System.Drawing.Point(166, 359);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowHeadersWidth = 62;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(937, 296);
            this.dgvdata.TabIndex = 27;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // Idproducto
            // 
            this.Idproducto.HeaderText = "Idproducto";
            this.Idproducto.MinimumWidth = 8;
            this.Idproducto.Name = "Idproducto";
            this.Idproducto.Visible = false;
            this.Idproducto.Width = 150;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 8;
            this.Producto.Name = "Producto";
            this.Producto.Width = 300;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.MinimumWidth = 8;
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.Width = 150;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "PrecioVenta";
            this.PrecioVenta.MinimumWidth = 8;
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.Visible = false;
            this.PrecioVenta.Width = 150;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 8;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 150;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.MinimumWidth = 8;
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.Width = 150;
            // 
            // btneliminar
            // 
            this.btneliminar.HeaderText = "";
            this.btneliminar.MinimumWidth = 8;
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Width = 50;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1129, 535);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "Total a pagar ";
            // 
            // txttotalapagar
            // 
            this.txttotalapagar.Location = new System.Drawing.Point(1129, 568);
            this.txttotalapagar.Name = "txttotalapagar";
            this.txttotalapagar.Size = new System.Drawing.Size(124, 26);
            this.txttotalapagar.TabIndex = 30;
            this.txttotalapagar.Text = "0";
            // 
            // btnregistrar
            // 
            this.btnregistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnregistrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnregistrar.IconColor = System.Drawing.Color.Black;
            this.btnregistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnregistrar.Location = new System.Drawing.Point(1129, 609);
            this.btnregistrar.Name = "btnregistrar";
            this.btnregistrar.Size = new System.Drawing.Size(124, 46);
            this.btnregistrar.TabIndex = 31;
            this.btnregistrar.Text = "Registrar";
            this.btnregistrar.UseVisualStyleBackColor = true;
            this.btnregistrar.Click += new System.EventHandler(this.btnregistrar_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregar.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnagregar.IconColor = System.Drawing.Color.ForestGreen;
            this.btnagregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnagregar.IconSize = 50;
            this.btnagregar.Location = new System.Drawing.Point(1129, 359);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(124, 87);
            this.btnagregar.TabIndex = 28;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 704);
            this.Controls.Add(this.btnregistrar);
            this.Controls.Add(this.txttotalapagar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Name = "frmCompras";
            this.Text = "frmCompras";
            this.Load += new System.EventHandler(this.frmCompras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbotipodocumento;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtnombreprovedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdocproveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtidproveedor;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtproducto;
        private FontAwesome.Sharp.IconButton btnbuscar2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtidproducto;
        private System.Windows.Forms.TextBox txtcodproducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.TextBox txtpreciocompra;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminar;
        private FontAwesome.Sharp.IconButton btnagregar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txttotalapagar;
        private FontAwesome.Sharp.IconButton btnregistrar;
    }
}