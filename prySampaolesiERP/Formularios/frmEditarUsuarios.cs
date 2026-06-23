using prySampaolesiClaseBD;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public partial class frmEditarUsuarios : Form
    {
        private clsConexion conexion;

        public event EventHandler SolicitarVolverGestionUsuarios;

        public event EventHandler<int> SolicitarEditarUsuario;

        public frmEditarUsuarios()
        {
            InitializeComponent();
            Load += frmEstadoUsuarios_Load;
            FormClosing += frmEstadoUsuarios_FormClosing;
            txtBuscar.TextChanged += Filtros_Changed;
            cmbEstado.SelectedIndexChanged += Filtros_Changed;
            btnCambiarEstado.Click += btnCambiarEstado_Click;
            btnVolver.Click += btnVolver_Click;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
        }

        private void frmEstadoUsuarios_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                cmbEstado.SelectedIndex = 0;
                CargarUsuarios();
            }
        }

        private void Filtros_Changed(object sender, EventArgs e)
        {
            if (conexion != null)
                CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            string consulta =
                "SELECT Usuario.IdUsuario, Usuario.Nombre & ' ' & Usuario.Apellido AS Nombre, " +
                "Perfil.Nombre AS Cargo, Usuario.DNI, " +
                "IIF(DatosPersonales.Activo = False, 'Desactivado', 'Activo') AS Estado, " +
                "IIF(DatosPersonales.Activo = False, False, True) AS Activo " +
                "FROM ((Usuario LEFT JOIN DatosPersonales ON Usuario.IdUsuario = DatosPersonales.IdUsuario) " +
                "LEFT JOIN [Relacion-Perfil-Usuario] ON Usuario.IdUsuario = [Relacion-Perfil-Usuario].IdUsuario) " +
                "LEFT JOIN Perfil ON [Relacion-Perfil-Usuario].IdPerfil = Perfil.IdPerfil " +
                "WHERE 1 = 1 ";

            if (cmbEstado.SelectedItem != null)
            {
                string estado = cmbEstado.SelectedItem.ToString();
                if (estado == "Activos")
                    consulta += "AND (DatosPersonales.Activo Is Null OR DatosPersonales.Activo <> False) ";
                else if (estado == "Desactivados")
                    consulta += "AND DatosPersonales.Activo = False ";
            }

            string busqueda = txtBuscar.Text.Trim();
            OleDbParameter[] parametros = null;
            if (busqueda != "")
            {
                consulta += "AND (Usuario.Nombre LIKE ? OR Usuario.Apellido LIKE ? OR (Usuario.Nombre & ' ' & Usuario.Apellido) LIKE ? OR CStr(Usuario.DNI) LIKE ?) ";
                parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@nombre", OleDbType.VarWChar) { Value = "%" + busqueda + "%" },
                    new OleDbParameter("@apellido", OleDbType.VarWChar) { Value = "%" + busqueda + "%" },
                    new OleDbParameter("@nombreCompleto", OleDbType.VarWChar) { Value = "%" + busqueda + "%" },
                    new OleDbParameter("@dni", OleDbType.VarWChar) { Value = "%" + busqueda + "%" }
                };
            }

            consulta += "ORDER BY Usuario.Nombre, Usuario.Apellido";

            DataTable dt = conexion.EjecutarConsulta(consulta, parametros);
            dgvUsuarios.DataSource = dt;
            ConfigurarGrilla();
            ActualizarBotonEstado();
        }

        private void ConfigurarGrilla()
        {
            if (dgvUsuarios.Columns.Count == 0)
                return;

            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["Activo"].Visible = false;
            dgvUsuarios.Columns["Nombre"].HeaderText = "Nombre";
            dgvUsuarios.Columns["Cargo"].HeaderText = "Cargo";
            dgvUsuarios.Columns["DNI"].HeaderText = "DNI";
            dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
            dgvUsuarios.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUsuarios.Columns["Cargo"].Width = 160;
            dgvUsuarios.Columns["DNI"].Width = 110;
            dgvUsuarios.Columns["Estado"].Width = 120;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonEstado();
        }

        private void ActualizarBotonEstado()
        {
            bool haySeleccion = dgvUsuarios.CurrentRow != null && !dgvUsuarios.CurrentRow.IsNewRow;
            btnCambiarEstado.Enabled = haySeleccion;
            btnEditarUsuario.Enabled = haySeleccion;

            if (!haySeleccion)
            {
                btnCambiarEstado.Text = "Cambiar estado";
                return;
            }

            bool activo = Convert.ToBoolean(dgvUsuarios.CurrentRow.Cells["Activo"].Value);
            btnCambiarEstado.Text = activo ? "Desactivar usuario" : "Activar usuario";
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la grilla.", "Editar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value);
            SolicitarEditarUsuario?.Invoke(this, idUsuario);
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.IsNewRow)
                return;

            int idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value);
            string nombre = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            bool activo = Convert.ToBoolean(dgvUsuarios.CurrentRow.Cells["Activo"].Value);
            bool nuevoEstado = !activo;

            if (idUsuario == Program.UsuarioID && !nuevoEstado)
            {
                MessageBox.Show("No podes desactivar el usuario con la sesion actual.", "Estado de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accion = nuevoEstado ? "activar" : "desactivar";
            DialogResult respuesta = MessageBox.Show(
                "Seguro que queres " + accion + " a " + nombre + "?",
                "Estado de usuarios",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            if (GuardarEstadoUsuario(idUsuario, nuevoEstado))
            {
                MessageBox.Show("Estado actualizado correctamente.", "Estado de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            SolicitarVolverGestionUsuarios?.Invoke(this, EventArgs.Empty);
        }

        private bool GuardarEstadoUsuario(int idUsuario, bool activo)
        {
            DataTable dt = conexion.EjecutarConsulta(
                "SELECT COUNT(*) AS Cantidad FROM DatosPersonales WHERE IdUsuario = ?",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario }
                });

            int cantidad = dt != null && dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["Cantidad"]) : 0;
            if (cantidad > 0)
            {
                return conexion.EjecutarComando(
                    "UPDATE DatosPersonales SET Activo = ? WHERE IdUsuario = ?",
                    new OleDbParameter[]
                    {
                        new OleDbParameter("@activo", OleDbType.Boolean) { Value = activo },
                        new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario }
                    });
            }

            return conexion.EjecutarComando(
                "INSERT INTO DatosPersonales (IdUsuario, Activo) VALUES (?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = idUsuario },
                    new OleDbParameter("@activo", OleDbType.Boolean) { Value = activo }
                });
        }

        private void frmEstadoUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
