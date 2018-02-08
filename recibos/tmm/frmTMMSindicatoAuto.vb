Imports CrystalDecisions.CrystalReports.Engine
Public Class frmTMMSindicatoAuto
    Dim direccioncarpeta As String
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        'pnlCatalogo.Enabled = True
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
                Dim bGenerar As Boolean



                pgbProgreso.Minimum = 0
                pgbProgreso.Value = 0
                pgbProgreso.Maximum = lsvLista.CheckedItems.Count


                'Dim fila As New DataRow

                'Dim forma As New frmRecibosLupita
                Dim dsReporte As New DataSet

                dsReporte.Tables.Add("Tabla")


                dsReporte.Tables("Tabla").Columns.Add("nombre")
                dsReporte.Tables("Tabla").Columns.Add("cantidad")
                dsReporte.Tables("Tabla").Columns.Add("letra")
                dsReporte.Tables("Tabla").Columns.Add("Fecha")
                dsReporte.Tables("Tabla").Columns.Add("Lugar")

                'Seleccionar carpeta donde guardar los archivos
                Dim Carpeta = New FolderBrowserDialog
                If Carpeta.ShowDialog() = DialogResult.OK Then
                    direccioncarpeta = Carpeta.SelectedPath
                Else
                    Exit Sub
                End If

                For Each producto As ListViewItem In lsvLista.CheckedItems
                    dsReporte.Clear()
                    bGenerar = False


                    If producto.Index >= (CInt(NudFilaI.Value) - 1) And producto.Index <= (CInt(NudFilaF.Value) - 1) Then
                        If CDbl(IIf(producto.SubItems(CInt(NudColumnaC.Value)).Text = "", "0", producto.SubItems(CInt(NudColumnaC.Value)).Text)) > 0 Then
                            Dim fila As DataRow = dsReporte.Tables("Tabla").NewRow
                            fila.Item("nombre") = Trim(producto.SubItems(CInt(NudColumnaN.Value)).Text)
                            fila.Item("cantidad") = Math.Round(CDbl(producto.SubItems(CInt(NudColumnaC.Value)).Text), 2)
                            fila.Item("letra") = ImprimeLetra(Math.Round(CDbl(producto.SubItems(CInt(NudColumnaC.Value)).Text), 2))

                            fila.Item("fecha") = dtpfecha.Value.ToLongDateString().ToUpper()

                            fila.Item("Lugar") = txtlugar.Text.ToUpper()



                            dsReporte.Tables("Tabla").Rows.Add(fila)
                            bGenerar = True
                        End If


                    End If
                    pgbProgreso.Value += 1
                    Application.DoEvents()
                    'mandar el reporte

                    'mandar el reporte
                    If bGenerar Then
                        If rbctmlogo.Checked Then
                            'opcion = 1
                            Dim oReporte As New ctmlogo
                            oReporte.SetDataSource(dsReporte)
                            oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value.ToShortDateString).Month.ToString("00") & CDate(dtpfecha.Value.ToShortDateString).Year.ToString() & Trim(producto.SubItems(CInt(NudColumnaI.Value)).Text) & "S.pdf")
                        End If
                        If rbctm.Checked Then
                            'opcion = 2
                            Dim oReporte As New ctmsinlogo
                            oReporte.SetDataSource(dsReporte)
                            oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value.ToShortDateString).Month.ToString("00") & CDate(dtpfecha.Value.ToShortDateString).Year.ToString() & Trim(producto.SubItems(CInt(NudColumnaI.Value)).Text) & "S.pdf")
                        End If
                        If rbcroc.Checked Then
                            'opcion = 3
                            Dim oReporte As New recibos
                            oReporte.SetDataSource(dsReporte)
                            oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value.ToShortDateString).Month.ToString("00") & CDate(dtpfecha.Value.ToShortDateString).Year.ToString() & Trim(producto.SubItems(CInt(NudColumnaI.Value)).Text) & "S.pdf")
                        End If
                        If rbalimentos.Checked Then
                            'opcion = 4
                            Dim oReporte As New ctmalimentos
                            oReporte.SetDataSource(dsReporte)
                            oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value.ToShortDateString).Month.ToString("00") & CDate(dtpfecha.Value.ToShortDateString).Year.ToString() & Trim(producto.SubItems(CInt(NudColumnaI.Value)).Text) & "S.pdf")
                        End If
                        If rbtmm.Checked Then
                            'opcion = 5
                            Dim oReporte As New tmmsindicato
                            oReporte.SetDataSource(dsReporte)
                            oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(dtpfecha.Value.ToShortDateString).Month.ToString("00") & CDate(dtpfecha.Value.ToShortDateString).Year.ToString() & Trim(producto.SubItems(CInt(NudColumnaI.Value)).Text) & "S.pdf")
                        End If

                    End If



                    'Dim reporte = New ReportDocument

                    ''Dim oReporte As ReportDocument = Nothing

                    ''reporte.FileName = "tmm"

                    ''reporte.FileName = Application.StartupPath & "\Reportes\tmm.rpt"

                    'reporte.Load(Application.StartupPath & "\Reportes\tmm.rpt")
                    'reporte.SetDataSource(dsReporte)
                    'reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, direccioncarpeta & "\" & CDate(Periodo).Month.ToString("00") & CDate(Periodo).Year.ToString() & Trim(producto.SubItems(0).Text) & "F.pdf")



                Next
                'Dim Archivo As String = IO.Path.GetTempFileName.Replace(".tmp", ".xml")
                'forma.dsReporte.WriteXml(Archivo, XmlWriteMode.WriteSchema)

                'forma.ShowDialog()
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

            oCmd.CommandText = "SELECT * FROM [SINDICATO$] "
            oCmd.Connection = xlsConexion
            oDa.SelectCommand = oCmd

            oDa.Fill(oDs, "Sales")
            xlsConexion.Close()

            Dim tbRegistros As DataTable = oDs.Tables(0).Copy()
            lsvLista.Items.Clear()
            lsvLista.Columns.Clear()
            Dim anchos As String() = "90,150,190,190,190,190,190,190,190,190".Split(",")

            If tbRegistros Is Nothing = False Then
                For i As Integer = 0 To tbRegistros.Columns.Count - 1
                    If i = 0 Then
                        lsvLista.Columns.Add("")
                    Else
                        lsvLista.Columns.Add("columna " & i)
                    End If

                    If i >= 5 Then
                        lsvLista.Columns(i).TextAlign = HorizontalAlignment.Right
                    End If
                    If i < anchos.Length Then
                        lsvLista.Columns(i).Width = Val(anchos(i))
                    End If
                Next
                'lsvLista.Items.AddRange((From Fila As DataRow In tbRegistros.Select("PRECIO_CLAVE>0")
                'Where(Not IsDBNull(Fila.Item(7)) AndAlso CType("" & Fila.Item(0), String) <> "VALIDACION")
                '                                          Order By Val("" & Fila.Item("Pagina"))
                '                                         Select New ListViewItem((From campo In Fila.ItemArray Select CType("" & campo, String)).ToArray())).ToArray())

                'lsvLista.Items.AddRange((From Fila As DataRow In tbRegistros.Select("PRECIO_CLAVE>0")
                '                                           Where Not IsDBNull(Fila.Item(7)) AndAlso CType("" & Fila.Item(0), String) <> "VALIDACION"
                '                                           Order By Val("" & Fila.Item("Pagina"))
                '                                           Select New ListViewItem((From campo In Fila.ItemArray Select CType("" & campo, String)).ToArray())).ToArray())


                Dim item As ListViewItem
                For x = 0 To tbRegistros.Rows.Count - 1
                    item = lsvLista.Items.Add("Fila " & x + 1)
                    For y = 0 To tbRegistros.Columns.Count - 1
                        item.SubItems.Add("" & tbRegistros.Rows(x).Item(y).ToString())

                    Next
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(0).ToString())
                    'Dim ere As Integer = tbRegistros.Columns.Count
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(1).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(2).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(3).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(4).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(5).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(6).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(7).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(8).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(9).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(10).ToString())
                    'item.SubItems.Add("" & IIf(tbRegistros.Rows(x).Item(11).ToString() = Nothing, "", tbRegistros.Rows(x).Item(11).ToString()))
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(12).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(13).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(14).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(15).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(16).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(17).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(18).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(19).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(20).ToString())
                    'item.SubItems.Add("" & tbRegistros.Rows(x).Item(21).ToString())
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

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class