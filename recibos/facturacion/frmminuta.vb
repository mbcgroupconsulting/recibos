Imports ClosedXML.Excel
Public Class frmminuta
    Private Sub cmdgenerar_Click(sender As Object, e As EventArgs) Handles cmdgenerar.Click
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim idtipo As Integer
        Dim SQL As String
        Dim nombreempresa As String



        SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"

        SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
        SQL &= "case when cancelada=0 then 0 else importe end as importe,"
        SQL &= "case when cancelada=0 then 0 else iva end as iva,"
        SQL &= "case when cancelada=0 then 0 else desnomina end as desnomina,"
        SQL &= "case when cancelada=0 then 0 else total end as total,"
        SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
        SQL &= " from (facturas"
        SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
        SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"

        If rdbnomina.Checked Then
            SQL &= " where (tipofactura=0 or tipofactura=2)  "
        Else
            SQL &= " where tipofactura=1  "
        End If

        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        If (tiempo.Days >= 0) Then

            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
        Else
            MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End If



        Dim rwFilas As DataRow() = nConsulta(Sql)

        If rwFilas Is Nothing = False Then
            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

            hoja.Column("B").Width = 13
            hoja.Column("C").Width = 20
            hoja.Column("D").Width = 60
            hoja.Column("E").Width = 20
            hoja.Column("F").Width = 20
            hoja.Column("G").Width = 20
            hoja.Column("H").Width = 20

            hoja.Cell(2, 2).Value = "MINUTA AL" & Date.Now.ToLongDateString().ToUpper()


            'hoja.Cell(3, 2).Value = ":"
            'hoja.Cell(3, 3).Value = ""

            'hoja.Range(4, 2, 4, 7).Style.Font.FontSize = 10
            'hoja.Range(4, 2, 4, 7).Style.Font.SetBold(True)
            'hoja.Range(4, 2, 4, 7).Style.Alignment.WrapText = True
            'hoja.Range(4, 2, 4, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            'hoja.Range(4, 1, 4, 7).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            ''hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            'hoja.Range(4, 2, 4, 7).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            'hoja.Range(4, 2, 4, 7).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            nombreempresa = ""

            filaExcel = 4
            For x As Integer = 0 To rwFilas.Count - 1
                filaExcel = filaExcel + 1

                If x = 0 Then
                    hoja.Cell(filaExcel, 2).Value = rwFilas(x).Item("nombreempresa")
                    filaExcel = filaExcel + 1
                    nombreempresa = rwFilas(x).Item("nombreempresa")
                ElseIf rwFilas(x).Item("nombreempresa") <> nombreempresa Then
                    filaExcel = filaExcel + 1
                    hoja.Cell(filaExcel, 2).Value = rwFilas(x).Item("nombreempresa")
                    nombreempresa = rwFilas(x).Item("nombreempresa")
                    filaExcel = filaExcel + 1
                End If




                hoja.Cell(filaExcel, 2).Value = rwFilas(x).Item("numfactura")
                hoja.Cell(filaExcel, 3).Value = rwFilas(x).Item("fecha")
                hoja.Cell(filaExcel, 4).Value = rwFilas(x).Item("nombrecliente") & IIf(rwFilas(x).Item("cancelada") = "0", "***CANCELADA", "")
                hoja.Cell(filaExcel, 5).Value = Format(CType(rwFilas(x).Item("importe"), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 5).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 6).Value = Format(CType(rwFilas(x).Item("iva"), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 6).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 7).Value = Format(CType(rwFilas(x).Item("desnomina"), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 7).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 8).Value = Format(CType(rwFilas(x).Item("total"), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 8).Style.NumberFormat.SetFormat("###,###,##0.#0")

            Next

            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Minuta " & Date.Now.ToLongDateString().ToUpper()
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            libro.SaveAs(dialogo.FileName)
            'libro.SaveAs("c:\temp\control.xlsx")
            'libro.SaveAs(dialogo.FileName)
            'apExcel.Quit()
            libro = Nothing
        Else
            MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


    End Sub
End Class