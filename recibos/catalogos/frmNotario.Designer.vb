<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotario))
        Me.pnlEmpresa = New System.Windows.Forms.Panel()
        Me.dtRegistroActa = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtLugarRPP = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.txtresidencia = New System.Windows.Forms.TextBox()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.pnlEmpresa.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEmpresa
        '
        Me.pnlEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlEmpresa.Controls.Add(Me.dtRegistroActa)
        Me.pnlEmpresa.Controls.Add(Me.Label27)
        Me.pnlEmpresa.Controls.Add(Me.txtLugarRPP)
        Me.pnlEmpresa.Controls.Add(Me.Label18)
        Me.pnlEmpresa.Controls.Add(Me.txtFolio)
        Me.pnlEmpresa.Controls.Add(Me.txtresidencia)
        Me.pnlEmpresa.Controls.Add(Me.txtnumero)
        Me.pnlEmpresa.Controls.Add(Me.txtnombre)
        Me.pnlEmpresa.Controls.Add(Me.Label7)
        Me.pnlEmpresa.Controls.Add(Me.Label5)
        Me.pnlEmpresa.Controls.Add(Me.Label4)
        Me.pnlEmpresa.Controls.Add(Me.Label1)
        Me.pnlEmpresa.Enabled = False
        Me.pnlEmpresa.Location = New System.Drawing.Point(6, 14)
        Me.pnlEmpresa.Name = "pnlEmpresa"
        Me.pnlEmpresa.Size = New System.Drawing.Size(476, 297)
        Me.pnlEmpresa.TabIndex = 40
        '
        'dtRegistroActa
        '
        Me.dtRegistroActa.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtRegistroActa.Location = New System.Drawing.Point(266, 216)
        Me.dtRegistroActa.Name = "dtRegistroActa"
        Me.dtRegistroActa.Size = New System.Drawing.Size(96, 27)
        Me.dtRegistroActa.TabIndex = 57
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(14, 219)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(246, 19)
        Me.Label27.TabIndex = 56
        Me.Label27.Text = "Fecha de registro del acta en el RPP:"
        '
        'txtLugarRPP
        '
        Me.txtLugarRPP.Location = New System.Drawing.Point(142, 253)
        Me.txtLugarRPP.MaxLength = 100
        Me.txtLugarRPP.Name = "txtLugarRPP"
        Me.txtLugarRPP.Size = New System.Drawing.Size(305, 27)
        Me.txtLugarRPP.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 256)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 19)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Lugar del RPP y C:"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(123, 163)
        Me.txtFolio.MaxLength = 100
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(324, 27)
        Me.txtFolio.TabIndex = 10
        '
        'txtresidencia
        '
        Me.txtresidencia.Location = New System.Drawing.Point(130, 120)
        Me.txtresidencia.Name = "txtresidencia"
        Me.txtresidencia.Size = New System.Drawing.Size(317, 27)
        Me.txtresidencia.TabIndex = 7
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(133, 80)
        Me.txtnumero.MaxLength = 5
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(119, 27)
        Me.txtnumero.TabIndex = 5
        '
        'txtnombre
        '
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(131, 45)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(316, 27)
        Me.txtnombre.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Folio Mercantil:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Residencia:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-2, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Número de Notario:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdcancelar)
        Me.Panel1.Controls.Add(Me.cmdsalir)
        Me.Panel1.Controls.Add(Me.cmdguardar)
        Me.Panel1.Location = New System.Drawing.Point(488, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 287)
        Me.Panel1.TabIndex = 39
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcancelar.Location = New System.Drawing.Point(10, 84)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(87, 72)
        Me.cmdcancelar.TabIndex = 38
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'cmdsalir
        '
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdsalir.Location = New System.Drawing.Point(9, 208)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(87, 72)
        Me.cmdsalir.TabIndex = 37
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'cmdguardar
        '
        Me.cmdguardar.Image = CType(resources.GetObject("cmdguardar.Image"), System.Drawing.Image)
        Me.cmdguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdguardar.Location = New System.Drawing.Point(9, 3)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(87, 72)
        Me.cmdguardar.TabIndex = 34
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'frmNotario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(613, 313)
        Me.Controls.Add(Me.pnlEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmNotario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notario"
        Me.pnlEmpresa.ResumeLayout(False)
        Me.pnlEmpresa.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEmpresa As System.Windows.Forms.Panel
    Friend WithEvents txtLugarRPP As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents txtresidencia As System.Windows.Forms.TextBox
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents dtRegistroActa As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
