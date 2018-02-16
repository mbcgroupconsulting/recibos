Imports ClosedXML.Excel
Public Class frmComisiones
    Private Sub cmdcomisiones_Click(sender As Object, e As EventArgs) Handles cmdcomisiones.Click
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
        Dim dsReporte As New DataSet
        Dim dsOrdenamiento As New DataSet
        Dim consecutivocontrol As Integer

        Alter = True
        Try
            If (tiempo.Days >= 0) Then





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
                SQL &= " inner join (select parcial.fkiIdFactura, parcial.importemes,sum(importe) as importetotalfactura from pagos "
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

                If rdbTodas.Checked Then
                    SQL &= " clientes.iTipo=" & cboplaza.SelectedValue & " and"
                Else
                    SQL &= " and clientes.iTipo=" & cboplaza.SelectedValue & " and"
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


                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then


                    dsReporte.Tables.Add("Tabla")
                    dsReporte.Tables("Tabla").Columns.Add("fecha")
                    dsReporte.Tables("Tabla").Columns.Add("iIdCliente")
                    dsReporte.Tables("Tabla").Columns.Add("cliente_factura")
                    dsReporte.Tables("Tabla").Columns.Add("empresa_factura")
                    dsReporte.Tables("Tabla").Columns.Add("num_factura")
                    dsReporte.Tables("Tabla").Columns.Add("subtotal")
                    dsReporte.Tables("Tabla").Columns.Add("iva")
                    dsReporte.Tables("Tabla").Columns.Add("total")
                    dsReporte.Tables("Tabla").Columns.Add("abono_rango")
                    dsReporte.Tables("Tabla").Columns.Add("abono_total")
                    dsReporte.Tables("Tabla").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Tabla").Columns.Add("porsa")
                    dsReporte.Tables("Tabla").Columns.Add("comisionsa")
                    dsReporte.Tables("Tabla").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Tabla").Columns.Add("porsin")
                    dsReporte.Tables("Tabla").Columns.Add("comisionsin")
                    dsReporte.Tables("Tabla").Columns.Add("costosocial")
                    dsReporte.Tables("Tabla").Columns.Add("retencionimss")
                    dsReporte.Tables("Tabla").Columns.Add("clientenomina")
                    dsReporte.Tables("Tabla").Columns.Add("empresapatrona")
                    dsReporte.Tables("Tabla").Columns.Add("periodo")
                    dsReporte.Tables("Tabla").Columns.Add("promotor")
                    dsReporte.Tables("Tabla").Columns.Add("fechanomina")
                    dsReporte.Tables("Tabla").Columns.Add("consecutivo")

                    filaExcel = 5
                    contadorfacturas = 1
                    consecutivocontrol = 1

                    For x As Integer = 0 To rwFilas.Count - 1

                        'filaExcel = filaExcel + 1

                        iniciorango = filaExcel

                        'If rwFilas(x).Item("iIdFacturasNomina") = "1384" Or rwFilas(x).Item("iIdFacturasNomina") = "831" Or rwFilas(x).Item("iIdFacturasNomina") = "833" Then
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

                                Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow



                                If rwDatos Is Nothing = False Then

                                    fila.Item("dispersion_sa") = rwDatos(0).Item("dispersa")
                                    fila.Item("porsa") = rwDatos(0).Item("porsa")
                                    fila.Item("comisionsa") = rwDatos(0).Item("comisionsa")
                                    fila.Item("dispersion_sin") = rwDatos(0).Item("dispersindicato")
                                    fila.Item("porsin") = rwDatos(0).Item("porsindicato")
                                    fila.Item("comisionsin") = rwDatos(0).Item("comisionsin")
                                    fila.Item("costosocial") = rwDatos(0).Item("costosocial")
                                    fila.Item("retencionimss") = rwDatos(0).Item("retencion")
                                    fila.Item("clientenomina") = rwDatos(0).Item("nombrecliente")
                                    fila.Item("empresapatrona") = rwDatos(0).Item("nombreempresa")
                                    fila.Item("periodo") = rwDatos(0).Item("tipoperiodo")

                                    'hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("dispersa")
                                    'hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("porsa")
                                    'hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("comisionsa")
                                    'hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("dispersindicato")
                                    'hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("porsindicato")
                                    'hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("comisionsin")
                                    'hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("costosocial")
                                    'hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("retencion")
                                    'hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("nombrecliente")
                                    'hoja.Cell(filaExcel, 20).Value = rwDatos(0).Item("nombreempresa")
                                    'hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("tipoperiodo")

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

                                    'hoja.Cell(filaExcel, 22).Value = promotor

                                    'hoja.Cell(filaExcel, 23).Value = rwDatos(0).Item("fechapago")

                                    fila.Item("promotor") = promotor
                                    fila.Item("fechanomina") = rwDatos(0).Item("fechapago")
                                    fila.Item("consecutivo") = consecutivocontrol
                                End If

                                If (numpatronas - numfacturas + 1) <= contadorfacturas Then

                                    SQL = "select iIdFactura,fecha,numfactura,importe, iva, total,importemes,importetotalfactura,facturas.fkiIdCliente,"
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

                                        fila.Item("fecha") = rwDFacturas(0).Item("fecha")
                                        fila.Item("iIdCliente") = rwDFacturas(0).Item("fkiIdCliente")
                                        fila.Item("cliente_factura") = rwDFacturas(0).Item("clientefactura")
                                        fila.Item("empresa_factura") = rwDFacturas(0).Item("empresafactura")
                                        fila.Item("num_factura") = rwDFacturas(0).Item("numfactura")
                                        fila.Item("subtotal") = rwDFacturas(0).Item("importe")
                                        fila.Item("iva") = rwDFacturas(0).Item("iva")
                                        fila.Item("total") = rwDFacturas(0).Item("total")
                                        fila.Item("abono_rango") = rwFilas(x + y).Item("importemes")
                                        fila.Item("abono_total") = rwFilas(x + y).Item("importetotalfactura")

                                        'hoja.Cell(filaExcel, 2).Value = rwDFacturas(0).Item("fecha")
                                        'hoja.Cell(filaExcel, 3).Value = rwDFacturas(0).Item("clientefactura")
                                        'hoja.Cell(filaExcel, 4).Value = rwDFacturas(0).Item("empresafactura")
                                        'hoja.Cell(filaExcel, 5).Value = rwDFacturas(0).Item("numfactura")
                                        'hoja.Cell(filaExcel, 6).Value = rwDFacturas(0).Item("importe")
                                        'hoja.Cell(filaExcel, 7).Value = rwDFacturas(0).Item("iva")
                                        'hoja.Cell(filaExcel, 8).Value = rwDFacturas(0).Item("total")
                                        'hoja.Cell(filaExcel, 9).Value = rwFilas(x + y).Item("importemes")
                                        'hoja.Cell(filaExcel, 10).Value = rwFilas(x + y).Item("importetotalfactura")
                                        xx = xx + 1

                                    End If

                                Else
                                    fila.Item("fecha") = ""
                                    fila.Item("iIdCliente") = ""
                                    fila.Item("cliente_factura") = ""
                                    fila.Item("empresa_factura") = ""
                                    fila.Item("num_factura") = ""
                                    fila.Item("subtotal") = ""
                                    fila.Item("iva") = ""
                                    fila.Item("total") = ""
                                    fila.Item("abono_rango") = ""
                                    fila.Item("abono_total") = ""
                                End If

                                dsReporte.Tables("Tabla").Rows.Add(fila)

                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next
                            'MessageBox.Show("Existen mas patronas que facturas en la factura:" & rwFilas(x).Item("numfactura") & ", se omitira en el reporte", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)


                            finrango = filaExcel - 1
                            'If Alter Then
                            '    hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            'End If
                            'Alter = Not Alter

                            consecutivocontrol = consecutivocontrol + 1

                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)

                        Else
                            numfacturastotales = numpatronas * numfacturas
                            xx = 0

                            For y As Integer = 0 To numfacturas - 1

                                Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow

                                fila.Item("fecha") = rwFilas(x + y).Item("fechafac")
                                fila.Item("iIdCliente") = rwFilas(x + y).Item("fkiIdcliente")
                                fila.Item("cliente_factura") = rwFilas(x + y).Item("clientefactura")
                                fila.Item("empresa_factura") = rwFilas(x + y).Item("empresafactura")
                                fila.Item("num_factura") = rwFilas(x + y).Item("numfactura")
                                fila.Item("subtotal") = rwFilas(x + y).Item("importe")
                                fila.Item("iva") = rwFilas(x + y).Item("iva")
                                fila.Item("total") = rwFilas(x + y).Item("total")
                                fila.Item("abono_rango") = rwFilas(x + y).Item("importemes")
                                fila.Item("abono_total") = rwFilas(x + y).Item("importetotalfactura")





                                'hoja.Cell(filaExcel, 2).Value = rwFilas(x + y).Item("fechafac")
                                'hoja.Cell(filaExcel, 3).Value = rwFilas(x + y).Item("clientefactura")
                                'hoja.Cell(filaExcel, 4).Value = rwFilas(x + y).Item("empresafactura")
                                'hoja.Cell(filaExcel, 5).Value = rwFilas(x + y).Item("numfactura")
                                'hoja.Cell(filaExcel, 6).Value = rwFilas(x + y).Item("importe")
                                'hoja.Cell(filaExcel, 7).Value = rwFilas(x + y).Item("iva")
                                'hoja.Cell(filaExcel, 8).Value = rwFilas(x + y).Item("total")
                                'hoja.Cell(filaExcel, 9).Value = rwFilas(x + y).Item("importemes")
                                'hoja.Cell(filaExcel, 10).Value = rwFilas(x + y).Item("importetotalfactura")

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

                                        fila.Item("dispersion_sa") = rwDatos(0).Item("dispersa")
                                        fila.Item("porsa") = rwDatos(0).Item("porsa")
                                        fila.Item("comisionsa") = rwDatos(0).Item("comisionsa")
                                        fila.Item("dispersion_sin") = rwDatos(0).Item("dispersindicato")
                                        fila.Item("porsin") = rwDatos(0).Item("porsindicato")
                                        fila.Item("comisionsin") = rwDatos(0).Item("comisionsin")
                                        fila.Item("costosocial") = rwDatos(0).Item("costosocial")
                                        fila.Item("retencionimss") = rwDatos(0).Item("retencion")
                                        fila.Item("clientenomina") = rwDatos(0).Item("nombrecliente")
                                        fila.Item("empresapatrona") = rwDatos(0).Item("nombreempresa")
                                        fila.Item("periodo") = rwDatos(0).Item("tipoperiodo")


                                        'hoja.Cell(filaExcel, 11).Value = rwDatos(0).Item("dispersa")
                                        'hoja.Cell(filaExcel, 12).Value = rwDatos(0).Item("porsa")
                                        'hoja.Cell(filaExcel, 13).Value = rwDatos(0).Item("comisionsa")
                                        'hoja.Cell(filaExcel, 14).Value = rwDatos(0).Item("dispersindicato")
                                        'hoja.Cell(filaExcel, 15).Value = rwDatos(0).Item("porsindicato")
                                        'hoja.Cell(filaExcel, 16).Value = rwDatos(0).Item("comisionsin")
                                        'hoja.Cell(filaExcel, 17).Value = rwDatos(0).Item("costosocial")
                                        'hoja.Cell(filaExcel, 18).Value = rwDatos(0).Item("retencion")
                                        'hoja.Cell(filaExcel, 19).Value = rwDatos(0).Item("nombrecliente")
                                        'hoja.Cell(filaExcel, 20).Value = rwDatos(0).Item("nombreempresa")
                                        'hoja.Cell(filaExcel, 21).Value = rwDatos(0).Item("tipoperiodo")

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

                                        'hoja.Cell(filaExcel, 22).Value = promotor

                                        'hoja.Cell(filaExcel, 23).Value = rwDatos(0).Item("fechapago")

                                        fila.Item("promotor") = promotor
                                        fila.Item("fechanomina") = rwDatos(0).Item("fechapago")
                                        fila.Item("consecutivo") = consecutivocontrol
                                    End If
                                    xx = xx + 1



                                Else
                                    'metemos los demas datos
                                    fila.Item("dispersion_sa") = ""
                                    fila.Item("porsa") = ""
                                    fila.Item("comisionsa") = ""
                                    fila.Item("dispersion_sin") = ""
                                    fila.Item("porsin") = ""
                                    fila.Item("comisionsin") = ""
                                    fila.Item("costosocial") = ""
                                    fila.Item("retencionimss") = ""
                                    fila.Item("clientenomina") = ""
                                    fila.Item("empresapatrona") = ""
                                    fila.Item("periodo") = ""
                                    fila.Item("promotor") = ""
                                    fila.Item("fechanomina") = ""
                                    fila.Item("consecutivo") = consecutivocontrol

                                End If

                                dsReporte.Tables("Tabla").Rows.Add(fila)

                                contadorfacturas = contadorfacturas + 1
                                filaExcel = filaExcel + 1
                            Next

                            finrango = filaExcel - 1
                            'If Alter Then
                            '    hoja.Range(iniciorango, 2, finrango, 21).Style.Fill.BackgroundColor = XLColor.FromHtml("#C5C5C5")
                            'End If
                            'Alter = Not Alter

                            consecutivocontrol = consecutivocontrol + 1
                            contadorfacturas = 1

                            x = x + (numfacturastotales - 1)
                        End If



                    Next

                    '#########################
                    '#####################
                    '#############
                    '#######
                    '####
                    '##
                    'Despues de generar el archivo empezamos a evaluar las comisiones

                    consecutivocontrol = 0
                    Dim encontradas As Integer = 0
                    Dim IVA As Double
                    Dim GADMON As Double
                    Dim REPARTIR As Double
                    Dim cantidadpro1 As Double
                    Dim cantidadpro2 As Double
                    Dim cantidadpro3 As Double
                    Dim cantidadprofijo As Double
                    Dim cantidadpromotorremanente As Double
                    Dim REPARTIROTRO As Double
                    Dim REPARTIRMBC As Double
                    Dim REPARTIRCOMISION As Double
                    Dim COMISIONSA As Double
                    Dim COMISIONSIN As Double
                    Dim COMISIONMBC As Double
                    Dim COMISIONPRO As Double
                    Dim CUATRO As Double
                    Dim RESTOCUATRO As Double
                    Dim REMANENTETOTAL As Double
                    Dim cantidadremanente As Double
                    Dim nombreclientes As String

                    dsReporte.Tables.Add("Promotor1")
                    dsReporte.Tables("Promotor1").Columns.Add("fecha")
                    dsReporte.Tables("Promotor1").Columns.Add("iIdCliente")
                    dsReporte.Tables("Promotor1").Columns.Add("cliente_factura")
                    dsReporte.Tables("Promotor1").Columns.Add("empresa_factura")
                    dsReporte.Tables("Promotor1").Columns.Add("num_factura")
                    dsReporte.Tables("Promotor1").Columns.Add("subtotal")
                    dsReporte.Tables("Promotor1").Columns.Add("iva")
                    dsReporte.Tables("Promotor1").Columns.Add("total")
                    dsReporte.Tables("Promotor1").Columns.Add("abono_rango")
                    dsReporte.Tables("Promotor1").Columns.Add("abono_total")
                    dsReporte.Tables("Promotor1").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Promotor1").Columns.Add("porsa")
                    dsReporte.Tables("Promotor1").Columns.Add("comisionsa")
                    dsReporte.Tables("Promotor1").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Promotor1").Columns.Add("porsin")
                    dsReporte.Tables("Promotor1").Columns.Add("comisionsin")
                    dsReporte.Tables("Promotor1").Columns.Add("costosocial")
                    dsReporte.Tables("Promotor1").Columns.Add("retencionimss")
                    dsReporte.Tables("Promotor1").Columns.Add("clientenomina")
                    dsReporte.Tables("Promotor1").Columns.Add("empresapatrona")
                    dsReporte.Tables("Promotor1").Columns.Add("periodo")
                    dsReporte.Tables("Promotor1").Columns.Add("promotor")
                    dsReporte.Tables("Promotor1").Columns.Add("fechanomina")
                    dsReporte.Tables("Promotor1").Columns.Add("poradmon")
                    dsReporte.Tables("Promotor1").Columns.Add("porrepartir")
                    dsReporte.Tables("Promotor1").Columns.Add("gadmon")
                    dsReporte.Tables("Promotor1").Columns.Add("cuatro")
                    dsReporte.Tables("Promotor1").Columns.Add("restoadmon")
                    dsReporte.Tables("Promotor1").Columns.Add("grepartir")
                    dsReporte.Tables("Promotor1").Columns.Add("nombre")
                    dsReporte.Tables("Promotor1").Columns.Add("porpromotor")
                    dsReporte.Tables("Promotor1").Columns.Add("cantidad")
                    dsReporte.Tables("Promotor1").Columns.Add("nombre2")
                    dsReporte.Tables("Promotor1").Columns.Add("porpromotor2")
                    dsReporte.Tables("Promotor1").Columns.Add("cantidad2")
                    dsReporte.Tables("Promotor1").Columns.Add("comisiontotal")
                    dsReporte.Tables("Promotor1").Columns.Add("comisionpromotor")
                    dsReporte.Tables("Promotor1").Columns.Add("comisionmbc")
                    dsReporte.Tables("Promotor1").Columns.Add("repartirmbc")
                    dsReporte.Tables("Promotor1").Columns.Add("nombre3")
                    dsReporte.Tables("Promotor1").Columns.Add("porpromotor3")
                    dsReporte.Tables("Promotor1").Columns.Add("cantidad3")
                    dsReporte.Tables("Promotor1").Columns.Add("NombrePromotor")
                    dsReporte.Tables("Promotor1").Columns.Add("totalf")
                    dsReporte.Tables("Promotor1").Columns.Add("tipo")
                    dsReporte.Tables("Promotor1").Columns.Add("idpromotor")

                    dsReporte.Tables.Add("Promotor2")
                    dsReporte.Tables("Promotor2").Columns.Add("fecha")
                    dsReporte.Tables("Promotor2").Columns.Add("iIdCliente")
                    dsReporte.Tables("Promotor2").Columns.Add("cliente_factura")
                    dsReporte.Tables("Promotor2").Columns.Add("empresa_factura")
                    dsReporte.Tables("Promotor2").Columns.Add("num_factura")
                    dsReporte.Tables("Promotor2").Columns.Add("subtotal")
                    dsReporte.Tables("Promotor2").Columns.Add("iva")
                    dsReporte.Tables("Promotor2").Columns.Add("total")
                    dsReporte.Tables("Promotor2").Columns.Add("abono_rango")
                    dsReporte.Tables("Promotor2").Columns.Add("abono_total")
                    dsReporte.Tables("Promotor2").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Promotor2").Columns.Add("porsa")
                    dsReporte.Tables("Promotor2").Columns.Add("comisionsa")
                    dsReporte.Tables("Promotor2").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Promotor2").Columns.Add("porsin")
                    dsReporte.Tables("Promotor2").Columns.Add("comisionsin")
                    dsReporte.Tables("Promotor2").Columns.Add("costosocial")
                    dsReporte.Tables("Promotor2").Columns.Add("retencionimss")
                    dsReporte.Tables("Promotor2").Columns.Add("clientenomina")
                    dsReporte.Tables("Promotor2").Columns.Add("empresapatrona")
                    dsReporte.Tables("Promotor2").Columns.Add("periodo")
                    dsReporte.Tables("Promotor2").Columns.Add("promotor")
                    dsReporte.Tables("Promotor2").Columns.Add("fechanomina")
                    dsReporte.Tables("Promotor2").Columns.Add("poradmon")
                    dsReporte.Tables("Promotor2").Columns.Add("porrepartir")
                    dsReporte.Tables("Promotor2").Columns.Add("gadmon")
                    dsReporte.Tables("Promotor2").Columns.Add("cuatro")
                    dsReporte.Tables("Promotor2").Columns.Add("restoadmon")
                    dsReporte.Tables("Promotor2").Columns.Add("grepartir")
                    dsReporte.Tables("Promotor2").Columns.Add("nombre")
                    dsReporte.Tables("Promotor2").Columns.Add("porpromotor")
                    dsReporte.Tables("Promotor2").Columns.Add("cantidad")
                    dsReporte.Tables("Promotor2").Columns.Add("nombre2")
                    dsReporte.Tables("Promotor2").Columns.Add("porpromotor2")
                    dsReporte.Tables("Promotor2").Columns.Add("cantidad2")
                    dsReporte.Tables("Promotor2").Columns.Add("comisiontotal")
                    dsReporte.Tables("Promotor2").Columns.Add("comisionpromotor")
                    dsReporte.Tables("Promotor2").Columns.Add("comisionmbc")
                    dsReporte.Tables("Promotor2").Columns.Add("repartirmbc")
                    dsReporte.Tables("Promotor2").Columns.Add("nombre3")
                    dsReporte.Tables("Promotor2").Columns.Add("porpromotor3")
                    dsReporte.Tables("Promotor2").Columns.Add("cantidad3")
                    dsReporte.Tables("Promotor2").Columns.Add("NombrePromotor")
                    dsReporte.Tables("Promotor2").Columns.Add("totalf")
                    dsReporte.Tables("Promotor2").Columns.Add("tipo")
                    dsReporte.Tables("Promotor2").Columns.Add("idpromotor")

                    dsReporte.Tables.Add("Promotor3")
                    dsReporte.Tables("Promotor3").Columns.Add("fecha")
                    dsReporte.Tables("Promotor3").Columns.Add("iIdCliente")
                    dsReporte.Tables("Promotor3").Columns.Add("cliente_factura")
                    dsReporte.Tables("Promotor3").Columns.Add("empresa_factura")
                    dsReporte.Tables("Promotor3").Columns.Add("num_factura")
                    dsReporte.Tables("Promotor3").Columns.Add("subtotal")
                    dsReporte.Tables("Promotor3").Columns.Add("iva")
                    dsReporte.Tables("Promotor3").Columns.Add("total")
                    dsReporte.Tables("Promotor3").Columns.Add("abono_rango")
                    dsReporte.Tables("Promotor3").Columns.Add("abono_total")
                    dsReporte.Tables("Promotor3").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Promotor3").Columns.Add("porsa")
                    dsReporte.Tables("Promotor3").Columns.Add("comisionsa")
                    dsReporte.Tables("Promotor3").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Promotor3").Columns.Add("porsin")
                    dsReporte.Tables("Promotor3").Columns.Add("comisionsin")
                    dsReporte.Tables("Promotor3").Columns.Add("costosocial")
                    dsReporte.Tables("Promotor3").Columns.Add("retencionimss")
                    dsReporte.Tables("Promotor3").Columns.Add("clientenomina")
                    dsReporte.Tables("Promotor3").Columns.Add("empresapatrona")
                    dsReporte.Tables("Promotor3").Columns.Add("periodo")
                    dsReporte.Tables("Promotor3").Columns.Add("promotor")
                    dsReporte.Tables("Promotor3").Columns.Add("fechanomina")
                    dsReporte.Tables("Promotor3").Columns.Add("poradmon")
                    dsReporte.Tables("Promotor3").Columns.Add("porrepartir")
                    dsReporte.Tables("Promotor3").Columns.Add("gadmon")
                    dsReporte.Tables("Promotor3").Columns.Add("cuatro")
                    dsReporte.Tables("Promotor3").Columns.Add("restoadmon")
                    dsReporte.Tables("Promotor3").Columns.Add("grepartir")
                    dsReporte.Tables("Promotor3").Columns.Add("nombre")
                    dsReporte.Tables("Promotor3").Columns.Add("porpromotor")
                    dsReporte.Tables("Promotor3").Columns.Add("cantidad")
                    dsReporte.Tables("Promotor3").Columns.Add("nombre2")
                    dsReporte.Tables("Promotor3").Columns.Add("porpromotor2")
                    dsReporte.Tables("Promotor3").Columns.Add("cantidad2")
                    dsReporte.Tables("Promotor3").Columns.Add("comisiontotal")
                    dsReporte.Tables("Promotor3").Columns.Add("comisionpromotor")
                    dsReporte.Tables("Promotor3").Columns.Add("comisionmbc")
                    dsReporte.Tables("Promotor3").Columns.Add("repartirmbc")
                    dsReporte.Tables("Promotor3").Columns.Add("nombre3")
                    dsReporte.Tables("Promotor3").Columns.Add("porpromotor3")
                    dsReporte.Tables("Promotor3").Columns.Add("cantidad3")
                    dsReporte.Tables("Promotor3").Columns.Add("NombrePromotor")
                    dsReporte.Tables("Promotor3").Columns.Add("totalf")
                    dsReporte.Tables("Promotor3").Columns.Add("tipo")
                    dsReporte.Tables("Promotor3").Columns.Add("idpromotor")

                    dsReporte.Tables.Add("Promotor4")
                    dsReporte.Tables("Promotor4").Columns.Add("fecha")
                    dsReporte.Tables("Promotor4").Columns.Add("iIdCliente")
                    dsReporte.Tables("Promotor4").Columns.Add("cliente_factura")
                    dsReporte.Tables("Promotor4").Columns.Add("empresa_factura")
                    dsReporte.Tables("Promotor4").Columns.Add("num_factura")
                    dsReporte.Tables("Promotor4").Columns.Add("subtotal")
                    dsReporte.Tables("Promotor4").Columns.Add("iva")
                    dsReporte.Tables("Promotor4").Columns.Add("total")
                    dsReporte.Tables("Promotor4").Columns.Add("abono_rango")
                    dsReporte.Tables("Promotor4").Columns.Add("abono_total")
                    dsReporte.Tables("Promotor4").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Promotor4").Columns.Add("porsa")
                    dsReporte.Tables("Promotor4").Columns.Add("comisionsa")
                    dsReporte.Tables("Promotor4").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Promotor4").Columns.Add("porsin")
                    dsReporte.Tables("Promotor4").Columns.Add("comisionsin")
                    dsReporte.Tables("Promotor4").Columns.Add("costosocial")
                    dsReporte.Tables("Promotor4").Columns.Add("retencionimss")
                    dsReporte.Tables("Promotor4").Columns.Add("clientenomina")
                    dsReporte.Tables("Promotor4").Columns.Add("empresapatrona")
                    dsReporte.Tables("Promotor4").Columns.Add("periodo")
                    dsReporte.Tables("Promotor4").Columns.Add("promotor")
                    dsReporte.Tables("Promotor4").Columns.Add("fechanomina")
                    dsReporte.Tables("Promotor4").Columns.Add("poradmon")
                    dsReporte.Tables("Promotor4").Columns.Add("porrepartir")
                    dsReporte.Tables("Promotor4").Columns.Add("gadmon")
                    dsReporte.Tables("Promotor4").Columns.Add("cuatro")
                    dsReporte.Tables("Promotor4").Columns.Add("restoadmon")
                    dsReporte.Tables("Promotor4").Columns.Add("grepartir")
                    dsReporte.Tables("Promotor4").Columns.Add("nombre")
                    dsReporte.Tables("Promotor4").Columns.Add("porpromotor")
                    dsReporte.Tables("Promotor4").Columns.Add("cantidad")
                    dsReporte.Tables("Promotor4").Columns.Add("nombre2")
                    dsReporte.Tables("Promotor4").Columns.Add("porpromotor2")
                    dsReporte.Tables("Promotor4").Columns.Add("cantidad2")
                    dsReporte.Tables("Promotor4").Columns.Add("comisiontotal")
                    dsReporte.Tables("Promotor4").Columns.Add("comisionpromotor")
                    dsReporte.Tables("Promotor4").Columns.Add("comisionmbc")
                    dsReporte.Tables("Promotor4").Columns.Add("repartirmbc")
                    dsReporte.Tables("Promotor4").Columns.Add("nombre3")
                    dsReporte.Tables("Promotor4").Columns.Add("porpromotor3")
                    dsReporte.Tables("Promotor4").Columns.Add("cantidad3")
                    dsReporte.Tables("Promotor4").Columns.Add("NombrePromotor")
                    dsReporte.Tables("Promotor4").Columns.Add("totalf")
                    dsReporte.Tables("Promotor4").Columns.Add("tipo")
                    dsReporte.Tables("Promotor4").Columns.Add("idpromotor")

                    dsReporte.Tables.Add("Promotor5")
                    dsReporte.Tables("Promotor5").Columns.Add("fecha")
                    dsReporte.Tables("Promotor5").Columns.Add("iIdCliente")
                    dsReporte.Tables("Promotor5").Columns.Add("cliente_factura")
                    dsReporte.Tables("Promotor5").Columns.Add("empresa_factura")
                    dsReporte.Tables("Promotor5").Columns.Add("num_factura")
                    dsReporte.Tables("Promotor5").Columns.Add("subtotal")
                    dsReporte.Tables("Promotor5").Columns.Add("iva")
                    dsReporte.Tables("Promotor5").Columns.Add("total")
                    dsReporte.Tables("Promotor5").Columns.Add("abono_rango")
                    dsReporte.Tables("Promotor5").Columns.Add("abono_total")
                    dsReporte.Tables("Promotor5").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Promotor5").Columns.Add("porsa")
                    dsReporte.Tables("Promotor5").Columns.Add("comisionsa")
                    dsReporte.Tables("Promotor5").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Promotor5").Columns.Add("porsin")
                    dsReporte.Tables("Promotor5").Columns.Add("comisionsin")
                    dsReporte.Tables("Promotor5").Columns.Add("costosocial")
                    dsReporte.Tables("Promotor5").Columns.Add("retencionimss")
                    dsReporte.Tables("Promotor5").Columns.Add("clientenomina")
                    dsReporte.Tables("Promotor5").Columns.Add("empresapatrona")
                    dsReporte.Tables("Promotor5").Columns.Add("periodo")
                    dsReporte.Tables("Promotor5").Columns.Add("promotor")
                    dsReporte.Tables("Promotor5").Columns.Add("fechanomina")
                    dsReporte.Tables("Promotor5").Columns.Add("poradmon")
                    dsReporte.Tables("Promotor5").Columns.Add("porrepartir")
                    dsReporte.Tables("Promotor5").Columns.Add("gadmon")
                    dsReporte.Tables("Promotor5").Columns.Add("cuatro")
                    dsReporte.Tables("Promotor5").Columns.Add("restoadmon")
                    dsReporte.Tables("Promotor5").Columns.Add("grepartir")
                    dsReporte.Tables("Promotor5").Columns.Add("nombre")
                    dsReporte.Tables("Promotor5").Columns.Add("porpromotor")
                    dsReporte.Tables("Promotor5").Columns.Add("cantidad")
                    dsReporte.Tables("Promotor5").Columns.Add("nombre2")
                    dsReporte.Tables("Promotor5").Columns.Add("porpromotor2")
                    dsReporte.Tables("Promotor5").Columns.Add("cantidad2")
                    dsReporte.Tables("Promotor5").Columns.Add("comisiontotal")
                    dsReporte.Tables("Promotor5").Columns.Add("comisionpromotor")
                    dsReporte.Tables("Promotor5").Columns.Add("comisionmbc")
                    dsReporte.Tables("Promotor5").Columns.Add("repartirmbc")
                    dsReporte.Tables("Promotor5").Columns.Add("nombre3")
                    dsReporte.Tables("Promotor5").Columns.Add("porpromotor3")
                    dsReporte.Tables("Promotor5").Columns.Add("cantidad3")
                    dsReporte.Tables("Promotor5").Columns.Add("NombrePromotor")
                    dsReporte.Tables("Promotor5").Columns.Add("totalf")
                    dsReporte.Tables("Promotor5").Columns.Add("tipo")
                    dsReporte.Tables("Promotor5").Columns.Add("idpromotor")

                    dsReporte.Tables.Add("Promotor6")
                    dsReporte.Tables("Promotor6").Columns.Add("fecha")
                    dsReporte.Tables("Promotor6").Columns.Add("iIdCliente")
                    dsReporte.Tables("Promotor6").Columns.Add("cliente_factura")
                    dsReporte.Tables("Promotor6").Columns.Add("empresa_factura")
                    dsReporte.Tables("Promotor6").Columns.Add("num_factura")
                    dsReporte.Tables("Promotor6").Columns.Add("subtotal")
                    dsReporte.Tables("Promotor6").Columns.Add("iva")
                    dsReporte.Tables("Promotor6").Columns.Add("total")
                    dsReporte.Tables("Promotor6").Columns.Add("abono_rango")
                    dsReporte.Tables("Promotor6").Columns.Add("abono_total")
                    dsReporte.Tables("Promotor6").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Promotor6").Columns.Add("porsa")
                    dsReporte.Tables("Promotor6").Columns.Add("comisionsa")
                    dsReporte.Tables("Promotor6").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Promotor6").Columns.Add("porsin")
                    dsReporte.Tables("Promotor6").Columns.Add("comisionsin")
                    dsReporte.Tables("Promotor6").Columns.Add("costosocial")
                    dsReporte.Tables("Promotor6").Columns.Add("retencionimss")
                    dsReporte.Tables("Promotor6").Columns.Add("clientenomina")
                    dsReporte.Tables("Promotor6").Columns.Add("empresapatrona")
                    dsReporte.Tables("Promotor6").Columns.Add("periodo")
                    dsReporte.Tables("Promotor6").Columns.Add("promotor")
                    dsReporte.Tables("Promotor6").Columns.Add("fechanomina")
                    dsReporte.Tables("Promotor6").Columns.Add("poradmon")
                    dsReporte.Tables("Promotor6").Columns.Add("porrepartir")
                    dsReporte.Tables("Promotor6").Columns.Add("gadmon")
                    dsReporte.Tables("Promotor6").Columns.Add("cuatro")
                    dsReporte.Tables("Promotor6").Columns.Add("restoadmon")
                    dsReporte.Tables("Promotor6").Columns.Add("grepartir")
                    dsReporte.Tables("Promotor6").Columns.Add("nombre")
                    dsReporte.Tables("Promotor6").Columns.Add("porpromotor")
                    dsReporte.Tables("Promotor6").Columns.Add("cantidad")
                    dsReporte.Tables("Promotor6").Columns.Add("nombre2")
                    dsReporte.Tables("Promotor6").Columns.Add("porpromotor2")
                    dsReporte.Tables("Promotor6").Columns.Add("cantidad2")
                    dsReporte.Tables("Promotor6").Columns.Add("comisiontotal")
                    dsReporte.Tables("Promotor6").Columns.Add("comisionpromotor")
                    dsReporte.Tables("Promotor6").Columns.Add("comisionmbc")
                    dsReporte.Tables("Promotor6").Columns.Add("repartirmbc")
                    dsReporte.Tables("Promotor6").Columns.Add("nombre3")
                    dsReporte.Tables("Promotor6").Columns.Add("porpromotor3")
                    dsReporte.Tables("Promotor6").Columns.Add("cantidad3")
                    dsReporte.Tables("Promotor6").Columns.Add("NombrePromotor")
                    dsReporte.Tables("Promotor6").Columns.Add("totalf")
                    dsReporte.Tables("Promotor6").Columns.Add("tipo")
                    dsReporte.Tables("Promotor6").Columns.Add("idpromotor")

                    dsReporte.Tables.Add("Final")
                    dsReporte.Tables("Final").Columns.Add("fecha")
                    dsReporte.Tables("Final").Columns.Add("iIdCliente")
                    dsReporte.Tables("Final").Columns.Add("cliente_factura")
                    dsReporte.Tables("Final").Columns.Add("empresa_factura")
                    dsReporte.Tables("Final").Columns.Add("num_factura")
                    dsReporte.Tables("Final").Columns.Add("subtotal")
                    dsReporte.Tables("Final").Columns.Add("iva")
                    dsReporte.Tables("Final").Columns.Add("total")
                    dsReporte.Tables("Final").Columns.Add("abono_rango")
                    dsReporte.Tables("Final").Columns.Add("abono_total")
                    dsReporte.Tables("Final").Columns.Add("dispersion_sa")
                    dsReporte.Tables("Final").Columns.Add("porsa")
                    dsReporte.Tables("Final").Columns.Add("comisionsa")
                    dsReporte.Tables("Final").Columns.Add("dispersion_sin")
                    dsReporte.Tables("Final").Columns.Add("porsin")
                    dsReporte.Tables("Final").Columns.Add("comisionsin")
                    dsReporte.Tables("Final").Columns.Add("costosocial")
                    dsReporte.Tables("Final").Columns.Add("retencionimss")
                    dsReporte.Tables("Final").Columns.Add("clientenomina")
                    dsReporte.Tables("Final").Columns.Add("empresapatrona")
                    dsReporte.Tables("Final").Columns.Add("periodo")
                    dsReporte.Tables("Final").Columns.Add("promotor")
                    dsReporte.Tables("Final").Columns.Add("fechanomina")
                    dsReporte.Tables("Final").Columns.Add("poradmon")
                    dsReporte.Tables("Final").Columns.Add("cuatro")
                    dsReporte.Tables("Final").Columns.Add("restoadmon")
                    dsReporte.Tables("Final").Columns.Add("porrepartir")
                    dsReporte.Tables("Final").Columns.Add("gadmon")
                    dsReporte.Tables("Final").Columns.Add("grepartir")
                    dsReporte.Tables("Final").Columns.Add("nombre")
                    dsReporte.Tables("Final").Columns.Add("porpromotor")
                    dsReporte.Tables("Final").Columns.Add("cantidad")
                    dsReporte.Tables("Final").Columns.Add("nombre2")
                    dsReporte.Tables("Final").Columns.Add("porpromotor2")
                    dsReporte.Tables("Final").Columns.Add("cantidad2")
                    dsReporte.Tables("Final").Columns.Add("comisiontotal")
                    dsReporte.Tables("Final").Columns.Add("comisionpromotor")
                    dsReporte.Tables("Final").Columns.Add("comisionmbc")
                    dsReporte.Tables("Final").Columns.Add("repartirmbc")
                    dsReporte.Tables("Final").Columns.Add("nombre3")
                    dsReporte.Tables("Final").Columns.Add("porpromotor3")
                    dsReporte.Tables("Final").Columns.Add("cantidad3")
                    dsReporte.Tables("Final").Columns.Add("NombrePromotor")
                    dsReporte.Tables("Final").Columns.Add("totalf")
                    dsReporte.Tables("Final").Columns.Add("tipo")
                    dsReporte.Tables("Final").Columns.Add("idpromotor")



                    For x As Integer = 0 To dsReporte.Tables("Tabla").Rows.Count - 1
                        If dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString <> "" Then
                            'Buscamos al cliente en la base
                            SQL = "select * from IntClientePromotor where fkiIdCliente=" & dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                            Dim rwIntClientePromotor As DataRow() = nConsulta(SQL)
                            If rwIntClientePromotor Is Nothing = False Then

                                Dim fila As DataRow = dsReporte.Tables("Promotor1").NewRow
                                COMISIONPRO = 0

                                fila.Item("fecha") = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                                fila.Item("iIdCliente") = dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                                fila.Item("cliente_factura") = dsReporte.Tables("Tabla").Rows(x)("cliente_factura").ToString
                                fila.Item("empresa_factura") = dsReporte.Tables("Tabla").Rows(x)("empresa_factura").ToString
                                fila.Item("num_factura") = dsReporte.Tables("Tabla").Rows(x)("num_factura").ToString
                                fila.Item("subtotal") = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                                fila.Item("iva") = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                                fila.Item("total") = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                                fila.Item("abono_rango") = dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString
                                fila.Item("abono_total") = dsReporte.Tables("Tabla").Rows(x)("abono_total").ToString
                                fila.Item("dispersion_sa") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sa").ToString
                                fila.Item("porsa") = dsReporte.Tables("Tabla").Rows(x)("porsa").ToString
                                fila.Item("comisionsa") = dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString
                                fila.Item("dispersion_sin") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sin").ToString
                                fila.Item("porsin") = dsReporte.Tables("Tabla").Rows(x)("porsin").ToString
                                fila.Item("comisionsin") = dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString
                                fila.Item("costosocial") = dsReporte.Tables("Tabla").Rows(x)("costosocial").ToString
                                fila.Item("retencionimss") = dsReporte.Tables("Tabla").Rows(x)("retencionimss").ToString
                                fila.Item("clientenomina") = dsReporte.Tables("Tabla").Rows(x)("clientenomina").ToString
                                fila.Item("empresapatrona") = dsReporte.Tables("Tabla").Rows(x)("empresapatrona").ToString
                                fila.Item("periodo") = dsReporte.Tables("Tabla").Rows(x)("periodo").ToString
                                fila.Item("promotor") = dsReporte.Tables("Tabla").Rows(x)("promotor").ToString
                                fila.Item("fechanomina") = dsReporte.Tables("Tabla").Rows(x)("fechanomina").ToString
                                'fila.Item("consecutivo") = dsReporte.Tables("Tabla").Rows(x)("consecutivo").ToString

                                'obtenemos el iva de la factura
                                IVA = Double.Parse(dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString) - (Double.Parse(dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString) / 1.16)

                                'Obtenemos la cantidad que se va a repartir del iva de acuerdo a los puntos a repartir
                                REPARTIR = (IVA * Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))) / 16

                                'Al total del iva le quitamos por que se va a repartir y nos dan los gastos administrativos
                                GADMON = IVA - REPARTIR

                                'Obtenemos los 4 puntos de los gastos administrativos
                                CUATRO = GADMON - (GADMON * 4 / (16 - Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))))

                                'con una resta obtenemos el resto de los 4 puntos
                                RESTOCUATRO = GADMON - CUATRO

                                'obtenemos la cantidad que le corresponde al promotor inicial Num1 segun el orden de la plantilla
                                cantidadpro1 = REPARTIR * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotor")) / 100)

                                'Obtenemos lo que queda del iva a repartir despues de sacar lo del promotor inicial, 
                                'esto es lo que se tendria que repartir a los promotores 2 y 3 si existen
                                REPARTIRMBC = REPARTIR - cantidadpro1


                                'Verificamos si existen comisiones para sa y sindicato
                                If Trim(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString()) = "" Then
                                    COMISIONSA = 0
                                Else
                                    COMISIONSA = Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString())
                                End If

                                If Trim(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString()) = "" Then
                                    COMISIONSIN = 0 + COMISIONSA
                                Else
                                    COMISIONSIN = Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString()) + COMISIONSA
                                End If
                                'COMISIONSA = IIf(Trim(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString()) = "", 0, Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString()))
                                'COMISIONSIN = IIf(Trim(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString()) = "", 0, Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString())) + COMISIONSA

                                COMISIONMBC = COMISIONSIN


                                If rwIntClientePromotor(0).Item("OtroPromotor") = "1" Then
                                    Dim filaPro2 As DataRow = dsReporte.Tables("Promotor2").NewRow

                                    filaPro2.Item("fecha") = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                                    filaPro2.Item("iIdCliente") = dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                                    filaPro2.Item("cliente_factura") = dsReporte.Tables("Tabla").Rows(x)("cliente_factura").ToString
                                    filaPro2.Item("empresa_factura") = dsReporte.Tables("Tabla").Rows(x)("empresa_factura").ToString
                                    filaPro2.Item("num_factura") = dsReporte.Tables("Tabla").Rows(x)("num_factura").ToString
                                    filaPro2.Item("subtotal") = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                                    filaPro2.Item("iva") = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                                    filaPro2.Item("total") = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                                    filaPro2.Item("abono_rango") = dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString
                                    filaPro2.Item("abono_total") = dsReporte.Tables("Tabla").Rows(x)("abono_total").ToString
                                    filaPro2.Item("dispersion_sa") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sa").ToString
                                    filaPro2.Item("porsa") = dsReporte.Tables("Tabla").Rows(x)("porsa").ToString
                                    filaPro2.Item("comisionsa") = dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString
                                    filaPro2.Item("dispersion_sin") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sin").ToString
                                    filaPro2.Item("porsin") = dsReporte.Tables("Tabla").Rows(x)("porsin").ToString
                                    filaPro2.Item("comisionsin") = dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString
                                    filaPro2.Item("costosocial") = dsReporte.Tables("Tabla").Rows(x)("costosocial").ToString
                                    filaPro2.Item("retencionimss") = dsReporte.Tables("Tabla").Rows(x)("retencionimss").ToString
                                    filaPro2.Item("clientenomina") = dsReporte.Tables("Tabla").Rows(x)("clientenomina").ToString
                                    filaPro2.Item("empresapatrona") = dsReporte.Tables("Tabla").Rows(x)("empresapatrona").ToString
                                    filaPro2.Item("periodo") = dsReporte.Tables("Tabla").Rows(x)("periodo").ToString
                                    filaPro2.Item("promotor") = dsReporte.Tables("Tabla").Rows(x)("promotor").ToString
                                    filaPro2.Item("fechanomina") = dsReporte.Tables("Tabla").Rows(x)("fechanomina").ToString
                                    'filaPro2.Item("consecutivo") = dsReporte.Tables("Tabla").Rows(x)("consecutivo").ToString

                                    REPARTIROTRO = REPARTIR - cantidadpro1
                                    cantidadpro2 = REPARTIROTRO * (Double.Parse(rwIntClientePromotor(0).Item("PorOtroPromotor")) / 100)
                                    REPARTIRMBC = REPARTIRMBC - cantidadpro2


                                    filaPro2.Item("poradmon") = 16 - Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro2.Item("porrepartir") = Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro2.Item("gadmon") = "" 'GADMON
                                    filaPro2.Item("cuatro") = "0"
                                    filaPro2.Item("restoadmon") = "0"
                                    filaPro2.Item("grepartir") = "0" 'REPARTIR
                                    filaPro2.Item("nombre") = ""
                                    filaPro2.Item("porpromotor") = "0"
                                    filaPro2.Item("cantidad") = "0"
                                    filaPro2.Item("nombre2") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorOtro"))
                                    filaPro2.Item("porpromotor2") = rwIntClientePromotor(0).Item("PorOtroPromotor")
                                    filaPro2.Item("cantidad2") = cantidadpro2
                                    filaPro2.Item("comisiontotal") = "0" 'COMISIONSIN
                                    filaPro2.Item("comisionpromotor") = "0"
                                    filaPro2.Item("comisionmbc") = "0"
                                    filaPro2.Item("repartirmbc") = "0"
                                    filaPro2.Item("nombre3") = ""
                                    filaPro2.Item("porpromotor3") = "0"
                                    filaPro2.Item("cantidad3") = "0"
                                    filaPro2.Item("NombrePromotor") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorOtro"))
                                    filaPro2.Item("totalf") = cantidadpro2
                                    filaPro2.Item("tipo") = "2"
                                    filaPro2.Item("idpromotor") = rwIntClientePromotor(0).Item("fkiIdPromotorOtro")

                                    dsReporte.Tables("Promotor2").Rows.Add(filaPro2)
                                Else

                                End If
                                '#################################
                                '##############################
                                '#########################
                                '###################
                                '##############
                                '#########
                                '#####

                                'Cambio segundo promotor de iva

                                If rwIntClientePromotor(0).Item("OtroPromotorIva") = "1" Then
                                    Dim filaPro3 As DataRow = dsReporte.Tables("Promotor3").NewRow

                                    filaPro3.Item("fecha") = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                                    filaPro3.Item("iIdCliente") = dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                                    filaPro3.Item("cliente_factura") = dsReporte.Tables("Tabla").Rows(x)("cliente_factura").ToString
                                    filaPro3.Item("empresa_factura") = dsReporte.Tables("Tabla").Rows(x)("empresa_factura").ToString
                                    filaPro3.Item("num_factura") = dsReporte.Tables("Tabla").Rows(x)("num_factura").ToString
                                    filaPro3.Item("subtotal") = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                                    filaPro3.Item("iva") = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                                    filaPro3.Item("total") = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                                    filaPro3.Item("abono_rango") = dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString
                                    filaPro3.Item("abono_total") = dsReporte.Tables("Tabla").Rows(x)("abono_total").ToString
                                    filaPro3.Item("dispersion_sa") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sa").ToString
                                    filaPro3.Item("porsa") = dsReporte.Tables("Tabla").Rows(x)("porsa").ToString
                                    filaPro3.Item("comisionsa") = dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString
                                    filaPro3.Item("dispersion_sin") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sin").ToString
                                    filaPro3.Item("porsin") = dsReporte.Tables("Tabla").Rows(x)("porsin").ToString
                                    filaPro3.Item("comisionsin") = dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString
                                    filaPro3.Item("costosocial") = dsReporte.Tables("Tabla").Rows(x)("costosocial").ToString
                                    filaPro3.Item("retencionimss") = dsReporte.Tables("Tabla").Rows(x)("retencionimss").ToString
                                    filaPro3.Item("clientenomina") = dsReporte.Tables("Tabla").Rows(x)("clientenomina").ToString
                                    filaPro3.Item("empresapatrona") = dsReporte.Tables("Tabla").Rows(x)("empresapatrona").ToString
                                    filaPro3.Item("periodo") = dsReporte.Tables("Tabla").Rows(x)("periodo").ToString
                                    filaPro3.Item("promotor") = dsReporte.Tables("Tabla").Rows(x)("promotor").ToString
                                    filaPro3.Item("fechanomina") = dsReporte.Tables("Tabla").Rows(x)("fechanomina").ToString
                                    'filaPro2.Item("consecutivo") = dsReporte.Tables("Tabla").Rows(x)("consecutivo").ToString

                                    REPARTIROTRO = REPARTIR - cantidadpro1
                                    cantidadpro2 = REPARTIROTRO * (Double.Parse(rwIntClientePromotor(0).Item("PorOtroPromotorIva")) / 100)
                                    REPARTIRMBC = REPARTIRMBC - cantidadpro2

                                    filaPro3.Item("poradmon") = 16 - Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro3.Item("porrepartir") = Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro3.Item("gadmon") = "" 'GADMON
                                    filaPro3.Item("cuatro") = "0"
                                    filaPro3.Item("restoadmon") = "0"
                                    filaPro3.Item("grepartir") = "0" 'REPARTIR
                                    filaPro3.Item("nombre") = ""
                                    filaPro3.Item("porpromotor") = "0"
                                    filaPro3.Item("cantidad") = "0"
                                    filaPro3.Item("nombre2") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorOtroIva"))
                                    filaPro3.Item("porpromotor2") = rwIntClientePromotor(0).Item("PorOtroPromotorIva")
                                    filaPro3.Item("cantidad2") = cantidadpro2
                                    filaPro3.Item("comisiontotal") = "0" 'COMISIONSIN
                                    filaPro3.Item("comisionpromotor") = "0"
                                    filaPro3.Item("comisionmbc") = "0"
                                    filaPro3.Item("repartirmbc") = "0"
                                    filaPro3.Item("nombre3") = ""
                                    filaPro3.Item("porpromotor3") = "0"
                                    filaPro3.Item("cantidad3") = "0"
                                    filaPro3.Item("NombrePromotor") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorOtroIva"))
                                    filaPro3.Item("totalf") = cantidadpro2
                                    filaPro3.Item("tipo") = "3"
                                    filaPro3.Item("idpromotor") = rwIntClientePromotor(0).Item("fkiIdPromotorOtroIva")

                                    dsReporte.Tables("Promotor3").Rows.Add(filaPro3)
                                Else

                                End If

                                'Agregamos las comisiones al primer promotor
                                'para sus calculos
                                If rwIntClientePromotor(0).Item("sumarcomision") = "1" Then
                                    'COMISIONSA = IIf(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString = "", 0, Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString))
                                    'COMISIONSIN = IIf(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString = "", 0, Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString)) + COMISIONSA
                                    cantidadpro1 = cantidadpro1 + (COMISIONSIN * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotor")) / 100))
                                    COMISIONMBC = COMISIONSIN - (COMISIONSIN * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotor")) / 100))
                                Else

                                End If


                                'Empezamos con el calculo de la comision
                                'de acuerdo a lo que esta en la plantilla
                                If rwIntClientePromotor(0).Item("calculoscomision") = "1" Then
                                    Dim filaPro4 As DataRow = dsReporte.Tables("Promotor4").NewRow

                                    filaPro4.Item("fecha") = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                                    filaPro4.Item("iIdCliente") = dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                                    filaPro4.Item("cliente_factura") = dsReporte.Tables("Tabla").Rows(x)("cliente_factura").ToString
                                    filaPro4.Item("empresa_factura") = dsReporte.Tables("Tabla").Rows(x)("empresa_factura").ToString
                                    filaPro4.Item("num_factura") = dsReporte.Tables("Tabla").Rows(x)("num_factura").ToString
                                    filaPro4.Item("subtotal") = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                                    filaPro4.Item("iva") = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                                    filaPro4.Item("total") = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                                    filaPro4.Item("abono_rango") = dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString
                                    filaPro4.Item("abono_total") = dsReporte.Tables("Tabla").Rows(x)("abono_total").ToString
                                    filaPro4.Item("dispersion_sa") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sa").ToString
                                    filaPro4.Item("porsa") = dsReporte.Tables("Tabla").Rows(x)("porsa").ToString
                                    filaPro4.Item("comisionsa") = dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString
                                    filaPro4.Item("dispersion_sin") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sin").ToString
                                    filaPro4.Item("porsin") = dsReporte.Tables("Tabla").Rows(x)("porsin").ToString
                                    filaPro4.Item("comisionsin") = dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString
                                    filaPro4.Item("costosocial") = dsReporte.Tables("Tabla").Rows(x)("costosocial").ToString
                                    filaPro4.Item("retencionimss") = dsReporte.Tables("Tabla").Rows(x)("retencionimss").ToString
                                    filaPro4.Item("clientenomina") = dsReporte.Tables("Tabla").Rows(x)("clientenomina").ToString
                                    filaPro4.Item("empresapatrona") = dsReporte.Tables("Tabla").Rows(x)("empresapatrona").ToString
                                    filaPro4.Item("periodo") = dsReporte.Tables("Tabla").Rows(x)("periodo").ToString
                                    filaPro4.Item("promotor") = dsReporte.Tables("Tabla").Rows(x)("promotor").ToString
                                    filaPro4.Item("fechanomina") = dsReporte.Tables("Tabla").Rows(x)("fechanomina").ToString
                                    'filaPro3.Item("consecutivo") = dsReporte.Tables("Tabla").Rows(x)("consecutivo").ToString

                                    'COMISIONSA = IIf(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString = "", 0, Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString))
                                    'COMISIONSIN = IIf(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString = "", 0, Double.Parse(dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString)) + COMISIONSA
                                    cantidadpro3 = COMISIONSIN * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotorComision")) / 100)
                                    REPARTIRCOMISION = COMISIONSIN - cantidadpro3

                                    ' aqui agregamos la el calculo de promotor fijo y despues lo del promotor inicial

                                    If Double.Parse(rwIntClientePromotor(0).Item("CantidadPromoComisionFijo")) > 0 Then


                                        Dim filaPro5 As DataRow = dsReporte.Tables("Promotor5").NewRow

                                        filaPro5.Item("fecha") = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                                        filaPro5.Item("iIdCliente") = dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                                        filaPro5.Item("cliente_factura") = dsReporte.Tables("Tabla").Rows(x)("cliente_factura").ToString
                                        filaPro5.Item("empresa_factura") = dsReporte.Tables("Tabla").Rows(x)("empresa_factura").ToString
                                        filaPro5.Item("num_factura") = dsReporte.Tables("Tabla").Rows(x)("num_factura").ToString
                                        filaPro5.Item("subtotal") = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                                        filaPro5.Item("iva") = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                                        filaPro5.Item("total") = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                                        filaPro5.Item("abono_rango") = dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString
                                        filaPro5.Item("abono_total") = dsReporte.Tables("Tabla").Rows(x)("abono_total").ToString
                                        filaPro5.Item("dispersion_sa") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sa").ToString
                                        filaPro5.Item("porsa") = dsReporte.Tables("Tabla").Rows(x)("porsa").ToString
                                        filaPro5.Item("comisionsa") = dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString
                                        filaPro5.Item("dispersion_sin") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sin").ToString
                                        filaPro5.Item("porsin") = dsReporte.Tables("Tabla").Rows(x)("porsin").ToString
                                        filaPro5.Item("comisionsin") = dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString
                                        filaPro5.Item("costosocial") = dsReporte.Tables("Tabla").Rows(x)("costosocial").ToString
                                        filaPro5.Item("retencionimss") = dsReporte.Tables("Tabla").Rows(x)("retencionimss").ToString
                                        filaPro5.Item("clientenomina") = dsReporte.Tables("Tabla").Rows(x)("clientenomina").ToString
                                        filaPro5.Item("empresapatrona") = dsReporte.Tables("Tabla").Rows(x)("empresapatrona").ToString
                                        filaPro5.Item("periodo") = dsReporte.Tables("Tabla").Rows(x)("periodo").ToString
                                        filaPro5.Item("promotor") = dsReporte.Tables("Tabla").Rows(x)("promotor").ToString
                                        filaPro5.Item("fechanomina") = dsReporte.Tables("Tabla").Rows(x)("fechanomina").ToString

                                        cantidadprofijo = Double.Parse(rwIntClientePromotor(0).Item("CantidadPromoComisionFijo"))
                                        REPARTIRCOMISION = REPARTIRCOMISION - cantidadprofijo

                                        filaPro5.Item("poradmon") = 16 - Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                        filaPro5.Item("porrepartir") = Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                        filaPro5.Item("gadmon") = "0" 'GADMON
                                        filaPro5.Item("cuatro") = "0"
                                        filaPro5.Item("restoadmon") = "0"
                                        filaPro5.Item("grepartir") = "0" 'REPARTIR
                                        filaPro5.Item("nombre") = ""
                                        filaPro5.Item("porpromotor") = "0"
                                        filaPro5.Item("cantidad") = "0"
                                        filaPro5.Item("nombre2") = ""
                                        filaPro5.Item("porpromotor2") = "0"
                                        filaPro5.Item("cantidad2") = "0"
                                        filaPro5.Item("comisiontotal") = "0" 'COMISIONSIN
                                        filaPro5.Item("comisionpromotor") = "0"
                                        filaPro5.Item("comisionmbc") = "0"
                                        filaPro5.Item("repartirmbc") = "0"
                                        filaPro5.Item("nombre3") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorComisionFijo"))
                                        filaPro5.Item("porpromotor3") = "0"
                                        filaPro5.Item("cantidad3") = cantidadprofijo
                                        filaPro5.Item("NombrePromotor") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorComisionFijo"))
                                        filaPro5.Item("totalf") = cantidadprofijo
                                        filaPro5.Item("tipo") = "5"
                                        filaPro5.Item("idpromotor") = rwIntClientePromotor(0).Item("fkiIdPromotorComisionFijo")

                                        dsReporte.Tables("Promotor5").Rows.Add(filaPro5)

                                    End If





                                    cantidadpro1 = cantidadpro1 + (REPARTIRCOMISION * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotorInicialComision")) / 100))

                                    COMISIONMBC = REPARTIRCOMISION - (REPARTIRCOMISION * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotorInicialComision")) / 100))


                                    filaPro4.Item("poradmon") = 16 - Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro4.Item("porrepartir") = Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro4.Item("gadmon") = "0" 'GADMON
                                    filaPro4.Item("cuatro") = "0"
                                    filaPro4.Item("restoadmon") = "0"
                                    filaPro4.Item("grepartir") = "0" 'REPARTIR
                                    filaPro4.Item("nombre") = ""
                                    filaPro4.Item("porpromotor") = "0"
                                    filaPro4.Item("cantidad") = "0"
                                    filaPro4.Item("nombre2") = ""
                                    filaPro4.Item("porpromotor2") = "0"
                                    filaPro4.Item("cantidad2") = "0"
                                    filaPro4.Item("comisiontotal") = "0" 'COMISIONSIN
                                    filaPro4.Item("comisionpromotor") = "0"
                                    filaPro4.Item("comisionmbc") = "0"
                                    filaPro4.Item("repartirmbc") = "0"
                                    filaPro4.Item("nombre3") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorComision"))
                                    filaPro4.Item("porpromotor3") = rwIntClientePromotor(0).Item("PorPromotorComision")
                                    filaPro4.Item("cantidad3") = cantidadpro3
                                    filaPro4.Item("NombrePromotor") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorComision"))
                                    filaPro4.Item("totalf") = cantidadpro3
                                    filaPro4.Item("tipo") = "4"
                                    filaPro4.Item("idpromotor") = rwIntClientePromotor(0).Item("fkiIdPromotorComision")

                                    dsReporte.Tables("Promotor4").Rows.Add(filaPro4)
                                Else

                                End If

                                'COMISION REMANENTE

                                If rwIntClientePromotor(0).Item("RepartoRemanente") = "1" Then
                                    Dim filaPro6 As DataRow = dsReporte.Tables("Promotor6").NewRow
                                    filaPro6.Item("fecha") = dsReporte.Tables("Tabla").Rows(x)("fecha").ToString
                                    filaPro6.Item("iIdCliente") = dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                                    filaPro6.Item("cliente_factura") = dsReporte.Tables("Tabla").Rows(x)("cliente_factura").ToString
                                    filaPro6.Item("empresa_factura") = dsReporte.Tables("Tabla").Rows(x)("empresa_factura").ToString
                                    filaPro6.Item("num_factura") = dsReporte.Tables("Tabla").Rows(x)("num_factura").ToString
                                    filaPro6.Item("subtotal") = dsReporte.Tables("Tabla").Rows(x)("subtotal").ToString
                                    filaPro6.Item("iva") = dsReporte.Tables("Tabla").Rows(x)("iva").ToString
                                    filaPro6.Item("total") = dsReporte.Tables("Tabla").Rows(x)("total").ToString
                                    filaPro6.Item("abono_rango") = dsReporte.Tables("Tabla").Rows(x)("abono_rango").ToString
                                    filaPro6.Item("abono_total") = dsReporte.Tables("Tabla").Rows(x)("abono_total").ToString
                                    filaPro6.Item("dispersion_sa") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sa").ToString
                                    filaPro6.Item("porsa") = dsReporte.Tables("Tabla").Rows(x)("porsa").ToString
                                    filaPro6.Item("comisionsa") = dsReporte.Tables("Tabla").Rows(x)("comisionsa").ToString
                                    filaPro6.Item("dispersion_sin") = dsReporte.Tables("Tabla").Rows(x)("dispersion_sin").ToString
                                    filaPro6.Item("porsin") = dsReporte.Tables("Tabla").Rows(x)("porsin").ToString
                                    filaPro6.Item("comisionsin") = dsReporte.Tables("Tabla").Rows(x)("comisionsin").ToString
                                    filaPro6.Item("costosocial") = dsReporte.Tables("Tabla").Rows(x)("costosocial").ToString
                                    filaPro6.Item("retencionimss") = dsReporte.Tables("Tabla").Rows(x)("retencionimss").ToString
                                    filaPro6.Item("clientenomina") = dsReporte.Tables("Tabla").Rows(x)("clientenomina").ToString
                                    filaPro6.Item("empresapatrona") = dsReporte.Tables("Tabla").Rows(x)("empresapatrona").ToString
                                    filaPro6.Item("periodo") = dsReporte.Tables("Tabla").Rows(x)("periodo").ToString
                                    filaPro6.Item("promotor") = dsReporte.Tables("Tabla").Rows(x)("promotor").ToString
                                    filaPro6.Item("fechanomina") = dsReporte.Tables("Tabla").Rows(x)("fechanomina").ToString

                                    'REMANENTETOTAL = COMISIONMBC + REPARTIRMBC

                                    cantidadremanente = COMISIONMBC * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotorRemanente")) / 100)
                                    COMISIONMBC = COMISIONMBC - (COMISIONMBC * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotorRemanente")) / 100))


                                    cantidadremanente = cantidadremanente + (REPARTIRMBC * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotorRemanente")) / 100))

                                    REPARTIRMBC = REPARTIRMBC - (REPARTIRMBC * (Double.Parse(rwIntClientePromotor(0).Item("PorPromotorRemanente")) / 100))

                                    filaPro6.Item("poradmon") = 16 - Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro6.Item("porrepartir") = Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                    filaPro6.Item("gadmon") = "0" 'GADMON
                                    filaPro6.Item("cuatro") = "0"
                                    filaPro6.Item("restoadmon") = "0"
                                    filaPro6.Item("grepartir") = "0" 'REPARTIR
                                    filaPro6.Item("nombre") = ""
                                    filaPro6.Item("porpromotor") = "0"
                                    filaPro6.Item("cantidad") = "0"
                                    filaPro6.Item("nombre2") = ""
                                    filaPro6.Item("porpromotor2") = "0"
                                    filaPro6.Item("cantidad2") = "0"
                                    filaPro6.Item("comisiontotal") = "0" 'COMISIONSIN
                                    filaPro6.Item("comisionpromotor") = "0"
                                    filaPro6.Item("comisionmbc") = "0"
                                    filaPro6.Item("repartirmbc") = "0"
                                    filaPro6.Item("nombre3") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorRemanente"))
                                    filaPro6.Item("porpromotor3") = rwIntClientePromotor(0).Item("PorPromotorRemanente")
                                    filaPro6.Item("cantidad3") = cantidadremanente
                                    filaPro6.Item("NombrePromotor") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotorRemanente"))
                                    filaPro6.Item("totalf") = cantidadremanente
                                    filaPro6.Item("tipo") = "6"
                                    filaPro6.Item("idpromotor") = rwIntClientePromotor(0).Item("fkiIdPromotorRemanente")

                                    dsReporte.Tables("Promotor6").Rows.Add(filaPro6)

                                End If


                                fila.Item("poradmon") = 16 - Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                fila.Item("porrepartir") = Double.Parse(rwIntClientePromotor(0).Item("PorRepartir"))
                                fila.Item("gadmon") = GADMON
                                fila.Item("cuatro") = CUATRO
                                fila.Item("restoadmon") = RESTOCUATRO
                                fila.Item("grepartir") = REPARTIR
                                fila.Item("nombre") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotor"))
                                fila.Item("porpromotor") = rwIntClientePromotor(0).Item("PorPromotor")
                                fila.Item("cantidad") = cantidadpro1
                                fila.Item("nombre2") = ""
                                fila.Item("porpromotor2") = "0"
                                fila.Item("cantidad2") = "0"
                                fila.Item("comisiontotal") = COMISIONSIN
                                fila.Item("comisionpromotor") = COMISIONPRO
                                fila.Item("comisionmbc") = COMISIONMBC
                                fila.Item("repartirmbc") = REPARTIRMBC
                                fila.Item("nombre3") = ""
                                fila.Item("porpromotor3") = "0"
                                fila.Item("cantidad3") = "0"
                                fila.Item("NombrePromotor") = obtenerpromotor(rwIntClientePromotor(0).Item("fkiIdPromotor"))
                                fila.Item("totalf") = cantidadpro1
                                fila.Item("tipo") = "1"
                                fila.Item("idpromotor") = rwIntClientePromotor(0).Item("fkiIdPromotor")

                                dsReporte.Tables("Promotor1").Rows.Add(fila)

                                encontradas = encontradas + 1
                            Else
                                SQL = "select * from clientes where iIdCliente=" & dsReporte.Tables("Tabla").Rows(x)("iIdCliente").ToString
                                Dim rwCliente As DataRow() = nConsulta(SQL)
                                If rwCliente Is Nothing = False Then
                                    nombreclientes = nombreclientes & rwCliente(0).Item("Nombre") & vbCrLf
                                End If


                            End If

                                consecutivocontrol = consecutivocontrol + 1
                        End If
                    Next

                    For x As Integer = 0 To dsReporte.Tables("Promotor1").Rows.Count - 1
                        Dim Final As DataRow = dsReporte.Tables("Final").NewRow

                        Final.Item("fecha") = dsReporte.Tables("Promotor1").Rows(x)("fecha").ToString
                        Final.Item("iIdCliente") = dsReporte.Tables("Promotor1").Rows(x)("iIdCliente").ToString
                        Final.Item("cliente_factura") = dsReporte.Tables("Promotor1").Rows(x)("cliente_factura").ToString
                        Final.Item("empresa_factura") = dsReporte.Tables("Promotor1").Rows(x)("empresa_factura").ToString
                        Final.Item("num_factura") = dsReporte.Tables("Promotor1").Rows(x)("num_factura").ToString
                        Final.Item("subtotal") = dsReporte.Tables("Promotor1").Rows(x)("subtotal").ToString
                        Final.Item("iva") = dsReporte.Tables("Promotor1").Rows(x)("iva").ToString
                        Final.Item("total") = dsReporte.Tables("Promotor1").Rows(x)("total").ToString
                        Final.Item("abono_rango") = dsReporte.Tables("Promotor1").Rows(x)("abono_rango").ToString
                        Final.Item("abono_total") = dsReporte.Tables("Promotor1").Rows(x)("abono_total").ToString
                        Final.Item("dispersion_sa") = dsReporte.Tables("Promotor1").Rows(x)("dispersion_sa").ToString
                        Final.Item("porsa") = dsReporte.Tables("Promotor1").Rows(x)("porsa").ToString
                        Final.Item("comisionsa") = dsReporte.Tables("Promotor1").Rows(x)("comisionsa").ToString
                        Final.Item("dispersion_sin") = dsReporte.Tables("Promotor1").Rows(x)("dispersion_sin").ToString
                        Final.Item("porsin") = dsReporte.Tables("Promotor1").Rows(x)("porsin").ToString
                        Final.Item("comisionsin") = dsReporte.Tables("Promotor1").Rows(x)("comisionsin").ToString
                        Final.Item("costosocial") = dsReporte.Tables("Promotor1").Rows(x)("costosocial").ToString
                        Final.Item("retencionimss") = dsReporte.Tables("Promotor1").Rows(x)("retencionimss").ToString
                        Final.Item("clientenomina") = dsReporte.Tables("Promotor1").Rows(x)("clientenomina").ToString
                        Final.Item("empresapatrona") = dsReporte.Tables("Promotor1").Rows(x)("empresapatrona").ToString
                        Final.Item("periodo") = dsReporte.Tables("Promotor1").Rows(x)("periodo").ToString
                        Final.Item("promotor") = dsReporte.Tables("Promotor1").Rows(x)("promotor").ToString
                        Final.Item("fechanomina") = dsReporte.Tables("Promotor1").Rows(x)("fechanomina").ToString
                        'Final.Item("consecutivo") = dsReporte.Tables("Promotor1").Rows(x)("consecutivo").ToString
                        Final.Item("poradmon") = dsReporte.Tables("Promotor1").Rows(x)("poradmon").ToString
                        Final.Item("porrepartir") = dsReporte.Tables("Promotor1").Rows(x)("porrepartir").ToString
                        Final.Item("gadmon") = dsReporte.Tables("Promotor1").Rows(x)("gadmon").ToString
                        Final.Item("cuatro") = dsReporte.Tables("Promotor1").Rows(x)("cuatro").ToString
                        Final.Item("restoadmon") = dsReporte.Tables("Promotor1").Rows(x)("restoadmon").ToString
                        Final.Item("grepartir") = dsReporte.Tables("Promotor1").Rows(x)("grepartir").ToString
                        Final.Item("nombre") = dsReporte.Tables("Promotor1").Rows(x)("nombre").ToString
                        Final.Item("porpromotor") = dsReporte.Tables("Promotor1").Rows(x)("porpromotor").ToString
                        Final.Item("cantidad") = dsReporte.Tables("Promotor1").Rows(x)("cantidad").ToString
                        Final.Item("nombre2") = dsReporte.Tables("Promotor1").Rows(x)("nombre2").ToString
                        Final.Item("porpromotor2") = dsReporte.Tables("Promotor1").Rows(x)("porpromotor2").ToString
                        Final.Item("cantidad2") = dsReporte.Tables("Promotor1").Rows(x)("cantidad2").ToString
                        Final.Item("comisiontotal") = dsReporte.Tables("Promotor1").Rows(x)("comisiontotal").ToString
                        Final.Item("comisionpromotor") = dsReporte.Tables("Promotor1").Rows(x)("comisionpromotor").ToString
                        Final.Item("comisionmbc") = dsReporte.Tables("Promotor1").Rows(x)("comisionmbc").ToString
                        Final.Item("repartirmbc") = dsReporte.Tables("Promotor1").Rows(x)("repartirmbc").ToString
                        Final.Item("nombre3") = dsReporte.Tables("Promotor1").Rows(x)("nombre3").ToString
                        Final.Item("porpromotor3") = dsReporte.Tables("Promotor1").Rows(x)("porpromotor3").ToString
                        Final.Item("cantidad3") = dsReporte.Tables("Promotor1").Rows(x)("cantidad3").ToString
                        Final.Item("NombrePromotor") = dsReporte.Tables("Promotor1").Rows(x)("NombrePromotor").ToString
                        Final.Item("totalf") = dsReporte.Tables("Promotor1").Rows(x)("totalf").ToString
                        Final.Item("tipo") = dsReporte.Tables("Promotor1").Rows(x)("tipo").ToString
                        Final.Item("idpromotor") = dsReporte.Tables("Promotor1").Rows(x)("idpromotor").ToString



                        dsReporte.Tables("Final").Rows.Add(Final)
                    Next


                    For x As Integer = 0 To dsReporte.Tables("Promotor2").Rows.Count - 1
                        Dim Final As DataRow = dsReporte.Tables("Final").NewRow

                        Final.Item("fecha") = dsReporte.Tables("Promotor2").Rows(x)("fecha").ToString
                        Final.Item("iIdCliente") = dsReporte.Tables("Promotor2").Rows(x)("iIdCliente").ToString
                        Final.Item("cliente_factura") = dsReporte.Tables("Promotor2").Rows(x)("cliente_factura").ToString
                        Final.Item("empresa_factura") = dsReporte.Tables("Promotor2").Rows(x)("empresa_factura").ToString
                        Final.Item("num_factura") = dsReporte.Tables("Promotor2").Rows(x)("num_factura").ToString
                        Final.Item("subtotal") = dsReporte.Tables("Promotor2").Rows(x)("subtotal").ToString
                        Final.Item("iva") = dsReporte.Tables("Promotor2").Rows(x)("iva").ToString
                        Final.Item("total") = dsReporte.Tables("Promotor2").Rows(x)("total").ToString
                        Final.Item("abono_rango") = dsReporte.Tables("Promotor2").Rows(x)("abono_rango").ToString
                        Final.Item("abono_total") = dsReporte.Tables("Promotor2").Rows(x)("abono_total").ToString
                        Final.Item("dispersion_sa") = dsReporte.Tables("Promotor2").Rows(x)("dispersion_sa").ToString
                        Final.Item("porsa") = dsReporte.Tables("Promotor2").Rows(x)("porsa").ToString
                        Final.Item("comisionsa") = dsReporte.Tables("Promotor2").Rows(x)("comisionsa").ToString
                        Final.Item("dispersion_sin") = dsReporte.Tables("Promotor2").Rows(x)("dispersion_sin").ToString
                        Final.Item("porsin") = dsReporte.Tables("Promotor2").Rows(x)("porsin").ToString
                        Final.Item("comisionsin") = dsReporte.Tables("Promotor2").Rows(x)("comisionsin").ToString
                        Final.Item("costosocial") = dsReporte.Tables("Promotor2").Rows(x)("costosocial").ToString
                        Final.Item("retencionimss") = dsReporte.Tables("Promotor2").Rows(x)("retencionimss").ToString
                        Final.Item("clientenomina") = dsReporte.Tables("Promotor2").Rows(x)("clientenomina").ToString
                        Final.Item("empresapatrona") = dsReporte.Tables("Promotor2").Rows(x)("empresapatrona").ToString
                        Final.Item("periodo") = dsReporte.Tables("Promotor2").Rows(x)("periodo").ToString
                        Final.Item("promotor") = dsReporte.Tables("Promotor2").Rows(x)("promotor").ToString
                        Final.Item("fechanomina") = dsReporte.Tables("Promotor2").Rows(x)("fechanomina").ToString
                        'Final.Item("consecutivo") = dsReporte.Tables("Promotor2").Rows(x)("consecutivo").ToString
                        Final.Item("poradmon") = dsReporte.Tables("Promotor2").Rows(x)("poradmon").ToString
                        Final.Item("porrepartir") = dsReporte.Tables("Promotor2").Rows(x)("porrepartir").ToString
                        Final.Item("gadmon") = dsReporte.Tables("Promotor2").Rows(x)("gadmon").ToString
                        Final.Item("cuatro") = dsReporte.Tables("Promotor2").Rows(x)("cuatro").ToString
                        Final.Item("restoadmon") = dsReporte.Tables("Promotor2").Rows(x)("restoadmon").ToString
                        Final.Item("grepartir") = dsReporte.Tables("Promotor2").Rows(x)("grepartir").ToString
                        Final.Item("nombre") = dsReporte.Tables("Promotor2").Rows(x)("nombre").ToString
                        Final.Item("porpromotor") = dsReporte.Tables("Promotor2").Rows(x)("porpromotor").ToString
                        Final.Item("cantidad") = dsReporte.Tables("Promotor2").Rows(x)("cantidad").ToString
                        Final.Item("nombre2") = dsReporte.Tables("Promotor2").Rows(x)("nombre2").ToString
                        Final.Item("porpromotor2") = dsReporte.Tables("Promotor2").Rows(x)("porpromotor2").ToString
                        Final.Item("cantidad2") = dsReporte.Tables("Promotor2").Rows(x)("cantidad2").ToString
                        Final.Item("comisiontotal") = dsReporte.Tables("Promotor2").Rows(x)("comisiontotal").ToString
                        Final.Item("comisionpromotor") = dsReporte.Tables("Promotor2").Rows(x)("comisionpromotor").ToString
                        Final.Item("comisionmbc") = dsReporte.Tables("Promotor2").Rows(x)("comisionmbc").ToString
                        Final.Item("repartirmbc") = dsReporte.Tables("Promotor2").Rows(x)("repartirmbc").ToString
                        Final.Item("nombre3") = dsReporte.Tables("Promotor2").Rows(x)("nombre3").ToString
                        Final.Item("porpromotor3") = dsReporte.Tables("Promotor2").Rows(x)("porpromotor3").ToString
                        Final.Item("cantidad3") = dsReporte.Tables("Promotor2").Rows(x)("cantidad3").ToString
                        Final.Item("NombrePromotor") = dsReporte.Tables("Promotor2").Rows(x)("NombrePromotor").ToString
                        Final.Item("totalf") = dsReporte.Tables("Promotor2").Rows(x)("totalf").ToString
                        Final.Item("tipo") = dsReporte.Tables("Promotor2").Rows(x)("tipo").ToString
                        Final.Item("idpromotor") = dsReporte.Tables("Promotor2").Rows(x)("idpromotor").ToString



                        dsReporte.Tables("Final").Rows.Add(Final)
                    Next

                    For x As Integer = 0 To dsReporte.Tables("Promotor3").Rows.Count - 1
                        Dim Final As DataRow = dsReporte.Tables("Final").NewRow

                        Final.Item("fecha") = dsReporte.Tables("Promotor3").Rows(x)("fecha").ToString
                        Final.Item("iIdCliente") = dsReporte.Tables("Promotor3").Rows(x)("iIdCliente").ToString
                        Final.Item("cliente_factura") = dsReporte.Tables("Promotor3").Rows(x)("cliente_factura").ToString
                        Final.Item("empresa_factura") = dsReporte.Tables("Promotor3").Rows(x)("empresa_factura").ToString
                        Final.Item("num_factura") = dsReporte.Tables("Promotor3").Rows(x)("num_factura").ToString
                        Final.Item("subtotal") = dsReporte.Tables("Promotor3").Rows(x)("subtotal").ToString
                        Final.Item("iva") = dsReporte.Tables("Promotor3").Rows(x)("iva").ToString
                        Final.Item("total") = dsReporte.Tables("Promotor3").Rows(x)("total").ToString
                        Final.Item("abono_rango") = dsReporte.Tables("Promotor3").Rows(x)("abono_rango").ToString
                        Final.Item("abono_total") = dsReporte.Tables("Promotor3").Rows(x)("abono_total").ToString
                        Final.Item("dispersion_sa") = dsReporte.Tables("Promotor3").Rows(x)("dispersion_sa").ToString
                        Final.Item("porsa") = dsReporte.Tables("Promotor3").Rows(x)("porsa").ToString
                        Final.Item("comisionsa") = dsReporte.Tables("Promotor3").Rows(x)("comisionsa").ToString
                        Final.Item("dispersion_sin") = dsReporte.Tables("Promotor3").Rows(x)("dispersion_sin").ToString
                        Final.Item("porsin") = dsReporte.Tables("Promotor3").Rows(x)("porsin").ToString
                        Final.Item("comisionsin") = dsReporte.Tables("Promotor3").Rows(x)("comisionsin").ToString
                        Final.Item("costosocial") = dsReporte.Tables("Promotor3").Rows(x)("costosocial").ToString
                        Final.Item("retencionimss") = dsReporte.Tables("Promotor3").Rows(x)("retencionimss").ToString
                        Final.Item("clientenomina") = dsReporte.Tables("Promotor3").Rows(x)("clientenomina").ToString
                        Final.Item("empresapatrona") = dsReporte.Tables("Promotor3").Rows(x)("empresapatrona").ToString
                        Final.Item("periodo") = dsReporte.Tables("Promotor3").Rows(x)("periodo").ToString
                        Final.Item("promotor") = dsReporte.Tables("Promotor3").Rows(x)("promotor").ToString
                        Final.Item("fechanomina") = dsReporte.Tables("Promotor3").Rows(x)("fechanomina").ToString
                        'Final.Item("consecutivo") = dsReporte.Tables("Promotor3").Rows(x)("consecutivo").ToString
                        Final.Item("poradmon") = dsReporte.Tables("Promotor3").Rows(x)("poradmon").ToString
                        Final.Item("porrepartir") = dsReporte.Tables("Promotor3").Rows(x)("porrepartir").ToString
                        Final.Item("gadmon") = dsReporte.Tables("Promotor3").Rows(x)("gadmon").ToString
                        Final.Item("cuatro") = dsReporte.Tables("Promotor3").Rows(x)("cuatro").ToString
                        Final.Item("restoadmon") = dsReporte.Tables("Promotor3").Rows(x)("restoadmon").ToString
                        Final.Item("grepartir") = dsReporte.Tables("Promotor3").Rows(x)("grepartir").ToString
                        Final.Item("nombre") = dsReporte.Tables("Promotor3").Rows(x)("nombre").ToString
                        Final.Item("porpromotor") = dsReporte.Tables("Promotor3").Rows(x)("porpromotor").ToString
                        Final.Item("cantidad") = dsReporte.Tables("Promotor3").Rows(x)("cantidad").ToString
                        Final.Item("nombre2") = dsReporte.Tables("Promotor3").Rows(x)("nombre2").ToString
                        Final.Item("porpromotor2") = dsReporte.Tables("Promotor3").Rows(x)("porpromotor2").ToString
                        Final.Item("cantidad2") = dsReporte.Tables("Promotor3").Rows(x)("cantidad2").ToString
                        Final.Item("comisiontotal") = dsReporte.Tables("Promotor3").Rows(x)("comisiontotal").ToString
                        Final.Item("comisionpromotor") = dsReporte.Tables("Promotor3").Rows(x)("comisionpromotor").ToString
                        Final.Item("comisionmbc") = dsReporte.Tables("Promotor3").Rows(x)("comisionmbc").ToString
                        Final.Item("repartirmbc") = dsReporte.Tables("Promotor3").Rows(x)("repartirmbc").ToString
                        Final.Item("nombre3") = dsReporte.Tables("Promotor3").Rows(x)("nombre3").ToString
                        Final.Item("porpromotor3") = dsReporte.Tables("Promotor3").Rows(x)("porpromotor3").ToString
                        Final.Item("cantidad3") = dsReporte.Tables("Promotor3").Rows(x)("cantidad3").ToString
                        Final.Item("NombrePromotor") = dsReporte.Tables("Promotor3").Rows(x)("NombrePromotor").ToString
                        Final.Item("totalf") = dsReporte.Tables("Promotor3").Rows(x)("totalf").ToString
                        Final.Item("tipo") = dsReporte.Tables("Promotor3").Rows(x)("tipo").ToString
                        Final.Item("idpromotor") = dsReporte.Tables("Promotor3").Rows(x)("idpromotor").ToString



                        dsReporte.Tables("Final").Rows.Add(Final)
                    Next


                    For x As Integer = 0 To dsReporte.Tables("Promotor4").Rows.Count - 1
                        Dim Final As DataRow = dsReporte.Tables("Final").NewRow

                        Final.Item("fecha") = dsReporte.Tables("Promotor4").Rows(x)("fecha").ToString
                        Final.Item("iIdCliente") = dsReporte.Tables("Promotor4").Rows(x)("iIdCliente").ToString
                        Final.Item("cliente_factura") = dsReporte.Tables("Promotor4").Rows(x)("cliente_factura").ToString
                        Final.Item("empresa_factura") = dsReporte.Tables("Promotor4").Rows(x)("empresa_factura").ToString
                        Final.Item("num_factura") = dsReporte.Tables("Promotor4").Rows(x)("num_factura").ToString
                        Final.Item("subtotal") = dsReporte.Tables("Promotor4").Rows(x)("subtotal").ToString
                        Final.Item("iva") = dsReporte.Tables("Promotor4").Rows(x)("iva").ToString
                        Final.Item("total") = dsReporte.Tables("Promotor4").Rows(x)("total").ToString
                        Final.Item("abono_rango") = dsReporte.Tables("Promotor4").Rows(x)("abono_rango").ToString
                        Final.Item("abono_total") = dsReporte.Tables("Promotor4").Rows(x)("abono_total").ToString
                        Final.Item("dispersion_sa") = dsReporte.Tables("Promotor4").Rows(x)("dispersion_sa").ToString
                        Final.Item("porsa") = dsReporte.Tables("Promotor4").Rows(x)("porsa").ToString
                        Final.Item("comisionsa") = dsReporte.Tables("Promotor4").Rows(x)("comisionsa").ToString
                        Final.Item("dispersion_sin") = dsReporte.Tables("Promotor4").Rows(x)("dispersion_sin").ToString
                        Final.Item("porsin") = dsReporte.Tables("Promotor4").Rows(x)("porsin").ToString
                        Final.Item("comisionsin") = dsReporte.Tables("Promotor4").Rows(x)("comisionsin").ToString
                        Final.Item("costosocial") = dsReporte.Tables("Promotor4").Rows(x)("costosocial").ToString
                        Final.Item("retencionimss") = dsReporte.Tables("Promotor4").Rows(x)("retencionimss").ToString
                        Final.Item("clientenomina") = dsReporte.Tables("Promotor4").Rows(x)("clientenomina").ToString
                        Final.Item("empresapatrona") = dsReporte.Tables("Promotor4").Rows(x)("empresapatrona").ToString
                        Final.Item("periodo") = dsReporte.Tables("Promotor4").Rows(x)("periodo").ToString
                        Final.Item("promotor") = dsReporte.Tables("Promotor4").Rows(x)("promotor").ToString
                        Final.Item("fechanomina") = dsReporte.Tables("Promotor4").Rows(x)("fechanomina").ToString
                        'Final.Item("consecutivo") = dsReporte.Tables("Promotor3").Rows(x)("consecutivo").ToString
                        Final.Item("poradmon") = dsReporte.Tables("Promotor4").Rows(x)("poradmon").ToString
                        Final.Item("porrepartir") = dsReporte.Tables("Promotor4").Rows(x)("porrepartir").ToString
                        Final.Item("gadmon") = dsReporte.Tables("Promotor4").Rows(x)("gadmon").ToString
                        Final.Item("cuatro") = dsReporte.Tables("Promotor4").Rows(x)("cuatro").ToString
                        Final.Item("restoadmon") = dsReporte.Tables("Promotor4").Rows(x)("restoadmon").ToString
                        Final.Item("grepartir") = dsReporte.Tables("Promotor4").Rows(x)("grepartir").ToString
                        Final.Item("nombre") = dsReporte.Tables("Promotor4").Rows(x)("nombre").ToString
                        Final.Item("porpromotor") = dsReporte.Tables("Promotor4").Rows(x)("porpromotor").ToString
                        Final.Item("cantidad") = dsReporte.Tables("Promotor4").Rows(x)("cantidad").ToString
                        Final.Item("nombre2") = dsReporte.Tables("Promotor4").Rows(x)("nombre2").ToString
                        Final.Item("porpromotor2") = dsReporte.Tables("Promotor4").Rows(x)("porpromotor2").ToString
                        Final.Item("cantidad2") = dsReporte.Tables("Promotor4").Rows(x)("cantidad2").ToString
                        Final.Item("comisiontotal") = dsReporte.Tables("Promotor4").Rows(x)("comisiontotal").ToString
                        Final.Item("comisionpromotor") = dsReporte.Tables("Promotor4").Rows(x)("comisionpromotor").ToString
                        Final.Item("comisionmbc") = dsReporte.Tables("Promotor4").Rows(x)("comisionmbc").ToString
                        Final.Item("repartirmbc") = dsReporte.Tables("Promotor4").Rows(x)("repartirmbc").ToString
                        Final.Item("nombre3") = dsReporte.Tables("Promotor4").Rows(x)("nombre3").ToString
                        Final.Item("porpromotor3") = dsReporte.Tables("Promotor4").Rows(x)("porpromotor3").ToString
                        Final.Item("cantidad3") = dsReporte.Tables("Promotor4").Rows(x)("cantidad3").ToString
                        Final.Item("NombrePromotor") = dsReporte.Tables("Promotor4").Rows(x)("NombrePromotor").ToString
                        Final.Item("totalf") = dsReporte.Tables("Promotor4").Rows(x)("totalf").ToString
                        Final.Item("tipo") = dsReporte.Tables("Promotor4").Rows(x)("tipo").ToString
                        Final.Item("idpromotor") = dsReporte.Tables("Promotor4").Rows(x)("idpromotor").ToString



                        dsReporte.Tables("Final").Rows.Add(Final)
                    Next

                    For x As Integer = 0 To dsReporte.Tables("Promotor5").Rows.Count - 1
                        Dim Final As DataRow = dsReporte.Tables("Final").NewRow

                        Final.Item("fecha") = dsReporte.Tables("Promotor5").Rows(x)("fecha").ToString
                        Final.Item("iIdCliente") = dsReporte.Tables("Promotor5").Rows(x)("iIdCliente").ToString
                        Final.Item("cliente_factura") = dsReporte.Tables("Promotor5").Rows(x)("cliente_factura").ToString
                        Final.Item("empresa_factura") = dsReporte.Tables("Promotor5").Rows(x)("empresa_factura").ToString
                        Final.Item("num_factura") = dsReporte.Tables("Promotor5").Rows(x)("num_factura").ToString
                        Final.Item("subtotal") = dsReporte.Tables("Promotor5").Rows(x)("subtotal").ToString
                        Final.Item("iva") = dsReporte.Tables("Promotor5").Rows(x)("iva").ToString
                        Final.Item("total") = dsReporte.Tables("Promotor5").Rows(x)("total").ToString
                        Final.Item("abono_rango") = dsReporte.Tables("Promotor5").Rows(x)("abono_rango").ToString
                        Final.Item("abono_total") = dsReporte.Tables("Promotor5").Rows(x)("abono_total").ToString
                        Final.Item("dispersion_sa") = dsReporte.Tables("Promotor5").Rows(x)("dispersion_sa").ToString
                        Final.Item("porsa") = dsReporte.Tables("Promotor5").Rows(x)("porsa").ToString
                        Final.Item("comisionsa") = dsReporte.Tables("Promotor5").Rows(x)("comisionsa").ToString
                        Final.Item("dispersion_sin") = dsReporte.Tables("Promotor5").Rows(x)("dispersion_sin").ToString
                        Final.Item("porsin") = dsReporte.Tables("Promotor5").Rows(x)("porsin").ToString
                        Final.Item("comisionsin") = dsReporte.Tables("Promotor5").Rows(x)("comisionsin").ToString
                        Final.Item("costosocial") = dsReporte.Tables("Promotor5").Rows(x)("costosocial").ToString
                        Final.Item("retencionimss") = dsReporte.Tables("Promotor5").Rows(x)("retencionimss").ToString
                        Final.Item("clientenomina") = dsReporte.Tables("Promotor5").Rows(x)("clientenomina").ToString
                        Final.Item("empresapatrona") = dsReporte.Tables("Promotor5").Rows(x)("empresapatrona").ToString
                        Final.Item("periodo") = dsReporte.Tables("Promotor5").Rows(x)("periodo").ToString
                        Final.Item("promotor") = dsReporte.Tables("Promotor5").Rows(x)("promotor").ToString
                        Final.Item("fechanomina") = dsReporte.Tables("Promotor5").Rows(x)("fechanomina").ToString
                        'Final.Item("consecutivo") = dsReporte.Tables("Promotor3").Rows(x)("consecutivo").ToString
                        Final.Item("poradmon") = dsReporte.Tables("Promotor5").Rows(x)("poradmon").ToString
                        Final.Item("porrepartir") = dsReporte.Tables("Promotor5").Rows(x)("porrepartir").ToString
                        Final.Item("gadmon") = dsReporte.Tables("Promotor5").Rows(x)("gadmon").ToString
                        Final.Item("cuatro") = dsReporte.Tables("Promotor5").Rows(x)("cuatro").ToString
                        Final.Item("restoadmon") = dsReporte.Tables("Promotor5").Rows(x)("restoadmon").ToString
                        Final.Item("grepartir") = dsReporte.Tables("Promotor5").Rows(x)("grepartir").ToString
                        Final.Item("nombre") = dsReporte.Tables("Promotor5").Rows(x)("nombre").ToString
                        Final.Item("porpromotor") = dsReporte.Tables("Promotor5").Rows(x)("porpromotor").ToString
                        Final.Item("cantidad") = dsReporte.Tables("Promotor5").Rows(x)("cantidad").ToString
                        Final.Item("nombre2") = dsReporte.Tables("Promotor5").Rows(x)("nombre2").ToString
                        Final.Item("porpromotor2") = dsReporte.Tables("Promotor5").Rows(x)("porpromotor2").ToString
                        Final.Item("cantidad2") = dsReporte.Tables("Promotor5").Rows(x)("cantidad2").ToString
                        Final.Item("comisiontotal") = dsReporte.Tables("Promotor5").Rows(x)("comisiontotal").ToString
                        Final.Item("comisionpromotor") = dsReporte.Tables("Promotor5").Rows(x)("comisionpromotor").ToString
                        Final.Item("comisionmbc") = dsReporte.Tables("Promotor5").Rows(x)("comisionmbc").ToString
                        Final.Item("repartirmbc") = dsReporte.Tables("Promotor5").Rows(x)("repartirmbc").ToString
                        Final.Item("nombre3") = dsReporte.Tables("Promotor5").Rows(x)("nombre3").ToString
                        Final.Item("porpromotor3") = dsReporte.Tables("Promotor5").Rows(x)("porpromotor3").ToString
                        Final.Item("cantidad3") = dsReporte.Tables("Promotor5").Rows(x)("cantidad3").ToString
                        Final.Item("NombrePromotor") = dsReporte.Tables("Promotor5").Rows(x)("NombrePromotor").ToString
                        Final.Item("totalf") = dsReporte.Tables("Promotor5").Rows(x)("totalf").ToString
                        Final.Item("tipo") = dsReporte.Tables("Promotor5").Rows(x)("tipo").ToString
                        Final.Item("idpromotor") = dsReporte.Tables("Promotor5").Rows(x)("idpromotor").ToString



                        dsReporte.Tables("Final").Rows.Add(Final)
                    Next


                    For x As Integer = 0 To dsReporte.Tables("Promotor6").Rows.Count - 1
                        Dim Final As DataRow = dsReporte.Tables("Final").NewRow

                        Final.Item("fecha") = dsReporte.Tables("Promotor6").Rows(x)("fecha").ToString
                        Final.Item("iIdCliente") = dsReporte.Tables("Promotor6").Rows(x)("iIdCliente").ToString
                        Final.Item("cliente_factura") = dsReporte.Tables("Promotor6").Rows(x)("cliente_factura").ToString
                        Final.Item("empresa_factura") = dsReporte.Tables("Promotor6").Rows(x)("empresa_factura").ToString
                        Final.Item("num_factura") = dsReporte.Tables("Promotor6").Rows(x)("num_factura").ToString
                        Final.Item("subtotal") = dsReporte.Tables("Promotor6").Rows(x)("subtotal").ToString
                        Final.Item("iva") = dsReporte.Tables("Promotor6").Rows(x)("iva").ToString
                        Final.Item("total") = dsReporte.Tables("Promotor6").Rows(x)("total").ToString
                        Final.Item("abono_rango") = dsReporte.Tables("Promotor6").Rows(x)("abono_rango").ToString
                        Final.Item("abono_total") = dsReporte.Tables("Promotor6").Rows(x)("abono_total").ToString
                        Final.Item("dispersion_sa") = dsReporte.Tables("Promotor6").Rows(x)("dispersion_sa").ToString
                        Final.Item("porsa") = dsReporte.Tables("Promotor6").Rows(x)("porsa").ToString
                        Final.Item("comisionsa") = dsReporte.Tables("Promotor6").Rows(x)("comisionsa").ToString
                        Final.Item("dispersion_sin") = dsReporte.Tables("Promotor6").Rows(x)("dispersion_sin").ToString
                        Final.Item("porsin") = dsReporte.Tables("Promotor6").Rows(x)("porsin").ToString
                        Final.Item("comisionsin") = dsReporte.Tables("Promotor6").Rows(x)("comisionsin").ToString
                        Final.Item("costosocial") = dsReporte.Tables("Promotor6").Rows(x)("costosocial").ToString
                        Final.Item("retencionimss") = dsReporte.Tables("Promotor6").Rows(x)("retencionimss").ToString
                        Final.Item("clientenomina") = dsReporte.Tables("Promotor6").Rows(x)("clientenomina").ToString
                        Final.Item("empresapatrona") = dsReporte.Tables("Promotor6").Rows(x)("empresapatrona").ToString
                        Final.Item("periodo") = dsReporte.Tables("Promotor6").Rows(x)("periodo").ToString
                        Final.Item("promotor") = dsReporte.Tables("Promotor6").Rows(x)("promotor").ToString
                        Final.Item("fechanomina") = dsReporte.Tables("Promotor6").Rows(x)("fechanomina").ToString
                        'Final.Item("consecutivo") = dsReporte.Tables("Promotor3").Rows(x)("consecutivo").ToString
                        Final.Item("poradmon") = dsReporte.Tables("Promotor6").Rows(x)("poradmon").ToString
                        Final.Item("porrepartir") = dsReporte.Tables("Promotor6").Rows(x)("porrepartir").ToString
                        Final.Item("gadmon") = dsReporte.Tables("Promotor6").Rows(x)("gadmon").ToString
                        Final.Item("cuatro") = dsReporte.Tables("Promotor6").Rows(x)("cuatro").ToString
                        Final.Item("restoadmon") = dsReporte.Tables("Promotor6").Rows(x)("restoadmon").ToString
                        Final.Item("grepartir") = dsReporte.Tables("Promotor6").Rows(x)("grepartir").ToString
                        Final.Item("nombre") = dsReporte.Tables("Promotor6").Rows(x)("nombre").ToString
                        Final.Item("porpromotor") = dsReporte.Tables("Promotor6").Rows(x)("porpromotor").ToString
                        Final.Item("cantidad") = dsReporte.Tables("Promotor6").Rows(x)("cantidad").ToString
                        Final.Item("nombre2") = dsReporte.Tables("Promotor6").Rows(x)("nombre2").ToString
                        Final.Item("porpromotor2") = dsReporte.Tables("Promotor6").Rows(x)("porpromotor2").ToString
                        Final.Item("cantidad2") = dsReporte.Tables("Promotor6").Rows(x)("cantidad2").ToString
                        Final.Item("comisiontotal") = dsReporte.Tables("Promotor6").Rows(x)("comisiontotal").ToString
                        Final.Item("comisionpromotor") = dsReporte.Tables("Promotor6").Rows(x)("comisionpromotor").ToString
                        Final.Item("comisionmbc") = dsReporte.Tables("Promotor6").Rows(x)("comisionmbc").ToString
                        Final.Item("repartirmbc") = dsReporte.Tables("Promotor6").Rows(x)("repartirmbc").ToString
                        Final.Item("nombre3") = dsReporte.Tables("Promotor6").Rows(x)("nombre3").ToString
                        Final.Item("porpromotor3") = dsReporte.Tables("Promotor6").Rows(x)("porpromotor3").ToString
                        Final.Item("cantidad3") = dsReporte.Tables("Promotor6").Rows(x)("cantidad3").ToString
                        Final.Item("NombrePromotor") = dsReporte.Tables("Promotor6").Rows(x)("NombrePromotor").ToString
                        Final.Item("totalf") = dsReporte.Tables("Promotor6").Rows(x)("totalf").ToString
                        Final.Item("tipo") = dsReporte.Tables("Promotor6").Rows(x)("tipo").ToString
                        Final.Item("idpromotor") = dsReporte.Tables("Promotor6").Rows(x)("idpromotor").ToString



                        dsReporte.Tables("Final").Rows.Add(Final)
                    Next

                    '##################
                    '#########
                    'ENVIAR A EXCEL

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

                    hoja.Column("W").Width = 15
                    hoja.Column("X").Width = 15
                    hoja.Column("Y").Width = 15
                    hoja.Column("Z").Width = 15
                    hoja.Column("AA").Width = 16
                    hoja.Column("AB").Width = 15
                    hoja.Column("AC").Width = 15
                    hoja.Column("AD").Width = 15
                    hoja.Column("AE").Width = 45
                    hoja.Column("AF").Width = 15
                    hoja.Column("AG").Width = 15
                    hoja.Column("AH").Width = 45
                    hoja.Column("AI").Width = 15
                    hoja.Column("AJ").Width = 15
                    hoja.Column("AK").Width = 15
                    hoja.Column("AL").Width = 15
                    hoja.Column("AM").Width = 15
                    hoja.Column("AN").Width = 15
                    hoja.Column("AO").Width = 45
                    hoja.Column("AP").Width = 15
                    hoja.Column("AQ").Width = 15
                    hoja.Column("AR").Width = 45
                    hoja.Column("AS").Width = 15
                    hoja.Column("AT").Width = 15
                    hoja.Column("AU").Width = 15

                    hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                    hoja.Cell(3, 2).Value = "COMISIONES"

                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 2, 4, 47).Style.Font.FontSize = 10
                    hoja.Range(4, 2, 4, 47).Style.Font.SetBold(True)
                    hoja.Range(4, 2, 4, 47).Style.Alignment.WrapText = True
                    hoja.Range(4, 2, 4, 47).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 47).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 2, 4, 47).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 2, 4, 47).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 2).Value = "Fecha"
                    hoja.Cell(4, 3).Value = "Cliente factura"
                    hoja.Cell(4, 4).Value = "Empresa factura"
                    hoja.Cell(4, 5).Value = "Num Fact"
                    hoja.Cell(4, 6).Value = "Subtotal"
                    hoja.Range(5, 6, 1500, 6).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 7).Value = "Iva"
                    hoja.Range(5, 7, 1500, 7).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 8).Value = "Total"
                    hoja.Range(5, 8, 1500, 8).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 9).Value = "Abono Rango Fechas"
                    hoja.Range(5, 9, 1500, 9).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 10).Value = "Abono Total"
                    hoja.Range(5, 10, 1500, 10).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 11).Value = "Dispersion SA"
                    hoja.Range(5, 11, 1500, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 12).Value = "% SA"
                    hoja.Cell(4, 13).Value = "Comisión SA"
                    hoja.Range(5, 13, 1500, 13).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 14).Value = "Dispersion Sindicato"
                    hoja.Range(5, 14, 1500, 14).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 15).Value = "% Sindicato"
                    hoja.Cell(4, 16).Value = "Comisión Sindicato"
                    hoja.Range(5, 16, 1500, 16).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 17).Value = "Costo Social"
                    hoja.Range(5, 17, 1500, 17).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 18).Value = "Retención imss"
                    hoja.Range(5, 18, 1500, 18).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 19).Value = "Cliente Nomina"
                    hoja.Cell(4, 20).Value = "Empresa patrona"
                    hoja.Cell(4, 21).Value = "Periodo"
                    hoja.Cell(4, 22).Value = "Promotor"
                    hoja.Cell(4, 23).Value = "Fecha Nomina"

                    'hoja.Cell(4, 24).Value = 
                    hoja.Cell(4, 25).Value = "% Admon"
                    hoja.Cell(4, 26).Value = "% Repartir"
                    hoja.Cell(4, 27).Value = "Cant Admon"
                    hoja.Range(5, 27, 1500, 27).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 28).Value = "4%"
                    hoja.Range(5, 28, 1500, 28).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 29).Value = "Resto Cant Admon"
                    hoja.Range(5, 29, 1500, 29).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 30).Value = "Cant Repartir"
                    hoja.Range(5, 30, 1500, 30).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 31).Value = "Nombre Pro 1"
                    hoja.Cell(4, 32).Value = "% Pro 1"
                    hoja.Cell(4, 33).Value = "Cantidad"
                    hoja.Range(5, 33, 1500, 33).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 34).Value = "Nombre Pro 2"
                    hoja.Cell(4, 35).Value = "% Pro 2"
                    hoja.Cell(4, 36).Value = "Cantidad"
                    hoja.Range(5, 36, 1500, 36).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 37).Value = "Comisión C"
                    hoja.Range(5, 37, 1500, 37).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 38).Value = "Comisión Pro"
                    hoja.Range(5, 38, 1500, 38).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 39).Value = "Comisión MBC"
                    hoja.Range(5, 39, 1500, 39).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 40).Value = "Repartir MBC"
                    hoja.Range(5, 40, 1500, 40).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 41).Value = "Nombre Pro 3"
                    hoja.Cell(4, 42).Value = "% Pro 3"
                    hoja.Cell(4, 43).Value = "Cantidad"
                    hoja.Range(5, 43, 1500, 43).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 44).Value = "Nombre Promotor"
                    hoja.Cell(4, 45).Value = "Total Registro"
                    hoja.Range(5, 45, 200, 45).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    hoja.Cell(4, 46).Value = "Tipo"
                    hoja.Cell(4, 47).Value = "Id Promotor"


                    'dsReporte.Tables("Final").AsDataView.Sort = "idpromotor ASC"
                    Dim tabla As DataTable = dsReporte.Tables("Final")
                    ''Dim vista As DataView = tabla.AsDataView()
                    ''vista.Sort = "idpromotor ASC"
                    Dim Query = From order In tabla.AsEnumerable() Order By order.Field(Of String)("idpromotor") Select order
                    'dsOrdenamiento.Tables.Add(.ToTable)
                    dsOrdenamiento.Tables.Add(Query.AsDataView.ToTable)

                    filaExcel = 5

                    For x As Integer = 0 To dsOrdenamiento.Tables("Final").Rows.Count - 1

                        hoja.Cell(filaExcel, 2).Value = dsOrdenamiento.Tables("Final").Rows(x)("fecha").ToString
                        hoja.Cell(filaExcel, 3).Value = dsOrdenamiento.Tables("Final").Rows(x)("cliente_factura").ToString
                        hoja.Cell(filaExcel, 4).Value = dsOrdenamiento.Tables("Final").Rows(x)("empresa_factura").ToString
                        hoja.Cell(filaExcel, 5).Value = dsOrdenamiento.Tables("Final").Rows(x)("num_factura").ToString
                        hoja.Cell(filaExcel, 6).Value = dsOrdenamiento.Tables("Final").Rows(x)("subtotal").ToString
                        hoja.Cell(filaExcel, 7).Value = dsOrdenamiento.Tables("Final").Rows(x)("iva").ToString
                        hoja.Cell(filaExcel, 8).Value = dsOrdenamiento.Tables("Final").Rows(x)("total").ToString
                        hoja.Cell(filaExcel, 9).Value = dsOrdenamiento.Tables("Final").Rows(x)("abono_rango").ToString
                        hoja.Cell(filaExcel, 10).Value = dsOrdenamiento.Tables("Final").Rows(x)("abono_total").ToString
                        hoja.Cell(filaExcel, 11).Value = dsOrdenamiento.Tables("Final").Rows(x)("dispersion_sa").ToString
                        hoja.Cell(filaExcel, 12).Value = dsOrdenamiento.Tables("Final").Rows(x)("porsa").ToString
                        hoja.Cell(filaExcel, 13).Value = dsOrdenamiento.Tables("Final").Rows(x)("comisionsa").ToString
                        hoja.Cell(filaExcel, 14).Value = dsOrdenamiento.Tables("Final").Rows(x)("dispersion_sin").ToString
                        hoja.Cell(filaExcel, 15).Value = dsOrdenamiento.Tables("Final").Rows(x)("porsin").ToString
                        hoja.Cell(filaExcel, 16).Value = dsOrdenamiento.Tables("Final").Rows(x)("comisionsin").ToString
                        hoja.Cell(filaExcel, 17).Value = dsOrdenamiento.Tables("Final").Rows(x)("costosocial").ToString
                        hoja.Cell(filaExcel, 18).Value = dsOrdenamiento.Tables("Final").Rows(x)("retencionimss").ToString
                        hoja.Cell(filaExcel, 19).Value = dsOrdenamiento.Tables("Final").Rows(x)("clientenomina").ToString
                        hoja.Cell(filaExcel, 20).Value = dsOrdenamiento.Tables("Final").Rows(x)("empresapatrona").ToString
                        hoja.Cell(filaExcel, 21).Value = dsOrdenamiento.Tables("Final").Rows(x)("periodo").ToString
                        hoja.Cell(filaExcel, 22).Value = dsOrdenamiento.Tables("Final").Rows(x)("promotor").ToString
                        hoja.Cell(filaExcel, 23).Value = dsOrdenamiento.Tables("Final").Rows(x)("fechanomina").ToString

                        'hoja.Cell(filaExcel, 24).Value = dsReporte.Tables("Final").Rows(x)("consecutivo").ToString
                        hoja.Cell(filaExcel, 25).Value = dsOrdenamiento.Tables("Final").Rows(x)("poradmon").ToString
                        hoja.Cell(filaExcel, 26).Value = dsOrdenamiento.Tables("Final").Rows(x)("porrepartir").ToString
                        hoja.Cell(filaExcel, 27).Value = dsOrdenamiento.Tables("Final").Rows(x)("gadmon").ToString
                        hoja.Cell(filaExcel, 28).Value = dsOrdenamiento.Tables("Final").Rows(x)("cuatro").ToString
                        hoja.Cell(filaExcel, 29).Value = dsOrdenamiento.Tables("Final").Rows(x)("restoadmon").ToString
                        hoja.Cell(filaExcel, 30).Value = dsOrdenamiento.Tables("Final").Rows(x)("grepartir").ToString
                        hoja.Cell(filaExcel, 31).Value = dsOrdenamiento.Tables("Final").Rows(x)("nombre").ToString
                        hoja.Cell(filaExcel, 32).Value = dsOrdenamiento.Tables("Final").Rows(x)("porpromotor").ToString
                        hoja.Cell(filaExcel, 33).Value = dsOrdenamiento.Tables("Final").Rows(x)("cantidad").ToString
                        hoja.Cell(filaExcel, 34).Value = dsOrdenamiento.Tables("Final").Rows(x)("nombre2").ToString
                        hoja.Cell(filaExcel, 35).Value = dsOrdenamiento.Tables("Final").Rows(x)("porpromotor2").ToString
                        hoja.Cell(filaExcel, 36).Value = dsOrdenamiento.Tables("Final").Rows(x)("cantidad2").ToString
                        hoja.Cell(filaExcel, 37).Value = dsOrdenamiento.Tables("Final").Rows(x)("comisiontotal").ToString
                        hoja.Cell(filaExcel, 38).Value = dsOrdenamiento.Tables("Final").Rows(x)("comisionpromotor").ToString
                        hoja.Cell(filaExcel, 39).Value = dsOrdenamiento.Tables("Final").Rows(x)("comisionmbc").ToString
                        hoja.Cell(filaExcel, 40).Value = dsOrdenamiento.Tables("Final").Rows(x)("repartirmbc").ToString
                        hoja.Cell(filaExcel, 41).Value = dsOrdenamiento.Tables("Final").Rows(x)("nombre3").ToString
                        hoja.Cell(filaExcel, 42).Value = dsOrdenamiento.Tables("Final").Rows(x)("porpromotor3").ToString
                        hoja.Cell(filaExcel, 43).Value = dsOrdenamiento.Tables("Final").Rows(x)("cantidad3").ToString
                        hoja.Cell(filaExcel, 44).Value = dsOrdenamiento.Tables("Final").Rows(x)("NombrePromotor").ToString
                        hoja.Cell(filaExcel, 45).Value = dsOrdenamiento.Tables("Final").Rows(x)("totalf").ToString
                        hoja.Cell(filaExcel, 46).Value = dsOrdenamiento.Tables("Final").Rows(x)("tipo").ToString
                        hoja.Cell(filaExcel, 47).Value = dsOrdenamiento.Tables("Final").Rows(x)("idpromotor").ToString


                        filaExcel = filaExcel + 1

                    Next


                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Comisiones"
                    dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                    dialogo.ShowDialog()
                    libro.SaveAs(dialogo.FileName)
                    'libro.SaveAs("c:\temp\control.xlsx")
                    'libro.SaveAs(dialogo.FileName)
                    'apExcel.Quit()
                    libro = Nothing

                    MessageBox.Show("Número de facturas encontradas:" & consecutivocontrol & " Número de facturas procesadas: " & encontradas & ". Proceso terminado correctamente" & vbCrLf & "Clientes no procesados:" & vbCrLf & nombreclientes, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmComisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarPlaza()
    End Sub

    Private Sub MostrarPlaza()
        Dim sql As String
        sql = "Select * from CatPlaza"
        nCargaCBO(cboplaza, Sql, "nombre", "iIdPlaza")
    End Sub
End Class