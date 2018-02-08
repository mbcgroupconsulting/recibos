Imports ClosedXML.Excel
Public Class AltaNominaEmpleado
    Dim SQL As String
    Private Sub AltaNominaEmpleado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'dtgDatos.ColumnCount = 5
        'dtgDatos.Columns(0).Name = "ID"
        'dtgDatos.Columns(1).Width = 150
        'dtgDatos.Columns(1).Name = "NOMBRE"
        'dtgDatos.Columns(2).Width = 250
        'dtgDatos.Columns(2).Name = "APELLIDO P"
        'dtgDatos.Columns(3).Width = 250
        'dtgDatos.Columns(3).Name = "APELLIDO M"
        'dtgDatos.Columns(4).Width = 100
        'dtgDatos.Columns(4).Name = "EDAD"
        'dtgDatos.Columns(5).Width = 100
        'dtgDatos.Columns(5).Name = "SEXO"
        'dtgDatos.Columns(6).Width = 100
        'dtgDatos.Columns(6).Name = "ESTADO CIVIL"
        'dtgDatos.Columns(7).Width = 100
        'dtgDatos.Columns(7).Name = "PUESTO"
        'dtgDatos.Columns(8).Width = 100
        'dtgDatos.Columns(8).Name = "FUNCIONES DEL PUESTO"
        'dtgDatos.Columns(9).Width = 100
        'dtgDatos.Columns(9).Name = "CATEGORIA"

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

    Private Sub cboempresas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        MostrarSucursales()
    End Sub

    Private Sub MostrarSucursales()
        SQL = "Select * from empresa order by nombre"
        nCargaCBO(cbosucursales, SQL, "nombre", "iIdEmpresa")

    End Sub

    Private Sub cmdnuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdnuevo.Click
        Dim forma As New frmAltaEmpleado
        forma.gIdCliente = cboclientes.SelectedValue
        forma.gIdEmpresa = cboempresas.SelectedValue
        forma.ShowDialog()

    End Sub

    Private Sub pnlVentana_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlVentana.Paint

    End Sub

    Private Sub cboempresas_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cboempresas.SelectedIndexChanged
        MostrarDireccion()
        lsvLista.Clear()
    End Sub

    Private Sub cmdmostrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdmostrar.Click
        Dim SQL As String, Alter As Boolean = False
        Dim contador As Integer
        Try
            If rbActivos.Checked Then
                SQL = "select * from empleados "
                SQL &= " where (fkiIdCliente=" & cboclientes.SelectedValue & " and fkiIdEmpresa=" & cboempresas.SelectedValue & " AND iEstatus = 1)"

                SQL &= " order by cCodigoEmpleado,cNombre,cApellidoP,cApellidoM "
            Else
                SQL = "select * from empleados "
                SQL &= " where (fkiIdCliente=" & cboclientes.SelectedValue & " and fkiIdEmpresa=" & cboempresas.SelectedValue & " )"

                SQL &= " order by cCodigoEmpleado,cNombre,cApellidoP,cApellidoM "
            End If

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
                    item.SubItems.Add("" & Fila.Item("cDireccion"))
                    item.SubItems.Add("" & Fila.Item("cCiudadL"))

                    SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstado")
                    Dim Estado As DataRow() = nConsulta(SQL)

                    item.SubItems.Add("" & Estado(0).Item("cEstado"))

                    item.SubItems.Add("" & Fila.Item("cCP"))
                    item.SubItems.Add("" & Fila.Item("dFechaAntiguedad"))
                    item.SubItems.Add("" & Fila.Item("cDireccionP") & "" & Fila.Item("cCiudadP"))
                    item.SubItems.Add("" & Fila.Item("cDuracion"))
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


        Catch ex As Exception

        End Try
    End Sub

 


    Private Sub lsvLista_ItemActivate(sender As Object, e As System.EventArgs) Handles lsvLista.ItemActivate
        Dim forma As New frmAltaEmpleado
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
                        item.SubItems.Add("" & Fila.Item("cDireccion"))
                        item.SubItems.Add("" & Fila.Item("cCiudadL"))

                        SQL = "select * from Cat_Estados where iIdEstado=" & Fila.Item("fkiIdEstado")
                        Dim Estado As DataRow() = nConsulta(SQL)

                        item.SubItems.Add("" & Estado(0).Item("cEstado"))

                        item.SubItems.Add("" & Fila.Item("cCP"))
                        item.SubItems.Add("" & Fila.Item("dFechaAntiguedad"))
                        item.SubItems.Add("" & Fila.Item("cDireccionP") & "" & Fila.Item("cCiudadP"))
                        item.SubItems.Add("" & Fila.Item("cDuracion"))
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



    Private Sub cmdexcel_Click(sender As Object, e As EventArgs) Handles cmdexcel.Click
        Dim SQL As String, Alter As Boolean = False
        Dim aID As String()
        Dim promotor As String = ""
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()

        SQL = "select * from empleados "
        SQL &= " where (fkiIdCliente=" & cboclientes.SelectedValue & " and fkiIdEmpresa=" & cboempresas.SelectedValue & " )"

        SQL &= " order by cCodigoEmpleado,cNombre,cApellidoP,cApellidoM "

        'If rdbintermediaria.Checked Then
        '    SQL &= " where empresa.fkiIdTipoEmpresa= 2"
        'ElseIf rdbiva.Checked Then
        '    SQL &= " where empresa.fkiIdTipoEmpresa= 3"
        'ElseIf rdbpatrona.Checked Then
        '    SQL &= " where empresa.fkiIdTipoEmpresa= 1"
        'End If


        'If rdbpagadas.Checked Then
        '    SQL &= " And facturas.pagada=1"
        'ElseIf rdbnopagadas.Checked Then
        '    SQL &= " And facturas.pagada=0"
        'End If




        Dim rwFilas As DataRow() = nConsulta(SQL)
        If rwFilas Is Nothing = False Then
            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Empleados")

            hoja.Column("B").Width = 30
            hoja.Column("C").Width = 13
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
            hoja.Column("Q").Width = 13
            hoja.Column("R").Width = 13
            hoja.Column("S").Width = 13
            hoja.Column("T").Width = 13
            hoja.Column("U").Width = 13
            hoja.Column("V").Width = 13
            hoja.Column("W").Width = 13
            hoja.Column("X").Width = 13
            hoja.Column("Y").Width = 13
            hoja.Column("Z").Width = 13
            hoja.Column("AA").Width = 13
            hoja.Column("AB").Width = 13
            hoja.Column("AC").Width = 13

            hoja.Cell(2, 2).Value = "Fecha:"
            hoja.Cell(2, 3).Value = Date.Now.ToShortDateString()

            'hoja.Cell(3, 2).Value = ":"
            'hoja.Cell(3, 3).Value = ""

            hoja.Range(4, 2, 4, 29).Style.Font.FontSize = 10
            hoja.Range(4, 2, 4, 29).Style.Font.SetBold(True)
            hoja.Range(4, 2, 4, 29).Style.Alignment.WrapText = True
            hoja.Range(4, 2, 4, 29).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja.Range(4, 1, 4, 29).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja.Range(4, 2, 4, 29).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja.Range(4, 2, 4, 29).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            'hoja.Cell(4, 1).Value = "Num"
            hoja.Cell(4, 2).Value = "Codigo"
            hoja.Cell(4, 3).Value = "Nombre"
            hoja.Cell(4, 4).Value = "Apellido P"
            hoja.Cell(4, 5).Value = "Apellido M"
            hoja.Cell(4, 6).Value = "Edad"
            hoja.Cell(4, 7).Value = "Sexo"
            hoja.Cell(4, 8).Value = "Estado Civil"
            hoja.Cell(4, 9).Value = "Puesto"
            hoja.Cell(4, 10).Value = "Funciones"
            hoja.Cell(4, 11).Value = "Categoria"
            hoja.Cell(4, 12).Value = "Fecha Patrona"
            hoja.Cell(4, 13).Value = "Fecha Sindicato"
            hoja.Cell(4, 14).Value = "Integrar a"
            hoja.Cell(4, 15).Value = "Salario Diario"
            hoja.Cell(4, 16).Value = "Fecha Nac."
            hoja.Cell(4, 17).Value = "CURP"
            hoja.Cell(4, 18).Value = "RFC"
            hoja.Cell(4, 19).Value = "No IMSS"
            hoja.Cell(4, 20).Value = "Autorización P"
            hoja.Cell(4, 21).Value = "Credito Infonavit"
            hoja.Cell(4, 22).Value = "Tipo Factor"
            hoja.Cell(4, 23).Value = "Factor Desc."
            hoja.Cell(4, 24).Value = "Numero cuenta"
            hoja.Cell(4, 25).Value = "Clabe"
            hoja.Cell(4, 26).Value = "Banco"
            hoja.Cell(4, 27).Value = "Nacionalidad"
            hoja.Cell(4, 28).Value = "Direccion"
            hoja.Cell(4, 29).Value = "Ciudad"




            filaExcel = 4
            For Each Fila In rwFilas
                filaExcel = filaExcel + 1

                'aID = Fila.Item("fkiIdPromotor").Split(",")
                'If aID.Length = 1 Then
                '    promotor = obtenerpromotor(aID(0))

                'ElseIf aID.Length = 2 Then
                '    promotor = obtenerpromotor(aID(0))
                '    promotor &= "," & obtenerpromotor(aID(1))

                'ElseIf aID.Length = 3 Then
                '    promotor = obtenerpromotor(aID(0))
                '    promotor &= "," & obtenerpromotor(aID(1))
                '    promotor &= "," & obtenerpromotor(aID(2))
                'End If

                hoja.Cell(filaExcel, 2).Value = Fila.Item("cCodigoEmpleado")
                hoja.Cell(filaExcel, 3).Value = Fila.Item("cNombre")
                hoja.Cell(filaExcel, 4).Value = Fila.Item("cApellidoP")
                hoja.Cell(filaExcel, 5).Value = Fila.Item("cApellidoM")
                hoja.Cell(filaExcel, 6).Value = ""
                hoja.Cell(filaExcel, 7).Value = Fila.Item("iSexo")
                hoja.Cell(filaExcel, 8).Value = ""
                hoja.Cell(filaExcel, 9).Value = Fila.Item("cPuesto")
                hoja.Cell(filaExcel, 10).Value = Fila.Item("cFuncionesPuesto")
                hoja.Cell(filaExcel, 11).Value = ""
                hoja.Cell(filaExcel, 12).Value = Fila.Item("dFechaPatrona")
                hoja.Cell(filaExcel, 13).Value = Fila.Item("dFechaSindicato")
                hoja.Cell(filaExcel, 14).Value = Fila.Item("cIntegrar")
                hoja.Cell(filaExcel, 15).Value = Fila.Item("fSueldoBase")
                hoja.Cell(filaExcel, 16).Value = Fila.Item("dFechaNac")
                hoja.Cell(filaExcel, 17).Value = Fila.Item("cCURP")
                hoja.Cell(filaExcel, 18).Value = Fila.Item("cRFC")
                hoja.Cell(filaExcel, 19).Value = Fila.Item("cIMSS")
                hoja.Cell(filaExcel, 20).Value = Fila.Item("iPermanente")
                hoja.Cell(filaExcel, 21).Value = Fila.Item("cInfonavit")
                hoja.Cell(filaExcel, 22).Value = Fila.Item("cTipoFactor")
                hoja.Cell(filaExcel, 23).Value = Fila.Item("fFactor")
                hoja.Cell(filaExcel, 24).Value = Fila.Item("Numcuenta")
                hoja.Cell(filaExcel, 25).Value = Fila.Item("Clabe")
                hoja.Cell(filaExcel, 26).Value = Fila.Item("fkiIdBanco")
                hoja.Cell(filaExcel, 27).Value = Fila.Item("cNacionalidad")
                hoja.Cell(filaExcel, 28).Value = Fila.Item("cDireccion")
                hoja.Cell(filaExcel, 29).Value = Fila.Item("cCiudadL")




            Next

            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Lista empleado"
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

    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub
End Class