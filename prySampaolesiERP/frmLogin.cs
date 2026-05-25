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
            string mail = txtMail.Text.Trim();
            string contrasenia = txtContrasenia.Text;

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Ingrese mail y contraseña", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbParameter[] parametros = new OleDbParameter[]
            {
                new OleDbParameter("@mail", mail),
                new OleDbParameter("@pass", contrasenia)
            };

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT IdUsuario, Mail FROM Usuario WHERE Mail = @mail AND Contrasenia = @pass", 
                parametros);

            if (dt != null && dt.Rows.Count > 0)
            {
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

                if (dtPerfil != null && dtPerfil.Rows.Count > 0)
                {
                    Program.UsuarioPerfil = dtPerfil.Rows[0]["Nombre"] != DBNull.Value ? 
                        dtPerfil.Rows[0]["Nombre"].ToString() : "";
                }

                frmMain frm = new frmMain();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                intentos--;
                ActualizarIntentos();
                if (intentos > 0)
                    MessageBox.Show($"Datos incorrectos. Intentos restantes: {intentos}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se agotaron los intentos. El programa se cerrará.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
