using System;
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
            usuario = (usuario ?? "").Replace("'", "''");
            cargo = (cargo ?? "").Replace("'", "''");
            accion = (accion ?? "").Replace("'", "''");
            conexion.EjecutarComando($"INSERT INTO Auditoria ([Usuario], [Cargo], [FechaYHora], [Accion]) VALUES ('{usuario}', '{cargo}', Now(), '{accion}')");
        }
    }
}
