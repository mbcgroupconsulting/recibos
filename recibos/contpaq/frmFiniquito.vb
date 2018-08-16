Imports ClosedXML.Excel
Imports System.IO

Public Class frmFiniquito
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim total As Double
    Dim numpagos As Integer
    Public gIdEmpresa As String
    Public gIdCliente As String
    Public gIdEmpleado As String
    Public gIdPeriodo As String
    Public gIdPrestamo As String
    Dim existe As Boolean = False
    Dim iIdFiniquitoC As String




    Private Sub frmFiniquito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CargarFiniquito()

        
    End Sub

    Private Sub CargarFiniquito()
        Try
            SQL = "select * from finiquitoC inner join EmpleadosC on finiquitoC.fkiIdEmpleadoC= EmpleadosC.iIdEmpleadoC where fkiIdEmpleadoC=" & gIdEmpleado & " and fkiIdPeriodo=" & gIdPeriodo

            Dim rwFiniquitoC As DataRow() = nConsulta(SQL)

            If rwFiniquitoC Is Nothing = False Then
                'Hay un finiquito previo cargamos los datos
                iIdFiniquitoC = rwFiniquitoC(0)("iIdFiniquitoC")

                txtTrabajador.Text = rwFiniquitoC(0)("cNombreLargo")
                txtContratacion.Text = rwFiniquitoC(0)("TipoContratacion")
                dtpIngreso.Value = rwFiniquitoC(0)("FechaAlta")
                dtpBaja.Value = rwFiniquitoC(0)("FechaBaja")
                txtCuotaDiaria.Text = rwFiniquitoC(0)("CuotaDiaria")
                NudAniosCompletos.Value = rwFiniquitoC(0)("AniosCompletos")
                NudDiasVacaciones.Value = rwFiniquitoC(0)("DiasLaboradosVac")
                NudAguinaldoLaborado.Value = rwFiniquitoC(0)("DiasLaboradosAgui")
                NudVacacionesContrato.Value = rwFiniquitoC(0)("DiasVacContrato")
                NudVacacionesLey.Value = rwFiniquitoC(0)("DiasVacLey")
                NudPorPrima.Value = rwFiniquitoC(0)("PorcentajePrima")
                NudDiasAguinaldo.Value = rwFiniquitoC(0)("DiasAguinaldo")
                NudSubsidio.Value = rwFiniquitoC(0)("PorcentajeSubsidio")
                NudDevengados.Value = rwFiniquitoC(0)("DiaPendientes")
                NudDiasVacPendientes.Value = rwFiniquitoC(0)("DiasVacPendientes")
                txtIndemnizacionSugerida.Text = rwFiniquitoC(0)("IndeCliente")
                nudComisionCliente.Value = rwFiniquitoC(0)("ComsionCliente")
                'Buscar periodo

                txtSalario.Text = rwFiniquitoC(0)("SalarioPatrona")

                txtIndeServicioP.Text = rwFiniquitoC(0)("IndeAniosP")
                txtIndeServicioS.Text = rwFiniquitoC(0)("IndeAniosS")
                txtIndeConstitucionalP.Text = rwFiniquitoC(0)("IndeConstitucionalP")
                txtIndeConstitucionalS.Text = rwFiniquitoC(0)("IndeConstitucionalS")
                txtPrimaAntiguedadP.Text = rwFiniquitoC(0)("PrimaAntigueP")
                txtPrimaAntiguedadS.Text = rwFiniquitoC(0)("PrimaAntigueS")


                txtProporAguinaldoP.Text = rwFiniquitoC(0)("ProporAguinaldoP")
                txtProporAguinaldoS.Text = rwFiniquitoC(0)("ProporAguinaldoS")
                txtProporVacacionesP.Text = rwFiniquitoC(0)("ProporVacacionesP")
                txtProporVacacionesS.Text = rwFiniquitoC(0)("ProporVacacionesS")
                txtProporPrimaP.Text = rwFiniquitoC(0)("ProporPrimaP")
                txtProporPrimaS.Text = rwFiniquitoC(0)("ProporPrimaS")
                txtSalarioDevengadoP.Text = rwFiniquitoC(0)("SalarioDevengadoP")
                txtSalarioDevengadoS.Text = rwFiniquitoC(0)("SalarioDevengadoS")
                txtCreditoInfonavitP.Text = rwFiniquitoC(0)("CreditoInfonavitP")
                txtCreditoInfonavitS.Text = rwFiniquitoC(0)("CreditoInfonavitS")
                'txtTotalPatrona.Text = rwFiniquitoC(0)("PrimaAntugeS")
                'txtTotalSindicato.Text = rwFiniquitoC(0)("PrimaAntugeS")
                'txtPartePatrona.Text = rwFiniquitoC(0)("PrimaAntugeS")
                'txtParteSindicato.Text = rwFiniquitoC(0)("PrimaAntugeS")

                calcular()
                lblleyenda.Text = "FINIQUITO CALCULADO Y GUARDADO"
                existe = True
            Else
                'Subir Datos empleados
                SQL = "select * from EmpleadosC where iIdEmpleadoC=" & gIdEmpleado

                Dim rwEmpleado As DataRow() = nConsulta(SQL)

                If rwEmpleado Is Nothing = False Then
                    txtTrabajador.Text = rwEmpleado(0)("cNombreLargo")
                    txtContratacion.Text = "INDETERMINADO"
                    dtpIngreso.Value = rwEmpleado(0)("dFechaAntiguedad")
                    NudAniosCompletos.Value = CalcularEdad(Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString).Day, Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString).Month, Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString).Year)
                    SQL = "select iDiasPeriodo from periodos inner join tipos_periodo on periodos.fkiIdTipoPeriodo = tipos_periodo.iIdTipoPeriodo where iIdPeriodo = " & gIdPeriodo
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    If rwFilas Is Nothing = False Then
                        txtCuotaDiaria.Text = Math.Round(Double.Parse(rwEmpleado(0)("fSueldoOrd")) / Double.Parse(rwFilas(0)("iDiasPeriodo")), 2)
                    End If
                    NudAguinaldoLaborado.Value = DiasAguinaldo(Integer.Parse(gIdEmpleado), gIdEmpresa) 'Llamamos a la función
                    NudDiasVacaciones.Value = DiasVacaciones(Integer.Parse(gIdEmpleado), gIdEmpresa) 'Llamamos a la función
                    SQL = "select * from VacacionesLey where Numanios=" & NudAniosCompletos.Value
                    Dim rwVacacionesLey As DataRow() = nConsulta(SQL)
                    If rwVacacionesLey Is Nothing = False Then
                        NudVacacionesContrato.Value = rwVacacionesLey(0)("Numdias")
                        NudVacacionesLey.Value = rwVacacionesLey(0)("Numdias")
                    Else
                        NudVacacionesContrato.Value = 6
                        NudVacacionesLey.Value = 6
                    End If

                End If

                lblleyenda.Text = ""

                existe = False

            End If

        Catch ex As Exception

        End Try

    End Sub

    Function DiasAguinaldo(idempleado As String, idempresa As String) As Integer

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
                Dim fin As DateTime = Date.Parse("01/01/" & Year(Date.Parse(dtpBaja.Value.ToString)).ToString)
                Dim tiempo As TimeSpan = fin - inicio

                If (tiempo.Days >= 0) Then
                    inicio = Date.Parse("01/01/" & Year(Date.Parse(dtpBaja.Value.ToString)).ToString)
                    fin = Date.Parse(dtpBaja.Value.ToString)
                    tiempo = fin - inicio
                    If (tiempo.Days > 0) Then
                        dias = tiempo.Days

                    End If

                    'dias = 365
                Else
                    inicio = Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString)
                    fin = Date.Parse(dtpBaja.Value.ToString)
                    tiempo = fin - inicio
                    If (tiempo.Days > 0) Then
                        dias = tiempo.Days

                    End If
                End If





            End If



        Catch ex As Exception

        End Try


        Return dias + 1

    End Function

    Function DiasVacaciones(idempleado As String, idempresa As String) As Integer

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


                'Dim AñoActual As Integer = Year(Date.Parse(dtpBaja.Value.ToString)).ToString
                'Dim MesActual As Integer = Month(Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString))
                'Dim DiaActual As Integer = Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString).Day

                Dim inicio As DateTime = Date.Parse(Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString).Day & "/" & Month(Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString)) & "/" & Year(Date.Parse(dtpBaja.Value.ToString)).ToString)
                Dim fin As DateTime = Date.Parse(dtpBaja.Value.ToString)
                Dim tiempo As TimeSpan = fin - inicio

                If (tiempo.Days >= 0) Then
                    'inicio = Date.Parse("01/01/" & Year(Date.Parse(dtpBaja.Value.ToString)).ToString)
                    'fin = Date.Parse(dtpBaja.Value.ToString)
                    'tiempo = fin - inicio
                    'If (tiempo.Days > 0) Then
                    dias = tiempo.Days

                    'End If

                    'dias = 365
                Else
                    inicio = Date.Parse(Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString).Day & "/" & Month(Date.Parse(rwEmpleado(0)("dFechaAntiguedad").ToString)) & "/" & (Year(Date.Parse(dtpBaja.Value.ToString)) - 1).ToString)
                    fin = Date.Parse(dtpBaja.Value.ToString)
                    tiempo = fin - inicio
                    If (tiempo.Days > 0) Then
                        dias = tiempo.Days

                    End If
                End If





            End If



        Catch ex As Exception

        End Try


        Return dias + 1

    End Function

    Private Sub DatosCalculo()

    End Sub

    Private Sub txtIndemnizacionSugerida_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndemnizacionSugerida.KeyPress
        SoloNumero.NumeroDec(e, sender)

    End Sub

    Private Sub txtIndeServicioP_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndeServicioP.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtIndeServicioS_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndeServicioS.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtIndeConstitucionalP_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndeConstitucionalP.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtIndeConstitucionalS_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIndeConstitucionalS.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtPrimaAntiguedadP_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrimaAntiguedadP.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtPrimaAntiguedadS_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrimaAntiguedadS.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub
    Private Function CalcularEdad(ByVal DiaNacimiento As Integer, ByVal MesNacimiento As Integer, ByVal AñoNacimiento As Integer)
        ' SE DEFINEN LAS FECHAS ACTUALES
        Dim AñoActual As Integer = Year(Date.Parse(dtpBaja.Value.ToString))
        Dim MesActual As Integer = Month(Date.Parse(dtpBaja.Value.ToString))
        Dim DiaActual As Integer = Date.Parse(dtpBaja.Value.ToString).Day
        Dim Cumplidos As Boolean = False
        ' SE COMPRUEBA CUANDO FUE EL ULTIMOS CUMPLEAÑOS
        ' FORMULA:
        '   Años cumplidos = (Año del ultimo cumpleaños - Año de nacimiento)
        If (MesNacimiento <= MesActual) Then
            If (DiaNacimiento <= DiaActual) Then
                If (DiaNacimiento = DiaActual And MesNacimiento = MesActual) Then
                    'MsgBox("Feliz Cumpleaños!")
                End If
                ' MsgBox("Ya cumplio")
                Cumplidos = True
            End If
        End If

        If (Cumplidos = False) Then
            AñoActual = (AñoActual - 1)
            'MsgBox("Ultimo cumpleaños: " & AñoActual)
        End If
        ' Se realiza la resta de años para definir los años cumplidos
        Dim EdadAños As Integer = (AñoActual - AñoNacimiento)
        ' DEFINICION DE LOS MESES LUEGO DEL ULTIMO CUMPLEAÑOS
        Dim EdadMes As Integer
        If Not (AñoActual = Now.Year) Then
            EdadMes = (12 - MesNacimiento)
            EdadMes = EdadMes + Now.Month
        Else
            EdadMes = Math.Abs(Now.Month - MesNacimiento)
        End If
        'SACAMOS LA CANTIDAD DE DIAS EXACTOS
        Dim EdadDia As Integer = (DiaActual - DiaNacimiento)

        'RETORNAMOS LOS VALORES EN UNA CADENA STRING
        Return (EdadAños)


    End Function


    Private Sub cmdCalcular_Click(sender As System.Object, e As System.EventArgs) Handles cmdCalcular.Click
        'Aguinaldo
        txtProporAguinaldoS.Text = Math.Round(((Double.Parse(txtCuotaDiaria.Text) * Double.Parse(NudDiasAguinaldo.Value)) / 365) * Double.Parse(NudAguinaldoLaborado.Value), 2)
        txtProporVacacionesS.Text = Math.Round(((Double.Parse(txtCuotaDiaria.Text) * (IIf(NudVacacionesContrato.Value >= NudVacacionesLey.Value, NudVacacionesContrato.Value, NudVacacionesLey.Value))) / 365) * Double.Parse(NudAguinaldoLaborado.Value), 2)
        txtProporPrimaS.Text = Math.Round((((Double.Parse(txtCuotaDiaria.Text) * (IIf(NudVacacionesContrato.Value >= NudVacacionesLey.Value, NudVacacionesContrato.Value, NudVacacionesLey.Value))) / 365) * Double.Parse(NudAguinaldoLaborado.Value)) * (NudPorPrima.Value / 100), 2)
        txtSalarioDevengadoS.Text = Math.Round((Double.Parse(txtCuotaDiaria.Text) * Double.Parse(NudDevengados.Value)) + (Double.Parse(txtCuotaDiaria.Text) * Double.Parse(NudDiasVacPendientes.Value)), 2)


        calcular()

    End Sub

    Private Sub calcular()
        Dim indeserviciop, indeconstitucionalp, primaantiguedadp, proporaguinaldop, proporvacacionesp, proporprimap, salariodevengadop, creditoinfonavitp
        Dim indeservicios, indeconstitucionals, primaantiguedads, proporaguinaldos, proporvacacioness, proporprimas, salariodevengados, creditoinfonavits

        indeserviciop = Double.Parse(IIf(txtIndeServicioP.Text = "", "0", txtIndeServicioP.Text))
        indeconstitucionalp = Double.Parse(IIf(txtIndeConstitucionalP.Text = "", "0", txtIndeConstitucionalP.Text))
        primaantiguedadp = Double.Parse(IIf(txtPrimaAntiguedadP.Text = "", "0", txtPrimaAntiguedadP.Text))
        proporaguinaldop = Double.Parse(IIf(txtProporAguinaldoP.Text = "", "0", txtProporAguinaldoP.Text))
        proporvacacionesp = Double.Parse(IIf(txtProporVacacionesP.Text = "", "0", txtProporVacacionesP.Text))
        proporprimap = Double.Parse(IIf(txtProporPrimaP.Text = "", "0", txtProporPrimaP.Text))
        salariodevengadop = Double.Parse(IIf(txtSalarioDevengadoP.Text = "", "0", txtSalarioDevengadoP.Text))
        creditoinfonavitp = Double.Parse(IIf(txtCreditoInfonavitP.Text = "", "0", txtCreditoInfonavitP.Text))

        indeservicios = Double.Parse(IIf(txtIndeServicioS.Text = "", "0", txtIndeServicioS.Text))
        indeconstitucionals = Double.Parse(IIf(txtIndeConstitucionalS.Text = "", "0", txtIndeConstitucionalS.Text))
        primaantiguedads = Double.Parse(IIf(txtPrimaAntiguedadS.Text = "", "0", txtPrimaAntiguedadS.Text))
        proporaguinaldos = Double.Parse(IIf(txtProporAguinaldoS.Text = "", "0", txtProporAguinaldoS.Text))
        proporvacacioness = Double.Parse(IIf(txtProporVacacionesS.Text = "", "0", txtProporVacacionesS.Text))
        proporprimas = Double.Parse(IIf(txtProporPrimaS.Text = "", "0", txtProporPrimaS.Text))
        salariodevengados = Double.Parse(IIf(txtSalarioDevengadoS.Text = "", "0", txtSalarioDevengadoS.Text))
        creditoinfonavits = Double.Parse(IIf(txtCreditoInfonavitS.Text = "", "0", txtCreditoInfonavitS.Text))


        txtTotalPatrona.Text = Math.Round(indeserviciop + indeconstitucionalp + primaantiguedadp + proporaguinaldop + proporvacacionesp + proporprimap + salariodevengadop + creditoinfonavitp, 2)
        txtTotalSindicato.Text = Math.Round(indeservicios + indeconstitucionals + primaantiguedads + proporaguinaldos + proporvacacioness + proporprimas + salariodevengados + creditoinfonavits, 2)

        txtPartePatrona.Text = txtTotalPatrona.Text
        txtParteSindicato.Text = Math.Round(Double.Parse(txtTotalSindicato.Text) - Double.Parse(txtTotalPatrona.Text), 2)




    End Sub

    Private Sub cmdguardar_Click(sender As System.Object, e As System.EventArgs) Handles cmdguardar.Click
        Dim resultado As Integer = MessageBox.Show("Los datos son correctos, ¿Desea guardar los datos?", "Pregunta", MessageBoxButtons.YesNo)
        If resultado = DialogResult.Yes Then
            If existe Then
                SQL = "EXEC setFiniquitoCActualizar "
                SQL &= iIdFiniquitoC
                SQL &= "," & gIdEmpleado
                SQL &= ",'" & txtContratacion.Text
                SQL &= "','" & Date.Parse(dtpIngreso.Value).ToShortDateString
                SQL &= "','" & Date.Parse(dtpBaja.Value).ToShortDateString
                SQL &= "'," & txtCuotaDiaria.Text
                SQL &= "," & NudAniosCompletos.Value
                SQL &= "," & NudDiasVacaciones.Value
                SQL &= "," & NudAguinaldoLaborado.Value
                SQL &= "," & NudVacacionesContrato.Value
                SQL &= "," & NudVacacionesLey.Value
                SQL &= "," & NudPorPrima.Value
                SQL &= "," & NudDiasAguinaldo.Value
                SQL &= "," & NudSubsidio.Value
                SQL &= "," & NudDevengados.Value
                SQL &= "," & NudDiasVacPendientes.Value
                SQL &= "," & IIf(txtIndemnizacionSugerida.Text = "", "0", txtIndemnizacionSugerida.Text)
                SQL &= "," & nudComisionCliente.Value
                SQL &= "," & gIdPeriodo
                SQL &= "," & IIf(txtSalario.Text = "", "0", txtSalario.Text)


                SQL &= "," & IIf(txtIndeServicioP.Text = "", "0", txtIndeServicioP.Text)
                SQL &= "," & IIf(txtIndeServicioS.Text = "", "0", txtIndeServicioS.Text)
                SQL &= "," & IIf(txtIndeConstitucionalP.Text = "", "0", txtIndeConstitucionalP.Text)
                SQL &= "," & IIf(txtIndeConstitucionalS.Text = "", "0", txtIndeConstitucionalS.Text)
                SQL &= "," & IIf(txtPrimaAntiguedadP.Text = "", "0", txtPrimaAntiguedadP.Text)
                SQL &= "," & IIf(txtPrimaAntiguedadS.Text = "", "0", txtPrimaAntiguedadS.Text)
                SQL &= "," & IIf(txtProporAguinaldoP.Text = "", "0", txtProporAguinaldoP.Text)
                SQL &= "," & IIf(txtProporAguinaldoS.Text = "", "0", txtProporAguinaldoS.Text)
                SQL &= "," & IIf(txtProporVacacionesP.Text = "", "0", txtProporVacacionesP.Text)
                SQL &= "," & IIf(txtProporVacacionesS.Text = "", "0", txtProporVacacionesS.Text)
                SQL &= "," & IIf(txtProporPrimaP.Text = "", "0", txtProporPrimaP.Text)
                SQL &= "," & IIf(txtProporPrimaS.Text = "", "0", txtProporPrimaS.Text)
                SQL &= "," & IIf(txtSalarioDevengadoP.Text = "", "0", txtSalarioDevengadoP.Text)
                SQL &= "," & IIf(txtSalarioDevengadoS.Text = "", "0", txtSalarioDevengadoS.Text)
                SQL &= "," & IIf(txtCreditoInfonavitP.Text = "", "0", txtCreditoInfonavitP.Text)
                SQL &= "," & IIf(txtCreditoInfonavitS.Text = "", "0", txtCreditoInfonavitS.Text)
                SQL &= ",1"
                SQL &= ",1"
            Else
                SQL = "EXEC setFiniquitoCInsertar   0"
                SQL &= "," & gIdEmpleado
                SQL &= ",'" & txtContratacion.Text
                SQL &= "','" & Date.Parse(dtpIngreso.Value).ToShortDateString
                SQL &= "','" & Date.Parse(dtpBaja.Value).ToShortDateString
                SQL &= "'," & txtCuotaDiaria.Text
                SQL &= "," & NudAniosCompletos.Value
                SQL &= "," & NudDiasVacaciones.Value
                SQL &= "," & NudAguinaldoLaborado.Value
                SQL &= "," & NudVacacionesContrato.Value
                SQL &= "," & NudVacacionesLey.Value
                SQL &= "," & NudPorPrima.Value
                SQL &= "," & NudDiasAguinaldo.Value
                SQL &= "," & NudSubsidio.Value
                SQL &= "," & NudDevengados.Value
                SQL &= "," & NudDiasVacPendientes.Value
                SQL &= "," & IIf(txtIndemnizacionSugerida.Text = "", "0", txtIndemnizacionSugerida.Text)
                SQL &= "," & nudComisionCliente.Value
                SQL &= "," & gIdPeriodo
                SQL &= "," & IIf(txtSalario.Text = "", "0", txtSalario.Text)


                SQL &= "," & IIf(txtIndeServicioP.Text = "", "0", txtIndeServicioP.Text)
                SQL &= "," & IIf(txtIndeServicioS.Text = "", "0", txtIndeServicioS.Text)
                SQL &= "," & IIf(txtIndeConstitucionalP.Text = "", "0", txtIndeConstitucionalP.Text)
                SQL &= "," & IIf(txtIndeConstitucionalS.Text = "", "0", txtIndeConstitucionalS.Text)
                SQL &= "," & IIf(txtPrimaAntiguedadP.Text = "", "0", txtPrimaAntiguedadP.Text)
                SQL &= "," & IIf(txtPrimaAntiguedadS.Text = "", "0", txtPrimaAntiguedadS.Text)
                SQL &= "," & IIf(txtProporAguinaldoP.Text = "", "0", txtProporAguinaldoP.Text)
                SQL &= "," & IIf(txtProporAguinaldoS.Text = "", "0", txtProporAguinaldoS.Text)
                SQL &= "," & IIf(txtProporVacacionesP.Text = "", "0", txtProporVacacionesP.Text)
                SQL &= "," & IIf(txtProporVacacionesS.Text = "", "0", txtProporVacacionesS.Text)
                SQL &= "," & IIf(txtProporPrimaP.Text = "", "0", txtProporPrimaP.Text)
                SQL &= "," & IIf(txtProporPrimaS.Text = "", "0", txtProporPrimaS.Text)
                SQL &= "," & IIf(txtSalarioDevengadoP.Text = "", "0", txtSalarioDevengadoP.Text)
                SQL &= "," & IIf(txtSalarioDevengadoS.Text = "", "0", txtSalarioDevengadoS.Text)
                SQL &= "," & IIf(txtCreditoInfonavitP.Text = "", "0", txtCreditoInfonavitP.Text)
                SQL &= "," & IIf(txtCreditoInfonavitS.Text = "", "0", txtCreditoInfonavitS.Text)
                SQL &= ",1"
                SQL &= ",1"

            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If
            lblleyenda.Text = "FINIQUITO CALCULADO Y GUARDADO"
            MessageBox.Show("Datos guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargarFiniquito()


        End If
    End Sub

    Private Sub cmdBorrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdBorrar.Click

        If existe Then
            Dim resultado As Integer = MessageBox.Show("¿Esta seguro de borrar este finiquito?", "Pregunta", MessageBoxButtons.YesNo)

            If resultado = DialogResult.Yes Then
                SQL = " DELETE FROM  FiniquitoC "
                SQL &= "WHERE iIdFiniquitoC=" & iIdFiniquitoC
                If nExecute(SQL) = False Then
                    MessageBox.Show("Hubo un error al eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
        limpiar()
        CargarFiniquito()


    End Sub

    Private Sub limpiar()
        txtIndeServicioP.Text = ""
        txtIndeServicioS.Text = ""
        txtIndeConstitucionalP.Text = ""
        txtIndeConstitucionalS.Text = ""
        txtPrimaAntiguedadP.Text = ""
        txtPrimaAntiguedadS.Text = ""
        txtProporAguinaldoP.Text = ""
        txtProporAguinaldoS.Text = ""
        txtProporVacacionesP.Text = ""
        txtProporVacacionesS.Text = ""
        txtProporPrimaP.Text = ""
        txtProporPrimaS.Text = ""
        txtSalarioDevengadoP.Text = ""
        txtSalarioDevengadoS.Text = ""
        txtCreditoInfonavitP.Text = ""
        txtCreditoInfonavitS.Text = ""
        
        calcular()

    End Sub

    Private Sub cmdcancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancelar.Click
        limpiar()
        CargarFiniquito()

    End Sub

    Private Sub cmdExccel_Click(sender As System.Object, e As System.EventArgs) Handles cmdExccel.Click
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


            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Datos")
            Dim hoja2 As IXLWorksheet = libro.Worksheets.Add("Pagos")
            Dim hoja3 As IXLWorksheet = libro.Worksheets.Add("Resumen")
            'Dim hoja4 As IXLWorksheet = libro.Worksheets.Add("Resumen")
            hoja.Column("A").Width = 3
            hoja.Column("B").Width = 50
            hoja.Column("C").Width = 40

            hoja.Range(3, 2, 3, 3).Style.Font.SetBold(True)
            hoja.Range(3, 2, 3, 3).Style.Alignment.WrapText = True
            hoja.Range(3, 2, 3, 3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja.Range(3, 2, 3, 3).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja.Range(3, 2, 3, 3).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja.Range(3, 2, 3, 3).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja.Range(3, 2, 3, 3).Merge()
            hoja.Range(3, 2, 21, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thick
            hoja.Range(3, 2, 21, 3).Style.Border.InsideBorder = XLBorderStyleValues.Thin

            

            hoja.Cell(3, 2).Value = "DATOS GENERALES"

            hoja.Cell(5, 2).Value = "NOMBRE DEL TRABAJADOR:"
            hoja.Cell(6, 2).Value = "TIPO DE CONTRATACION:"
            hoja.Cell(7, 2).Value = "FECHA DE INGRESO:"
            hoja.Cell(8, 2).Value = "FECHA DE BAJA:"
            hoja.Cell(9, 2).Value = "CUOTA DIARIA:"
            hoja.Cell(10, 2).Value = "TIEMPO LABORADO(AÑOS COMPLETOS):"
            hoja.Cell(11, 2).Value = "DIAS LABORADOS PARA VACACIONES:"
            hoja.Cell(12, 2).Value = "DIAS LABORADOS PARA AGUINALDO:"
            hoja.Cell(13, 2).Value = "DIAS VACACIONES SEGUN CONTRATO:"
            hoja.Cell(14, 2).Value = "VACACIONES DE LEY:"
            hoja.Cell(15, 2).Value = "PORCENTAJE OTORGADO POR PRIMA VACACIONAL:"
            hoja.Cell(16, 2).Value = "DIAS DE AGUINALDO:"
            hoja.Cell(17, 2).Value = "PROPORCION SUBSIDIADO ACREDITABLE:"
            hoja.Cell(18, 2).Value = "DIAS DEVENGADOS PENDIENTES DE PAGO:"
            hoja.Cell(19, 2).Value = "DIAS DE VACACIONES PENDIENTES"
            hoja.Cell(20, 2).Value = "INDEMNIZACION SUGERIDA POR EL CLIENTE:"
            hoja.Cell(21, 2).Value = "COMISION DEL CLIENTE:"

            hoja.Cell(5, 3).Value = txtTrabajador.Text
            hoja.Cell(6, 3).Value = txtContratacion.Text
            hoja.Cell(7, 3).Value = dtpIngreso.Value
            hoja.Cell(8, 3).Value = dtpBaja.Value
            hoja.Cell(9, 3).Value = txtCuotaDiaria.Text
            hoja.Cell(10, 3).Value = NudAniosCompletos.Value
            hoja.Cell(11, 3).Value = NudDiasVacaciones.Value
            hoja.Cell(12, 3).Value = NudAguinaldoLaborado.Value
            hoja.Cell(13, 3).Value = NudVacacionesContrato.Value
            hoja.Cell(14, 3).Value = NudVacacionesLey.Value
            hoja.Cell(15, 3).Value = NudPorPrima.Value
            hoja.Cell(16, 3).Value = NudDiasAguinaldo.Value
            hoja.Cell(17, 3).Value = NudSubsidio.Value
            hoja.Cell(18, 3).Value = NudDevengados.Value
            hoja.Cell(19, 3).Value = NudDiasVacPendientes.Value
            hoja.Cell(20, 3).Value = txtIndemnizacionSugerida.Text
            hoja.Cell(21, 3).Value = nudComisionCliente.Value



            '###HOJA2
            hoja2.Column("A").Width = 3
            hoja2.Column("B").Width = 13
            hoja2.Column("C").Width = 60
            hoja2.Column("D").Width = 15

            hoja2.Range(1, 1, 1, 4).Style.Font.SetBold(True)
            hoja2.Range(1, 1, 1, 4).Style.Alignment.WrapText = True
            'hoja.Range(1, 1, 1, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(1, 1, 1, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja2.Range(1, 1, 1, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(1, 1, 1, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja2.Range(1, 1, 1, 4).Merge()
            hoja2.Cell(1, 1).Value = "PAGOS POR SEPARACION:"


            hoja2.Range(2, 2, 2, 4).Style.Font.SetBold(True)
            hoja2.Range(2, 2, 2, 4).Style.Alignment.WrapText = True
            hoja2.Range(2, 2, 2, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(2, 2, 2, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja2.Range(2, 2, 2, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(2, 2, 2, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")



            hoja2.Range(2, 2, 7, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(2, 2, 7, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin

            hoja2.Range(2, 2, 2, 4).Merge()





            hoja2.Cell(2, 2).Value = "1.-INDEMNIZACION DE 20 DIAS POR CADA AÑO DE SERVICIO"

            hoja2.Cell(3, 3).Value = "Salario base de indemnizaciones (integrado)"

            hoja2.Cell(4, 2).Value = "Por:"
            hoja2.Cell(4, 3).Value = "Días de salario por cada año de servicio"

            hoja2.Cell(5, 2).Value = "Igual:"
            hoja2.Cell(5, 3).Value = "Indemnización por cada año de servicio"

            hoja2.Cell(6, 2).Value = "Por:"
            hoja2.Cell(6, 3).Value = "Años completos de servicio prestados"

            hoja2.Cell(7, 2).Value = "Igual:"
            hoja2.Cell(7, 3).Value = "Monto de indemnización por años de servicios prestados"

            hoja2.Range(9, 2, 9, 4).Style.Font.SetBold(True)
            hoja2.Range(9, 2, 9, 4).Style.Alignment.WrapText = True
            hoja2.Range(9, 2, 9, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(9, 2, 9, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja2.Range(9, 2, 9, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(9, 2, 9, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja2.Range(9, 2, 12, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(9, 2, 12, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin

            hoja2.Range(9, 2, 9, 4).Merge()

            hoja2.Cell(9, 2).Value = "2. INDEMNIZACION CONSTITUCIONAL"

            hoja2.Cell(10, 3).Value = "Salario base de indemnizaciones (integrado)"

            hoja2.Cell(11, 2).Value = "Por:"
            hoja2.Cell(11, 3).Value = "3 meses de salario"

            hoja2.Cell(12, 2).Value = "Igual:"
            hoja2.Cell(12, 3).Value = "Importe de indemnización constitucional"

            hoja2.Range(14, 2, 14, 4).Style.Font.SetBold(True)
            hoja2.Range(14, 2, 14, 4).Style.Alignment.WrapText = True
            hoja2.Range(14, 2, 14, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(14, 2, 14, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja2.Range(14, 2, 14, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(14, 2, 14, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja2.Range(14, 2, 19, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(14, 2, 19, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin

            hoja2.Range(14, 2, 14, 4).Merge()

            hoja2.Cell(14, 2).Value = "3. PRIMA DE ANTIGÜEDAD"

            hoja2.Cell(15, 3).Value = "Tiempo de servicio:   (años completos)"


            hoja2.Cell(16, 3).Value = "Dias laborados  del año de separación"


            hoja2.Cell(17, 3).Value = "Dias de salario por prima de antigüedad por año"


            hoja2.Cell(18, 3).Value = "Total días de salario de prima de antigüedad"


            hoja2.Cell(19, 2).Value = "Por:"
            hoja2.Cell(19, 3).Value = "Salario base"

            hoja2.Cell(19, 2).Value = "Igual:"
            hoja2.Cell(19, 3).Value = "Monto a pagar por prima de antigüedad"

            '##

            hoja2.Range(21, 1, 21, 4).Style.Font.SetBold(True)
            hoja2.Range(21, 1, 21, 4).Style.Alignment.WrapText = True
            'hoja.Range(1, 1, 1, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(21, 1, 21, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja2.Range(21, 1, 21, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(21, 1, 21, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")
            hoja2.Range(21, 1, 21, 4).Merge()
            hoja2.Cell(21, 1).Value = "OTROS PAGOS POR SEPARACION:"


            hoja2.Range(22, 2, 22, 4).Style.Font.SetBold(True)
            hoja2.Range(22, 2, 22, 4).Style.Alignment.WrapText = True
            hoja2.Range(22, 2, 22, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(22, 2, 22, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja2.Range(22, 2, 22, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(22, 2, 22, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja2.Range(22, 2, 25, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(22, 2, 25, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(22, 2, 22, 4).Merge()

            hoja2.Cell(22, 2).Value = "4. SALARIOS DEVENGADOS NO PAGADOS"

            hoja2.Cell(23, 3).Value = "Cuota diaria"

            hoja2.Cell(24, 2).Value = "Por:"
            hoja2.Cell(24, 3).Value = "Días pendientes de pago"

            hoja2.Cell(25, 2).Value = "Igual:"
            hoja2.Cell(25, 3).Value = "Salario pendiente de pago"



            hoja2.Range(27, 2, 27, 4).Style.Font.SetBold(True)
            hoja2.Range(27, 2, 27, 4).Style.Alignment.WrapText = True
            hoja2.Range(27, 2, 27, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(27, 2, 27, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja2.Range(27, 2, 27, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(27, 2, 27, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja2.Range(27, 2, 34, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(27, 2, 34, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(27, 2, 27, 4).Merge()

            hoja2.Cell(27, 2).Value = "5. PARTE PROPORCIONAL DE AGUINALDO"

            hoja2.Cell(28, 3).Value = "Cuota diaria"

            hoja2.Cell(29, 2).Value = "Por:"
            hoja2.Cell(29, 3).Value = "Días de aguinaldo"

            hoja2.Cell(30, 2).Value = "Igual:"
            hoja2.Cell(30, 3).Value = "Importe de aguinaldo anual"

            hoja2.Cell(31, 2).Value = "Entre:"
            hoja2.Cell(31, 3).Value = "Días del año"

            hoja2.Cell(32, 2).Value = "Igual:"
            hoja2.Cell(32, 3).Value = "Proporción diaria de aguinaldo"

            hoja2.Cell(33, 2).Value = "Por:"
            hoja2.Cell(33, 3).Value = "Días laborados del último año"

            hoja2.Cell(34, 2).Value = "Igual:"
            hoja2.Cell(34, 3).Value = "Aguinaldo proporcional"

            hoja2.Range(36, 2, 36, 4).Style.Font.SetBold(True)
            hoja2.Range(36, 2, 36, 4).Style.Alignment.WrapText = True
            hoja2.Range(36, 2, 36, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(36, 2, 36, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja2.Range(36, 2, 36, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(36, 2, 36, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja2.Range(36, 2, 43, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(36, 2, 43, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(36, 2, 36, 4).Merge()

            hoja2.Cell(36, 2).Value = "6. PARTE PROPORCIONAL DE VACACIONES"

            hoja2.Cell(37, 3).Value = "Cuota diaria"

            hoja2.Cell(38, 2).Value = "Por:"
            hoja2.Cell(38, 3).Value = "Días de vacaciones a que tiene derecho"

            hoja2.Cell(39, 2).Value = "Igual:"
            hoja2.Cell(39, 3).Value = "Importe total de vacaciones"

            hoja2.Cell(40, 2).Value = "Entre:"
            hoja2.Cell(40, 3).Value = "Días del año"

            hoja2.Cell(41, 2).Value = "Igual:"
            hoja2.Cell(41, 3).Value = "Proporción diaria de vacaciones"

            hoja2.Cell(42, 2).Value = "Por:"
            hoja2.Cell(42, 3).Value = "Días laborados del último año"

            hoja2.Cell(43, 2).Value = "Igual:"
            hoja2.Cell(43, 3).Value = "Vacaciones proporcionales"

            hoja2.Range(45, 2, 45, 4).Style.Font.SetBold(True)
            hoja2.Range(45, 2, 45, 4).Style.Alignment.WrapText = True
            hoja2.Range(45, 2, 45, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja2.Range(45, 2, 45, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja2.Range(45, 2, 45, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja2.Range(45, 2, 45, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            hoja2.Range(45, 2, 48, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(45, 2, 48, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja2.Range(45, 2, 45, 4).Merge()

            hoja2.Cell(45, 2).Value = "6. PARTE PROPORCIONAL DE PRIMA DE VACACIONES"

            hoja2.Cell(46, 3).Value = "Vacaciones proporcionales"

            hoja2.Cell(47, 2).Value = "Por:"
            hoja2.Cell(47, 3).Value = "Porcentaje de prima vacacional"

            hoja2.Cell(48, 2).Value = "Igual:"
            hoja2.Cell(48, 3).Value = "Prima vacacional proporcional"




            '###HOJA3

            hoja3.Column("A").Width = 3
            hoja3.Column("B").Width = 60
            hoja3.Column("C").Width = 15
            hoja3.Column("D").Width = 15

            hoja3.Range(2, 2, 3, 4).Style.Font.SetBold(True)
            hoja3.Range(2, 2, 3, 4).Style.Alignment.WrapText = True
            hoja3.Range(2, 2, 3, 4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja3.Range(2, 2, 3, 4).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            hoja3.Range(2, 2, 3, 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja3.Range(2, 2, 3, 4).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")
            hoja3.Range(2, 2, 3, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja3.Range(2, 2, 3, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja3.Range(2, 2, 2, 4).Merge()

            
            hoja3.Cell(2, 2).Value = "OMAR PEREZ PEREZ" 'nombre
            hoja3.Cell(3, 2).Value = "RESUMEN DE PAGOS POR SEPARACION"
            hoja3.Cell(3, 3).Value = "PATRONA"
            hoja3.Cell(3, 4).Value = "REAL"



            hoja3.Range(4, 2, 12, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja3.Range(4, 2, 12, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja3.Cell(4, 2).Value = "INDEMNIZACION POR AÑOS DE SERVICIO"
            hoja3.Cell(5, 2).Value = "INDEMNIZACION CONSTITUCIONAL"
            hoja3.Cell(6, 2).Value = "PRIMA DE ANTIGÜEDAD"
            hoja3.Cell(7, 2).Value = "PROPORCION DE AGUINALDO"
            hoja3.Cell(8, 2).Value = "PROPORCION DE VACACIONES"
            hoja3.Cell(9, 2).Value = "PROPORCION DE PRIMA VACACIONAL"
            hoja3.Cell(10, 2).Value = "SALARIOS DEVENGADOS "
            hoja3.Cell(11, 2).Value = "CREDITO INFONAVIT"
            hoja3.Cell(12, 2).Value = "TOTAL"

            hoja3.Range(4, 3, 1000, 4).Style.NumberFormat.NumberFormatId = 4

            hoja3.Cell(4, 3).Value = txtIndeServicioP.Text
            hoja3.Cell(5, 3).Value = txtIndeConstitucionalP.Text
            hoja3.Cell(6, 3).Value = txtPrimaAntiguedadP.Text
            hoja3.Cell(7, 3).Value = txtProporAguinaldoP.Text
            hoja3.Cell(8, 3).Value = txtProporVacacionesP.Text
            hoja3.Cell(9, 3).Value = txtProporPrimaP.Text
            hoja3.Cell(10, 3).Value = txtSalarioDevengadoP.Text
            hoja3.Cell(11, 3).Value = txtCreditoInfonavitP.Text
            hoja3.Cell(12, 3).FormulaA1 = "=SUM(C4:C11)"

            'hoja.Cell(filaExcel + dtgDatos.Rows.Count, 5).FormulaA1 = "=SUM(E" & filaExcel & ":E" & filaExcel + dtgDatos.Rows.Count - 1 & ")"


            hoja3.Cell(4, 4).Value = txtIndeServicioS.Text
            hoja3.Cell(5, 4).Value = txtIndeConstitucionalS.Text
            hoja3.Cell(6, 4).Value = txtPrimaAntiguedadS.Text
            hoja3.Cell(7, 4).Value = txtProporAguinaldoS.Text
            hoja3.Cell(8, 4).Value = txtProporVacacionesS.Text
            hoja3.Cell(9, 4).Value = txtProporPrimaS.Text
            hoja3.Cell(10, 4).Value = txtSalarioDevengadoS.Text
            hoja3.Cell(11, 4).Value = txtCreditoInfonavitS.Text
            hoja3.Cell(12, 4).FormulaA1 = "=SUM(D4:D11)"




            hoja3.Range(15, 2, 19, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja3.Range(15, 2, 19, 3).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja3.Range(15, 2, 19, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
            hoja3.Cell(15, 2).Value = "comision"
            hoja3.Cell(16, 2).Value = "cuota obrera imss"
            hoja3.Cell(17, 2).Value = "importe"
            hoja3.Cell(18, 2).Value = "iva"
            hoja3.Cell(19, 2).Value = "total"



            hoja3.Range(21, 2, 26, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            hoja3.Range(21, 2, 26, 3).Style.Border.InsideBorder = XLBorderStyleValues.Thin
            hoja3.Range(21, 2, 26, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
            hoja3.Cell(21, 2).Value = "beneficio social sindical"
            hoja3.Cell(22, 2).Value = "beneficio social sindical-credito infonavit"
            hoja3.Cell(23, 2).Value = "comision"
            hoja3.Cell(24, 2).Value = "importe"
            hoja3.Cell(25, 2).Value = "iva"
            hoja3.Cell(26, 2).Value = "total"


            'Dim rwFilas As DataRow() = nConsulta(SQL)
            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Finiquito"
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            libro.SaveAs(dialogo.FileName)
                'libro.SaveAs("c:\temp\control.xlsx")
                'libro.SaveAs(dialogo.FileName)
                'apExcel.Quit()
            libro = Nothing
            MessageBox.Show("Archivo generado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            

        Catch ex As Exception

        End Try


    End Sub
End Class