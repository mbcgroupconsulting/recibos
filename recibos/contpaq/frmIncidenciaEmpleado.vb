Public Class frmIncidenciaEmpleado
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gIdEmpresa As String
    Public gIdCliente As String
    Public gIdEmpleado As String
    Public gIdPeriodo As String
    Public gIdIncidencia As String
    Private Sub frmIncidenciaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SQL = "select * from periodos where iIdPeriodo=" & gIdPeriodo
        Dim rwPeriodo As DataRow() = nConsulta(SQL)
        If rwPeriodo Is Nothing = False Then
            lblnumfactura.Text = Date.Parse(rwPeriodo(0)("dFechaInicio").ToString).ToShortDateString & " al " & Date.Parse(rwPeriodo(0)("dFechaFin").ToString).ToShortDateString
        End If

        cargarlista()
        blnNuevo = True
    End Sub

    Private Sub cargarlista()
        Dim sql As String

        sql = "Select * from incidencias where fkiIdEmpleado=" & gIdEmpleado & " and fkiIdEmpresa=" & gIdEmpresa & " and fkiIdPeriodo=" & gIdPeriodo & " and iEstatus=1"





        Dim rwFilas As DataRow() = nConsulta(sql)
        lsvLista.Items.Clear()
        lsvLista.Clear()
        lsvLista.Columns.Add("Fecha")
        lsvLista.Columns(0).Width = 90
        lsvLista.Columns.Add("Dias")
        lsvLista.Columns(1).Width = 50
        lsvLista.Columns(1).TextAlign = 1
        lsvLista.Columns.Add("Observaciones")
        lsvLista.Columns(2).Width = 300

        If rwFilas Is Nothing = False Then
            Dim Alter As Boolean = False
            Dim item As ListViewItem

            'Cargamos la lista de abonos

            For x As Integer = 0 To rwFilas.Length - 1
                Dim Fila As DataRow = rwFilas(x)
                item = lsvLista.Items.Add(Fila.Item("fecha"))
                item.SubItems.Add(Fila.Item("numdias"))
                item.SubItems.Add(Fila.Item("observaciones"))


                'totalfactura = totalfactura + txttotal.Text
                'txttotalf.Text = (Double.Parse(Fila.Item("total")) + Double.Parse(txttotalf.Text)).ToString()

                item.Tag = Fila.Item("iIdIncidencia")

                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter

            Next

            MessageBox.Show(rwFilas.Length & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("No se encontraron registros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
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
        sql = "select * from incidencias where iIdIncidencia = " & id
        Dim rwFilas As DataRow() = nConsulta(sql)
        Try
            If rwFilas Is Nothing = False Then
                blnNuevo = False
                Dim Fila As DataRow = rwFilas(0)


                dtpfecha.Value = Fila.Item("fecha")
                txtimporte.Text = Fila.Item("numdias")
                txtcomentario.Text = Fila.Item("Observaciones")

                gIdIncidencia = id


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub limpiar()
        dtpfecha.Value = Date.Now.ToShortDateString()
        txtimporte.Text = "0"
        txtcomentario.Text = ""
        blnNuevo = True
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

                Dim resultado As Integer = MessageBox.Show("¿Desea borrar la incidencia seleccionada ", "Pregunta", MessageBoxButtons.YesNo)


                If resultado = DialogResult.Yes Then
                    'MessageBox.Show(datos(0).Tag, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)



                    sql = "update incidencias set iEstatus=0 where iIdIncidencia=" & datos(0).Tag
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

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Try


            If txtimporte.Text.Trim.Length = 0 And Mensaje = "" Then

                Mensaje = "Por favor indique el importe"

            End If




            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If




            If blnNuevo Then


                'Insertar nuevo con idfactura
                SQL = "EXEC setincidenciasInsertar   0," & gIdEmpresa
                SQL &= "," & gIdPeriodo
                SQL &= "," & gIdEmpleado
                SQL &= "," & txtimporte.Text
                SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "',1"
                SQL &= ",'" & txtcomentario.Text & "'"



            Else

                'Actualizar con idfactura
                SQL = "EXEC setincidenciasActualizar " & gIdIncidencia & "," & gIdEmpresa
                SQL &= "," & gIdPeriodo
                SQL &= "," & gIdEmpleado
                SQL &= "," & txtimporte.Text
                SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "',1"
                SQL &= ",'" & txtcomentario.Text & "'"





            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If

            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargarlista()
            limpiar()




        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtimporte_TextChanged(sender As Object, e As EventArgs) Handles txtimporte.TextChanged

    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub
End Class