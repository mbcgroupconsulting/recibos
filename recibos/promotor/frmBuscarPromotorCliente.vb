﻿Public Class frmBuscarPromotorCliente
    Public gIdCliente As String
    Public SoloActivo As Boolean = False
    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Dim SQL As String, Alter As Boolean = False
        Try
            SQL = "select iIdCliente,nombre, nombrefiscal from clientes inner join IntClientePromotor on iIdCliente=fkiIdCliente "
            SQL &= " where (nombre like '%" & txtbuscar.Text & "%' or nombrefiscal like '%" & txtbuscar.Text & "%')"
            'If SoloActivo Then
            SQL &= " AND clientes.iEstatus = 1"
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

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub txtbuscar_ForeColorChanged(sender As Object, e As EventArgs) Handles txtbuscar.ForeColorChanged

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

    Private Sub frmBuscarPromotorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class