namespace PracticaTopicos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lstLista = new ListBox();
            menuStrip1 = new MenuStrip();
            salirToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(197, 46);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(410, 43);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Contactos";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 128);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(230, 27);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 105);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(12, 199);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(230, 27);
            txtTelefono.TabIndex = 3;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(12, 176);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(187, 20);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Numero de Telefono o Cel.";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(12, 269);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(230, 27);
            txtCorreo.TabIndex = 5;
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(12, 246);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(132, 20);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "Correo Electrónico";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 322);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(12, 366);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(12, 409);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lstLista
            // 
            lstLista.FormattingEnabled = true;
            lstLista.HorizontalScrollbar = true;
            lstLista.Location = new Point(329, 132);
            lstLista.Name = "lstLista";
            lstLista.ScrollAlwaysVisible = true;
            lstLista.Size = new Size(459, 304);
            lstLista.TabIndex = 10;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { salirToolStripMenuItem, acercaDeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(52, 24);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(89, 24);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstLista);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(lblCorreo);
            Controls.Add(txtCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblTitulo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Gestión de Contactos";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private ListBox lstLista;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}
