Public Class frmCargoManual
    Public gTextoCargo As String
    Private Sub frmCargoManual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdAceptar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAceptar.Click
        If txtTexto.Text.Length > 0 Then
            Dim resultado As Integer = MessageBox.Show("¿El texto es correcto?, al guardar la información ya no es posible modificarla", "Pregunta", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                gTextoCargo = txtTexto.Text
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            MessageBox.Show("Por favor escriba el texto que se va a asociar al cargo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        
    End Sub
End Class