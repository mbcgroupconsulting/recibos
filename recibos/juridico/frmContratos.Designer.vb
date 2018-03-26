<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContratos))
        Me.pnlVentana = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtJurisdiccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdingreso = New System.Windows.Forms.Button()
        Me.cmdcontrato = New System.Windows.Forms.Button()
        Me.lbldireccion = New System.Windows.Forms.Label()
        Me.cboempresas = New System.Windows.Forms.ComboBox()
        Me.cboclientes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLugarFirma = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbosucursales = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFirma = New System.Windows.Forms.DateTimePicker()
        Me.pnlVentana.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlVentana
        '
        Me.pnlVentana.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlVentana.Controls.Add(Me.Label7)
        Me.pnlVentana.Controls.Add(Me.dtpFirma)
        Me.pnlVentana.Controls.Add(Me.txtLugarFirma)
        Me.pnlVentana.Controls.Add(Me.Label5)
        Me.pnlVentana.Controls.Add(Me.Label4)
        Me.pnlVentana.Controls.Add(Me.txtJurisdiccion)
        Me.pnlVentana.Controls.Add(Me.Label3)
        Me.pnlVentana.Controls.Add(Me.Panel1)
        Me.pnlVentana.Controls.Add(Me.lbldireccion)
        Me.pnlVentana.Controls.Add(Me.cboempresas)
        Me.pnlVentana.Controls.Add(Me.cboclientes)
        Me.pnlVentana.Controls.Add(Me.Label2)
        Me.pnlVentana.Controls.Add(Me.Label1)
        Me.pnlVentana.Location = New System.Drawing.Point(5, 6)
        Me.pnlVentana.Name = "pnlVentana"
        Me.pnlVentana.Size = New System.Drawing.Size(441, 381)
        Me.pnlVentana.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 18)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Lugar de"
        '
        'txtJurisdiccion
        '
        Me.txtJurisdiccion.Location = New System.Drawing.Point(109, 128)
        Me.txtJurisdiccion.Name = "txtJurisdiccion"
        Me.txtJurisdiccion.Size = New System.Drawing.Size(302, 26)
        Me.txtJurisdiccion.TabIndex = 114
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Jurisdicción:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdingreso)
        Me.Panel1.Controls.Add(Me.cmdcontrato)
        Me.Panel1.Location = New System.Drawing.Point(49, 258)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 94)
        Me.Panel1.TabIndex = 100
        '
        'cmdingreso
        '
        Me.cmdingreso.Image = CType(resources.GetObject("cmdingreso.Image"), System.Drawing.Image)
        Me.cmdingreso.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdingreso.Location = New System.Drawing.Point(207, 3)
        Me.cmdingreso.Name = "cmdingreso"
        Me.cmdingreso.Size = New System.Drawing.Size(137, 72)
        Me.cmdingreso.TabIndex = 38
        Me.cmdingreso.Text = "Correlacionado"
        Me.cmdingreso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdingreso.UseVisualStyleBackColor = True
        '
        'cmdcontrato
        '
        Me.cmdcontrato.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdcontrato.Image = CType(resources.GetObject("cmdcontrato.Image"), System.Drawing.Image)
        Me.cmdcontrato.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcontrato.Location = New System.Drawing.Point(36, 3)
        Me.cmdcontrato.Name = "cmdcontrato"
        Me.cmdcontrato.Size = New System.Drawing.Size(132, 72)
        Me.cmdcontrato.TabIndex = 34
        Me.cmdcontrato.Text = "APE Excedente"
        Me.cmdcontrato.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcontrato.UseVisualStyleBackColor = True
        '
        'lbldireccion
        '
        Me.lbldireccion.AutoSize = True
        Me.lbldireccion.Location = New System.Drawing.Point(78, 71)
        Me.lbldireccion.Name = "lbldireccion"
        Me.lbldireccion.Size = New System.Drawing.Size(77, 18)
        Me.lbldireccion.TabIndex = 20
        Me.lbldireccion.Text = "Sucursales:"
        '
        'cboempresas
        '
        Me.cboempresas.FormattingEnabled = True
        Me.cboempresas.Location = New System.Drawing.Point(81, 42)
        Me.cboempresas.Name = "cboempresas"
        Me.cboempresas.Size = New System.Drawing.Size(340, 26)
        Me.cboempresas.TabIndex = 13
        '
        'cboclientes
        '
        Me.cboclientes.FormattingEnabled = True
        Me.cboclientes.Location = New System.Drawing.Point(81, 10)
        Me.cboclientes.Name = "cboclientes"
        Me.cboclientes.Size = New System.Drawing.Size(340, 26)
        Me.cboclientes.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Empresa:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Cliente:"
        '
        'txtLugarFirma
        '
        Me.txtLugarFirma.Location = New System.Drawing.Point(109, 169)
        Me.txtLugarFirma.Name = "txtLugarFirma"
        Me.txtLugarFirma.Size = New System.Drawing.Size(302, 26)
        Me.txtLugarFirma.TabIndex = 117
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 18)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Firma:"
        '
        'cbosucursales
        '
        Me.cbosucursales.FormattingEnabled = True
        Me.cbosucursales.Location = New System.Drawing.Point(75, 393)
        Me.cbosucursales.Name = "cbosucursales"
        Me.cbosucursales.Size = New System.Drawing.Size(330, 26)
        Me.cbosucursales.TabIndex = 17
        Me.cbosucursales.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 396)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 18)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Sucursales:"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 18)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "Fecha Firma:"
        '
        'dtpFirma
        '
        Me.dtpFirma.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFirma.Location = New System.Drawing.Point(109, 214)
        Me.dtpFirma.Name = "dtpFirma"
        Me.dtpFirma.Size = New System.Drawing.Size(165, 26)
        Me.dtpFirma.TabIndex = 118
        '
        'frmContratos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(458, 431)
        Me.Controls.Add(Me.cbosucursales)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pnlVentana)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contratos empresa y cliente"
        Me.pnlVentana.ResumeLayout(False)
        Me.pnlVentana.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlVentana As Panel
    Friend WithEvents lbldireccion As Label
    Friend WithEvents cboempresas As ComboBox
    Friend WithEvents cboclientes As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdingreso As System.Windows.Forms.Button
    Friend WithEvents cmdcontrato As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtJurisdiccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLugarFirma As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbosucursales As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFirma As System.Windows.Forms.DateTimePicker
End Class
