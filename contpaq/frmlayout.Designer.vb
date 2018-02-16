<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmlayout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmlayout))
        Me.cmdbancomer = New System.Windows.Forms.Button()
        Me.cmdbanamex = New System.Windows.Forms.Button()
        Me.cmdbanorte = New System.Windows.Forms.Button()
        Me.cmdscotiabank = New System.Windows.Forms.Button()
        Me.cmdscotiabankinter = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdbancomer
        '
        Me.cmdbancomer.Image = CType(resources.GetObject("cmdbancomer.Image"), System.Drawing.Image)
        Me.cmdbancomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdbancomer.Location = New System.Drawing.Point(22, 22)
        Me.cmdbancomer.Name = "cmdbancomer"
        Me.cmdbancomer.Size = New System.Drawing.Size(87, 72)
        Me.cmdbancomer.TabIndex = 35
        Me.cmdbancomer.Text = "Bancomer"
        Me.cmdbancomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbancomer.UseVisualStyleBackColor = True
        '
        'cmdbanamex
        '
        Me.cmdbanamex.Image = CType(resources.GetObject("cmdbanamex.Image"), System.Drawing.Image)
        Me.cmdbanamex.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdbanamex.Location = New System.Drawing.Point(130, 22)
        Me.cmdbanamex.Name = "cmdbanamex"
        Me.cmdbanamex.Size = New System.Drawing.Size(87, 72)
        Me.cmdbanamex.TabIndex = 36
        Me.cmdbanamex.Text = "Banamex"
        Me.cmdbanamex.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbanamex.UseVisualStyleBackColor = True
        '
        'cmdbanorte
        '
        Me.cmdbanorte.Image = CType(resources.GetObject("cmdbanorte.Image"), System.Drawing.Image)
        Me.cmdbanorte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdbanorte.Location = New System.Drawing.Point(240, 22)
        Me.cmdbanorte.Name = "cmdbanorte"
        Me.cmdbanorte.Size = New System.Drawing.Size(87, 72)
        Me.cmdbanorte.TabIndex = 37
        Me.cmdbanorte.Text = "Banorte"
        Me.cmdbanorte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbanorte.UseVisualStyleBackColor = True
        '
        'cmdscotiabank
        '
        Me.cmdscotiabank.Image = CType(resources.GetObject("cmdscotiabank.Image"), System.Drawing.Image)
        Me.cmdscotiabank.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdscotiabank.Location = New System.Drawing.Point(352, 22)
        Me.cmdscotiabank.Name = "cmdscotiabank"
        Me.cmdscotiabank.Size = New System.Drawing.Size(87, 72)
        Me.cmdscotiabank.TabIndex = 38
        Me.cmdscotiabank.Text = "Scotiabank"
        Me.cmdscotiabank.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdscotiabank.UseVisualStyleBackColor = True
        '
        'cmdscotiabankinter
        '
        Me.cmdscotiabankinter.Image = CType(resources.GetObject("cmdscotiabankinter.Image"), System.Drawing.Image)
        Me.cmdscotiabankinter.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdscotiabankinter.Location = New System.Drawing.Point(466, 22)
        Me.cmdscotiabankinter.Name = "cmdscotiabankinter"
        Me.cmdscotiabankinter.Size = New System.Drawing.Size(87, 72)
        Me.cmdscotiabankinter.TabIndex = 39
        Me.cmdscotiabankinter.Text = "Scotiabank Int"
        Me.cmdscotiabankinter.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdscotiabankinter.UseVisualStyleBackColor = True
        '
        'frmlayout
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(579, 112)
        Me.Controls.Add(Me.cmdscotiabankinter)
        Me.Controls.Add(Me.cmdscotiabank)
        Me.Controls.Add(Me.cmdbanorte)
        Me.Controls.Add(Me.cmdbanamex)
        Me.Controls.Add(Me.cmdbancomer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmlayout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Layouts"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdbancomer As Button
    Friend WithEvents cmdbanamex As Button
    Friend WithEvents cmdbanorte As Button
    Friend WithEvents cmdscotiabank As Button
    Friend WithEvents cmdscotiabankinter As Button
End Class
