Public Class frmBuscarSucursal
    Public gIdSucursal As String
    Public SoloActivo As Boolean = False
    Public gIdEmpresa As String
    Private Sub frmBuscarSucursal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim SQL As String, Alter As Boolean = False
        Try
            SQL = "select iIdSucursal,calle + ' ' + numero + ' ' + colonia + ' ' + municipio as nombre,registropatronal  from sucursal "
            SQL &= " where (calle like '%" & txtbuscar.Text & "%' or colonia like '%" & txtbuscar.Text & "%' or municipio like '%" & txtbuscar.Text & "%' or registropatronal like '%" & txtbuscar.Text & "%') AND fkiIdEmpresa =" & gIdEmpresa
            If SoloActivo Then
                SQL &= " AND iEstatus = 1"
            End If
            SQL &= " order by nombre,registropatronal "
            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvEmpresas.Items.Clear()
            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    item = lsvEmpresas.Items.Add(Fila.Item("iIdSucursal"))
                    item.SubItems.Add("" & Fila.Item("registropatronal"))
                    item.Tag = Fila.Item("iIdSucursal")
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
            gIdSucursal = lsvEmpresas.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class