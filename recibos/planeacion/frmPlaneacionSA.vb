Public Class frmPlaneacionSA
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

    End Sub

    Private Sub tsbProcesar_Click(sender As Object, e As EventArgs) Handles tsbProcesar.Click
        Dim xlsConexion As New OleDb.OleDbConnection
        Dim oCmd As New OleDb.OleDbCommand
        Dim oDa As New OleDb.OleDbDataAdapter
        Dim oDs As New DataSet, Hoja As String = ""

        'pnlCatalogo.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        'lsvLista.Visible = False
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

            Dim anchos As String() = "90,150,190,190,190,190,190,190,190,190,190".Split(",")
            'dtgDatos.DataSource = ""

            If tbRegistros Is Nothing = False Then



                dtgDatos.DefaultCellStyle.Font = New Font("Calibri", 8)
                dtgDatos.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 9)
                Dim dsPeriodo As New DataSet
                dsPeriodo.Tables.Add("Tabla")

                dsPeriodo.Tables("Tabla").Columns.Add("Id_empleado")

                dsPeriodo.Tables("Tabla").Columns.Add("Nombre")
                dsPeriodo.Tables("Tabla").Columns.Add("Sueldo")
                dsPeriodo.Tables("Tabla").Columns.Add("Sueldo Diario")
                dsPeriodo.Tables("Tabla").Columns.Add("SBC")
                dsPeriodo.Tables("Tabla").Columns.Add("Dias")
                dsPeriodo.Tables("Tabla").Columns.Add("Sueldo Bruto")
                dsPeriodo.Tables("Tabla").Columns.Add("Total_Percepciones")
                dsPeriodo.Tables("Tabla").Columns.Add("Total Percepciones ISR")
                dsPeriodo.Tables("Tabla").Columns.Add("Subsidio al empleo")
                dsPeriodo.Tables("Tabla").Columns.Add("Total Percepciones")
                dsPeriodo.Tables("Tabla").Columns.Add("ISR")
                dsPeriodo.Tables("Tabla").Columns.Add("IMSS")
                dsPeriodo.Tables("Tabla").Columns.Add("Total deducciones")
                dsPeriodo.Tables("Tabla").Columns.Add("Neto")
                dsPeriodo.Tables("Tabla").Columns.Add("IMSS_CS")
                dsPeriodo.Tables("Tabla").Columns.Add("RCV_CS")
                dsPeriodo.Tables("Tabla").Columns.Add("INFONAVIT_CS")
                dsPeriodo.Tables("Tabla").Columns.Add("ISN_CS")
                dsPeriodo.Tables("Tabla").Columns.Add("TOTAL_CS")
                dsPeriodo.Tables("Tabla").Columns.Add("COSTO_NOMINA_TOTAL")
                For x = 0 To tbRegistros.Rows.Count - 1

                    Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow
                    fila.Item("Id_empleado") = (x + 1).ToString
                    fila.Item("Nombre") = tbRegistros.Rows(x).Item(0).ToString()
                    fila.Item("Sueldo") = tbRegistros.Rows(x).Item(1).ToString()
                    fila.Item("Sueldo Diario") = "0"
                    fila.Item("SBC") = "0"
                    fila.Item("Dias") = "0"
                    fila.Item("Sueldo Bruto") = "0"
                    fila.Item("Total_Percepciones") = "0"
                    fila.Item("Total Percepciones ISR") = "0"
                    fila.Item("Subsidio al empleo") = "0"
                    fila.Item("Total Percepciones") = "0"
                    fila.Item("ISR") = "0"
                    fila.Item("IMSS") = "0"
                    fila.Item("Total deducciones") = "0"
                    fila.Item("Neto") = "0"
                    fila.Item("IMSS_CS") = "0"
                    fila.Item("RCV_CS") = "0"
                    fila.Item("INFONAVIT_CS") = "0"
                    fila.Item("ISN_CS") = "0"
                    fila.Item("TOTAL_CS") = "0"
                    fila.Item("COSTO_NOMINA_TOTAL") = "0"



                    dsPeriodo.Tables("Tabla").Rows.Add(fila)




                Next

                dtgDatos.DataSource = dsPeriodo.Tables("Tabla")


                dtgDatos.Columns(0).Width = 30
                dtgDatos.Columns(0).ReadOnly = True
                dtgDatos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'nombre
                dtgDatos.Columns(1).Width = 200
                dtgDatos.Columns(1).ReadOnly = True

                'sueldo
                dtgDatos.Columns(2).Width = 100

                dtgDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Sueldo Diario
                dtgDatos.Columns(3).Width = 100
                dtgDatos.Columns(3).ReadOnly = True
                dtgDatos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'SBC
                dtgDatos.Columns(4).Width = 100
                dtgDatos.Columns(4).ReadOnly = True
                dtgDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Dias
                dtgDatos.Columns(5).Width = 100
                dtgDatos.Columns(5).ReadOnly = True
                dtgDatos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Sueldo Bruto
                dtgDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(6).ReadOnly = True
                dtgDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Total Percepciones
                dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(7).ReadOnly = True
                dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Total Percepciones ISR
                dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(8).ReadOnly = True
                dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Subsidio al empleo
                dtgDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(9).ReadOnly = True
                dtgDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Total Percepciones
                dtgDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(10).ReadOnly = True
                dtgDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'ISR
                dtgDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(11).ReadOnly = True
                dtgDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'IMSS
                dtgDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(12).ReadOnly = True
                dtgDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Total deducciones
                dtgDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(13).ReadOnly = True
                dtgDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Neto
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(14).ReadOnly = True
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dtgDatos.Columns(15).Width = 100
                dtgDatos.Columns(15).ReadOnly = True
                dtgDatos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dtgDatos.Columns(16).Width = 100
                dtgDatos.Columns(16).ReadOnly = True
                dtgDatos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dtgDatos.Columns(17).Width = 100
                dtgDatos.Columns(17).ReadOnly = True
                dtgDatos.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dtgDatos.Columns(18).Width = 100
                dtgDatos.Columns(18).ReadOnly = True
                dtgDatos.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dtgDatos.Columns(19).Width = 100
                dtgDatos.Columns(19).ReadOnly = True
                dtgDatos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dtgDatos.Columns(20).Width = 150
                dtgDatos.Columns(20).ReadOnly = True
                dtgDatos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                

            End If



            If dtgDatos.Rows.Count = 0 Then
                MessageBox.Show("El archivo no puso ser importado o no contiene registros." & vbCrLf & "¿Por favor verifique?", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Se han encontrado " & FormatNumber(dtgDatos.Rows.Count, 0) & " registros en el archivo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tsbGuardar.Enabled = True
                tsbCancelar.Enabled = True
                lblRuta.Text = FormatNumber(dtgDatos.Rows.Count, 0) & " registros en el archivo."
            End If
        Catch ex As Exception
            ShowError(ex, Me.Text)
        End Try
        Me.Enabled = True
        Me.cmdCerrar.Enabled = True
        Me.Cursor = Cursors.Default
        tsbImportar.Enabled = True

    End Sub

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        'pnlCatalogo.Enabled = False
        'lsvLista.Items.Clear()
        'chkAll.Checked = False
        'lblRuta.Text = ""
        tsbImportar.Enabled = False
        tsbProcesar.Enabled = False
        tsbGuardar.Enabled = False
        tsbCancelar.Enabled = False
        tsbNuevo.Enabled = True
    End Sub

    Private Sub frmPlaneacionSA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarperiodos()
        cargarsalario()
    End Sub
    Private Sub cargarsalario()
        Dim SQL As String
        Try
            SQL = "select * from salario where anio=" & Date.Now.Year.ToString("0000")
            Dim rwSalario As DataRow() = nConsulta(SQL)
            If rwSalario Is Nothing = False Then
                txtsalario.Text = rwSalario(0)("areaa")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cargarperiodos()
        Dim sql As String
        Try
            sql = "select * from tipos_periodos2"
            nCargaCBO(cboperiodo, sql, "nombre", "iIdTipoperiodo2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcalcular_Click(sender As Object, e As EventArgs) Handles cmdcalcular.Click
        Dim propuesta As Double
        Dim bruto As Double
        Dim excendente As Double
        Dim isr As Double
        Dim isr2 As Double
        Dim subsidio As Double
        Dim diferencia As Double
        Dim SDI As Double
        Dim imss As Double
        Dim imssP As Double
        Dim RCVP As Double
        Dim INFONAVITP As Double

        Dim SQL As String
        Try
            If dtgDatos.Rows.Count > 0 Then


                pnlProgreso.Visible = True

                Application.DoEvents()



                pgbProgreso.Minimum = 0
                pgbProgreso.Value = 0
                pgbProgreso.Maximum = dtgDatos.Rows.Count

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    propuesta = Double.Parse(dtgDatos.Rows(x).Cells(2).Value) / Double.Parse(Nuddias.Value)
                    bruto = propuesta * Double.Parse(Nuddias.Value)

                    Do
                        bruto = propuesta * Double.Parse(Nuddias.Value)
                        'calculos

                        'Calculamos isr

                        '1.- buscamos datos para el calculo

                        SQL = "select * from isr where ((" & bruto & ">=isr.limiteinf and " & bruto & "<=isr.limitesup)"
                        SQL &= " or (" & bruto & ">=isr.limiteinf and isr.limitesup=0)) and fkiIdTipoPeriodo2=" & cboperiodo.SelectedValue

                        Dim rwISRCALCULO As DataRow() = nConsulta(SQL)
                        If rwISRCALCULO Is Nothing = False Then
                            excendente = bruto - Double.Parse(rwISRCALCULO(0)("limiteinf").ToString)
                            isr = (excendente * (Double.Parse(rwISRCALCULO(0)("porcentaje").ToString) / 100)) + Double.Parse(rwISRCALCULO(0)("cuotafija").ToString)

                            '2.- buscamos los datos para subsidio
                            SQL = "select * from subsidio where ((" & bruto & ">=limiteinf and " & bruto & "<=limitesup)"
                            SQL &= " or (" & bruto & ">=limiteinf and limitesup=0)) and fkiIdTipoPeriodo2=" & cboperiodo.SelectedValue

                            Dim rwSUBSIDIO As DataRow() = nConsulta(SQL)
                            If rwSUBSIDIO Is Nothing = False Then
                                subsidio = Double.Parse(rwSUBSIDIO(0)("credito").ToString)

                                isr2 = IIf(isr > subsidio, isr - subsidio, 0)
                                subsidio = IIf(subsidio > isr, subsidio - isr, 0)

                                'Calcular imss
                                imss = calculoimss(propuesta * 1.0452, bruto, 1)



                                If Math.Round((bruto + subsidio - isr - imss), 2) = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(2).Value), 2) Then
                                    'el sueldo de la propuesta es correcto
                                    dtgDatos.Rows(x).Cells(3).Value = propuesta
                                Else
                                    If bruto + subsidio - isr2 - imss > Double.Parse(dtgDatos.Rows(x).Cells(2).Value) Then

                                        diferencia = (bruto + subsidio - isr2 - imss) - Double.Parse(dtgDatos.Rows(x).Cells(2).Value)
                                        If diferencia > 1000 Then
                                            propuesta = propuesta - 100
                                        ElseIf diferencia > 500 And diferencia < 999.999 Then
                                            propuesta = propuesta - 50
                                        ElseIf diferencia > 300 And diferencia < 499.999 Then
                                            propuesta = propuesta - 15
                                        ElseIf diferencia > 100 And diferencia < 299.999 Then
                                            propuesta = propuesta - 10
                                        ElseIf diferencia > 50 And diferencia < 99.999 Then
                                            propuesta = propuesta - 5
                                        ElseIf diferencia > 20 And diferencia < 49.999 Then
                                            propuesta = propuesta - 1
                                        ElseIf diferencia > 10 And diferencia < 19.999 Then
                                            propuesta = propuesta - 0.5
                                        ElseIf diferencia > 5 And diferencia < 9.999 Then
                                            propuesta = propuesta - 0.4
                                        ElseIf diferencia > 4.5 And diferencia < 4.999 Then
                                            propuesta = propuesta - 0.3
                                        ElseIf diferencia > 4 And diferencia < 4.499 Then
                                            propuesta = propuesta - 0.2
                                        ElseIf diferencia > 3.5 And diferencia < 3.999 Then
                                            propuesta = propuesta - 0.15
                                        ElseIf diferencia > 3 And diferencia < 3.499 Then
                                            propuesta = propuesta - 0.1
                                        ElseIf diferencia > 2.5 And diferencia < 2.999 Then
                                            propuesta = propuesta - 0.05
                                        ElseIf diferencia > 2 And diferencia < 2.499 Then
                                            propuesta = propuesta - 0.04
                                        ElseIf diferencia > 1 And diferencia < 1.999 Then
                                            propuesta = propuesta - 0.01
                                        ElseIf diferencia > 0.5 And diferencia < 0.999 Then
                                            propuesta = propuesta - 0.008
                                        ElseIf diferencia > 0.2 And diferencia < 0.49 Then
                                            propuesta = propuesta - 0.005
                                        ElseIf diferencia > 0.1 And diferencia < 0.19 Then
                                            propuesta = propuesta - 0.0001
                                        Else
                                            propuesta = propuesta - 0.0001

                                        End If

                                    Else
                                        diferencia = Double.Parse(dtgDatos.Rows(x).Cells(2).Value) - (bruto + subsidio - isr2 - imss)
                                        If diferencia > 1000 Then
                                            propuesta = propuesta + 100
                                        ElseIf diferencia > 500 And diferencia < 999.999 Then
                                            propuesta = propuesta + 40
                                        ElseIf diferencia > 300 And diferencia < 499.999 Then
                                            propuesta = propuesta + 30
                                        ElseIf diferencia > 100 And diferencia < 299.999 Then
                                            propuesta = propuesta + 20
                                        ElseIf diferencia > 50 And diferencia < 99.999 Then
                                            propuesta = propuesta + 3
                                        ElseIf diferencia > 20 And diferencia < 49.999 Then
                                            propuesta = propuesta + 1
                                        ElseIf diferencia > 10 And diferencia < 19.999 Then
                                            propuesta = propuesta + 0.5
                                        ElseIf diferencia > 5 And diferencia < 9.999 Then
                                            propuesta = propuesta + 0.3
                                        ElseIf diferencia > 3 And diferencia < 4.999 Then
                                            propuesta = propuesta + 0.2
                                        ElseIf diferencia > 1 And diferencia < 2.999 Then
                                            propuesta = propuesta + 0.15
                                        ElseIf diferencia > 0.5 And diferencia < 0.999 Then
                                            propuesta = propuesta + 0.1
                                        ElseIf diferencia > 0.2 And diferencia < 0.49 Then
                                            propuesta = propuesta + 0.05
                                        ElseIf diferencia > 0.1 And diferencia < 0.19 Then
                                            propuesta = propuesta + 0.01
                                        Else
                                            propuesta = propuesta + 0.0001

                                        End If




                                    End If
                                End If

                            End If
                        End If
                    Loop While Math.Round((bruto + subsidio - isr2 - imss), 2) <> Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(2).Value), 2)
                    dtgDatos.Rows(x).Cells(3).Value = propuesta

                    pgbProgreso.Value += 1
                    Application.DoEvents()
                Next


                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    propuesta = Double.Parse(dtgDatos.Rows(x).Cells(3).Value)
                    bruto = propuesta * Double.Parse(Nuddias.Value)


                    bruto = propuesta * Double.Parse(Nuddias.Value)
                    'calculos

                    'Calculamos isr

                    '1.- buscamos datos para el calculo

                    SQL = "select * from isr where ((" & bruto & ">=isr.limiteinf and " & bruto & "<=isr.limitesup)"
                    SQL &= " or (" & bruto & ">=isr.limiteinf and isr.limitesup=0)) and fkiIdTipoPeriodo2=" & cboperiodo.SelectedValue

                    Dim rwISRCALCULO As DataRow() = nConsulta(SQL)
                    If rwISRCALCULO Is Nothing = False Then
                        excendente = bruto - Double.Parse(rwISRCALCULO(0)("limiteinf").ToString)
                        isr = (excendente * (Double.Parse(rwISRCALCULO(0)("porcentaje").ToString) / 100)) + Double.Parse(rwISRCALCULO(0)("cuotafija").ToString)

                        '2.- buscamos los datos para subsidio
                        SQL = "select * from subsidio where ((" & bruto & ">=limiteinf and " & bruto & "<=limitesup)"
                        SQL &= " or (" & bruto & ">=limiteinf and limitesup=0)) and fkiIdTipoPeriodo2=" & cboperiodo.SelectedValue

                        Dim rwSUBSIDIO As DataRow() = nConsulta(SQL)
                        If rwSUBSIDIO Is Nothing = False Then
                            subsidio = Double.Parse(rwSUBSIDIO(0)("credito").ToString)

                            isr2 = IIf(isr > subsidio, isr - subsidio, 0)
                            subsidio = IIf(subsidio > isr, subsidio - isr, 0)

                            'Calcular imss
                            imss = calculoimss(propuesta * 1.0452, bruto, 1)
                            imssP = calculoimss(propuesta * 1.0452, bruto, 2)
                            RCVP = calculoimss(propuesta * 1.0452, bruto, 3)
                            INFONAVITP = calculoimss(propuesta * 1.0452, bruto, 4)


                        End If
                    End If

                    dtgDatos.Rows(x).Cells(4).Value = Double.Parse(dtgDatos.Rows(x).Cells(3).Value) * 1.0452
                    dtgDatos.Rows(x).Cells(5).Value = Nuddias.Value
                    dtgDatos.Rows(x).Cells(6).Value = bruto
                    dtgDatos.Rows(x).Cells(7).Value = bruto
                    dtgDatos.Rows(x).Cells(8).Value = bruto
                    dtgDatos.Rows(x).Cells(9).Value = subsidio
                    dtgDatos.Rows(x).Cells(10).Value = bruto + subsidio
                    dtgDatos.Rows(x).Cells(11).Value = isr2
                    dtgDatos.Rows(x).Cells(12).Value = imss
                    dtgDatos.Rows(x).Cells(13).Value = imss + isr2
                    dtgDatos.Rows(x).Cells(14).Value = (bruto + subsidio) - (imss + isr2)
                    dtgDatos.Rows(x).Cells(15).Value = imssP
                    dtgDatos.Rows(x).Cells(16).Value = RCVP
                    dtgDatos.Rows(x).Cells(17).Value = INFONAVITP
                    dtgDatos.Rows(x).Cells(18).Value = (Double.Parse(Nudnomina.Value) / 100) * bruto
                    dtgDatos.Rows(x).Cells(19).Value = imssP + RCVP + INFONAVITP + ((Double.Parse(Nudnomina.Value) / 100) * bruto)

                    dtgDatos.Rows(x).Cells(20).Value = (bruto) + (imssP + RCVP + INFONAVITP + ((Double.Parse(Nudnomina.Value) / 100) * bruto))



                    'fila.Item("IMSS_CS") = "0"
                    'fila.Item("RCV_CS") = "0"
                    'fila.Item("INFONAVIT_CS") = "0"
                    'fila.Item("ISN_CS") = "0"
                    'fila.Item("TOTAL_CS") = "0"
                    'fila.Item("COSTO_NOMINA_TOTAL") = "0"
                Next
                pnlProgreso.Visible = False
                MessageBox.Show("Calculos terminados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No hay registros para realizar el calculo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Function calculoimss(sdi As Double, totalp As Double, tipo As Integer) As Double
        Dim SQL As String
        Dim TC25 As Double = Double.Parse(txtsalario.Text) * 25
        Dim TC22 As Double = Double.Parse(txtsalario.Text) * 25
        Dim TC15 As Double = Double.Parse(txtsalario.Text) * 15
        Dim TCF As Double = Double.Parse(txtsalario.Text) * 3
        Dim imss As Double
        Dim tope As Double
        Dim cuotafija As Double
        Dim excedentep As Double
        Dim excedentet As Double
        Dim prestaciondinerop As Double
        Dim prestaciondinerot As Double
        Dim gastosmedicosp As Double
        Dim gastosmedicost As Double
        Dim riesgotrabajo As Double
        Dim invalidezp As Double
        Dim invalidezt As Double
        Dim guarderia As Double
        Dim cuotasimssp As Double
        Dim cuotasimsst As Double
        Dim totalcuotasimss As Double
        Dim retiro As Double
        Dim vejezp As Double
        Dim vejezt As Double
        Dim tope22 As Double
        Dim totalrcvp As Double
        Dim totalrcvt As Double
        Dim infonavitp As Double
        Dim impuestonomina As Double
        Dim totaltotalp As Double
        Dim totaltotalt As Double
        Dim costosocial As Double
        Try
            SQL = "select * from enfermedades where anio=" & Date.Now.Year.ToString("0000")
            Dim rwIMSS As DataRow() = nConsulta(SQL)
            If rwIMSS Is Nothing = False Then
                'tope
                If sdi > TC25 Then
                    tope = TC25
                Else
                    tope = sdi
                End If
                'cuota fija patron
                If sdi > 0 Then
                    cuotafija = Double.Parse(txtsalario.Text) * Double.Parse(Nuddias.Value) * (Double.Parse(rwIMSS(0)("cfpatron").ToString) / 100)
                Else
                    cuotafija = 0
                End If
                'excendente patron
                If tope > TCF Then
                    excedentep = (tope - TCF) * Double.Parse(Nuddias.Value) * (Double.Parse(rwIMSS(0)("excedentep").ToString) / 100)
                Else
                    excedentep = 0
                End If
                'excedente trabajador
                If tope > TCF Then
                    excedentet = (tope - TCF) * Double.Parse(Nuddias.Value) * (Double.Parse(rwIMSS(0)("excedentet").ToString) / 100)
                Else
                    excedentet = 0
                End If

                'PRESTACIONES DE DINERO
                'patron

                If tope > Double.Parse(txtsalario.Text) Then
                    prestaciondinerop = (tope * (Double.Parse(rwIMSS(0)("prestaciondp").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    prestaciondinerop = (tope * ((Double.Parse(rwIMSS(0)("prestaciondp").ToString) / 100) + (Double.Parse(rwIMSS(0)("prestaciondt").ToString) / 100))) * Double.Parse(Nuddias.Value)
                End If
                'trabajador
                If tope > Double.Parse(txtsalario.Text) Then
                    prestaciondinerot = (tope * (Double.Parse(rwIMSS(0)("prestaciondt").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    prestaciondinerot = 0
                End If
                'GASTOS MEDICOS
                'patron
                If tope > Double.Parse(txtsalario.Text) Then
                    gastosmedicosp = (tope * (Double.Parse(rwIMSS(0)("prestacionep").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    gastosmedicosp = (tope * ((Double.Parse(rwIMSS(0)("prestacionep").ToString) / 100) + (Double.Parse(rwIMSS(0)("prestacionet").ToString) / 100))) * Double.Parse(Nuddias.Value)
                End If
                'trabajador
                If tope > Double.Parse(txtsalario.Text) Then
                    gastosmedicost = (tope * (Double.Parse(rwIMSS(0)("prestacionet").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    gastosmedicost = 0
                End If

                'RIESGO DE TRABAJO

                riesgotrabajo = Double.Parse(Nuddias.Value) * tope * 0.0054355

                'TOPE 22
                If sdi > TC22 Then
                    tope22 = TC22
                Else
                    tope22 = sdi
                End If

                'INVALIDEZ Y VIDA
                'patron
                If tope22 > Double.Parse(txtsalario.Text) Then
                    invalidezp = (tope22 * (Double.Parse(rwIMSS(0)("invalidezp").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    invalidezp = (tope22 * ((Double.Parse(rwIMSS(0)("invalidezp").ToString) / 100) + (Double.Parse(rwIMSS(0)("invalidezt").ToString) / 100))) * Double.Parse(Nuddias.Value)
                End If
                'trabajador
                If tope22 > Double.Parse(txtsalario.Text) Then
                    invalidezt = (tope22 * (Double.Parse(rwIMSS(0)("invalidezt").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    invalidezt = 0
                End If

                'GUARDERIAS
                guarderia = tope * (Double.Parse(rwIMSS(0)("guarderiasp").ToString) / 100) * Double.Parse(Nuddias.Value)

                'CUOTAS IMSS
                'patron
                cuotasimssp = cuotafija + excedentep + prestaciondinerop + gastosmedicosp + riesgotrabajo + invalidezp + guarderia

                'trabajador

                cuotasimsst = excedentet + prestaciondinerot + gastosmedicost + invalidezt

                'TOTAL CUOTAS IMSS
                totalcuotasimss = cuotasimssp + cuotasimsst

                'RETIRO
                retiro = tope * Double.Parse(Nuddias.Value) * (Double.Parse(rwIMSS(0)("retirop").ToString) / 100)

                'VEJEZ
                'patron
                If tope22 > Double.Parse(txtsalario.Text) Then
                    vejezp = (tope22 * (Double.Parse(rwIMSS(0)("cesantiap").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    vejezp = (tope22 * ((Double.Parse(rwIMSS(0)("cesantiat").ToString) / 100) + (Double.Parse(rwIMSS(0)("invalidezt").ToString) / 100))) * Double.Parse(Nuddias.Value)
                End If
                'trabajador
                If tope22 > Double.Parse(txtsalario.Text) Then
                    vejezt = (tope22 * (Double.Parse(rwIMSS(0)("cesantiat").ToString) / 100)) * Double.Parse(Nuddias.Value)
                Else
                    vejezt = 0
                End If

                'TOTALRCV PATRON
                totalrcvp = retiro + vejezp

                'TOTALRCV TRABAJADOR

                totalrcvt = vejezt

                'INFONAVIT PATRON

                infonavitp = tope22 * Double.Parse(Nuddias.Value) * (Double.Parse(rwIMSS(0)("infonavitp").ToString) / 100)

                'IMPUESTO SOBRE NOMINA

                impuestonomina = (Double.Parse(Nudnomina.Value) / 100) * totalp

                'TOTAL PATRON
                totaltotalp = cuotasimssp + totalrcvp + infonavitp + impuestonomina

                'TOTAL TRABAJADOR
                totaltotalt = cuotasimsst + totalrcvt

                'COSTO SOCIAL
                costosocial = totaltotalp + totaltotalt
                If tipo = 2 Then
                    totaltotalt = cuotasimssp
                ElseIf tipo = 3 Then
                    totaltotalt = totalrcvp
                ElseIf tipo = 4 Then
                    totaltotalt = infonavitp
                End If
                Return totaltotalt

            End If


        Catch ex As Exception

        End Try

        Return 0
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim propuesta As Double
        Dim bruto As Double
        Dim excendente As Double
        Dim isr As Double
        Dim isr2 As Double
        Dim subsidio As Double
        Dim diferencia As Double
        Dim SDI As Double
        Dim imss As Double

        Dim SQL As String

        Try
            For x As Integer = 0 To dtgDatos.Rows.Count - 1
                propuesta = Double.Parse(dtgDatos.Rows(x).Cells(3).Value)
                bruto = propuesta * Double.Parse(Nuddias.Value)


                bruto = propuesta * Double.Parse(Nuddias.Value)
                'calculos

                'Calculamos isr

                '1.- buscamos datos para el calculo

                Sql = "select * from isr where ((" & bruto & ">=isr.limiteinf and " & bruto & "<=isr.limitesup)"
                Sql &= " or (" & bruto & ">=isr.limiteinf and isr.limitesup=0)) and fkiIdTipoPeriodo2=" & cboperiodo.SelectedValue

                Dim rwISRCALCULO As DataRow() = nConsulta(Sql)
                If rwISRCALCULO Is Nothing = False Then
                    excendente = bruto - Double.Parse(rwISRCALCULO(0)("limiteinf").ToString)
                    isr = (excendente * (Double.Parse(rwISRCALCULO(0)("porcentaje").ToString) / 100)) + Double.Parse(rwISRCALCULO(0)("cuotafija").ToString)

                    '2.- buscamos los datos para subsidio
                    Sql = "select * from subsidio where ((" & bruto & ">=limiteinf and " & bruto & "<=limitesup)"
                    Sql &= " or (" & bruto & ">=limiteinf and limitesup=0)) and fkiIdTipoPeriodo2=" & cboperiodo.SelectedValue

                    Dim rwSUBSIDIO As DataRow() = nConsulta(Sql)
                    If rwSUBSIDIO Is Nothing = False Then
                        subsidio = Double.Parse(rwSUBSIDIO(0)("credito").ToString)

                        isr2 = IIf(isr > subsidio, isr - subsidio, 0)
                        subsidio = IIf(subsidio > isr, subsidio - isr, 0)

                        'Calcular imss
                        imss = calculoimss(propuesta * 1.0452, bruto, 1)





                    End If
                End If

                dtgDatos.Rows(x).Cells(4).Value = Double.Parse(dtgDatos.Rows(x).Cells(3).Value) * 1.0452
                dtgDatos.Rows(x).Cells(5).Value = Nuddias.Value
                dtgDatos.Rows(x).Cells(6).Value = bruto
                dtgDatos.Rows(x).Cells(7).Value = bruto
                dtgDatos.Rows(x).Cells(8).Value = bruto
                dtgDatos.Rows(x).Cells(9).Value = subsidio
                dtgDatos.Rows(x).Cells(10).Value = bruto + subsidio
                dtgDatos.Rows(x).Cells(11).Value = isr2
                dtgDatos.Rows(x).Cells(12).Value = imss
                dtgDatos.Rows(x).Cells(13).Value = imss + isr2
                dtgDatos.Rows(x).Cells(14).Value = (bruto + subsidio) - (imss + isr2)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class