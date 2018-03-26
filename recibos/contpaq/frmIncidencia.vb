Public Class frmIncidencia
    Public gValor As String
    Public giEmpresa As String
    Public giPeriodo As String
    Private Sub frmIncidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

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

                Transaccion = CONEXION.BeginTransaction




                For Each producto As ListViewItem In lsvLista.CheckedItems
                    '
                    If IIf(Trim(producto.SubItems(4).Text) = "", "0", Trim(producto.SubItems(4).Text)) > 0 Or (IIf(Trim(producto.SubItems(8).Text) = "", "0", Trim(producto.SubItems(8).Text)) > 0 And IIf(Trim(producto.SubItems(9).Text) = "", "0", Trim(producto.SubItems(9).Text)) > 0) Or (IIf(Trim(producto.SubItems(8).Text) = "", "0", Trim(producto.SubItems(8).Text)) > 0 And IIf(Trim(producto.SubItems(10).Text) = "", "0", Trim(producto.SubItems(10).Text)) > 0) Then
                        SQL = "update empleadosC set "
                        If IIf(Trim(producto.SubItems(4).Text) = "", "0", Trim(producto.SubItems(4).Text)) > 0 Then
                            SQL &= " fSueldoOrd=" & Math.Round(Double.Parse(IIf(Trim(producto.SubItems(4).Text) = "", "0", Trim(producto.SubItems(4).Text))), 2) & ","
                        End If

                        SQL &= "fkiIdBanco=" & IIf(Trim(producto.SubItems(8).Text) = "", "0", Trim(producto.SubItems(8).Text))
                        SQL &= ",Numcuenta='" & IIf(Trim(producto.SubItems(9).Text) = "", "0", Trim(producto.SubItems(9).Text)) & "'"
                        SQL &= ",Clabe='" & IIf(Trim(producto.SubItems(10).Text) = "", "0", Trim(producto.SubItems(10).Text)) & "'"

                        SQL &= ",fkiIdBanco2=" & IIf(Trim(producto.SubItems(8).Text) = "", "0", Trim(producto.SubItems(8).Text))
                        SQL &= ",cuenta2='" & IIf(Trim(producto.SubItems(9).Text) = "", "0", Trim(producto.SubItems(9).Text)) & "'"
                        SQL &= ",clabe2='" & IIf(Trim(producto.SubItems(10).Text) = "", "0", Trim(producto.SubItems(10).Text)) & "'"

                        SQL &= " where iIdEmpleadoC=" & Trim(producto.SubItems(1).Text)

                        If nExecute(SQL) = False Then
                            MessageBox.Show("Error en el registro al insertar Sueldo ordinario con los siguiente datos: Empleado:" & Trim(producto.SubItems(3).Text) & " Sueldo:" & Trim(producto.SubItems(4).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            pnlProgreso.Visible = False
                            Exit Sub

                        End If
                    End If

                    'Insertar nuevo

                    If IIf(Trim(producto.SubItems(5).Text) = "", "0", Trim(producto.SubItems(5).Text)) > 0 Then

                        SQL = "EXEC setincidenciasInsertar 0," & giEmpresa
                        SQL &= "," & giPeriodo
                        SQL &= "," & Trim(producto.SubItems(1).Text)
                        SQL &= "," & IIf(Trim(producto.SubItems(5).Text) = "", "0", Trim(producto.SubItems(5).Text))
                        SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                        SQL &= ",1,'Faltas'"


                        If nExecute(SQL) = False Then
                            MessageBox.Show("Error en el registro al insertar Incidencia con los siguiente datos: Empleado:" & Trim(producto.SubItems(3).Text) & " Num dias:" & Trim(producto.SubItems(5).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            pnlProgreso.Visible = False
                            Exit Sub

                        End If

                    End If
                    

                    If (IIf(producto.SubItems(6).Text = "", 0, Double.Parse(Trim(producto.SubItems(6).Text).ToString())) > 0) Then
                        SQL = "EXEC setPrestamoInsertar 0," & IIf(Trim(producto.SubItems(6).Text) = "", "0", Trim(producto.SubItems(6).Text))
                        SQL &= "," & IIf(Trim(producto.SubItems(7).Text) = "", "0", Trim(producto.SubItems(7).Text))
                        SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                        SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                        SQL &= ",1"
                        SQL &= "," & Trim(producto.SubItems(1).Text)

                        If nExecute(SQL) = False Then
                            MessageBox.Show("Error en el registro al insertar prestamo con los siguiente datos: Empleado:" & Trim(producto.SubItems(3).Text) & " Prestamo:" & Trim(producto.SubItems(6).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            pnlProgreso.Visible = False
                            Exit Sub

                        End If

                    End If

                    pgbProgreso.Value += 1
                    Application.DoEvents()





                Next
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
                gValor = "1"
                Transaccion.Commit()

            Else

                MessageBox.Show("Por favor seleccione al menos una registro para importar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            pnlCatalogo.Enabled = True

        Catch ex As Exception
            Transaccion.Rollback()
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
                lsvLista.Columns(0).Width = 30
                lsvLista.Columns.Add("Id_Empleado")
                lsvLista.Columns(1).Width = 90
                lsvLista.Columns(1).TextAlign = 1
                lsvLista.Columns.Add("RFC")
                lsvLista.Columns(2).Width = 90
                lsvLista.Columns(2).TextAlign = 1
                lsvLista.Columns.Add("Nombre empleado")
                lsvLista.Columns(3).Width = 200
                lsvLista.Columns.Add("Salario Ordinario")
                lsvLista.Columns(4).Width = 150
                lsvLista.Columns(4).TextAlign = 1
                lsvLista.Columns.Add("Dias Descuento")
                lsvLista.Columns(5).Width = 130
                lsvLista.Columns(5).TextAlign = 1
                lsvLista.Columns.Add("Prestamo Total")
                lsvLista.Columns(6).Width = 130
                lsvLista.Columns(6).TextAlign = 1
                lsvLista.Columns.Add("Descuento x Nomina")
                lsvLista.Columns(7).Width = 130
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Id Banco")
                lsvLista.Columns(8).Width = 130
                lsvLista.Columns(8).TextAlign = 1
                lsvLista.Columns.Add("Num cuenta")
                lsvLista.Columns(9).Width = 130
                lsvLista.Columns(9).TextAlign = 1
                lsvLista.Columns.Add("Cable Interbancaria")
                lsvLista.Columns(10).Width = 130
                lsvLista.Columns(10).TextAlign = 1

                Dim item As ListViewItem
                For x = 0 To tbRegistros.Rows.Count - 1
                    item = lsvLista.Items.Add("")
                    For y = 0 To tbRegistros.Columns.Count - 1
                        item.SubItems.Add("" & IIf(Trim(tbRegistros.Rows(x).Item(y).ToString()) = "", "0", Trim(tbRegistros.Rows(x).Item(y).ToString())))

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