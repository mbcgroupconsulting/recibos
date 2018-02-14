﻿Imports CrystalDecisions.CrystalReports.Engine

Public Class frmTMMFiscalAuto


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
            .Title = "Búsqueda de catálogos."
            .Filter = "Archivos de excel (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                lblRuta.Text = .FileName
            End If
        End With
        tsbProcesar.Enabled = lblRuta.Text.Length > 0
        If tsbProcesar.Enabled Then
            tsbProcesar_Click(sender, e)
        End If
    End Sub

    Private Sub tsbProcesar_Click(sender As Object, e As EventArgs) Handles tsbProcesar.Click
        Dim xlsConexion As New OleDb.OleDbConnection
        Dim oCmd As New OleDb.OleDbCommand
        Dim oDa As New OleDb.OleDbDataAdapter
        Dim oDs As New DataSet, Hoja As String = ""

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
            xlsConexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & lblRuta.Text & "; Extended Properties= Excel 12.0 Xml;"
            xlsConexion.Open()

            Dim Esquema As DataTable = xlsConexion.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, {Nothing, Nothing, Nothing, "TABLE"})

            If Esquema Is Nothing = False Then
                Hoja = Esquema.Rows(0)(2).ToString()
            Else
                MessageBox.Show("No se ha podido leer el archivo específicado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            oCmd.CommandText = "SELECT * FROM [NOMINA$] "
            oCmd.Connection = xlsConexion
            oDa.SelectCommand = oCmd

            oDa.Fill(oDs, "Sales")
            xlsConexion.Close()

            Dim tbRegistros As DataTable = oDs.Tables(0).Copy()
            lsvLista.Items.Clear()
            lsvLista.Columns.Clear()
            Dim anchos As String() = "150,200,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150,150".Split(",")

            Periodo = tbRegistros.Rows(0).Item(1).ToString()
            Periodocom = tbRegistros.Rows(0).Item(2).ToString() + " al " + tbRegistros.Rows(0).Item(3).ToString()
            If tbRegistros Is Nothing = False Then
                For i As Integer = 0 To tbRegistros.Columns.Count - 1
                    lsvLista.Columns.Add(tbRegistros.Rows(3).Item(i).ToString())
                    If i >= (tbRegistros.Columns.Count - 3) Then
                        lsvLista.Columns(i).TextAlign = HorizontalAlignment.Right
                    End If
                    If i < anchos.Length Then
                        lsvLista.Columns(i).Width = Val(anchos(i))
                    End If
                Next


                Dim item As ListViewItem
                For x = 0 To tbRegistros.Rows.Count - 5
                    item = lsvLista.Items.Add(tbRegistros.Rows(x + 4).Item(0).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(1).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(2).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(3).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(4).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(5).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(6).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(7).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(8).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(9).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(10).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(11).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(12).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(13).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(14).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(15).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(16).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(17).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(18).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(19).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(20).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(21).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(22).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(23).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(24).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(25).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(26).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(27).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(28).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(29).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(30).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(31).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(32).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(33).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(34).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(35).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(36).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(37).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(38).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(39).ToString())
                Next

            End If
            pnlCatalogo.Enabled = True
            If lsvLista.Items.Count = 0 Then
                MessageBox.Show("El catálogo no puso ser importado o no contiene registros." & vbCrLf & "¿Por favor verifique?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Se han encontrado " & FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbGuardar.Enabled = True
                tsbCancelar.Enabled = True
                lblRuta.Text = FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo."
            End If
        Catch ex As Exception
            ShowError(ex, Me.Text)
        End Try
        Me.Enabled = True
        Me.cmdCerrar.Enabled = True
        Me.Cursor = Cursors.Default
        tsbImportar.Enabled = True
        lsvLista.Visible = True
    End Sub
    Private Sub tsbGuardar_Click(sender As Object, e As EventArgs) Handles tsbGuardar.Click
        Try
            Dim SQL As String
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
                Dim isr As Double
                Dim subsidio As Double
                Dim totalp As Double
                Dim totald As Double

                Dim incapacidad As Double

                Dim imss As Double
                Dim infonavit2 As Double
                Dim pension2 As Double
                Dim prestamo2 As Double
                Dim fonacot2 As Double
                Dim cuotasindical As Double
                Dim prestamo As Double


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
                    totald = 0
                    totalp = 0

                    dsReporte.Clear()

                    'percepciones = Val(IIf(Trim(producto.SubItems(20).Text) = "", "0", Trim(producto.SubItems(20).Text)))
                    'deducciones = Val(IIf(Trim(producto.SubItems(21).Text) = "", "0", Trim(producto.SubItems(21).Text)))
                    'neto = Val(IIf(Trim(producto.SubItems(22).Text) = "", "0", Trim(producto.SubItems(22).Text)))

                    Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow
                    fila.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    fila.Item("nombre") = Trim(producto.SubItems(1).Text)
                    fila.Item("buque") = Trim(producto.SubItems(9).Text)
                    fila.Item("periodo") = Periodocom
                    fila.Item("puesto") = Trim(producto.SubItems(8).Text)
                    fila.Item("Sueldobase") = Math.Round(CDbl(Trim(producto.SubItems(17).Text)), 2).ToString("######0.00")
                    fila.Item("Tefijo") = Math.Round(CDbl(Trim(producto.SubItems(18).Text)), 2).ToString("######0.00")
                    fila.Item("Teadicional") = Math.Round(CDbl(Trim(producto.SubItems(19).Text)), 2).ToString("######0.00")
                    fila.Item("bonoseguridad") = "0"
                    fila.Item("tiporecibo") = "Nomina"
                    fila.Item("mespago") = CDate(Periodo).Month.ToString()
                    fila.Item("diastrabajados") = Trim(producto.SubItems(14).Text)
                    fila.Item("diasviajando") = Trim(producto.SubItems(14).Text)
                    fila.Item("fechaelaboracion") = Now.ToShortDateString().ToString()
                    fila.Item("vacaciones") = Math.Round(CDbl(Trim(producto.SubItems(18).Text)), 2).ToString("######0.00")
                    fila.Item("alimentovac") = "0"
                    fila.Item("bonoxbuque") = "0"
                    fila.Item("bonoespecial") = "0"
                    fila.Item("tpercepciones") = Math.Round(CDbl(Trim(producto.SubItems(29).Text)), 2).ToString("######0.00")
                    incapacidad = CDbl(Trim(producto.SubItems(31).Text))
                    isr = CDbl(Trim(producto.SubItems(32).Text))
                    imss = CDbl(Trim(producto.SubItems(33).Text))
                    infonavit2 = CDbl(Trim(producto.SubItems(34).Text))
                    cuotasindical = CDbl(IIf(Trim(producto.SubItems(35).Text) = "", 0, Trim(producto.SubItems(35).Text)))
                    fonacot2 = CDbl(IIf(Trim(producto.SubItems(36).Text) = "", 0, Trim(producto.SubItems(36).Text)))
                    pension2 = CDbl(IIf(Trim(producto.SubItems(37).Text) = "", 0, Trim(producto.SubItems(37).Text)))
                    prestamo2 = CDbl(IIf(Trim(producto.SubItems(38).Text) = "", 0, Trim(producto.SubItems(38).Text)))


                    fila.Item("tdeducciones") = Math.Round(incapacidad + isr + imss + infonavit2 + pension2 + prestamo2 + fonacot2 + prestamo2, 2).ToString("#######.00")

                    fila.Item("neto") = Math.Round(CDbl(Trim(producto.SubItems(39).Text)), 2).ToString("######0.00")

                    dsReporte.Tables("Tabla").Rows.Add(fila)




                    'Sueldo base

                    Dim fila2 As DataRow = dsReporte.Tables("Percepciones").NewRow
                    fila2.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    fila2.Item("dias") = Trim(producto.SubItems(14).Text)
                    fila2.Item("concepto") = "Sueldo base"
                    fila2.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(17).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Percepciones").Rows.Add(fila2)

                    'TE Fijo

                    Dim tefijo As DataRow = dsReporte.Tables("Percepciones").NewRow
                    tefijo.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    tefijo.Item("dias") = Trim(producto.SubItems(14).Text)
                    tefijo.Item("concepto") = "TE fijo"
                    tefijo.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(18).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Percepciones").Rows.Add(tefijo)

                    'TE Ocasional

                    Dim teocasional As DataRow = dsReporte.Tables("Percepciones").NewRow
                    teocasional.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    teocasional.Item("dias") = Trim(producto.SubItems(14).Text)
                    teocasional.Item("concepto") = "TE ocasional"
                    teocasional.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(19).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Percepciones").Rows.Add(teocasional)

                    'Desc Semanal obligatorio

                    Dim descsemanal As DataRow = dsReporte.Tables("Percepciones").NewRow
                    descsemanal.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    descsemanal.Item("dias") = Trim(producto.SubItems(14).Text)
                    descsemanal.Item("concepto") = "Desc. sem. obligatorio"
                    descsemanal.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(20).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Percepciones").Rows.Add(descsemanal)

                    'Vacaciones proporcionales

                    Dim vacaciones As DataRow = dsReporte.Tables("Percepciones").NewRow
                    vacaciones.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    vacaciones.Item("dias") = Trim(producto.SubItems(14).Text)
                    vacaciones.Item("concepto") = "Vacaciones proporcionales"
                    vacaciones.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(21).Text)), 2).ToString("#######.00")
                    dsReporte.Tables("Percepciones").Rows.Add(vacaciones)

                    'Prima de vacaciones

                    Dim prima As DataRow = dsReporte.Tables("Percepciones").NewRow
                    prima.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    prima.Item("dias") = Trim(producto.SubItems(14).Text)
                    prima.Item("concepto") = "Prima de vacaciones"
                    prima.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(28).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Percepciones").Rows.Add(prima)

                    'Aguinaldo

                    Dim aguinaldo As DataRow = dsReporte.Tables("Percepciones").NewRow
                    aguinaldo.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    aguinaldo.Item("dias") = Trim(producto.SubItems(14).Text)
                    aguinaldo.Item("concepto") = "Aguinaldo"
                    aguinaldo.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(25).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Percepciones").Rows.Add(aguinaldo)


                    'DEDUCCIONES
                    'INCAPACIDAD
                    Dim incapacidadf As DataRow = dsReporte.Tables("Deducciones").NewRow
                    incapacidadf.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    incapacidadf.Item("dias") = Trim(producto.SubItems(14).Text)
                    incapacidadf.Item("concepto") = "INCAPACIDAD"
                    incapacidadf.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(31).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(incapacidadf)

                    'ISR

                    Dim isrf As DataRow = dsReporte.Tables("Deducciones").NewRow
                    isrf.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    isrf.Item("dias") = Trim(producto.SubItems(14).Text)
                    isrf.Item("concepto") = "ISR"
                    isrf.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(32).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(isrf)

                    'IMSS

                    Dim imssf As DataRow = dsReporte.Tables("Deducciones").NewRow
                    imssf.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    imssf.Item("dias") = Trim(producto.SubItems(14).Text)
                    imssf.Item("concepto") = "IMSS"
                    imssf.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(33).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(imssf)

                    'credito infonavit

                    Dim infonavit As DataRow = dsReporte.Tables("Deducciones").NewRow
                    infonavit.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    infonavit.Item("dias") = Trim(producto.SubItems(14).Text)
                    infonavit.Item("concepto") = "Credito infonavit"
                    infonavit.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(34).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(infonavit)

                    'Cuota sindical

                    Dim sindical As DataRow = dsReporte.Tables("Deducciones").NewRow
                    sindical.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    sindical.Item("dias") = Trim(producto.SubItems(14).Text)
                    sindical.Item("concepto") = "Cuota sindical"
                    sindical.Item("monto") = Math.Round(CDbl(Trim(producto.SubItems(35).Text)), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(sindical)

                    'Fonacot

                    Dim fonacot As DataRow = dsReporte.Tables("Deducciones").NewRow
                    fonacot.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    fonacot.Item("dias") = Trim(producto.SubItems(14).Text)
                    fonacot.Item("concepto") = "Fonacot"
                    fonacot.Item("monto") = Math.Round(CDbl(IIf(Trim(producto.SubItems(36).Text) = "", 0, Trim(producto.SubItems(36).Text))), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(fonacot)

                    'Pension alimenticia

                    Dim pension As DataRow = dsReporte.Tables("Deducciones").NewRow
                    pension.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    pension.Item("dias") = Trim(producto.SubItems(14).Text)
                    pension.Item("concepto") = "Pensión Alimenticia"
                    pension.Item("monto") = Math.Round(CDbl(IIf(Trim(producto.SubItems(37).Text) = "", 0, Trim(producto.SubItems(37).Text))), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(pension)

                    'Prestamo

                    Dim prestamocon As DataRow = dsReporte.Tables("Deducciones").NewRow
                    prestamocon.Item("numtrabajador") = Trim(producto.SubItems(0).Text)
                    prestamocon.Item("dias") = Trim(producto.SubItems(14).Text)
                    prestamocon.Item("concepto") = "Préstamo"
                    prestamocon.Item("monto") = Math.Round(CDbl(IIf(Trim(producto.SubItems(38).Text) = "", 0, Trim(producto.SubItems(38).Text))), 2).ToString("######0.00")
                    dsReporte.Tables("Deducciones").Rows.Add(prestamo)






                    pgbProgreso.Value += 1
                    Application.DoEvents()
                    'mandar el reporte
                    Dim reporte = New ReportDocument
                    'Dim oReporte As ReportDocument = Nothing

                    'reporte.FileName = "tmm"

                    'reporte.FileName = Application.StartupPath & "\Reportes\tmm.rpt"
                    reporte.Load(Application.StartupPath & "\Reportes\tmm.rpt")
                    reporte.SetDataSource(dsReporte)
                    reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(Periodo).Month.ToString("00") & CDate(Periodo).Year.ToString() & Trim(producto.SubItems(0).Text) & "F.pdf")





                Next
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

    Private Sub frmTMMFiscalAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblRuta_Click(sender As Object, e As EventArgs) Handles lblRuta.Click

    End Sub
End Class