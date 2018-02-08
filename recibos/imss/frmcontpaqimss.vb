Public Class frmcontpaqimss
    Private m_currentControl As Control = Nothing
    Public gIdEmpresa As String
    Public gIdTipoPeriodo As String
    Public gNombrePeriodo As String
    Dim Ruta As String
    Dim nombre As String

    Private Sub frmcontpaqimss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sql As String
            cargarperiodos()
            MostrarClientes()
            MostrarEmpresas()
            'cargarbancosasociados()

            sql = "select * from empresac where iidEmpresac = " & gIdEmpresa
            Dim rwEmpresaC As DataRow() = nConsulta(sql)
            If rwEmpresaC Is Nothing = False Then
                Ruta = rwEmpresaC(0)("ruta")
                nombre = rwEmpresaC(0)("nombre")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MostrarClientes()
        Dim sql As String
        'Verificar si se tienen permisos
        sql = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(Sql)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6") Then

                    sql = "Select nombre,iIdCliente from clientes order by nombre"
                Else
                    Sql = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
                    Sql &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
                    Sql &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    Sql &= "  order by nombre "


                End If
                nCargaCBO(cbocliente, sql, "nombre", "iIdCliente")
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub MostrarEmpresas()
        Dim sql As String
        'Verificar si se tienen permisos
        sql = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(Sql)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6") Then

                    sql = "Select nombre,iIdEmpresa from empresa order by nombre"
                Else
                    Sql = "Select distinct(iIdEmpresa),empresa.nombre from ((clientes inner join UsuarioClientes  "
                    Sql &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente) inner join"
                    Sql &= " IntClienteEmpresa on clientes.iIdCliente=IntClienteEmpresa.fkIdCliente)"
                    Sql &= " inner join empresa on IntClienteEmpresa.fkIdEmpresa= empresa.iIdEmpresa"
                    Sql &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    Sql &= " order by nombre "


                End If
                nCargaCBO(cbopatrona, sql, "nombre", "iIdEmpresa")
            End If

        Catch ex As Exception

        End Try




    End Sub

    'Private Sub cargarbancosasociados()
    '    Dim sql As String
    '    Try
    '        sql = "select * from bancos inner join ( select distinct(fkiidBanco) from DatosBanco) bancos2 on bancos.iIdBanco=bancos2.fkiidBanco order by cBanco"
    '        nCargaCBO(cbobancos, sql, "cBanco", "iIdBanco")
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub cargarperiodos()
        'Verificar si se tienen permisos
        Dim sql As String
        Try
            sql = "Select * from periodos where fkiIdTipoPeriodo=" & gIdTipoPeriodo & " and fkiIdEmpresa=" & gIdEmpresa & "order by iEjercicio,iNumeroPeriodo"
            nCargaCBO(cboperiodo, sql, "dFechainicio", "iIdPeriodo")
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
                                sql &= "," & rwTiposPeriodoC(x)("mes") & "," & rwTiposPeriodoC(x)("diaspago")
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

    Private Sub tsbEmpleados_Click(sender As Object, e As EventArgs) Handles tsbEmpleados.Click
        Dim sql As String
        Dim sql2 As String
        Dim iBan As Integer
        Dim nacimiento As String
        Dim idempleado As String

        Try
            If Ruta <> "" And Ruta <> "ctCSyAP" Then
                'importamos los tipos de periodo

                Dim resultado As Integer = MessageBox.Show("Los empleados se asociaran a la empresa patrona: " & cbopatrona.Text & " con el cliente: " & cbocliente.Text & " ¿desea continuar, este la asociación ya no es modificable?", "Pregunta", MessageBoxButtons.YesNo)
                If resultado = DialogResult.Yes Then
                    ConectarContpaq(Ruta)

                    sql = "select nom10001.*,nom10003.descripcion as departamento, nom10006.descripcion as puesto from nom10001"
                    sql &= " inner Join nom10003 on nom10001.iddepartamento= nom10003.iddepartamento"
                    sql &= " inner Join nom10006 On nom10001.idpuesto = nom10006.idpuesto"


                    Dim rwEmpleadosC As DataRow() = nConsultaContpaq(sql)
                    If rwEmpleadosC Is Nothing = False Then

                        sql = "Select * from empleados where fkiIdEmpresaC=" & gIdEmpresa


                        Dim rwEmpleados As DataRow() = nConsulta(sql)

                        If rwEmpleados Is Nothing = False Then

                            For x As Integer = 0 To rwEmpleadosC.Length - 1
                                nacimiento = ""
                                iBan = 0
                                For y As Integer = 0 To rwEmpleados.Length - 1
                                    If (rwEmpleadosC(x)("codigoempleado").ToString() = rwEmpleados(y)("cCodigoEmpleado").ToString) Then

                                        If rwEmpleadosC(x)("estadoempleado").ToString() = "B" Then
                                            sql = "update empleados set fkiIdClienteInter = -2 where iIdEmpleado=" & rwEmpleados(y)("iIdEmpleado").ToString

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
                                    If rwEmpleadosC(x)("estadoempleado") <> "B" Then
                                        sql = "EXEC setempleadosInsertar2 0"
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
                                        sql &= "," & cbopatrona.SelectedValue

                                        sql &= ",0.00"
                                        sql &= ",0.00"
                                        sql &= "," & cbocliente.SelectedValue
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



                                        sql &= "," & IIf(rwEmpleadosC(x)("estadoempleado").ToString() = "B", "-2", "-1")

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
                                        'empresacontpaq
                                        sql &= "," & gIdEmpresa
                                        'estado civil

                                        sql &= ",1"



                                        If nExecute(sql) = False Then
                                            MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            'pnlProgreso.Visible = False
                                            Exit Sub

                                        End If

                                    End If

                                End If
                            Next

                        Else



                            For x As Integer = 0 To rwEmpleadosC.Length - 1
                                idempleado = ""
                                If rwEmpleadosC(x)("estadoempleado") <> "B" Then
                                    nacimiento = ""

                                    sql = "EXEC setempleadosInsertar2 0"
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
                                    sql &= "," & cbopatrona.SelectedValue

                                    sql &= ",0.00"
                                    sql &= ",0.00"
                                    sql &= "," & cbocliente.SelectedValue
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



                                    sql &= "," & IIf(rwEmpleadosC(x)("estadoempleado").ToString() = "B", "-2", "-1")

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
                                    'empresacontpaq
                                    sql &= "," & gIdEmpresa
                                    'estado civil
                                    sql &= ",1"

                                    If Execute(sql, idempleado) = False Then
                                        MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        'pnlProgreso.Visible = False
                                        Exit Sub


                                    End If

                                    'insertamos el alta
                                    sql = "select * from nom10020"
                                    sql &= " where idempleado=" & rwEmpleadosC(x)("idempleado").ToString()


                                    Dim rwAlta As DataRow() = nConsultaContpaq(sql)
                                    If rwAlta Is Nothing = False Then
                                        'insertamos el alta y el sueldo
                                        sql = "EXEC setSueldoInsertar  0,0.00" & ",'" & Date.Parse(rwAlta(0)("fecha").ToString()).ToShortDateString()
                                        sql += "',0,''," & rwEmpleadosC(x)("sueldodiario") & "," & rwEmpleadosC(x)("sueldointegrado") & "," & idempleado
                                        sql += ",'01/01/1900',''"

                                        If nExecute(sql) = False Then
                                            MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            'pnlProgreso.Visible = False
                                            Exit Sub


                                        End If

                                        sql = "EXEC setIngresoBajaInsertar  0," & idempleado & ",'A','" & Date.Parse(rwAlta(0)("fecha").ToString).ToShortDateString & "','01/01/1900','',''"

                                        If nExecute(sql) = False Then
                                            MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            'pnlProgreso.Visible = False
                                            Exit Sub


                                        End If

                                    End If

                                End If



                            Next

                        End If
                    End If

                    MessageBox.Show("Los empleados han sido importados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DesconectarContpaq()
                    'cargarperiodos()
                End If




            End If
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
                            sql = "delete From movimientosIMSS"
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
                                sql = "select iIdEmpleado from empleados where"
                                sql &= " cCodigoEmpleado ='" & rwEmpleadoConpaq(0)("codigoempleado") & "' AND cNombre='" & rwEmpleadoConpaq(0)("nombre") & "' AND"
                                sql &= " cApellidoP ='" & rwEmpleadoConpaq(0)("apellidopaterno") & "' AND cApellidoM='" & rwEmpleadoConpaq(0)("apellidomaterno") & "' AND fkiIdEmpresaC=" & gIdEmpresa

                                Dim rwEmpleado As DataRow() = nConsulta(sql)
                                If rwEmpleado Is Nothing = False Then

                                    sql = "EXEC setmovimientosIMSSInsertar 0"
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbopatrona.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocliente.SelectedIndexChanged

    End Sub
End Class