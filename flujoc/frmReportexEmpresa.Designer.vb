<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportexEmpresa
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
        Me.grbfechas = New System.Windows.Forms.GroupBox()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.cmdcomisiones = New System.Windows.Forms.Button()
        Me.cmdCien = New System.Windows.Forms.Button()
        Me.cmdnocien = New System.Windows.Forms.Button()
        Me.grbfechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbfechas
        '
        Me.grbfechas.Controls.Add(Me.dtpfechafin)
        Me.grbfechas.Controls.Add(Me.Label4)
        Me.grbfechas.Controls.Add(Me.Label1)
        Me.grbfechas.Controls.Add(Me.dtpfechainicio)
        Me.grbfechas.Location = New System.Drawing.Point(13, 11)
        Me.grbfechas.Name = "grbfechas"
        Me.grbfechas.Size = New System.Drawing.Size(342, 93)
        Me.grbfechas.TabIndex = 14
        Me.grbfechas.TabStop = False
        Me.grbfechas.Text = "Rango de fechas"
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(197, 47)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechafin.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(193, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Fecha fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(43, 49)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechainicio.TabIndex = 37
        '
        'cmdcomisiones
        '
        Me.cmdcomisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcomisiones.Location = New System.Drawing.Point(13, 110)
        Me.cmdcomisiones.Name = "cmdcomisiones"
        Me.cmdcomisiones.Size = New System.Drawing.Size(139, 46)
        Me.cmdcomisiones.TabIndex = 13
        Me.cmdcomisiones.Text = "Movimientos IVA"
        Me.cmdcomisiones.UseVisualStyleBackColor = True
        '
        'cmdCien
        '
        Me.cmdCien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCien.Location = New System.Drawing.Point(210, 110)
        Me.cmdCien.Name = "cmdCien"
        Me.cmdCien.Size = New System.Drawing.Size(140, 46)
        Me.cmdCien.TabIndex = 15
        Me.cmdCien.Text = "Flujos al 100%"
        Me.cmdCien.UseVisualStyleBackColor = True
        '
        'cmdnocien
        '
        Me.cmdnocien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnocien.Location = New System.Drawing.Point(115, 162)
        Me.cmdnocien.Name = "cmdnocien"
        Me.cmdnocien.Size = New System.Drawing.Size(140, 46)
        Me.cmdnocien.TabIndex = 16
        Me.cmdnocien.Text = "Flujos No Cob 100%"
        Me.cmdnocien.UseVisualStyleBackColor = True
        '
        'frmReportexEmpresa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(372, 216)
        Me.Controls.Add(Me.cmdnocien)
        Me.Controls.Add(Me.cmdCien)
        Me.Controls.Add(Me.grbfechas)
        Me.Controls.Add(Me.cmdcomisiones)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReportexEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte por empresa"
        Me.grbfechas.ResumeLayout(False)
        Me.grbfechas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbfechas As GroupBox
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents cmdcomisiones As Button
    Friend WithEvents cmdCien As Button
    Friend WithEvents cmdnocien As Button
End Class
