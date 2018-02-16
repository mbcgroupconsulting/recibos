Imports ClosedXML.Excel


Public Class frmMostrarflujoconcepto
    Dim SQL As String
    Private Sub frmMostrarflujoconcepto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
        cbonumflujo.Enabled = False

    End Sub

    Private Sub chknumeroflujo_CheckedChanged(sender As Object, e As EventArgs) Handles chknumeroflujo.CheckedChanged
        If chknumeroflujo.Checked = True Then
            cbonumflujo.Enabled = True
        Else
            cbonumflujo.Enabled = False
        End If
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Try
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            lsvLista.Items.Clear()
            lsvLista.Clear()
            If (tiempo.Days >= 0) Then
                If chknumeroflujo.Checked Then
                    If cbonumflujo.SelectedIndex = -1 Then
                        MessageBox.Show("Seleccione un número de flujo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        SQL = "select * from FacturaConcepto where "
                        SQL &= "fechaflujo between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                        SQL &= " and iEstatus=1 and numeroFlujo=" & IIf(rdbInterno.Checked, cbonumflujo.Text, -1)
                        SQL &= " order by fechaflujo"

                    End If


                Else

                    SQL = "select * from FacturaConcepto where "
                    SQL &= "fechaflujo between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and iEstatus=1 and " & IIf(rdbInterno.Checked, "numeroFlujo>0", "numeroFlujo=-1")
                    SQL &= " order by fechaflujo"

                End If


                Dim item As ListViewItem
                lsvLista.Columns.Add("IdFacturaConcepto")
                lsvLista.Columns(0).Width = 170
                lsvLista.Columns.Add("Mov. Flujo")
                lsvLista.Columns(1).Width = 170
                lsvLista.Columns.Add("Mes")
                lsvLista.Columns(2).Width = 100
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(3).Width = 90
                lsvLista.Columns(3).TextAlign = 1
                lsvLista.Columns.Add("Id Cliente")
                lsvLista.Columns(4).Width = 70
                lsvLista.Columns.Add("Cliente")
                lsvLista.Columns(5).Width = 200
                lsvLista.Columns.Add("Mov")
                lsvLista.Columns(6).Width = 50
                lsvLista.Columns.Add("Id Pagadora")
                lsvLista.Columns(7).Width = 70
                lsvLista.Columns.Add("Pagadora")
                lsvLista.Columns(8).Width = 200
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(9).Width = 120
                lsvLista.Columns.Add("IVA")
                lsvLista.Columns(10).Width = 120
                lsvLista.Columns.Add("Total")
                lsvLista.Columns(11).Width = 120
                lsvLista.Columns.Add("Clave Sat")
                lsvLista.Columns(12).Width = 120
                lsvLista.Columns.Add("Concepto")
                lsvLista.Columns(13).Width = 300
                lsvLista.Columns.Add("Num Factura")
                lsvLista.Columns(14).Width = 150



                Dim sumatoria As Double

                Dim rwFacturasConcepto As DataRow() = nConsulta(SQL)
                If rwFacturasConcepto Is Nothing = False Then
                    For Each Fila In rwFacturasConcepto




                        item = lsvLista.Items.Add("" & Fila.Item("iIdFacturaConcepto"))

                        item.SubItems.Add("" & Fila.Item("NumeroFlujo"))
                        item.SubItems.Add("" & MonthName(Date.Parse(Fila.Item("FechaFlujo")).Month))
                        item.SubItems.Add("" & Fila.Item("FechaFlujo"))
                        item.SubItems.Add("")
                        item.SubItems.Add("" & Fila.Item("Cliente"))
                        item.SubItems.Add("" & Fila.Item("Tipo"))
                        item.SubItems.Add("")
                        item.SubItems.Add("" & Fila.Item("Prestadora"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("subtotal"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Fila.Item("ClaveSat"))
                        item.SubItems.Add("" & Fila.Item("Concepto"))

                        If Fila.Item("fkiIdFactura").ToString = "0" Then
                            item.SubItems.Add("")
                        Else
                            'Buscamos el numero de factura
                            SQL = "select * from facturas where "
                            SQL &= "iIdFactura=" & Fila.Item("fkiIdFactura").ToString


                            Dim rwNumFactura As DataRow() = nConsulta(SQL)
                            If rwNumFactura Is Nothing = False Then
                                item.SubItems.Add("" & rwNumFactura(0)("numfactura").ToString)

                            End If

                        End If






                        item.Tag = Fila.Item("iIdFacturaConcepto")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                        Alter = Not Alter
                        sumatoria = sumatoria + Double.Parse(Fila.Item("total"))

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

    Private Sub cmdexcel_Click(sender As Object, e As EventArgs) Handles cmdexcel.Click
        Try
            Dim filaExcel As Integer = 5
            Dim dialogo As New SaveFileDialog()
            Dim idtipo As Integer
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            If (tiempo.Days >= 0) Then
                If chknumeroflujo.Checked Then
                    If cbonumflujo.SelectedIndex = -1 Then
                        MessageBox.Show("Seleccione un número de flujo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else
                        SQL = "select * from FacturaConcepto where "
                        SQL &= "fechaflujo between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                        SQL &= " and iEstatus=1 and numeroFlujo=" & IIf(rdbInterno.Checked, cbonumflujo.Text, -1)
                        SQL &= " order by fechaflujo"

                    End If


                Else

                    SQL = "select * from FacturaConcepto where "
                    SQL &= "fechaflujo between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and iEstatus=1 and " & IIf(rdbInterno.Checked, "numeroFlujo>0", "numeroFlujo=-1")
                    SQL &= " order by fechaflujo"

                End If



                Dim sumatoria As Double
                sumatoria = 0

                Dim rwFacturasConcepto As DataRow() = nConsulta(SQL)
                If rwFacturasConcepto Is Nothing = False Then

                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Flujo")
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

                    hoja.Range(1, 1, 1, 15).Style.Font.FontSize = 10
                    hoja.Range(1, 1, 1, 15).Style.Font.SetBold(True)
                    hoja.Range(1, 1, 1, 15).Style.Alignment.WrapText = True
                    hoja.Range(1, 1, 1, 15).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(1, 1, 1, 15).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(1, 1, 1, 15).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(1, 1, 1, 15).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"

                    hoja.Cell(1, 1).Value = "IdFacturaConcepto"
                    hoja.Cell(1, 2).Value = "Mov. Flujo"
                    hoja.Cell(1, 3).Value = "Mes"
                    hoja.Cell(1, 4).Value = "Fecha"
                    hoja.Cell(1, 5).Value = "Id Cliente"
                    hoja.Cell(1, 6).Value = "Cliente"
                    hoja.Cell(1, 7).Value = "Mov"
                    hoja.Cell(1, 8).Value = "Id Pagadora"
                    hoja.Cell(1, 9).Value = "Pagadora"
                    hoja.Cell(1, 10).Value = "Importe"
                    hoja.Cell(1, 11).Value = "IVA"
                    hoja.Cell(1, 12).Value = "Total"
                    hoja.Cell(1, 13).Value = "Clave Sat"
                    hoja.Cell(1, 14).Value = "Concepto"
                    hoja.Cell(1, 15).Value = "Num Factura"


                    filaExcel = 1
                    For Each Fila In rwFacturasConcepto
                        filaExcel = filaExcel + 1
                        hoja.Cell(filaExcel, 1).Value = Fila.Item("iIdFacturaConcepto")
                        hoja.Cell(filaExcel, 2).Value = Fila.Item("NumeroFlujo")
                        hoja.Cell(filaExcel, 3).Value = MonthName(Date.Parse(Fila.Item("FechaFlujo")).Month)
                        hoja.Cell(filaExcel, 4).Value = Fila.Item("FechaFlujo")
                        hoja.Cell(filaExcel, 5).Value = ""
                        hoja.Cell(filaExcel, 6).Value = Fila.Item("Cliente")
                        hoja.Cell(filaExcel, 7).Value = Fila.Item("Tipo")
                        hoja.Cell(filaExcel, 8).Value = ""
                        hoja.Cell(filaExcel, 9).Value = Fila.Item("Prestadora")
                        hoja.Cell(filaExcel, 10).Value = Format(CType(Fila.Item("subtotal"), Decimal), "###,###,##0.#0")
                        hoja.Cell(filaExcel, 11).Value = Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0")
                        hoja.Cell(filaExcel, 12).Value = Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0")
                        hoja.Cell(filaExcel, 13).Value = Fila.Item("ClaveSat")
                        hoja.Cell(filaExcel, 14).Value = Fila.Item("Concepto")

                        If Fila.Item("fkiIdFactura").ToString = "0" Then
                            hoja.Cell(filaExcel, 15).Value = ""
                        Else
                            'Buscamos el numero de factura
                            SQL = "select * from facturas where "
                            SQL &= "iIdFactura=" & Fila.Item("fkiIdFactura").ToString


                            Dim rwNumFactura As DataRow() = nConsulta(SQL)
                            If rwNumFactura Is Nothing = False Then
                                hoja.Cell(filaExcel, 15).Value = rwNumFactura(0)("numfactura").ToString

                            End If

                        End If





                        hoja.Range(2, 9, 1500, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")



                    Next

                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Flujo"
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

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate


        Try

            If lsvLista.SelectedItems.Count > 0 Then
                Dim item As ListViewItem = lsvLista.SelectedItems(0)
                If item.SubItems(1).Text = "-1" And rdbExterno.Checked Then

                    SQL = "select * from usuarios"
                    SQL &= " inner join CatPerfiles on usuarios.fkIdPerfil=CatPerfiles.IdPerfil"
                    SQL &= " where idUsuario = " & idUsuario

                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    If rwFilas Is Nothing = False Then


                        Dim Fila As DataRow = rwFilas(0)

                        If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "6") Then
                            Dim resultado As Integer = MessageBox.Show("¿Desea agregar el concepto y clave?", "Pregunta", MessageBoxButtons.YesNo)

                            If resultado = DialogResult.Yes Then
                                Dim Forma As New frmAgregarConceptos
                                Forma.gIdConcepto = item.Tag

                                Forma.ShowDialog()

                                cmdbuscar_Click(sender, e)


                            End If




                            'EditarFactura(lsvLista.SelectedItems(0).Tag)
                        End If
                    End If



                End If

            End If




        Catch ex As Exception

        End Try
    End Sub
End Class