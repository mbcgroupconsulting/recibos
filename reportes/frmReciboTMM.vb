Public Class frmReciboTMM
    Public dsReporte As New DataSet

    Private Sub frmReciboTMM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sReporte As String = "tmm.rpt"
        With UcVisor1
            Try

                .DataSource = dsReporte
                '.Reporte = sReporte
                .crReporte = New tmm
                .ShowReport()

            Catch ex As Exception

            End Try
        End With
    End Sub
End Class