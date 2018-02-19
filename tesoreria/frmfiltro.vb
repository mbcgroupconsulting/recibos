Imports ClosedXML.Excel

Public Class frmfiltro
    Private Sub cmdgenerar_Click(sender As Object, e As EventArgs) Handles cmdgenerar.Click

        'Dim apExcel = New Microsoft.Office.Interop.Excel.Application
        'Dim libro = apExcel.Workbooks.Add
        'Dim dialogo As New SaveFileDialog()
        Dim idFacturaNomina As Long
        Dim SQL As String, Alter As Boolean = False
        Dim aID As String()
        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim iniciorango As Integer
        Dim finrango As Integer
        Dim numfacturas As Integer
        Dim numpatronas As Integer
        Dim contadorfacturas As Integer
        Dim numfacturastotales As Integer
        Dim xx As Integer
        Dim tipofecha As String

        Alter = True
        Try
            If (tiempo.Days >= 0) Then

                If rdbfacturacion.Checked Then
                    tipofecha = "fechafac"
                Else
                    tipofecha = "fechapago"
                End If



                SQL = "Select iIdFacturasNomina, FacturasNomina.fkiIdEmpresa,empresa.nombre As nombreempresa  ,FacturasNomina.fkiIdcliente, "
                SQL &= "clientes.nombre As nombrecliente,clientes.fkiIdPromotor,FacturasNomina.fkiIdTipoperiodo,  tipos_periodos2.nombre as tipoperiodo,"
                SQL &= "FacturasNomina.fechapago, DetNominaFactura.numfactura as nfactura, facturas.numfactura , DetNominaFactura.importe, DetNominaFactura.iva, DetNominaFactura.total,"
                SQL &= "FacturasNomina.dispersa, FacturasNomina.porsa, FacturasNomina.comisionsa, FacturasNomina.porsindicato,"
                SQL &= "FacturasNomina.comisionsin,FacturasNomina.dispersindicato,FacturasNomina.costosocial,FacturasNomina.retencion,fechafac,"
                SQL &= " empresa1.nombre as empresafactura,clientes1.nombre as clientefactura"
                SQL &= " from (((((((FacturasNomina inner Join empresa on FacturasNomina.fkiIdEmpresa= empresa.iIdEmpresa) "
                SQL &= " inner Join clientes On FacturasNomina.fkiIdcliente =  clientes.iIdCliente )"
                SQL &= " inner join tipos_periodos2 on FacturasNomina.fkiIdTipoperiodo = tipos_periodos2.iIdTipoperiodo2)"
                SQL &= " inner join InterFacturasNomina on FacturasNomina.iIdFacturasNomina= InterFacturasNomina.fkiIdFacturasNomina)"
                SQL &= " inner join DetNominaFactura on InterFacturasNomina.fkiIdDetNominaFactura= DetNominaFactura.iIdDetNominaFactura)"
                SQL &= " inner join facturas on facturas.iIdFactura= DetNominaFactura.fkiIdFactura)"
                SQL &= " inner join empresa as empresa1 on facturas.fkiIdEmpresa = empresa1.iIdEmpresa)"
                SQL &= " inner join clientes as clientes1 on facturas.fkiIdcliente= clientes1.iIdCliente where"
                If rdbintermediaria.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 2 and"
                ElseIf rdbiva.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 3 and"
                ElseIf rdbpatrona.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 1 and"
                End If



                If rdbpagadas.Checked = True Then
                    SQL &= " facturas.color=2 and"
                ElseIf rdbnopagadas.Checked = True Then
                    SQL &= " facturas.color<>2 and"
                End If


                SQL &= " " & tipofecha & " between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 and FacturasNomina.iEstatus=1"

                'Solo por empresa
                'SQL &= " and empresa1.iIdEmpresa = 28"
                SQL &= " order by fkiIdPromotor,iIdFacturasNomina"


                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("Q").Width = 35
                    hoja.Column("R").Width = 35
                    hoja.Column("S").Width = 13
                    hoja.Column("T").Width = 40
                    hoja.Column("U").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString()
                    hoja.Cell(3, 2).Value = "CONTROL TESORERIA"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 2, 4, 21).Style.Font.FontSize = 10
                    hoja.Range(4, 2, 4, 21).Style.Font.SetBold(True)
                    hoja.Range(4, 2, 4, 21).Style.Alignment.WrapText = True
                    hoja.Range(4, 2, 4, 21).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 21).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 2, 4, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 2, 4, 21).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Fecha"
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"
                    hoja.Cell(4, 9).Value = "Dispersion SA"
                    hoja.Cell(4, 10).Value = "% SA"
                    hoja.Cell(4, 11).Value = "Comisión SA"
                    hoja.Cell(4, 12).Value = "Dispersion Sindicato"
                    hoja.Cell(4, 13).Value = "% Sindicato"
                    hoja.Cell(4, 14).Value = "Comisión Sindicato"
                    hoja.Cell(4, 15).Value = "Costo Social"
                    hoja.Cell(4, 16).Value = "Retención imss"
                    hoja.Cell(4, 17).Value = "Cliente Nomina"
                    hoja.Cell(4, 18).Value = "Empresa patrona"
                    hoja.Cell(4, 19).Value = "Periodo"
                    hoja.Cell(4, 20).Value = "Promotor"
                    hoja.Cell(4, 21).Value = "Fecha Nomina"

                    filaExcel = 5
                    contadorfacturas = 1
                    For x As Integer = 0 To rwFilas.Count - 1

                        'filaExcel = filaExcel + 1

                        iniciorango = filaExcel

                        SQL = "select count (Distinct(iIdFacturasNomina)) as numpatronas from (DetNominaFactura inner join"
                        SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                        SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & ")"

                        Dim rwIdPatronas As DataRow() = nConsulta(SQL)
                        If rwIdPatronas Is Nothing = False Then
                            Dim FilaP As DataRow = rwIdPatronas(0)
                            numpatronas = FilaP.Item("numpatronas")
                        Else
                            Exit Sub
                        End If

                        SQL = "select count (Distinct(iIdDetNominaFactura)) as numfacturas from ((DetNominaFactura inner join"
                        SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina)"
                        SQL &= " inner join Facturas on DetnominaFactura.fkiIdFactura = Facturas.iIdFactura"
                        SQL &= " where  (iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & "))"
                        SQL &= " and facturas.fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"

                        If rdbpagadas.Checked Then
                            SQL &= " and facturas.color=2"
                        ElseIf rdbnopagadas.Checked Then
                            SQL &= " and facturas.color<>2"
                        End If


                        'SQL = "select count (Distinct(iIdDetNominaFactura)) as numfacturas from (DetNominaFactura inner join"
                        'SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                        'SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                        'SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        'SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        'SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & ")"

                        Dim rwNumFacturas As DataRow() = nConsulta(SQL)
                        If rwNumFacturas Is Nothing = False Then
                            Dim FilaF As DataRow = rwNumFacturas(0)
                            numfacturas = FilaF.Item("numfacturas")
                        Else
                            Exit Sub
                        End If



                        SQL = "select Distinct(iIdFacturasNomina) from (DetNominaFactura inner join"
                        SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                        SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & ")"

                        Dim rwPatronas As DataRow() = nConsulta(SQL)
                        If rwPatronas Is Nothing = False Then

                        Else
                            Exit Sub
                        End If


                        SQL = "select Distinct(Facturas.iIdFactura) as facturas from ((DetNominaFactura inner join"
                        SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina)"
                        SQL &= " inner join Facturas on DetnominaFactura.fkiIdFactura = Facturas.iIdFactura"
                        SQL &= " where  (iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & "))"
                        SQL &= " and facturas.fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                        If rdbpagadas.Checked Then
                            SQL &= " and facturas.color=2"
                        ElseIf rdbnopagadas.Checked Then
                            SQL &= " and facturas.color<>2"
                        End If

                        Dim rwFacturas As DataRow() = nConsulta(SQL)
                        If rwFacturas Is Nothing = False Then

                        Else
                            Exit Sub
                        End If


                        If numpatronas > numfacturas Then
                            numfacturastotales = numpatronas * numfacturas
                            xx = 0
                            For y As Integer = 0 To numpatronas - 1
                                SQL = "select dispersa,porsa,comisionsa,dispersindicato,FacturasNomina.porsindicato,comisionsin,fechapago,"
                                SQL &= "costosocial,retencion, clientes.nombre as nombrecliente, fkiIdPromotor,"
                                SQL &= "empresa.nombre as nombreempresa,tipos_periodos2.nombre as tipoperiodo from ((FacturasNomina"
                                SQL &= " inner join clientes on fkiIdCliente = iIdCliente)"
                                SQL &= " inner join empresa on fkiIdEmpresa = iIdEmpresa)"
                                SQL &= " inner join tipos_periodos2 on fkiIdTipoperiodo = iIdTipoperiodo2"
                                SQL &= " where  iIdFacturasNomina =" & rwPatronas(y).Item("iIdFacturasNomina")
                                Dim rwDatos As DataRow() = nConsulta(SQL)

                                If rwDatos Is Nothing = False Then
                                    hoja.Cell(filaExcel, 9).Value = rwDatos(0).Item("dispersa")
                                    hoja.Cell(filaExcel, 10).Value = rwDatos(0).Item("porsa")
                                    hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("comisionsa")
                                    hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("dispersindicato")
                                    hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("porsindicato")
                                    hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("comisionsin")
                                    hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("costosocial")
                                    hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("retencion")
                                    hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("nombrecliente")
                                    hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("nombreempresa")
                                    hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("tipoperiodo")

                                    aID = rwDatos(0).Item("fkiIdPromotor").Split(",")
                                    If aID.Length = 1 Then
                                        promotor = obtenerpromotor(aID(0))

                                    ElseIf aID.Length = 2 Then
                                        promotor = obtenerpromotor(aID(0))
                                        promotor &= "," & obtenerpromotor(aID(1))

                                    ElseIf aID.Length = 3 Then
                                        promotor = obtenerpromotor(aID(0))
                                        promotor &= "," & obtenerpromotor(aID(1))
                                        promotor &= "," & obtenerpromotor(aID(2))
                                    End If

                                    hoja.Cell(filaExcel, 20).Value = promotor

                                    hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("fechapago")
                                End If

                                If (numpatronas - numfacturas + 1) <= contadorfacturas Then

                                    SQL = "select iIdFactura,fecha,numfactura,importe, iva, total,"
                                    SQL &= " empresa.nombre as empresafactura,clientes.nombre as clientefactura"
                                    SQL &= " from (facturas inner join empresa on facturas.fkiIdEmpresa=Empresa.iIdEmpresa)"
                                    SQL &= " inner join clientes on facturas.fkiIdCliente=clientes.iIdCliente"
                                    SQL &= " where facturas.iIdFactura=" & rwFacturas(xx).Item("facturas")

                                    Dim rwDFacturas As DataRow() = nConsulta(SQL)

                                    If rwDFacturas Is Nothing = False Then
                                        hoja.Cell(filaExcel, 2).Value = rwDFacturas(0).Item("fecha")
                                        hoja.Cell(filaExcel, 3).Value = rwDFacturas(0).Item("clientefactura")
                                        hoja.Cell(filaExcel, 4).Value = rwDFacturas(0).Item("empresafactura")
                                        hoja.Cell(filaExcel, 5).Value = rwDFacturas(0).Item("numfactura")
                                        hoja.Cell(filaExcel, 6).Value = rwDFacturas(0).Item("importe")
                                        hoja.Cell(filaExcel, 7).Value = rwDFacturas(0).Item("iva")
                                        hoja.Cell(filaExcel, 8).Value = rwDFacturas(0).Item("total")

                                        xx = xx + 1
                                    End If


                                End If

                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next
                            'MessageBox.Show("Existen mas patronas que facturas en la factura:" & rwFilas(x).Item("numfactura") & ", se omitira en el reporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)


                            finrango = filaExcel - 1
                            If Alter Then
                                hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            End If
                            Alter = Not Alter


                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)

                        Else
                            numfacturastotales = numpatronas * numfacturas
                            xx = 0

                            For y As Integer = 0 To numfacturas - 1
                                hoja.Cell(filaExcel, 2).Value = rwFilas(x + y).Item("fechafac")
                                hoja.Cell(filaExcel, 3).Value = rwFilas(x + y).Item("clientefactura")
                                hoja.Cell(filaExcel, 4).Value = rwFilas(x + y).Item("empresafactura")
                                hoja.Cell(filaExcel, 5).Value = rwFilas(x + y).Item("numfactura")
                                hoja.Cell(filaExcel, 6).Value = rwFilas(x + y).Item("importe")
                                hoja.Cell(filaExcel, 7).Value = rwFilas(x + y).Item("iva")
                                hoja.Cell(filaExcel, 8).Value = rwFilas(x + y).Item("total")

                                If (numfacturas - numpatronas + 1) <= contadorfacturas Then

                                    'buscamos las facturas, son las patronas

                                    SQL = "select dispersa,porsa,comisionsa,dispersindicato,FacturasNomina.porsindicato,comisionsin,fechapago,"
                                    SQL &= "costosocial,retencion, clientes.nombre as nombrecliente, fkiIdPromotor,"
                                    SQL &= "empresa.nombre as nombreempresa,tipos_periodos2.nombre as tipoperiodo from ((FacturasNomina"
                                    SQL &= " inner join clientes on fkiIdCliente = iIdCliente)"
                                    SQL &= " inner join empresa on fkiIdEmpresa = iIdEmpresa)"
                                    SQL &= " inner join tipos_periodos2 on fkiIdTipoperiodo = iIdTipoperiodo2"
                                    SQL &= " where  iIdFacturasNomina =" & rwPatronas(xx).Item("iIdFacturasNomina")
                                    Dim rwDatos As DataRow() = nConsulta(SQL)

                                    If rwDatos Is Nothing = False Then
                                        hoja.Cell(filaExcel, 9).Value = rwDatos(0).Item("dispersa")
                                        hoja.Cell(filaExcel, 10).Value = rwDatos(0).Item("porsa")
                                        hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("comisionsa")
                                        hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("dispersindicato")
                                        hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("porsindicato")
                                        hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("comisionsin")
                                        hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("costosocial")
                                        hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("retencion")
                                        hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("nombrecliente")
                                        hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("nombreempresa")
                                        hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("tipoperiodo")

                                        aID = rwDatos(0).Item("fkiIdPromotor").Split(",")
                                        If aID.Length = 1 Then
                                            promotor = obtenerpromotor(aID(0))

                                        ElseIf aID.Length = 2 Then
                                            promotor = obtenerpromotor(aID(0))
                                            promotor &= "," & obtenerpromotor(aID(1))

                                        ElseIf aID.Length = 3 Then
                                            promotor = obtenerpromotor(aID(0))
                                            promotor &= "," & obtenerpromotor(aID(1))
                                            promotor &= "," & obtenerpromotor(aID(2))
                                        End If

                                        hoja.Cell(filaExcel, 20).Value = promotor

                                        hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("fechapago")
                                    End If
                                    xx = xx + 1





                                End If


                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next

                            finrango = filaExcel - 1
                            If Alter Then
                                hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            End If
                            Alter = Not Alter


                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)
                        End If



                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Control Informativo"
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try








    End Sub

    Private Function obtenerpromotor(id As String) As String
        Dim Sql As String
        Dim nombre As String = ""

        Try
            Sql = "select * from promotor where iIdPromotor= " & id
            Dim rwFilas As DataRow() = nConsulta(Sql)
            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombre = (Fila.Item("nombrecom"))

            End If

        Catch ex As Exception

        End Try
        Return nombre
    End Function

    Private Sub frmfiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarPlaza()
    End Sub

    Private Sub MostrarPlaza()
        Dim sql As String
        sql = "Select * from CatPlaza"
        nCargaCBO(cboplaza, sql, "nombre", "iIdPlaza")
    End Sub

    Private Sub grbfechas_Enter(sender As Object, e As EventArgs) Handles grbfechas.Enter

    End Sub

    Private Sub cmdFacturas_Click(sender As Object, e As EventArgs) Handles cmdFacturas.Click

        Dim SQL As String, Alter As Boolean = False

        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim contadorfacturas As Integer


        Alter = True
        Try
            If (tiempo.Days >= 0) Then





                SQL = "Select iIdFactura,fecha,facturas.numfactura,facturas.importe,facturas.iva,facturas.total,"
                SQL &= " pagoabono, comentario, comentario2, empresa.nombrefiscal, clientes.nombre "
                SQL &= " from((facturas "
                SQL &= " Left Join"
                SQL &= " (Select * from DetNominaFactura where DetNominaFactura.iEstatus=1) as"
                SQL &= " DetNominaFactura on facturas.iIdFactura= DetNominaFactura.fkiIdFactura)"
                SQL &= " inner Join empresa on facturas.fkiIdEmpresa=empresa.iIdEmpresa)"
                SQL &= " inner Join clientes on facturas.fkiIdCliente= clientes.iIdCliente"
                SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 and facturas.cancelada=1 "
                SQL &= " And empresa.fkiIdTipoEmpresa=2 "
                SQL &= " And fkiIdFactura Is NULL"
                SQL &= " order by empresa.nombrefiscal, fecha"




                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Faltantes")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("Q").Width = 35
                    hoja.Column("R").Width = 35
                    hoja.Column("S").Width = 13
                    hoja.Column("T").Width = 40
                    hoja.Column("U").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "Facturas que no estan en el control tesoreria"

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
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"



                    filaExcel = 5
                    contadorfacturas = 1
                    For x As Integer = 0 To rwFilas.Count - 1
                        hoja.Cell(filaExcel + x, 2).Value = rwFilas(x).Item("fecha")
                        hoja.Cell(filaExcel + x, 3).Value = rwFilas(x).Item("nombre")
                        hoja.Cell(filaExcel + x, 4).Value = rwFilas(x).Item("nombrefiscal")
                        hoja.Cell(filaExcel + x, 5).Value = rwFilas(x).Item("numfactura")
                        hoja.Cell(filaExcel + x, 6).Value = rwFilas(x).Item("importe")
                        hoja.Cell(filaExcel + x, 7).Value = rwFilas(x).Item("iva")
                        hoja.Cell(filaExcel + x, 8).Value = rwFilas(x).Item("total")


                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Facturas faltantes"
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try





    End Sub

    Private Sub cmdduplicadas_Click(sender As Object, e As EventArgs) Handles cmdduplicadas.Click

        Dim SQL As String, Alter As Boolean = False
        Dim aID As String()
        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim iniciorango As Integer
        Dim finrango As Integer




        Alter = True
        Try
            If (tiempo.Days >= 0) Then




                SQL = "Select iIdFacturasNomina, FacturasNomina.fkiIdEmpresa,empresa.nombre As nombreempresa,"
                SQL &= "FacturasNomina.fkiIdcliente, clientes.nombre As nombrecliente,clientes.fkiIdPromotor,"
                SQL &= "FacturasNomina.fkiIdTipoperiodo,tipos_periodos2.nombre as tipoperiodo,FacturasNomina.fechapago,"
                SQL &= "DetNominaFactura.numfactura as nfactura, facturas.numfactura , DetNominaFactura.importe,"
                SQL &= "DetNominaFactura.iva, DetNominaFactura.total,FacturasNomina.dispersa, FacturasNomina.porsa,"
                SQL &= "FacturasNomina.comisionsa, FacturasNomina.porsindicato,FacturasNomina.comisionsin,"
                SQL &= "FacturasNomina.dispersindicato,FacturasNomina.costosocial,FacturasNomina.retencion,"
                SQL &= "fechafac, empresa1.nombre as empresafactura,clientes1.nombre as clientefactura"
                SQL &= " from (((((((FacturasNomina"
                SQL &= " inner Join empresa on FacturasNomina.fkiIdEmpresa= empresa.iIdEmpresa)"
                SQL &= " inner Join clientes On FacturasNomina.fkiIdcliente =  clientes.iIdCliente )"
                SQL &= " inner join tipos_periodos2 on FacturasNomina.fkiIdTipoperiodo = tipos_periodos2.iIdTipoperiodo2)"
                SQL &= " inner join InterFacturasNomina on FacturasNomina.iIdFacturasNomina= InterFacturasNomina.fkiIdFacturasNomina)"
                SQL &= " inner join DetNominaFactura on InterFacturasNomina.fkiIdDetNominaFactura= DetNominaFactura.iIdDetNominaFactura)"
                SQL &= " inner join (select count(iIdFactura) as numrepeticion,facturas.numfactura, facturas.iIdFactura"
                SQL &= " From facturas "
                SQL &= " inner join detNominaFactura on iIdFactura=fkiIdFactura"
                SQL &= " where detNominaFactura.iEstatus=1"
                SQL &= " group by iIdFactura,facturas.numfactura,facturas.iIdFactura) as facturas"
                SQL &= " On facturas.iIdFactura= DetNominaFactura.fkiIdFactura)"
                SQL &= " inner join empresa as empresa1 on DetNominaFactura.fkiIdEmpresa = empresa1.iIdEmpresa) "
                SQL &= " inner join clientes as clientes1 on DetNominaFactura.fkiIdcliente= clientes1.iIdCliente "
                SQL &= " where fechafac between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                SQL &= " and  FacturasNomina.iEstatus=1 and numrepeticion>1"
                SQL &= " order by empresa1.nombre,facturas.numfactura"








                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Duplicados")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("Q").Width = 35
                    hoja.Column("R").Width = 35
                    hoja.Column("S").Width = 13
                    hoja.Column("T").Width = 40
                    hoja.Column("U").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "CONTROL TESORERIA DUPLICADOS"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 2, 4, 21).Style.Font.FontSize = 10
                    hoja.Range(4, 2, 4, 21).Style.Font.SetBold(True)
                    hoja.Range(4, 2, 4, 21).Style.Alignment.WrapText = True
                    hoja.Range(4, 2, 4, 21).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 21).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 2, 4, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 2, 4, 21).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Fecha"
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"
                    hoja.Cell(4, 9).Value = "Dispersion SA"
                    hoja.Cell(4, 10).Value = "% SA"
                    hoja.Cell(4, 11).Value = "Comisión SA"
                    hoja.Cell(4, 12).Value = "Dispersion Sindicato"
                    hoja.Cell(4, 13).Value = "% Sindicato"
                    hoja.Cell(4, 14).Value = "Comisión Sindicato"
                    hoja.Cell(4, 15).Value = "Costo Social"
                    hoja.Cell(4, 16).Value = "Retención imss"
                    hoja.Cell(4, 17).Value = "Cliente Nomina"
                    hoja.Cell(4, 18).Value = "Empresa patrona"
                    hoja.Cell(4, 19).Value = "Periodo"
                    hoja.Cell(4, 20).Value = "Promotor"
                    hoja.Cell(4, 21).Value = "Fecha Nomina"

                    filaExcel = 5

                    For x As Integer = 0 To rwFilas.Count - 1

                        'filaExcel = filaExcel + 1

                        hoja.Cell(filaExcel, 9).Value = rwFilas(x).Item("dispersa")
                        hoja.Cell(filaExcel, 10).Value = rwFilas(x).Item("porsa")
                        hoja.Cell(filaExcel, 11).Value = rwFilas(x).Item("comisionsa")
                        hoja.Cell(filaExcel, 12).Value = rwFilas(x).Item("dispersindicato")
                        hoja.Cell(filaExcel, 13).Value = rwFilas(x).Item("porsindicato")
                        hoja.Cell(filaExcel, 14).Value = rwFilas(x).Item("comisionsin")
                        hoja.Cell(filaExcel, 15).Value = rwFilas(x).Item("costosocial")
                        hoja.Cell(filaExcel, 16).Value = rwFilas(x).Item("retencion")
                        hoja.Cell(filaExcel, 17).Value = rwFilas(x).Item("nombrecliente")
                        hoja.Cell(filaExcel, 18).Value = rwFilas(x).Item("nombreempresa")
                        hoja.Cell(filaExcel, 19).Value = rwFilas(x).Item("tipoperiodo")

                        aID = rwFilas(x).Item("fkiIdPromotor").Split(",")
                        If aID.Length = 1 Then
                            promotor = obtenerpromotor(aID(0))

                        ElseIf aID.Length = 2 Then
                            promotor = obtenerpromotor(aID(0))
                            promotor &= "," & obtenerpromotor(aID(1))

                        ElseIf aID.Length = 3 Then
                            promotor = obtenerpromotor(aID(0))
                            promotor &= "," & obtenerpromotor(aID(1))
                            promotor &= "," & obtenerpromotor(aID(2))

                        End If

                        hoja.Cell(filaExcel, 20).Value = promotor
                        hoja.Cell(filaExcel, 21).Value = rwFilas(x).Item("fechapago")
                        hoja.Cell(filaExcel, 2).Value = rwFilas(x).Item("fechafac")
                        hoja.Cell(filaExcel, 3).Value = rwFilas(x).Item("clientefactura")
                        hoja.Cell(filaExcel, 4).Value = rwFilas(x).Item("empresafactura")
                        hoja.Cell(filaExcel, 5).Value = rwFilas(x).Item("numfactura")
                        hoja.Cell(filaExcel, 6).Value = rwFilas(x).Item("importe")
                        hoja.Cell(filaExcel, 7).Value = rwFilas(x).Item("iva")
                        hoja.Cell(filaExcel, 8).Value = rwFilas(x).Item("total")
                        filaExcel = filaExcel + 1
                    Next

                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Facturas duplicadas en el control"
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try








    End Sub

    Private Sub cmdabonos_Click(sender As Object, e As EventArgs) Handles cmdabonos.Click
        'Dim apExcel = New Microsoft.Office.Interop.Excel.Application
        'Dim libro = apExcel.Workbooks.Add
        'Dim dialogo As New SaveFileDialog()
        Dim idFacturaNomina As Long
        Dim SQL As String, Alter As Boolean = False
        Dim aID As String()
        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim iniciorango As Integer
        Dim finrango As Integer
        Dim numfacturas As Integer
        Dim numpatronas As Integer
        Dim contadorfacturas As Integer
        Dim numfacturastotales As Integer
        Dim xx As Integer
        Dim tipofecha As String

        Alter = True
        Try
            If (tiempo.Days >= 0) Then

                If rdbfacturacion.Checked Then
                    tipofecha = "fechafac"
                Else
                    tipofecha = "fechapago"
                End If



                SQL = "Select iIdFacturasNomina, FacturasNomina.fkiIdEmpresa,empresa.nombre As nombreempresa  ,FacturasNomina.fkiIdcliente, "
                SQL &= "clientes.nombre As nombrecliente,clientes.fkiIdPromotor,FacturasNomina.fkiIdTipoperiodo,  tipos_periodos2.nombre as tipoperiodo,"
                SQL &= "FacturasNomina.fechapago, DetNominaFactura.numfactura as nfactura, facturas.numfactura , DetNominaFactura.importe, DetNominaFactura.iva, DetNominaFactura.total,"
                SQL &= "FacturasNomina.dispersa, FacturasNomina.porsa, FacturasNomina.comisionsa, FacturasNomina.porsindicato,"
                SQL &= "FacturasNomina.comisionsin,FacturasNomina.dispersindicato,FacturasNomina.costosocial,FacturasNomina.retencion,fechafac,"
                SQL &= " empresa1.nombre as empresafactura,clientes1.nombre as clientefactura, importemes, importetotalfactura "
                SQL &= " from ((((((((FacturasNomina inner Join empresa on FacturasNomina.fkiIdEmpresa= empresa.iIdEmpresa) "
                SQL &= " inner Join clientes On FacturasNomina.fkiIdcliente =  clientes.iIdCliente )"
                SQL &= " inner join tipos_periodos2 on FacturasNomina.fkiIdTipoperiodo = tipos_periodos2.iIdTipoperiodo2)"
                SQL &= " inner join InterFacturasNomina on FacturasNomina.iIdFacturasNomina= InterFacturasNomina.fkiIdFacturasNomina)"
                SQL &= " inner join DetNominaFactura on InterFacturasNomina.fkiIdDetNominaFactura= DetNominaFactura.iIdDetNominaFactura)"
                SQL &= " inner join facturas on facturas.iIdFactura= DetNominaFactura.fkiIdFactura)"
                SQL &= " inner join (select parcial.fkiIdFactura, parcial.importemes,sum(importe) as importetotalfactura from pagos "
                SQL &= " inner join (select fkiIdFactura, sum(importe) as importemes"
                SQL &= " from pagos"
                SQL &= " where fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                SQL &= " group by fkiIdFactura, importe) as parcial on parcial.fkiIdFactura = pagos.fkiIdFactura"
                SQL &= " group by importe,parcial.fkiIdFactura, parcial.importemes) as pagos on facturas.iIdFactura=pagos.fkiIdFactura )"
                SQL &= " inner join empresa as empresa1 on facturas.fkiIdEmpresa = empresa1.iIdEmpresa)"
                SQL &= " inner join clientes as clientes1 on facturas.fkiIdcliente= clientes1.iIdCliente where"
                If rdbintermediaria.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 2 and"
                ElseIf rdbiva.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 3 and"
                ElseIf rdbpatrona.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 1 and"
                End If



                'If rdbpagadas.Checked = True Then
                '    SQL &= " facturas.color=2 and"
                'ElseIf rdbnopagadas.Checked = True Then
                '    SQL &= " facturas.color<>2 and"
                'End If


                'SQL &= " " & tipofecha & " between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 and FacturasNomina.iEstatus=1"

                SQL &= " facturas.iEstatus=1 and FacturasNomina.iEstatus=1"
                'Solo por empresa
                'SQL &= " and empresa1.iIdEmpresa = 28"
                SQL &= " order by fkiIdPromotor,fechacaptura,iIdFacturasNomina"
                'SQL &= " order by iIdFacturasNomina"

                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("S").Width = 35
                    hoja.Column("T").Width = 35
                    hoja.Column("U").Width = 13
                    hoja.Column("V").Width = 40
                    hoja.Column("W").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "CONTROL TESORERIA"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 2, 4, 23).Style.Font.FontSize = 10
                    hoja.Range(4, 2, 4, 23).Style.Font.SetBold(True)
                    hoja.Range(4, 2, 4, 23).Style.Alignment.WrapText = True
                    hoja.Range(4, 2, 4, 23).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 23).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 2, 4, 23).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 2, 4, 23).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Fecha"
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"
                    hoja.Cell(4, 9).Value = "Abono Rango Fechas"
                    hoja.Cell(4, 10).Value = "Abono Total"
                    hoja.Cell(4, 11).Value = "Dispersion SA"
                    hoja.Cell(4, 12).Value = "% SA"
                    hoja.Cell(4, 13).Value = "Comisión SA"
                    hoja.Cell(4, 14).Value = "Dispersion Sindicato"
                    hoja.Cell(4, 15).Value = "% Sindicato"
                    hoja.Cell(4, 16).Value = "Comisión Sindicato"
                    hoja.Cell(4, 17).Value = "Costo Social"
                    hoja.Cell(4, 18).Value = "Retención imss"
                    hoja.Cell(4, 19).Value = "Cliente Nomina"
                    hoja.Cell(4, 20).Value = "Empresa patrona"
                    hoja.Cell(4, 21).Value = "Periodo"
                    hoja.Cell(4, 22).Value = "Promotor"
                    hoja.Cell(4, 23).Value = "Fecha Nomina"

                    filaExcel = 5
                    contadorfacturas = 1
                    For x As Integer = 0 To rwFilas.Count - 1

                        'filaExcel = filaExcel + 1

                        iniciorango = filaExcel

                        'If rwFilas(x).Item("iIdFacturasNomina") = "5655" Then 'Or rwFilas(x).Item("iIdFacturasNomina") = "831" Or rwFilas(x).Item("iIdFacturasNomina") = "833" Then
                        '    MessageBox.Show(rwFilas(x).Item("iIdFacturasNomina"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'End If

                        SQL = "Select count (Distinct(iIdFacturasNomina)) As numpatronas from (DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura= fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                        SQL &= " where  iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & ")"

                        Dim rwIdPatronas As DataRow() = nConsulta(SQL)
                        If rwIdPatronas Is Nothing = False Then
                            Dim FilaP As DataRow = rwIdPatronas(0)
                            numpatronas = FilaP.Item("numpatronas")
                        Else
                            Exit Sub
                        End If

                        SQL = "Select count (Distinct(iIdDetNominaFactura)) As numfacturas from ((DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina)"
                        SQL &= " inner join Facturas On DetnominaFactura.fkiIdFactura = Facturas.iIdFactura"
                        SQL &= " where  (iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & "))"
                        SQL &= " And facturas.iEstatus=1"

                        'If rdbpagadas.Checked Then
                        '    SQL &= " And facturas.color=2"
                        'ElseIf rdbnopagadas.Checked Then
                        '    SQL &= " And facturas.color<>2"
                        'End If




                        Dim rwNumFacturas As DataRow() = nConsulta(SQL)
                        If rwNumFacturas Is Nothing = False Then
                            Dim FilaF As DataRow = rwNumFacturas(0)
                            numfacturas = FilaF.Item("numfacturas")
                        Else
                            Exit Sub
                        End If



                        SQL = "Select Distinct(iIdFacturasNomina) from (DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                        SQL &= " where  iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & ")"

                        Dim rwPatronas As DataRow() = nConsulta(SQL)
                        If rwPatronas Is Nothing = False Then

                        Else
                            Exit Sub
                        End If


                        SQL = "Select Distinct(Facturas.iIdFactura) As facturas from ((DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina)"
                        SQL &= " inner join Facturas On DetnominaFactura.fkiIdFactura = Facturas.iIdFactura"
                        SQL &= " where  (iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & "))"
                        SQL &= " And facturas.iEstatus=1"
                        'SQL &= " And facturas.fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                        'If rdbpagadas.Checked Then
                        '    SQL &= " and facturas.color=2"
                        'ElseIf rdbnopagadas.Checked Then
                        '    SQL &= " and facturas.color<>2"
                        'End If

                        Dim rwFacturas As DataRow() = nConsulta(SQL)
                        If rwFacturas Is Nothing = False Then

                        Else
                            Exit Sub
                        End If


                        If numpatronas > numfacturas Then
                            numfacturastotales = numpatronas * numfacturas
                            xx = 0
                            For y As Integer = 0 To numpatronas - 1
                                SQL = "select dispersa,porsa,comisionsa,dispersindicato,FacturasNomina.porsindicato,comisionsin,fechapago,"
                                SQL &= "costosocial,retencion, clientes.nombre as nombrecliente, fkiIdPromotor,"
                                SQL &= "empresa.nombre as nombreempresa,tipos_periodos2.nombre as tipoperiodo from ((FacturasNomina"
                                SQL &= " inner join clientes on fkiIdCliente = iIdCliente)"
                                SQL &= " inner join empresa on fkiIdEmpresa = iIdEmpresa)"
                                SQL &= " inner join tipos_periodos2 on fkiIdTipoperiodo = iIdTipoperiodo2"
                                SQL &= " where  iIdFacturasNomina =" & rwPatronas(y).Item("iIdFacturasNomina")
                                Dim rwDatos As DataRow() = nConsulta(SQL)

                                If rwDatos Is Nothing = False Then
                                    hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("dispersa")
                                    hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("porsa")
                                    hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("comisionsa")
                                    hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("dispersindicato")
                                    hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("porsindicato")
                                    hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("comisionsin")
                                    hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("costosocial")
                                    hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("retencion")
                                    hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("nombrecliente")
                                    hoja.Cell(filaExcel, 20).Value = rwDatos(0).Item("nombreempresa")
                                    hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("tipoperiodo")

                                    aID = rwDatos(0).Item("fkiIdPromotor").Split(",")
                                    If aID.Length = 1 Then
                                        promotor = obtenerpromotor(aID(0))

                                    ElseIf aID.Length = 2 Then
                                        promotor = obtenerpromotor(aID(0))
                                        promotor &= "," & obtenerpromotor(aID(1))

                                    ElseIf aID.Length = 3 Then
                                        promotor = obtenerpromotor(aID(0))
                                        promotor &= "," & obtenerpromotor(aID(1))
                                        promotor &= "," & obtenerpromotor(aID(2))
                                    End If

                                    hoja.Cell(filaExcel, 22).Value = promotor

                                    hoja.Cell(filaExcel, 23).Value = rwDatos(0).Item("fechapago")
                                End If

                                If (numpatronas - numfacturas + 1) <= contadorfacturas Then

                                    SQL = "select iIdFactura,fecha,numfactura,importe, iva, total,importemes,importetotalfactura,"
                                    SQL &= " empresa.nombre as empresafactura,clientes.nombre as clientefactura"
                                    SQL &= " from ((facturas"
                                    SQL &= " inner join"
                                    SQL &= " (select parcial.fkiIdFactura, parcial.importemes,sum(importe) as importetotalfactura from pagos"
                                    SQL &= " inner join (select fkiIdFactura, sum(importe) as importemes"
                                    SQL &= " from pagos where fkiIdFactura=" & rwFacturas(xx).Item("facturas")
                                    SQL &= " group by fkiIdFactura, importe) as parcial on parcial.fkiIdFactura = pagos.fkiIdFactura"
                                    SQL &= " group by importe,parcial.fkiIdFactura, parcial.importemes) as pagos on facturas.iIdFactura= pagos.fkiIdFactura)"
                                    SQL &= " inner join empresa on facturas.fkiIdEmpresa=Empresa.iIdEmpresa)"
                                    SQL &= " inner join clientes on facturas.fkiIdCliente=clientes.iIdCliente"
                                    SQL &= " where facturas.iIdFactura=" & rwFacturas(xx).Item("facturas")

                                    Dim rwDFacturas As DataRow() = nConsulta(SQL)

                                    If rwDFacturas Is Nothing = False Then
                                        hoja.Cell(filaExcel, 2).Value = rwDFacturas(0).Item("fecha")
                                        hoja.Cell(filaExcel, 3).Value = rwDFacturas(0).Item("clientefactura")
                                        hoja.Cell(filaExcel, 4).Value = rwDFacturas(0).Item("empresafactura")
                                        hoja.Cell(filaExcel, 5).Value = rwDFacturas(0).Item("numfactura")
                                        hoja.Cell(filaExcel, 6).Value = rwDFacturas(0).Item("importe")
                                        hoja.Cell(filaExcel, 7).Value = rwDFacturas(0).Item("iva")
                                        hoja.Cell(filaExcel, 8).Value = rwDFacturas(0).Item("total")
                                        hoja.Cell(filaExcel, 9).Value = rwFilas(x + y).Item("importemes")
                                        hoja.Cell(filaExcel, 10).Value = rwFilas(x + y).Item("importetotalfactura")
                                        xx = xx + 1
                                    End If


                                End If

                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next
                            'MessageBox.Show("Existen mas patronas que facturas en la factura:" & rwFilas(x).Item("numfactura") & ", se omitira en el reporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)


                            finrango = filaExcel - 1
                            If Alter Then
                                hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            End If
                            Alter = Not Alter


                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)

                        Else
                            numfacturastotales = numpatronas * numfacturas
                            xx = 0

                            For y As Integer = 0 To numfacturas - 1
                                hoja.Cell(filaExcel, 2).Value = rwFilas(x + y).Item("fechafac")
                                hoja.Cell(filaExcel, 3).Value = rwFilas(x + y).Item("clientefactura")
                                hoja.Cell(filaExcel, 4).Value = rwFilas(x + y).Item("empresafactura")
                                hoja.Cell(filaExcel, 5).Value = rwFilas(x + y).Item("numfactura")
                                hoja.Cell(filaExcel, 6).Value = rwFilas(x + y).Item("importe")
                                hoja.Cell(filaExcel, 7).Value = rwFilas(x + y).Item("iva")
                                hoja.Cell(filaExcel, 8).Value = rwFilas(x + y).Item("total")
                                hoja.Cell(filaExcel, 9).Value = rwFilas(x + y).Item("importemes")
                                hoja.Cell(filaExcel, 10).Value = rwFilas(x + y).Item("importetotalfactura")

                                If (numfacturas - numpatronas + 1) <= contadorfacturas Then

                                    'buscamos las facturas, son las patronas

                                    SQL = "select dispersa,porsa,comisionsa,dispersindicato,FacturasNomina.porsindicato,comisionsin,fechapago,"
                                    SQL &= "costosocial,retencion, clientes.nombre as nombrecliente, fkiIdPromotor,"
                                    SQL &= "empresa.nombre as nombreempresa,tipos_periodos2.nombre as tipoperiodo from ((FacturasNomina"
                                    SQL &= " inner join clientes on fkiIdCliente = iIdCliente)"
                                    SQL &= " inner join empresa on fkiIdEmpresa = iIdEmpresa)"
                                    SQL &= " inner join tipos_periodos2 on fkiIdTipoperiodo = iIdTipoperiodo2"
                                    SQL &= " where  iIdFacturasNomina =" & rwPatronas(xx).Item("iIdFacturasNomina")
                                    Dim rwDatos As DataRow() = nConsulta(SQL)

                                    If rwDatos Is Nothing = False Then
                                        hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("dispersa")
                                        hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("porsa")
                                        hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("comisionsa")
                                        hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("dispersindicato")
                                        hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("porsindicato")
                                        hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("comisionsin")
                                        hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("costosocial")
                                        hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("retencion")
                                        hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("nombrecliente")
                                        hoja.Cell(filaExcel, 20).Value = rwDatos(0).Item("nombreempresa")
                                        hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("tipoperiodo")

                                        aID = rwDatos(0).Item("fkiIdPromotor").Split(",")
                                        If aID.Length = 1 Then
                                            promotor = obtenerpromotor(aID(0))

                                        ElseIf aID.Length = 2 Then
                                            promotor = obtenerpromotor(aID(0))
                                            promotor &= "," & obtenerpromotor(aID(1))

                                        ElseIf aID.Length = 3 Then
                                            promotor = obtenerpromotor(aID(0))
                                            promotor &= "," & obtenerpromotor(aID(1))
                                            promotor &= "," & obtenerpromotor(aID(2))
                                        End If

                                        hoja.Cell(filaExcel, 22).Value = promotor

                                        hoja.Cell(filaExcel, 23).Value = rwDatos(0).Item("fechapago")
                                    End If
                                    xx = xx + 1





                                End If


                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next

                            finrango = filaExcel - 1
                            If Alter Then
                                hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            End If
                            Alter = Not Alter


                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)
                        End If



                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Control tesoreria abonos"
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdfacturasabonos_Click(sender As Object, e As EventArgs) Handles cmdfacturasabonos.Click
        Dim SQL As String, Alter As Boolean = False

        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim contadorfacturas As Integer


        Alter = True
        Try
            If (tiempo.Days >= 0) Then





                SQL = "Select iIdFactura,fecha,facturas.numfactura,facturas.importe,facturas.iva,facturas.total,"
                SQL &= " pagoabono, comentario, comentario2, empresa.nombrefiscal, clientes.nombre "
                SQL &= " from(((DetNominaFactura left join pagos on detnominafactura.fkiIdFactura=pagos.fkiIdFactura)"
                SQL &= " inner Join facturas on facturas.iIdFactura= DetNominaFactura.fkiIdFactura)"
                SQL &= " inner Join empresa on facturas.fkiIdEmpresa=empresa.iIdEmpresa)"
                SQL &= " inner Join clientes on facturas.fkiIdCliente= clientes.iIdCliente"
                SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 "
                SQL &= "  And facturas.cancelada=1  And DetNominaFactura.iEstatus=1"
                SQL &= " And pagos.iIdPago Is NULL"
                SQL &= " order by empresa.nombrefiscal, fecha"





                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Faltantes")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("Q").Width = 35
                    hoja.Column("R").Width = 35
                    hoja.Column("S").Width = 13
                    hoja.Column("T").Width = 40
                    hoja.Column("U").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "Facturas que estan en el control tesoreria pero no tienen ningun abono"

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
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"



                    filaExcel = 5
                    contadorfacturas = 1
                    For x As Integer = 0 To rwFilas.Count - 1
                        hoja.Cell(filaExcel + x, 2).Value = rwFilas(x).Item("fecha")
                        hoja.Cell(filaExcel + x, 3).Value = rwFilas(x).Item("nombre")
                        hoja.Cell(filaExcel + x, 4).Value = rwFilas(x).Item("nombrefiscal")
                        hoja.Cell(filaExcel + x, 5).Value = rwFilas(x).Item("numfactura")
                        hoja.Cell(filaExcel + x, 6).Value = rwFilas(x).Item("importe")
                        hoja.Cell(filaExcel + x, 7).Value = rwFilas(x).Item("iva")
                        hoja.Cell(filaExcel + x, 8).Value = rwFilas(x).Item("total")


                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Facturas en el control tesoreria pero sin abonos"
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try




    End Sub

    Private Sub cmdsinabonos_Click(sender As Object, e As EventArgs) Handles cmdsinabonos.Click
        Dim SQL As String, Alter As Boolean = False

        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim contadorfacturas As Integer


        Alter = True
        Try
            If (tiempo.Days >= 0) Then





                SQL = "Select iIdFactura,fecha,facturas.numfactura,facturas.importe,facturas.iva,facturas.total,"
                SQL &= " pagoabono, comentario, comentario2, empresa.nombrefiscal, clientes.nombre "
                SQL &= " from((Facturas left join pagos on Facturas.iIdFactura=pagos.fkiIdFactura)"
                SQL &= " inner Join empresa on facturas.fkiIdEmpresa=empresa.iIdEmpresa) "
                SQL &= " inner Join clientes on facturas.fkiIdCliente= clientes.iIdCliente"
                SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 "
                SQL &= "  And facturas.cancelada=1  And pagos.iIdPago Is NULL and facturas.tipofactura=0"
                SQL &= " order by empresa.nombrefiscal, fecha"





                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Facturas sin abonos")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("Q").Width = 35
                    hoja.Column("R").Width = 35
                    hoja.Column("S").Width = 13
                    hoja.Column("T").Width = 40
                    hoja.Column("U").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "Facturas que no tienen ningun abono"

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
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"



                    filaExcel = 5
                    contadorfacturas = 1
                    For x As Integer = 0 To rwFilas.Count - 1
                        hoja.Cell(filaExcel + x, 2).Value = rwFilas(x).Item("fecha")
                        hoja.Cell(filaExcel + x, 3).Value = rwFilas(x).Item("nombre")
                        hoja.Cell(filaExcel + x, 4).Value = rwFilas(x).Item("nombrefiscal")
                        hoja.Cell(filaExcel + x, 5).Value = rwFilas(x).Item("numfactura")
                        hoja.Cell(filaExcel + x, 6).Value = rwFilas(x).Item("importe")
                        hoja.Cell(filaExcel + x, 7).Value = rwFilas(x).Item("iva")
                        hoja.Cell(filaExcel + x, 8).Value = rwFilas(x).Item("total")


                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Facturas sin abonos"
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdabonosmas_Click(sender As Object, e As EventArgs) Handles cmdabonosmas.Click
        Dim SQL As String, Alter As Boolean = False

        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim contadorfacturas As Integer


        Alter = True
        Try
            If (tiempo.Days >= 0) Then





                SQL = "Select iIdFactura,fecha,facturas.numfactura,facturas.importe,facturas.iva,facturas.total,"
                SQL &= " pagoabono, comentario, comentario2, empresa.nombrefiscal, clientes.nombre "
                SQL &= " from ((Facturas "
                SQL &= " inner join (select fkiidfactura, sum(importe) as monto from pagos where iEstatus=1 group by fkiidfactura ) as pagos "
                SQL &= " on Facturas.iIdFactura=pagos.fkiIdFactura)"
                SQL &= " inner Join empresa on facturas.fkiIdEmpresa=empresa.iIdEmpresa)  "
                SQL &= " inner Join clientes on facturas.fkiIdCliente= clientes.iIdCliente "
                SQL &= " where monto>total and facturas.iEstatus=1 and facturas.cancelada=1"
                SQL &= " order by fecha,empresa.nombrefiscal"





                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Abonos mayores al total")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("Q").Width = 35
                    hoja.Column("R").Width = 35
                    hoja.Column("S").Width = 13
                    hoja.Column("T").Width = 40
                    hoja.Column("U").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "Facturas con abonos mayores al total"

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
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"



                    filaExcel = 5
                    contadorfacturas = 1
                    For x As Integer = 0 To rwFilas.Count - 1
                        hoja.Cell(filaExcel + x, 2).Value = rwFilas(x).Item("fecha")
                        hoja.Cell(filaExcel + x, 3).Value = rwFilas(x).Item("nombre")
                        hoja.Cell(filaExcel + x, 4).Value = rwFilas(x).Item("nombrefiscal")
                        hoja.Cell(filaExcel + x, 5).Value = rwFilas(x).Item("numfactura")
                        hoja.Cell(filaExcel + x, 6).Value = rwFilas(x).Item("importe")
                        hoja.Cell(filaExcel + x, 7).Value = rwFilas(x).Item("iva")
                        hoja.Cell(filaExcel + x, 8).Value = rwFilas(x).Item("total")


                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Facturas con abonos mayores al total"
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdabonos2_Click(sender As Object, e As EventArgs) Handles cmdabonos2.Click
        'Dim apExcel = New Microsoft.Office.Interop.Excel.Application
        'Dim libro = apExcel.Workbooks.Add
        'Dim dialogo As New SaveFileDialog()
        Dim idFacturaNomina As Long
        Dim SQL As String, Alter As Boolean = False
        Dim aID As String()
        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        Dim iniciorango As Integer
        Dim finrango As Integer
        Dim numfacturas As Integer
        Dim numpatronas As Integer
        Dim contadorfacturas As Integer
        Dim numfacturastotales As Integer
        Dim xx As Integer
        Dim tipofecha As String

        Alter = True
        Try
            If (tiempo.Days >= 0) Then

                If rdbfacturacion.Checked Then
                    tipofecha = "fechafac"
                Else
                    tipofecha = "fechapago"
                End If



                SQL = "Select iIdFacturasNomina, FacturasNomina.fkiIdEmpresa,empresa.nombre As nombreempresa  ,FacturasNomina.fkiIdcliente, "
                SQL &= "clientes.nombre As nombrecliente,clientes.fkiIdPromotor,FacturasNomina.fkiIdTipoperiodo,  tipos_periodos2.nombre as tipoperiodo,"
                SQL &= "FacturasNomina.fechapago, DetNominaFactura.numfactura as nfactura, facturas.numfactura , DetNominaFactura.importe, DetNominaFactura.iva, DetNominaFactura.total,"
                SQL &= "FacturasNomina.dispersa, FacturasNomina.porsa, FacturasNomina.comisionsa, FacturasNomina.porsindicato,"
                SQL &= "FacturasNomina.comisionsin,FacturasNomina.dispersindicato,FacturasNomina.costosocial,FacturasNomina.retencion,fechafac,"
                SQL &= " empresa1.nombre as empresafactura,clientes1.nombre as clientefactura, isnull(importemes,0) as importemes, isnull( importetotalfactura,0) as importetotalfactura   "
                SQL &= " from ((((((((FacturasNomina inner Join empresa on FacturasNomina.fkiIdEmpresa= empresa.iIdEmpresa) "
                SQL &= " inner Join clientes On FacturasNomina.fkiIdcliente =  clientes.iIdCliente )"
                SQL &= " inner join tipos_periodos2 on FacturasNomina.fkiIdTipoperiodo = tipos_periodos2.iIdTipoperiodo2)"
                SQL &= " inner join InterFacturasNomina on FacturasNomina.iIdFacturasNomina= InterFacturasNomina.fkiIdFacturasNomina)"
                SQL &= " inner join DetNominaFactura on InterFacturasNomina.fkiIdDetNominaFactura= DetNominaFactura.iIdDetNominaFactura)"
                SQL &= " inner join facturas on facturas.iIdFactura= DetNominaFactura.fkiIdFactura)"
                SQL &= " full join (select parcial.fkiIdFactura, parcial.importemes,sum(importe) as importetotalfactura from pagos "
                SQL &= " inner join (select fkiIdFactura, sum(importe) as importemes"
                SQL &= " from pagos"
                SQL &= " where fechaingreso between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and pagos.iEstatus=1"
                SQL &= " group by fkiIdFactura) as parcial on parcial.fkiIdFactura = pagos.fkiIdFactura"
                SQL &= " where pagos.iEstatus=1"
                SQL &= " group by parcial.fkiIdFactura, parcial.importemes) as pagos on facturas.iIdFactura=pagos.fkiIdFactura )"
                SQL &= " inner join empresa as empresa1 on facturas.fkiIdEmpresa = empresa1.iIdEmpresa)"
                SQL &= " inner join clientes as clientes1 on facturas.fkiIdcliente= clientes1.iIdCliente where"
                If rdbintermediaria.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 2 and"
                ElseIf rdbiva.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 3 and"
                ElseIf rdbpatrona.Checked Then
                    SQL &= " empresa1.fkiIdTipoEmpresa= 1 and"
                End If



                'If rdbpagadas.Checked = True Then
                '    SQL &= " facturas.color=2 and"
                'ElseIf rdbnopagadas.Checked = True Then
                '    SQL &= " facturas.color<>2 and"
                'End If


                'SQL &= " " & tipofecha & " between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 and FacturasNomina.iEstatus=1"

                SQL &= " facturas.iEstatus=1 and FacturasNomina.iEstatus=1 and facturas.fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
                'Solo por empresa
                'SQL &= " and empresa1.iIdEmpresa = 28"

                If chkplazas.Checked Then
                    SQL &= " and clientes.iTipo=" & cboplaza.SelectedValue
                End If

                SQL &= " order by fkiIdPromotor,fechacaptura,iIdFacturasNomina"
                'SQL &= " order by iIdFacturasNomina"

                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")

                    hoja.Column("B").Width = 13
                    hoja.Column("C").Width = 30
                    hoja.Column("D").Width = 30
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
                    hoja.Column("S").Width = 35
                    hoja.Column("T").Width = 35
                    hoja.Column("U").Width = 13
                    hoja.Column("V").Width = 40
                    hoja.Column("W").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "CONTROL TESORERIA"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 2, 4, 23).Style.Font.FontSize = 10
                    hoja.Range(4, 2, 4, 23).Style.Font.SetBold(True)
                    hoja.Range(4, 2, 4, 23).Style.Alignment.WrapText = True
                    hoja.Range(4, 2, 4, 23).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 23).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 2, 4, 23).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 2, 4, 23).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Fecha"
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Cell(4, 8).Value = "Total"
                    hoja.Cell(4, 9).Value = "Abono Rango Fechas"
                    hoja.Cell(4, 10).Value = "Abono Total"
                    hoja.Cell(4, 11).Value = "Dispersion SA"
                    hoja.Cell(4, 12).Value = "% SA"
                    hoja.Cell(4, 13).Value = "Comisión SA"
                    hoja.Cell(4, 14).Value = "Dispersion Sindicato"
                    hoja.Cell(4, 15).Value = "% Sindicato"
                    hoja.Cell(4, 16).Value = "Comisión Sindicato"
                    hoja.Cell(4, 17).Value = "Costo Social"
                    hoja.Cell(4, 18).Value = "Retención imss"
                    hoja.Cell(4, 19).Value = "Cliente Nomina"
                    hoja.Cell(4, 20).Value = "Empresa patrona"
                    hoja.Cell(4, 21).Value = "Periodo"
                    hoja.Cell(4, 22).Value = "Promotor"
                    hoja.Cell(4, 23).Value = "Fecha Nomina"

                    filaExcel = 5
                    contadorfacturas = 1
                    For x As Integer = 0 To rwFilas.Count - 1

                        'filaExcel = filaExcel + 1

                        iniciorango = filaExcel

                        'If rwFilas(x).Item("iIdFacturasNomina") = "5655" Then 'Or rwFilas(x).Item("iIdFacturasNomina") = "831" Or rwFilas(x).Item("iIdFacturasNomina") = "833" Then
                        '    MessageBox.Show(rwFilas(x).Item("iIdFacturasNomina"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'End If

                        SQL = "Select count (Distinct(iIdFacturasNomina)) As numpatronas from (DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura= fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                        SQL &= " where  iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & ")"

                        Dim rwIdPatronas As DataRow() = nConsulta(SQL)
                        If rwIdPatronas Is Nothing = False Then
                            Dim FilaP As DataRow = rwIdPatronas(0)
                            numpatronas = FilaP.Item("numpatronas")
                        Else
                            Exit Sub
                        End If

                        SQL = "Select count (Distinct(iIdDetNominaFactura)) As numfacturas from ((DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina)"
                        SQL &= " inner join Facturas On DetnominaFactura.fkiIdFactura = Facturas.iIdFactura"
                        SQL &= " where  (iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & "))"
                        SQL &= " And facturas.iEstatus=1"

                        'If rdbpagadas.Checked Then
                        '    SQL &= " And facturas.color=2"
                        'ElseIf rdbnopagadas.Checked Then
                        '    SQL &= " And facturas.color<>2"
                        'End If




                        Dim rwNumFacturas As DataRow() = nConsulta(SQL)
                        If rwNumFacturas Is Nothing = False Then
                            Dim FilaF As DataRow = rwNumFacturas(0)
                            numfacturas = FilaF.Item("numfacturas")
                        Else
                            Exit Sub
                        End If



                        SQL = "Select Distinct(iIdFacturasNomina) from (DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                        SQL &= " where  iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & ")"

                        Dim rwPatronas As DataRow() = nConsulta(SQL)
                        If rwPatronas Is Nothing = False Then

                        Else
                            Exit Sub
                        End If


                        SQL = "Select Distinct(Facturas.iIdFactura) As facturas from ((DetNominaFactura inner join"
                        SQL &= " interfacturasnomina On iIdDetnominafactura=fkiidDetNominaFactura)"
                        SQL &= " inner Join FacturasNomina On  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina)"
                        SQL &= " inner join Facturas On DetnominaFactura.fkiIdFactura = Facturas.iIdFactura"
                        SQL &= " where  (iIdDetNominaFactura In (Select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                        SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                        SQL &= " where  iIdFacturasNomina =" & rwFilas(x).Item("iIdFacturasNomina") & "))"
                        SQL &= " And facturas.iEstatus=1"
                        'SQL &= " And facturas.fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1"
                        'If rdbpagadas.Checked Then
                        '    SQL &= " and facturas.color=2"
                        'ElseIf rdbnopagadas.Checked Then
                        '    SQL &= " and facturas.color<>2"
                        'End If

                        Dim rwFacturas As DataRow() = nConsulta(SQL)
                        If rwFacturas Is Nothing = False Then

                        Else
                            Exit Sub
                        End If


                        If numpatronas > numfacturas Then
                            numfacturastotales = numpatronas * numfacturas
                            xx = 0
                            For y As Integer = 0 To numpatronas - 1
                                SQL = "select dispersa,porsa,comisionsa,dispersindicato,FacturasNomina.porsindicato,comisionsin,fechapago,"
                                SQL &= "costosocial,retencion, clientes.nombre as nombrecliente, fkiIdPromotor,"
                                SQL &= "empresa.nombre as nombreempresa,tipos_periodos2.nombre as tipoperiodo from ((FacturasNomina"
                                SQL &= " inner join clientes on fkiIdCliente = iIdCliente)"
                                SQL &= " inner join empresa on fkiIdEmpresa = iIdEmpresa)"
                                SQL &= " inner join tipos_periodos2 on fkiIdTipoperiodo = iIdTipoperiodo2"
                                SQL &= " where  iIdFacturasNomina =" & rwPatronas(y).Item("iIdFacturasNomina")
                                Dim rwDatos As DataRow() = nConsulta(SQL)

                                If rwDatos Is Nothing = False Then
                                    hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("dispersa")
                                    hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("porsa")
                                    hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("comisionsa")
                                    hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("dispersindicato")
                                    hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("porsindicato")
                                    hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("comisionsin")
                                    hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("costosocial")
                                    hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("retencion")
                                    hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("nombrecliente")
                                    hoja.Cell(filaExcel, 20).Value = rwDatos(0).Item("nombreempresa")
                                    hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("tipoperiodo")

                                    aID = rwDatos(0).Item("fkiIdPromotor").Split(",")
                                    If aID.Length = 1 Then
                                        promotor = obtenerpromotor(aID(0))

                                    ElseIf aID.Length = 2 Then
                                        promotor = obtenerpromotor(aID(0))
                                        promotor &= "," & obtenerpromotor(aID(1))

                                    ElseIf aID.Length = 3 Then
                                        promotor = obtenerpromotor(aID(0))
                                        promotor &= "," & obtenerpromotor(aID(1))
                                        promotor &= "," & obtenerpromotor(aID(2))
                                    End If

                                    hoja.Cell(filaExcel, 22).Value = promotor

                                    hoja.Cell(filaExcel, 23).Value = rwDatos(0).Item("fechapago")
                                End If

                                If (numpatronas - numfacturas + 1) <= contadorfacturas Then

                                    SQL = "select iIdFactura,fecha,numfactura,importe, iva, total,importemes,importetotalfactura,"
                                    SQL &= " empresa.nombre as empresafactura,clientes.nombre as clientefactura"
                                    SQL &= " from ((facturas"
                                    SQL &= " inner join"
                                    SQL &= " (select parcial.fkiIdFactura, parcial.importemes,sum(importe) as importetotalfactura from pagos"
                                    SQL &= " inner join (select fkiIdFactura, sum(importe) as importemes"
                                    SQL &= " from pagos where fkiIdFactura=" & rwFacturas(xx).Item("facturas")
                                    SQL &= " group by fkiIdFactura, importe) as parcial on parcial.fkiIdFactura = pagos.fkiIdFactura"
                                    SQL &= " group by importe,parcial.fkiIdFactura, parcial.importemes) as pagos on facturas.iIdFactura= pagos.fkiIdFactura)"
                                    SQL &= " inner join empresa on facturas.fkiIdEmpresa=Empresa.iIdEmpresa)"
                                    SQL &= " inner join clientes on facturas.fkiIdCliente=clientes.iIdCliente"
                                    SQL &= " where facturas.iIdFactura=" & rwFacturas(xx).Item("facturas")

                                    Dim rwDFacturas As DataRow() = nConsulta(SQL)

                                    If rwDFacturas Is Nothing = False Then
                                        hoja.Cell(filaExcel, 2).Value = rwDFacturas(0).Item("fecha")
                                        hoja.Cell(filaExcel, 3).Value = rwDFacturas(0).Item("clientefactura")
                                        hoja.Cell(filaExcel, 4).Value = rwDFacturas(0).Item("empresafactura")
                                        hoja.Cell(filaExcel, 5).Value = rwDFacturas(0).Item("numfactura")
                                        hoja.Cell(filaExcel, 6).Value = rwDFacturas(0).Item("importe")
                                        hoja.Cell(filaExcel, 7).Value = rwDFacturas(0).Item("iva")
                                        hoja.Cell(filaExcel, 8).Value = rwDFacturas(0).Item("total")
                                        hoja.Cell(filaExcel, 9).Value = rwFilas(x + y).Item("importemes")
                                        hoja.Cell(filaExcel, 10).Value = rwFilas(x + y).Item("importetotalfactura")
                                        xx = xx + 1
                                    End If


                                End If

                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next
                            'MessageBox.Show("Existen mas patronas que facturas en la factura:" & rwFilas(x).Item("numfactura") & ", se omitira en el reporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)


                            finrango = filaExcel - 1
                            If Alter Then
                                hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            End If
                            Alter = Not Alter


                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)

                        Else
                            numfacturastotales = numpatronas * numfacturas
                            xx = 0

                            For y As Integer = 0 To numfacturas - 1
                                hoja.Cell(filaExcel, 2).Value = rwFilas(x + y).Item("fechafac")
                                hoja.Cell(filaExcel, 3).Value = rwFilas(x + y).Item("clientefactura")
                                hoja.Cell(filaExcel, 4).Value = rwFilas(x + y).Item("empresafactura")
                                hoja.Cell(filaExcel, 5).Value = rwFilas(x + y).Item("numfactura")
                                hoja.Cell(filaExcel, 6).Value = rwFilas(x + y).Item("importe")
                                hoja.Cell(filaExcel, 7).Value = rwFilas(x + y).Item("iva")
                                hoja.Cell(filaExcel, 8).Value = rwFilas(x + y).Item("total")
                                hoja.Cell(filaExcel, 9).Value = rwFilas(x + y).Item("importemes")
                                hoja.Cell(filaExcel, 10).Value = rwFilas(x + y).Item("importetotalfactura")

                                If (numfacturas - numpatronas + 1) <= contadorfacturas Then

                                    'buscamos las facturas, son las patronas

                                    SQL = "select dispersa,porsa,comisionsa,dispersindicato,FacturasNomina.porsindicato,comisionsin,fechapago,"
                                    SQL &= "costosocial,retencion, clientes.nombre as nombrecliente, fkiIdPromotor,"
                                    SQL &= "empresa.nombre as nombreempresa,tipos_periodos2.nombre as tipoperiodo from ((FacturasNomina"
                                    SQL &= " inner join clientes on fkiIdCliente = iIdCliente)"
                                    SQL &= " inner join empresa on fkiIdEmpresa = iIdEmpresa)"
                                    SQL &= " inner join tipos_periodos2 on fkiIdTipoperiodo = iIdTipoperiodo2"
                                    SQL &= " where  iIdFacturasNomina =" & rwPatronas(xx).Item("iIdFacturasNomina")
                                    Dim rwDatos As DataRow() = nConsulta(SQL)

                                    If rwDatos Is Nothing = False Then
                                        hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("dispersa")
                                        hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("porsa")
                                        hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("comisionsa")
                                        hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("dispersindicato")
                                        hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("porsindicato")
                                        hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("comisionsin")
                                        hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("costosocial")
                                        hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("retencion")
                                        hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("nombrecliente")
                                        hoja.Cell(filaExcel, 20).Value = rwDatos(0).Item("nombreempresa")
                                        hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("tipoperiodo")

                                        aID = rwDatos(0).Item("fkiIdPromotor").Split(",")
                                        If aID.Length = 1 Then
                                            promotor = obtenerpromotor(aID(0))

                                        ElseIf aID.Length = 2 Then
                                            promotor = obtenerpromotor(aID(0))
                                            promotor &= "," & obtenerpromotor(aID(1))

                                        ElseIf aID.Length = 3 Then
                                            promotor = obtenerpromotor(aID(0))
                                            promotor &= "," & obtenerpromotor(aID(1))
                                            promotor &= "," & obtenerpromotor(aID(2))
                                        End If

                                        hoja.Cell(filaExcel, 22).Value = promotor

                                        hoja.Cell(filaExcel, 23).Value = rwDatos(0).Item("fechapago")
                                    End If
                                    xx = xx + 1





                                End If


                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next

                            finrango = filaExcel - 1
                            If Alter Then
                                hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            End If
                            Alter = Not Alter


                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)
                        End If



                    Next




                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Control tesoreria abonos " & IIf(chkplazas.Checked, cboplaza.Text, "") & " " & MonthName(inicio.Month)
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
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkplazas_CheckedChanged(sender As Object, e As EventArgs) Handles chkplazas.CheckedChanged
        If chkplazas.Checked Then
            grbplazas.Enabled = True
        Else
            grbplazas.Enabled = False
        End If
    End Sub
End Class