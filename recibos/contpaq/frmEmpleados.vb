Imports System.Text.RegularExpressions


Public Class frmEmpleados
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gIdEmpresa As String
    Public gIdCliente As String
    Public gIdEmpleado As String
    Public gIdPeriodo As String

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
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
            'If txtmaterno.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Indique Apellido materno"
            'End If


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


            'If blnNuevo Then
            '    SQL = "select max(iIdEmpleado) as id from empleados"
            '    Dim rwFilas As DataRow() = nConsulta(SQL)

            '    If rwFilas Is Nothing = False Then
            '        Dim Fila As DataRow = rwFilas(0)
            '        SQL = "EXEC setSueldoInsertar  0," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & ",'" & Format(dtppatrona.Value.Date, "yyyy/dd/MM")
            '        SQL += "',0,''," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text) & "," & Fila.Item("id")
            '        SQL += ",'01/01/1900',''"

            '    End If
            'Else
            '    'verificamos el cambio de algun dato
            '    SQL = "select * from empleados where iIdEmpleado = " & gIdEmpleado
            '    Dim rwFilas As DataRow() = nConsulta(SQL)

            '    If rwFilas Is Nothing = False Then

            '        Dim Fila As DataRow = rwFilas(0)
            '        If Fila.Item("fSueldoOrd") <> IIf(txtsalario.Text = "", 0, txtsalario.Text) Or Fila.Item("fSueldoBase") <> IIf(txtsd.Text = "", 0, txtsd.Text) Or Fila.Item("fSueldoIntegrado") <> IIf(txtsdi.Text = "", 0, txtsdi.Text) Then

            '            SQL = "EXEC setSueldoInsertar  0," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & ",'" & Date.Today.ToShortDateString()
            '            SQL += "',0,''," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text) & "," & gIdEmpleado
            '            SQL += ",'01/01/1900',''"
            '            Enviar_Mail(GenerarCorreo(gIdEmpresa, cboclientefiscal.SelectedValue, gIdEmpleado), "p.isidro@mbcgroup.mx;l.aquino@mbcgroup.mx;r.garcia@mbcgroup.mx", "Cambio en sueldo")
            '        End If


            '    End If
            'End If

            'If SQL <> "" Then
            '    If nExecute(SQL) = False Then
            '        Exit Sub
            '    End If
            'End If


            '---



            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setempleadosCInsertar 0,'" & txtcodigo.Text & "','" & txtnombre.Text
                SQL &= "','" & txtpaterno.Text
                SQL &= "','" & txtmaterno.Text & "','" & txtpaterno.Text & " " & txtmaterno.Text & " " & txtnombre.Text
                SQL &= "','" & txtrfc.Text & "','" & txtcurp.Text & "','" & txtimss.Text
                SQL &= "','" & txtdireccion.Text
                SQL &= "','" & txtciudad.Text & "'," & cboestado.SelectedValue & ",'" & txtcp.Text
                SQL &= "'," & cbosexo.SelectedIndex & ",'" & Format(dtpfechanac.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpCaptura.Value.Date, "yyyy/dd/MM")
                SQL &= "','','" & txtfunciones.Text
                SQL &= "'," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text)
                SQL &= ",'','" & txtnacionalidad.Text & "','','','" & txtduracion.Text & "','" & txtcomentarios.Text
                SQL &= "'," & gIdEmpresa & "," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & ",0" & ",-1" & "," & cbopertenece.SelectedIndex + 1 & "," & cbobanco.SelectedValue
                SQL &= ",'" & txtcuenta.Text & "',1,'" & txtdireccionP.Text
                SQL &= "','" & txtciudadP.Text & "'," & cboestadoP.SelectedValue & ",'" & txtcp2.Text
                SQL &= "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpsindicato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpantiguedad.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & cboautorizacion.SelectedIndex & ",'" & txtclabe.Text & "','" & txtintegrar.Text
                SQL &= "'," & cbocategoria.SelectedIndex & ",'" & txtcredito.Text & "','" & cbotipofactor.Text
                SQL &= "'," & IIf(txtfactor.Text = "", 0, txtfactor.Text) & ",'" & cbojornada.Text & "','" & txtcorreo.Text
                SQL &= "','" & txthorario.Text & "','" & txthoras.Text & "','" & txtdescanso.Text & "'," & IIf(cbostatus.SelectedIndex = 0, -1, 1)
                SQL &= "," & cbopuesto.SelectedValue & "," & cbodepartamento.SelectedValue
                SQL &= "," & cboedocivil.SelectedIndex
                SQL &= "," & cbobanco2.SelectedValue
                SQL &= ",'" & txtcuenta2.Text
                SQL &= "','" & txtclabe2.Text & "'"
                SQL &= "," & txtExtra.Text
            Else
                'Actualizar

                SQL = "EXEC setempleadosCActualizar  " & gIdEmpleado & ",'" & txtcodigo.Text & "','" & txtnombre.Text
                SQL &= "','" & txtpaterno.Text
                SQL &= "','" & txtmaterno.Text & "','" & txtpaterno.Text & " " & txtmaterno.Text & " " & txtnombre.Text
                SQL &= "','" & txtrfc.Text & "','" & txtcurp.Text & "','" & txtimss.Text
                SQL &= "','" & txtdireccion.Text
                SQL &= "','" & txtciudad.Text & "'," & cboestado.SelectedValue & ",'" & txtcp.Text
                SQL &= "'," & cbosexo.SelectedIndex & ",'" & Format(dtpfechanac.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpCaptura.Value.Date, "yyyy/dd/MM")
                SQL &= "','','" & txtfunciones.Text
                SQL &= "'," & IIf(txtsd.Text = "", 0, txtsd.Text) & "," & IIf(txtsdi.Text = "", 0, txtsdi.Text)
                SQL &= ",'','" & txtnacionalidad.Text & "','','','" & txtduracion.Text & "','" & txtcomentarios.Text
                SQL &= "'," & gIdEmpresa & "," & IIf(txtsalario.Text = "", 0, txtsalario.Text) & ",0" & ",-1" & "," & cbopertenece.SelectedIndex + 1 & "," & cbobanco.SelectedValue
                SQL &= ",'" & txtcuenta.Text & "',1,'" & txtdireccionP.Text
                SQL &= "','" & txtciudadP.Text & "'," & cboestadoP.SelectedValue & ",'" & txtcp2.Text
                SQL &= "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpsindicato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpantiguedad.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & cboautorizacion.SelectedIndex & ",'" & txtclabe.Text & "','" & txtintegrar.Text
                SQL &= "'," & cbocategoria.SelectedIndex & ",'" & txtcredito.Text & "','" & cbotipofactor.Text
                SQL &= "'," & IIf(txtfactor.Text = "", 0, txtfactor.Text) & ",'" & cbojornada.Text & "','" & txtcorreo.Text
                SQL &= "','" & txthorario.Text & "','" & txthoras.Text & "','" & txtdescanso.Text & "'," & IIf(cbostatus.SelectedIndex = 0, -1, 1)
                SQL &= "," & cbopuesto.SelectedValue & "," & cbodepartamento.SelectedValue
                SQL &= "," & cboedocivil.SelectedIndex
                SQL &= "," & cbobanco2.SelectedValue
                SQL &= ",'" & txtcuenta2.Text
                SQL &= "','" & txtclabe2.Text & "'"
                SQL &= "," & txtExtra.Text

            End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If

            'Agregar alta/baja
            'If blnNuevo Then
            '    'Obtener id
            '    SQL = "select max(iIdEmpleado) as id from empleados"
            '    Dim rwFilas As DataRow() = nConsulta(SQL)

            '    If rwFilas Is Nothing = False Then
            '        Dim Fila As DataRow = rwFilas(0)
            '        SQL = "EXEC setIngresoBajaInsertar  0," & Fila.Item("id") & ",'" & IIf(cbostatus.SelectedIndex = 0, "A", "B") & "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','01/01/1900','',''"
            '        'Enviar correo
            '        Enviar_Mail(GenerarCorreo(gIdEmpresa, cboclientefiscal.SelectedValue, Fila.Item("id")), "p.isidro@mbcgroup.mx;l.aquino@mbcgroup.mx;r.garcia@mbcgroup.mx", "Alta de empleado")
            '    End If


            'Else
            '    SQL = "select * from IngresoBaja"
            '    SQL &= " where iIdIngresoBaja= (select max(iIdIngresoBaja) "
            '    SQL &= " as maximo from IngresoBaja where fkiIdEmpleado =" & gIdEmpleado & ")"


            '    Dim rwFilas As DataRow() = nConsulta(SQL)

            '    If rwFilas Is Nothing = False Then
            '        SQL = ""
            '        Dim Fila As DataRow = rwFilas(0)
            '        If Fila.Item("Clave") <> IIf(cbostatus.SelectedIndex = 0, "A", "B") Then

            '            SQL = "EXEC setIngresoBajaInsertar  0," & gIdEmpleado & ",'" & IIf(cbostatus.SelectedIndex = 0, "A", "B") & "','" & Date.Today.ToShortDateString & "','01/01/1900','',''"
            '            Enviar_Mail(GenerarCorreo(gIdEmpresa, cboclientefiscal.SelectedValue, gIdEmpleado), "p.isidro@mbcgroup.mx;l.aquino@mbcgroup.mx;r.garcia@mbcgroup.mx", "Modificacion Baja/reingreso")

            '        End If


            '    End If


            'End If

            'If SQL <> "" Then
            '    If nExecute(SQL) = False Then
            '        Exit Sub
            '    End If
            'End If




            gIdEmpleado = ""

            gIdCliente = ""


            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Limpiar(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        If blnNuevo Then
            'Cargar los datos anteriores
        Else
            Limpiar(Me)
        End If
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarEmpleado
        Forma.gIdEmpresa = gIdEmpresa
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            gIdEmpleado = Forma.gIdEmpleado
            MostrarEmpleado(Forma.gIdEmpleado)

        End If
    End Sub
    Private Sub MostrarEmpleado(idempleado As String)
        SQL = "select * from empleadosC where iIdEmpleadoC = " & idempleado
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)
                cbostatus.SelectedIndex = IIf(Fila.Item("fkiIdClienteInter") = 1, 1, 0)
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
                cboedocivil.SelectedIndex = Integer.Parse(Fila.Item("iEstadoCivil"))
                'item.SubItems.Add("" & civil)
                cbopertenece.SelectedIndex = Integer.Parse(Fila.Item("iOrigen")) - 1
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
                'cboClientes.SelectedValue = Fila.Item("fkiIdClienteInter")
                cbopuesto.SelectedValue = Fila.Item("fkiIdPuesto")
                cbodepartamento.SelectedValue = Fila.Item("fkiIdDepartamento")

                txtcuenta2.Text = Fila.Item("cuenta2")
                'item.SubItems.Add("" & Fila.Item("NumCuenta"))
                txtclabe2.Text = Fila.Item("clabe2")
                'item.SubItems.Add("" & Fila.Item("Clabe"))
                txtsalario.Text = Fila.Item("fSueldoOrd")
                SQL = "select * from bancos where iIdBanco=" & Fila.Item("fkiIdBanco2")
                Dim Banco2 As DataRow() = nConsulta(SQL)
                cbobanco2.SelectedValue = Banco2(0).Item("iIdBanco")

                txtExtra.Text = Fila.Item("fsindicatoExtra")

                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
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
        cbobanco2.SelectedIndex = 0

        cbocategoria.SelectedIndex = 0

        cboedocivil.SelectedIndex = 0
        cboestado.SelectedIndex = 0
        cboestadoP.SelectedIndex = 0
        cbojornada.SelectedIndex = 0
        cbosexo.SelectedIndex = 0
        cbostatus.SelectedIndex = 0
        cbotipofactor.SelectedIndex = 0
        'cboclientefiscal.SelectedIndex = 0
        cbodepartamento.SelectedIndex = 0
        cbopuesto.SelectedIndex = 0
        'cboClientes.SelectedIndex = 0



    End Sub

    Private Sub frmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarEstados()
        MostrarEstadosP()
        MostrarBancos()
        MostrarBancos2()
        MostrarEmpresa()
        'MostrarCliente()
        'MostrarClienteS()
        MostrarPuesto()
        MostrarDepartamentos()
        blnNuevo = True


        'blnNuevo = gIdEmpleado = ""


        If gIdEmpleado = "" Then
            blnNuevo = True
            cboautorizacion.SelectedIndex = 0
            cbobanco.SelectedIndex = 0
            cbobanco2.SelectedIndex = 0
            cbocategoria.SelectedIndex = 0

            cboedocivil.SelectedIndex = 0
            cboestado.SelectedIndex = 0
            cboestadoP.SelectedIndex = 0
            cbojornada.SelectedIndex = 0
            cbosexo.SelectedIndex = 0
            cbostatus.SelectedIndex = 0
            cbotipofactor.SelectedIndex = 0
            'cboclientefiscal.SelectedIndex = 0
            cbodepartamento.SelectedIndex = 0
            cbopuesto.SelectedIndex = 0
            'cboClientes.SelectedIndex = 0
            cbopertenece.SelectedIndex = 0
            'Limpiar(Me)
        Else
            blnNuevo = False
            MostrarEmpleado()
        End If
    End Sub

    Private Sub MostrarDepartamentos()
        SQL = "Select * from departamentos where fkiIdEmpresa=" & gIdEmpresa
        SQL &= " order by cnombre"
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
        SQL = "Select * from Puestos where fkiIdEmpresa=" & gIdEmpresa
        SQL &= " order by cnombre"
        nCargaCBO(cbopuesto, SQL, "cnombre", "iIdPuesto")
        cbopuesto.SelectedIndex = 0
        'cboClientes.SelectedValue = gIdCliente

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    'Private Sub MostrarClienteS()
    '    'Verificar si se tienen permisos
    '    SQL = "select * from usuarios where idUsuario = " & idUsuario
    '    Dim rwFilas As DataRow() = nConsulta(SQL)
    '    Dim Forma As New frmTipoEmpresa
    '    Try
    '        If rwFilas Is Nothing = False Then


    '            Dim Fila As DataRow = rwFilas(0)
    '            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

    '                SQL = "Select nombre,iIdCliente from clientes"
    '            Else
    '                SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
    '                SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
    '                SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
    '                SQL &= "  order by nombre "


    '            End If
    '            nCargaCBO(cboClientes, SQL, "nombre", "iIdCliente")
    '            cboClientes.SelectedValue = gIdCliente
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    'SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
    '    'SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
    '    'SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
    '    'SQL &= "  order by nombre "
    '    'nCargaCBO(cboClientes, SQL, "nombre", "iIdCliente")
    '    'SQL = "Select * from clientes order by nombre"
    '    'nCargaCBO(cboClientes, SQL, "nombre", "iIdCliente")
    '    'cboClientes.SelectedValue = gIdCliente
    'End Sub
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
                cboedocivil.SelectedIndex = Fila.Item("iOrigen")
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
                'cboClientes.SelectedValue = Fila.Item("fkiIdClienteInter")
                cbopuesto.SelectedValue = Fila.Item("fkiIdPuesto")
                cbodepartamento.SelectedValue = Fila.Item("fkiIdDepartamento")


                txtcuenta.Text = Fila.Item("cuenta2")
                'item.SubItems.Add("" & Fila.Item("NumCuenta"))
                txtclabe.Text = Fila.Item("clabe2")
                'item.SubItems.Add("" & Fila.Item("Clabe"))

                SQL = "select * from bancos where iIdBanco=" & Fila.Item("fkiIdBanco2")
                Dim Banco2 As DataRow() = nConsulta(SQL)
                cbobanco2.SelectedValue = Banco2(0).Item("iIdBanco")


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

    Private Sub MostrarBancos2()
        SQL = "Select * from bancos order by cBanco"
        nCargaCBO(cbobanco2, SQL, "cBanco", "iIdBanco")
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
        SQL = "select * from empresaC where iIdEmpresaC = " & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                'lblEmpresa.Text = "Empresa: " & Fila.Item("nombre")
                'lblDireccion.Text = "Direccion: " & Fila.Item("calle") & " " & Fila.Item("numero") & " " & Fila.Item("numeroint") & " " & Fila.Item("colonia") & " "

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdincidencias_Click(sender As Object, e As EventArgs) Handles cmdincidencias.Click
        If blnNuevo = False Then
            Dim Forma As New frmIncidenciaEmpleado
            Forma.gIdEmpresa = gIdEmpresa
            Forma.gIdEmpleado = gIdEmpleado
            Forma.gIdPeriodo = gIdPeriodo
            Forma.gIdCliente = gIdCliente
            Forma.ShowDialog()



        Else
            MessageBox.Show("Seleccione un empleado primeramente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub cmdprestamo_Click(sender As Object, e As EventArgs) Handles cmdprestamo.Click
        If blnNuevo = False Then
            Dim Forma As New frmPrestamoEmpleado
            Forma.gIdEmpresa = gIdEmpresa
            Forma.gIdEmpleado = gIdEmpleado
            Forma.gIdPeriodo = gIdPeriodo
            Forma.gIdCliente = gIdCliente
            Forma.ShowDialog()



        Else
            MessageBox.Show("Seleccione un empleado primeramente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub txtExtra_TextChanged(sender As Object, e As EventArgs) Handles txtExtra.TextChanged

    End Sub

    Private Sub txtExtra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExtra.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    'Private Sub MostrarCliente()
    '    'Verificar si se tienen permisos
    '    SQL = "select * from usuarios where idUsuario = " & idUsuario
    '    Dim rwFilas As DataRow() = nConsulta(SQL)
    '    Dim Forma As New frmTipoEmpresa
    '    Try
    '        If rwFilas Is Nothing = False Then


    '            Dim Fila As DataRow = rwFilas(0)
    '            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

    '                SQL = "Select nombre,iIdCliente from clientes"
    '            Else
    '                SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
    '                SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
    '                SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
    '                SQL &= "  order by nombre "


    '            End If
    '            nCargaCBO(cboclientefiscal, SQL, "nombre", "iIdCliente")
    '            cboclientefiscal.SelectedValue = gIdCliente
    '        End If

    '    Catch ex As Exception

    '    End Try
    '    'SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
    '    'SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
    '    'SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
    '    'SQL &= "  order by nombre "
    '    'nCargaCBO(cboclientefiscal, SQL, "nombre", "iIdCliente")
    '    'cboclientefiscal.SelectedValue = gIdCliente
    'End Sub

    Private Sub cmdfiniquito_Click(sender As System.Object, e As System.EventArgs) Handles cmdfiniquito.Click
        If blnNuevo = False Then
            Dim Forma As New frmPrestamoEmpleado
            Forma.gIdEmpresa = gIdEmpresa
            Forma.gIdEmpleado = gIdEmpleado
            Forma.gIdPeriodo = gIdPeriodo
            Forma.gIdCliente = gIdCliente
            Forma.ShowDialog()



        Else
            MessageBox.Show("Seleccione un empleado primeramente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
End Class