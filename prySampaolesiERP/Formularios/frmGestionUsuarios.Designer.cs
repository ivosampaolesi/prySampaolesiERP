namespace prySampaolesiERP
{
    partial class frmGestionUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAgregarUsuarios = new System.Windows.Forms.Button();
            this.btnEstadoUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarUsuarios
            // 
            this.btnAgregarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAgregarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnAgregarUsuarios.Location = new System.Drawing.Point(90, 55);
            this.btnAgregarUsuarios.Name = "btnAgregarUsuarios";
            this.btnAgregarUsuarios.Size = new System.Drawing.Size(240, 40);
            this.btnAgregarUsuarios.TabIndex = 0;
            this.btnAgregarUsuarios.Text = "Agregar Usuarios";
            this.btnAgregarUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnEstadoUsuarios
            // 
            this.btnEstadoUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnEstadoUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEstadoUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnEstadoUsuarios.Location = new System.Drawing.Point(90, 127);
            this.btnEstadoUsuarios.Name = "btnEstadoUsuarios";
            this.btnEstadoUsuarios.Size = new System.Drawing.Size(240, 40);
            this.btnEstadoUsuarios.TabIndex = 2;
            this.btnEstadoUsuarios.Text = "Estado de Usuarios";
            this.btnEstadoUsuarios.UseVisualStyleBackColor = false;
            // 
            // frmGestionUsuarios
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(420, 220);
            this.Controls.Add(this.btnAgregarUsuarios);
            this.Controls.Add(this.btnEstadoUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionUsuarios";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnAgregarUsuarios;
        private System.Windows.Forms.Button btnEstadoUsuarios;
    }
}
