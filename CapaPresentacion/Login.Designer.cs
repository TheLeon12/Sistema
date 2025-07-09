namespace CapaPresentacion
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.Textdocumento = new System.Windows.Forms.TextBox();
            this.Textclave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btningresar = new FontAwesome.Sharp.IconButton();
            this.Btncancelar = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 261);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sistema ventas";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 97;
            this.iconPictureBox1.Location = new System.Drawing.Point(30, 35);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(141, 97);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            // 
            // Textdocumento
            // 
            this.Textdocumento.Location = new System.Drawing.Point(246, 93);
            this.Textdocumento.Name = "Textdocumento";
            this.Textdocumento.Size = new System.Drawing.Size(229, 26);
            this.Textdocumento.TabIndex = 3;
            // 
            // Textclave
            // 
            this.Textclave.Location = new System.Drawing.Point(246, 163);
            this.Textclave.Name = "Textclave";
            this.Textclave.PasswordChar = '*';
            this.Textclave.Size = new System.Drawing.Size(229, 26);
            this.Textclave.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "No. Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña";
            // 
            // Btningresar
            // 
            this.Btningresar.BackColor = System.Drawing.Color.RoyalBlue;
            this.Btningresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btningresar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btningresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btningresar.ForeColor = System.Drawing.Color.White;
            this.Btningresar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Btningresar.IconColor = System.Drawing.Color.Black;
            this.Btningresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btningresar.Location = new System.Drawing.Point(246, 204);
            this.Btningresar.Name = "Btningresar";
            this.Btningresar.Size = new System.Drawing.Size(115, 38);
            this.Btningresar.TabIndex = 7;
            this.Btningresar.Text = "Ingresar";
            this.Btningresar.UseVisualStyleBackColor = false;
            this.Btningresar.Click += new System.EventHandler(this.Btningresar_Click);
            // 
            // Btncancelar
            // 
            this.Btncancelar.BackColor = System.Drawing.Color.Firebrick;
            this.Btncancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btncancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btncancelar.ForeColor = System.Drawing.Color.White;
            this.Btncancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Btncancelar.IconColor = System.Drawing.Color.Black;
            this.Btncancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btncancelar.Location = new System.Drawing.Point(367, 204);
            this.Btncancelar.Name = "Btncancelar";
            this.Btncancelar.Size = new System.Drawing.Size(108, 38);
            this.Btncancelar.TabIndex = 8;
            this.Btncancelar.Text = "Cancelar";
            this.Btncancelar.UseVisualStyleBackColor = false;
            this.Btncancelar.Click += new System.EventHandler(this.Btncancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(280, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "INICIAR SECION ";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btncancelar);
            this.Controls.Add(this.Btningresar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Textclave);
            this.Controls.Add(this.Textdocumento);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.TextBox Textdocumento;
        private System.Windows.Forms.TextBox Textclave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton Btningresar;
        private FontAwesome.Sharp.IconButton Btncancelar;
        private System.Windows.Forms.Label label5;
    }
}