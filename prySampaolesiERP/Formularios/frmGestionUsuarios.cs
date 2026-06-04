using System;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public partial class frmGestionUsuarios : Form
    {
        public event EventHandler SolicitarAgregarUsuario;
        public event EventHandler SolicitarEstadoUsuarios;

        public frmGestionUsuarios()
        {
            InitializeComponent();
            btnAgregarUsuarios.Click += btnAgregarUsuarios_Click;
            btnEstadoUsuarios.Click += btnEstadoUsuarios_Click;
        }

        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            SolicitarAgregarUsuario?.Invoke(this, EventArgs.Empty);
        }

        private void btnEstadoUsuarios_Click(object sender, EventArgs e)
        {
            SolicitarEstadoUsuarios?.Invoke(this, EventArgs.Empty);
        }
    }
}
