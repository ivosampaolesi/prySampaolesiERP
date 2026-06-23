namespace prySampaolesiERP

{

    partial class frmDatosUsuario

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
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGEO = new System.Windows.Forms.TextBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblDetalleDomicilio = new System.Windows.Forms.Label();
            this.txtDetalleDomicilio = new System.Windows.Forms.TextBox();
            this.btnAgregarDomicilio = new System.Windows.Forms.Button();
            this.btnQuitarDomicilio = new System.Windows.Forms.Button();
            this.lstDomicilios = new System.Windows.Forms.ListView();
            this.colDomicilio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblIngresarMedio = new System.Windows.Forms.Label();
            this.txtMedioIngresado = new System.Windows.Forms.TextBox();
            this.btnQuitarMedio = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMedios = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(97, 27);
            this.txtDni.Margin = new System.Windows.Forms.Padding(4);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(213, 25);
            this.txtDni.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(97, 75);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(213, 25);
            this.txtApellido.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(97, 126);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(213, 25);
            this.txtNombre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 367);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "GEO:";
            // 
            // txtGEO
            // 
            this.txtGEO.Location = new System.Drawing.Point(107, 363);
            this.txtGEO.Margin = new System.Windows.Forms.Padding(4);
            this.txtGEO.Name = "txtGEO";
            this.txtGEO.Size = new System.Drawing.Size(203, 25);
            this.txtGEO.TabIndex = 8;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomicilio.Location = new System.Drawing.Point(15, 115);
            this.lblDomicilio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(72, 17);
            this.lblDomicilio.TabIndex = 7;
            this.lblDomicilio.Text = "Domicilio:";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(107, 112);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(203, 25);
            this.txtDomicilio.TabIndex = 6;
            // 
            // lblDetalleDomicilio
            // 
            this.lblDetalleDomicilio.AutoSize = true;
            this.lblDetalleDomicilio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleDomicilio.Location = new System.Drawing.Point(16, 149);
            this.lblDetalleDomicilio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetalleDomicilio.Name = "lblDetalleDomicilio";
            this.lblDetalleDomicilio.Size = new System.Drawing.Size(56, 17);
            this.lblDetalleDomicilio.TabIndex = 32;
            this.lblDetalleDomicilio.Text = "Detalle:";
            // 
            // txtDetalleDomicilio
            // 
            this.txtDetalleDomicilio.Location = new System.Drawing.Point(107, 149);
            this.txtDetalleDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDetalleDomicilio.Name = "txtDetalleDomicilio";
            this.txtDetalleDomicilio.Size = new System.Drawing.Size(203, 25);
            this.txtDetalleDomicilio.TabIndex = 24;
            // 
            // btnAgregarDomicilio
            // 
            this.btnAgregarDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAgregarDomicilio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDomicilio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregarDomicilio.Location = new System.Drawing.Point(186, 180);
            this.btnAgregarDomicilio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarDomicilio.Name = "btnAgregarDomicilio";
            this.btnAgregarDomicilio.Size = new System.Drawing.Size(160, 28);
            this.btnAgregarDomicilio.TabIndex = 25;
            this.btnAgregarDomicilio.Text = "Agregar domicilio";
            this.btnAgregarDomicilio.UseVisualStyleBackColor = false;
            // 
            // btnQuitarDomicilio
            // 
            this.btnQuitarDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnQuitarDomicilio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitarDomicilio.Location = new System.Drawing.Point(186, 322);
            this.btnQuitarDomicilio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitarDomicilio.Name = "btnQuitarDomicilio";
            this.btnQuitarDomicilio.Size = new System.Drawing.Size(160, 28);
            this.btnQuitarDomicilio.TabIndex = 26;
            this.btnQuitarDomicilio.Text = "Quitar domicilio";
            this.btnQuitarDomicilio.UseVisualStyleBackColor = false;
            // 
            // lstDomicilios
            // 
            this.lstDomicilios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDomicilio});
            this.lstDomicilios.FullRowSelect = true;
            this.lstDomicilios.GridLines = true;
            this.lstDomicilios.HideSelection = false;
            this.lstDomicilios.Location = new System.Drawing.Point(13, 212);
            this.lstDomicilios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstDomicilios.MultiSelect = false;
            this.lstDomicilios.Name = "lstDomicilios";
            this.lstDomicilios.Size = new System.Drawing.Size(333, 103);
            this.lstDomicilios.TabIndex = 26;
            this.lstDomicilios.UseCompatibleStateImageBehavior = false;
            this.lstDomicilios.View = System.Windows.Forms.View.Details;
            // 
            // colDomicilio
            // 
            this.colDomicilio.Text = "Domicilio";
            this.colDomicilio.Width = 230;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLocalidad);
            this.groupBox1.Controls.Add(this.cmbProvincia);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnQuitarDomicilio);
            this.groupBox1.Controls.Add(this.lstDomicilios);
            this.groupBox1.Controls.Add(this.btnAgregarDomicilio);
            this.groupBox1.Controls.Add(this.txtDetalleDomicilio);
            this.groupBox1.Controls.Add(this.lblDetalleDomicilio);
            this.groupBox1.Controls.Add(this.txtDomicilio);
            this.groupBox1.Controls.Add(this.lblDomicilio);
            this.groupBox1.Controls.Add(this.txtGEO);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 206);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(353, 396);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de domicilio";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(107, 69);
            this.cmbLocalidad.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(203, 25);
            this.cmbLocalidad.TabIndex = 13;
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(107, 26);
            this.cmbProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(203, 25);
            this.cmbProvincia.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Provincia:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Localidad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.lblIngresarMedio);
            this.groupBox2.Controls.Add(this.txtMedioIngresado);
            this.groupBox2.Controls.Add(this.btnQuitarMedio);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbMedios);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(392, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(312, 550);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Contacto";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Location = new System.Drawing.Point(180, 157);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 28);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 119);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 25);
            this.textBox2.TabIndex = 30;
            // 
            // lblIngresarMedio
            // 
            this.lblIngresarMedio.Location = new System.Drawing.Point(8, 78);
            this.lblIngresarMedio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIngresarMedio.Name = "lblIngresarMedio";
            this.lblIngresarMedio.Size = new System.Drawing.Size(80, 26);
            this.lblIngresarMedio.TabIndex = 29;
            this.lblIngresarMedio.Text = "Usuario:";
            // 
            // txtMedioIngresado
            // 
            this.txtMedioIngresado.Location = new System.Drawing.Point(93, 74);
            this.txtMedioIngresado.Margin = new System.Windows.Forms.Padding(4);
            this.txtMedioIngresado.Name = "txtMedioIngresado";
            this.txtMedioIngresado.Size = new System.Drawing.Size(137, 25);
            this.txtMedioIngresado.TabIndex = 28;
            // 
            // btnQuitarMedio
            // 
            this.btnQuitarMedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnQuitarMedio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitarMedio.Location = new System.Drawing.Point(115, 513);
            this.btnQuitarMedio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitarMedio.Name = "btnQuitarMedio";
            this.btnQuitarMedio.Size = new System.Drawing.Size(119, 28);
            this.btnQuitarMedio.TabIndex = 27;
            this.btnQuitarMedio.Text = "Quitar medio";
            this.btnQuitarMedio.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 191);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(285, 315);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 39);
            this.label5.TabIndex = 1;
            this.label5.Text = "Medio de contacto";
            // 
            // cmbMedios
            // 
            this.cmbMedios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedios.FormattingEnabled = true;
            this.cmbMedios.Location = new System.Drawing.Point(93, 25);
            this.cmbMedios.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedios.Name = "cmbMedios";
            this.cmbMedios.Size = new System.Drawing.Size(137, 25);
            this.cmbMedios.TabIndex = 0;
            this.cmbMedios.SelectedIndexChanged += new System.EventHandler(this.cmbMedios_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 122);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 26);
            this.label9.TabIndex = 31;
            this.label9.Text = "Detalle: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDni);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtApellido);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(31, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(353, 183);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de domicilio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Location = new System.Drawing.Point(599, 575);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(105, 31);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Actualizar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // frmDatosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(748, 615);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDatosUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion



        private System.Windows.Forms.TextBox txtDni;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox txtApellido;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox txtNombre;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox txtGEO;

        private System.Windows.Forms.Label lblDomicilio;

        private System.Windows.Forms.TextBox txtDomicilio;

        private System.Windows.Forms.Label lblDetalleDomicilio;

        private System.Windows.Forms.TextBox txtDetalleDomicilio;

        private System.Windows.Forms.Button btnAgregarDomicilio;

        private System.Windows.Forms.Button btnQuitarDomicilio;

        private System.Windows.Forms.ListView lstDomicilios;

        private System.Windows.Forms.ColumnHeader colDomicilio;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.ComboBox cmbLocalidad;

        private System.Windows.Forms.ComboBox cmbProvincia;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMedios;
        private System.Windows.Forms.Button btnQuitarMedio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblIngresarMedio;
        private System.Windows.Forms.TextBox txtMedioIngresado;
        private System.Windows.Forms.Label label9;
    }

}

