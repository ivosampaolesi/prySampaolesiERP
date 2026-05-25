namespace prySampaolesiERP
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.stpEstado = new System.Windows.Forms.StatusStrip();
            this.stplblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.stpEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpEstado
            // 
            this.stpEstado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stpEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stplblEstado});
            this.stpEstado.Location = new System.Drawing.Point(0, 415);
            this.stpEstado.Name = "stpEstado";
            this.stpEstado.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.stpEstado.Size = new System.Drawing.Size(852, 26);
            this.stpEstado.TabIndex = 0;
            this.stpEstado.Text = "statusStrip1";
            // 
            // stplblEstado
            // 
            this.stplblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stplblEstado.Name = "stplblEstado";
            this.stplblEstado.Size = new System.Drawing.Size(160, 20);
            this.stplblEstado.Text = "toolStripStatusLabel1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.Location = new System.Drawing.Point(409, 17);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(429, 25);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaHora.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFechaHora.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaHora.Location = new System.Drawing.Point(684, 42);
            this.lblFechaHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(155, 25);
            this.lblFechaHora.TabIndex = 2;
            this.lblFechaHora.Text = "Fecha/Hora";
            this.lblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 441);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.stpEstado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main ERP";
            this.stpEstado.ResumeLayout(false);
            this.stpEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stpEstado;
        private System.Windows.Forms.ToolStripStatusLabel stplblEstado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFechaHora;
    }
}

