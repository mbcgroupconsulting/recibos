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

        'Nuevos
        If opcion = 6 Then
            Dim sReporte As String = "ctmconstruccion.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmconstruccion
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 7 Then
            Dim sReporte As String = "ctm20noviembre.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctm20noviembre
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 8 Then
            Dim sReporte As String = "ctmcarmenserdan.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmcarmenserdan
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 9 Then
            Dim sReporte As String = "ctmindustriaalimenticia.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmindustriaalimenticia
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 10 Then
            Dim sReporte As String = "ctmtrabajadoresobreros.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmtrabajadoresobreros
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 11 Then
            Dim sReporte As String = "ctmsolidaridad.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctmsolidaridad
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If
        If opcion = 12 Then
            Dim sReporte As String = "ctm7enero.rpt"
            With UcVisor1
                Try

                    .DataSource = dsReporte
                    '.Reporte = sReporte
                    .crReporte = New ctm7enero
                    .ShowReport()

                Catch ex As Exception

                End Try
            End With
        End If

    End Sub
End Class