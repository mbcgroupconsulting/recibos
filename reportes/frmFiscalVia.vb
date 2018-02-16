Public Class frmFiscalVia
    Public dsReporte As New DataSet
    Public dsOrdenamiento As New DataSet
    Public iTipo As Integer

    Private Sub frmFiscalVia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim sReporte As String = "recibosfiscalvia.rpt"

        'Dim dt As DataTable = dsReporte.Tables("Tabla")
        'Dim rows() As DataRow = dt.Select("numtrabajador>0", "sucursal,departamento ASC")
        'Dim Tabla As DataTable = dt.Clone()
        'For Each row As DataRow In rows
        '    row.SetAdded()
        '    Tabla.ImportRow(row)
        'Next
        'dsOrdenamiento.Tables.Add(Tabla)

        'dsOrdenamiento.Tables.Add(dsReporte.Tables("Percepciones"))
        'dsOrdenamiento.Tables.Add(dsReporte.Tables("Deducciones"))
        dsReporte.Tables("Tabla").DefaultView.Sort = "sucursal,departamento,puesto,nombre ASC"
        dsReporte.Tables("Percepciones").DefaultView.Sort = "numtrabajador ASC"
        dsReporte.Tables("Deducciones").DefaultView.Sort = "numtrabajador ASC"

        dsOrdenamiento.Tables.Add(dsReporte.Tables("Tabla").DefaultView.ToTable)
        dsOrdenamiento.Tables.Add(dsReporte.Tables("Percepciones").DefaultView.ToTable)
        dsOrdenamiento.Tables.Add(dsReporte.Tables("Deducciones").DefaultView.ToTable)

        With UcVisor1
            Try

                .DataSource = dsOrdenamiento

                '.Reporte = sReporte
                If iTipo = 1 Then
                    .crReporte = New recibosfiscalvia
                Else
                    'MessageBox.Show("XURTEP")
                    .crReporte = New recibosfiscalviaxurtep
                End If

                .ShowReport()

            Catch ex As Exception

            End Try
        End With
    End Sub
End Class