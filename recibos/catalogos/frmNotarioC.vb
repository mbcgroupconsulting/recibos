Imports System.Text.RegularExpressions

Public Class frmNotarioC
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gIdEmpresa As String
    'Public nombre As String
    'Dim gIdSucursal As String

    'Private Sub cmdnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnuevo.Click
    '    pnlEmpresa.Enabled = True
    '    blnNuevo = True
    '    ''cbostatus.Focus()
    'End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            'Validar
            If txtnombre.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el nombre"
            End If
            If txtnumero.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el número de notario"
            End If

            If txtresidencia.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique lugar de residencia del notario"
            End If
            If txtFolio.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el Folio del acta"
            End If
            If txtLugarRPP.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el Lugar de RPP"
            End If

            If dtRegistroActa.Value.ToString = " " And Mensaje = "" Then
                Mensaje = "Indique el estatus del proveedor"
            End If


            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If blnNuevo Then
            'Insertar nuevo
            SQL = "EXEC setNotarioCliente " & gIdEmpresa
            SQL &= ",'" & txtnombre.Text & "','" & txtnumero.Text
            SQL &= "','" & txtresidencia.Text & "','" & txtFolio.Text & "','" & Format(dtRegistroActa.Value, "yyyy/dd/MM")
            SQL &= "','" & txtLugarRPP.Text & "'"

            'Else
            ' ''Actualizar

            'SQL = "EXEC setsucursalActualizar " & gIdSucursal & "," & gIdEmpresa
            'SQL &= ",'" & txtcalle.Text & "','" & txtnumero.Text
            'SQL &= "','" & txtint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text
            'SQL &= "','" & txtlocalidad.Text
            'SQL &= "','" & txtmunicipio.Text & "','" & txttelefono.Text
            'SQL &= "','" & txttelefono2.Text & "','" & txtcontacto.Text & "','" & txtemail.Text
            'SQL &= "','" & txtpatronal.Text & "','" & cboestados.SelectedValue & "'"
            'SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0)


            'End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If
            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlEmpresa.Enabled = True

            ''Limpiar(pnlEmpresa)
            '' txtnombre.Text = nombre

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
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        pnlEmpresa.Enabled = False
        Limpiar(pnlEmpresa)
        ''txtnombre.Text = nombre
    End Sub

    'Private Sub cmdbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbuscar.Click
    '    Dim Forma As New frmBuscarSucursal
    '    Forma.gIdEmpresa = gIdEmpresa
    '    If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        gIdSucursal = Forma.gIdSucursal
    '        Mostrar_DatosSucursal(Forma.gIdSucursal)

    '    End If
    'End Sub



    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()

    End Sub

    Private Sub frmNotarioC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlEmpresa.Enabled = True

        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True

        MostrarNotario()


    End Sub

    Private Sub MostrarNotario()
        SQL = "select * from clientes where iIdCliente = " & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlEmpresa.Enabled = True
                Dim Fila As DataRow = rwFilas(0)

                txtnombre.Text = Fila.Item("cNotario")
                txtnumero.Text = Fila.Item("cNotarioNumero")
                txtresidencia.Text = Fila.Item("cNotarioResidencia")
                txtFolio.Text = Fila.Item("cFolioMercantil")
                txtLugarRPP.Text = Fila.Item("cLugarRPP")
                dtRegistroActa.Value = Fila.Item("dFechaActa")


            End If

        Catch
        End Try

    End Sub

    Private Sub pnlEmpresa_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlEmpresa.EnabledChanged

        cmdguardar.Enabled = pnlEmpresa.Enabled
        cmdcancelar.Enabled = pnlEmpresa.Enabled

        txtnombre.Enabled = pnlEmpresa.Enabled
        txtnumero.Enabled = pnlEmpresa.Enabled
        txtLugarRPP.Enabled = pnlEmpresa.Enabled
        txtresidencia.Enabled = pnlEmpresa.Enabled
        dtRegistroActa.Enabled = pnlEmpresa.Enabled

    End Sub



End Class