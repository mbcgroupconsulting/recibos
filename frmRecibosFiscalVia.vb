Public Class frmRecibosFiscalVia
    Dim Periodo As String
    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
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

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGuardar.Click
        Dim SQL As String
        Dim Cliente, Puesto, Departamento As String
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




            pgbProgreso.Minimum = 0
            pgbProgreso.Value = 0
            pgbProgreso.Maximum = lsvLista.CheckedItems.Count


            'Dim fila As New DataRow

            Dim fiscalvia As New frmFiscalVia
            fiscalvia.iTipo = IIf(rdbGuo.Checked, 1, 2)

            fiscalvia.dsReporte.Tables.Add("Tabla")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("numtrabajador")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("nombre")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("rfc")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("curp")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("imss")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("fecingreso")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("sucursal")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("departamento")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("puesto")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("deldia")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("aldia")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("sdodiario")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("sdointegrado")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("percepciones")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("deducciones")
            fiscalvia.dsReporte.Tables("Tabla").Columns.Add("neto")



            fiscalvia.dsReporte.Tables.Add("Percepciones")
            fiscalvia.dsReporte.Tables("Percepciones").Columns.Add("numtrabajador")
            fiscalvia.dsReporte.Tables("Percepciones").Columns.Add("numconcepto")
            fiscalvia.dsReporte.Tables("Percepciones").Columns.Add("concepto")
            fiscalvia.dsReporte.Tables("Percepciones").Columns.Add("monto")

            fiscalvia.dsReporte.Tables.Add("Deducciones")
            fiscalvia.dsReporte.Tables("Deducciones").Columns.Add("numtrabajador")
            fiscalvia.dsReporte.Tables("Deducciones").Columns.Add("numconcepto")
            fiscalvia.dsReporte.Tables("Deducciones").Columns.Add("concepto")
            fiscalvia.dsReporte.Tables("Deducciones").Columns.Add("monto")

            For Each producto As ListViewItem In lsvLista.CheckedItems
                totald = 0
                totalp = 0

                'If Trim(producto.SubItems(8).Text) = "6551" Then
                '    MessageBox.Show("No coincide " + producto.SubItems(8).Text)
                'End If

                If (Trim(producto.SubItems(0).Text) = "A") Then
                    

                    percepciones = Val(IIf(Trim(producto.SubItems(19).Text) = "", "0", Trim(producto.SubItems(19).Text)))
                    deducciones = Val(IIf(Trim(producto.SubItems(20).Text) = "", "0", Trim(producto.SubItems(20).Text)))
                    neto = Val(IIf(Trim(producto.SubItems(21).Text) = "", "0", Trim(producto.SubItems(21).Text)))

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
                        
                        Dim fila As DataRow = fiscalvia.dsReporte.Tables("Tabla").NewRow
                        fila.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                        fila.Item("nombre") = Trim(producto.SubItems(9).Text)
                        fila.Item("rfc") = Trim(producto.SubItems(31).Text)
                        fila.Item("curp") = Trim(producto.SubItems(32).Text)
                        fila.Item("imss") = Trim(producto.SubItems(30).Text)
                        fila.Item("fecingreso") = Trim(producto.SubItems(17).Text).Substring(0, 10)
                        fila.Item("sucursal") = Trim(registro.Item("cliente"))
                        fila.Item("departamento") = Trim(registro.Item("depto"))
                        fila.Item("puesto") = Trim(registro.Item("puesto"))
                        fila.Item("deldia") = Periodo
                        fila.Item("aldia") = " "
                        fila.Item("sdodiario") = Trim(producto.SubItems(27).Text)
                        fila.Item("sdointegrado") = Trim(producto.SubItems(28).Text)
                        fila.Item("percepciones") = IIf(Trim(producto.SubItems(19).Text) = "", "0", Trim(producto.SubItems(19).Text))
                        fila.Item("deducciones") = IIf(Trim(producto.SubItems(20).Text) = "", "0", Trim(producto.SubItems(20).Text))
                        fila.Item("neto") = IIf(Trim(producto.SubItems(21).Text) = "", "0", Trim(producto.SubItems(21).Text))

                        fiscalvia.dsReporte.Tables("Tabla").Rows.Add(fila)

                        For x = 38 To 100


                            'Sueldos y salarios
                            If (Trim(lsvLista.Columns(x).Text) = "1") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Percepciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "1"
                                    fila2.Item("concepto") = "Sueldos y salarios"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text)
                                    totalp += Val(IIf(Trim(producto.SubItems(x).Text) = "", "0", Trim(producto.SubItems(x).Text)))
                                    fiscalvia.dsReporte.Tables("Percepciones").Rows.Add(fila2)
                                End If

                            End If

                            ''Aguinaldo
                            'If (Trim(lsvLista.Columns(x).Text) = "30") Then
                            '    If (Trim(producto.SubItems(x).Text) <> "") Then
                            '        Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Percepciones").NewRow
                            '        fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                            '        fila2.Item("numconcepto") = "30"
                            '        fila2.Item("concepto") = "Aguinaldo"
                            '        fila2.Item("monto") = Trim(producto.SubItems(x).Text)
                            '        totalp += Val(IIf(Trim(producto.SubItems(x).Text) = "", "0", Trim(producto.SubItems(x).Text)))
                            '        fiscalvia.dsReporte.Tables("Percepciones").Rows.Add(fila2)
                            '    End If

                            'End If
                            'Anticipo
                            If (Trim(lsvLista.Columns(x).Text) = "560") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "560"
                                    fila2.Item("concepto") = "Anticipo"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If

                            'Ajuste Infonavit
                            If (Trim(lsvLista.Columns(x).Text) = "566") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "566"
                                    fila2.Item("concepto") = "Ajuste Infonavit"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If

                            'Fonacot
                            If (Trim(lsvLista.Columns(x).Text) = "567") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "567"
                                    fila2.Item("concepto") = "Fonacot"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If
                            'credito infonavit
                            If (Trim(lsvLista.Columns(x).Text) = "568") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "568"
                                    fila2.Item("concepto") = "Credito infonavit"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If
                            'seguro de daños
                            If (Trim(lsvLista.Columns(x).Text) = "569") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "569"
                                    fila2.Item("concepto") = "Seguro de daños"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text)
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text) = "", "0", Trim(producto.SubItems(x).Text)))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If
                            'imss
                            If (Trim(lsvLista.Columns(x).Text) = "570") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "570"
                                    fila2.Item("concepto") = "I.M.S.S."
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If
                            'sin goce de sueldo
                            If (Trim(lsvLista.Columns(x).Text) = "571") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "571"
                                    fila2.Item("concepto") = "Permiso sin goce de sueldo"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If
                            'Falta
                            If (Trim(lsvLista.Columns(x).Text) = "573") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "573"
                                    fila2.Item("concepto") = "Falta"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If

                            'incapacidad enfermedad general
                            If (Trim(lsvLista.Columns(x).Text) = "581") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "581"
                                    fila2.Item("concepto") = "Incapacidad enfermedad general"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If
                            'incapacidad maternidad
                            If (Trim(lsvLista.Columns(x).Text) = "582") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "582"
                                    fila2.Item("concepto") = "Incapacidad maternidad"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If

                            'incapacidad rt
                            If (Trim(lsvLista.Columns(x).Text) = "583") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "583"
                                    fila2.Item("concepto") = "Incapacidad riesgo de trabajo"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If

                            'pension alimenticia
                            If (Trim(lsvLista.Columns(x).Text) = "559") Then
                                If (Trim(producto.SubItems(x).Text) <> "") Then
                                    Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                    fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                    fila2.Item("numconcepto") = "559"
                                    fila2.Item("concepto") = "Pensión alimenticia"
                                    fila2.Item("monto") = Trim(producto.SubItems(x).Text).Replace(",", "")
                                    totald += Val(IIf(Trim(producto.SubItems(x).Text).Replace(",", "") = "", "0", Trim(producto.SubItems(x).Text).Replace(",", "")))
                                    fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)
                                End If

                            End If

                            'isr
                            If (Trim(lsvLista.Columns(x).Text) = "801") Then

                                isr = Val(IIf(Trim(producto.SubItems(x).Text) = "", "0", Trim(producto.SubItems(x).Text)))

                            End If
                            'subsidio empleo
                            If (Trim(lsvLista.Columns(x).Text) = "802") Then

                                subsidio = Val(IIf(Trim(producto.SubItems(x).Text) = "", "0", Trim(producto.SubItems(x).Text)))

                            End If
                        Next
                        If percepciones = totalp Then
                            subsidio = subsidio + isr
                            'redondear a dos digitos
                            If (deducciones = Math.Round((totald + Math.Round(subsidio, 2)), 2)) Then
                                'Si coincide
                                Dim fila2 As DataRow = fiscalvia.dsReporte.Tables("Deducciones").NewRow
                                fila2.Item("numtrabajador") = Trim(producto.SubItems(8).Text)
                                fila2.Item("numconcepto") = "919"
                                fila2.Item("concepto") = "Subsidio al empleo efectivo"
                                fila2.Item("monto") = Math.Round(subsidio, 2)
                                fiscalvia.dsReporte.Tables("Deducciones").Rows.Add(fila2)

                            Else
                                'No coincide
                                MessageBox.Show("No coincide " + producto.SubItems(8).Text)
                            End If
                        Else
                            MessageBox.Show("No coincide " + producto.SubItems(8).Text)
                        End If
                    Else
                        MessageBox.Show("No existe este numero de empleado en la base de captura:" + producto.SubItems(8).Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If



                End If



                pgbProgreso.Value += 1
                Application.DoEvents()
                'mandar el reporte




            Next

            Dim Archivo As String = IO.Path.GetTempFileName.Replace(".tmp", ".xml")
            fiscalvia.dsReporte.WriteXml(Archivo, XmlWriteMode.WriteSchema)

            fiscalvia.ShowDialog()
            tsbCancelar_Click(sender, e)
            pnlProgreso.Visible = False
        Else

            MessageBox.Show("Por favor seleccione al menos un trabajador para generar el recibo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        pnlCatalogo.Enabled = True
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

    Private Sub frmRecibosFiscalVia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class