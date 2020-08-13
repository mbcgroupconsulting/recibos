Public Class frmSantander
    Public gIdDatosBancos As String
    Public gFecha As String
    'Public gSecuencial As String
    Public gIdBanco As String
    Public gIdEmpresa As String
    Private Sub frmSantander_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargarbancosasociados()
    End Sub
    Private Sub cargarbancosasociados()
        Dim sql As String
        Try
            'sql = "select * from DatosBanco where fkiidBanco =" & gIdBanco & " order by numcliente"
            sql = "select * from DatosBanco where fkiidBanco =" & gIdBanco & " and fkiIdEmpresa=" & gIdEmpresa & " order by numcliente"
            nCargaCBO(cbocliente, sql, "cuentacargo", "iIdDatosBanco")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdaceptar_Click(sender As System.Object, e As System.EventArgs) Handles cmdaceptar.Click
        Try

            gFecha = dtpFecha.Value.ToShortDateString
            gIdDatosBancos = cbocliente.SelectedValue



            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class