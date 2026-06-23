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
            txtDni.KeyPress += TxtDni_KeyPress;
            txtNumeroCelu.KeyPress += TxtDni_KeyPress;
        }

        private void TxtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                CargarPerfiles();
                CargarProvincias();
                cmbProvincia2.SelectedIndexChanged += cmbProvincia2_SelectedIndexChanged;
            }
        }

        private void CargarPerfiles()
        {
            DataTable dt = conexion.EjecutarConsulta("SELECT IdPerfil, Nombre FROM Perfil ORDER BY Nombre");
            cmbPerfil.DataSource = dt;
            cmbPerfil.DisplayMember = "Nombre";
            cmbPerfil.ValueMember = "IdPerfil";
        }

        private void CargarProvincias()
        {
            DataTable dt = conexion.ObtenerDatos("Provincias");
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbProvincia2.DataSource = dt;
                cmbProvincia2.DisplayMember = "Nombre";
                cmbProvincia2.SelectedIndex = -1;
            }
        }

        private void CargarLocalidades()
        {
            DataTable dt = conexion.ObtenerDatos("LocalidadesCordoba");
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbLocalidad2.DataSource = dt;
                cmbLocalidad2.DisplayMember = "Nombre";
                cmbLocalidad2.SelectedIndex = -1;
            }
        }

        private void cmbProvincia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia2.SelectedIndex >= 0 && cmbProvincia2.Text.Equals("Córdoba", StringComparison.OrdinalIgnoreCase))
                CargarLocalidades();
            else
            {
                cmbLocalidad2.DataSource = null;
                cmbLocalidad2.Items.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "" || txtDni.Text.Trim() == "" ||
                txtMail.Text.Trim() == "" || txtContrasenia.Text == "" || cmbPerfil.SelectedValue == null)
            {
                MessageBox.Show("Complete todos los datos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDni.Text.Trim().Length < 7 || !int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe ser numerico y tener al menos 7 digitos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbParameter[] parametrosDni = new OleDbParameter[]
            {
                new OleDbParameter("@dni", OleDbType.Integer) { Value = dni }
            };
            DataTable dtExistente = conexion.EjecutarConsulta(
                "SELECT IdUsuario FROM Usuario WHERE DNI = @dni",
                parametrosDni);

            if (dtExistente != null && dtExistente.Rows.Count > 0)
            {
                MessageBox.Show("El DNI ingresado ya se encuentra registrado.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string provincia = cmbProvincia2.SelectedIndex >= 0 ? cmbProvincia2.Text : "";
            string localidad = cmbLocalidad2.SelectedIndex >= 0 ? cmbLocalidad2.Text : "";
            string geo = txtGEO.Text.Trim();

            if (!conexion.EjecutarComando(
                "INSERT INTO DatosPersonales (IdUsuario, Provincia, Localidad, Geo, Activo) VALUES (?, ?, ?, ?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario },
                    new OleDbParameter("@provincia", OleDbType.VarWChar) { Value = provincia },
                    new OleDbParameter("@localidad", OleDbType.VarWChar) { Value = localidad },
                    new OleDbParameter("@geo", OleDbType.VarWChar) { Value = geo },
                    new OleDbParameter("@activo", OleDbType.Boolean) { Value = true }
                }))
                return false;

            if (!string.IsNullOrWhiteSpace(txtDomicilio.Text) && !conexion.EjecutarComando(
                "INSERT INTO Domicilios (IdUsuario, Domicilio, Detalle) VALUES (?, ?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario },
                    new OleDbParameter("@domicilio", OleDbType.VarWChar) { Value = txtDomicilio.Text.Trim() },
                    new OleDbParameter("@detalle", OleDbType.VarWChar) { Value = txtDetalleDomicilio.Text.Trim() }
                }))
                return false;

            if (!string.IsNullOrWhiteSpace(txtNumeroCelu.Text))
            {
                DataTable dtCelular = conexion.EjecutarConsulta("SELECT IdMedio FROM Medios WHERE NombreMedio = 'NumeroCelular'");
                int idMedioCelular = dtCelular != null && dtCelular.Rows.Count > 0 ? Convert.ToInt32(dtCelular.Rows[0]["IdMedio"]) : 0;

                if (idMedioCelular > 0 && !conexion.EjecutarComando(
                    "INSERT INTO MediosContacto (IdUsuario, IdMedio, UsuarioMedio, Detalles) VALUES (?, ?, ?, ?)",
                    new OleDbParameter[]
                    {
                        new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario },
                        new OleDbParameter("@idMedio", OleDbType.Integer) { Value = idMedioCelular },
                        new OleDbParameter("@usuarioMedio", OleDbType.VarWChar) { Value = txtNumeroCelu.Text.Trim() },
                        new OleDbParameter("@detalles", OleDbType.VarWChar) { Value = "" }
                    }))
                    return false;
            }

            return true;
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

        private void btnVolver_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
