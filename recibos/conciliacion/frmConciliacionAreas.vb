Imports ClosedXML.Excel
Public Class frmFondeoPatrona
    Dim SQL As String
    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Try
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            lsvLista.Items.Clear()
            lsvLista.Clear()
            If (tiempo.Days >= 0) Then

                SQL = "select iIdConciliacion,cBanco,nombre,dFechaMovimiento,cConcepto,fCargo,fAbono,fSaldo,"
                SQL &= "cDatosfactura,cUsuario,iEstatus2,cUsuario2 from (conciliacion "
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
                lsvLista.Columns.Add("Numero")
                lsvLista.Columns(11).Width = 50
                lsvLista.Columns(11).TextAlign = 1




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
                        item.SubItems.Add("" & Fila.Item("cUsuario2"))
                        item.SubItems.Add(IIf(Fila.Item("iEstatus2") = "2", "5", ""))
                        item.Tag = Fila.Item("iIdConciliacion")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                        item.BackColor = IIf(Fila.Item("iEstatus2") = "2", Color.Aquamarine, Color.White)
                        'Alter = Not Alter


                    Next

                    MessageBox.Show(rwFacturasConcepto.Count & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'tsbGuardar.Enabled = True
                    tsbNuevo.Enabled = False
                    tsbConciliar.Enabled = True

                    tsbCancelar.Enabled = True
                    tsbDeleted.Enabled = True

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

    Private Sub frmConciliacionAreas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click

        lsvLista.Items.Clear()
        chkAll.Checked = False
        lblRuta.Text = ""
        tsbImportar.Enabled = False
        tsbProcesar.Enabled = False
        tsbConciliar.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False

        tsbDeleted.Enabled = False
        tsbNuevo.Enabled = True
    End Sub

    Private Sub tsbConciliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConciliar.Click
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
                Dim ValorRangoMenos As Double
                Dim ValorRangoMas As Double

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
                            If producto.SubItems(11).Text <> "5" Then
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
                                                producto.SubItems(8).Tag = Fila("iIdGasto")
                                                'producto.SubItems.Add(Fila("Factura") & " " & Fila("proveedor"))
                                                producto.SubItems(11).Text = "1"
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
                                                producto.SubItems(11).Tag = facturas
                                                'producto.Tag = facturas
                                                producto.SubItems(8).Text = cadena
                                                'producto.SubItems.Add(cadena)
                                                'producto.SubItems.Add("2")
                                                producto.SubItems(11).Text = "2"
                                                producto.BackColor = Color.Yellow
                                            End If
                                        Else

                                            'Buscamos a las empresas relacionadas con los cargos
                                            If InStr(Trim(producto.SubItems(4).Text).ToUpper, "SUELDO") > 0 Then
                                                producto.SubItems(8).Text = "NOMINA"
                                                'producto.SubItems.Add("NOMINA")
                                                producto.SubItems(11).Text = "1"
                                                'producto.SubItems.Add("1")
                                                producto.BackColor = Color.Green

                                            ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "DISPERSION") > 0 Then
                                                producto.SubItems(8).Text = "NOMINA"
                                                'producto.SubItems.Add("NOMINA")
                                                producto.SubItems(11).Text = "1"
                                                'producto.SubItems.Add("1")
                                                producto.BackColor = Color.Green

                                            ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "AGUINALDO") > 0 Then
                                                producto.SubItems(8).Text = "NOMINA"
                                                'producto.SubItems.Add("NOMINA")
                                                producto.SubItems(11).Text = "1"
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
                                                        producto.SubItems(8).Tag = Fila("iIdFactura")
                                                        'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                                        producto.SubItems(11).Text = "1"
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
                                                        producto.SubItems(11).Tag = facturas
                                                        'producto.Tag = facturas
                                                        producto.SubItems(8).Text = cadena
                                                        'producto.SubItems.Add(cadena)
                                                        producto.SubItems(11).Text = "2"
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
                                                            producto.SubItems(11).Text = "1"
                                                            'producto.SubItems.Add("1")
                                                            producto.BackColor = Color.Green
                                                            x = comisiones.Length
                                                            bValidar = False
                                                        End If


                                                    Next
                                                    If bValidar Then
                                                        producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                        'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                        producto.SubItems(11).Text = "3"
                                                        'producto.SubItems.Add("3")
                                                        producto.BackColor = Color.Red

                                                    End If

                                                Else
                                                    producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                    'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                    producto.SubItems(11).Text = "3"
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
                                                        producto.SubItems(11).Text = "1"
                                                        'producto.SubItems.Add("1")
                                                        producto.BackColor = Color.Green
                                                        x = comisiones.Length
                                                        bValidar = False
                                                    End If


                                                Next
                                                If bValidar Then
                                                    producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                    'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                    producto.SubItems(11).Text = "3"
                                                    'producto.SubItems.Add("3")
                                                    producto.BackColor = Color.Red

                                                End If

                                            Else
                                                producto.SubItems(8).Text = "--"
                                                'producto.SubItems.Add("--")
                                                producto.SubItems(11).Text = "3"
                                                'producto.SubItems.Add("3")
                                            End If
                                        End If







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
                                                producto.SubItems(8).Tag = Fila("iIdFactura")
                                                'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                                producto.SubItems(11).Text = "1"
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
                                                'producto.Tag = facturas
                                                producto.SubItems(11).Tag = facturas
                                                producto.SubItems(8).Text = cadena
                                                'producto.SubItems.Add(cadena)
                                                producto.SubItems(11).Text = "2"
                                                'producto.SubItems.Add("2")
                                                producto.BackColor = Color.Yellow
                                            End If
                                        Else
                                            'Aqui va lo del prestamo

                                            If InStr(Trim(producto.SubItems(4).Text).ToUpper, "PRESTAMO") > 0 Then
                                                producto.SubItems(8).Text = "PRESTAMO"
                                                'producto.SubItems.Add("NOMINA")
                                                producto.SubItems(11).Text = "1"
                                                'producto.SubItems.Add("1")
                                                producto.BackColor = Color.Green

                                            ElseIf InStr(Trim(producto.SubItems(4).Text).ToUpper, "PRÉSTAMO") > 0 Then
                                                producto.SubItems(8).Text = "NOMINA"
                                                'producto.SubItems.Add("NOMINA")
                                                producto.SubItems(11).Text = "1"
                                                'producto.SubItems.Add("1")
                                                producto.BackColor = Color.Green
                                            Else
                                                'producto.BackColor = Color.Red
                                                producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                producto.SubItems(11).Text = "3"
                                                'producto.SubItems.Add("3")
                                                producto.BackColor = Color.Red
                                            End If





                                        End If

                                    Else
                                        producto.SubItems(8).Text = "//"
                                        'producto.SubItems.Add("//")
                                        producto.SubItems(11).Text = "3"
                                        'producto.SubItems.Add("3")
                                    End If
                                    'MessageBox.Show("esta dentro del rango", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                End If
                            End If
                            'termina la validacion de que si ya la factura fue conciliada

                        Else

                        End If
                        'termina validacion de check de fecha

                    Else
                        MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If



                Next
                pgbProgreso.Value = 0
                If rdbrango.Checked = True Then
                    For Each producto As ListViewItem In lsvLista.CheckedItems
                        cadena = ""
                        facturas = ""
                        contadorlista = contadorlista + 1
                        pgbProgreso.Value += 1
                        Application.DoEvents()
                        'mandar el reporte
                        If (tiempo.Days >= 0) Then
                            If chkfecha.Checked = True Then
                                'vemos solo las facturas que no esten en facturacion

                                If producto.SubItems(11).Text = "3" Then
                                    fecha = CDate(producto.SubItems(3).Text)
                                    If fecha.Date >= dtpfechainicio.Value.Date And fecha.Date <= dtpfechafin.Value.Date Then
                                        If producto.SubItems(5).Text <> "0.00" And (producto.SubItems(6).Text = "" Or producto.SubItems(6).Text = "0.00") Then
                                            'Buscamos en gastos
                                            ValorRangoMenos = producto.SubItems(5).Text - Double.Parse(Nudrango.Value)
                                            ValorRangoMas = producto.SubItems(5).Text + Double.Parse(Nudrango.Value)
                                            SQL = "select * from gastos"
                                            SQL &= " where total between " & ValorRangoMenos & " And " & ValorRangoMas & " And gastos.iEstatus=1 "
                                            SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                            SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                                            Dim rwGastos As DataRow() = nConsulta(SQL)
                                            If rwGastos Is Nothing = False Then
                                                If rwGastos.Count = 1 Then
                                                    'Se encontro una sola cantidad
                                                    Dim Fila As DataRow = rwGastos(0)
                                                    producto.SubItems(8).Text = Fila("Factura") & " " & Fila("proveedor")
                                                    'producto.SubItems.Add(Fila("Factura") & " " & Fila("proveedor"))
                                                    producto.SubItems(8).Tag = Fila("iIdGasto")
                                                    producto.SubItems(11).Text = "1"
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
                                                    'producto.Tag = facturas
                                                    producto.SubItems(11).Tag = facturas
                                                    producto.SubItems(8).Text = cadena
                                                    'producto.SubItems.Add(cadena)
                                                    'producto.SubItems.Add("2")
                                                    producto.SubItems(11).Text = "2"
                                                    producto.BackColor = Color.Yellow
                                                End If
                                            Else

                                                'Buscamos a las empresas relacionadas con los cargos
                                                If InStr(Trim(producto.SubItems(4).Text).ToUpper, "SUELDO") > 0 Then
                                                    producto.SubItems(8).Text = "NOMINA"
                                                    'producto.SubItems.Add("NOMINA")
                                                    producto.SubItems(11).Text = "1"
                                                    'producto.SubItems.Add("1")
                                                    producto.BackColor = Color.Green

                                                ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "DISPERSION") > 0 Then
                                                    producto.SubItems(8).Text = "NOMINA"
                                                    'producto.SubItems.Add("NOMINA")
                                                    producto.SubItems(11).Text = "1"
                                                    'producto.SubItems.Add("1")
                                                    producto.BackColor = Color.Green

                                                ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "AGUINALDO") > 0 Then
                                                    producto.SubItems(8).Text = "NOMINA"
                                                    'producto.SubItems.Add("NOMINA")
                                                    producto.SubItems(11).Text = "1"
                                                    'producto.SubItems.Add("1")
                                                    producto.BackColor = Color.Green


                                                ElseIf txtidempresa.Text <> "" Then

                                                    SQL = "Select * from facturas"
                                                    SQL &= " inner join empresa On fkiIdEmpresa= iIdEmpresa "
                                                    SQL &= " where total between " & ValorRangoMenos & " And " & ValorRangoMas
                                                    SQL &= " And cancelada=1 And facturas.iEstatus=1 "
                                                    SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                                                    SQL &= " and fkiIdCliente=" & txtidempresa.Text
                                                    Dim rwCargos As DataRow() = nConsulta(SQL)

                                                    If rwCargos Is Nothing = False Then
                                                        If rwCargos.Count = 1 Then
                                                            'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                                            Dim Fila As DataRow = rwCargos(0)

                                                            producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
                                                            'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                                            producto.SubItems(8).Tag = Fila("iIdFactura")
                                                            producto.SubItems(11).Text = "1"
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
                                                            'producto.Tag = facturas
                                                            producto.SubItems(11).Tag = facturas
                                                            producto.SubItems(8).Text = cadena
                                                            'producto.SubItems.Add(cadena)
                                                            producto.SubItems(11).Text = "2"
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
                                                                producto.SubItems(11).Text = "1"
                                                                'producto.SubItems.Add("1")
                                                                producto.BackColor = Color.Green
                                                                x = comisiones.Length
                                                                bValidar = False
                                                            End If


                                                        Next
                                                        If bValidar Then
                                                            producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                            'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                            producto.SubItems(11).Text = "3"
                                                            'producto.SubItems.Add("3")
                                                            producto.BackColor = Color.Red

                                                        End If

                                                    Else
                                                        producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                        'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                        producto.SubItems(11).Text = "3"
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
                                                            producto.SubItems(11).Text = "1"
                                                            'producto.SubItems.Add("1")
                                                            producto.BackColor = Color.Green
                                                            x = comisiones.Length
                                                            bValidar = False
                                                        End If


                                                    Next
                                                    If bValidar Then
                                                        producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                        'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                        producto.SubItems(11).Text = "3"
                                                        'producto.SubItems.Add("3")
                                                        producto.BackColor = Color.Red

                                                    End If

                                                Else
                                                    producto.SubItems(8).Text = "--"
                                                    'producto.SubItems.Add("--")
                                                    producto.SubItems(11).Text = "3"
                                                    'producto.SubItems.Add("3")
                                                End If
                                            End If



                                        ElseIf (producto.SubItems(5).Text = "" Or producto.SubItems(5).Text = "0.00") And producto.SubItems(6).Text <> "0.00" Then
                                            'buscamos la cantidad en empresa




                                            'SQL = "select * from (pagos"
                                            'SQL &= " inner join facturas on pagos.fkiidFactura=facturas.iIdfactura)"
                                            'SQL &= " inner join clientes on fkiIdCliente= iIdCliente "
                                            'SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And pagos.importe=" & (producto.SubItems(CInt(NudAbono.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
                                            'SQL &= " And fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"

                                            ValorRangoMenos = producto.SubItems(6).Text - Double.Parse(Nudrango.Value)
                                            ValorRangoMas = producto.SubItems(6).Text + Double.Parse(Nudrango.Value)

                                            SQL = "select * from facturas"
                                            SQL &= " inner join clientes on fkiIdCliente= iIdCliente  "
                                            SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And"
                                            SQL &= " facturas.total between " & ValorRangoMenos & " And " & ValorRangoMas
                                            SQL &= " And cancelada=1 And facturas.iEstatus=1 "
                                            SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                                            Dim rwCargos As DataRow() = nConsulta(SQL)

                                            If rwCargos Is Nothing = False Then
                                                If rwCargos.Count = 1 Then
                                                    'solo hay una cantidad y agregamos el numero de factura y serie al listview
                                                    Dim Fila As DataRow = rwCargos(0)
                                                    producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
                                                    producto.SubItems(8).Tag = Fila("iIdFactura")
                                                    'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
                                                    producto.SubItems(11).Text = "1"
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
                                                    'producto.Tag = facturas
                                                    producto.SubItems(11).Tag = facturas
                                                    producto.SubItems(8).Text = cadena
                                                    'producto.SubItems.Add(cadena)
                                                    producto.SubItems(11).Text = "2"
                                                    'producto.SubItems.Add("2")
                                                    producto.BackColor = Color.Yellow
                                                End If
                                            Else
                                                'producto.BackColor = Color.Red
                                                producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
                                                'producto.SubItems.Add("No existe esta factura en la base de facturación")
                                                producto.SubItems(11).Text = "3"
                                                'producto.SubItems.Add("3")
                                                producto.BackColor = Color.Red
                                            End If

                                        Else
                                            producto.SubItems(8).Text = "//"
                                            'producto.SubItems.Add("//")
                                            producto.SubItems(11).Text = "3"
                                            'producto.SubItems.Add("3")
                                        End If
                                        'MessageBox.Show("esta dentro del rango", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    End If
                                End If
                                'Fin de la factura tiene valor 3

                            Else

                            End If
                            'Fin esta activado el chkfecha
                        Else
                            MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If



                    Next
                End If

                'pgbProgreso.Value = 0
                ''preguntamos si quiere que validemos los datos de la no encontradas en sumatorias, solo en abonos

                'Dim resultado As Integer = MessageBox.Show("¿Desea que el sistema trate en sumar los montos de los abonos sin factura?", "Pregunta", MessageBoxButtons.YesNo)
                'If resultado = DialogResult.Yes Then
                '    'Buscamos en pagos
                '    For Each producto As ListViewItem In lsvLista.CheckedItems

                '    Next
                'End If

                'select iIdFactura from facturas where iIdFactura NOT IN (select fkiIdFactura as iIdFactura
                'from conciliacion  
                'where  conciliacion.iEstatus=1 and iEstatus2=2)
                'and Facturas.Fecha between '01/12/2017' and '31/12/2017' And facturas.fkiIdEmpresa= 28 and Facturas.cancelada=1


                tsbGuardar.Enabled = True
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

    Private Sub lsvLista_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvLista.ItemActivate
        Try
            If lsvLista.SelectedItems(0).SubItems(11).Tag <> "" Then
                Dim Forma As New frmlista
                Forma.gIdFacturas = lsvLista.SelectedItems(0).SubItems(11).Tag
                If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                    lsvLista.SelectedItems(0).SubItems(8).Text = Forma.gIdFacturaSelec
                    lsvLista.SelectedItems(0).SubItems(8).Tag = Forma.giIdFactura
                    lsvLista.SelectedItems(0).SubItems(11).Text = "1"
                    lsvLista.SelectedItems(0).BackColor = Color.Green
                    lsvLista.SelectedItems(0).Checked = True
                    'lsvLista.SelectedItems(0).SubItems(lsvLista.SelectedItems(0).SubItems.Count - 1).Text = "1"

                    MessageBox.Show("Factura asignada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'If cboempresa.SelectedIndex > -1 Then
                    '    cargarlista()
                    'End If
                    'lsvLista.SelectedItems(0).Tag = ""
                End If
            ElseIf lsvLista.SelectedItems(0).SubItems(11).Text = "3" And lsvLista.SelectedItems(0).SubItems(6).Text <> "0.00" Then

                'preguntamos si quiere asginar gastos o requiere poner la leyenda directamente
                Dim resultado As Integer = MessageBox.Show("¿Desea buscar Factura?", "Pregunta", MessageBoxButtons.YesNo)
                If resultado = DialogResult.Yes Then
                    Dim Forma As New frmAnexarFacturaConciliacion
                    Forma.giIdEmpresa = cboempresa.SelectedIndex
                    Forma.gFechaInicial = dtpfechainicio.Value
                    Forma.gFechaFinal = dtpfechafin.Value
                    If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                        lsvLista.SelectedItems(0).SubItems(8).Text = Forma.gDatosFactura
                        lsvLista.SelectedItems(0).SubItems(8).Tag = Forma.giIdFactura
                        lsvLista.SelectedItems(0).SubItems(11).Text = "1"
                        lsvLista.SelectedItems(0).BackColor = Color.Green
                        lsvLista.SelectedItems(0).Checked = True
                        'lsvLista.SelectedItems(0).SubItems(lsvLista.SelectedItems(0).SubItems.Count - 1).Text = "1"

                        MessageBox.Show("Factura asignada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'If cboempresa.SelectedIndex > -1 Then
                        '    cargarlista()
                        'End If
                        'lsvLista.SelectedItems(0).Tag = ""
                    End If
                Else
                    Dim Forma As New frmCargoManual

                    If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                        lsvLista.SelectedItems(0).SubItems(8).Text = Forma.gTextoCargo
                        'lsvLista.SelectedItems(0).SubItems(8).Tag = Forma.giIdFactura
                        lsvLista.SelectedItems(0).SubItems(11).Text = "1"
                        lsvLista.SelectedItems(0).BackColor = Color.Green
                        lsvLista.SelectedItems(0).Checked = True


                        MessageBox.Show("Abono asignado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If
                End If


            ElseIf (lsvLista.SelectedItems(0).SubItems(11).Text = "3" And lsvLista.SelectedItems(0).SubItems(5).Text <> "0.00") Or (lsvLista.SelectedItems(0).SubItems(11).Text = "1" And lsvLista.SelectedItems(0).SubItems(5).Text <> "0.00") Then

                'preguntamos si quiere asginar gastos o requiere poner la leyenda directamente
                Dim resultado As Integer = MessageBox.Show("¿Desea buscar gastos?", "Pregunta", MessageBoxButtons.YesNo)
                If resultado = DialogResult.Yes Then
                    Dim Forma As New frmAnexarGastosConciliacion
                    Forma.giIdEmpresa = cboempresa.SelectedIndex
                    Forma.gFechaInicial = dtpfechainicio.Value
                    Forma.gFechaFinal = dtpfechafin.Value
                    If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                        lsvLista.SelectedItems(0).SubItems(8).Text = Forma.gDatosFactura
                        lsvLista.SelectedItems(0).SubItems(8).Tag = Forma.giIdFactura
                        lsvLista.SelectedItems(0).SubItems(11).Text = "1"
                        lsvLista.SelectedItems(0).BackColor = Color.Green
                        lsvLista.SelectedItems(0).Checked = True
                        'lsvLista.SelectedItems(0).SubItems(lsvLista.SelectedItems(0).SubItems.Count - 1).Text = "1"

                        MessageBox.Show("Factura asignada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'If cboempresa.SelectedIndex > -1 Then
                        '    cargarlista()
                        'End If
                        'lsvLista.SelectedItems(0).Tag = ""
                    End If
                Else
                    Dim Forma As New frmCargoManual

                    If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                        lsvLista.SelectedItems(0).SubItems(8).Text = Forma.gTextoCargo
                        'lsvLista.SelectedItems(0).SubItems(8).Tag = Forma.giIdFactura
                        lsvLista.SelectedItems(0).SubItems(11).Text = "1"
                        lsvLista.SelectedItems(0).BackColor = Color.Green
                        lsvLista.SelectedItems(0).Checked = True


                        MessageBox.Show("Cargo asignado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If
                End If

            ElseIf lsvLista.SelectedItems(0).SubItems(11).Text = "1" And lsvLista.SelectedItems(0).SubItems(6).Text <> "0.00" Then
                Dim resultado As Integer = MessageBox.Show("¿Desea buscar Factura?", "Pregunta", MessageBoxButtons.YesNo)
                If resultado = DialogResult.Yes Then
                    Dim Forma As New frmAnexarFacturaConciliacion
                    Forma.giIdEmpresa = cboempresa.SelectedIndex
                    Forma.gFechaInicial = dtpfechainicio.Value
                    Forma.gFechaFinal = dtpfechafin.Value
                    If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                        lsvLista.SelectedItems(0).SubItems(8).Text = Forma.gDatosFactura
                        lsvLista.SelectedItems(0).SubItems(8).Tag = Forma.giIdFactura
                        lsvLista.SelectedItems(0).SubItems(11).Text = "1"
                        lsvLista.SelectedItems(0).BackColor = Color.Green
                        lsvLista.SelectedItems(0).Checked = True
                        'lsvLista.SelectedItems(0).SubItems(lsvLista.SelectedItems(0).SubItems.Count - 1).Text = "1"

                        MessageBox.Show("Factura asignada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'If cboempresa.SelectedIndex > -1 Then
                        '    cargarlista()
                        'End If
                        'lsvLista.SelectedItems(0).Tag = ""
                    End If
                Else
                    Dim Forma As New frmCargoManual

                    If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                        lsvLista.SelectedItems(0).SubItems(8).Text = Forma.gTextoCargo
                        'lsvLista.SelectedItems(0).SubItems(8).Tag = Forma.giIdFactura
                        lsvLista.SelectedItems(0).SubItems(11).Text = "1"
                        lsvLista.SelectedItems(0).BackColor = Color.Green
                        lsvLista.SelectedItems(0).Checked = True


                        MessageBox.Show("Abono asignado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub tsbGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGuardar.Click
        Dim TotalLista As Integer
        Dim nombresistema As String
        Dim valorFactura As String
        nombresistema = ""
        Dim ids As String()
        Dim fkiIdFactura0 As String
        Dim fkiIdFactura1 As String
        Dim fkiIdFactura2 As String
        Dim fkiIdFactura3 As String
        Dim fkiIdFactura4 As String
        Dim fkiIdFactura5 As String
        Dim fkiIdFactura6 As String
        Dim fkiIdFactura7 As String
        Dim fkiIdFactura8 As String
        Dim fkiIdFactura9 As String
        Dim fkiIdFactura10 As String
        Dim fkiIdFactura11 As String
        Dim fkiIdFactura12 As String
        Dim fkiIdFactura13 As String
        Dim fkiIdFactura14 As String
        Dim abonos As Double



        Dim cadena As String

        pnlProgreso.Visible = True
        pnlCatalogo.Enabled = False
        Application.DoEvents()



        pgbProgreso.Minimum = 0
        pgbProgreso.Value = 0
        pgbProgreso.Maximum = lsvLista.CheckedItems.Count
        Try

            TotalLista = lsvLista.Items.Count

            If rdbTodos.Checked Then
                cadena = "Todos"
            ElseIf rdbAbonos.Checked Then
                cadena = "solo Abonos"
            ElseIf rdbCargos.Checked Then
                cadena = "solo Cargos"
            End If


            Dim resultado As Integer = MessageBox.Show("Los datos a guardar son " & cadena & ". Solo se guardaran los registros seleccionados y en color verde, el registro guardado sera ligado al usuario. ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                'Buscamos en pagos
                SQL = "Select * from usuarios where idUsuario = " & idUsuario
                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim Fila As DataRow = rwFilas(0)
                    nombresistema = Fila.Item("nombre")
                    If Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "9" Then
                        For Each producto As ListViewItem In lsvLista.CheckedItems
                            pgbProgreso.Value += 1
                            If producto.SubItems(11).Text = "1" Then
                                If producto.SubItems(8).Tag Is Nothing = False Then
                                    valorFactura = IIf(producto.SubItems(8).Tag.ToString = "", "0", producto.SubItems(8).Tag.ToString)
                                Else
                                    valorFactura = "0"
                                End If

                                ids = valorFactura.Split(",")

                                fkiIdFactura0 = "0"
                                fkiIdFactura1 = "0"
                                fkiIdFactura2 = "0"
                                fkiIdFactura3 = "0"
                                fkiIdFactura4 = "0"
                                fkiIdFactura5 = "0"
                                fkiIdFactura6 = "0"
                                fkiIdFactura7 = "0"
                                fkiIdFactura8 = "0"
                                fkiIdFactura9 = "0"
                                fkiIdFactura10 = "0"
                                fkiIdFactura11 = "0"
                                fkiIdFactura12 = "0"
                                fkiIdFactura13 = "0"
                                fkiIdFactura14 = "0"

                                If ids.Length = 1 Then
                                    fkiIdFactura0 = ids(0)
                                ElseIf ids.Length = 2 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                ElseIf ids.Length = 3 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)

                                ElseIf ids.Length = 4 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                ElseIf ids.Length = 5 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)

                                ElseIf ids.Length = 6 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)

                                ElseIf ids.Length = 7 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)


                                ElseIf ids.Length = 8 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)

                                ElseIf ids.Length = 9 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)
                                    fkiIdFactura8 = ids(8)

                                ElseIf ids.Length = 10 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)
                                    fkiIdFactura8 = ids(8)
                                    fkiIdFactura9 = ids(9)

                                ElseIf ids.Length = 11 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)
                                    fkiIdFactura8 = ids(8)
                                    fkiIdFactura9 = ids(9)
                                    fkiIdFactura10 = ids(10)

                                ElseIf ids.Length = 12 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)
                                    fkiIdFactura8 = ids(8)
                                    fkiIdFactura9 = ids(9)
                                    fkiIdFactura10 = ids(10)
                                    fkiIdFactura11 = ids(11)

                                ElseIf ids.Length = 13 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)
                                    fkiIdFactura8 = ids(8)
                                    fkiIdFactura9 = ids(9)
                                    fkiIdFactura10 = ids(10)
                                    fkiIdFactura11 = ids(11)
                                    fkiIdFactura12 = ids(12)

                                ElseIf ids.Length = 14 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)
                                    fkiIdFactura8 = ids(8)
                                    fkiIdFactura9 = ids(9)
                                    fkiIdFactura10 = ids(10)
                                    fkiIdFactura11 = ids(11)
                                    fkiIdFactura12 = ids(12)
                                    fkiIdFactura13 = ids(13)

                                ElseIf ids.Length >= 15 Then
                                    fkiIdFactura0 = ids(0)
                                    fkiIdFactura1 = ids(1)
                                    fkiIdFactura2 = ids(2)
                                    fkiIdFactura3 = ids(3)
                                    fkiIdFactura4 = ids(4)
                                    fkiIdFactura5 = ids(5)
                                    fkiIdFactura6 = ids(6)
                                    fkiIdFactura7 = ids(7)
                                    fkiIdFactura8 = ids(8)
                                    fkiIdFactura9 = ids(9)
                                    fkiIdFactura10 = ids(10)
                                    fkiIdFactura11 = ids(11)
                                    fkiIdFactura12 = ids(12)
                                    fkiIdFactura13 = ids(13)
                                    fkiIdFactura14 = ids(14)

                                End If


                                If rdbTodos.Checked Then
                                    SQL = "update conciliacion set  fkIdUsuario2=" & idUsuario
                                    SQL &= ",cUsuario2='" & nombresistema
                                    SQL &= "',cDatosFactura='" & producto.SubItems(8).Text
                                    SQL &= "',fkiIdFactura=" & fkiIdFactura0
                                    SQL &= ",fkiIdFactura2=" & fkiIdFactura1
                                    SQL &= ",fkiIdFactura3=" & fkiIdFactura2
                                    SQL &= ",fkiIdFactura4=" & fkiIdFactura3
                                    SQL &= ",fkiIdFactura5=" & fkiIdFactura4
                                    SQL &= ",fkiIdFactura6=" & fkiIdFactura5
                                    SQL &= ",fkiIdFactura7=" & fkiIdFactura6
                                    SQL &= ",fkiIdFactura8=" & fkiIdFactura7
                                    SQL &= ",fkiIdFactura9=" & fkiIdFactura8
                                    SQL &= ",fkiIdFactura10=" & fkiIdFactura9
                                    SQL &= ",fkiIdFactura11=" & fkiIdFactura10
                                    SQL &= ",fkiIdFactura12=" & fkiIdFactura11
                                    SQL &= ",fkiIdFactura13=" & fkiIdFactura12
                                    SQL &= ",fkiIdFactura14=" & fkiIdFactura13
                                    SQL &= ",fkiIdFactura15=" & fkiIdFactura14
                                    SQL &= ",iEstatus2=2"
                                    SQL &= " where iIdConciliacion=" & producto.Tag

                                    If nExecute(SQL) = False Then
                                        MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(4).Text) & " Cargo:" & Trim(producto.SubItems(5).Text) & " Abono:" & Trim(producto.SubItems(6).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If

                                    producto.SubItems(10).Text = nombresistema
                                ElseIf rdbAbonos.Checked And producto.SubItems(6).Text <> "0.00" Then
                                    SQL = "update conciliacion set  fkIdUsuario2=" & idUsuario
                                    SQL &= ",cUsuario2='" & nombresistema
                                    SQL &= "',cDatosFactura='" & producto.SubItems(8).Text
                                    SQL &= "',fkiIdFactura=" & fkiIdFactura0
                                    SQL &= ",fkiIdFactura2=" & fkiIdFactura1
                                    SQL &= ",fkiIdFactura3=" & fkiIdFactura2
                                    SQL &= ",fkiIdFactura4=" & fkiIdFactura3
                                    SQL &= ",fkiIdFactura5=" & fkiIdFactura4
                                    SQL &= ",fkiIdFactura6=" & fkiIdFactura5
                                    SQL &= ",fkiIdFactura7=" & fkiIdFactura6
                                    SQL &= ",fkiIdFactura8=" & fkiIdFactura7
                                    SQL &= ",fkiIdFactura9=" & fkiIdFactura8
                                    SQL &= ",fkiIdFactura10=" & fkiIdFactura9
                                    SQL &= ",fkiIdFactura11=" & fkiIdFactura10
                                    SQL &= ",fkiIdFactura12=" & fkiIdFactura11
                                    SQL &= ",fkiIdFactura13=" & fkiIdFactura12
                                    SQL &= ",fkiIdFactura14=" & fkiIdFactura13
                                    SQL &= ",fkiIdFactura15=" & fkiIdFactura14
                                    SQL &= ",iEstatus2=2"
                                    SQL &= " where iIdConciliacion=" & producto.Tag

                                    If nExecute(SQL) = False Then
                                        MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(4).Text) & " Cargo:" & Trim(producto.SubItems(5).Text) & " Abono:" & Trim(producto.SubItems(6).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If

                                    producto.SubItems(10).Text = nombresistema
                                ElseIf rdbCargos.Checked And producto.SubItems(5).Text <> "0.00" Then
                                    SQL = "update conciliacion set  fkIdUsuario2=" & idUsuario
                                    SQL &= ",cUsuario2='" & nombresistema
                                    SQL &= "',cDatosFactura='" & producto.SubItems(8).Text
                                    SQL &= "',fkiIdFactura=" & fkiIdFactura0
                                    SQL &= ",fkiIdFactura2=" & fkiIdFactura1
                                    SQL &= ",fkiIdFactura3=" & fkiIdFactura2
                                    SQL &= ",fkiIdFactura4=" & fkiIdFactura3
                                    SQL &= ",fkiIdFactura5=" & fkiIdFactura4
                                    SQL &= ",fkiIdFactura6=" & fkiIdFactura5
                                    SQL &= ",fkiIdFactura7=" & fkiIdFactura6
                                    SQL &= ",fkiIdFactura8=" & fkiIdFactura7
                                    SQL &= ",fkiIdFactura9=" & fkiIdFactura8
                                    SQL &= ",fkiIdFactura10=" & fkiIdFactura9
                                    SQL &= ",fkiIdFactura11=" & fkiIdFactura10
                                    SQL &= ",fkiIdFactura12=" & fkiIdFactura11
                                    SQL &= ",fkiIdFactura13=" & fkiIdFactura12
                                    SQL &= ",fkiIdFactura14=" & fkiIdFactura13
                                    SQL &= ",fkiIdFactura15=" & fkiIdFactura14
                                    SQL &= ",iEstatus2=2"
                                    SQL &= " where iIdConciliacion=" & producto.Tag

                                    If nExecute(SQL) = False Then
                                        MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(4).Text) & " Cargo:" & Trim(producto.SubItems(5).Text) & " Abono:" & Trim(producto.SubItems(6).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If

                                    producto.SubItems(10).Text = nombresistema
                                End If

                                'Pones las facturas en verde en forma automatica

                                For z As Integer = 0 To ids.Length - 1
                                    SQL = "select isnull(sum(importe),0) as importe from pagos where iEstatus=1 and fkiIdfactura=" & ids(z)
                                    Dim rwFilasAbonos As DataRow() = nConsulta(SQL)
                                    abonos = 0

                                    If rwFilasAbonos Is Nothing = False Then
                                        abonos = Double.Parse(rwFilasAbonos(0).Item("importe"))
                                    End If
                                    SQL = "select * from facturas where iIdFactura=" & ids(z)

                                    Dim rwDatosFactura As DataRow() = nConsulta(SQL)
                                    If rwDatosFactura Is Nothing = False Then
                                        If abonos = 0 Then
                                            'Factura sin abonos
                                            'Dim resultadoabono As Integer = MessageBox.Show("Guardar la factura en color verde, significa que dicha factura esta pagada en su totalidad, por lo cual se hara de manera automatica un abono por la cantidad total de la factura y quedara saldada, ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)

                                            'Hacer el detalle automatico
                                            SQL = "EXEC setpagosInsertar  0," & ids(z)
                                            SQL &= ",'" & Date.Parse(rwDatosFactura(0)("fecha").ToString).ToShortDateString
                                            SQL &= "'," & rwDatosFactura(0)("Total").ToString
                                            SQL &= ",'" & nombresistema
                                            SQL &= "','Abono automatico'"
                                            SQL &= ",'" & Date.Now.ToShortDateString()
                                            SQL &= "',1"

                                            If nExecute(SQL) = False Then
                                                Exit Sub
                                            End If

                                            SQL = "update facturas set  color=2 where iIdFactura=" & ids(z)
                                            If nExecute(SQL) = False Then
                                                Exit Sub
                                            End If
                                            'bandera = True
                                            'MessageBox.Show("Abono por el total de la factura realizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                            'EditarColores(lsvLista.SelectedItems(0).Tag)

                                            'ElseIf (Double.Parse(totalfactura) - abonos) <= 1 Or (abonos - Double.Parse(totalfactura)) <= 1 Then
                                            '    'Factura saldada

                                            '    MessageBox.Show("La factura ya fue abonada en sus totalidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                            '    bandera = True
                                            'ElseIf (Double.Parse(totalfactura) - abonos) > 1 Then
                                            '    'Factura con abonos pendientes
                                            '    MessageBox.Show("La factura ya fue abonada pero tiene saldo pendiente, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                                        End If
                                    End If



                                Next

                            End If
                        Next
                        pnlProgreso.Visible = False
                        pnlCatalogo.Enabled = True

                        tsbCancelar_Click(sender, e)

                        MessageBox.Show("Datos guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        pnlProgreso.Visible = False
                        pnlCatalogo.Enabled = True

                        'tsbCancelar_Click(sender, e)
                        MessageBox.Show("Su perfil de usuario, no tienes permisos para esta acción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)


                    End If
                End If



                
            End If
            'For Each producto As ListViewItem In lsvLista.CheckedItems
            '    If producto.SubItems(11).Text = "1" Then
            '        'SQL = "update"

            '    End If

            'Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbreportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbreportes.Click
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

            hoja.Range(4, 2, 4, 8).Style.Font.FontSize = 10

            hoja.Range(4, 2, 4, 8).Style.Font.SetBold(True)
            hoja.Range(4, 2, 4, 8).Style.Alignment.WrapText = True

            hoja.Range(4, 2, 4, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja.Range(4, 1, 4, 8).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)

            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja.Range(4, 2, 4, 8).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")

            hoja.Range(4, 2, 4, 8).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            'hoja.Cell(4, 1).Value = "Num"
            hoja.Cell(4, 2).Value = "Fecha"

            hoja.Cell(4, 3).Value = "Concepto/Referencia"
            hoja.Cell(4, 4).Value = "Cargo"

            hoja.Cell(4, 5).Value = "Abono"

            hoja.Cell(4, 6).Value = "Saldo"
            hoja.Cell(4, 7).Value = "Conciliado con"
            hoja.Cell(4, 8).Value = "Conciliado por"

            filaExcel = 4

            For Each producto As ListViewItem In lsvLista.CheckedItems
                filaExcel = filaExcel + 1


                hoja.Cell(filaExcel, 2).Value = producto.SubItems(3).Text

                hoja.Cell(filaExcel, 3).Value = producto.SubItems(4).Text

                hoja.Cell(filaExcel, 4).Value = Format(CType(IIf(producto.SubItems(5).Text = "", "0", producto.SubItems(5).Text), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 4).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 5).Value = Format(CType(IIf(producto.SubItems(6).Text = "", "0", producto.SubItems(6).Text), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 5).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 6).Value = Format(CType(IIf(producto.SubItems(7).Text = "", "0", producto.SubItems(7).Text), Decimal), "###,###,##0.#0")
                hoja.Cell(filaExcel, 6).Style.NumberFormat.SetFormat("###,###,##0.#0")
                hoja.Cell(filaExcel, 7).Value = producto.SubItems(8).Text


                If producto.SubItems(11).Text = "1" Then
                    hoja.Cell(filaExcel, 7).Style.Fill.BackgroundColor = XLColor.FromHtml("#00FF40")



                ElseIf producto.SubItems(11).Text = "2" Then
                    hoja.Cell(filaExcel, 7).Style.Fill.BackgroundColor = XLColor.Yellow

                ElseIf producto.SubItems(11).Text = "3" Then
                    hoja.Cell(filaExcel, 7).Style.Fill.BackgroundColor = XLColor.Red

                ElseIf producto.SubItems(11).Text = "5" Then
                    hoja.Cell(filaExcel, 7).Style.Fill.BackgroundColor = XLColor.Aquamarine
                End If
                hoja.Cell(filaExcel, 8).Value = producto.SubItems(10).Text

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

    Private Sub tsbDeleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDeleted.Click

        Dim SQL As String, nombresistema As String = ""
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio

        Try

            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombresistema = Fila.Item("nombre")

                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then
                    ''If (tiempo.Days >= 0) Then

                    If lsvLista.CheckedItems.Count <> 0 Then

                        Dim confimacion As String = MsgBox("¿Esta seguro que desea eliminar?, una vez eliminado ya no podra utilizar estos datos.", vbOKCancel, "CONFIRMACIÓN")
                        If confimacion = vbOK Then

                            Dim mensaje As String
                            Dim idConciliacion As String


                            pnlProgreso.Visible = True
                            pnlCatalogo.Enabled = False
                            Application.DoEvents()
                            Dim t As Integer = 0


                            For x = 0 To lsvLista.CheckedItems.Count - 1
                                Dim rwData As DataRow() = nConsulta("select * from conciliacion where iIdConciliacion= " & lsvLista.CheckedItems(x).Tag)
                                pgbProgreso.Minimum = 0
                                pgbProgreso.Value = 0
                                pgbProgreso.Maximum = rwData.Length
                                If rwData Is Nothing = False Then
                                    For Each Fila In rwData

                                        SQL = "EXEC setconciliacionRespaldoInsertar  0," & cbobanco.SelectedValue & "," & cboempresa.SelectedValue
                                        SQL &= ",'" & Fila.Item("dFechaMovimiento").ToString.Substring(0, 16)
                                        SQL &= "'," & Fila.Item("iAnio")
                                        SQL &= "," & Fila.Item("iMes")
                                        SQL &= ",'" & Fila.Item("cConcepto")
                                        SQL &= "'," & Fila.Item("fCargo")
                                        SQL &= "," & Fila.Item("fAbono")
                                        SQL &= "," & Fila.Item("fSaldo")
                                        SQL &= ",'','',0,0,0,0,''," & Fila.Item("fkiIdUsuario")
                                        SQL &= ",'" & Fila.Item("cUsuario")
                                        SQL &= "','" & Fila.Item("dFechaCaptura").ToString.Substring(0, 16)
                                        SQL &= "',1,1"
                                        SQL &= ",0,''"
                                        SQL &= ",'" & DateTime.Now.ToString.Substring(0, 16)
                                        SQL &= "','" & nombresistema & "'"


                                        If nExecute(SQL) = False Then
                                            MessageBox.Show("Error al eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        End If
                                        pgbProgreso.Value += 1
                                        Application.DoEvents()
                                        t = t + 1

                                        SQL = " DELETE FROM  conciliacion "
                                        SQL &= "WHERE iIdConciliacion=" & Fila.Item("iIdConciliacion")
                                        If nExecute(SQL) = False Then
                                            MessageBox.Show("Hubo un error al eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        End If
                                    Next
                                End If
                            Next x




                            'SQL = " SELECT * from conciliacion"
                            'SQL &= " WHERE fkiIdEmpresa=" & cboempresa.SelectedValue
                            'SQL &= " AND fkiIdBanco=" & cbobanco.SelectedValue
                            'SQL &= " AND  dfechaMovimiento BETWEEN '" + inicio.ToShortDateString + "' AND '" + fin.ToShortDateString + "'"

                            'Dim rwDatos As DataRow() = nConsulta(SQL)

                            'If rwDatos Is Nothing = False Then

                            '    For Each Fila In rwDatos

                            '        SQL = "EXEC setconciliacionRespaldoInsertar  0," & cbobanco.SelectedValue & "," & cboempresa.SelectedValue
                            '        SQL &= ",'" & Fila.Item("dFechaMovimiento").ToString.Substring(0, 16)
                            '        SQL &= "'," & Fila.Item("iAnio")
                            '        SQL &= "," & Fila.Item("iMes")
                            '        SQL &= ",'" & Fila.Item("cConcepto")
                            '        SQL &= "'," & Fila.Item("fCargo")
                            '        SQL &= "," & Fila.Item("fAbono")
                            '        SQL &= "," & Fila.Item("fSaldo")
                            '        SQL &= ",'','',0,0,0,0,''," & Fila.Item("fkiIdUsuario")
                            '        SQL &= ",'" & Fila.Item("cUsuario")
                            '        SQL &= "','" & Fila.Item("dFechaCaptura").ToString.Substring(0, 16)
                            '        SQL &= "',1,1"
                            '        SQL &= ",0,''"
                            '        SQL &= ",'" & DateTime.Now.ToString.Substring(0, 16)
                            '        SQL &= "','" & nombresistema & "'"

                            '        If nExecute(SQL) = False Then
                            '            MessageBox.Show("Error al eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            '        End If
                            '        pgbProgreso.Value += 1
                            '        Application.DoEvents()
                            '        t = t + 1
                            '    Next

                            'SQL = "EXEC deleteConciliacion "
                            'SQL &= cboempresa.SelectedValue
                            'SQL &= ", " & cbobanco.SelectedValue
                            'SQL &= ", '" & inicio.ToShortDateString & "'"
                            'SQL &= ", '" & fin.ToShortDateString & "'"
                            'If nExecute(SQL) = False Then
                            '    MessageBox.Show("Hubo un error al eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'End If


                            'Else
                            '    MessageBox.Show("No se encontraron datos que eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            'End If

                            ' tsbCancelar_Click(sender, e)
                            '' lsvLista.Clear()

                            pnlProgreso.Visible = False
                            pnlCatalogo.Enabled = True
                            MessageBox.Show("Datos eliminados satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tsbNuevo_Click(sender, e)
                        End If
                        'Else

                        '    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'End If
                    Else
                        MessageBox.Show("Seleccione al menos un dato, que desea eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


                    End If

                Else
                    MessageBox.Show("No tiene permisos para realizar esta acción, consulte al administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Else
                MessageBox.Show("Existe un error con el usuario, consulte al administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try


    End Sub


    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub tsbRegistros_Click(sender As System.Object, e As System.EventArgs) Handles tsbRegistros.Click
        Try
            Dim filaExcel As Integer = 5
            Dim dialogo As New SaveFileDialog()
            Dim idtipo As Integer
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Flujo")
            hoja.Column("A").Width = 20
            hoja.Column("B").Width = 15
            hoja.Column("C").Width = 15
            hoja.Column("D").Width = 12
            hoja.Column("E").Width = 25
            hoja.Column("F").Width = 15
            hoja.Column("G").Width = 15
            hoja.Column("H").Width = 15
            hoja.Column("I").Width = 25
            

            hoja.Range(1, 1, 1, 9).Style.Font.FontSize = 10
            hoja.Range(1, 1, 1, 9).Style.Font.SetBold(True)
            hoja.Range(1, 1, 1, 9).Style.Alignment.WrapText = True
            hoja.Range(1, 1, 1, 9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja.Range(1, 1, 1, 9).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja.Range(1, 1, 1, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja.Range(1, 1, 1, 9).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            'hoja.Cell(4, 1).Value = "Num"

            hoja.Cell(1, 1).Value = "iIdConciliación"
            hoja.Cell(1, 2).Value = "Banco"
            hoja.Cell(1, 3).Value = "Empresa"
            hoja.Cell(1, 4).Value = "Fecha"
            hoja.Cell(1, 5).Value = "Concepto"
            hoja.Cell(1, 6).Value = "Cargo"
            hoja.Cell(1, 7).Value = "Abono"
            hoja.Cell(1, 8).Value = "Saldo"
            hoja.Cell(1, 9).Value = "Datos Factura"
            


            filaExcel = 1

            For Each producto As ListViewItem In lsvLista.CheckedItems

                If producto.SubItems(5).Text <> "0.00" And (producto.SubItems(6).Text = "" Or producto.SubItems(6).Text = "0.00") Then
                    filaExcel = filaExcel + 1

                    hoja.Cell(filaExcel, 1).Value = producto.SubItems(0).Text
                    hoja.Cell(filaExcel, 2).Value = producto.SubItems(1).Text
                    hoja.Cell(filaExcel, 3).Value = producto.SubItems(2).Text
                    hoja.Cell(filaExcel, 4).Value = producto.SubItems(3).Text
                    hoja.Cell(filaExcel, 5).Value = producto.SubItems(4).Text
                    hoja.Cell(filaExcel, 6).Value = producto.SubItems(5).Text
                    hoja.Cell(filaExcel, 7).Value = producto.SubItems(6).Text
                    hoja.Cell(filaExcel, 8).Value = producto.SubItems(7).Text
                    hoja.Cell(filaExcel, 9).Value = producto.SubItems(8).Text

                    hoja.Range(2, 9, 1500, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")
                End If


            Next

            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Datos conciliacion " & cboempresa.Text & " en el banco " & cbobanco.Text
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            libro.SaveAs(dialogo.FileName)
            'libro.SaveAs("c:\temp\control.xlsx")
            'libro.SaveAs(dialogo.FileName)
            'apExcel.Quit()
            libro = Nothing
            MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsbSubirRegistro_Click(sender As System.Object, e As System.EventArgs) Handles tsbSubirRegistro.Click
        Dim Forma As New ImportarSueldosConciliacion
        Forma.ShowDialog()

        'Forma.gIdEmpresa = gIdEmpresa
        'If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    gIdEmpleado = Forma.gIdEmpleado
        '    MostrarEmpleado(Forma.gIdEmpleado)

        'End If
    End Sub
End Class