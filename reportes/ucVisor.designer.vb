<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucVisor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.crvVisor = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvVisor
        '
        Me.crvVisor.ActiveViewIndex = -1
        Me.crvVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvVisor.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvVisor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvVisor.Location = New System.Drawing.Point(0, 0)
        Me.crvVisor.Name = "crvVisor"
        Me.crvVisor.SelectionFormula = ""
        Me.crvVisor.ShowCloseButton = False
        Me.crvVisor.ShowGotoPageButton = False
        Me.crvVisor.ShowGroupTreeButton = False
        Me.crvVisor.ShowTextSearchButton = False
        Me.crvVisor.Size = New System.Drawing.Size(600, 321)
        Me.crvVisor.TabIndex = 0
        Me.crvVisor.ViewTimeSelectionFormula = ""
        '
        'ucVisor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.crvVisor)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucVisor"
        Me.Size = New System.Drawing.Size(600, 321)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvVisor As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class
