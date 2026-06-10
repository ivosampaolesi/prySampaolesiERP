using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prySampaolesiClaseBD;

namespace prySampaolesiERP
{
    public partial class frmDatosUsuario : Form
    {
        private clsConexion conexion;
        private string estadoOriginal;

        public frmDatosUsuario()
        {
            InitializeComponent();
            this.Load += FrmEditarUsuario_Load;
            this.FormClosing += FrmDatosUsuario_FormClosing;

            btnAgregarDomicilio.Click += btnAgregarDomicilio_Click;
            btnQuitarDomicilio.Click += btnQuitarDomicilio_Click;
            btnGuardar.Click += btnGuardar_Click;
            button2.Click += button2_Click;
            button1.Click += button1_Click;
            txtDni.KeyPress += TxtDni_KeyPress;
        }

        private void TxtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                CargarProvincias();
                cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
                
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                listView1.GridLines = true;
                listView1.Columns.Add("Medio", 80);
                listView1.Columns.Add("Usuario/Nro/Mail", 120);
                listView1.Columns.Add("Detalles", 120);

                lstDomicilios.Columns.Add("Detalle", 100);

                CargarMediosDisponibles();

                GarantizarDatosPersonalesUsuario();
                CargarDatosUsuario();
                CargarMediosUsuario();
                CargarDomiciliosUsuario();
                estadoOriginal = ObtenerEstadoActual();
            }
            else
            {
                MessageBox.Show("Error al conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMediosDisponibles()
        {
            DataTable dt = conexion.ObtenerDatos("Medios");
            if (dt != null)
            {
                cmbMedios.DataSource = dt;
                cmbMedios.DisplayMember = "NombreMedio";
                cmbMedios.ValueMember = "IdMedio";
                cmbMedios.SelectedIndex = -1;
            }
        }

        private bool GarantizarDatosPersonalesUsuario()
        {
            DataTable dt = conexion.EjecutarConsulta(
                "SELECT COUNT(*) AS Cantidad FROM DatosPersonales WHERE IdUsuario = ?",
                new OleDbParameter[] { new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID } });

            int cantidad = dt != null && dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["Cantidad"]) : 0;
            if (cantidad > 0)
                return true;

            return conexion.EjecutarComando(
                "INSERT INTO DatosPersonales (IdUsuario, Activo) VALUES (?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@activo", OleDbType.Boolean) { Value = true }
                });
        }

        private void CargarProvincias()
        {
            DataTable dt = conexion.ObtenerDatos("Provincias");
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbProvincia.DataSource = dt;
                cmbProvincia.DisplayMember = "Nombre";
                cmbProvincia.SelectedIndex = -1;
            }
        }

        private void CargarLocalidades()
        {
            DataTable dt = conexion.ObtenerDatos("LocalidadesCordoba");
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbLocalidad.DataSource = dt;
                cmbLocalidad.DisplayMember = "Nombre";
                cmbLocalidad.SelectedIndex = -1;
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex >= 0 && cmbProvincia.Text.Equals("Córdoba", StringComparison.OrdinalIgnoreCase))
                CargarLocalidades();
            else
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
            }
        }

        private void CargarDatosUsuario()
        {
            DataTable dt = conexion.EjecutarConsulta(
                "SELECT Usuario.Nombre, Usuario.Apellido, Usuario.DNI, DatosPersonales.Localidad, DatosPersonales.Provincia, DatosPersonales.Geo " +
                "FROM Usuario LEFT JOIN DatosPersonales ON Usuario.IdUsuario = DatosPersonales.IdUsuario " +
                "WHERE Usuario.IdUsuario = ?",
                new OleDbParameter[] { new OleDbParameter("@idUsuario", Program.UsuarioID) });

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                txtNombre.Text = ObtenerTexto(fila, "Nombre");
                txtApellido.Text = ObtenerTexto(fila, "Apellido");
                txtDni.Text = ObtenerTexto(fila, "DNI");
                txtGEO.Text = ObtenerTexto(fila, "Geo");

                SeleccionarComboPorTexto(cmbProvincia, ObtenerTexto(fila, "Provincia"));
                SeleccionarComboPorTexto(cmbLocalidad, ObtenerTexto(fila, "Localidad"));
            }
        }

        private string ObtenerTexto(DataRow fila, string columna)
        {
            return fila[columna] != DBNull.Value ? fila[columna].ToString() : "";
        }

        private void SeleccionarComboPorTexto(ComboBox combo, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                combo.SelectedIndex = -1;
                return;
            }
            int indice = combo.FindStringExact(texto);
            if (indice >= 0)
                combo.SelectedIndex = indice;
            else
                combo.Text = texto;
        }

        private void CargarMediosUsuario()
        {
            listView1.Items.Clear();
            DataTable dt = conexion.EjecutarConsulta(
                "SELECT MediosContacto.IdMedio, Medios.NombreMedio, MediosContacto.UsuarioMedio, MediosContacto.Detalles " +
                "FROM MediosContacto INNER JOIN Medios ON MediosContacto.IdMedio = Medios.IdMedio " +
                "WHERE MediosContacto.IdUsuario = ? " +
                "ORDER BY Medios.NombreMedio",
                new OleDbParameter[] { new OleDbParameter("@idUsuario", Program.UsuarioID) });

            if (dt != null)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    AgregarMedioALista(
                        Convert.ToInt32(fila["IdMedio"]),
                        fila["NombreMedio"].ToString(),
                        fila["UsuarioMedio"].ToString(),
                        fila["Detalles"].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbMedios.SelectedValue == null || cmbMedios.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un medio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuarioMedio = textBox1.Text.Trim();
            if (usuarioMedio == "")
            {
                MessageBox.Show("Ingrese el usuario, teléfono o mail.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string detalles = textBox2.Text.Trim();
            int idMedio = Convert.ToInt32(cmbMedios.SelectedValue);

            foreach (ListViewItem item in listView1.Items)
            {
                if ((int)item.Tag == idMedio && item.SubItems[1].Text.Equals(usuarioMedio, StringComparison.OrdinalIgnoreCase))
                {
                    item.SubItems[2].Text = detalles;
                    textBox1.Clear();
                    textBox2.Clear();
                    cmbMedios.SelectedIndex = -1;
                    return;
                }
            }

            AgregarMedioALista(idMedio, cmbMedios.Text, usuarioMedio, detalles);
            textBox1.Clear();
            textBox2.Clear();
            cmbMedios.SelectedIndex = -1;
        }

        private void AgregarMedioALista(int idMedio, string nombreMedio, string usuarioMedio, string detalles)
        {
            ListViewItem item = new ListViewItem(nombreMedio);
            item.SubItems.Add(usuarioMedio);
            item.SubItems.Add(detalles);
            item.Tag = idMedio;
            listView1.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (estadoOriginal == ObtenerEstadoActual())
            {
                MessageBox.Show("No hay cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lstDomicilios.Items.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un domicilio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (GuardarDatosUsuario() && GuardarMediosUsuario() && GuardarDomiciliosUsuario())
            {
                MessageBox.Show("Datos personales guardados correctamente.", "Datos personales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                estadoOriginal = ObtenerEstadoActual();
            }
        }

        private bool GuardarDatosUsuario()
        {
            if (txtDni.Text.Trim().Length < 7 || !int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe ser numerico y tener al menos 7 digitos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool usuarioActualizado = conexion.EjecutarComando(
                "UPDATE Usuario SET Nombre = ?, Apellido = ?, DNI = ? WHERE IdUsuario = ?",
                new OleDbParameter[]
                {
                    new OleDbParameter("@nombre", OleDbType.VarWChar) { Value = txtNombre.Text.Trim() },
                    new OleDbParameter("@apellido", OleDbType.VarWChar) { Value = txtApellido.Text.Trim() },
                    new OleDbParameter("@dni", OleDbType.Integer) { Value = dni },
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
                });

            if (!usuarioActualizado)
                return false;

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT COUNT(*) AS Cantidad FROM DatosPersonales WHERE IdUsuario = ?",
                new OleDbParameter[] { new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID } });

            int cantidad = dt != null && dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["Cantidad"]) : 0;

            string provincia = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : "";
            string localidad = cmbLocalidad.SelectedIndex >= 0 ? cmbLocalidad.Text : "";

            if (cantidad > 0)
            {
                return conexion.EjecutarComando(
                    "UPDATE DatosPersonales SET Localidad = ?, Provincia = ?, Activo = ?, Geo = ? WHERE IdUsuario = ?",
                    new OleDbParameter[]
                    {
                        new OleDbParameter("@localidad", OleDbType.VarWChar) { Value = localidad },
                        new OleDbParameter("@provincia", OleDbType.VarWChar) { Value = provincia },
                        new OleDbParameter("@activo", OleDbType.Boolean) { Value = true },
                        new OleDbParameter("@geo", OleDbType.VarWChar) { Value = txtGEO.Text.Trim() },
                        new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
                    });
            }

            return conexion.EjecutarComando(
                "INSERT INTO DatosPersonales (IdUsuario, Localidad, Provincia, Activo, Geo) VALUES (?, ?, ?, ?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@localidad", OleDbType.VarWChar) { Value = localidad },
                    new OleDbParameter("@provincia", OleDbType.VarWChar) { Value = provincia },
                    new OleDbParameter("@activo", OleDbType.Boolean) { Value = true },
                    new OleDbParameter("@geo", OleDbType.VarWChar) { Value = txtGEO.Text.Trim() }
                });
        }

        private void CargarDomiciliosUsuario()
        {
            lstDomicilios.Items.Clear();
            DataTable dt = conexion.EjecutarConsulta(
                "SELECT Domicilio, Detalle FROM Domicilios WHERE IdUsuario = ?",
                new OleDbParameter[] { new OleDbParameter("@idUsuario", Program.UsuarioID) });

            if (dt != null)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(fila["Domicilio"].ToString());
                    item.SubItems.Add(fila["Detalle"] != DBNull.Value ? fila["Detalle"].ToString() : "");
                    lstDomicilios.Items.Add(item);
                }
            }
        }

        private void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            string domicilio = txtDomicilio.Text.Trim();
            if (domicilio == "")
            {
                MessageBox.Show("Ingrese un domicilio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in lstDomicilios.Items)
            {
                if (item.Text.Equals(domicilio, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El domicilio ya fue ingresado.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ListViewItem nuevoItem = new ListViewItem(domicilio);
            nuevoItem.SubItems.Add(txtDetalleDomicilio.Text.Trim());
            lstDomicilios.Items.Add(nuevoItem);
            txtDomicilio.Clear();
            txtDetalleDomicilio.Clear();
        }

        private void btnQuitarDomicilio_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstDomicilios.SelectedItems)
            {
                lstDomicilios.Items.Remove(item);
            }
        }

        private bool GuardarDomiciliosUsuario()
        {
            if (!conexion.EjecutarComando("DELETE FROM Domicilios WHERE IdUsuario = ?", new OleDbParameter[] { new OleDbParameter("@idUsuario", Program.UsuarioID) }))
                return false;

            foreach (ListViewItem item in lstDomicilios.Items)
            {
                OleDbParameter[] parametrosInsertar = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@domicilio", OleDbType.VarWChar) { Value = item.Text },
                    new OleDbParameter("@detalle", OleDbType.VarWChar) { Value = item.SubItems.Count > 1 ? item.SubItems[1].Text : "" }
                };

                if (!conexion.EjecutarComando("INSERT INTO Domicilios (IdUsuario, Domicilio, Detalle) VALUES (?, ?, ?)", parametrosInsertar))
                {
                    return false;
                }
            }
            return true;
        }

        private bool GuardarMediosUsuario()
        {
            if (!conexion.EjecutarComando("DELETE FROM MediosContacto WHERE IdUsuario = ?", new OleDbParameter[] { new OleDbParameter("@idUsuario", Program.UsuarioID) }))
                return false;

            foreach (ListViewItem item in listView1.Items)
            {
                OleDbParameter[] parametrosInsertar = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@idMedio", OleDbType.Integer) { Value = (int)item.Tag },
                    new OleDbParameter("@usuarioMedio", OleDbType.VarWChar) { Value = item.SubItems[1].Text },
                    new OleDbParameter("@detalles", OleDbType.VarWChar) { Value = item.SubItems[2].Text }
                };

                if (!conexion.EjecutarComando("INSERT INTO MediosContacto (IdUsuario, IdMedio, UsuarioMedio, Detalles) VALUES (?, ?, ?, ?)", parametrosInsertar))
                {
                    return false;
                }
            }
            return true;
        }

        private string ObtenerEstadoActual()
        {
            var valores = new System.Text.StringBuilder();
            valores.Append(txtNombre.Text).Append("|");
            valores.Append(txtApellido.Text).Append("|");
            valores.Append(txtDni.Text).Append("|");
            foreach (ListViewItem domItem in lstDomicilios.Items)
                valores.Append(domItem.Text).Append(":").Append(domItem.SubItems.Count > 1 ? domItem.SubItems[1].Text : "").Append("|");
            valores.Append(txtGEO.Text).Append("|");
            valores.Append(cmbProvincia.Text).Append("|");
            valores.Append(cmbLocalidad.Text).Append("|");
            foreach (ListViewItem item in listView1.Items)
                valores.Append(item.SubItems[0].Text).Append(":").Append(item.SubItems[1].Text).Append(":").Append(item.SubItems.Count > 2 ? item.SubItems[2].Text : "").Append("|");
            return valores.ToString();
        }

        private void FrmDatosUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
