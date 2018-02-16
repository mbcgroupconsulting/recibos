Public Class frmlayout
    Public gIdTipo As Integer
    Private Sub frmlayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdbancomer_Click(sender As Object, e As EventArgs) Handles cmdbancomer.Click
        gIdTipo = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdbanamex_Click(sender As Object, e As EventArgs) Handles cmdbanamex.Click
        gIdTipo = 2
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdbanorte_Click(sender As Object, e As EventArgs) Handles cmdbanorte.Click
        gIdTipo = 3
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdscotiabank_Click(sender As Object, e As EventArgs) Handles cmdscotiabank.Click
        gIdTipo = 4
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdscotiabankinter_Click(sender As Object, e As EventArgs) Handles cmdscotiabankinter.Click
        gIdTipo = 5
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class