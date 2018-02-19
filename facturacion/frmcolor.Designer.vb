<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmcolor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlcolores = New System.Windows.Forms.Panel()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbocolor = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.cmdabonos = New System.Windows.Forms.Button()
        Me.pnlcolores.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlcolores
        '
        Me.pnlcolores.Controls.Add(Me.dtpfecha)
        Me.pnlcolores.Controls.Add(Me.Label1)
        Me.pnlcolores.Controls.Add(Me.Label17)
        Me.pnlcolores.Controls.Add(Me.cbocolor)
        Me.pnlcolores.Controls.Add(Me.Label16)
        Me.pnlcolores.Location = New System.Drawing.Point(12, 12)
        Me.pnlcolores.Name = "pnlcolores"
        Me.pnlcolores.Size = New System.Drawing.Size(196, 153)
        Me.pnlcolores.TabIndex = 44
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(7, 103)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(96, 20)
        Me.dtpfecha.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 17)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Fecha para abono automatico"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(179, 31)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Amarillo-Pendiente, Verde-Pagado, Rojo-Cancelado"
        '
        'cbocolor
        '
        Me.cbocolor.FormattingEnabled = True
        Me.cbocolor.Items.AddRange(New Object() {"Ninguno", "Amarillo", "Verde", "Rojo", "Fiusha", "Azul", "Naranja"})
        Me.cbocolor.Location = New System.Drawing.Point(3, 24)
        Me.cbocolor.Name = "cbocolor"
        Me.cbocolor.Size = New System.Drawing.Size(167, 21)
        Me.cbocolor.TabIndex = 46
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 2)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 19)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Colores"
        '
        'cmdguardar
        '
        Me.cmdguardar.Location = New System.Drawing.Point(19, 171)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(75, 23)
        Me.cmdguardar.TabIndex = 45
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'cmdabonos
        '
        Me.cmdabonos.Location = New System.Drawing.Point(119, 172)
        Me.cmdabonos.Name = "cmdabonos"
        Me.cmdabonos.Size = New System.Drawing.Size(75, 23)
        Me.cmdabonos.TabIndex = 46
        Me.cmdabonos.Text = "Abonos"
        Me.cmdabonos.UseVisualStyleBackColor = True
        '
        'frmcolor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(223, 201)
        Me.Controls.Add(Me.cmdabonos)
        Me.Controls.Add(Me.cmdguardar)
        Me.Controls.Add(Me.pnlcolores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmcolor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmcolor"
        Me.pnlcolores.ResumeLayout(False)
        Me.pnlcolores.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlcolores As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents cbocolor As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmdguardar As Button
    Friend WithEvents cmdabonos As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfecha As DateTimePicker
End Class
