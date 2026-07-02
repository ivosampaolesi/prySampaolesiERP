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
            dtpFecha.ValueChanged += (s, e) => { if (dtpFecha.Checked && dtpHasta.Checked && dtpHasta.Value.Date < dtpFecha.Value.Date) dtpHasta.Value = dtpFecha.Value; };
            dtpHasta.ValueChanged += (s, e) => { if (dtpFecha.Checked && dtpHasta.Checked && dtpHasta.Value.Date < dtpFecha.Value.Date) dtpFecha.Value = dtpHasta.Value; };
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                CargarCargos();
                CargarAuditoria();
            }
        }

        private void CargarCargos()
        {
            cmbCargo.DataSource = conexion.EjecutarConsulta("SELECT Nombre FROM Perfil ORDER BY Nombre");
            cmbCargo.DisplayMember = "Nombre";
            cmbCargo.SelectedIndex = -1;
        }

        private void CargarAuditoria()
        {
            string consulta = "SELECT IdSesion, Usuario, Cargo, FechaYHora, Accion FROM Auditoria WHERE 1=1";
            var parametros = new System.Collections.Generic.List<OleDbParameter>();

            if (dtpFecha.Checked)
            {
                consulta += " AND FechaYHora >= ?";
                parametros.Add(new OleDbParameter("@desde", OleDbType.Date) { Value = dtpFecha.Value.Date });
            }

            if (dtpHasta.Checked || dtpFecha.Checked)
            {
                consulta += " AND FechaYHora < ?";
                DateTime hasta = dtpHasta.Checked ? dtpHasta.Value.Date.AddDays(1) : dtpFecha.Value.Date.AddDays(1);
                parametros.Add(new OleDbParameter("@hasta", OleDbType.Date) { Value = hasta });
            }

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                consulta += " AND Usuario LIKE ?";
                parametros.Add(new OleDbParameter("@usuario", "%" + txtUsuario.Text.Trim() + "%"));
            }

            if (cmbCargo.SelectedIndex != -1)
            {
                consulta += " AND Cargo = ?";
                parametros.Add(new OleDbParameter("@cargo", cmbCargo.Text));
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
            dtpFecha.Value = DateTime.Today;
            dtpHasta.Checked = false;
            txtUsuario.Clear();
            cmbCargo.SelectedIndex = -1;
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
