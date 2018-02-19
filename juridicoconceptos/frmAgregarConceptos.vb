Public Class frmAgregarConceptos
    Dim SQL As String

    Public gIdConcepto As String
    Private Sub frmAgregarConceptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Buscamos los datos y los cargamos
        SQL = "select * from FacturaConcepto where iIdFacturaConcepto=" & gIdConcepto
        Dim rwConcepto As DataRow() = nConsulta(SQL)

        If rwConcepto Is Nothing = False Then
            txtclave.Text = rwConcepto(0)("ClaveSat")
            txtconcepto.Text = rwConcepto(0)("Concepto")


        End If



    End Sub

    Private Sub txtclave_TextChanged(sender As Object, e As EventArgs) Handles txtclave.TextChanged

    End Sub

    Private Sub txtclave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtclave.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtdescuento_TextChanged(sender As Object, e As EventArgs) Handles txtconcepto.TextChanged

    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        SQL = "update FacturaConcepto set CLaveSat=" & txtclave.Text & ",Concepto='" & txtconcepto.Text & "'"
        SQL &= " where iIdFacturaConcepto=" & gIdConcepto

        If nExecute(SQL) = False Then
            Exit Sub
        End If

        MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        SQL = "select * from FacturaConcepto where iIdFacturaConcepto=" & gIdConcepto
        Dim rwConcepto As DataRow() = nConsulta(SQL)

        If rwConcepto Is Nothing = False Then
            txtclave.Text = rwConcepto(0)("ClaveSat")
            txtconcepto.Text = rwConcepto(0)("Concepto")


        End If
    End Sub
End Class