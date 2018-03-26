Public Class frmEstatusNomina
    Public gIdEstatusNomina
    Private Sub frmEstatusNomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdAceptar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAceptar.Click
        If cboNomina.SelectedIndex <> -1 Then
            gIdEstatusNomina = cboNomina.SelectedIndex
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("No eligio ninguna opción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class