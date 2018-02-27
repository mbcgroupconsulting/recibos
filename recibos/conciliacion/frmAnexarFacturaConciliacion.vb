Public Class frmAnexarFacturaConciliacion
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gDatosFactura As String
    Public giIdFactura As String
    Public giIdEmpresa As String
    Public gFechaInicial As String
    Public gFechaFinal As String


    Private Sub frmAnexarFacturaConciliacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        blnNuevo = True
        MostrarEmpresa()
        MostrarCliente()
        cboempresa.SelectedIndex = giIdEmpresa
        dtpfechainicio.Value = gFechaInicial
        dtpfechafin.Value = gFechaFinal
    End Sub

    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MostrarCliente()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre "
            nCargaCBO(cboclientes, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdbuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdbuscar.Click
        Try
            Dim contador As Integer
            Dim Alter As Boolean = False


            lsvLista.Items.Clear()
            lsvLista.Clear()

            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            If (rdbfechas.Checked) Then

                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked) Then
                        SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                        SQL &= "fecha,ISNULL(numfactura,0) as numfactura,importe,iva,total,pagoabono,comentario,facturas.cancelada,usuarioc"
                        SQL &= " from (facturas"
                        SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                        SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                        SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                        If chknominas.Checked Then
                            SQL &= " and facturas.tipofactura=0 "
                        End If
                        SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                        Dim rwFilas As DataRow() = nConsulta(SQL)
                        Dim item As ListViewItem
                        lsvLista.Columns.Add("Factura")
                        lsvLista.Columns(0).Width = 70
                        lsvLista.Columns.Add("Fecha")
                        lsvLista.Columns(1).Width = 70
                        lsvLista.Columns.Add("Empresa")
                        lsvLista.Columns(2).Width = 300
                        lsvLista.Columns.Add("Cliente")
                        lsvLista.Columns(2).Width = 300
                        lsvLista.Columns.Add("Importe")
                        lsvLista.Columns(3).Width = 100
                        lsvLista.Columns.Add("Iva")
                        lsvLista.Columns(4).Width = 100
                        lsvLista.Columns.Add("Total")
                        lsvLista.Columns(5).Width = 100
                        lsvLista.Columns.Add("Pago/Abono")
                        lsvLista.Columns(6).Width = 400
                        lsvLista.Columns.Add("Comentario")
                        lsvLista.Columns(7).Width = 400
                        lsvLista.Columns.Add("Estado")
                        lsvLista.Columns(8).Width = 100

                        contador = 0

                        If rwFilas Is Nothing = False Then
                            For Each Fila In rwFilas
                                contador = contador + 1
                                item = lsvLista.Items.Add(Fila.Item("numfactura"))
                                item.SubItems.Add("" & Fila.Item("fecha"))
                                item.SubItems.Add("" & Fila.Item("nombreempresa"))
                                item.SubItems.Add("" & Fila.Item("nombrecliente"))
                                item.SubItems.Add("" & Fila.Item("importe"))
                                item.SubItems.Add("" & Fila.Item("iva"))
                                item.SubItems.Add("" & Fila.Item("total"))
                                item.SubItems.Add("" & Fila.Item("pagoabono"))
                                item.SubItems.Add("" & Fila.Item("comentario"))
                                item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))



                                item.Tag = Fila.Item("iIdFactura")
                                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                                Alter = Not Alter

                            Next
                        Else
                            MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        If lsvLista.Items.Count > 0 Then
                            lsvLista.Focus()
                            lsvLista.Items(0).Selected = True
                            MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Else
                        SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                        SQL &= "fecha,ISNULL(numfactura,0) as numfactura,importe,iva,total,pagoabono,comentario,facturas.cancelada,usuarioc"
                        SQL &= " from (facturas"
                        SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                        SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                        SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                        SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                        If chknominas.Checked Then
                            SQL &= " and facturas.tipofactura=0 "
                        End If
                        SQL &= " order by fecha,iIdFactura asc"



                        Dim rwFilas As DataRow() = nConsulta(SQL)
                        Dim item As ListViewItem

                        lsvLista.Columns.Add("Factura")
                        lsvLista.Columns(0).Width = 70
                        lsvLista.Columns.Add("Fecha")
                        lsvLista.Columns(1).Width = 70
                        lsvLista.Columns.Add("Cliente")
                        lsvLista.Columns(2).Width = 300
                        lsvLista.Columns.Add("Importe")
                        lsvLista.Columns(3).Width = 100
                        lsvLista.Columns.Add("Iva")
                        lsvLista.Columns(4).Width = 100
                        lsvLista.Columns.Add("Total")
                        lsvLista.Columns(5).Width = 100
                        lsvLista.Columns.Add("Pago/Abono")
                        lsvLista.Columns(6).Width = 400
                        lsvLista.Columns.Add("Comentario")
                        lsvLista.Columns(7).Width = 400
                        lsvLista.Columns.Add("Estado")
                        lsvLista.Columns(8).Width = 100



                        contador = 0

                        If rwFilas Is Nothing = False Then
                            For Each Fila In rwFilas
                                contador = contador + 1
                                item = lsvLista.Items.Add(Fila.Item("numfactura"))
                                item.SubItems.Add("" & Fila.Item("fecha"))
                                item.SubItems.Add("" & Fila.Item("nombrecliente"))
                                item.SubItems.Add("" & Fila.Item("importe"))
                                item.SubItems.Add("" & Fila.Item("iva"))
                                item.SubItems.Add("" & Fila.Item("total"))
                                item.SubItems.Add("" & Fila.Item("pagoabono"))
                                item.SubItems.Add("" & Fila.Item("comentario"))
                                item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))



                                item.Tag = Fila.Item("iIdFactura")
                                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                                Alter = Not Alter

                            Next
                        Else
                            MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        If lsvLista.Items.Count > 0 Then
                            lsvLista.Focus()
                            lsvLista.Items(0).Selected = True
                            MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            ElseIf (rdbcliente.Checked) Then
                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked) Then
                        SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                        SQL &= "fecha,ISNULL(numfactura,0) as numfactura,importe,iva,total,pagoabono,comentario,facturas.cancelada,usuarioc"
                        SQL &= " from (facturas"
                        SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                        SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                        SQL &= " where fkiIdcliente =" & cboclientes.SelectedValue & " and facturas.iEstatus=1"

                        If chknominas.Checked Then
                            SQL &= " and facturas.tipofactura=0 "
                        End If
                        SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                        SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                        Dim rwFilas As DataRow() = nConsulta(SQL)
                        Dim item As ListViewItem
                        lsvLista.Columns.Add("Factura")
                        lsvLista.Columns(0).Width = 70
                        lsvLista.Columns.Add("Fecha")
                        lsvLista.Columns(1).Width = 70
                        lsvLista.Columns.Add("Empresa")
                        lsvLista.Columns(2).Width = 300
                        lsvLista.Columns.Add("Cliente")
                        lsvLista.Columns(2).Width = 300
                        lsvLista.Columns.Add("Importe")
                        lsvLista.Columns(3).Width = 100
                        lsvLista.Columns.Add("Iva")
                        lsvLista.Columns(4).Width = 100
                        lsvLista.Columns.Add("Total")
                        lsvLista.Columns(5).Width = 100
                        lsvLista.Columns.Add("Pago/Abono")
                        lsvLista.Columns(6).Width = 400
                        lsvLista.Columns.Add("Comentario")
                        lsvLista.Columns(7).Width = 400
                        lsvLista.Columns.Add("Estado")
                        lsvLista.Columns(8).Width = 100

                        contador = 0

                        If rwFilas Is Nothing = False Then
                            For Each Fila In rwFilas
                                contador = contador + 1
                                item = lsvLista.Items.Add(Fila.Item("numfactura"))
                                item.SubItems.Add("" & Fila.Item("fecha"))
                                item.SubItems.Add("" & Fila.Item("nombreempresa"))
                                item.SubItems.Add("" & Fila.Item("nombrecliente"))
                                item.SubItems.Add("" & Fila.Item("importe"))
                                item.SubItems.Add("" & Fila.Item("iva"))
                                item.SubItems.Add("" & Fila.Item("total"))
                                item.SubItems.Add("" & Fila.Item("pagoabono"))
                                item.SubItems.Add("" & Fila.Item("comentario"))
                                item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))



                                item.Tag = Fila.Item("iIdFactura")
                                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                                Alter = Not Alter

                            Next
                        Else
                            MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        If lsvLista.Items.Count > 0 Then
                            lsvLista.Focus()
                            lsvLista.Items(0).Selected = True
                            MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'fin chktodas
                    Else
                        SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                        SQL &= "fecha,ISNULL(numfactura,0) as numfactura,importe,iva,total,pagoabono,comentario,facturas.cancelada,usuarioc"
                        SQL &= " from (facturas"
                        SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                        SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                        SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                        SQL &= " and fkiIdcliente=" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                        If chknominas.Checked Then
                            SQL &= " and facturas.tipofactura=0 "
                        End If
                        SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                        SQL &= " order by fecha,iIdFactura asc"



                        Dim rwFilas As DataRow() = nConsulta(SQL)
                        Dim item As ListViewItem

                        lsvLista.Columns.Add("Factura")
                        lsvLista.Columns(0).Width = 70
                        lsvLista.Columns.Add("Fecha")
                        lsvLista.Columns(1).Width = 70
                        lsvLista.Columns.Add("Cliente")
                        lsvLista.Columns(2).Width = 300
                        lsvLista.Columns.Add("Importe")
                        lsvLista.Columns(3).Width = 100
                        lsvLista.Columns.Add("Iva")
                        lsvLista.Columns(4).Width = 100
                        lsvLista.Columns.Add("Total")
                        lsvLista.Columns(5).Width = 100
                        lsvLista.Columns.Add("Pago/Abono")
                        lsvLista.Columns(6).Width = 400
                        lsvLista.Columns.Add("Comentario")
                        lsvLista.Columns(7).Width = 400
                        lsvLista.Columns.Add("Estado")
                        lsvLista.Columns(8).Width = 100



                        contador = 0

                        If rwFilas Is Nothing = False Then
                            For Each Fila In rwFilas
                                contador = contador + 1
                                item = lsvLista.Items.Add(Fila.Item("numfactura"))
                                item.SubItems.Add("" & Fila.Item("fecha"))
                                item.SubItems.Add("" & Fila.Item("nombrecliente"))
                                item.SubItems.Add("" & Fila.Item("importe"))
                                item.SubItems.Add("" & Fila.Item("iva"))
                                item.SubItems.Add("" & Fila.Item("total"))
                                item.SubItems.Add("" & Fila.Item("pagoabono"))
                                item.SubItems.Add("" & Fila.Item("comentario"))
                                item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))



                                item.Tag = Fila.Item("iIdFactura")
                                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                                Alter = Not Alter

                            Next
                        Else
                            MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        If lsvLista.Items.Count > 0 Then
                            lsvLista.Focus()
                            lsvLista.Items(0).Selected = True
                            MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                    'ElseIf (rdbpendientes.Checked) Then
                    '    SQL = "select empresa.nombre as nombreempresa,numfactura,iIdFactura"
                    '    SQL &= " from (facturas"
                    '    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    '    SQL &= " where numfactura=null or numfactura=0"
                    '    SQL &= " order by nombre asc"



                    '    Dim rwFilas As DataRow() = nConsulta(SQL)
                    '    Dim item As ListViewItem

                    '    lsvLista.Columns.Add("Factura")
                    '    lsvLista.Columns(0).Width = 70
                    '    lsvLista.Columns.Add("Fecha")
                    '    lsvLista.Columns(1).Width = 70
                    '    lsvLista.Columns.Add("Empresa")
                    '    lsvLista.Columns(2).Width = 300
                    '    lsvLista.Columns.Add("Cliente")
                    '    lsvLista.Columns(2).Width = 300


                    '    contador = 0

                    '    If rwFilas Is Nothing = False Then
                    '        For Each Fila In rwFilas
                    '            contador = contador + 1
                    '            item = lsvLista.Items.Add(Fila.Item("numfactura"))
                    '            item.SubItems.Add("" & Fila.Item("nombreempresa"))




                    '            item.Tag = Fila.Item("iIdFactura")
                    '            item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    '            Alter = Not Alter

                    '        Next
                    '    Else
                    '        MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    End If
                    '    If lsvLista.Items.Count > 0 Then
                    '        lsvLista.Focus()
                    '        lsvLista.Items(0).Selected = True
                    '        MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf (rdbbuscar.Checked) Then
                If (chktodas.Checked) Then
                    SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                    SQL &= " fecha,numfactura,importe,iva,total,pagoabono,comentario,facturas.cancelada,usuarioc"
                    SQL &= " from (facturas"
                    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                    SQL &= " where (numfactura<>null or numfactura<>0)"
                    SQL &= " and numfactura=" & IIf(txtbuscar.Text = "", 0, txtbuscar.Text) & " and facturas.iEstatus=1"
                    If chknominas.Checked Then
                        SQL &= " and facturas.tipofactura=0 "
                    End If
                    SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                    Dim rwFilas As DataRow() = nConsulta(SQL)
                    Dim item As ListViewItem
                    lsvLista.Columns.Add("Factura")
                    lsvLista.Columns(0).Width = 70
                    lsvLista.Columns.Add("Fecha")
                    lsvLista.Columns(1).Width = 70
                    lsvLista.Columns.Add("Empresa")
                    lsvLista.Columns(2).Width = 300
                    lsvLista.Columns.Add("Cliente")
                    lsvLista.Columns(2).Width = 300
                    lsvLista.Columns.Add("Importe")
                    lsvLista.Columns(3).Width = 100
                    lsvLista.Columns.Add("Iva")
                    lsvLista.Columns(4).Width = 100
                    lsvLista.Columns.Add("Total")
                    lsvLista.Columns(5).Width = 100
                    lsvLista.Columns.Add("Pago/Abono")
                    lsvLista.Columns(6).Width = 400
                    lsvLista.Columns.Add("Comentario")
                    lsvLista.Columns(7).Width = 400
                    lsvLista.Columns.Add("Estado")
                    lsvLista.Columns(8).Width = 100

                    contador = 0

                    If rwFilas Is Nothing = False Then
                        For Each Fila In rwFilas
                            contador = contador + 1
                            item = lsvLista.Items.Add(Fila.Item("numfactura"))
                            item.SubItems.Add("" & Fila.Item("fecha"))
                            item.SubItems.Add("" & Fila.Item("nombreempresa"))
                            item.SubItems.Add("" & Fila.Item("nombrecliente"))
                            item.SubItems.Add("" & Fila.Item("importe"))
                            item.SubItems.Add("" & Fila.Item("iva"))
                            item.SubItems.Add("" & Fila.Item("total"))
                            item.SubItems.Add("" & Fila.Item("pagoabono"))
                            item.SubItems.Add("" & Fila.Item("comentario"))
                            item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))



                            item.Tag = Fila.Item("iIdFactura")
                            item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                            Alter = Not Alter

                        Next
                    Else
                        MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    If lsvLista.Items.Count > 0 Then
                        lsvLista.Focus()
                        lsvLista.Items(0).Selected = True
                        MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    'fin chktodas
                Else
                    SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                    SQL &= "fecha,numfactura,importe,iva,total,pagoabono,comentario,facturas.cancelada,usuarioc"
                    SQL &= " from (facturas"
                    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                    SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " and (numfactura<>null or numfactura<>0)"
                    SQL &= " and numfactura=" & IIf(txtbuscar.Text = "", 0, txtbuscar.Text) & " and facturas.iEstatus=1"
                    If chknominas.Checked Then
                        SQL &= " and facturas.tipofactura=0 "
                    End If
                    SQL &= " order by fecha,iIdFactura asc"



                    Dim rwFilas As DataRow() = nConsulta(SQL)
                    Dim item As ListViewItem

                    lsvLista.Columns.Add("Factura")
                    lsvLista.Columns(0).Width = 70
                    lsvLista.Columns.Add("Fecha")
                    lsvLista.Columns(1).Width = 70
                    lsvLista.Columns.Add("Cliente")
                    lsvLista.Columns(2).Width = 300
                    lsvLista.Columns.Add("Importe")
                    lsvLista.Columns(3).Width = 100
                    lsvLista.Columns.Add("Iva")
                    lsvLista.Columns(4).Width = 100
                    lsvLista.Columns.Add("Total")
                    lsvLista.Columns(5).Width = 100
                    lsvLista.Columns.Add("Pago/Abono")
                    lsvLista.Columns(6).Width = 400
                    lsvLista.Columns.Add("Comentario")
                    lsvLista.Columns(7).Width = 400
                    lsvLista.Columns.Add("Estado")
                    lsvLista.Columns(8).Width = 100



                    contador = 0

                    If rwFilas Is Nothing = False Then
                        For Each Fila In rwFilas
                            contador = contador + 1
                            item = lsvLista.Items.Add(Fila.Item("numfactura"))
                            item.SubItems.Add("" & Fila.Item("fecha"))
                            item.SubItems.Add("" & Fila.Item("nombrecliente"))
                            item.SubItems.Add("" & Fila.Item("importe"))
                            item.SubItems.Add("" & Fila.Item("iva"))
                            item.SubItems.Add("" & Fila.Item("total"))
                            item.SubItems.Add("" & Fila.Item("pagoabono"))
                            item.SubItems.Add("" & Fila.Item("comentario"))
                            item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))



                            item.Tag = Fila.Item("iIdFactura")
                            item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                            Alter = Not Alter

                        Next
                    Else
                        MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    If lsvLista.Items.Count > 0 Then
                        lsvLista.Focus()
                        lsvLista.Items(0).Selected = True
                        MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdagregar_Click(sender As System.Object, e As System.EventArgs) Handles cmdagregar.Click
        Try
            gDatosFactura = ""
            giIdFactura = ""
            Dim inicio As Boolean = True
            If lsvLista.CheckedItems.Count > 0 Then
                For Each producto As ListViewItem In lsvLista.CheckedItems
                    If inicio Then
                        gDatosFactura = producto.SubItems(0).Text & " " & producto.SubItems(2).Text
                        giIdFactura = producto.Tag
                        inicio = False
                    Else
                        gDatosFactura &= ", " & producto.SubItems(0).Text & " " & producto.SubItems(2).Text
                        giIdFactura &= "," & producto.Tag
                    End If
                Next
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Por favor seleccione al menos una factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class