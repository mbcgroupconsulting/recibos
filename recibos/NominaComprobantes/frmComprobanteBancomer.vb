Imports ClosedXML.Excel
Imports System.IO
Imports System.Text.RegularExpressions
Public Class frmComprobanteBancomer
    Dim sheetIndex As Integer = -1
    Dim SQL As String
    Dim contacolumna As Integer
    Public gIdFactura As String
    Dim direccioncarpeta As String
    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub tsbImportar_Click(sender As System.Object, e As System.EventArgs) Handles tsbImportar.Click
        Dim dialogo As New OpenFileDialog
        lblRuta.Text = ""
        With dialogo
            .Title = "Búsqueda de archivos de saldos."
            .Filter = "Hoja de cálculo de excel (xlsx)|*.xlsx;*.xlsm;*.xls"
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

    Private Sub tsbProcesar_Click(sender As System.Object, e As System.EventArgs) Handles tsbProcesar.Click
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

                        lsvLista.Columns.Add(numerocolumna)
                        numerocolumna = numerocolumna + 1

                    Next

                    'lsvLista.Columns.Add("conciliacion")
                    'lsvLista.Columns.Add("color")

                    lsvLista.Columns(1).Width = 200
                    lsvLista.Columns(2).Width = 200
                    lsvLista.Columns(3).Width = 400
                    lsvLista.Columns(3).TextAlign = 1
                    'lsvLista.Columns(4).Width = 100
                    'lsvLista.Columns(4).TextAlign = 1
                    'lsvLista.Columns(5).Width = 100
                    'lsvLista.Columns(5).TextAlign = 1
                    'lsvLista.Columns(6).Width = 350

                    Dim Filas As Long = sheet.RowsUsed().Count()
                    For f As Integer = 1 To Filas
                        Dim item As ListViewItem = lsvLista.Items.Add(f.ToString())
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
            MessageBox.Show(ex.Message)
            tsbCancelar_Click(sender, e)
        End Try
    End Sub

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGuardar.Click
        Try
           
            If lsvLista.CheckedItems.Count > 0 Then



                pnlProgreso.Visible = True
                pnlCatalogo.Enabled = False
                Application.DoEvents()



                Dim i As Integer = 0
                Dim conta As Integer = 0
             
                'Dim isr As Double

             




                pgbProgreso.Minimum = 0
                pgbProgreso.Value = 0
                pgbProgreso.Maximum = lsvLista.CheckedItems.Count


                'Dim fila As New DataRow

                'Dim fiscaltmm As New frmReciboTMM

                
                
                'Seleccionar carpeta donde guardar los archivos
                Dim Carpeta = New FolderBrowserDialog
                If Carpeta.ShowDialog() = DialogResult.OK Then
                    direccioncarpeta = Carpeta.SelectedPath
                Else
                    Exit Sub
                End If




                For Each producto As ListViewItem In lsvLista.CheckedItems

                    Dim importe As Double = Double.Parse(IIf(producto.SubItems(CInt(NudImporte.Value)).Text = "", "0", producto.SubItems(CInt(NudImporte.Value)).Text))

                    If importe > 0 Then
                        Dim dsReporte As New DataSet

                        dsReporte.Tables.Add("Tabla")
                        dsReporte.Tables("Tabla").Columns.Add("Empresa")
                        dsReporte.Tables("Tabla").Columns.Add("Fecha")
                        dsReporte.Tables("Tabla").Columns.Add("Hora")
                        dsReporte.Tables("Tabla").Columns.Add("Contrato")
                        dsReporte.Tables("Tabla").Columns.Add("Cuenta")
                        dsReporte.Tables("Tabla").Columns.Add("NombrePago")
                        dsReporte.Tables("Tabla").Columns.Add("Folio")
                        dsReporte.Tables("Tabla").Columns.Add("Nombretrabajdor")
                        dsReporte.Tables("Tabla").Columns.Add("CuentaTrabajador")
                        dsReporte.Tables("Tabla").Columns.Add("Importe")

                        Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow
                        fila.Item("Empresa") = Trim(txtEmpresa.Text.ToUpper)
                        fila.Item("Fecha") = Trim(Date.Parse(dtpFecha.Value).ToShortDateString)
                        fila.Item("Hora") = Trim(dtpFecha.Value.ToString.ToUpper.Substring(11))
                        fila.Item("Contrato") = Trim(txtContrato.Text)
                        fila.Item("Cuenta") = Trim(txtCuenta.Text)
                        fila.Item("NombrePago") = Trim(txtNombrepago.Text.ToUpper)
                        fila.Item("Folio") = Trim(txtFolio.Text)
                        fila.Item("Nombretrabajdor") = producto.SubItems(CInt(NudNombre.Value)).Text
                        fila.Item("CuentaTrabajador") = producto.SubItems(CInt(NudCuenta.Value)).Text
                        fila.Item("Importe") = Math.Round(importe, 2)
                        
                        dsReporte.Tables("Tabla").Rows.Add(fila)

                        'Dim Archivo As String = IO.Path.GetTempFileName.Replace(".tmp", ".xml")
                        'dsReporte.WriteXml(Archivo, XmlWriteMode.WriteSchema)
                        


                        pgbProgreso.Value += 1
                        Application.DoEvents()
                        'mandar el reporte
                        ''Dim reporte = New ReportDocument
                        'Dim oReporte As ReportDocument = Nothing

                        'reporte.FileName = "tmm"

                        'reporte.FileName = Application.StartupPath & "\Reportes\tmm.rpt"
                        Dim oReporte As New comprobantenominabancomer
                        oReporte.SetDataSource(dsReporte)
                        oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & producto.SubItems(CInt(NudNombre.Value)).Text.ToUpper & " " & CDate(dtpFecha.Value).Month.ToString("00") & "-" & CDate(dtpFecha.Value).Month.ToString("00") & "-" & CDate(dtpFecha.Value).Year.ToString() & ".pdf")
                        ''reporte.Load(Application.StartupPath & "\reportes\asitmm.rpt")
                        ''reporte.SetDataSource(dsReporte)
                        ''reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value).Month.ToString("00") & CDate(dtpfecha.Value).Year.ToString() & Trim(producto.SubItems(1).Text) & "ASIM.pdf")


                    End If

                    'pgbProgreso.Value += 1
                    'Application.DoEvents()
                    ''mandar el reporte
                    ' ''Dim reporte = New ReportDocument
                    ''Dim oReporte As ReportDocument = Nothing

                    ''reporte.FileName = "tmm"

                    ''reporte.FileName = Application.StartupPath & "\Reportes\tmm.rpt"
                    'Dim oReporte As New comprobantenominabancomer
                    ''oReporte.SetDataSource(dsReporte)
                    'oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfechainicio.Value).Month.ToString("00") & CDate(dtpfechainicio.Value).Year.ToString() & Trim(producto.SubItems(3).Text) & ".pdf")
                    ' ''reporte.Load(Application.StartupPath & "\reportes\asitmm.rpt")
                    ' ''reporte.SetDataSource(dsReporte)
                    ' ''reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value).Month.ToString("00") & CDate(dtpfecha.Value).Year.ToString() & Trim(producto.SubItems(1).Text) & "ASIM.pdf")



                Next


                '###### FIN CALCULO ISR #######





                'Dim Archivo As String = IO.Path.GetTempFileName.Replace(".tmp", ".xml")
                'dsReporte.WriteXml(Archivo, XmlWriteMode.WriteSchema)

                'fiscaltmm.ShowDialog()
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                MessageBox.Show("Por favor seleccione al menos un trabajador para generar el comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbCancelar_Click(sender As System.Object, e As System.EventArgs) Handles tsbCancelar.Click
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

    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub
End Class