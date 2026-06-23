using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySampaolesiERP
{
    internal static class Program
    {
        public static int UsuarioID { get; set; }
        public static string UsuarioMail { get; set; }
        public static string UsuarioPerfil { get; set; }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }

    public static class ValidadorUI
    {
        public static void InicializarValidadores(Form form)
        {
            InicializarValidadoresInternal(form);
        }

        private static void InicializarValidadoresInternal(Control container)
        {
            container.Paint += (s, e) =>
            {
                foreach (Control c in container.Controls)
                {
                    if ((c is TextBox || c is ComboBox) && c.Tag?.ToString() == "Error")
                    {
                        ControlPaint.DrawBorder(e.Graphics, new Rectangle(c.Left - 1, c.Top - 1, c.Width + 2, c.Height + 2), Color.Red, ButtonBorderStyle.Solid);
                    }
                }
            };

            foreach (Control c in container.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.TextChanged += (s, e) => { LimpiarError(txt); };
                }
                else if (c is ComboBox cmb)
                {
                    cmb.SelectedIndexChanged += (s, e) => { LimpiarError(cmb); };
                    cmb.TextChanged += (s, e) => { LimpiarError(cmb); };
                }
                else if (c.HasChildren)
                {
                    InicializarValidadoresInternal(c);
                }
            }
        }

        private static void LimpiarError(Control c)
        {
            if (c.Tag?.ToString() == "Error")
            {
                c.Tag = null;
                c.Parent.Invalidate();
            }
        }

        public static void PintarError(params Control[] controls)
        {
            foreach (var c in controls)
            {
                c.Tag = "Error";
                c.Parent.Invalidate();
            }
        }
    }
}

