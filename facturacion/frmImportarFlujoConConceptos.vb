Imports ClosedXML.Excel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmImportarFlujoConConceptos
    Dim sheetIndex As Integer = -1
    Dim SQL As String
    Dim contacolumna As Integer
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
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

    Private Sub tsbProcesar_Click(sender As Object, e As EventArgs) Handles tsbProcesar.Click
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
                    'A IdFactura Concepto
                    lsvLista.Columns(1).Width = 90
                    'B Numero flujo
                    lsvLista.Columns(2).Width = 70
                    'C Mes
                    lsvLista.Columns(3).Width = 100
                    'D Fecha
                    lsvLista.Columns(4).Width = 90
                    'E idCLiente
                    lsvLista.Columns(5).Width = 50
                    'F Nombre cliente
                    lsvLista.Columns(6).Width = 100
                    'G Tipo flujo
                    lsvLista.Columns(7).Width = 50
                    'H id pagadora
                    lsvLista.Columns(8).Width = 50
                    'I pagadora
                    lsvLista.Columns(9).Width = 100
                    'J importe
                    lsvLista.Columns(10).Width = 100
                    lsvLista.Columns(10).TextAlign = 1
                    'K iva
                    lsvLista.Columns(11).Width = 100
                    lsvLista.Columns(11).TextAlign = 1
                    'L total
                    lsvLista.Columns(12).Width = 100
                    lsvLista.Columns(12).TextAlign = 1
                    'M clave sat
                    lsvLista.Columns(13).Width = 100
                    'N nombre concepto
                    lsvLista.Columns(14).Width = 150
                    'O num factura nombre concepto
                    lsvLista.Columns(15).Width = 100




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

    Private Sub tsbGuardar_Click(sender As Object, e As EventArgs) Handles tsbGuardar.Click
        Dim SQL As String, nombresistema As String = ""
        Try
            If lsvLista.CheckedItems.Count > 0 Then
                Dim mensaje As String


                pnlProgreso.Visible = True
                pnlCatalogo.Enabled = False
                Application.DoEvents()


                Dim IdProducto As Long
                Dim i As Integer = 0
                Dim conta As Integer = 0
                Dim IdFactura1 As String
                IdFactura1 = ""

                pgbProgreso.Minimum = 0
                pgbProgreso.Value = 0
                pgbProgreso.Maximum = lsvLista.CheckedItems.Count


                'Dim fila As New DataRow
                SQL = "Select * from usuarios where idUsuario = " & idUsuario
                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim Fila As DataRow = rwFilas(0)
                    nombresistema = Fila.Item("nombre")
                End If

                For Each producto As ListViewItem In lsvLista.CheckedItems

                    If Trim(producto.SubItems(7).Text).Replace(" ", "") = "F" Then
                        'Insertar nuevo
                        SQL = "EXEC setfacturasInsertar 0," & Trim(producto.SubItems(8).Text) & "," & Trim(producto.SubItems(5).Text)
                        SQL &= ",'" & Format(Date.Parse(Mid((Trim(producto.SubItems(4).Text)), 1, 10)), "yyyy/dd/MM")

                        If Trim(nombresistema) = "Guadalupe" Or Trim(nombresistema) = "David" Then
                            SQL &= "'," & IIf(Trim(producto.SubItems(15).Text) = "", 0, Trim(producto.SubItems(15).Text))
                        Else
                            SQL &= "',0" '& IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))
                        End If

                        'SQL &= "',0" '& IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))
                        SQL &= "," & ((IIf(Trim(producto.SubItems(10).Text) = "", 0, Trim(producto.SubItems(10).Text))).ToString.Replace(",", "")).Replace(" ", "")
                        SQL &= "," & ((IIf(Trim(producto.SubItems(11).Text) = "", 0, Trim(producto.SubItems(11).Text))).ToString.Replace(",", "")).Replace(" ", "")
                        SQL &= "," & ((IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))).ToString.Replace(",", "")).Replace(" ", "")
                        SQL &= ",'','',1"
                        SQL &= ",'" & nombresistema & "','" & nombresistema
                        SQL &= "',1,0" ' pendiente = 0 pagada =1 
                        SQL &= ",0,'',0,0"
                        SQL &= ",1,'','" & Date.Now.ToShortDateString() & "',0,0,0"






                        If Execute(SQL, IdFactura1) = False Then
                            MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(4).Text) & " Cliente:" & Trim(producto.SubItems(6).Text) & " Intermediaria/pagadora:" & Trim(producto.SubItems(9).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If


                        'Actualizamos la tabla de los conceptos con los datos de la factura
                        'Debemos obtener el numero del iIdFactura que acabamos de agregar



                        SQL = "update FacturaConcepto set fkiIdFactura=" & IdFactura1
                        SQL &= " where iIdFacturaConcepto=" & IIf(Trim(producto.SubItems(1).Text) = "", 0, Trim(producto.SubItems(1).Text))



                        If nExecute(SQL) = False Then
                            MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(4).Text) & " Cliente:" & Trim(producto.SubItems(6).Text) & " Intermediaria/pagadora:" & Trim(producto.SubItems(9).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If


                        pgbProgreso.Value += 1
                        Application.DoEvents()
                    Else
                        MessageBox.Show("El caracter en tipo de movimientos tiene espacios o no es una letra F, este error es en el numero de factura:" & ((IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))).ToString.Replace(",", "")).Replace(" ", ""), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If









                Next
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False

            Else

                MessageBox.Show("Por favor seleccione al menos una registro para importar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        pnlCatalogo.Enabled = False
        lsvLista.Items.Clear()
        chkAll.Checked = False
        lblRuta.Text = ""
        tsbImportar.Enabled = False
        tsbProcesar.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        tsbNuevo.Enabled = True
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub
End Class