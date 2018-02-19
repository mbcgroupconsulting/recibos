Public Class ImportacionAltas
    Dim Periodo As String
    Dim iddepto As String
    Dim idpuesto As String
    Dim idfiscal As String
    Dim idinterna As String
    Dim idencontrado As String
    Dim idaguila As String
    Dim idinfonavit As String

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        tsbNuevo.Enabled = False
        tsbImportar.Enabled = True
        tsbImportar_Click(sender, e)
    End Sub

    Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
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

    Private Sub tsbGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGuardar.Click
        Dim SQL As String, Mensaje As String = ""
        Dim paterno, materno, nombre, paso As String
        Dim puesto, departamento As String

        Try
            'Validar
            If lsvLista.Items.Count > 0 Then
                For Each producto As ListViewItem In lsvLista.Items
                    idencontrado = "0"

                    If (Trim(producto.SubItems(0).Text) <> "") Then
                        puesto = ""

                        SQL = "select iIdEmpleado, clientes.nombre as cliente,puestos.cNombre as puesto, departamentos.cnombre as depto"
                        SQL &= " from (((empleados inner join clientes "
                        SQL &= " on fkiIdClienteInter=iIdCliente)"
                        SQL &= " inner join puestos on fkiIdPuesto=iIdPuesto)"
                        SQL &= " inner join departamentos on fkiIdDepartamento=iIdDepartamento)"
                        SQL &= " where cCodigoEmpleado =" & Trim(producto.SubItems(0).Text)
                        SQL &= " and empleados.fkiIdEmpresa =5"

                        Dim rwEmpleado As DataRow() = nConsulta(SQL)



                        'Si es igual el numero de empleado de la lista de aguila en la lista de ale
                        If rwEmpleado Is Nothing = False Then
                            MessageBox.Show("El numero de trabajador : " & Trim(producto.SubItems(0).Text) & " ya esta dado de alta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            'Si es igual el numero de empleado de la lista de aguila en la lista de ale

                            'buscar departamento con los datos de la lista de ale en la base de la empresa guo
                            iddepto = ""
                            idpuesto = ""
                            idencontrado = "1"
                            SQL = "select * from departamentos"
                            Dim rwFilas As DataRow() = nConsulta(SQL)

                            If rwFilas Is Nothing = False Then


                                For Each rwfila As DataRow In rwFilas
                                    If (Trim(rwfila.Item("cNombre")) = Trim(producto.SubItems(26).Text)) Then
                                        iddepto = rwfila.Item("iIdDepartamento")
                                        departamento = Trim(rwfila.Item("cNombre"))
                                        Exit For

                                    End If

                                Next
                                If iddepto = "" Then
                                    iddepto = "1"
                                End If
                            End If

                            'buscar puesto con los datos de la lista de ale en la base de la empresa guo
                            SQL = "select * from puestos"
                            Dim rwFilas2 As DataRow() = nConsulta(SQL)

                            If rwFilas2 Is Nothing = False Then


                                For Each rwfila As DataRow In rwFilas2
                                    If (Trim(rwfila.Item("cNombre")) = Trim(producto.SubItems(23).Text)) Then
                                        idpuesto = rwfila.Item("iIdPuesto")
                                        puesto = Trim(rwfila.Item("cNombre"))
                                        Exit For

                                    End If

                                Next
                                If idpuesto = "" Then
                                    idpuesto = "1"
                                End If
                            End If
                            'obtener empresa fiscal archivo aguila
                            If (Trim(producto.SubItems(7).Text) = "CLASE") Then
                                idfiscal = "7"
                            End If
                            If (Trim(producto.SubItems(7).Text) = "DAMAS") Then
                                idfiscal = "8"
                            End If
                            If (Trim(producto.SubItems(7).Text) = "PROFESIONAL") Then
                                idfiscal = "9"
                            End If
                            If (Trim(producto.SubItems(7).Text) = "PRODUCTORA") Then
                                idfiscal = "12"
                            End If
                            If (Trim(producto.SubItems(7).Text) = "SURTIDORA") Then
                                idfiscal = "11"
                            End If
                            'obtener empresa interna archivo ale
                            If (Trim(producto.SubItems(27).Text) = "CLASE") Then
                                idinterna = "7"
                            ElseIf (Trim(producto.SubItems(27).Text) = "DAMAS") Then
                                idinterna = "8"
                            ElseIf (Trim(producto.SubItems(27).Text) = "PROFESIONAL") Then
                                idinterna = "9"
                            ElseIf (Trim(producto.SubItems(27).Text) = "PRODUCTORA") Then
                                idinterna = "12"
                            ElseIf (Trim(producto.SubItems(27).Text) = "SURTIDORA") Then
                                idinterna = "11"
                            End If


                            paso = Trim(producto.SubItems(1).Text)
                            paterno = Strings.Left(paso, InStr(paso, " ") - 1)
                            paso = Mid(paso, InStr(paso, " ") + 1)
                            If (InStr(paso, " ") > 0) Then
                                materno = Strings.Left(paso, InStr(paso, " ") - 1)
                                nombre = Mid(paso, InStr(paso, " ") + 1)
                            Else
                                nombre = paso
                            End If

                            'obtener id infonavit
                            If (Trim(producto.SubItems(54).Text) = "VSM") Then
                                idinfonavit = "0"
                            ElseIf (Trim(producto.SubItems(54).Text) = "PORCENTAJE") Then
                                idinfonavit = "1"
                            ElseIf (Trim(producto.SubItems(54).Text) = "CUOTA FIJA") Then
                                idinfonavit = "2"
                            End If



                            'verificar datos a agregar
                            'Agregar el trabajador
                            'Insertar nuevo
                            SQL = "EXEC setempleadosInsertar 0,'" & Trim(producto.SubItems(0).Text) & "','" & nombre
                            SQL &= "','" & paterno
                            SQL &= "','" & materno & "','" & Trim(producto.SubItems(1).Text)
                            SQL &= "','" & Trim(producto.SubItems(28).Text) & "','" & Trim(producto.SubItems(29).Text) & "','" & Trim(producto.SubItems(30).Text)
                            SQL &= "','"
                            SQL &= "','',1,'"
                            SQL &= "',1,'" & Date.Today.ToShortDateString & "','" & Date.Today.ToShortDateString
                            SQL &= "','" & puesto & "','"
                            SQL &= "'," & IIf(Trim(producto.SubItems(51).Text) = "", 0, Trim(producto.SubItems(51).Text)) & "," & IIf(Trim(producto.SubItems(52).Text) = "", 0, Trim(producto.SubItems(52).Text))
                            SQL &= ",'','','','','','"
                            SQL &= "',5,0,0," & idfiscal & ",0,4"
                            SQL &= ",'" & Trim(producto.SubItems(39).Text) & "',1,'"
                            SQL &= "','',1,'"
                            SQL &= "','" & Convert.ToDateTime(Trim(producto.SubItems(45).Text)).ToShortDateString & "','" & Date.Today.ToShortDateString & "','" & Convert.ToDateTime(Trim(producto.SubItems(45).Text)).ToShortDateString
                            SQL &= "',0,'','"
                            SQL &= "',0,'" & Trim(producto.SubItems(57).Text) & "','" & Trim(producto.SubItems(54).Text)
                            SQL &= "'," & IIf(Trim(producto.SubItems(55).Text) = "", 0, Trim(producto.SubItems(55).Text)) & ",'','"
                            SQL &= "','','',''," & idinterna & "," & idpuesto & "," & iddepto
                            ' PRueba
                            'idaguila = Trim(producto.SubItems(8).Text)
                            'If idaguila = "12982" Then
                            '    MessageBox.Show("dato encontrado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'End If

                            If nExecute(SQL) = False Then
                                Exit Sub
                            End If

                            'Agregar alta/baja

                            'Obtener id
                            SQL = "select max(iIdEmpleado) as id from empleados"
                            Dim rwAB As DataRow() = nConsulta(SQL)

                            If rwAB Is Nothing = False Then
                                Dim Fila As DataRow = rwAB(0)
                                SQL = "EXEC setIngresoBajaInsertar  0," & Fila.Item("id") & ",'A','" & Convert.ToDateTime(Trim(producto.SubItems(45).Text)).ToShortDateString & "','01/01/1900'"

                            End If



                            If nExecute(SQL) = False Then
                                Exit Sub
                            End If

                            'Agregar datos de sueldos para historial



                            SQL = "select max(iIdEmpleado) as id from empleados"
                            Dim rwSueldo As DataRow() = nConsulta(SQL)

                            If rwSueldo Is Nothing = False Then
                                Dim Fila As DataRow = rwSueldo(0)
                                SQL = "EXEC setSueldoInsertar  0,0,'" & Convert.ToDateTime(Trim(producto.SubItems(45).Text)).ToShortDateString
                                SQL += "',0,''," & IIf(Trim(producto.SubItems(51).Text) = "", 0, Trim(producto.SubItems(51).Text)) & "," & IIf(Trim(producto.SubItems(52).Text) = "", 0, Trim(producto.SubItems(52).Text)) & "," & Fila.Item("id")

                            End If


                            If nExecute(SQL) = False Then
                                Exit Sub
                            End If
                        End If
                        
                    End If
                Next
                MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If



        Catch ex As Exception
            ShowError(ex, Me.Text & idaguila)
        End Try
    End Sub

    Private Sub tsbProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbProcesar.Click
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
            Dim anchos As String() = "65,250,10,10,10,10,10,200,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,150,10,10,150,150,150,150,150,10,10,10,10,10,10,10,150,150,10,10,10,10,10,150,10,10,10,10,10,100,100,10,100,100,100,100".Split(",")

            'Periodo = tbRegistros.Rows(1).Item(8).ToString().Substring(0, 36)
            If tbRegistros Is Nothing = False Then
                For i As Integer = 0 To tbRegistros.Columns.Count - 1
                    lsvLista.Columns.Add(tbRegistros.Rows(0).Item(i).ToString())
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
                For x = 0 To tbRegistros.Rows.Count - 4
                    item = lsvLista.Items.Add(tbRegistros.Rows(x + 3).Item(0).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(1).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(2).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(3).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(4).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(5).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(6).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(7).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(8).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(9).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(10).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(11).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(12).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(13).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(14).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(15).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(16).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(17).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(18).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(19).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(20).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(21).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(22).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(23).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(24).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(25).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(26).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(27).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(28).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(29).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(30).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(31).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(32).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(33).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(34).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(35).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(36).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(37).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(38).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(39).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(40).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(41).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(42).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(43).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(44).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(45).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(46).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(47).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(48).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(49).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(50).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(51).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(52).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(53).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(54).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(55).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(56).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(57).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(58).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(59).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(60).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(61).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(62).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(63).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(64).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(65).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(66).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(67).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(68).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(69).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 3).Item(70).ToString())
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

    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
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

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class