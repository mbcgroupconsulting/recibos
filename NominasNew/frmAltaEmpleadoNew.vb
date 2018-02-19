Imports System.Text.RegularExpressions
Public Class frmAltaEmpleadoNew
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gIdEmpresa As String
    Public gIdCliente As String
    Public gIdEmpleado As String
    Public iOrigen As String
    Public iEmpresaC As String



    Private Sub frmAltaEmpleadoNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarTipoContrato()
        MostrarJornada()
        MostrarIntegrar()
        MostrarMetodoPago()
        MostrarEstadoNac()

        MostrarEstados()
        MostrarEstadosP()
        MostrarBancos()
        MostrarBancos2()
        MostrarEmpresa()

        MostrarEmpresasC()
        MostrarPuesto()
        MostrarDepartamentos()
        IndexTab()

        'blnNuevo = gIdEmpleado = ""


        If gIdEmpleado = "" Then
            blnNuevo = True

            cboTipoContrato.SelectedIndex = 0
            cbojornada.SelectedIndex = 0
            cboIntegrar.SelectedIndex = 0
            cbometodopago.SelectedIndex = 0
            cboEdoNac.SelectedIndex = 0


            cboautorizacion.SelectedIndex = 0
            cbobanco.SelectedIndex = 0
            cbocategoria.SelectedIndex = 0

            cboedocivil.SelectedIndex = 0
            cboestadotrab.SelectedIndex = 0
            cboestadoP.SelectedIndex = 0
            cbojornada.SelectedIndex = 0
            cbosexo.SelectedIndex = 0
            cbostatus.SelectedIndex = 0
            cbotipofactor.SelectedIndex = 0
            ''Validar Si esta vacio

            cbodepartamento.SelectedIndex = 0
            cbopuesto.SelectedIndex = 0


            'Limpiar(Me)
        Else
            blnNuevo = False
            MostrarEmpleado()
        End If
    End Sub
    Private Sub IndexTab()
        cbostatus.TabIndex = 0
        txtcodigo.TabIndex = 1
        dtpCaptura.TabIndex = 2
        cboTipoContrato.TabIndex = 3
        cboIntegrar.TabIndex = 4
        cbojornada.TabIndex = 5
        txtpaterno.TabIndex = 6
        txtmaterno.TabIndex = 7
        txtnombre.TabIndex = 8
        cbosexo.TabIndex = 9
        cboedocivil.TabIndex = 10
        cbopuesto.TabIndex = 11
        txtfunciones.TabIndex = 12
        cbodepartamento.TabIndex = 13
        cbocategoria.TabIndex = 14
        txtnacionalidad.TabIndex = 15
        dtpfechanac.TabIndex = 16
        txtedad.TabIndex = 17
        dtppatrona.TabIndex = 18
        dtpsindicato.TabIndex = 19
        dtpantiguedad.TabIndex = 20
        chkAntiguedad.TabIndex = 21
        cboautorizacion.TabIndex = 22
        txtcredito.TabIndex = 23
        cbotipofactor.TabIndex = 24
        txtfactor.TabIndex = 25
        txtcurp.TabIndex = 26
        txtrfc.TabIndex = 27
        txtimss.TabIndex = 28
        cboEdoNac.TabIndex = 29
        txtsd.TabIndex = 30
        txtsdi.TabIndex = 31
        txtsalario.TabIndex = 32
        cbometodopago.TabIndex = 33
        GroupBox3.TabIndex = 34
        cbobanco.TabIndex = 35
        txtcuenta.TabIndex = 36
        txtclabe.TabIndex = 37
        txttarjeta.TabIndex = 38
        GroupBox4.TabIndex = 39
        cbobanco2.TabIndex = 40
        txtcuenta2.TabIndex = 41
        txtclabe2.TabIndex = 42
        GroupBox2.TabIndex = 43
        txtcallenum.TabIndex = 44
        txtcolonia.TabIndex = 45
        txtmunicipio.TabIndex = 46
        cboestadotrab.TabIndex = 47
        txtcp.TabIndex = 48
        GroupBox1.TabIndex = 49
        txtdireccionP.TabIndex = 50
        txtciudadP.TabIndex = 51
        cboestadoP.TabIndex = 52
        txtcp2.TabIndex = 53
        txtRegistroPatronal.TabIndex = 54
        cbEmpresasC.TabIndex = 55
        txthorario.TabIndex = 56
        txthoras.TabIndex = 57
        txtdescanso.TabIndex = 58
        txtFechapago.TabIndex = 59
        txtFormaPago.TabIndex = 60
        txtlugarpago.TabIndex = 61
        txtlugarfirma.TabIndex = 62
        dtpFechaterminocontrato.TabIndex = 63
        txtcorreo.TabIndex = 64
        txtcomentarios.TabIndex = 65



    End Sub

    Private Sub MostrarEmpleado()

        SQL = "select * from empleadosAlta where iIdEmpleadoAlta = " & gIdEmpleado
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

                Dim fechaalta As Date
                fechaalta = Fila.Item("dFechaCap")
                dtpCaptura.Value = Fila.Item("dFechaCap")

                Dim sexo As String = IIf(Fila.Item("iSexo") = "0", "Femenino", "Masculino")
                cbosexo.SelectedIndex = Fila.Item("iSexo")
                
                cboedocivil.SelectedIndex = Fila.Item("iEstadoCivil")
           
                txtfunciones.Text = Fila.Item("cFuncionesPuesto")

                cbocategoria.SelectedIndex = Fila.Item("iCategoria")
                'Dim Categoria As String = IIf(Fila.Item("iCategoria") = "0", "A", "B")
                'item.SubItems.Add("" & Categoria)
                dtppatrona.Value = Fila.Item("dFechaPatrona")
                'item.SubItems.Add("" & Fila.Item("dFechaPatrona"))
                dtpsindicato.Value = Fila.Item("dFechaSindicato")

                cboIntegrar.SelectedIndex = Fila.Item("cIntegrar")
                'item.SubItems.Add("" & Fila.Item("cIntegrar"))
                txtsd.Text = Fila.Item("fSueldoBase")
                'item.SubItems.Add("" & Fila.Item("fSueldoBase"))
                txtsdi.Text = Fila.Item("fSueldoIntegrado")
                'item.SubItems.Add("" & Fila.Item("fSueldoIntegrado"))
                txtsalario.Text = Fila.Item("fSueldoOrd")


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

                SQL = "select * from bancos where iIdBanco=" & Fila.Item("fkiIdBanco2")
                Dim Banco2 As DataRow() = nConsulta(SQL)
                cbobanco2.SelectedValue = Banco2(0).Item("iIdBanco")

                'item.SubItems.Add("" & Banco(0).Item("cBanco"))
                txtnacionalidad.Text = Fila.Item("cNacionalidad")
                'item.SubItems.Add("" & Fila.Item("cNacionalidad"))
                txtcallenum.Text = Fila.Item("cCalleNumero")
                'item.SubItems.Add("" & Fila.Item("cDireccion"))
                txtciudadP.Text = Fila.Item("cCiudadP")
                'item.SubItems.Add("" & Fila.Item("cCiudadL"))

                SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstadoNac")
                Dim Estado As DataRow() = nConsulta(SQL)
                cboEdoNac.SelectedValue = Estado(0).Item("iIdEstado")

                'item.SubItems.Add("" & Estado(0).Item("cEstado"))
                txtcp.Text = Fila.Item("cCP")
                'item.SubItems.Add("" & Fila.Item("cCP"))
                dtpantiguedad.Value = Fila.Item("dFechaAntiguedad")
                'item.SubItems.Add("" & Fila.Item("dFechaAntiguedad"))
                txtdireccionP.Text = Fila.Item("cDireccionP")
                txtciudadP.Text = Fila.Item("cCiudadP")
                txtFechapago.Text = Fila.Item("cFechaPago")

                txtcolonia.Text = Fila.Item("cColonia")
                txtmunicipio.Text = Fila.Item("cMunicipio")
                txtcp2.Text = Fila.Item("cCPP")
              
                cbojornada.SelectedValue = Fila.Item("cJornada")
                'item.SubItems.Add("" & Fila.Item("cJornada"))
                txtcomentarios.Text = Fila.Item("cObservaciones")
                'item.SubItems.Add("" & Fila.Item("cObservaciones"))
                txtcorreo.Text = Fila.Item("cCorreo")
                'item.SubItems.Add("" & Fila.Item("cCorreo"))
                txthorario.Text = Fila.Item("cHorario")
                txthoras.Text = Fila.Item("cHoras")
                txtdescanso.Text = Fila.Item("cDescanso")


                txtnacionalidad.Text = Fila.Item("cNacionalidad")

                txttarjeta.Text = Fila.Item("Numtarjeta")
                txtcuenta2.Text = Fila.Item("cuenta2")
                txtclabe2.Text = Fila.Item("clabe2")


                SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstado")
                Dim Estado2 As DataRow() = nConsulta(SQL)
                cboestadotrab.SelectedValue = Estado2(0).Item("iIdEstado")


                SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstadoP")
                Dim cEstadoP As DataRow() = nConsulta(SQL)
                cboestadoP.SelectedValue = cEstadoP(0).Item("iIdEstado")

                cbopuesto.SelectedValue = Fila.Item("fkiIdPuesto")
                cbodepartamento.SelectedValue = Fila.Item("fkiIdDepartamento")

                cbotipofactor.SelectedIndex = Fila.Item("cTipoFactor")

                SQL = "select * from Cat_TipoContratoAlta where iIdTipoContratoAlta=" & Fila.Item("fkiIdTipoContratoAlta")
                Dim contra As DataRow() = nConsulta(SQL)
                cboTipoContrato.SelectedValue = contra(0).Item("iIdTipoContratoAlta")

                cbEmpresasC.SelectedValue = Fila.Item("fkiIdEmpresaC")

                txtlugarpago.Text = Fila.Item("cLugarPago")
                txtFormaPago.Text = Fila.Item("cFormaPago")
                txtFechapago.Text = Fila.Item("cFechaPago")
                txtlugarfirma.Text = Fila.Item("cLugarFirmaContrato")
                dtpFechaterminocontrato.Value = Fila.Item("dFechaTerminoContrato")

                cbometodopago.SelectedValue = Fila.Item("fkiIdMetodoPagoAlta")


                Dim fechafin As Date
                fechafin = Fila.Item("dFechaTerminoContrato")
                dtpFechaterminocontrato.Value = Fila.Item("dFechaTerminoContrato")

                txtRegistroPatronal.Text = Fila.Item("cRegistroPatronal")
              
                iOrigen = Fila.Item("iOrigen")
                cbEmpresasC.SelectedValue = Fila.Item("fkiIdEmpresaC")
                '' iEmpresaC = Fila.Item("fkiIdEmpresaC")


                Dim tmp = Fila.Item("iReconoceAntiguedad")
                If tmp = 1 Then
                    chkAntiguedad.Checked = True

                Else
                    chkAntiguedad.Checked = False

                End If

                cboautorizacion.SelectedIndex = Fila.Item("iPermanente")


                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MostrarDepartamentos()
        SQL = "select  * from DepartamentosAlta  where fkiIdEmpresa = " & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)

        If rwFilas Is Nothing = False Then

            nCargaCBO(cbodepartamento, SQL, "cnombre", "iIdDepartamentoAlta")
            cbodepartamento.SelectedIndex = 0

        End If


       



        
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
      
        SQL = "select  * from puestosAlta  where fkiIdEmpresa = " & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        If rwFilas Is Nothing = False Then
            
            nCargaCBO(cbopuesto, SQL, "cnombre", "iIdPuestoAlta")
            cbopuesto.SelectedIndex = 0
        End If

        

    End Sub

    Private Sub MostrarTipoContrato()
        SQL = "Select * from Cat_TipoContratoAlta where iEstatus=1"
        nCargaCBO(cboTipoContrato, SQL, "Descripcion", "iIdTipoContratoAlta")
        cboTipoContrato.SelectedIndex = 0
    End Sub

    Private Sub MostrarJornada()
        SQL = "Select * from Cat_TipoJornadaAlta where iEstatus=1"
        nCargaCBO(cbojornada, SQL, "Descripcion", "iIdTipoJornadaAlta")
        cbojornada.SelectedIndex = 0
    End Sub

    Private Sub MostrarIntegrar()
        SQL = "Select * from Cat_IntegrarAlta where iEstatus=1"
        nCargaCBO(cboIntegrar, SQL, "Descripcion", "iIdIntegrarAlta")
        cboIntegrar.SelectedIndex = 0
    End Sub
    Private Sub MostrarMetodoPago()
        SQL = "Select * from Cat_MetodoPagoAlta where iEstatus=1"
        nCargaCBO(cbometodopago, SQL, "Descripcion", "iIdMetodoPagoAlta")
        cbometodopago.SelectedIndex = 0
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

    Private Sub MostrarEstadoNac()
        SQL = "Select * from Cat_Estados order by iIdEstado"
        nCargaCBO(cboEdoNac, SQL, "cEstado", "iIdEstado")
        cboEdoNac.SelectedIndex = 0
    End Sub
    Private Sub MostrarEstados()
        SQL = "Select * from Cat_Estados order by iIdEstado"
        nCargaCBO(cboestadotrab, SQL, "cEstado", "iIdEstado")
        cboestadotrab.SelectedIndex = 0
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


    Private Sub MostrarEmpresasC()
        SQL = "select (nombre + ' ' + ruta) AS nombre, iIdEmpresaC from empresaC ORDER BY nombre"
        nCargaCBO(cbEmpresasC, SQL, "nombre", "iIdEmpresaC")
        cbEmpresasC.SelectedIndex = 0

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
        cboTipoContrato.SelectedIndex = 0
        cbojornada.SelectedIndex = 0
        cboIntegrar.SelectedIndex = 0
        cbometodopago.SelectedIndex = 0
        cboEdoNac.SelectedIndex = 0

        cboautorizacion.SelectedIndex = 0
        cbobanco.SelectedIndex = 0
        cbobanco2.SelectedIndex = 0
        cbocategoria.SelectedIndex = 0

        cboedocivil.SelectedIndex = 0
        cboestadotrab.SelectedIndex = 0
        cboestadoP.SelectedIndex = 0
        cbojornada.SelectedIndex = 0
        cbosexo.SelectedIndex = 0
        cbostatus.SelectedIndex = 0
        cbotipofactor.SelectedIndex = 0

        cbodepartamento.SelectedIndex = 0
        cbopuesto.SelectedIndex = 0




    End Sub

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
            If txtmaterno.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique Apellido materno"
            End If
            If txtimss.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el numero del IMSS"
            End If
            If txtrfc.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el RFC"
            End If
            If txtcurp.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique la CURP"
            End If
            If cboTipoContrato.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el tipo de contrato"
            End If
            If cboIntegrar.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el tipo de integraciôn"
            End If
            If cbopuesto.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el tipo de puesto"
            End If
            If cbodepartamento.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el departamento"
            End If
            If cbEmpresasC.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique la Empresa  CONTPAQ"
            End If
            If cboestadotrab.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique estado del trabajador"
            End If
            If cboEdoNac.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique estado de nacimiento"
            End If
            If cboEdoNac.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique estado de presentaciôn de servicios"
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
                SQL = "select * from empleadosAlta where cCodigoEmpleado=" & txtcodigo.Text
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

            End If

            If SQL <> "" Then
                If nExecute(SQL) = False Then
                    Exit Sub
                End If
            End If


            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setempleadosAltaInsertar 0 ,'" & txtcodigo.Text & "','" & txtnombre.Text
                SQL &= "','" & txtpaterno.Text
                SQL &= "','" & txtmaterno.Text & "','" & txtpaterno.Text & " " & txtmaterno.Text & " " & txtnombre.Text
                SQL &= "','" & txtrfc.Text & "','" & txtcurp.Text & "','" & txtimss.Text
                SQL &= "','" & txtcallenum.Text
                SQL &= "','" & txtcolonia.Text & "','" & txtmunicipio.Text & "'," & cboestadotrab.SelectedValue & ",'" & txtcp.Text
                SQL &= "'," & cbosexo.SelectedIndex & ",'" & Format(dtpfechanac.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpCaptura.Value.Date, "yyyy/dd/MM")
                SQL &= "','" & cbopuesto.SelectedValue & "','" & txtfunciones.Text
                SQL &= "','" & IIf(txtsd.Text = "", 0, txtsd.Text) & "','" & IIf(txtsdi.Text = "", 0, txtsdi.Text) & "','" & IIf(txtsalario.Text = "", 0, txtsalario.Text) & "','" & 0
                SQL &= "','" & txtcallenum.Text & "','" & txtnacionalidad.Text & "','','','" & (Format(dtpFechaterminocontrato.Value.Date, "yyyy/dd/MM")) & "','" & txtcomentarios.Text
                SQL &= "'," & gIdEmpresa & "," & gIdCliente & "," & cbobanco.SelectedValue ''BNCO
                SQL &= ",'" & txtcuenta.Text & "','" & txtclabe.Text & "','" & txttarjeta.Text & "','" & " 1 " 'Asignar codigo por tipo de cuenta
                SQL &= "'," & cbobanco2.SelectedValue & ",'" & txtcuenta2.Text & "','" & txtclabe2.Text & "','" & "1" ' IIf(cbobanco2.SelectedValue <> "", 1, cbobanco2.SelectedIndex) 'Asignar codigo por tipo de cuenta2
                SQL &= "','" & txtdireccionP.Text & "','" & txtciudadP.Text & "'," & cboestadoP.SelectedValue & ",'" & txtcp2.Text
                SQL &= "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpFechaterminocontrato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpsindicato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpantiguedad.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & IIf(chkAntiguedad.Checked, 1, 0) & "," & cboautorizacion.SelectedIndex & "," & cboIntegrar.SelectedIndex
                SQL &= "," & cbocategoria.SelectedIndex & ",'" & txtcredito.Text & "','" & IIf(cbotipofactor.SelectedIndex = -1, 0, cbotipofactor.SelectedIndex) ''
                SQL &= "'," & IIf(txtfactor.Text = "", 0, txtfactor.Text) & ",'" & cbojornada.SelectedValue & "','" & txtcorreo.Text ''JORNADA
                SQL &= "','" & txthorario.Text & "','" & txthoras.Text & "','" & " " & "','" & txtdescanso.Text & "','" & txtFechapago.Text
                SQL &= "','" & txtFormaPago.Text & "','" & txtlugarpago.Text & "'," & 0 & "," & cbopuesto.SelectedValue & "," & cbodepartamento.SelectedValue ''depto
                SQL &= ",'" & cboedocivil.SelectedIndex & "'," & cboTipoContrato.SelectedValue & ",0" & "," & cbometodopago.SelectedValue & ",'" & txtlugarpago.Text & "', 1, " & cboEdoNac.SelectedValue & ", 1, 1,'" & IIf(cbostatus.SelectedIndex = 0, 1, 0) & "','" & cbEmpresasC.SelectedValue & "','" & txtlugarfirma.Text & "','" & txtRegistroPatronal.Text & "'"


            Else
                'Actualizar

                SQL = "EXEC setempleadosAltaActualizar " & gIdEmpleado & ",'" & txtcodigo.Text & "','" & txtnombre.Text
                SQL &= "','" & txtpaterno.Text
                SQL &= "','" & txtmaterno.Text & "','" & txtpaterno.Text & " " & txtmaterno.Text & " " & txtnombre.Text
                SQL &= "','" & txtrfc.Text & "','" & txtcurp.Text & "','" & txtimss.Text
                SQL &= "','" & txtcallenum.Text
                SQL &= "','" & txtcolonia.Text & "','" & txtmunicipio.Text & "'," & cboestadotrab.SelectedValue & ",'" & txtcp.Text
                SQL &= "'," & cbosexo.SelectedIndex & ",'" & Format(dtpfechanac.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpCaptura.Value.Date, "yyyy/dd/MM")
                SQL &= "','" & cbopuesto.SelectedValue & "','" & txtfunciones.Text
                SQL &= "','" & IIf(txtsd.Text = "", 0, txtsd.Text) & "','" & IIf(txtsdi.Text = "", 0, txtsdi.Text) & "','" & IIf(txtsalario.Text = "", 0, txtsalario.Text) & "','" & 0
                SQL &= "','" & txtcallenum.Text & "','" & txtnacionalidad.Text & "','','','" & (Format(dtpFechaterminocontrato.Value.Date, "yyyy/dd/MM")) & "','" & txtcomentarios.Text
                SQL &= "'," & gIdEmpresa & "," & gIdCliente & "," & cbobanco.SelectedValue
                SQL &= ",'" & txtcuenta.Text & "','" & txtclabe.Text & "','" & txttarjeta.Text & "','" & " 1 " 'Asignar codigo por tipo de cuenta
                SQL &= "'," & cbobanco2.SelectedValue & ",'" & txtcuenta2.Text & "','" & txtclabe2.Text & "','" & "1" ' IIf(cbobanco2.SelectedValue <> "", 1, cbobanco2.SelectedIndex) 'Asignar codigo por tipo de cuenta2
                SQL &= "','" & txtdireccionP.Text & "','" & txtciudadP.Text & "'," & cboestadoP.SelectedValue & ",'" & txtcp2.Text
                SQL &= "','" & Format(dtppatrona.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpFechaterminocontrato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpsindicato.Value.Date, "yyyy/dd/MM") & "','" & Format(dtpantiguedad.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & IIf(chkAntiguedad.Checked, 1, 0) & "," & cboautorizacion.SelectedIndex & "," & cboIntegrar.SelectedIndex
                SQL &= "," & cbocategoria.SelectedIndex & ",'" & txtcredito.Text & "','" & IIf(cbotipofactor.SelectedIndex = -1, 0, cbotipofactor.SelectedIndex) ''
                SQL &= "'," & IIf(txtfactor.Text = "", 0, txtfactor.Text) & ",'" & cbojornada.SelectedValue & "','" & txtcorreo.Text ''JORNADA
                SQL &= "','" & txthorario.Text & "','" & txthoras.Text & "','" & " " & "','" & txtdescanso.Text & "','" & txtFechapago.Text
                SQL &= "','" & txtFormaPago.Text & "','" & txtlugarpago.Text & "'," & 0 & "," & cbopuesto.SelectedValue & "," & cbodepartamento.SelectedValue ''depto
                SQL &= ",'" & cboedocivil.SelectedIndex & "'," & cboTipoContrato.SelectedValue & ",0" & "," & cbometodopago.SelectedValue & ",'" & txtlugarpago.Text & "', 1, " & cboEdoNac.SelectedValue & ", 1, 1,'" & IIf(cbostatus.SelectedIndex = 0, 1, 0) & "','" & cbEmpresasC.SelectedValue & "','" & txtlugarfirma.Text & "','" & txtRegistroPatronal.Text & "'"

            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If


            gIdEmpleado = "" '" & txtmunicip
            gIdEmpresa = ""
            gIdCliente = ""


            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Limpiar(Me)

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
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

    Private Sub cmdimss_Click(sender As Object, e As EventArgs) Handles cmdimss.Click

    End Sub

    Private Sub cmdjuridico_Click(sender As Object, e As EventArgs) Handles cmdjuridico.Click

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
  
    Private Sub cboestadotrab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboestadotrab.SelectedIndexChanged

    End Sub

    Private Sub cboTipoContrato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoContrato.SelectedIndexChanged

    End Sub

    Private Sub cbotipofactor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotipofactor.SelectedIndexChanged

    End Sub
End Class