Imports ClosedXML.Excel

Public Class frmAguinaldo
    Public gIdPeriodo As String
    Public gIdEmpresa As String
    Public gIdTipoPeriodo As String

    Dim SQL As String
    Private Sub frmAguinaldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Datos Periodo
        SQL = "select * from periodos where iIdPeriodo=" & gIdPeriodo
        Dim rwPeriodo As DataRow() = nConsulta(SQL)
        If rwPeriodo Is Nothing = False Then
            lblperiodo.Text &= " " & Date.Parse(rwPeriodo(0)("dFechaInicio").ToString).ToShortDateString & " al " & Date.Parse(rwPeriodo(0)("dFechaFin").ToString).ToShortDateString
        End If

        'Año

        txtanio.Text = Date.Now.Year

        SQL = "select * from tipos_periodo where fkiIdEmpresa = " & gIdEmpresa
        nCargaCBO(cboperiodo, SQL, "cNombrePeriodo", "iIdTipoPeriodo")

    End Sub

    Private Sub txtanio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtanio.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub


    Private Sub cmdcalcular_Click(sender As Object, e As EventArgs) Handles cmdcalcular.Click

        SQL = "select iIdEmpleadoC,NumCuenta, (cApellidoP + ' ' + cApellidoM + ' ' + cNombre) as nombre, fkiIdEmpresa,fSueldoOrd,fCosto from empleadosC"
        SQL &= " where empleadosC.iEstatus=1 and empleadosC.fkiIdClienteInter=-1"
        SQL &= " and empleadosC.fkiIdEmpresa =" & gIdEmpresa
        SQL &= " order by nombre"

        dtgDatos.DataSource = Nothing


        dtgDatos.DefaultCellStyle.Font = New Font("Calibri", 8)
        dtgDatos.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 9)
        'Dim chk As New DataGridViewCheckBoxColumn()
        'dtgDatos.Columns.Add(chk)
        'chk.HeaderText = ""
        'chk.Name = "chk"

        Dim rwDatosSindicato As DataRow() = nConsulta(SQL)
        If rwDatosSindicato Is Nothing = False Then
            'Generar los dias que le tocan al cliente
            'por la fecha de antiguedad

            Dim dsPeriodo As New DataSet
            dsPeriodo.Tables.Add("Tabla")
            dsPeriodo.Tables("Tabla").Columns.Add("Consecutivo")
            dsPeriodo.Tables("Tabla").Columns.Add("Id_empleado")
            dsPeriodo.Tables("Tabla").Columns.Add("Nombre")
            dsPeriodo.Tables("Tabla").Columns.Add("Días_Prestación")
            dsPeriodo.Tables("Tabla").Columns.Add("Días_Trabajados")
            dsPeriodo.Tables("Tabla").Columns.Add("Días_Aguinaldo")
            dsPeriodo.Tables("Tabla").Columns.Add("Aguinaldo")
            dsPeriodo.Tables("Tabla").Columns.Add("TipoPeriodo")
            'dsPeriodo.Tables("Tabla").Columns.Add("Días_Trabajados")

            For x As Integer = 0 To rwDatosSindicato.Length - 1

                Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow

                fila.Item("Consecutivo") = x + 1
                fila.Item("Id_empleado") = rwDatosSindicato(x)("iIdEmpleadoC")
                fila.Item("nombre") = rwDatosSindicato(x)("nombre")

                fila.Item("Días_Prestación") = nuddias.Value
                fila.Item("Días_Trabajados") = DiasEmpleado(rwDatosSindicato(x)("iIdEmpleadoC"), gIdEmpresa) 'Llamamos a la función
                fila.Item("Días_Aguinaldo") = Math.Round(Double.Parse(fila.Item("Días_Trabajados")) * Integer.Parse(nuddias.Value) / Diasanio(txtanio.Text), 7)

                fila.Item("Aguinaldo") = ""

                'CalculoAguinaldo(rwDatosSindicato(x)("iIdEmpleadoC"), gIdEmpresa)
                fila.Item("TipoPeriodo") = ""
                'fila.Item("Días_Trabajados") = ""

                dsPeriodo.Tables("Tabla").Rows.Add(fila)



            Next





            dtgDatos.DataSource = ""

            dtgDatos.DataSource = dsPeriodo.Tables("Tabla")
            'consecutivo
            dtgDatos.Columns(0).Width = 60
            dtgDatos.Columns(0).ReadOnly = True
            dtgDatos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'idempleado
            dtgDatos.Columns(1).Width = 60
            dtgDatos.Columns(1).ReadOnly = True
            dtgDatos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'nombre
            dtgDatos.Columns(2).Width = 350
            dtgDatos.Columns(2).ReadOnly = True

            'Dias Prestación
            dtgDatos.Columns(3).Width = 150
            dtgDatos.Columns(3).ReadOnly = True
            dtgDatos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Dias trabajados
            dtgDatos.Columns(4).Width = 150
            dtgDatos.Columns(4).ReadOnly = True
            dtgDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Dias aguinaldo
            dtgDatos.Columns(5).Width = 150
            dtgDatos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Monto aguinaldo
            dtgDatos.Columns(6).Width = 150
            dtgDatos.Columns(6).ReadOnly = True
            dtgDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'Tipo periodo
            dtgDatos.Columns(7).Width = 150
            dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dtgDatos.Columns(7).ReadOnly = True
            'infonavit 
            'dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dtgDatos.Columns(8).ReadOnly = True


        End If







    End Sub

    Function DiasEmpleado(idempleado As String, idempresa As String) As Integer

        Dim Sql As String
        Dim dias As Integer

        Try
            'Agregar el banco y el tipo de cuenta ya sea a terceros o interbancaria
            'Buscamos el banco y verificarmos el tipo de cuenta a tercero o interbancaria

            Sql = "select *"
            Sql &= " from empleadosC"
            Sql &= " where fkiIdEmpresa=" & idempresa & " and iIdempleadoC=" & idempleado

            Dim rwEmpleado As DataRow() = nConsulta(Sql)


            If rwEmpleado Is Nothing = False Then



                Dim inicio As DateTime = Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString)
                Dim fin As DateTime = Date.Parse("01/01/" & txtanio.Text)
                Dim tiempo As TimeSpan = fin - inicio

                If (tiempo.Days >= 0) Then
                    inicio = Date.Parse("01/01/" & txtanio.Text)
                    fin = Date.Parse("31/12/" & txtanio.Text)
                    tiempo = fin - inicio
                    If (tiempo.Days > 0) Then
                        dias = tiempo.Days

                    End If

                    'dias = 365
                Else
                    inicio = Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString)
                    fin = Date.Parse("31/12/" & txtanio.Text)
                    tiempo = fin - inicio
                    If (tiempo.Days > 0) Then
                        dias = tiempo.Days

                    End If
                End If





            End If



        Catch ex As Exception

        End Try
        If (txtanio.Text Mod 4) = 0 And chk365.Checked And dias = 365 Then
            dias = dias - 1

        End If

        Return dias + 1

    End Function

    Function Diasanio(anio As String) As Integer

        'Agregar el banco y el tipo de cuenta ya sea a terceros o interbancaria
        'Buscamos el banco y verificarmos el tipo de cuenta a tercero o interbancaria

        Dim dias As Integer
        If chk365.Checked Then
            dias = 365
        Else
            If (txtanio.Text Mod 4) = 0 Then
                dias = 366
            Else
                dias = 365
            End If

        End If

        

        Return dias


    End Function


    Function Diasperiodo(idtipoperiodo As String, idempresa As String) As Integer

        'Agregar el banco y el tipo de cuenta ya sea a terceros o interbancaria
        'Buscamos el banco y verificarmos el tipo de cuenta a tercero o interbancaria
        Dim dias As Integer
        SQL = "select * from tipos_periodo where fkiIdEmpresa = " & idempresa & " And iIdTipoPeriodo=" & idtipoperiodo
        Dim rwFilas As DataRow() = nConsulta(SQL)

        If rwFilas Is Nothing = False Then
            dias = rwFilas(0)("iDiasPeriodo")
        End If

        Return dias


    End Function


    Function CalculoAguinaldo(idempleado As String, idempresa As String) As Double

        Dim Sql As String


        Dim sueldodiario As Double
        Dim dias As Integer
        Dim diasanio As Integer
        Dim diasperiodo As Integer
        Dim Aguinaldo As Double


        Try
            'Agregar el banco y el tipo de cuenta ya sea a terceros o interbancaria
            'Buscamos el banco y verificarmos el tipo de cuenta a tercero o interbancaria





            Sql = "select *"
            Sql &= " from empleadosC"
            Sql &= " where fkiIdEmpresa=" & gIdEmpresa & " and iIdempleadoC=" & idempleado

            Dim rwEmpleado As DataRow() = nConsulta(Sql)


            If rwEmpleado Is Nothing = False Then



                Dim inicio As DateTime = Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString)
                Dim fin As DateTime = Date.Parse("01/01/" & txtanio.Text)
                Dim tiempo As TimeSpan = fin - inicio

                If (tiempo.Days >= 0) Then
                    inicio = Date.Parse("01/01/" & txtanio.Text)
                    fin = Date.Parse("31/12/" & txtanio.Text)
                    tiempo = fin - inicio
                    If (tiempo.Days > 0) Then
                        dias = tiempo.Days + 1

                    End If

                    'dias = 365
                Else
                    inicio = Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString)
                    fin = Date.Parse("31/12/" & txtanio.Text)
                    tiempo = fin - inicio
                    If (tiempo.Days > 0) Then
                        dias = tiempo.Days + 1

                    End If
                End If

                If (txtanio.Text Mod 4) = 0 Then
                    diasanio = 366
                Else
                    diasanio = 365
                End If


                Sql = "select * from tipos_periodo where fkiIdEmpresa = " & gIdEmpresa & " And iIdTipoPeriodo=" & gIdTipoPeriodo
                Dim rwFilas As DataRow() = nConsulta(Sql)

                If rwFilas Is Nothing = False Then
                    diasperiodo = rwFilas(0)("iDiasPeriodo")
                End If


                'verificar el periodo para saber si queda entre el rango de fecha

                sueldodiario = Double.Parse(rwEmpleado(0)("fsueldoOrd")) / diasperiodo

                Aguinaldo = 15 / diasanio * dias * sueldodiario






            End If


            Return Math.Round(Aguinaldo, 2)
        Catch ex As Exception

        End Try


        Return Math.Round(Aguinaldo, 2)


    End Function

    Private Sub cmdExcel_Click(sender As Object, e As EventArgs) Handles cmdExcel.Click
        'Enviar datos a excel
        Dim SQL As String, Alter As Boolean = False

        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim contadorfacturas As Integer


        Alter = True
        Try


            If dtgDatos.Rows.Count > 0 Then
                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("Aguinaldo")

                hoja.Column("B").Width = 13
                hoja.Column("C").Width = 30
                hoja.Column("D").Width = 30
                hoja.Column("E").Width = 30
                hoja.Column("F").Width = 13


                hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                hoja.Cell(3, 2).Value = "Aguinaldo Total"

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja.Range(4, 2, 4, 6).Style.Font.FontSize = 10
                hoja.Range(4, 2, 4, 6).Style.Font.SetBold(True)
                hoja.Range(4, 2, 4, 6).Style.Alignment.WrapText = True
                hoja.Range(4, 2, 4, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(4, 2, 4, 6).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(4, 2, 4, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(4, 2, 4, 6).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                'hoja.Cell(4, 1).Value = "Num"
                hoja.Cell(4, 2).Value = "Consecutivo"
                hoja.Cell(4, 3).Value = "Nombre"
                hoja.Cell(4, 4).Value = "Dias Aguinaldo"
                hoja.Cell(4, 5).Value = "Dias Trabajados"
                hoja.Cell(4, 6).Value = "Monto Aguinaldo"


                filaExcel = 5
                contadorfacturas = 1

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    'Consecutivo
                    hoja.Cell(filaExcel + x, 2).Value = dtgDatos.Rows(x).Cells(0).Value
                    'Nombre
                    hoja.Cell(filaExcel + x, 3).Value = dtgDatos.Rows(x).Cells(2).Value
                    'Días de prestación
                    hoja.Cell(filaExcel + x, 4).Value = dtgDatos.Rows(x).Cells(3).Value
                    'Días Trabajados
                    hoja.Cell(filaExcel + x, 5).Value = dtgDatos.Rows(x).Cells(4).Value
                    'Días de Aguinaldo
                    hoja.Cell(filaExcel + x, 5).Value = dtgDatos.Rows(x).Cells(5).Value
                    'Aguinaldo
                    hoja.Cell(filaExcel + x, 6).Value = dtgDatos.Rows(x).Cells(6).Value



                Next




                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Resumen Aguinaldo"
                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                dialogo.ShowDialog()
                libro.SaveAs(dialogo.FileName)
                'libro.SaveAs("c:\temp\control.xlsx")
                'libro.SaveAs(dialogo.FileName)
                'apExcel.Quit()
                libro = Nothing

                MessageBox.Show("Archivo generado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdMonto_Click(sender As Object, e As EventArgs) Handles cmdMonto.Click
        For x As Integer = 0 To dtgDatos.Rows.Count - 1
            dtgDatos.Rows(x).Cells(6).Value = MontoAguinaldo(dtgDatos.Rows(x).Cells(1).Value, gIdEmpresa, dtgDatos.Rows(x).Cells(5).Value)
        Next

    End Sub

    Function MontoAguinaldo(idempleado As String, idempresa As String, dias As Double) As Double

        Dim Sql As String


        Dim sueldodiario As Double

        Dim diasperiodo As Integer
        Dim Aguinaldo As Double


        Try
            'Agregar el banco y el tipo de cuenta ya sea a terceros o interbancaria
            'Buscamos el banco y verificarmos el tipo de cuenta a tercero o interbancaria





            Sql = "select *"
            Sql &= " from empleadosC"
            Sql &= " where fkiIdEmpresa=" & gIdEmpresa & " and iIdempleadoC=" & idempleado

            Dim rwEmpleado As DataRow() = nConsulta(Sql)


            If rwEmpleado Is Nothing = False Then



                Sql = "select * from tipos_periodo where fkiIdEmpresa = " & gIdEmpresa & " And iIdTipoPeriodo=" & cboperiodo.SelectedValue
                Dim rwFilas As DataRow() = nConsulta(Sql)

                If rwFilas Is Nothing = False Then
                    diasperiodo = rwFilas(0)("iDiasPeriodo")
                End If


                'verificar el periodo para saber si queda entre el rango de fecha

                sueldodiario = Double.Parse(rwEmpleado(0)("fsueldoOrd")) / diasperiodo

                Aguinaldo = dias * sueldodiario






            End If


            Return Math.Round(Aguinaldo, 2)
        Catch ex As Exception

        End Try


        Return Math.Round(Aguinaldo, 2)


    End Function

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Try
            Dim Respuesta As Boolean
            Dim sql As String
            Respuesta = True

            sql = "select * from AguinaldoC where fkiIdEmpresaC=" & gIdEmpresa
            sql &= " AND fkiIdPeriodo=" & gIdPeriodo


            Dim rwDatosAguinaldo As DataRow() = nConsulta(sql)

            If rwDatosAguinaldo Is Nothing = False Then
                Dim resultado As Integer = MessageBox.Show("Existen datos de aguinaldo guardados,¿Desea sobreescribirlos?", "Pregunta", MessageBoxButtons.YesNo)
                If resultado = DialogResult.Yes Then
                    'Borramos y Guardamos
                    sql = "Delete from AguinaldoC where fkiIdEmpresaC=" & gIdEmpresa
                    sql &= " AND fkiIdPeriodo=" & gIdPeriodo

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If
                Else
                    Respuesta = False

                End If
            End If


            If Respuesta Then
                'Guardamos
                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    sql = "EXEC setAguinaldoCInsertar 0"
                    'Empresa
                    sql &= "," & gIdEmpresa
                    'Periodo
                    sql &= "," & gIdPeriodo
                    'Empleado
                    sql &= "," & dtgDatos.Rows(x).Cells(1).Value
                    'Dias
                    sql &= "," & dtgDatos.Rows(x).Cells(5).Value
                    'Cantidad
                    sql &= "," & dtgDatos.Rows(x).Cells(6).Value





                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If


                Next

                MessageBox.Show("Datos guardados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception

        End Try

    End Sub
End Class