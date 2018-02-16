Public Class frmMostrarPagos
    Public gIdPrestamo As String

    Private Sub frmMostrarPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim total As Double

        lsvLista.Items.Clear()
        lsvLista.Clear()

        lsvLista.Columns.Add("")
        lsvLista.Columns(0).Width = 250
        lsvLista.Columns(0).TextAlign = 1

        sql = "select * from PagoPrestamo where fkiIdPrestamo = " & gIdPrestamo
        Dim rwFilas As DataRow() = nConsulta(sql)
        total = 0
        If rwFilas Is Nothing = False Then
            Dim item As ListViewItem
            For x As Integer = 0 To rwFilas.Length - 1
                item = lsvLista.Items.Add(rwFilas(x)("monto"))
                item.Tag = rwFilas(x)("iIdPagoPrestamo")
                total = total + rwFilas(x)("monto")

            Next

            lblnumfactura.Text = total

        End If
    End Sub
End Class