Public Class frmComisionFlujosClientesNomina
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdClienteProveedor As String

    Private Sub frmComisionFlujosClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        MostrarPromotores1()
        MostrarPromotores2()
        MostrarPromotores3()
        MostrarPromotores4()
        'MostrarCliente()

        pnlpromotor1.Enabled = False

        pnlpromotor2.Enabled = False
        pnlpromotor3.Enabled = False
        pnlpromotor4.Enabled = False
    End Sub

    Private Sub MostrarPromotores1()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbopromotor1, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarPromotores2()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbopromotor2, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarPromotores3()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbopromotor3, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarPromotores4()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbopromotor4, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub cmdnuevo_Click(sender As Object, e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        MostrarCliente2()

        blnNuevo = True
    End Sub

    Private Sub MostrarCliente2()
        'Verificar si se tienen permisos
        Try
            SQL = "select * from clientes where (iTipo=1 or iTipo=2 or iTipo=3 or iTipo=5) and iIdCliente NOT IN (select iIdCliente from clientes inner join ComisionClienteFlujo on iIdCliente=fkiIdCliente where tipo=2) order by nombre"
            nCargaCBO(cbocliente, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        pnlProveedores.Enabled = False
        Limpiar(pnlProveedores)
        Limpiarnud()
    End Sub

    Private Sub Limpiarnud()
        nudcomision.Value = 1
        nudpromotor1.Value = 0
        nudpromotor2.Value = 0
        nudpromotor3.Value = 0
        nudpromotor4.Value = 0



        chkpromotor1.Checked = False
        chkpromotor2.Checked = False
        chkpromotor3.Checked = False
        chkpromotor4.Checked = False
        chkSumarIVA.Checked = False

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

            cbopromotor1.SelectedIndex = 0
            cbopromotor2.SelectedIndex = 0
            cbopromotor3.SelectedIndex = 0
            cbopromotor4.SelectedIndex = 0


        Next
    End Sub

    Private Sub pnlProveedores_EnabledChanged(sender As Object, e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = Not pnlProveedores.Enabled
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarComisionFlujoNomina
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

            MostrarDatos(Forma.gIdCliente)

        End If
    End Sub

    Private Sub MostrarDatos(ByVal IdProveedor As String)
        SQL = "select * from ComisionClienteFlujo where fkiIdCliente= " & IdProveedor & " and tipo=2"

        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlProveedores.Enabled = True
                Dim Fila As DataRow = rwFilas(0)

                MostrarCliente3(IdProveedor)

                gIdClienteProveedor = Fila.Item("iIdComisionClienteFlujo")
                cbocliente.SelectedValue = Fila.Item("fkiIdCliente")

                nudcomision.Value = Fila.Item("porcobrado")


                chkSumarIVA.Checked = IIf(Fila.Item("masiva") = "1", True, False)


                chkpromotor1.Checked = IIf(Fila.Item("promotor1") = "1", True, False)
                cbopromotor1.SelectedValue = Fila.Item("fkiIdPromotor1")
                nudpromotor1.Value = Fila.Item("porcentaje1")

                chkpromotor2.Checked = IIf(Fila.Item("promotor2") = "1", True, False)
                cbopromotor2.SelectedValue = Fila.Item("fkiIdPromotor2")
                nudpromotor2.Value = Fila.Item("porcentaje2")

                chkpromotor3.Checked = IIf(Fila.Item("promotor3") = "1", True, False)
                cbopromotor3.SelectedValue = Fila.Item("fkiIdPromotor3")
                nudpromotor3.Value = Fila.Item("porcentaje3")

                chkpromotor4.Checked = IIf(Fila.Item("promotor4") = "1", True, False)
                cbopromotor4.SelectedValue = Fila.Item("fkiIdPromotor4")
                nudpromotor4.Value = Fila.Item("porcentaje4")



                If Fila.Item("sobresubtotal") = 1 Then
                    rdbSubtotal.Checked = True
                Else
                    rdbTotal.Checked = True
                End If

                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarCliente3(ByVal IdCliente As String)
        'Verificar si se tienen permisos
        Try
            SQL = "select * from clientes where  iIdCliente NOT IN (select iIdCliente from clientes inner join ComisionClienteFlujo on iIdCliente=fkiIdCliente where tipo=2) "
            SQL &= " UNION"
            SQL &= " select * from clientes where iIdCliente=" & IdCliente
            SQL &= " order by nombre"

            nCargaCBO(cbocliente, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            'Validar
            'If txtnombre.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Por favor indique el nombre del cliente"
            'End If
            'If txtpaterno.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Por favor indique el nombre fiscal"
            'End If


            'If cbostatus.SelectedIndex = -1 And Mensaje = "" Then
            '    Mensaje = "Indique el estatus del promotor"
            'End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim resultado As Integer = MessageBox.Show(" Los datos con los que se guardara el registro son los siguientes cliente: " & cbocliente.Text & " ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                If blnNuevo Then
                    'Insertar nuevo
                    SQL = "EXEC setComisionClienteFlujoInsertar 0," & cbocliente.SelectedValue

                    SQL &= "," & nudcomision.Value
                    SQL &= "," & IIf(chkSumarIVA.Checked, "1", "0")
                    SQL &= "," & IIf(chkpromotor1.Checked, "1", "0")
                    SQL &= "," & cbopromotor1.SelectedValue
                    SQL &= "," & nudpromotor1.Value
                    SQL &= "," & IIf(chkpromotor2.Checked, "1", "0")
                    SQL &= "," & cbopromotor2.SelectedValue
                    SQL &= "," & nudpromotor2.Value
                    SQL &= "," & IIf(chkpromotor3.Checked, "1", "0")
                    SQL &= "," & cbopromotor3.SelectedValue
                    SQL &= "," & nudpromotor3.Value
                    SQL &= "," & IIf(chkpromotor4.Checked, "1", "0")
                    SQL &= "," & cbopromotor4.SelectedValue
                    SQL &= "," & nudpromotor4.Value

                    SQL &= "," & IIf(rdbSubtotal.Checked, "1", "2")
                    SQL &= ",2"
                    SQL &= ",1"


                Else
                    'Actualizar


                    SQL = "EXEC setComisionClienteFlujoActualizar   " & gIdClienteProveedor & "," & cbocliente.SelectedValue
                    SQL &= "," & nudcomision.Value
                    SQL &= "," & IIf(chkSumarIVA.Checked, "1", "0")
                    SQL &= "," & IIf(chkpromotor1.Checked, "1", "0")
                    SQL &= "," & cbopromotor1.SelectedValue
                    SQL &= "," & nudpromotor1.Value
                    SQL &= "," & IIf(chkpromotor2.Checked, "1", "0")
                    SQL &= "," & cbopromotor2.SelectedValue
                    SQL &= "," & nudpromotor2.Value
                    SQL &= "," & IIf(chkpromotor3.Checked, "1", "0")
                    SQL &= "," & cbopromotor3.SelectedValue
                    SQL &= "," & nudpromotor3.Value
                    SQL &= "," & IIf(chkpromotor4.Checked, "1", "0")
                    SQL &= "," & cbopromotor4.SelectedValue
                    SQL &= "," & nudpromotor4.Value

                    SQL &= "," & IIf(rdbSubtotal.Checked, "1", "2")
                    SQL &= ",2"
                    SQL &= ",1"

                End If
                If nExecute(SQL) = False Then
                    Exit Sub
                End If
                MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                pnlProveedores.Enabled = False
                Limpiar(pnlProveedores)
                Limpiarnud()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkpromotor1_CheckedChanged(sender As Object, e As EventArgs) Handles chkpromotor1.CheckedChanged
        If chkpromotor1.Checked Then
            pnlpromotor1.Enabled = True
        Else
            pnlpromotor1.Enabled = False
        End If
    End Sub

    Private Sub chkpromotor2_CheckedChanged(sender As Object, e As EventArgs) Handles chkpromotor2.CheckedChanged
        If chkpromotor2.Checked Then
            pnlpromotor2.Enabled = True
        Else
            pnlpromotor2.Enabled = False
        End If
    End Sub

    Private Sub chkpromotor3_CheckedChanged(sender As Object, e As EventArgs) Handles chkpromotor3.CheckedChanged
        If chkpromotor3.Checked Then
            pnlpromotor3.Enabled = True
        Else
            pnlpromotor3.Enabled = False
        End If
    End Sub

    Private Sub chkpromotor4_CheckedChanged(sender As Object, e As EventArgs) Handles chkpromotor4.CheckedChanged
        If chkpromotor4.Checked Then
            pnlpromotor4.Enabled = True
        Else
            pnlpromotor4.Enabled = False
        End If
    End Sub
End Class