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
                    if (c is TextBox txt && txt.Tag?.ToString() == "Error")
                    {
                        ControlPaint.DrawBorder(e.Graphics, new Rectangle(txt.Left - 1, txt.Top - 1, txt.Width + 2, txt.Height + 2), Color.Red, ButtonBorderStyle.Solid);
                    }
                }
            };

            foreach (Control c in container.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.TextChanged += (s, e) =>
                    {
                        if (txt.Tag?.ToString() == "Error")
                        {
                            txt.Tag = null;
                            txt.Parent.Invalidate();
                        }
                    };
                }
                else if (c.HasChildren)
                {
                    InicializarValidadoresInternal(c);
                }
            }
        }

        public static void PintarError(params TextBox[] textboxes)
        {
            foreach (var txt in textboxes)
            {
                txt.Tag = "Error";
                txt.Parent.Invalidate();
            }
        }
    }
}

