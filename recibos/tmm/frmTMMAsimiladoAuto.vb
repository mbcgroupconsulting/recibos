Imports CrystalDecisions.CrystalReports.Engine
Imports ClosedXML.Excel
Imports System.IO
Imports System.Text.RegularExpressions
Public Class frmTMMAsimiladoAuto
    Dim sheetIndex As Integer = -1
    Dim Periodo As String
    Dim Periodocom As String
    Dim direccioncarpeta As String
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
        Dim dialogo As New OpenFileDialog
        lblRuta.Text = ""
        With dialogo
            .Title = "Búsqueda de archivos de saldos."
            .Filter = "Hoja de cálculo de excel (xlsx)|*.xlsx;*.xlsm;"
            .CheckFileExists = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                lblRuta.Text = .FileName
            End If
        End With
        tsbProcesar.Enabled = lblRuta.Text.Length > 0
        If tsbProcesar.Enabled Then
            tsbProcesar_Click(sender, e)
        End If



    End Sub

    Private Sub tsbGuardar_Click(sender As Object, e As EventArgs) Handles tsbGuardar.Click
        Try
            Dim SQL As String

            Dim ISRRECIBO As Double
            Dim NETORECIBO As Double
            Dim PRESTAMORECIBO As Double
            Dim DESCUENTOINFRECIBO As Double
            Dim DIFINFONAVITRECIBO As Double
            Dim TOTALRECIBO As Double



            Dim propuesta As Double
            Dim bruto As Double
            Dim excendente As Double
            Dim isr As Double
            Dim perpecionneta As Double
            Dim impuestonomina As Double
            Dim comision As Double
            Dim diferencia As Double
            Dim calculado As Double

            If lsvLista.CheckedItems.Count > 0 Then
                Dim mensaje As String


                pnlProgreso.Visible = True
                pnlCatalogo.Enabled = False
                Application.DoEvents()


                Dim IdProducto As Long
                Dim i As Integer = 0
                Dim conta As Integer = 0
                Dim percepciones As Double
                Dim deducciones As Double
                Dim neto As Double
                'Dim isr As Double

                Dim subsidio As Double
                Dim totalp As Double
                Dim totald As Double




                pgbProgreso.Minimum = 0
                pgbProgreso.Value = 0
                pgbProgreso.Maximum = lsvLista.CheckedItems.Count


                'Dim fila As New DataRow

                'Dim fiscaltmm As New frmReciboTMM

                Dim dsReporte As New DataSet

                dsReporte.Tables.Add("Tabla")
                dsReporte.Tables("Tabla").Columns.Add("numtrabajador")
                dsReporte.Tables("Tabla").Columns.Add("nombre")
                dsReporte.Tables("Tabla").Columns.Add("buque")
                dsReporte.Tables("Tabla").Columns.Add("puesto")
                dsReporte.Tables("Tabla").Columns.Add("periodo")
                dsReporte.Tables("Tabla").Columns.Add("Sueldobase")
                dsReporte.Tables("Tabla").Columns.Add("Tefijo")
                dsReporte.Tables("Tabla").Columns.Add("Teadicional")
                dsReporte.Tables("Tabla").Columns.Add("bonoseguridad")
                dsReporte.Tables("Tabla").Columns.Add("tiporecibo")
                dsReporte.Tables("Tabla").Columns.Add("mespago")
                dsReporte.Tables("Tabla").Columns.Add("diastrabajados")
                dsReporte.Tables("Tabla").Columns.Add("diasviajando")
                dsReporte.Tables("Tabla").Columns.Add("fechaelaboracion")
                dsReporte.Tables("Tabla").Columns.Add("vacaciones")
                dsReporte.Tables("Tabla").Columns.Add("alimentovac")
                dsReporte.Tables("Tabla").Columns.Add("bonoxbuque")
                dsReporte.Tables("Tabla").Columns.Add("bonoespecial")
                dsReporte.Tables("Tabla").Columns.Add("tpercepciones")
                dsReporte.Tables("Tabla").Columns.Add("tdeducciones")
                dsReporte.Tables("Tabla").Columns.Add("neto")

                dsReporte.Tables.Add("Percepciones")
                dsReporte.Tables("Percepciones").Columns.Add("numtrabajador")
                dsReporte.Tables("Percepciones").Columns.Add("dias")
                dsReporte.Tables("Percepciones").Columns.Add("concepto")
                dsReporte.Tables("Percepciones").Columns.Add("monto")

                dsReporte.Tables.Add("Deducciones")
                dsReporte.Tables("Deducciones").Columns.Add("numtrabajador")
                dsReporte.Tables("Deducciones").Columns.Add("dias")
                dsReporte.Tables("Deducciones").Columns.Add("concepto")
                dsReporte.Tables("Deducciones").Columns.Add("monto")

                'Seleccionar carpeta donde guardar los archivos
                Dim Carpeta = New FolderBrowserDialog
                If Carpeta.ShowDialog() = DialogResult.OK Then
                    direccioncarpeta = Carpeta.SelectedPath
                Else
                    Exit Sub
                End If




                For Each producto As ListViewItem In lsvLista.CheckedItems

                    Dim netoasimilado As Double = Double.Parse(IIf(producto.SubItems(52).Text = "", "0", producto.SubItems(52).Text))

                    If netoasimilado > 0 Then
                        '###### CALCULAMOS EL ISR ##################
                        propuesta = Double.Parse(producto.SubItems(52).Text) / 30
                        bruto = propuesta * 30

                        Do
                            bruto = propuesta * 30
                            'calculos

                            'Calculamos isr

                            '1.- buscamos datos para el calculo

                            isr = fisr(bruto)


                            'dtgDatos.Rows(x).Cells(3).Value = propuesta

                            calculado = bruto - isr





                            If Math.Round((calculado), 2) = Math.Round(Double.Parse(producto.SubItems(52).Text), 2) Then
                                'el sueldo de la propuesta es correcto
                                'dtgDatos.Rows(x).Cells(3).Value = propuesta

                                'MessageBox.Show("propuesta:" & isr.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            Else
                                If calculado > Double.Parse(producto.SubItems(52).Text) Then

                                    diferencia = (calculado) - Double.Parse(producto.SubItems(52).Text)
                                    If diferencia > 1000 Then
                                        propuesta = propuesta - 150
                                    ElseIf diferencia > 500 And diferencia < 999.999 Then
                                        propuesta = propuesta - 70
                                    ElseIf diferencia > 300 And diferencia < 499.999 Then
                                        propuesta = propuesta - 15
                                    ElseIf diferencia > 100 And diferencia < 299.999 Then
                                        propuesta = propuesta - 10
                                    ElseIf diferencia > 50 And diferencia < 99.999 Then
                                        propuesta = propuesta - 5
                                    ElseIf diferencia > 20 And diferencia < 49.999 Then
                                        propuesta = propuesta - 1
                                    ElseIf diferencia > 10 And diferencia < 19.999 Then
                                        propuesta = propuesta - 0.5
                                    ElseIf diferencia > 5 And diferencia < 9.999 Then
                                        propuesta = propuesta - 0.4
                                    ElseIf diferencia > 4.5 And diferencia < 4.999 Then
                                        propuesta = propuesta - 0.3
                                    ElseIf diferencia > 4 And diferencia < 4.499 Then
                                        propuesta = propuesta - 0.2
                                    ElseIf diferencia > 3.5 And diferencia < 3.999 Then
                                        propuesta = propuesta - 0.15
                                    ElseIf diferencia > 3 And diferencia < 3.499 Then
                                        propuesta = propuesta - 0.1
                                    ElseIf diferencia > 2.5 And diferencia < 2.999 Then
                                        propuesta = propuesta - 0.05
                                    ElseIf diferencia > 2 And diferencia < 2.499 Then
                                        propuesta = propuesta - 0.04
                                    ElseIf diferencia > 1 And diferencia < 1.999 Then
                                        propuesta = propuesta - 0.01
                                    ElseIf diferencia > 0.5 And diferencia < 0.999 Then
                                        propuesta = propuesta - 0.008
                                    ElseIf diferencia > 0.2 And diferencia < 0.49 Then
                                        propuesta = propuesta - 0.005
                                    ElseIf diferencia > 0.1 And diferencia < 0.19 Then
                                        propuesta = propuesta - 0.0001
                                    Else
                                        propuesta = propuesta - 0.0001

                                    End If

                                Else
                                    diferencia = Double.Parse(producto.SubItems(52).Text) - (calculado)
                                    If diferencia > 1000 Then
                                        propuesta = propuesta + 100
                                    ElseIf diferencia > 500 And diferencia < 999.999 Then
                                        propuesta = propuesta + 40
                                    ElseIf diferencia > 300 And diferencia < 499.999 Then
                                        propuesta = propuesta + 30
                                    ElseIf diferencia > 100 And diferencia < 299.999 Then
                                        propuesta = propuesta + 20
                                    ElseIf diferencia > 50 And diferencia < 99.999 Then
                                        propuesta = propuesta + 3
                                    ElseIf diferencia > 20 And diferencia < 49.999 Then
                                        propuesta = propuesta + 1
                                    ElseIf diferencia > 10 And diferencia < 19.999 Then
                                        propuesta = propuesta + 0.5
                                    ElseIf diferencia > 5 And diferencia < 9.999 Then
                                        propuesta = propuesta + 0.3
                                    ElseIf diferencia > 3 And diferencia < 4.999 Then
                                        propuesta = propuesta + 0.2
                                    ElseIf diferencia > 1 And diferencia < 2.999 Then
                                        propuesta = propuesta + 0.15
                                    ElseIf diferencia > 0.5 And diferencia < 0.999 Then
                                        propuesta = propuesta + 0.1
                                    ElseIf diferencia > 0.2 And diferencia < 0.49 Then
                                        propuesta = propuesta + 0.05
                                    ElseIf diferencia > 0.1 And diferencia < 0.19 Then
                                        propuesta = propuesta + 0.01
                                    Else
                                        propuesta = propuesta + 0.0001

                                    End If




                                End If
                            End If



                        Loop While Math.Round((calculado), 2) <> Math.Round(Double.Parse(producto.SubItems(52).Text), 2)
                        '###### FIN CALCULO ISR #######

                        ISRRECIBO = isr
                        NETORECIBO = Double.Parse(producto.SubItems(52).Text)
                        PRESTAMORECIBO = Double.Parse(IIf(producto.SubItems(49).Text = "", 0, producto.SubItems(49).Text))
                        DESCUENTOINFRECIBO = Double.Parse(IIf(producto.SubItems(50).Text = "", 0, producto.SubItems(50).Text))
                        DIFINFONAVITRECIBO = Double.Parse(IIf(producto.SubItems(51).Text = "", 0, producto.SubItems(51).Text))
                        TOTALRECIBO = ISRRECIBO + NETORECIBO + PRESTAMORECIBO + DESCUENTOINFRECIBO + DIFINFONAVITRECIBO



                        totald = 0
                        totalp = 0

                        dsReporte.Clear()



                        'percepciones = Val(IIf(Trim(producto.SubItems(20).Text) = "", "0", Trim(producto.SubItems(20).Text)))
                        'deducciones = Val(IIf(Trim(producto.SubItems(21).Text) = "", "0", Trim(producto.SubItems(21).Text)))
                        'neto = Val(IIf(Trim(producto.SubItems(22).Text) = "", "0", Trim(producto.SubItems(22).Text)))

                        Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow
                        fila.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                        fila.Item("nombre") = Trim(producto.SubItems(2).Text)
                        fila.Item("buque") = Trim(producto.SubItems(10).Text)
                        fila.Item("periodo") = DateSerial(Year(dtpfecha.Value), Month(dtpfecha.Value), 1).ToShortDateString & " - " & DateSerial(Year(dtpfecha.Value), Month(dtpfecha.Value) + 1, 0).ToShortDateString
                        fila.Item("puesto") = Trim(producto.SubItems(9).Text)
                        fila.Item("Sueldobase") = "0"
                        fila.Item("Tefijo") = "0"
                        fila.Item("Teadicional") = "0"
                        fila.Item("bonoseguridad") = "0"
                        fila.Item("tiporecibo") = "Detalle de pago. Depósito"
                        fila.Item("mespago") = Date.Parse(dtpfecha.Value).Month  'CDate(Periodo).Month.ToString()
                        fila.Item("diastrabajados") = Trim(producto.SubItems(15).Text)
                        fila.Item("diasviajando") = Trim(producto.SubItems(15).Text)
                        fila.Item("fechaelaboracion") = Date.Parse(dtpfecha.Value).ToShortDateString
                        fila.Item("vacaciones") = "0"
                        fila.Item("alimentovac") = "0"
                        fila.Item("bonoxbuque") = "0"
                        fila.Item("bonoespecial") = "0"
                        fila.Item("tpercepciones") = Math.Round(TOTALRECIBO, 2).ToString("#,###,##0.00")
                        fila.Item("tdeducciones") = Math.Round(ISRRECIBO + PRESTAMORECIBO + DESCUENTOINFRECIBO + DIFINFONAVITRECIBO, 2).ToString("#,###,##0.00")

                        fila.Item("neto") = Math.Round(TOTALRECIBO - ISRRECIBO - PRESTAMORECIBO - DESCUENTOINFRECIBO - DIFINFONAVITRECIBO, 2).ToString("#,###,##0.00")

                        dsReporte.Tables("Tabla").Rows.Add(fila)


                        'HONORARIOS ASIMILABLES

                        Dim ASIMILABLES As DataRow = dsReporte.Tables("Percepciones").NewRow
                        ASIMILABLES.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                        ASIMILABLES.Item("dias") = Trim(producto.SubItems(15).Text)
                        ASIMILABLES.Item("concepto") = "HONORARIOS ASIMILABLES"
                        ASIMILABLES.Item("monto") = Math.Round(TOTALRECIBO / 2, 2).ToString("#,###,##0.00")
                        dsReporte.Tables("Percepciones").Rows.Add(ASIMILABLES)


                        'HONORARIOS ASIMILABLES A
                        Dim ASIMILABLESA As DataRow = dsReporte.Tables("Percepciones").NewRow
                        ASIMILABLESA.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                        ASIMILABLESA.Item("dias") = Trim(producto.SubItems(15).Text)
                        ASIMILABLESA.Item("concepto") = "HONORARIOS ASIMILABLES A"
                        ASIMILABLESA.Item("monto") = Math.Round(TOTALRECIBO / 2, 2).ToString("#,###,##0.00")
                        dsReporte.Tables("Percepciones").Rows.Add(ASIMILABLESA)

                        If PRESTAMORECIBO > 0 Then
                            'DEDUCCIONES
                            'PRESTAMORECIBO
                            Dim PRESTAMO As DataRow = dsReporte.Tables("Deducciones").NewRow
                            PRESTAMO.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                            PRESTAMO.Item("dias") = Trim(producto.SubItems(15).Text)
                            PRESTAMO.Item("concepto") = lsvLista.Columns(49).Text
                            PRESTAMO.Item("monto") = Math.Round(PRESTAMORECIBO / 2, 2).ToString("#,###,##0.00")
                            dsReporte.Tables("Deducciones").Rows.Add(PRESTAMO)

                            'PRESTAMORECIBOA
                            Dim PRESTAMOA As DataRow = dsReporte.Tables("Deducciones").NewRow
                            PRESTAMOA.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                            PRESTAMOA.Item("dias") = Trim(producto.SubItems(15).Text)
                            PRESTAMOA.Item("concepto") = lsvLista.Columns(49).Text & " A"
                            PRESTAMOA.Item("monto") = Math.Round(PRESTAMORECIBO / 2, 2).ToString("#,###,##0.00")
                            dsReporte.Tables("Deducciones").Rows.Add(PRESTAMOA)
                        End If

                        If DESCUENTOINFRECIBO > 0 Then
                            'DESCUENTOINFRECIBO

                            Dim DSCTOINF As DataRow = dsReporte.Tables("Deducciones").NewRow
                            DSCTOINF.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                            DSCTOINF.Item("dias") = Trim(producto.SubItems(15).Text)
                            DSCTOINF.Item("concepto") = lsvLista.Columns(50).Text
                            DSCTOINF.Item("monto") = Math.Round(DESCUENTOINFRECIBO / 2, 2).ToString("#,###,##0.00")
                            dsReporte.Tables("Deducciones").Rows.Add(DSCTOINF)

                            'DESCUENTOINFRECIBOA

                            Dim DSCTOINFA As DataRow = dsReporte.Tables("Deducciones").NewRow
                            DSCTOINFA.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                            DSCTOINFA.Item("dias") = Trim(producto.SubItems(15).Text)
                            DSCTOINFA.Item("concepto") = lsvLista.Columns(50).Text & " A"
                            DSCTOINFA.Item("monto") = Math.Round(DESCUENTOINFRECIBO / 2, 2).ToString("#,###,##0.00")
                            dsReporte.Tables("Deducciones").Rows.Add(DSCTOINFA)
                        End If


                        If DIFINFONAVITRECIBO > 0 Then
                            'DIFINFONAVITRECIBO

                            Dim DIFINFONAVIT As DataRow = dsReporte.Tables("Deducciones").NewRow
                            DIFINFONAVIT.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                            DIFINFONAVIT.Item("dias") = Trim(producto.SubItems(15).Text)
                            DIFINFONAVIT.Item("concepto") = lsvLista.Columns(51).Text
                            DIFINFONAVIT.Item("monto") = Math.Round(DIFINFONAVITRECIBO / 2, 2).ToString("#,###,##0.00")
                            dsReporte.Tables("Deducciones").Rows.Add(DIFINFONAVIT)

                            'DIFINFONAVITRECIBOA

                            Dim DIFINFONAVITA As DataRow = dsReporte.Tables("Deducciones").NewRow
                            DIFINFONAVITA.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                            DIFINFONAVITA.Item("dias") = Trim(producto.SubItems(15).Text)
                            DIFINFONAVITA.Item("concepto") = lsvLista.Columns(51).Text & " A"
                            DIFINFONAVITA.Item("monto") = Math.Round(DIFINFONAVITRECIBO / 2, 2).ToString("#,###,##0.00")
                            dsReporte.Tables("Deducciones").Rows.Add(DIFINFONAVITA)


                        End If



                        'RETENCION ISR

                        Dim RETISR As DataRow = dsReporte.Tables("Deducciones").NewRow
                        RETISR.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                        RETISR.Item("dias") = Trim(producto.SubItems(15).Text)
                        RETISR.Item("concepto") = "RETENCION ISR"
                        RETISR.Item("monto") = Math.Round(ISRRECIBO / 2, 2).ToString("#,###,##0.00")
                        dsReporte.Tables("Deducciones").Rows.Add(RETISR)

                        'RETENCION ISR A

                        Dim RETISRA As DataRow = dsReporte.Tables("Deducciones").NewRow
                        RETISRA.Item("numtrabajador") = Trim(producto.SubItems(1).Text)
                        RETISRA.Item("dias") = Trim(producto.SubItems(15).Text)
                        RETISRA.Item("concepto") = "RETENCION ISR"
                        RETISRA.Item("monto") = Math.Round(ISRRECIBO / 2, 2).ToString("#,###,##0.00")
                        dsReporte.Tables("Deducciones").Rows.Add(RETISRA)

                        pgbProgreso.Value += 1
                        Application.DoEvents()
                        'mandar el reporte
                        ''Dim reporte = New ReportDocument
                        'Dim oReporte As ReportDocument = Nothing

                        'reporte.FileName = "tmm"

                        'reporte.FileName = Application.StartupPath & "\Reportes\tmm.rpt"
                        Dim oReporte As New asimiladostmm
                        oReporte.SetDataSource(dsReporte)
                        oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value).Month.ToString("00") & CDate(dtpfecha.Value).Year.ToString() & Trim(producto.SubItems(1).Text) & "SIM.pdf")
                        ''reporte.Load(Application.StartupPath & "\reportes\asitmm.rpt")
                        ''reporte.SetDataSource(dsReporte)
                        ''reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value).Month.ToString("00") & CDate(dtpfecha.Value).Year.ToString() & Trim(producto.SubItems(1).Text) & "ASIM.pdf")


                    End If


                    

                Next


                '###### FIN CALCULO ISR #######


                


                'Dim Archivo As String = IO.Path.GetTempFileName.Replace(".tmp", ".xml")
                'dsReporte.WriteXml(Archivo, XmlWriteMode.WriteSchema)

                'fiscaltmm.ShowDialog()
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                MessageBox.Show("Por favor seleccione al menos un trabajador para generar el recibo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Function fisr(bruto As Double) As Double
        Dim sql As String
        Dim excendente As Double
        Dim isr As Double
        Try
            sql = "select * from isr where ((" & bruto & ">=isr.limiteinf and " & bruto & "<=isr.limitesup)"
            sql &= " or (" & bruto & ">=isr.limiteinf and isr.limitesup=0)) and fkiIdTipoPeriodo2=1" '& cboperiodo.SelectedValue

            Dim rwISRCALCULO As DataRow() = nConsulta(sql)

            If rwISRCALCULO Is Nothing = False Then
                excendente = bruto - Double.Parse(rwISRCALCULO(0)("limiteinf").ToString)
                isr = (excendente * (Double.Parse(rwISRCALCULO(0)("porcentaje").ToString) / 100)) + Double.Parse(rwISRCALCULO(0)("cuotafija").ToString)

            End If
            Return isr
        Catch ex As Exception
            Return 0
        End Try






    End Function

    Private Sub tsbProcesar_Click(sender As Object, e As EventArgs) Handles tsbProcesar.Click
        lsvLista.Items.Clear()
        lsvLista.Columns.Clear()
        lsvLista.Clear()

        pnlCatalogo.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        lsvLista.Visible = False
        tsbImportar.Enabled = False
        Me.cmdCerrar.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        Application.DoEvents()

        Try
            If File.Exists(lblRuta.Text) Then
                Dim Archivo As String = lblRuta.Text
                Dim Hoja As String


                Dim book As New ClosedXML.Excel.XLWorkbook(Archivo)
                If book.Worksheets.Count >= 1 Then
                    sheetIndex = 1
                    If book.Worksheets.Count > 1 Then
                        Dim Forma As New frmHojasNomina
                        Dim Hojas As String = ""
                        For i As Integer = 0 To book.Worksheets.Count - 1
                            Hojas &= book.Worksheets(i).Name & IIf(i < (book.Worksheets.Count - 1), "|", "")
                        Next
                        Forma.Hojas = Hojas
                        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                            sheetIndex = Forma.selectedIndex + 1
                        Else
                            Exit Sub
                        End If
                    End If
                    Hoja = book.Worksheet(sheetIndex).Name
                    Dim sheet As IXLWorksheet = book.Worksheet(sheetIndex)

                    Dim colIni As Integer = sheet.FirstColumnUsed().ColumnNumber()
                    Dim colFin As Integer = sheet.LastColumnUsed().ColumnNumber()
                    Dim Columna As String
                    Dim numerocolumna As Integer = 1


                    lsvLista.Columns.Add("#")
                    For c As Integer = colIni To colFin

                        lsvLista.Columns.Add(sheet.Cell(5, c).Value.ToString)
                        numerocolumna = numerocolumna + 1

                    Next

                    'lsvLista.Columns.Add("conciliacion")
                    'lsvLista.Columns.Add("color")

                    lsvLista.Columns(1).Width = 90
                    lsvLista.Columns(2).Width = 400
                    lsvLista.Columns(3).Width = 100
                    lsvLista.Columns(3).TextAlign = 1
                    lsvLista.Columns(4).Width = 100
                    lsvLista.Columns(4).TextAlign = 1
                    lsvLista.Columns(5).Width = 100
                    lsvLista.Columns(5).TextAlign = 1
                    lsvLista.Columns(6).Width = 350

                    Dim Filas As Long = sheet.RowsUsed().Count()
                    For f As Integer = 6 To Filas
                        Dim item As ListViewItem = lsvLista.Items.Add((f - 6).ToString())
                        For c As Integer = colIni To colFin
                            Try

                                Dim Valor As String = ""
                                If (sheet.Cell(f, c).ValueCached Is Nothing) Then
                                    Valor = sheet.Cell(f, c).Value.ToString()
                                Else
                                    Valor = sheet.Cell(f, c).ValueCached.ToString()
                                End If
                                Valor = Valor.Trim()
                                item.SubItems.Add(Valor)


                                If f = 6 And c >= 12 Then

                                    'If Valor <> "" AndAlso InStr(Valor, "-") > 0 Then
                                    '    Dim sValores() As String = Valor.Split("-")
                                    '    Select Case sValores(0).ToUpper()
                                    '        Case "P"
                                    '            item.SubItems(item.SubItems.Count - 1).Tag = "1" 'Percepción
                                    '        Case "D"
                                    '            item.SubItems(item.SubItems.Count - 1).Tag = "2" 'Deducción
                                    '        Case "I"
                                    '            item.SubItems(item.SubItems.Count - 1).Tag = "3" 'Incapacidad
                                    '    End Select
                                    '    Valor = sValores(1).Trim()
                                    'End If
                                    item.SubItems(item.SubItems.Count - 1).Text = Valor
                                End If



                            Catch ex As Exception

                            End Try

                        Next
                    Next

                    book.Dispose()
                    book = Nothing
                    GC.Collect()
                    'If lsvNominaFile.Items.Count >= 9 Then
                    '    If chkTipo.Checked Then
                    '        ProcesarNomina()
                    '    Else
                    '        ProcesarNomina1()
                    '    End If

                    'End If
                    pnlCatalogo.Enabled = True
                    If lsvLista.Items.Count = 0 Then
                        MessageBox.Show("El catálogo no puso ser importado o no contiene registros." & vbCrLf & "¿Por favor verifique?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        MessageBox.Show("Se han encontrado " & FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        tsbGuardar.Enabled = True
                        tsbCancelar.Enabled = True
                        lblRuta.Text = FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo."
                        Me.Enabled = True
                        Me.cmdCerrar.Enabled = True
                        Me.Cursor = Cursors.Default
                        tsbImportar.Enabled = True
                        lsvLista.Visible = True
                    End If




                ElseIf book.Worksheets.Count = 0 Then
                    MessageBox.Show("El archivo no contiene hojas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("El archivo ya no se encuentra en la ruta indicada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function getColumnName(index As Single) As String
        Dim numletter As Single = 26
        Dim sGrupo As Single = index / numletter
        Dim Modulo As Single = sGrupo - Math.Truncate(sGrupo)

        If Modulo = 0 Then Modulo = 1
        Dim Grupo As Integer = sGrupo - Modulo

        Dim Indice As Integer = index - (Grupo * numletter)
        Dim ColumnName As String = ""

        If Grupo > 0 Then
            ColumnName = Chr(64 + Grupo)
        End If
        ColumnName &= Chr(64 + Indice)
        Return ColumnName

    End Function

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        pnlCatalogo.Enabled = False
        lsvLista.Items.Clear()
        chkAll.Checked = False
        lblRuta.Text = ""
        tsbImportar.Enabled = False
        tsbProcesar.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        tsbNuevo.Enabled = True
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub
End Class