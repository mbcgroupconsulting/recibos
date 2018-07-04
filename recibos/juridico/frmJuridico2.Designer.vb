<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJuridico2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJuridico2))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdDeterminado = New System.Windows.Forms.Button()
        Me.btnAsimilados = New System.Windows.Forms.Button()
        Me.btnAnexo4 = New System.Windows.Forms.Button()
        Me.btnAnexo3 = New System.Windows.Forms.Button()
        Me.btnAnexo2 = New System.Windows.Forms.Button()
        Me.btnAnexos = New System.Windows.Forms.Button()
        Me.cmdoficio = New System.Windows.Forms.Button()
        Me.cmdempleo = New System.Windows.Forms.Button()
        Me.cmdingreso = New System.Windows.Forms.Button()
        Me.cmdsimple = New System.Windows.Forms.Button()
        Me.cmdcontrato = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.cmdDeterminado)
        Me.Panel1.Controls.Add(Me.btnAsimilados)
        Me.Panel1.Controls.Add(Me.btnAnexo4)
        Me.Panel1.Controls.Add(Me.btnAnexo3)
        Me.Panel1.Controls.Add(Me.btnAnexo2)
        Me.Panel1.Controls.Add(Me.btnAnexos)
        Me.Panel1.Controls.Add(Me.cmdoficio)
        Me.Panel1.Controls.Add(Me.cmdempleo)
        Me.Panel1.Controls.Add(Me.cmdingreso)
        Me.Panel1.Controls.Add(Me.cmdsimple)
        Me.Panel1.Controls.Add(Me.cmdcontrato)
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(478, 250)
        Me.Panel1.TabIndex = 99
        '
        'cmdDeterminado
        '
        Me.cmdDeterminado.Image = CType(resources.GetObject("cmdDeterminado.Image"), System.Drawing.Image)
        Me.cmdDeterminado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdDeterminado.Location = New System.Drawing.Point(7, 82)
        Me.cmdDeterminado.Name = "cmdDeterminado"
        Me.cmdDeterminado.Size = New System.Drawing.Size(87, 72)
        Me.cmdDeterminado.TabIndex = 46
        Me.cmdDeterminado.Text = "C. Determ."
        Me.cmdDeterminado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDeterminado.UseVisualStyleBackColor = True
        '
        'btnAsimilados
        '
        Me.btnAsimilados.Image = CType(resources.GetObject("btnAsimilados.Image"), System.Drawing.Image)
        Me.btnAsimilados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAsimilados.Location = New System.Drawing.Point(7, 160)
        Me.btnAsimilados.Name = "btnAsimilados"
        Me.btnAsimilados.Size = New System.Drawing.Size(87, 72)
        Me.btnAsimilados.TabIndex = 45
        Me.btnAsimilados.Text = " Asimilados"
        Me.btnAsimilados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAsimilados.UseVisualStyleBackColor = True
        Me.btnAsimilados.Visible = False
        '
        'btnAnexo4
        '
        Me.btnAnexo4.Image = CType(resources.GetObject("btnAnexo4.Image"), System.Drawing.Image)
        Me.btnAnexo4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnexo4.Location = New System.Drawing.Point(379, 82)
        Me.btnAnexo4.Name = "btnAnexo4"
        Me.btnAnexo4.Size = New System.Drawing.Size(87, 72)
        Me.btnAnexo4.TabIndex = 44
        Me.btnAnexo4.Text = "Anexo IV"
        Me.btnAnexo4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnexo4.UseVisualStyleBackColor = True
        '
        'btnAnexo3
        '
        Me.btnAnexo3.Image = CType(resources.GetObject("btnAnexo3.Image"), System.Drawing.Image)
        Me.btnAnexo3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnexo3.Location = New System.Drawing.Point(286, 82)
        Me.btnAnexo3.Name = "btnAnexo3"
        Me.btnAnexo3.Size = New System.Drawing.Size(87, 72)
        Me.btnAnexo3.TabIndex = 43
        Me.btnAnexo3.Text = "Anexo III"
        Me.btnAnexo3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnexo3.UseVisualStyleBackColor = True
        '
        'btnAnexo2
        '
        Me.btnAnexo2.Image = CType(resources.GetObject("btnAnexo2.Image"), System.Drawing.Image)
        Me.btnAnexo2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnexo2.Location = New System.Drawing.Point(193, 82)
        Me.btnAnexo2.Name = "btnAnexo2"
        Me.btnAnexo2.Size = New System.Drawing.Size(87, 72)
        Me.btnAnexo2.TabIndex = 42
        Me.btnAnexo2.Text = "Anexo II"
        Me.btnAnexo2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnexo2.UseVisualStyleBackColor = True
        '
        'btnAnexos
        '
        Me.btnAnexos.Image = CType(resources.GetObject("btnAnexos.Image"), System.Drawing.Image)
        Me.btnAnexos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnexos.Location = New System.Drawing.Point(100, 82)
        Me.btnAnexos.Name = "btnAnexos"
        Me.btnAnexos.Size = New System.Drawing.Size(87, 72)
        Me.btnAnexos.TabIndex = 41
        Me.btnAnexos.Text = "Anexo I"
        Me.btnAnexos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAnexos.UseVisualStyleBackColor = True
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
        'frmJuridico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(493, 279)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmJuridico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Juridico"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdoficio As System.Windows.Forms.Button
    Friend WithEvents cmdempleo As System.Windows.Forms.Button
    Friend WithEvents cmdingreso As System.Windows.Forms.Button
    Friend WithEvents cmdsimple As System.Windows.Forms.Button
    Friend WithEvents cmdcontrato As System.Windows.Forms.Button
    Friend WithEvents btnAnexos As System.Windows.Forms.Button
    Friend WithEvents btnAnexo4 As System.Windows.Forms.Button
    Friend WithEvents btnAnexo3 As System.Windows.Forms.Button
    Friend WithEvents btnAnexo2 As System.Windows.Forms.Button
    Friend WithEvents btnAsimilados As System.Windows.Forms.Button
    Friend WithEvents cmdDeterminado As System.Windows.Forms.Button
End Class
