Public Class importacionflujob
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
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim numerodefacturas As String()
        Dim sa, porsa, sindicato, porsindicato, comisionsa, comisionsin, costo, retencion As String
        Dim isr As String

        Dim IdFactura1 As String
        Dim idFactura2 As String
        Dim detFactura, sID As String
        IdFactura1 = ""
        idFactura2 = ""
        detFactura = ""
        sID = ""

        Dim Alter As Boolean = False

        Try

            'Validar
            If lsvLista.CheckedItems.Count > 0 Then

                pnlProgreso.Visible = True
                pnlCatalogo.Enabled = False
                Application.DoEvents()


                Dim IdProducto As Long
                Dim i As Integer = 0
                Dim conta As Integer = 0


                pgbProgreso.Minimum = 0
                pgbProgreso.Value = 0
                pgbProgreso.Maximum = lsvLista.CheckedItems.Count

                SQL = "Select * from usuarios where idUsuario = " & idUsuario
                Dim rwUsuario As DataRow() = nConsulta(SQL)

                If rwUsuario Is Nothing = False Then
                    Dim Fila As DataRow = rwUsuario(0)
                    nombresistema = Fila.Item("nombre")
                End If

                For Each producto As ListViewItem In lsvLista.CheckedItems

                    sa = IIf(producto.SubItems(6).Text = "", 0, (producto.SubItems(6).Text.Replace(",", "")).Replace("$", "").Trim)
                    porsa = IIf(producto.SubItems(7).Text = "", 0, (producto.SubItems(7).Text.Replace(",", "")).Replace("$", "").Trim)
                    comisionsa = (Double.Parse(sa) * (Double.Parse(porsa) / 100)).ToString()
                    sindicato = IIf(producto.SubItems(8).Text = "", 0, (producto.SubItems(8).Text.Replace(",", "")).Replace("$", "").Trim)
                    porsindicato = IIf(producto.SubItems(9).Text = "", 0, (producto.SubItems(9).Text.Replace(",", "")).Replace("$", "").Trim)
                    comisionsin = (Double.Parse(sindicato) * (Double.Parse(porsindicato) / 100)).ToString()
                    costo = "0"
                    retencion = "0"
                    isr = "0"

                    SQL = "EXEC setFacturasNominaInsertar 0," & producto.SubItems(2).Text & "," & producto.SubItems(4).Text
                    SQL &= ",1"  'periodo
                    SQL &= ",'" & Date.Parse(producto.SubItems(1).Text).ToShortDateString()
                    SQL &= "'," & sa
                    SQL &= "," & porsa
                    SQL &= "," & comisionsa
                    SQL &= "," & sindicato & "," & porsindicato & "," & comisionsin
                    SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                    SQL &= "," & costo & "," & retencion
                    SQL &= ",1,'" & nombresistema & "','',1," & isr

                    If Execute(SQL, IdFactura1) = False Then
                        MessageBox.Show("Ocurrio un error setFacturasNominaInsertar 1 ," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    'Buscamos los datos para despues volver a insertarlos

                    SQL = "select * "
                    SQL &= "  from facturas"
                    SQL &= " where iIdFactura = " & producto.SubItems(16).Text

                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    If rwFilas Is Nothing = False Then

                        Dim Fila As DataRow = rwFilas(0)

                        SQL = "EXEC setDetNominaFacturaInsertar   0," & Fila.Item("iIdFactura")
                        SQL &= "," & Fila.Item("fkiIdEmpresa")
                        SQL &= "," & Fila.Item("fkiIdcliente")
                        SQL &= "," & Fila.Item("numfactura") & "," & Fila.Item("importe")
                        SQL &= "," & Fila.Item("iva") & "," & Fila.Item("total")
                        SQL &= ",'','" & Fila.Item("fecha") & "','" & Date.Now.ToShortDateString()
                        SQL &= "'," & IdFactura1 & ",1"


                        If Execute(SQL, detFactura) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        'hacemos el abono automatico

                        'Hacer el detalle automatico pero veirficamos antes si existe algun abono

                        SQL = "select isnull(sum(importe),0) as importe from pagos where iEstatus=1 and fkiIdfactura=" & Fila.Item("iIdFactura")
                        Dim rwabono As DataRow() = nConsulta(SQL)
                        Dim abonos As Double = 0

                        If rwabono Is Nothing = False Then
                            abonos = Double.Parse(rwFilas(0).Item("importe"))
                        End If

                        If abonos = 0 Then
                            SQL = "EXEC setpagosInsertar  0," & Fila.Item("iIdFactura")
                            SQL &= ",'" & Date.Parse(producto.SubItems(1).Text).ToShortDateString()
                            SQL &= "'," & Fila.Item("total")
                            SQL &= ",'" & nombresistema
                            SQL &= "','Abono automatico'"
                            SQL &= ",'" & Date.Now.ToShortDateString()
                            SQL &= "',1"

                            If nExecute(SQL) = False Then
                                Exit Sub
                            End If
                        ElseIf (Double.Parse(Fila.Item("total")) - abonos) > 0 Then
                            'Factura con abonos pendientes
                            MessageBox.Show("La factura ya fue abonada pero tiene saldo pendiente, num de factura:" & Fila.Item("numfactura") & ". Por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If

                        'guardamos la intermedia


                        SQL = "EXEC setInterFacturasNominaInsertar 0," & detFactura & "," & IdFactura1
                        If nExecute(SQL) = False Then

                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If



                    End If





                Next






                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbCancelar_Click(sender, e)
                pnlProgreso.Visible = False
            Else
                MessageBox.Show("Por favor seleccione al menos una registro para importar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If





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

            oCmd.CommandText = "SELECT * FROM [FacturasB$] "
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
                lsvLista.Columns(1).Width = 70
                lsvLista.Columns.Add("ID Patrona")
                lsvLista.Columns(2).Width = 70
                lsvLista.Columns(2).TextAlign = 1
                lsvLista.Columns.Add("Nombre Patrona")
                lsvLista.Columns(3).Width = 150
                lsvLista.Columns.Add("ID Cliente")
                lsvLista.Columns(4).Width = 70
                lsvLista.Columns(4).TextAlign = 1
                lsvLista.Columns.Add("Nombre Cliente")
                lsvLista.Columns(5).Width = 300
                lsvLista.Columns.Add("Dispersión SA")
                lsvLista.Columns(6).Width = 100
                lsvLista.Columns(6).TextAlign = 1
                lsvLista.Columns.Add("% SA")
                lsvLista.Columns(7).Width = 70
                lsvLista.Columns(7).TextAlign = 1
                lsvLista.Columns.Add("Dispersión Sindicato")
                lsvLista.Columns(8).Width = 100
                lsvLista.Columns(8).TextAlign = 1
                lsvLista.Columns.Add("% Sindicato")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns(9).TextAlign = 1
                lsvLista.Columns.Add("Num Factura")
                lsvLista.Columns(10).Width = 100
                lsvLista.Columns(10).TextAlign = 1
                lsvLista.Columns.Add("Importe")
                lsvLista.Columns(11).Width = 100
                lsvLista.Columns(11).TextAlign = 1
                lsvLista.Columns.Add("Iva")
                lsvLista.Columns(12).Width = 100
                lsvLista.Columns(12).TextAlign = 1
                lsvLista.Columns.Add("Total")
                lsvLista.Columns(13).Width = 100
                lsvLista.Columns(13).TextAlign = 1
                lsvLista.Columns.Add("Empresa Facturo")
                lsvLista.Columns(14).Width = 200
                lsvLista.Columns.Add("Cliente Factura")
                lsvLista.Columns(14).Width = 200
                lsvLista.Columns.Add("ID Factura")
                lsvLista.Columns(15).Width = 100
                lsvLista.Columns(15).TextAlign = 1



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