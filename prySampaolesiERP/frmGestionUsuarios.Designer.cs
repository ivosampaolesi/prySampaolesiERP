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
            this.btnEditarUsuarios = new System.Windows.Forms.Button();
            this.btnDesactivarUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarUsuarios
            // 
            this.btnAgregarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAgregarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnAgregarUsuarios.Location = new System.Drawing.Point(90, 30);
            this.btnAgregarUsuarios.Name = "btnAgregarUsuarios";
            this.btnAgregarUsuarios.Size = new System.Drawing.Size(240, 40);
            this.btnAgregarUsuarios.TabIndex = 0;
            this.btnAgregarUsuarios.Text = "Agregar Usuarios";
            this.btnAgregarUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnEditarUsuarios
            // 
            this.btnEditarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnEditarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnEditarUsuarios.Location = new System.Drawing.Point(90, 85);
            this.btnEditarUsuarios.Name = "btnEditarUsuarios";
            this.btnEditarUsuarios.Size = new System.Drawing.Size(240, 40);
            this.btnEditarUsuarios.TabIndex = 1;
            this.btnEditarUsuarios.Text = "Editar Usuarios";
            this.btnEditarUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnDesactivarUsuarios
            // 
            this.btnDesactivarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDesactivarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivarUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesactivarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnDesactivarUsuarios.Location = new System.Drawing.Point(90, 140);
            this.btnDesactivarUsuarios.Name = "btnDesactivarUsuarios";
            this.btnDesactivarUsuarios.Size = new System.Drawing.Size(240, 40);
            this.btnDesactivarUsuarios.TabIndex = 2;
            this.btnDesactivarUsuarios.Text = "Desactivar Usuarios";
            this.btnDesactivarUsuarios.UseVisualStyleBackColor = false;
            // 
            // frmGestionUsuarios
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(420, 220);
            this.Controls.Add(this.btnAgregarUsuarios);
            this.Controls.Add(this.btnEditarUsuarios);
            this.Controls.Add(this.btnDesactivarUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionUsuarios";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnAgregarUsuarios;
        private System.Windows.Forms.Button btnEditarUsuarios;
        private System.Windows.Forms.Button btnDesactivarUsuarios;
    }
}
