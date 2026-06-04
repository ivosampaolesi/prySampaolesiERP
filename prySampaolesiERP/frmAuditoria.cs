using prySampaolesiClaseBD;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public partial class frmAuditoria : Form
    {
        private clsConexion conexion;

        public frmAuditoria()
        {
            InitializeComponent();
            Load += frmAuditoria_Load;
            FormClosing += frmAuditoria_FormClosing;
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
                CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            string consulta = "SELECT IdSesion, Usuario, Cargo, FechaYHora, Accion FROM Auditoria WHERE 1=1";
            var parametros = new System.Collections.Generic.List<OleDbParameter>();

            if (dtpFecha.Checked)
            {
                consulta += " AND FechaYHora >= ? AND FechaYHora < ?";
                parametros.Add(new OleDbParameter("@desde", OleDbType.Date) { Value = dtpFecha.Value.Date });
                parametros.Add(new OleDbParameter("@hasta", OleDbType.Date) { Value = dtpFecha.Value.Date.AddDays(1) });
            }

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                consulta += " AND Usuario LIKE ?";
                parametros.Add(new OleDbParameter("@usuario", "%" + txtUsuario.Text.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                consulta += " AND Cargo LIKE ?";
                parametros.Add(new OleDbParameter("@cargo", "%" + txtCargo.Text.Trim() + "%"));
            }

            consulta += " ORDER BY FechaYHora DESC";
            DataTable dt = conexion.EjecutarConsulta(consulta, parametros.ToArray());
            dgvAuditoria.DataSource = dt;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void LimpiarFiltros()
        {
            dtpFecha.Checked = false;
            txtUsuario.Clear();
            txtCargo.Clear();
            CargarAuditoria();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void frmAuditoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
