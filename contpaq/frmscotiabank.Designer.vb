<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmscotiabank
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdaceptar = New System.Windows.Forms.Button()
        Me.NudFilaI = New System.Windows.Forms.NumericUpDown()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsucursal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcuentacargo = New System.Windows.Forms.TextBox()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtempresa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbocliente = New System.Windows.Forms.ComboBox()
        CType(Me.NudFilaI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Location = New System.Drawing.Point(326, 94)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(138, 37)
        Me.cmdcancelar.TabIndex = 49
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'cmdaceptar
        '
        Me.cmdaceptar.Location = New System.Drawing.Point(164, 94)
        Me.cmdaceptar.Name = "cmdaceptar"
        Me.cmdaceptar.Size = New System.Drawing.Size(138, 37)
        Me.cmdaceptar.TabIndex = 48
        Me.cmdaceptar.Text = "Aceptar"
        Me.cmdaceptar.UseVisualStyleBackColor = True
        '
        'NudFilaI
        '
        Me.NudFilaI.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFilaI.Location = New System.Drawing.Point(557, 70)
        Me.NudFilaI.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NudFilaI.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudFilaI.Name = "NudFilaI"
        Me.NudFilaI.Size = New System.Drawing.Size(53, 22)
        Me.NudFilaI.TabIndex = 47
        Me.NudFilaI.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(416, 70)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(91, 20)
        Me.dtpFecha.TabIndex = 46
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(554, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Secuencial"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(413, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Fecha de pago"
        '
        'txtsucursal
        '
        Me.txtsucursal.Enabled = False
        Me.txtsucursal.Location = New System.Drawing.Point(206, 70)
        Me.txtsucursal.Name = "txtsucursal"
        Me.txtsucursal.Size = New System.Drawing.Size(198, 20)
        Me.txtsucursal.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(203, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Concepto de pago"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "No de Cuenta Cargo"
        '
        'txtcuentacargo
        '
        Me.txtcuentacargo.Enabled = False
        Me.txtcuentacargo.Location = New System.Drawing.Point(16, 70)
        Me.txtcuentacargo.Name = "txtcuentacargo"
        Me.txtcuentacargo.Size = New System.Drawing.Size(172, 20)
        Me.txtcuentacargo.TabIndex = 40
        '
        'txtdescripcion
        '
        Me.txtdescripcion.Enabled = False
        Me.txtdescripcion.Location = New System.Drawing.Point(416, 21)
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(198, 20)
        Me.txtdescripcion.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(413, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Tipo Archivo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(203, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Referencia Empresa"
        '
        'txtempresa
        '
        Me.txtempresa.Enabled = False
        Me.txtempresa.Location = New System.Drawing.Point(206, 22)
        Me.txtempresa.Name = "txtempresa"
        Me.txtempresa.Size = New System.Drawing.Size(198, 20)
        Me.txtempresa.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "No Cliente"
        '
        'cbocliente
        '
        Me.cbocliente.FormattingEnabled = True
        Me.cbocliente.Location = New System.Drawing.Point(16, 21)
        Me.cbocliente.Name = "cbocliente"
        Me.cbocliente.Size = New System.Drawing.Size(172, 21)
        Me.cbocliente.TabIndex = 34
        '
        'frmscotiabank
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(626, 137)
        Me.Controls.Add(Me.cmdcancelar)
        Me.Controls.Add(Me.cmdaceptar)
        Me.Controls.Add(Me.NudFilaI)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsucursal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcuentacargo)
        Me.Controls.Add(Me.txtdescripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtempresa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbocliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmscotiabank"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione los encabezados para el layout"
        CType(Me.NudFilaI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdcancelar As Button
    Friend WithEvents cmdaceptar As Button
    Friend WithEvents NudFilaI As NumericUpDown
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsucursal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtcuentacargo As TextBox
    Friend WithEvents txtdescripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtempresa As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbocliente As ComboBox
End Class
