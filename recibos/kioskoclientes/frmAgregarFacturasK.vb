Public Class frmAgregarFacturasK
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdClienteEmpresa As String
    Dim files As Integer
    Dim tmm As Integer

    Private Sub frmAgregarFacturasK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        cmdDeleted.Enabled = False
        MostrarClientes()
        MostrarDocumentos()
        TabIndex()
    End Sub

    Private Sub cmdnuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        'MostrarCliente2()

        blnNuevo = True
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdguardar.Click
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

                        ' Dim doc As DataRow() = nConsulta("SELECT * FROM Documentos where Documentos='" & archivo.SubItems(2).Text & "' AND iTMM=" & tmm)

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
                        SQL &= ",100"


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
                'Limpiar(pnlProveedores)
             
            End If


        Catch ex As Exception
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

            Else
                MessageBox.Show("No hay una empresa seleccionada para asociar los archivos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If cboanio.SelectedIndex > 0 Then

            
            'Trae los documentos que se guardaron en recibos, tambien los no asignados
            SQL = "EXEC getDocFactMesAno_KC "
            SQL &= cboclientes.SelectedValue & ","
            SQL &= datos(0).Tag & ","
            SQL &= cbomes.SelectedIndex + 1 & ","
            SQL &= cboanio.Text



            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvArchivo.Items.Clear()

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas

                    item = lsvArchivo.Items.Add(Fila.Item("nombrearchivo"))

                    ' item.Tag = System.IO.Path.GetFileNameWithoutExtension(.FileName) & System.IO.Path.GetExtension(.FileName)

                    item.SubItems.Add("Facturación")


                    'Dim doc As DataRow() = nConsulta("SELECT * FROM Documentos where cArea=2 and iIdDocumentos=" & Fila.Item("fkiIdDocumentos"))
                    item.SubItems.Add("Facturas")

                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            Else
                MessageBox.Show("No se encontro algun documento, revise la información", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Porfavor seleccione un año", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch

        End Try

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdagregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdagregar.Click
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

            'validarTMM()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdarchivo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdarchivo.Click
        Dim dialogo As New OpenFileDialog()
        Dim item As ListViewItem
        Dim Alter As Boolean = False
        'Dim d As String
        Try

            ' item.SubItems.Clear()


            ' If Duplicado(Trim(cboDocumento.SelectedItem)) = False Then
            With dialogo
                .Title = "Búsqueda de archivos."
                .Filter = "Archivos RAR (Rar)|*.rar;*.zip;"
                .CheckFileExists = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    ' item.SubItems.Clear()

                    files = files + 1
                    SQL = "SELECT * FROM Documentos where cArea=2 and iIdDocumentos=" & cboDocumento.SelectedValue
                    Dim doc As DataRow() = nConsulta(SQL)


                    item = lsvArchivo.Items.Add(.FileName)

                    item.Tag = System.IO.Path.GetFileNameWithoutExtension(.FileName) & System.IO.Path.GetExtension(.FileName)

                    item.SubItems.Add("FACTURACION")
                    item.SubItems.Add("Doc")

                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                End If

            End With





        Catch ex As Exception
            MsgBox(ex.Message)
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

   

    Private Sub TabIndex()
        cboclientes.TabIndex = 1
        cmdagregar.TabIndex = 2
        cmdborrarfactura.TabIndex = 3
        lsvLista.TabIndex = 4
        cmdarchivo.TabIndex = 5
        cboanio.TabIndex = 6
        cbomes.TabIndex = 7
        cmdBorrarArchivo.TabIndex = 8
        cboDocumento.TabIndex = 9
        lsvArchivo.TabIndex = 10

    End Sub

    Private Sub MostrarClientes()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre  "
            nCargaCBO(cboclientes, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MostrarDocumentos()
        'Verificar si se tienen permisos
        Try
            SQL = "Select Documentos,iIdDocumentos from Documentos where iEstatus=1 and cArea=2"
            SQL &= sqltmm()

            nCargaCBO(cboDocumento, SQL, Trim("Documentos"), "iIdDocumentos")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pnlProveedores_EnabledChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = pnlProveedores.Enabled
        cmdDeleted.Enabled = pnlProveedores.Enabled
    End Sub

    Private Sub cboclientes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboclientes.SelectedIndexChanged
        lsvLista.Items.Clear()
    End Sub

    Public Sub cboclientes_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cboclientes.LostFocus
        MostrarDocumentos()
    End Sub
    Public Function sqltmm() As String

        If cboclientes.SelectedValue = "37" Or
            cboclientes.SelectedValue = "411" Or
            cboclientes.SelectedValue = "420" Then

            tmm = 1
            Return "AND iTMM=1  order by iIdDocumentos"
        Else
            tmm = 0
            Return "AND iTMM=0  order by iIdDocumentos"

        End If

    End Function



    Private Sub cmdDeleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleted.Click

        Try


            Dim datos As ListView.SelectedListViewItemCollection = lsvArchivo.SelectedItems
            If datos.Count > 0 Then
                Dim resultado As Integer = MessageBox.Show("¿Desea borrar el documento, se eliminara del sistema " & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


                If resultado = DialogResult.Yes Then

                    SQL = "DELETE FROM InfoKiosko where nombrearchivo like '%" & datos(0).SubItems(0).Text & "%'"

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
        End Try
    End Sub
End Class