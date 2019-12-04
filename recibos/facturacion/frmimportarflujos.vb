Public Class frmimportarflujos
    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        'pnlCatalogo.Enabled = True
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub frmimportarflujos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                    If Trim(producto.SubItems(6).Text).Replace(" ", "") = "F" Then
                        'Insertar nuevo
                        SQL = "EXEC setfacturasInsertar 0," & Trim(producto.SubItems(7).Text) & "," & Trim(producto.SubItems(4).Text)
                        SQL &= ",'" & Format(Date.Parse(Mid((Trim(producto.SubItems(3).Text)), 1, 10)), "yyyy/dd/MM")

                        If Trim(nombresistema) = "Guadalupe" Or Trim(nombresistema) = "Ingrid" Then
                            SQL &= "'," & IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))
                        Else
                            SQL &= "',0" '& IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))
                        End If

                        'SQL &= "',0" '& IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))
                        SQL &= "," & ((IIf(Trim(producto.SubItems(9).Text) = "", 0, Trim(producto.SubItems(9).Text))).ToString.Replace(",", "")).Replace(" ", "")
                        SQL &= "," & ((IIf(Trim(producto.SubItems(10).Text) = "", 0, Trim(producto.SubItems(10).Text))).ToString.Replace(",", "")).Replace(" ", "")
                        SQL &= "," & ((IIf(Trim(producto.SubItems(11).Text) = "", 0, Trim(producto.SubItems(11).Text))).ToString.Replace(",", "")).Replace(" ", "")
                        SQL &= ",'','',1"
                        SQL &= ",'" & nombresistema & "','" & nombresistema
                        SQL &= "',1,0" ' pendiente = 0 pagada =1 
                        SQL &= ",0,'',0,0"
                        SQL &= ",1,'','" & Date.Now.ToShortDateString() & "',0,0,0"






                        If nExecute(SQL) = False Then
                            MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(3).Text) & " Cliente:" & Trim(producto.SubItems(5).Text) & " Intermediaria/pagadora:" & Trim(producto.SubItems(8).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        pgbProgreso.Value += 1
                        Application.DoEvents()
                    Else
                        MessageBox.Show("El caracter en tipo de movimientos tiene espacios o no es una letra F, este error es en el numero de factura:" & ((IIf(Trim(producto.SubItems(12).Text) = "", 0, Trim(producto.SubItems(12).Text))).ToString.Replace(",", "")).Replace(" ", ""), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If









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
                lsvLista.Columns.Add("Mov")
                lsvLista.Columns(1).Width = 70
                lsvLista.Columns.Add("Mes")
                lsvLista.Columns(2).Width = 70
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(3).Width = 70
                lsvLista.Columns.Add("ID Cliente")
                lsvLista.Columns(4).Width = 70
                lsvLista.Columns(4).TextAlign = 1
                lsvLista.Columns.Add("Cliente")
                lsvLista.Columns(5).Width = 300
                lsvLista.Columns.Add("Mov")
                lsvLista.Columns(6).Width = 70
                lsvLista.Columns.Add("ID Inter")
                lsvLista.Columns(7).Width = 70
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("INTERMEDIARIA/PAGADORA")
                lsvLista.Columns(8).Width = 300
                lsvLista.Columns.Add("IMPORTE")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns(9).TextAlign = 1
                lsvLista.Columns.Add("IVA")
                lsvLista.Columns(10).Width = 100
                lsvLista.Columns(10).TextAlign = 1
                lsvLista.Columns.Add("DEPOSITO")
                lsvLista.Columns(11).Width = 70
                lsvLista.Columns(11).TextAlign = 1
                lsvLista.Columns.Add("NUM FACT")
                lsvLista.Columns(12).Width = 70
                lsvLista.Columns(12).TextAlign = 1
                lsvLista.Columns.Add("")
                lsvLista.Columns(13).Width = 70
                lsvLista.Columns(13).TextAlign = 1


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

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class