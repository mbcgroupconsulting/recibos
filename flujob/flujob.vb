Imports ClosedXML.Excel
Public Class flujob
    Dim SQL As String
    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click

        Dim Alter As Boolean = False
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio

        lsvLista.Items.Clear()
        lsvLista.Clear()
        If (tiempo.Days >= 0) Then
            If chktodas.Checked = False Then
                SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
                SQL &= "case when cancelada=0 then 0 else importe end as importe,"
                SQL &= "case when cancelada=0 then 0 else iva end as iva,"
                SQL &= "case when cancelada=0 then 0 else total end as total,"
                SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,"
                SQL &= "ISNULL(color,0) as color,"
                SQL &= "usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " where flujob=1 and fkiIdEmpresa=" & cboempresa.SelectedValue
                SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                SQL &= " order by fecha,iIdFactura asc"

            Else

                SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
                SQL &= "case when cancelada=0 then 0 else importe end as importe,"
                SQL &= "case when cancelada=0 then 0 else iva end as iva,"
                SQL &= "case when cancelada=0 then 0 else total end as total,"
                SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,"
                SQL &= "ISNULL(color,0) as color,"
                SQL &= "usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " where flujob=1  and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

            End If

            Dim item As ListViewItem
            lsvLista.Columns.Add("Edo Pago")
            lsvLista.Columns(0).Width = 70
            lsvLista.Columns.Add("Tipo Fac")
            lsvLista.Columns(1).Width = 70
            lsvLista.Columns.Add("Serie F")
            lsvLista.Columns(2).Width = 60
            lsvLista.Columns.Add("Factura")
            lsvLista.Columns(3).Width = 70
            lsvLista.Columns(3).TextAlign = 1
            lsvLista.Columns.Add("Fecha")
            lsvLista.Columns(4).Width = 90
            lsvLista.Columns.Add("Empresa")
            lsvLista.Columns(5).Width = 300
            lsvLista.Columns.Add("Cliente")
            lsvLista.Columns(6).Width = 300
            lsvLista.Columns.Add("Importe")
            lsvLista.Columns(7).Width = 100
            lsvLista.Columns(7).TextAlign = 1
            lsvLista.Columns.Add("Iva")
            lsvLista.Columns(8).Width = 100
            lsvLista.Columns(8).TextAlign = 1
            lsvLista.Columns.Add("Total")
            lsvLista.Columns(9).Width = 100
            lsvLista.Columns(9).TextAlign = 1
            lsvLista.Columns.Add("Serie N")
            lsvLista.Columns(10).Width = 70
            lsvLista.Columns.Add("Nota")
            lsvLista.Columns(11).Width = 70
            lsvLista.Columns(11).TextAlign = 1
            lsvLista.Columns.Add("Pago/Abono")
            lsvLista.Columns(12).Width = 400
            lsvLista.Columns.Add("Periodo")
            lsvLista.Columns(13).Width = 400
            lsvLista.Columns.Add("Comentario")
            lsvLista.Columns(14).Width = 400
            lsvLista.Columns.Add("Estado")
            lsvLista.Columns(15).Width = 100
            lsvLista.Columns.Add("Elaborado")
            lsvLista.Columns(16).Width = 100
            lsvLista.Columns.Add("Modificado")
            lsvLista.Columns(17).Width = 100



            Dim rwGastos As DataRow() = nConsulta(SQL)
            If rwGastos Is Nothing = False Then
                For Each Fila In rwGastos





                    item = lsvLista.Items.Add("")
                    item.UseItemStyleForSubItems = False
                    If Fila.Item("color") = "0" Then
                        item.SubItems.Item(0).BackColor = Color.White

                    ElseIf Fila.Item("color") = "1" Then
                        item.SubItems.Item(0).BackColor = Color.Yellow
                    ElseIf Fila.Item("color") = "2" Then
                        item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                    ElseIf Fila.Item("color") = "3" Then
                        item.SubItems.Item(0).BackColor = Color.Red
                    ElseIf Fila.Item("color") = "4" Then
                        item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                    ElseIf Fila.Item("color") = "5" Then
                        item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                    End If

                    item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                    If (Fila.Item("serief") = "0") Then
                        item.SubItems.Add("" & "A")
                    ElseIf Fila.Item("serief") = "1" Then
                        item.SubItems.Add("" & "B")
                    ElseIf Fila.Item("serief") = "2" Then
                        item.SubItems.Add("" & "C")
                    ElseIf Fila.Item("serief") = "3" Then
                        item.SubItems.Add("" & "D")
                    End If



                    item.SubItems.Add("" & Fila.Item("numfactura"))
                    item.SubItems.Add("" & Fila.Item("fecha"))
                    item.SubItems.Add("" & Fila.Item("nombreempresa"))
                    item.SubItems.Add("" & Fila.Item("nombrecliente"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                    item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Fila.Item("serien"))
                    item.SubItems.Add("" & Fila.Item("numnota"))
                    item.SubItems.Add("" & Fila.Item("pagoabono"))
                    item.SubItems.Add("" & Fila.Item("comentario"))
                    item.SubItems.Add("" & Fila.Item("comentario2"))
                    item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                    'If (Fila.Item("cancelada") = "0") Then
                    '    item.SubItems.Item(0).BackColor = Color.Red
                    'End If
                    item.SubItems.Add("" & Fila.Item("usuarioc"))
                    item.SubItems.Add("" & Fila.Item("usuariom"))


                    item.Tag = Fila.Item("iIdFactura")
                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
                MessageBox.Show(rwGastos.Count & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub flujob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
        MostrarEmpresa()
    End Sub

    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmddescargar_Click(sender As Object, e As EventArgs) Handles cmddescargar.Click
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim Alter As Boolean = False
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio

        lsvLista.Items.Clear()
        lsvLista.Clear()
        If (tiempo.Days >= 0) Then
            If chktodas.Checked = False Then
                SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
                SQL &= "case when cancelada=0 then 0 else importe end as importe,"
                SQL &= "case when cancelada=0 then 0 else iva end as iva,"
                SQL &= "case when cancelada=0 then 0 else total end as total,"
                SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,"
                SQL &= "ISNULL(color,0) as color,"
                SQL &= "usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " where flujob=1 and fkiIdEmpresa=" & cboempresa.SelectedValue
                SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                SQL &= " order by fecha,iIdFactura asc"

            Else

                SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
                SQL &= "case when cancelada=0 then 0 else importe end as importe,"
                SQL &= "case when cancelada=0 then 0 else iva end as iva,"
                SQL &= "case when cancelada=0 then 0 else total end as total,"
                SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,"
                SQL &= "ISNULL(color,0) as color,"
                SQL &= "usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " where flujob=1  and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

            End If

            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas Is Nothing = False Then
                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("FacturasB")

                hoja.Column("B").Width = 13
                hoja.Column("C").Width = 13
                hoja.Column("D").Width = 13
                hoja.Column("E").Width = 13
                hoja.Column("F").Width = 30
                hoja.Column("G").Width = 30
                hoja.Column("H").Width = 13
                hoja.Column("I").Width = 13
                hoja.Column("J").Width = 13
                hoja.Column("K").Width = 13
                hoja.Column("L").Width = 13
                hoja.Column("M").Width = 35
                hoja.Column("N").Width = 35
                hoja.Column("O").Width = 35
                hoja.Column("P").Width = 35

                'hoja.Cell(2, 2).Value = "Fecha:"
                'hoja.Cell(2, 3).Value = Date.Now.ToShortDateString()

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja.Range(1, 1, 1, 16).Style.Font.FontSize = 10
                hoja.Range(1, 1, 1, 16).Style.Font.SetBold(True)
                hoja.Range(1, 1, 1, 16).Style.Alignment.WrapText = True
                hoja.Range(1, 1, 1, 16).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(1, 1, 1, 16).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(1, 1, 1, 16).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(1, 1, 1, 16).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")


                hoja.Cell(1, 1).Value = "Fecha"
                hoja.Cell(1, 2).Value = "IdPatrona"
                hoja.Cell(1, 3).Value = "NombrePatrona"
                hoja.Cell(1, 4).Value = "IdCliente"
                hoja.Cell(1, 5).Value = "NombreCliente"
                hoja.Cell(1, 6).Value = "DispersiónSA"
                hoja.Cell(1, 7).Value = "%SA"
                hoja.Cell(1, 8).Value = "DispersiónSINDICATO"
                hoja.Cell(1, 9).Value = "%SINDICATO"
                hoja.Cell(1, 10).Value = "NumFactura"
                hoja.Cell(1, 11).Value = "Importe"
                hoja.Cell(1, 12).Value = "Iva"
                hoja.Cell(1, 13).Value = "Total"
                hoja.Cell(1, 14).Value = "EmpresaFacturo"
                hoja.Cell(1, 15).Value = "EmpresaCliente"
                hoja.Cell(1, 16).Value = "idfactura"


                filaExcel = 1
                For Each Fila In rwFilas
                    filaExcel = filaExcel + 1



                    hoja.Cell(filaExcel, 10).Value = Fila.Item("numfactura")
                    hoja.Cell(filaExcel, 11).Value = Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 12).Value = Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 12).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 13).Value = Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 13).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 14).Value = Fila.Item("nombreempresa")
                    hoja.Cell(filaExcel, 15).Value = Fila.Item("nombrecliente")
                    hoja.Cell(filaExcel, 16).Value = Fila.Item("iIdFactura")





                Next

                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "FacturasB"
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
        End If

    End Sub
End Class