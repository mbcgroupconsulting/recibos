<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAguinaldo
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
        Me.cmdcalcular = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtanio = New System.Windows.Forms.TextBox()
        Me.lblperiodo = New System.Windows.Forms.Label()
        Me.dtgDatos = New System.Windows.Forms.DataGridView()
        Me.cmdExcel = New System.Windows.Forms.Button()
        Me.cmdMonto = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.nuddias = New System.Windows.Forms.NumericUpDown()
        Me.cboperiodo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dtgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuddias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdcalcular
        '
        Me.cmdcalcular.Location = New System.Drawing.Point(16, 59)
        Me.cmdcalcular.Name = "cmdcalcular"
        Me.cmdcalcular.Size = New System.Drawing.Size(107, 36)
        Me.cmdcalcular.TabIndex = 0
        Me.cmdcalcular.Text = "Calcular Días"
        Me.cmdcalcular.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Año a calcular:"
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(123, 17)
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(57, 27)
        Me.txtanio.TabIndex = 2
        '
        'lblperiodo
        '
        Me.lblperiodo.AutoSize = True
        Me.lblperiodo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblperiodo.Location = New System.Drawing.Point(509, 68)
        Me.lblperiodo.Name = "lblperiodo"
        Me.lblperiodo.Size = New System.Drawing.Size(370, 19)
        Me.lblperiodo.TabIndex = 3
        Me.lblperiodo.Text = "Periodo en donde se guardaran los datos del aguinaldo:"
        '
        'dtgDatos
        '
        Me.dtgDatos.AllowUserToAddRows = False
        Me.dtgDatos.AllowUserToDeleteRows = False
        Me.dtgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDatos.Location = New System.Drawing.Point(12, 108)
        Me.dtgDatos.Name = "dtgDatos"
        Me.dtgDatos.Size = New System.Drawing.Size(1027, 425)
        Me.dtgDatos.TabIndex = 7
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(254, 60)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(101, 36)
        Me.cmdExcel.TabIndex = 8
        Me.cmdExcel.Text = "Enviar Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'cmdMonto
        '
        Me.cmdMonto.Location = New System.Drawing.Point(130, 60)
        Me.cmdMonto.Name = "cmdMonto"
        Me.cmdMonto.Size = New System.Drawing.Size(118, 36)
        Me.cmdMonto.TabIndex = 9
        Me.cmdMonto.Text = "Calcular Monto"
        Me.cmdMonto.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(196, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Dias de prestación:"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Location = New System.Drawing.Point(361, 60)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(142, 36)
        Me.cmdGuardar.TabIndex = 11
        Me.cmdGuardar.Text = "Guardar Aguinaldo"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'nuddias
        '
        Me.nuddias.Location = New System.Drawing.Point(336, 18)
        Me.nuddias.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nuddias.Name = "nuddias"
        Me.nuddias.Size = New System.Drawing.Size(51, 27)
        Me.nuddias.TabIndex = 12
        Me.nuddias.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'cboperiodo
        '
        Me.cboperiodo.FormattingEnabled = True
        Me.cboperiodo.Location = New System.Drawing.Point(513, 17)
        Me.cboperiodo.Name = "cboperiodo"
        Me.cboperiodo.Size = New System.Drawing.Size(225, 27)
        Me.cboperiodo.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(393, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 19)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Tipo de periodo:"
        '
        'frmAguinaldo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1051, 545)
        Me.Controls.Add(Me.cboperiodo)
        Me.Controls.Add(Me.nuddias)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdMonto)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.dtgDatos)
        Me.Controls.Add(Me.lblperiodo)
        Me.Controls.Add(Me.txtanio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdcalcular)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmAguinaldo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAguinaldo"
        CType(Me.dtgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuddias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdcalcular As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtanio As TextBox
    Friend WithEvents lblperiodo As Label
    Friend WithEvents dtgDatos As DataGridView
    Friend WithEvents cmdExcel As Button
    Friend WithEvents cmdMonto As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents nuddias As NumericUpDown
    Friend WithEvents cboperiodo As ComboBox
    Friend WithEvents Label3 As Label
End Class
