using System;
using System.Data.OleDb;
using prySampaolesiClaseBD;

namespace prySampaolesiERP
{
    internal class clsAuditoria
    {
        public static void RegistrarInicioSesion(clsConexion conexion, string usuario, string cargo)
        {
            Registrar(conexion, usuario, cargo, "Inicio de sesion");
        }

        public static void RegistrarCierreSesion(clsConexion conexion, string usuario, string cargo)
        {
            Registrar(conexion, usuario, cargo, "Cierre de sesion");
        }

        public static void RegistrarAccion(clsConexion conexion, string usuario, string cargo, string accion)
        {
            Registrar(conexion, usuario, cargo, accion);
        }

        private static void Registrar(clsConexion conexion, string usuario, string cargo, string accion)
        {
            OleDbParameter[] parametros = new OleDbParameter[]
            {
                new OleDbParameter("@usuario", OleDbType.VarWChar) { Value = usuario ?? "" },
                new OleDbParameter("@cargo", OleDbType.VarWChar) { Value = cargo ?? "" },
                new OleDbParameter("@accion", OleDbType.VarWChar) { Value = accion ?? "" }
            };
            conexion.EjecutarComando("INSERT INTO Auditoria ([Usuario], [Cargo], [FechaYHora], [Accion]) VALUES (?, ?, Now(), ?)", parametros);
        }
    }
}
