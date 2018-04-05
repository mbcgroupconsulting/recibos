Imports ClosedXML.Excel
Imports System.IO
Imports System.Text

Public Class frmEmpleadosXCliente
    Dim SQL As String
    Private Sub frmEmpleadosXCliente_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        MostrarClientes()
        MostrarEmpresas()
        MostrarDireccion()
    End Sub

    Private Sub MostrarDireccion()
        SQL = "select * from empresa where iIdEmpresa = " & cboempresas.SelectedValue
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                'lblEmpresa.Text = "Empresa: " & Fila.Item("nombre")
                lbldireccion.Text = "Direccion: " & Fila.Item("calle") & " " & Fila.Item("numero") & " " & Fila.Item("numeroint") & " " & Fila.Item("colonia") & " "

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarClientes()

        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6") Then

                    SQL = "Select nombre,iIdCliente from clientes order by nombre"
                Else
                    SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
                    SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
                    SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    SQL &= "  order by nombre "


                End If
                nCargaCBO(cboclientes, SQL, "nombre", "iIdCliente")
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub MostrarEmpresas()
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6") Then

                    SQL = "Select nombre,iIdEmpresa from empresa order by nombre"
                Else
                    SQL = "Select distinct(iIdEmpresa),empresa.nombre from ((clientes inner join UsuarioClientes  "
                    SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente) inner join"
                    SQL &= " IntClienteEmpresa on clientes.iIdCliente=IntClienteEmpresa.fkIdCliente)"
                    SQL &= " inner join empresa on IntClienteEmpresa.fkIdEmpresa= empresa.iIdEmpresa"
                    SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    SQL &= " order by nombre "


                End If
                nCargaCBO(cboempresas, SQL, "nombre", "iIdEmpresa")
            End If

        Catch ex As Exception

        End Try




    End Sub

    Private Sub cboempresas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MostrarSucursales()
    End Sub

    Private Sub MostrarSucursales()
        SQL = "Select * from empresa order by nombre"
        nCargaCBO(cbosucursales, SQL, "nombre", "iIdEmpresa")

    End Sub

    Private Sub cmdnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnuevo.Click
        SQL = "select * from PuestosAlta where fkiIdEmpresa=" & cboempresas.SelectedValue

        Dim rwFilas As DataRow() = nConsulta(SQL)
        If (rwFilas Is Nothing) Then
            MessageBox.Show("Necesita agregar puesto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            SQL = "select * from DepartamentosAlta where fkiIdEmpresa=" & cboempresas.SelectedValue

            Dim dpto As DataRow() = nConsulta(SQL)
            If (dpto Is Nothing) Then
                MessageBox.Show("Necesita agregar Departamento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else

                Dim forma As New frmAltaEmpleadoNew
                forma.gIdCliente = cboclientes.SelectedValue
                forma.gIdEmpresa = cboempresas.SelectedValue
                forma.ShowDialog()
            End If
        End If



    End Sub

    Private Sub pnlVentana_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlVentana.Paint

    End Sub

    Private Sub cboempresas_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboempresas.SelectedIndexChanged
        MostrarDireccion()
        lsvLista.Clear()
    End Sub

    Private Sub cmdmostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmostrar.Click
        Dim SQL As String, Alter As Boolean = False
        Dim contador As Integer
        Try
            If rbActivos.Checked Then
                SQL = "select * from empleadosAlta "
                ''SQL = "select * from empleados "
                SQL &= " where (fkiIdCliente=" & cboclientes.SelectedValue & " and fkiIdEmpresa=" & cboempresas.SelectedValue & " AND iEstatus = 1)"

                SQL &= " order by cCodigoEmpleado,cNombre,cApellidoP,cApellidoM "
            Else
                SQL = "select * from empleadosAlta "
                ''SQL = "select * from empleados "
                SQL &= " where (fkiIdCliente=" & cboclientes.SelectedValue & " and fkiIdEmpresa=" & cboempresas.SelectedValue & " )"

                SQL &= " order by cCodigoEmpleado,cNombre,cApellidoP,cApellidoM "
            End If

            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvLista.Clear()


            lsvLista.Columns.Add("Codigo")
            lsvLista.Columns(0).Width = 100
            lsvLista.Columns.Add("Nombre")
            lsvLista.Columns(1).Width = 200
            lsvLista.Columns.Add("Apellido P")
            lsvLista.Columns(2).Width = 200
            lsvLista.Columns.Add("Apellido M")
            lsvLista.Columns(3).Width = 200
            lsvLista.Columns.Add("Edad")
            lsvLista.Columns(4).Width = 100
            lsvLista.Columns.Add("Sexo")
            lsvLista.Columns(5).Width = 100
            lsvLista.Columns.Add("Estado Civil")
            lsvLista.Columns(6).Width = 100
            lsvLista.Columns.Add("Puesto")
            lsvLista.Columns(7).Width = 100
            lsvLista.Columns.Add("Funciones")
            lsvLista.Columns(8).Width = 100
            lsvLista.Columns.Add("Categoria")
            lsvLista.Columns(9).Width = 100
            lsvLista.Columns.Add("Fecha Patrona")
            lsvLista.Columns(10).Width = 100
            lsvLista.Columns.Add("Fecha Sindicato")
            lsvLista.Columns(11).Width = 100
            lsvLista.Columns.Add("Integrar a")
            lsvLista.Columns(12).Width = 100
            lsvLista.Columns.Add("Salario Diario")
            lsvLista.Columns(13).Width = 100
            lsvLista.Columns.Add("SDI")
            lsvLista.Columns(14).Width = 100
            lsvLista.Columns.Add("Fecha Nac.")
            lsvLista.Columns(15).Width = 100
            lsvLista.Columns.Add("CURP")
            lsvLista.Columns(16).Width = 100
            lsvLista.Columns.Add("RFC")
            lsvLista.Columns(17).Width = 100
            lsvLista.Columns.Add("No IMSS")
            lsvLista.Columns(18).Width = 100
            lsvLista.Columns.Add("Autorización P")
            lsvLista.Columns(19).Width = 100
            lsvLista.Columns.Add("Credito Infonavit")
            lsvLista.Columns(20).Width = 100
            lsvLista.Columns.Add("Tipo Factor")
            lsvLista.Columns(21).Width = 100
            lsvLista.Columns.Add("Factor Desc.")
            lsvLista.Columns(22).Width = 100
            lsvLista.Columns.Add("Numero cuenta")
            lsvLista.Columns(23).Width = 100
            lsvLista.Columns.Add("Clabe")
            lsvLista.Columns(24).Width = 100
            lsvLista.Columns.Add("Banco")
            lsvLista.Columns(25).Width = 100
            lsvLista.Columns.Add("Nacionalidad")
            lsvLista.Columns(26).Width = 100
            lsvLista.Columns.Add("Direccion")
            lsvLista.Columns(27).Width = 100
            lsvLista.Columns.Add("Ciudad")
            lsvLista.Columns(28).Width = 100
            lsvLista.Columns.Add("Estado")
            lsvLista.Columns(29).Width = 100
            lsvLista.Columns.Add("CP")
            lsvLista.Columns(30).Width = 100
            lsvLista.Columns.Add("Fecha antiguedad")
            lsvLista.Columns(31).Width = 100
            lsvLista.Columns.Add("Lugar Prestacion")
            lsvLista.Columns(32).Width = 300
            lsvLista.Columns.Add("Duracion Contrato")
            lsvLista.Columns(33).Width = 100
            lsvLista.Columns.Add("Tipo Jornada")
            lsvLista.Columns(34).Width = 100
            lsvLista.Columns.Add("Salario Real")
            lsvLista.Columns(35).Width = 100
            lsvLista.Columns.Add("Comentarios")
            lsvLista.Columns(36).Width = 100
            lsvLista.Columns.Add("Correo")
            lsvLista.Columns(37).Width = 100
            lsvLista.Columns.Add("Horario Labores")
            lsvLista.Columns(38).Width = 100
            lsvLista.Columns.Add("Num horas jornada")
            lsvLista.Columns(39).Width = 100
            lsvLista.Columns.Add("Dia descanso")
            lsvLista.Columns(40).Width = 100


            contador = 0
            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    contador = contador + 1
                    item = lsvLista.Items.Add(Fila.Item("cCodigoEmpleado"))
                    item.SubItems.Add("" & Fila.Item("cNombre"))
                    item.SubItems.Add("" & Fila.Item("cApellidoP"))
                    item.SubItems.Add("" & Fila.Item("cApellidoM"))
                    Dim fechanac As Date
                    fechanac = Fila.Item("dFechaNac")
                    Dim edad As Integer = DateDiff(DateInterval.Year, fechanac, Date.Today)
                    item.SubItems.Add("" & edad.ToString())

                    Dim sexo As String = IIf(Fila.Item("iSexo") = "0", "Femenino", "Masculino")

                    item.SubItems.Add("" & sexo)
                    Dim civil As String = IIf(Fila.Item("iEstadoCivil") = "0", "Soltero", "Casado")
                    item.SubItems.Add("" & civil)
                    item.SubItems.Add("" & Fila.Item("cPuesto"))
                    item.SubItems.Add("" & Fila.Item("cFuncionesPuesto"))
                    Dim Categoria As String = IIf(Fila.Item("iCategoria") = "0", "A", "B")
                    item.SubItems.Add("" & Categoria)
                    item.SubItems.Add("" & Fila.Item("dFechaPatrona"))
                    item.SubItems.Add("" & Fila.Item("dFechaSindicato"))
                    item.SubItems.Add("" & Fila.Item("cIntegrar"))
                    item.SubItems.Add("" & Fila.Item("fSueldoBase"))
                    item.SubItems.Add("" & Fila.Item("fSueldoIntegrado"))
                    item.SubItems.Add("" & Fila.Item("dFechaNac"))
                    item.SubItems.Add("" & Fila.Item("cCURP"))
                    item.SubItems.Add("" & Fila.Item("cRFC"))
                    item.SubItems.Add("" & Fila.Item("cIMSS"))

                    item.SubItems.Add("" & IIf(Fila.Item("iPermanente") = "0", "No", "Si"))

                    item.SubItems.Add("" & Fila.Item("cInfonavit"))
                    item.SubItems.Add("" & Fila.Item("cTipoFactor"))
                    item.SubItems.Add("" & Fila.Item("fFactor"))

                    item.SubItems.Add("" & Fila.Item("NumCuenta"))
                    item.SubItems.Add("" & Fila.Item("Clabe"))

                    SQL = "select * from bancos where iIdBanco=" & Fila.Item("fkiIdBanco")
                    Dim Banco As DataRow() = nConsulta(SQL)
                    If Banco Is Nothing Then
                        item.SubItems.Add("" & " -")
                    Else
                        item.SubItems.Add("" & Banco(0).Item("cBanco"))
                    End If


                    item.SubItems.Add("" & Fila.Item("cNacionalidad"))
                    item.SubItems.Add("" & Fila.Item("cCalleNumero"))
                    item.SubItems.Add("" & Fila.Item("cCiudadP"))

                    SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstadoP")
                    Dim Estado As DataRow() = nConsulta(SQL)

                    item.SubItems.Add("" & Estado(0).Item("cEstado"))
                    ''item.SubItems.Add("" & Estado(0).Item("fkiIdEstadoP"))

                    item.SubItems.Add("" & Fila.Item("cCP"))
                    item.SubItems.Add("" & Fila.Item("dFechaAntiguedad"))
                    item.SubItems.Add("" & Fila.Item("cCalleNumero") & "" & Fila.Item("cCiudadP"))
                    item.SubItems.Add("" & Fila.Item("cDuracionContrato").ToString)
                    SQL = "select * from Cat_TipoJornadaAlta where iIdTipoJornadaAlta=" & Fila.Item("cJornada")
                    Dim jornada As DataRow() = nConsulta(SQL)

                    item.SubItems.Add("" & jornada(0).Item("Descripcion"))


                    item.SubItems.Add("" & Fila.Item("fSueldoOrd"))
                    item.SubItems.Add("" & Fila.Item("cObservaciones"))
                    item.SubItems.Add("" & Fila.Item("cCorreo"))
                    item.SubItems.Add("" & Fila.Item("cHorario"))
                    item.SubItems.Add("" & Fila.Item("cHoras"))
                    item.SubItems.Add("" & Fila.Item("cDescanso"))

                    item.Tag = Fila.Item("iIdEmpleadoAlta")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If lsvLista.Items.Count > 0 Then
                lsvLista.Focus()
                lsvLista.Items(0).Selected = True
                MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'txtbuscar.Focus()
                'txtbuscar.SelectAll()
            End If


        Catch ex As Exception

        End Try
    End Sub




    Private Sub lsvLista_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvLista.ItemActivate
        Dim forma As New frmAltaEmpleadoNew
        forma.gIdCliente = cboclientes.SelectedValue
        forma.gIdEmpresa = cboempresas.SelectedValue
        forma.gIdEmpleado = lsvLista.SelectedItems(0).Tag
        forma.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SQL As String, Alter As Boolean = False
        Dim contador As Integer
        Try
            If txtCodigo.Text = "" Then
                MessageBox.Show("Escriba el codigo del empleado en la caja de texto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                SQL = "select * from empleados "
                SQL &= " where (fkiIdCliente=" & cboclientes.SelectedValue & " and fkiIdEmpresa=" & cboempresas.SelectedValue & " AND cCodigoEmpleado =" & txtCodigo.Text & ")"

                SQL &= " order by cCodigoEmpleado,cNombre,cApellidoP,cApellidoM "


                Dim rwFilas As DataRow() = nConsulta(SQL)
                Dim item As ListViewItem
                lsvLista.Items.Clear()

                lsvLista.Columns.Add("Codigo")
                lsvLista.Columns(0).Width = 100
                lsvLista.Columns.Add("Nombre")
                lsvLista.Columns(1).Width = 200
                lsvLista.Columns.Add("Apellido P")
                lsvLista.Columns(2).Width = 200
                lsvLista.Columns.Add("Apellido M")
                lsvLista.Columns(3).Width = 200
                lsvLista.Columns.Add("Edad")
                lsvLista.Columns(4).Width = 100
                lsvLista.Columns.Add("Sexo")
                lsvLista.Columns(5).Width = 100
                lsvLista.Columns.Add("Estado Civil")
                lsvLista.Columns(6).Width = 100
                lsvLista.Columns.Add("Puesto")
                lsvLista.Columns(7).Width = 100
                lsvLista.Columns.Add("Funciones")
                lsvLista.Columns(8).Width = 100
                lsvLista.Columns.Add("Categoria")
                lsvLista.Columns(9).Width = 100
                lsvLista.Columns.Add("Fecha Patrona")
                lsvLista.Columns(10).Width = 100
                lsvLista.Columns.Add("Fecha Sindicato")
                lsvLista.Columns(11).Width = 100
                lsvLista.Columns.Add("Integrar a")
                lsvLista.Columns(12).Width = 100
                lsvLista.Columns.Add("Salario Diario")
                lsvLista.Columns(13).Width = 100
                lsvLista.Columns.Add("SDI")
                lsvLista.Columns(14).Width = 100
                lsvLista.Columns.Add("Fecha Nac.")
                lsvLista.Columns(15).Width = 100
                lsvLista.Columns.Add("CURP")
                lsvLista.Columns(16).Width = 100
                lsvLista.Columns.Add("RFC")
                lsvLista.Columns(17).Width = 100
                lsvLista.Columns.Add("No IMSS")
                lsvLista.Columns(18).Width = 100
                lsvLista.Columns.Add("Autorización P")
                lsvLista.Columns(19).Width = 100
                lsvLista.Columns.Add("Credito Infonavit")
                lsvLista.Columns(20).Width = 100
                lsvLista.Columns.Add("Tipo Factor")
                lsvLista.Columns(21).Width = 100
                lsvLista.Columns.Add("Factor Desc.")
                lsvLista.Columns(22).Width = 100
                lsvLista.Columns.Add("Numero cuenta")
                lsvLista.Columns(23).Width = 100
                lsvLista.Columns.Add("Clabe")
                lsvLista.Columns(24).Width = 100
                lsvLista.Columns.Add("Banco")
                lsvLista.Columns(25).Width = 100
                lsvLista.Columns.Add("Nacionalidad")
                lsvLista.Columns(26).Width = 100
                lsvLista.Columns.Add("Direccion")
                lsvLista.Columns(27).Width = 100
                lsvLista.Columns.Add("Ciudad")
                lsvLista.Columns(28).Width = 100
                lsvLista.Columns.Add("Estado")
                lsvLista.Columns(29).Width = 100
                lsvLista.Columns.Add("CP")
                lsvLista.Columns(30).Width = 100
                lsvLista.Columns.Add("Fecha antiguedad")
                lsvLista.Columns(31).Width = 100
                lsvLista.Columns.Add("Lugar Prestacion")
                lsvLista.Columns(32).Width = 300
                lsvLista.Columns.Add("Duracion Contrato")
                lsvLista.Columns(33).Width = 100
                lsvLista.Columns.Add("Tipo Jornada")
                lsvLista.Columns(34).Width = 100
                lsvLista.Columns.Add("Salario Real")
                lsvLista.Columns(35).Width = 100
                lsvLista.Columns.Add("Comentarios")
                lsvLista.Columns(36).Width = 100
                lsvLista.Columns.Add("Correo")
                lsvLista.Columns(37).Width = 100
                lsvLista.Columns.Add("Horario Labores")
                lsvLista.Columns(38).Width = 100
                lsvLista.Columns.Add("Num horas jornada")
                lsvLista.Columns(39).Width = 100
                lsvLista.Columns.Add("Dia descanso")
                lsvLista.Columns(40).Width = 100

                contador = 0

                If rwFilas Is Nothing = False Then
                    For Each Fila In rwFilas
                        contador = contador + 1
                        item = lsvLista.Items.Add(Fila.Item("cCodigoEmpleado"))
                        item.SubItems.Add("" & Fila.Item("cNombre"))
                        item.SubItems.Add("" & Fila.Item("cApellidoP"))
                        item.SubItems.Add("" & Fila.Item("cApellidoM"))
                        Dim fechanac As Date
                        fechanac = Fila.Item("dFechaNac")
                        Dim edad As Integer = DateDiff(DateInterval.Year, fechanac, Date.Today)
                        item.SubItems.Add("" & edad.ToString())

                        Dim sexo As String = IIf(Fila.Item("iSexo") = "0", "Femenino", "Masculino")

                        item.SubItems.Add("" & sexo)
                        Dim civil As String = IIf(Fila.Item("iOrigen") = "0", "Soltero", "Casado")
                        item.SubItems.Add("" & civil)
                        item.SubItems.Add("" & Fila.Item("cPuesto"))
                        item.SubItems.Add("" & Fila.Item("cFuncionesPuesto"))
                        Dim Categoria As String = IIf(Fila.Item("iCategoria") = "0", "A", "B")
                        item.SubItems.Add("" & Categoria)
                        item.SubItems.Add("" & Fila.Item("dFechaPatrona"))
                        item.SubItems.Add("" & Fila.Item("dFechaSindicato"))
                        item.SubItems.Add("" & Fila.Item("cIntegrar"))
                        item.SubItems.Add("" & Fila.Item("fSueldoBase"))
                        item.SubItems.Add("" & Fila.Item("fSueldoIntegrado"))
                        item.SubItems.Add("" & Fila.Item("dFechaNac"))
                        item.SubItems.Add("" & Fila.Item("cCURP"))
                        item.SubItems.Add("" & Fila.Item("cRFC"))
                        item.SubItems.Add("" & Fila.Item("cIMSS"))

                        item.SubItems.Add("" & IIf(Fila.Item("iPermanente") = "0", "No", "Si"))

                        item.SubItems.Add("" & Fila.Item("cInfonavit"))
                        item.SubItems.Add("" & Fila.Item("cTipoFactor"))
                        item.SubItems.Add("" & Fila.Item("fFactor"))

                        item.SubItems.Add("" & Fila.Item("NumCuenta"))
                        item.SubItems.Add("" & Fila.Item("Clabe"))

                        SQL = "select * from bancos where iIdBanco=" & Fila.Item("fkiIdBanco")
                        Dim Banco As DataRow() = nConsulta(SQL)

                        item.SubItems.Add("" & Banco(0).Item("cBanco"))

                        item.SubItems.Add("" & Fila.Item("cNacionalidad"))
                        item.SubItems.Add("" & Fila.Item("cCalleNumero"))
                        item.SubItems.Add("" & Fila.Item("cCiudadL"))

                        SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstado")
                        Dim Estado As DataRow() = nConsulta(SQL)

                        item.SubItems.Add("" & Estado(0).Item("cEstado"))

                        item.SubItems.Add("" & Fila.Item("cCP"))
                        item.SubItems.Add("" & Fila.Item("dFechaAntiguedad"))
                        item.SubItems.Add("" & Fila.Item("cDireccionP") & "" & Fila.Item("cCiudadP"))
                        item.SubItems.Add("" & Fila.Item("cDuracionContrato"))
                        item.SubItems.Add("" & Fila.Item("cJornada"))
                        item.SubItems.Add("" & Fila.Item("cObservaciones"))
                        item.SubItems.Add("" & Fila.Item("cCorreo"))
                        item.SubItems.Add("" & Fila.Item("cHorario"))
                        item.SubItems.Add("" & Fila.Item("cHoras"))
                        item.SubItems.Add("" & Fila.Item("cDescanso"))

                        item.Tag = Fila.Item("iIdEmpleado")
                        item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                        Alter = Not Alter

                    Next
                Else
                    MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                If lsvLista.Items.Count > 0 Then
                    lsvLista.Focus()
                    lsvLista.Items(0).Selected = True
                    MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    'txtbuscar.Focus()
                    'txtbuscar.SelectAll()
                End If
            End If



        Catch ex As Exception

        End Try
    End Sub




    Private Sub lsvLista_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub btnPuestoN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPuestoN.Click
        Dim formI As New frmPuestoAlta
        ''  forma.gIdCliente = cboclientes.SelectedValue
        formI.gIdEmpresa = cboempresas.SelectedValue
        formI.ShowDialog()
    End Sub

    Private Sub btnDepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepto.Click
        Dim formI As New frmDepartamentoAlta
        ''  forma.gIdCliente = cboclientes.SelectedValue
        formI.gIdEmpresa = cboempresas.SelectedValue
        formI.ShowDialog()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If lsvLista.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and print results.
            Dim x As Integer
            Dim s As String = ""

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

            dialogo.DefaultExt = "*.txt"
            dialogo.FileName = "Empleados"
            dialogo.Filter = "Archivos de texto (*.txt)|*.txt"
            Dim ret As DialogResult = dialogo.ShowDialog()
            PathArchivo = ""
            PathArchivo = dialogo.FileName

            If ret = Windows.Forms.DialogResult.OK Then
                If PathArchivo <> "" Then

                    'If dialogo.ShowDialog() = DialogResult.OK Then

                    strStreamW = File.Create(PathArchivo) ' lo creamos
                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                    contador = 1
                    sRenglon = ""
                    For x = 0 To lsvLista.CheckedItems.Count - 1
                        ''s = s & "Checked Item " & (x + 1).ToString & " = " & lsvLista.CheckedItems(x).ToString & "Tag" & lsvLista.Items(x).Tag & ControlChars.CrLf
                        sql = "select * from empleadosAlta where iIdEmpleadoAlta= " & lsvLista.CheckedItems(x).Tag
                        '' sql = "select * from empleadosAlta where cCodigoEmpleado= " & lsvLista.CheckedItems(x).Tag
                        Dim rwDatos As DataRow() = nConsulta(sql)

                        If rwDatos Is Nothing = False Then

                            For Each Fila In rwDatos
                                sql = "SELECT * FROM Cat_TipoJornadaAlta where iIdTipoJornadaAlta=" & Fila.Item("cJornada")
                                Dim cJornada As DataRow() = nConsulta(sql)
                                Dim Jor As String
                                If cJornada Is Nothing Then
                                    Jor = "(No asignada)"
                                Else
                                    Jor = cJornada(0).Item("Descripcion")
                                End If
                                sRenglon = Fila.Item("cCodigoEmpleado") & "|" & Fila.Item("dFechaCap") & "|" & "30/12/1899" & "|" & "30/12/1899" & "|" & Fila.Item("fkiIdTipoContratoAlta")
                                sRenglon = sRenglon & "|" & Fila.Item("cApellidoP") & "|" & Fila.Item("cApellidoM") & "|" & Fila.Item("cNombre")
                                sRenglon = sRenglon & "|" & Jor & "|" & Fila.Item("fSueldoBase") & "|" & Fila.Item("fSueldoIntegrado") & "|" & "F"

                                sql = "SELECT * FROM DepartamentosALTA WHERE iIdDepartamentoAlta=" & Fila.Item("fkiIdDepartamento")
                                Dim cDepto As DataRow() = nConsulta(sql)
                                Dim dpto As String
                                If cDepto Is Nothing Then
                                    dpto = "(No asignado)"
                                Else
                                    dpto = cDepto(0).Item("cNombre")

                                End If

                                sRenglon = sRenglon & "|" & "A" & "|" & "(Ninguno)" & "|" & "C" & "|" & "S" & "|" & Trim(Fila.Item("fkiIdMetodoPagoAlta"))
                                sRenglon = sRenglon & "|" & "Matutino" & "|" & IIf(Fila.Item("iCategoria") = "0", "A", "B") & "|" & "" & "|" & "" & "|" & "" & "|" & "" & "|" & ""
                                Dim var, var2 As String
                                Dim var_leg As Integer
                                var = Fila.Item("cRFC")
                                var_leg = var.Length

                                Dim curp_leg As Integer
                                var2 = Fila.Item("cCURP")
                                curp_leg = var2.Length
                                sRenglon = sRenglon & "|" & Fila.Item("cIMSS") & "|" & Fila.Item("cRFC").Substring(0, 4) & "|" & Fila.Item("cRFC").Substring(var_leg - 3, 3) & "|" & Fila.Item("cRFC").Substring(0, 4) & "|" & Fila.Item("cCURP").Substring(curp_leg - 8, 8)
                                Dim t As String
                                If Fila.Item("iSexo") = "1" Then
                                    t = "M"
                                Else
                                    t = "F"
                                End If
                                sql = "SELECT * FROM PuestosAlta WHERE iIdPuestoAlta=" & Fila.Item("fkiIdPuesto")

                                sRenglon = sRenglon & "|" & t & "|" & "" & "|" & Fila.Item("dFechaNac") & "|" & "0" & "|" & "" & "|" & "" & "|" & "" & "|" & "(Ninguno)" & "|" & "" & "|" & "" & "|" & "0"
                                sRenglon = sRenglon & "|" & "" & "|" & "" & "|" & "0" & "|" & "1" & "|" & "0" & "|" & "0" & "|" & Fila.Item("dFechaCap")
                                sRenglon = sRenglon & "|" & Fila.Item("dFechaCap") & "|" & "0" & "|" & Fila.Item("dFechaCap") & "|" & "0" & "|" & "30/12/1899" & "|" & "0" & "|" & "0" & "|" & "1" & "|" & "1"

                                sql = "SELECT * FROM bancos WHERE iIdBanco=" & Fila.Item("fkiIdBanco")
                                Dim bancoClave As DataRow() = nConsulta(sql)
                                Dim banco As String
                                banco = bancoClave(0).Item("clave")
                                sRenglon = sRenglon & "|" & "" & "|" & banco & "|" & Fila.Item("NumCuenta") & "|" & "" & "|" & "" & "|" & "0" & "|" & "0" & "|" & "0" & "|" & "0" & "|" & "0"
                                sRenglon = sRenglon & "|" & "_A" & "|" & "30/12/1899" & "|" & "0" & "|" & Fila.Item("cRegistroPatronal") & "|" & Fila.Item("cRFC").Substring(0, 4) & "|" & ""
                                sql = "SELECT * FROM Cat_Estados WHERE iIdEstado=" & Fila.Item("fkiIdEstadoNac")
                                Dim c As String
                                c = Fila.Item("cCURP").Substring(curp_leg - 7, 7)
                                Dim codeE As String
                                codeE = c.Substring(0, 2)

                                sRenglon = sRenglon & "|" & Fila.Item("cCorreo") & "|" & "2" & "|" & Fila.Item("Clabe") & "|" & codeE & "|" & "0"

                            Next

                        End If
                        strStreamWriter.WriteLine(sRenglon)
                        contador = contador + 1
                    Next x
                    strStreamWriter.Close() ' cerramos
                    MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)




                End If
                ''end path
            Else
                MessageBox.Show("No gaurdo nada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If



        End If



    End Sub

   



    Private Sub cmdexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexcel.Click


        ImportarExcel()
        'Try

        '    Dim filaExcel As Integer = 5
        '    Dim dialogo As New SaveFileDialog()
        '    Dim idtipo As Integer
        '    Dim Alter As Boolean = False
        '    '' Dim tiempo As TimeSpan = fin - inicio 
        '    Dim sumatoria As Double

        '    If lsvLista.CheckedItems.Count <> 0 Then
        '        For x = 0 To lsvLista.CheckedItems.Count - 1

        '            SQL = "select * from empleadosAlta where iIdEmpleadoAlta= " & lsvLista.CheckedItems(x).Tag
        '            sumatoria = 0

        '            Dim rwDatos As DataRow() = nConsulta(SQL)
        '            If rwDatos Is Nothing = False Then

        '                Dim libro As New ClosedXML.Excel.XLWorkbook
        '                Dim hoja As IXLWorksheet = libro.Worksheets.Add("Flujo")
        '                hoja.Column("A").Width = 20
        '                hoja.Column("B").Width = 15
        '                hoja.Column("C").Width = 15
        '                hoja.Column("D").Width = 12
        '                hoja.Column("E").Width = 12
        '                hoja.Column("F").Width = 25
        '                hoja.Column("G").Width = 15
        '                hoja.Column("H").Width = 15
        '                hoja.Column("I").Width = 25
        '                hoja.Column("J").Width = 15
        '                hoja.Column("K").Width = 15
        '                hoja.Column("L").Width = 15
        '                hoja.Column("M").Width = 15
        '                hoja.Column("N").Width = 50
        '                hoja.Column("O").Width = 12

        '                hoja.Range(1, 1, 1, 15).Style.Font.FontSize = 10
        '                hoja.Range(1, 1, 1, 15).Style.Font.SetBold(True)
        '                hoja.Range(1, 1, 1, 15).Style.Alignment.WrapText = True
        '                hoja.Range(1, 1, 1, 15).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        '                hoja.Range(1, 1, 1, 15).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
        '                'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
        '                hoja.Range(1, 1, 1, 15).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
        '                hoja.Range(1, 1, 1, 15).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

        '                'hoja.Cell(4, 1).Value = "Num"

        '                'hoja.Cell(1, 1).Value = "IdFacturaConcepto"
        '                'hoja.Cell(1, 2).Value = "Mov. Flujo"
        '                'hoja.Cell(1, 3).Value = "Mes"
        '                'hoja.Cell(1, 4).Value = "Fecha"
        '                'hoja.Cell(1, 5).Value = "Id Cliente"
        '                'hoja.Cell(1, 6).Value = "Cliente"
        '                'hoja.Cell(1, 7).Value = "Mov"
        '                'hoja.Cell(1, 8).Value = "Id Pagadora"
        '                'hoja.Cell(1, 9).Value = "Pagadora"
        '                'hoja.Cell(1, 10).Value = "Importe"
        '                'hoja.Cell(1, 11).Value = "IVA"
        '                'hoja.Cell(1, 12).Value = "Total"
        '                'hoja.Cell(1, 13).Value = "Clave Sat"
        '                'hoja.Cell(1, 14).Value = "Concepto"
        '                'hoja.Cell(1, 15).Value = "Num Factura"


        '                filaExcel = 1
        '                For Each Fila In rwDatos
        '                    filaExcel = filaExcel + 1

        '                    hoja.Cell(filaExcel, 1).Value = Fila.Item("iIdFacturaConcepto")
        '                    hoja.Cell(filaExcel, 2).Value = Fila.Item("NumeroFlujo")
        '                    hoja.Cell(filaExcel, 3).Value = MonthName(Date.Parse(Fila.Item("FechaFlujo")).Month)
        '                    hoja.Cell(filaExcel, 4).Value = Fila.Item("FechaFlujo")
        '                    hoja.Cell(filaExcel, 5).Value = ""
        '                    hoja.Cell(filaExcel, 6).Value = Fila.Item("Cliente")
        '                    hoja.Cell(filaExcel, 7).Value = Fila.Item("Tipo")
        '                    hoja.Cell(filaExcel, 8).Value = ""
        '                    hoja.Cell(filaExcel, 9).Value = Fila.Item("Prestadora")
        '                    hoja.Cell(filaExcel, 10).Value = Format(CType(Fila.Item("subtotal"), Decimal), "###,###,##0.#0")
        '                    hoja.Cell(filaExcel, 11).Value = Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0")
        '                    hoja.Cell(filaExcel, 12).Value = Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0")
        '                    hoja.Cell(filaExcel, 13).Value = Fila.Item("ClaveSat")
        '                    hoja.Cell(filaExcel, 14).Value = Fila.Item("Concepto")





        '                    'If Fila.Item("fkiIdFactura").ToString = "0" Then
        '                    '    hoja.Cell(filaExcel, 15).Value = ""
        '                    'Else
        '                    '    'Buscamos el numero de factura
        '                    '    SQL = "select * from facturas where "
        '                    '    SQL &= "iIdFactura=" & Fila.Item("fkiIdFactura").ToString


        '                    '    Dim rwNumFactura As DataRow() = nConsulta(SQL)
        '                    '    If rwNumFactura Is Nothing = False Then
        '                    '        hoja.Cell(filaExcel, 15).Value = rwNumFactura(0)("numfactura").ToString

        '                    '    End If

        '                    'End If


        '                    hoja.Range(2, 9, 1500, 11).Style.NumberFormat.SetFormat("###,###,##0.#0")



        '                Next

        '                dialogo.DefaultExt = "*.xlsx"
        '                dialogo.FileName = "Empleados"
        '                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
        '                dialogo.ShowDialog()
        '                libro.SaveAs(dialogo.FileName)
        '                'libro.SaveAs("c:\temp\control.xlsx")
        '                'libro.SaveAs(dialogo.FileName)
        '                'apExcel.Quit()
        '                libro = Nothing
        '                MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        '            Else
        '                MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            End If
        '        Next


        '    End If






        'Catch ex As Exception

        'End Try

    End Sub

    Public Sub ImportarExcel()
        Try

        
        Dim filaExcel As Integer = 2
        Dim dialogo As New SaveFileDialog()
        If lsvLista.CheckedItems.Count > 0 Then

            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Flujo")
            hoja.Column("A").Width = 20
            hoja.Column("B").Width = 15
            hoja.Column("C").Width = 15
            hoja.Column("D").Width = 12
            hoja.Column("E").Width = 12
            hoja.Column("F").Width = 25
            hoja.Column("G").Width = 15
            hoja.Column("H").Width = 15
            hoja.Column("I").Width = 25
            hoja.Column("J").Width = 15
            hoja.Column("K").Width = 15
            hoja.Column("L").Width = 15
            hoja.Column("M").Width = 15
            hoja.Column("N").Width = 50
                hoja.Column("O").Width = 12

                hoja.Cell(1, 1).Value = ("Codigo")
                hoja.Cell(1, 2).Value = ("Nombre")
                hoja.Cell(1, 3).Value = ("Apellido P")
                hoja.Cell(1, 4).Value = ("Apellido M")
                hoja.Cell(1, 5).Value = ("Edad")
                hoja.Cell(1, 6).Value = ("Sexo")
                hoja.Cell(1, 7).Value = ("Estado Civil")
                hoja.Cell(1, 8).Value = ("Puesto")
                hoja.Cell(1, 9).Value = ("Funciones")
                hoja.Cell(1, 10).Value = ("Categoria")
                hoja.Cell(1, 11).Value = ("Fecha Patrona")
                hoja.Cell(1, 12).Value = ("Fecha Sindicato")
                hoja.Cell(1, 13).Value = ("Integrar a")
                hoja.Cell(1, 14).Value = ("Salario Diario")
                hoja.Cell(1, 15).Value = ("SDI")
                hoja.Cell(1, 16).Value = ("Fecha Nac.")
                hoja.Cell(1, 17).Value = ("CURP")
                hoja.Cell(1, 18).Value = ("RFC")
                hoja.Cell(1, 19).Value = ("No IMSS")
                hoja.Cell(1, 20).Value = ("Autorización P")
                hoja.Cell(1, 21).Value = ("Credito Infonavit")
                hoja.Cell(1, 22).Value = ("Tipo Factor")
                hoja.Cell(1, 23).Value = ("Factor Desc.")
                hoja.Cell(1, 24).Value = ("Numero cuenta")
                hoja.Cell(1, 25).Value = ("Clabe")
                hoja.Cell(1, 26).Value = ("Banco")
                hoja.Cell(1, 27).Value = ("Nacionalidad")
                hoja.Cell(1, 28).Value = ("Direccion")
                hoja.Cell(1, 29).Value = ("Ciudad")
                hoja.Cell(1, 30).Value = ("Estado")
                hoja.Cell(1, 31).Value = ("CP")
                hoja.Cell(1, 32).Value = ("Fecha antiguedad")
                hoja.Cell(1, 33).Value = ("Lugar Prestacion")
                hoja.Cell(1, 34).Value = ("Duracion Contrato")
                hoja.Cell(1, 35).Value = ("Tipo Jornada")
                hoja.Cell(1, 36).Value = ("Salario Real")
                hoja.Cell(1, 37).Value = ("Comentarios")
                hoja.Cell(1, 38).Value = ("Correo")
                hoja.Cell(1, 39).Value = ("Horario Labores")
                hoja.Cell(1, 40).Value = ("Num horas jornada")
                hoja.Cell(1, 41).Value = ("Dia descanso")


                hoja.Range(1, 1, 1, 41).Style.Font.FontSize = 10
                hoja.Range(1, 1, 1, 41).Style.Font.SetBold(True)
                hoja.Range(1, 1, 1, 41).Style.Alignment.WrapText = True
                hoja.Range(1, 1, 1, 41).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hoja.Range(1, 1, 1, 41).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                hoja.Range(1, 1, 1, 41).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                hoja.Range(1, 1, 1, 41).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                For Each dato As ListViewItem In lsvLista.CheckedItems


                    hoja.Cell(filaExcel, 1).Value = dato.SubItems(0).Text
                    hoja.Cell(filaExcel, 2).Value = dato.SubItems(1).Text
                    hoja.Cell(filaExcel, 3).Value = dato.SubItems(2).Text
                    hoja.Cell(filaExcel, 4).Value = dato.SubItems(3).Text
                    hoja.Cell(filaExcel, 5).Value = dato.SubItems(4).Text
                    hoja.Cell(filaExcel, 6).Value = dato.SubItems(5).Text
                    hoja.Cell(filaExcel, 7).Value = dato.SubItems(6).Text
                    hoja.Cell(filaExcel, 8).Value = dato.SubItems(7).Text
                    hoja.Cell(filaExcel, 9).Value = dato.SubItems(8).Text
                    hoja.Cell(filaExcel, 10).Value = dato.SubItems(9).Text
                    hoja.Cell(filaExcel, 11).Value = dato.SubItems(10).Text
                    hoja.Cell(filaExcel, 12).Value = dato.SubItems(11).Text
                    hoja.Cell(filaExcel, 13).Value = dato.SubItems(12).Text
                    hoja.Cell(filaExcel, 14).Value = dato.SubItems(13).Text
                    hoja.Cell(filaExcel, 15).Value = dato.SubItems(14).Text
                    hoja.Cell(filaExcel, 16).Value = dato.SubItems(15).Text
                    hoja.Cell(filaExcel, 17).Value = dato.SubItems(16).Text
                    hoja.Cell(filaExcel, 18).Value = dato.SubItems(17).Text
                    hoja.Cell(filaExcel, 19).Value = dato.SubItems(18).Text
                    hoja.Cell(filaExcel, 20).Value = dato.SubItems(19).Text
                    hoja.Cell(filaExcel, 21).Value = dato.SubItems(20).Text
                    hoja.Cell(filaExcel, 22).Value = dato.SubItems(21).Text
                    hoja.Cell(filaExcel, 23).Value = dato.SubItems(22).Text
                    hoja.Cell(filaExcel, 24).Value = dato.SubItems(23).Text
                    hoja.Cell(filaExcel, 25).Value = dato.SubItems(24).Text
                    hoja.Cell(filaExcel, 26).Value = dato.SubItems(25).Text
                    hoja.Cell(filaExcel, 27).Value = dato.SubItems(26).Text
                    hoja.Cell(filaExcel, 28).Value = dato.SubItems(27).Text
                    hoja.Cell(filaExcel, 29).Value = dato.SubItems(28).Text
                    hoja.Cell(filaExcel, 30).Value = dato.SubItems(29).Text
                    hoja.Cell(filaExcel, 31).Value = dato.SubItems(30).Text
                    hoja.Cell(filaExcel, 32).Value = dato.SubItems(31).Text
                    hoja.Cell(filaExcel, 33).Value = dato.SubItems(32).Text
                    hoja.Cell(filaExcel, 34).Value = dato.SubItems(33).Text
                    hoja.Cell(filaExcel, 35).Value = dato.SubItems(34).Text
                    hoja.Cell(filaExcel, 36).Value = dato.SubItems(35).Text
                    hoja.Cell(filaExcel, 37).Value = dato.SubItems(36).Text
                    hoja.Cell(filaExcel, 38).Value = dato.SubItems(37).Text
                    hoja.Cell(filaExcel, 39).Value = dato.SubItems(38).Text
                    hoja.Cell(filaExcel, 40).Value = dato.SubItems(39).Text
                    hoja.Cell(filaExcel, 41).Value = dato.SubItems(40).Text


                    filaExcel = filaExcel + 1

                Next

                SQL = "select * from empresa where iIdEmpresa = " & cboempresas.SelectedValue
                Dim e As DataRow() = nConsulta(SQL)
                Dim c As DataRow() = nConsulta("select * from clientes where iIdCliente =" & cboclientes.SelectedValue)

            Dim moment As Date = Date.Now()
            Dim month As Integer = moment.Month
            Dim year As Integer = moment.Year
            dialogo.DefaultExt = "*.xlsx"
                dialogo.FileName = "Empleados Excel de " & e(0).Item("nombre").ToString & " " & "--" & " " & c(0).Item("nombre").ToString
                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            libro.SaveAs(dialogo.FileName)
         
            MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)



            End If

        Catch ex As Exception

        End Try

    End Sub


End Class