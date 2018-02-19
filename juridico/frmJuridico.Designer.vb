<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJuridico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJuridico))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdoficio = New System.Windows.Forms.Button()
        Me.cmdempleo = New System.Windows.Forms.Button()
        Me.cmdingreso = New System.Windows.Forms.Button()
        Me.cmdsimple = New System.Windows.Forms.Button()
        Me.cmdcontrato = New System.Windows.Forms.Button()
        Me.pnlLote = New System.Windows.Forms.Panel()
        Me.rbContrato = New System.Windows.Forms.RadioButton()
        Me.rbOficio = New System.Windows.Forms.RadioButton()
        Me.rbSolicitud = New System.Windows.Forms.RadioButton()
        Me.rbSimple = New System.Windows.Forms.RadioButton()
        Me.chkLotes = New System.Windows.Forms.CheckBox()
        Me.txtlotes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlLote.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdoficio)
        Me.Panel1.Controls.Add(Me.cmdempleo)
        Me.Panel1.Controls.Add(Me.cmdingreso)
        Me.Panel1.Controls.Add(Me.cmdsimple)
        Me.Panel1.Controls.Add(Me.cmdcontrato)
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(474, 87)
        Me.Panel1.TabIndex = 99
        '
        'cmdoficio
        '
        Me.cmdoficio.Image = CType(resources.GetObject("cmdoficio.Image"), System.Drawing.Image)
        Me.cmdoficio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdoficio.Location = New System.Drawing.Point(286, 4)
        Me.cmdoficio.Name = "cmdoficio"
        Me.cmdoficio.Size = New System.Drawing.Size(87, 72)
        Me.cmdoficio.TabIndex = 40
        Me.cmdoficio.Text = "Oficio"
        Me.cmdoficio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdoficio.UseVisualStyleBackColor = True
        '
        'cmdempleo
        '
        Me.cmdempleo.Image = CType(resources.GetObject("cmdempleo.Image"), System.Drawing.Image)
        Me.cmdempleo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdempleo.Location = New System.Drawing.Point(193, 4)
        Me.cmdempleo.Name = "cmdempleo"
        Me.cmdempleo.Size = New System.Drawing.Size(87, 72)
        Me.cmdempleo.TabIndex = 39
        Me.cmdempleo.Text = "S. Empleo"
        Me.cmdempleo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdempleo.UseVisualStyleBackColor = True
        '
        'cmdingreso
        '
        Me.cmdingreso.Image = CType(resources.GetObject("cmdingreso.Image"), System.Drawing.Image)
        Me.cmdingreso.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdingreso.Location = New System.Drawing.Point(100, 4)
        Me.cmdingreso.Name = "cmdingreso"
        Me.cmdingreso.Size = New System.Drawing.Size(87, 72)
        Me.cmdingreso.TabIndex = 38
        Me.cmdingreso.Text = "S. Ingreso"
        Me.cmdingreso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdingreso.UseVisualStyleBackColor = True
        '
        'cmdsimple
        '
        Me.cmdsimple.Image = CType(resources.GetObject("cmdsimple.Image"), System.Drawing.Image)
        Me.cmdsimple.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdsimple.Location = New System.Drawing.Point(379, 4)
        Me.cmdsimple.Name = "cmdsimple"
        Me.cmdsimple.Size = New System.Drawing.Size(87, 72)
        Me.cmdsimple.TabIndex = 37
        Me.cmdsimple.Text = "Oficio S."
        Me.cmdsimple.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsimple.UseVisualStyleBackColor = True
        '
        'cmdcontrato
        '
        Me.cmdcontrato.Image = CType(resources.GetObject("cmdcontrato.Image"), System.Drawing.Image)
        Me.cmdcontrato.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdcontrato.Location = New System.Drawing.Point(7, 4)
        Me.cmdcontrato.Name = "cmdcontrato"
        Me.cmdcontrato.Size = New System.Drawing.Size(87, 72)
        Me.cmdcontrato.TabIndex = 34
        Me.cmdcontrato.Text = "Contrato"
        Me.cmdcontrato.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcontrato.UseVisualStyleBackColor = True
        '
        'pnlLote
        '
        Me.pnlLote.Controls.Add(Me.txtlotes)
        Me.pnlLote.Controls.Add(Me.chkLotes)
        Me.pnlLote.Controls.Add(Me.rbSimple)
        Me.pnlLote.Controls.Add(Me.rbSolicitud)
        Me.pnlLote.Controls.Add(Me.rbOficio)
        Me.pnlLote.Controls.Add(Me.rbContrato)
        Me.pnlLote.Location = New System.Drawing.Point(7, 104)
        Me.pnlLote.Name = "pnlLote"
        Me.pnlLote.Size = New System.Drawing.Size(470, 166)
        Me.pnlLote.TabIndex = 100
        '
        'rbContrato
        '
        Me.rbContrato.AutoSize = True
        Me.rbContrato.Checked = True
        Me.rbContrato.Location = New System.Drawing.Point(21, 39)
        Me.rbContrato.Name = "rbContrato"
        Me.rbContrato.Size = New System.Drawing.Size(80, 22)
        Me.rbContrato.TabIndex = 0
        Me.rbContrato.TabStop = True
        Me.rbContrato.Text = "Contrato"
        Me.rbContrato.UseVisualStyleBackColor = True
        '
        'rbOficio
        '
        Me.rbOficio.AutoSize = True
        Me.rbOficio.Location = New System.Drawing.Point(251, 39)
        Me.rbOficio.Name = "rbOficio"
        Me.rbOficio.Size = New System.Drawing.Size(62, 22)
        Me.rbOficio.TabIndex = 1
        Me.rbOficio.Text = "Oficio"
        Me.rbOficio.UseVisualStyleBackColor = True
        '
        'rbSolicitud
        '
        Me.rbSolicitud.AutoSize = True
        Me.rbSolicitud.Location = New System.Drawing.Point(128, 39)
        Me.rbSolicitud.Name = "rbSolicitud"
        Me.rbSolicitud.Size = New System.Drawing.Size(86, 22)
        Me.rbSolicitud.TabIndex = 2
        Me.rbSolicitud.Text = "S. Ingreso"
        Me.rbSolicitud.UseVisualStyleBackColor = True
        '
        'rbSimple
        '
        Me.rbSimple.AutoSize = True
        Me.rbSimple.Location = New System.Drawing.Point(350, 39)
        Me.rbSimple.Name = "rbSimple"
        Me.rbSimple.Size = New System.Drawing.Size(76, 22)
        Me.rbSimple.TabIndex = 3
        Me.rbSimple.Text = "Oficio S."
        Me.rbSimple.UseVisualStyleBackColor = True
        '
        'chkLotes
        '
        Me.chkLotes.AutoSize = True
        Me.chkLotes.Location = New System.Drawing.Point(21, 7)
        Me.chkLotes.Name = "chkLotes"
        Me.chkLotes.Size = New System.Drawing.Size(207, 22)
        Me.chkLotes.TabIndex = 4
        Me.chkLotes.Text = "Activar documentos por lotes"
        Me.chkLotes.UseVisualStyleBackColor = True
        '
        'txtlotes
        '
        Me.txtlotes.Location = New System.Drawing.Point(5, 67)
        Me.txtlotes.Multiline = True
        Me.txtlotes.Name = "txtlotes"
        Me.txtlotes.Size = New System.Drawing.Size(450, 96)
        Me.txtlotes.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 275)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(458, 36)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Para generar el archivo por lotes, poner los numeros de trabajador separado por c" & _
            "omas sin espacios."
        '
        'frmJuridico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(483, 331)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlLote)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmJuridico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Juridico"
        Me.Panel1.ResumeLayout(False)
        Me.pnlLote.ResumeLayout(False)
        Me.pnlLote.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdoficio As System.Windows.Forms.Button
    Friend WithEvents cmdempleo As System.Windows.Forms.Button
    Friend WithEvents cmdingreso As System.Windows.Forms.Button
    Friend WithEvents cmdsimple As System.Windows.Forms.Button
    Friend WithEvents cmdcontrato As System.Windows.Forms.Button
    Friend WithEvents pnlLote As System.Windows.Forms.Panel
    Friend WithEvents txtlotes As System.Windows.Forms.TextBox
    Friend WithEvents chkLotes As System.Windows.Forms.CheckBox
    Friend WithEvents rbSimple As System.Windows.Forms.RadioButton
    Friend WithEvents rbSolicitud As System.Windows.Forms.RadioButton
    Friend WithEvents rbOficio As System.Windows.Forms.RadioButton
    Friend WithEvents rbContrato As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
