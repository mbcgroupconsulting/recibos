Public Class frmAcceso

    Private Sub frmAcceso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Main()
        Dim SQL As String

        SQL = "SELECT IdSucursal,Descripcion FROM CatSucursales WHERE Status=1 ORDER BY Descripcion"
        nCargaCBO(cboSucursal, SQL, "Descripcion", "IdSucursal")
        If cboSucursal.Items.Count > 0 Then
            cboSucursal.SelectedIndex = 0
        End If

    End Sub

    Private Sub lsvUsuario_ItemActivate(sender As Object, e As System.EventArgs) Handles lsvUsuario.ItemActivate
        txtClave.Focus()
        txtClave.SelectAll()
    End Sub

    Private Sub lsvUsuario_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvUsuario.SelectedIndexChanged
        'txtClave.Focus()
        'txtClave.SelectAll()
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        Dim SQL As String
        If cboSucursal.SelectedIndex >= 0 Then
            SQL = "SELECT * FROM Usuarios WHERE Status=1 AND fkIdSucursal=" & cboSucursal.SelectedValue
            Dim rwUsuarios As DataRow() = nConsulta(SQL)

            lsvUsuario.Items.Clear()
            If rwUsuarios Is Nothing = False Then
                For Each Usuario As DataRow In rwUsuarios
                    Dim item As ListViewItem = lsvUsuario.Items.Add(Usuario!Nombre)
                    item.SubItems.Add(Usuario!Password)
                    item.SubItems.Add(Usuario!fkIdPerfil)
                    item.ImageIndex = 0
                    item.Tag = Usuario!IdUsuario

                Next
            End If
        End If
    End Sub

    Private Sub cmdEntrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEntrar.Click
        If lsvUsuario.SelectedItems.Count > 0 Then
            If txtClave.Text.Trim.Length > 0 Then
                Dim Clave As String = lsvUsuario.SelectedItems(0).SubItems(1).Text
                If StrComp(txtClave.Text, Clave) = 0 Then
                    Me.Visible = False
                    Usuario.Nombre = lsvUsuario.SelectedItems(0).Text
                    Usuario.Perfil = lsvUsuario.SelectedItems(0).SubItems(2).Text
                    Usuario.IdSeccion = cboSucursal.SelectedValue
                    Usuario.Id = lsvUsuario.SelectedItems(0).Tag
                    idUsuario = Usuario.Id
                    Dim frmPrincipal As New frmPrincipal
                    frmPrincipal.ShowDialog()
                    End
                Else
                    MessageBox.Show("La contraseña no es válida", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Por favor indique la clave de acceso", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Por favor seleccione un usuario de la lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        txtClave.Focus()
        txtClave.SelectAll()
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdEntrar_Click(sender, Nothing)
        End If
    End Sub

    Private Sub txtClave_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtClave.TextChanged

    End Sub
End Class