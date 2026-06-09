$file = "prySampaolesiERP\Formularios\frmDatosUsuario.cs"
$content = [System.IO.File]::ReadAllText($file, [System.Text.Encoding]::Default)

# 1. Constructor: add event handlers for domicilio buttons
$content = $content.Replace(
    "btnQuitarRed.Click += btnQuitarRed_Click;`r`n            btnGuardar.Click += btnGuardar_Click;",
    "btnQuitarRed.Click += btnQuitarRed_Click;`r`n            btnAgregarDomicilio.Click += btnAgregarDomicilio_Click;`r`n            btnQuitarDomicilio.Click += btnQuitarDomicilio_Click;`r`n            btnGuardar.Click += btnGuardar_Click;"
)

# 2. Load: add CargarDomiciliosUsuario call
$content = $content.Replace(
    "CargarRedesUsuario();`r`n                estadoOriginal = ObtenerEstadoActual();",
    "CargarRedesUsuario();`r`n                CargarDomiciliosUsuario();`r`n                estadoOriginal = ObtenerEstadoActual();"
)

# 3. CargarDatosUsuario: remove Direccion from SELECT query
$content = $content.Replace(
    """Usuario.DNI, DatosPersonales.Direccion, DatosPersonales.Localidad, """,
    """Usuario.DNI, DatosPersonales.Localidad, """
)

# 4. CargarDatosUsuario: remove txtDireccion.Text assignment
$content = $content.Replace(
    "txtDireccion.Text = ObtenerTexto(fila, ""Direccion"");`r`n                txtGEO.Text",
    "txtGEO.Text"
)

# 5. GuardarDatosUsuario UPDATE: remove Direccion from SET clause
$content = $content.Replace(
    """UPDATE DatosPersonales SET Direccion = ?, Localidad = ?, Provincia = ?, Telefono = ?, Activo = ?, Geo = ? WHERE IdUsuario = ?""",
    """UPDATE DatosPersonales SET Localidad = ?, Provincia = ?, Telefono = ?, Activo = ?, Geo = ? WHERE IdUsuario = ?"""
)

# 6. GuardarDatosUsuario UPDATE: remove @direccion parameter
$content = $content.Replace(
    "new OleDbParameter(""@direccion"", OleDbType.VarWChar) { Value = txtDireccion.Text.Trim() },`r`n                        new OleDbParameter(""@localidad""",
    "new OleDbParameter(""@localidad"""
)

# 7. GuardarDatosUsuario INSERT: remove Direccion from column list and values
$content = $content.Replace(
    """INSERT INTO DatosPersonales (IdUsuario, Direccion, Localidad, Provincia, Telefono, Activo, Geo) VALUES (?, ?, ?, ?, ?, ?, ?)""",
    """INSERT INTO DatosPersonales (IdUsuario, Localidad, Provincia, Telefono, Activo, Geo) VALUES (?, ?, ?, ?, ?, ?)"""
)

# 8. GuardarDatosUsuario INSERT: remove @direccion parameter
$content = $content.Replace(
    "new OleDbParameter(""@direccion"", OleDbType.VarWChar) { Value = txtDireccion.Text.Trim() },`r`n                    new OleDbParameter(""@localidad""",
    "new OleDbParameter(""@localidad"""
)

# 9. btnGuardar_Click: add domicilio validation and GuardarDomiciliosUsuario call
$content = $content.Replace(
    "if (GuardarDatosUsuario() && GuardarRedesUsuario())",
    "if (lstDomicilios.Items.Count == 0)`r`n            {`r`n                MessageBox.Show(""Debe ingresar al menos un domicilio."", ""Validacion"", MessageBoxButtons.OK, MessageBoxIcon.Warning);`r`n                return;`r`n            }`r`n            if (GuardarDatosUsuario() && GuardarRedesUsuario() && GuardarDomiciliosUsuario())"
)

# 10. ObtenerEstadoActual: replace txtDireccion with lstDomicilios items
$content = $content.Replace(
    "valores.Append(txtDireccion.Text).Append(""|"");`r`n            valores.Append(txtGEO.Text)",
    "foreach (ListViewItem domItem in lstDomicilios.Items)`r`n                valores.Append(domItem.Text).Append(""|"");`r`n            valores.Append(txtGEO.Text)"
)

# 11. Add new methods before GuardarRedesUsuario method
$newMethods = @"
        private void CargarDomiciliosUsuario()
        {
            lstDomicilios.Items.Clear();

            OleDbParameter[] parametros = new OleDbParameter[]
            {
                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
            };

            DataTable dt = conexion.EjecutarConsulta(
                "SELECT Domicilio FROM Domicilios WHERE IdUsuario = ?",
                parametros);

            if (dt == null)
                return;

            foreach (DataRow fila in dt.Rows)
            {
                lstDomicilios.Items.Add(fila["Domicilio"].ToString());
            }
        }

        private void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            string domicilio = txtDomicilio.Text.Trim();
            if (domicilio == "")
            {
                MessageBox.Show("Ingrese un domicilio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in lstDomicilios.Items)
            {
                if (item.Text.Equals(domicilio, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El domicilio ya fue ingresado.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            lstDomicilios.Items.Add(domicilio);
            txtDomicilio.Clear();
        }

        private void btnQuitarDomicilio_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstDomicilios.SelectedItems)
            {
                lstDomicilios.Items.Remove(item);
            }
        }

        private bool GuardarDomiciliosUsuario()
        {
            OleDbParameter[] parametrosEliminar = new OleDbParameter[]
            {
                new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID }
            };

            if (!conexion.EjecutarComando("DELETE FROM Domicilios WHERE IdUsuario = ?", parametrosEliminar))
                return false;

            foreach (ListViewItem item in lstDomicilios.Items)
            {
                OleDbParameter[] parametrosInsertar = new OleDbParameter[]
                {
                    new OleDbParameter("@idUsuario", OleDbType.Integer) { Value = Program.UsuarioID },
                    new OleDbParameter("@domicilio", OleDbType.VarWChar) { Value = item.Text }
                };

                if (!conexion.EjecutarComando(
                    "INSERT INTO Domicilios (IdUsuario, Domicilio) VALUES (?, ?)",
                    parametrosInsertar))
                {
                    return false;
                }
            }

            return true;
        }

"@

$content = $content.Replace(
    "        private bool GuardarRedesUsuario()",
    $newMethods + "        private bool GuardarRedesUsuario()"
)

[System.IO.File]::WriteAllText($file, $content, [System.Text.Encoding]::Default)
Write-Host "frmDatosUsuario.cs updated successfully"
