Public Class filtrofacturacion
    Public gIdTipo As Integer
    Private Sub cmdgenerar_Click(sender As Object, e As EventArgs) Handles cmdgenerar.Click
        If rdbnomina.Checked Then
            gIdTipo = 1
        ElseIf rdbflujo.Checked Then
            gIdTipo = 2
        ElseIf rdbtodas.Checked Then
            gIdTipo = 3
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub filtrofacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class