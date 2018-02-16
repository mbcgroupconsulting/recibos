Public Class frmscotiabank
    Public gIdDatosBancos As String
    Public gFecha As String
    Public gSecuencial As String
    Public gIdBanco As String
    Public gIdEmpresa As String
    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Try
            gSecuencial = NudFilaI.Value
            gFecha = dtpFecha.Value.ToShortDateString
            gIdDatosBancos = cbocliente.SelectedValue



            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmscotiabank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarbancosasociados()
    End Sub

    Private Sub cargarbancosasociados()
        Dim sql As String
        Try
            sql = "select * from DatosBanco where fkiidBanco =" & gIdBanco & " and fkiIdEmpresa=" & gIdEmpresa & " order by numcliente"
            nCargaCBO(cbocliente, sql, "numcliente", "iIdDatosBanco")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbocliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocliente.SelectedIndexChanged
        Dim sql As String
        Try
            sql = "select * from DatosBanco where iIdDatosBanco=" & cbocliente.SelectedValue
            Dim rwDatos As DataRow() = nConsulta(sql)

            If rwDatos Is Nothing = False Then
                txtempresa.Text = rwDatos(0)("empresa").ToString
                txtdescripcion.Text = rwDatos(0)("descripcion").ToString
                txtcuentacargo.Text = rwDatos(0)("cuentacargo").ToString
                txtsucursal.Text = rwDatos(0)("numsucursal").ToString
            Else
                MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class