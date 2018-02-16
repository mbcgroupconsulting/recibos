


Public Class ImportacionGuo
    Dim Periodo As String
    Dim iddepto As String
    Dim idpuesto As String
    Dim idfiscal As String
    Dim idinterna As String
    Dim idencontrado As String
    Dim idaguila As String


    Private Sub pnlGuo_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlGuo.Paint

    End Sub

    Private Sub ImportacionGuo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

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

                    If (Trim(producto.SubItems(0).Text) = "A") Then
                        puesto = ""
                        For Each filaguo As ListViewItem In lsvListaGuo.Items

                            'Si es igual el numero de empleado de la lista de aguila en la lista de ale
                            If (Trim(producto.SubItems(8).Text) = Trim(filaguo.SubItems(1).Text)) Then
                                'buscar departamento con los datos de la lista de ale en la base de la empresa guo
                                iddepto = ""
                                idpuesto = ""
                                idencontrado = "1"
                                SQL = "select * from departamentos"
                                Dim rwFilas As DataRow() = nConsulta(SQL)

                                If rwFilas Is Nothing = False Then


                                    For Each rwfila As DataRow In rwFilas
                                        If (Trim(rwfila.Item("cNombre")) = Trim(filaguo.SubItems(4).Text)) Then
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
                                        If (Trim(rwfila.Item("cNombre")) = Trim(filaguo.SubItems(3).Text)) Then
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
                                If (Trim(producto.SubItems(11).Text) = "CLASE") Then
                                    idfiscal = "7"
                                End If
                                If (Trim(producto.SubItems(11).Text) = "DAMAS") Then
                                    idfiscal = "8"
                                End If
                                If (Trim(producto.SubItems(11).Text) = "PROFESIONAL") Then
                                    idfiscal = "9"
                                End If
                                If (Trim(producto.SubItems(11).Text) = "PRODUCTORA") Then
                                    idfiscal = "12"
                                End If
                                If (Trim(producto.SubItems(11).Text) = "SURTIDORA") Then
                                    idfiscal = "11"
                                End If
                                'obtener empresa interna archivo ale
                                If (Trim(filaguo.SubItems(6).Text) = "MANUFACTURERA CLASE") Then
                                    idinterna = "7"
                                ElseIf (Trim(filaguo.SubItems(6).Text) = "MANUFACTURERA DAMA") Then
                                    idinterna = "8"
                                ElseIf (Trim(filaguo.SubItems(6).Text) = "PROFESIONALES") Then
                                    idinterna = "9"
                                ElseIf (Trim(filaguo.SubItems(6).Text) = "PRODUCTORA") Then
                                    idinterna = "12"
                                ElseIf (Trim(filaguo.SubItems(6).Text) = "SURTIDORA") Then
                                    idinterna = "11"
                                End If


                                paso = Trim(producto.SubItems(9).Text)
                                paterno = Strings.Left(paso, InStr(paso, " ") - 1)
                                paso = Mid(paso, InStr(paso, " ") + 1)
                                If (InStr(paso, " ") > 0) Then
                                    materno = Strings.Left(paso, InStr(paso, " ") - 1)
                                    nombre = Mid(paso, InStr(paso, " ") + 1)
                                Else
                                    nombre = paso
                                End If


                               
                                'verificar datos a agregar
                                'Agregar el trabajador
                                'Insertar nuevo
                                SQL = "EXEC setempleadosInsertar 0,'" & Trim(producto.SubItems(8).Text) & "','" & nombre
                                SQL &= "','" & paterno
                                SQL &= "','" & materno & "','" & nombre
                                SQL &= "','" & Trim(producto.SubItems(31).Text) & "','" & Trim(producto.SubItems(32).Text) & "','" & Trim(producto.SubItems(30).Text)
                                SQL &= "','"
                                SQL &= "','" & "',1,'"
                                SQL &= "',1,'" & Date.Today.ToShortDateString & "','" & Date.Today.ToShortDateString
                                SQL &= "','" & puesto & "','"
                                SQL &= "'," & Trim(producto.SubItems(27).Text) & "," & Trim(producto.SubItems(28).Text)
                                SQL &= ",'','','','','','"
                                SQL &= "',5,0,0," & idfiscal & ",0,0"
                                SQL &= ",'" & Strings.Right(Trim(producto.SubItems(25).Text), 10) & "',1,'"
                                SQL &= "','',1,'"
                                SQL &= "','" & Convert.ToDateTime(Trim(producto.SubItems(17).Text)).ToShortDateString & "','" & Date.Today.ToShortDateString & "','" & Convert.ToDateTime(Trim(producto.SubItems(17).Text)).ToShortDateString
                                SQL &= "',0,'','"
                                SQL &= "',0,'','"
                                SQL &= "',0,'','"
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
                                    SQL = "EXEC setIngresoBajaInsertar  0," & Fila.Item("id") & ",'A','" & Convert.ToDateTime(Trim(producto.SubItems(17).Text)).ToShortDateString & "','01/01/1900'"

                                End If



                                If nExecute(SQL) = False Then
                                    Exit Sub
                                End If

                                'Agregar datos de sueldos para historial



                                SQL = "select max(iIdEmpleado) as id from empleados"
                                Dim rwSueldo As DataRow() = nConsulta(SQL)

                                If rwSueldo Is Nothing = False Then
                                    Dim Fila As DataRow = rwSueldo(0)
                                    SQL = "EXEC setSueldoInsertar  0,0,'" & Convert.ToDateTime(Trim(producto.SubItems(17).Text)).ToShortDateString
                                    SQL += "',0,''," & Trim(producto.SubItems(27).Text) & "," & Trim(producto.SubItems(28).Text) & "," & Fila.Item("id")

                                End If


                                If nExecute(SQL) = False Then
                                    Exit Sub
                                End If

                                Exit For
                            End If



                        Next
                        If idencontrado = "0" Then
                            MessageBox.Show("no se encontro el numero de trabajador : " & Trim(producto.SubItems(8).Text), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim anchos As String() = "40,20,20,20,20,20,20,40,65,250,150,130,130,130,130,130,130,130,130,130,130,130,130".Split(",")

            Periodo = tbRegistros.Rows(1).Item(8).ToString().Substring(0, 36)
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
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(40).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(41).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(42).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(43).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(44).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(45).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(46).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(47).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(48).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(49).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(50).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(51).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(52).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(53).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(54).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(55).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(56).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(57).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(58).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(59).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(60).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(61).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(62).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(63).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(64).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(65).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(66).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(67).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(68).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(69).ToString())
                    item.SubItems.Add("" & tbRegistros.Rows(x + 4).Item(70).ToString())
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

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsbase.Click
        Dim dialogo As New OpenFileDialog
        Dim ruta As String = ""

        With dialogo
            .Title = "Búsqueda de catálogos."
            .Filter = "Archivos de excel (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                ruta = .FileName
            End If
        End With
        If (ruta.Length > 0) Then
            Dim xlsConexion As New OleDb.OleDbConnection
            Dim oCmd As New OleDb.OleDbCommand
            Dim oDa As New OleDb.OleDbDataAdapter
            Dim oDs As New DataSet, Hoja As String = ""

            pnlGuo.Enabled = False

            lsvListaGuo.Visible = False

            Me.cmdCerrar.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False
            Application.DoEvents()

            Try
                xlsConexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta & "; Extended Properties= Excel 12.0 Xml;"
                xlsConexion.Open()

                Dim Esquema As DataTable = xlsConexion.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, {Nothing, Nothing, Nothing, "TABLE"})

                If Esquema Is Nothing = False Then
                    Hoja = Esquema.Rows(0)(2).ToString()
                Else
                    MessageBox.Show("No se ha podido leer el archivo específicado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                oCmd.CommandText = "SELECT * FROM [hoja1$] "
                oCmd.Connection = xlsConexion
                oDa.SelectCommand = oCmd

                oDa.Fill(oDs, "Sales")
                xlsConexion.Close()



                Dim tbRegistros As DataTable = oDs.Tables(0).Copy()
                lsvListaGuo.Items.Clear()
                lsvListaGuo.Columns.Clear()
                Dim anchos As String() = "90,150,190,190,190,190,190,190,190,190".Split(",")

                If tbRegistros Is Nothing = False Then
                    For i As Integer = 0 To tbRegistros.Columns.Count - 1
                        If i = 0 Then
                            lsvListaGuo.Columns.Add("")
                        Else
                            lsvListaGuo.Columns.Add("columna " & i)
                        End If

                        If i >= 5 Then
                            lsvListaGuo.Columns(i).TextAlign = HorizontalAlignment.Right
                        End If
                        If i < anchos.Length Then
                            lsvListaGuo.Columns(i).Width = Val(anchos(i))
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
                        item = lsvListaGuo.Items.Add("Fila " & x + 1)
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
                pnlGuo.Enabled = True
                If lsvListaGuo.Items.Count = 0 Then
                    MessageBox.Show("El catálogo no puso ser importado o no contiene registros." & vbCrLf & "¿Por favor verifique?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Se han encontrado " & FormatNumber(lsvListaGuo.Items.Count, 0) & " registros en el archivo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'tsbGuardar.Enabled = True
                    'tsbCancelar.Enabled = True
                    'lblRuta.Text = FormatNumber(lsvLista.Items.Count, 0) & " registros en el archivo."
                End If
            Catch ex As Exception
                ShowError(ex, Me.Text)
            End Try
            Me.Enabled = True
            Me.cmdCerrar.Enabled = True
            Me.Cursor = Cursors.Default
            'tsbImportar.Enabled = True
            lsvListaGuo.Visible = True
        End If

    End Sub
End Class