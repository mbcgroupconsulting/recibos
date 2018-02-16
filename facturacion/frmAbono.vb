Public Class frmAbono
    Public gIdFactura
    Public gIdPago
    Dim blnNuevo As Boolean
    Dim abonos As Double
    Dim numpagos As Integer
    Private Sub frmAbono_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gIdFactura = "" Then
            blnNuevo = True
            listasinfactura()
            lblnumfactura.Text = "Sin numero de factura"
            lbltotal.Text = ""
            lblabono.Text = ""
            lblfaltante.Text = ""

        Else
            grbfechas.Enabled = False

            blnNuevo = True
            cargarlista()
            cargardatos()
        End If


    End Sub
    Private Sub listasinfactura()
        Dim sql As String
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value

        sql = "select pagos.iIdPago,pagos.fechaingreso,pagos.Importe,pagos.observaciones, pagos.usuario from facturas inner join pagos on facturas.iIdFactura= pagos.fkiIdFactura"
        sql &= "  where fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString & "' and fkiIdFactura=0"
        '01/" & Date.Now.Month & "/" & Date.Now.Year & "' and '" & DateSerial(Date.Now.Year, Date.Now.Month + 1, 0) & "/" & Date.Now.Month & "/" & Date.Now.Year & "'"




        Dim rwFilas As DataRow() = nConsulta(sql)
        lsvLista.Items.Clear()
        lsvLista.Clear()
        lsvLista.Columns.Add("Fecha")
        lsvLista.Columns(0).Width = 170
        lsvLista.Columns.Add("Importe")
        lsvLista.Columns(1).Width = 170
        lsvLista.Columns(1).TextAlign = 1
        lsvLista.Columns.Add("Observaciones")
        lsvLista.Columns(2).Width = 300
        lsvLista.Columns.Add("Usuario")
        lsvLista.Columns(3).Width = 120

        If rwFilas Is Nothing = False Then
            Dim Alter As Boolean = False
            Dim item As ListViewItem

            'Cargamos la lista de abonos
            abonos = 0

            For x As Integer = 0 To rwFilas.Length - 1
                Dim Fila As DataRow = rwFilas(x)
                item = lsvLista.Items.Add(Fila.Item("fechaingreso"))
                item.SubItems.Add(Fila.Item("importe"))
                item.SubItems.Add(Fila.Item("observaciones"))
                item.SubItems.Add(Fila.Item("usuario"))
                abonos = abonos + Fila.Item("importe")
                'totalfactura = totalfactura + txttotal.Text
                'txttotalf.Text = (Double.Parse(Fila.Item("total")) + Double.Parse(txttotalf.Text)).ToString()

                item.Tag = Fila.Item("iIdPago")

                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter

            Next

            MessageBox.Show(rwFilas.Length & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("No se encontraron registros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Private Sub cargarlista()
        Dim sql As String

        sql = "Select facturas.iIdFactura,pagos.iIdPago,pagos.fechaingreso,pagos.Importe,pagos.observaciones, pagos.usuario from facturas inner join pagos On facturas.iIdFactura= pagos.fkiIdFactura"
        sql &= "  where pagos.iEstatus=1 and Facturas.iIdFactura=" & gIdFactura




        Dim rwFilas As DataRow() = nConsulta(sql)
        lsvLista.Items.Clear()
        lsvLista.Clear()
        lsvLista.Columns.Add("Fecha")
        lsvLista.Columns(0).Width = 170
        lsvLista.Columns.Add("Importe")
        lsvLista.Columns(1).Width = 170
        lsvLista.Columns(1).TextAlign = 1
        lsvLista.Columns.Add("Observaciones")
        lsvLista.Columns(2).Width = 300
        lsvLista.Columns.Add("Usuario")
        lsvLista.Columns(3).Width = 120
        numpagos = 0
        If rwFilas Is Nothing = False Then
            Dim Alter As Boolean = False
            Dim item As ListViewItem

            'Cargamos la lista de abonos
            abonos = 0
            numpagos = rwFilas.Length
            For x As Integer = 0 To rwFilas.Length - 1
                Dim Fila As DataRow = rwFilas(x)
                item = lsvLista.Items.Add(Fila.Item("fechaingreso"))
                item.SubItems.Add(Fila.Item("importe"))
                item.SubItems.Add(Fila.Item("observaciones"))
                item.SubItems.Add(Fila.Item("usuario"))
                abonos = abonos + Fila.Item("importe")
                'totalfactura = totalfactura + txttotal.Text
                'txttotalf.Text = (Double.Parse(Fila.Item("total")) + Double.Parse(txttotalf.Text)).ToString()

                item.Tag = Fila.Item("iIdPago")

                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter

            Next

            MessageBox.Show(rwFilas.Length & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("No se encontraron registros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Private Sub cargardatos()
        Dim sql As String
        sql = "Select empresa.nombre As empresa,clientes.nombre As cliente,numfactura,importe,iva,total,fkiIdEmpresa,fkiIdCliente,fecha "
        Sql &= "  from (facturas"
        Sql &= " inner join empresa On fkiIdEmpresa= iIdEmpresa)"
        Sql &= " inner join clientes On fkiIdCliente= iIdCliente"
        sql &= " where iIdFactura = " & gIdFactura

        Dim rwFilas As DataRow() = nConsulta(Sql)

        If rwFilas Is Nothing = False Then

            Dim Fila As DataRow = rwFilas(0)
            lblnumfactura.Text = Fila.Item("numfactura")
            lbltotal.Text = Fila.Item("total")
            lbltotal.Text = Format(CType(IIf(lbltotal.Text = "", "0", lbltotal.Text), Decimal), "###,###,##0.#0")
            lblabono.Text = abonos.ToString()
            lblabono.Text = Format(CType(IIf(lblabono.Text = "", "0", lblabono.Text), Decimal), "###,###,##0.#0")

            lblfaltante.Text = Double.Parse(Fila.Item("total")) - abonos

            lblfaltante.Text = Format(CType(IIf(lblfaltante.Text = "", "0", lblfaltante.Text), Decimal), "###,###,##0.#0")

            If (Double.Parse(Fila.Item("total")) - abonos) <= 0 Then
                sql = "update facturas set  color=2 where iIdFactura=" & gIdFactura
                If nExecute(sql) = False Then
                    Exit Sub
                End If

            End If

        End If
    End Sub

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Try

            'Validar
            If gIdFactura <> "" Then
                'If Double.Parse((IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")) > Double.Parse((IIf(lblfaltante.Text = "", 0, lblfaltante.Text)).ToString.Replace(",", "")) Then

                '    MessageBox.Show("El importe no puede ser mayor a la cantidad que falta por abonar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
                'End If

                If txtimporte.Text.Trim.Length = 0 And Mensaje = "" Then
                    Mensaje = "Por favor indique el importe"
                End If

            End If



            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombresistema = Fila.Item("nombre")
            End If


            If blnNuevo Then

                If gIdFactura = "" Then
                    'Insertar nuevo sin idfactura
                    SQL = "EXEC setpagosInsertar  0,0"
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                    SQL &= ",'" & nombresistema
                    SQL &= "','" & txtcomentario.Text
                    SQL &= "','" & Date.Now.ToShortDateString()
                    SQL &= "',1"
                Else
                    'Insertar nuevo con idfactura
                    SQL = "EXEC setpagosInsertar  0," & gIdFactura
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                    SQL &= ",'" & nombresistema
                    SQL &= "','" & txtcomentario.Text
                    SQL &= "','" & Date.Now.ToShortDateString()
                    SQL &= "',1"
                End If



            Else
                If gIdFactura = "" Then
                    'Actualizar sin idfactura
                    SQL = "EXEC setpagosActualizar " & gIdPago & ",0"
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                    SQL &= ",'" & nombresistema
                    SQL &= "','" & txtcomentario.Text
                    SQL &= "','" & Date.Now.ToShortDateString()
                    SQL &= "',1"
                Else
                    'Actualizar con idfactura
                    SQL = "EXEC setpagosActualizar " & gIdPago & "," & gIdFactura
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                    SQL &= ",'" & nombresistema
                    SQL &= "','" & txtcomentario.Text
                    SQL &= "','" & Date.Now.ToShortDateString()
                    SQL &= "',1"

                End If



            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If

            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Limpiar()


            If gIdFactura = "" Then
                blnNuevo = True
                listasinfactura()
                lblnumfactura.Text = "Sin numero de factura"
                lbltotal.Text = ""
                lblabono.Text = ""
                lblfaltante.Text = ""
            Else
                cargarlista()
                cargardatos()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub limpiar()
        dtpfecha.Value = Date.Now.ToShortDateString()
        txtimporte.Text = "0"
        txtcomentario.Text = ""
        blnNuevo = True
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        If lsvLista.SelectedItems.Count > 0 Then
            editar(lsvLista.SelectedItems(0).Tag)
        End If


    End Sub

    Private Sub editar(id As String)
        Dim sql As String 
        limpiar()
        Sql = "select * from pagos where iIdPago = " & id
        Dim rwFilas As DataRow() = nConsulta(Sql)
        Try
            If rwFilas Is Nothing = False Then
                blnNuevo = False
                Dim Fila As DataRow = rwFilas(0)


                dtpfecha.Value = Fila.Item("fechaingreso")
                txtimporte.Text = Fila.Item("importe")
                txtcomentario.Text = Fila.Item("observaciones")

                gIdPago = id


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtimporte_TextChanged(sender As Object, e As EventArgs) Handles txtimporte.TextChanged

    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtimporte_LostFocus(sender As Object, e As EventArgs) Handles txtimporte.LostFocus
        txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "0", txtimporte.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        limpiar()
    End Sub

    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Dim bandera As Boolean
        Dim sql
        Dim color As Integer
        Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
        Try
            If datos.Count = 1 Then

                Dim resultado As Integer = MessageBox.Show("¿Desea borrar el abono con importe: " & datos(0).SubItems(1).Text & " y fecha de captura de: " & datos(0).SubItems(0).Text & "? (Este proceso no es reversible)", "Pregunta", MessageBoxButtons.YesNo)


                If resultado = DialogResult.Yes Then
                    'MessageBox.Show(datos(0).Tag, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    color = 0
                    bandera = False
                    sql = "select * from facturas where iIdFactura = " & gIdFactura
                    Dim rwFilas As DataRow() = nConsulta(sql)

                    If rwFilas Is Nothing = False Then
                        color = rwFilas(0).Item("color")


                    End If
                    If color = 0 Then
                        bandera = True
                    ElseIf color = 1 Then
                        bandera = True
                    ElseIf color = 2 Then
                        bandera = True
                        'MessageBox.Show("La factura y a sido conciliada con el color verde, por lo cual no es posible borrar abonos, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf color = 3 Then
                        MessageBox.Show("La factura y a sido conciliada con el color rojo, por lo cual no es posible borrar abonos, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf color = 4 Then
                        MessageBox.Show("La factura y a sido conciliada con el color fiusha, por lo cual no es posible borrar abonos, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf color = 5 Then

                    ElseIf color = 6 Then
                        If numpagos > 1 Then
                            bandera = True
                        Else
                            MessageBox.Show("La factura y a sido conciliada con el color naranja, por lo cual no es posible borrar abonos, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                    If bandera Then
                        sql = "update pagos set iEstatus=0 where iIdPago=" & datos(0).Tag
                        If nExecute(sql) = False Then

                            MessageBox.Show("Ocurrio un error," & sql, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        blnNuevo = True
                        cargarlista()
                        cargardatos()
                        MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If



                    'lsvLista.SelectedItems(0).Remove()

                End If
            Else
                MessageBox.Show("No hay datos seleccionados para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtpfechainicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechainicio.ValueChanged

    End Sub
End Class