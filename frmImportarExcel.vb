Public Class frmImportarExcel

    Private Sub ImportarExcel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        'pnlCatalogo.Enabled = True
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub tsbImportar_Click(sender As System.Object, e As System.EventArgs) Handles tsbImportar.Click
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

    Private Sub tsbProcesar_Click(sender As System.Object, e As System.EventArgs) Handles tsbProcesar.Click
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

            oCmd.CommandText = "SELECT * FROM [" + Hoja + "] "
            oCmd.Connection = xlsConexion
            oDa.SelectCommand = oCmd

            oDa.Fill(oDs, "Sales")
            xlsConexion.Close()

            Dim tbRegistros As DataTable = oDs.Tables(0).Copy()
            lsvLista.Items.Clear()
            lsvLista.Columns.Clear()
            Dim anchos As String() = "40,20,20,20,20,20,20,40,65,250,150,130,130,130,130,130,130,130,130,130,130,130,130".Split(",")

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
                'lsvLista.Items.AddRange((From Fila As DataRow In tbRegistros.Select("PRECIO_CLAVE>0")
                'Where(Not IsDBNull(Fila.Item(7)) AndAlso CType("" & Fila.Item(0), String) <> "VALIDACION")
                '                                          Order By Val("" & Fila.Item("Pagina"))
                '                                         Select New ListViewItem((From campo In Fila.ItemArray Select CType("" & campo, String)).ToArray())).ToArray())

                'lsvLista.Items.AddRange((From Fila As DataRow In tbRegistros.Select("PRECIO_CLAVE>0")
                '                                           Where Not IsDBNull(Fila.Item(7)) AndAlso CType("" & Fila.Item(0), String) <> "VALIDACION"
                '                                           Order By Val("" & Fila.Item("Pagina"))
                '                                           Select New ListViewItem((From campo In Fila.ItemArray Select CType("" & campo, String)).ToArray())).ToArray())


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

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGuardar.Click
        Dim SQL As String
        If lsvLista.CheckedItems.Count > 0 Then
            Dim mensaje As String
            
            
            pnlProgreso.Visible = True
            pnlCatalogo.Enabled = False
            Application.DoEvents()


            Dim IdProducto As Long
            Dim i As Integer = 0
            Dim conta As Integer = 0


            pgbProgreso.Minimum = 0
            pgbProgreso.Value = 0
            pgbProgreso.Maximum = lsvLista.CheckedItems.Count

            
            'Dim fila As New DataRow

            Dim forma As New frmRecibos

            forma.dsReporte.Tables.Add("Tabla")


            forma.dsReporte.Tables("Tabla").Columns.Add("nombre")
            forma.dsReporte.Tables("Tabla").Columns.Add("cantidad")
            forma.dsReporte.Tables("Tabla").Columns.Add("letra")
            forma.dsReporte.Tables("Tabla").Columns.Add("Fecha")
            forma.dsReporte.Tables("Tabla").Columns.Add("Lugar")
            forma.dsReporte.Tables("Tabla").Columns.Add("sucursal")
            forma.dsReporte.Tables("Tabla").Columns.Add("departamento")
            forma.dsReporte.Tables("Tabla").Columns.Add("puesto")

            For Each producto As ListViewItem In lsvLista.CheckedItems
                If (Trim(producto.SubItems(0).Text) = "A") Then

                    SQL = "select iIdEmpleado, clientes.nombre as cliente,puestos.cNombre as puesto, departamentos.cnombre as depto"
                    SQL &= " from (((empleados inner join clientes "
                    SQL &= " on fkiIdClienteInter=iIdCliente)"
                    SQL &= " inner join puestos on fkiIdPuesto=iIdPuesto)"
                    SQL &= " inner join departamentos on fkiIdDepartamento=iIdDepartamento)"
                    SQL &= " where cCodigoEmpleado =" & Trim(producto.SubItems(8).Text)
                    SQL &= " and empleados.fkiIdEmpresa =5"

                    Dim rwAB As DataRow() = nConsulta(SQL)

                    If rwAB Is Nothing = False Then

                        Dim registro As DataRow = rwAB(0)


                        Dim fila As DataRow = forma.dsReporte.Tables("Tabla").NewRow
                        fila.Item("nombre") = Trim(producto.SubItems(9).Text)
                        fila.Item("cantidad") = producto.SubItems(21).Text
                        fila.Item("letra") = ImprimeLetra(Val(producto.SubItems(21).Text))

                        fila.Item("fecha") = dtpfecha.Value.ToLongDateString().ToUpper()

                        fila.Item("Lugar") = txtlugar.Text.ToUpper()

                        fila.Item("sucursal") = Trim(registro.Item("cliente"))
                        fila.Item("departamento") = Trim(registro.Item("depto"))
                        fila.Item("puesto") = Trim(registro.Item("puesto"))



                        forma.dsReporte.Tables("Tabla").Rows.Add(fila)

                    End If

                    
                End If
                pgbProgreso.Value += 1
                Application.DoEvents()
                'mandar el reporte




            Next
            Dim Archivo As String = IO.Path.GetTempFileName.Replace(".tmp", ".xml")
            forma.dsReporte.WriteXml(Archivo, XmlWriteMode.WriteSchema)
            
            forma.ShowDialog()
            tsbCancelar_Click(sender, e)
            pnlProgreso.Visible = False
        Else

            MessageBox.Show("Por favor seleccione al menos un trabajador para generar el recibo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        pnlCatalogo.Enabled = True
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

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click

    End Sub
End Class