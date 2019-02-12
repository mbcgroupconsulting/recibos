Imports ClosedXML.Excel
Imports System.IO
Public Class frmPrestamoEmpleado

    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim total As Double
    Dim numpagos As Integer
    Public gIdEmpresa As String
    Public gIdCliente As String
    Public gIdEmpleado As String
    Public gIdPeriodo As String
    Public gIdPrestamo As String
    Private Sub frmPrestamoEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blnNuevo = True
        cargarlista()
        'cargardatos()

    End Sub


    Private Sub cargarlista()
        Dim sql As String

        sql = "select * from prestamo where fkiIdEmpleado =" & gIdEmpleado





        Dim rwFilas As DataRow() = nConsulta(sql)
        lsvLista.Items.Clear()
        lsvLista.Clear()
        lsvLista.Columns.Add("Fecha")
        lsvLista.Columns(0).Width = 170
        lsvLista.Columns.Add("Importe")
        lsvLista.Columns(1).Width = 170
        lsvLista.Columns(1).TextAlign = 1
        lsvLista.Columns.Add("Descuento")
        lsvLista.Columns(2).Width = 170
        lsvLista.Columns(2).TextAlign = 1


        If rwFilas Is Nothing = False Then
            Dim Alter As Boolean = False
            Dim item As ListViewItem

            'Cargamos la lista de abonos
            total = 0
            numpagos = rwFilas.Length
            For x As Integer = 0 To rwFilas.Length - 1
                Dim Fila As DataRow = rwFilas(x)
                item = lsvLista.Items.Add(Fila.Item("fechaprestamo"))
                item.SubItems.Add(Fila.Item("montototal"))
                item.SubItems.Add(Fila.Item("descuento"))

                total = total + Fila.Item("montototal")
                'totalfactura = totalfactura + txttotal.Text
                'txttotalf.Text = (Double.Parse(Fila.Item("total")) + Double.Parse(txttotalf.Text)).ToString()

                item.Tag = Fila.Item("iIdPrestamo")

                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter



            Next

            'lbltotal.Text = total
            'lbltotal.Text = Format(CType(IIf(lbltotal.Text = "", "0", lbltotal.Text), Decimal), "###,###,##0.#0")

            'Abonos



            'MessageBox.Show(rwFilas.Length & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("No se encontraron registros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub cmdpagos_Click(sender As Object, e As EventArgs) Handles cmdpagos.Click
        Try
            Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
            If datos.Count = 1 Then
                Dim Forma As New frmMostrarPagos
                Forma.gIdPrestamo = datos(0).Tag
                Forma.ShowDialog()
            Else
                MessageBox.Show("No hay datos seleccionados para mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdimprimirpagos_Click(sender As Object, e As EventArgs) Handles cmdimprimirpagos.Click
        Try
            Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
            If datos.Count = 1 Then

                'Enviar datos a excel
                Dim SQL As String, Alter As Boolean = False

                Dim promotor As String = ""
                Dim filaExcel As Integer = 5
                Dim dialogo As New SaveFileDialog()
                Dim contadorfacturas As Integer


                Alter = True


                'SQL = "Select iIdFactura,fecha,facturas.numfactura,facturas.importe,facturas.iva,facturas.total,"
                'SQL &= " pagoabono, comentario, comentario2, empresa.nombrefiscal, clientes.nombre "
                'SQL &= " from((Facturas left join pagos on Facturas.iIdFactura=pagos.fkiIdFactura)"
                'SQL &= " inner Join empresa on facturas.fkiIdEmpresa=empresa.iIdEmpresa) "
                'SQL &= " inner Join clientes on facturas.fkiIdCliente= clientes.iIdCliente"
                'SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 "
                'SQL &= "  And facturas.cancelada=1  And pagos.iIdPago Is NULL and facturas.tipofactura=0"
                'SQL &= " order by empresa.nombrefiscal, fecha"



                SQL = "select cNombreLargo,montototal,fechaprestamo,fechainiciopago,pagoprestamo.monto,"
                SQL &= "pagoprestamo.fecha from (empleadosC"
                SQL &= " inner join prestamo on empleadosC.iIdEmpleadoC = prestamo.fkiIdEmpleado)"
                SQL &= " inner join PagoPrestamo on prestamo.iIdPrestamo = PagoPrestamo.fkiIdPrestamo"
                SQL &= " where iIdEmpleadoC =" & gIdEmpleado & " and iIdPrestamo=" & datos(0).Tag
                SQL &= " and prestamo.iEstatus=1 and pagoprestamo.iEstatus=1"
                SQL &= " order by pagoprestamo.fecha"


                Dim rwFilas As DataRow() = nConsulta(SQL)
                total = 0
                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Reporte Prestamo")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
                    hoja.Column("E").Width = 30
                    hoja.Column("F").Width = 30

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "Resumen prestamo"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 1, 4, 5).Style.Font.FontSize = 10
                    hoja.Range(4, 1, 4, 5).Style.Font.SetBold(True)
                    hoja.Range(4, 1, 4, 5).Style.Alignment.WrapText = True
                    hoja.Range(4, 1, 4, 5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 5).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 1, 4, 5).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 1, 4, 5).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Fecha"
                    hoja.Cell(4, 3).Value = "Descripcion"
                    hoja.Cell(4, 4).Value = "Abono"
                    hoja.Cell(4, 5).Value = "Saldo"

                    hoja.Cell(5, 1).Value = 1
                    hoja.Cell(5, 2).Value = rwFilas(0)("fechaprestamo")
                    hoja.Cell(5, 3).Value = "Monto Inicial"
                    hoja.Cell(5, 4).Value = ""
                    hoja.Cell(5, 5).Value = rwFilas(0)("montototal")


                    filaExcel = 6
                    contadorfacturas = 1

                    For x As Integer = 0 To rwFilas.Length - 1

                        hoja.Cell(filaExcel + x, 1).Value = x + 2
                        hoja.Cell(filaExcel + x, 2).Value = rwFilas(x)("Fecha")
                        hoja.Cell(filaExcel + x, 3).Value = "Descuento de nomina"
                        hoja.Cell(filaExcel + x, 4).Value = rwFilas(x)("monto")
                        hoja.Cell(filaExcel + x, 5).Value = (hoja.Cell(filaExcel + x - 1, 5).Value) - rwFilas(x)("monto")

                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Prestamo"
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


                'Dim rwFilas As DataRow() = nConsulta(SQL)




            Else
                MessageBox.Show("No hay datos seleccionados para mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Try

            'Validar


            If txtimporte.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el importe"
            End If

            If txtdescuento.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el descuento"
            End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If




            If blnNuevo Then


                SQL = "EXEC setPrestamoInsertar  0,"
                SQL &= txtimporte.Text & ","
                SQL &= txtdescuento.Text
                SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "',1," & gIdEmpleado



            Else

                SQL = "EXEC setPrestamoActualizar " & gIdPrestamo & ","
                SQL &= txtimporte.Text & ","
                SQL &= txtdescuento.Text
                SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "',1," & gIdEmpleado



            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If

            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            limpiar()


            cargarlista()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub txtimporte_TextChanged(sender As Object, e As EventArgs) Handles txtimporte.TextChanged

    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtdescuento_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento.TextChanged

    End Sub

    Private Sub txtdescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescuento.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub


    Private Sub limpiar()
        dtpfecha.Value = Date.Now.ToShortDateString()
        txtimporte.Text = "0"
        txtdescuento.Text = "0"

        blnNuevo = True
    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        If lsvLista.SelectedItems.Count > 0 Then
            editar(lsvLista.SelectedItems(0).Tag)
        End If
    End Sub

    Private Sub editar(id As String)
        Dim sql As String
        limpiar()
        sql = "select * from prestamo where iIdPrestamo = " & id
        Dim rwFilas As DataRow() = nConsulta(sql)
        Try
            If rwFilas Is Nothing = False Then
                blnNuevo = False
                Dim Fila As DataRow = rwFilas(0)


                dtpfecha.Value = Fila.Item("fechaprestamo")
                txtimporte.Text = Fila.Item("montototal")
                txtdescuento.Text = Fila.Item("descuento")

                gIdPrestamo = id


            End If
        Catch ex As Exception

        End Try

    End Sub

End Class