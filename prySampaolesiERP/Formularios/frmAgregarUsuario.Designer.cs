namespace prySampaolesiERP
{
    partial class frmAgregarUsuario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbLocalidad2 = new System.Windows.Forms.ComboBox();
            this.cmbProvincia2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDetalleDomicilio = new System.Windows.Forms.TextBox();
            this.lblDetalleDomicilio = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtNumeroCelu = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGEO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(35, 64);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(35, 104);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(64, 17);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(35, 144);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(36, 17);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "DNI:";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(35, 261);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(39, 17);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Mail:";
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.Location = new System.Drawing.Point(35, 184);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(81, 17);
            this.lblContrasenia.TabIndex = 4;
            this.lblContrasenia.Text = "Contraseña:";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(35, 223);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(48, 17);
            this.lblCargo.TabIndex = 5;
            this.lblCargo.Text = "Cargo:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(140, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(140, 100);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(220, 22);
            this.txtApellido.TabIndex = 7;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(140, 140);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(220, 22);
            this.txtDni.TabIndex = 8;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(140, 259);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(203, 22);
            this.txtMail.TabIndex = 9;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(140, 179);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.Size = new System.Drawing.Size(111, 22);
            this.txtContrasenia.TabIndex = 10;
            // 
            // cmbPerfil
            // 
            this.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.Location = new System.Drawing.Point(140, 220);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(111, 24);
            this.cmbPerfil.TabIndex = 11;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(553, 340);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(88, 38);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Atras";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(659, 340);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 38);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // cmbLocalidad2
            // 
            this.cmbLocalidad2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad2.FormattingEnabled = true;
            this.cmbLocalidad2.Location = new System.Drawing.Point(526, 99);
            this.cmbLocalidad2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLocalidad2.Name = "cmbLocalidad2";
            this.cmbLocalidad2.Size = new System.Drawing.Size(203, 24);
            this.cmbLocalidad2.TabIndex = 38;
            // 
            // cmbProvincia2
            // 
            this.cmbProvincia2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia2.FormattingEnabled = true;
            this.cmbProvincia2.Location = new System.Drawing.Point(526, 56);
            this.cmbProvincia2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProvincia2.Name = "cmbProvincia2";
            this.cmbProvincia2.Size = new System.Drawing.Size(203, 24);
            this.cmbProvincia2.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(434, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Provincia:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(435, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Localidad:";
            // 
            // txtDetalleDomicilio
            // 
            this.txtDetalleDomicilio.Location = new System.Drawing.Point(526, 179);
            this.txtDetalleDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDetalleDomicilio.Name = "txtDetalleDomicilio";
            this.txtDetalleDomicilio.Size = new System.Drawing.Size(203, 22);
            this.txtDetalleDomicilio.TabIndex = 39;
            // 
            // lblDetalleDomicilio
            // 
            this.lblDetalleDomicilio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleDomicilio.Location = new System.Drawing.Point(434, 179);
            this.lblDetalleDomicilio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetalleDomicilio.Name = "lblDetalleDomicilio";
            this.lblDetalleDomicilio.Size = new System.Drawing.Size(83, 36);
            this.lblDetalleDomicilio.TabIndex = 40;
            this.lblDetalleDomicilio.Text = "Detalle del domicilio:";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(526, 138);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(203, 22);
            this.txtDomicilio.TabIndex = 33;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(434, 141);
            this.lblDomicilio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(72, 17);
            this.lblDomicilio.TabIndex = 34;
            this.lblDomicilio.Text = "Domicilio:";
            // 
            // txtNumeroCelu
            // 
            this.txtNumeroCelu.Location = new System.Drawing.Point(140, 295);
            this.txtNumeroCelu.Name = "txtNumeroCelu";
            this.txtNumeroCelu.Size = new System.Drawing.Size(203, 22);
            this.txtNumeroCelu.TabIndex = 41;
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(35, 295);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(82, 42);
            this.lbl.TabIndex = 42;
            this.lbl.Text = "Numero de Celular:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 227);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "GEO:";
            // 
            // txtGEO
            // 
            this.txtGEO.Location = new System.Drawing.Point(526, 223);
            this.txtGEO.Margin = new System.Windows.Forms.Padding(4);
            this.txtGEO.Name = "txtGEO";
            this.txtGEO.Size = new System.Drawing.Size(203, 22);
            this.txtGEO.TabIndex = 43;
            // 
            // frmAgregarUsuario
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(787, 390);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGEO);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtNumeroCelu);
            this.Controls.Add(this.cmbLocalidad2);
            this.Controls.Add(this.cmbProvincia2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDetalleDomicilio);
            this.Controls.Add(this.lblDetalleDomicilio);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.lblDomicilio);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbPerfil);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAgregarUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbLocalidad2;
        private System.Windows.Forms.ComboBox cmbProvincia2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDetalleDomicilio;
        private System.Windows.Forms.Label lblDetalleDomicilio;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtNumeroCelu;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGEO;
    }
}
