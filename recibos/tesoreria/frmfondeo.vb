Imports ClosedXML.Excel
Public Class frmFondeo
    Dim SQL As String
    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub
  
    Private Sub tsbBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBuscar.Click
        Try
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            lsvLista.Items.Clear()
            lsvLista.Clear()

            If chkAllEmpresas.Checked = True Then
                SQL = "SELECT * FROM FondeoPatrona"
                SQL &= " WHERE iEstatus=1 "
                SQL &= " ORDER BY fkiIdEmpresa, fechapago"
            Else
                If (tiempo.Days >= 0) Then

                    SQL = "SELECT * FROM FondeoPatrona where fkiIdEmpresa=" & cboempresa.SelectedValue
                    If chkfecha.Checked = True Then
                        SQL &= " AND fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                        ' SQL &= " and DATEPART(month, fechapago) ='" & cboMesI.SelectedIndex + 1 & "'"
                    End If
                    SQL &= "AND iEstatus=1 "
                    SQL &= "ORDER BY fechapago "

                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
           
            Dim item As ListViewItem
            lsvLista.Columns.Add("iIdFondePatrona")
            lsvLista.Columns(0).Width = 50
            lsvLista.Columns.Add("Fecha")
            lsvLista.Columns(1).Width = 100
            lsvLista.Columns.Add("Cliente")
            lsvLista.Columns(2).Width = 300
            lsvLista.Columns.Add("Intermediario")
            lsvLista.Columns(3).Width = 300
            lsvLista.Columns.Add("Sueldo")
            lsvLista.Columns(4).Width = 100
            lsvLista.Columns.Add("Descuento")
            lsvLista.Columns(5).Width = 110
            lsvLista.Columns(5).TextAlign = 1
            lsvLista.Columns.Add("INFONAVIT")
            lsvLista.Columns(6).Width = 110
            lsvLista.Columns(6).TextAlign = 1
            lsvLista.Columns.Add("Pensión")
            lsvLista.Columns(7).Width = 110
            lsvLista.Columns(7).TextAlign = 1
            lsvLista.Columns.Add("IMSS")
            lsvLista.Columns(8).Width = 110
            lsvLista.Columns.Add("Total Fondeo")
            lsvLista.Columns(9).Width = 110
            lsvLista.Columns.Add("Periodo")
            lsvLista.Columns(10).Width = 190
            lsvLista.Columns.Add("Observaciones")
            lsvLista.Columns(11).Width = 350
            lsvLista.Columns(11).TextAlign = 2
            lsvLista.Columns.Add("Fondeado")
            lsvLista.Columns(12).Width = 150
            lsvLista.Columns(12).TextAlign = 2


            Dim rwFondeOperadora As DataRow() = nConsulta(SQL)
            If rwFondeOperadora Is Nothing = False Then
                For Each Fila In rwFondeOperadora

                    Dim cliente As DataRow() = nConsulta("select *  from clientes where iIdCliente=" & Fila.Item("fkiIdCliente"))
                    Dim empresa As DataRow() = nConsulta("select *  from empresa where iIdEmpresa=" & Fila.Item("fkiIdEmpresa"))
                    Dim periodo As DataRow() = nConsulta("select (CONVERT(nvarchar(12),dFechaInicio,103) + ' - ' + CONVERT(nvarchar(12),dFechaFin,103)) as Periodo  from periodos where iIdPeriodo=" & Fila.Item("fkiIdPeriodo"))

                    item = lsvLista.Items.Add("" & Fila.Item("iIdFondeoPatrona"))
                    item.SubItems.Add("" & Fila.Item("fechapago"))
                    item.SubItems.Add("" & cliente(0).Item("nombre"))
                    item.SubItems.Add("" & empresa(0).Item("nombre"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("fSueldo"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("fComisionSA"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("fInfonavit"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("fPension"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("fIMSS"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CInt(Fila.Item("fSueldo")) + CInt(Fila.Item("fComisionSA")) + CInt(Fila.Item("fInfonavit")) + CInt(Fila.Item("fPension")) + CInt(Fila.Item("fIMSS")), "###,###,##0.#0"))
                    item.SubItems.Add("" & periodo(0).Item("Periodo"))
                    item.SubItems.Add("" & tipoNomina(Fila.Item("iTipoNomina")))

                    item.SubItems.Add("" & IIf(Fila.Item("iEstatusFondeo") = 1, "SI", "NO"))
                    item.Tag = Fila.Item("iIdFondeoPatrona")
                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)

                    If (Fila.Item("iEstatusFondeo") = 1) Then
                        item.BackColor = Color.YellowGreen
                    ElseIf (Fila.Item("iEstatusFondeo") = 0) Then

                        item.BackColor = Color.Yellow
                    End If

                Next

                MessageBox.Show(rwFondeOperadora.Count & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'tsbGuardar.Enabled = True
                'tsbNuevo.Enabled = False
                tsbCancelar.Enabled = True

                lblRuta.Text = FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo."
                Me.Enabled = True
                Me.cmdCerrar.Enabled = True
                Me.Cursor = Cursors.Default

            Else
                If chkAllEmpresas.Checked = False Then
                    MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se encontraron datos, intente más tarde", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmfondeo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MostrarEmpresa()
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
        'tsbImportar.Enabled = False
        tsbProcesar.Enabled = False
        ' tsbConciliar.Enabled = False
        ' tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False

        'tsbDeleted.Enabled = False
        tsbBuscar.Enabled = True
    End Sub

    'Private Sub tsbConciliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim SQL As String

    '    Try
    '        If lsvLista.CheckedItems.Count > 0 Then
    '            Dim mensaje As String


    '            pnlProgreso.Visible = True
    '            pnlCatalogo.Enabled = False
    '            Application.DoEvents()


    '            Dim IdProducto As Long
    '            Dim i As Integer = 0
    '            Dim conta As Integer = 0


    '            pgbProgreso.Minimum = 0
    '            pgbProgreso.Value = 0
    '            pgbProgreso.Maximum = lsvLista.CheckedItems.Count

    '            Dim inicio As DateTime = dtpfechainicio.Value
    '            Dim fin As DateTime = dtpfechafin.Value
    '            Dim tiempo As TimeSpan = fin - inicio
    '            Dim fecha As DateTime
    '            Dim contadorlista As Integer
    '            Dim ids As String()
    '            Dim comisiones As String()
    '            Dim clientes As String
    '            Dim numcliente As Integer
    '            Dim cadena As String
    '            Dim facturas As String
    '            Dim bValidar As Boolean
    '            Dim ValorRangoMenos As Double
    '            Dim ValorRangoMas As Double

    '            contadorlista = 0
    '            For Each producto As ListViewItem In lsvLista.CheckedItems
    '                cadena = ""
    '                facturas = ""
    '                contadorlista = contadorlista + 1
    '                pgbProgreso.Value += 1
    '                Application.DoEvents()
    '                'mandar el reporte
    '                If (tiempo.Days >= 0) Then
    '                    If chkfecha.Checked = True Then
    '                        If producto.SubItems(11).Text <> "5" Then
    '                            fecha = CDate(producto.SubItems(3).Text)
    '                            If fecha.Date >= dtpfechainicio.Value.Date And fecha.Date <= dtpfechafin.Value.Date Then
    '                                If producto.SubItems(5).Text <> "0.00" And (producto.SubItems(6).Text = "" Or producto.SubItems(6).Text = "0.00") Then
    '                                    'Buscamos en gastos

    '                                    SQL = "select * from gastos"
    '                                    SQL &= " where total=" & (producto.SubItems(5).Text).Replace(",", "").Replace("$", "") & " And gastos.iEstatus=1 "
    '                                    SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
    '                                    SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
    '                                    Dim rwGastos As DataRow() = nConsulta(SQL)
    '                                    If rwGastos Is Nothing = False Then
    '                                        If rwGastos.Count = 1 Then
    '                                            'Se encontro una sola cantidad
    '                                            Dim Fila As DataRow = rwGastos(0)
    '                                            producto.SubItems(8).Text = Fila("Factura") & " " & Fila("proveedor")
    '                                            producto.SubItems(8).Tag = Fila("iIdGasto")
    '                                            'producto.SubItems.Add(Fila("Factura") & " " & Fila("proveedor"))
    '                                            producto.SubItems(11).Text = "1"
    '                                            'producto.SubItems.Add("1")
    '                                            producto.BackColor = Color.Green
    '                                        Else
    '                                            'Se encontro mas de una cantidad
    '                                            For x As Integer = 0 To rwGastos.Count - 1
    '                                                cadena &= rwGastos(x).Item("Factura") & "-" & rwGastos(x).Item("proveedor") & "/"
    '                                                If x = rwGastos.Count - 1 Then

    '                                                    facturas &= "G" & rwGastos(x).Item("iIdGasto")
    '                                                Else
    '                                                    facturas &= "G" & rwGastos(x).Item("iIdGasto") & ","
    '                                                End If
    '                                            Next
    '                                            producto.SubItems(11).Tag = facturas
    '                                            'producto.Tag = facturas
    '                                            producto.SubItems(8).Text = cadena
    '                                            'producto.SubItems.Add(cadena)
    '                                            'producto.SubItems.Add("2")
    '                                            producto.SubItems(11).Text = "2"
    '                                            producto.BackColor = Color.Yellow
    '                                        End If
    '                                    Else

    '                                        'Buscamos a las empresas relacionadas con los cargos
    '                                        If InStr(Trim(producto.SubItems(4).Text).ToUpper, "SUELDO") > 0 Then
    '                                            producto.SubItems(8).Text = "NOMINA"
    '                                            'producto.SubItems.Add("NOMINA")
    '                                            producto.SubItems(11).Text = "1"
    '                                            'producto.SubItems.Add("1")
    '                                            producto.BackColor = Color.Green

    '                                        ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "DISPERSION") > 0 Then
    '                                            producto.SubItems(8).Text = "NOMINA"
    '                                            'producto.SubItems.Add("NOMINA")
    '                                            producto.SubItems(11).Text = "1"
    '                                            'producto.SubItems.Add("1")
    '                                            producto.BackColor = Color.Green

    '                                        ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "AGUINALDO") > 0 Then
    '                                            producto.SubItems(8).Text = "NOMINA"
    '                                            'producto.SubItems.Add("NOMINA")
    '                                            producto.SubItems(11).Text = "1"
    '                                            'producto.SubItems.Add("1")
    '                                            producto.BackColor = Color.Green

    '                                        ElseIf txtidempresa.Text <> "" Then

    '                                            SQL = "Select * from facturas"
    '                                            SQL &= " inner join empresa On fkiIdEmpresa= iIdEmpresa "
    '                                            SQL &= " where total=" & (producto.SubItems(5).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
    '                                            SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
    '                                            SQL &= " and fkiIdCliente=" & txtidempresa.Text
    '                                            Dim rwCargos As DataRow() = nConsulta(SQL)

    '                                            If rwCargos Is Nothing = False Then
    '                                                If rwCargos.Count = 1 Then
    '                                                    'solo hay una cantidad y agregamos el numero de factura y serie al listview
    '                                                    Dim Fila As DataRow = rwCargos(0)

    '                                                    producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
    '                                                    producto.SubItems(8).Tag = Fila("iIdFactura")
    '                                                    'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
    '                                                    producto.SubItems(11).Text = "1"
    '                                                    'producto.SubItems.Add("1")
    '                                                    producto.BackColor = Color.Green
    '                                                Else
    '                                                    'Hay mas de una cantidad
    '                                                    For x As Integer = 0 To rwCargos.Count - 1
    '                                                        cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
    '                                                        If x = rwCargos.Count - 1 Then

    '                                                            facturas &= "F" & rwCargos(x).Item("iIdFactura")
    '                                                        Else
    '                                                            facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
    '                                                        End If
    '                                                    Next
    '                                                    producto.SubItems(11).Tag = facturas
    '                                                    'producto.Tag = facturas
    '                                                    producto.SubItems(8).Text = cadena
    '                                                    'producto.SubItems.Add(cadena)
    '                                                    producto.SubItems(11).Text = "2"
    '                                                    'producto.SubItems.Add("2")
    '                                                    producto.BackColor = Color.Yellow

    '                                                End If
    '                                            ElseIf txtcomision.Text <> "" Then
    '                                                comisiones = txtcomision.Text.Split(",")
    '                                                bValidar = True
    '                                                For x As Integer = 0 To comisiones.Length - 1

    '                                                    If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(5).Text).Replace(",", "").Replace("$", "")) Then
    '                                                        producto.SubItems(8).Text = "Comisión"
    '                                                        'producto.SubItems.Add("Comisión")
    '                                                        producto.SubItems(11).Text = "1"
    '                                                        'producto.SubItems.Add("1")
    '                                                        producto.BackColor = Color.Green
    '                                                        x = comisiones.Length
    '                                                        bValidar = False
    '                                                    End If


    '                                                Next
    '                                                If bValidar Then
    '                                                    producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                                    'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                                    producto.SubItems(11).Text = "3"
    '                                                    'producto.SubItems.Add("3")
    '                                                    producto.BackColor = Color.Red

    '                                                End If

    '                                            Else
    '                                                producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                                'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                                producto.SubItems(11).Text = "3"
    '                                                'producto.SubItems.Add("3")
    '                                                producto.BackColor = Color.Red
    '                                            End If

    '                                        ElseIf txtcomision.Text <> "" Then
    '                                            comisiones = txtcomision.Text.Split(",")
    '                                            bValidar = True
    '                                            For x As Integer = 0 To comisiones.Length - 1

    '                                                If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(5).Text).Replace(",", "").Replace("$", "")) Then
    '                                                    producto.SubItems(8).Text = "Comisión"
    '                                                    'producto.SubItems.Add("Comisión")
    '                                                    producto.SubItems(11).Text = "1"
    '                                                    'producto.SubItems.Add("1")
    '                                                    producto.BackColor = Color.Green
    '                                                    x = comisiones.Length
    '                                                    bValidar = False
    '                                                End If


    '                                            Next
    '                                            If bValidar Then
    '                                                producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                                'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                                producto.SubItems(11).Text = "3"
    '                                                'producto.SubItems.Add("3")
    '                                                producto.BackColor = Color.Red

    '                                            End If

    '                                        Else
    '                                            producto.SubItems(8).Text = "--"
    '                                            'producto.SubItems.Add("--")
    '                                            producto.SubItems(11).Text = "3"
    '                                            'producto.SubItems.Add("3")
    '                                        End If
    '                                    End If







    '                                ElseIf (producto.SubItems(5).Text = "" Or producto.SubItems(5).Text = "0.00") And producto.SubItems(6).Text <> "0.00" Then
    '                                    'buscamos la cantidad en empresa




    '                                    'SQL = "select * from (pagos"
    '                                    'SQL &= " inner join facturas on pagos.fkiidFactura=facturas.iIdfactura)"
    '                                    'SQL &= " inner join clientes on fkiIdCliente= iIdCliente "
    '                                    'SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And pagos.importe=" & (producto.SubItems(CInt(NudAbono.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
    '                                    'SQL &= " And fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"

    '                                    SQL = "select * from facturas"
    '                                    SQL &= " inner join clientes on fkiIdCliente= iIdCliente  "
    '                                    SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And facturas.total=" & (producto.SubItems(6).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
    '                                    SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
    '                                    Dim rwCargos As DataRow() = nConsulta(SQL)

    '                                    If rwCargos Is Nothing = False Then
    '                                        If rwCargos.Count = 1 Then
    '                                            'solo hay una cantidad y agregamos el numero de factura y serie al listview
    '                                            Dim Fila As DataRow = rwCargos(0)
    '                                            producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
    '                                            producto.SubItems(8).Tag = Fila("iIdFactura")
    '                                            'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
    '                                            producto.SubItems(11).Text = "1"
    '                                            'producto.SubItems.Add("1")
    '                                            producto.BackColor = Color.Green
    '                                        Else
    '                                            'Hay mas de una cantidad

    '                                            For x As Integer = 0 To rwCargos.Count - 1
    '                                                cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
    '                                                If x = rwCargos.Count - 1 Then

    '                                                    facturas &= "F" & rwCargos(x).Item("iIdFactura")
    '                                                Else
    '                                                    facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
    '                                                End If
    '                                            Next
    '                                            'producto.Tag = facturas
    '                                            producto.SubItems(11).Tag = facturas
    '                                            producto.SubItems(8).Text = cadena
    '                                            'producto.SubItems.Add(cadena)
    '                                            producto.SubItems(11).Text = "2"
    '                                            'producto.SubItems.Add("2")
    '                                            producto.BackColor = Color.Yellow
    '                                        End If
    '                                    Else
    '                                        'Aqui va lo del prestamo

    '                                        If InStr(Trim(producto.SubItems(4).Text).ToUpper, "PRESTAMO") > 0 Then
    '                                            producto.SubItems(8).Text = "PRESTAMO"
    '                                            'producto.SubItems.Add("NOMINA")
    '                                            producto.SubItems(11).Text = "1"
    '                                            'producto.SubItems.Add("1")
    '                                            producto.BackColor = Color.Green

    '                                        ElseIf InStr(Trim(producto.SubItems(4).Text).ToUpper, "PRÉSTAMO") > 0 Then
    '                                            producto.SubItems(8).Text = "NOMINA"
    '                                            'producto.SubItems.Add("NOMINA")
    '                                            producto.SubItems(11).Text = "1"
    '                                            'producto.SubItems.Add("1")
    '                                            producto.BackColor = Color.Green
    '                                        Else
    '                                            'producto.BackColor = Color.Red
    '                                            producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                            'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                            producto.SubItems(11).Text = "3"
    '                                            'producto.SubItems.Add("3")
    '                                            producto.BackColor = Color.Red
    '                                        End If





    '                                    End If

    '                                Else
    '                                    producto.SubItems(8).Text = "//"
    '                                    'producto.SubItems.Add("//")
    '                                    producto.SubItems(11).Text = "3"
    '                                    'producto.SubItems.Add("3")
    '                                End If
    '                                'MessageBox.Show("esta dentro del rango", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                            End If
    '                        End If
    '                        'termina la validacion de que si ya la factura fue conciliada

    '                    Else

    '                    End If
    '                    'termina validacion de check de fecha

    '                Else
    '                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If



    '            Next
    '            pgbProgreso.Value = 0
    '            If rdbrango.Checked = True Then
    '                For Each producto As ListViewItem In lsvLista.CheckedItems
    '                    cadena = ""
    '                    facturas = ""
    '                    contadorlista = contadorlista + 1
    '                    pgbProgreso.Value += 1
    '                    Application.DoEvents()
    '                    'mandar el reporte
    '                    If (tiempo.Days >= 0) Then
    '                        If chkfecha.Checked = True Then
    '                            'vemos solo las facturas que no esten en facturacion

    '                            If producto.SubItems(11).Text = "3" Then
    '                                fecha = CDate(producto.SubItems(3).Text)
    '                                If fecha.Date >= dtpfechainicio.Value.Date And fecha.Date <= dtpfechafin.Value.Date Then
    '                                    If producto.SubItems(5).Text <> "0.00" And (producto.SubItems(6).Text = "" Or producto.SubItems(6).Text = "0.00") Then
    '                                        'Buscamos en gastos
    '                                        ValorRangoMenos = producto.SubItems(5).Text - Double.Parse(Nudrango.Value)
    '                                        ValorRangoMas = producto.SubItems(5).Text + Double.Parse(Nudrango.Value)
    '                                        SQL = "select * from gastos"
    '                                        SQL &= " where total between " & ValorRangoMenos & " And " & ValorRangoMas & " And gastos.iEstatus=1 "
    '                                        SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
    '                                        SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
    '                                        Dim rwGastos As DataRow() = nConsulta(SQL)
    '                                        If rwGastos Is Nothing = False Then
    '                                            If rwGastos.Count = 1 Then
    '                                                'Se encontro una sola cantidad
    '                                                Dim Fila As DataRow = rwGastos(0)
    '                                                producto.SubItems(8).Text = Fila("Factura") & " " & Fila("proveedor")
    '                                                'producto.SubItems.Add(Fila("Factura") & " " & Fila("proveedor"))
    '                                                producto.SubItems(8).Tag = Fila("iIdGasto")
    '                                                producto.SubItems(11).Text = "1"
    '                                                'producto.SubItems.Add("1")
    '                                                producto.BackColor = Color.Green
    '                                            Else
    '                                                'Se encontro mas de una cantidad
    '                                                For x As Integer = 0 To rwGastos.Count - 1
    '                                                    cadena &= rwGastos(x).Item("Factura") & "-" & rwGastos(x).Item("proveedor") & "/"
    '                                                    If x = rwGastos.Count - 1 Then

    '                                                        facturas &= "G" & rwGastos(x).Item("iIdGasto")
    '                                                    Else
    '                                                        facturas &= "G" & rwGastos(x).Item("iIdGasto") & ","
    '                                                    End If
    '                                                Next
    '                                                'producto.Tag = facturas
    '                                                producto.SubItems(11).Tag = facturas
    '                                                producto.SubItems(8).Text = cadena
    '                                                'producto.SubItems.Add(cadena)
    '                                                'producto.SubItems.Add("2")
    '                                                producto.SubItems(11).Text = "2"
    '                                                producto.BackColor = Color.Yellow
    '                                            End If
    '                                        Else

    '                                            'Buscamos a las empresas relacionadas con los cargos
    '                                            If InStr(Trim(producto.SubItems(4).Text).ToUpper, "SUELDO") > 0 Then
    '                                                producto.SubItems(8).Text = "NOMINA"
    '                                                'producto.SubItems.Add("NOMINA")
    '                                                producto.SubItems(11).Text = "1"
    '                                                'producto.SubItems.Add("1")
    '                                                producto.BackColor = Color.Green

    '                                            ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "DISPERSION") > 0 Then
    '                                                producto.SubItems(8).Text = "NOMINA"
    '                                                'producto.SubItems.Add("NOMINA")
    '                                                producto.SubItems(11).Text = "1"
    '                                                'producto.SubItems.Add("1")
    '                                                producto.BackColor = Color.Green

    '                                            ElseIf InStr(Trim(producto.SubItems(4).Text).Replace(",", ""), "AGUINALDO") > 0 Then
    '                                                producto.SubItems(8).Text = "NOMINA"
    '                                                'producto.SubItems.Add("NOMINA")
    '                                                producto.SubItems(11).Text = "1"
    '                                                'producto.SubItems.Add("1")
    '                                                producto.BackColor = Color.Green


    '                                            ElseIf txtidempresa.Text <> "" Then

    '                                                SQL = "Select * from facturas"
    '                                                SQL &= " inner join empresa On fkiIdEmpresa= iIdEmpresa "
    '                                                SQL &= " where total between " & ValorRangoMenos & " And " & ValorRangoMas
    '                                                SQL &= " And cancelada=1 And facturas.iEstatus=1 "
    '                                                SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
    '                                                SQL &= " and fkiIdCliente=" & txtidempresa.Text
    '                                                Dim rwCargos As DataRow() = nConsulta(SQL)

    '                                                If rwCargos Is Nothing = False Then
    '                                                    If rwCargos.Count = 1 Then
    '                                                        'solo hay una cantidad y agregamos el numero de factura y serie al listview
    '                                                        Dim Fila As DataRow = rwCargos(0)

    '                                                        producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
    '                                                        'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
    '                                                        producto.SubItems(8).Tag = Fila("iIdFactura")
    '                                                        producto.SubItems(11).Text = "1"
    '                                                        'producto.SubItems.Add("1")
    '                                                        producto.BackColor = Color.Green
    '                                                    Else
    '                                                        'Hay mas de una cantidad
    '                                                        For x As Integer = 0 To rwCargos.Count - 1
    '                                                            cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
    '                                                            If x = rwCargos.Count - 1 Then

    '                                                                facturas &= "F" & rwCargos(x).Item("iIdFactura")
    '                                                            Else
    '                                                                facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
    '                                                            End If
    '                                                        Next
    '                                                        'producto.Tag = facturas
    '                                                        producto.SubItems(11).Tag = facturas
    '                                                        producto.SubItems(8).Text = cadena
    '                                                        'producto.SubItems.Add(cadena)
    '                                                        producto.SubItems(11).Text = "2"
    '                                                        'producto.SubItems.Add("2")
    '                                                        producto.BackColor = Color.Yellow

    '                                                    End If
    '                                                ElseIf txtcomision.Text <> "" Then
    '                                                    comisiones = txtcomision.Text.Split(",")
    '                                                    bValidar = True
    '                                                    For x As Integer = 0 To comisiones.Length - 1

    '                                                        If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(5).Text).Replace(",", "").Replace("$", "")) Then
    '                                                            producto.SubItems(8).Text = "Comisión"
    '                                                            'producto.SubItems.Add("Comisión")
    '                                                            producto.SubItems(11).Text = "1"
    '                                                            'producto.SubItems.Add("1")
    '                                                            producto.BackColor = Color.Green
    '                                                            x = comisiones.Length
    '                                                            bValidar = False
    '                                                        End If


    '                                                    Next
    '                                                    If bValidar Then
    '                                                        producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                                        'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                                        producto.SubItems(11).Text = "3"
    '                                                        'producto.SubItems.Add("3")
    '                                                        producto.BackColor = Color.Red

    '                                                    End If

    '                                                Else
    '                                                    producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                                    'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                                    producto.SubItems(11).Text = "3"
    '                                                    'producto.SubItems.Add("3")
    '                                                    producto.BackColor = Color.Red
    '                                                End If

    '                                            ElseIf txtcomision.Text <> "" Then
    '                                                comisiones = txtcomision.Text.Split(",")
    '                                                bValidar = True
    '                                                For x As Integer = 0 To comisiones.Length - 1

    '                                                    If Double.Parse(comisiones(x)) = Double.Parse((producto.SubItems(5).Text).Replace(",", "").Replace("$", "")) Then
    '                                                        producto.SubItems(8).Text = "Comisión"
    '                                                        'producto.SubItems.Add("Comisión")
    '                                                        producto.SubItems(11).Text = "1"
    '                                                        'producto.SubItems.Add("1")
    '                                                        producto.BackColor = Color.Green
    '                                                        x = comisiones.Length
    '                                                        bValidar = False
    '                                                    End If


    '                                                Next
    '                                                If bValidar Then
    '                                                    producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                                    'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                                    producto.SubItems(11).Text = "3"
    '                                                    'producto.SubItems.Add("3")
    '                                                    producto.BackColor = Color.Red

    '                                                End If

    '                                            Else
    '                                                producto.SubItems(8).Text = "--"
    '                                                'producto.SubItems.Add("--")
    '                                                producto.SubItems(11).Text = "3"
    '                                                'producto.SubItems.Add("3")
    '                                            End If
    '                                        End If



    '                                    ElseIf (producto.SubItems(5).Text = "" Or producto.SubItems(5).Text = "0.00") And producto.SubItems(6).Text <> "0.00" Then
    '                                        'buscamos la cantidad en empresa




    '                                        'SQL = "select * from (pagos"
    '                                        'SQL &= " inner join facturas on pagos.fkiidFactura=facturas.iIdfactura)"
    '                                        'SQL &= " inner join clientes on fkiIdCliente= iIdCliente "
    '                                        'SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And pagos.importe=" & (producto.SubItems(CInt(NudAbono.Value)).Text).Replace(",", "").Replace("$", "") & " And cancelada=1 And facturas.iEstatus=1 "
    '                                        'SQL &= " And fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"

    '                                        ValorRangoMenos = producto.SubItems(6).Text - Double.Parse(Nudrango.Value)
    '                                        ValorRangoMas = producto.SubItems(6).Text + Double.Parse(Nudrango.Value)

    '                                        SQL = "select * from facturas"
    '                                        SQL &= " inner join clientes on fkiIdCliente= iIdCliente  "
    '                                        SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " And"
    '                                        SQL &= " facturas.total between " & ValorRangoMenos & " And " & ValorRangoMas
    '                                        SQL &= " And cancelada=1 And facturas.iEstatus=1 "
    '                                        SQL &= " And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
    '                                        Dim rwCargos As DataRow() = nConsulta(SQL)

    '                                        If rwCargos Is Nothing = False Then
    '                                            If rwCargos.Count = 1 Then
    '                                                'solo hay una cantidad y agregamos el numero de factura y serie al listview
    '                                                Dim Fila As DataRow = rwCargos(0)
    '                                                producto.SubItems(8).Text = Fila("numfactura") & " " & Fila("nombre")
    '                                                producto.SubItems(8).Tag = Fila("iIdFactura")
    '                                                'producto.SubItems.Add(Fila("numfactura") & " " & Fila("nombre"))
    '                                                producto.SubItems(11).Text = "1"
    '                                                'producto.SubItems.Add("1")
    '                                                producto.BackColor = Color.Green
    '                                            Else
    '                                                'Hay mas de una cantidad

    '                                                For x As Integer = 0 To rwCargos.Count - 1
    '                                                    cadena &= rwCargos(x).Item("numfactura") & "-" & rwCargos(x).Item("nombre") & "/"
    '                                                    If x = rwCargos.Count - 1 Then

    '                                                        facturas &= "F" & rwCargos(x).Item("iIdFactura")
    '                                                    Else
    '                                                        facturas &= "F" & rwCargos(x).Item("iIdFactura") & ","
    '                                                    End If
    '                                                Next
    '                                                'producto.Tag = facturas
    '                                                producto.SubItems(11).Tag = facturas
    '                                                producto.SubItems(8).Text = cadena
    '                                                'producto.SubItems.Add(cadena)
    '                                                producto.SubItems(11).Text = "2"
    '                                                'producto.SubItems.Add("2")
    '                                                producto.BackColor = Color.Yellow
    '                                            End If
    '                                        Else
    '                                            'producto.BackColor = Color.Red
    '                                            producto.SubItems(8).Text = "No existe esta factura en la base de facturación"
    '                                            'producto.SubItems.Add("No existe esta factura en la base de facturación")
    '                                            producto.SubItems(11).Text = "3"
    '                                            'producto.SubItems.Add("3")
    '                                            producto.BackColor = Color.Red
    '                                        End If

    '                                    Else
    '                                        producto.SubItems(8).Text = "//"
    '                                        'producto.SubItems.Add("//")
    '                                        producto.SubItems(11).Text = "3"
    '                                        'producto.SubItems.Add("3")
    '                                    End If
    '                                    'MessageBox.Show("esta dentro del rango", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                                End If
    '                            End If
    '                            'Fin de la factura tiene valor 3

    '                        Else

    '                        End If
    '                        'Fin esta activado el chkfecha
    '                    Else
    '                        MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If



    '                Next
    '            End If

    '            'pgbProgreso.Value = 0
    '            ''preguntamos si quiere que validemos los datos de la no encontradas en sumatorias, solo en abonos

    '            'Dim resultado As Integer = MessageBox.Show("¿Desea que el sistema trate en sumar los montos de los abonos sin factura?", "Pregunta", MessageBoxButtons.YesNo)
    '            'If resultado = DialogResult.Yes Then
    '            '    'Buscamos en pagos
    '            '    For Each producto As ListViewItem In lsvLista.CheckedItems

    '            '    Next
    '            'End If

    '            'select iIdFactura from facturas where iIdFactura NOT IN (select fkiIdFactura as iIdFactura
    '            'from conciliacion  
    '            'where  conciliacion.iEstatus=1 and iEstatus2=2)
    '            'and Facturas.Fecha between '01/12/2017' and '31/12/2017' And facturas.fkiIdEmpresa= 28 and Facturas.cancelada=1


    '            tsbGuardar.Enabled = True
    '            'tsbCancelar_Click(sender, e)
    '            pnlProgreso.Visible = False
    '        Else

    '            MessageBox.Show("Por favor seleccione al menos un registro para hacer la conciliacion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '        pnlCatalogo.Enabled = True
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub lsvLista_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvLista.ItemActivate
        Try
            SQL = "select * from usuarios where idUsuario = " & idUsuario
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas(0).Item("fkIdPerfil") = "4" Or rwFilas(0).Item("fkIdPerfil") = "1" Then
                Dim confimacion As String = MsgBox("¿Esta seguro que desea cambiar el estatus del Fondeo?", vbOKCancel, "CONFIRMACIÓN")
                If confimacion = vbOK Then
                    Dim item As ListViewItem = lsvLista.SelectedItems(0)

                    Dim idFondeoPatrona As String = item.SubItems(0).Text
                    Dim fondeoPatrona As DataRow() = nConsulta("SELECT * FROM FondeoPatrona where iIdFondeoPatrona=" & idFondeoPatrona)

                    If (fondeoPatrona(0).Item("iEstatusFondeo") = 0) Then
                        SQL = " UPDATE FondeoPatrona SET  iEstatusFondeo=1"
                        SQL &= "WHERE iIdFondeoPatrona=" & idFondeoPatrona
                    Else
                        SQL = " UPDATE FondeoPatrona SET  iEstatusFondeo=0"
                        SQL &= "WHERE iIdFondeoPatrona=" & idFondeoPatrona
                    End If
                   

                    If nExecute(SQL) = False Then
                        MessageBox.Show("Hubo un error al eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        'MessageBox.Show("Se actualizo correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tsbBuscar_Click(sender, e)
                    End If

                End If

            Else
                MessageBox.Show("Necesita permisos para poder realizar cambios")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub


    Public Function tipoNomina(ByVal iTipoNomina As Integer) As String

        Dim tn As String

        Select Case iTipoNomina
            Case 0 : tn = "Pendiente"
            Case 1 : tn = "Pagado"
            Case 2 : tn = "Financiado"
        End Select

        Return tn
    End Function
  

   
    Private Sub chkAllEmpresas_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllEmpresas.CheckedChanged
        If chkAllEmpresas.Checked = True Then
            chkfecha.Checked = False
        Else
            chkfecha.Checked = True
        End If
    End Sub
End Class