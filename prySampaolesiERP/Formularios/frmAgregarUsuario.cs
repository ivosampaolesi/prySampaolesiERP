using prySampaolesiClaseBD;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public partial class frmAgregarUsuario : Form
    {
        private clsConexion conexion;

        public event EventHandler SolicitarVolverGestionUsuarios;

        public frmAgregarUsuario()
        {
            InitializeComponent();
            Load += frmAgregarUsuario_Load;
            FormClosing += frmAgregarUsuario_FormClosing;
            btnGuardar.Click += btnGuardar_Click;
          
            btnVolver.Click += btnVolver_Click;
        }

        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                CargarPerfiles();
            }
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
            if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "" || txtDni.Text.Trim() == "" ||
                txtMail.Text.Trim() == "" || txtContrasenia.Text == "" || cmbPerfil.SelectedValue == null)
            {
                MessageBox.Show("Complete todos los datos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe ser numerico.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = conexion.EjecutarComando(
                "INSERT INTO Usuario (Nombre, Apellido, DNI, Mail, Contrasenia) VALUES (?, ?, ?, ?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@nombre", OleDbType.VarWChar) { Value = txtNombre.Text.Trim() },
                    new OleDbParameter("@apellido", OleDbType.VarWChar) { Value = txtApellido.Text.Trim() },
                    new OleDbParameter("@dni", OleDbType.Integer) { Value = dni },
                    new OleDbParameter("@mail", OleDbType.VarWChar) { Value = txtMail.Text.Trim() },
                    new OleDbParameter("@contrasenia", OleDbType.VarWChar) { Value = txtContrasenia.Text }
                });

            int idUsuario = ok ? Convert.ToInt32(conexion.EjecutarEscalar("SELECT @@IDENTITY")) : 0;
            if (idUsuario > 0 && conexion.EjecutarComando(
                "INSERT INTO [Relacion-Perfil-Usuario] (IdUsuario, IdPerfil) VALUES (?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario },
                    new OleDbParameter("@idPerfil", OleDbType.Integer) { Value = Convert.ToInt32(cmbPerfil.SelectedValue) }
                }) && CrearDatosPersonalesUsuario(idUsuario))
            {
                MessageBox.Show("Usuario agregado correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SolicitarVolverGestionUsuarios?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool CrearDatosPersonalesUsuario(int idUsuario)
        {
            return conexion.EjecutarComando(
                "INSERT INTO DatosPersonales (IdUsuario, Activo) VALUES (?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario },
                    new OleDbParameter("@activo", OleDbType.Boolean) { Value = true }
                });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SolicitarVolverGestionUsuarios?.Invoke(this, EventArgs.Empty);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            SolicitarVolverGestionUsuarios?.Invoke(this, EventArgs.Empty);
        }

        private void frmAgregarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
            {
                conexion.Desconectar();
            }
        }
    }
}
