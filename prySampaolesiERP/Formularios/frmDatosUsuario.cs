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
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                CargarProvincias();
                CargarLocalidades();
                
                CargarRedesDisponibles();

                GarantizarDatosPersonalesUsuario();
                CargarDatosUsuario();
                CargarRedesUsuario();
                CargarDomiciliosUsuario();
                estadoOriginal = ObtenerEstadoActual();
            }
            else
            {
                MessageBox.Show("Error al conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRedesDisponibles()
        {
            DataTable dt = conexion.ObtenerDatos("Redes");
            cmbRedes.DataSource = dt;
            cmbRedes.DisplayMember = "NombreRed";
            cmbRedes.ValueMember = "IdRed";
            cmbRedes.SelectedIndex = -1;
        }

        private bool GarantizarDatosPersonalesUsuario()
        {
            DataTable dt = conexion.EjecutarConsulta(
                "SELECT COUNT(*) AS Cantidad FROM DatosPersonales WHERE IdUsuario = ?",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
                });

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
            try
            {
                DataTable dt = conexion.ObtenerDatos("Provincias");
                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbProvincia.DataSource = dt;
                    cmbProvincia.DisplayMember = "Nombre";
                    
                    cmbProvincia.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar provincias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarLocalidades()
        {
            try
            {
                DataTable dt = conexion.ObtenerDatos("LocalidadesCordoba");
                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbLocalidad.DataSource = dt;
                    cmbLocalidad.DisplayMember = "Nombre";
                    
                    cmbLocalidad.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosUsuario()
        {
            try
            {
                OleDbParameter[] parametros = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", Program.UsuarioID)
                };

                DataTable dt = conexion.EjecutarConsulta(
                    "SELECT Usuario.Nombre, Usuario.Apellido, Usuario.Mail, " +
                    "Usuario.DNI, DatosPersonales.Localidad, " +
                    "DatosPersonales.Provincia, DatosPersonales.Telefono, DatosPersonales.Activo, DatosPersonales.Geo " +
                    "FROM Usuario LEFT JOIN DatosPersonales ON Usuario.IdUsuario = DatosPersonales.IdUsuario " +
                    "WHERE Usuario.IdUsuario = @idUsuario",
                    parametros);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para el usuario actual.", "Datos de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow fila = dt.Rows[0];

                txtNombre.Text = ObtenerTexto(fila, "Nombre");
                txtApellido.Text = ObtenerTexto(fila, "Apellido");
                txtMail.Text = ObtenerTexto(fila, "Mail");
                txtDni.Text = ObtenerTexto(fila, "DNI");
                txtGEO.Text = ObtenerTexto(fila, "Geo");
                maskedTextBox1.Text = ObtenerTexto(fila, "Telefono");
             

                SeleccionarComboPorTexto(cmbProvincia, ObtenerTexto(fila, "Provincia"));
                SeleccionarComboPorTexto(cmbLocalidad, ObtenerTexto(fila, "Localidad"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerTexto(DataRow fila, string columna)
        {
            return fila[columna] != DBNull.Value ? fila[columna].ToString() : "";
        }

        private bool ObtenerBooleano(DataRow fila, string columna)
        {
            return fila[columna] != DBNull.Value && Convert.ToBoolean(fila[columna]);
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

        private void CargarRedesUsuario()
        {
            lstRedesUsuario.Items.Clear();

            OleDbParameter[] parametros = new OleDbParameter[]
            {
                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
            };

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT RedesUsuario.IdRed, Redes.NombreRed, RedesUsuario.UsuarioRed " +
                "FROM RedesUsuario INNER JOIN Redes ON RedesUsuario.IdRed = Redes.IdRed " +
                "WHERE RedesUsuario.IdUsuario = @idUsuario " +
                "ORDER BY Redes.NombreRed",
                parametros);

            if (dt == null)
                return;

            foreach (DataRow fila in dt.Rows)
            {
                AgregarRedALista(
                    Convert.ToInt32(fila["IdRed"]),
                    fila["NombreRed"].ToString(),
                    fila["UsuarioRed"].ToString());
            }
        }

        private void btnAgregarRed_Click(object sender, EventArgs e)
        {
            if (cmbRedes.SelectedValue == null || cmbRedes.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una red.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuarioRed = txtRedes.Text.Trim();
            if (usuarioRed == "")
            {
                MessageBox.Show("Ingrese el usuario de la red seleccionada.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRed = Convert.ToInt32(cmbRedes.SelectedValue);
            foreach (ListViewItem item in lstRedesUsuario.Items)
            {
                if ((int)item.Tag == idRed)
                {
                    item.SubItems[1].Text = usuarioRed;
                    txtRedes.Clear();
                    cmbRedes.SelectedIndex = -1;
                    return;
                }
            }

            AgregarRedALista(idRed, cmbRedes.Text, usuarioRed);
            txtRedes.Clear();
            cmbRedes.SelectedIndex = -1;
        }

        private void AgregarRedALista(int idRed, string nombreRed, string usuarioRed)
        {
            ListViewItem item = new ListViewItem(nombreRed);
            item.SubItems.Add(usuarioRed);
            item.Tag = idRed;
            lstRedesUsuario.Items.Add(item);
        }

        private void btnQuitarRed_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstRedesUsuario.SelectedItems)
            {
                lstRedesUsuario.Items.Remove(item);
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
            if (GuardarDatosUsuario() && GuardarRedesUsuario() && GuardarDomiciliosUsuario())
            {
                MessageBox.Show("Datos personales guardados correctamente.", "Datos personales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                estadoOriginal = ObtenerEstadoActual();
            }
        }

        private bool GuardarDatosUsuario()
        {
            if (!int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("El DNI debe ser numerico.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool usuarioActualizado = conexion.EjecutarComando(
                "UPDATE Usuario SET Nombre = ?, Apellido = ?, DNI = ?, Mail = ? WHERE IdUsuario = ?",
                new OleDbParameter[]
                {
                    new OleDbParameter("@nombre", OleDbType.VarWChar) { Value = txtNombre.Text.Trim() },
                    new OleDbParameter("@apellido", OleDbType.VarWChar) { Value = txtApellido.Text.Trim() },
                    new OleDbParameter("@dni", OleDbType.Integer) { Value = dni },
                    new OleDbParameter("@mail", OleDbType.VarWChar) { Value = txtMail.Text.Trim() },
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
                });

            if (!usuarioActualizado)
                return false;

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT COUNT(*) AS Cantidad FROM DatosPersonales WHERE IdUsuario = ?",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
                });

            int cantidad = dt != null && dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["Cantidad"]) : 0;

            string provincia = cmbProvincia.SelectedIndex >= 0 ? cmbProvincia.Text : "";
            string localidad = cmbLocalidad.SelectedIndex >= 0 ? cmbLocalidad.Text : "";
            string telefono = maskedTextBox1.MaskCompleted ? maskedTextBox1.Text.Trim() : "";

            if (cantidad > 0)
            {
                return conexion.EjecutarComando(
                    "UPDATE DatosPersonales SET Localidad = ?, Provincia = ?, Telefono = ?, Activo = ?, Geo = ? WHERE IdUsuario = ?",
                    new OleDbParameter[]
                    {
                        new OleDbParameter("@localidad", OleDbType.VarWChar) { Value = localidad },
                        new OleDbParameter("@provincia", OleDbType.VarWChar) { Value = provincia },
                        new OleDbParameter("@telefono", OleDbType.VarWChar) { Value = telefono },
                        new OleDbParameter("@activo", OleDbType.Boolean) { Value = true },
                        new OleDbParameter("@geo", OleDbType.VarWChar) { Value = txtGEO.Text.Trim() },
                        new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
                    });
            }

            return conexion.EjecutarComando(
                "INSERT INTO DatosPersonales (IdUsuario, Localidad, Provincia, Telefono, Activo, Geo) VALUES (?, ?, ?, ?, ?, ?)",
                new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@localidad", OleDbType.VarWChar) { Value = localidad },
                    new OleDbParameter("@provincia", OleDbType.VarWChar) { Value = provincia },
                    new OleDbParameter("@telefono", OleDbType.VarWChar) { Value = telefono },
                    new OleDbParameter("@activo", OleDbType.Boolean) { Value = true },
                    new OleDbParameter("@geo", OleDbType.VarWChar) { Value = txtGEO.Text.Trim() }
                });
        }

        private void CargarDomiciliosUsuario()
        {
            lstDomicilios.Items.Clear();

            OleDbParameter[] parametros = new OleDbParameter[]
            {
                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
            };

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT Domicilio FROM Domicilios WHERE IdUsuario = ?",
                parametros);

            if (dt == null)
                return;

            foreach (DataRow fila in dt.Rows)
            {
                lstDomicilios.Items.Add(fila["Domicilio"].ToString());
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

            lstDomicilios.Items.Add(domicilio);
            txtDomicilio.Clear();
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
            OleDbParameter[] parametrosEliminar = new OleDbParameter[]
            {
                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
            };

            if (!conexion.EjecutarComando("DELETE FROM Domicilios WHERE IdUsuario = ?", parametrosEliminar))
                return false;

            foreach (ListViewItem item in lstDomicilios.Items)
            {
                OleDbParameter[] parametrosInsertar = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@domicilio", OleDbType.VarWChar) { Value = item.Text }
                };

                if (!conexion.EjecutarComando(
                    "INSERT INTO Domicilios (IdUsuario, Domicilio) VALUES (?, ?)",
                    parametrosInsertar))
                {
                    return false;
                }
            }

            return true;
        }
        private bool GuardarRedesUsuario()
        {
            OleDbParameter[] parametrosEliminar = new OleDbParameter[]
            {
                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
            };

            if (!conexion.EjecutarComando("DELETE FROM RedesUsuario WHERE IdUsuario = ?", parametrosEliminar))
                return false;

            foreach (ListViewItem item in lstRedesUsuario.Items)
            {
                OleDbParameter[] parametrosInsertar = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@idRed", OleDbType.Integer) { Value = (int)item.Tag },
                    new OleDbParameter("@usuarioRed", OleDbType.VarWChar) { Value = item.SubItems[1].Text }
                };

                if (!conexion.EjecutarComando(
                    "INSERT INTO RedesUsuario (IdUsuario, IdRed, UsuarioRed) VALUES (?, ?, ?)",
                    parametrosInsertar))
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
            valores.Append(txtMail.Text).Append("|");
            valores.Append(txtDni.Text).Append("|");
            foreach (ListViewItem domItem in lstDomicilios.Items)
                valores.Append(domItem.Text).Append("|");
            valores.Append(txtGEO.Text).Append("|");
            valores.Append(maskedTextBox1.Text).Append("|");
            valores.Append(cmbProvincia.Text).Append("|");
            valores.Append(cmbLocalidad.Text).Append("|");
            foreach (ListViewItem item in lstRedesUsuario.Items)
                valores.Append(item.SubItems[0].Text).Append(":").Append(item.SubItems[1].Text).Append("|");
            return valores.ToString();
        }

        private void FrmDatosUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
