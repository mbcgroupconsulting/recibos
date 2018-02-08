Imports ClosedXML.Excel

Public Class frmReportexEmpresa
    Private Sub cmdcomisiones_Click(sender As Object, e As EventArgs) Handles cmdcomisiones.Click
        Dim SQL As String, Alter As Boolean = False
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim dsReporte As New DataSet
        Dim filaExcel As Integer = 5
        Dim encontradas As Integer = 0
        Dim nombreclientes As String

        Try
            If (tiempo.Days >= 0) Then


                SQL = "select iIdFactura, fkiIdEmpresa, fkiIdcliente, fecha, numfactura, importe,"
                SQL &= "iva, desnomina, total,  facturas.iEstatus, flujob, cancelada, empresa.nombre as empresa,"
                SQL &= "clientes.nombre as cliente"
                SQL &= " from (facturas"
                SQL &= " inner join clientes on facturas.fkiidcliente= clientes.iidcliente)"
                SQL &= " inner join empresa on facturas.fkiidempresa = empresa.iidempresa"
                SQL &= " where (flujob=2 or flujob=3)"
                SQL &= " AND (fecha BETWEEN '" & inicio.ToShortDateString & "' AND '" & fin.ToShortDateString & "') and facturas.iEstatus=1 And facturas.cancelada=1"
                SQL &= " AND clientes.iTipo<>6"
                SQL &= " order by fkiidEmpresa"

                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then

                    dsReporte.Tables.Add("Tabla")
                    dsReporte.Tables("Tabla").Columns.Add("cliente")
                    dsReporte.Tables("Tabla").Columns.Add("fecha")
                    dsReporte.Tables("Tabla").Columns.Add("empresa")
                    dsReporte.Tables("Tabla").Columns.Add("subtotal")
                    dsReporte.Tables("Tabla").Columns.Add("iva")
                    dsReporte.Tables("Tabla").Columns.Add("total")
                    dsReporte.Tables("Tabla").Columns.Add("comision")
                    dsReporte.Tables("Tabla").Columns.Add("calculoc")
                    dsReporte.Tables("Tabla").Columns.Add("promotor1")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor1")
                    dsReporte.Tables("Tabla").Columns.Add("promotor2")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor2")
                    dsReporte.Tables("Tabla").Columns.Add("promotor3")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor3")
                    dsReporte.Tables("Tabla").Columns.Add("promotor4")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor4")
                    dsReporte.Tables("Tabla").Columns.Add("rcliente")
                    dsReporte.Tables("Tabla").Columns.Add("11")
                    dsReporte.Tables("Tabla").Columns.Add("12")
                    dsReporte.Tables("Tabla").Columns.Add("sumar")
                    dsReporte.Tables("Tabla").Columns.Add("utilidad")

                    'hacemos un ciclo para calcular los importes y despues guardarlo en el dataset


                    For x As Integer = 0 To rwFilas.Count - 1

                        'buscamos primero si esta guardado en la tabla

                        'buscamos la factura si ya esta guardada

                        SQL = "select * from CalculoFlujoCManual where fkiIdFactura=" & rwFilas(x)("iIdFactura")


                        Dim rwCalculado As DataRow() = nConsulta(SQL)
                        If rwCalculado Is Nothing = False Then

                            Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow

                            fila.Item("cliente") = rwFilas(x)("numfactura") & " " & rwFilas(x)("cliente")
                            fila.Item("fecha") = rwFilas(x)("fecha")
                            fila.Item("empresa") = rwFilas(x)("empresa")
                            fila.Item("subtotal") = rwFilas(x)("importe")
                            fila.Item("iva") = rwFilas(x)("iva")
                            fila.Item("total") = rwFilas(x)("total")
                            fila.Item("comision") = rwCalculado(0)("Comision")
                            fila.Item("calculoc") = rwCalculado(0)("CalculoComision")
                            fila.Item("promotor1") = ""
                            fila.Item("cantidadpromotor1") = rwCalculado(0)("Promotor1")
                            fila.Item("promotor2") = ""
                            fila.Item("cantidadpromotor2") = rwCalculado(0)("Promotor2")
                            fila.Item("promotor3") = ""
                            fila.Item("cantidadpromotor3") = rwCalculado(0)("Promotor3")
                            fila.Item("promotor4") = ""
                            fila.Item("cantidadpromotor4") = rwCalculado(0)("Promotor4")
                            fila.Item("rcliente") = rwCalculado(0)("RetornoCliente")
                            fila.Item("11") = rwCalculado(0)("uno1")
                            fila.Item("12") = rwCalculado(0)("uno2")
                            fila.Item("sumar") = rwCalculado(0)("sumaretornos")
                            fila.Item("utilidad") = rwCalculado(0)("utilidad")

                            dsReporte.Tables("Tabla").Rows.Add(fila)
                            encontradas = encontradas + 1


                        Else

                            If Integer.Parse(rwFilas(x)("flujob")) = 2 Then
                                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & rwFilas(x)("fkiIdcliente") & " and tipo=1"
                            Else
                                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & rwFilas(x)("fkiIdcliente") & " and tipo=2"
                            End If

                            Dim rwComisionClienteFlujo As DataRow() = nConsulta(SQL)

                            If rwComisionClienteFlujo Is Nothing = False Then


                                Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow

                                fila.Item("cliente") = rwFilas(x)("numfactura") & " " & rwFilas(x)("cliente")
                                fila.Item("fecha") = rwFilas(x)("fecha")
                                fila.Item("empresa") = rwFilas(x)("empresa")
                                fila.Item("subtotal") = rwFilas(x)("importe")
                                fila.Item("iva") = rwFilas(x)("iva")
                                fila.Item("total") = rwFilas(x)("total")
                                fila.Item("comision") = rwComisionClienteFlujo(0).Item("porcobrado") & "%" & IIf(Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1, " + IVA", "")

                                If Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1 Then

                                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    Else
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    End If



                                    'retorno cliente

                                    fila.Item("rcliente") = Math.Round(Double.Parse(rwFilas(x)("importe")) / ((Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100) + 1), 2)

                                    fila.Item("calculoc") = Math.Round(Double.Parse(fila.Item("rcliente")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                                    fila.Item("11") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("12") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("sumar") = Math.Round(Double.Parse(fila.Item("cantidadpromotor1")) + Double.Parse(fila.Item("cantidadpromotor2")) + Double.Parse(fila.Item("cantidadpromotor3")) + Double.Parse(fila.Item("cantidadpromotor4")) + Double.Parse(fila.Item("rcliente")), 2)

                                    fila.Item("utilidad") = Math.Round(Double.Parse(rwFilas(x)("total")) - Double.Parse(fila.Item("sumar")) - Double.Parse(fila.Item("11")) - Double.Parse(fila.Item("12")), 2)

                                Else

                                    fila.Item("calculoc") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    Else
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    End If



                                    'retorno cliente
                                    fila.Item("rcliente") = Math.Round(Double.Parse(rwFilas(x)("total")) - (Double.Parse(fila.Item("calculoc"))), 2)

                                    fila.Item("11") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("12") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("sumar") = Math.Round(Double.Parse(fila.Item("cantidadpromotor1")) + Double.Parse(fila.Item("cantidadpromotor2")) + Double.Parse(fila.Item("cantidadpromotor3")) + Double.Parse(fila.Item("cantidadpromotor4")) + Double.Parse(fila.Item("rcliente")), 2)

                                    fila.Item("utilidad") = Math.Round(Double.Parse(rwFilas(x)("total")) - Double.Parse(fila.Item("sumar")) - Double.Parse(fila.Item("11")) - Double.Parse(fila.Item("12")), 2)

                                End If

                                dsReporte.Tables("Tabla").Rows.Add(fila)
                                encontradas = encontradas + 1
                            Else
                                nombreclientes = nombreclientes + rwFilas(x)("cliente") & vbCrLf
                                'MessageBox.Show("lientes no procesados:" & vbCrLf & nombreclientes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If


                        End If




                    Next



                    'ya que se tiene el dataset hecho se pasan los datos al excel hoja por empresa

                    '##################
                    '#########
                    'ENVIAR A EXCEL

                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim nombreempresa As String
                    Dim nombreempresacorto As String


                    filaExcel = 5

                    nombreempresa = ""

                    If dsReporte.Tables("Tabla").Rows(0)("empresa").ToString.Length > 31 Then
                        nombreempresacorto = dsReporte.Tables("Tabla").Rows(0)("empresa").ToString.Substring(1, 31)
                    Else
                        nombreempresacorto = dsReporte.Tables("Tabla").Rows(0)("empresa").ToString
                    End If

                    Dim hoja As IXLWorksheet '= libro.Worksheets.Add(nombreempresacorto)

                    For x As Integer = 0 To dsReporte.Tables("Tabla").Rows.Count - 1

                        If nombreempresa <> dsReporte.Tables("Tabla").Rows(x)("empresa").ToString() Then
                            filaExcel = 5

                            nombreempresa = dsReporte.Tables("Tabla").Rows(x)("empresa").ToString()

                            If dsReporte.Tables("Tabla").Rows(0)("empresa").ToString.Length > 31 Then
                                nombreempresacorto = dsReporte.Tables("Tabla").Rows(x)("empresa").ToString.Substring(1, 31)
                            Else
                                nombreempresacorto = dsReporte.Tables("Tabla").Rows(x)("empresa").ToString
                            End If

                            hoja = libro.Worksheets.Add(nombreempresacorto)


                            hoja.Column("B").Width = 40
                            hoja.Column("C").Width = 15
                            hoja.Column("D").Width = 40
                            hoja.Column("E").Width = 30
                            hoja.Column("F").Width = 13
                            hoja.Column("G").Width = 13
                            hoja.Column("H").Width = 13
                            hoja.Column("I").Width = 13
                            hoja.Column("J").Width = 13
                            hoja.Column("K").Width = 13
                            hoja.Column("L").Width = 13
                            hoja.Column("M").Width = 13
                            hoja.Column("N").Width = 13
                            hoja.Column("O").Width = 13
                            hoja.Column("P").Width = 13
                            hoja.Column("Q").Width = 13
                            hoja.Column("R").Width = 13


                            hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                            hoja.Cell(3, 2).Value = "MOVIMIENTOS IVA"

                            'hoja.Cell(3, 2).Value = ":"
                            'hoja.Cell(3, 3).Value = ""

                            hoja.Range(4, 2, 4, 18).Style.Font.FontSize = 10
                            hoja.Range(4, 2, 4, 18).Style.Font.SetBold(True)
                            hoja.Range(4, 2, 4, 18).Style.Alignment.WrapText = True
                            hoja.Range(4, 2, 4, 18).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                            hoja.Range(4, 1, 4, 18).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                            hoja.Range(4, 2, 4, 18).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                            hoja.Range(4, 2, 4, 18).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                            'hoja.Cell(4, 1).Value = "Num"
                            hoja.Cell(4, 2).Value = "Cliente factura"
                            hoja.Cell(4, 3).Value = "Fecha"
                            hoja.Cell(4, 4).Value = "Empresa factura"
                            hoja.Cell(4, 5).Value = "Subtotal"
                            hoja.Range(5, 5, 1500, 5).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 6).Value = "IVA"
                            hoja.Range(5, 6, 1500, 6).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 7).Value = "Total"
                            hoja.Range(5, 7, 1500, 7).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 8).Value = "Comisión"
                            hoja.Cell(4, 9).Value = "Calculo Comisión"
                            hoja.Range(5, 9, 1500, 8).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 10).Value = "Promotor 1"
                            hoja.Range(5, 10, 1500, 9).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 11).Value = "Promotor 2"
                            hoja.Range(5, 11, 1500, 10).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 12).Value = "Promotor 3"
                            hoja.Range(5, 12, 1500, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 13).Value = "Promotor 4"
                            hoja.Range(5, 13, 1500, 12).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 14).Value = "R Cliente"
                            hoja.Range(5, 14, 1500, 13).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 15).Value = "1%"
                            hoja.Range(5, 15, 1500, 14).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 16).Value = "1%"
                            hoja.Range(5, 16, 1500, 15).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 17).Value = "Suma retorno"
                            hoja.Range(5, 17, 1500, 16).Style.NumberFormat.SetFormat("###,###,##0.#0")
                            hoja.Cell(4, 18).Value = "Utilidad"
                            hoja.Range(5, 18, 1500, 17).Style.NumberFormat.SetFormat("###,###,##0.#0")
                        End If





                        hoja.Cell(filaExcel, 2).Value = dsReporte.Tables("Tabla").Rows(x)("cliente").ToString
                        hoja.Cell(filaExcel, 3).Value = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                        hoja.Cell(filaExcel, 4).Value = dsReporte.Tables("Tabla").Rows(x)("empresa").ToString
                        hoja.Cell(filaExcel, 5).Value = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                        hoja.Cell(filaExcel, 6).Value = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                        hoja.Cell(filaExcel, 7).Value = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                        hoja.Cell(filaExcel, 8).Value = dsReporte.Tables("Tabla").Rows(x)("comision").ToString
                        hoja.Cell(filaExcel, 9).Value = dsReporte.Tables("Tabla").Rows(x)("calculoc").ToString
                        hoja.Cell(filaExcel, 10).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor1").ToString
                        hoja.Cell(filaExcel, 11).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor2").ToString
                        hoja.Cell(filaExcel, 12).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor3").ToString
                        hoja.Cell(filaExcel, 13).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor4").ToString
                        hoja.Cell(filaExcel, 14).Value = dsReporte.Tables("Tabla").Rows(x)("rcliente").ToString
                        hoja.Cell(filaExcel, 15).Value = dsReporte.Tables("Tabla").Rows(x)("11").ToString
                        hoja.Cell(filaExcel, 16).Value = dsReporte.Tables("Tabla").Rows(x)("12").ToString
                        hoja.Cell(filaExcel, 17).Value = dsReporte.Tables("Tabla").Rows(x)("sumar").ToString
                        hoja.Cell(filaExcel, 18).Value = dsReporte.Tables("Tabla").Rows(x)("utilidad").ToString





                        filaExcel = filaExcel + 1

                    Next


                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Movimientos IVA " & dtpfechainicio.Value.ToString.Replace("/", "-").Substring(1, 10) & " a " & dtpfechafin.Value.ToString.Replace("/", "-").Substring(1, 10)
                    dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                    dialogo.ShowDialog()
                    libro.SaveAs(dialogo.FileName)
                    'libro.SaveAs("c:\temp\control.xlsx")
                    'libro.SaveAs(dialogo.FileName)
                    'apExcel.Quit()
                    libro = Nothing

                    MessageBox.Show("Número de facturas encontradas:" & rwFilas.Count & " Número de facturas procesadas: " & encontradas & ". Proceso terminado correctamente" & vbCrLf & "Clientes no procesados:" & vbCrLf & nombreclientes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception



        End Try

    End Sub

    Private Sub cmdCien_Click(sender As Object, e As EventArgs) Handles cmdCien.Click
        Dim SQL As String, Alter As Boolean = False
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim dsReporte As New DataSet
        Dim filaExcel As Integer = 5
        Dim encontradas As Integer = 0
        Dim nombreclientes As String

        Try
            If (tiempo.Days >= 0) Then


                SQL = "select iIdFactura, facturas.fkiIdEmpresa, facturas.fkiIdcliente, fecha, numfactura, importe,"
                SQL &= "iva, desnomina, total,  facturas.iEstatus, flujob, cancelada, empresa.nombre as empresa,"
                SQL &= "clientes.nombre as cliente"
                SQL &= " from ((facturas"
                SQL &= " inner join clientes on facturas.fkiidcliente= clientes.iidcliente)"
                SQL &= " inner join empresa on facturas.fkiidempresa = empresa.iidempresa)"
                SQL &= " inner join comisionclienteflujo on facturas.fkiidcliente=comisionclienteflujo.fkiidcliente"
                SQL &= " where (flujob=2 or flujob=3)"
                SQL &= " AND (fecha BETWEEN '" & inicio.ToShortDateString & "' AND '" & fin.ToShortDateString & "') AND cancelada=1 And facturas.iestatus=1"
                SQL &= " AND comisionclienteflujo.masiva=1"
                SQL &= " order by fkiidEmpresa"

                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then

                    dsReporte.Tables.Add("Tabla")
                    dsReporte.Tables("Tabla").Columns.Add("cliente")
                    dsReporte.Tables("Tabla").Columns.Add("fecha")
                    dsReporte.Tables("Tabla").Columns.Add("empresa")
                    dsReporte.Tables("Tabla").Columns.Add("subtotal")
                    dsReporte.Tables("Tabla").Columns.Add("iva")
                    dsReporte.Tables("Tabla").Columns.Add("total")
                    dsReporte.Tables("Tabla").Columns.Add("comision")
                    dsReporte.Tables("Tabla").Columns.Add("calculoc")
                    dsReporte.Tables("Tabla").Columns.Add("promotor1")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor1")
                    dsReporte.Tables("Tabla").Columns.Add("promotor2")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor2")
                    dsReporte.Tables("Tabla").Columns.Add("promotor3")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor3")
                    dsReporte.Tables("Tabla").Columns.Add("promotor4")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor4")
                    dsReporte.Tables("Tabla").Columns.Add("rcliente")
                    dsReporte.Tables("Tabla").Columns.Add("11")
                    dsReporte.Tables("Tabla").Columns.Add("12")
                    dsReporte.Tables("Tabla").Columns.Add("sumar")
                    dsReporte.Tables("Tabla").Columns.Add("utilidad")

                    'hacemos un ciclo para calcular los importes y despues guardarlo en el dataset


                    For x As Integer = 0 To rwFilas.Count - 1


                        'buscamos primero si esta guardado en la tabla

                        'buscamos la factura si ya esta guardada

                        SQL = "select * from CalculoFlujoCManual where fkiIdFactura=" & rwFilas(x)("iIdFactura")


                        Dim rwCalculado As DataRow() = nConsulta(SQL)
                        If rwCalculado Is Nothing = False Then
                            Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow

                            fila.Item("cliente") = rwFilas(x)("numfactura") & " " & rwFilas(x)("cliente")
                            fila.Item("fecha") = rwFilas(x)("fecha")
                            fila.Item("empresa") = rwFilas(x)("empresa")
                            fila.Item("subtotal") = rwFilas(x)("importe")
                            fila.Item("iva") = rwFilas(x)("iva")
                            fila.Item("total") = rwFilas(x)("total")
                            fila.Item("comision") = rwCalculado(0)("Comision")
                            fila.Item("calculoc") = rwCalculado(0)("CalculoComision")
                            fila.Item("promotor1") = ""
                            fila.Item("cantidadpromotor1") = rwCalculado(0)("Promotor1")
                            fila.Item("promotor2") = ""
                            fila.Item("cantidadpromotor2") = rwCalculado(0)("Promotor2")
                            fila.Item("promotor3") = ""
                            fila.Item("cantidadpromotor3") = rwCalculado(0)("Promotor3")
                            fila.Item("promotor4") = ""
                            fila.Item("cantidadpromotor4") = rwCalculado(0)("Promotor4")
                            fila.Item("rcliente") = rwCalculado(0)("RetornoCliente")
                            fila.Item("11") = rwCalculado(0)("uno1")
                            fila.Item("12") = rwCalculado(0)("uno2")
                            fila.Item("sumar") = rwCalculado(0)("sumaretornos")
                            fila.Item("utilidad") = rwCalculado(0)("utilidad")

                            dsReporte.Tables("Tabla").Rows.Add(fila)
                            encontradas = encontradas + 1

                        Else
                            If Integer.Parse(rwFilas(x)("flujob")) = 2 Then
                                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & rwFilas(x)("fkiIdcliente") & " and tipo=1 and masiva=1"
                            Else
                                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & rwFilas(x)("fkiIdcliente") & " and tipo=2 and masiva=1"
                            End If

                            Dim rwComisionClienteFlujo As DataRow() = nConsulta(SQL)

                            If rwComisionClienteFlujo Is Nothing = False Then


                                Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow

                                fila.Item("cliente") = rwFilas(x)("numfactura") & " " & rwFilas(x)("cliente")
                                fila.Item("fecha") = rwFilas(x)("fecha")
                                fila.Item("empresa") = rwFilas(x)("empresa")
                                fila.Item("subtotal") = rwFilas(x)("importe")
                                fila.Item("iva") = rwFilas(x)("iva")
                                fila.Item("total") = rwFilas(x)("total")
                                fila.Item("comision") = rwComisionClienteFlujo(0).Item("porcobrado") & "%" & IIf(Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1, " + IVA", "")

                                If Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1 Then

                                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    Else
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    End If



                                    'retorno cliente

                                    fila.Item("rcliente") = Math.Round(Double.Parse(rwFilas(x)("importe")) / ((Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100) + 1), 2)

                                    fila.Item("calculoc") = Math.Round(Double.Parse(fila.Item("rcliente")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                                    fila.Item("11") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("12") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("sumar") = Math.Round(Double.Parse(fila.Item("cantidadpromotor1")) + Double.Parse(fila.Item("cantidadpromotor2")) + Double.Parse(fila.Item("cantidadpromotor3")) + Double.Parse(fila.Item("cantidadpromotor4")) + Double.Parse(fila.Item("rcliente")), 2)

                                    fila.Item("utilidad") = Math.Round(Double.Parse(rwFilas(x)("total")) - Double.Parse(fila.Item("sumar")) - Double.Parse(fila.Item("11")) - Double.Parse(fila.Item("12")), 2)

                                Else

                                    fila.Item("calculoc") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    Else
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    End If



                                    'retorno cliente
                                    fila.Item("rcliente") = Math.Round(Double.Parse(rwFilas(x)("importe")) - ((Double.Parse(fila.Item("calculoc")) / 100) + 1), 2)

                                    fila.Item("11") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("12") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("sumar") = Math.Round(Double.Parse(fila.Item("cantidadpromotor1")) + Double.Parse(fila.Item("cantidadpromotor2")) + Double.Parse(fila.Item("cantidadpromotor3")) + Double.Parse(fila.Item("cantidadpromotor4")) + Double.Parse(fila.Item("rcliente")), 2)

                                    fila.Item("utilidad") = Math.Round(Double.Parse(rwFilas(x)("total")) - Double.Parse(fila.Item("sumar")) - Double.Parse(fila.Item("11")) - Double.Parse(fila.Item("12")), 2)

                                End If

                                dsReporte.Tables("Tabla").Rows.Add(fila)
                                encontradas = encontradas + 1
                            Else
                                nombreclientes = nombreclientes + rwFilas(x)("cliente") & vbCrLf
                                'MessageBox.Show("lientes no procesados:" & vbCrLf & nombreclientes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If






                    Next



                    'ya que se tiene el dataset hecho se pasan los datos al excel hoja por empresa

                    '##################
                    '#########
                    'ENVIAR A EXCEL

                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim nombreempresa As String
                    Dim nombreempresacorto As String


                    filaExcel = 5



                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Flujos al 100%")

                    hoja.Column("B").Width = 40
                    hoja.Column("C").Width = 15
                    hoja.Column("D").Width = 40
                    hoja.Column("E").Width = 30
                    hoja.Column("F").Width = 13
                    hoja.Column("G").Width = 13
                    hoja.Column("H").Width = 13
                    hoja.Column("I").Width = 13
                    hoja.Column("J").Width = 13
                    hoja.Column("K").Width = 13
                    hoja.Column("L").Width = 13
                    hoja.Column("M").Width = 13
                    hoja.Column("N").Width = 13
                    hoja.Column("O").Width = 13
                    hoja.Column("P").Width = 13
                    hoja.Column("Q").Width = 13
                    hoja.Column("R").Width = 13


                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "Flujos al 100%"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 2, 4, 18).Style.Font.FontSize = 10
                    hoja.Range(4, 2, 4, 18).Style.Font.SetBold(True)
                    hoja.Range(4, 2, 4, 18).Style.Alignment.WrapText = True
                    hoja.Range(4, 2, 4, 18).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 18).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 2, 4, 18).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 2, 4, 18).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Cliente factura"
                    hoja.Cell(4, 3).Value = "Fecha"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Subtotal"
                    hoja.Range(5, 5, 1500, 5).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 6).Value = "IVA"
                    hoja.Range(5, 6, 1500, 6).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 7).Value = "Total"
                    hoja.Range(5, 7, 1500, 7).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 8).Value = "Comisión"
                    hoja.Cell(4, 9).Value = "Calculo Comisión"
                    hoja.Range(5, 9, 1500, 8).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 10).Value = "Promotor 1"
                    hoja.Range(5, 10, 1500, 9).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 11).Value = "Promotor 2"
                    hoja.Range(5, 11, 1500, 10).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 12).Value = "Promotor 3"
                    hoja.Range(5, 12, 1500, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 13).Value = "Promotor 4"
                    hoja.Range(5, 13, 1500, 12).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 14).Value = "R Cliente"
                    hoja.Range(5, 14, 1500, 13).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 15).Value = "1%"
                    hoja.Range(5, 15, 1500, 14).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 16).Value = "1%"
                    hoja.Range(5, 16, 1500, 15).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 17).Value = "Suma retorno"
                    hoja.Range(5, 17, 1500, 16).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 18).Value = "Utilidad"
                    hoja.Range(5, 18, 1500, 17).Style.NumberFormat.SetFormat("###,###,##0.#0")

                    For x As Integer = 0 To dsReporte.Tables("Tabla").Rows.Count - 1







                        hoja.Cell(filaExcel, 2).Value = dsReporte.Tables("Tabla").Rows(x)("cliente").ToString
                        hoja.Cell(filaExcel, 3).Value = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                        hoja.Cell(filaExcel, 4).Value = dsReporte.Tables("Tabla").Rows(x)("empresa").ToString
                        hoja.Cell(filaExcel, 5).Value = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                        hoja.Cell(filaExcel, 6).Value = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                        hoja.Cell(filaExcel, 7).Value = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                        hoja.Cell(filaExcel, 8).Value = dsReporte.Tables("Tabla").Rows(x)("comision").ToString
                        hoja.Cell(filaExcel, 9).Value = dsReporte.Tables("Tabla").Rows(x)("calculoc").ToString
                        hoja.Cell(filaExcel, 10).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor1").ToString
                        hoja.Cell(filaExcel, 11).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor2").ToString
                        hoja.Cell(filaExcel, 12).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor3").ToString
                        hoja.Cell(filaExcel, 13).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor4").ToString
                        hoja.Cell(filaExcel, 14).Value = dsReporte.Tables("Tabla").Rows(x)("rcliente").ToString
                        hoja.Cell(filaExcel, 15).Value = dsReporte.Tables("Tabla").Rows(x)("11").ToString
                        hoja.Cell(filaExcel, 16).Value = dsReporte.Tables("Tabla").Rows(x)("12").ToString
                        hoja.Cell(filaExcel, 17).Value = dsReporte.Tables("Tabla").Rows(x)("sumar").ToString
                        hoja.Cell(filaExcel, 18).Value = dsReporte.Tables("Tabla").Rows(x)("utilidad").ToString





                        filaExcel = filaExcel + 1

                    Next


                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Flujos al 100% " & dtpfechainicio.Value.ToString.Replace("/", "-").Substring(1, 10) & " a " & dtpfechafin.Value.ToString.Replace("/", "-").Substring(1, 10)
                    dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                    dialogo.ShowDialog()
                    libro.SaveAs(dialogo.FileName)
                    'libro.SaveAs("c:\temp\control.xlsx")
                    'libro.SaveAs(dialogo.FileName)
                    'apExcel.Quit()
                    libro = Nothing

                    'MessageBox.Show("Número de facturas encontradas:" & rwFilas.Count & " Número de facturas procesadas: " & encontradas & ". Proceso terminado correctamente" & vbCrLf & "Clientes no procesados:" & vbCrLf & nombreclientes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("Proceso terminado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception



        End Try

    End Sub

    Private Sub cmdnocien_Click(sender As Object, e As EventArgs) Handles cmdnocien.Click
        Dim SQL As String, Alter As Boolean = False
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim dsReporte As New DataSet
        Dim filaExcel As Integer = 5
        Dim encontradas As Integer = 0
        Dim nombreclientes As String

        Try
            If (tiempo.Days >= 0) Then


                SQL = "select iIdFactura, facturas.fkiIdEmpresa, facturas.fkiIdcliente, fecha, numfactura, importe,"
                SQL &= "iva, desnomina, total,  facturas.iEstatus, flujob, cancelada, empresa.nombre as empresa,"
                SQL &= "clientes.nombre as cliente"
                SQL &= " from ((facturas"
                SQL &= " inner join clientes on facturas.fkiidcliente= clientes.iidcliente)"
                SQL &= " inner join empresa on facturas.fkiidempresa = empresa.iidempresa)"
                SQL &= " inner join comisionclienteflujo on facturas.fkiidcliente=comisionclienteflujo.fkiidcliente"
                SQL &= " where (flujob=2 or flujob=3)"
                SQL &= " AND (fecha BETWEEN '" & inicio.ToShortDateString & "' AND '" & fin.ToShortDateString & "') AND cancelada=1 AND Facturas.iEstatus=1"
                SQL &= " AND comisionclienteflujo.masiva=0"
                SQL &= " order by fkiidEmpresa"

                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then

                    dsReporte.Tables.Add("Tabla")
                    dsReporte.Tables("Tabla").Columns.Add("cliente")
                    dsReporte.Tables("Tabla").Columns.Add("fecha")
                    dsReporte.Tables("Tabla").Columns.Add("empresa")
                    dsReporte.Tables("Tabla").Columns.Add("subtotal")
                    dsReporte.Tables("Tabla").Columns.Add("iva")
                    dsReporte.Tables("Tabla").Columns.Add("total")
                    dsReporte.Tables("Tabla").Columns.Add("comision")
                    dsReporte.Tables("Tabla").Columns.Add("calculoc")
                    dsReporte.Tables("Tabla").Columns.Add("promotor1")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor1")
                    dsReporte.Tables("Tabla").Columns.Add("promotor2")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor2")
                    dsReporte.Tables("Tabla").Columns.Add("promotor3")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor3")
                    dsReporte.Tables("Tabla").Columns.Add("promotor4")
                    dsReporte.Tables("Tabla").Columns.Add("cantidadpromotor4")
                    dsReporte.Tables("Tabla").Columns.Add("rcliente")
                    dsReporte.Tables("Tabla").Columns.Add("11")
                    dsReporte.Tables("Tabla").Columns.Add("12")
                    dsReporte.Tables("Tabla").Columns.Add("sumar")
                    dsReporte.Tables("Tabla").Columns.Add("utilidad")

                    'hacemos un ciclo para calcular los importes y despues guardarlo en el dataset


                    For x As Integer = 0 To rwFilas.Count - 1


                        'buscamos primero si esta guardado en la tabla

                        'buscamos la factura si ya esta guardada

                        SQL = "select * from CalculoFlujoCManual where fkiIdFactura=" & rwFilas(x)("iIdFactura")


                        Dim rwCalculado As DataRow() = nConsulta(SQL)
                        If rwCalculado Is Nothing = False Then
                            Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow

                            fila.Item("cliente") = rwFilas(x)("numfactura") & " " & rwFilas(x)("cliente")
                            fila.Item("fecha") = rwFilas(x)("fecha")
                            fila.Item("empresa") = rwFilas(x)("empresa")
                            fila.Item("subtotal") = rwFilas(x)("importe")
                            fila.Item("iva") = rwFilas(x)("iva")
                            fila.Item("total") = rwFilas(x)("total")
                            fila.Item("comision") = rwCalculado(0)("Comision")
                            fila.Item("calculoc") = rwCalculado(0)("CalculoComision")
                            fila.Item("promotor1") = ""
                            fila.Item("cantidadpromotor1") = rwCalculado(0)("Promotor1")
                            fila.Item("promotor2") = ""
                            fila.Item("cantidadpromotor2") = rwCalculado(0)("Promotor2")
                            fila.Item("promotor3") = ""
                            fila.Item("cantidadpromotor3") = rwCalculado(0)("Promotor3")
                            fila.Item("promotor4") = ""
                            fila.Item("cantidadpromotor4") = rwCalculado(0)("Promotor4")
                            fila.Item("rcliente") = rwCalculado(0)("RetornoCliente")
                            fila.Item("11") = rwCalculado(0)("uno1")
                            fila.Item("12") = rwCalculado(0)("uno2")
                            fila.Item("sumar") = rwCalculado(0)("sumaretornos")
                            fila.Item("utilidad") = rwCalculado(0)("utilidad")

                            dsReporte.Tables("Tabla").Rows.Add(fila)
                            encontradas = encontradas + 1
                        Else
                            If Integer.Parse(rwFilas(x)("flujob")) = 2 Then
                                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & rwFilas(x)("fkiIdcliente") & " and tipo=1 and masiva=0"
                            Else
                                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & rwFilas(x)("fkiIdcliente") & " and tipo=2 and masiva=0"
                            End If

                            Dim rwComisionClienteFlujo As DataRow() = nConsulta(SQL)

                            If rwComisionClienteFlujo Is Nothing = False Then


                                Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow

                                fila.Item("cliente") = rwFilas(x)("numfactura") & " " & rwFilas(x)("cliente")
                                fila.Item("fecha") = rwFilas(x)("fecha")
                                fila.Item("empresa") = rwFilas(x)("empresa")
                                fila.Item("subtotal") = rwFilas(x)("importe")
                                fila.Item("iva") = rwFilas(x)("iva")
                                fila.Item("total") = rwFilas(x)("total")
                                fila.Item("comision") = rwComisionClienteFlujo(0).Item("porcobrado") & "%" & IIf(Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1, " + IVA", "")

                                If Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1 Then

                                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    Else
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    End If



                                    'retorno cliente

                                    fila.Item("rcliente") = Math.Round(Double.Parse(rwFilas(x)("importe")) / ((Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100) + 1), 2)

                                    fila.Item("calculoc") = Math.Round(Double.Parse(fila.Item("rcliente")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                                    fila.Item("11") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("12") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("sumar") = Math.Round(Double.Parse(fila.Item("cantidadpromotor1")) + Double.Parse(fila.Item("cantidadpromotor2")) + Double.Parse(fila.Item("cantidadpromotor3")) + Double.Parse(fila.Item("cantidadpromotor4")) + Double.Parse(fila.Item("rcliente")), 2)

                                    fila.Item("utilidad") = Math.Round(Double.Parse(rwFilas(x)("total")) - Double.Parse(fila.Item("sumar")) - Double.Parse(fila.Item("11")) - Double.Parse(fila.Item("12")), 2)

                                Else

                                    fila.Item("calculoc") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("importe")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    Else
                                        'promotor
                                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                                        Else
                                            fila.Item("promotor1") = ""
                                            fila.Item("cantidadpromotor1") = "0.00"
                                        End If

                                        'promotor2
                                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                                        Else
                                            fila.Item("promotor2") = ""
                                            fila.Item("cantidadpromotor2") = "0.00"
                                        End If

                                        'promotor3
                                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                                        Else
                                            fila.Item("promotor3") = ""
                                            fila.Item("cantidadpromotor3") = "0.00"
                                        End If

                                        'promotor4
                                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = Math.Round(Double.Parse(rwFilas(x)("total")) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                                        Else
                                            fila.Item("promotor4") = ""
                                            fila.Item("cantidadpromotor4") = "0.00"
                                        End If
                                    End If



                                    'retorno cliente
                                    fila.Item("rcliente") = Math.Round(Double.Parse(rwFilas(x)("importe")) - ((Double.Parse(fila.Item("calculoc")) / 100) + 1), 2)

                                    fila.Item("11") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("12") = Math.Round(Double.Parse(rwFilas(x)("total")) * 0.01, 2)

                                    fila.Item("sumar") = Math.Round(Double.Parse(fila.Item("cantidadpromotor1")) + Double.Parse(fila.Item("cantidadpromotor2")) + Double.Parse(fila.Item("cantidadpromotor3")) + Double.Parse(fila.Item("cantidadpromotor4")) + Double.Parse(fila.Item("rcliente")), 2)

                                    fila.Item("utilidad") = Math.Round(Double.Parse(rwFilas(x)("total")) - Double.Parse(fila.Item("sumar")) - Double.Parse(fila.Item("11")) - Double.Parse(fila.Item("12")), 2)

                                End If

                                dsReporte.Tables("Tabla").Rows.Add(fila)
                                encontradas = encontradas + 1
                            Else
                                nombreclientes = nombreclientes + rwFilas(x)("cliente") & vbCrLf
                                'MessageBox.Show("lientes no procesados:" & vbCrLf & nombreclientes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If


                        End If






                    Next



                    'ya que se tiene el dataset hecho se pasan los datos al excel hoja por empresa

                    '##################
                    '#########
                    'ENVIAR A EXCEL

                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim nombreempresa As String
                    Dim nombreempresacorto As String


                    filaExcel = 5



                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Flujos al 100%")

                    hoja.Column("B").Width = 40
                    hoja.Column("C").Width = 15
                    hoja.Column("D").Width = 40
                    hoja.Column("E").Width = 30
                    hoja.Column("F").Width = 13
                    hoja.Column("G").Width = 13
                    hoja.Column("H").Width = 13
                    hoja.Column("I").Width = 13
                    hoja.Column("J").Width = 13
                    hoja.Column("K").Width = 13
                    hoja.Column("L").Width = 13
                    hoja.Column("M").Width = 13
                    hoja.Column("N").Width = 13
                    hoja.Column("O").Width = 13
                    hoja.Column("P").Width = 13
                    hoja.Column("Q").Width = 13
                    hoja.Column("R").Width = 13


                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "Flujos NO Cob al 100%"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 2, 4, 18).Style.Font.FontSize = 10
                    hoja.Range(4, 2, 4, 18).Style.Font.SetBold(True)
                    hoja.Range(4, 2, 4, 18).Style.Alignment.WrapText = True
                    hoja.Range(4, 2, 4, 18).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 18).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 2, 4, 18).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 2, 4, 18).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Cliente factura"
                    hoja.Cell(4, 3).Value = "Fecha"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Subtotal"
                    hoja.Range(5, 5, 1500, 5).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 6).Value = "IVA"
                    hoja.Range(5, 6, 1500, 6).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 7).Value = "Total"
                    hoja.Range(5, 7, 1500, 7).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 8).Value = "Comisión"
                    hoja.Cell(4, 9).Value = "Calculo Comisión"
                    hoja.Range(5, 9, 1500, 8).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 10).Value = "Promotor 1"
                    hoja.Range(5, 10, 1500, 9).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 11).Value = "Promotor 2"
                    hoja.Range(5, 11, 1500, 10).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 12).Value = "Promotor 3"
                    hoja.Range(5, 12, 1500, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 13).Value = "Promotor 4"
                    hoja.Range(5, 13, 1500, 12).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 14).Value = "R Cliente"
                    hoja.Range(5, 14, 1500, 13).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 15).Value = "1%"
                    hoja.Range(5, 15, 1500, 14).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 16).Value = "1%"
                    hoja.Range(5, 16, 1500, 15).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 17).Value = "Suma retorno"
                    hoja.Range(5, 17, 1500, 16).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 18).Value = "Utilidad"
                    hoja.Range(5, 18, 1500, 17).Style.NumberFormat.SetFormat("###,###,##0.#0")

                    For x As Integer = 0 To dsReporte.Tables("Tabla").Rows.Count - 1







                        hoja.Cell(filaExcel, 2).Value = dsReporte.Tables("Tabla").Rows(x)("cliente").ToString
                        hoja.Cell(filaExcel, 3).Value = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                        hoja.Cell(filaExcel, 4).Value = dsReporte.Tables("Tabla").Rows(x)("empresa").ToString
                        hoja.Cell(filaExcel, 5).Value = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                        hoja.Cell(filaExcel, 6).Value = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                        hoja.Cell(filaExcel, 7).Value = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                        hoja.Cell(filaExcel, 8).Value = dsReporte.Tables("Tabla").Rows(x)("comision").ToString
                        hoja.Cell(filaExcel, 9).Value = dsReporte.Tables("Tabla").Rows(x)("calculoc").ToString
                        hoja.Cell(filaExcel, 10).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor1").ToString
                        hoja.Cell(filaExcel, 11).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor2").ToString
                        hoja.Cell(filaExcel, 12).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor3").ToString
                        hoja.Cell(filaExcel, 13).Value = dsReporte.Tables("Tabla").Rows(x)("cantidadpromotor4").ToString
                        hoja.Cell(filaExcel, 14).Value = dsReporte.Tables("Tabla").Rows(x)("rcliente").ToString
                        hoja.Cell(filaExcel, 15).Value = dsReporte.Tables("Tabla").Rows(x)("11").ToString
                        hoja.Cell(filaExcel, 16).Value = dsReporte.Tables("Tabla").Rows(x)("12").ToString
                        hoja.Cell(filaExcel, 17).Value = dsReporte.Tables("Tabla").Rows(x)("sumar").ToString
                        hoja.Cell(filaExcel, 18).Value = dsReporte.Tables("Tabla").Rows(x)("utilidad").ToString





                        filaExcel = filaExcel + 1

                    Next


                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Flujos NO cob al 100% " & dtpfechainicio.Value.ToString.Replace("/", "-").Substring(1, 10) & " a " & dtpfechafin.Value.ToString.Replace("/", "-").Substring(1, 10)
                    dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                    dialogo.ShowDialog()
                    libro.SaveAs(dialogo.FileName)
                    'libro.SaveAs("c:\temp\control.xlsx")
                    'libro.SaveAs(dialogo.FileName)
                    'apExcel.Quit()
                    libro = Nothing

                    'MessageBox.Show("Número de facturas encontradas:" & rwFilas.Count & " Número de facturas procesadas: " & encontradas & ". Proceso terminado correctamente" & vbCrLf & "Clientes no procesados:" & vbCrLf & nombreclientes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("Proceso terminado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception



        End Try
    End Sub
End Class