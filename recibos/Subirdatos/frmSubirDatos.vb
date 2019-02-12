Imports ClosedXML.Excel
Imports System.IO
Imports System.Text.RegularExpressions
Public Class frmSubirDatos
    Dim sheetIndex As Integer = -1
    Dim SQL As String
    Dim contacolumna As Integer
    Public dsReporte As New DataSet

    Private Sub frmSubirDatos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub tsbImportar_Click(sender As System.Object, e As System.EventArgs) Handles tsbImportar.Click
        Dim dialogo As New OpenFileDialog
        lblRuta.Text = ""
        With dialogo
            .Title = "Búsqueda de archivos de saldos."
            .Filter = "Hoja de cálculo de excel (xlsx)|*.xlsx;"
            .CheckFileExists = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                lblRuta.Text = .FileName
            End If
        End With
        tsbProcesar.Enabled = lblRuta.Text.Length > 0
        If tsbProcesar.Enabled Then
            tsbProcesar_Click(sender, e)
        End If
    End Sub

    Private Sub tsbProcesar_Click(sender As System.Object, e As System.EventArgs) Handles tsbProcesar.Click
        lsvLista.Items.Clear()
        lsvLista.Columns.Clear()
        lsvLista.Clear()

        pnlCatalogo.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        lsvLista.Visible = False
        tsbImportar.Enabled = False
        Me.cmdCerrar.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        Application.DoEvents()

        Try
            If File.Exists(lblRuta.Text) Then
                Dim Archivo As String = lblRuta.Text
                Dim Hoja As String


                Dim book As New ClosedXML.Excel.XLWorkbook(Archivo)
                If book.Worksheets.Count >= 1 Then
                    sheetIndex = 1
                    If book.Worksheets.Count > 1 Then
                        Dim Forma As New frmHojasNomina
                        Dim Hojas As String = ""
                        For i As Integer = 0 To book.Worksheets.Count - 1
                            Hojas &= book.Worksheets(i).Name & IIf(i < (book.Worksheets.Count - 1), "|", "")
                        Next
                        Forma.Hojas = Hojas
                        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                            sheetIndex = Forma.selectedIndex + 1
                        Else
                            Exit Sub
                        End If
                    End If
                    Hoja = book.Worksheet(sheetIndex).Name
                    Dim sheet As IXLWorksheet = book.Worksheet(sheetIndex)

                    Dim colIni As Integer = sheet.FirstColumnUsed().ColumnNumber()
                    Dim colFin As Integer = sheet.LastColumnUsed().ColumnNumber()
                    Dim Columna As String
                    Dim numerocolumna As Integer = 1


                    lsvLista.Columns.Add("#")
                    For c As Integer = colIni To colFin

                        lsvLista.Columns.Add(sheet.Cell(1, c).Value.ToString)
                        'lsvLista.Columns.Add(numerocolumna)
                        'numerocolumna = numerocolumna + 1

                    Next

                    'lsvLista.Columns.Add("conciliacion")
                    'lsvLista.Columns.Add("color")

                    lsvLista.Columns(1).Width = 100

                    lsvLista.Columns(2).Width = 100
                    lsvLista.Columns(3).Width = 450
                    lsvLista.Columns(4).Width = 50
                    lsvLista.Columns(5).Width = 100
                    lsvLista.Columns(5).TextAlign = HorizontalAlignment.Right
                    lsvLista.Columns(6).Width = 100
                    lsvLista.Columns(6).TextAlign = HorizontalAlignment.Right
                    lsvLista.Columns(7).Width = 100
                    lsvLista.Columns(7).TextAlign = HorizontalAlignment.Right
                    lsvLista.Columns(8).Width = 100
                    lsvLista.Columns(8).TextAlign = HorizontalAlignment.Right
                    'lsvLista.Columns(9).Width = 150
                    'lsvLista.Columns(10).Width = 100
                    'lsvLista.Columns(11).Width = 400





                    Dim Filas As Long = sheet.RowsUsed().Count()
                    For f As Integer = 2 To Filas
                        Dim item As ListViewItem = lsvLista.Items.Add((f - 1).ToString())
                        For c As Integer = colIni To colFin
                            Try

                                Dim Valor As String = ""
                                If (sheet.Cell(f, c).ValueCached Is Nothing) Then
                                    Valor = sheet.Cell(f, c).Value.ToString()
                                Else
                                    Valor = sheet.Cell(f, c).ValueCached.ToString()
                                End If
                                Valor = Valor.Trim()
                                item.SubItems.Add(Valor)


                                If f = 6 And c >= 12 Then

                                    'If Valor <> "" AndAlso InStr(Valor, "-") > 0 Then
                                    '    Dim sValores() As String = Valor.Split("-")
                                    '    Select Case sValores(0).ToUpper()
                                    '        Case "P"
                                    '            item.SubItems(item.SubItems.Count - 1).Tag = "1" 'Percepción
                                    '        Case "D"
                                    '            item.SubItems(item.SubItems.Count - 1).Tag = "2" 'Deducción
                                    '        Case "I"
                                    '            item.SubItems(item.SubItems.Count - 1).Tag = "3" 'Incapacidad
                                    '    End Select
                                    '    Valor = sValores(1).Trim()
                                    'End If
                                    item.SubItems(item.SubItems.Count - 1).Text = Valor
                                End If



                            Catch ex As Exception

                            End Try

                        Next
                    Next

                    book.Dispose()
                    book = Nothing
                    GC.Collect()
                    'If lsvNominaFile.Items.Count >= 9 Then
                    '    If chkTipo.Checked Then
                    '        ProcesarNomina()
                    '    Else
                    '        ProcesarNomina1()
                    '    End If

                    'End If
                    pnlCatalogo.Enabled = True
                    If lsvLista.Items.Count = 0 Then
                        MessageBox.Show("El catálogo no puso ser importado o no contiene registros." & vbCrLf & "¿Por favor verifique?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        MessageBox.Show("Se han encontrado " & FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tsbGuardar.Enabled = True
                        tsbCancelar.Enabled = True
                        tsbAgregar.Enabled = True
                        lblRuta.Text = FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo."
                        Me.Enabled = True
                        Me.cmdCerrar.Enabled = True
                        Me.Cursor = Cursors.Default
                        tsbImportar.Enabled = True
                        lsvLista.Visible = True
                    End If




                ElseIf book.Worksheets.Count = 0 Then
                    MessageBox.Show("El archivo no contiene hojas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("El archivo ya no se encuentra en la ruta indicada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function getColumnName(index As Single) As String
        Dim numletter As Single = 26
        Dim sGrupo As Single = index / numletter
        Dim Modulo As Single = sGrupo - Math.Truncate(sGrupo)

        If Modulo = 0 Then Modulo = 1
        Dim Grupo As Integer = sGrupo - Modulo

        Dim Indice As Integer = index - (Grupo * numletter)
        Dim ColumnName As String = ""

        If Grupo > 0 Then
            ColumnName = Chr(64 + Grupo)
        End If
        ColumnName &= Chr(64 + Indice)
        Return ColumnName

    End Function

    Private Sub tsbCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancelar.Click
        pnlCatalogo.Enabled = False
        lsvLista.Items.Clear()
        chkAll.Checked = False
        lblRuta.Text = ""
        tsbImportar.Enabled = False
        tsbProcesar.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        tsbAgregar.Enabled = False
        tsbNuevo.Enabled = True
    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGuardar.Click
        Try
            'Dim resultado As Integer = MessageBox.Show("Solo se agregaran los registros seleccionados y en color verde, ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)
            Dim filaExcel As Integer = 5
            Dim tipo As Boolean
            Dim dialogo As New SaveFileDialog()
            dsReporte.Tables.Add("Tabla")
            dsReporte.Tables("Tabla").Columns.Add("FechaO")
            dsReporte.Tables("Tabla").Columns.Add("FechaL")
            dsReporte.Tables("Tabla").Columns.Add("Nombre")
            dsReporte.Tables("Tabla").Columns.Add("Descripcion")
            dsReporte.Tables("Tabla").Columns.Add("Cuenta")
            dsReporte.Tables("Tabla").Columns.Add("Cargo")
            Dim mensaje As String
            pnlProgreso.Visible = True
            pnlCatalogo.Enabled = False
            Application.DoEvents()

            Dim IdProducto As Long
            Dim i As Integer = 0
            Dim conta As Integer = 0
            pgbProgreso.Minimum = 0
            pgbProgreso.Value = 0
            pgbProgreso.Maximum = lsvLista.Items.Count + 5


            For f As Integer = 0 To lsvLista.Items.Count - 1



                If Trim(lsvLista.Items(f).SubItems(5).Text) <> "" Then
                    Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow
                    fila.Item("FechaO") = lsvLista.Items(f).SubItems(1).Text
                    fila.Item("FechaL") = lsvLista.Items(f).SubItems(2).Text
                    fila.Item("Descripcion") = lsvLista.Items(f).SubItems(3).Text
                    fila.Item("Cargo") = lsvLista.Items(f).SubItems(5).Text
                    If (Trim(lsvLista.Items(f + 1).SubItems(5).Text) = "" And Trim(lsvLista.Items(f + 1).SubItems(6).Text) = "") And (Trim(lsvLista.Items(f + 2).SubItems(5).Text) = "" And Trim(lsvLista.Items(f + 2).SubItems(6).Text) = "") Then
                        fila.Item("Nombre") = lsvLista.Items(f + 4).SubItems(3).Text
                        fila.Item("Cuenta") = lsvLista.Items(f + 2).SubItems(3).Text

                    Else
                        If lsvLista.Items(f + 1).SubItems(5).Text <> "" Then
                            fila.Item("Nombre") = lsvLista.Items(f).SubItems(3).Text
                            fila.Item("Cuenta") = ""
                        Else
                            fila.Item("Nombre") = lsvLista.Items(f).SubItems(3).Text
                            fila.Item("Cuenta") = lsvLista.Items(f + 1).SubItems(3).Text
                        End If



                    End If

                    dsReporte.Tables("Tabla").Rows.Add(fila)

                End If




                pgbProgreso.Value += 1
            Next

                    'For Each producto As ListViewItem In lsvLista.CheckedItems

                    '    If Trim(producto.SubItems(5).Text) <> "" Then
                    '        Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow
                    '        fila.Item("FechaO") = Trim(producto.SubItems(1).Text)
                    '        fila.Item("FechaL") = Trim(producto.SubItems(2).Text)
                    '        fila.Item("Nombre") = Trim(producto.SubItems(3).Text)
                    '        fila.Item("Descripcion") = Trim(producto.SubItems(3).Text)
                    '        fila.Item("Cuenta") = Trim(producto.SubItems(17).Text)
                    '        fila.Item("Cargo") = Trim(producto.SubItems(17).Text)

                    '        dsReporte.Tables("Tabla").Rows.Add(fila)
                    '    End If



                    '    SQL = "select * from empleadosC where cCodigoEmpleado = " & Trim(producto.SubItems(1).Text).Substring(2, 4)
                    '    Dim rwFilas As DataRow() = nConsulta(SQL)


                    '    pgbProgreso.Value += 1

                    'Next

                    'Enviar correo
                    'Enviar_Mail(GenerarCorreoFlujo("Importación Flujo-Conceptos", "Área Facturación", "Se importo un flujo con los conceptos necesarios"), "g.gomez@mbcgroup.mx", "Importación")





                    'tsbCancelar_Click(sender, e)

            pnlProgreso.Visible = False


            pgbProgreso.Minimum = 0
            pgbProgreso.Value = 0
            pgbProgreso.Maximum = dsReporte.Tables("Tabla").Rows.Count + 1


            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

            hoja.Column("B").Width = 15
            hoja.Column("C").Width = 15
            hoja.Column("D").Width = 40
            hoja.Column("E").Width = 40
            hoja.Column("F").Width = 20
            hoja.Column("G").Width = 15

            hoja.Cell(2, 2).Value = "Fecha:"
            hoja.Cell(2, 3).Value = Date.Now.ToShortDateString()

            'hoja.Cell(3, 2).Value = ":"
            'hoja.Cell(3, 3).Value = ""

            hoja.Range(4, 2, 4, 7).Style.Font.FontSize = 10
            hoja.Range(4, 2, 4, 7).Style.Font.SetBold(True)
            hoja.Range(4, 2, 4, 7).Style.Alignment.WrapText = True
            hoja.Range(4, 2, 4, 7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja.Range(4, 1, 4, 7).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja.Range(4, 2, 4, 7).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja.Range(4, 2, 4, 7).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            'hoja.Cell(4, 1).Value = "Num"


            hoja.Cell(4, 2).Value = "Fecha Op"
            hoja.Cell(4, 3).Value = "Fecha Liq"
            hoja.Cell(4, 4).Value = "Nombre"
            hoja.Cell(4, 5).Value = "Descripción"
            hoja.Cell(4, 6).Value = "Cuenta"
            hoja.Cell(4, 7).Value = "Cargo"




            filaExcel = 4
            For z As Integer = 0 To dsReporte.Tables("Tabla").Rows.Count - 1

                filaExcel = filaExcel + 1
                


                hoja.Cell(filaExcel, 2).Value = dsReporte.Tables("Tabla").Rows(z)("FechaO")
                hoja.Cell(filaExcel, 3).Value = dsReporte.Tables("Tabla").Rows(z)("FechaL")
                hoja.Cell(filaExcel, 4).Value = dsReporte.Tables("Tabla").Rows(z)("Nombre")
                hoja.Cell(filaExcel, 5).Value = dsReporte.Tables("Tabla").Rows(z)("Descripcion")
                hoja.Cell(filaExcel, 6).Value = "'" & dsReporte.Tables("Tabla").Rows(z)("Cuenta")
                hoja.Cell(filaExcel, 7).Value = Format(CType(dsReporte.Tables("Tabla").Rows(z)("Cargo"), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 7).Style.NumberFormat.SetFormat("###,###,##0.#0")





            Next

            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Salida"
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            libro.SaveAs(dialogo.FileName)
            'libro.SaveAs("c:\temp\control.xlsx")
            'libro.SaveAs(dialogo.FileName)
            'apExcel.Quit()
            libro = Nothing




            pnlProgreso.Visible = False

            MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            pnlCatalogo.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsbAgregar_Click(sender As System.Object, e As System.EventArgs) Handles tsbAgregar.Click

    End Sub
End Class