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

        public frmDatosUsuario()
        {
            InitializeComponent();
            this.Load += FrmEditarUsuario_Load;
            this.FormClosing += FrmDatosUsuario_FormClosing;
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                CargarProvincias();
                CargarLocalidades();
                
                cmbRedes.DataSource = conexion.ObtenerDatos("Redes");
                cmbRedes.DisplayMember = "NombreRed";
                cmbRedes.SelectedIndex = -1;

                CargarDatosUsuario();
            }
            else
            {
                MessageBox.Show("Error al conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    "Usuario.DNI, DatosPersonales.Direccion, DatosPersonales.Localidad, " +
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
                txtDireccion.Text = ObtenerTexto(fila, "Direccion");
                txtGEO.Text = ObtenerTexto(fila, "Geo");
                maskedTextBox1.Text = ObtenerTexto(fila, "Telefono");
                chkActivo.Checked = ObtenerBooleano(fila, "Activo");

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

        private void FrmDatosUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conexion != null)
                conexion.Desconectar();
        }
    }
}
