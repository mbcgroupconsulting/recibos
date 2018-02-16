Public Class frmBuscarEmpresa
    Public gIdEmpresa As String
    Public SoloActivo As Boolean = False
    Private Sub frmBuscarEmpresa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtbuscar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtbuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmdBuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdBuscar.Click
        Dim SQL As String, Alter As Boolean = False
        Try
            SQL = "select iIdEmpresa,nombre, nombrefiscal from empresa "
            SQL &= " where (nombre like '%" & txtbuscar.Text & "%' or nombrefiscal like '%" & txtbuscar.Text & "%')"
            'If SoloActivo Then
            SQL &= " AND iEstatus = 1"
            'End If
            SQL &= " order by nombre,nombrefiscal "
            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvEmpresas.Items.Clear()
            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    item = lsvEmpresas.Items.Add(Fila.Item("nombre"))
                    item.SubItems.Add("" & Fila.Item("nombrefiscal"))
                    item.Tag = Fila.Item("iIdEmpresa")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            End If
            If lsvEmpresas.Items.Count > 0 Then
                lsvEmpresas.Focus()
                lsvEmpresas.Items(0).Selected = True
            Else
                txtbuscar.Focus()
                txtbuscar.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lsvEmpresas_ItemActivate(sender As Object, e As System.EventArgs) Handles lsvEmpresas.ItemActivate
        If lsvEmpresas.SelectedItems.Count > 0 Then
            gIdEmpresa = lsvEmpresas.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub lsvEmpresas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvEmpresas.SelectedIndexChanged

    End Sub
End Class