$file = "prySampaolesiERP\Formularios\frmMain.cs"
$content = [System.IO.File]::ReadAllText($file, [System.Text.Encoding]::Default)

# 1. TieneDatosPersonalesIncompletos: remove Direccion from SELECT
$content = $content.Replace(
    """SELECT Usuario.Nombre, Usuario.Apellido, Usuario.Mail, Usuario.DNI, "" +`r`n                ""DatosPersonales.Direccion, DatosPersonales.Localidad, DatosPersonales.Provincia, "" +",
    """SELECT Usuario.Nombre, Usuario.Apellido, Usuario.Mail, Usuario.DNI, "" +`r`n                ""DatosPersonales.Localidad, DatosPersonales.Provincia, "" +"
)

# 2. TieneDatosPersonalesIncompletos: remove Direccion from columnasObligatorias
$content = $content.Replace(
    """Nombre"", ""Apellido"", ""Mail"", ""DNI"", ""Direccion"", ""Localidad"", ""Provincia"", ""Telefono"", ""Geo""",
    """Nombre"", ""Apellido"", ""Mail"", ""DNI"", ""Localidad"", ""Provincia"", ""Telefono"", ""Geo"""
)

# 3. TieneDatosPersonalesIncompletos: add domicilios check alongside redes check
# After the redes check, the method returns cantidadRedes == 0
# We need to also check domicilios
$content = $content.Replace(
    "int cantidadRedes = dtRedes != null && dtRedes.Rows.Count > 0 ? Convert.ToInt32(dtRedes.Rows[0][""Cantidad""]) : 0;`r`n            return cantidadRedes == 0;`r`n        }",
    "int cantidadRedes = dtRedes != null && dtRedes.Rows.Count > 0 ? Convert.ToInt32(dtRedes.Rows[0][""Cantidad""]) : 0;`r`n            if (cantidadRedes == 0)`r`n                return true;`r`n`r`n            DataTable dtDomicilios = conexion.EjecutarConsulta(`r`n                ""SELECT COUNT(*) AS Cantidad FROM Domicilios WHERE IdUsuario = ?"",`r`n                new OleDbParameter[]`r`n                {`r`n                    new OleDbParameter(""@idUsuario"", OleDbType.Integer) { Value = Program.UsuarioID }`r`n                });`r`n`r`n            int cantidadDomicilios = dtDomicilios != null && dtDomicilios.Rows.Count > 0 ? Convert.ToInt32(dtDomicilios.Rows[0][""Cantidad""]) : 0;`r`n            return cantidadDomicilios == 0;`r`n        }"
)

# 4. ObtenerCamposFaltantes: remove Direccion from SELECT (second occurrence)
# This is the second SELECT with Direccion - need to be careful to target the right one
# The second occurrence is in ObtenerCamposFaltantes
$content = $content.Replace(
    """SELECT Usuario.Nombre, Usuario.Apellido, Usuario.Mail, Usuario.DNI, "" +`r`n                ""DatosPersonales.Localidad, DatosPersonales.Provincia, "" +",
    """SELECT Usuario.Nombre, Usuario.Apellido, Usuario.Mail, Usuario.DNI, "" +`r`n                ""DatosPersonales.Localidad, DatosPersonales.Provincia, "" +"
)

# Wait - the first replacement already changed BOTH occurrences. Let me check.
# Actually the second one in ObtenerCamposFaltantes still has the original text since 
# step 1 only replaced the first occurrence if there were differences.
# Let me check if there's still a reference to DatosPersonales.Direccion
if ($content.Contains("DatosPersonales.Direccion")) {
    $content = $content.Replace(
        "DatosPersonales.Direccion, DatosPersonales.Localidad",
        "DatosPersonales.Localidad"
    )
    Write-Host "Removed remaining DatosPersonales.Direccion reference"
}

# 5. ObtenerCamposFaltantes: remove Direccion from dictionary
# The dictionary entry looks like { "Direccion", "Dirección" } but with encoded chars
# Let me find and remove it by looking for the pattern
$lines = $content.Split("`r`n")
$result = New-Object System.Collections.Generic.List[string]
for ($i = 0; $i -lt $lines.Count; $i++) {
    # Skip lines containing "Direccion" in the dictionary section (but not SQL)
    if ($lines[$i].Contains("""Direccion""") -and $lines[$i].Contains("Direcci")) {
        continue
    }
    $result.Add($lines[$i])
}
$content = [string]::Join("`r`n", $result.ToArray())

# 6. ObtenerCamposFaltantes: add Domicilios check after redes check
$content = $content.Replace(
    "if (cantidadRedes == 0)`r`n            {`r`n                faltantes.Add(""Redes Sociales"");`r`n            }`r`n`r`n            return faltantes;",
    "if (cantidadRedes == 0)`r`n            {`r`n                faltantes.Add(""Redes Sociales"");`r`n            }`r`n`r`n            DataTable dtDomicilios = conexion.EjecutarConsulta(`r`n                ""SELECT COUNT(*) AS Cantidad FROM Domicilios WHERE IdUsuario = ?"",`r`n                new OleDbParameter[]`r`n                {`r`n                    new OleDbParameter(""@idUsuario"", OleDbType.Integer) { Value = Program.UsuarioID }`r`n                });`r`n`r`n            int cantidadDomicilios = dtDomicilios != null && dtDomicilios.Rows.Count > 0 ? Convert.ToInt32(dtDomicilios.Rows[0][""Cantidad""]) : 0;`r`n            if (cantidadDomicilios == 0)`r`n            {`r`n                faltantes.Add(""Domicilio"");`r`n            }`r`n`r`n            return faltantes;"
)

[System.IO.File]::WriteAllText($file, $content, [System.Text.Encoding]::Default)
Write-Host "frmMain.cs updated successfully"
