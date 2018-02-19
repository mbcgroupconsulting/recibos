<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSindicato
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
        Me.cmdaceptar = New System.Windows.Forms.Button()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.txtlugar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtmm = New System.Windows.Forms.RadioButton()
        Me.rbalimentos = New System.Windows.Forms.RadioButton()
        Me.rbcroc = New System.Windows.Forms.RadioButton()
        Me.rbctm = New System.Windows.Forms.RadioButton()
        Me.rbctmlogo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdaceptar
        '
        Me.cmdaceptar.Location = New System.Drawing.Point(114, 147)
        Me.cmdaceptar.Name = "cmdaceptar"
        Me.cmdaceptar.Size = New System.Drawing.Size(138, 37)
        Me.cmdaceptar.TabIndex = 18
        Me.cmdaceptar.Text = "Aceptar"
        Me.cmdaceptar.UseVisualStyleBackColor = True
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Location = New System.Drawing.Point(276, 147)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(138, 37)
        Me.cmdcancelar.TabIndex = 19
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'txtlugar
        '
        Me.txtlugar.Location = New System.Drawing.Point(151, 6)
        Me.txtlugar.Name = "txtlugar"
        Me.txtlugar.Size = New System.Drawing.Size(380, 27)
        Me.txtlugar.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 19)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Lugar de expedicion:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 19)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Fecha del recibo:"
        '
        'dtpfecha
        '
        Me.dtpfecha.Location = New System.Drawing.Point(151, 41)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(202, 27)
        Me.dtpfecha.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtmm)
        Me.GroupBox1.Controls.Add(Me.rbalimentos)
        Me.GroupBox1.Controls.Add(Me.rbcroc)
        Me.GroupBox1.Controls.Add(Me.rbctm)
        Me.GroupBox1.Controls.Add(Me.rbctmlogo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 57)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de sindicato y formato"
        '
        'rbtmm
        '
        Me.rbtmm.AutoSize = True
        Me.rbtmm.Location = New System.Drawing.Point(450, 25)
        Me.rbtmm.Name = "rbtmm"
        Me.rbtmm.Size = New System.Drawing.Size(61, 23)
        Me.rbtmm.TabIndex = 4
        Me.rbtmm.Text = "TMM"
        Me.rbtmm.UseVisualStyleBackColor = True
        '
        'rbalimentos
        '
        Me.rbalimentos.AutoSize = True
        Me.rbalimentos.Location = New System.Drawing.Point(248, 25)
        Me.rbalimentos.Name = "rbalimentos"
        Me.rbalimentos.Size = New System.Drawing.Size(125, 23)
        Me.rbalimentos.TabIndex = 3
        Me.rbalimentos.Text = "CTM alimentos"
        Me.rbalimentos.UseVisualStyleBackColor = True
        '
        'rbcroc
        '
        Me.rbcroc.AutoSize = True
        Me.rbcroc.Location = New System.Drawing.Point(379, 25)
        Me.rbcroc.Name = "rbcroc"
        Me.rbcroc.Size = New System.Drawing.Size(65, 23)
        Me.rbcroc.TabIndex = 2
        Me.rbcroc.Text = "CROC"
        Me.rbcroc.UseVisualStyleBackColor = True
        '
        'rbctm
        '
        Me.rbctm.AutoSize = True
        Me.rbctm.Location = New System.Drawing.Point(130, 25)
        Me.rbctm.Name = "rbctm"
        Me.rbctm.Size = New System.Drawing.Size(112, 23)
        Me.rbctm.TabIndex = 1
        Me.rbctm.Text = "CTM sin logo"
        Me.rbctm.UseVisualStyleBackColor = True
        '
        'rbctmlogo
        '
        Me.rbctmlogo.AutoSize = True
        Me.rbctmlogo.Checked = True
        Me.rbctmlogo.Location = New System.Drawing.Point(6, 25)
        Me.rbctmlogo.Name = "rbctmlogo"
        Me.rbctmlogo.Size = New System.Drawing.Size(118, 23)
        Me.rbctmlogo.TabIndex = 0
        Me.rbctmlogo.TabStop = True
        Me.rbctmlogo.Text = "CTM Con logo"
        Me.rbctmlogo.UseVisualStyleBackColor = True
        '
        'frmSindicato
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(543, 196)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpfecha)
        Me.Controls.Add(Me.txtlugar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdcancelar)
        Me.Controls.Add(Me.cmdaceptar)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSindicato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibos sindicato"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdaceptar As Button
    Friend WithEvents cmdcancelar As Button
    Friend WithEvents txtlugar As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfecha As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbtmm As RadioButton
    Friend WithEvents rbalimentos As RadioButton
    Friend WithEvents rbcroc As RadioButton
    Friend WithEvents rbctm As RadioButton
    Friend WithEvents rbctmlogo As RadioButton
End Class
