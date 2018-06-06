Imports ClosedXML.Excel
Public Class conciliacion
    Dim SQL As String
    Dim contacolumna As Integer
    Public gIdFactura As String

    Private Sub conciliacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
        MostrarEmpresa()
        MostrarBancos()
    End Sub
    Private Sub MostrarBancos()
        SQL = "Select * from bancos order by cBanco"
        nCargaCBO(cbobanco, SQL, "cBanco", "iIdBanco")
        'cbobanco.SelectedIndex = 0
    End Sub
    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
        Dim dialogo As New OpenFileDialog
        lblRuta.Text = ""
        With dialogo
            .Title = "Búsqueda de catálogos."
            .Filter = "Archivos de excel (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                lblRuta.Text = .FileName
            End If
        End With
        tsbProcesar.Enabled = lblRuta.Text.Length > 0
        If tsbProcesar.Enabled Then
            tsbProcesar_Click(sender, e)
        End If
    End Sub

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
                Dim idsempresas As String()
                Dim clientes As String
                Dim empresas As String
                Dim numcliente As Integer
                Dim numempresas As Integer
                Dim cadena As String
                Dim facturas As String

                contadorlista = 0
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
                                            producto.BackColor = Color.Yellow
                                        End If
                                    Else
                                        'Buscamos a las empresas relacionadas con los cargos


                                        If txtidempresa.Text <> "" Then
                                            SQL = "select * from facturas"
                                            SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa "
                                            SQL &= " where total=" & (producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                            SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                            SQL &= " and fkiIdCliente=" & txtidempresa.Text
                                            Dim rwCargos As DataRow() = nConsulta(SQL)

                                            If rwCargos Is Nothing = False Then
                                                If rwCargos.Count = 1 Then
                                                    'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                                    Dim Fila As DataRow = rwCargos(0)
                                                    producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
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
                                                    producto.BackColor = Color.Yellow

                                                End If
                                            Else
                                                producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                producto.BackColor = Color.Red
                                            End If

                                        Else
                                            producto.SubItems.Add("--")
                                        End If




                                        'Buscamos la cantidad en clientes

                                        'numcliente = 1
                                        'If txtids.Text <> "" Then
                                        '    ids = txtids.Text.Split(",")

                                        '    For x As Integer = 0 To ids.Length - 1
                                        '        If numcliente = 1 Then
                                        '            clientes &= "and (fkiIdCliente=" & ids(x)
                                        '            numcliente = 1 + 1
                                        '        Else
                                        '            clientes &= " or fkiIdCliente=" & ids(x)
                                        '        End If
                                        '    Next
                                        '    clientes &= ")"

                                        'End If

                                        'If clientes <> "" Then
                                        '    SQL = "select * from facturas"
                                        '    SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa "
                                        '    SQL &= " where total=" & (producto.SubItems(CInt(NudCargo.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                        '    SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                        '    SQL &= clientes
                                        '    Dim rwCargos As DataRow() = nConsulta(SQL)

                                        '    If rwCargos Is Nothing = False Then
                                        '        If rwCargos.Count = 1 Then
                                        '            'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                        '            Dim Fila As DataRow = rwCargos(0)
                                        '            producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                        '            producto.BackColor = Color.Green
                                        '        Else
                                        '            'Hay mas de una cantidad
                                        '            For x As Integer = 0 To rwCargos.Count - 1
                                        '                cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
                                        '                If x = rwCargos.Count - 1 Then

                                        '                    facturas &= "F" & rwCargos(x).Item("iIdFactura")
                                        '                Else
                                        '                    facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
                                        '                End If
                                        '            Next
                                        '            producto.Tag = facturas
                                        '            producto.SubItems.Add(cadena)
                                        '            producto.BackColor = Color.Yellow

                                        '        End If
                                        '    Else
                                        '        producto.SubItems.Add("No existe esta factura en la base de facturación")
                                        '        producto.BackColor = Color.Red
                                        '    End If
                                        'Else
                                        '    producto.SubItems.Add("--")
                                        'End If
                                    End If




                                ElseIf (producto.SubItems(CInt(NudCargo.Value)).Text = "" Or producto.SubItems(CInt(NudCargo.Value)).Text = "0") And producto.SubItems(CInt(NudAbono.Value)).Text <> "" Then
                                    'buscamos la cantidad en empresa
                                    SQL = "select * from facturas"
                                    SQL &= " inner join clientes on fkiIdCliente= iIdCliente "
                                    SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And total=" & (producto.SubItems(CInt(NudAbono.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                    SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                                    Dim rwCargos As DataRow() = nConsulta(SQL)

                                    If rwCargos Is Nothing = False Then
                                        If rwCargos.Count = 1 Then
                                            'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                            Dim Fila As DataRow = rwCargos(0)
                                            producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
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
                                            producto.BackColor = Color.Yellow
                                        End If
                                    Else
                                        'producto.BackColor = Color.Red
                                        producto.SubItems.Add("No existe esta factura en la base de facturación")
                                        producto.BackColor = Color.Red
                                    End If

                                Else
                                    producto.SubItems.Add("//")
                                End If
                                'MessageBox.Show("esta dentro del rango", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        Else

                        End If

                    Else
                        MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If



                Next

                'tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
            Else

                MessageBox.Show("Por favor seleccione al menos un registro para hacer la conciliacion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True
        Catch ex As Exception

        End Try


    End Sub

    Private Sub tsbProcesar_Click(sender As Object, e As EventArgs) Handles tsbProcesar.Click
        Dim xlsConexion As New OleDb.OleDbConnection
        Dim oCmd As New OleDb.OleDbCommand
        Dim oDa As New OleDb.OleDbDataAdapter
        Dim oDs As New DataSet, Hoja As String = ""


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
            xlsConexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & lblRuta.Text & "; Extended Properties= Excel 12.0 Xml;"
            xlsConexion.Open()

            Dim Esquema As DataTable = xlsConexion.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, {Nothing, Nothing, Nothing, "TABLE"})

            If Esquema Is Nothing = False Then
                Hoja = Esquema.Rows(0)(2).ToString()
            Else
                MessageBox.Show("No se ha podido leer el archivo específicado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            oCmd.CommandText = "SELECT * FROM [" + Hoja + "] "
            oCmd.Connection = xlsConexion
            oDa.SelectCommand = oCmd

            oDa.Fill(oDs, "Sales")
            xlsConexion.Close()

            Dim tbRegistros As DataTable = oDs.Tables(0).Copy()
            lsvLista.Items.Clear()
            lsvLista.Columns.Clear()
            Dim anchos As String() = "70,100,350,100,100,100,100,190,190,190".Split(",")

            If tbRegistros Is Nothing = False Then
                contacolumna = tbRegistros.Columns.Count + 1

                For i As Integer = 0 To tbRegistros.Columns.Count
                    If i = 0 Then
                        lsvLista.Columns.Add("")
                    Else
                        lsvLista.Columns.Add("columna " & i)
                    End If

                    If i >= 2 Then
                        lsvLista.Columns(i).TextAlign = HorizontalAlignment.Right
                    End If
                    If i < anchos.Length Then
                        lsvLista.Columns(i).Width = Val(anchos(i))
                    End If
                Next
                lsvLista.Columns.Add("conciliacion")
                lsvLista.Columns(contacolumna).Width = 350
                'lsvLista.Items.AddRange((From Fila As DataRow In tbRegistros.Select("PRECIO_CLAVE>0")
                'Where(Not IsDBNull(Fila.Item(7)) AndAlso CType("" & Fila.Item(0), String) <> "VALIDACION")
                '                                          Order By Val("" & Fila.Item("Pagina"))
                '                                         Select New ListViewItem((From campo In Fila.ItemArray Select CType("" & campo, String)).ToArray())).ToArray())

                'lsvLista.Items.AddRange((From Fila As DataRow In tbRegistros.Select("PRECIO_CLAVE>0")
                '                                           Where Not IsDBNull(Fila.Item(7)) AndAlso CType("" & Fila.Item(0), String) <> "VALIDACION"
                '                                           Order By Val("" & Fila.Item("Pagina"))
                '                                           Select New ListViewItem((From campo In Fila.ItemArray Select CType("" & campo, String)).ToArray())).ToArray())


                Dim item As ListViewItem
                For x = 0 To tbRegistros.Rows.Count - 1
                    item = lsvLista.Items.Add("Fila " & x + 1)
                    For y = 0 To tbRegistros.Columns.Count - 1
                        item.SubItems.Add("" & tbRegistros.Rows(x).Item(y).ToString())

                    Next
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(0).ToString())
                    'Dim ere As Integer = tbRegistros.Columns.Count
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(1).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(2).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(3).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(4).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(5).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(6).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(7).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(8).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(9).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(10).ToString())
                    'item.SubItems.Add("" & IIf(tbRegistros.Rows(x).Item(11).ToString() = Nothing, "", tbRegistros.Rows(x).Item(11).ToString()))
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(12).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(13).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(14).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(15).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(16).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(17).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(18).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(19).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(20).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(21).ToString())
                Next

            End If
            pnlCatalogo.Enabled = True
            If lsvLista.Items.Count = 0 Then
                MessageBox.Show("El catálogo no puso ser importado o no contiene registros." & vbCrLf & "¿Por favor verifique?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Se han encontrado " & FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbGuardar.Enabled = True
                tsbCancelar.Enabled = True
                lblRuta.Text = FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo."
            End If
        Catch ex As Exception
            ShowError(ex, Me.Text)
        End Try
        Me.Enabled = True
        Me.cmdCerrar.Enabled = True
        Me.Cursor = Cursors.Default
        tsbImportar.Enabled = True
        lsvLista.Visible = True
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

    Private Sub chkfecha_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged


    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        Try
            If lsvLista.SelectedItems(0).Tag <> "" Then
                Dim Forma As New frmlista
                Forma.gIdFacturas = lsvLista.SelectedItems(0).Tag
                If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                    lsvLista.SelectedItems(0).SubItems(6).Text = Forma.gIdFacturaSelec
                    lsvLista.SelectedItems(0).BackColor = Color.Green
                    'If cboempresa.SelectedIndex > -1 Then
                    '    cargarlista()
                    'End If
                    'lsvLista.SelectedItems(0).Tag = ""
                End If
                MessageBox.Show("datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbExcel.Click
        Try
            Dim filaExcel As Integer = 5
            Dim dialogo As New SaveFileDialog()
            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

            hoja.Column("B").Width = 13
            hoja.Column("C").Width = 50
            hoja.Column("D").Width = 15
            hoja.Column("E").Width = 15
            hoja.Column("F").Width = 15
            hoja.Column("G").Width = 35


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
                hoja.Cell(filaExcel, 7).Value = producto.SubItems(producto.SubItems.Count - 1).Text

            Next

            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Conciliacion"
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            libro.SaveAs(dialogo.FileName)
            'libro.SaveAs("c:\temp\control.xlsx")
            'libro.SaveAs(dialogo.FileName)
            'apExcel.Quit()

            libro = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsbDeleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleted.Click
        Dim SQL As String, nombresistema As String = ""
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value

        Try

            Dim mensaje As String
            Dim idConciliacion As String


            pnlProgreso.Visible = True
            pnlCatalogo.Enabled = False
            Application.DoEvents()

            pgbProgreso.Minimum = 0
            pgbProgreso.Value = 0
            pgbProgreso.Maximum = lsvLista.CheckedItems.Count

            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombresistema = Fila.Item("nombre")
            End If

            SQL = " SELECT * from conciliacion"
            SQL &= " WHERE fkiIdEmpresa=" & cboempresa.SelectedValue
            SQL &= " AND fkiIdBanco=" & cbobanco.SelectedValue
            SQL &= " AND  dfechaMovimiento BETWEEN '" + inicio.ToShortDateString + "' AND '" + fin.ToShortDateString + "'"

            Dim rwDatos As DataRow() = nConsulta(SQL)

            If rwDatos Is Nothing = False Then

                For Each Fila In rwDatos

                    SQL = "EXEC setconciliacionRespaldoInsertar  0," & cbobanco.SelectedValue & "," & cboempresa.SelectedValue
                    SQL &= ",'" & Fila.Item("dFechaMovimiento")
                    SQL &= "'," & Fila.Item("iAnio")
                    SQL &= "," & Fila.Item("iMes")
                    SQL &= ",'" & Fila.Item("cConcepto")
                    SQL &= "'," & Fila.Item("fCargo")
                    SQL &= "," & Fila.Item("fAbono")
                    SQL &= "," & Fila.Item("fSaldo")
                    SQL &= ",'','',0,0,0,0,''," & Fila.Item("fkiIdUsuario")
                    SQL &= ",'" & Fila.Item("cUsuario")
                    SQL &= "','" & Fila.Item("dFechaCaptura")
                    SQL &= "',1,1"
                    SQL &= ",0,''"
                    SQL &= ",0,0,0,0,0,0,0,0,0,0,0"
                    SQL &= ", '" & DateTime.Now.ToString
                    SQL &= "','" & nombresistema & "'"

                Next


                SQL = "EXEC deleteConciliacion "
                SQL &= cboempresa.SelectedValue
                SQL &= ", " & cbobanco.SelectedValue
                SQL &= ", '" & inicio.ToShortDateString & "'"
                SQL &= ", '" & fin.ToShortDateString & "'"



            Else
                MessageBox.Show("No se encontraron datos que eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        Catch ex As Exception

        End Try



    End Sub

   
End Class