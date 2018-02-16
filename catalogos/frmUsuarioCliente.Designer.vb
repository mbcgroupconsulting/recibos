<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarioCliente
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
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcontra = New System.Windows.Forms.TextBox()
        Me.cmdgenerar = New System.Windows.Forms.Button()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.chkactivo = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtusuario
        '
        Me.txtusuario.Location = New System.Drawing.Point(16, 67)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(258, 27)
        Me.txtusuario.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contraseña:"
        '
        'txtcontra
        '
        Me.txtcontra.Location = New System.Drawing.Point(16, 124)
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.Size = New System.Drawing.Size(258, 27)
        Me.txtcontra.TabIndex = 3
        '
        'cmdgenerar
        '
        Me.cmdgenerar.Location = New System.Drawing.Point(41, 157)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(75, 28)
        Me.cmdgenerar.TabIndex = 4
        Me.cmdgenerar.Text = "Generar"
        Me.cmdgenerar.UseVisualStyleBackColor = True
        '
        'cmdguardar
        '
        Me.cmdguardar.Location = New System.Drawing.Point(148, 157)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(75, 28)
        Me.cmdguardar.TabIndex = 5
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'chkactivo
        '
        Me.chkactivo.AutoSize = True
        Me.chkactivo.Location = New System.Drawing.Point(16, 12)
        Me.chkactivo.Name = "chkactivo"
        Me.chkactivo.Size = New System.Drawing.Size(131, 23)
        Me.chkactivo.TabIndex = 6
        Me.chkactivo.Text = "Activar Usuario."
        Me.chkactivo.UseVisualStyleBackColor = True
        '
        'frmUsuarioCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 198)
        Me.Controls.Add(Me.chkactivo)
        Me.Controls.Add(Me.cmdguardar)
        Me.Controls.Add(Me.cmdgenerar)
        Me.Controls.Add(Me.txtcontra)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtusuario)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmUsuarioCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtusuario As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcontra As TextBox
    Friend WithEvents cmdgenerar As Button
    Friend WithEvents cmdguardar As Button
    Friend WithEvents chkactivo As CheckBox
End Class
