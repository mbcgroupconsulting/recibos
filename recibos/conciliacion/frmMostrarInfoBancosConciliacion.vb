Imports ClosedXML.Excel

Public Class frmMostrarInfoBancosConciliacion
    Dim SQL As String
    Private Sub cmdbuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdbuscar.Click
        Try
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            lsvLista.Items.Clear()
            lsvLista.Clear()
            If (tiempo.Days >= 0) Then
                
                SQL = "select iIdConciliacion,cBanco,nombre,dFechaMovimiento,cConcepto,fCargo,fAbono,fSaldo,"
                SQL &= "cDatosfactura,cUsuario,iEstatus2 from (conciliacion "
                SQL &= " inner join bancos on conciliacion.fkiIdBanco=bancos.iIdBanco)"
                SQL &= " inner join empresa on conciliacion.fkiIdEmpresa = empresa.iIdEmpresa where "
                SQL &= " dFechaMovimiento between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                SQL &= " and fkiIdBanco=" & cbobanco.SelectedValue & " and fkiIdEmpresa=" & cboempresa.SelectedValue
                SQL &= " and conciliacion.iEstatus=1 "
                SQL &= " order by dFechaMovimiento"

                Dim item As ListViewItem
                lsvLista.Columns.Add("iIdConciliacion")
                lsvLista.Columns(0).Width = 90
                lsvLista.Columns.Add("Banco")
                lsvLista.Columns(1).Width = 200
                lsvLista.Columns.Add("Empresa")
                lsvLista.Columns(2).Width = 200
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(3).Width = 100
                lsvLista.Columns.Add("Concepto")
                lsvLista.Columns(4).Width = 250
                lsvLista.Columns.Add("Cargo")
                lsvLista.Columns(5).Width = 110
                lsvLista.Columns(5).TextAlign = 1
                lsvLista.Columns.Add("Abono")
                lsvLista.Columns(6).Width = 110
                lsvLista.Columns(6).TextAlign = 1
                lsvLista.Columns.Add("Saldo")
                lsvLista.Columns(7).Width = 110
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Datos Factura")
                lsvLista.Columns(8).Width = 250
                lsvLista.Columns.Add("Usuario")
                lsvLista.Columns(8).Width = 100




                Dim rwFacturasConcepto As DataRow() = nConsulta(SQL)
                If rwFacturasConcepto Is Nothing = False Then
                    For Each Fila In rwFacturasConcepto

                        item = lsvLista.Items.Add("" & Fila.Item("iIdConciliacion"))
                        item.SubItems.Add("" & Fila.Item("cBanco"))
                        item.SubItems.Add("" & Fila.Item("nombre"))
                        item.SubItems.Add("" & Fila.Item("dFechaMovimiento"))
                        item.SubItems.Add("" & Fila.Item("cConcepto"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("fCargo"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("fAbono"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("fSaldo"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Fila.Item("cDatosfactura"))
                        item.SubItems.Add("" & Fila.Item("cUsuario"))
                        item.Tag = Fila.Item("iIdConciliacion")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                        Alter = Not Alter


                    Next

                    MessageBox.Show(rwFacturasConcepto.Count & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmMostrarInfoBancosConciliacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MostrarEmpresa()
        MostrarBancos()
    End Sub

    Private Sub MostrarBancos()
        Sql = "Select * from bancos order by cBanco"
        nCargaCBO(cbobanco, Sql, "cBanco", "iIdBanco")
        'cbobanco.SelectedIndex = 0
    End Sub
    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            Sql = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, Sql, "nombre", "iIdEmpresa")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdexcel_Click(sender As System.Object, e As System.EventArgs) Handles cmdexcel.Click
        Try
            Dim filaExcel As Integer = 5
            Dim dialogo As New SaveFileDialog()
            Dim idtipo As Integer
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            If (tiempo.Days >= 0) Then

                SQL = "select iIdConciliacion,cBanco,nombre,dFechaMovimiento,cConcepto,fCargo,fAbono,fSaldo,"
                SQL &= "cDatosfactura,cUsuario,iEstatus2 from (conciliacion "
                SQL &= " inner join bancos on conciliacion.fkiIdBanco=bancos.iIdBanco)"
                SQL &= " inner join empresa on conciliacion.fkiIdEmpresa = empresa.iIdEmpresa where "
                SQL &= " dFechaMovimiento between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                SQL &= " and fkiIdBanco=" & cbobanco.SelectedValue & " and fkiIdEmpresa=" & cboempresa.SelectedValue
                SQL &= " and conciliacion.iEstatus=1 "
                SQL &= " order by dFechaMovimiento"

                Dim rwFacturasConcepto As DataRow() = nConsulta(SQL)
                If rwFacturasConcepto Is Nothing = False Then

                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Movimientos")
                    hoja.Column("A").Width = 20
                    hoja.Column("B").Width = 15
                    hoja.Column("C").Width = 15
                    hoja.Column("D").Width = 12
                    hoja.Column("E").Width = 12
                    hoja.Column("F").Width = 25
                    hoja.Column("G").Width = 15
                    hoja.Column("H").Width = 15
                    hoja.Column("I").Width = 25
                    hoja.Column("J").Width = 15
                    hoja.Column("K").Width = 15
                    hoja.Column("L").Width = 15
                    hoja.Column("M").Width = 15
                    hoja.Column("N").Width = 50
                    hoja.Column("O").Width = 12

                    hoja.Range(1, 1, 1, 10).Style.Font.FontSize = 10
                    hoja.Range(1, 1, 1, 10).Style.Font.SetBold(True)
                    hoja.Range(1, 1, 1, 10).Style.Alignment.WrapText = True
                    hoja.Range(1, 1, 1, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(1, 1, 1, 10).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(1, 1, 1, 10).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(1, 1, 1, 10).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"

                    hoja.Cell(1, 1).Value = "iIdConciliacion"
                    hoja.Cell(1, 2).Value = "Banco"
                    hoja.Cell(1, 3).Value = "Empresa"
                    hoja.Cell(1, 4).Value = "Fecha"
                    hoja.Cell(1, 5).Value = "Concepto"
                    hoja.Cell(1, 6).Value = "Cargo"
                    hoja.Cell(1, 7).Value = "Abono"
                    hoja.Cell(1, 8).Value = "Saldo"
                    hoja.Cell(1, 9).Value = "Datos Factura"
                    hoja.Cell(1, 10).Value = "Usuario"
                    


                    filaExcel = 1
                    For Each Fila In rwFacturasConcepto
                        filaExcel = filaExcel + 1
                        hoja.Cell(filaExcel, 1).Value = Fila.Item("iIdConciliacion")
                        hoja.Cell(filaExcel, 2).Value = Fila.Item("cBanco")
                        hoja.Cell(filaExcel, 3).Value = Fila.Item("nombre")
                        hoja.Cell(filaExcel, 4).Value = Fila.Item("dFechaMovimiento")
                        hoja.Cell(filaExcel, 5).Value = Fila.Item("cConcepto")
                        hoja.Cell(filaExcel, 6).Value = Fila.Item("fCargo")
                        hoja.Cell(filaExcel, 7).Value = Fila.Item("fAbono")
                        hoja.Cell(filaExcel, 8).Value = Fila.Item("fSaldo")
                        hoja.Cell(filaExcel, 9).Value = Fila.Item("cDatosfactura")
                        hoja.Cell(filaExcel, 10).Value = Fila.Item("cUsuario")
                        





                        hoja.Range(2, 6, 1500, 8).Style.NumberFormat.SetFormat("###,###,##0.#0")



                    Next

                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Movimientos"
                    dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                    dialogo.ShowDialog()
                    libro.SaveAs(dialogo.FileName)
                    'libro.SaveAs("c:\temp\control.xlsx")
                    'libro.SaveAs(dialogo.FileName)
                    'apExcel.Quit()
                    libro = Nothing
                    MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If



        Catch ex As Exception

        End Try
    End Sub
End Class