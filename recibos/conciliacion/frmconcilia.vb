Imports ClosedXML.Excel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmconcilia
    Dim sheetIndex As Integer = -1
    Dim SQL As String
    Dim contacolumna As Integer
    Public gIdFactura As String
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

    Private Sub frmconcilia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
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

    Private Sub tsbGuardar_Click(sender As Object, e As EventArgs) Handles tsbGuardar.Click
        Dim SQL As String

        Try
            If lsvLista.CheckedItems.Count > 0 Then
                Dim mensaje As String


                pnlProgreso.Visible = True
                pnlCatalogo.Enabled = False
                Application.DoEvents()


                Dim IdProducto As Long
                Dim i As Integer = 0
                Dim conta As Integer = 0


                pgbProgreso.Minimum = 0
                pgbProgreso.Value = 0
                pgbProgreso.Maximum = lsvLista.CheckedItems.Count

                Dim inicio As DateTime = dtpfechainicio.Value
                Dim fin As DateTime = dtpfechafin.Value
                Dim tiempo As TimeSpan = fin - inicio
                Dim fecha As DateTime
                Dim contadorlista As Integer
                Dim ids As String()
                Dim comisiones As String()
                Dim clientes As String
                Dim numcliente As Integer
                Dim cadena As String
                Dim facturas As String
                Dim bValidar As Boolean

                contadorlista = 0
                'If rdbIguales.Checked = True Then
                For Each producto As ListViewItem In lsvLista.CheckedItems
                    cadena = ""
                    facturas = ""
                    contadorlista = contadorlista + 1
                    pgbProgreso.Value += 1
                    Application.DoEvents()
                    'mandar el reporte
                    If (tiempo.Days >= 0) Then
                        If chkfecha.Checked = True Then
                            fecha = CDate(producto.SubItems(CInt(NudFecha.Value)).Text)
                            If fecha.Date >= dtpfechainicio.Value.Date And fecha.Date <= dtpfechafin.Value.Date Then

                                If producto.SubItems(CInt(NudCargo.Value)).Text <> "" And (producto.SubItems(CInt(NudAbono.Value)).Text = "" Or producto.SubItems(CInt(NudAbono.Value)).Text = "0") Then


                                    'Buscamos en gastos

                                    SQL = "select * from gastos"
                                    SQL &= " where total=" & (producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "") & " And gastos.iEstatus=1 "
                                    SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                    SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                                    Dim rwGastos As DataRow() = nConsulta(SQL)
                                    If rwGastos Is Nothing = False Then
                                        If rwGastos.Count = 1 Then
                                            'Se encontro una sola cantidad
                                            Dim Fila As DataRow = rwGastos(0)
                                            producto.SubItems.Add(Fila("Factura") & " " & Fila("proveedor"))
                                            producto.SubItems.Add("1")
                                            producto.BackColor = Color.Green
                                        Else
                                            'Se encontro mas de una cantidad
                                            For x As Integer = 0 To rwGastos.Count - 1
                                                cadena &= rwGastos(x).Item("Factura") & "-" & rwGastos(x).Item("proveedor") & "/"
                                                If x = rwGastos.Count - 1 Then

                                                    facturas &= "G" & rwGastos(x).Item("iIdGasto")
                                                Else
                                                    facturas &= "G" & rwGastos(x).Item("iIdGasto") & ","
                                                End If
                                            Next
                                            producto.Tag = facturas
                                            producto.SubItems.Add(cadena)
                                            producto.SubItems.Add("2")
                                            producto.BackColor = Color.Yellow
                                        End If
                                    Else

                                        'Buscamos a las empresas relacionadas con los cargos
                                        If InStr(Trim(producto.SubItems(CInt(NudConcepto.Value)).Text).ToUpper, "SUELDO") > 0 Then
                                            producto.SubItems.Add("NOMINA")
                                            producto.SubItems.Add("1")
                                            producto.BackColor = Color.Green

                                        ElseIf InStr(Trim(producto.SubItems(CInt(NudConcepto.Value)).Text).Replace(",", ""), "DISPERSION") > 0 Then

                                            producto.SubItems.Add("NOMINA")
                                            producto.SubItems.Add("1")
                                            producto.BackColor = Color.Green

                                        ElseIf txtidempresa.Text <> "" Then

                                            SQL = "Select * from facturas"
                                            SQL &= " inner join empresa On fkiIdEmpresa= iIdEmpresa "
                                            SQL &= " where total=" & (producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                            SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                            SQL &= " and fkiIdCliente=" & txtidempresa.Text
                                            Dim rwCargos As DataRow() = nConsulta(SQL)

                                            If rwCargos Is Nothing = False Then
                                                If rwCargos.Count = 1 Then
                                                    'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                                    Dim Fila As DataRow = rwCargos(0)
                                                    producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                                    producto.SubItems.Add("1")
                                                    producto.BackColor = Color.Green
                                                Else
                                                    'Hay mas de una cantidad
                                                    For x As Integer = 0 To rwCargos.Count - 1
                                                        cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
                                                        If x = rwCargos.Count - 1 Then

                                                            facturas &= "F" & rwCargos(x).Item("iIdFactura")
                                                        Else
                                                            facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
                                                        End If
                                                    Next
                                                    producto.Tag = facturas
                                                    producto.SubItems.Add(cadena)
                                                    producto.SubItems.Add("2")
                                                    producto.BackColor = Color.Yellow

                                                End If
                                            ElseIf txtcomision.Text <> "" Then
                                                comisiones = txtcomision.Text.Split(",")
                                                bValidar = True
                                                For x As Integer = 0 To comisiones.Length - 1

                                                    If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "")) Then
                                                        producto.SubItems.Add("Comisión")
                                                        producto.SubItems.Add("1")
                                                        producto.BackColor = Color.Green
                                                        x = comisiones.Length
                                                        bValidar = False
                                                    End If


                                                Next
                                                If bValidar Then
                                                    producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                    producto.SubItems.Add("3")
                                                    producto.BackColor = Color.Red

                                                End If

                                            Else
                                                producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                producto.SubItems.Add("3")
                                                producto.BackColor = Color.Red
                                            End If

                                        ElseIf txtcomision.Text <> "" Then
                                            comisiones = txtcomision.Text.Split(",")
                                            bValidar = True
                                            For x As Integer = 0 To comisiones.Length - 1

                                                If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "")) Then
                                                    producto.SubItems.Add("Comisión")
                                                    producto.SubItems.Add("1")
                                                    producto.BackColor = Color.Green
                                                    x = comisiones.Length
                                                    bValidar = False
                                                End If


                                            Next
                                            If bValidar Then
                                                producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                producto.SubItems.Add("3")
                                                producto.BackColor = Color.Red

                                            End If

                                        Else
                                            producto.SubItems.Add("--")
                                            producto.SubItems.Add("3")
                                        End If
                                    End If



                                    ''Buscamos la cantidad en clientes

                                    'clientes = ""
                                    '    numcliente = 1
                                    '    If txtids.Text <> "" Then
                                    '        ids = txtids.Text.Split(",")

                                    '        For x As Integer = 0 To ids.Length - 1
                                    '            If numcliente = 1 Then
                                    '                clientes &= "and (fkiIdCliente=" & ids(x)
                                    '                numcliente = 1 + 1
                                    '            Else
                                    '                clientes &= " or fkiIdCliente=" & ids(x)
                                    '            End If
                                    '        Next
                                    '        clientes &= ")"

                                    '    End If

                                    '    If clientes <> "" Then
                                    '        SQL = "select * from facturas"
                                    '        SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa "
                                    '        SQL &= " where total=" & (producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                    '        SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                    '        SQL &= clientes
                                    '        Dim rwCargos As DataRow() = nConsulta(SQL)

                                    '        If rwCargos Is Nothing = False Then
                                    '            If rwCargos.Count = 1 Then
                                    '                'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                    '                Dim Fila As DataRow = rwCargos(0)
                                    '                producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                    '                producto.BackColor = Color.Green
                                    '            Else
                                    '                'Hay mas de una cantidad
                                    '                For x As Integer = 0 To rwCargos.Count - 1
                                    '                    cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
                                    '                    If x = rwCargos.Count - 1 Then

                                    '                        facturas &= "F" & rwCargos(x).Item("iIdFactura")
                                    '                    Else
                                    '                        facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
                                    '                    End If
                                    '                Next
                                    '                producto.Tag = facturas
                                    '                producto.SubItems.Add(cadena)
                                    '                producto.BackColor = Color.Yellow

                                    '            End If
                                    '        ElseIf txtcomision.text <> "" Then
                                    '            comisiones = txtcomision.Text.Split(",")
                                    '            bValidar = True
                                    '            For x As Integer = 0 To comisiones.Length - 1

                                    '                If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "")) Then
                                    '                    producto.SubItems.Add("Comisión")
                                    '                    producto.BackColor = Color.Green
                                    '                    x = comisiones.Length
                                    '                    bValidar = False
                                    '                End If


                                    '            Next
                                    '            If bValidar Then
                                    '                producto.SubItems.Add("No existe esta factura en la base de facturación")
                                    '                producto.BackColor = Color.Red

                                    '            End If

                                    '        Else
                                    '            producto.SubItems.Add("No existe esta factura en la base de facturación")
                                    '            producto.BackColor = Color.Red
                                    '        End If
                                    '    ElseIf txtcomision.text <> "" Then
                                    '        comisiones = txtcomision.Text.Split(",")
                                    '        bValidar = True
                                    '        For x As Integer = 0 To comisiones.Length - 1

                                    '            If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "")) Then
                                    '                producto.SubItems.Add("Comisión")
                                    '                producto.BackColor = Color.Green
                                    '                x = comisiones.Length
                                    '                bValidar = False
                                    '            End If


                                    '        Next
                                    '        If bValidar Then
                                    '            producto.SubItems.Add("No existe esta factura en la base de facturación")
                                    '            producto.BackColor = Color.Red

                                    '        End If

                                    '    Else
                                    '        producto.SubItems.Add("--")
                                    '    End If
                                    'End If





                                ElseIf (producto.SubItems(CInt(NudCargo.Value)).Text = "" Or producto.SubItems(CInt(NudCargo.Value)).Text = "0") And producto.SubItems(CInt(NudAbono.Value)).Text <> "" Then
                                    'buscamos la cantidad en empresa




                                    'SQL = "select * from (pagos"
                                    'SQL &= " inner join facturas on pagos.fkiidFactura=facturas.iIdfactura)"
                                    'SQL &= " inner join clientes on fkiIdCliente= iIdCliente "
                                    'SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And pagos.importe=" & (producto.SubItems(CInt(NudAbono.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                    'SQL &= " And fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"

                                    SQL = "select * from facturas"
                                    SQL &= " inner join clientes on fkiIdCliente= iIdCliente  "
                                    SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And facturas.total=" & (producto.SubItems(CInt(NudAbono.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                    SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                                    Dim rwCargos As DataRow() = nConsulta(SQL)

                                    If rwCargos Is Nothing = False Then
                                        If rwCargos.Count = 1 Then
                                            'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                            Dim Fila As DataRow = rwCargos(0)
                                            producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                            producto.SubItems.Add("1")
                                            producto.BackColor = Color.Green
                                        Else
                                            'Hay mas de una cantidad

                                            For x As Integer = 0 To rwCargos.Count - 1
                                                cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
                                                If x = rwCargos.Count - 1 Then

                                                    facturas &= "F" & rwCargos(x).Item("iIdFactura")
                                                Else
                                                    facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
                                                End If
                                            Next
                                            producto.Tag = facturas
                                            producto.SubItems.Add(cadena)
                                            producto.SubItems.Add("2")
                                            producto.BackColor = Color.Yellow
                                        End If
                                    Else
                                        'producto.BackColor = Color.Red
                                        producto.SubItems.Add("No existe esta factura en la base de facturación")
                                        producto.SubItems.Add("3")
                                        producto.BackColor = Color.Red
                                    End If

                                Else
                                    producto.SubItems.Add("//")
                                    producto.SubItems.Add("3")
                                End If



                                'MessageBox.Show("esta dentro del rango", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        Else

                        End If

                    Else
                        MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If



                Next
                'ElseIf rdbrango.Checked = True Then
                '    Dim range As String = Nudrango.Value
                '    MessageBox.Show("Rango", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If


                'tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
            Else

                MessageBox.Show("Por favor seleccione al menos un registro para hacer la conciliacion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub tsbExcel_Click(sender As Object, e As EventArgs) Handles tsbExcel.Click
        Try

            Dim dialogo As New SaveFileDialog
            lblRuta.Text = ""


            'With dialogo
            '    .Title = "Búsqueda de archivos de saldos."
            '    .Filter = "Hoja de cálculo de excel (xlsx)|*.xlsx;"
            '    .CheckFileExists = True
            '    If .ShowDialog = Windows.Forms.DialogResult.OK Then
            '        lblRuta.Text = .FileName
            '    End If
            'End With


            'Dim Archivo As String = lblRuta.Text
            'Dim Hoja As String


            'Dim book As New ClosedXML.Excel.XLWorkbook

            Dim filaExcel As Integer = 5

            'Dim dialogo As New SaveFileDialog()

            Dim libro As New ClosedXML.Excel.XLWorkbook


            Dim hoja As IXLWorksheet = libro.Worksheets.Add("conciliacion")


            hoja.Column("B").Width = 13

            hoja.Column("C").Width = 50
            hoja.Column("D").Width = 15

            hoja.Column("E").Width = 15
            hoja.Column("F").Width = 15

            hoja.Column("G").Width = 35


            hoja.Cell(2, 2).Value = "Fecha:"

            hoja.Cell(2, 3).Value = Date.Now.ToShortDateString() & " " & Date.Now.ToShortTimeString()

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
            hoja.Cell(4, 2).Value = "Fecha"

            hoja.Cell(4, 3).Value = "Concepto/Referencia"
            hoja.Cell(4, 4).Value = "Cargo"

            hoja.Cell(4, 5).Value = "Abono"

            hoja.Cell(4, 6).Value = "Saldo"
            hoja.Cell(4, 7).Value = "Conciliado con"


            filaExcel = 4

            For Each producto As ListViewItem In lsvLista.CheckedItems
                filaExcel = filaExcel + 1


                hoja.Cell(filaExcel, 2).Value = producto.SubItems(CInt(NudFecha.Value)).Text

                hoja.Cell(filaExcel, 3).Value = producto.SubItems(CInt(NudConcepto.Value)).Text

                hoja.Cell(filaExcel, 4).Value = Format(CType(IIf(producto.SubItems(CInt(NudCargo.Value)).Text = "", "0", producto.SubItems(CInt(NudCargo.Value)).Text), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 4).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 5).Value = Format(CType(IIf(producto.SubItems(CInt(NudAbono.Value)).Text = "", "0", producto.SubItems(CInt(NudAbono.Value)).Text), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 5).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 6).Value = Format(CType(IIf(producto.SubItems(CInt(NudSaldo.Value)).Text = "", "0", producto.SubItems(CInt(NudSaldo.Value)).Text), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 6).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 7).Value = producto.SubItems(producto.SubItems.Count - 2).Text


                If producto.SubItems(producto.SubItems.Count - 1).Text = "1" Then
                    hoja.Cell(filaExcel, 7).Style.Fill.BackgroundColor = XLColor.FromHtml("#00FF40")



                ElseIf producto.SubItems(producto.SubItems.Count - 1).Text = "2" Then
                    hoja.Cell(filaExcel, 7).Style.Fill.BackgroundColor = XLColor.Yellow

                ElseIf producto.SubItems(producto.SubItems.Count - 1).Text = "3" Then
                    hoja.Cell(filaExcel, 7).Style.Fill.BackgroundColor = XLColor.Red


                End If


            Next


            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = cboempresa.Text & " " & cbobanco.Text & " " & MonthName(DateTime.Parse(dtpfechainicio.Value).Month).ToString.ToUpper & " DE " & DateTime.Parse(dtpfechainicio.Value).Year

            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            'libro.Save()
            'libro.SaveAs("c:\temp\control.xlsx")

            libro.SaveAs(dialogo.FileName)
            'apExcel.Quit()

            libro = Nothing
            hoja = Nothing

            MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)



        Catch ex As Exception

        End Try
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        Try
            If lsvLista.SelectedItems(0).Tag <> "" Then
                Dim Forma As New frmlista
                Forma.gIdFacturas = lsvLista.SelectedItems(0).Tag
                If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                    lsvLista.SelectedItems(0).SubItems(lsvLista.SelectedItems(0).SubItems.Count - 2).Text = Forma.gIdFacturaSelec
                    lsvLista.SelectedItems(0).BackColor = Color.Green
                    lsvLista.SelectedItems(0).Checked = True
                    lsvLista.SelectedItems(0).SubItems(lsvLista.SelectedItems(0).SubItems.Count - 1).Text = "1"


                    'If cboempresa.SelectedIndex > -1 Then
                    '    cargarlista()
                    'End If
                    'lsvLista.SelectedItems(0).Tag = ""
                End If
                MessageBox.Show("Factura asignada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception

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