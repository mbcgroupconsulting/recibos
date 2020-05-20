Public Class frmImportarCheques

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
            Dim anchos As String() = "90,150,190,190,190,190,190,190,190,190,190".Split(",")

            If tbRegistros Is Nothing = False Then

                lsvLista.Columns.Add("")
                lsvLista.Columns(0).Width = 40
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(1).Width = 150
                lsvLista.Columns.Add("Num cheque")
                lsvLista.Columns(2).Width = 150
                lsvLista.Columns.Add("IdEmpresa")
                lsvLista.Columns(3).Width = 150
                lsvLista.Columns.Add("IdBanco")
                lsvLista.Columns(4).Width = 100
                lsvLista.Columns(4).TextAlign = 1
                lsvLista.Columns.Add("Nombre")
                lsvLista.Columns(5).Width = 250
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(6).Width = 130
                lsvLista.Columns(6).TextAlign = 1
                lsvLista.Columns.Add("Recibio")
                lsvLista.Columns(7).Width = 105
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Ocupado Para")
                lsvLista.Columns(8).Width = 250




                Dim item As ListViewItem
                For x = 0 To tbRegistros.Rows.Count - 1
                    item = lsvLista.Items.Add("")
                    For y = 0 To tbRegistros.Columns.Count - 1
                        item.SubItems.Add("" & Trim(tbRegistros.Rows(x).Item(y).ToString()))

                    Next

                Next

            End If
            pnlCatalogo.Enabled = True
            If lsvLista.Items.Count = 0 Then
                MessageBox.Show("El archivo no puso ser importado o no contiene registros." & vbCrLf & "¿Por favor verifique?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGuardar.Click
        Dim SQL As String, nombresistema As String = ""
        Try
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
                SQL = "Select * from usuarios where idUsuario = " & idUsuario
                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim Fila As DataRow = rwFilas(0)
                    nombresistema = Fila.Item("nombre")
                End If

                For Each producto As ListViewItem In lsvLista.CheckedItems
                    

                    'Insertar nuevo

                    SQL = "EXEC setGastosChequesInsertar 0," & Trim(producto.SubItems(3).Text) & "," & Trim(producto.SubItems(4).Text)
                    SQL &= ",'" & Trim(producto.SubItems(2).Text)
                    SQL &= "','" & Trim(producto.SubItems(5).Text)
                    SQL &= "','" & Format(Date.Parse(Mid((Trim(producto.SubItems(1).Text)), 1, 10)), "yyyy/dd/MM")
                    SQL &= "','" & Date.Now.ToShortDateString() & "'"
                    SQL &= ",'" & nombresistema & "','" & nombresistema
                    SQL &= "',1," & ((IIf(Trim(producto.SubItems(6).Text) = "", 0, Trim(producto.SubItems(6).Text))).ToString.Replace(",", "")).Replace(" ", "")
                    SQL &= "," & Trim(producto.SubItems(7).Text) & ",'" & Trim(producto.SubItems(8).Text) & "'"
                    SQL &= "," & Trim(producto.SubItems(9).Text)

                    If nExecute(SQL) = False Then
                        MessageBox.Show("Error en el registro con los siguiente datos: fecha expedición:" & Trim(producto.SubItems(1).Text) & " Nombre:" & Trim(producto.SubItems(5).Text) & " Recibio:" & Trim(producto.SubItems(7).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        pnlProgreso.Visible = False
                        Exit Sub

                    End If
                        pgbProgreso.Value += 1
                        Application.DoEvents()





                Next
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False

            Else

                MessageBox.Show("Por favor seleccione al menos una registro para importar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class







