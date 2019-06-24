<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMostrarflujoconcepto
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
        Me.cmdexcel = New System.Windows.Forms.Button()
        Me.cbonumflujo = New System.Windows.Forms.ComboBox()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.chknumeroflujo = New System.Windows.Forms.CheckBox()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbExterno = New System.Windows.Forms.RadioButton()
        Me.rdbInterno = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdexcel
        '
        Me.cmdexcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexcel.Location = New System.Drawing.Point(810, 22)
        Me.cmdexcel.Name = "cmdexcel"
        Me.cmdexcel.Size = New System.Drawing.Size(179, 29)
        Me.cmdexcel.TabIndex = 61
        Me.cmdexcel.Text = "Enviar a Excel"
        Me.cmdexcel.UseVisualStyleBackColor = True
        '
        'cbonumflujo
        '
        Me.cbonumflujo.FormattingEnabled = True
        Me.cbonumflujo.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40"})
        Me.cbonumflujo.Location = New System.Drawing.Point(318, 24)
        Me.cbonumflujo.Name = "cbonumflujo"
        Me.cbonumflujo.Size = New System.Drawing.Size(62, 27)
        Me.cbonumflujo.TabIndex = 59
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(899, 451)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdCerrar.Size = New System.Drawing.Size(94, 43)
        Me.cmdCerrar.TabIndex = 58
        Me.cmdCerrar.Text = "  Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.Location = New System.Drawing.Point(625, 22)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(179, 29)
        Me.cmdbuscar.TabIndex = 56
        Me.cmdbuscar.Text = "Realizar busqueda"
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'chknumeroflujo
        '
        Me.chknumeroflujo.AutoSize = True
        Me.chknumeroflujo.BackColor = System.Drawing.Color.Transparent
        Me.chknumeroflujo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chknumeroflujo.Location = New System.Drawing.Point(224, 24)
        Me.chknumeroflujo.Name = "chknumeroflujo"
        Me.chknumeroflujo.Size = New System.Drawing.Size(88, 22)
        Me.chknumeroflujo.TabIndex = 50
        Me.chknumeroflujo.Text = "Num flujo"
        Me.chknumeroflujo.UseVisualStyleBackColor = False
        '
        'lsvLista
        '
        Me.lsvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(3, 74)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(990, 371)
        Me.lsvLista.TabIndex = 49
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(118, 24)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechafin.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(118, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Fecha fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(16, 24)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechainicio.TabIndex = 51
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbExterno)
        Me.Panel1.Controls.Add(Me.rdbInterno)
        Me.Panel1.Location = New System.Drawing.Point(404, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(187, 34)
        Me.Panel1.TabIndex = 62
        '
        'rdbExterno
        '
        Me.rdbExterno.AutoSize = True
        Me.rdbExterno.Location = New System.Drawing.Point(107, 5)
        Me.rdbExterno.Name = "rdbExterno"
        Me.rdbExterno.Size = New System.Drawing.Size(76, 23)
        Me.rdbExterno.TabIndex = 1
        Me.rdbExterno.TabStop = True
        Me.rdbExterno.Text = "Externo"
        Me.rdbExterno.UseVisualStyleBackColor = True
        '
        'rdbInterno
        '
        Me.rdbInterno.AutoSize = True
        Me.rdbInterno.Checked = True
        Me.rdbInterno.Location = New System.Drawing.Point(10, 5)
        Me.rdbInterno.Name = "rdbInterno"
        Me.rdbInterno.Size = New System.Drawing.Size(73, 23)
        Me.rdbInterno.TabIndex = 0
        Me.rdbInterno.TabStop = True
        Me.rdbInterno.Text = "Interno"
        Me.rdbInterno.UseVisualStyleBackColor = True
        '
        'frmMostrarflujoconcepto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(996, 497)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdexcel)
        Me.Controls.Add(Me.cbonumflujo)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.dtpfechafin)
        Me.Controls.Add(Me.cmdbuscar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpfechainicio)
        Me.Controls.Add(Me.chknumeroflujo)
        Me.Controls.Add(Me.lsvLista)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMostrarflujoconcepto"
        Me.Text = "Mostrar e imprimir flujos con conceptos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdexcel As Button
    Friend WithEvents cbonumflujo As ComboBox
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents chknumeroflujo As CheckBox
    Friend WithEvents lsvLista As ListView
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdbExterno As RadioButton
    Friend WithEvents rdbInterno As RadioButton
End Class
