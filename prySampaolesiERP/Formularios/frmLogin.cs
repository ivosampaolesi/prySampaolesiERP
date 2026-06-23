using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using prySampaolesiClaseBD;

namespace prySampaolesiERP
{
    public partial class frmLogin : Form
    {
        private clsConexion conexion;
        private int intentos = 3;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            conexion.Conectar();
            txtContrasenia.PasswordChar = '*';
            ActualizarIntentos();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string dni = txtMail.Text.Trim();
            string contrasenia = txtContrasenia.Text;

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Ingrese DNI y contraseña", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(dni, out int dniNumero))
            {
                MessageBox.Show("El DNI debe ser numérico", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbParameter[] parametros = new OleDbParameter[]
            {
                new OleDbParameter("@dni", OleDbType.Integer) { Value = dniNumero },
                new OleDbParameter("@pass", OleDbType.VarWChar) { Value = contrasenia }
            };

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT Usuario.IdUsuario, Usuario.Mail, DatosPersonales.Activo " +
                "FROM Usuario LEFT JOIN DatosPersonales ON Usuario.IdUsuario = DatosPersonales.IdUsuario " +
                "WHERE Usuario.DNI = @dni AND Usuario.Contrasenia = @pass",
                parametros);

            if (dt != null && dt.Rows.Count > 0)
            {
                bool usuarioActivo = dt.Rows[0]["Activo"] != DBNull.Value && Convert.ToBoolean(dt.Rows[0]["Activo"]);
                if (!usuarioActivo)
                {
                    MessageBox.Show("El usuario fue desactivado. No puede ingresar al sistema.", "Usuario desactivado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasenia.Clear();
                    txtMail.Focus();
                    return;
                }

                Program.UsuarioID = (int)dt.Rows[0]["IdUsuario"];
                Program.UsuarioMail = dt.Rows[0]["Mail"].ToString();

                OleDbParameter[] parametrosPerfil = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", Program.UsuarioID)
                };

                DataTable dtPerfil = conexion.EjecutarConsulta(
                    "SELECT Perfil.Nombre " +
                    "FROM (Usuario LEFT JOIN [Relacion-Perfil-Usuario] ON Usuario.IdUsuario = [Relacion-Perfil-Usuario].IdUsuario) " +
                    "LEFT JOIN Perfil ON [Relacion-Perfil-Usuario].IdPerfil = Perfil.IdPerfil " +
                    "WHERE Usuario.IdUsuario = @idUsuario",
                    parametrosPerfil);

                Program.UsuarioPerfil = "";
                if (dtPerfil != null && dtPerfil.Rows.Count > 0)
                {
                    Program.UsuarioPerfil = dtPerfil.Rows[0]["Nombre"] != DBNull.Value ? 
                        dtPerfil.Rows[0]["Nombre"].ToString() : "";
                }

                clsAuditoria.RegistrarInicioSesion(conexion, Program.UsuarioMail, Program.UsuarioPerfil);

                frmMain frm = new frmMain();
                this.Hide();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    txtContrasenia.Clear();
                    txtMail.Clear();
                    intentos = 3;
                    ActualizarIntentos();
                    txtMail.Focus();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                intentos--;
                ActualizarIntentos();
                if (intentos > 0)
                    MessageBox.Show($"Datos incorrectos. Intentos restantes: {intentos}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Se agotaron los intentos. El programa se cerrará.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
                txtContrasenia.Clear();
                txtMail.Focus();
            }
        }

        private void ActualizarIntentos()
        {
            lblIntentos.Text = $"Intentos restantes: {intentos}";
        }

        private void chkMostrarContrasenia_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenia.PasswordChar = chkMostrarContrasenia.Checked ? '\0' : '*';
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
