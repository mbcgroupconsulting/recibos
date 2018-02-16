Public Class frmUsuarioCliente
    Dim blnNuevo As Boolean
    Public gIdCliente As String
    Dim gIdClienteAcceso As String
    Private Sub cmdgenerar_Click(sender As Object, e As EventArgs) Handles cmdgenerar.Click
        txtcontra.Text = Gen_Psw(10, True)
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            If txtusuario.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el nombre del cliente"
            End If
            If txtcontra.Text.Trim.Length < 10 And Mensaje = "" Then
                Mensaje = "La contraseña minima es de 10 digitos, la puede generar automaticamente dando click en el botón generar"
            End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setClienteAccesoInsertar 0," & IIf(chkactivo.Checked, "1", "0")
                SQL &= "," & gIdCliente
                SQL &= ",'" & txtusuario.Text
                SQL &= "','" & txtcontra.Text & "'"
                If Execute(SQL, gIdClienteAcceso) = False Then
                    Exit Sub
                End If


                blnNuevo = False

            Else
                'Actualizar

                SQL = "EXEC setClienteAccesoActualizar " & gIdClienteAcceso
                SQL &= "," & IIf(chkactivo.Checked, "1", "0")
                SQL &= "," & gIdCliente
                SQL &= ",'" & txtusuario.Text
                SQL &= "','" & txtcontra.Text & "'"
                If nExecute(SQL) = False Then
                    Exit Sub
                End If

            End If

            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcontra_TextChanged(sender As Object, e As EventArgs) Handles txtcontra.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtusuario_TextChanged(sender As Object, e As EventArgs) Handles txtusuario.TextChanged

    End Sub

    Private Sub frmUsuarioCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQL As String

        Try
            'buscar datos del cliente si es que existen
            SQL = "select * from ClienteAcceso where fkiIdCliente=" & gIdCliente

            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                chkactivo.Checked = IIf(Fila.Item("Activo") = "1", True, False)
                txtusuario.Text = Fila.Item("Usuario")
                txtcontra.Text = Fila.Item("Contraseña")
                gIdClienteAcceso = Fila.Item("iIdClienteAcceso")
                blnNuevo = False
            Else
                gIdClienteAcceso = ""
                blnNuevo = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class