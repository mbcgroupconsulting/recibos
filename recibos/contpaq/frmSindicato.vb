Public Class frmSindicato
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
            gIdTipo = 5

        End If
        If rdbconstruccion.Checked Then
            gIdTipo = 6
        End If
        If rb20nov.Checked Then
            gIdTipo = 7
        End If

        
        If rdbcarmen.Checked Then
            gIdTipo = 8

        End If
        If rdbindustria.Checked Then
            gIdTipo = 9

        End If
        If rdbobrerosindustria.Checked Then
            gIdTipo = 10

        End If
        If rdbsolidario.Checked Then
            gIdTipo = 11

        End If
        If rdbenero.Checked Then
            gIdTipo = 12

        End If


        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class