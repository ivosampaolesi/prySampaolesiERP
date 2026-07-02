using prySampaolesiClaseBD;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public partial class frmMain : Form
    {
        private clsConexion conexion;
        private Timer timer;

        public frmMain()
        {
            InitializeComponent();
            this.Load += frmMain_Load;
            this.FormClosing += frmMain_FormClosing;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            bool ok = conexion.Conectar();
            if (ok)
            {
                stpEstado.BackColor = Color.Green;
                stplblEstado.Text = "Conexion exitosa :)";
                MostrarDatosUsuario();
                btnAuditoria.Visible = Program.UsuarioPerfil.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
                
                btnGestionUsuarios.Visible = Program.UsuarioPerfil.Equals("Administrador", StringComparison.OrdinalIgnoreCase) ||
                                             Program.UsuarioPerfil.Equals("Recursos Humanos", StringComparison.OrdinalIgnoreCase);
                
                MostrarInicio();
            }
            else
            {
                stpEstado.BackColor = Color.Red;
                stplblEstado.Text = "Error de conexión >:(";
            }

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void MostrarDatosUsuario()
        {
            OleDbParameter[] parametros = new OleDbParameter[]
            {
                new OleDbParameter("@idUsuario", Program.UsuarioID)
            };

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT Usuario.Nombre, Perfil.Nombre AS NombrePerfil " +
                "FROM (Usuario LEFT JOIN [Relacion-Perfil-Usuario] ON Usuario.IdUsuario = [Relacion-Perfil-Usuario].IdUsuario) " +
                "LEFT JOIN Perfil ON [Relacion-Perfil-Usuario].IdPerfil = Perfil.IdPerfil " +
                "WHERE Usuario.IdUsuario = @idUsuario",
                parametros);

            if (dt != null && dt.Rows.Count > 0)
            {
                string nombreUsuario = dt.Rows[0]["Nombre"].ToString();
                string nombrePerfil = dt.Rows[0]["NombrePerfil"] != DBNull.Value ? 
                    dt.Rows[0]["NombrePerfil"].ToString() : "";

                lblUsuario.Text = string.IsNullOrEmpty(nombrePerfil) ? 
                    nombreUsuario : $"{nombreUsuario} ({nombrePerfil})";
            }
        }

        private Form activeForm = null;

        private void AbrirFormularioHijo(Form formularioHijo, string tituloSeccion)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = formularioHijo;
            lblTituloSeccion.Text = tituloSeccion;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.None; // Keep None so we can center it

            pnlContent.Controls.Add(formularioHijo);
            pnlContent.Tag = formularioHijo;

            CentrarFormularioHijo();

            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void CentrarFormularioHijo()
        {
            if (activeForm != null && pnlContent != null)
            {
                activeForm.Location = new Point(
                    (pnlContent.Width - activeForm.Width) / 2,
                    (pnlContent.Height - activeForm.Height) / 2
                );
            }
        }

        private void pnlContent_Resize(object sender, EventArgs e)
        {
            CentrarFormularioHijo();
        }

        private void btnDatosPersonales_Click(object sender, EventArgs e)
        {
            clsAuditoria.RegistrarAccion(conexion, Program.UsuarioMail, Program.UsuarioPerfil, "Pestana Datos Personales");
            AbrirFormularioHijo(new frmDatosUsuario(), "Datos Personales");
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            clsAuditoria.RegistrarAccion(conexion, Program.UsuarioMail, Program.UsuarioPerfil, "Pestana Inicio");
            MostrarInicio();
        }

        private void MostrarInicio()
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }
            lblTituloSeccion.Text = "Inicio";
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            clsAuditoria.RegistrarAccion(conexion, Program.UsuarioMail, Program.UsuarioPerfil, "Pestana Auditoria");
            AbrirFormularioHijo(new frmAuditoria(), "Auditoría");
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            clsAuditoria.RegistrarAccion(conexion, Program.UsuarioMail, Program.UsuarioPerfil, "Pestana Gestion de Usuarios");
            MostrarGestionUsuarios();
        }

        private void MostrarGestionUsuarios()
        {
            frmGestionUsuarios frm = new frmGestionUsuarios();
            frm.SolicitarAgregarUsuario += frmGestionUsuarios_SolicitarAgregarUsuario;
            frm.SolicitarEstadoUsuarios += frmGestionUsuarios_SolicitarEstadoUsuarios;
            AbrirFormularioHijo(frm, "Gestion de Usuarios");
        }

        private void frmGestionUsuarios_SolicitarAgregarUsuario(object sender, EventArgs e)
        {
            clsAuditoria.RegistrarAccion(conexion, Program.UsuarioMail, Program.UsuarioPerfil, "Boton Agregar Usuario");

            frmAgregarUsuario frm = new frmAgregarUsuario();
            frm.SolicitarVolverGestionUsuarios += frmAgregarUsuario_SolicitarVolverGestionUsuarios;
            AbrirFormularioHijo(frm, "Agregar Usuario");
        }

        private void frmGestionUsuarios_SolicitarEstadoUsuarios(object sender, EventArgs e)
        {
            clsAuditoria.RegistrarAccion(conexion, Program.UsuarioMail, Program.UsuarioPerfil, "Boton Estado de Usuarios");
            frmEditarUsuarios frm = new frmEditarUsuarios();
            frm.SolicitarVolverGestionUsuarios += frmEstadoUsuarios_SolicitarVolverGestionUsuarios;
            frm.SolicitarEditarUsuario += frmEditarUsuarios_SolicitarEditarUsuario;
            AbrirFormularioHijo(frm, "Estado de Usuarios");
        }

        private void frmEditarUsuarios_SolicitarEditarUsuario(object sender, int idUsuario)
        {
            frmDatosUsuario frm = new frmDatosUsuario(idUsuario);
            frm.SolicitarVolver += frmDatosUsuario_SolicitarVolver;
            AbrirFormularioHijo(frm, "Datos de Usuario");
        }

        private void frmDatosUsuario_SolicitarVolver(object sender, EventArgs e)
        {
            frmEditarUsuarios frm = new frmEditarUsuarios();
            frm.SolicitarVolverGestionUsuarios += frmEstadoUsuarios_SolicitarVolverGestionUsuarios;
            frm.SolicitarEditarUsuario += frmEditarUsuarios_SolicitarEditarUsuario;
            AbrirFormularioHijo(frm, "Estado de Usuarios");
        }

        private void frmAgregarUsuario_SolicitarVolverGestionUsuarios(object sender, EventArgs e)
        {
            MostrarGestionUsuarios();
        }

        private void frmEstadoUsuarios_SolicitarVolverGestionUsuarios(object sender, EventArgs e)
        {
            MostrarGestionUsuarios();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }
            if (conexion != null)
            {
                clsAuditoria.RegistrarCierreSesion(conexion, Program.UsuarioMail, Program.UsuarioPerfil);
                conexion.Desconectar();
            }
        }
    }
}
