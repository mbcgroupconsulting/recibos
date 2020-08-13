Public Class frmAgregarJuridico
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdClienteEmpresa As String
    Dim files As Integer
    Dim tmm As Integer

    Dim basedatos As String = ""
    Dim tablausuarios As String = ""
    Dim nombreusuario As String = ""
    Dim idusuariok As String = ""
    Dim carpetakiosko As String = ""

    Private Sub cmdnuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True   
        blnNuevo = True
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdguardar.Click
        Dim bSubir As Boolean
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim usuario As String = "", idperfil As String = "", nombrearchivocompleto As String

        Try
            '  DesconectarKiosko()
            Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
            If datos.Count = 1 Then

            Else
                MessageBox.Show("No hay un empleado seleccionada para asociar los archivos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If lsvLista.Items.Count <= 0 And Mensaje = "" Then
                Mensaje = "Seleccione el empleado al que pertenece la información"
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

            Dim resultado As Integer = MessageBox.Show("¿Desea guardar la información para el cliente: " & cboclientes.Text & " y empleado:" & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)

            If resultado = DialogResult.Yes Then
                If blnNuevo Then
                    'Insertar nuevo
                    DesconectarKiosko()
                    ConectarKiosko(basedatos)
                    mdoObjetos3.sBase = basedatos

                    For Each archivo As ListViewItem In lsvArchivo.Items



                        'bSubir = True
                        nombrearchivocompleto = cboanio.Text & "-" & cbomes.SelectedIndex + 1 & "-" & "-" & Gen_Psw(15, True) & "-" & archivo.Tag.Replace(" ", "-")


                        SQL = "EXEC setArchivosAltaInsertar 0, '" & nombrearchivocompleto & "',"
                        SQL &= datos(0).Tag
                        SQL &= "," & cboanio.Text
                        SQL &= "," & cbomes.SelectedIndex + 1 & ",'" & Date.Now.ToShortDateString()
                        SQL &= "','" & nombresistema & "'"
                        SQL &= "," & 1
                        FileCopy(archivo.SubItems(0).Text, "C:\Temp\" & nombrearchivocompleto)

                        'My.Computer.Network.UploadFile("C:\Temp\" & nombrearchivocompleto, "ftp://192.168.1.222/" & nombrearchivocompleto, "infodown", "rkd4e33lr4")
                        My.Computer.Network.UploadFile("C:\Temp\" & nombrearchivocompleto, "ftp://" & Servidor.IP & "/" & nombrearchivocompleto, carpetakiosko, "rkd4e33lr4")

                        If nExecuteKiosko(SQL) = False Then
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
                DesconectarKiosko()
                pnlProveedores.Enabled = False
                Limpiar(pnlProveedores)
            End If


        Catch ex As Exception
            DesconectarKiosko()
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdcancelar.Click
        pnlProveedores.Enabled = False
        Limpiar(pnlProveedores)
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
    Private Sub cmdbuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdbuscar.Click

        Dim Alter As Boolean = False
        'lsvArchivo.Clear()

        Try
            Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
            If datos.Count = 1 Then

                ' lsvArchivo.Clear()

            Else
                MessageBox.Show("No hay una empresa seleccionada para asociar los archivos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ConectarKiosko(basedatos)
            mdoObjetos3.sBase = basedatos

            'Trae los documentos que se guardaron en recibos, tambien los no asignados
            SQL = "EXEC [getArchivosAltaListar] "
            SQL &= datos(0).Tag & ", "
            SQL &= cbomes.SelectedIndex + 1 & ", "
            SQL &= cboanio.Text


            Dim rwFilas As DataRow() = nConsultaKiosko(SQL)
            Dim item As ListViewItem
            lsvArchivo.Items.Clear()

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas

                    item = lsvArchivo.Items.Add(Fila.Item("cNombreArchivo"))
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            Else
                MessageBox.Show("No se encontro algun documento, revise la información", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            DesconectarKiosko()
        Catch
            DesconectarKiosko()
        End Try

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

  

    Private Sub cmdarchivo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdarchivo.Click
        Dim dialogo As New OpenFileDialog()
        Dim item As ListViewItem
        Dim Alter As Boolean = False
        Dim d As String
        Try


            'If cboDocumento.SelectedValue <> Nothing Then
            'Dim valor As ListViewItem = lsvArchivo.FindItemWithText(cboDocumento.Text)
            'If valor Is Nothing Then

            'If Duplicado(Trim(cboDocumento.SelectedItem)) = False Then
            With dialogo
                .Title = "Búsqueda de archivos."
                .Filter = "Archivos pdf (pdf)|*.pdf;"
                .CheckFileExists = True
                .Multiselect = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then


                    files = files + 1


                    item = lsvArchivo.Items.Add(.FileName)

                    item.Tag = System.IO.Path.GetFileNameWithoutExtension(.FileName) & System.IO.Path.GetExtension(.FileName)

                    'item.SubItems.Add("Juridico")
                    'item.SubItems.Add(doc(0).Item("Documentos"))

                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                End If

            End With

            'Else
            'MessageBox.Show("Escoja otro tipo de documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'End If

            'Else
            '    MessageBox.Show("Seleccione el tipo de documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If

        Catch ex As Exception
            DesconectarKiosko()
        End Try
    End Sub

    Private Sub cmdBorrarArchivo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBorrarArchivo.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvArchivo.SelectedItems
        If datos.Count = 1 Then
            Dim resultado As Integer = MessageBox.Show("¿Desea borrar la empresa " & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


            If resultado = DialogResult.Yes Then

                datos(0).Remove()
                files = files - 1
                MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If
        Else
            MessageBox.Show("No hay una empresa seleccionada para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub frmAgregarJuridico_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        cmdDeleted.Enabled = False
        MostrarClientes()
        TabIndex()

    End Sub

   

    Private Sub MostrarClientes()
        cboclientes.Items.Clear()
        cboclientes.Items.Add("MAECCO")
        cboclientes.Items.Add("XURTEP")
        cboclientes.Items.Add("OPERADORA")
        cboclientes.Items.Add("NAVIGATOR")
        cboclientes.Show()
    End Sub
    Private Sub TabIndex()
        cboclientes.TabIndex = 1
        'cmdborrarfactura.TabIndex = 2
        cmdarchivo.TabIndex = 3
        cboanio.TabIndex = 4
        cbomes.TabIndex = 7
        cmdBorrarArchivo.TabIndex = 8

        lsvArchivo.TabIndex = 10

    End Sub





    Private Sub pnlProveedores_EnabledChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = pnlProveedores.Enabled
        cmdDeleted.Enabled = pnlProveedores.Enabled
    End Sub






    Private Sub cmdDeleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleted.Click

        Try


            Dim datos As ListView.SelectedListViewItemCollection = lsvArchivo.SelectedItems
            If datos.Count > 0 Then
                Dim resultado As Integer = MessageBox.Show("¿Desea borrar el documento, se eliminara del sistema " & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


                If resultado = DialogResult.Yes Then

                    SQL = "DELETE FROM ArchivosAlta where nombrearchivo like '%" & datos(0).SubItems(0).Text & "%'"

                    If nExecute(SQL) = False Then
                        MessageBox.Show("Hubo un problema al borrar, revise sus datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        datos(0).Remove()
                        MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmdbuscar_Click(sender, e)
                    End If

                End If

            Else

                MessageBox.Show("Seleccione un archivo para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
            DesconectarKiosko()
        End Try
    End Sub

 

    Private Sub cmdagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdagregar.Click       
        Dim Alter As Boolean = False
        Try

            DesconectarKiosko()

            Select Case cboclientes.SelectedItem
                Case "MAECCO"
                    basedatos = "kiosko"
                    tablausuarios = "Usuarios"
                    nombreusuario = "nombreC"
                    idusuariok = "IdUsuario"
                    carpetakiosko = "contratost"
                    'rkd4e33lr4
                Case "NAVIGATOR"
                    basedatos = "kioskonavigator"
                    tablausuarios = "UsuarioK"
                    nombreusuario = "nombreC"
                    idusuariok = "iIdUsuarioK"
                    carpetakiosko = "contratostnaviga"

                Case "OPERADORA"
                    basedatos = "kioskooperadora"
                    tablausuarios = "UsuarioK"
                    nombreusuario = "nombreC"
                    idusuariok = "iIdUsuarioK"
                    carpetakiosko = "contratostopera"

                Case "XURTEP"
                    basedatos = "kioskoxurtep"
                    tablausuarios = "UsuarioK"
                    nombreusuario = "nombreC"
                    idusuariok = "iIdUsuarioK"
                    carpetakiosko = "contratostxurtep"

            End Select

            ConectarKiosko(basedatos)
            mdoObjetos3.sBase = basedatos

            SQL = "select " & nombreusuario & ", " & idusuariok & " from " & tablausuarios & " WHERE " '& iEstatus=1 "
            SQL &= IIf(basedatos = "MAECCO", "  fkIdPerfil=2 ", "  iEstatus=1")
            SQL &= " order by " & nombreusuario & ", " & idusuariok

            Dim rwUsuarioK As DataRow() = nConsultaKiosko(SQL)
            Dim item As ListViewItem
            lsvLista.Items.Clear()

            If rwUsuarioK Is Nothing = False Then
                For Each Fila In rwUsuarioK
                    item = lsvLista.Items.Add(Fila.Item(nombreusuario))
                    item.Tag = Fila.Item(idusuariok)
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            End If

            DesconectarKiosko()

        Catch ex As Exception
            DesconectarKiosko()

        End Try
    End Sub

    Private Sub cmdborrarfactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdborrarfactura.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvArchivo.SelectedItems
        If datos.Count = 1 Then
            Dim resultado As Integer = MessageBox.Show("¿Desea borrar la empleados " & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


            If resultado = DialogResult.Yes Then

                datos(0).Remove()
                MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If
        Else
            MessageBox.Show("No hay una empleados seleccionada para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class