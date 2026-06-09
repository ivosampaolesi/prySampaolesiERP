namespace prySampaolesiERP
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.stpEstado = new System.Windows.Forms.StatusStrip();
            this.stplblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnDatosPersonales = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlAviso = new System.Windows.Forms.Panel();
            this.lblCerrarAviso = new System.Windows.Forms.Label();
            this.lblAvisoTitulo = new System.Windows.Forms.Label();
            this.lblAvisoDetalle = new System.Windows.Forms.Label();
            this.stpEstado.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlAviso.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpEstado
            // 
            this.stpEstado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stpEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stplblEstado});
            this.stpEstado.Location = new System.Drawing.Point(0, 628);
            this.stpEstado.Name = "stpEstado";
            this.stpEstado.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.stpEstado.Size = new System.Drawing.Size(1179, 26);
            this.stpEstado.TabIndex = 0;
            this.stpEstado.Text = "statusStrip1";
            // 
            // stplblEstado
            // 
            this.stplblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stplblEstado.Name = "stplblEstado";
            this.stplblEstado.Size = new System.Drawing.Size(160, 20);
            this.stplblEstado.Text = "toolStripStatusLabel1";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.btnInicio);
            this.pnlSidebar.Controls.Add(this.btnDatosPersonales);
            this.pnlSidebar.Controls.Add(this.btnGestionUsuarios);
            this.pnlSidebar.Controls.Add(this.btnAuditoria);
            this.pnlSidebar.Controls.Add(this.btnSalir);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 628);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnInicio
            // 
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(-19, 14);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnInicio.Size = new System.Drawing.Size(220, 50);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "🏠  Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnDatosPersonales
            // 
            this.btnDatosPersonales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatosPersonales.FlatAppearance.BorderSize = 0;
            this.btnDatosPersonales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnDatosPersonales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnDatosPersonales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatosPersonales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatosPersonales.ForeColor = System.Drawing.Color.White;
            this.btnDatosPersonales.Location = new System.Drawing.Point(-19, 75);
            this.btnDatosPersonales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDatosPersonales.Name = "btnDatosPersonales";
            this.btnDatosPersonales.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDatosPersonales.Size = new System.Drawing.Size(248, 46);
            this.btnDatosPersonales.TabIndex = 1;
            this.btnDatosPersonales.Text = "👤  Datos Personales";
            this.btnDatosPersonales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatosPersonales.UseVisualStyleBackColor = true;
            this.btnDatosPersonales.Click += new System.EventHandler(this.btnDatosPersonales_Click);
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            this.btnGestionUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnGestionUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnGestionUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnGestionUsuarios.Location = new System.Drawing.Point(-19, 138);
            this.btnGestionUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnGestionUsuarios.Size = new System.Drawing.Size(272, 46);
            this.btnGestionUsuarios.TabIndex = 3;
            this.btnGestionUsuarios.Text = "👥  Gestion de Usuarios";
            this.btnGestionUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Visible = false;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditoria.FlatAppearance.BorderSize = 0;
            this.btnAuditoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnAuditoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditoria.ForeColor = System.Drawing.Color.White;
            this.btnAuditoria.Location = new System.Drawing.Point(-19, 202);
            this.btnAuditoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAuditoria.Size = new System.Drawing.Size(239, 46);
            this.btnAuditoria.TabIndex = 4;
            this.btnAuditoria.Text = "📋  Auditoria";
            this.btnAuditoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditoria.UseVisualStyleBackColor = true;
            this.btnAuditoria.Visible = false;
            this.btnAuditoria.Click += new System.EventHandler(this.btnAuditoria_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSalir.Location = new System.Drawing.Point(0, 564);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(220, 46);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "🚪  Cerrar Sesión";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.pnlHeader.Controls.Add(this.lblTituloSeccion);
            this.pnlHeader.Controls.Add(this.lblUsuario);
            this.pnlHeader.Controls.Add(this.lblFechaHora);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(959, 70);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTituloSeccion
            // 
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloSeccion.Location = new System.Drawing.Point(20, 20);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(360, 30);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "Inicio";
            this.lblTituloSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblUsuario.Location = new System.Drawing.Point(509, 15);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(429, 20);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaHora.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFechaHora.Location = new System.Drawing.Point(759, 38);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(180, 20);
            this.lblFechaHora.TabIndex = 2;
            this.lblFechaHora.Text = "Fecha/Hora";
            this.lblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.pnlContent.Controls.Add(this.pnlAviso);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 70);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(959, 558);
            this.pnlContent.TabIndex = 3;
            this.pnlContent.Resize += new System.EventHandler(this.pnlContent_Resize);
            // 
            // pnlAviso
            // 
            this.pnlAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAviso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlAviso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAviso.Controls.Add(this.lblCerrarAviso);
            this.pnlAviso.Controls.Add(this.lblAvisoTitulo);
            this.pnlAviso.Controls.Add(this.lblAvisoDetalle);
            this.pnlAviso.Location = new System.Drawing.Point(559, 318);
            this.pnlAviso.Name = "pnlAviso";
            this.pnlAviso.Size = new System.Drawing.Size(380, 220);
            this.pnlAviso.TabIndex = 4;
            this.pnlAviso.Visible = false;
            // 
            // lblCerrarAviso
            // 
            this.lblCerrarAviso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrarAviso.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCerrarAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(113)))), ((int)(((byte)(108)))));
            this.lblCerrarAviso.Location = new System.Drawing.Point(350, 5);
            this.lblCerrarAviso.Name = "lblCerrarAviso";
            this.lblCerrarAviso.Size = new System.Drawing.Size(25, 25);
            this.lblCerrarAviso.TabIndex = 0;
            this.lblCerrarAviso.Text = "×";
            this.lblCerrarAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCerrarAviso.Click += new System.EventHandler(this.lblCerrarAviso_Click);
            this.lblCerrarAviso.MouseEnter += new System.EventHandler(this.lblCerrarAviso_MouseEnter);
            this.lblCerrarAviso.MouseLeave += new System.EventHandler(this.lblCerrarAviso_MouseLeave);
            // 
            // lblAvisoTitulo
            // 
            this.lblAvisoTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAvisoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblAvisoTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblAvisoTitulo.Name = "lblAvisoTitulo";
            this.lblAvisoTitulo.Size = new System.Drawing.Size(325, 20);
            this.lblAvisoTitulo.TabIndex = 1;
            this.lblAvisoTitulo.Text = "⚠️ Datos pendientes por completar";
            // 
            // lblAvisoDetalle
            // 
            this.lblAvisoDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAvisoDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblAvisoDetalle.Location = new System.Drawing.Point(15, 38);
            this.lblAvisoDetalle.Name = "lblAvisoDetalle";
            this.lblAvisoDetalle.Size = new System.Drawing.Size(350, 170);
            this.lblAvisoDetalle.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 654);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.stpEstado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.stpEstado.ResumeLayout(false);
            this.stpEstado.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlAviso.ResumeLayout(false);
            this.pnlAviso.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stpEstado;
        private System.Windows.Forms.ToolStripStatusLabel stplblEstado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnDatosPersonales;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlAviso;
        private System.Windows.Forms.Label lblCerrarAviso;
        private System.Windows.Forms.Label lblAvisoTitulo;
        private System.Windows.Forms.Label lblAvisoDetalle;
    }
}
