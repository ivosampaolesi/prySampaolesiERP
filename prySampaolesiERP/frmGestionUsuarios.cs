using prySampaolesiClaseBD;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public partial class frmGestionUsuarios : Form
    {
        private clsConexion conexion;
        private Panel pnlAgregar;
        private TextBox txtNombre, txtApellido, txtDni, txtMail, txtContrasenia;
        private ComboBox cmbPerfil;

        public frmGestionUsuarios()
        {
            InitializeComponent();
            btnAgregarUsuarios.Click += btnAgregarUsuarios_Click;
            FormClosing += (s, e) => { if (conexion != null) conexion.Desconectar(); };
            conexion = new clsConexion();
            conexion.Conectar();
        }

        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            if (pnlAgregar == null)
                CrearPanelAgregar();

            CargarPerfiles();
            btnAgregarUsuarios.Visible = btnEditarUsuarios.Visible = btnDesactivarUsuarios.Visible = false;
            pnlAgregar.Visible = true;
        }

        private void CrearPanelAgregar()
        {
            pnlAgregar = new Panel { Location = new Point(35, 20), Size = new Size(350, 325), Visible = false };
            txtNombre = AgregarCampo("Nombre", 0);
            txtApellido = AgregarCampo("Apellido", 1);
            txtDni = AgregarCampo("DNI", 2);
            txtMail = AgregarCampo("Mail", 3);
            txtContrasenia = AgregarCampo("Contrasenia", 4);
            txtContrasenia.PasswordChar = '*';

            pnlAgregar.Controls.Add(new Label { Text = "Cargo", Location = new Point(0, 208), AutoSize = true });
            cmbPerfil = new ComboBox { Location = new Point(105, 204), Size = new Size(220, 24), DropDownStyle = ComboBoxStyle.DropDownList };
            pnlAgregar.Controls.Add(cmbPerfil);

            Button btnGuardar = new Button { Text = "Guardar", Location = new Point(105, 260), Size = new Size(105, 35) };
            Button btnCancelar = new Button { Text = "Cancelar", Location = new Point(220, 260), Size = new Size(105, 35) };
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += (s, e) => MostrarMenu();
            pnlAgregar.Controls.Add(btnGuardar);
            pnlAgregar.Controls.Add(btnCancelar);
            Controls.Add(pnlAgregar);
            ClientSize = new Size(420, 370);
        }

        private TextBox AgregarCampo(string texto, int fila)
        {
            int y = fila * 40;
            pnlAgregar.Controls.Add(new Label { Text = texto, Location = new Point(0, y + 4), AutoSize = true });
            TextBox txt = new TextBox { Location = new Point(105, y), Size = new Size(220, 24) };
            pnlAgregar.Controls.Add(txt);
            return txt;
        }

        private void CargarPerfiles()
        {
            DataTable dt = conexion.EjecutarConsulta("SELECT IdPerfil, Nombre FROM Perfil ORDER BY Nombre");
            cmbPerfil.DataSource = dt;
            cmbPerfil.DisplayMember = "Nombre";
            cmbPerfil.ValueMember = "IdPerfil";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "" || txtDni.Text.Trim() == "" || txtMail.Text.Trim() == "" || txtContrasenia.Text == "" || cmbPerfil.SelectedValue == null)
            {
                MessageBox.Show("Complete todos los datos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtDni.Text.Trim(), out long dni))
            {
                MessageBox.Show("El DNI debe ser numerico.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = conexion.EjecutarComando(
                "INSERT INTO Usuario (Nombre, Apellido, DNI, Mail, Contrasenia) VALUES (?, ?, ?, ?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@nombre", txtNombre.Text.Trim()),
                    new OleDbParameter("@apellido", txtApellido.Text.Trim()),
                    new OleDbParameter("@dni", dni),
                    new OleDbParameter("@mail", txtMail.Text.Trim()),
                    new OleDbParameter("@contrasenia", txtContrasenia.Text)
                });

            int idUsuario = ok ? Convert.ToInt32(conexion.EjecutarEscalar("SELECT @@IDENTITY")) : 0;
            if (idUsuario > 0 && conexion.EjecutarComando(
                "INSERT INTO [Relacion-Perfil-Usuario] (IdUsuario, IdPerfil) VALUES (?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", idUsuario),
                    new OleDbParameter("@idPerfil", cmbPerfil.SelectedValue)
                }))
            {
                MessageBox.Show("Usuario agregado correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                MostrarMenu();
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtMail.Clear();
            txtContrasenia.Clear();
            if (cmbPerfil.Items.Count > 0) cmbPerfil.SelectedIndex = 0;
        }

        private void MostrarMenu()
        {
            pnlAgregar.Visible = false;
            btnAgregarUsuarios.Visible = btnEditarUsuarios.Visible = btnDesactivarUsuarios.Visible = true;
            ClientSize = new Size(420, 220);
        }
    }
}
