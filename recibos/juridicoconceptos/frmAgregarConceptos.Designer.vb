<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarConceptos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtconcepto = New System.Windows.Forms.TextBox()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.txtclave = New System.Windows.Forms.TextBox()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 19)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Concepto:"
        '
        'txtconcepto
        '
        Me.txtconcepto.Location = New System.Drawing.Point(90, 36)
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.Size = New System.Drawing.Size(565, 27)
        Me.txtconcepto.TabIndex = 69
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Location = New System.Drawing.Point(228, 69)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(91, 27)
        Me.cmdcancelar.TabIndex = 68
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'txtclave
        '
        Me.txtclave.Location = New System.Drawing.Point(90, 4)
        Me.txtclave.Name = "txtclave"
        Me.txtclave.Size = New System.Drawing.Size(122, 27)
        Me.txtclave.TabIndex = 67
        Me.txtclave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Location = New System.Drawing.Point(108, 69)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(91, 27)
        Me.cmdGuardar.TabIndex = 66
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Clave:"
        '
        'frmAgregarConceptos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(676, 106)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtconcepto)
        Me.Controls.Add(Me.cmdcancelar)
        Me.Controls.Add(Me.txtclave)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAgregarConceptos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar concepto y clave"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtconcepto As TextBox
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents txtclave As TextBox
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents Label3 As Label
End Class
