using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            conexion = new clsConexion();
            if (conexion.Conectar())
            {
                CargarProvincias();
                CargarLocalidades();
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
    }
}
