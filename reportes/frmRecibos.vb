

Public Class frmRecibos
    Public dsReporte As New DataSet
    Public dsOrdenamiento As New DataSet

    Private Sub frmRecibos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sReporte As String = "recibos.rpt"
        dsReporte.Tables("Tabla").DefaultView.Sort = "sucursal,departamento,puesto,nombre ASC"
        

        dsOrdenamiento.Tables.Add(dsReporte.Tables("Tabla").DefaultView.ToTable)
        

        With UcVisor1
            Try

                .DataSource = dsOrdenamiento
                '.Reporte = sReporte
                .crReporte = New reciboviasindicato

                .ShowReport()

            Catch ex As Exception

            End Try
        End With
    End Sub
End Class