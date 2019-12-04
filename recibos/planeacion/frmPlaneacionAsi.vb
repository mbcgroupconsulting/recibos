Imports ClosedXML.Excel
Imports System.IO
Public Class frmPlaneacionAsi
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
                dsPeriodo.Tables("Tabla").Columns.Add("Dias")
                dsPeriodo.Tables("Tabla").Columns.Add("Total_Asimilados")
                dsPeriodo.Tables("Tabla").Columns.Add("Retencion_ISR")
                dsPeriodo.Tables("Tabla").Columns.Add("Percepcion_Neta")
                dsPeriodo.Tables("Tabla").Columns.Add("Impuesto_Nomina")
                dsPeriodo.Tables("Tabla").Columns.Add("Suma")
                dsPeriodo.Tables("Tabla").Columns.Add("Espacio")
                dsPeriodo.Tables("Tabla").Columns.Add("Asimilados_Neto")
                dsPeriodo.Tables("Tabla").Columns.Add("Costo_Social")
                dsPeriodo.Tables("Tabla").Columns.Add("Comision")
                dsPeriodo.Tables("Tabla").Columns.Add("Subtotal")
                dsPeriodo.Tables("Tabla").Columns.Add("IVA")
                dsPeriodo.Tables("Tabla").Columns.Add("Total")

                For x = 0 To tbRegistros.Rows.Count - 1

                    Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow
                    fila.Item("Id_empleado") = (x + 1).ToString
                    fila.Item("Nombre") = tbRegistros.Rows(x).Item(0).ToString()
                    fila.Item("Sueldo") = tbRegistros.Rows(x).Item(1).ToString()
                    fila.Item("Sueldo Diario") = "0"
                    fila.Item("Dias") = "0"
                    fila.Item("Total_Asimilados") = "0"
                    fila.Item("Retencion_ISR") = "0"
                    fila.Item("Percepcion_Neta") = "0"
                    fila.Item("Impuesto_Nomina") = "0"
                    fila.Item("Suma") = "0"
                    fila.Item("Espacio") = ""
                    fila.Item("Asimilados_Neto") = "0"
                    fila.Item("Costo_Social") = "0"
                    fila.Item("Comision") = "0"
                    fila.Item("Subtotal") = "0"
                    fila.Item("IVA") = "0"
                    fila.Item("Total") = "0"

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
                'Dias
                dtgDatos.Columns(4).Width = 100
                dtgDatos.Columns(4).ReadOnly = True
                dtgDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Total_Asimilados
                dtgDatos.Columns(5).Width = 100
                dtgDatos.Columns(5).ReadOnly = True
                dtgDatos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Retencion_ISR
                dtgDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(6).ReadOnly = True
                dtgDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Percepcion_Neta
                dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(7).ReadOnly = True
                dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Impuesto_Nomina
                dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(8).ReadOnly = True
                dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Suma
                dtgDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(9).ReadOnly = True
                dtgDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Espacio
                dtgDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(10).ReadOnly = True
                dtgDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Asimilados_Neto
                dtgDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(11).ReadOnly = True
                dtgDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Costo_Social
                dtgDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(12).ReadOnly = True
                dtgDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Comision
                dtgDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(13).ReadOnly = True
                dtgDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Subtotal
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(14).ReadOnly = True
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'IVA
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(14).ReadOnly = True
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Total
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(14).ReadOnly = True
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

    Private Sub cmdcalcular_Click(sender As Object, e As EventArgs) Handles cmdcalcular.Click
        Dim propuesta As Double
        Dim bruto As Double
        Dim excendente As Double
        Dim isr As Double
        Dim perpecionneta As Double
        Dim impuestonomina As Double
        Dim comision As Double
        Dim diferencia As Double
        Dim calculado As Double

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

                        isr = fisr(bruto)

                        If rbneto.Checked Then
                            dtgDatos.Rows(x).Cells(3).Value = propuesta
                            calculado = bruto - isr

                        ElseIf rbsubtotal.Checked Then
                            dtgDatos.Rows(x).Cells(3).Value = propuesta

                            dtgDatos.Rows(x).Cells(4).Value = Nuddias.Value
                            dtgDatos.Rows(x).Cells(5).Value = Math.Round(bruto, 2)
                            dtgDatos.Rows(x).Cells(6).Value = Math.Round(isr, 2)
                            perpecionneta = bruto - isr
                            impuestonomina = (bruto) * (Double.Parse(Nudnomina.Value) / 100)

                            dtgDatos.Rows(x).Cells(7).Value = Math.Round(perpecionneta, 2)

                            dtgDatos.Rows(x).Cells(8).Value = Math.Round(impuestonomina, 2)
                            dtgDatos.Rows(x).Cells(9).Value = Math.Round(perpecionneta + impuestonomina, 2)
                            dtgDatos.Rows(x).Cells(10).Value = ""
                            dtgDatos.Rows(x).Cells(11).Value = Math.Round(perpecionneta, 2)
                            dtgDatos.Rows(x).Cells(12).Value = (Math.Round(IIf(chkcosto.Checked, impuestonomina, 0), 2))
                            comision = perpecionneta * (Double.Parse(Nudcomision.Value) / 100)
                            dtgDatos.Rows(x).Cells(13).Value = Math.Round(comision, 2)
                            dtgDatos.Rows(x).Cells(14).Value = Math.Round(perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision, 2)
                            calculado = perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision
                            dtgDatos.Rows(x).Cells(15).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) * 0.16, 2)

                            dtgDatos.Rows(x).Cells(16).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) + ((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, "0")) + comision) * 0.16), 2)
                        Else
                            dtgDatos.Rows(x).Cells(3).Value = propuesta

                            dtgDatos.Rows(x).Cells(4).Value = Nuddias.Value
                            dtgDatos.Rows(x).Cells(5).Value = Math.Round(bruto, 2)
                            dtgDatos.Rows(x).Cells(6).Value = Math.Round(isr, 2)
                            perpecionneta = bruto - isr
                            impuestonomina = (bruto) * (Double.Parse(Nudnomina.Value) / 100)

                            dtgDatos.Rows(x).Cells(7).Value = Math.Round(perpecionneta, 2)

                            dtgDatos.Rows(x).Cells(8).Value = Math.Round(impuestonomina, 2)
                            dtgDatos.Rows(x).Cells(9).Value = Math.Round(perpecionneta + impuestonomina, 2)
                            dtgDatos.Rows(x).Cells(10).Value = ""
                            dtgDatos.Rows(x).Cells(11).Value = Math.Round(perpecionneta, 2)
                            dtgDatos.Rows(x).Cells(12).Value = (Math.Round(IIf(chkcosto.Checked, impuestonomina, 0), 2))
                            comision = perpecionneta * (Double.Parse(Nudcomision.Value) / 100)
                            dtgDatos.Rows(x).Cells(13).Value = Math.Round(comision, 2)
                            dtgDatos.Rows(x).Cells(14).Value = Math.Round(perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision, 2)
                            dtgDatos.Rows(x).Cells(15).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) * 0.16, 2)
                            dtgDatos.Rows(x).Cells(16).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) + ((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, "0")) + comision) * 0.16), 2)
                            calculado = (perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) + ((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, "0")) + comision) * 0.16)

                        End If


                        If Math.Round((calculado), 2) = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(2).Value), 2) Then
                            'el sueldo de la propuesta es correcto
                            dtgDatos.Rows(x).Cells(3).Value = propuesta
                        Else
                            If calculado > Double.Parse(dtgDatos.Rows(x).Cells(2).Value) Then

                                diferencia = (calculado) - Double.Parse(dtgDatos.Rows(x).Cells(2).Value)
                                If diferencia > 1000 Then
                                    propuesta = propuesta - 150
                                ElseIf diferencia > 500 And diferencia < 999.999 Then
                                    propuesta = propuesta - 70
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
                                diferencia = Double.Parse(dtgDatos.Rows(x).Cells(2).Value) - (calculado)
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
                                ElseIf diferencia > 3 And diferencia < 4.499 Then
                                    propuesta = propuesta + 0.1
                                ElseIf diferencia > 3 And diferencia < 3.999 Then
                                    propuesta = propuesta + 0.001
                                ElseIf diferencia > 3 And diferencia < 3.699 Then
                                    propuesta = propuesta + 0.002
                                ElseIf diferencia > 1 And diferencia < 2.599 Then
                                    propuesta = propuesta + 0.003
                                ElseIf diferencia > 1 And diferencia < 1.799 Then
                                    propuesta = propuesta + 0.004
                                ElseIf diferencia > 0.5 And diferencia < 0.999 Then
                                    propuesta = propuesta + 0.006
                                ElseIf diferencia > 0.2 And diferencia < 0.49 Then
                                    propuesta = propuesta + 0.005
                                ElseIf diferencia > 0.1 And diferencia < 0.19 Then
                                    propuesta = propuesta + 0.001
                                Else
                                    propuesta = propuesta + 0.0001

                                End If




                            End If
                        End If



                    Loop While Math.Round((calculado), 2) <> Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(2).Value), 2)


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

                    End If
                    'dtgDatos.Rows(x).Cells(3).Value = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(3).Value), 2).ToString("###,###,##0.00")
                    dtgDatos.Rows(x).Cells(4).Value = Nuddias.Value
                    dtgDatos.Rows(x).Cells(5).Value = Math.Round(bruto, 2)
                    dtgDatos.Rows(x).Cells(6).Value = Math.Round(isr, 2)
                    perpecionneta = bruto - isr
                    impuestonomina = (bruto) * (Double.Parse(Nudnomina.Value) / 100)

                    dtgDatos.Rows(x).Cells(7).Value = Math.Round(perpecionneta, 2)

                    dtgDatos.Rows(x).Cells(8).Value = Math.Round(impuestonomina, 2)
                    dtgDatos.Rows(x).Cells(9).Value = Math.Round(perpecionneta + impuestonomina, 2)
                    dtgDatos.Rows(x).Cells(10).Value = ""
                    dtgDatos.Rows(x).Cells(11).Value = Math.Round(perpecionneta, 2)
                    dtgDatos.Rows(x).Cells(12).Value = (Math.Round(IIf(chkcosto.Checked, impuestonomina, 0), 2))
                    comision = perpecionneta * (Double.Parse(Nudcomision.Value) / 100)
                    dtgDatos.Rows(x).Cells(13).Value = Math.Round(comision, 2)
                    dtgDatos.Rows(x).Cells(14).Value = Math.Round(perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision, 2)
                    dtgDatos.Rows(x).Cells(15).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) * 0.16, 2)
                    dtgDatos.Rows(x).Cells(16).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) + ((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, "0")) + comision) * 0.16), 2)
                Next
                pnlProgreso.Visible = False
                MessageBox.Show("Calculos terminados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No hay registros para realizar el calculo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function fisr(bruto As Double) As Double
        Dim sql As String
        Dim excendente As Double
        Dim isr As Double
        Try
            sql = "select * from isr where ((" & bruto & ">=isr.limiteinf and " & bruto & "<=isr.limitesup)"
            sql &= " or (" & bruto & ">=isr.limiteinf and isr.limitesup=0)) and fkiIdTipoPeriodo2=" & cboperiodo.SelectedValue

            Dim rwISRCALCULO As DataRow() = nConsulta(sql)

            If rwISRCALCULO Is Nothing = False Then
                excendente = bruto - Double.Parse(rwISRCALCULO(0)("limiteinf").ToString)
                isr = (excendente * (Double.Parse(rwISRCALCULO(0)("porcentaje").ToString) / 100)) + Double.Parse(rwISRCALCULO(0)("cuotafija").ToString)

            End If
            Return isr
        Catch ex As Exception
            Return 0
        End Try






    End Function
    Function calculoimss(sdi As Double, totalp As Double) As Double
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
        Dim perpecionneta As Double
        Dim impuestonomina As Double
        Dim comision As Double


        Dim SQL As String

        Try
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

                End If
                'dtgDatos.Rows(x).Cells(3).Value = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(3).Value), 2).ToString("###,###,##0.00")
                dtgDatos.Rows(x).Cells(4).Value = Nuddias.Value
                dtgDatos.Rows(x).Cells(5).Value = Math.Round(bruto, 2)
                dtgDatos.Rows(x).Cells(6).Value = Math.Round(isr, 2)
                perpecionneta = bruto - isr
                impuestonomina = (bruto) * (Double.Parse(Nudnomina.Value) / 100)

                dtgDatos.Rows(x).Cells(7).Value = Math.Round(perpecionneta, 2)

                dtgDatos.Rows(x).Cells(8).Value = Math.Round(impuestonomina, 2)
                dtgDatos.Rows(x).Cells(9).Value = Math.Round(perpecionneta + impuestonomina, 2)
                dtgDatos.Rows(x).Cells(10).Value = ""
                dtgDatos.Rows(x).Cells(11).Value = Math.Round(perpecionneta, 2)
                dtgDatos.Rows(x).Cells(12).Value = (Math.Round(IIf(chkcosto.Checked, impuestonomina, 0), 2))
                comision = perpecionneta * (Double.Parse(Nudcomision.Value) / 100)
                dtgDatos.Rows(x).Cells(13).Value = Math.Round(comision, 2)
                dtgDatos.Rows(x).Cells(14).Value = Math.Round(perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision, 2)
                dtgDatos.Rows(x).Cells(15).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) * 0.16, 2)
                dtgDatos.Rows(x).Cells(16).Value = Math.Round((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, 0)) + comision) + ((perpecionneta + (IIf(chkcosto.Checked, impuestonomina, "0")) + comision) * 0.16), 2)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPlaneacionAsi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Enviar datos a excel
        Dim SQL As String, Alter As Boolean = False

        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim contadorfacturas As Integer


        Alter = True
        Try

            'SQL = "Select iIdFactura,fecha,facturas.numfactura,facturas.importe,facturas.iva,facturas.total,"
            'SQL &= " pagoabono, comentario, comentario2, empresa.nombrefiscal, clientes.nombre "
            'SQL &= " from((Facturas left join pagos on Facturas.iIdFactura=pagos.fkiIdFactura)"
            'SQL &= " inner Join empresa on facturas.fkiIdEmpresa=empresa.iIdEmpresa) "
            'SQL &= " inner Join clientes on facturas.fkiIdCliente= clientes.iIdCliente"
            'SQL &= " where fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' and facturas.iEstatus=1 "
            'SQL &= "  And facturas.cancelada=1  And pagos.iIdPago Is NULL and facturas.tipofactura=0"
            'SQL &= " order by empresa.nombrefiscal, fecha"





            'Dim rwFilas As DataRow() = nConsulta(SQL)

            If dtgDatos.Rows.Count > 0 Then
                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("Asmilados")

                hoja.Column("B").Width = 13
                hoja.Column("C").Width = 30
                hoja.Column("D").Width = 30
                hoja.Column("E").Width = 30
                hoja.Column("F").Width = 13
                hoja.Column("G").Width = 13
                hoja.Column("H").Width = 13
                hoja.Column("I").Width = 13
                hoja.Column("J").Width = 13
                hoja.Column("K").Width = 13
                hoja.Column("L").Width = 13
                hoja.Column("M").Width = 13
                hoja.Column("N").Width = 13
                hoja.Column("O").Width = 13
                hoja.Column("P").Width = 13
                hoja.Column("Q").Width = 35
                hoja.Column("R").Width = 35
                hoja.Column("S").Width = 13
                hoja.Column("T").Width = 40
                hoja.Column("U").Width = 15

                hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                hoja.Cell(3, 2).Value = "Calculo Asimilados"

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja.Range(4, 2, 4, 18).Style.Font.FontSize = 10
                hoja.Range(4, 2, 4, 18).Style.Font.SetBold(True)
                hoja.Range(4, 2, 4, 18).Style.Alignment.WrapText = True
                hoja.Range(4, 2, 4, 18).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(4, 1, 4, 18).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(4, 2, 4, 18).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(4, 2, 4, 18).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                'hoja.Cell(4, 1).Value = "Num"
                hoja.Cell(4, 2).Value = "Consecutivo"
                hoja.Cell(4, 3).Value = "Nombre"
                hoja.Cell(4, 4).Value = "Sueldo"
                hoja.Cell(4, 5).Value = "Sueldo Diario"
                hoja.Cell(4, 6).Value = "Dias"
                hoja.Cell(4, 7).Value = "Total Asimilados"
                hoja.Cell(4, 8).Value = "Retención ISR"
                hoja.Cell(4, 9).Value = "Percepción Neta"
                hoja.Cell(4, 10).Value = "Impuesto Nomina"
                hoja.Cell(4, 11).Value = "Suma"
                hoja.Cell(4, 12).Value = ""
                hoja.Cell(4, 13).Value = "Asimilados Neto"
                hoja.Cell(4, 14).Value = "Costo Social"
                hoja.Cell(4, 15).Value = "Comisión"
                hoja.Cell(4, 16).Value = "Subtotal"
                hoja.Cell(4, 17).Value = "IVA"
                hoja.Cell(4, 18).Value = "Total"


                filaExcel = 5
                contadorfacturas = 0

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    contadorfacturas = contadorfacturas + 1

                    hoja.Cell(filaExcel + x, 2).Value = x + 1
                    hoja.Cell(filaExcel + x, 3).Value = dtgDatos.Rows(x).Cells(1).Value
                    hoja.Cell(filaExcel + x, 4).Value = Double.Parse(dtgDatos.Rows(x).Cells(2).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 5).Value = dtgDatos.Rows(x).Cells(3).Value
                    hoja.Cell(filaExcel + x, 6).Value = dtgDatos.Rows(x).Cells(4).Value
                    hoja.Cell(filaExcel + x, 7).Value = Double.Parse(dtgDatos.Rows(x).Cells(5).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 8).Value = Double.Parse(dtgDatos.Rows(x).Cells(6).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 9).Value = Double.Parse(dtgDatos.Rows(x).Cells(7).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 10).Value = Double.Parse(dtgDatos.Rows(x).Cells(8).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 11).Value = Double.Parse(dtgDatos.Rows(x).Cells(9).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 12).Value = dtgDatos.Rows(x).Cells(10).Value
                    hoja.Cell(filaExcel + x, 13).Value = Double.Parse(dtgDatos.Rows(x).Cells(11).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 14).Value = Double.Parse(dtgDatos.Rows(x).Cells(12).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 15).Value = Double.Parse(dtgDatos.Rows(x).Cells(13).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 16).Value = Double.Parse(dtgDatos.Rows(x).Cells(14).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 17).Value = Double.Parse(dtgDatos.Rows(x).Cells(15).Value).ToString("###,###,##0.00")
                    hoja.Cell(filaExcel + x, 18).Value = Double.Parse(dtgDatos.Rows(x).Cells(16).Value).ToString("###,###,##0.00")
                Next

                hoja.Range(5, 4, 5 + contadorfacturas, 4).Style.NumberFormat.NumberFormatId = 4
                hoja.Range(5, 7, 5 + contadorfacturas, 18).Style.NumberFormat.NumberFormatId = 4


                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Calculo Asimilados"
                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                dialogo.ShowDialog()
                libro.SaveAs(dialogo.FileName)
                'libro.SaveAs("c:\temp\control.xlsx")
                'libro.SaveAs(dialogo.FileName)
                'apExcel.Quit()
                libro = Nothing
            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception

        End Try


    End Sub
End Class