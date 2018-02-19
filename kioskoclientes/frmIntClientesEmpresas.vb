Public Class frmIntClientesEmpresas
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdClienteEmpresa As String

    Private Sub frmIntClientesEmpresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        MostrarEmpresa()

    End Sub
    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdnuevo_Click(sender As Object, e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        MostrarCliente2()

        blnNuevo = True
    End Sub

    Private Sub MostrarCliente2()
        'Verificar si se tienen permisos
        Try
            SQL = "select * from clientes where (iTipo=1 or iTipo=2 or iTipo=3 or iTipo=5) and iIdCliente NOT IN (select iIdCliente from clientes inner join IntClienteEmpresaKiosko on iIdCliente=fkiIdCliente) order by nombre"
            nCargaCBO(cbocliente, Sql, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pnlProveedores_EnabledChanged(sender As Object, e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = Not pnlProveedores.Enabled
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Try
            If lsvLista.Items.Count <= 0 Then
                MessageBox.Show("La lista no tiene ninguna empresa agregada, agrega una para poder guardar al cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                Dim resultado As Integer = MessageBox.Show("¿Desea guardar la información para el cliente: " & cbocliente.Text & "?", "Pregunta", MessageBoxButtons.YesNo)


                If resultado = DialogResult.Yes Then

                    If blnNuevo Then
                        For Each renglon As ListViewItem In lsvLista.Items
                            SQL = "EXEC setIntClienteEmpresaKioskoInsertar 0"
                            SQL &= "," & renglon.Tag
                            SQL &= "," & cbocliente.SelectedValue


                            If nExecute(SQL) = False Then
                                MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                        Next

                    Else

                        SQL = "delete from IntClienteEmpresaKiosko where fkiIdCliente =" & cbocliente.SelectedValue
                        If nExecute(SQL) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        For Each renglon As ListViewItem In lsvLista.Items
                            SQL = "EXEC setIntClienteEmpresaKioskoInsertar 0"
                            SQL &= "," & renglon.Tag
                            SQL &= "," & cbocliente.SelectedValue


                            If nExecute(SQL) = False Then
                                MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                        Next


                    End If
                    'mensaje

                    MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    pnlProveedores.Enabled = False
                    Limpiar(pnlProveedores)

                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        pnlProveedores.Enabled = False
        Limpiar(pnlProveedores)
        'Limpiarnud()
    End Sub

    Private Sub Limpiar(ByVal Contenedor As Object)
        For Each oControl In Contenedor.Controls
            If TypeOf oControl Is TabControl Or TypeOf oControl Is GroupBox Or TypeOf oControl Is Panel Then
                Limpiar(oControl)
            ElseIf TypeOf oControl Is TextBox Then
                Dim txtControl As TextBox = oControl
                txtControl.Text = ""
                txtControl.Tag = ""
            ElseIf TypeOf oControl Is ComboBox Then
                Dim cboControl As ComboBox = oControl
                cboControl.SelectedIndex = -1
                cboControl.Text = ""
            ElseIf TypeOf oControl Is ListView Then
                Dim Lista As ListView = oControl
                Lista.Items.Clear()
            ElseIf TypeOf oControl Is DateTimePicker Then
                Dim dtpControl As DateTimePicker = oControl
                dtpControl.Value = Date.Now

            End If

            cboempresa.SelectedIndex = 0




        Next
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarClienteEmpresaK

        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

            MostrarDatos(Forma.gIdCliente)

        End If
    End Sub

    Private Sub MostrarDatos(ByVal IdProveedor As String)
        SQL = "select * from IntClienteEmpresaKiosko where fkiIdCliente= " & IdProveedor
        Dim Alter As Boolean = False
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlProveedores.Enabled = True
                'Dim Fila As DataRow = rwFilas(0)
                MostrarCliente3(IdProveedor)

                cbocliente.SelectedValue = IdProveedor

                lsvLista.Items.Clear()


                For x As Integer = 0 To rwFilas.Count - 1
                    'Buscar los datos de la empresa
                    SQL = "select * from empresa where iIdEmpresa=" & rwFilas(x)("fkiIdEmpresa")

                    Dim rwEmpresa As DataRow() = nConsulta(SQL)

                    If rwEmpresa Is Nothing = False Then
                        Dim item As ListViewItem
                        item = lsvLista.Items.Add("(" & rwEmpresa(0)("iIdEmpresa") & ")" & rwEmpresa(0)("nombre"))
                        item.Tag = rwEmpresa(0)("iIdEmpresa")

                        item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                        Alter = Not Alter

                    End If


                Next


                gIdClienteEmpresa = IdProveedor

                'cbopromotor.SelectedValue = Fila.Item("fkiIdPromotor")
                'nudrepartir.Value = Fila.Item("PorRepartir")
                'nudpromotor.Value = Fila.Item("PorPromotor")

                'chkOtro.Checked = IIf(Fila.Item("OtroPromotor") = "1", True, False)
                'cboprootro.SelectedValue = Fila.Item("fkiIdPromotorOtro")
                'nudOtropromotor.Value = Fila.Item("PorOtroPromotor")

                'chkSumarComision.Checked = IIf(Fila.Item("sumarcomision") = "1", True, False)
                'chkcalculos.Checked = IIf(Fila.Item("calculoscomision") = "1", True, False)

                'cboprocomision.SelectedValue = Fila.Item("fkiIdPromotorComision")
                'nudpromotorcomision.Value = Fila.Item("PorPromotorComision")
                'nudpromotorinicial.Value = Fila.Item("PorPromotorInicialComision")



                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub MostrarCliente3(ByVal IdCliente As String)
        'Verificar si se tienen permisos
        Try
            SQL = "select * from clientes where  iIdCliente NOT IN (select iIdCliente from clientes inner join IntClienteEmpresaKiosko on iIdCliente=fkiIdCliente) "
            SQL &= " UNION"
            SQL &= " select * from clientes where iIdCliente=" & IdCliente
            SQL &= " order by nombre"

            nCargaCBO(cbocliente, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdagregar_Click(sender As Object, e As EventArgs) Handles cmdagregar.Click
        Dim item As ListViewItem
        Dim Alter As Boolean = False
        Dim validacion As Boolean
        Try
            validacion = True

            'recorremos la lista

            For Each renglon As ListViewItem In lsvLista.Items
                If renglon.Tag = cboempresa.SelectedValue Then
                    validacion = False

                End If
            Next

            If validacion Then
                item = lsvLista.Items.Add("(" & cboempresa.SelectedValue & ")" & cboempresa.Text)
                item.Tag = cboempresa.SelectedValue

                item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter
            Else
                'Ya esta agregada la empresa
                MessageBox.Show("La empresa ya esta agregada, elige otra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdborrarfactura_Click(sender As Object, e As EventArgs) Handles cmdborrarfactura.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
        If datos.Count = 1 Then
            Dim resultado As Integer = MessageBox.Show("¿Desea borrar la empresa " & datos(0).SubItems(0).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


            If resultado = DialogResult.Yes Then

                datos(0).Remove()
                MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If
        Else
            MessageBox.Show("No hay una empresa seleccionada para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class