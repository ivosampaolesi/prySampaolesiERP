$file = "prySampaolesiERP\Formularios\frmDatosUsuario.Designer.cs"
$content = [System.IO.File]::ReadAllText($file, [System.Text.Encoding]::Default)

# 1. Replace object declarations: label5 + txtDireccion -> new domicilio controls
$content = $content.Replace(
    "this.label5 = new System.Windows.Forms.Label();`r`n            this.txtDireccion = new System.Windows.Forms.TextBox();",
    "this.lblDomicilio = new System.Windows.Forms.Label();`r`n            this.txtDomicilio = new System.Windows.Forms.TextBox();`r`n            this.btnAgregarDomicilio = new System.Windows.Forms.Button();`r`n            this.btnQuitarDomicilio = new System.Windows.Forms.Button();`r`n            this.lstDomicilios = new System.Windows.Forms.ListView();`r`n            this.colDomicilio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));"
)

# 2. Move label4 (GEO) position down
$content = $content.Replace(
    "this.label4.Location = new System.Drawing.Point(20, 172);",
    "this.label4.Location = new System.Drawing.Point(20, 322);"
)

# 3. Move txtGEO position down
$content = $content.Replace(
    "this.txtGEO.Location = new System.Drawing.Point(97, 169);",
    "this.txtGEO.Location = new System.Drawing.Point(97, 318);"
)

# 4. Replace groupBox1 Controls - remove txtDireccion and label5, add new controls
$content = $content.Replace(
    "this.groupBox1.Controls.Add(this.txtDireccion);`r`n            this.groupBox1.Controls.Add(this.label5);",
    "this.groupBox1.Controls.Add(this.btnQuitarDomicilio);`r`n            this.groupBox1.Controls.Add(this.lstDomicilios);`r`n            this.groupBox1.Controls.Add(this.btnAgregarDomicilio);`r`n            this.groupBox1.Controls.Add(this.txtDomicilio);`r`n            this.groupBox1.Controls.Add(this.lblDomicilio);"
)

# 5. Update groupBox1 size (was 271, 219 -> 271, 360)
$content = $content.Replace(
    "this.groupBox1.Size = new System.Drawing.Size(271, 219);",
    "this.groupBox1.Size = new System.Drawing.Size(271, 360);"
)

# 6. Update btnGuardar location (move down)
$content = $content.Replace(
    "this.btnGuardar.Location = new System.Drawing.Point(463, 430);",
    "this.btnGuardar.Location = new System.Drawing.Point(463, 575);"
)

# 7. Update form ClientSize (was 581, 474 -> 581, 615)
$content = $content.Replace(
    "this.ClientSize = new System.Drawing.Size(581, 474);",
    "this.ClientSize = new System.Drawing.Size(581, 615);"
)

# 8. Replace field declarations: label5 + txtDireccion -> new fields
$content = $content.Replace(
    "private System.Windows.Forms.Label label5;`r`n        private System.Windows.Forms.TextBox txtDireccion;",
    "private System.Windows.Forms.Label lblDomicilio;`r`n        private System.Windows.Forms.TextBox txtDomicilio;`r`n        private System.Windows.Forms.Button btnAgregarDomicilio;`r`n        private System.Windows.Forms.Button btnQuitarDomicilio;`r`n        private System.Windows.Forms.ListView lstDomicilios;`r`n        private System.Windows.Forms.ColumnHeader colDomicilio;"
)

# 9. Now handle the label5/txtDireccion initialization blocks (lines ~143-164)
# We need to work line by line for this part since it contains encoded chars
$lines = $content.Split("`r`n")
$result = New-Object System.Collections.Generic.List[string]
$skipUntil = -1
$inserted = $false

for ($i = 0; $i -lt $lines.Count; $i++) {
    if ($skipUntil -ge 0 -and $i -le $skipUntil) { continue }
    
    # Find "// label5" comment line (the section starts 1 line before with "// ")
    if ($lines[$i].Trim() -eq "// label5" -and -not $inserted) {
        # Skip from line i-1 (the "// " separator) to the end of txtDireccion section
        # Remove the "// " line we already added
        $result.RemoveAt($result.Count - 1)
        
        # Find end of txtDireccion block (look for next "// " separator that starts groupBox1)
        $endIdx = $i
        for ($j = $i + 1; $j -lt $lines.Count; $j++) {
            if ($lines[$j].Contains("this.txtDomicilio.TabIndex") -or $lines[$j].Contains("this.txtDireccion.TabIndex")) {
                $endIdx = $j
                break
            }
        }
        $skipUntil = $endIdx
        $inserted = $true
        
        # Insert new control initialization blocks
        $result.Add("            // ")
        $result.Add("            // lblDomicilio")
        $result.Add("            // ")
        $result.Add("            this.lblDomicilio.AutoSize = true;")
        $result.Add('            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));')
        $result.Add("            this.lblDomicilio.Location = new System.Drawing.Point(9, 122);")
        $result.Add("            this.lblDomicilio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);")
        $result.Add('            this.lblDomicilio.Name = "lblDomicilio";')
        $result.Add("            this.lblDomicilio.Size = new System.Drawing.Size(75, 17);")
        $result.Add("            this.lblDomicilio.TabIndex = 7;")
        $result.Add('            this.lblDomicilio.Text = "Domicilio:";')
        $result.Add("            // ")
        $result.Add("            // txtDomicilio")
        $result.Add("            // ")
        $result.Add("            this.txtDomicilio.Location = new System.Drawing.Point(97, 118);")
        $result.Add("            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(4);")
        $result.Add('            this.txtDomicilio.Name = "txtDomicilio";')
        $result.Add("            this.txtDomicilio.Size = new System.Drawing.Size(160, 25);")
        $result.Add("            this.txtDomicilio.TabIndex = 6;")
        $result.Add("            // ")
        $result.Add("            // btnAgregarDomicilio")
        $result.Add("            // ")
        $result.Add('            this.btnAgregarDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));')
        $result.Add('            this.btnAgregarDomicilio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));')
        $result.Add("            this.btnAgregarDomicilio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;")
        $result.Add("            this.btnAgregarDomicilio.Location = new System.Drawing.Point(97, 148);")
        $result.Add('            this.btnAgregarDomicilio.Name = "btnAgregarDomicilio";')
        $result.Add("            this.btnAgregarDomicilio.Size = new System.Drawing.Size(160, 28);")
        $result.Add("            this.btnAgregarDomicilio.TabIndex = 24;")
        $result.Add('            this.btnAgregarDomicilio.Text = "Agregar domicilio";')
        $result.Add("            this.btnAgregarDomicilio.UseVisualStyleBackColor = false;")
        $result.Add("            // ")
        $result.Add("            // lstDomicilios")
        $result.Add("            // ")
        $result.Add("            this.lstDomicilios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {")
        $result.Add("            this.colDomicilio});")
        $result.Add("            this.lstDomicilios.FullRowSelect = true;")
        $result.Add("            this.lstDomicilios.GridLines = true;")
        $result.Add("            this.lstDomicilios.HideSelection = false;")
        $result.Add("            this.lstDomicilios.Location = new System.Drawing.Point(14, 182);")
        $result.Add("            this.lstDomicilios.MultiSelect = false;")
        $result.Add('            this.lstDomicilios.Name = "lstDomicilios";')
        $result.Add("            this.lstDomicilios.Size = new System.Drawing.Size(243, 90);")
        $result.Add("            this.lstDomicilios.TabIndex = 25;")
        $result.Add("            this.lstDomicilios.UseCompatibleStateImageBehavior = false;")
        $result.Add("            this.lstDomicilios.View = System.Windows.Forms.View.Details;")
        $result.Add("            // ")
        $result.Add("            // colDomicilio")
        $result.Add("            // ")
        $result.Add('            this.colDomicilio.Text = "Domicilio";')
        $result.Add("            this.colDomicilio.Width = 230;")
        $result.Add("            // ")
        $result.Add("            // btnQuitarDomicilio")
        $result.Add("            // ")
        $result.Add('            this.btnQuitarDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));')
        $result.Add("            this.btnQuitarDomicilio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;")
        $result.Add("            this.btnQuitarDomicilio.Location = new System.Drawing.Point(97, 278);")
        $result.Add('            this.btnQuitarDomicilio.Name = "btnQuitarDomicilio";')
        $result.Add("            this.btnQuitarDomicilio.Size = new System.Drawing.Size(160, 28);")
        $result.Add("            this.btnQuitarDomicilio.TabIndex = 26;")
        $result.Add('            this.btnQuitarDomicilio.Text = "Quitar domicilio";')
        $result.Add("            this.btnQuitarDomicilio.UseVisualStyleBackColor = false;")
        continue
    }
    
    $result.Add($lines[$i])
}

$finalContent = [string]::Join("`r`n", $result.ToArray())
[System.IO.File]::WriteAllText($file, $finalContent, [System.Text.Encoding]::Default)
Write-Host "Designer.cs updated successfully"
