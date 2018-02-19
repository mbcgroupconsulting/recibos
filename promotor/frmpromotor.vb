Imports ClosedXML.Excel
Public Class frmpromotor
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdProveedor As String
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub cmdnuevo_Click(sender As Object, e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        blnNuevo = True

        cbostatus.Focus()

    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            'Validar
            If txtnombre.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el nombre del cliente"
            End If
            If txtpaterno.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el apellido paterno"
            End If


            If cbostatus.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el estatus del promotor"
            End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setpromotorInsertar  0,'" & txtpaterno.Text
                SQL &= "','" & txtMaterno.Text
                SQL &= "','" & txtnombre.Text & "','" & txtnombre.Text & " " & txtpaterno.Text & " " & txtMaterno.Text
                SQL &= "',0"
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0)
            Else
                'Actualizar


                SQL = "EXEC setpromotorActualizar  " & gIdProveedor & ",'" & txtpaterno.Text
                SQL &= "','" & txtMaterno.Text
                SQL &= "','" & txtnombre.Text & "','" & txtnombre.Text & " " & txtpaterno.Text & " " & txtMaterno.Text
                SQL &= "',0"
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0)


            End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If
            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlProveedores.Enabled = False
            Limpiar(pnlProveedores)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        pnlProveedores.Enabled = False
        Limpiar(pnlProveedores)
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarPromotor
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            gIdProveedor = Forma.gIdPromotor
            MostrarDatos(Forma.gIdPromotor)

        End If
    End Sub

    Private Sub MostrarDatos(ByVal IdProveedor As String)
        SQL = "select * from promotor where iIdPromotor= " & IdProveedor
        Dim aID As String()
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlProveedores.Enabled = True
                Dim Fila As DataRow = rwFilas(0)
                txtnombre.Text = Fila.Item("nombre")
                txtpaterno.Text = Fila.Item("apellidop")
                txtMaterno.Text = Fila.Item("apellidom")
                cbostatus.SelectedIndex = IIf(Fila.Item("iEstatus") = "1", 0, 1)

                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdlista_Click(sender As Object, e As EventArgs) Handles cmdlista.Click

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub frmpromotor_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
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

    Private Sub pnlProveedores_EnabledChanged(sender As Object, e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = Not pnlProveedores.Enabled
    End Sub
End Class