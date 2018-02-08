Public Class frmRecibosLupita
    Public dsReporte As New DataSet
    Public opcion As Integer


    Private Sub frmRecibosLupita_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If opcion = 1 Then
            Dim sReporte As String = "ctmlogo.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmlogo
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If

        If opcion = 2 Then
            Dim sReporte As String = "ctmsinlogo.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmsinlogo
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If

        If opcion = 3 Then
            Dim sReporte As String = "recibos.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New recibos
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 4 Then
            Dim sReporte As String = "ctmalimentos.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmalimentos
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 5 Then
            Dim sReporte As String = "tmmsindicato.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New tmmsindicato
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
    End Sub
End Class