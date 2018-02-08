Public Class frmBuscarComisionFlujoNomina
    Public gIdCliente As String
    Public SoloActivo As Boolean = False
    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Dim SQL As String, Alter As Boolean = False
        Try
            SQL = "select iIdCliente,nombre, nombrefiscal from clientes inner join ComisionClienteFlujo on iIdCliente=fkiIdCliente "
            SQL &= " where (nombre like '%" & txtbuscar.Text & "%' or nombrefiscal like '%" & txtbuscar.Text & "%')"
            'If SoloActivo Then
            SQL &= " AND clientes.iEstatus = 1 AND ComisionClienteFlujo.tipo=2"
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

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lsvProveedor_ItemActivate(sender As Object, e As EventArgs) Handles lsvProveedor.ItemActivate
        If lsvProveedor.SelectedItems.Count > 0 Then
            gIdCliente = lsvProveedor.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub txtbuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmBuscarComisionClienteFlujo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class