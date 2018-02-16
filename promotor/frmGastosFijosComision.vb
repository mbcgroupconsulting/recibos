Public Class frmGastosFijosComision
    Public gIdCliente
    Dim blnNuevo As Boolean
    Dim IdGastoComision

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Try



            If txtimporte.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el importe"
            End If

            If txtcomentario.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique la descripción del gasto"
            End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If




            If blnNuevo Then

                SQL = "EXEC setGastosFijosComisionInsertar   0," & gIdCliente
                SQL &= ",'" & txtcomentario.Text
                SQL &= "'," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                SQL &= ",1"




            Else
                SQL = "EXEC setGastosFijosComisionActualizar " & IdGastoComision & "," & gIdCliente
                SQL &= ",'" & txtcomentario.Text
                SQL &= "'," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                SQL &= ",1"
            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If

            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Limpiar()



            cargarlista()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub limpiar()

        txtimporte.Text = "0"
        txtcomentario.Text = ""
        blnNuevo = True
    End Sub

    Private Sub frmGastosFijosComision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarlista()
        blnNuevo = True


    End Sub

    Private Sub cargarlista()
        Dim sql As String

        sql = "select * from GastosFijosComision where iEstatus=1 and fkiIdCliente=" & gIdCliente





        Dim rwFilas As DataRow() = nConsulta(sql)
        lsvLista.Items.Clear()
        lsvLista.Clear()

        lsvLista.Columns.Add("Descripcion")
        lsvLista.Columns(0).Width = 300
        lsvLista.Columns.Add("Importe")
        lsvLista.Columns(1).Width = 170
        lsvLista.Columns(1).TextAlign = 1


        If rwFilas Is Nothing = False Then
            Dim Alter As Boolean = False
            Dim item As ListViewItem


            For x As Integer = 0 To rwFilas.Length - 1
                Dim Fila As DataRow = rwFilas(x)
                item = lsvLista.Items.Add(Fila.Item("Descripcion"))
                item.SubItems.Add(Fila.Item("Cantidad"))

                'totalfactura = totalfactura + txttotal.Text
                'txttotalf.Text = (Double.Parse(Fila.Item("total")) + Double.Parse(txttotalf.Text)).ToString()

                item.Tag = Fila.Item("iIdGastosFijosComision")

                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter

            Next

            MessageBox.Show(rwFilas.Length & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("No se encontraron registros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtimporte_LostFocus(sender As Object, e As EventArgs) Handles txtimporte.LostFocus
        txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "0", txtimporte.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        If lsvLista.SelectedItems.Count > 0 Then
            editar(lsvLista.SelectedItems(0).Tag)
        End If
    End Sub

    Private Sub editar(id As String)
        Dim sql As String
        limpiar()
        sql = "select * from GastosFijosComision where iIdGastosFijosComision = " & id
        Dim rwFilas As DataRow() = nConsulta(sql)
        Try
            If rwFilas Is Nothing = False Then
                blnNuevo = False
                Dim Fila As DataRow = rwFilas(0)



                txtimporte.Text = Fila.Item("Cantidad")
                txtcomentario.Text = Fila.Item("Descripcion")

                IdGastoComision = id


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        limpiar()

    End Sub

    Private Sub cmdBorrar_Click(sender As Object, e As EventArgs) Handles cmdBorrar.Click
        Dim bandera As Boolean
        Dim sql
        Dim color As Integer
        Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
        Try
            If datos.Count = 1 Then

                Dim resultado As Integer = MessageBox.Show("¿Desea borrar el gasto: " & datos(0).SubItems(0).Text & "? (Este proceso no es reversible)", "Pregunta", MessageBoxButtons.YesNo)


                If resultado = DialogResult.Yes Then
                    'MessageBox.Show(datos(0).Tag, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    color = 0
                    bandera = False



                    sql = "update GastosFijosComision set iEstatus=0 where iIdGastosFijosComision=" & datos(0).Tag

                    If nExecute(sql) = False Then

                        MessageBox.Show("Ocurrio un error," & sql, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    blnNuevo = True

                    cargarlista()

                    MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)




                    'lsvLista.SelectedItems(0).Remove()

                End If
            Else
                MessageBox.Show("No hay datos seleccionados para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class