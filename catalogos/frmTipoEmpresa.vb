Public Class frmTipoEmpresa
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdTipoEmpresa As String

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

    Private Sub Mostrar_DatosTipoEmpresa(ByVal IdTipoEmpresa As String)
        SQL = "select * from tipo_empresa where iIdTipoEmpresa = " & IdTipoEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlTipoEmpresa.Enabled = True
                Dim Fila As DataRow = rwFilas(0)
                txtnombre.Text = Fila.Item("nombre")
                cbostatus.SelectedIndex = IIf(Fila.Item("iEstatus") = 1, 0, 1)
                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As System.Object, e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdbuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarTipoEmpresa
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            gIdTipoEmpresa = Forma.gIdTipoEmpresa
            Mostrar_DatosTipoEmpresa(Forma.gIdTipoEmpresa)

        End If
    End Sub

    Private Sub cmdcancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancelar.Click
        pnlTipoEmpresa.Enabled = False
        Limpiar(pnlTipoEmpresa)
    End Sub

    Private Sub cmdguardar_Click(sender As System.Object, e As System.EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            'Validar
            If txtnombre.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el nombre del Tipo de empresa"
            End If
            
            If cbostatus.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el estatus del Tipo de empresa"
            End If

            
            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC settipo_empresaInsertar  0,'" & txtnombre.Text & "'"
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0)
            Else
                'Actualizar

                SQL = "EXEC settipo_empresaActualizar  " & gIdTipoEmpresa & ",'" & txtnombre.Text & "'"
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0)



            End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If
            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlTipoEmpresa.Enabled = False
            Limpiar(pnlTipoEmpresa)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdnuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdnuevo.Click
        pnlTipoEmpresa.Enabled = True
        blnNuevo = True
        cbostatus.Focus()
    End Sub

    Private Sub frmTipoEmpresa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
    End Sub


    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub pnlTipoEmpresa_EnabledChanged(sender As Object, e As System.EventArgs) Handles pnlTipoEmpresa.EnabledChanged
        cmdnuevo.Enabled = Not pnlTipoEmpresa.Enabled
        cmdguardar.Enabled = pnlTipoEmpresa.Enabled
        cmdcancelar.Enabled = pnlTipoEmpresa.Enabled
        cmdbuscar.Enabled = Not pnlTipoEmpresa.Enabled
    End Sub
End Class