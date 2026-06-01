using prySampaolesiClaseBD;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public class frmAuditoria : Form
    {
        private clsConexion conexion;
        private DataGridView dgvAuditoria;
        private TextBox txtUsuario;
        private TextBox txtCargo;
        private DateTimePicker dtpFecha;

        public frmAuditoria()
        {
            InitializeComponent();
            Load += frmAuditoria_Load;
            FormClosing += frmAuditoria_FormClosing;
        }

        private void InitializeComponent()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(700, 430);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;

            GroupBox grpFiltros = new GroupBox
            {
                Text = "Filtros",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Location = new Point(12, 10),
                Size = new Size(676, 82)
            };

            Label lblFecha = CrearLabel("Fecha:", 14, 32);
            dtpFecha = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true,
                Location = new Point(65, 28),
                Size = new Size(125, 25)
            };

            Label lblUsuario = CrearLabel("Usuario:", 205, 32);
            txtUsuario = new TextBox { Location = new Point(270, 28), Size = new Size(135, 25) };

            Label lblCargo = CrearLabel("Cargo:", 420, 32);
            txtCargo = new TextBox { Location = new Point(475, 28), Size = new Size(125, 25) };

            Button btnFiltrar = CrearBoton("Filtrar", 605, 26);
            btnFiltrar.Click += (s, e) => CargarAuditoria();

            Button btnLimpiar = CrearBoton("Limpiar", 605, 54);
            btnLimpiar.Click += (s, e) => LimpiarFiltros();

            grpFiltros.Controls.AddRange(new Control[] { lblFecha, dtpFecha, lblUsuario, txtUsuario, lblCargo, txtCargo, btnFiltrar, btnLimpiar });

            dgvAuditoria = new DataGridView
            {
                Location = new Point(12, 105),
                Size = new Size(676, 315),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            dgvAuditoria.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvAuditoria.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAuditoria.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvAuditoria.EnableHeadersVisualStyles = false;

            Controls.Add(grpFiltros);
            Controls.Add(dgvAuditoria);
        }

        private Label CrearLabel(string texto, int x, int y)
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Location = new Point(x, y),
                Text = texto
            };
        }

        private Button CrearBoton(string texto, int x, int y)
        {
            return new Button
            {
                BackColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 7.8F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(x, y),
                Size = new Size(65, 24),
                Text = texto,
                UseVisualStyleBackColor = false
            };
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

        private void LimpiarFiltros()
        {
            dtpFecha.Checked = false;
            txtUsuario.Clear();
            txtCargo.Clear();
            CargarAuditoria();
        }

        private void frmAuditoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
