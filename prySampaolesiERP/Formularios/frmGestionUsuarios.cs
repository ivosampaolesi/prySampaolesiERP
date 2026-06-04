using System;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    public partial class frmGestionUsuarios : Form
    {
        public event EventHandler SolicitarAgregarUsuario;

        public frmGestionUsuarios()
        {
            InitializeComponent();
            btnAgregarUsuarios.Click += btnAgregarUsuarios_Click;
        }

        private void btnAgregarUsuarios_Click(object sender, EventArgs e)
        {
            SolicitarAgregarUsuario?.Invoke(this, EventArgs.Empty);
        }
    }
}
