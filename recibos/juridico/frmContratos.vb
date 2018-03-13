Imports ClosedXML.Excel
Imports System.IO
Imports System.Text

Public Class frmContratos
    Dim SQL As String
    Private Sub frmContratos_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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

    Private Sub cmdnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        '' lsvLista.Clear()
    End Sub

End Class