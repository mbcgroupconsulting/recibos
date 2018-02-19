<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class flujob
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
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.dtpfechafin = New System.Windows.Forms.DateTimePicker()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cboempresa = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.chktodas = New System.Windows.Forms.CheckBox()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.cmddescargar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(899, 451)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.cmdCerrar.Size = New System.Drawing.Size(94, 43)
        Me.cmdCerrar.TabIndex = 55
        Me.cmdCerrar.Text = "  Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'dtpfechafin
        '
        Me.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafin.Location = New System.Drawing.Point(139, 70)
        Me.dtpfechafin.Name = "dtpfechafin"
        Me.dtpfechafin.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechafin.TabIndex = 54
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.Location = New System.Drawing.Point(251, 68)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(179, 29)
        Me.cmdbuscar.TabIndex = 53
        Me.cmdbuscar.Text = "Realizar busqueda"
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'cboempresa
        '
        Me.cboempresa.FormattingEnabled = True
        Me.cboempresa.Location = New System.Drawing.Point(15, 25)
        Me.cboempresa.Name = "cboempresa"
        Me.cboempresa.Size = New System.Drawing.Size(434, 27)
        Me.cboempresa.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(135, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Fecha fin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 19)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Empresa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Fecha Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(16, 72)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(96, 27)
        Me.dtpfechainicio.TabIndex = 48
        '
        'chktodas
        '
        Me.chktodas.AutoSize = True
        Me.chktodas.BackColor = System.Drawing.Color.Transparent
        Me.chktodas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktodas.Location = New System.Drawing.Point(455, 25)
        Me.chktodas.Name = "chktodas"
        Me.chktodas.Size = New System.Drawing.Size(145, 22)
        Me.chktodas.TabIndex = 47
        Me.chktodas.Text = "Todas las empresas"
        Me.chktodas.UseVisualStyleBackColor = False
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
        Me.lsvLista.Location = New System.Drawing.Point(3, 103)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(990, 342)
        Me.lsvLista.TabIndex = 46
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'cmddescargar
        '
        Me.cmddescargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddescargar.Location = New System.Drawing.Point(445, 68)
        Me.cmddescargar.Name = "cmddescargar"
        Me.cmddescargar.Size = New System.Drawing.Size(179, 29)
        Me.cmddescargar.TabIndex = 56
        Me.cmddescargar.Text = "Bajar archivo"
        Me.cmddescargar.UseVisualStyleBackColor = True
        '
        'flujob
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(996, 497)
        Me.Controls.Add(Me.cmddescargar)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.dtpfechafin)
        Me.Controls.Add(Me.cmdbuscar)
        Me.Controls.Add(Me.cboempresa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpfechainicio)
        Me.Controls.Add(Me.chktodas)
        Me.Controls.Add(Me.lsvLista)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "flujob"
        Me.Text = "Listas facturas flujo Belen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCerrar As Button
    Friend WithEvents dtpfechafin As DateTimePicker
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents cboempresa As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpfechainicio As DateTimePicker
    Friend WithEvents chktodas As CheckBox
    Friend WithEvents lsvLista As ListView
    Friend WithEvents cmddescargar As Button
End Class
