Public Class frmAgregarNominaK
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdClienteEmpresa As String
    Private Sub cmdnuevo_Click(sender As Object, e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        'MostrarCliente2()

        blnNuevo = True
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim usuario As String = "", idperfil As String = "", nombrearchivocompleto As String


        Try
            Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
            If datos.Count = 1 Then

            Else
                MessageBox.Show("No hay una empresa seleccionada para asociar los archivos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If lsvArchivo.Items.Count <= 0 And Mensaje = "" Then
                Mensaje = "Tiene que agregar por lo menos un archivo"
            End If

            If cboanio.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Seleccione el año al que pertenece la información"
            End If

            If cbomes.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Seleccione el mes al que pertenece la información"
            End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwUsuario As DataRow() = nConsulta(SQL)

            If rwUsuario Is Nothing = False Then
                Dim Fila As DataRow = rwUsuario(0)
                nombresistema = Fila.Item("nombre")
                usuario = Fila.Item("IdUsuario")
                idperfil = Fila.Item("fkIdPerfil")

            End If

            Dim resultado As Integer = MessageBox.Show("¿Desea guardar la información para el cliente: " & cboclientes.Text & " y empresa:" & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


            If resultado = DialogResult.Yes Then
                If blnNuevo Then
                    'Insertar nuevo


                    For Each archivo As ListViewItem In lsvArchivo.Items

                        nombrearchivocompleto = cboanio.Text & "-" & cbomes.SelectedIndex + 1 & "-" & datos(0).Tag & "-" & Gen_Psw(15, True) & "-" & archivo.Tag.Replace(" ", "-")
                        SQL = "EXEC setInfoKioskoInsertar 0," & cboanio.Text & "," & cbomes.SelectedIndex + 1
                        SQL &= "," & 20
                        SQL &= ",'" & Date.Now.ToShortDateString() & "','" & Date.Now.ToShortDateString()
                        SQL &= "','" & nombresistema & "',''"
                        SQL &= "," & datos(0).Tag
                        SQL &= "," & cboclientes.SelectedValue
                        SQL &= "," & idperfil
                        SQL &= "," & usuario
                        SQL &= ",'" & nombrearchivocompleto
                        SQL &= "'"

                        FileCopy(archivo.SubItems(0).Text, "C:\Temp\" & nombrearchivocompleto)

                        My.Computer.Network.UploadFile("C:\Temp\" & nombrearchivocompleto, "ftp://192.168.1.222/" & nombrearchivocompleto, "infodown", "rkd4e33lr4")

                        If nExecute(SQL) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                    Next



                Else
                    'Actualizar

                    'SQL = "EXEC setInfoKioskoActualizar " & gIdProveedor & ",'" & txtnombre.Text & "','" & txtnombre2.Text
                    'SQL &= "," & 20
                    'SQL &= ",'" & Date.Now.ToShortDateString() & "','" & Date.Now.ToShortDateString()
                    'SQL &= "','" & nombresistema & "''"
                    'SQL &= "," & renglon.Tag
                    'SQL &= ",0"
                    'SQL &= "," & idperfil
                    'SQL &= "," & idUsuario
                    'SQL &= ",'" & cboanio.Text & "-" & cbomes.SelectedIndex + 1 & "-" & renglon.Tag & "-" & archivo.SubItems(0).Text.Replace(" ", "-") & "-" & Gen_Psw(15, True)
                    'SQL &= "'"
                    'If nExecute(SQL) = False Then
                    '    Exit Sub
                    'End If

                End If

                MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                pnlProveedores.Enabled = False
                Limpiar(pnlProveedores)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            cboclientes.SelectedIndex = 0




        Next
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        pnlProveedores.Enabled = False
        Limpiar(pnlProveedores)
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub frmAgregarNominaK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        MostrarClientes()
    End Sub

    Private Sub MostrarClientes()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre  "
            nCargaCBO(cboclientes, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pnlProveedores_EnabledChanged(sender As Object, e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = Not pnlProveedores.Enabled
    End Sub

    Private Sub cboclientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboclientes.SelectedIndexChanged
        lsvLista.Items.Clear()
    End Sub

    Private Sub cmdagregar_Click(sender As Object, e As EventArgs) Handles cmdagregar.Click
        Dim Alter As Boolean = False
        Try
            SQL = "select empresa.iIdEmpresa,empresa.nombre from IntClienteEmpresaKiosko"
            SQL &= " inner join empresa on IntClienteEmpresaKiosko.fkiIdEmpresa= empresa.iIdEmpresa"
            SQL &= " where IntClienteEmpresaKiosko.fkiIdCliente=" & cboclientes.SelectedValue
            SQL &= " order by empresa.nombre "
            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvLista.Items.Clear()
            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    item = lsvLista.Items.Add(Fila.Item("nombre"))
                    item.Tag = Fila.Item("iIdEmpresa")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter


                Next
            End If
            'If lsvLista.Items.Count > 0 Then
            '    lsvLista.Focus()
            '    lsvLista.Items(0).Selected = True

            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdarchivo_Click(sender As Object, e As EventArgs) Handles cmdarchivo.Click
        Dim dialogo As New OpenFileDialog()
        Dim item As ListViewItem
        Dim Alter As Boolean = False
        Try


            With dialogo
                .Multiselect = True
                .Title = "Búsqueda de archivos"
                .Filter = "Archivos comprimidos|*.zip;*.rar"
                .CheckFileExists = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then

                    Dim selectfiles() As String = .FileNames

                    For Each file In selectfiles
                        item = lsvArchivo.Items.Add(file)
                        item.Tag = System.IO.Path.GetFileNameWithoutExtension(file) & System.IO.Path.GetExtension(file)

                        item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                        Alter = Not Alter
                    Next



                    'item = lsvArchivo.Items.Add(.FileName)
                    'item.Tag = System.IO.Path.GetFileNameWithoutExtension(.FileName) & System.IO.Path.GetExtension(.FileName)

                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    'Alter = Not Alter

                End If
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdBorrarArchivo_Click(sender As Object, e As EventArgs) Handles cmdBorrarArchivo.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvArchivo.SelectedItems
        If datos.Count = 1 Then
            Dim resultado As Integer = MessageBox.Show("¿Desea borrar la empresa " & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


            If resultado = DialogResult.Yes Then

                datos(0).Remove()
                MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If
        Else
            MessageBox.Show("No hay una empresa seleccionada para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class