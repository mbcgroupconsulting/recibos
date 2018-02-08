Public Class frmBuscarTipoEmpresa
    Public gIdTipoEmpresa As String
    Public SoloActivo As Boolean = False

    Private Sub cmdBuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdBuscar.Click
        Dim SQL As String, Alter As Boolean = False
        Try
            SQL = "select iIdTipoEmpresa,Nombre from tipo_empresa"
            SQL &= " where (Nombre like '%" & txtbuscar.Text & "%')"
            If SoloActivo Then
                SQL &= " AND iEstatus = 1"
            End If
            SQL &= " order by nombre "
            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvtipoempresa.Items.Clear()
            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    item = lsvtipoempresa.Items.Add(Fila.Item("nombre"))
                    item.Tag = Fila.Item("iIdTipoEmpresa")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            End If
            If lsvtipoempresa.Items.Count > 0 Then
                lsvtipoempresa.Focus()
                lsvtipoempresa.Items(0).Selected = True
            Else
                txtbuscar.Focus()
                txtbuscar.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbuscar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtbuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbuscar.TextChanged

    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lsvtipoempresa_ItemActivate(sender As Object, e As System.EventArgs) Handles lsvtipoempresa.ItemActivate
        If lsvtipoempresa.SelectedItems.Count > 0 Then
            gIdTipoEmpresa = lsvtipoempresa.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub lsvtipoempresa_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvtipoempresa.SelectedIndexChanged

    End Sub
End Class