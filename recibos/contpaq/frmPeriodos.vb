Public Class frmPeriodos
    Public gIPeriodo As String
    Public gNombrePeriodo As String
    Public gIEmpresa As String
    Private Sub frmPeriodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        lsvLista.Items.Clear()
        lsvLista.Clear()

        lsvLista.Columns.Add("")
        lsvLista.Columns(0).Width = 250
        sql = "select * from tipos_periodo where fkiIdEmpresa = " & gIEmpresa
        Dim rwFilas As DataRow() = nConsulta(sql)

        If rwFilas Is Nothing = False Then
            Dim item As ListViewItem
            For x As Integer = 0 To rwFilas.Length - 1
                item = lsvLista.Items.Add(rwFilas(x)("cNombrePeriodo"))
                item.Tag = rwFilas(x)("iIdTipoPeriodo")

            Next
        End If
    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        If lsvLista.SelectedItems.Count > 0 Then
            gIPeriodo = lsvLista.SelectedItems(0).Tag
            gNombrePeriodo = lsvLista.SelectedItems(0).SubItems.Item(0).Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub
End Class