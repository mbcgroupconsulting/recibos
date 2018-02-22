Imports ClosedXML.Excel
Imports System.IO
Imports System.Text.RegularExpressions
Public Class frmSubirInfoBancosConciliacion

    Dim sheetIndex As Integer = -1
    Dim SQL As String
    Dim contacolumna As Integer
    Public gIdFactura As String

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub frmSubirInfoBancosConciliacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

                        lsvLista.Columns.Add(numerocolumna)
                        numerocolumna = numerocolumna + 1

                    Next

                    lsvLista.Columns.Add("conciliacion")
                    lsvLista.Columns.Add("color")

                    lsvLista.Columns(1).Width = 90
                    lsvLista.Columns(2).Width = 400
                    lsvLista.Columns(3).Width = 100
                    lsvLista.Columns(3).TextAlign = 1
                    lsvLista.Columns(4).Width = 100
                    lsvLista.Columns(4).TextAlign = 1
                    lsvLista.Columns(5).Width = 100
                    lsvLista.Columns(5).TextAlign = 1
                    lsvLista.Columns(6).Width = 350

                    Dim Filas As Long = sheet.RowsUsed().Count()
                    For f As Integer = 1 To Filas
                        Dim item As ListViewItem = lsvLista.Items.Add(f.ToString())
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

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGuardar.Click
        Dim SQL As String, nombresistema As String = ""
        Dim Guardar As String

        Try
            If lsvLista.CheckedItems.Count > 0 Then
                Dim mensaje As String
                Dim idConciliacion As String


                pnlProgreso.Visible = True
                pnlCatalogo.Enabled = False
                Application.DoEvents()


                Dim IdProducto As Long
                Dim i As Integer = 0
                Dim conta As Integer = 0


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
                    Guardar = "1"
                    idConciliacion = ""
                    'validar si existe el movimiento en la fecha

                    SQL = "select * from conciliacion where fkiIdBanco=" & cbobanco.SelectedValue
                    SQL &= " and fkiIdEmpresa=" & cboempresa.SelectedValue
                    SQL &= " and dFechaMovimiento='" & CDate(producto.SubItems(CInt(NudFecha.Value)).Text).ToShortDateString
                    SQL &= "' and fCargo=" & IIf(producto.SubItems(CInt(NudCargo.Value)).Text = "", "0", producto.SubItems(CInt(NudCargo.Value)).Text)
                    SQL &= " and fAbono=" & IIf(producto.SubItems(CInt(NudAbono.Value)).Text = "", "0", producto.SubItems(CInt(NudAbono.Value)).Text)
                    SQL &= " and fSaldo=" & IIf(producto.SubItems(CInt(NudSaldo.Value)).Text = "", "0", producto.SubItems(CInt(NudSaldo.Value)).Text)

                    Dim rwEncontrar As DataRow() = nConsulta(SQL)

                    If rwEncontrar Is Nothing = False Then
                        'Verificar si el dato ya tiene un gasto o factura asociada
                        If rwEncontrar(0)("iEstatus2") = "2" Then
                            MessageBox.Show("El siguiente registro ya se encuentra guardado en la base de datos. Y ya fue conciliado. Fecha:" & producto.SubItems(CInt(NudFecha.Value)).Text & " Cargo:" & producto.SubItems(CInt(NudCargo.Value)).Text & " Abono:" & producto.SubItems(CInt(NudAbono.Value)).Text & " Saldo:" & producto.SubItems(CInt(NudSaldo.Value)).Text & ". El proceso omitira este registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Guardar = "2"
                        Else
                            Dim resultado As Integer = MessageBox.Show("El siguiente registro ya se encuentra guardado en la base de datos. Fecha:" & producto.SubItems(CInt(NudFecha.Value)).Text & " Cargo:" & producto.SubItems(CInt(NudCargo.Value)).Text & " Abono:" & producto.SubItems(CInt(NudAbono.Value)).Text & " Saldo:" & producto.SubItems(CInt(NudSaldo.Value)).Text & " ¿Deseas sobreescribirlo?", "Pregunta", MessageBoxButtons.YesNo)
                            If resultado = DialogResult.Yes Then
                                Guardar = "3"
                                idConciliacion = rwEncontrar(0)("iIdConciliacion")
                            Else
                                Guardar = "2"
                            End If

                        End If

                    Else



                    End If

                    If Guardar = "1" Then
                        'Insertamos nuevo

                        SQL = "EXEC setconciliacionInsertar  0," & cbobanco.SelectedValue & "," & cboempresa.SelectedValue
                        SQL &= ",'" & CDate(producto.SubItems(CInt(NudFecha.Value)).Text).ToShortDateString
                        SQL &= "'," & CDate(producto.SubItems(CInt(NudFecha.Value)).Text).Year
                        SQL &= "," & CDate(producto.SubItems(CInt(NudFecha.Value)).Text).Month
                        SQL &= ",'" & producto.SubItems(CInt(NudConcepto.Value)).Text
                        SQL &= "'," & IIf(producto.SubItems(CInt(NudCargo.Value)).Text = "", "0", producto.SubItems(CInt(NudCargo.Value)).Text)
                        SQL &= "," & IIf(producto.SubItems(CInt(NudAbono.Value)).Text = "", "0", producto.SubItems(CInt(NudAbono.Value)).Text)
                        SQL &= "," & IIf(producto.SubItems(CInt(NudSaldo.Value)).Text = "", "0", producto.SubItems(CInt(NudSaldo.Value)).Text)
                        SQL &= ",'','',0,''," & idUsuario
                        SQL &= ",'" & nombresistema
                        SQL &= "','" & DateTime.Now.ToString.Substring(0, 20)

                        SQL &= "',1,1"

                        If nExecute(SQL) = False Then
                            MessageBox.Show("Error en el registro con los siguiente datos: Fecha:" & producto.SubItems(CInt(NudFecha.Value)).Text & " Cargo:" & producto.SubItems(CInt(NudCargo.Value)).Text & " Abono:" & producto.SubItems(CInt(NudAbono.Value)).Text & " Saldo:" & producto.SubItems(CInt(NudSaldo.Value)).Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If

                    ElseIf Guardar = "3" Then
                        'Borramos e Insertamos
                        SQL = "delete from conciliacion where iIdConciliacion=" & idConciliacion
                        If nExecute(SQL) = False Then

                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        'Insertamos nuevo

                        SQL = "EXEC setconciliacionInsertar  0," & cbobanco.SelectedValue & "," & cboempresa.SelectedValue
                        SQL &= ",'" & CDate(producto.SubItems(CInt(NudFecha.Value)).Text).ToShortDateString
                        SQL &= "'," & CDate(producto.SubItems(CInt(NudFecha.Value)).Text).Year
                        SQL &= "," & CDate(producto.SubItems(CInt(NudFecha.Value)).Text).Month
                        SQL &= ",'" & producto.SubItems(CInt(NudConcepto.Value)).Text
                        SQL &= "'," & IIf(producto.SubItems(CInt(NudCargo.Value)).Text = "", "0", producto.SubItems(CInt(NudCargo.Value)).Text)
                        SQL &= "," & IIf(producto.SubItems(CInt(NudAbono.Value)).Text = "", "0", producto.SubItems(CInt(NudAbono.Value)).Text)
                        SQL &= "," & IIf(producto.SubItems(CInt(NudSaldo.Value)).Text = "", "0", producto.SubItems(CInt(NudSaldo.Value)).Text)
                        SQL &= ",'','',0,''," & idUsuario
                        SQL &= ",'" & nombresistema
                        SQL &= "','" & DateTime.Now.ToString.Substring(0, 20)

                        SQL &= "',1,1"

                        If nExecute(SQL) = False Then
                            MessageBox.Show("Error en el registro con los siguiente datos: Fecha:" & producto.SubItems(CInt(NudFecha.Value)).Text & " Cargo:" & producto.SubItems(CInt(NudCargo.Value)).Text & " Abono:" & producto.SubItems(CInt(NudAbono.Value)).Text & " Saldo:" & producto.SubItems(CInt(NudSaldo.Value)).Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    pgbProgreso.Value += 1
                    Application.DoEvents()


                Next
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                MessageBox.Show("Por favor seleccione al menos una registro para importar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancelar.Click
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
End Class