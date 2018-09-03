﻿Imports ClosedXML.Excel
Imports System.IO

Public Class frmcontpaqnominas2
    Private m_currentControl As Control = Nothing
    Public gIdEmpresa As String
    Public gIdTipoPeriodo As String
    Public gNombrePeriodo As String
    Dim Ruta As String
    Dim nombre As String
    Dim cargado As Boolean = False
    Dim diasperiodo As Integer
    Dim gIdEmpresaAsignada As String
    Dim gIdClienteAsignada As String
    Dim gdFechaFin As String
    Dim valorsubsidio As Integer
    Dim calculosubsidio As Integer


    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub frmcontpaqnominas2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sql As String
            cargarperiodos()
            cargarbancosasociados()

            BuscarEmpresaAsignada()
            BuscarClienteAsignado()



            Me.dtgDatos.ContextMenuStrip = Me.cmenu

            sql = "select * from empresac where iidEmpresac = " & gIdEmpresa
            Dim rwEmpresaC As DataRow() = nConsulta(sql)
            If rwEmpresaC Is Nothing = False Then
                Ruta = rwEmpresaC(0)("ruta")
                nombre = rwEmpresaC(0)("nombre")
            End If

            sql = "select * from tipos_periodo where fkiIdEmpresa = " & gIdEmpresa & " And iIdTipoPeriodo=" & gIdTipoPeriodo
            Dim rwFilas As DataRow() = nConsulta(sql)

            If rwFilas Is Nothing = False Then
                diasperiodo = rwFilas(0)("iDiasPeriodo")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BuscarEmpresaAsignada()
        Try
            Dim sql As String = "select * from IntEmpresaEmpresaContpaq inner join empresa on fkiIdEmpresa=iIdEmpresa where fkIdEmpresaC=" & gIdEmpresa
            Dim rwEmpresa As DataRow() = nConsulta(sql)
            If rwEmpresa Is Nothing = False Then
                lblEmpresa.Text = "Empresa Asignada: " & rwEmpresa(0)("nombre")
                gIdEmpresaAsignada = rwEmpresa(0)("fkiIdEmpresa").ToString
            Else
                lblEmpresa.Text = "No existe empresa asignada, favor de realizar la asignación"
                gIdEmpresaAsignada = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BuscarClienteAsignado()
        Try
            Dim sql As String = "select * from IntClienteEmpresaContpaq inner join clientes on fkIdCliente= iIdCliente where fkIdEmpresaC=" & gIdEmpresa
            Dim rwCliente As DataRow() = nConsulta(sql)
            If rwCliente Is Nothing = False Then
                lblCliente.Text = "Cliente Asignado: " & rwCliente(0)("nombre") & " - Tipo porcentaje: " & IIf(rwCliente(0)("iTipoPor") = "1", "Sueldo Ordinario", "Sueldo Neto + Sindicato") & " - Porcentaje Neto: " & rwCliente(0)("porcentaje") & "% - Porcentaje sindicato: " & rwCliente(0)("porsindicato") & "%"
                gIdClienteAsignada = rwCliente(0)("fkIdCliente").ToString
                valorsubsidio = rwCliente(0)("TipoSubsidio").ToString
                calculosubsidio = rwCliente(0)("CalculoSubsidio").ToString
            Else
                lblCliente.Text = "No existe cliente asignado, favor de realizar la asignación"
                gIdClienteAsignada = "0"
                valorsubsidio = 0
                calculosubsidio = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        
    End Sub

    Private Sub cargarbancosasociados()
        Dim sql As String
        Try
            sql = "select * from bancos inner join ( select distinct(fkiidBanco) from DatosBanco where fkiIdEmpresa=" & gIdEmpresa & ") bancos2 on bancos.iIdBanco=bancos2.fkiidBanco order by cBanco"
            nCargaCBO(cbobancos, sql, "cBanco", "iIdBanco")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarperiodos()
        'Verificar si se tienen permisos
        Dim sql As String
        Try
            sql = "Select (Convert(varchar, dFechaInicio,103) + '-' + Convert(varchar, dFechaFin,103)) as dFechaInicio,iIdPeriodo,dFechaFin "
            sql &= "from periodos where fkiIdTipoPeriodo=" & gIdTipoPeriodo & " and fkiIdEmpresa=" & gIdEmpresa & " and iEjercicio=" & Date.Now.Year
            sql &= " order by iEjercicio,iNumeroPeriodo"
            nCargaCBO(cboperiodo, sql, "dFechainicio", "iIdPeriodo")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsbDatos_Click(sender As Object, e As EventArgs) Handles tsbDatos.Click
        Dim sql As String
        Dim sql2 As String
        Dim iBan As Integer

        Try
            If Ruta <> "" And Ruta <> "ctCSyAP" Then
                'importamos los tipos de periodo

                ConectarContpaq(Ruta)

                sql = "select numeroconcepto,tipoconcepto,descripcion from nom10004"


                Dim rwConceptosC As DataRow() = nConsultaContpaq(sql)
                If rwConceptosC Is Nothing = False Then

                    sql = "Select * from concepto_pago "



                    Dim rwConceptos As DataRow() = nConsulta(sql)

                    If rwConceptos Is Nothing = False Then

                        For x As Integer = 0 To rwConceptosC.Length - 1
                            iBan = 0
                            For y As Integer = 0 To rwConceptos.Length - 1
                                If (rwConceptosC(x)("descripcion").ToString() = rwConceptos(y)("cDescripcion").ToString) Then
                                    iBan = 1
                                    y = rwConceptos.Length
                                End If
                            Next
                            If iBan = 0 Then

                                sql = "EXEC setconcepto_pagoInsertar 0"
                                sql &= "," & rwConceptosC(x)("numeroconcepto") & ",'" & rwConceptosC(x)("tipoconcepto")
                                sql &= "','" & rwConceptosC(x)("descripcion")
                                sql &= "',1," & gIdEmpresa & ",1"
                                If nExecute(sql) = False Then
                                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    'pnlProgreso.Visible = False
                                    Exit Sub

                                End If
                            End If
                        Next

                    Else
                        For x As Integer = 0 To rwConceptosC.Length - 1


                            sql = "EXEC setconcepto_pagoInsertar 0"
                            sql &= "," & rwConceptosC(x)("numeroconcepto") & ",'" & rwConceptosC(x)("tipoconcepto")
                            sql &= "','" & rwConceptosC(x)("descripcion")
                            sql &= "',1," & gIdEmpresa & ",1"

                            If nExecute(sql) = False Then
                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub


                            End If


                        Next

                    End If




                    sql = "select * from periodos where fkiIdEmpresa=" & gIdEmpresa & " and iIdPeriodo=" & cboperiodo.SelectedValue

                    Dim rwFechasPeriodo As DataRow() = nConsulta(sql)
                    If rwFechasPeriodo Is Nothing = False Then

                        sql = "select nom10008.idperiodo,idempleado,nom10004.idconcepto,nom10004.descripcion as descri,importetotal,nom10008.timestamp as fecha"
                        sql &= " from ((nom10023 inner join"
                        sql &= " nom10002 on nom10023.idtipoperiodo=nom10002.idtipoperiodo) inner join"
                        sql &= " nom10008 on nom10002.idperiodo=nom10008.idperiodo) inner join"
                        sql &= " nom10004 on nom10008.idconcepto= nom10004.idconcepto "
                        sql &= " where nom10023.nombretipoperiodo ='" & gNombrePeriodo
                        sql &= "' and CONVERT(nvarchar(10),nom10002.fechainicio,103)='" & rwFechasPeriodo(0)("dFechaInicio")
                        sql &= "' and CONVERT(nvarchar(10),nom10002.fechafin,103)='" & rwFechasPeriodo(0)("dFechaFin") & "' "
                        sql &= "union "
                        sql &= " select nom10007.idperiodo,idempleado,nom10004.idconcepto,nom10004.descripcion as descri,importetotal,nom10007.timestamp as fecha "
                        sql &= " from ((nom10023 inner join "
                        sql &= " nom10002 on nom10023.idtipoperiodo=nom10002.idtipoperiodo) inner join "
                        sql &= " nom10007 on nom10002.idperiodo=nom10007.idperiodo) inner join "
                        sql &= " nom10004 on nom10007.idconcepto= nom10004.idconcepto "
                        sql &= "where nom10023.nombretipoperiodo ='" & gNombrePeriodo
                        sql &= "' and CONVERT(nvarchar(10),nom10002.fechainicio,103)='" & rwFechasPeriodo(0)("dFechaInicio")
                        sql &= "' and CONVERT(nvarchar(10),nom10002.fechafin,103)='" & rwFechasPeriodo(0)("dFechaFin") & "' "

                        Dim rwMovimientosC As DataRow() = nConsultaContpaq(sql)
                        If rwMovimientosC Is Nothing = False Then
                            'Borrar movimientos
                            sql = "delete From movimientos"
                            sql &= " Where movimientos.fkiIdPeriodo = ("
                            sql &= " Select periodos.iIdPeriodo From tipos_periodo inner Join periodos On "
                            sql &= " tipos_periodo.iIdTipoPeriodo = periodos.fkiIdTipoPeriodo"
                            sql &= " Where tipos_periodo.cNombrePeriodo ='" & gNombrePeriodo & "'"
                            sql &= " And tipos_periodo.fkiIdEmpresa=" & gIdEmpresa
                            sql &= " And CONVERT(nvarchar(10),periodos.dFechaInicio,103)='" & rwFechasPeriodo(0)("dFechaInicio") & "'"
                            sql &= " And CONVERT(nvarchar(10),periodos.dFechaFin,103)='" & rwFechasPeriodo(0)("dFechaFin") & "') "
                            sql &= " And movimientos.fkiIdEmpresa=" & gIdEmpresa

                            If nExecute(sql) = False Then
                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub
                            End If

                            'Insertamos los datos nuevamente
                            For x As Integer = 0 To rwMovimientosC.Length - 1
                                sql = "select nombre,apellidopaterno,apellidomaterno,codigoempleado from nom10001 where idempleado=" & rwMovimientosC(x)("idempleado")
                                Dim rwEmpleadoConpaq As DataRow() = nConsultaContpaq(sql)
                                sql = "select iIdEmpleadoC from empleadosC where"
                                sql &= " cCodigoEmpleado ='" & rwEmpleadoConpaq(0)("codigoempleado") & "' AND cNombre='" & rwEmpleadoConpaq(0)("nombre") & "' AND"
                                sql &= " cApellidoP ='" & rwEmpleadoConpaq(0)("apellidopaterno") & "' AND cApellidoM='" & rwEmpleadoConpaq(0)("apellidomaterno") & "' AND fkiIdEmpresa=" & gIdEmpresa

                                Dim rwEmpleado As DataRow() = nConsulta(sql)
                                If rwEmpleado Is Nothing = False Then

                                    sql = "EXEC setmovimientosInsertar 0"
                                    sql &= "," & cboperiodo.SelectedValue & "," & rwEmpleado(0)("iIdEmpleadoC")

                                    sql2 = "select * from concepto_pago where cDescripcion ='" & rwMovimientosC(x)("descri") & "' and iOrigen=1"
                                    Dim rwConcepto As DataRow() = nConsulta(sql2)
                                    If rwConcepto Is Nothing = False Then
                                        sql &= "," & rwConcepto(0)("iIdConceptoPago")
                                    End If


                                    sql &= "," & rwMovimientosC(x)("importetotal")

                                    sql &= "," & gIdEmpresa & ",1"
                                    sql &= ",'" & Date.Parse(rwMovimientosC(x)("fecha").ToString).ToShortDateString & "'"

                                    If nExecute(sql) = False Then

                                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        'pnlProgreso.Visible = False

                                        Exit Sub

                                    End If

                                Else
                                    MessageBox.Show("Los empleados de esta empresa no estan actualizados, realiza la importación ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                End If


                            Next



                        Else
                            MessageBox.Show("No existen movimientos en este periodo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    End If





                Else
                    MessageBox.Show("La empresa en el programa de conpaq no tiene conceptos de pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                MessageBox.Show("Los datos han sido importados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DesconectarContpaq()
                'cargarperiodos()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsbPeriodos_Click(sender As Object, e As EventArgs) Handles tsbPeriodos.Click
        Dim sql As String
        Dim iBan As Integer

        Try
            If Ruta <> "" And Ruta <> "ctCSyAP" Then
                'importamos los tipos de periodo

                ConectarContpaq(Ruta)

                sql = "Select idperiodo,nom10002.idtipoperiodo,numeroperiodo,nom10002.ejercicio,mes,nom10002.diasdepago,fechainicio,fechafin"
                sql &= " from nom10002 inner join nom10023 On nom10002.idtipoperiodo = nom10023.idtipoperiodo"
                sql &= " where nom10023.nombretipoperiodo='" & gNombrePeriodo & "' order by ejercicio,numeroperiodo"

                Dim rwTiposPeriodoC As DataRow() = nConsultaContpaq(sql)
                If rwTiposPeriodoC Is Nothing = False Then

                    sql = "Select * from periodos where fkiIdTipoPeriodo=" & gIdTipoPeriodo & " and  fkiIdEmpresa=" & gIdEmpresa


                    Dim rwTiposPeriodo As DataRow() = nConsulta(sql)

                    If rwTiposPeriodo Is Nothing = False Then

                        For x As Integer = 0 To rwTiposPeriodoC.Length - 1
                            iBan = 0
                            For y As Integer = 0 To rwTiposPeriodo.Length - 1
                                If (rwTiposPeriodoC(x)("numeroperiodo").ToString() = rwTiposPeriodo(y)("iNumeroPeriodo").ToString) And (rwTiposPeriodoC(x)("ejercicio").ToString() = rwTiposPeriodo(y)("iEjercicio").ToString) Then
                                    iBan = 1
                                    y = rwTiposPeriodo.Length
                                End If
                            Next
                            If iBan = 0 Then

                                sql = "EXEC setperiodosInsertar 0," & gIdTipoPeriodo
                                sql &= "," & rwTiposPeriodoC(x)("numeroperiodo") & "," & rwTiposPeriodoC(x)("ejercicio")
                                sql &= "," & rwTiposPeriodoC(x)("mes") & "," & rwTiposPeriodoC(x)("diasdepago")
                                sql &= ",'" & Date.Parse(rwTiposPeriodoC(x)("fechainicio").ToString()).ToShortDateString
                                sql &= "','" & Date.Parse(rwTiposPeriodoC(x)("fechafin").ToString()).ToShortDateString
                                sql &= "'," & gIdEmpresa & ",1"
                                If nExecute(sql) = False Then
                                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    'pnlProgreso.Visible = False
                                    Exit Sub

                                End If
                            End If
                        Next

                    Else
                        For x As Integer = 0 To rwTiposPeriodoC.Length - 1


                            sql = "EXEC setperiodosInsertar 0," & gIdTipoPeriodo
                            sql &= "," & rwTiposPeriodoC(x)("numeroperiodo") & "," & rwTiposPeriodoC(x)("ejercicio")
                            sql &= "," & rwTiposPeriodoC(x)("mes") & "," & rwTiposPeriodoC(x)("diasdepago")
                            sql &= ",'" & Date.Parse(rwTiposPeriodoC(x)("fechainicio").ToString()).ToShortDateString
                            sql &= "','" & Date.Parse(rwTiposPeriodoC(x)("fechafin").ToString()).ToShortDateString
                            sql &= "'," & gIdEmpresa & ",1"

                            If nExecute(sql) = False Then
                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub


                            End If


                        Next

                    End If
                End If

                MessageBox.Show("Los periodos han sido importados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DesconectarContpaq()
                cargarperiodos()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub tsbpuestos_Click(sender As Object, e As EventArgs) Handles tsbpuestos.Click
        Dim sql As String
        Dim iBan As Integer

        Try
            If Ruta <> "" And Ruta <> "ctCSyAP" Then
                'importamos los tipos de periodo

                ConectarContpaq(Ruta)

                sql = "select * from nom10006"


                Dim rwPuestosC As DataRow() = nConsultaContpaq(sql)
                If rwPuestosC Is Nothing = False Then

                    sql = "Select * from puestos where fkiIdEmpresa=" & gIdEmpresa


                    Dim rwPuestos As DataRow() = nConsulta(sql)

                    If rwPuestos Is Nothing = False Then

                        For x As Integer = 0 To rwPuestosC.Length - 1
                            iBan = 0
                            For y As Integer = 0 To rwPuestos.Length - 1
                                If (rwPuestosC(x)("descripcion").ToString() = rwPuestos(y)("cDescripcion").ToString) Then
                                    iBan = 1
                                    y = rwPuestos.Length
                                End If
                            Next
                            If iBan = 0 Then

                                sql = "EXEC setPuestosInsertar 0"
                                sql &= ",'" & rwPuestosC(x)("descripcion") & "','" & rwPuestosC(x)("descripcion")
                                sql &= "'," & gIdEmpresa & ",1"
                                If nExecute(sql) = False Then
                                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    'pnlProgreso.Visible = False
                                    Exit Sub

                                End If
                            End If
                        Next

                    Else
                        For x As Integer = 0 To rwPuestosC.Length - 1


                            sql = "EXEC setPuestosInsertar 0"
                            sql &= ",'" & rwPuestosC(x)("descripcion") & "','" & rwPuestosC(x)("descripcion")
                            sql &= "'," & gIdEmpresa & ",1"

                            If nExecute(sql) = False Then
                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub


                            End If


                        Next

                    End If
                End If

                MessageBox.Show("Los puestos han sido importados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DesconectarContpaq()
                'cargarperiodos()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsbdeptos_Click(sender As Object, e As EventArgs) Handles tsbdeptos.Click
        Dim sql As String
        Dim iBan As Integer

        Try
            If Ruta <> "" And Ruta <> "ctCSyAP" Then
                'importamos los tipos de periodo

                ConectarContpaq(Ruta)

                sql = "select * from nom10003"


                Dim rwDeptosC As DataRow() = nConsultaContpaq(sql)
                If rwDeptosC Is Nothing = False Then

                    sql = "Select * from departamentos where fkiIdEmpresa=" & gIdEmpresa


                    Dim rwDeptos As DataRow() = nConsulta(sql)

                    If rwDeptos Is Nothing = False Then

                        For x As Integer = 0 To rwDeptosC.Length - 1
                            iBan = 0
                            For y As Integer = 0 To rwDeptos.Length - 1
                                If (rwDeptosC(x)("descripcion").ToString() = rwDeptos(y)("cDescripcion").ToString) Then
                                    iBan = 1
                                    y = rwDeptos.Length
                                End If
                            Next
                            If iBan = 0 Then

                                sql = "EXEC setdepartamentosInsertar 0"
                                sql &= ",'" & rwDeptosC(x)("descripcion") & "','" & rwDeptosC(x)("descripcion")
                                sql &= "'," & gIdEmpresa & ",1"
                                If nExecute(sql) = False Then
                                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    'pnlProgreso.Visible = False
                                    Exit Sub

                                End If
                            End If
                        Next

                    Else
                        For x As Integer = 0 To rwDeptosC.Length - 1


                            sql = "EXEC setdepartamentosInsertar 0"
                            sql &= ",'" & rwDeptosC(x)("descripcion") & "','" & rwDeptosC(x)("descripcion")
                            sql &= "'," & gIdEmpresa & ",1"

                            If nExecute(sql) = False Then
                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub


                            End If


                        Next

                    End If
                End If

                MessageBox.Show("Los departamentos han sido importados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DesconectarContpaq()
                'cargarperiodos()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsbEmpleados_Click(sender As Object, e As EventArgs) Handles tsbEmpleados.Click
        Dim sql As String
        Dim sql2 As String
        Dim iBan As Integer
        Dim nacimiento As String
        Try
            If Ruta <> "" And Ruta <> "ctCSyAP" Then
                'importamos los tipos de periodo

                ConectarContpaq(Ruta)

                sql = "select nom10001.*,nom10003.descripcion as departamento, nom10006.descripcion as puesto from nom10001"
                sql &= " inner Join nom10003 on nom10001.iddepartamento= nom10003.iddepartamento"
                sql &= " inner Join nom10006 On nom10001.idpuesto = nom10006.idpuesto"


                Dim rwEmpleadosC As DataRow() = nConsultaContpaq(sql)
                If rwEmpleadosC Is Nothing = False Then

                    sql = "Select * from empleadosC where fkiIdEmpresa=" & gIdEmpresa


                    Dim rwEmpleados As DataRow() = nConsulta(sql)

                    If rwEmpleados Is Nothing = False Then

                        For x As Integer = 0 To rwEmpleadosC.Length - 1
                            nacimiento = ""
                            iBan = 0
                            For y As Integer = 0 To rwEmpleados.Length - 1
                                If (rwEmpleadosC(x)("codigoempleado").ToString() = rwEmpleados(y)("cCodigoEmpleado").ToString) Then

                                    If rwEmpleadosC(x)("estadoempleado").ToString() = "B" Then
                                        sql = "update empleadosC set fkiIdClienteInter = 1,fSueldoBase=" & rwEmpleadosC(x)("sueldodiario") & ",fSueldoIntegrado=" & rwEmpleadosC(x)("sueldointegrado")
                                        sql &= " where iIdEmpleadoC=" & rwEmpleados(y)("iIdEmpleadoC").ToString

                                        If nExecute(sql) = False Then
                                            MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            'pnlProgreso.Visible = False
                                            Exit Sub

                                        End If
                                    Else
                                        sql = "update empleadosC set fSueldoBase=" & rwEmpleadosC(x)("sueldodiario") & ",fSueldoIntegrado=" & rwEmpleadosC(x)("sueldointegrado")
                                        sql &= " where iIdEmpleadoC=" & rwEmpleados(y)("iIdEmpleadoC").ToString

                                        If nExecute(sql) = False Then
                                            MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            'pnlProgreso.Visible = False
                                            Exit Sub

                                        End If

                                    End If


                                    iBan = 1
                                    y = rwEmpleados.Length
                                End If
                            Next
                            If iBan = 0 Then

                                sql = "EXEC setempleadosCInsertar 0"
                                sql &= ",'" & rwEmpleadosC(x)("codigoempleado") & "'"
                                sql &= ",'" & rwEmpleadosC(x)("nombre")
                                sql &= "','" & rwEmpleadosC(x)("apellidopaterno")
                                sql &= "','" & rwEmpleadosC(x)("apellidomaterno")
                                sql &= "','" & rwEmpleadosC(x)("nombrelargo")

                                nacimiento = Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).Year.ToString.Substring(2, 2)
                                nacimiento &= Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).Month.ToString("00")
                                nacimiento &= Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).Day.ToString("00")

                                sql &= "','" & rwEmpleadosC(x)("rfc") & nacimiento & rwEmpleadosC(x)("homoclave")
                                sql &= "','" & rwEmpleadosC(x)("curpi") & nacimiento & rwEmpleadosC(x)("curpf")

                                sql &= "','" & rwEmpleadosC(x)("numerosegurosocial")
                                sql &= "','" & rwEmpleadosC(x)("direccion")
                                sql &= "','" & rwEmpleadosC(x)("poblacion")
                                'Buscar estado
                                sql2 = "Select * from cat_estados where cEstado='" & rwEmpleadosC(x)("estado") & "'"


                                Dim rwEstados As DataRow() = nConsulta(sql2)

                                If rwEstados Is Nothing = False Then
                                    sql &= "'," & rwEstados(0)("iIdEstado")
                                Else
                                    sql &= "',20"
                                End If

                                sql &= ",'" & rwEmpleadosC(x)("codigopostal")
                                sql &= "'," & IIf(rwEmpleadosC(x)("sexo") = "F", "0", "1")
                                sql &= ",'" & Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).ToShortDateString
                                'fecha de captura
                                sql &= "','" & Date.Now.ToShortDateString

                                'Buscar Puesto

                                sql2 = "Select * from puestos where cNombre='" & rwEmpleadosC(x)("puesto") & "' and fkiIdEmpresa=" & gIdEmpresa


                                Dim rwPuesto As DataRow() = nConsulta(sql2)

                                If rwPuesto Is Nothing = False Then
                                    sql &= "','" & rwPuesto(0)("iIdPuesto")
                                Else
                                    sql &= "','-1"
                                End If
                                'Funciones del puesto

                                sql &= "',''"

                                sql &= "," & rwEmpleadosC(x)("sueldodiario")
                                sql &= "," & rwEmpleadosC(x)("sueldointegrado")
                                sql &= ",'" & rwEmpleadosC(x)("lugarnacimiento")
                                'nacionalidad
                                sql &= "',''"
                                'lugarcelebracion
                                sql &= ",''"
                                'lugarcelebracion2
                                sql &= ",''"
                                'duracion
                                sql &= ",''"
                                'observaciones
                                sql &= ",''"
                                'id empresa
                                sql &= "," & gIdEmpresa

                                sql &= ",0.00"
                                'Costo Social
                                sql &= ",0.00"
                                sql &= ",-1"
                                sql &= ",1"
                                sql &= ",1"
                                sql &= ",''"
                                sql &= ",1"
                                sql &= ",''"
                                sql &= ",''"
                                'estado
                                sql &= ",20"
                                sql &= ",''"
                                sql &= ",'" & Date.Parse(rwEmpleadosC(x)("fechaalta").ToString()).ToShortDateString
                                sql &= "','" & Date.Parse(rwEmpleadosC(x)("fechaalta").ToString()).ToShortDateString
                                sql &= "','" & Date.Parse(rwEmpleadosC(x)("fechaalta").ToString()).ToShortDateString
                                sql &= "',1"
                                sql &= ",''"
                                'integrar
                                sql &= ",''"
                                sql &= ",1"
                                sql &= ",''"
                                'tipofactor
                                sql &= ",''"
                                sql &= ",0.00"
                                sql &= ",''"
                                sql &= ",''"
                                sql &= ",''"
                                sql &= ",''"
                                'descanso
                                sql &= ",''"



                                sql &= "," & IIf(rwEmpleadosC(x)("estadoempleado").ToString() = "B", "1", "-1")

                                'Buscar puesto
                                If rwPuesto Is Nothing = False Then
                                    sql &= "," & rwPuesto(0)("iIdPuesto")
                                Else
                                    sql &= ",-1"
                                End If

                                'Buscar Depto

                                sql2 = "Select * from departamentos where cNombre='" & rwEmpleadosC(x)("departamento") & "' and fkiIdEmpresa=" & gIdEmpresa


                                Dim rwDepto As DataRow() = nConsulta(sql2)

                                If rwDepto Is Nothing = False Then
                                    sql &= "," & rwDepto(0)("iIdDepartamento")
                                Else
                                    sql &= ",-1"
                                End If

                                'estado civil

                                sql &= ",1"
                                'Banco2
                                sql &= ",1"
                                'cuenta2
                                sql &= ",''"

                                'clabe2
                                sql &= ",''"
                                'SindicatoExtra
                                sql &= ",0"


                                If nExecute(sql) = False Then
                                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    'pnlProgreso.Visible = False
                                    Exit Sub

                                End If
                            End If
                        Next

                    Else
                        For x As Integer = 0 To rwEmpleadosC.Length - 1
                            nacimiento = ""

                            sql = "EXEC setempleadosCInsertar 0"
                            sql &= ",'" & rwEmpleadosC(x)("codigoempleado") & "'"
                            sql &= ",'" & rwEmpleadosC(x)("nombre")
                            sql &= "','" & rwEmpleadosC(x)("apellidopaterno")
                            sql &= "','" & rwEmpleadosC(x)("apellidomaterno")
                            sql &= "','" & rwEmpleadosC(x)("nombrelargo")

                            nacimiento = Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).Year.ToString.Substring(2, 2)
                            nacimiento &= Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).Month.ToString("00")
                            nacimiento &= Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).Day.ToString("00")

                            sql &= "','" & rwEmpleadosC(x)("rfc") & nacimiento & rwEmpleadosC(x)("homoclave")
                            sql &= "','" & rwEmpleadosC(x)("curpi") & nacimiento & rwEmpleadosC(x)("curpf")

                            sql &= "','" & rwEmpleadosC(x)("numerosegurosocial")
                            sql &= "','" & rwEmpleadosC(x)("direccion")
                            sql &= "','" & rwEmpleadosC(x)("poblacion")
                            'Buscar estado
                            sql2 = "Select * from cat_estados where cEstado='" & rwEmpleadosC(x)("estado") & "'"


                            Dim rwEstados As DataRow() = nConsulta(sql2)

                            If rwEstados Is Nothing = False Then
                                sql &= "'," & rwEstados(0)("iIdEstado")
                            Else
                                sql &= "',20"
                            End If

                            sql &= ",'" & rwEmpleadosC(x)("codigopostal")
                            sql &= "'," & IIf(rwEmpleadosC(x)("sexo") = "F", "0", "1")
                            sql &= ",'" & Date.Parse(rwEmpleadosC(x)("fechanacimiento").ToString()).ToShortDateString
                            'fecha de captura
                            sql &= "','" & Date.Now.ToShortDateString

                            'Buscar Puesto

                            sql2 = "Select * from puestos where cNombre='" & rwEmpleadosC(x)("puesto") & "' and fkiIdEmpresa=" & gIdEmpresa


                            Dim rwPuesto As DataRow() = nConsulta(sql2)

                            If rwPuesto Is Nothing = False Then
                                sql &= "','" & rwPuesto(0)("iIdPuesto")
                            Else
                                sql &= "','-1"
                            End If
                            'Funciones del puesto

                            sql &= "',''"

                            sql &= "," & rwEmpleadosC(x)("sueldodiario")
                            sql &= "," & rwEmpleadosC(x)("sueldointegrado")
                            sql &= ",'" & rwEmpleadosC(x)("lugarnacimiento")
                            'nacionalidad
                            sql &= "',''"
                            'lugarcelebracion
                            sql &= ",''"
                            'lugarcelebracion2
                            sql &= ",''"
                            'duracion
                            sql &= ",''"
                            'observaciones
                            sql &= ",''"
                            'id empresa
                            sql &= "," & gIdEmpresa

                            sql &= ",0.00"
                            sql &= ",0.00"
                            sql &= ",-1"
                            sql &= ",1"
                            sql &= ",1"
                            sql &= ",''"
                            sql &= ",1"
                            sql &= ",''"
                            sql &= ",''"
                            'estado
                            sql &= ",20"
                            sql &= ",''"
                            sql &= ",'" & Date.Parse(rwEmpleadosC(x)("fechaalta").ToString()).ToShortDateString
                            sql &= "','" & Date.Parse(rwEmpleadosC(x)("fechaalta").ToString()).ToShortDateString
                            sql &= "','" & Date.Parse(rwEmpleadosC(x)("fechaalta").ToString()).ToShortDateString
                            sql &= "',1"
                            sql &= ",''"
                            'integrar
                            sql &= ",''"
                            sql &= ",1"
                            sql &= ",''"
                            'tipofactor
                            sql &= ",''"
                            sql &= ",0.00"
                            sql &= ",''"
                            sql &= ",''"
                            sql &= ",''"
                            sql &= ",''"
                            'descanso
                            sql &= ",''"



                            sql &= "," & IIf(rwEmpleadosC(x)("estadoempleado").ToString() = "B", "1", "-1")

                            'Buscar puesto
                            If rwPuesto Is Nothing = False Then
                                sql &= "," & rwPuesto(0)("iIdPuesto")
                            Else
                                sql &= ",-1"
                            End If

                            'Buscar Depto

                            sql2 = "Select * from departamentos where cNombre='" & rwEmpleadosC(x)("departamento") & "' and fkiIdEmpresa=" & gIdEmpresa


                            Dim rwDepto As DataRow() = nConsulta(sql2)

                            If rwDepto Is Nothing = False Then
                                sql &= "," & rwDepto(0)("iIdDepartamento")
                            Else
                                sql &= ",-1"
                            End If
                            'estado civil
                            sql &= ",1"

                            'Banco2
                            sql &= ",1"
                            'cuenta2
                            sql &= ",''"
                            'clabe2
                            sql &= ",''"
                            'SindicatoExtra
                            sql &= ",0"
                            If nExecute(sql) = False Then
                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub


                            End If


                        Next

                    End If
                End If

                MessageBox.Show("Los empleados han sido importados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DesconectarContpaq()
                'cargarperiodos()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdverdatos_Click(sender As Object, e As EventArgs) Handles cmdverdatos.Click
        Try
            'If cargado Then



            '    dtgDatos.DataSource = Nothing
            '    llenargrid()
            'Else
            '    cargado = True
            '    llenargrid()
            'End If

            dtgDatos.Columns.Clear()
            llenargrid()



        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenargrid()

        Try
            Dim sql As String
            Dim sql2 As String
            Dim infonavit As Double
            Dim prestamo As Double
            Dim incidencia As Double
            Dim bCalcular As Boolean
            Dim PrimaSA As Double
            Dim AguinaldoSA As Double
            Dim ImssSA As Double
            Dim SubsidioSA As Double
            Dim fCostoSA As Double
            Dim AguinaldoSin As Double
            Dim cadenabanco As String

            dtgDatos.DataSource = Nothing


            dtgDatos.DefaultCellStyle.Font = New Font("Calibri", 8)
            dtgDatos.ColumnHeadersDefaultCellStyle.Font = New Font("Calibri", 9)
            Dim chk As New DataGridViewCheckBoxColumn()
            dtgDatos.Columns.Add(chk)
            chk.HeaderText = ""
            chk.Name = "chk"
            'dtgDatos.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

            'dtgDatos.Columns("chk").SortMode = DataGridViewColumnSortMode.NotSortable

            'dtgDatos.Columns.Add("idempleado", "idempleado")
            'dtgDatos.Columns(0).Width = 30
            'dtgDatos.Columns(0).ReadOnly = True
            ''dtgDatos.Columns(0).DataPropertyName("idempleado")

            'dtgDatos.Columns.Add("departamento", "Departamento")
            'dtgDatos.Columns(1).Width = 100
            'dtgDatos.Columns(1).ReadOnly = True
            'dtgDatos.Columns.Add("nombre", "Trabajador")
            'dtgDatos.Columns(2).Width = 250
            'dtgDatos.Columns(2).ReadOnly = True
            'dtgDatos.Columns.Add("sueldo", "Sueldo Ordinario")
            'dtgDatos.Columns(3).Width = 75
            'dtgDatos.Columns.Add("neto", "Neto")
            'dtgDatos.Columns(4).Width = 75
            'dtgDatos.Columns.Add("infonavit", "Infonavit")
            'dtgDatos.Columns(5).Width = 75
            'dtgDatos.Columns.Add("descuento", "Descuento")
            'dtgDatos.Columns(6).Width = 75
            'dtgDatos.Columns.Add("prestamo", "Prestamo")
            'dtgDatos.Columns(7).Width = 75
            'dtgDatos.Columns.Add("sindicato", "Sindicato")
            'dtgDatos.Columns(8).Width = 75
            'dtgDatos.Columns.Add("neto", "Sueldo Neto")
            'dtgDatos.Columns(9).Width = 75
            'dtgDatos.Columns.Add("imss", "Retención IMSS")
            'dtgDatos.Columns(10).Width = 75
            'dtgDatos.Columns.Add("subsidiado", "Retenciones")
            'dtgDatos.Columns(11).Width = 75
            'dtgDatos.Columns.Add("costosocial", "Costo Social")
            'dtgDatos.Columns(12).Width = 75
            'dtgDatos.Columns.Add("comision", "Comisión")
            'dtgDatos.Columns(13).Width = 75
            'dtgDatos.Columns.Add("subtotal", "Subtotal")
            'dtgDatos.Columns(14).Width = 75
            'dtgDatos.Columns.Add("iva", "IVA")
            'dtgDatos.Columns(15).Width = 75
            'dtgDatos.Columns.Add("total", "Total")
            'dtgDatos.Columns(16).Width = 75


            Dim dsPeriodo As New DataSet
            dsPeriodo.Tables.Add("Tabla")
            dsPeriodo.Tables("Tabla").Columns.Add("Consecutivo")
            dsPeriodo.Tables("Tabla").Columns.Add("Info")
            dsPeriodo.Tables("Tabla").Columns.Add("Id_empleado")
            dsPeriodo.Tables("Tabla").Columns.Add("Num_Cuenta")
            dsPeriodo.Tables("Tabla").Columns.Add("Departamento")
            dsPeriodo.Tables("Tabla").Columns.Add("Nombre")
            dsPeriodo.Tables("Tabla").Columns.Add("Sueldo")
            dsPeriodo.Tables("Tabla").Columns.Add("Neto_SA")
            dsPeriodo.Tables("Tabla").Columns.Add("P_Alimenticia")
            dsPeriodo.Tables("Tabla").Columns.Add("Infonavit")
            'dsPeriodo.Tables("Tabla").Columns.Add("Fonacot")
            dsPeriodo.Tables("Tabla").Columns.Add("Prima_SA")
            dsPeriodo.Tables("Tabla").Columns.Add("Aguinaldo_SA")
            dsPeriodo.Tables("Tabla").Columns.Add("Descuento")
            dsPeriodo.Tables("Tabla").Columns.Add("Prestamo")
            dsPeriodo.Tables("Tabla").Columns.Add("Sindicato")
            dsPeriodo.Tables("Tabla").Columns.Add("P_Alimenticia_S")
            dsPeriodo.Tables("Tabla").Columns.Add("Prima_Sin")
            dsPeriodo.Tables("Tabla").Columns.Add("Aguinaldo_Sin")

            dsPeriodo.Tables("Tabla").Columns.Add("Extra")
            dsPeriodo.Tables("Tabla").Columns.Add("Total_Sindicato")
            dsPeriodo.Tables("Tabla").Columns.Add("Neto_pagar")
            dsPeriodo.Tables("Tabla").Columns.Add("Imss")
            dsPeriodo.Tables("Tabla").Columns.Add("Subsidiado")
            dsPeriodo.Tables("Tabla").Columns.Add("Costo_social")
            dsPeriodo.Tables("Tabla").Columns.Add("Costo_social2")
            dsPeriodo.Tables("Tabla").Columns.Add("Comision_SA")
            dsPeriodo.Tables("Tabla").Columns.Add("Comision_Sindicato")
            dsPeriodo.Tables("Tabla").Columns.Add("Subtotal")
            dsPeriodo.Tables("Tabla").Columns.Add("Iva")
            dsPeriodo.Tables("Tabla").Columns.Add("Total")



            Dim dsSASindicato As New DataSet
            dsSASindicato.Tables.Add("Tabla")
            dsSASindicato.Tables("Tabla").Columns.Add("idempleado")
            dsSASindicato.Tables("Tabla").Columns.Add("Info")
            dsSASindicato.Tables("Tabla").Columns.Add("numcuenta")
            dsSASindicato.Tables("Tabla").Columns.Add("nombre")
            dsSASindicato.Tables("Tabla").Columns.Add("sueldo")
            dsSASindicato.Tables("Tabla").Columns.Add("neto")
            dsSASindicato.Tables("Tabla").Columns.Add("P_Alimenticia")
            dsSASindicato.Tables("Tabla").Columns.Add("infonavit")
            'dsSASindicato.Tables("Tabla").Columns.Add("fonacot")
            dsSASindicato.Tables("Tabla").Columns.Add("Prima_SA")
            dsSASindicato.Tables("Tabla").Columns.Add("Aguinaldo_SA")
            dsSASindicato.Tables("Tabla").Columns.Add("Aguinaldo_Sin")
            dsSASindicato.Tables("Tabla").Columns.Add("Extra")
            dsSASindicato.Tables("Tabla").Columns.Add("imss")
            dsSASindicato.Tables("Tabla").Columns.Add("subsidiado")
            dsSASindicato.Tables("Tabla").Columns.Add("costosocial")
            dsSASindicato.Tables("Tabla").Columns.Add("costosocial2")
            dsSASindicato.Tables("Tabla").Columns.Add("ISPT")
            dsSASindicato.Tables("Tabla").Columns.Add("departamento")

            'verificamos que no sea una nomina ya guardada como final
            'fImporteSin1 = Extra Sindicato
            'fImporteSa1 = Costos Social 2
            'fimporteSin2 = Comsion Sindicato
            sql = "select fkiIdempleado,cCuenta,(cApellidoP + ' ' + cApellidoM + ' ' + empleadosC.cNombre) as nombre,"
            sql &= " NominaSindicato.fSueldoOrd ,fNeto,fDescuento,fPrestamo,fSindicato,fSueldoNeto,"
            sql &= " fRentencionIMSS,fRetenciones,fCostoSocial,fComision,fSubtotal,fIVA,fTotal,cDepartamento as departamento,fInfonavit,fIncremento"
            sql &= " ,fPrimaSA,fPrimaSin,fAguinaldoSA,fAguinaldoSin,fImporteSin1,fImporteSa1,fImporteSin2,fImporteSA2,fImporteSin3"
            sql &= " from NominaSindicato"
            sql &= " inner join empleadosC on NominaSindicato.fkiIdempleado= empleadosC.iIdEmpleadoC"
            sql &= " inner join departamentos on empleadosC.fkiIdDepartamento= departamentos.iIdDepartamento "
            sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue & " and iEstatusNomina=1 and NominaSindicato.iEstatus=1"
            sql &= " order by empleadosC.iOrigen,departamentos.cNombre,nombre"

            'sql = "EXEC getNominaXEmpresaXPeriodo " & gIdEmpresa & "," & cboperiodo.SelectedValue & ",1"

            bCalcular = True
            Dim rwNominaGuardadaFinal As DataRow() = nConsulta(sql)

            If rwNominaGuardadaFinal Is Nothing = False Then
                'Cargamos los datos de guardados como final
                For x As Integer = 0 To rwNominaGuardadaFinal.Count - 1

                    Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow
                    fila.Item("Consecutivo") = (x + 1).ToString
                    fila.Item("Info") = ""
                    fila.Item("Id_empleado") = rwNominaGuardadaFinal(x)("fkiIdempleado").ToString
                    fila.Item("Num_Cuenta") = rwNominaGuardadaFinal(x)("cCuenta").ToString
                    fila.Item("Nombre") = rwNominaGuardadaFinal(x)("nombre").ToString.ToUpper()
                    fila.Item("Sueldo") = rwNominaGuardadaFinal(x)("fSueldoOrd").ToString
                    fila.Item("Neto_SA") = rwNominaGuardadaFinal(x)("fNeto").ToString
                    fila.Item("P_Alimenticia") = rwNominaGuardadaFinal(x)("fImporteSA2").ToString
                    fila.Item("Infonavit") = rwNominaGuardadaFinal(x)("fInfonavit").ToString
                    fila.Item("Prima_SA") = rwNominaGuardadaFinal(x)("fPrimaSA").ToString
                    fila.Item("Aguinaldo_SA") = rwNominaGuardadaFinal(x)("fAguinaldoSA").ToString


                    fila.Item("Descuento") = rwNominaGuardadaFinal(x)("fDescuento").ToString
                    fila.Item("Prestamo") = rwNominaGuardadaFinal(x)("fPrestamo").ToString
                    fila.Item("Sindicato") = rwNominaGuardadaFinal(x)("fSindicato").ToString
                    fila.Item("P_Alimenticia_S") = rwNominaGuardadaFinal(x)("fImporteSin3").ToString
                    fila.Item("Prima_Sin") = rwNominaGuardadaFinal(x)("fPrimaSin").ToString
                    fila.Item("Aguinaldo_Sin") = rwNominaGuardadaFinal(x)("fAguinaldoSin").ToString
                    fila.Item("Extra") = rwNominaGuardadaFinal(x)("fImporteSin1").ToString
                    fila.Item("Neto_pagar") = rwNominaGuardadaFinal(x)("fSueldoNeto").ToString
                    fila.Item("Imss") = rwNominaGuardadaFinal(x)("fRentencionIMSS").ToString
                    fila.Item("Subsidiado") = rwNominaGuardadaFinal(x)("fRetenciones").ToString
                    fila.Item("Costo_social") = rwNominaGuardadaFinal(x)("fCostoSocial").ToString
                    fila.Item("Costo_social2") = rwNominaGuardadaFinal(x)("fImporteSA1").ToString
                    fila.Item("Comision_SA") = rwNominaGuardadaFinal(x)("fComision").ToString
                    fila.Item("Comision_Sindicato") = rwNominaGuardadaFinal(x)("fImporteSin2").ToString
                    fila.Item("Subtotal") = rwNominaGuardadaFinal(x)("fSubtotal").ToString
                    fila.Item("Iva") = rwNominaGuardadaFinal(x)("fIVA").ToString
                    fila.Item("Total") = rwNominaGuardadaFinal(x)("fTotal").ToString
                    fila.Item("Departamento") = rwNominaGuardadaFinal(x)("departamento").ToString



                    fila.Item("Departamento") &= TipoCuentaBanco(rwNominaGuardadaFinal(x)("fkiIdempleado").ToString, 0)


                    dsPeriodo.Tables("Tabla").Rows.Add(fila)
                Next

                dtgDatos.DataSource = ""

                dtgDatos.DataSource = dsPeriodo.Tables("Tabla")

                dtgDatos.Columns(0).Width = 30
                dtgDatos.Columns(0).ReadOnly = True
                dtgDatos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                'consecutivo
                dtgDatos.Columns(1).Width = 60
                dtgDatos.Columns(1).ReadOnly = True
                dtgDatos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Info
                dtgDatos.Columns(2).Width = 100
                dtgDatos.Columns(2).ReadOnly = True
                'dtgDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                'idempleado
                dtgDatos.Columns(3).Width = 100
                dtgDatos.Columns(3).ReadOnly = True
                dtgDatos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'num cuenta
                dtgDatos.Columns(4).Width = 100
                dtgDatos.Columns(4).ReadOnly = True
                dtgDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'departamento
                dtgDatos.Columns(5).Width = 100
                dtgDatos.Columns(5).ReadOnly = True
                'nombre
                dtgDatos.Columns(6).Width = 250
                dtgDatos.Columns(6).ReadOnly = True
                'sueldo ordinario
                dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'neto
                dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(8).ReadOnly = True
                'Pensión Alimenticia
                dtgDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(9).ReadOnly = True
                'infonavit 
                dtgDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(10).ReadOnly = True
                'prima SA
                dtgDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'dtgDatos.Columns(10).ReadOnly = True

                'Aguinaldo SA
                dtgDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(12).ReadOnly = True


                'descuento
                dtgDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'Prestamo
                dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'sindicato
                dtgDatos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'dtgDatos.Columns(14).ReadOnly = True
                'Pension Alimenticia Sindicato
                dtgDatos.Columns(16).Width = 100
                dtgDatos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(16).ReadOnly = True
                'Prima_Sin
                dtgDatos.Columns(17).Width = 100
                dtgDatos.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Aguinaldo_Sin
                dtgDatos.Columns(18).Width = 100
                dtgDatos.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(18).ReadOnly = True

                'Importe sindicato Extra
                dtgDatos.Columns(19).Width = 100
                dtgDatos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(19).ReadOnly = True

                'Total sindicato Total_Sindicato
                dtgDatos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(20).ReadOnly = True

                'neto a pagar
                dtgDatos.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(21).ReadOnly = True
                'imss
                dtgDatos.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(22).ReadOnly = True
                'subsidiado
                dtgDatos.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'costosocial
                dtgDatos.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(24).ReadOnly = True

                'costosocial2 
                dtgDatos.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(25).ReadOnly = True
                'comisionSA
                dtgDatos.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(26).ReadOnly = True
                'comision Sindicato
                dtgDatos.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(27).ReadOnly = True
                'subtotal
                dtgDatos.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(28).ReadOnly = True
                'iva
                dtgDatos.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(29).ReadOnly = True

                'total
                dtgDatos.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtgDatos.Columns(30).ReadOnly = True




                Dim sindicato, primasin, pensionsindicato, totalsindicato, ExtraSindicato As Double

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    sindicato = dtgDatos.Rows(x).Cells(15).Value
                    pensionsindicato = dtgDatos.Rows(x).Cells(16).Value
                    primasin = dtgDatos.Rows(x).Cells(17).Value
                    AguinaldoSin = dtgDatos.Rows(x).Cells(18).Value
                    ExtraSindicato = dtgDatos.Rows(x).Cells(19).Value
                    totalsindicato = sindicato - pensionsindicato + primasin + AguinaldoSin + ExtraSindicato
                    dtgDatos.Rows(x).Cells(20).Value = Math.Round(totalsindicato, 2).ToString("##0.00")

                Next


                'calcular()

                MessageBox.Show("Datos cargados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            Else
                'verificamos si ya hay datos guardados en nomina aun cuando no estan marcados como final
                'primero buscamos en la nomina importada si hay datos es posible que haya datos guardados
                'en caso de que no sea asi no hay de donde sacar datos
                sql = "EXEC getNominaXEmpresaXPeriodo " & gIdEmpresa & "," & cboperiodo.SelectedValue & ",1"
                Dim consecutivo As Integer = 1

                Dim rwDatosPeriodo As DataRow() = nConsulta(sql)

                If rwDatosPeriodo Is Nothing = False Then

                    

                    Dim dt As DataTable
                    dt = rwDatosPeriodo.CopyToDataTable()

                    'la nomina por S.A. ordenada por nombre y tipo en el procedure
                    'la nomina por sindicato ordenada por nombre y tipo de procedure
                    'pedir la nomina por sindicato
                    sql = "select iIdEmpleadoC,NumCuenta, (cApellidoP + ' ' + cApellidoM + ' ' + cNombre) as nombre, fkiIdEmpresa,fSueldoOrd,fCosto from empleadosC"
                    sql &= " where empleadosC.iOrigen=2 and empleadosC.fkiIdClienteInter=-1"
                    sql &= " and empleadosC.fkiIdEmpresa =" & gIdEmpresa
                    sql &= " order by nombre"

                    Dim rwDatosSindicato As DataRow() = nConsulta(sql)
                    If rwDatosSindicato Is Nothing = False Then
                        For Each row As DataRow In dt.Rows
                            infonavit = 0

                            If Ruta = "ctDREVIN_CSyAP" Then

                            Else
                                Dim fila As DataRow = dsSASindicato.Tables("Tabla").NewRow


                                fila.Item("idempleado") = Trim(row("fkiIdEmpleado"))
                                fila.Item("numcuenta") = Trim(row("NumCuenta"))
                                fila.Item("nombre") = Trim(row("nombre")).ToUpper()
                                fila.Item("sueldo") = Trim(row("fSueldoOrd"))
                                fila.Item("neto") = Trim(row("neto"))

                                'If dt.Columns.IndexOf("I.S.R. finiquito") <> -1 Then
                                '    fila.Item("nombre") = "<finiquito> " & Trim(row("nombre"))
                                'End If

                                If Trim(row("fkiIdClienteInter")) = "1" Then
                                    fila.Item("nombre") = (Trim(row("nombre")) & "<finiquito>").ToUpper()
                                End If
                                'Pension Alimenticia
                                fila.Item("P_Alimenticia") = "0.00"

                                If dt.Columns.IndexOf("Pensión Alimenticia") <> -1 Then
                                    If (Not (row("Pensión Alimenticia") Is DBNull.Value)) Then
                                        fila.Item("P_Alimenticia") = IIf(Trim(row("Pensión Alimenticia")) = "", "0.00", Trim(row("Pensión Alimenticia")))
                                    End If
                                End If



                                If dt.Columns.IndexOf("Préstamo Infonavit (vsm)") <> -1 Then
                                    'MessageBox.Show("No hay datos en este período", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    If (Not (row("Préstamo Infonavit (vsm)") Is DBNull.Value)) Then
                                        infonavit = IIf(Trim(row("Préstamo Infonavit (vsm)")) = "", "0.00", Trim(row("Préstamo Infonavit (vsm)")))
                                    End If


                                End If


                                

                                If dt.Columns.IndexOf("Préstamo Infonavit (cf)") <> -1 Then
                                    If (Not (row("Préstamo Infonavit (cf)") Is DBNull.Value)) Then
                                        infonavit = IIf(Trim(row("Préstamo Infonavit (cf)")) = "", "0.00", Trim(row("Préstamo Infonavit (cf)")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("Diferencia Infonavit") <> -1 Then
                                    If (Not (row("Diferencia Infonavit") Is DBNull.Value)) Then
                                        infonavit = infonavit + IIf(Trim(row("Diferencia Infonavit")) = "", "0.00", Trim(row("Diferencia Infonavit")))
                                    End If
                                End If



                                fila.Item("infonavit") = infonavit

                                'Agregamos la prima de vacaciones
                                PrimaSA = 0

                                If dt.Columns.IndexOf("Prima de vacaciones a tiempo") <> -1 Then
                                    If (Not (row("Prima de vacaciones a tiempo") Is DBNull.Value)) Then
                                        PrimaSA = IIf(Trim(row("Prima de vacaciones a tiempo")) = "", "0.00", Trim(row("Prima de vacaciones a tiempo")))
                                    End If
                                End If


                                If dt.Columns.IndexOf("Prima de vacaciones reportada $") <> -1 Then
                                    If (Not (row("Prima de vacaciones reportada $") Is DBNull.Value)) Then
                                        PrimaSA = PrimaSA + IIf(Trim(row("Prima de vacaciones reportada $")) = "", "0.00", Trim(row("Prima de vacaciones reportada $")))
                                    End If
                                End If





                                fila.Item("Prima_SA") = PrimaSA

                                'Termina

                                'Agregamos aguinaldo
                                AguinaldoSA = 0

                                If dt.Columns.IndexOf("Aguinaldo") <> -1 Then
                                    If (Not (row("Aguinaldo") Is DBNull.Value)) Then
                                        AguinaldoSA = IIf(Trim(row("Aguinaldo")) = "", "0.00", Trim(row("Aguinaldo")))
                                    End If
                                End If
                                fila.Item("Aguinaldo_SA") = AguinaldoSA
                                'Termina Aguinaldo
                                'Agregamos aguinaldo
                                AguinaldoSA = 0

                                If dt.Columns.IndexOf("Aguinaldo") <> -1 Then
                                    If (Not (row("Aguinaldo") Is DBNull.Value)) Then
                                        AguinaldoSA = IIf(Trim(row("Aguinaldo")) = "", "0.00", Trim(row("Aguinaldo")))
                                    End If
                                End If
                                fila.Item("Aguinaldo_SA") = Math.Round(AguinaldoSA, 2)
                                'Termina Aguinaldo

                                ImssSA = 0
                                If dt.Columns.IndexOf("I.M.S.S.") <> -1 Then
                                    If (Not (row("I.M.S.S.") Is DBNull.Value)) Then
                                        ImssSA = IIf(Trim(row("I.M.S.S.")) = "", "0.00", Trim(row("I.M.S.S.")))
                                    End If
                                End If

                                fila.Item("imss") = ImssSA

                                SubsidioSA = 0

                                If valorsubsidio = 0 Then
                                    If dt.Columns.IndexOf("Subs al Empleo acreditado") <> -1 Then
                                        If (Not (row("Subs al Empleo acreditado") Is DBNull.Value)) Then
                                            SubsidioSA = IIf(Trim(row("Subs al Empleo acreditado")) = "", "0.00", Trim(row("Subs al Empleo acreditado")))
                                        End If
                                    End If
                                Else
                                    If dt.Columns.IndexOf("Subsidio al Empleo (sp)") <> -1 Then
                                        If (Not (row("Subsidio al Empleo (sp)") Is DBNull.Value)) Then
                                            SubsidioSA = IIf(Trim(row("Subsidio al Empleo (sp)")) = "", "0.00", Trim(row("Subsidio al Empleo (sp)")))
                                        End If
                                    End If
                                End If

                                fila.Item("subsidiado") = SubsidioSA


                                'Costo Social

                                fCostoSA = 0

                                If dt.Columns.IndexOf("Invalidez y Vida") <> -1 Then
                                    If (Not (row("Invalidez y Vida") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Invalidez y Vida")) = "", "0.00", Trim(row("Invalidez y Vida")))
                                    End If
                                End If


                                If dt.Columns.IndexOf("Cesantia y Vejez") <> -1 Then
                                    If (Not (row("Cesantia y Vejez") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Cesantia y Vejez")) = "", "0.00", Trim(row("Cesantia y Vejez")))
                                    End If
                                End If


                                If dt.Columns.IndexOf("Enf. y Mat. Patron") <> -1 Then
                                    If (Not (row("Enf. y Mat. Patron") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Enf. y Mat. Patron")) = "", "0.00", Trim(row("Enf. y Mat. Patron")))
                                    End If
                                End If
                                If dt.Columns.IndexOf("2% Fondo retiro SAR (8)") <> -1 Then
                                    If (Not (row("2% Fondo retiro SAR (8)") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("2% Fondo retiro SAR (8)")) = "", "0.00", Trim(row("2% Fondo retiro SAR (8)")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("2% Impuesto estatal") <> -1 Then
                                    If (Not (row("2% Impuesto estatal") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("2% Impuesto estatal")) = "", "0.00", Trim(row("2% Impuesto estatal")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("Riesgo de trabajo (9)") <> -1 Then
                                    If (Not (row("Riesgo de trabajo (9)") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Riesgo de trabajo (9)")) = "", "0.00", Trim(row("Riesgo de trabajo (9)")))
                                    End If
                                End If

                                'If dt.Columns.IndexOf("I.M.S.S. empresa") <> -1 Then
                                '    If (Not (row("I.M.S.S. empresa") Is DBNull.Value)) Then
                                '        fCostoSA = fCostoSA + IIf(Trim(row("I.M.S.S. empresa")) = "", "0.00", Trim(row("I.M.S.S. empresa")))
                                '    End If
                                'End If

                                If dt.Columns.IndexOf("Infonavit empresa") <> -1 Then
                                    If (Not (row("Infonavit empresa") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Infonavit empresa")) = "", "0.00", Trim(row("Infonavit empresa")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("Guarderia I.M.S.S. (7)") <> -1 Then
                                    If (Not (row("Guarderia I.M.S.S. (7)") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Guarderia I.M.S.S. (7)")) = "", "0.00", Trim(row("Guarderia I.M.S.S. (7)")))
                                    End If
                                End If




                                'If dt.Columns.IndexOf("fCosto") <> -1 Then
                                '    If (Not (row("fCosto") Is DBNull.Value)) Then
                                '        fCostoSA = IIf(Trim(row("fCosto")) = "", "0.00", Trim(row("fCosto")))
                                '    End If
                                'End If


                                fila.Item("costosocial") = fCostoSA
                                fila.Item("ISPT") = "0.00"
                                fila.Item("departamento") = Trim(row("depto"))

                                dsSASindicato.Tables("Tabla").Rows.Add(fila)



                            End If
                        Next
                        For x As Integer = 0 To rwDatosSindicato.Length - 1

                            Dim fila As DataRow = dsSASindicato.Tables("Tabla").NewRow


                            fila.Item("idempleado") = rwDatosSindicato(x)("iIdEmpleadoC")
                            fila.Item("numcuenta") = rwDatosSindicato(x)("NumCuenta")
                            fila.Item("nombre") = rwDatosSindicato(x)("nombre").ToString.ToUpper()
                            fila.Item("sueldo") = rwDatosSindicato(x)("fSueldoOrd")
                            fila.Item("neto") = "0.00"
                            fila.Item("P_Alimenticia") = "0.00"
                            fila.Item("infonavit") = "0.00"
                            fila.Item("Prima_SA") = "0.00"
                            fila.Item("Aguinaldo_SA") = "0.00"
                            fila.Item("imss") = "0.00"
                            fila.Item("subsidiado") = "0.00"
                            fila.Item("costosocial") = rwDatosSindicato(x)("fCosto")
                            fila.Item("ISPT") = "0.00"
                            fila.Item("departamento") = "Sindicato"

                            dsSASindicato.Tables("Tabla").Rows.Add(fila)

                        Next



                    Else
                        'verificamos el tipo de  empresa para ver si no requiere un tratamiento especial SIN TRABAJADORES DE SINDICATO
                        'For x As Integer = 0 To dt.Rows.Count - 1
                        For Each row As DataRow In dt.Rows
                            infonavit = 0

                            If Ruta = "ctDREVIN_CSyAP" Then

                            Else
                                Dim fila As DataRow = dsSASindicato.Tables("Tabla").NewRow


                                fila.Item("idempleado") = Trim(row("fkiIdEmpleado"))
                                fila.Item("numcuenta") = Trim(row("NumCuenta"))
                                fila.Item("nombre") = Trim(row("nombre")).ToUpper()
                                fila.Item("sueldo") = Trim(row("fSueldoOrd"))
                                fila.Item("neto") = Trim(row("neto"))

                                'If dt.Columns.IndexOf("I.S.R. finiquito") <> -1 Then
                                '    fila.Item("nombre") = "<finiquito> " & Trim(row("nombre"))
                                'End If

                                If Trim(row("fkiIdClienteInter")) = "1" Then
                                    fila.Item("nombre") = (Trim(row("nombre")) & "<finiquito>").ToUpper()
                                End If
                                'Pension alimenticia
                                fila.Item("P_Alimenticia") = "0.00"
                                If dt.Columns.IndexOf("Pensión Alimenticia") <> -1 Then
                                    If (Not (row("Pensión Alimenticia") Is DBNull.Value)) Then
                                        fila.Item("P_Alimenticia") = IIf(Trim(row("Pensión Alimenticia")) = "", "0.00", Trim(row("Pensión Alimenticia")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("Préstamo Infonavit (vsm)") <> -1 Then
                                    'MessageBox.Show("No hay datos en este período", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    If (Not (row("Préstamo Infonavit (vsm)") Is DBNull.Value)) Then
                                        infonavit = IIf(Trim(row("Préstamo Infonavit (vsm)")) = "", "0.00", Trim(row("Préstamo Infonavit (vsm)")))
                                    End If


                                End If


                                If dt.Columns.IndexOf("Préstamo Infonavit (cf)") <> -1 Then
                                    If (Not (row("Préstamo Infonavit (cf)") Is DBNull.Value)) Then
                                        infonavit = IIf(Trim(row("Préstamo Infonavit (cf)")) = "", "0.00", Trim(row("Préstamo Infonavit (cf)")))
                                    End If
                                End If


                                If dt.Columns.IndexOf("Diferencia Infonavit") <> -1 Then
                                    If (Not (row("Diferencia Infonavit") Is DBNull.Value)) Then
                                        infonavit = infonavit + IIf(Trim(row("Diferencia Infonavit")) = "", "0.00", Trim(row("Diferencia Infonavit")))
                                    End If
                                End If


                                fila.Item("infonavit") = infonavit

                                'Agregamos la prima de vacaciones
                                PrimaSA = 0

                                If dt.Columns.IndexOf("Prima de vacaciones a tiempo") <> -1 Then
                                    If (Not (row("Prima de vacaciones a tiempo") Is DBNull.Value)) Then
                                        PrimaSA = IIf(Trim(row("Prima de vacaciones a tiempo")) = "", "0.00", Trim(row("Prima de vacaciones a tiempo")))
                                    End If
                                End If


                                If dt.Columns.IndexOf("Prima de vacaciones reportada $") <> -1 Then
                                    If (Not (row("Prima de vacaciones reportada $") Is DBNull.Value)) Then
                                        PrimaSA = PrimaSA + IIf(Trim(row("Prima de vacaciones reportada $")) = "", "0.00", Trim(row("Prima de vacaciones reportada $")))
                                    End If
                                End If

                                fila.Item("Prima_SA") = PrimaSA

                                'Termina

                                'Agregamos aguinaldo
                                AguinaldoSA = 0

                                If dt.Columns.IndexOf("Aguinaldo") <> -1 Then
                                    If (Not (row("Aguinaldo") Is DBNull.Value)) Then
                                        AguinaldoSA = IIf(Trim(row("Aguinaldo")) = "", "0.00", Trim(row("Aguinaldo")))
                                    End If
                                End If
                                fila.Item("Aguinaldo_SA") = Math.Round(AguinaldoSA, 2)
                                'Termina Aguinaldo

                                ImssSA = 0
                                If dt.Columns.IndexOf("I.M.S.S.") <> -1 Then
                                    If (Not (row("I.M.S.S.") Is DBNull.Value)) Then
                                        ImssSA = IIf(Trim(row("I.M.S.S.")) = "", "0.00", Trim(row("I.M.S.S.")))
                                    End If
                                End If

                                fila.Item("imss") = ImssSA

                                SubsidioSA = 0

                                If valorsubsidio = 0 Then
                                    If dt.Columns.IndexOf("Subs al Empleo acreditado") <> -1 Then
                                        If (Not (row("Subs al Empleo acreditado") Is DBNull.Value)) Then
                                            SubsidioSA = IIf(Trim(row("Subs al Empleo acreditado")) = "", "0.00", Trim(row("Subs al Empleo acreditado")))
                                        End If
                                    End If
                                Else
                                    If dt.Columns.IndexOf("Subsidio al Empleo (sp)") <> -1 Then
                                        If (Not (row("Subsidio al Empleo (sp)") Is DBNull.Value)) Then
                                            SubsidioSA = IIf(Trim(row("Subsidio al Empleo (sp)")) = "", "0.00", Trim(row("Subsidio al Empleo (sp)")))
                                        End If
                                    End If
                                End If



                                fila.Item("subsidiado") = SubsidioSA


                                'Costo Social

                                fCostoSA = 0

                                If dt.Columns.IndexOf("Invalidez y Vida") <> -1 Then
                                    If (Not (row("Invalidez y Vida") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Invalidez y Vida")) = "", "0.00", Trim(row("Invalidez y Vida")))
                                    End If
                                End If


                                If dt.Columns.IndexOf("Cesantia y Vejez") <> -1 Then
                                    If (Not (row("Cesantia y Vejez") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Cesantia y Vejez")) = "", "0.00", Trim(row("Cesantia y Vejez")))
                                    End If
                                End If


                                If dt.Columns.IndexOf("Enf. y Mat. Patron") <> -1 Then
                                    If (Not (row("Enf. y Mat. Patron") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Enf. y Mat. Patron")) = "", "0.00", Trim(row("Enf. y Mat. Patron")))
                                    End If
                                End If
                                If dt.Columns.IndexOf("2% Fondo retiro SAR (8)") <> -1 Then
                                    If (Not (row("2% Fondo retiro SAR (8)") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("2% Fondo retiro SAR (8)")) = "", "0.00", Trim(row("2% Fondo retiro SAR (8)")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("2% Impuesto estatal") <> -1 Then
                                    If (Not (row("2% Impuesto estatal") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("2% Impuesto estatal")) = "", "0.00", Trim(row("2% Impuesto estatal")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("Riesgo de trabajo (9)") <> -1 Then
                                    If (Not (row("Riesgo de trabajo (9)") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Riesgo de trabajo (9)")) = "", "0.00", Trim(row("Riesgo de trabajo (9)")))
                                    End If
                                End If

                                'If dt.Columns.IndexOf("I.M.S.S. empresa") <> -1 Then
                                '    If (Not (row("I.M.S.S. empresa") Is DBNull.Value)) Then
                                '        fCostoSA = fCostoSA + IIf(Trim(row("I.M.S.S. empresa")) = "", "0.00", Trim(row("I.M.S.S. empresa")))
                                '    End If
                                'End If

                                If dt.Columns.IndexOf("Infonavit empresa") <> -1 Then
                                    If (Not (row("Infonavit empresa") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Infonavit empresa")) = "", "0.00", Trim(row("Infonavit empresa")))
                                    End If
                                End If

                                If dt.Columns.IndexOf("Guarderia I.M.S.S. (7)") <> -1 Then
                                    If (Not (row("Guarderia I.M.S.S. (7)") Is DBNull.Value)) Then
                                        fCostoSA = fCostoSA + IIf(Trim(row("Guarderia I.M.S.S. (7)")) = "", "0.00", Trim(row("Guarderia I.M.S.S. (7)")))
                                    End If
                                End If




                                'If dt.Columns.IndexOf("fCosto") <> -1 Then
                                '    If (Not (row("fCosto") Is DBNull.Value)) Then
                                '        fCostoSA = IIf(Trim(row("fCosto")) = "", "0.00", Trim(row("fCosto")))
                                '    End If
                                'End If


                                fila.Item("costosocial") = fCostoSA

                                fila.Item("ISPT") = "0.00"

                                fila.Item("departamento") = Trim(row("depto"))

                                dsSASindicato.Tables("Tabla").Rows.Add(fila)



                            End If
                        Next

                    End If

                    'unir las dos nominas en un nuevo dataset o en una nueva tabla
                    'comparamos con lo guardado
                    sql = "select * from NominaSindicato where"
                    sql &= " fkiIdEmpresa =" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue & " and iEstatus=1"

                    Dim rwNominaGuardada As DataRow() = nConsulta(sql)
                    If rwNominaGuardada Is Nothing = False Then
                        For x As Integer = 0 To dsSASindicato.Tables("Tabla").Rows.Count - 1
                            Dim subsidio, retencion, resultado As Double
                            If dsSASindicato.Tables("Tabla").Rows(x)("subsidiado").ToString = "" Then
                                subsidio = 0
                            Else
                                subsidio = Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("subsidiado").ToString)
                            End If

                            If dsSASindicato.Tables("Tabla").Rows(x)("ISPT").ToString = "" Then
                                retencion = 0
                            Else
                                retencion = Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("ISPT").ToString)
                            End If
                            If subsidio = 0 Then
                                resultado = retencion
                            ElseIf subsidio >= retencion Then
                                resultado = 0
                            Else
                                resultado = retencion - subsidio
                            End If
                            'bandera 
                            Dim ban As Integer = 0

                            For z As Integer = 0 To rwNominaGuardada.Length - 1

                                If dsSASindicato.Tables("Tabla").Rows(x)("idempleado").ToString = rwNominaGuardada(z)("fkiIdempleado").ToString Then
                                    Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow
                                    Dim InfoEmpleado As String
                                    'buscamos info del trabajador

                                    sql = "select * from InfoEmpleadoPeriodoContpaq where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idempleado").ToString
                                    sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue

                                    Dim rwInfoEmpleado As DataRow() = nConsulta(sql)
                                    If rwInfoEmpleado Is Nothing = False Then
                                        InfoEmpleado = IIf(rwInfoEmpleado(0)("igualar0") = "1", "Igualar 0", "")
                                    Else
                                        InfoEmpleado = ""
                                    End If


                                    If chkAguinaldo.Checked Then
                                        fila.Item("Consecutivo") = consecutivo
                                        fila.Item("Info") = InfoEmpleado
                                        fila.Item("Id_empleado") = dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                        fila.Item("Num_Cuenta") = dsSASindicato.Tables("Tabla").Rows(x)("numcuenta").ToString
                                        fila.Item("Nombre") = dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper()
                                        fila.Item("Sueldo") = rwNominaGuardada(z)("fSueldoOrd").ToString
                                        fila.Item("Neto_SA") = "0.00"
                                        fila.Item("Infonavit") = "0.00"
                                        fila.Item("Prima_SA") = "0.00"
                                        fila.Item("Aguinaldo_SA") = rwNominaGuardada(z)("fAguinaldoSA").ToString
                                        fila.Item("Descuento") = "0.00"


                                        fila.Item("Prestamo") = "0.00"

                                        'fila.Item("Prestamo") = rwNominaGuardada(z)("fPrestamo").ToString
                                        'fila.Item("pRIM") = "0.00"
                                        fila.Item("Sindicato") = "0.00"
                                        fila.Item("Prima_Sin") = "0.00"
                                        fila.Item("Aguinaldo_Sin") = rwNominaGuardada(z)("fAguinaldoSin").ToString
                                        fila.Item("Extra") = "0.00"
                                        fila.Item("Neto_pagar") = "0.00"
                                        fila.Item("Imss") = "0.00"
                                        fila.Item("Subsidiado") = "0.00"
                                        fila.Item("Costo_social") = "0.00"
                                        fila.Item("Costo_social2") = "0.00"
                                        fila.Item("Comision_SA") = "0.00"
                                        fila.Item("Comision_Sindicato") = "0.00"
                                        fila.Item("Subtotal") = "0.00"
                                        fila.Item("Iva") = "0.00"
                                        fila.Item("Total") = "0.00"
                                        fila.Item("Departamento") = Trim(dsSASindicato.Tables("Tabla").Rows(x)("departamento"))

                                        fila.Item("Departamento") &= TipoCuentaBanco(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0)

                                        dsPeriodo.Tables("Tabla").Rows.Add(fila)

                                        ban = 1
                                        consecutivo = consecutivo + 1
                                    Else
                                        fila.Item("Consecutivo") = consecutivo
                                        fila.Item("Info") = InfoEmpleado
                                        fila.Item("Id_empleado") = dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                        fila.Item("Num_Cuenta") = dsSASindicato.Tables("Tabla").Rows(x)("numcuenta").ToString
                                        fila.Item("Nombre") = dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper()
                                        fila.Item("Sueldo") = rwNominaGuardada(z)("fSueldoOrd").ToString
                                        fila.Item("Neto_SA") = dsSASindicato.Tables("Tabla").Rows(x)("neto").ToString
                                        fila.Item("P_Alimenticia") = dsSASindicato.Tables("Tabla").Rows(x)("P_Alimenticia").ToString
                                        fila.Item("Infonavit") = dsSASindicato.Tables("Tabla").Rows(x)("infonavit").ToString
                                        fila.Item("Prima_SA") = rwNominaGuardada(z)("fPrimaSA").ToString
                                        fila.Item("Aguinaldo_SA") = rwNominaGuardada(z)("fAguinaldoSA").ToString
                                        fila.Item("Descuento") = rwNominaGuardada(z)("fDescuento").ToString

                                        'Calculamos  la pension sindicato
                                        sql = "select * from PensionAlimenticia where fkiIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString

                                        Dim rwDatosPension As DataRow() = nConsulta(sql)

                                        If rwDatosPension Is Nothing = False Then

                                            If rwDatosPension(0)("iTipo") = "1" Then

                                            End If

                                            If rwDatosPension(0)("iTipo") = "2" Then
                                                fila.Item("P_Alimenticia_S") = (Double.Parse(rwDatosPension(0)("MontoCalculo")) * Double.Parse(rwDatosPension(0)("ValorImporte"))) - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("P_Alimenticia").ToString)
                                            End If


                                        Else
                                            fila.Item("P_Alimenticia_S") = "0.00"

                                        End If


                                        'Calculamos el prestamos 28/08/2017

                                        sql = "select * from Prestamo where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString & " and iEstatus=1"

                                        Dim rwPrestamos As DataRow() = nConsulta(sql)
                                        prestamo = 0

                                        If rwPrestamos Is Nothing = False Then
                                            sql = "select isnull(sum(monto),0) as monto from pagoprestamo where fkiIdPrestamo=" & rwPrestamos(0)("iIdPrestamo").ToString
                                            Dim rwMontoPrestamo As DataRow() = nConsulta(sql)
                                            If rwMontoPrestamo Is Nothing = False Then

                                                If Double.Parse(rwMontoPrestamo(0)("monto").ToString) < Double.Parse(rwPrestamos(0)("montototal").ToString) Then
                                                    If (Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)) >= Double.Parse(rwPrestamos(0)("descuento").ToString) Then
                                                        prestamo = Double.Parse(rwPrestamos(0)("descuento").ToString)
                                                    Else
                                                        prestamo = Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)
                                                    End If
                                                End If


                                            End If
                                        End If

                                        fila.Item("Prestamo") = Math.Round(prestamo, 2).ToString("##0.00")

                                        'fila.Item("Prestamo") = rwNominaGuardada(z)("fPrestamo").ToString
                                        'fila.Item("pRIM") = "0.00"
                                        fila.Item("Sindicato") = "0.00"
                                        fila.Item("Prima_Sin") = rwNominaGuardada(z)("fPrimaSin").ToString
                                        fila.Item("Aguinaldo_Sin") = rwNominaGuardada(z)("fAguinaldoSin").ToString
                                        fila.Item("Extra") = rwNominaGuardada(z)("fImporteSin1").ToString
                                        fila.Item("Neto_pagar") = "0.00"
                                        fila.Item("Imss") = dsSASindicato.Tables("Tabla").Rows(x)("imss").ToString
                                        fila.Item("Subsidiado") = resultado.ToString("###,###,###,##0.00")
                                        fila.Item("Costo_social") = rwNominaGuardada(z)("fCostoSocial").ToString
                                        fila.Item("Costo_social2") = "0.00"
                                        fila.Item("Comision_SA") = "0.00"
                                        fila.Item("Comision_Sindicato") = "0.00"
                                        fila.Item("Subtotal") = "0.00"
                                        fila.Item("Iva") = "0.00"
                                        fila.Item("Total") = "0.00"
                                        fila.Item("Departamento") = Trim(dsSASindicato.Tables("Tabla").Rows(x)("departamento"))

                                        fila.Item("Departamento") &= TipoCuentaBanco(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0)

                                        dsPeriodo.Tables("Tabla").Rows.Add(fila)

                                        ban = 1
                                        consecutivo = consecutivo + 1
                                    End If


                                End If

                            Next

                            If ban = 0 Then
                                Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow
                                Dim InfoEmpleado As String
                                'buscamos info del trabajador

                                sql = "select * from InfoEmpleadoPeriodoContpaq where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue

                                Dim rwInfoEmpleado As DataRow() = nConsulta(sql)
                                If rwInfoEmpleado Is Nothing = False Then
                                    InfoEmpleado = IIf(rwInfoEmpleado(0)("igualar0") = "1", "Igualar 0", "")
                                Else
                                    InfoEmpleado = ""
                                End If
                                If chkAguinaldo.Checked Then
                                    fila.Item("Consecutivo") = consecutivo
                                    fila.Item("Info") = InfoEmpleado
                                    fila.Item("Id_empleado") = dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                    fila.Item("Num_Cuenta") = dsSASindicato.Tables("Tabla").Rows(x)("numcuenta").ToString
                                    fila.Item("Nombre") = dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper()
                                    fila.Item("Sueldo") = dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString
                                    fila.Item("Neto_SA") = "0.00"
                                    fila.Item("Infonavit") = "0.00"
                                    fila.Item("Prima_SA") = "0.00"
                                    fila.Item("Aguinaldo_SA") = dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString



                                    fila.Item("Descuento") = "0.00"

                                    'buscamos prestamos y los agregamos



                                    fila.Item("Prestamo") = "0.00"


                                    'Buscamos si existe aguinaldo calculado en este periodo y si es asi lo pasamos a la tabla del dataset

                                    sql = "select * from AguinaldoC where fkiIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                    sql &= " and fkiIdEmpresaC=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue

                                    Dim rwAguinaldo As DataRow() = nConsulta(sql)
                                    AguinaldoSin = 0
                                    If rwAguinaldo Is Nothing = False Then
                                        AguinaldoSin = Double.Parse(rwAguinaldo(0)("Cantidad").ToString)
                                    End If

                                    If AguinaldoSin = 0 Then
                                        fila.Item("Aguinaldo_Sin") = "0.00"
                                    Else
                                        fila.Item("Aguinaldo_Sin") = AguinaldoSin - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString)
                                    End If


                                    fila.Item("Extra") = "0.00"



                                    fila.Item("Sindicato") = "0.00"
                                    'Calculo prima originalmente tenia 0
                                    fila.Item("Prima_Sin") = "0.00"
                                    fila.Item("Total_Sindicato") = "0.00"
                                    fila.Item("Neto_pagar") = "0.00"
                                    fila.Item("Imss") = "0.00"
                                    fila.Item("Subsidiado") = "0.00"
                                    fila.Item("Costo_social") = "0.00"
                                    fila.Item("Costo_social2") = "0.00"
                                    fila.Item("Comision_SA") = "0.00"
                                    fila.Item("Comision_Sindicato") = "0.00"
                                    fila.Item("Subtotal") = "0.00"
                                    fila.Item("Iva") = "0.00"
                                    fila.Item("Total") = "0.00"
                                    fila.Item("Departamento") = Trim(dsSASindicato.Tables("Tabla").Rows(x)("departamento"))

                                    fila.Item("Departamento") &= TipoCuentaBanco(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0)


                                    dsPeriodo.Tables("Tabla").Rows.Add(fila)

                                    consecutivo = consecutivo + 1
                                Else
                                    fila.Item("Consecutivo") = consecutivo
                                    fila.Item("Info") = InfoEmpleado
                                    fila.Item("Id_empleado") = dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                    fila.Item("Num_Cuenta") = dsSASindicato.Tables("Tabla").Rows(x)("numcuenta").ToString
                                    fila.Item("Nombre") = dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper()
                                    fila.Item("Sueldo") = dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString
                                    fila.Item("Neto_SA") = dsSASindicato.Tables("Tabla").Rows(x)("neto").ToString

                                    fila.Item("P_Alimenticia") = dsSASindicato.Tables("Tabla").Rows(x)("P_Alimenticia").ToString
                                    fila.Item("Infonavit") = dsSASindicato.Tables("Tabla").Rows(x)("infonavit").ToString
                                    fila.Item("Prima_SA") = dsSASindicato.Tables("Tabla").Rows(x)("Prima_SA").ToString
                                    fila.Item("Aguinaldo_SA") = dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString

                                    'Buscamos incidencias

                                    'Buscamos incidencias

                                    sql = "select * from incidencias where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString & "and fkiIdEmpresa=" & gIdEmpresa
                                    sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue & " and iEstatus=1"
                                    incidencia = 0
                                    Dim rwIncidencias As DataRow() = nConsulta(sql)
                                    If rwIncidencias Is Nothing = False Then
                                        incidencia = (Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString) / diasperiodo) * Double.Parse(rwIncidencias(0)("numdias").ToString)
                                    End If

                                    fila.Item("Descuento") = Math.Round(incidencia, 2).ToString("##0.00")

                                    'buscamos prestamos y los agregamos

                                    sql = "select * from Prestamo where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString & " and iEstatus=1"

                                    Dim rwPrestamos As DataRow() = nConsulta(sql)

                                    If rwPrestamos Is Nothing = False Then
                                        sql = "select isnull(sum(monto),0) as monto from pagoprestamo where fkiIdPrestamo=" & rwPrestamos(0)("iIdPrestamo").ToString
                                        Dim rwMontoPrestamo As DataRow() = nConsulta(sql)
                                        If rwMontoPrestamo Is Nothing = False Then

                                            If Double.Parse(rwMontoPrestamo(0)("monto").ToString) < Double.Parse(rwPrestamos(0)("montototal").ToString) Then
                                                If (Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)) >= Double.Parse(rwPrestamos(0)("descuento").ToString) Then
                                                    prestamo = Double.Parse(rwPrestamos(0)("descuento").ToString)
                                                Else
                                                    prestamo = Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)
                                                End If
                                            End If


                                        End If
                                    End If

                                    fila.Item("Prestamo") = Math.Round(prestamo, 2).ToString("##0.00")


                                    'Buscamos si existe aguinaldo calculado en este periodo y si es asi lo pasamos a la tabla del dataset

                                    sql = "select * from AguinaldoC where fkiIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                    sql &= " and fkiIdEmpresaC=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue

                                    Dim rwAguinaldo As DataRow() = nConsulta(sql)
                                    AguinaldoSin = 0
                                    If rwAguinaldo Is Nothing = False Then
                                        AguinaldoSin = Double.Parse(rwAguinaldo(0)("Cantidad").ToString)
                                    End If

                                    If AguinaldoSin = 0 Then
                                        fila.Item("Aguinaldo_Sin") = "0.00"
                                    Else
                                        fila.Item("Aguinaldo_Sin") = AguinaldoSin - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString)
                                    End If


                                    'Calculamos  la pension sindicato
                                    sql = "select * from PensionAlimenticia where fkiIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString

                                    Dim rwDatosPension As DataRow() = nConsulta(sql)

                                    If rwDatosPension Is Nothing = False Then

                                        If rwDatosPension(0)("iTipo") = "1" Then

                                        End If

                                        If rwDatosPension(0)("iTipo") = "2" Then
                                            fila.Item("P_Alimenticia_S") = (Double.Parse(rwDatosPension(0)("MontoCalculo")) * Double.Parse(rwDatosPension(0)("ValorImporte"))) - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("P_Alimenticia").ToString)
                                        End If


                                    Else
                                        fila.Item("P_Alimenticia_S") = "0.00"

                                    End If


                                    'Buscamos si hay importe extra y si el pago es mensual

                                    sql = "select * from empleadosC where iIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString


                                    Dim rwDatosEmpleado As DataRow() = nConsulta(sql)

                                    If rwDatosEmpleado Is Nothing = False Then
                                        If Double.Parse(rwDatosEmpleado(0)("fsindicatoExtra").ToString) > 0 Then
                                            'Preguntamos si ponemos el importe extra o no
                                            Dim respuesta As Integer = MessageBox.Show("Existe registrado un pago extra para el trabajador: " & dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper() & ", ¿Desea aplicarlo?", "Pregunta", MessageBoxButtons.YesNo)
                                            If respuesta = DialogResult.Yes Then
                                                fila.Item("Extra") = rwDatosEmpleado(0)("fsindicatoExtra").ToString
                                            Else
                                                fila.Item("Extra") = "0.00"
                                            End If
                                        Else
                                            fila.Item("Extra") = rwDatosEmpleado(0)("fsindicatoExtra").ToString
                                        End If
                                    End If


                                    fila.Item("Sindicato") = "0.00"
                                    'Calculo prima originalmente tenia 0
                                    fila.Item("Prima_Sin") = (Double.Parse(CalculoPrimaSindicato(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0))) - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("Prima_SA").ToString)
                                    fila.Item("Total_Sindicato") = "0.00"
                                    fila.Item("Neto_pagar") = "0.00"
                                    fila.Item("Imss") = dsSASindicato.Tables("Tabla").Rows(x)("imss").ToString
                                    fila.Item("Subsidiado") = resultado.ToString("###,###,###,##0.00")
                                    fila.Item("Costo_social") = dsSASindicato.Tables("Tabla").Rows(x)("costosocial").ToString
                                    fila.Item("Costo_social2") = "0.00"
                                    fila.Item("Comision_SA") = "0.00"
                                    fila.Item("Comision_Sindicato") = "0.00"
                                    fila.Item("Subtotal") = "0.00"
                                    fila.Item("Iva") = "0.00"
                                    fila.Item("Total") = "0.00"
                                    fila.Item("Departamento") = Trim(dsSASindicato.Tables("Tabla").Rows(x)("departamento"))

                                    fila.Item("Departamento") &= TipoCuentaBanco(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0)


                                    dsPeriodo.Tables("Tabla").Rows.Add(fila)

                                    consecutivo = consecutivo + 1
                                End If



                            End If

                        Next

                    Else
                        For x As Integer = 0 To dsSASindicato.Tables("Tabla").Rows.Count - 1
                            'Subsidio
                            Dim subsidio, retencion, resultado As Double
                            prestamo = 0

                            If dsSASindicato.Tables("Tabla").Rows(x)("subsidiado").ToString = "" Then
                                subsidio = 0
                            Else
                                subsidio = Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("subsidiado").ToString)
                            End If

                            If dsSASindicato.Tables("Tabla").Rows(x)("ISPT").ToString = "" Then
                                retencion = 0
                            Else
                                retencion = Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("ISPT").ToString)
                            End If
                            If subsidio = 0 Then
                                resultado = retencion
                            ElseIf subsidio >= retencion Then
                                resultado = 0
                            Else
                                resultado = retencion - subsidio
                            End If


                            'Llenamos la tabla

                            Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow

                            If chkAguinaldo.Checked Then
                                fila.Item("Consecutivo") = (x + 1).ToString
                                fila.Item("Info") = ""
                                fila.Item("Id_empleado") = dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                fila.Item("Num_cuenta") = dsSASindicato.Tables("Tabla").Rows(x)("numcuenta").ToString
                                fila.Item("Nombre") = dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper
                                fila.Item("Sueldo") = dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString
                                fila.Item("Neto_SA") = "0.00"
                                fila.Item("Infonavit") = "0.00"
                                fila.Item("Prima_SA") = "0.00"
                                fila.Item("Aguinaldo_SA") = dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString

                                fila.Item("Descuento") = "0.00"


                                fila.Item("Prestamo") = "0.00"


                                'Buscamos si existe aguinaldo calculado en este periodo y si es asi lo pasamos a la tabla del dataset

                                sql = "select * from AguinaldoC where fkiIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                sql &= " and fkiIdEmpresaC=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue

                                Dim rwAguinaldo As DataRow() = nConsulta(sql)
                                AguinaldoSin = 0
                                If rwAguinaldo Is Nothing = False Then
                                    AguinaldoSin = Double.Parse(rwAguinaldo(0)("Cantidad").ToString)
                                End If


                                If AguinaldoSin = 0 Then
                                    fila.Item("Aguinaldo_Sin") = "0.00"
                                Else
                                    fila.Item("Aguinaldo_Sin") = AguinaldoSin - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString)
                                End If


                                fila.Item("Extra") = "0.00"
                                fila.Item("Sindicato") = "0.00"

                                fila.Item("Prima_Sin") = "0.00"
                                fila.Item("Total_Sindicato") = "0.00"

                                fila.Item("Neto_pagar") = "0.00"
                                fila.Item("Imss") = "0.00"
                                fila.Item("Subsidiado") = "0.00"
                                fila.Item("Costo_social") = "0.00"
                                fila.Item("Costo_social2") = "0.00"
                                fila.Item("Comision_SA") = "0.00"
                                fila.Item("Comision_Sindicato") = "0.00"
                                fila.Item("Subtotal") = "0.00"
                                fila.Item("Iva") = "0.00"
                                fila.Item("Total") = "0.00"
                                fila.Item("Departamento") = Trim(dsSASindicato.Tables("Tabla").Rows(x)("departamento"))


                                fila.Item("Departamento") &= TipoCuentaBanco(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0)


                                dsPeriodo.Tables("Tabla").Rows.Add(fila)
                            Else
                                fila.Item("Consecutivo") = (x + 1).ToString
                                fila.Item("Info") = ""
                                fila.Item("Id_empleado") = dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                fila.Item("Num_cuenta") = dsSASindicato.Tables("Tabla").Rows(x)("numcuenta").ToString
                                fila.Item("Nombre") = dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper
                                fila.Item("Sueldo") = dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString
                                fila.Item("Neto_SA") = dsSASindicato.Tables("Tabla").Rows(x)("neto").ToString

                                fila.Item("P_Alimenticia") = dsSASindicato.Tables("Tabla").Rows(x)("P_Alimenticia").ToString
                                fila.Item("Infonavit") = dsSASindicato.Tables("Tabla").Rows(x)("infonavit").ToString
                                fila.Item("Prima_SA") = dsSASindicato.Tables("Tabla").Rows(x)("Prima_SA").ToString
                                fila.Item("Aguinaldo_SA") = dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString
                                'Buscamos incidencias

                                sql = "select * from incidencias where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString & "and fkiIdEmpresa=" & gIdEmpresa
                                sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue & "and iEstatus=1"
                                incidencia = 0
                                Dim rwIncidencias As DataRow() = nConsulta(sql)
                                If rwIncidencias Is Nothing = False Then
                                    incidencia = (Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString) / diasperiodo) * Double.Parse(rwIncidencias(0)("numdias").ToString)
                                End If

                                fila.Item("Descuento") = Math.Round(incidencia, 2).ToString("##0.00")

                                'buscamos prestamos y los agregamos

                                sql = "select * from Prestamo where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString & " and iEstatus=1"

                                Dim rwPrestamos As DataRow() = nConsulta(sql)

                                If rwPrestamos Is Nothing = False Then
                                    sql = "select isnull(sum(monto),0) as monto from pagoprestamo where fkiIdPrestamo=" & rwPrestamos(0)("iIdPrestamo").ToString
                                    Dim rwMontoPrestamo As DataRow() = nConsulta(sql)
                                    If rwMontoPrestamo Is Nothing = False Then

                                        If Double.Parse(rwMontoPrestamo(0)("monto").ToString) < Double.Parse(rwPrestamos(0)("montototal").ToString) Then
                                            If (Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)) >= Double.Parse(rwPrestamos(0)("descuento").ToString) Then
                                                prestamo = Double.Parse(rwPrestamos(0)("descuento").ToString)
                                            Else
                                                prestamo = Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)
                                            End If
                                        End If


                                    End If
                                End If


                                fila.Item("Prestamo") = Math.Round(prestamo, 2).ToString("##0.00")


                                'Buscamos si existe aguinaldo calculado en este periodo y si es asi lo pasamos a la tabla del dataset

                                sql = "select * from AguinaldoC where fkiIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                                sql &= " and fkiIdEmpresaC=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue

                                Dim rwAguinaldo As DataRow() = nConsulta(sql)
                                AguinaldoSin = 0
                                If rwAguinaldo Is Nothing = False Then
                                    AguinaldoSin = Double.Parse(rwAguinaldo(0)("Cantidad").ToString)
                                End If


                                If AguinaldoSin = 0 Then
                                    fila.Item("Aguinaldo_Sin") = "0.00"
                                Else
                                    fila.Item("Aguinaldo_Sin") = AguinaldoSin - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("Aguinaldo_SA").ToString)
                                End If

                                'Calculamos  la pension sindicato
                                sql = "select * from PensionAlimenticia where fkiIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString

                                Dim rwDatosPension As DataRow() = nConsulta(sql)

                                If rwDatosPension Is Nothing = False Then

                                    If rwDatosPension(0)("iTipo") = "1" Then

                                    End If

                                    If rwDatosPension(0)("iTipo") = "2" Then
                                        fila.Item("P_Alimenticia_S") = (Double.Parse(rwDatosPension(0)("MontoCalculo")) * Double.Parse(rwDatosPension(0)("ValorImporte"))) - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("P_Alimenticia").ToString)
                                    End If


                                Else
                                    fila.Item("P_Alimenticia_S") = "0.00"

                                End If



                                'Buscamos si hay importe extra y si el pago es mensual

                                sql = "select * from empleadosC where iIdEmpleadoC=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString


                                Dim rwDatosEmpleado As DataRow() = nConsulta(sql)

                                If rwDatosEmpleado Is Nothing = False Then
                                    If Double.Parse(rwDatosEmpleado(0)("fsindicatoExtra").ToString) > 0 Then
                                        'Preguntamos si ponemos el importe extra o no
                                        Dim respuesta As Integer = MessageBox.Show("Existe registrado un pago extra para el trabajador: " & dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper() & ", ¿Desea aplicarlo?", "Pregunta", MessageBoxButtons.YesNo)
                                        If respuesta = DialogResult.Yes Then
                                            fila.Item("Extra") = rwDatosEmpleado(0)("fsindicatoExtra").ToString
                                        Else
                                            fila.Item("Extra") = "0.00"
                                        End If
                                    Else
                                        fila.Item("Extra") = rwDatosEmpleado(0)("fsindicatoExtra").ToString
                                    End If
                                End If

                                fila.Item("Sindicato") = "0.00"

                                fila.Item("Prima_Sin") = (Double.Parse(CalculoPrimaSindicato(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0))) - Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("Prima_SA").ToString)
                                fila.Item("Total_Sindicato") = "0.00"

                                fila.Item("Neto_pagar") = "0.00"
                                fila.Item("Imss") = dsSASindicato.Tables("Tabla").Rows(x)("imss").ToString
                                fila.Item("Subsidiado") = resultado.ToString("###,###,###,##0.00")
                                fila.Item("Costo_social") = dsSASindicato.Tables("Tabla").Rows(x)("costosocial").ToString
                                fila.Item("Costo_social2") = "0.00"
                                fila.Item("Comision_SA") = "0.00"
                                fila.Item("Comision_Sindicato") = "0.00"
                                fila.Item("Subtotal") = "0.00"
                                fila.Item("Iva") = "0.00"
                                fila.Item("Total") = "0.00"
                                fila.Item("Departamento") = Trim(dsSASindicato.Tables("Tabla").Rows(x)("departamento"))


                                fila.Item("Departamento") &= TipoCuentaBanco(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0)


                                dsPeriodo.Tables("Tabla").Rows.Add(fila)
                            End If







                        Next
                    End If

                    'dtgDatos.AutoGenerateColumns = False

                    dtgDatos.DataSource = ""

                    dtgDatos.DataSource = dsPeriodo.Tables("Tabla")

                    dtgDatos.Columns(0).Width = 30
                    dtgDatos.Columns(0).ReadOnly = True
                    dtgDatos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                    'consecutivo
                    dtgDatos.Columns(1).Width = 60
                    dtgDatos.Columns(1).ReadOnly = True
                    dtgDatos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    'Info
                    dtgDatos.Columns(2).Width = 100
                    dtgDatos.Columns(2).ReadOnly = True
                    'dtgDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                    'idempleado
                    dtgDatos.Columns(3).Width = 100
                    dtgDatos.Columns(3).ReadOnly = True
                    dtgDatos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'num cuenta
                    dtgDatos.Columns(4).Width = 100
                    dtgDatos.Columns(4).ReadOnly = True
                    dtgDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'departamento
                    dtgDatos.Columns(5).Width = 100
                    dtgDatos.Columns(5).ReadOnly = True
                    'nombre
                    dtgDatos.Columns(6).Width = 250
                    dtgDatos.Columns(6).ReadOnly = True
                    'sueldo ordinario
                    dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    'neto
                    dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(8).ReadOnly = True
                    'Pensión Alimenticia
                    dtgDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(9).ReadOnly = True
                    'infonavit 
                    dtgDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(10).ReadOnly = True
                    'prima SA
                    dtgDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'dtgDatos.Columns(10).ReadOnly = True

                    'Aguinaldo SA
                    dtgDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(12).ReadOnly = True


                    'descuento
                    dtgDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'Prestamo
                    dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    'sindicato
                    dtgDatos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'dtgDatos.Columns(14).ReadOnly = True
                    'Pension Alimenticia Sindicato
                    dtgDatos.Columns(16).Width = 100
                    dtgDatos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(16).ReadOnly = True
                    'Prima_Sin
                    dtgDatos.Columns(17).Width = 100
                    dtgDatos.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    'Aguinaldo_Sin
                    dtgDatos.Columns(18).Width = 100
                    dtgDatos.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(18).ReadOnly = True

                    'Importe sindicato Extra
                    dtgDatos.Columns(19).Width = 100
                    dtgDatos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(19).ReadOnly = True

                    'Total sindicato Total_Sindicato
                    dtgDatos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(20).ReadOnly = True

                    'neto a pagar
                    dtgDatos.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(21).ReadOnly = True
                    'imss
                    dtgDatos.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(22).ReadOnly = True
                    'subsidiado
                    dtgDatos.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    'costosocial
                    dtgDatos.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(24).ReadOnly = True

                    'costosocial2 
                    dtgDatos.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(25).ReadOnly = True
                    'comisionSA
                    dtgDatos.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(26).ReadOnly = True
                    'comision Sindicato
                    dtgDatos.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(27).ReadOnly = True
                    'subtotal
                    dtgDatos.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(28).ReadOnly = True
                    'iva
                    dtgDatos.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(29).ReadOnly = True

                    'total
                    dtgDatos.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dtgDatos.Columns(30).ReadOnly = True




                    calcular()
                    MessageBox.Show("Datos cargados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    'Buscamos los datos de sindicato solamente
                    sql = "select iIdEmpleadoC,NumCuenta, (cApellidoP + ' ' + cApellidoM + ' ' + cNombre) as nombre, fkiIdEmpresa,fSueldoOrd,fCosto from empleadosC"
                    sql &= " where empleadosC.iOrigen=2 and empleadosC.fkiIdClienteInter=-1"
                    sql &= " and empleadosC.fkiIdEmpresa =" & gIdEmpresa
                    sql &= " order by nombre"

                    Dim rwDatosSindicato As DataRow() = nConsulta(sql)
                    If rwDatosSindicato Is Nothing = False Then
                        For x As Integer = 0 To rwDatosSindicato.Length - 1


                            Dim fila As DataRow = dsSASindicato.Tables("Tabla").NewRow
                            fila.Item("idempleado") = rwDatosSindicato(x)("iIdEmpleadoC")

                            fila.Item("numcuenta") = rwDatosSindicato(x)("NumCuenta")
                            fila.Item("nombre") = rwDatosSindicato(x)("nombre").ToString.ToUpper()
                            fila.Item("sueldo") = rwDatosSindicato(x)("fSueldoOrd")
                            fila.Item("neto") = "0.00"
                            fila.Item("P_Alimenticia") = "0.00"
                            fila.Item("infonavit") = "0.00"
                            fila.Item("imss") = "0.00"
                            fila.Item("subsidiado") = "0.00"
                            fila.Item("costosocial") = rwDatosSindicato(x)("fCosto")
                            fila.Item("ISPT") = "0.00"
                            fila.Item("departamento") = "Sindicato"

                            dsSASindicato.Tables("Tabla").Rows.Add(fila)




                        Next


                        For x As Integer = 0 To dsSASindicato.Tables("Tabla").Rows.Count - 1
                            'Subsidio
                            Dim subsidio, retencion, resultado As Double
                            prestamo = 0

                            If dsSASindicato.Tables("Tabla").Rows(x)("subsidiado").ToString = "" Then
                                subsidio = 0
                            Else
                                subsidio = Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("subsidiado").ToString)
                            End If

                            If dsSASindicato.Tables("Tabla").Rows(x)("ISPT").ToString = "" Then
                                retencion = 0
                            Else
                                retencion = Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("ISPT").ToString)
                            End If
                            If subsidio = 0 Then
                                resultado = retencion
                            ElseIf subsidio >= retencion Then
                                resultado = 0
                            Else
                                resultado = retencion - subsidio
                            End If


                            'Llenamos la tabla

                            Dim fila As DataRow = dsPeriodo.Tables("Tabla").NewRow
                            fila.Item("Consecutivo") = (x + 1).ToString
                            fila.Item("Info") = ""
                            fila.Item("Id_empleado") = dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString
                            fila.Item("Num_cuenta") = dsSASindicato.Tables("Tabla").Rows(x)("numcuenta").ToString
                            fila.Item("Nombre") = dsSASindicato.Tables("Tabla").Rows(x)("nombre").ToString.ToUpper
                            fila.Item("Sueldo") = dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString
                            fila.Item("Neto_SA") = dsSASindicato.Tables("Tabla").Rows(x)("neto").ToString
                            fila.Item("Infonavit") = dsSASindicato.Tables("Tabla").Rows(x)("infonavit").ToString
                            fila.Item("P_Alimenticia") = dsSASindicato.Tables("Tabla").Rows(x)("P_Alimenticia").ToString
                            fila.Item("Prima_SA") = "0.00"
                            fila.Item("Aguinaldo_SA") = "0.00"
                            'Buscamos incidencias

                            sql = "select * from incidencias where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString & "and fkiIdEmpresa=" & gIdEmpresa
                            sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue & " and iEstatus=1"
                            incidencia = 0
                            Dim rwIncidencias As DataRow() = nConsulta(sql)
                            If rwIncidencias Is Nothing = False Then
                                incidencia = (Double.Parse(dsSASindicato.Tables("Tabla").Rows(x)("sueldo").ToString) / diasperiodo) * Double.Parse(rwIncidencias(0)("numdias").ToString)
                            End If

                            fila.Item("Descuento") = Math.Round(incidencia, 2).ToString("##0.00")

                            'buscamos prestamos y los agregamos

                            sql = "select * from Prestamo where fkiIdEmpleado=" & dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString & " and iEstatus=1"

                            Dim rwPrestamos As DataRow() = nConsulta(sql)

                            If rwPrestamos Is Nothing = False Then
                                sql = "select isnull(sum(monto),0) as monto from pagoprestamo where fkiIdPrestamo=" & rwPrestamos(0)("iIdPrestamo").ToString
                                Dim rwMontoPrestamo As DataRow() = nConsulta(sql)
                                If rwMontoPrestamo Is Nothing = False Then

                                    If Double.Parse(rwMontoPrestamo(0)("monto").ToString) < Double.Parse(rwPrestamos(0)("montototal").ToString) Then
                                        If (Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)) >= Double.Parse(rwPrestamos(0)("descuento").ToString) Then
                                            prestamo = Double.Parse(rwPrestamos(0)("descuento").ToString)
                                        Else
                                            prestamo = Double.Parse(rwPrestamos(0)("montototal").ToString) - Double.Parse(rwMontoPrestamo(0)("monto").ToString)
                                        End If
                                    End If


                                End If
                            End If

                            fila.Item("Prestamo") = Math.Round(prestamo, 2).ToString("##0.00")

                            fila.Item("Sindicato") = "0.00"
                            fila.Item("P_Alimenticia_S") = "0.00"
                            fila.Item("Prima_Sin") = "0.00"
                            fila.Item("Aguinaldo_Sin") = "0.00"
                            fila.Item("Extra") = "0.00"
                            fila.Item("Total_Sindicato") = "0.00"

                            fila.Item("Neto_pagar") = "0.00"
                            fila.Item("Imss") = dsSASindicato.Tables("Tabla").Rows(x)("imss").ToString
                            fila.Item("Subsidiado") = resultado.ToString("###,###,###,##0.00")
                            fila.Item("Costo_social") = dsSASindicato.Tables("Tabla").Rows(x)("costosocial").ToString
                            fila.Item("Costo_social2") = "0.00"
                            fila.Item("Comision_SA") = "0.00"
                            fila.Item("Comision_Sindicato") = "0.00"
                            fila.Item("Subtotal") = "0.00"
                            fila.Item("Iva") = "0.00"
                            fila.Item("Total") = "0.00"
                            fila.Item("Departamento") = Trim(dsSASindicato.Tables("Tabla").Rows(x)("departamento"))

                            fila.Item("Departamento") &= TipoCuentaBanco(dsSASindicato.Tables("Tabla").Rows(x)("idEmpleado").ToString, 0)


                            dsPeriodo.Tables("Tabla").Rows.Add(fila)



                        Next


                        dtgDatos.DataSource = ""

                        dtgDatos.DataSource = dsPeriodo.Tables("Tabla")

                        dtgDatos.Columns(0).Width = 30
                        dtgDatos.Columns(0).ReadOnly = True
                        dtgDatos.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                        'consecutivo
                        dtgDatos.Columns(1).Width = 60
                        dtgDatos.Columns(1).ReadOnly = True
                        dtgDatos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        'Info
                        dtgDatos.Columns(2).Width = 100
                        dtgDatos.Columns(2).ReadOnly = True
                        'dtgDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                        'idempleado
                        dtgDatos.Columns(3).Width = 100
                        dtgDatos.Columns(3).ReadOnly = True
                        dtgDatos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'num cuenta
                        dtgDatos.Columns(4).Width = 100
                        dtgDatos.Columns(4).ReadOnly = True
                        dtgDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'departamento
                        dtgDatos.Columns(5).Width = 100
                        dtgDatos.Columns(5).ReadOnly = True
                        'nombre
                        dtgDatos.Columns(6).Width = 250
                        dtgDatos.Columns(6).ReadOnly = True
                        'sueldo ordinario
                        dtgDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        'neto
                        dtgDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(8).ReadOnly = True
                        'Pensión Alimenticia
                        dtgDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(9).ReadOnly = True
                        'infonavit 
                        dtgDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(10).ReadOnly = True
                        'prima SA
                        dtgDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'dtgDatos.Columns(10).ReadOnly = True

                        'Aguinaldo SA
                        dtgDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(12).ReadOnly = True


                        'descuento
                        dtgDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'Prestamo
                        dtgDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        'sindicato
                        dtgDatos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'dtgDatos.Columns(14).ReadOnly = True
                        'Pension Alimenticia Sindicato
                        dtgDatos.Columns(16).Width = 100
                        dtgDatos.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(16).ReadOnly = True
                        'Prima_Sin
                        dtgDatos.Columns(17).Width = 100
                        dtgDatos.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        'Aguinaldo_Sin
                        dtgDatos.Columns(18).Width = 100
                        dtgDatos.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(18).ReadOnly = True

                        'Importe sindicato Extra
                        dtgDatos.Columns(19).Width = 100
                        dtgDatos.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(19).ReadOnly = True

                        'Total sindicato Total_Sindicato
                        dtgDatos.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(20).ReadOnly = True

                        'neto a pagar
                        dtgDatos.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(21).ReadOnly = True
                        'imss
                        dtgDatos.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(22).ReadOnly = True
                        'subsidiado
                        dtgDatos.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        'costosocial
                        dtgDatos.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(24).ReadOnly = True

                        'costosocial2 
                        dtgDatos.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(25).ReadOnly = True
                        'comisionSA
                        dtgDatos.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(26).ReadOnly = True
                        'comision Sindicato
                        dtgDatos.Columns(27).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(27).ReadOnly = True
                        'subtotal
                        dtgDatos.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(28).ReadOnly = True
                        'iva
                        dtgDatos.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(29).ReadOnly = True

                        'total
                        dtgDatos.Columns(30).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        dtgDatos.Columns(30).ReadOnly = True





                        calcular()
                        MessageBox.Show("Datos cargados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No hay datos en este período", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If




                    'No hay datos en este período



                End If



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try

    End Sub

    Private Sub cmdguardarnomina_Click(sender As Object, e As EventArgs) Handles cmdguardarnomina.Click

        Try
            Dim sql As String
            sql = "select fkiIdempleado,cCuenta,(cApellidoP + ' ' + cApellidoM + ' ' + empleadosC.cNombre) as nombre,"
            sql &= " NominaSindicato.fSueldoOrd ,fNeto,fDescuento,fSindicato,fSueldoNeto,"
            sql &= " fRentencionIMSS,fRetenciones,fCostoSocial,fComision,fSubtotal,fIVA,fTotal,cDepartamento as departamento,fInfonavit,fIncremento"
            sql &= " from NominaSindicato"
            sql &= " inner join empleadosC on NominaSindicato.fkiIdempleado= empleadosC.iIdEmpleadoC"
            sql &= " inner join departamentos on empleadosC.fkiIdDepartamento= departamentos.iIdDepartamento "
            sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue & " and iEstatusNomina=1 and NominaSindicato.iEstatus=1"
            sql &= " order by empleadosC.iOrigen,nombre"

            'sql = "EXEC getNominaXEmpresaXPeriodo " & gIdEmpresa & "," & cboperiodo.SelectedValue & ",1"

            Dim rwNominaGuardadaFinal As DataRow() = nConsulta(sql)

            If rwNominaGuardadaFinal Is Nothing = False Then
                MessageBox.Show("La nomina ya esta marcada como final, no  se pueden guardar cambios", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                sql = "delete from NominaSindicato"
                sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and NominaSindicato.fkiIdPeriodo=" & cboperiodo.SelectedValue
                sql &= " and NominaSindicato.iEstatusNomina=0 and NominaSindicato.iEstatus=1"

                If nExecute(sql) = False Then
                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'pnlProgreso.Visible = False
                    Exit Sub
                End If

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    sql = "EXEC [setNominaSindicatoInsertar] 0"
                    'periodo
                    sql &= "," & cboperiodo.SelectedValue
                    'idempresa
                    sql &= "," & gIdEmpresa
                    'idempleado
                    sql &= "," & dtgDatos.Rows(x).Cells(3).Value
                    'sueldoordinario
                    sql &= "," & dtgDatos.Rows(x).Cells(7).Value.ToString.Replace(",", "")
                    'neto
                    sql &= "," & dtgDatos.Rows(x).Cells(8).Value.ToString.Replace(",", "")
                    'descuento
                    sql &= "," & dtgDatos.Rows(x).Cells(13).Value.ToString.Replace(",", "")
                    'Prestamo
                    sql &= "," & dtgDatos.Rows(x).Cells(14).Value.ToString.Replace(",", "")
                    'sindicato
                    sql &= ",0"
                    'sueldo neto
                    sql &= ",0"
                    'retencion imss
                    sql &= "," & dtgDatos.Rows(x).Cells(22).Value.ToString.Replace(",", "")
                    'retenciones
                    sql &= "," & dtgDatos.Rows(x).Cells(23).Value.ToString.Replace(",", "")
                    'costosocial
                    sql &= "," & dtgDatos.Rows(x).Cells(24).Value.ToString.Replace(",", "")
                    'comision
                    sql &= "," & dtgDatos.Rows(x).Cells(26).Value.ToString.Replace(",", "")
                    'subtotal
                    sql &= "," & dtgDatos.Rows(x).Cells(28).Value.ToString.Replace(",", "")
                    'IVA
                    sql &= "," & dtgDatos.Rows(x).Cells(29).Value.ToString.Replace(",", "")
                    'total
                    sql &= "," & dtgDatos.Rows(x).Cells(30).Value.ToString.Replace(",", "")
                    'iestatus
                    sql &= ",1"
                    'estatusnomina
                    sql &= ",0"
                    'cuenta
                    sql &= ",'" & dtgDatos.Rows(x).Cells(4).Value & "'"
                    'infonavit
                    sql &= "," & dtgDatos.Rows(x).Cells(10).Value.ToString.Replace(",", "")
                    'departamento
                    sql &= ",'" & dtgDatos.Rows(x).Cells(5).Value & "'"
                    'incremento
                    sql &= ",0.00"
                    'Prima SA
                    sql &= "," & dtgDatos.Rows(x).Cells(11).Value.ToString.Replace(",", "")
                    'Prima Sindicato
                    sql &= "," & dtgDatos.Rows(x).Cells(17).Value.ToString.Replace(",", "")

                    'fAguinaldoSA
                    sql &= "," & dtgDatos.Rows(x).Cells(12).Value.ToString.Replace(",", "")

                    'fAguinaldoSin
                    sql &= "," & dtgDatos.Rows(x).Cells(18).Value.ToString.Replace(",", "")
                    'fVacacionesSA
                    sql &= ",0.00"
                    'fVacacionesSin
                    sql &= ",0.00"
                    'fIndemnizacionLeySA
                    sql &= ",0.00"
                    'fIndemnizacionLeySin
                    sql &= ",0.00"
                    'fPrimaAntSA
                    sql &= ",0.00"
                    'fPrimaAntSin
                    sql &= ",0.00"
                    'fPrimaAntSA2
                    sql &= ",0.00"
                    'fPrimaAntSin2
                    sql &= ",0.00"
                    'fImporteSA1 =CostoSocial2 grid
                    sql &= "," & dtgDatos.Rows(x).Cells(25).Value.ToString.Replace(",", "")
                    'fImporteSin1 = Importe sindicato Extra grid
                    sql &= "," & dtgDatos.Rows(x).Cells(19).Value.ToString.Replace(",", "")
                    'fImporteSA2 = Pensión Alimenticia Patrona Grid
                    sql &= "," & dtgDatos.Rows(x).Cells(9).Value.ToString.Replace(",", "")
                    'fImporteSin2 = comision Sindicato grid
                    sql &= "," & dtgDatos.Rows(x).Cells(27).Value.ToString.Replace(",", "")
                    'fImporteSA3
                    sql &= ",0.00"
                    'fImporteSin3 =Pension Alimenticia Sindicato grid
                    sql &= "," & dtgDatos.Rows(x).Cells(16).Value.ToString.Replace(",", "")
                    'fImporteSA4
                    sql &= ",0.00"
                    'fImporteSin4
                    sql &= ",0.00"

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If

                    sql = "update empleadosC set fSueldoOrd=" & dtgDatos.Rows(x).Cells(7).Value & ", fCosto =" & dtgDatos.Rows(x).Cells(22).Value
                    sql &= " where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If
                Next

                MessageBox.Show("Datos guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdcalcular_Click(sender As Object, e As EventArgs) Handles cmdcalcular.Click
        Try
            calcular()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub calcular()
        Dim sql As String

        Dim anios As Integer
        Dim sueldodiario As Double
        Dim dias As Integer
        Dim BanSueldoOrd As Boolean
        Dim BanPeriodo As Boolean
        Dim bandera As Boolean
        Dim Igualar0 As Boolean

        Dim sueldoord, neto, pensionpatrona, infonavit, descuento, prestamo, sindicato, pensionsindicato, primasin, totalsindicato, netopagar, primasa, aguinaldosa, aguinaldosin, Extra As Double
        Dim imss, costosocial1, costosocial2, comisionSA, comisionSindicato, subtotal, iva, subsidio As Double
        Try
            bandera = False

            For x As Integer = 0 To dtgDatos.Rows.Count - 1
                If chkAguinaldo.Checked Then
                    aguinaldosa = dtgDatos.Rows(x).Cells(12).Value
                    aguinaldosin = dtgDatos.Rows(x).Cells(18).Value
                    netopagar = aguinaldosa + aguinaldosin
                    dtgDatos.Rows(x).Cells(21).Value = Math.Round(netopagar, 2).ToString("##0.00")
                Else
                    sueldoord = dtgDatos.Rows(x).Cells(7).Value
                    neto = dtgDatos.Rows(x).Cells(8).Value
                    pensionpatrona = dtgDatos.Rows(x).Cells(9).Value
                    infonavit = dtgDatos.Rows(x).Cells(10).Value
                    primasa = dtgDatos.Rows(x).Cells(11).Value
                    aguinaldosa = dtgDatos.Rows(x).Cells(12).Value
                    descuento = dtgDatos.Rows(x).Cells(13).Value
                    prestamo = dtgDatos.Rows(x).Cells(14).Value
                    pensionsindicato = dtgDatos.Rows(x).Cells(16).Value
                    aguinaldosin = dtgDatos.Rows(x).Cells(18).Value

                    Extra = dtgDatos.Rows(x).Cells(19).Value

                    'verificamos igualar a 0

                    sql = "select * from InfoEmpleadoPeriodoContpaq where fkiIdEmpleado=" & dtgDatos.Rows(x).Cells(3).Value
                    sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue

                    Dim rwInfoEmpleado As DataRow() = nConsulta(sql)
                    If rwInfoEmpleado Is Nothing = False Then
                        If rwInfoEmpleado(0)("igualar0") = "1" Then
                            Igualar0 = True
                        Else
                            Igualar0 = False
                        End If
                    Else
                        Igualar0 = False
                    End If



                    'Verificamos la fecha para saber cuantos dias calcular

                    sql = "select *"
                    sql &= " from empleadosC"
                    sql &= " where fkiIdEmpresa=" & gIdEmpresa & " and iIdempleadoC=" & dtgDatos.Rows(x).Cells(3).Value

                    Dim rwDatosBanco As DataRow() = nConsulta(sql)


                    If rwDatosBanco Is Nothing = False Then

                        'If Double.Parse(rwDatosBanco(0)("fsueldoOrd")) > 0 Then
                        If Double.Parse(IIf(dtgDatos.Rows(x).Cells(7).Value = "", "0", dtgDatos.Rows(x).Cells(7).Value)) > 0 Then
                            BanSueldoOrd = True

                            'verificar el periodo para saber si queda entre el rango de fecha

                            'sueldodiario = Double.Parse(rwDatosBanco(0)("fsueldoOrd")) / diasperiodo
                            sueldodiario = Double.Parse(IIf(dtgDatos.Rows(x).Cells(7).Value = "", "0", dtgDatos.Rows(x).Cells(7).Value)) / diasperiodo
                            sql = "select * from periodos where iIdPeriodo= " & cboperiodo.SelectedValue
                            Dim rwPeriodo As DataRow() = nConsulta(sql)

                            If rwPeriodo Is Nothing = False Then
                                Dim FechaBuscar As Date = Date.Parse(rwDatosBanco(0)("dFechaSindicato"))
                                Dim FechaInicial As Date = Date.Parse(rwPeriodo(0)("dFechaInicio"))
                                Dim FechaFinal As Date = Date.Parse(rwPeriodo(0)("dFechaFin"))
                                Dim FechaAntiguedad As Date = Date.Parse(rwDatosBanco(0)("dFechaAntiguedad"))

                                If FechaBuscar.CompareTo(FechaInicial) > 0 And FechaBuscar.CompareTo(FechaFinal) <= 0 Then
                                    'Estamos dentro del rango 
                                    'Calculamos la prima

                                    dias = (DateDiff("y", FechaBuscar, FechaFinal)) + 1
                                    If Igualar0 Then
                                        sindicato = (sueldodiario * dias) - neto - pensionpatrona - infonavit - descuento - prestamo
                                    Else
                                        sindicato = (sueldodiario * dias) - neto - pensionpatrona - infonavit - descuento - prestamo + primasa + aguinaldosa
                                    End If

                                    BanPeriodo = True

                                ElseIf FechaBuscar.CompareTo(FechaInicial) <= 0 Then
                                    If Igualar0 Then
                                        sindicato = IIf(sueldoord - neto - pensionpatrona - infonavit - descuento - prestamo >= 0, sueldoord - neto - pensionpatrona - infonavit - descuento - prestamo, 0)
                                    Else
                                        sindicato = IIf(sueldoord - neto - pensionpatrona - infonavit - descuento - prestamo + primasa + aguinaldosa >= 0, sueldoord - neto - pensionpatrona - infonavit - descuento - prestamo + primasa + aguinaldosa, 0)
                                    End If


                                    BanPeriodo = False

                                End If


                            End If
                        Else
                            BanSueldoOrd = False

                            sindicato = 0

                        End If





                        'sindicato = IIf(sueldoord - neto - infonavit - descuento - prestamo + primasa >= 0, sueldoord - neto - infonavit - descuento - prestamo + primasa, 0)
                        dtgDatos.Rows(x).Cells(15).Value = Math.Round(sindicato, 2).ToString("##0.00")


                        primasin = dtgDatos.Rows(x).Cells(17).Value

                        totalsindicato = sindicato - pensionsindicato + primasin + aguinaldosin + Extra

                        dtgDatos.Rows(x).Cells(20).Value = Math.Round(totalsindicato, 2).ToString("##0.00")

                        If BanSueldoOrd Then
                            If BanPeriodo Then

                                If Igualar0 Then
                                    netopagar = (sueldodiario * dias) - pensionpatrona - infonavit - descuento - prestamo - pensionsindicato + primasin + aguinaldosin + Extra
                                Else
                                    netopagar = (sueldodiario * dias) - pensionpatrona - infonavit - descuento - prestamo - pensionsindicato + primasa + primasin + aguinaldosa + aguinaldosin + Extra
                                End If

                            Else
                                If Igualar0 Then
                                    netopagar = IIf(sueldoord - pensionpatrona - infonavit - descuento - prestamo - pensionsindicato + primasin + aguinaldosin + Extra >= 0, sueldoord - pensionpatrona - infonavit - descuento - prestamo - pensionsindicato + primasin + aguinaldosin + Extra, 0)
                                Else
                                    netopagar = IIf(sueldoord - pensionpatrona - infonavit - descuento - prestamo - pensionsindicato + primasa + primasin + aguinaldosa + aguinaldosin + Extra >= 0, sueldoord - pensionpatrona - infonavit - descuento - prestamo - pensionsindicato + primasa + primasin + aguinaldosa + aguinaldosin + Extra, 0)
                                End If

                            End If
                        Else
                            netopagar = neto

                        End If
                        'netopagar = IIf(sueldoord - infonavit - descuento - prestamo + primasa + primasin >= 0, sueldoord - infonavit - descuento - prestamo + primasa + primasin, 0)

                        dtgDatos.Rows(x).Cells(21).Value = Math.Round(netopagar, 2).ToString("##0.00")

                        'Calculamos comisiones



                        sql = "select * from IntClienteEmpresaContpaq where fkIdEmpresaC=" & gIdEmpresa

                        Dim rwClienteEmpresaContpaq As DataRow() = nConsulta(sql)

                        If rwClienteEmpresaContpaq Is Nothing = False Then
                            sql = "select * from clientes where iIdCliente=" & rwClienteEmpresaContpaq(0)("fkIdCliente")

                            Dim rwCliente As DataRow() = nConsulta(sql)
                            If rwCliente Is Nothing = False Then

                                If rwCliente(0)("iTipoPor") = "0" Then
                                    dtgDatos.Rows(x).Cells(26).Value = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * (Double.Parse(rwCliente(0)("porcentaje").ToString()) / 100), 2).ToString("#,###,##0.00")
                                    dtgDatos.Rows(x).Cells(27).Value = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * (Double.Parse(rwCliente(0)("porsindicato").ToString()) / 100), 2).ToString("#,###,##0.00")
                                Else
                                    dtgDatos.Rows(x).Cells(26).Value = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * (Double.Parse(rwCliente(0)("porcentaje").ToString()) / 100), 2).ToString("#,###,##0.00")
                                    dtgDatos.Rows(x).Cells(27).Value = Math.Round(Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * (Double.Parse(rwCliente(0)("porcentaje").ToString()) / 100), 2).ToString("#,###,##0.00")

                                End If


                            End If

                        Else
                            'No existe relación
                            If bandera = False Then
                                MessageBox.Show("No existe un cliente asignado para el calculo de la comisión. Asigne al cliente y vuelva a calcular la nomina", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                bandera = True
                            End If

                        End If

                        'Calculo subtotal = neto a pagar + imss + costo social + costo social 2 + comision sa + comision sindicato 
                        netopagar = Double.Parse(IIf(dtgDatos.Rows(x).Cells(21).Value = "", "0", dtgDatos.Rows(x).Cells(21).Value))
                        imss = Double.Parse(IIf(dtgDatos.Rows(x).Cells(22).Value = "", "0", dtgDatos.Rows(x).Cells(22).Value))
                        subsidio = Double.Parse(IIf(dtgDatos.Rows(x).Cells(23).Value = "", "0", dtgDatos.Rows(x).Cells(23).Value))
                        costosocial1 = Double.Parse(IIf(dtgDatos.Rows(x).Cells(24).Value = "", "0", dtgDatos.Rows(x).Cells(24).Value))
                        costosocial2 = Double.Parse(IIf(dtgDatos.Rows(x).Cells(25).Value = "", "0", dtgDatos.Rows(x).Cells(25).Value))
                        comisionSA = Double.Parse(IIf(dtgDatos.Rows(x).Cells(26).Value = "", "0", dtgDatos.Rows(x).Cells(26).Value))
                        comisionSindicato = Double.Parse(IIf(dtgDatos.Rows(x).Cells(25).Value = "", "0", dtgDatos.Rows(x).Cells(27).Value))

                        If calculosubsidio = 0 Then
                            subtotal = netopagar + imss + costosocial1 + costosocial2 + comisionSA + comisionSindicato
                        ElseIf calculosubsidio = 1 Then
                            subtotal = netopagar + subsidio + imss + costosocial1 + costosocial2 + comisionSA + comisionSindicato
                        ElseIf calculosubsidio = 2 Then
                            subtotal = netopagar - subsidio + imss + costosocial1 + costosocial2 + comisionSA + comisionSindicato
                        End If

                        'subtotal = netopagar + imss + costosocial1 + costosocial2 + comisionSA + comisionSindicato
                        dtgDatos.Rows(x).Cells(28).Value = Math.Round(subtotal, 2).ToString("#,###,##0.00")

                        'Calculo IVA
                        iva = Math.Round(subtotal * 0.16, 2)

                        dtgDatos.Rows(x).Cells(29).Value = iva.ToString("#,###,##0.00")


                        'Calculo total

                        dtgDatos.Rows(x).Cells(30).Value = Math.Round(subtotal + iva, 2).ToString("#,###,##0.00")

                    End If
                End If




            Next
            MessageBox.Show("Datos calculados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdguardarfinal_Click(sender As Object, e As EventArgs) Handles cmdguardarfinal.Click
        Try

            If gIdEmpresaAsignada = 0 Then
                MessageBox.Show("No existe una  Empresa asignada para la generación del fondeo. Asigne a la empresa y vuelva a guardar la nomina como final", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If gIdClienteAsignada = 0 Then
                MessageBox.Show("No existe un cliente asignado para el calculo de la comisión. Asigne al cliente, vuelva a calcular la nomina y despues guardela como final", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim SueldoSA, Sindicato, Infonavit, Pension, Imss, ComisionSA, ComisionSindicato, CostoSocial As Double
            Dim IdEstatusNominas As Integer
            Dim sql As String
            sql = "select fkiIdempleado,cCuenta,(cApellidoP + ' ' + cApellidoM + ' ' + empleadosC.cNombre) as nombre,"
            sql &= " NominaSindicato.fSueldoOrd ,fNeto,fDescuento,fSindicato,fSueldoNeto,"
            sql &= " fRentencionIMSS,fRetenciones,fCostoSocial,fComision,fSubtotal,fIVA,fTotal,cDepartamento as departamento,fInfonavit,fIncremento"
            sql &= " from NominaSindicato"
            sql &= " inner join empleadosC on NominaSindicato.fkiIdempleado= empleadosC.iIdEmpleadoC"
            sql &= " inner join departamentos on empleadosC.fkiIdDepartamento= departamentos.iIdDepartamento "
            sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue & " and iEstatusNomina=1 and NominaSindicato.iEstatus=1"
            sql &= " order by empleadosC.iOrigen,nombre"

            'sql = "EXEC getNominaXEmpresaXPeriodo " & gIdEmpresa & "," & cboperiodo.SelectedValue & ",1"

            Dim rwNominaGuardadaFinal As DataRow() = nConsulta(sql)

            If rwNominaGuardadaFinal Is Nothing = False Then
                MessageBox.Show("La nomina ya esta marcada como final, no  se pueden guardar cambios", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                sql = "delete from NominaSindicato"
                sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and NominaSindicato.fkiIdPeriodo=" & cboperiodo.SelectedValue
                sql &= " and NominaSindicato.iEstatusNomina=0 and NominaSindicato.iEstatus=1"

                If nExecute(sql) = False Then
                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'pnlProgreso.Visible = False
                    Exit Sub
                End If
                SueldoSA = 0
                Sindicato = 0
                Infonavit = 0
                Pension = 0
                Imss = 0
                ComisionSA = 0
                ComisionSindicato = 0
                CostoSocial = 0

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    sql = "EXEC [setNominaSindicatoInsertar] 0"
                    'periodo
                    sql &= "," & cboperiodo.SelectedValue
                    'idempresa
                    sql &= "," & gIdEmpresa
                    'idempleado
                    sql &= "," & dtgDatos.Rows(x).Cells(3).Value
                    'sueldoordinario
                    sql &= "," & dtgDatos.Rows(x).Cells(7).Value.ToString.Replace(",", "")
                    'neto
                    sql &= "," & dtgDatos.Rows(x).Cells(8).Value.ToString.Replace(",", "")
                    'descuento
                    sql &= "," & dtgDatos.Rows(x).Cells(13).Value.ToString.Replace(",", "")
                    'Prestamo
                    sql &= "," & dtgDatos.Rows(x).Cells(14).Value.ToString.Replace(",", "")
                    'sindicato
                    sql &= "," & dtgDatos.Rows(x).Cells(15).Value.ToString.Replace(",", "")
                    'sueldo neto
                    sql &= "," & dtgDatos.Rows(x).Cells(21).Value.ToString.Replace(",", "")
                    'retencion imss
                    sql &= "," & dtgDatos.Rows(x).Cells(22).Value.ToString.Replace(",", "")
                    'retenciones
                    sql &= "," & dtgDatos.Rows(x).Cells(23).Value.ToString.Replace(",", "")
                    'costosocial
                    sql &= "," & dtgDatos.Rows(x).Cells(24).Value.ToString.Replace(",", "")
                    'comision
                    sql &= "," & dtgDatos.Rows(x).Cells(26).Value.ToString.Replace(",", "")
                    'subtotal
                    sql &= "," & dtgDatos.Rows(x).Cells(28).Value.ToString.Replace(",", "")
                    'IVA
                    sql &= "," & dtgDatos.Rows(x).Cells(29).Value.ToString.Replace(",", "")
                    'total
                    sql &= "," & dtgDatos.Rows(x).Cells(30).Value.ToString.Replace(",", "")
                    'iestatus
                    sql &= ",1"
                    'estatusnomina
                    sql &= ",1"
                    'cuenta
                    sql &= ",'" & dtgDatos.Rows(x).Cells(4).Value & "'"
                    'infonavit
                    sql &= "," & dtgDatos.Rows(x).Cells(10).Value.ToString.Replace(",", "")
                    'departamento
                    sql &= ",'" & dtgDatos.Rows(x).Cells(5).Value & "'"
                    'incremento
                    sql &= ",0.00"
                    'Prima SA
                    sql &= "," & dtgDatos.Rows(x).Cells(11).Value.ToString.Replace(",", "")
                    'Prima Sindicato
                    sql &= "," & dtgDatos.Rows(x).Cells(17).Value.ToString.Replace(",", "")

                    'fAguinaldoSA
                    sql &= "," & dtgDatos.Rows(x).Cells(12).Value.ToString.Replace(",", "")

                    'fAguinaldoSin
                    sql &= "," & dtgDatos.Rows(x).Cells(18).Value.ToString.Replace(",", "")
                    'fVacacionesSA
                    sql &= ",0.00"
                    'fVacacionesSin
                    sql &= ",0.00"
                    'fIndemnizacionLeySA
                    sql &= ",0.00"
                    'fIndemnizacionLeySin
                    sql &= ",0.00"
                    'fPrimaAntSA
                    sql &= ",0.00"
                    'fPrimaAntSin
                    sql &= ",0.00"
                    'fPrimaAntSA2
                    sql &= ",0.00"
                    'fPrimaAntSin2
                    sql &= ",0.00"
                    'fImporteSA1 =CostoSocial2 grid
                    sql &= "," & dtgDatos.Rows(x).Cells(25).Value.ToString.Replace(",", "")
                    'fImporteSin1 = Importe sindicato Extra grid
                    sql &= "," & dtgDatos.Rows(x).Cells(19).Value.ToString.Replace(",", "")
                    'fImporteSA2 = Pensión Alimenticia Patrona Grid
                    sql &= "," & dtgDatos.Rows(x).Cells(9).Value.ToString.Replace(",", "")
                    'fImporteSin2 = comision Sindicato grid
                    sql &= "," & dtgDatos.Rows(x).Cells(27).Value.ToString.Replace(",", "")
                    'fImporteSA3
                    sql &= ",0.00"
                    'fImporteSin3 =Pension Alimenticia Sindicato grid
                    sql &= "," & dtgDatos.Rows(x).Cells(16).Value.ToString.Replace(",", "")
                    'fImporteSA4
                    sql &= ",0.00"
                    'fImporteSin4
                    sql &= ",0.00"

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If

                    sql = "update empleadosC set fSueldoOrd=" & dtgDatos.Rows(x).Cells(7).Value '& ", fCosto =" & dtgDatos.Rows(x).Cells(22).Value
                    sql &= " where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If

                    If Double.Parse(dtgDatos.Rows(x).Cells(14).Value) > 0 Then

                        sql = "select * from Prestamo where fkiIdEmpleado=" & dtgDatos.Rows(x).Cells(3).Value & " and iEstatus=1"

                        Dim rwPrestamos As DataRow() = nConsulta(sql)

                        If rwPrestamos Is Nothing = False Then
                            sql = "EXEC setPagoPrestamoInsertar 0"
                            sql &= "," & rwPrestamos(0)("iIdPrestamo").ToString
                            sql &= "," & dtgDatos.Rows(x).Cells(14).Value
                            sql &= ",'" & Date.Now.ToShortDateString
                            sql &= "',1"
                            sql &= "," & cboperiodo.SelectedValue
                            If nExecute(sql) = False Then
                                MessageBox.Show("Ocurrio un error insertar pago prestamo ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub
                            End If

                        Else
                            'hay que insertar todo
                        End If

                        'Verificamos el prestamo ya se termino en ese caso ponemos el prestamos en estatus = 0



                        If rwPrestamos Is Nothing = False Then
                            sql = "select isnull(sum(monto),0) as monto from pagoprestamo where fkiIdPrestamo=" & rwPrestamos(0)("iIdPrestamo").ToString
                            Dim rwMontoPrestamo As DataRow() = nConsulta(sql)
                            If rwMontoPrestamo Is Nothing = False Then

                                If Double.Parse(rwMontoPrestamo(0)("monto").ToString) >= Double.Parse(rwPrestamos(0)("montototal").ToString) Then
                                    'Actualizamos el status
                                    sql = "update prestamo set iEstatus=0 where iIdPrestamo=" & rwPrestamos(0)("iIdPrestamo").ToString
                                    If nExecute(sql) = False Then
                                        MessageBox.Show("Ocurrio un error insertar pago prestamo ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        'pnlProgreso.Visible = False
                                        Exit Sub
                                    End If
                                End If


                            End If
                        End If


                    End If
                Next

                MessageBox.Show("Datos guardados y marcados como final", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Insertar fondeo

                MessageBox.Show("Se generara el fondeo de la nomina, para lo cual se le pediaran algunos datos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                'insertar el fondeo y preguntar el estatus del pago, asi como tabmien si va a agregar los importes del banco donde se hizo el deposito
                ' y los bancos donde quiere el fondeo


                'Dim resultado As Integer = MessageBox.Show("¿Editar solo colores?", "Pregunta", MessageBoxButtons.YesNo)
                'If resultado = DialogResult.Yes Then
                '    EditarColores(lsvLista.SelectedItems(0).Tag)
                'ElseIf resultado = DialogResult.No Then
                '    EditarFactura(lsvLista.SelectedItems(0).Tag)
                'End If

                Dim Forma As New frmEstatusNomina
                If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                    IdEstatusNominas = Forma.gIdEstatusNomina

                Else
                    IdEstatusNominas = 0
                End If

                sql = "EXEC setFondeoPatronaInsertar 0"
                sql &= "," & gIdClienteAsignada
                sql &= "," & gIdEmpresaAsignada
                sql &= "," & cboperiodo.SelectedValue
                sql &= "," & SueldoSA
                sql &= "," & Sindicato
                sql &= "," & Infonavit
                sql &= "," & Pension
                sql &= "," & Imss
                sql &= "," & ComisionSA
                sql &= "," & ComisionSindicato
                sql &= "," & CostoSocial
                sql &= "," & IdEstatusNominas  'iEstatusNomina pendiente, pagado, financiamiento
                sql &= ",1" 'iTipoNomina Sa + Sindicato u otra
                sql &= ",'" & Date.Parse(gdFechaFin).ToShortDateString & "'"
                sql &= ",0" 'Id en caso de que sea subida al kiosko de martin
                sql &= ",1" 'iEstatus as general
                sql &= ",0" 'IEstatusFondeo  -Se refiere a que si ya esta fondeado o no


                If nExecute(sql) = False Then
                    MessageBox.Show("Ocurrio un error insertar el fondeo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'pnlProgreso.Visible = False
                    Exit Sub
                End If
                MessageBox.Show("Fondeo guardado correctamente. Si necesita ver el fondeo lo puede hacer en la opción: Menú --> Tesoreria --> Fondeo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'preguntamos si ya tiene los datos de los bancos


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboperiodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboperiodo.SelectedIndexChanged
        Try
            dtgDatos.DataSource = ""
            dtgDatos.Columns.Clear()
            Dim x As Integer = InStr(cboperiodo.Text, "-")
            gdFechaFin = cboperiodo.Text.Substring(x)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdreciboss_Click(sender As Object, e As EventArgs) Handles cmdreciboss.Click
        Try
            Dim Forma As New frmSindicato

            Dim iTipo As Integer
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

                If dtgDatos.Rows.Count > 0 Then
                    Dim mensaje As String


                    pnlProgreso.Visible = True
                    pnlCatalogo.Enabled = False
                    Application.DoEvents()


                    Dim IdProducto As Long
                    Dim i As Integer = 0
                    Dim conta As Integer = 0


                    pgbProgreso.Minimum = 0
                    pgbProgreso.Value = 0
                    pgbProgreso.Maximum = dtgDatos.Rows.Count

                    Dim forma2 As New frmRecibosLupita


                    forma2.dsReporte.Tables.Add("Tabla")
                    forma2.opcion = Forma.gIdTipo

                    forma2.dsReporte.Tables("Tabla").Columns.Add("nombre")
                    forma2.dsReporte.Tables("Tabla").Columns.Add("cantidad")
                    forma2.dsReporte.Tables("Tabla").Columns.Add("letra")
                    forma2.dsReporte.Tables("Tabla").Columns.Add("Fecha")
                    forma2.dsReporte.Tables("Tabla").Columns.Add("Lugar")

                    For x As Integer = 0 To dtgDatos.Rows.Count - 1

                        If dtgDatos.Rows(x).Cells(0).Value Then

                            If chkAguinaldo.Checked Then
                                If CDbl(IIf(dtgDatos.Rows(x).Cells(18).Value = "", "0", dtgDatos.Rows(x).Cells(18).Value)) > 0 Then
                                    Dim fila As DataRow = forma2.dsReporte.Tables("Tabla").NewRow
                                    fila.Item("nombre") = Trim(dtgDatos.Rows(x).Cells(6).Value)
                                    fila.Item("cantidad") = Math.Round(CDbl(dtgDatos.Rows(x).Cells(18).Value), 2).ToString("##,###,###.00")
                                    fila.Item("letra") = ImprimeLetra(Math.Round(CDbl(dtgDatos.Rows(x).Cells(18).Value), 2))

                                    fila.Item("fecha") = Forma.gfecha

                                    fila.Item("Lugar") = Forma.gExpedicion



                                    forma2.dsReporte.Tables("Tabla").Rows.Add(fila)
                                End If
                            Else
                                If CDbl(IIf(dtgDatos.Rows(x).Cells(20).Value = "", "0", dtgDatos.Rows(x).Cells(20).Value)) > 0 Then
                                    Dim fila As DataRow = forma2.dsReporte.Tables("Tabla").NewRow
                                    fila.Item("nombre") = Trim(dtgDatos.Rows(x).Cells(6).Value)
                                    fila.Item("cantidad") = Math.Round(CDbl(dtgDatos.Rows(x).Cells(20).Value), 2).ToString("##,###,###.00")
                                    fila.Item("letra") = ImprimeLetra(Math.Round(CDbl(dtgDatos.Rows(x).Cells(20).Value), 2))

                                    fila.Item("fecha") = Forma.gfecha

                                    fila.Item("Lugar") = Forma.gExpedicion



                                    forma2.dsReporte.Tables("Tabla").Rows.Add(fila)
                                End If

                            End If






                            pgbProgreso.Value += 1
                            Application.DoEvents()
                        End If


                        'mandar el reporte
                    Next


                    'Dim Archivo As String = IO.Path.GetTempFileName.Replace(".tmp", ".xml")
                    'forma2.dsReporte.WriteXml(Archivo, XmlWriteMode.WriteSchema)

                    forma2.ShowDialog()

                    pnlProgreso.Visible = False
                    pnlCatalogo.Enabled = True

                Else
                    MessageBox.Show("No hay registros para procesar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDatos.CellContentClick
        If e.RowIndex = -1 And e.ColumnIndex = 0 Then
            Return
        Else
            'dtgDatos.Rows(e.RowIndex).Selected = True
        End If


    End Sub



    Private Sub dtgDatos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgDatos.KeyPress
        Try

            SoloNumero.NumeroDec(e, sender)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdexcel_Click(sender As Object, e As EventArgs) Handles cmdexcel.Click
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


            If chkgrupo.Checked Then


            Else


            End If


            'Dim rwFilas As DataRow() = nConsulta(SQL)

            If dtgDatos.Rows.Count > 0 Then
                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("Nomina")
                Dim hoja2 As IXLWorksheet = libro.Worksheets.Add("Resumen pago")

                hoja.Column("B").Width = 13
                hoja.Column("C").Width = 40
                hoja.Column("D").Width = 40
                hoja.Column("E").Width = 13
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
                hoja.Column("Q").Width = 13
                hoja.Column("R").Width = 13
                hoja.Column("S").Width = 13
                hoja.Column("T").Width = 13
                hoja.Column("U").Width = 13
                hoja.Cell(1, 2).Value = "CARATULA DE NOMINA"
                hoja.Range(1, 2, 1, 2).Style.Font.SetBold(True)
                hoja.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                hoja.Cell(3, 2).Value = "PERIODO: " & cboperiodo.Text
                hoja.Range(3, 2, 3, 2).Style.Font.SetBold(True)

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja.Range(4, 2, 4, 26).Style.Font.FontSize = 10
                hoja.Range(4, 2, 4, 26).Style.Font.SetBold(True)
                hoja.Range(4, 2, 4, 26).Style.Alignment.WrapText = True
                hoja.Range(4, 2, 4, 26).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(4, 1, 4, 26).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(4, 2, 4, 26).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(4, 2, 4, 26).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                hoja.Range(5, 5, 1000, 26).Style.NumberFormat.NumberFormatId = 4

                'Format = ("$ #,###,##0.00")
                'hoja.Cell(4, 1).Value = "Num"
                hoja.Cell(4, 2).Value = "Consecutivo"
                hoja.Cell(4, 3).Value = "Departamento"
                hoja.Cell(4, 4).Value = "Nombre"
                hoja.Cell(4, 5).Value = "Sueldo"
                hoja.Cell(4, 6).Value = "Neto_SA"
                hoja.Cell(4, 7).Value = "Prima_SA"
                hoja.Cell(4, 8).Value = "Aguinaldo_SA"
                hoja.Cell(4, 9).Value = "(-) Pensión Alim. Pat."
                hoja.Cell(4, 10).Value = "(-)Imss"
                hoja.Cell(4, 11).Value = "(-)Infonavit"
                hoja.Cell(4, 12).Value = "(-)Descuento"
                hoja.Cell(4, 13).Value = "(-)Prestamo"
                hoja.Cell(4, 14).Value = "Sindicato"
                hoja.Cell(4, 15).Value = "(-) Pensión Alim. Sindic."
                hoja.Cell(4, 16).Value = "Prima_Sin"
                hoja.Cell(4, 17).Value = "Aguinaldo_Sin"
                hoja.Cell(4, 18).Value = "Extra"
                hoja.Cell(4, 19).Value = "Neto a pagar"
                hoja.Cell(4, 20).Value = "Imss"
                hoja.Cell(4, 21).Value = "Costo Social"
                hoja.Cell(4, 22).Value = "Comisión SA"
                hoja.Cell(4, 23).Value = "Comisión Sindicato"
                hoja.Cell(4, 24).Value = "Subtotal"
                hoja.Cell(4, 25).Value = "IVA"
                hoja.Cell(4, 26).Value = "Total"

                filaExcel = 5
                contadorfacturas = 1

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    'Consecutivo
                    hoja.Cell(filaExcel + x, 2).Value = x + 1
                    'Departamento
                    hoja.Cell(filaExcel + x, 3).Value = dtgDatos.Rows(x).Cells(5).Value
                    'Nombre
                    hoja.Cell(filaExcel + x, 4).Value = dtgDatos.Rows(x).Cells(6).Value
                    'Sueldo
                    hoja.Cell(filaExcel + x, 5).Value = dtgDatos.Rows(x).Cells(7).Value
                    'Neto SA
                    hoja.Cell(filaExcel + x, 6).Value = dtgDatos.Rows(x).Cells(8).Value
                    'Prima_SA
                    hoja.Cell(filaExcel + x, 7).Value = dtgDatos.Rows(x).Cells(11).Value
                    'Aguinaldo_SA
                    hoja.Cell(filaExcel + x, 8).Value = dtgDatos.Rows(x).Cells(12).Value
                    '(-) Pensión Alim. Pat.
                    hoja.Cell(filaExcel + x, 9).Value = dtgDatos.Rows(x).Cells(9).Value

                    'Imss
                    'Obtener el imss de los movimientos con el idperiodo del combo

                    SQL = "select * from movimientos where fkiIdPeriodo=" & cboperiodo.SelectedValue
                    SQL &= " and fkiIdEmpleado=" & dtgDatos.Rows(x).Cells(3).Value
                    SQL &= " and fkiIdConceptoPago=36"

                    Dim rwImss As DataRow() = nConsulta(SQL)

                    If rwImss Is Nothing = False Then

                        hoja.Cell(filaExcel + x, 10).Value = rwImss(0)("fImporteTotal").ToString

                        hoja.Cell(filaExcel + x, 20).Value = rwImss(0)("fImporteTotal").ToString

                    End If



                    'Infonavit
                    hoja.Cell(filaExcel + x, 11).Value = dtgDatos.Rows(x).Cells(10).Value
                    'Descuento
                    hoja.Cell(filaExcel + x, 12).Value = dtgDatos.Rows(x).Cells(13).Value
                    'Prestamo
                    hoja.Cell(filaExcel + x, 13).Value = dtgDatos.Rows(x).Cells(14).Value
                    'Sindicato
                    hoja.Cell(filaExcel + x, 14).Value = dtgDatos.Rows(x).Cells(20).Value
                    '(-) Pensión Alim. Sindic.
                    hoja.Cell(filaExcel + x, 15).Value = dtgDatos.Rows(x).Cells(16).Value
                    'Prima_Sin
                    hoja.Cell(filaExcel + x, 16).Value = dtgDatos.Rows(x).Cells(17).Value
                    'Aguinaldo_Sin
                    hoja.Cell(filaExcel + x, 17).Value = dtgDatos.Rows(x).Cells(18).Value
                    'Extra
                    hoja.Cell(filaExcel + x, 18).Value = dtgDatos.Rows(x).Cells(19).Value
                    'Neto a pagar
                    hoja.Cell(filaExcel + x, 19).Value = dtgDatos.Rows(x).Cells(21).Value

                    'Costo Social
                    hoja.Cell(filaExcel + x, 21).Value = dtgDatos.Rows(x).Cells(24).Value
                    'Comision Sa
                    hoja.Cell(filaExcel + x, 22).Value = dtgDatos.Rows(x).Cells(26).Value
                    'Comision Sindicato
                    hoja.Cell(filaExcel + x, 23).Value = dtgDatos.Rows(x).Cells(27).Value
                    'Subtotal
                    hoja.Cell(filaExcel + x, 24).Value = dtgDatos.Rows(x).Cells(28).Value
                    'IVA
                    hoja.Cell(filaExcel + x, 25).Value = dtgDatos.Rows(x).Cells(29).Value
                    'Total
                    hoja.Cell(filaExcel + x, 26).Value = dtgDatos.Rows(x).Cells(30).Value

                Next


                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 5).FormulaA1 = "=SUM(E" & filaExcel & ":E" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 6).FormulaA1 = "=SUM(F" & filaExcel & ":F" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 7).FormulaA1 = "=SUM(G" & filaExcel & ":G" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 8).FormulaA1 = "=SUM(H" & filaExcel & ":H" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 9).FormulaA1 = "=SUM(I" & filaExcel & ":I" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 10).FormulaA1 = "=SUM(J" & filaExcel & ":J" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 11).FormulaA1 = "=SUM(K" & filaExcel & ":K" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 12).FormulaA1 = "=SUM(L" & filaExcel & ":L" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 13).FormulaA1 = "=SUM(M" & filaExcel & ":M" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 14).FormulaA1 = "=SUM(N" & filaExcel & ":N" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 15).FormulaA1 = "=SUM(O" & filaExcel & ":O" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 16).FormulaA1 = "=SUM(P" & filaExcel & ":P" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 17).FormulaA1 = "=SUM(Q" & filaExcel & ":Q" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 18).FormulaA1 = "=SUM(R" & filaExcel & ":R" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 19).FormulaA1 = "=SUM(S" & filaExcel & ":S" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 20).FormulaA1 = "=SUM(T" & filaExcel & ":T" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 21).FormulaA1 = "=SUM(U" & filaExcel & ":U" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 22).FormulaA1 = "=SUM(V" & filaExcel & ":V" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 23).FormulaA1 = "=SUM(W" & filaExcel & ":W" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 24).FormulaA1 = "=SUM(X" & filaExcel & ":X" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 25).FormulaA1 = "=SUM(Y" & filaExcel & ":Y" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja.Cell(filaExcel + dtgDatos.Rows.Count, 26).FormulaA1 = "=SUM(Z" & filaExcel & ":Z" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                


                hoja.Range(filaExcel + dtgDatos.Rows.Count, 5, filaExcel + dtgDatos.Rows.Count, 27).Style.Font.SetBold(True)


                '##### HOJA NUMERO 2 RESUMEN PAGO

                hoja2.Column("B").Width = 40
                hoja2.Column("C").Width = 20
                hoja2.Column("D").Width = 20
                hoja2.Column("E").Width = 20
                hoja2.Column("F").Width = 20
                hoja2.Column("G").Width = 20
                hoja2.Column("H").Width = 20
                hoja2.Column("I").Width = 20
                hoja2.Column("J").Width = 20
                
                hoja2.Cell(1, 2).Value = "RESUMEN DE PAGO"
                hoja2.Range(1, 2, 1, 2).Style.Font.SetBold(True)
                hoja2.Cell(2, 2).Value = "Fecha:" & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString
                hoja2.Cell(3, 2).Value = "PERIODO: " & cboperiodo.Text
                hoja2.Range(3, 2, 3, 2).Style.Font.SetBold(True)

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja2.Range(4, 2, 4, 10).Style.Font.FontSize = 10
                hoja2.Range(4, 2, 4, 10).Style.Font.SetBold(True)
                hoja2.Range(4, 2, 4, 10).Style.Alignment.WrapText = True
                hoja2.Range(4, 2, 4, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja2.Range(4, 1, 4, 10).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja2.Range(4, 2, 4, 10).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja2.Range(4, 2, 4, 10).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                hoja2.Range(5, 5, 1000, 26).Style.NumberFormat.NumberFormatId = 49
                hoja2.Range(5, 6, 1000, 6).Style.NumberFormat.NumberFormatId = 4
                hoja2.Range(5, 10, 1000, 10).Style.NumberFormat.NumberFormatId = 4

                'Format = ("$ #,###,##0.00")
                'hoja.Cell(4, 1).Value = "Num"
                hoja2.Cell(4, 2).Value = "Nombre"
                hoja2.Cell(4, 3).Value = "Banco"
                hoja2.Cell(4, 4).Value = "Clabe"
                hoja2.Cell(4, 5).Value = "Cuenta"
                hoja2.Cell(4, 6).Value = "Patrona"
                hoja2.Cell(4, 7).Value = "Banco"
                hoja2.Cell(4, 8).Value = "Clabe"
                hoja2.Cell(4, 9).Value = "Cuenta"
                hoja2.Cell(4, 10).Value = "Sindicato"
               

                filaExcel = 5
                contadorfacturas = 1

                For x As Integer = 0 To dtgDatos.Rows.Count - 1

                    

                    SQL = "select iIdempleadoC,NumCuenta,Clabe,cuenta2,clabe2,fkiIdBanco,bancos.cBanco as banco1,fkiIdBanco2,bancos2.cBanco as banco2"
                    SQL &= " from (empleadosC"
                    SQL &= " inner join bancos on empleadosC.fkiIdBanco= bancos.iIdBanco)"
                    SQL &= " inner join (select iIdBanco,cBanco from bancos) as bancos2 on empleadosC.fkiIdBanco2= bancos2.iIdBanco"
                    SQL &= " where fkiIdEmpresa=" & gIdEmpresa & " and iIdempleadoC=" & dtgDatos.Rows(x).Cells(3).Value
                    Dim rwEmpleado As DataRow() = nConsulta(SQL)

                    If rwEmpleado Is Nothing = False Then

                        'Nombre
                        hoja2.Cell(filaExcel + x, 2).Value = dtgDatos.Rows(x).Cells(6).Value
                        'Banco
                        hoja2.Cell(filaExcel + x, 3).Value = rwEmpleado(0)("banco1").ToString
                        'Clabe
                        hoja2.Cell(filaExcel + x, 4).Value = If(rwEmpleado(0)("Clabe").ToString = "", "", "'" & rwEmpleado(0)("Clabe").ToString)
                        'Cuenta
                        hoja2.Cell(filaExcel + x, 5).Value = If(rwEmpleado(0)("NumCuenta").ToString = "", "", "'" & rwEmpleado(0)("NumCuenta").ToString)
                        'Patrona
                        hoja2.Cell(filaExcel + x, 6).Value = dtgDatos.Rows(x).Cells(8).Value
                        'Banco
                        hoja2.Cell(filaExcel + x, 7).Value = rwEmpleado(0)("banco2").ToString
                        'Clabe
                        hoja2.Cell(filaExcel + x, 8).Value = If(rwEmpleado(0)("Clabe2").ToString = "", "", "'" & rwEmpleado(0)("Clabe2").ToString)
                        'Cuenta
                        hoja2.Cell(filaExcel + x, 9).Value = If(rwEmpleado(0)("cuenta2").ToString = "", "", "'" & rwEmpleado(0)("cuenta2").ToString)
                        'Sindicato
                        hoja2.Cell(filaExcel + x, 10).Value = dtgDatos.Rows(x).Cells(20).Value

                    End If

                    

                Next


                hoja2.Cell(filaExcel + dtgDatos.Rows.Count, 6).FormulaA1 = "=SUM(F" & filaExcel & ":F" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                
                hoja2.Cell(filaExcel + dtgDatos.Rows.Count, 10).FormulaA1 = "=SUM(J" & filaExcel & ":J" & filaExcel + dtgDatos.Rows.Count - 1 & ")"
                hoja2.Range(filaExcel + dtgDatos.Rows.Count, 6, filaExcel + dtgDatos.Rows.Count, 10).Style.Font.SetBold(True)

                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Resumen Nomina"
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

    Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
        Try
            'Agregar incidencias y prestamos
            Dim Forma As New frmIncidencia
            Forma.giEmpresa = gIdEmpresa
            Forma.giPeriodo = cboperiodo.SelectedValue
            Forma.ShowDialog()

            If Forma.gValor = "1" Then
                dtgDatos.Columns.Clear()
                llenargrid()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdincidencias_Click(sender As Object, e As EventArgs) Handles cmdincidencias.Click
        Try
            Dim filaExcel As Integer = 5
            Dim dialogo As New SaveFileDialog()
            Dim Alter As Boolean = False


            Dim sql As String

            'sql = "EXEC getNominaXEmpresaXPeriodo " & gIdEmpresa & "," & cboperiodo.SelectedValue & ",1"
            Dim consecutivo As Integer = 1

            'Dim rwDatosPeriodo As DataRow() = nConsulta(sql)


            If dtgDatos.Rows.Count > 0 Then


                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("Nomina")

                hoja.Column("A").Width = 30
                hoja.Column("B").Width = 30
                hoja.Column("C").Width = 30
                hoja.Column("D").Width = 25
                hoja.Column("E").Width = 25
                hoja.Column("F").Width = 25
                hoja.Column("G").Width = 25
                hoja.Column("H").Width = 25
                hoja.Column("I").Width = 25
                hoja.Column("J").Width = 25


                'hoja.Cell(2, 2).Value = "Fecha:"
                'hoja.Cell(2, 3).Value = Date.Now.ToShortDateString()

                'hoja.Cell(3, 2).Value = ":"
                'hoja.Cell(3, 3).Value = ""

                hoja.Range(1, 1, 1, 10).Style.Font.FontSize = 10
                hoja.Range(1, 1, 1, 10).Style.Font.SetBold(True)
                hoja.Range(1, 1, 1, 10).Style.Alignment.WrapText = True
                hoja.Range(1, 1, 1, 10).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(1, 1, 1, 10).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(1, 1, 1, 10).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(1, 1, 1, 10).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")


                hoja.Cell(1, 1).Value = "Id Empleado"
                hoja.Cell(1, 2).Value = "RFC"
                hoja.Cell(1, 3).Value = "Nombre"
                hoja.Cell(1, 4).Value = "Sueldo Ordinario"
                hoja.Cell(1, 5).Value = "Dias Descuento"
                hoja.Cell(1, 6).Value = "Prestamo Total"
                hoja.Cell(1, 7).Value = "Descuento x Nomina"
                hoja.Cell(1, 8).Value = "ID Banco"
                hoja.Cell(1, 9).Value = "Num Cuenta"
                hoja.Cell(1, 10).Value = "Clabe Interbancaria"

                filaExcel = 1

                'Dim dt As DataTable
                'dt = rwDatosPeriodo.CopyToDataTable()

                For x As Integer = 0 To dtgDatos.Rows.Count - 1
                    filaExcel = filaExcel + 1



                    hoja.Cell(filaExcel, 1).Value = dtgDatos.Rows(x).Cells(3).Value
                    'Buscamos el RFC del cliente
                    sql = "select * from empleadosC where iIdEmpleadoC=" & dtgDatos.Rows(x).Cells(3).Value
                    Dim rwEmpleado As DataRow() = nConsulta(sql)

                    If rwEmpleado Is Nothing = False Then
                        hoja.Cell(filaExcel, 2).Value = rwEmpleado(0)("cRFC")

                    End If

                    hoja.Cell(filaExcel, 3).Value = dtgDatos.Rows(x).Cells(6).Value
                    'hoja.Cell(filaExcel, 3).Style.NumberFormat.SetFormat("###,###,##0.#0")
                    'hoja.Cell(filaExcel, 4).Value = Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0")
                    'hoja.Cell(filaExcel, 5).Style.NumberFormat.SetFormat("###,###,##0.#0")






                Next

                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Archivo incidencias periodo-" & cboperiodo.SelectedText
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

    Private Sub cmdreiniciar_Click(sender As Object, e As EventArgs) Handles cmdreiniciar.Click
        Try
            Dim sql As String
            Dim resultado As Integer = MessageBox.Show("¿Desea reiniciar la nomina?", "Pregunta", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then

                sql = "select fkiIdempleado,cCuenta,(cApellidoP + ' ' + cApellidoM + ' ' + empleadosC.cNombre) as nombre,"
                sql &= " NominaSindicato.fSueldoOrd ,fNeto,fDescuento,fSindicato,fSueldoNeto,"
                sql &= " fRentencionIMSS,fRetenciones,fCostoSocial,fComision,fSubtotal,fIVA,fTotal,cDepartamento as departamento,fInfonavit,fIncremento"
                sql &= " from NominaSindicato"
                sql &= " inner join empleadosC on NominaSindicato.fkiIdempleado= empleadosC.iIdEmpleadoC"
                sql &= " inner join departamentos on empleadosC.fkiIdDepartamento= departamentos.iIdDepartamento "
                sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and fkiIdPeriodo=" & cboperiodo.SelectedValue & " and iEstatusNomina=1 and NominaSindicato.iEstatus=1"
                sql &= " order by empleadosC.iOrigen,nombre"

                'sql = "EXEC getNominaXEmpresaXPeriodo " & gIdEmpresa & "," & cboperiodo.SelectedValue & ",1"

                Dim rwNominaGuardadaFinal As DataRow() = nConsulta(sql)

                If rwNominaGuardadaFinal Is Nothing = False Then
                    MessageBox.Show("La nomina ya esta marcada como final, no  se pueden guardar cambios", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    sql = "delete from NominaSindicato"
                    sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and NominaSindicato.fkiIdPeriodo=" & cboperiodo.SelectedValue


                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If
                    MessageBox.Show("Nomina reiniciada correctamente, vuelva a cargar los datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dtgDatos.DataSource = ""
                End If



            End If




        Catch ex As Exception

        End Try


    End Sub

    Private Sub tsbIEmpleados_Click(sender As Object, e As EventArgs) Handles tsbIEmpleados.Click
        Try
            Dim Forma As New frmEmpleados
            Forma.gIdEmpresa = gIdEmpresa
            Forma.gIdPeriodo = cboperiodo.SelectedValue

            Forma.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgDatos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDatos.CellClick
        If e.ColumnIndex = 0 Then
            dtgDatos.Rows(e.RowIndex).Cells(0).Value = Not dtgDatos.Rows(e.RowIndex).Cells(0).Value
        End If

    End Sub

    Private Sub dtgDatos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDatos.CellEnter
        'MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub TextboxNumeric_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim nonNumberEntered As Boolean

        nonNumberEntered = True

        If (Convert.ToInt32(e.KeyChar) >= 48 AndAlso Convert.ToInt32(e.KeyChar) <= 57) OrElse Convert.ToInt32(e.KeyChar) = 8 OrElse Convert.ToInt32(e.KeyChar) = 46 Then
            'If Convert.ToInt32(e.KeyChar) = 46 Then
            '    'verificamos cuantos puntos hay

            'Else

            'End If
            nonNumberEntered = False
        End If

        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub dtgDatos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgDatos.CellEndEdit
        If Not m_currentControl Is Nothing Then
            RemoveHandler m_currentControl.KeyPress, AddressOf TextboxNumeric_KeyPress
        End If
    End Sub

    Private Sub dtgDatos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dtgDatos.EditingControlShowing
        Dim columna As Integer
        m_currentControl = Nothing
        columna = CInt(DirectCast(sender, System.Windows.Forms.DataGridView).CurrentCell.ColumnIndex)
        If columna = 7 Or columna = 10 Or columna = 12 Or columna = 13 Or columna = 14 Or columna = 15 Then
            AddHandler e.Control.KeyPress, AddressOf TextboxNumeric_KeyPress
            m_currentControl = e.Control
        End If
    End Sub

    Private Sub dtgDatos_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgDatos.ColumnHeaderMouseClick
        Try
            Dim newColumn As DataGridViewColumn = dtgDatos.Columns(e.ColumnIndex)

            If e.ColumnIndex = 0 Then
                dtgDatos.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        

    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        For x As Integer = 0 To dtgDatos.Rows.Count - 1
            dtgDatos.Rows(x).Cells(0).Value = Not dtgDatos.Rows(x).Cells(0).Value
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub

    Private Sub cmdlayouts_Click(sender As Object, e As EventArgs) Handles cmdlayouts.Click
        Dim dialogo As New SaveFileDialog()
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        Dim validar As Boolean
        Dim numcuenta As String
        Dim nombre As String
        Dim PathArchivo As String
        Dim contador As Integer
        Dim sql As String

        Try


            If dtgDatos.Rows.Count > 0 Then

                validar = False
                Dim iTipo As Integer

                Select Case cbobancos.SelectedValue.ToString()
                    Case "4"


                        dialogo.DefaultExt = "*.txt"
                        dialogo.FileName = "Layout Bancomer"
                        dialogo.Filter = "Archivos de texto (*.txt)|*.txt"
                        dialogo.ShowDialog()
                        PathArchivo = ""
                        PathArchivo = dialogo.FileName

                        If PathArchivo <> "" Then
                            strStreamW = File.Create(PathArchivo) ' lo creamos
                            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                            contador = 1
                            sRenglon = ""
                            For x As Integer = 0 To dtgDatos.Rows.Count - 1
                                If dtgDatos.Rows(x).Cells(0).Value Then
                                    sRenglon = contador.ToString("000000000")
                                    sRenglon &= "                "
                                    sRenglon &= "99"

                                    'BANCO RECEPTOR 

                                    numcuenta = ""

                                    sql = "select * from EmpleadosC where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value
                                    Dim rwDatosCuenta As DataRow() = nConsulta(sql)

                                    If rwDatosCuenta Is Nothing = False Then
                                        If chkSindicato.Checked Then
                                            numcuenta = IIf(rwDatosCuenta(0)("cuenta2") = "", "0000000000", rwDatosCuenta(0)("cuenta2"))
                                        Else
                                            numcuenta = dtgDatos.Rows(x).Cells(4).Value
                                        End If
                                    End If


                                    'numcuenta = dtgDatos.Rows(x).Cells(3).Value

                                    For y As Integer = numcuenta.Length To 19
                                        numcuenta &= " "
                                    Next
                                    sRenglon &= numcuenta
                                    'Neto SA 
                                    If chkSindicato.Checked Then
                                        If chkAguinaldo.Checked Then
                                            sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(18).Value) * 100).ToString("000000000000000")
                                        Else
                                            sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * 100).ToString("000000000000000")
                                        End If

                                    Else
                                        If chkAguinaldo.Checked Then
                                            sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(12).Value) * 100).ToString("000000000000000")
                                        Else
                                            sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * 100).ToString("000000000000000")
                                        End If

                                    End If


                                    nombre = dtgDatos.Rows(x).Cells(6).Value
                                    If nombre.Length < 41 Then
                                        For y As Integer = nombre.Length To 39
                                            nombre &= " "
                                        Next

                                    Else
                                        nombre = nombre.Substring(0, 40)
                                    End If

                                    nombre = RemoverBasura(nombre)
                                    sRenglon &= nombre
                                    sRenglon &= "001"
                                    sRenglon &= "001"


                                    strStreamWriter.WriteLine(sRenglon)
                                    contador = contador + 1
                                End If


                            Next
                            'escribimos en el archivo



                            strStreamWriter.Close() ' cerramos

                            MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


                        End If



                    Case "1"
                        If chkinter.Checked Then
                            Dim Forma As New frmbanamex
                            Forma.gIdBanco = cbobancos.SelectedValue
                            Forma.gIdEmpresa = gIdEmpresa
                            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                                'Buscamos datos
                                sql = "select * from DatosBanco where iIdDatosBanco=" & Forma.gIdDatosBancos
                                Dim rwDatos As DataRow() = nConsulta(sql)

                                If rwDatos Is Nothing = False Then


                                    Dim Secuencial As Integer = Integer.Parse(Forma.gSecuencial)

                                    dialogo.DefaultExt = "*.txt"
                                    dialogo.FileName = "BMX" & " " & Secuencial.ToString("00")
                                    dialogo.Filter = "Archivos de texto (*.txt)|*.txt"
                                    dialogo.ShowDialog()
                                    PathArchivo = ""
                                    PathArchivo = dialogo.FileName

                                    If PathArchivo <> "" Then

                                        strStreamW = File.Create(PathArchivo) ' lo creamos
                                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                                        contador = 1
                                        sRenglon = ""
                                        '## Reglon 1
                                        sRenglon = "1"
                                        sRenglon &= Long.Parse(rwDatos(0)("numcliente").ToString).ToString("000000000000")
                                        sRenglon &= Date.Parse(Forma.gFecha).Day.ToString("00") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Year.ToString.Substring(2, 2)

                                        sRenglon &= Secuencial.ToString("0000")


                                        nombre = RemoverBasura(rwDatos(0)("empresa").ToString)
                                        If nombre.Length < 37 Then
                                            For y As Integer = nombre.Length To 35
                                                nombre &= " "
                                            Next

                                        Else
                                            nombre = nombre.Substring(0, 36)
                                        End If

                                        sRenglon &= nombre


                                        nombre = RemoverBasura(rwDatos(0)("descripcion").ToString)
                                        If nombre.Length < 21 Then
                                            For y As Integer = nombre.Length To 19
                                                nombre &= " "
                                            Next

                                        Else
                                            nombre = nombre.Substring(0, 20)
                                        End If

                                        sRenglon &= nombre
                                        'naturaleza del archivo
                                        sRenglon &= "12"
                                        nombre = ""
                                        For x As Integer = 1 To 40
                                            nombre &= " "
                                        Next
                                        sRenglon &= nombre
                                        sRenglon &= "C"
                                        sRenglon &= "0"
                                        sRenglon &= "0"
                                        strStreamWriter.WriteLine(sRenglon)

                                        '## Reglon 2
                                        sRenglon = ""
                                        sRenglon = "2"
                                        sRenglon &= "1"
                                        sRenglon &= "001"

                                        'Suma todos los importes
                                        Dim suma As Double
                                        suma = 0

                                        For z As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(z).Cells(0).Value Then
                                                If chkSindicato.Checked Then
                                                    suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(20).Value)
                                                Else
                                                    suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(8).Value)
                                                End If
                                            End If

                                        Next

                                        sRenglon &= (suma * 100).ToString("000000000000000000")

                                        sRenglon &= "01"
                                        sRenglon &= Integer.Parse(rwDatos(0)("numsucursal").ToString).ToString("0000")
                                        sRenglon &= Long.Parse(rwDatos(0)("cuentacargo").ToString).ToString("00000000000000000000")

                                        nombre = ""
                                        For x As Integer = 1 To 20
                                            nombre &= " "
                                        Next
                                        sRenglon &= nombre
                                        strStreamWriter.WriteLine(sRenglon)


                                        '##Cuerpo del layout

                                        For x As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(x).Cells(0).Value Then
                                                sRenglon = "3"
                                                sRenglon &= "0"
                                                sRenglon &= "001"

                                                'Neto SA 
                                                If chkSindicato.Checked Then
                                                    sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * 100).ToString("000000000000000000")
                                                Else
                                                    sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * 100).ToString("000000000000000000")
                                                End If
                                                'Naturaleza del abono
                                                sRenglon &= "01"

                                                'Sabemos si es por sa o sindicato interbancario

                                                sql = "select * from EmpleadosC where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value
                                                Dim rwDatosCuenta As DataRow() = nConsulta(sql)

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= (Long.Parse(IIf(rwDatosCuenta(0)("clabe2") = "", "0", rwDatosCuenta(0)("clabe2")))).ToString("00000000000000000000")
                                                    Else
                                                        sRenglon &= (Long.Parse(IIf(rwDatosCuenta(0)("Clabe") = "", "0", rwDatosCuenta(0)("Clabe")))).ToString("00000000000000000000")
                                                    End If
                                                End If


                                                'sRenglon &= (Long.Parse(IIf(dtgDatos.Rows(x).Cells(3).Value = "", "0", dtgDatos.Rows(x).Cells(3).Value))).ToString("00000000000000000000")
                                                'Referencia Alfanumerica
                                                nombre = "SUELDO"

                                                For y As Integer = nombre.Length To 39
                                                    nombre &= " "
                                                Next

                                                'nombre = (Long.Parse(contador)).ToString("0000000000000000000000000000000000000000")


                                                'For y As Integer = nombre.Length To 39
                                                '    nombre &= " "
                                                'Next
                                                sRenglon &= nombre

                                                If rwDatosCuenta Is Nothing = False Then
                                                    nombre = RemoverBasura(rwDatosCuenta(0)("cNombre").ToString() & "," & rwDatosCuenta(0)("cApellidoP").ToString() & "/" & rwDatosCuenta(0)("cApellidoM").ToString()) '& "@")

                                                End If




                                                If nombre.Length < 56 Then
                                                    For y As Integer = nombre.Length To 54
                                                        nombre &= " "
                                                    Next

                                                Else
                                                    nombre = nombre.Substring(0, 55)
                                                End If


                                                sRenglon &= nombre

                                                nombre = ""
                                                For i As Integer = 1 To 40
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre


                                                'nombre = "SUELDO"
                                                nombre = ""
                                                For y As Integer = nombre.Length To 23
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre
                                                'clabe banco

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= "0" & Microsoft.VisualBasic.Left(IIf(rwDatosCuenta(0)("clabe2") = "", "000", rwDatosCuenta(0)("clabe2")), 3)
                                                    Else
                                                        sRenglon &= "0" & Microsoft.VisualBasic.Left(IIf(rwDatosCuenta(0)("Clabe") = "", "000", rwDatosCuenta(0)("Clabe")), 3)
                                                    End If
                                                End If

                                                'sRenglon &= "0000"

                                                nombre = (Long.Parse(contador)).ToString("0000000")

                                                sRenglon &= nombre

                                                sRenglon &= "00"

                                                'escribimos en el archivo
                                                strStreamWriter.WriteLine(sRenglon)
                                                contador = contador + 1
                                            End If

                                        Next

                                        '## Linea Final

                                        sRenglon = "4"
                                        sRenglon &= "001"
                                        sRenglon &= (contador - 1).ToString("000000")
                                        sRenglon &= (suma * 100).ToString("000000000000000000")
                                        sRenglon &= "000001"
                                        sRenglon &= (suma * 100).ToString("000000000000000000")

                                        strStreamWriter.WriteLine(sRenglon)
                                        strStreamWriter.Close() ' cerramos

                                        MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


                                    Else
                                        MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                End If




                            End If

                            'iTipo = Forma.gIdTipo
                        Else
                            Dim Forma As New frmbanamex
                            Forma.gIdBanco = cbobancos.SelectedValue
                            Forma.gIdEmpresa = gIdEmpresa
                            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                                'Buscamos datos
                                sql = "select * from DatosBanco where iIdDatosBanco=" & Forma.gIdDatosBancos
                                Dim rwDatos As DataRow() = nConsulta(sql)

                                If rwDatos Is Nothing = False Then


                                    Dim Secuencial As Integer = Integer.Parse(Forma.gSecuencial)

                                    dialogo.DefaultExt = "*.txt"
                                    dialogo.FileName = "BMX" & " " & Secuencial.ToString("00")
                                    dialogo.Filter = "Archivos de texto (*.txt)|*.txt"
                                    dialogo.ShowDialog()
                                    PathArchivo = ""
                                    PathArchivo = dialogo.FileName

                                    If PathArchivo <> "" Then

                                        strStreamW = File.Create(PathArchivo) ' lo creamos
                                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                                        contador = 1
                                        sRenglon = ""
                                        '## Reglon 1
                                        sRenglon = "1"
                                        sRenglon &= Long.Parse(rwDatos(0)("numcliente").ToString).ToString("000000000000")
                                        sRenglon &= Date.Parse(Forma.gFecha).Day.ToString("00") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Year.ToString.Substring(2, 2)

                                        sRenglon &= Secuencial.ToString("0000")


                                        nombre = RemoverBasura(rwDatos(0)("empresa").ToString)
                                        If nombre.Length < 37 Then
                                            For y As Integer = nombre.Length To 35
                                                nombre &= " "
                                            Next

                                        Else
                                            nombre = nombre.Substring(0, 36)
                                        End If

                                        sRenglon &= nombre


                                        nombre = RemoverBasura(rwDatos(0)("descripcion").ToString)
                                        If nombre.Length < 21 Then
                                            For y As Integer = nombre.Length To 19
                                                nombre &= " "
                                            Next

                                        Else
                                            nombre = nombre.Substring(0, 20)
                                        End If

                                        sRenglon &= nombre

                                        sRenglon &= "05"
                                        nombre = ""
                                        For x As Integer = 1 To 40
                                            nombre &= " "
                                        Next
                                        sRenglon &= nombre
                                        sRenglon &= "C"
                                        sRenglon &= "0"
                                        sRenglon &= "0"
                                        strStreamWriter.WriteLine(sRenglon)

                                        '## Reglon 2
                                        sRenglon = ""
                                        sRenglon = "2"
                                        sRenglon &= "1"
                                        sRenglon &= "001"

                                        'Suma todos los importes
                                        Dim suma As Double
                                        suma = 0

                                        For z As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(z).Cells(0).Value Then
                                                If chkSindicato.Checked Then
                                                    If chkAguinaldo.Checked Then
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(18).Value)
                                                    Else
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(20).Value)
                                                    End If


                                                Else
                                                    If chkAguinaldo.Checked Then
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(12).Value)
                                                    Else
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(8).Value)
                                                    End If

                                                End If
                                            End If

                                        Next

                                        sRenglon &= (suma * 100).ToString("000000000000000000")

                                        sRenglon &= "01"
                                        sRenglon &= Integer.Parse(rwDatos(0)("numsucursal").ToString).ToString("0000")
                                        sRenglon &= Long.Parse(rwDatos(0)("cuentacargo").ToString).ToString("00000000000000000000")

                                        nombre = ""
                                        For x As Integer = 1 To 20
                                            nombre &= " "
                                        Next
                                        sRenglon &= nombre
                                        strStreamWriter.WriteLine(sRenglon)


                                        '##Cuerpo del layout

                                        For x As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(x).Cells(0).Value Then
                                                sRenglon = "3"
                                                sRenglon &= "0"
                                                sRenglon &= "001"

                                                'Neto SA 
                                                If chkSindicato.Checked Then
                                                    If chkAguinaldo.Checked Then
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(18).Value) * 100).ToString("000000000000000000")
                                                    Else
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * 100).ToString("000000000000000000")
                                                    End If

                                                Else
                                                    If chkAguinaldo.Checked Then
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(12).Value) * 100).ToString("000000000000000000")
                                                    Else
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * 100).ToString("000000000000000000")
                                                    End If

                                                End If

                                                sRenglon &= "03"

                                                'Sabemos si es por sa o sindicato

                                                sql = "select * from EmpleadosC where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value
                                                Dim rwDatosCuenta As DataRow() = nConsulta(sql)

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= (Long.Parse(IIf(rwDatosCuenta(0)("cuenta2") = "", "0", rwDatosCuenta(0)("cuenta2")))).ToString("00000000000000000000")
                                                    Else
                                                        sRenglon &= (Long.Parse(IIf(dtgDatos.Rows(x).Cells(4).Value = "", "0", dtgDatos.Rows(x).Cells(4).Value))).ToString("00000000000000000000")
                                                    End If
                                                End If





                                                nombre = (Long.Parse(contador)).ToString("0000000000")


                                                For y As Integer = nombre.Length To 39
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre




                                                nombre = RemoverBasura(dtgDatos.Rows(x).Cells(6).Value)
                                                If nombre.Length < 56 Then
                                                    For y As Integer = nombre.Length To 54
                                                        nombre &= " "
                                                    Next

                                                Else
                                                    nombre = nombre.Substring(0, 55)
                                                End If


                                                sRenglon &= nombre

                                                nombre = ""
                                                For i As Integer = 1 To 40
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre

                                                If chkSindicato.Checked Then
                                                    nombre = "BENEFICIOSINDICALPROMY"
                                                Else
                                                    nombre = "SUELDO"
                                                End If
                                                'nombre = "SUELDO"
                                                For y As Integer = nombre.Length To 23
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre


                                                sRenglon &= "0000"
                                                sRenglon &= "0000000"

                                                sRenglon &= "00"

                                                'escribimos en el archivo
                                                strStreamWriter.WriteLine(sRenglon)
                                                contador = contador + 1
                                            End If

                                        Next

                                        '## Linea Final

                                        sRenglon = "4"
                                        sRenglon &= "001"
                                        sRenglon &= (contador - 1).ToString("000000")
                                        sRenglon &= (suma * 100).ToString("000000000000000000")
                                        sRenglon &= "000001"
                                        sRenglon &= (suma * 100).ToString("000000000000000000")

                                        strStreamWriter.WriteLine(sRenglon)
                                        strStreamWriter.Close() ' cerramos

                                        MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


                                    Else
                                        MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                End If




                            End If

                            'iTipo = Forma.gIdTipo
                        End If



                    Case "18"
                        If chkinter.Checked Then
                            Dim Forma As New frmbanorte

                            Forma.gIdBanco = cbobancos.SelectedValue
                            Forma.gIdEmpresa = gIdEmpresa
                            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                                'Buscamos datos
                                sql = "select * from DatosBanco where iIdDatosBanco=" & Forma.gIdDatosBancos
                                Dim rwDatos As DataRow() = nConsulta(sql)

                                If rwDatos Is Nothing = False Then


                                    Dim Secuencial As Integer = Integer.Parse(Forma.gSecuencial)

                                    dialogo.DefaultExt = "*.pag"
                                    dialogo.FileName = "NI" & rwDatos(0)("numcliente").ToString & Secuencial.ToString("00")
                                    dialogo.Filter = "Archivos Layout Banorte (*.pag)|*.pag"
                                    dialogo.ShowDialog()
                                    PathArchivo = ""
                                    PathArchivo = dialogo.FileName

                                    If PathArchivo <> "" Then

                                        strStreamW = File.Create(PathArchivo) ' lo creamos
                                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                                        contador = 1
                                        sRenglon = ""
                                        '## Reglon 1
                                        sRenglon = "H"
                                        sRenglon &= "NE"
                                        sRenglon &= rwDatos(0)("numcliente").ToString
                                        sRenglon &= Date.Parse(Forma.gFecha).Year.ToString("0000") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Day.ToString("00")

                                        sRenglon &= Secuencial.ToString("00")


                                        'Suma todos los importes
                                        Dim suma As Double
                                        suma = 0


                                        For z As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(z).Cells(0).Value Then
                                                If chkSindicato.Checked Then
                                                    suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(20).Value)
                                                Else
                                                    suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(8).Value)
                                                End If
                                                contador = contador + 1
                                            End If


                                        Next

                                        sRenglon &= (contador - 1).ToString("000000")


                                        sRenglon &= (suma * 100).ToString("000000000000000")

                                        sRenglon &= "000000"
                                        sRenglon &= "000000000000000"
                                        sRenglon &= "000000"
                                        sRenglon &= "000000000000000"
                                        sRenglon &= "000000"
                                        sRenglon &= "0"

                                        nombre = ""
                                        For x As Integer = 1 To 77
                                            nombre &= " "
                                        Next

                                        sRenglon &= nombre


                                        strStreamWriter.WriteLine(sRenglon)



                                        '##Cuerpo del layout Banorte
                                        contador = 1
                                        For x As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(x).Cells(0).Value Then
                                                sRenglon = "D"
                                                sRenglon &= Date.Parse(Forma.gFecha).Year.ToString("0000") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Day.ToString("00")
                                                sRenglon &= contador.ToString("0000000000")

                                                nombre = ""
                                                For y As Integer = 1 To 40
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre

                                                nombre = ""
                                                For y As Integer = 1 To 40
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre


                                                'Neto SA 
                                                If chkSindicato.Checked Then
                                                    sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * 100).ToString("000000000000000")
                                                Else
                                                    sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * 100).ToString("000000000000000")
                                                End If

                                                'BANCO RECEPTOR 
                                                sql = "select * from EmpleadosC where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value
                                                Dim rwDatosCuenta As DataRow() = nConsulta(sql)

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= Microsoft.VisualBasic.Left(IIf(rwDatosCuenta(0)("clabe2") = "", "000", rwDatosCuenta(0)("clabe2")), 3)
                                                    Else
                                                        sRenglon &= Microsoft.VisualBasic.Left(IIf(rwDatosCuenta(0)("Clabe") = "", "000", rwDatosCuenta(0)("Clabe")), 3)
                                                    End If
                                                End If

                                                'sRenglon &= "072"
                                                'TIPO DE CUENTA 01 CHEQUES 40 CLABE
                                                sRenglon &= "40"

                                                'CAMBIAR POR LA CUENTA CORRESPONDIENTE



                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= Long.Parse(IIf(rwDatosCuenta(0)("clabe2") = "", "0", rwDatosCuenta(0)("clabe2").ToString())).ToString("000000000000000000")

                                                    Else
                                                        sRenglon &= Long.Parse(IIf(rwDatosCuenta(0)("Clabe") = "", "0", rwDatosCuenta(0)("Clabe").ToString())).ToString("000000000000000000")
                                                    End If
                                                End If





                                                sRenglon &= "0"
                                                sRenglon &= " "
                                                sRenglon &= "00000000"
                                                nombre = ""
                                                For i As Integer = 1 To 18
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre



                                                'escribimos en el archivo
                                                strStreamWriter.WriteLine(sRenglon)
                                                contador = contador + 1
                                            End If


                                        Next




                                        strStreamWriter.Close() ' cerramos

                                        MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


                                    Else
                                        MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                End If




                            End If

                            'iTipo = Forma.gIdTipo
                        Else
                            Dim Forma As New frmbanorte
                            Forma.gIdBanco = cbobancos.SelectedValue
                            Forma.gIdEmpresa = gIdEmpresa


                            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                                'Buscamos datos
                                sql = "select * from DatosBanco where iIdDatosBanco=" & Forma.gIdDatosBancos
                                Dim rwDatos As DataRow() = nConsulta(sql)

                                If rwDatos Is Nothing = False Then


                                    Dim Secuencial As Integer = Integer.Parse(Forma.gSecuencial)

                                    dialogo.DefaultExt = "*.pag"
                                    dialogo.FileName = "NI" & rwDatos(0)("numcliente").ToString & Secuencial.ToString("00")
                                    dialogo.Filter = "Archivos Layout Banorte (*.pag)|*.pag"
                                    dialogo.ShowDialog()
                                    PathArchivo = ""
                                    PathArchivo = dialogo.FileName

                                    If PathArchivo <> "" Then

                                        strStreamW = File.Create(PathArchivo) ' lo creamos
                                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                                        contador = 1
                                        sRenglon = ""
                                        '## Reglon 1
                                        sRenglon = "H"
                                        sRenglon &= "NE"
                                        sRenglon &= rwDatos(0)("numcliente").ToString
                                        sRenglon &= Date.Parse(Forma.gFecha).Year.ToString("0000") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Day.ToString("00")

                                        sRenglon &= Secuencial.ToString("00")


                                        'Suma todos los importes
                                        Dim suma As Double
                                        suma = 0


                                        For z As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(z).Cells(0).Value Then
                                                If chkSindicato.Checked Then
                                                    If chkAguinaldo.Checked Then
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(18).Value)
                                                    Else
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(20).Value)
                                                    End If

                                                Else
                                                    If chkAguinaldo.Checked Then
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(12).Value)
                                                    Else
                                                        suma = suma + Double.Parse(dtgDatos.Rows(z).Cells(8).Value)
                                                    End If

                                                End If
                                                contador = contador + 1
                                            End If


                                        Next

                                        sRenglon &= (contador - 1).ToString("000000")


                                        sRenglon &= (suma * 100).ToString("000000000000000")

                                        sRenglon &= "000000"
                                        sRenglon &= "000000000000000"
                                        sRenglon &= "000000"
                                        sRenglon &= "000000000000000"
                                        sRenglon &= "000000"
                                        sRenglon &= "0"

                                        nombre = ""
                                        For x As Integer = 1 To 77
                                            nombre &= " "
                                        Next

                                        sRenglon &= nombre


                                        strStreamWriter.WriteLine(sRenglon)



                                        '##Cuerpo del layout Banorte
                                        contador = 1
                                        For x As Integer = 0 To dtgDatos.Rows.Count - 1
                                            If dtgDatos.Rows(x).Cells(0).Value Then
                                                sRenglon = "D"
                                                sRenglon &= Date.Parse(Forma.gFecha).Year.ToString("0000") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Day.ToString("00")

                                                'numero de empleado


                                                sRenglon &= contador.ToString("0000000000")


                                                nombre = ""
                                                For y As Integer = 1 To 40
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre

                                                nombre = ""
                                                For y As Integer = 1 To 40
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre


                                                'Neto SA 
                                                If chkSindicato.Checked Then
                                                    If chkAguinaldo.Checked Then
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(18).Value) * 100).ToString("000000000000000")
                                                    Else
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * 100).ToString("000000000000000")
                                                    End If


                                                Else
                                                    If chkAguinaldo.Checked Then
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(12).Value) * 100).ToString("000000000000000")
                                                    Else
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * 100).ToString("000000000000000")
                                                    End If

                                                End If

                                                'BANCO RECEPTOR 

                                                sRenglon &= "072"
                                                'TIPO DE CUENTA 01 CHEQUES 40 CLABE
                                                sRenglon &= "01"

                                                'CAMBIAR POR LA CUENTA CORRESPONDIENTE

                                                sql = "select * from EmpleadosC where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value
                                                Dim rwDatosCuenta As DataRow() = nConsulta(sql)

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= Long.Parse(IIf(rwDatosCuenta(0)("cuenta2") = "", "0", rwDatosCuenta(0)("cuenta2").ToString())).ToString("000000000000000000")

                                                    Else
                                                        sRenglon &= (Long.Parse(IIf(dtgDatos.Rows(x).Cells(4).Value = "", "0", dtgDatos.Rows(x).Cells(4).Value))).ToString("000000000000000000")
                                                    End If
                                                End If





                                                sRenglon &= "0"
                                                sRenglon &= " "
                                                sRenglon &= "00000000"
                                                nombre = ""
                                                For i As Integer = 1 To 18
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre



                                                'escribimos en el archivo
                                                strStreamWriter.WriteLine(sRenglon)
                                                contador = contador + 1
                                            End If


                                        Next




                                        strStreamWriter.Close() ' cerramos

                                        MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


                                    Else
                                        MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                End If




                            End If

                            'iTipo = Forma.gIdTipo
                        End If


                    Case "13"

                        If chkinter.Checked Then
                            Dim Forma As New frmscotiabank
                            Forma.gIdBanco = cbobancos.SelectedValue
                            Forma.gIdEmpresa = gIdEmpresa

                            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                                'Buscamos datos
                                sql = "select * from DatosBanco where iIdDatosBanco=" & Forma.gIdDatosBancos
                                Dim rwDatos As DataRow() = nConsulta(sql)

                                If rwDatos Is Nothing = False Then


                                    Dim Secuencial As Integer = Integer.Parse(Forma.gSecuencial)

                                    dialogo.DefaultExt = "*.txt"
                                    dialogo.FileName = "Layout scotiabank inter" & " " & Secuencial.ToString("00")
                                    dialogo.Filter = "Archivos de texto (*.txt)|*.txt"
                                    dialogo.ShowDialog()
                                    PathArchivo = ""
                                    PathArchivo = dialogo.FileName

                                    If PathArchivo <> "" Then

                                        strStreamW = File.Create(PathArchivo) ' lo creamos
                                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                                        contador = 1
                                        sRenglon = ""
                                        '## Reglon 1
                                        sRenglon = "EEHA"
                                        sRenglon &= Long.Parse(rwDatos(0)("numcliente").ToString).ToString("00000")
                                        sRenglon &= Secuencial.ToString("00")

                                        sRenglon &= "000000000000000000000000000"
                                        strStreamWriter.WriteLine(sRenglon)

                                        '## Reglon 2
                                        sRenglon = "EEHB000000"

                                        sRenglon &= Long.Parse(rwDatos(0)("cuentacargo").ToString).ToString("00000000000")
                                        sRenglon &= Long.Parse(rwDatos(0)("empresa").ToString).ToString("0000000000")
                                        sRenglon &= "000"
                                        strStreamWriter.WriteLine(sRenglon)


                                        'Suma todos los importes
                                        Dim suma As Double
                                        suma = 0

                                        '##Cuerpo del layout

                                        For x As Integer = 0 To dtgDatos.Rows.Count - 1

                                            If dtgDatos.Rows(x).Cells(0).Value Then
                                                sRenglon = "EEDA"
                                                sRenglon &= "04"


                                                'Neto SA 
                                                If chkSindicato.Checked Then
                                                    sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * 100).ToString("00000000000000000")
                                                    suma = suma + Double.Parse(dtgDatos.Rows(x).Cells(20).Value)
                                                Else
                                                    sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * 100).ToString("00000000000000000")
                                                    suma = suma + Double.Parse(dtgDatos.Rows(x).Cells(8).Value)
                                                End If

                                                sRenglon &= Date.Parse(Forma.gFecha).Year.ToString("0000") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Day.ToString("00")
                                                sRenglon &= "01"

                                                nombre = contador.ToString()
                                                For y As Integer = nombre.Length To 32
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre


                                                nombre = RemoverBasura(dtgDatos.Rows(x).Cells(6).Value)
                                                If nombre.Length < 41 Then
                                                    For y As Integer = nombre.Length To 39
                                                        nombre &= " "
                                                    Next

                                                Else
                                                    nombre = nombre.Substring(0, 40)
                                                End If


                                                sRenglon &= nombre

                                                sRenglon &= contador.ToString("0000000000000000")
                                                sRenglon &= "0000000000"

                                                'buscamos que cuenta le corresponde interbancaria sa o interbancaria sindicato

                                                sql = "select * from EmpleadosC where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value
                                                Dim rwDatosCuenta As DataRow() = nConsulta(sql)

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= "00" & IIf(rwDatosCuenta(0)("clabe2") = "", "0", rwDatosCuenta(0)("clabe2").ToString())

                                                    Else
                                                        sRenglon &= "00" & IIf(rwDatosCuenta(0)("Clabe") = "", "0", rwDatosCuenta(0)("Clabe").ToString())
                                                    End If
                                                End If

                                                'se termina de buscar la cuenta

                                                'sRenglon &= (Long.Parse(IIf(dtgDatos.Rows(x).Cells(3).Value = "", "0", dtgDatos.Rows(x).Cells(3).Value))).ToString("00000000000000000000")



                                                nombre = "00000"

                                                For i As Integer = nombre.Length To 44
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre

                                                sRenglon &= "9"
                                                sRenglon &= " "
                                                sRenglon &= "00000044"
                                                'Sustraemos el numero de banco

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= Microsoft.VisualBasic.Left(IIf(rwDatosCuenta(0)("clabe2") = "", "000", rwDatosCuenta(0)("clabe2")), 3)
                                                    Else
                                                        sRenglon &= Microsoft.VisualBasic.Left(IIf(rwDatosCuenta(0)("Clabe") = "", "000", rwDatosCuenta(0)("Clabe")), 3)
                                                    End If
                                                End If

                                                'sRenglon &= "044"

                                                sRenglon &= "001"

                                                If chkSindicato.Checked Then
                                                    nombre = "BENEFICIOSINDICALPROMYDIFSINDICAL"
                                                Else
                                                    nombre = "SUELDO"
                                                End If


                                                For y As Integer = nombre.Length To 49
                                                    nombre &= " "

                                                Next

                                                sRenglon &= nombre


                                                nombre = ""

                                                For y As Integer = 1 To 60
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre

                                                sRenglon &= "0000000000000000000000000"

                                                'escribimos en el archivo
                                                strStreamWriter.WriteLine(sRenglon)

                                                contador = contador + 1
                                            End If


                                        Next

                                        '## Linea Final

                                        sRenglon = "EETB"
                                        sRenglon &= (contador - 1).ToString("0000000")

                                        sRenglon &= (suma * 100).ToString("00000000000000000")
                                        sRenglon &= "000000000000000000000000"
                                        sRenglon &= "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"

                                        strStreamWriter.WriteLine(sRenglon)


                                        sRenglon = "EETA"
                                        sRenglon &= (contador - 1).ToString("0000000")

                                        sRenglon &= (suma * 100).ToString("00000000000000000")
                                        sRenglon &= "000000000000000000000000"
                                        sRenglon &= "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"

                                        strStreamWriter.WriteLine(sRenglon)

                                        strStreamWriter.Close() ' cerramos

                                        If contador = 1 Then
                                            MessageBox.Show("Archivo generado correctamente, pero vacio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Else
                                            MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If



                                    Else
                                        MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                End If




                            End If
                        Else
                            Dim Forma As New frmscotiabank
                            Forma.gIdBanco = cbobancos.SelectedValue
                            Forma.gIdEmpresa = gIdEmpresa
                            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                                'Buscamos datos
                                sql = "select * from DatosBanco where iIdDatosBanco=" & Forma.gIdDatosBancos
                                Dim rwDatos As DataRow() = nConsulta(sql)

                                If rwDatos Is Nothing = False Then


                                    Dim Secuencial As Integer = Integer.Parse(Forma.gSecuencial)

                                    dialogo.DefaultExt = "*.txt"
                                    dialogo.FileName = "Layout scotiabank" & " " & Secuencial.ToString("00")
                                    dialogo.Filter = "Archivos de texto (*.txt)|*.txt"
                                    dialogo.ShowDialog()
                                    PathArchivo = ""
                                    PathArchivo = dialogo.FileName

                                    If PathArchivo <> "" Then

                                        strStreamW = File.Create(PathArchivo) ' lo creamos
                                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                                        contador = 1
                                        sRenglon = ""
                                        '## Reglon 1
                                        sRenglon = "EEHA"
                                        sRenglon &= Long.Parse(rwDatos(0)("numcliente").ToString).ToString("00000")
                                        sRenglon &= Secuencial.ToString("00")

                                        sRenglon &= "000000000000000000000000000"
                                        strStreamWriter.WriteLine(sRenglon)

                                        '## Reglon 2
                                        sRenglon = "EEHB000000"

                                        sRenglon &= Long.Parse(rwDatos(0)("cuentacargo").ToString).ToString("00000000000")
                                        sRenglon &= Long.Parse(rwDatos(0)("empresa").ToString).ToString("0000000000")
                                        sRenglon &= "000"
                                        strStreamWriter.WriteLine(sRenglon)


                                        'Suma todos los importes
                                        Dim suma As Double
                                        suma = 0

                                        '##Cuerpo del layout

                                        For x As Integer = 0 To dtgDatos.Rows.Count - 1

                                            If dtgDatos.Rows(x).Cells(0).Value Then
                                                sRenglon = "EEDA"
                                                sRenglon &= "04"


                                                'Neto SA 
                                                If chkSindicato.Checked Then
                                                    If chkAguinaldo.Checked Then
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(18).Value) * 100).ToString("00000000000000000")
                                                        suma = suma + Double.Parse(dtgDatos.Rows(x).Cells(18).Value)
                                                    Else
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(20).Value) * 100).ToString("00000000000000000")
                                                        suma = suma + Double.Parse(dtgDatos.Rows(x).Cells(20).Value)
                                                    End If

                                                Else
                                                    If chkAguinaldo.Checked Then
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(12).Value) * 100).ToString("00000000000000000")
                                                        suma = suma + Double.Parse(dtgDatos.Rows(x).Cells(12).Value)
                                                    Else
                                                        sRenglon &= (Double.Parse(dtgDatos.Rows(x).Cells(8).Value) * 100).ToString("00000000000000000")
                                                        suma = suma + Double.Parse(dtgDatos.Rows(x).Cells(8).Value)
                                                    End If

                                                End If

                                                sRenglon &= Date.Parse(Forma.gFecha).Year.ToString("0000") & Date.Parse(Forma.gFecha).Month.ToString("00") & Date.Parse(Forma.gFecha).Day.ToString("00")
                                                sRenglon &= "01"

                                                nombre = contador.ToString()
                                                For y As Integer = nombre.Length To 32
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre


                                                nombre = RemoverBasura(dtgDatos.Rows(x).Cells(6).Value)
                                                If nombre.Length < 41 Then
                                                    For y As Integer = nombre.Length To 39
                                                        nombre &= " "
                                                    Next

                                                Else
                                                    nombre = nombre.Substring(0, 40)
                                                End If


                                                sRenglon &= nombre

                                                sRenglon &= contador.ToString("0000000000000000")
                                                sRenglon &= "0000000000"

                                                'buscamos que cuenta le corresponde interbancaria sa o interbancaria sindicato

                                                sql = "select * from EmpleadosC where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value
                                                Dim rwDatosCuenta As DataRow() = nConsulta(sql)

                                                If rwDatosCuenta Is Nothing = False Then
                                                    If chkSindicato.Checked Then
                                                        sRenglon &= (Long.Parse(IIf(rwDatosCuenta(0)("cuenta2") = "", "0", rwDatosCuenta(0)("cuenta2")))).ToString("00000000000000000000")
                                                    Else
                                                        sRenglon &= (Long.Parse(IIf(dtgDatos.Rows(x).Cells(4).Value = "", "0", dtgDatos.Rows(x).Cells(4).Value))).ToString("00000000000000000000")
                                                    End If
                                                End If




                                                nombre = "00000"
                                                For i As Integer = nombre.Length To 44
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre

                                                sRenglon &= "1"
                                                sRenglon &= " "
                                                sRenglon &= "00000044"
                                                sRenglon &= "044"
                                                sRenglon &= "001"

                                                If chkSindicato.Checked Then
                                                    nombre = "BENEFICIOSINDICALPROMYDIFSINDICAL"
                                                Else
                                                    nombre = "SUELDO"
                                                End If

                                                'nombre = "SUELDO"
                                                For y As Integer = nombre.Length To 49
                                                    nombre &= " "
                                                Next

                                                sRenglon &= nombre

                                                nombre = ""
                                                For y As Integer = 1 To 60
                                                    nombre &= " "
                                                Next
                                                sRenglon &= nombre


                                                sRenglon &= "0000000000000000000000000"


                                                'escribimos en el archivo
                                                strStreamWriter.WriteLine(sRenglon)
                                                contador = contador + 1
                                            End If


                                        Next

                                        '## Linea Final

                                        sRenglon = "EETB"
                                        sRenglon &= (contador - 1).ToString("0000000")

                                        sRenglon &= (suma * 100).ToString("00000000000000000")
                                        sRenglon &= "000000000000000000000000"
                                        sRenglon &= "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"

                                        strStreamWriter.WriteLine(sRenglon)


                                        sRenglon = "EETA"
                                        sRenglon &= (contador - 1).ToString("0000000")

                                        sRenglon &= (suma * 100).ToString("00000000000000000")
                                        sRenglon &= "000000000000000000000000"
                                        sRenglon &= "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"

                                        strStreamWriter.WriteLine(sRenglon)

                                        strStreamWriter.Close() ' cerramos

                                        If contador = 1 Then
                                            MessageBox.Show("Archivo generado correctamente, pero vacio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Else
                                            MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End If



                                    Else
                                        MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                End If




                            End If
                        End If



                        'iTipo = Forma.gIdTipo
                End Select

                'If iTipo = "1" Then

                '    'If File.Exists(PathArchivo) Then
                '    '    MessageBox.Show("El archivo con ese nombre ya existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    '    'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                '    '    Exit Sub
                '    'Else
                '    '    strStreamW = File.Create(PathArchivo) ' lo creamos
                '    'End If


                'End If



            Else
                MessageBox.Show("No hay datos cargados ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception
            MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
    End Sub

    Function RemoverBasura(nombre As String) As String
        Dim COMPSTR As String = "áéíóúÁÉÍÓÚ.ñÑ"
        Dim REPLSTR As String = "aeiouAEIOU nN"
        Dim Posicion As Integer
        Dim cadena As String = ""
        Dim arreglo As Char() = nombre.ToCharArray()
        For x As Integer = 0 To arreglo.Length - 1
            Posicion = COMPSTR.IndexOf(arreglo(x))
            If Posicion <> -1 Then
                arreglo(x) = REPLSTR(Posicion)

            End If
            cadena = cadena & arreglo(x)
        Next
        Return cadena
    End Function

    Function TipoCuentaBanco(idempleado As String, idempresa As String) As String
        'Agregar el banco y el tipo de cuenta ya sea a terceros o interbancaria
        'Buscamos el banco y verificarmos el tipo de cuenta a tercero o interbancaria
        Dim Sql As String
        Dim cadenabanco As String
        cadenabanco = ""

        Sql = "select iIdempleadoC,NumCuenta,Clabe,cuenta2,clabe2,fkiIdBanco,bancos.cBanco as banco1,fkiIdBanco2,bancos2.cBanco as banco2"
        Sql &= " from (empleadosC"
        Sql &= " inner join bancos on empleadosC.fkiIdBanco= bancos.iIdBanco)"
        Sql &= " inner join (select iIdBanco,cBanco from bancos) as bancos2 on empleadosC.fkiIdBanco2= bancos2.iIdBanco"
        Sql &= " where fkiIdEmpresa=" & gIdEmpresa & " and iIdempleadoC=" & idempleado

        Dim rwDatosBanco As DataRow() = nConsulta(Sql)

        cadenabanco = "@"

        If rwDatosBanco Is Nothing = False Then
            If rwDatosBanco(0)("NumCuenta") = "" Then
                cadenabanco &= "I"
            Else
                cadenabanco &= "T"
            End If

            cadenabanco &= "-" & rwDatosBanco(0)("banco1").ToString.ToUpper

            'If rwDatosBanco(0)("fkiIdBanco") = "1" Then
            '    cadenabanco &= "-BANAMEX"
            'ElseIf rwDatosBanco(0)("fkiIdBanco") = "4" Then
            '    cadenabanco &= "-BANCOMER"
            'ElseIf rwDatosBanco(0)("fkiIdBanco") = "13" Then
            '    cadenabanco &= "-SCOTIABANK"
            'ElseIf rwDatosBanco(0)("fkiIdBanco") = "18" Then
            '    cadenabanco &= "-BANORTE"
            'Else
            '    cadenabanco &= "-OTRO"
            'End If

            cadenabanco &= "/"

            If rwDatosBanco(0)("cuenta2") = "" Then
                cadenabanco &= "I"
            Else
                cadenabanco &= "T"
            End If

            'If rwDatosBanco(0)("fkiIdBanco2") = "1" Then
            '    cadenabanco &= "-BANAMEX"
            'ElseIf rwDatosBanco(0)("fkiIdBanco2") = "4" Then
            '    cadenabanco &= "-BANCOMER"
            'ElseIf rwDatosBanco(0)("fkiIdBanco2") = "13" Then
            '    cadenabanco &= "-SCOTIABANK"
            'ElseIf rwDatosBanco(0)("fkiIdBanco2") = "18" Then
            '    cadenabanco &= "-BANORTE"
            'Else
            '    cadenabanco &= "-OTRO"
            'End If

            cadenabanco &= "-" & rwDatosBanco(0)("banco2").ToString.ToUpper

        End If

        Return cadenabanco
    End Function

    Function CalculoPrimaSindicato(idempleado As String, idempresa As String) As String
        'Agregar el banco y el tipo de cuenta ya sea a terceros o interbancaria
        'Buscamos el banco y verificarmos el tipo de cuenta a tercero o interbancaria
        Dim Sql As String
        Dim cadenabanco As String
        Dim dia As String
        Dim mes As String
        Dim anio As String
        Dim anios As Integer
        Dim sueldodiario As Double
        Dim dias As Integer

        Dim Prima As String


        cadenabanco = ""


        Sql = "select *"
        Sql &= " from empleadosC"
        Sql &= " where fkiIdEmpresa=" & gIdEmpresa & " and iIdempleadoC=" & idempleado

        Dim rwDatosBanco As DataRow() = nConsulta(Sql)

        cadenabanco = "@"
        Prima = "0"
        If rwDatosBanco Is Nothing = False Then

            If Double.Parse(rwDatosBanco(0)("fsueldoOrd")) > 0 Then
                dia = Date.Parse(rwDatosBanco(0)("dFechaAntiguedad").ToString).Day.ToString("00")
                mes = Date.Parse(rwDatosBanco(0)("dFechaAntiguedad").ToString).Month.ToString("00")
                anio = Date.Today.Year
                'verificar el periodo para saber si queda entre el rango de fecha

                sueldodiario = Double.Parse(rwDatosBanco(0)("fsueldoOrd")) / diasperiodo

                Sql = "select * from periodos where iIdPeriodo= " & cboperiodo.SelectedValue
                Dim rwPeriodo As DataRow() = nConsulta(Sql)

                If rwPeriodo Is Nothing = False Then
                    Dim FechaBuscar As Date = Date.Parse(dia & "/" & mes & "/" & anio)
                    Dim FechaInicial As Date = Date.Parse(rwPeriodo(0)("dFechaInicio"))
                    Dim FechaFinal As Date = Date.Parse(rwPeriodo(0)("dFechaFin"))
                    Dim FechaAntiguedad As Date = Date.Parse(rwDatosBanco(0)("dFechaAntiguedad"))

                    If FechaBuscar.CompareTo(FechaInicial) >= 0 And FechaBuscar.CompareTo(FechaFinal) <= 0 Then
                        'Estamos dentro del rango 
                        'Calculamos la prima

                        anios = DateDiff("yyyy", FechaAntiguedad, FechaBuscar)

                        dias = CalculoDiasVacaciones(anios)

                        'Calcular prima

                        Prima = Math.Round(sueldodiario * dias * 0.25, 2).ToString()




                    End If


                End If


            End If


        End If


        Return Prima


    End Function


    Function CalculoDiasVacaciones(anios As Integer) As Integer
        Dim dias As Integer

        If anios = 1 Then
            dias = 6
        End If

        If anios = 2 Then
            dias = 8
        End If

        If anios = 3 Then
            dias = 10
        End If

        If anios = 4 Then
            dias = 12
        End If

        If anios >= 5 And anios <= 9 Then
            dias = 14
        End If

        If anios >= 10 And anios <= 14 Then
            dias = 16
        End If

        If anios >= 15 And anios <= 19 Then
            dias = 18
        End If

        If anios >= 20 And anios <= 24 Then
            dias = 20
        End If

        If anios >= 25 And anios <= 29 Then
            dias = 22
        End If

        If anios >= 30 And anios <= 34 Then
            dias = 24
        End If

        Return dias
    End Function

    Private Sub tsbAguinaldo_Click(sender As Object, e As EventArgs) Handles tsbAguinaldo.Click
        Try

            Dim resultado As Integer = MessageBox.Show("Para poder realizar el calculo del aguinaldo es necesario que la parte de SA ya haya sido calculada e importado los importes.¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)

            If resultado = DialogResult.Yes Then
                Dim Forma As New frmAguinaldo
                Forma.gIdPeriodo = cboperiodo.SelectedValue
                Forma.gIdEmpresa = gIdEmpresa
                Forma.gIdTipoPeriodo = gIdTipoPeriodo
                Forma.ShowDialog()




            End If

        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub tsbCliente_Click(sender As System.Object, e As System.EventArgs) Handles tsbCliente.Click
        Try
            Dim Forma As New frmAsignarCliente
            Forma.gidEmpresa = gIdEmpresa
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                'Refrescar la información


                BuscarClienteAsignado()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbEmpresa_Click(sender As System.Object, e As System.EventArgs) Handles tsbEmpresa.Click
        Try
            Dim Forma As New frmAsignarEmpresa
            Forma.gidEmpresa = gIdEmpresa
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                'Refrescar la información

                BuscarEmpresaAsignada()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdGuardarSueldo_Click(sender As System.Object, e As System.EventArgs) Handles cmdGuardarSueldo.Click
        Try

            
            Dim sql As String
            
            'sql = "EXEC getNominaXEmpresaXPeriodo " & gIdEmpresa & "," & cboperiodo.SelectedValue & ",1"

            
            For x As Integer = 0 To dtgDatos.Rows.Count - 1

                sql = "update empleadosC set fSueldoOrd=" & dtgDatos.Rows(x).Cells(7).Value '& ", fCosto =" & dtgDatos.Rows(x).Cells(22).Value
                sql &= " where iIdEmpleadoC = " & dtgDatos.Rows(x).Cells(3).Value

                If nExecute(sql) = False Then
                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'pnlProgreso.Visible = False
                    Exit Sub
                End If

            Next
            MessageBox.Show("Datos guardados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles Igualar0.Click
        'MessageBox.Show("Primero")
        Dim sql As String
        Try
            'insertamos el valor en la base, verificamos si existe para ese empleado en este peridodo
            'si existe solo actualizamos
            'si no insertamos
            Dim iFila As DataGridViewRow = Me.dtgDatos.CurrentRow()

            sql = "select * from InfoEmpleadoPeriodoContpaq where fkiIdEmpleado=" & iFila.Cells(3).Value
            sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue

            Dim rwInfoEmpleado As DataRow() = nConsulta(sql)
            If rwInfoEmpleado Is Nothing = False Then
                'actualizamos
                sql = "EXEC [setInfoEmpleadoPeriodoContpaqActualizar] " & rwInfoEmpleado(0)("iIdInfoEmpleadoPeriodo")
                'periodo
                sql &= "," & cboperiodo.SelectedValue
                sql &= "," & iFila.Cells(3).Value
                sql &= ",1"
                iFila.Cells(2).Value = "Igualar a 0"
            Else
                sql = "EXEC [setInfoEmpleadoPeriodoContpaqInsertar] 0"
                'periodo
                sql &= "," & cboperiodo.SelectedValue
                sql &= "," & iFila.Cells(3).Value
                sql &= ",1"
                iFila.Cells(2).Value = "Igualar a 0"
            End If
            If nExecute(sql) = False Then
                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'pnlProgreso.Visible = False
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs)
        Dim iFila As DataGridViewRow = Me.dtgDatos.CurrentRow()
        MessageBox.Show(iFila.Cells(6).Value)

    End Sub

    Private Sub dtgDatos_CellMouseDown(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgDatos.CellMouseDown
        'dtgDatos.Rows(e.RowIndex).Selected = True
        Try
            If e.RowIndex > -1 Then
                dtgDatos.CurrentCell = dtgDatos.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DesactivarIgualarA0ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DesactivarIgualarA0ToolStripMenuItem.Click
        Dim sql As String
        Try
            'insertamos el valor en la base, verificamos si existe para ese empleado en este peridodo
            'si existe solo actualizamos
            'si no insertamos
            Dim iFila As DataGridViewRow = Me.dtgDatos.CurrentRow()

            sql = "select * from InfoEmpleadoPeriodoContpaq where fkiIdEmpleado=" & iFila.Cells(3).Value
            sql &= " and fkiIdPeriodo=" & cboperiodo.SelectedValue

            Dim rwInfoEmpleado As DataRow() = nConsulta(sql)
            If rwInfoEmpleado Is Nothing = False Then
                'actualizamos
                sql = "EXEC [setInfoEmpleadoPeriodoContpaqActualizar] " & rwInfoEmpleado(0)("iIdInfoEmpleadoPeriodo")
                'periodo
                sql &= "," & cboperiodo.SelectedValue
                sql &= "," & iFila.Cells(3).Value
                sql &= ",0"
                iFila.Cells(2).Value = ""

                If nExecute(sql) = False Then
                    MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'pnlProgreso.Visible = False
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub tsbExportarExcelEmpleado_Click(sender As System.Object, e As System.EventArgs) Handles tsbExportarExcelEmpleado.Click
        Dim sql As String
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Try
            sql = "select iIdEmpleadoC,(cApellidoP + ' ' + cApellidoM + ' ' + cNombre) as nombre, cRFC,cCurp,cImss,fSueldoBase, fSueldoIntegrado"
            sql &= " from empleadosC where empleadosC.iOrigen=1 and empleadosC.fkiIdClienteInter=-1"
            Sql &= " and empleadosC.fkiIdEmpresa =" & gIdEmpresa
            Sql &= " order by nombre"
            Dim rwEmpleadosEmpresa As DataRow() = nConsulta(sql)
            If rwEmpleadosEmpresa Is Nothing = False Then
                Dim libro As New ClosedXML.Excel.XLWorkbook
                Dim hoja As IXLWorksheet = libro.Worksheets.Add("EMPLEADOS")
                hoja.Column("A").Width = 25
                hoja.Column("B").Width = 20
                hoja.Column("C").Width = 20
                hoja.Column("D").Width = 20
                hoja.Column("E").Width = 20
                hoja.Column("F").Width = 20
                

                hoja.Range(1, 1, 1, 6).Style.Font.FontSize = 10
                hoja.Range(1, 1, 1, 6).Style.Font.SetBold(True)
                hoja.Range(1, 1, 1, 6).Style.Alignment.WrapText = True
                hoja.Range(1, 1, 1, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(1, 1, 1, 6).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(1, 1, 1, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(1, 1, 1, 6).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")
                hoja.Range(2, 5, 1500, 6).Style.NumberFormat.NumberFormatId = 4
                hoja.Range(2, 4, 1500, 4).Style.NumberFormat.NumberFormatId = 49
                'hoja.Cell(4, 1).Value = "Num"

                hoja.Cell(1, 1).Value = "NOMBRE"
                hoja.Cell(1, 2).Value = "RFC"
                hoja.Cell(1, 3).Value = "CURP"
                hoja.Cell(1, 4).Value = "IMSS"
                hoja.Cell(1, 5).Value = "SD"
                hoja.Cell(1, 6).Value = "DI"
                


                filaExcel = 1
                For Each Fila In rwEmpleadosEmpresa
                    filaExcel = filaExcel + 1
                    hoja.Cell(filaExcel, 1).Value = Fila.Item("nombre")
                    hoja.Cell(filaExcel, 2).Value = Fila.Item("cRFC")
                    hoja.Cell(filaExcel, 3).Value = Fila.Item("cCurp")
                    'hoja.Cell(filaExcel, 4).Value = "IMSS"
                    hoja.Cell(filaExcel, 4).Value = Fila.Item("cImss").ToString()
                    hoja.Cell(filaExcel, 5).Value = Fila.Item("fSueldoBase")
                    hoja.Cell(filaExcel, 6).Value = Fila.Item("fSueldoIntegrado")


                Next

                dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Empleados"
                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                dialogo.ShowDialog()
                libro.SaveAs(dialogo.FileName)
                'libro.SaveAs("c:\temp\control.xlsx")
                'libro.SaveAs(dialogo.FileName)
                'apExcel.Quit()
                libro = Nothing
                MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

  
    Private Sub cmdBorrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdBorrar.Click
        Try
            Dim sql As String
            Dim resultado As Integer = MessageBox.Show("¿Realmente desea borrar la nomina que ya  aun cuando esta ya este guardada como final?", "Pregunta", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                sql = "select * from usuarios where idUsuario = " & idUsuario
                Dim rwFilas As DataRow() = nConsulta(sql)

                If rwFilas Is Nothing = False Then
                    sql = "delete from NominaSindicato"
                    sql &= " where NominaSindicato.fkiIdEmpresa=" & gIdEmpresa & " and NominaSindicato.fkiIdPeriodo=" & cboperiodo.SelectedValue

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error  borrado nomina", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub

                    End If

                    sql = "delete from PagoPrestamo"
                    sql &= " where PagoPrestamo.fkiIdPeriodo=" & cboperiodo.SelectedValue

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error borrado prestamo ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub

                    End If

                    sql = "delete from FondeoPatrona"
                    sql &= " where FondeoPatrona.fkiIdPeriodo=" & cboperiodo.SelectedValue

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error borrado fondeo ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub

                    End If



                    sql = "EXEC setNominaBorradaContpaqInsertar 0"
                    sql &= "," & cboperiodo.SelectedValue
                    sql &= ",'" & rwFilas(0)("Nombre").ToString & "'"

                    If nExecute(sql) = False Then
                        MessageBox.Show("Ocurrio un error al insertar NominaBorradaContpaq", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'pnlProgreso.Visible = False
                        Exit Sub
                    End If


                    MessageBox.Show("Nomina borrada correctamente, vuelva a cargar los datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dtgDatos.DataSource = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class