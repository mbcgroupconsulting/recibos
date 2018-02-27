Public Class frmlista
    Public gIdFacturas As String
    Public gIdFacturaSelec As String
    Public giIdFactura As String
    Private Sub frmlista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarlista()
    End Sub

    Private Sub cargarlista()
        Dim sql As String
        Dim contador As Integer
        Dim Alter As Boolean = False
        Dim ids As String()
        Dim facturas As String
        Dim numfactura As Integer



        If Strings.Left(gIdFacturas, 1) = "F" Then

            ids = gIdFacturas.Split(",")
            numfactura = 1
            facturas = ""
            For x As Integer = 0 To ids.Length - 1

                If numfactura = 1 Then
                    facturas &= " and (iIdFactura=" & Mid(ids(x), 2)
                    numfactura = 1 + 1
                Else
                    facturas &= " or iIdFactura=" & Mid(ids(x), 2)
                End If
            Next
            facturas &= ")"

            sql = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
            sql &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2"
            sql &= " from (facturas"
            sql &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
            sql &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
            sql &= " where facturas.iEstatus=1 "
            sql &= facturas
            sql &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

            Dim rwFilas As DataRow() = nConsulta(sql)
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
            lsvLista.Columns.Add("Total")
            lsvLista.Columns(9).Width = 100
            lsvLista.Columns(9).TextAlign = 1
            lsvLista.Columns.Add("Serie N")
            lsvLista.Columns(10).Width = 70
            lsvLista.Columns.Add("Nota")
            lsvLista.Columns(11).Width = 70
            lsvLista.Columns(11).TextAlign = 1
            lsvLista.Columns.Add("Pago/Abono")
            lsvLista.Columns(12).Width = 400
            lsvLista.Columns.Add("Periodo")
            lsvLista.Columns(13).Width = 400
            lsvLista.Columns.Add("Comentario")
            lsvLista.Columns(14).Width = 400
            lsvLista.Columns.Add("Estado")
            lsvLista.Columns(15).Width = 100
            lsvLista.Columns.Add("Elaborado")
            lsvLista.Columns(16).Width = 100
            lsvLista.Columns.Add("Modificado")
            lsvLista.Columns(17).Width = 100

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
                            item.SubItems.Item(0).BackColor = Color.Green
                        ElseIf Fila.Item("color") = "3" Then
                            item.SubItems.Item(0).BackColor = Color.Red
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
            End If

        Else
            'Gastoss
            ids = gIdFacturas.Split(",")
            numfactura = 1
            facturas = ""
            For x As Integer = 0 To ids.Length - 1

                If numfactura = 1 Then
                    facturas &= " and (iIdGasto=" & Mid(ids(x), 2)
                    numfactura = 1 + 1
                Else
                    facturas &= " or iIdGasto=" & Mid(ids(x), 2)
                End If
            Next
            facturas &= ")"


            sql = "select * from gastos "
            sql &= " where gastos.iEstatus=1 "
            sql &= facturas
            sql &= " order by fechapago,proveedor asc"

            Dim rwFilas As DataRow() = nConsulta(sql)
            Dim item As ListViewItem
            lsvLista.Columns.Add("Factura")
            lsvLista.Columns(0).Width = 170
            lsvLista.Columns.Add("Fecha Expedicón")
            lsvLista.Columns(1).Width = 170
            lsvLista.Columns.Add("Proveedor")
            lsvLista.Columns(2).Width = 300
            lsvLista.Columns.Add("Total")
            lsvLista.Columns(3).Width = 120
            lsvLista.Columns(3).TextAlign = 1
            lsvLista.Columns.Add("Fecha Pago")
            lsvLista.Columns(4).Width = 170


            contador = 0

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    contador = contador + 1



                    item = lsvLista.Items.Add("" & Fila.Item("Factura"))

                    item.SubItems.Add("" & Fila.Item("fechaexp"))
                    item.SubItems.Add("" & Fila.Item("proveedor"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Fila.Item("fechapago"))
                    item.Tag = Fila.Item("iIdGasto")
                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter
                Next
            End If

        End If






    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        If lsvLista.SelectedItems.Count > 0 Then

            If Strings.Left(gIdFacturas, 1) = "F" Then
                gIdFacturaSelec = lsvLista.SelectedItems(0).SubItems(3).Text & " " & lsvLista.SelectedItems(0).SubItems(6).Text
                giIdFactura = lsvLista.SelectedItems(0).Tag
            Else
                gIdFacturaSelec = lsvLista.SelectedItems(0).SubItems(0).Text & " " & lsvLista.SelectedItems(0).SubItems(2).Text
            End If



            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class