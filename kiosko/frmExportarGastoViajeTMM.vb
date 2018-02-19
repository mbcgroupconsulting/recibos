Public Class frmExportarGastoViajeTMM
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
                ConectarKiosko("kiosko")
                mdoObjetos3.sBase = "kiosko"

                For Each producto As ListViewItem In lsvLista.CheckedItems

                    SQL = "select * from usuarios where codigo ='" & Trim(producto.SubItems(2).Text) & "'"
                    Dim rwUsuarioK As DataRow() = nConsultaKiosko(SQL)


                    If rwUsuarioK Is Nothing = False Then
                        'insertamos el pago
                        'Insertar nuevo
                        SQL = "EXEC setviajeInsertar   0," & rwUsuarioK(0)("IdUsuario").ToString() & ",'" & Date.Parse(Trim(producto.SubItems(1).Text)).ToShortDateString() & "',1,"
                        SQL &= Double.Parse(Trim(producto.SubItems(3).Text).Replace(",", "").Replace("$", "").ToString()) & ",'"

                        SQL &= Trim(producto.SubItems(4).Text) & "'"



                        If nExecuteKiosko(SQL) = False Then

                            MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(1).Text) & " trabajador:" & Trim(producto.SubItems(3).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub

                        End If

                    Else
                        'insertamos tanto en usuario como en pago
                        'TransaccionKiosko = KIOSKOCONEXION.BeginTransaction



                        MessageBox.Show("No existe el id Empleado: fecha:" & Trim(producto.SubItems(1).Text) & " id Empleado:" & Trim(producto.SubItems(2).Text) & " . El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub

                    End If


                    pgbProgreso.Value += 1
                    Application.DoEvents()







                Next
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
                DesconectarKiosko()
            Else

                MessageBox.Show("Por favor seleccione al menos una registro para importar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True

        Catch ex As Exception
            DesconectarKiosko()
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
                lsvLista.Columns.Add("Fecha")
                lsvLista.Columns(1).Width = 90
                lsvLista.Columns.Add("Id Empleado")
                lsvLista.Columns(2).Width = 100
                lsvLista.Columns(2).TextAlign = 1
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(3).Width = 100
                lsvLista.Columns(3).TextAlign = 1
                lsvLista.Columns.Add("Nombre Archivo")
                lsvLista.Columns(4).Width = 200





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
End Class