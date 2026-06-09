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

                btnGestionUsuarios.Visible = Program.UsuarioPerfil.Equals("Administrador", StringComparison.OrdinalIgnoreCase);

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

           

            if (pnlAviso != null)

            {

                pnlAviso.Visible = false;

            }



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

            if (pnlAviso != null)

            {

                pnlAviso.Location = new Point(pnlContent.Width - pnlAviso.Width - 20, pnlContent.Height - pnlAviso.Height - 20);

            }

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

            ActualizarAvisoPendientes();

        }



        private bool TieneDatosPersonalesIncompletos()

        {

            OleDbParameter[] parametrosDatos = new OleDbParameter[]

            {

                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }

            };



            DataTable dt = conexion.EjecutarConsulta(

                "SELECT Usuario.Nombre, Usuario.Apellido, Usuario.Mail, Usuario.DNI, " +

                "DatosPersonales.Localidad, DatosPersonales.Provincia, " +

                "DatosPersonales.Telefono, DatosPersonales.Geo " +

                "FROM Usuario LEFT JOIN DatosPersonales ON Usuario.IdUsuario = DatosPersonales.IdUsuario " +

                "WHERE Usuario.IdUsuario = @idUsuario",

                parametrosDatos);



            if (dt == null || dt.Rows.Count == 0)

                return true;



            DataRow fila = dt.Rows[0];

            string[] columnasObligatorias = new string[]

            {

                "Nombre", "Apellido", "Mail", "DNI", "Localidad", "Provincia", "Telefono", "Geo"

            };



            foreach (string columna in columnasObligatorias)

            {

                if (fila[columna] == DBNull.Value || string.IsNullOrWhiteSpace(fila[columna].ToString()))

                    return true;

            }



            DataTable dtRedes = conexion.EjecutarConsulta(

                "SELECT COUNT(*) AS Cantidad FROM RedesUsuario WHERE IdUsuario = ?",

                new OleDbParameter[]

                {

                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }

                });



            int cantidadRedes = dtRedes != null && dtRedes.Rows.Count > 0 ? Convert.ToInt32(dtRedes.Rows[0]["Cantidad"]) : 0;

            if (cantidadRedes == 0)

                return true;



            DataTable dtDomicilios = conexion.EjecutarConsulta(

                "SELECT COUNT(*) AS Cantidad FROM Domicilios WHERE IdUsuario = ?",

                new OleDbParameter[]

                {

                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }

                });



            int cantidadDomicilios = dtDomicilios != null && dtDomicilios.Rows.Count > 0 ? Convert.ToInt32(dtDomicilios.Rows[0]["Cantidad"]) : 0;

            return cantidadDomicilios == 0;

        }



        private void btnAuditoria_Click(object sender, EventArgs e)

        {

            clsAuditoria.RegistrarAccion(conexion, Program.UsuarioMail, Program.UsuarioPerfil, "Pestana Auditoria");

            AbrirFormularioHijo(new frmAuditoria(), "Auditoria");

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

            frmEstadoUsuarios frm = new frmEstadoUsuarios();

            frm.SolicitarVolverGestionUsuarios += frmEstadoUsuarios_SolicitarVolverGestionUsuarios;

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



        private void btnSalir_Click(object sender, EventArgs e)

        {

            this.Close();

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



        private void lblCerrarAviso_Click(object sender, EventArgs e)

        {

            pnlAviso.Visible = false;

        }



        private void lblCerrarAviso_MouseEnter(object sender, EventArgs e)

        {

            lblCerrarAviso.ForeColor = Color.FromArgb(239, 68, 68);

        }



        private void lblCerrarAviso_MouseLeave(object sender, EventArgs e)

        {

            lblCerrarAviso.ForeColor = Color.FromArgb(120, 113, 108);

        }



        private void ActualizarAvisoPendientes()

        {

            if (pnlAviso == null) return;



            var faltantes = ObtenerCamposFaltantes();

            if (faltantes.Count > 0)

            {

                string mensaje = "Detectamos que aún te falta completar:\n\n";

                foreach (var campo in faltantes)

                {

                    mensaje += $"  • {campo}\n";

                }

                mensaje += "\nPodés completarlos en \"Datos Personales\".";

                lblAvisoDetalle.Text = mensaje;

                pnlAviso.Visible = true;

                pnlAviso.BringToFront();

            }

            else

            {

                pnlAviso.Visible = false;

            }

        }



        private System.Collections.Generic.List<string> ObtenerCamposFaltantes()

        {

            var faltantes = new System.Collections.Generic.List<string>();



            OleDbParameter[] parametrosDatos = new OleDbParameter[]

            {

                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }

            };



            DataTable dt = conexion.EjecutarConsulta(

                "SELECT Usuario.Nombre, Usuario.Apellido, Usuario.Mail, Usuario.DNI, " +

                "DatosPersonales.Localidad, DatosPersonales.Provincia, " +

                "DatosPersonales.Telefono, DatosPersonales.Geo " +

                "FROM Usuario LEFT JOIN DatosPersonales ON Usuario.IdUsuario = DatosPersonales.IdUsuario " +

                "WHERE Usuario.IdUsuario = @idUsuario",

                parametrosDatos);



            if (dt != null && dt.Rows.Count > 0)

            {

                DataRow fila = dt.Rows[0];



                var campos = new System.Collections.Generic.Dictionary<string, string>

                {

                    { "Nombre", "Nombre" },

                    { "Apellido", "Apellido" },

                    { "Mail", "Email" },

                    { "DNI", "DNI" },


                    { "Localidad", "Localidad" },

                    { "Provincia", "Provincia" },

                    { "Telefono", "Teléfono" },

                    { "Geo", "Geolocalización" }

                };



                foreach (var campo in campos)

                {

                    if (fila[campo.Key] == DBNull.Value || string.IsNullOrWhiteSpace(fila[campo.Key].ToString()))

                    {

                        faltantes.Add(campo.Value);

                    }

                }

            }

            else

            {

                faltantes.Add("Datos Personales");

            }



            DataTable dtRedes = conexion.EjecutarConsulta(

                "SELECT COUNT(*) AS Cantidad FROM RedesUsuario WHERE IdUsuario = ?",

                new OleDbParameter[]

                {

                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }

                });



            int cantidadRedes = dtRedes != null && dtRedes.Rows.Count > 0 ? Convert.ToInt32(dtRedes.Rows[0]["Cantidad"]) : 0;

            if (cantidadRedes == 0)

            {

                faltantes.Add("Redes Sociales");

            }



            return faltantes;

        }



        private void pictureBox1_Click(object sender, EventArgs e)

        {

            if (pnlAviso != null)

            {

                pnlAviso.Visible = false;

            }

        }

    }

}

