Public Class frmBuscarDepartamento
    Public gIdDepartamento As String
    Public SoloActivo As Boolean = False
    Public gIdEmpresa As String
    Private Sub frmBuscarSucursal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim SQL As String, Alter As Boolean = False
        Try
            SQL = "select iIdDepartamentoAlta ,cNombre ,cDescripcion  from DepartamentosAlta "
            SQL &= " where (cNombre like '%" & txtbuscar.Text & "%')"
            If SoloActivo Then
                SQL &= " AND iEstatus = 1"
            End If
            SQL &= " order by cNombre,cDescripcion "
            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem
            lsvPuestos.Items.Clear()
            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    item = lsvPuestos.Items.Add(Fila.Item("cNombre"))
                    item.SubItems.Add("" & Fila.Item("cDescripcion"))
                    item.Tag = Fila.Item("iIdDepartamentoAlta")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            End If
            If lsvPuestos.Items.Count > 0 Then
                lsvPuestos.Focus()
                lsvPuestos.Items(0).Selected = True
            Else
                txtbuscar.Focus()
                txtbuscar.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lsvPuestos_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvPuestos.ItemActivate
        If lsvPuestos.SelectedItems.Count > 0 Then
            gIdDepartamento = lsvPuestos.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub


End Class