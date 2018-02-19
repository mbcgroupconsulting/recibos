Public Class frmBuscarCliente
    Public gIdProveedor As String
    Public SoloActivo As Boolean = False

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdBuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdBuscar.Click
        Dim SQL As String, Alter As Boolean = False
        Try
            SQL = "select iIdCliente,nombre, nombrefiscal from clientes "
            SQL &= " where (nombre like '%" & txtbuscar.Text & "%' or nombrefiscal like '%" & txtbuscar.Text & "%')"
            'If SoloActivo Then
            SQL &= " AND iEstatus = 1"
            'End If
            SQL &= " order by nombre,nombrefiscal "
            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvProveedor.Items.Clear()
            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    item = lsvProveedor.Items.Add(Fila.Item("nombre"))
                    item.SubItems.Add("" & Fila.Item("nombrefiscal"))
                    item.Tag = Fila.Item("iIdCliente")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            End If
            If lsvProveedor.Items.Count > 0 Then
                lsvProveedor.Focus()
                lsvProveedor.Items(0).Selected = True
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

    Private Sub lsvProveedor_ItemActivate(sender As Object, e As System.EventArgs) Handles lsvProveedor.ItemActivate
        If lsvProveedor.SelectedItems.Count > 0 Then
            gIdProveedor = lsvProveedor.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub frmBuscarCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class