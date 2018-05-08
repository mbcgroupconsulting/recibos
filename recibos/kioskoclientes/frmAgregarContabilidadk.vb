Public Class frmAgregarContabilidadk
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdClienteEmpresa As String
    Private Sub frmAgregarContabilidadk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        MostrarEmpresa()
        MostrarDocumentos()
    End Sub
    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            Sql = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MostrarDocumentos()
        'Verificar si se tienen permisos
        Try
            SQL = "Select Documentos,iIdDocumentos from Documentos where iEstatus=1 and cArea=1 order by iIdDocumentos  "
            nCargaCBO(cboDocumento, SQL, Trim("Documentos"), "iIdDocumentos")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdnuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        'MostrarCliente2()

        blnNuevo = True
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim usuario As String = "", idperfil As String = "", nombrearchivocompleto As String


        Try
            If lsvLista.Items.Count <= 0 And Mensaje = "" Then
                Mensaje = "Tiene que seleccionar por lo menos una empresa"
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

            If blnNuevo Then
                'Insertar nuevo

                For Each renglon As ListViewItem In lsvLista.Items
                    For Each archivo As ListViewItem In lsvArchivo.Items
                        Dim doc As DataRow() = nConsulta("SELECT * FROM Documentos where Documentos='" & archivo.SubItems(2).Text & "'")

                        nombrearchivocompleto = cboanio.Text & "-" & cbomes.SelectedIndex + 1 & "-" & renglon.Tag & "-" & Gen_Psw(15, True) & "-" & archivo.Tag.Replace(" ", "-")
                        SQL = "EXEC setInfoKioskoInsertar 0," & cboanio.Text & "," & cbomes.SelectedIndex + 1
                        SQL &= "," & 20
                        SQL &= ",'" & Date.Now.ToShortDateString() & "','" & Date.Now.ToShortDateString()
                        SQL &= "','" & nombresistema & "',''"
                        SQL &= "," & renglon.Tag
                        SQL &= ",0"
                        SQL &= "," & idperfil
                        SQL &= "," & usuario
                        SQL &= ",'" & nombrearchivocompleto
                        SQL &= "'"
                        SQL &= "," & doc(0).Item("iIdDocumentos")

                        FileCopy(archivo.SubItems(0).Text, "C:\Temp\" & nombrearchivocompleto)

                        My.Computer.Network.UploadFile("C:\Temp\" & nombrearchivocompleto, "ftp://192.168.1.222/" & nombrearchivocompleto, "infodown", "rkd4e33lr4")

                        If nExecute(SQL) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Next
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
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

            cboempresa.SelectedIndex = 0




        Next
    End Sub
    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub pnlProveedores_EnabledChanged(sender As Object, e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = Not pnlProveedores.Enabled
    End Sub

    Private Sub cmdagregar_Click(sender As Object, e As EventArgs) Handles cmdagregar.Click
        Dim item As ListViewItem
        Dim Alter As Boolean = False
        Dim validacion As Boolean
        Try
            validacion = True

            'recorremos la lista

            For Each renglon As ListViewItem In lsvLista.Items
                If renglon.Tag = cboempresa.SelectedValue Then
                    validacion = False

                End If
            Next

            If validacion Then
                item = lsvLista.Items.Add("(" & cboempresa.SelectedValue & ")" & cboempresa.Text)
                item.Tag = cboempresa.SelectedValue

                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter
            Else
                'Ya esta agregada la empresa
                MessageBox.Show("La empresa ya esta agregada, elige otra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdborrarfactura_Click(sender As Object, e As EventArgs) Handles cmdborrarfactura.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
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

    Private Sub cmdarchivo_Click(sender As Object, e As EventArgs) Handles cmdarchivo.Click
        Dim dialogo As New OpenFileDialog()
        Dim item As ListViewItem
        Dim Alter As Boolean = False
        Try
            If cboDocumento.SelectedValue <> Nothing Then

                Dim valor As ListViewItem = lsvArchivo.FindItemWithText(cboDocumento.Text)
                If valor Is Nothing Then


                    With dialogo
                        .Title = "Búsqueda de archivos."
                        .Filter = "Archivos pdf (pdf)|*.pdf;"
                        .CheckFileExists = True
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then

                            SQL = "SELECT * FROM Documentos where cArea=1 and iIdDocumentos=" & cboDocumento.SelectedValue
                            Dim doc As DataRow() = nConsulta(SQL)


                            item = lsvArchivo.Items.Add(.FileName)
                            item.Tag = System.IO.Path.GetFileNameWithoutExtension(.FileName) & System.IO.Path.GetExtension(.FileName)
                            item.SubItems.Add("Contabilidad")
                            item.SubItems.Add(doc(0).Item("Documentos"))
                            item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                            Alter = Not Alter

                        End If
                    End With
                Else

                    MessageBox.Show("Escoja otro tipo de documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Else
                MessageBox.Show("Seleccione el tipo de documento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

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