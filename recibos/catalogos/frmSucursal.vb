Imports System.Text.RegularExpressions

Public Class frmSucursal
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gIdEmpresa As String
    Public nombre As String
    Dim gIdSucursal As String

    Private Sub cmdnuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdnuevo.Click
        pnlEmpresa.Enabled = True
        blnNuevo = True
        cbostatus.Focus()
    End Sub

    Private Sub cmdguardar_Click(sender As System.Object, e As System.EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            'Validar
            If txtcalle.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique la calle"
            End If
            If txtnumero.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el número de la dirección del cliente"
            End If
            If txtcolonia.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique la colonia"
            End If
            If txtmunicipio.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el municipio"
            End If
            If txtcp.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el codigo postal"
            End If
            If cboestados.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Seleccione el estado al que pertenece"
            End If
            If txttelefono.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el telefono"
            End If
            If txtcontacto.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el contacto de la empresa"
            End If

            If txtpatronal.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el registro patronal"
            End If

            If txtemail.Text.Trim.Length > 0 And Mensaje = "" Then
                If Not Regex.IsMatch(txtemail.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") Then
                    Mensaje = "El email no tiene una forma correcta de correo electrónico (usuario@dominio.com)."
                    Me.txtemail.Focus()
                End If
            End If

            If cbostatus.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el estatus del proveedor"
            End If

            
            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setsucursalInsertar  0," & gIdEmpresa
                SQL &= ",'" & txtcalle.Text & "','" & txtnumero.Text
                SQL &= "','" & txtint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text
                SQL &= "','" & txtlocalidad.Text
                SQL &= "','" & txtmunicipio.Text & "','" & txttelefono.Text
                SQL &= "','" & txttelefono2.Text & "','" & txtcontacto.Text & "','" & txtemail.Text
                SQL &= "','" & txtpatronal.Text & "','" & cboestados.SelectedValue & "'"
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0)
            Else
                'Actualizar

                SQL = "EXEC setsucursalActualizar " & gIdSucursal & "," & gIdEmpresa
                SQL &= ",'" & txtcalle.Text & "','" & txtnumero.Text
                SQL &= "','" & txtint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text
                SQL &= "','" & txtlocalidad.Text
                SQL &= "','" & txtmunicipio.Text & "','" & txttelefono.Text
                SQL &= "','" & txttelefono2.Text & "','" & txtcontacto.Text & "','" & txtemail.Text
                SQL &= "','" & txtpatronal.Text & "','" & cboestados.SelectedValue & "'"
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0)


            End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If
            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlEmpresa.Enabled = False
            Limpiar(pnlEmpresa)
            txtnombre.Text = nombre
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

    Private Sub cmdcancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancelar.Click
        pnlEmpresa.Enabled = False
        Limpiar(pnlEmpresa)
        txtnombre.Text = nombre
    End Sub

    Private Sub cmdbuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarSucursal
        Forma.gIdEmpresa = gIdEmpresa
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            gIdSucursal = Forma.gIdSucursal
            Mostrar_DatosSucursal(Forma.gIdSucursal)

        End If
    End Sub
    Private Sub Mostrar_DatosSucursal(ByVal IdSucursal As String)
        SQL = "select * from sucursal where iIdSucursal = " & IdSucursal
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlEmpresa.Enabled = True
                Dim Fila As DataRow = rwFilas(0)

                txtcalle.Text = Fila.Item("calle")
                txtnumero.Text = Fila.Item("numero")
                txtint.Text = Fila.Item("interior")
                txtcolonia.Text = Fila.Item("colonia")
                txtlocalidad.Text = Fila.Item("localidad")
                txtmunicipio.Text = Fila.Item("municipio")
                txtcp.Text = Fila.Item("cp")
                cboestados.SelectedValue = Fila.Item("fkiIdEstado")
                txttelefono.Text = Fila.Item("Telefono")
                txttelefono2.Text = Fila.Item("Telefono2")
                txtcontacto.Text = Fila.Item("Contacto")
                txtemail.Text = Fila.Item("email")

                txtpatronal.Text = Fila.Item("registropatronal")
                cbostatus.SelectedIndex = IIf(Fila.Item("iEstatus") = 1, 0, 1)
                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmdsalir_Click(sender As System.Object, e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub frmSucursal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        MostrarEstados()
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        txtnombre.Text = nombre
    End Sub

    Private Sub MostrarEstados()
        SQL = "Select * from Cat_Estados order by iIdEstado"
        nCargaCBO(cboestados, SQL, "cEstado", "iIdEstado")
    End Sub

    Private Sub pnlEmpresa_EnabledChanged(sender As Object, e As System.EventArgs) Handles pnlEmpresa.EnabledChanged
        cmdnuevo.Enabled = Not pnlEmpresa.Enabled
        cmdguardar.Enabled = pnlEmpresa.Enabled
        cmdcancelar.Enabled = pnlEmpresa.Enabled

        cmdbuscar.Enabled = Not pnlEmpresa.Enabled
    End Sub

    Private Sub txtnumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtnumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnumero.TextChanged

    End Sub

    Private Sub txtcp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcp.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcp_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcp.TextChanged

    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txttelefono_TextChanged(sender As System.Object, e As System.EventArgs) Handles txttelefono.TextChanged

    End Sub

    Private Sub txttelefono2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txttelefono2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txttelefono2.TextChanged

    End Sub
End Class