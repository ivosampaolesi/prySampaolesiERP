using System;
using System.Collections.Generic;
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
            Application.Run(new frmDatosUsuario());
        }
    }
}

