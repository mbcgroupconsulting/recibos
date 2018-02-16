Imports ClosedXML.Excel

Public Class frmverfacturascontrol
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gIdFactura As String

    Private Sub frmverfacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blnNuevo = True
        MostrarEmpresa()
        MostrarCliente()
        MostrarPlaza()

        cbocolor.SelectedIndex = 1

    End Sub
    Private Sub MostrarPlaza()
        SQL = "Select * from CatPlaza"
        nCargaCBO(cboplaza, SQL, "nombre", "iIdPlaza")
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

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim contador As Integer
        Dim Alter As Boolean = False


        lsvLista.Items.Clear()
        lsvLista.Clear()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim tipo As Boolean
        tipo = False
        If (rdbfechas.Checked) Then

            If (tiempo.Days >= 0) Then
                If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then



                    SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                    SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                    SQL &= " from (facturas"
                    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                    SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"

                    If chkintermediarias.Checked Then
                        SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                        tipo = True
                    End If
                    If chkotras.Checked Then
                        If tipo Then
                            SQL &= " or empresa.fkiIdTipoEmpresa=3"
                        Else
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                            tipo = True
                        End If

                    End If
                    If chkpatronas.Checked Then
                        If tipo Then
                            SQL &= " or empresa.fkiIdTipoEmpresa=1"
                        Else
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                            tipo = True
                        End If

                    End If

                    If tipo Then
                        SQL &= " )"

                    End If

                    SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                    Dim rwFilas As DataRow() = nConsulta(SQL)
                    Dim item As ListViewItem
                    lsvLista.Columns.Add("Edo Pago")
                    lsvLista.Columns(0).Width = 70
                    lsvLista.Columns.Add("Tipo Fac")
                    lsvLista.Columns(1).Width = 70
                    lsvLista.Columns.Add("Serie F")
                    lsvLista.Columns(2).Width = 60
                    lsvLista.Columns.Add("Factura")
                    lsvLista.Columns(3).Width = 70
                    lsvLista.Columns(3).TextAlign = 1
                    lsvLista.Columns.Add("Fecha")
                    lsvLista.Columns(4).Width = 90
                    lsvLista.Columns.Add("Empresa")
                    lsvLista.Columns(5).Width = 300
                    lsvLista.Columns.Add("Cliente")
                    lsvLista.Columns(6).Width = 300
                    lsvLista.Columns.Add("Importe")
                    lsvLista.Columns(7).Width = 100
                    lsvLista.Columns(7).TextAlign = 1
                    lsvLista.Columns.Add("Iva")
                    lsvLista.Columns(8).Width = 100
                    lsvLista.Columns(8).TextAlign = 1
                    lsvLista.Columns.Add("Retención ISN")
                    lsvLista.Columns(9).Width = 100
                    lsvLista.Columns(9).TextAlign = 1
                    lsvLista.Columns.Add("Total")
                    lsvLista.Columns(10).Width = 100
                    lsvLista.Columns(10).TextAlign = 1
                    lsvLista.Columns.Add("Serie N")
                    lsvLista.Columns(11).Width = 70
                    lsvLista.Columns.Add("Nota")
                    lsvLista.Columns(12).Width = 70
                    lsvLista.Columns(12).TextAlign = 1
                    lsvLista.Columns.Add("Pago/Abono")
                    lsvLista.Columns(13).Width = 400
                    lsvLista.Columns.Add("Periodo")
                    lsvLista.Columns(14).Width = 400
                    lsvLista.Columns.Add("Comentario")
                    lsvLista.Columns(15).Width = 400
                    lsvLista.Columns.Add("Estado")
                    lsvLista.Columns(16).Width = 100
                    lsvLista.Columns.Add("Elaborado")
                    lsvLista.Columns(17).Width = 100
                    lsvLista.Columns.Add("Modificado")
                    lsvLista.Columns(18).Width = 100

                    contador = 0

                    If rwFilas Is Nothing = False Then
                        For Each Fila In rwFilas
                            contador = contador + 1
                            item = lsvLista.Items.Add("")
                            item.UseItemStyleForSubItems = False
                            If Fila.Item("color") = "0" Then
                                item.SubItems.Item(0).BackColor = Color.White

                            ElseIf Fila.Item("color") = "1" Then
                                item.SubItems.Item(0).BackColor = Color.Yellow
                            ElseIf Fila.Item("color") = "2" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                            ElseIf Fila.Item("color") = "3" Then
                                item.SubItems.Item(0).BackColor = Color.Red
                            ElseIf Fila.Item("color") = "4" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                            ElseIf Fila.Item("color") = "5" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                            End If

                            item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                            If (Fila.Item("serief") = "0") Then
                                item.SubItems.Add("" & "A")
                            ElseIf Fila.Item("serief") = "1" Then
                                item.SubItems.Add("" & "B")
                            ElseIf Fila.Item("serief") = "2" Then
                                item.SubItems.Add("" & "C")
                            ElseIf Fila.Item("serief") = "3" Then
                                item.SubItems.Add("" & "D")
                            End If



                            item.SubItems.Add("" & Fila.Item("numfactura"))
                            item.SubItems.Add("" & Fila.Item("fecha"))
                            item.SubItems.Add("" & Fila.Item("nombreempresa"))
                            item.SubItems.Add("" & Fila.Item("nombrecliente"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                            item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Fila.Item("serien"))
                            item.SubItems.Add("" & Fila.Item("numnota"))
                            item.SubItems.Add("" & Fila.Item("pagoabono"))
                            item.SubItems.Add("" & Fila.Item("comentario"))
                            item.SubItems.Add("" & Fila.Item("comentario2"))
                            item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                            'If (Fila.Item("cancelada") = "0") Then
                            '    item.SubItems.Item(0).BackColor = Color.Red
                            'End If
                            item.SubItems.Add("" & Fila.Item("usuarioc"))
                            item.SubItems.Add("" & Fila.Item("usuariom"))


                            item.Tag = Fila.Item("iIdFactura")
                            'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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
                    SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                    SQL &= " from (facturas"
                    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                    SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                    SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                    SQL &= " order by fecha,iIdFactura asc"



                    Dim rwFilas As DataRow() = nConsulta(SQL)
                    Dim item As ListViewItem

                    lsvLista.Columns.Add("Edo Pago")
                    lsvLista.Columns(0).Width = 70
                    lsvLista.Columns.Add("Tipo Fac")
                    lsvLista.Columns(1).Width = 70
                    lsvLista.Columns.Add("Serie F")
                    lsvLista.Columns(2).Width = 60
                    lsvLista.Columns.Add("Factura")
                    lsvLista.Columns(3).Width = 70
                    lsvLista.Columns(3).TextAlign = 1
                    lsvLista.Columns.Add("Fecha")
                    lsvLista.Columns(4).Width = 90
                    lsvLista.Columns.Add("Empresa")
                    lsvLista.Columns(5).Width = 300
                    lsvLista.Columns.Add("Cliente")
                    lsvLista.Columns(6).Width = 300
                    lsvLista.Columns.Add("Importe")
                    lsvLista.Columns(7).Width = 100
                    lsvLista.Columns(7).TextAlign = 1
                    lsvLista.Columns.Add("Iva")
                    lsvLista.Columns(8).Width = 100
                    lsvLista.Columns(8).TextAlign = 1
                    lsvLista.Columns.Add("Retención ISN")
                    lsvLista.Columns(9).Width = 100
                    lsvLista.Columns(9).TextAlign = 1
                    lsvLista.Columns.Add("Total")
                    lsvLista.Columns(10).Width = 100
                    lsvLista.Columns(10).TextAlign = 1
                    lsvLista.Columns.Add("Serie N")
                    lsvLista.Columns(11).Width = 70
                    lsvLista.Columns.Add("Nota")
                    lsvLista.Columns(12).Width = 70
                    lsvLista.Columns(12).TextAlign = 1
                    lsvLista.Columns.Add("Pago/Abono")
                    lsvLista.Columns(13).Width = 400
                    lsvLista.Columns.Add("Periodo")
                    lsvLista.Columns(14).Width = 400
                    lsvLista.Columns.Add("Comentario")
                    lsvLista.Columns(15).Width = 400
                    lsvLista.Columns.Add("Estado")
                    lsvLista.Columns(16).Width = 100
                    lsvLista.Columns.Add("Elaborado")
                    lsvLista.Columns(17).Width = 100
                    lsvLista.Columns.Add("Modificado")
                    lsvLista.Columns(18).Width = 100





                    contador = 0

                    If rwFilas Is Nothing = False Then
                        For Each Fila In rwFilas
                            contador = contador + 1
                            item = lsvLista.Items.Add("")
                            item.UseItemStyleForSubItems = False
                            If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                                If Fila.Item("color") = "0" Then
                                    item.SubItems.Item(0).BackColor = Color.White

                                ElseIf Fila.Item("color") = "1" Then
                                    item.SubItems.Item(0).BackColor = Color.Yellow
                                ElseIf Fila.Item("color") = "2" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                                ElseIf Fila.Item("color") = "3" Then
                                    item.SubItems.Item(0).BackColor = Color.Red
                                ElseIf Fila.Item("color") = "4" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                                ElseIf Fila.Item("color") = "5" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                                End If
                            End If

                            item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                            If (Fila.Item("serief") = "0") Then
                                item.SubItems.Add("" & "A")
                            ElseIf Fila.Item("serief") = "1" Then
                                item.SubItems.Add("" & "B")
                            ElseIf Fila.Item("serief") = "2" Then
                                item.SubItems.Add("" & "C")
                            ElseIf Fila.Item("serief") = "3" Then
                                item.SubItems.Add("" & "D")
                            End If
                            item.SubItems.Add("" & Fila.Item("numfactura"))
                            item.SubItems.Add("" & Fila.Item("fecha"))
                            item.SubItems.Add("" & Fila.Item("nombreempresa"))
                            item.SubItems.Add("" & Fila.Item("nombrecliente"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                            item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Fila.Item("serien"))
                            item.SubItems.Add("" & Fila.Item("numnota"))
                            item.SubItems.Add("" & Fila.Item("pagoabono"))
                            item.SubItems.Add("" & Fila.Item("comentario"))
                            item.SubItems.Add("" & Fila.Item("comentario2"))
                            item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                            'If (Fila.Item("cancelada") = "0") Then
                            '    item.SubItems.Item(0).BackColor = Color.Red
                            'End If
                            item.SubItems.Add("" & Fila.Item("usuarioc"))
                            item.SubItems.Add("" & Fila.Item("usuariom"))

                            item.Tag = Fila.Item("iIdFactura")
                            'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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
                If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then
                    SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                    SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                    SQL &= " from (facturas"
                    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                    SQL &= " where fkiIdcliente =" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                    SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"

                    If chkintermediarias.Checked Then
                        SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                        tipo = True
                    End If
                    If chkotras.Checked Then
                        If tipo Then
                            SQL &= " or empresa.fkiIdTipoEmpresa=3"
                        Else
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                            tipo = True
                        End If

                    End If
                    If chkpatronas.Checked Then
                        If tipo Then
                            SQL &= " or empresa.fkiIdTipoEmpresa=1"
                        Else
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                            tipo = True
                        End If

                    End If

                    If tipo Then
                        SQL &= " )"

                    End If

                    SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                    Dim rwFilas As DataRow() = nConsulta(SQL)
                    Dim item As ListViewItem
                    lsvLista.Columns.Add("Edo Pago")
                    lsvLista.Columns(0).Width = 70
                    lsvLista.Columns.Add("Tipo Fac")
                    lsvLista.Columns(1).Width = 70
                    lsvLista.Columns.Add("Serie F")
                    lsvLista.Columns(2).Width = 60
                    lsvLista.Columns.Add("Factura")
                    lsvLista.Columns(3).Width = 70
                    lsvLista.Columns(3).TextAlign = 1
                    lsvLista.Columns.Add("Fecha")
                    lsvLista.Columns(4).Width = 90
                    lsvLista.Columns.Add("Empresa")
                    lsvLista.Columns(5).Width = 300
                    lsvLista.Columns.Add("Cliente")
                    lsvLista.Columns(6).Width = 300
                    lsvLista.Columns.Add("Importe")
                    lsvLista.Columns(7).Width = 100
                    lsvLista.Columns(7).TextAlign = 1
                    lsvLista.Columns.Add("Iva")
                    lsvLista.Columns(8).Width = 100
                    lsvLista.Columns(8).TextAlign = 1
                    lsvLista.Columns.Add("Retención ISN")
                    lsvLista.Columns(9).Width = 100
                    lsvLista.Columns(9).TextAlign = 1
                    lsvLista.Columns.Add("Total")
                    lsvLista.Columns(10).Width = 100
                    lsvLista.Columns(10).TextAlign = 1
                    lsvLista.Columns.Add("Serie N")
                    lsvLista.Columns(11).Width = 70
                    lsvLista.Columns.Add("Nota")
                    lsvLista.Columns(12).Width = 70
                    lsvLista.Columns(12).TextAlign = 1
                    lsvLista.Columns.Add("Pago/Abono")
                    lsvLista.Columns(13).Width = 400
                    lsvLista.Columns.Add("Periodo")
                    lsvLista.Columns(14).Width = 400
                    lsvLista.Columns.Add("Comentario")
                    lsvLista.Columns(15).Width = 400
                    lsvLista.Columns.Add("Estado")
                    lsvLista.Columns(16).Width = 100
                    lsvLista.Columns.Add("Elaborado")
                    lsvLista.Columns(17).Width = 100
                    lsvLista.Columns.Add("Modificado")
                    lsvLista.Columns(18).Width = 100



                    contador = 0

                    If rwFilas Is Nothing = False Then
                        For Each Fila In rwFilas
                            contador = contador + 1
                            item = lsvLista.Items.Add("")
                            item.UseItemStyleForSubItems = False
                            If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                                If Fila.Item("color") = "0" Then
                                    item.SubItems.Item(0).BackColor = Color.White

                                ElseIf Fila.Item("color") = "1" Then
                                    item.SubItems.Item(0).BackColor = Color.Yellow
                                ElseIf Fila.Item("color") = "2" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                                ElseIf Fila.Item("color") = "3" Then
                                    item.SubItems.Item(0).BackColor = Color.Red
                                ElseIf Fila.Item("color") = "4" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                                ElseIf Fila.Item("color") = "5" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                                End If
                            End If

                            item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                            If (Fila.Item("serief") = "0") Then
                                item.SubItems.Add("" & "A")
                            ElseIf Fila.Item("serief") = "1" Then
                                item.SubItems.Add("" & "B")
                            ElseIf Fila.Item("serief") = "2" Then
                                item.SubItems.Add("" & "C")
                            ElseIf Fila.Item("serief") = "3" Then
                                item.SubItems.Add("" & "D")
                            End If
                            item.SubItems.Add("" & Fila.Item("numfactura"))
                            item.SubItems.Add("" & Fila.Item("fecha"))
                            item.SubItems.Add("" & Fila.Item("nombreempresa"))
                            item.SubItems.Add("" & Fila.Item("nombrecliente"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                            item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Fila.Item("serien"))
                            item.SubItems.Add("" & Fila.Item("numnota"))
                            item.SubItems.Add("" & Fila.Item("pagoabono"))
                            item.SubItems.Add("" & Fila.Item("comentario"))
                            item.SubItems.Add("" & Fila.Item("comentario2"))
                            item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                            'If (Fila.Item("cancelada") = "0") Then
                            '    item.SubItems.Item(0).BackColor = Color.Red
                            'End If
                            item.SubItems.Add("" & Fila.Item("usuarioc"))
                            item.SubItems.Add("" & Fila.Item("usuariom"))

                            item.Tag = Fila.Item("iIdFactura")
                            'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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
                    SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                    SQL &= " from (facturas"
                    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                    SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                    SQL &= " and fkiIdcliente=" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                    SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                    SQL &= " order by fecha,iIdFactura asc"



                    Dim rwFilas As DataRow() = nConsulta(SQL)
                    Dim item As ListViewItem

                    lsvLista.Columns.Add("Edo Pago")
                    lsvLista.Columns(0).Width = 70
                    lsvLista.Columns.Add("Tipo Fac")
                    lsvLista.Columns(1).Width = 70
                    lsvLista.Columns.Add("Serie F")
                    lsvLista.Columns(2).Width = 60
                    lsvLista.Columns.Add("Factura")
                    lsvLista.Columns(3).Width = 70
                    lsvLista.Columns(3).TextAlign = 1
                    lsvLista.Columns.Add("Fecha")
                    lsvLista.Columns(4).Width = 90
                    lsvLista.Columns.Add("Empresa")
                    lsvLista.Columns(5).Width = 300
                    lsvLista.Columns.Add("Cliente")
                    lsvLista.Columns(6).Width = 300
                    lsvLista.Columns.Add("Importe")
                    lsvLista.Columns(7).Width = 100
                    lsvLista.Columns(7).TextAlign = 1
                    lsvLista.Columns.Add("Iva")
                    lsvLista.Columns(8).Width = 100
                    lsvLista.Columns(8).TextAlign = 1
                    lsvLista.Columns.Add("Retención ISN")
                    lsvLista.Columns(9).Width = 100
                    lsvLista.Columns(9).TextAlign = 1
                    lsvLista.Columns.Add("Total")
                    lsvLista.Columns(10).Width = 100
                    lsvLista.Columns(10).TextAlign = 1
                    lsvLista.Columns.Add("Serie N")
                    lsvLista.Columns(11).Width = 70
                    lsvLista.Columns.Add("Nota")
                    lsvLista.Columns(12).Width = 70
                    lsvLista.Columns(12).TextAlign = 1
                    lsvLista.Columns.Add("Pago/Abono")
                    lsvLista.Columns(13).Width = 400
                    lsvLista.Columns.Add("Periodo")
                    lsvLista.Columns(14).Width = 400
                    lsvLista.Columns.Add("Comentario")
                    lsvLista.Columns(15).Width = 400
                    lsvLista.Columns.Add("Estado")
                    lsvLista.Columns(16).Width = 100
                    lsvLista.Columns.Add("Elaborado")
                    lsvLista.Columns(17).Width = 100
                    lsvLista.Columns.Add("Modificado")
                    lsvLista.Columns(18).Width = 100





                    contador = 0

                    If rwFilas Is Nothing = False Then
                        For Each Fila In rwFilas
                            contador = contador + 1
                            item = lsvLista.Items.Add("")
                            item.UseItemStyleForSubItems = False
                            If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                                If Fila.Item("color") = "0" Then
                                    item.SubItems.Item(0).BackColor = Color.White

                                ElseIf Fila.Item("color") = "1" Then
                                    item.SubItems.Item(0).BackColor = Color.Yellow
                                ElseIf Fila.Item("color") = "2" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                                ElseIf Fila.Item("color") = "3" Then
                                    item.SubItems.Item(0).BackColor = Color.Red
                                ElseIf Fila.Item("color") = "4" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                                ElseIf Fila.Item("color") = "5" Then
                                    item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                                End If
                            End If

                            item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                            If (Fila.Item("serief") = "0") Then
                                item.SubItems.Add("" & "A")
                            ElseIf Fila.Item("serief") = "1" Then
                                item.SubItems.Add("" & "B")
                            ElseIf Fila.Item("serief") = "2" Then
                                item.SubItems.Add("" & "C")
                            ElseIf Fila.Item("serief") = "3" Then
                                item.SubItems.Add("" & "D")
                            End If



                            item.SubItems.Add("" & Fila.Item("numfactura"))
                            item.SubItems.Add("" & Fila.Item("fecha"))
                            item.SubItems.Add("" & Fila.Item("nombreempresa"))
                            item.SubItems.Add("" & Fila.Item("nombrecliente"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                            item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                            item.SubItems.Add("" & Fila.Item("serien"))
                            item.SubItems.Add("" & Fila.Item("numnota"))
                            item.SubItems.Add("" & Fila.Item("pagoabono"))
                            item.SubItems.Add("" & Fila.Item("comentario"))
                            item.SubItems.Add("" & Fila.Item("comentario2"))
                            item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                            'If (Fila.Item("cancelada") = "0") Then
                            '    item.SubItems.Item(0).BackColor = Color.Red
                            'End If
                            item.SubItems.Add("" & Fila.Item("usuarioc"))
                            item.SubItems.Add("" & Fila.Item("usuariom"))


                            item.Tag = Fila.Item("iIdFactura")
                            'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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

        ElseIf (rdbpendientes.Checked) Then
            SQL = "select empresa.nombre as nombreempresa,fkiIdcliente, clientes.nombre as nombrecliente,numfactura,iIdFactura,fecha"
            SQL &= " from (facturas"
            SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
            SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
            SQL &= " where numfactura=null or numfactura=0"
            SQL &= " order by empresa.nombre asc"



            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem

            lsvLista.Columns.Add("Factura")
            lsvLista.Columns(0).Width = 70
            lsvLista.Columns.Add("Fecha")
            lsvLista.Columns(1).Width = 90
            lsvLista.Columns.Add("Empresa")
            lsvLista.Columns(2).Width = 300
            lsvLista.Columns.Add("Cliente")
            lsvLista.Columns(3).Width = 300


            contador = 0

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    contador = contador + 1
                    item = lsvLista.Items.Add(Fila.Item("numfactura"))
                    item.SubItems.Add("" & Fila.Item("fecha"))
                    item.SubItems.Add("" & Fila.Item("nombreempresa"))
                    item.SubItems.Add("" & Fila.Item("nombrecliente"))



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
        ElseIf (rdbbuscar.Checked) Then
            If (chktodas.Checked) Then
                SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " where (numfactura<>null or numfactura<>0)"
                SQL &= " and numfactura=" & IIf(txtbuscar.Text = "", 0, txtbuscar.Text) & " and facturas.iEstatus=1"
                SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                Dim rwFilas As DataRow() = nConsulta(SQL)
                Dim item As ListViewItem
                lsvLista.Columns.Add("Edo Pago")
                lsvLista.Columns(0).Width = 70
                lsvLista.Columns.Add("Tipo Fac")
                lsvLista.Columns(1).Width = 70
                lsvLista.Columns.Add("Serie F")
                lsvLista.Columns(2).Width = 60
                lsvLista.Columns.Add("Factura")
                lsvLista.Columns(3).Width = 70
                lsvLista.Columns(3).TextAlign = 1
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(4).Width = 90
                lsvLista.Columns.Add("Empresa")
                lsvLista.Columns(5).Width = 300
                lsvLista.Columns.Add("Cliente")
                lsvLista.Columns(6).Width = 300
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(7).Width = 100
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Iva")
                lsvLista.Columns(8).Width = 100
                lsvLista.Columns(8).TextAlign = 1
                lsvLista.Columns.Add("Retención ISN")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns(9).TextAlign = 1
                lsvLista.Columns.Add("Total")
                lsvLista.Columns(10).Width = 100
                lsvLista.Columns(10).TextAlign = 1
                lsvLista.Columns.Add("Serie N")
                lsvLista.Columns(11).Width = 70
                lsvLista.Columns.Add("Nota")
                lsvLista.Columns(12).Width = 70
                lsvLista.Columns(12).TextAlign = 1
                lsvLista.Columns.Add("Pago/Abono")
                lsvLista.Columns(13).Width = 400
                lsvLista.Columns.Add("Periodo")
                lsvLista.Columns(14).Width = 400
                lsvLista.Columns.Add("Comentario")
                lsvLista.Columns(15).Width = 400
                lsvLista.Columns.Add("Estado")
                lsvLista.Columns(16).Width = 100
                lsvLista.Columns.Add("Elaborado")
                lsvLista.Columns(17).Width = 100
                lsvLista.Columns.Add("Modificado")
                lsvLista.Columns(18).Width = 100


                contador = 0

                If rwFilas Is Nothing = False Then
                    For Each Fila In rwFilas
                        contador = contador + 1
                        item = lsvLista.Items.Add("")
                        item.UseItemStyleForSubItems = False
                        If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                            If Fila.Item("color") = "0" Then
                                item.SubItems.Item(0).BackColor = Color.White

                            ElseIf Fila.Item("color") = "1" Then
                                item.SubItems.Item(0).BackColor = Color.Yellow
                            ElseIf Fila.Item("color") = "2" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                            ElseIf Fila.Item("color") = "3" Then
                                item.SubItems.Item(0).BackColor = Color.Red
                            ElseIf Fila.Item("color") = "4" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                            ElseIf Fila.Item("color") = "5" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                            End If
                        End If

                        item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                        If (Fila.Item("serief") = "0") Then
                            item.SubItems.Add("" & "A")
                        ElseIf Fila.Item("serief") = "1" Then
                            item.SubItems.Add("" & "B")
                        ElseIf Fila.Item("serief") = "2" Then
                            item.SubItems.Add("" & "C")
                        ElseIf Fila.Item("serief") = "3" Then
                            item.SubItems.Add("" & "D")
                        End If



                        item.SubItems.Add("" & Fila.Item("numfactura"))
                        item.SubItems.Add("" & Fila.Item("fecha"))
                        item.SubItems.Add("" & Fila.Item("nombreempresa"))
                        item.SubItems.Add("" & Fila.Item("nombrecliente"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                        item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Fila.Item("serien"))
                        item.SubItems.Add("" & Fila.Item("numnota"))
                        item.SubItems.Add("" & Fila.Item("pagoabono"))
                        item.SubItems.Add("" & Fila.Item("comentario"))
                        item.SubItems.Add("" & Fila.Item("comentario2"))
                        item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                        'If (Fila.Item("cancelada") = "0") Then
                        '    item.SubItems.Item(0).BackColor = Color.Red
                        'End If
                        item.SubItems.Add("" & Fila.Item("usuarioc"))
                        item.SubItems.Add("" & Fila.Item("usuariom"))



                        item.Tag = Fila.Item("iIdFactura")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " and (numfactura<>null or numfactura<>0)"
                SQL &= " and numfactura=" & IIf(txtbuscar.Text = "", 0, txtbuscar.Text) & " and facturas.iEstatus=1"
                SQL &= " order by fecha,iIdFactura asc"



                Dim rwFilas As DataRow() = nConsulta(SQL)
                Dim item As ListViewItem

                lsvLista.Columns.Add("Edo Pago")
                lsvLista.Columns(0).Width = 70
                lsvLista.Columns.Add("Tipo Fac")
                lsvLista.Columns(1).Width = 70
                lsvLista.Columns.Add("Serie F")
                lsvLista.Columns(2).Width = 60
                lsvLista.Columns.Add("Factura")
                lsvLista.Columns(3).Width = 70
                lsvLista.Columns(3).TextAlign = 1
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(4).Width = 90
                lsvLista.Columns.Add("Empresa")
                lsvLista.Columns(5).Width = 300
                lsvLista.Columns.Add("Cliente")
                lsvLista.Columns(6).Width = 300
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(7).Width = 100
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Iva")
                lsvLista.Columns(8).Width = 100
                lsvLista.Columns(8).TextAlign = 1
                lsvLista.Columns.Add("Retención ISN")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns(9).TextAlign = 1
                lsvLista.Columns.Add("Total")
                lsvLista.Columns(10).Width = 100
                lsvLista.Columns(10).TextAlign = 1
                lsvLista.Columns.Add("Serie N")
                lsvLista.Columns(11).Width = 70
                lsvLista.Columns.Add("Nota")
                lsvLista.Columns(12).Width = 70
                lsvLista.Columns(12).TextAlign = 1
                lsvLista.Columns.Add("Pago/Abono")
                lsvLista.Columns(13).Width = 400
                lsvLista.Columns.Add("Periodo")
                lsvLista.Columns(14).Width = 400
                lsvLista.Columns.Add("Comentario")
                lsvLista.Columns(15).Width = 400
                lsvLista.Columns.Add("Estado")
                lsvLista.Columns(16).Width = 100
                lsvLista.Columns.Add("Elaborado")
                lsvLista.Columns(17).Width = 100
                lsvLista.Columns.Add("Modificado")
                lsvLista.Columns(18).Width = 100




                contador = 0

                If rwFilas Is Nothing = False Then
                    For Each Fila In rwFilas
                        contador = contador + 1
                        item = lsvLista.Items.Add("")
                        item.UseItemStyleForSubItems = False
                        If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                            If Fila.Item("color") = "0" Then
                                item.SubItems.Item(0).BackColor = Color.White

                            ElseIf Fila.Item("color") = "1" Then
                                item.SubItems.Item(0).BackColor = Color.Yellow
                            ElseIf Fila.Item("color") = "2" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                            ElseIf Fila.Item("color") = "3" Then
                                item.SubItems.Item(0).BackColor = Color.Red
                            ElseIf Fila.Item("color") = "4" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                            ElseIf Fila.Item("color") = "5" Then
                                item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                            End If
                        End If

                        item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                        If (Fila.Item("serief") = "0") Then
                            item.SubItems.Add("" & "A")
                        ElseIf Fila.Item("serief") = "1" Then
                            item.SubItems.Add("" & "B")
                        ElseIf Fila.Item("serief") = "2" Then
                            item.SubItems.Add("" & "C")
                        ElseIf Fila.Item("serief") = "3" Then
                            item.SubItems.Add("" & "D")
                        End If



                        item.SubItems.Add("" & Fila.Item("numfactura"))
                        item.SubItems.Add("" & Fila.Item("fecha"))
                        item.SubItems.Add("" & Fila.Item("nombreempresa"))
                        item.SubItems.Add("" & Fila.Item("nombrecliente"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                        item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Fila.Item("serien"))
                        item.SubItems.Add("" & Fila.Item("numnota"))
                        item.SubItems.Add("" & Fila.Item("pagoabono"))
                        item.SubItems.Add("" & Fila.Item("comentario"))
                        item.SubItems.Add("" & Fila.Item("comentario2"))
                        item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                        'If (Fila.Item("cancelada") = "0") Then
                        '    item.SubItems.Item(0).BackColor = Color.Red
                        'End If
                        item.SubItems.Add("" & Fila.Item("usuarioc"))
                        item.SubItems.Add("" & Fila.Item("usuariom"))


                        item.Tag = Fila.Item("iIdFactura")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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
        ElseIf (rdbplaza.Checked) Then
            If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then
                SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"

                If chkintermediarias.Checked Then
                    SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                    tipo = True
                End If
                If chkotras.Checked Then
                    If tipo Then
                        SQL &= " or empresa.fkiIdTipoEmpresa=3"
                    Else
                        SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                        tipo = True
                    End If

                End If
                If chkpatronas.Checked Then
                    If tipo Then
                        SQL &= " or empresa.fkiIdTipoEmpresa=1"
                    Else
                        SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                        tipo = True
                    End If

                End If

                If tipo Then
                    SQL &= " )"

                End If

                SQL &= " and clientes.iTipo=" & cboplaza.SelectedValue
                SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                Dim rwFilas As DataRow() = nConsulta(SQL)
                Dim item As ListViewItem
                lsvLista.Columns.Add("Edo Pago")
                lsvLista.Columns(0).Width = 70
                lsvLista.Columns.Add("Tipo Fac")
                lsvLista.Columns(1).Width = 70
                lsvLista.Columns.Add("Serie F")
                lsvLista.Columns(2).Width = 60
                lsvLista.Columns.Add("Factura")
                lsvLista.Columns(3).Width = 70
                lsvLista.Columns(3).TextAlign = 1
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(4).Width = 90
                lsvLista.Columns.Add("Empresa")
                lsvLista.Columns(5).Width = 300
                lsvLista.Columns.Add("Cliente")
                lsvLista.Columns(6).Width = 300
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(7).Width = 100
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Iva")
                lsvLista.Columns(8).Width = 100
                lsvLista.Columns(8).TextAlign = 1
                lsvLista.Columns.Add("Retención ISN")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns(9).TextAlign = 1
                lsvLista.Columns.Add("Total")
                lsvLista.Columns(10).Width = 100
                lsvLista.Columns(10).TextAlign = 1
                lsvLista.Columns.Add("Serie N")
                lsvLista.Columns(11).Width = 70
                lsvLista.Columns.Add("Nota")
                lsvLista.Columns(12).Width = 70
                lsvLista.Columns(12).TextAlign = 1
                lsvLista.Columns.Add("Pago/Abono")
                lsvLista.Columns(13).Width = 400
                lsvLista.Columns.Add("Periodo")
                lsvLista.Columns(14).Width = 400
                lsvLista.Columns.Add("Comentario")
                lsvLista.Columns(15).Width = 400
                lsvLista.Columns.Add("Estado")
                lsvLista.Columns(16).Width = 100
                lsvLista.Columns.Add("Elaborado")
                lsvLista.Columns(17).Width = 100
                lsvLista.Columns.Add("Modificado")
                lsvLista.Columns(18).Width = 100


                contador = 0

                If rwFilas Is Nothing = False Then
                    For Each Fila In rwFilas
                        contador = contador + 1
                        item = lsvLista.Items.Add("")
                        item.UseItemStyleForSubItems = False
                        If Fila.Item("color") = "0" Then
                            item.SubItems.Item(0).BackColor = Color.White

                        ElseIf Fila.Item("color") = "1" Then
                            item.SubItems.Item(0).BackColor = Color.Yellow
                        ElseIf Fila.Item("color") = "2" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                        ElseIf Fila.Item("color") = "3" Then
                            item.SubItems.Item(0).BackColor = Color.Red
                        ElseIf Fila.Item("color") = "4" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                        ElseIf Fila.Item("color") = "5" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                        End If

                        item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                        If (Fila.Item("serief") = "0") Then
                            item.SubItems.Add("" & "A")
                        ElseIf Fila.Item("serief") = "1" Then
                            item.SubItems.Add("" & "B")
                        ElseIf Fila.Item("serief") = "2" Then
                            item.SubItems.Add("" & "C")
                        ElseIf Fila.Item("serief") = "3" Then
                            item.SubItems.Add("" & "D")
                        End If



                        item.SubItems.Add("" & Fila.Item("numfactura"))
                        item.SubItems.Add("" & Fila.Item("fecha"))
                        item.SubItems.Add("" & Fila.Item("nombreempresa"))
                        item.SubItems.Add("" & Fila.Item("nombrecliente"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                        item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Fila.Item("serien"))
                        item.SubItems.Add("" & Fila.Item("numnota"))
                        item.SubItems.Add("" & Fila.Item("pagoabono"))
                        item.SubItems.Add("" & Fila.Item("comentario"))
                        item.SubItems.Add("" & Fila.Item("comentario2"))
                        item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                        'If (Fila.Item("cancelada") = "0") Then
                        '    item.SubItems.Item(0).BackColor = Color.Red
                        'End If
                        item.SubItems.Add("" & Fila.Item("usuarioc"))
                        item.SubItems.Add("" & Fila.Item("usuariom"))


                        item.Tag = Fila.Item("iIdFactura")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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
                MessageBox.Show("Seleccione la opcion de todas las empresas o el grupo de empresas que quiere", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf (rdbtodasplazas.Checked) Then
            If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then
                SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
                SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
                SQL &= " from (facturas"
                SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
                SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"

                If chkintermediarias.Checked Then
                    SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                    tipo = True
                End If
                If chkotras.Checked Then
                    If tipo Then
                        SQL &= " or empresa.fkiIdTipoEmpresa=3"
                    Else
                        SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                        tipo = True
                    End If

                End If
                If chkpatronas.Checked Then
                    If tipo Then
                        SQL &= " or empresa.fkiIdTipoEmpresa=1"
                    Else
                        SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                        tipo = True
                    End If

                End If

                If tipo Then
                    SQL &= " )"

                End If

                SQL &= " and (clientes.iTipo=1 or clientes.iTipo=2 or clientes.iTipo=3 or clientes.iTipo=5)"
                SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

                Dim rwFilas As DataRow() = nConsulta(SQL)
                Dim item As ListViewItem
                lsvLista.Columns.Add("Edo Pago")
                lsvLista.Columns(0).Width = 70
                lsvLista.Columns.Add("Tipo Fac")
                lsvLista.Columns(1).Width = 70
                lsvLista.Columns.Add("Serie F")
                lsvLista.Columns(2).Width = 60
                lsvLista.Columns.Add("Factura")
                lsvLista.Columns(3).Width = 70
                lsvLista.Columns(3).TextAlign = 1
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(4).Width = 90
                lsvLista.Columns.Add("Empresa")
                lsvLista.Columns(5).Width = 300
                lsvLista.Columns.Add("Cliente")
                lsvLista.Columns(6).Width = 300
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(7).Width = 100
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Iva")
                lsvLista.Columns(8).Width = 100
                lsvLista.Columns(8).TextAlign = 1
                lsvLista.Columns.Add("Retención ISN")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns(9).TextAlign = 1
                lsvLista.Columns.Add("Total")
                lsvLista.Columns(10).Width = 100
                lsvLista.Columns(10).TextAlign = 1
                lsvLista.Columns.Add("Serie N")
                lsvLista.Columns(11).Width = 70
                lsvLista.Columns.Add("Nota")
                lsvLista.Columns(12).Width = 70
                lsvLista.Columns(12).TextAlign = 1
                lsvLista.Columns.Add("Pago/Abono")
                lsvLista.Columns(13).Width = 400
                lsvLista.Columns.Add("Periodo")
                lsvLista.Columns(14).Width = 400
                lsvLista.Columns.Add("Comentario")
                lsvLista.Columns(15).Width = 400
                lsvLista.Columns.Add("Estado")
                lsvLista.Columns(16).Width = 100
                lsvLista.Columns.Add("Elaborado")
                lsvLista.Columns(17).Width = 100
                lsvLista.Columns.Add("Modificado")
                lsvLista.Columns(18).Width = 100

                contador = 0

                If rwFilas Is Nothing = False Then
                    For Each Fila In rwFilas
                        contador = contador + 1
                        item = lsvLista.Items.Add("")
                        item.UseItemStyleForSubItems = False
                        If Fila.Item("color") = "0" Then
                            item.SubItems.Item(0).BackColor = Color.White

                        ElseIf Fila.Item("color") = "1" Then
                            item.SubItems.Item(0).BackColor = Color.Yellow
                        ElseIf Fila.Item("color") = "2" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                        ElseIf Fila.Item("color") = "3" Then
                            item.SubItems.Item(0).BackColor = Color.Red
                        ElseIf Fila.Item("color") = "4" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                        ElseIf Fila.Item("color") = "5" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                        End If

                        item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                        If (Fila.Item("serief") = "0") Then
                            item.SubItems.Add("" & "A")
                        ElseIf Fila.Item("serief") = "1" Then
                            item.SubItems.Add("" & "B")
                        ElseIf Fila.Item("serief") = "2" Then
                            item.SubItems.Add("" & "C")
                        ElseIf Fila.Item("serief") = "3" Then
                            item.SubItems.Add("" & "D")
                        End If



                        item.SubItems.Add("" & Fila.Item("numfactura"))
                        item.SubItems.Add("" & Fila.Item("fecha"))
                        item.SubItems.Add("" & Fila.Item("nombreempresa"))
                        item.SubItems.Add("" & Fila.Item("nombrecliente"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                        item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Fila.Item("serien"))
                        item.SubItems.Add("" & Fila.Item("numnota"))
                        item.SubItems.Add("" & Fila.Item("pagoabono"))
                        item.SubItems.Add("" & Fila.Item("comentario"))
                        item.SubItems.Add("" & Fila.Item("comentario2"))
                        item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                        'If (Fila.Item("cancelada") = "0") Then
                        '    item.SubItems.Item(0).BackColor = Color.Red
                        'End If
                        item.SubItems.Add("" & Fila.Item("usuarioc"))
                        item.SubItems.Add("" & Fila.Item("usuariom"))


                        item.Tag = Fila.Item("iIdFactura")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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
                MessageBox.Show("Seleccione la opcion de todas las empresas o el grupo de empresas que quiere", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf (rdbgrupo.Checked) Then

            SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,facturas.fkiIdcliente, clientes.nombre as nombrecliente,"
            SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
            SQL &= " from ((facturas"
            SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
            SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente)"
            SQL &= " inner join IntGrupoCliente on Clientes.iIdCliente= IntGrupoCliente.fkiIdCliente"
            SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
            SQL &= " and fkiIdGrupo =  (select max(fkiIdGrupo)as iIdGrupo from IntGrupoCliente"
            SQL &= " where fkiIdCliente=" & cboclientes.SelectedValue & ")"


            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvLista.Columns.Add("Edo Pago")
            lsvLista.Columns(0).Width = 70
            lsvLista.Columns.Add("Tipo Fac")
            lsvLista.Columns(1).Width = 70
            lsvLista.Columns.Add("Serie F")
            lsvLista.Columns(2).Width = 60
            lsvLista.Columns.Add("Factura")
            lsvLista.Columns(3).Width = 70
            lsvLista.Columns(3).TextAlign = 1
            lsvLista.Columns.Add("Fecha")
            lsvLista.Columns(4).Width = 90
            lsvLista.Columns.Add("Empresa")
            lsvLista.Columns(5).Width = 300
            lsvLista.Columns.Add("Cliente")
            lsvLista.Columns(6).Width = 300
            lsvLista.Columns.Add("Importe")
            lsvLista.Columns(7).Width = 100
            lsvLista.Columns(7).TextAlign = 1
            lsvLista.Columns.Add("Iva")
            lsvLista.Columns(8).Width = 100
            lsvLista.Columns(8).TextAlign = 1
            lsvLista.Columns.Add("Retención ISN")
            lsvLista.Columns(9).Width = 100
            lsvLista.Columns(9).TextAlign = 1
            lsvLista.Columns.Add("Total")
            lsvLista.Columns(10).Width = 100
            lsvLista.Columns(10).TextAlign = 1
            lsvLista.Columns.Add("Serie N")
            lsvLista.Columns(11).Width = 70
            lsvLista.Columns.Add("Nota")
            lsvLista.Columns(12).Width = 70
            lsvLista.Columns(12).TextAlign = 1
            lsvLista.Columns.Add("Pago/Abono")
            lsvLista.Columns(13).Width = 400
            lsvLista.Columns.Add("Periodo")
            lsvLista.Columns(14).Width = 400
            lsvLista.Columns.Add("Comentario")
            lsvLista.Columns(15).Width = 400
            lsvLista.Columns.Add("Estado")
            lsvLista.Columns(16).Width = 100
            lsvLista.Columns.Add("Elaborado")
            lsvLista.Columns(17).Width = 100
            lsvLista.Columns.Add("Modificado")
            lsvLista.Columns(18).Width = 100


            contador = 0

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    contador = contador + 1
                    item = lsvLista.Items.Add("")
                    item.UseItemStyleForSubItems = False
                    If Fila.Item("color") = "0" Then
                        item.SubItems.Item(0).BackColor = Color.White

                    ElseIf Fila.Item("color") = "1" Then
                        item.SubItems.Item(0).BackColor = Color.Yellow
                    ElseIf Fila.Item("color") = "2" Then
                        item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                    ElseIf Fila.Item("color") = "3" Then
                        item.SubItems.Item(0).BackColor = Color.Red
                    ElseIf Fila.Item("color") = "4" Then
                        item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                    ElseIf Fila.Item("color") = "5" Then
                        item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                    End If

                    item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                    If (Fila.Item("serief") = "0") Then
                        item.SubItems.Add("" & "A")
                    ElseIf Fila.Item("serief") = "1" Then
                        item.SubItems.Add("" & "B")
                    ElseIf Fila.Item("serief") = "2" Then
                        item.SubItems.Add("" & "C")
                    ElseIf Fila.Item("serief") = "3" Then
                        item.SubItems.Add("" & "D")
                    End If



                    item.SubItems.Add("" & Fila.Item("numfactura"))
                    item.SubItems.Add("" & Fila.Item("fecha"))
                    item.SubItems.Add("" & Fila.Item("nombreempresa"))
                    item.SubItems.Add("" & Fila.Item("nombrecliente"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                    item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Fila.Item("serien"))
                    item.SubItems.Add("" & Fila.Item("numnota"))
                    item.SubItems.Add("" & Fila.Item("pagoabono"))
                    item.SubItems.Add("" & Fila.Item("comentario"))
                    item.SubItems.Add("" & Fila.Item("comentario2"))
                    item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                    'If (Fila.Item("cancelada") = "0") Then
                    '    item.SubItems.Item(0).BackColor = Color.Red
                    'End If
                    item.SubItems.Add("" & Fila.Item("usuarioc"))
                    item.SubItems.Add("" & Fila.Item("usuariom"))


                    item.Tag = Fila.Item("iIdFactura")
                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
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

    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        If lsvLista.SelectedItems.Count > 0 Then
            gIdFactura = lsvLista.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub cmdjannet_Click(sender As Object, e As EventArgs) Handles cmdjannet.Click
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim idtipo As Integer

        Dim Forma As New filtrofacturacion
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            idtipo = Forma.gIdTipo

            SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
            SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
            SQL &= "case when cancelada=0 then 0 else importe end as importe,"
            SQL &= "case when cancelada=0 then 0 else iva end as iva,"
            SQL &= "case when cancelada=0 then 0 else desnomina end as desnomina,"
            SQL &= "case when cancelada=0 then 0 else total end as total,"
            SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
            SQL &= " from (facturas"
            SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
            SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"

            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio


            If (rdbfechas.Checked) Then

                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked) Then
                        If idtipo = 1 Then
                            SQL &= " where tipofactura=0 And fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If

                            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                        ElseIf idtipo = 2 Then
                            SQL &= " where tipofactura=1 and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                        ElseIf idtipo = 3 Then
                            SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                        End If

                    Else

                        If idtipo = 1 Then
                            SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " and tipofactura=0 "
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " order by fecha,iIdFactura asc"
                        ElseIf idtipo = 2 Then
                            SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " and tipofactura=1 "
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " order by fecha,iIdFactura asc"
                        ElseIf idtipo = 3 Then
                            SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " order by fecha,iIdFactura asc"
                        End If
                    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf (rdbcliente.Checked) Then
                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked) Then
                        If idtipo = 1 Then
                            SQL &= " where fkiIdcliente =" & cboclientes.SelectedValue & " and tipofactura=0  and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                        ElseIf idtipo = 2 Then
                            SQL &= " where fkiIdcliente =" & cboclientes.SelectedValue & " and tipofactura=1  and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                        ElseIf idtipo = 3 Then
                            SQL &= " where fkiIdcliente =" & cboclientes.SelectedValue & "  and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                            SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                        End If

                    Else
                        If idtipo = 1 Then
                            SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " and tipofactura=0 "
                            SQL &= " and fkiIdcliente=" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= "  and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                            SQL &= " order by fecha,iIdFactura asc"
                        ElseIf idtipo = 2 Then
                            SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue & " and tipofactura=1 "
                            SQL &= " and fkiIdcliente=" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                            SQL &= " order by fecha,iIdFactura asc"
                        ElseIf idtipo = 3 Then
                            SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                            SQL &= " and fkiIdcliente=" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                            If chkcolor.Checked = True Then
                                SQL &= " and color=" & cbocolor.SelectedIndex
                            End If
                            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                            SQL &= " order by fecha,iIdFactura asc"
                        End If

                    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If

            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas Is Nothing = False Then
                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

                hoja.Column("B").Width = 13
                hoja.Column("C").Width = 50
                hoja.Column("D").Width = 15
                hoja.Column("E").Width = 13
                hoja.Column("F").Width = 40


                hoja.Cell(2, 4).Value = "Fecha:"
                hoja.Cell(2, 5).Value = Date.Now.ToShortDateString()

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja.Range(4, 2, 4, 6).Style.Font.FontSize = 10
                hoja.Range(4, 2, 4, 6).Style.Font.SetBold(True)
                hoja.Range(4, 2, 4, 6).Style.Alignment.WrapText = True
                hoja.Range(4, 2, 4, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(4, 1, 4, 6).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(4, 2, 4, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(4, 2, 4, 6).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                'hoja.Cell(4, 1).Value = "Num"
                hoja.Cell(4, 2).Value = "Edo Pago"
                hoja.Cell(4, 3).Value = "Factura"
                hoja.Cell(4, 4).Value = "Total"
                hoja.Cell(4, 5).Value = "Fecha"
                hoja.Cell(4, 6).Value = "Empresa"





                filaExcel = 4
                For Each Fila In rwFilas
                    filaExcel = filaExcel + 1

                    If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                        If Fila.Item("color") = "0" Then

                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.White
                        ElseIf Fila.Item("color") = "1" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.Yellow
                        ElseIf Fila.Item("color") = "2" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#00FF40")
                        ElseIf Fila.Item("color") = "3" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.Red
                        ElseIf Fila.Item("color") = "4" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#FF00FF")
                        ElseIf Fila.Item("color") = "5" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#01A9DB")
                        End If
                    End If

                    If (Fila.Item("serief") = "0") Then
                        hoja.Cell(filaExcel, 3).Value = "A " & Fila.Item("numfactura") & " " & Fila.Item("nombrecliente")
                    ElseIf Fila.Item("serief") = "1" Then
                        hoja.Cell(filaExcel, 3).Value = "B " & Fila.Item("numfactura") & " " & Fila.Item("nombrecliente")
                    ElseIf Fila.Item("serief") = "2" Then
                        hoja.Cell(filaExcel, 3).Value = "C " & Fila.Item("numfactura") & " " & Fila.Item("nombrecliente")
                    ElseIf Fila.Item("serief") = "3" Then
                        hoja.Cell(filaExcel, 3).Value = "D " & Fila.Item("numfactura") & " " & Fila.Item("nombrecliente")
                    End If
                    hoja.Cell(filaExcel, 4).Value = Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 4).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 5).Value = Fila.Item("fecha")
                    hoja.Cell(filaExcel, 6).Value = Fila.Item("nombreempresa")






                Next

                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Facturacion"
                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                dialogo.ShowDialog()
                libro.SaveAs(dialogo.FileName)
                'libro.SaveAs("c:\temp\control.xlsx")
                'libro.SaveAs(dialogo.FileName)
                'apExcel.Quit()
                libro = Nothing
            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If



    End Sub

    Private Sub cmdgeneral_Click(sender As Object, e As EventArgs) Handles cmdgeneral.Click
        Try
            Dim filaExcel As Integer = 5
            Dim tipo As Boolean
            Dim dialogo As New SaveFileDialog()


            SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
            SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
            SQL &= "case when cancelada=0 then 0 else importe end as importe,"
            SQL &= "case when cancelada=0 then 0 else iva end as iva,"
            SQL &= "case when cancelada=0 then 0 else desnomina end as desnomina,"
            SQL &= "case when cancelada=0 then 0 else total end as total,"
            SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,comentario2"
            SQL &= " from (facturas"
            SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
            SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"

            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            tipo = False
            If (rdbfechas.Checked) Then

                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then

                        SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"

                        If chkintermediarias.Checked Then
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                            tipo = True
                        End If
                        If chkotras.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=3"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                                tipo = True
                            End If

                        End If
                        If chkpatronas.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=1"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                                tipo = True
                            End If

                        End If

                        If tipo Then
                            SQL &= " )"

                        End If

                        SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                    Else
                        SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                        SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                        SQL &= " order by fecha,iIdFactura asc"
                    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf (rdbcliente.Checked) Then
                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then

                        SQL &= " where fkiIdcliente =" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                        SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"

                        If chkintermediarias.Checked Then
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                            tipo = True
                        End If
                        If chkotras.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=3"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                                tipo = True
                            End If

                        End If
                        If chkpatronas.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=1"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                                tipo = True
                            End If

                        End If

                        If tipo Then
                            SQL &= " )"

                        End If

                        SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                    Else
                        SQL &= " where fkiIdEmpresa=" & cboempresa.SelectedValue
                        SQL &= " and fkiIdcliente=" & cboclientes.SelectedValue & " and facturas.iEstatus=1"
                        SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                        SQL &= " order by fecha,iIdFactura asc"
                    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf (rdbplaza.Checked) Then
                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then

                        SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"

                        If chkintermediarias.Checked Then
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                            tipo = True
                        End If
                        If chkotras.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=3"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                                tipo = True
                            End If

                        End If
                        If chkpatronas.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=1"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                                tipo = True
                            End If

                        End If

                        If tipo Then
                            SQL &= " )"

                        End If
                        SQL &= " and clientes.iTipo=" & cboplaza.SelectedValue
                        SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                    Else
                        MessageBox.Show("Seleccione la opcion de todas las empresas o el grupo de empresas que quiere", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            ElseIf (rdbtodasplazas.Checked) Then
                If (tiempo.Days >= 0) Then
                    If (chktodas.Checked Or chkintermediarias.Checked Or chkotras.Checked Or chkpatronas.Checked) Then

                        SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"

                        If chkintermediarias.Checked Then
                            SQL &= " and  (empresa.fkiIdTipoEmpresa=2"
                            tipo = True
                        End If
                        If chkotras.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=3"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=3"
                                tipo = True
                            End If

                        End If
                        If chkpatronas.Checked Then
                            If tipo Then
                                SQL &= " or empresa.fkiIdTipoEmpresa=1"
                            Else
                                SQL &= " and  (empresa.fkiIdTipoEmpresa=1"
                                tipo = True
                            End If

                        End If

                        If tipo Then
                            SQL &= " )"

                        End If
                        SQL &= " and (clientes.iTipo=1 or clientes.iTipo=2 or clientes.iTipo=3 or clientes.iTipo=5)"
                        SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                    Else
                        MessageBox.Show("Seleccione la opcion de todas las empresas o el grupo de empresas que quiere", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf (rdbgrupo.Checked) Then
                If (tiempo.Days >= 0) Then
                    SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,facturas.fkiIdcliente, clientes.nombre as nombrecliente,"
                    SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,"
                    SQL &= "case when cancelada=0 then 0 else importe end as importe,"
                    SQL &= "case when cancelada=0 then 0 else iva end as iva,"
                    SQL &= "case when cancelada=0 then 0 else desnomina end as desnomina,"
                    SQL &= "case when cancelada=0 then 0 else total end as total,"
                    SQL &= "pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,comentario2"
                    SQL &= " from ((facturas"
                    SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
                    SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente)"
                    SQL &= " inner join IntGrupoCliente on Clientes.iIdCliente= IntGrupoCliente.fkiIdCliente"
                    SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                    SQL &= " and fkiIdGrupo =  (select max(fkiIdGrupo)as iIdGrupo from IntGrupoCliente"
                    SQL &= " where fkiIdCliente=" & cboclientes.SelectedValue & ")"


                    SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"
                Else
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas Is Nothing = False Then
                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

                hoja.Column("B").Width = 13
                hoja.Column("C").Width = 13
                hoja.Column("D").Width = 13
                hoja.Column("E").Width = 13
                hoja.Column("F").Width = 30
                hoja.Column("G").Width = 30
                hoja.Column("H").Width = 13
                hoja.Column("I").Width = 13
                hoja.Column("J").Width = 13
                hoja.Column("K").Width = 13
                hoja.Column("L").Width = 13
                hoja.Column("M").Width = 13
                hoja.Column("N").Width = 35
                hoja.Column("O").Width = 35
                hoja.Column("P").Width = 35
                hoja.Column("Q").Width = 13
                hoja.Column("R").Width = 15
                hoja.Column("S").Width = 15
                hoja.Cell(2, 2).Value = "Fecha:"
                hoja.Cell(2, 3).Value = Date.Now.ToShortDateString()

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja.Range(4, 2, 4, 19).Style.Font.FontSize = 10
                hoja.Range(4, 2, 4, 19).Style.Font.SetBold(True)
                hoja.Range(4, 2, 4, 19).Style.Alignment.WrapText = True
                hoja.Range(4, 2, 4, 19).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(4, 1, 4, 19).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(4, 2, 4, 19).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(4, 2, 4, 19).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                'hoja.Cell(4, 1).Value = "Num"
                hoja.Cell(4, 2).Value = "Edo Pago"
                hoja.Cell(4, 3).Value = "Serie F"
                hoja.Cell(4, 4).Value = "Factura"
                hoja.Cell(4, 5).Value = "Fecha"
                hoja.Cell(4, 6).Value = "Empresa"
                hoja.Cell(4, 7).Value = "Cliente"
                hoja.Cell(4, 8).Value = "Importe"
                hoja.Cell(4, 9).Value = "Iva"
                hoja.Cell(4, 10).Value = "ISN"
                hoja.Cell(4, 11).Value = "Total"
                hoja.Cell(4, 12).Value = "Serie N"
                hoja.Cell(4, 12).Value = "Nota"
                hoja.Cell(4, 14).Value = "Pago/Abono"
                hoja.Cell(4, 15).Value = "Periodo"
                hoja.Cell(4, 16).Value = "Comentario"
                hoja.Cell(4, 17).Value = "Estado"
                hoja.Cell(4, 18).Value = "Elaborado"
                hoja.Cell(4, 19).Value = "Modificado"



                filaExcel = 4
                For Each Fila In rwFilas
                    filaExcel = filaExcel + 1

                    If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                        If Fila.Item("color") = "0" Then

                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.White
                        ElseIf Fila.Item("color") = "1" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.Yellow
                        ElseIf Fila.Item("color") = "2" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#00FF40")
                        ElseIf Fila.Item("color") = "3" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.Red
                        ElseIf Fila.Item("color") = "4" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#FF00FF")
                        ElseIf Fila.Item("color") = "5" Then
                            hoja.Cell(filaExcel, 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#01A9DB")
                        End If
                    End If

                    If (Fila.Item("serief") = "0") Then
                        hoja.Cell(filaExcel, 3).Value = "A"
                    ElseIf Fila.Item("serief") = "1" Then
                        hoja.Cell(filaExcel, 3).Value = "B"
                    ElseIf Fila.Item("serief") = "2" Then
                        hoja.Cell(filaExcel, 3).Value = "C"
                    ElseIf Fila.Item("serief") = "3" Then
                        hoja.Cell(filaExcel, 3).Value = "D"
                    End If

                    hoja.Cell(filaExcel, 4).Value = Fila.Item("numfactura")
                    hoja.Cell(filaExcel, 5).Value = Fila.Item("fecha")
                    hoja.Cell(filaExcel, 6).Value = Fila.Item("nombreempresa")
                    hoja.Cell(filaExcel, 7).Value = Fila.Item("nombrecliente")
                    hoja.Cell(filaExcel, 8).Value = Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 8).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 9).Value = Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 9).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 10).Value = Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 10).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 11).Value = Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0")
                    hoja.Cell(filaExcel, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(filaExcel, 12).Value = Fila.Item("serien")
                    hoja.Cell(filaExcel, 13).Value = Fila.Item("numnota")
                    hoja.Cell(filaExcel, 14).Value = Fila.Item("pagoabono")
                    hoja.Cell(filaExcel, 15).Value = Fila.Item("comentario")
                    hoja.Cell(filaExcel, 16).Value = Fila.Item("comentario2")
                    hoja.Cell(filaExcel, 17).Value = IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa")
                    hoja.Cell(filaExcel, 18).Value = Fila.Item("usuarioc")
                    hoja.Cell(filaExcel, 19).Value = Fila.Item("usuariom")




                Next

                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Facturacion"
                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                dialogo.ShowDialog()
                libro.SaveAs(dialogo.FileName)
                'libro.SaveAs("c:\temp\control.xlsx")
                'libro.SaveAs(dialogo.FileName)
                'apExcel.Quit()
                libro = Nothing
            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdminuta.Click
        Dim formas As New frmminuta
        formas.ShowDialog()
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub chktodas_CheckedChanged(sender As Object, e As EventArgs) Handles chktodas.CheckedChanged
        chkintermediarias.Checked = False
        chkotras.Checked = False
        chkpatronas.Checked = False

    End Sub
End Class