Imports System.Text.RegularExpressions


Public Class frmAltaEmpleado
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gIdEmpresa As String
    Public gIdCliente As String
    Public gIdEmpleado As String
    Public iOrigen As String
    Public iEmpresaC As String


    Private Sub frmAltaEmpleado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MostrarEstados()
        MostrarEstadosP()
        MostrarBancos()
        MostrarEmpresa()
        MostrarCliente()
        MostrarClienteS()
        MostrarPuesto()
        MostrarDepartamentos()


        'blnNuevo = gIdEmpleado = ""
        

        If gIdEmpleado = "" Then
            blnNuevo = True
            cboautorizacion.SelectedIndex = 0
            cbobanco.SelectedIndex = 0
            cbocategoria.SelectedIndex = 0

            cboedocivil.SelectedIndex = 0
            cboestado.SelectedIndex = 0
            cboestadoP.SelectedIndex = 0
            cbojornada.SelectedIndex = 0
            cbosexo.SelectedIndex = 0
            cbostatus.SelectedIndex = 0
            cbotipofactor.SelectedIndex = 0
            cboclientefiscal.SelectedIndex = 0
            cbodepartamento.SelectedIndex = 0
            cbopuesto.SelectedIndex = 0
            cboClientes.SelectedIndex = 0
            'Limpiar(Me)
        Else
            blnNuevo = False
            MostrarEmpleado()
        End If


    End Sub

    Private Sub MostrarDepartamentos()


        If gIdEmpleado = "" Then
            SQL = "select top(5) * from empleados inner join empresa on empleados.fkiIdEmpresa= empresa.iIdEmpresa where iIdEmpresa = " & gIdEmpresa
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas(0)("fkiIdEmpresaC").ToString() = "0" Then

                SQL = "Select * from departamentos where fkiIdEmpresa=" & gIdEmpresa
                SQL &= " order by cnombre"
            Else

                SQL = "Select * from departamentos where fkiIdEmpresa=" & rwFilas(0)("fkiIdEmpresaC")
                SQL &= " order by cnombre"

            End If

        Else
            SQL = "select * from empleados where iIdEmpleado = " & gIdEmpleado
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas(0)("fkiIdEmpresaC").ToString() = "0" Then

                SQL = "Select * from departamentos where fkiIdEmpresa=" & gIdEmpresa
                SQL &= " order by cnombre"
            Else

                SQL = "Select * from departamentos where fkiIdEmpresa=" & rwFilas(0)("fkiIdEmpresaC")
                SQL &= " order by cnombre"

            End If
        End If




        nCargaCBO(cbodepartamento, SQL, "cnombre", "iIdDepartamento")
        cbodepartamento.SelectedIndex = 0
        'cboClientes.SelectedValue = gIdCliente
    End Sub
    Private Sub MostrarPuesto()
        'SQL = "select * from UsuarioClientes inner join IntClienteEmpresa"
        'SQL &= " on UsuarioClientes.fkiIdCliente= IntClienteEmpresa.fkIdCliente"
        'SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
        'SQL &= " And IntClienteEmpresa.fkIdEmpresa =" & gIdEmpresa

        'Dim rwFilas As DataRow() = nConsulta(SQL)
        'Try
        '    If rwFilas Is Nothing = False Then

        '        Dim Fila As DataRow = rwFilas(0)
        If gIdEmpleado = "" Then
            SQL = "select top(5) * from empleados inner join empresa on empleados.fkiIdEmpresa= empresa.iIdEmpresa where iIdEmpresa = " & gIdEmpresa
            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas(0)("fkiIdEmpresaC").ToString() = "0" Then
                SQL = "Select * from Puestos where fkiIdEmpresa=" & gIdEmpresa
                SQL &= " order by cnombre"
            Else
                SQL = "Select * from Puestos where fkiIdEmpresa=" & rwFilas(0)("fkiIdEmpresaC")
                SQL &= " order by cnombre"
            End If


        Else
            SQL = "select * from empleados where iIdEmpleado = " & gIdEmpleado
            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas(0)("fkiIdEmpresaC").ToString() = "0" Then
                SQL = "Select * from Puestos where fkiIdEmpresa=" & gIdEmpresa
                SQL &= " order by cnombre"
            Else
                SQL = "Select * from Puestos where fkiIdEmpresa=" & rwFilas(0)("fkiIdEmpresaC")
                SQL &= " order by cnombre"
            End If
        End If


        nCargaCBO(cbopuesto, SQL, "cnombre", "iIdPuesto")
        cbopuesto.SelectedIndex = 0
        'cboClientes.SelectedValue = gIdCliente

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub MostrarClienteS()
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                    SQL = "Select nombre,iIdCliente from clientes order by nombre "
                Else
                    SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
                    SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
                    SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    SQL &= "  order by nombre "


                End If
                nCargaCBO(cboClientes, SQL, "nombre", "iIdCliente")
                cboClientes.SelectedValue = gIdCliente
            End If

        Catch ex As Exception

        End Try

        'SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
        'SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
        'SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
        'SQL &= "  order by nombre "
        'nCargaCBO(cboClientes, SQL, "nombre", "iIdCliente")
        'SQL = "Select * from clientes order by nombre"
        'nCargaCBO(cboClientes, SQL, "nombre", "iIdCliente")
        'cboClientes.SelectedValue = gIdCliente
    End Sub
    Private Sub MostrarEmpleado()

        SQL = "select * from empleados where iIdEmpleado = " & gIdEmpleado
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)
                cbostatus.SelectedIndex = IIf(Fila.Item("iEstatus") = 1, 0, 1)
                txtcodigo.Text = Fila.Item("cCodigoEmpleado")
                txtnombre.Text = Fila.Item("cNombre")
                txtpaterno.Text = Fila.Item("cApellidoP")
                txtmaterno.Text = Fila.Item("cApellidoM")
                Dim fechanac As Date
                fechanac = Fila.Item("dFechaNac")
                dtpfechanac.Value = Fila.Item("dFechaNac")
                Dim edad As Integer = DateDiff(DateInterval.Year, fechanac, Date.Today)
                txtedad.Text = edad.ToString()

                Dim sexo As String = IIf(Fila.Item("iSexo") = "0", "Femenino", "Masculino")
                cbosexo.SelectedIndex = Fila.Item("iSexo")
                'item.SubItems.Add("" & sexo)
                'Dim civil As String = IIf(Fila.Item("iOrigen") = "0", "Soltero", "Casado")
                cboedocivil.SelectedIndex = Fila.Item("iEstadoCivil")
                'item.SubItems.Add("" & civil)

                'item.SubItems.Add("" & Fila.Item("cPuesto"))
                txtfunciones.Text = Fila.Item("cFuncionesPuesto")
                'item.SubItems.Add("" & Fila.Item("cFuncionesPuesto"))
                cbocategoria.SelectedIndex = Fila.Item("iCategoria")
                'Dim Categoria As String = IIf(Fila.Item("iCategoria") = "0", "A", "B")
                'item.SubItems.Add("" & Categoria)
                dtppatrona.Value = Fila.Item("dFechaPatrona")
                'item.SubItems.Add("" & Fila.Item("dFechaPatrona"))
                dtpsindicato.Value = Fila.Item("dFechaSindicato")
                'item.SubItems.Add("" & Fila.Item("dFechaSindicato"))
                txtintegrar.Text = Fila.Item("cIntegrar")
                'item.SubItems.Add("" & Fila.Item("cIntegrar"))
                txtsd.Text = Fila.Item("fSueldoBase")
                'item.SubItems.Add("" & Fila.Item("fSueldoBase"))
                txtsdi.Text = Fila.Item("fSueldoIntegrado")
                'item.SubItems.Add("" & Fila.Item("fSueldoIntegrado"))

                'item.SubItems.Add("" & Fila.Item("dFechaNac"))
                txtcurp.Text = Fila.Item("cCURP")
                'item.SubItems.Add("" & Fila.Item("cCURP"))
                txtrfc.Text = Fila.Item("cRFC")
                'item.SubItems.Add("" & Fila.Item("cRFC"))
                txtimss.Text = Fila.Item("cIMSS")
                'item.SubItems.Add("" & Fila.Item("cIMSS"))
                cboautorizacion.SelectedIndex = Fila.Item("iPermanente")
                'item.SubItems.Add("" & IIf(Fila.Item("iPermanente") = "0", "No", "Si"))
                txtcredito.Text = Fila.Item("cInfonavit")
                'item.SubItems.Add("" & Fila.Item("cInfonavit"))
                cbotipofactor.Text = Fila.Item("cTipoFactor")
                'item.SubItems.Add("" & Fila.Item("cTipoFactor"))
                txtfactor.Text = Fila.Item("fFactor")
                'item.SubItems.Add("" & Fila.Item("fFactor"))
                txtcuenta.Text = Fila.Item("NumCuenta")
                'item.SubItems.Add("" & Fila.Item("NumCuenta"))
                txtclabe.Text = Fila.Item("Clabe")
                'item.SubItems.Add("" & Fila.Item("Clabe"))

                SQL = "select * from bancos where iIdBanco=" & Fila.Item("fkiIdBanco")
                Dim Banco As DataRow() = nConsulta(SQL)
                cbobanco.SelectedValue = Banco(0).Item("iIdBanco")
                'item.SubItems.Add("" & Banco(0).Item("cBanco"))
                txtnacionalidad.Text = Fila.Item("cNacionalidad")
                'item.SubItems.Add("" & Fila.Item("cNacionalidad"))
                txtdireccion.Text = Fila.Item("cDireccion")
                'item.SubItems.Add("" & Fila.Item("cDireccion"))
                txtciudad.Text = Fila.Item("cCiudadL")
                'item.SubItems.Add("" & Fila.Item("cCiudadL"))

                SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstado")
                Dim Estado As DataRow() = nConsulta(SQL)
                cboestado.SelectedValue = Estado(0).Item("iIdEstado")
                'item.SubItems.Add("" & Estado(0).Item("cEstado"))
                txtcp.Text = Fila.Item("cCP")
                'item.SubItems.Add("" & Fila.Item("cCP"))
                dtpantiguedad.Value = Fila.Item("dFechaAntiguedad")
                'item.SubItems.Add("" & Fila.Item("dFechaAntiguedad"))
                txtdireccionP.Text = Fila.Item("cDireccionP")
                txtciudadP.Text = Fila.Item("cCiudadP")
                'item.SubItems.Add("" & Fila.Item("cDireccionP") & "" & Fila.Item("cCiudadP"))
                txtduracion.Text = Fila.Item("cDuracion")
                'item.SubItems.Add("" & Fila.Item("cDuracion"))
                cbojornada.Text = Fila.Item("cJornada")
                'item.SubItems.Add("" & Fila.Item("cJornada"))
                txtcomentarios.Text = Fila.Item("cObservaciones")
                'item.SubItems.Add("" & Fila.Item("cObservaciones"))
                txtcorreo.Text = Fila.Item("cCorreo")
                'item.SubItems.Add("" & Fila.Item("cCorreo"))
                txthorario.Text = Fila.Item("cHorario")
                'item.SubItems.Add("" & Fila.Item("cHorario"))
                txthoras.Text = Fila.Item("cHoras")
                'item.SubItems.Add("" & Fila.Item("cHoras"))
                txtdescanso.Text = Fila.Item("cDescanso")
                'item.SubItems.Add("" & Fila.Item("cDescanso"))
                cboClientes.SelectedValue = Fila.Item("fkiIdClienteInter")
                cbopuesto.SelectedValue = Fila.Item("fkiIdPuesto")
                cbodepartamento.SelectedValue = Fila.Item("fkiIdDepartamento")
                iOrigen = Fila.Item("iOrigen")
                iEmpresaC = Fila.Item("fkiIdEmpresaC")
                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarBancos()
        SQL = "Select * from bancos order by cBanco"
        nCargaCBO(cbobanco, SQL, "cBanco", "iIdBanco")
        cbobanco.SelectedIndex = 0
    End Sub
    Private Sub MostrarEstados()
        SQL = "Select * from Cat_Estados order by iIdEstado"
        nCargaCBO(cboestado, SQL, "cEstado", "iIdEstado")
        cboestado.SelectedIndex = 0
    End Sub

    Private Sub MostrarEstadosP()
        SQL = "Select * from Cat_Estados order by iIdEstado"
        nCargaCBO(cboestadoP, SQL, "cEstado", "iIdEstado")
        cboestadoP.SelectedIndex = 0
    End Sub

    Private Sub MostrarEmpresa()
        SQL = "select * from empresa where iIdEmpresa = " & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                lblEmpresa.Text = "Empresa: " & Fila.Item("nombre")
                lblDireccion.Text = "Direccion: " & Fila.Item("calle") & " " & Fila.Item("numero") & " " & Fila.Item("numeroint") & " " & Fila.Item("colonia") & " "

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarCliente()
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                    SQL = "Select nombre,iIdCliente from clientes order by nombre"
                Else
                    SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
                    SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
                    SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    SQL &= "  order by nombre "


                End If
                nCargaCBO(cboclientefiscal, SQL, "nombre", "iIdCliente")
                cboclientefiscal.SelectedValue = gIdCliente
            End If

        Catch ex As Exception

        End Try
        'SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
        'SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
        'SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
        'SQL &= "  order by nombre "
        'nCargaCBO(cboclientefiscal, SQL, "nombre", "iIdCliente")
        'cboclientefiscal.SelectedValue = gIdCliente
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        If blnNuevo Then
            'Cargar los datos anteriores
        Else
            Limpiar(Me)
        End If
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            'Validar
            If txtcodigo.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el codigo a guardar"
            End If
            If txtnombre.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el nombre del trabajador"
            End If
            If txtpaterno.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique Apellido paterno"
            End If
            If txtmaterno.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique Apellido materno"
            End If


            If txtcorreo.Text.Trim.Length > 0 And Mensaje = "" Then
                If Not Regex.IsMatch(txtcorreo.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") Then
                    Mensaje = "El email no tiene una forma correcta de correo electrónico (usuario@dominio.com)."
                    Me.txtcorreo.Focus()
                End If
            End If


            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Validar si ya esta el codigo del empleado
            If blnNuevo Then
                SQL = "select * from empleados where cCodigoEmpleado=" & txtcodigo.Text
                Dim rwCodigo As DataRow() = nConsulta(SQL)

                If rwCodigo Is Nothing = False Then
                    MessageBox.Show("El codigo de empleado ya existe por favor verifique", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
            End If


            'Agregar datos de sueldos para historial


            If blnNuevo Then

                SQL = "select max(iIdEmpleado) as id from empleados"
                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim Fila As DataRow = rwFilas(0)
                    SQL = "EXEC setSueldoInsertar  0," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & ",'" & Format(dtppatrona.Value.Date, "yyyy/dd/MM")
                    SQL += "',0,''," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text) & "," & Fila.Item("id")
                    SQL += ",'01/01/1900',''"

                End If

            Else
                'verificamos el cambio de algun dato
                SQL = "select * from empleados where iIdEmpleado = " & gIdEmpleado
                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then

                    Dim Fila As DataRow = rwFilas(0)
                    If Fila.Item("fSueldoOrd") <> IIf(txtsalario.Text = "", 0, txtsalario.Text) Or Fila.Item("fSueldoBase") <> IIf(txtsd.Text = "", 0, txtsd.Text) Or Fila.Item("fSueldoIntegrado") <> IIf(txtsdi.Text = "", 0, txtsdi.Text) Then

                        SQL = "EXEC setSueldoInsertar  0," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & ",'" & Date.Today.ToShortDateString()
                        SQL += "',0,''," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text) & "," & gIdEmpleado
                        SQL += ",'01/01/1900',''"
                        Enviar_Mail(GenerarCorreo(gIdEmpresa, cboclientefiscal.SelectedValue, gIdEmpleado), "p.isidro@mbcgroup.mx;l.aquino@mbcgroup.mx;r.garcia@mbcgroup.mx", "Cambio en sueldo")
                    End If


                End If
            End If

            If SQL <> "" Then
                If nExecute(SQL) = False Then
                    Exit Sub
                End If
            End If


            '---



            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setempleadosInsertar 0,'" & txtcodigo.Text & "','" & txtnombre.Text
                SQL &= "','" & txtpaterno.Text
                SQL &= "','" & txtmaterno.Text & "','" & txtpaterno.Text & " " & txtmaterno.Text & " " & txtnombre.Text
                SQL &= "','" & txtrfc.Text & "','" & txtcurp.Text & "','" & txtimss.Text
                SQL &= "','" & txtdireccion.Text
                SQL &= "','" & txtciudad.Text & "'," & cboestado.SelectedValue & ",'" & txtcp.Text
                SQL &= "'," & cbosexo.SelectedIndex & ",'" & Format(dtpfechanac.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpCaptura.Value.Date, "yyyy/dd/MM")
                SQL &= "','','" & txtfunciones.Text
                SQL &= "'," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text)
                SQL &= ",'','" & txtnacionalidad.Text & "','','','" & txtduracion.Text & "','" & txtcomentarios.Text
                SQL &= "'," & gIdEmpresa & "," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & ",0" & "," & cboclientefiscal.SelectedValue & ",0" & "," & cbobanco.SelectedValue
                SQL &= ",'" & txtcuenta.Text & "'," & IIf(cbostatus.SelectedIndex = 0, 1, 0) & ",'" & txtdireccionP.Text
                SQL &= "','" & txtciudadP.Text & "'," & cboestadoP.SelectedValue & ",'" & txtcp2.Text
                SQL &= "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpsindicato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpantiguedad.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & cboautorizacion.SelectedIndex & ",'" & txtclabe.Text & "','" & txtintegrar.Text
                SQL &= "'," & cbocategoria.SelectedIndex & ",'" & txtcredito.Text & "','" & cbotipofactor.Text
                SQL &= "'," & IIf(txtfactor.Text = "", 0, txtfactor.Text) & ",'" & cbojornada.Text & "','" & txtcorreo.Text
                SQL &= "','" & txthorario.Text & "','" & txthoras.Text & "','" & txtdescanso.Text & "'," & cboClientes.SelectedValue
                SQL &= "," & cbopuesto.SelectedValue & "," & cbodepartamento.SelectedValue
                SQL &= ",0," & cboedocivil.SelectedIndex

            Else
                'Actualizar

                SQL = "EXEC setempleadosActualizar  " & gIdEmpleado & ",'" & txtcodigo.Text & "','" & txtnombre.Text
                SQL &= "','" & txtpaterno.Text
                SQL &= "','" & txtmaterno.Text & "','" & txtpaterno.Text & " " & txtmaterno.Text & " " & txtnombre.Text
                SQL &= "','" & txtrfc.Text & "','" & txtcurp.Text & "','" & txtimss.Text
                SQL &= "','" & txtdireccion.Text
                SQL &= "','" & txtciudad.Text & "'," & cboestado.SelectedValue & ",'" & txtcp.Text
                SQL &= "'," & cbosexo.SelectedIndex & ",'" & Format(dtpfechanac.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpCaptura.Value.Date, "yyyy/dd/MM")
                SQL &= "','','" & txtfunciones.Text
                SQL &= "'," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text)
                SQL &= ",'','" & txtnacionalidad.Text & "','','','" & txtduracion.Text & "','" & txtcomentarios.Text
                SQL &= "'," & gIdEmpresa & "," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & "," & iOrigen & "," & cboclientefiscal.SelectedValue & ",0" & "," & cbobanco.SelectedValue
                SQL &= ",'" & txtcuenta.Text & "'," & IIf(cbostatus.SelectedIndex = 0, 1, 0) & ",'" & txtdireccionP.Text
                SQL &= "','" & txtciudadP.Text & "'," & cboestadoP.SelectedValue & ",'" & txtcp2.Text
                SQL &= "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpsindicato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpantiguedad.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & cboautorizacion.SelectedIndex & ",'" & txtclabe.Text & "','" & txtintegrar.Text
                SQL &= "'," & cbocategoria.SelectedIndex & ",'" & txtcredito.Text & "','" & cbotipofactor.Text
                SQL &= "'," & IIf(txtfactor.Text = "", 0, txtfactor.Text) & ",'" & cbojornada.Text & "','" & txtcorreo.Text
                SQL &= "','" & txthorario.Text & "','" & txthoras.Text & "','" & txtdescanso.Text & "'," & cboClientes.SelectedValue
                SQL &= "," & cbopuesto.SelectedValue & "," & cbodepartamento.SelectedValue
                SQL &= "," & iEmpresaC & "," & cboedocivil.SelectedIndex

            End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If

            'Agregar alta/baja
            If blnNuevo Then
                'Obtener id
                SQL = "select max(iIdEmpleado) as id from empleados"
                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim Fila As DataRow = rwFilas(0)
                    SQL = "EXEC setIngresoBajaInsertar  0," & Fila.Item("id") & ",'" & IIf(cbostatus.SelectedIndex = 0, "A", "B") & "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','01/01/1900','',''"
                    'Enviar correo
                    Enviar_Mail(GenerarCorreo(gIdEmpresa, cboclientefiscal.SelectedValue, Fila.Item("id")), "p.isidro@mbcgroup.mx;l.aquino@mbcgroup.mx;r.garcia@mbcgroup.mx", "Alta de empleado")
                End If

                
            Else
                SQL = "select * from IngresoBaja"
                SQL &= " where iIdIngresoBaja= (select max(iIdIngresoBaja) "
                SQL &= " as maximo from IngresoBaja where fkiIdEmpleado =" & gIdEmpleado & ")"


                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    SQL = ""
                    Dim Fila As DataRow = rwFilas(0)
                    If Fila.Item("Clave") <> IIf(cbostatus.SelectedIndex = 0, "A", "B") Then

                        SQL = "EXEC setIngresoBajaInsertar  0," & gIdEmpleado & ",'" & IIf(cbostatus.SelectedIndex = 0, "A", "B") & "','" & Date.Today.ToShortDateString & "','01/01/1900','',''"
                        Enviar_Mail(GenerarCorreo(gIdEmpresa, cboclientefiscal.SelectedValue, gIdEmpleado), "p.isidro@mbcgroup.mx;l.aquino@mbcgroup.mx;r.garcia@mbcgroup.mx", "Modificacion Baja/reingreso")

                    End If


                End If


            End If

            If SQL <> "" Then
                If nExecute(SQL) = False Then
                    Exit Sub
                End If
            End If




            gIdEmpleado = ""
            gIdEmpresa = ""
            gIdCliente = ""


            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Limpiar(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Limpiar(ByVal Contenedor As Object)
        For Each oControl In Contenedor.Controls
            If TypeOf oControl Is TabControl Or TypeOf oControl Is GroupBox Or TypeOf oControl Is Panel Then
                Limpiar(oControl)
            ElseIf TypeOf oControl Is TextBox Then
                Dim txtControl As TextBox = oControl
                txtControl.Text = ""
                txtControl.Tag = ""
            ElseIf TypeOf oControl Is ComboBox Then
                Dim cboControl As ComboBox = oControl
                cboControl.SelectedIndex = -1
                cboControl.Text = ""
            ElseIf TypeOf oControl Is ListView Then
                Dim Lista As ListView = oControl
                Lista.Items.Clear()
            ElseIf TypeOf oControl Is DateTimePicker Then
                Dim dtpControl As DateTimePicker = oControl
                dtpControl.Value = Date.Now

            End If

        Next

        cboautorizacion.SelectedIndex = 0
        cbobanco.SelectedIndex = 0
        cbocategoria.SelectedIndex = 0

        cboedocivil.SelectedIndex = 0
        cboestado.SelectedIndex = 0
        cboestadoP.SelectedIndex = 0
        cbojornada.SelectedIndex = 0
        cbosexo.SelectedIndex = 0
        cbostatus.SelectedIndex = 0
        cbotipofactor.SelectedIndex = 0
        cboclientefiscal.SelectedIndex = 0
        cbodepartamento.SelectedIndex = 0
        cbopuesto.SelectedIndex = 0
        cboClientes.SelectedIndex = 0



    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged

    End Sub

    Private Sub txtimss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtimss.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtimss_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtimss.TextChanged

    End Sub

    Private Sub txtcredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcredito.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcredito.TextChanged

    End Sub

    Private Sub txtclabe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclabe.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtclabe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtclabe.TextChanged

    End Sub

    Private Sub txtsd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsd.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtsd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsd.TextChanged

    End Sub

    Private Sub txtsdi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsdi.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtsdi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsdi.TextChanged

    End Sub

    Private Sub txtcp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcp.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcp.TextChanged

    End Sub

    Private Sub txtcp2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcp2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcp2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcp2.TextChanged

    End Sub

    Private Sub txtsalario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsalario.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtsalario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsalario.TextChanged

    End Sub

    Private Sub Label47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label47.Click

    End Sub

    Private Sub cboclientefiscal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboclientefiscal.SelectedIndexChanged

    End Sub

    Private Sub txtfactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfactor.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtfactor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfactor.TextChanged

    End Sub

    Private Sub cmdimss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdimss.Click
        Dim forma As New frmImss
        If gIdEmpleado <> "" Then
            forma.gIdEmpleado = gIdEmpleado
            forma.gIdCliente = cboClientes.SelectedValue
            forma.gIdEmpresa = 1
            forma.ShowDialog()
        Else
            MessageBox.Show("Seleccione un empleado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        
    End Sub

    Private Sub cmdjuridico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdjuridico.Click
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim forma As New frmJuridico
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "6") Then
                    forma.gIdCliente = gIdCliente
                    forma.gIdEmpleado = gIdEmpleado
                    forma.gIdEmpresa = gIdEmpresa
                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try

       
    End Sub
End Class