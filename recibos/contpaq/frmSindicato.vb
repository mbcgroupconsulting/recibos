﻿Public Class frmSindicato
    Public gIdTipo As Integer
    Public gExpedicion As String
    Public gfecha As String
    Private Sub frmSindicato_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        gExpedicion = txtlugar.Text.ToUpper()
        gfecha = dtpfecha.Value.ToLongDateString().ToUpper()

        If rbctmlogo.Checked Then
            gIdTipo = 1
        End If
        If rbctm.Checked Then
            gIdTipo = 2
        End If
        If rbcroc.Checked Then
            gIdTipo = 3
        End If
        If rbalimentos.Checked Then
            gIdTipo = 4
        End If
        If rbtmm.Checked Then
            gIdTipo = 5e

        End If

        If rb20nov.Checked Then
            gIdTipo = 7
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class