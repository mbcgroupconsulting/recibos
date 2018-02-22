Imports ClosedXML.Excel
Public Class frmConciliacionAreas
    Dim SQL As String
    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
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
                lsvLista.Columns.Add("Usuario Alta")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns.Add("Usuario Conciliación")
                lsvLista.Columns(10).Width = 120




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
                    'tsbGuardar.Enabled = True
                    tsbNuevo.Enabled = False
                    tsbConciliar.Enabled = True

                    tsbCancelar.Enabled = True
                    lblRuta.Text = FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo."
                    Me.Enabled = True
                    Me.cmdCerrar.Enabled = True
                    Me.Cursor = Cursors.Default
                    
                Else
                    MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmConciliacionAreas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

    Private Sub tsbCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancelar.Click

        lsvLista.Items.Clear()
        chkAll.Checked = False
        lblRuta.Text = ""
        tsbImportar.Enabled = False
        tsbProcesar.Enabled = False
        tsbConciliar.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        tsbNuevo.Enabled = True
    End Sub

    Private Sub tsbConciliar_Click(sender As System.Object, e As System.EventArgs) Handles tsbConciliar.Click
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
                For Each producto As ListViewItem In lsvLista.CheckedItems
                    cadena = ""
                    facturas = ""
                    contadorlista = contadorlista + 1
                    pgbProgreso.Value += 1
                    Application.DoEvents()
                    'mandar el reporte
                    If (tiempo.Days >= 0) Then
                        If chkfecha.Checked = True Then
                            fecha = CDate(producto.SubItems(3).Text)
                            If fecha.Date >= dtpfechainicio.Value.Date And fecha.Date <= dtpfechafin.Value.Date Then
                                If producto.SubItems(5).Text <> "0.00" And (producto.SubItems(6).Text = "" Or producto.SubItems(6).Text = "0.00") Then
                                    'Buscamos en gastos

                                    SQL = "select * from gastos"
                                    SQL &= " where total=" & (producto.SubItems(5).Text).Replace(",", "").Replace("$", "") & " And gastos.iEstatus=1 "
                                    SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                    SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                                    Dim rwGastos As DataRow() = nConsulta(SQL)
                                    If rwGastos Is Nothing = False Then
                                        If rwGastos.Count = 1 Then
                                            'Se encontro una sola cantidad
                                            Dim Fila As DataRow = rwGastos(0)
                                            producto.SubItems(8).Text = Fila("Factura") & " " & Fila("proveedor")
                                            'producto.SubItems.Add(Fila("Factura") & " " & Fila("proveedor"))
                                            'producto.SubItems.Add("1")
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
                                            producto.SubItems(8).Text = cadena
                                            'producto.SubItems.Add(cadena)
                                            'producto.SubItems.Add("2")
                                            producto.BackColor = Color.Yellow
                                        End If
                                    Else

                                        'Buscamos a las empresas relacionadas con los cargos
                                        If InStr(Trim(producto.SubItems(4).Text).ToUpper, "SUELDO") > 0 Then
                                            producto.SubItems(8).Text = "NOMINA"
                                            'producto.SubItems.Add("NOMINA")
                                            'producto.SubItems.Add("1")
                                            producto.BackColor = Color.Green

                                        ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "DISPERSION") > 0 Then
                                            producto.SubItems(8).Text = "NOMINA"
                                            'producto.SubItems.Add("NOMINA")
                                            'producto.SubItems.Add("1")
                                            producto.BackColor = Color.Green

                                        ElseIf txtidempresa.Text <> "" Then

                                            SQL = "Select * from facturas"
                                            SQL &= " inner join empresa On fkiIdEmpresa= iIdEmpresa "
                                            SQL &= " where total=" & (producto.SubItems(5).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                            SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                            SQL &= " and fkiIdCliente=" & txtidempresa.Text
                                            Dim rwCargos As DataRow() = nConsulta(SQL)

                                            If rwCargos Is Nothing = False Then
                                                If rwCargos.Count = 1 Then
                                                    'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                                    Dim Fila As DataRow = rwCargos(0)

                                                    producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
                                                    'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                                    'producto.SubItems.Add("1")
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
                                                    producto.SubItems(8).Text = cadena
                                                    'producto.SubItems.Add(cadena)
                                                    'producto.SubItems.Add("2")
                                                    producto.BackColor = Color.Yellow

                                                End If
                                            ElseIf txtcomision.Text <> "" Then
                                                comisiones = txtcomision.Text.Split(",")
                                                bValidar = True
                                                For x As Integer = 0 To comisiones.Length - 1

                                                    If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(5).Text).Replace(",", "").Replace("$", "")) Then
                                                        producto.SubItems(8).Text = "Comisión"
                                                        'producto.SubItems.Add("Comisión")
                                                        'producto.SubItems.Add("1")
                                                        producto.BackColor = Color.Green
                                                        x = comisiones.Length
                                                        bValidar = False
                                                    End If


                                                Next
                                                If bValidar Then
                                                    producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                    'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                    'producto.SubItems.Add("3")
                                                    producto.BackColor = Color.Red

                                                End If

                                            Else
                                                producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                'producto.SubItems.Add("3")
                                                producto.BackColor = Color.Red
                                            End If

                                        ElseIf txtcomision.Text <> "" Then
                                            comisiones = txtcomision.Text.Split(",")
                                            bValidar = True
                                            For x As Integer = 0 To comisiones.Length - 1

                                                If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(5).Text).Replace(",", "").Replace("$", "")) Then
                                                    producto.SubItems(8).Text = "Comisión"
                                                    'producto.SubItems.Add("Comisión")
                                                    'producto.SubItems.Add("1")
                                                    producto.BackColor = Color.Green
                                                    x = comisiones.Length
                                                    bValidar = False
                                                End If


                                            Next
                                            If bValidar Then
                                                producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                'producto.SubItems.Add("3")
                                                producto.BackColor = Color.Red

                                            End If

                                        Else
                                            producto.SubItems(8).Text = "--"
                                            'producto.SubItems.Add("--")
                                            'producto.SubItems.Add("3")
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





                                ElseIf (producto.SubItems(5).Text = "" Or producto.SubItems(5).Text = "0.00") And producto.SubItems(6).Text <> "0.00" Then
                                    'buscamos la cantidad en empresa




                                    'SQL = "select * from (pagos"
                                    'SQL &= " inner join facturas on pagos.fkiidFactura=facturas.iIdfactura)"
                                    'SQL &= " inner join clientes on fkiIdCliente= iIdCliente "
                                    'SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And pagos.importe=" & (producto.SubItems(CInt(NudAbono.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                    'SQL &= " And fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"

                                    SQL = "select * from facturas"
                                    SQL &= " inner join clientes on fkiIdCliente= iIdCliente  "
                                    SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And facturas.total=" & (producto.SubItems(6).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                    SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                                    Dim rwCargos As DataRow() = nConsulta(SQL)

                                    If rwCargos Is Nothing = False Then
                                        If rwCargos.Count = 1 Then
                                            'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                            Dim Fila As DataRow = rwCargos(0)
                                            producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
                                            'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                            'producto.SubItems.Add("1")
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
                                            producto.SubItems(8).Text = cadena
                                            'producto.SubItems.Add(cadena)
                                            'producto.SubItems.Add("2")
                                            producto.BackColor = Color.Yellow
                                        End If
                                    Else
                                        'producto.BackColor = Color.Red
                                        producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                        'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                        'producto.SubItems.Add("3")
                                        producto.BackColor = Color.Red
                                    End If

                                Else
                                    producto.SubItems(8).Text = "//"
                                    'producto.SubItems.Add("//")
                                    'producto.SubItems.Add("3")
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
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class