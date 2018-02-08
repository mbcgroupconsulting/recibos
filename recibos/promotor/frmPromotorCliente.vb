Public Class frmPromotorCliente
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdClienteProveedor As String
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

            Dim resultado As Integer = MessageBox.Show(" Los datos con los que se guardara el registro son los siguientes: Promotor padre: " & cbopromotor.Text & " y cliente: " & cbocliente.Text & " ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then
                If blnNuevo Then
                    'Insertar nuevo
                    SQL = "EXEC setIntClientePromotorInsertar 0," & cbocliente.SelectedValue
                    SQL &= "," & cbopromotor.SelectedValue
                    SQL &= "," & nudrepartir.Value
                    SQL &= "," & nudpromotor.Value
                    SQL &= "," & IIf(chkOtro.Checked, "1", "0")
                    SQL &= "," & cboprootro.SelectedValue
                    SQL &= "," & nudOtropromotor.Value
                    SQL &= "," & IIf(chkSumarComision.Checked, "1", "0")
                    SQL &= "," & IIf(chkcalculos.Checked, "1", "0")
                    SQL &= "," & cboprocomision.SelectedValue
                    SQL &= "," & nudpromotorcomision.Value
                    SQL &= "," & nudpromotorinicial.Value

                    SQL &= "," & IIf(chkotropromotoriva.Checked, "1", "0")
                    SQL &= "," & cbootropromotoriva.SelectedValue
                    SQL &= "," & nudotropromotoriva.Value

                    SQL &= "," & cbocomisionprofijo.SelectedValue
                    SQL &= "," & nudcantidadcomision.Value

                    SQL &= "," & IIf(chkresto.Checked, "1", "0")
                    SQL &= "," & cbopromotorresto.SelectedValue
                    SQL &= "," & nudpromotorresto.Value

                    SQL &= ",1"


                Else
                    'Actualizar


                    SQL = "EXEC setIntClientePromotorActualizar  " & gIdClienteProveedor & "," & cbocliente.SelectedValue
                    SQL &= "," & cbopromotor.SelectedValue
                    SQL &= "," & nudrepartir.Value
                    SQL &= "," & nudpromotor.Value
                    SQL &= "," & IIf(chkOtro.Checked, "1", "0")
                    SQL &= "," & cboprootro.SelectedValue
                    SQL &= "," & nudOtropromotor.Value
                    SQL &= "," & IIf(chkSumarComision.Checked, "1", "0")
                    SQL &= "," & IIf(chkcalculos.Checked, "1", "0")
                    SQL &= "," & cboprocomision.SelectedValue
                    SQL &= "," & nudpromotorcomision.Value
                    SQL &= "," & nudpromotorinicial.Value

                    SQL &= "," & IIf(chkotropromotoriva.Checked, "1", "0")
                    SQL &= "," & cbootropromotoriva.SelectedValue
                    SQL &= "," & nudotropromotoriva.Value

                    SQL &= "," & cbocomisionprofijo.SelectedValue
                    SQL &= "," & nudcantidadcomision.Value

                    SQL &= "," & IIf(chkresto.Checked, "1", "0")
                    SQL &= "," & cbopromotorresto.SelectedValue
                    SQL &= "," & nudpromotorresto.Value

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

    Private Sub Limpiarnud()
        nudrepartir.Value = 1
        nudpromotor.Value = 0
        nudOtropromotor.Value = 0
        nudpromotorcomision.Value = 0
        nudotropromotoriva.Value = 0
        nudrepartir.Value = 0
        nudcantidadcomision.Value = 0


        nudpromotorinicial.Value = 0
        chkOtro.Checked = False
        chkSumarComision.Checked = False
        chkcalculos.Checked = False
        chkotropromotoriva.Checked = False
        chkresto.Checked = False
    End Sub

    Private Sub frmPromotorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        MostrarPromotores()
        MostrarPromotores2()
        MostrarPromotores3()
        MostrarPromotores4()
        MostrarPromotores5()
        MostrarPromotores6()
        'MostrarCliente()
        pnlcomision.Enabled = False
        pnlOtro.Enabled = False
        pnlresto.Enabled = False
        pnlotroiva.Enabled = False
        gIdClienteProveedor = ""


    End Sub
    Private Sub MostrarCliente()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre "
            nCargaCBO(cbocliente, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MostrarPromotores2()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cboprootro, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarPromotores3()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cboprocomision, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarPromotores4()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbopromotorresto, SQL, "nombrecom", "iIdPromotor")
    End Sub
    Private Sub MostrarPromotores5()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbootropromotoriva, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarPromotores6()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbocomisionprofijo, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarPromotores()
        SQL = "Select * from promotor where iEstatus=1 order by nombrecom"
        nCargaCBO(cbopromotor, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub cmdnuevo_Click(sender As Object, e As EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        MostrarCliente2()

        blnNuevo = True
    End Sub
    Private Sub MostrarCliente2()
        'Verificar si se tienen permisos
        Try
            SQL = "select * from clientes where (iTipo=1 or iTipo=2 or iTipo=3 or iTipo=5) and iIdCliente NOT IN (select iIdCliente from clientes inner join IntClientePromotor on iIdCliente=fkiIdCliente) order by nombre"
            nCargaCBO(cbocliente, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        pnlProveedores.Enabled = False
        Limpiar(pnlProveedores)
        Limpiarnud()

    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarPromotorCliente
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

            MostrarDatos(Forma.gIdCliente)

        End If
    End Sub

    Private Sub MostrarCliente3(ByVal IdCliente As String)
        'Verificar si se tienen permisos
        Try
            SQL = "select * from clientes where  iIdCliente NOT IN (select iIdCliente from clientes inner join IntClientePromotor on iIdCliente=fkiIdCliente) "
            SQL &= " UNION"
            SQL &= " select * from clientes where iIdCliente=" & IdCliente
            SQL &= " order by nombre"

            nCargaCBO(cbocliente, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MostrarDatos(ByVal IdProveedor As String)
        SQL = "select * from IntClientePromotor where fkiIdCliente= " & IdProveedor

        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlProveedores.Enabled = True
                Dim Fila As DataRow = rwFilas(0)

                MostrarCliente3(IdProveedor)

                gIdClienteProveedor = Fila.Item("iIdIntClientePromotor")


                cbocliente.SelectedValue = Fila.Item("fkiIdCliente")
                cbopromotor.SelectedValue = Fila.Item("fkiIdPromotor")
                nudrepartir.Value = Fila.Item("PorRepartir")
                nudpromotor.Value = Fila.Item("PorPromotor")

                chkOtro.Checked = IIf(Fila.Item("OtroPromotor") = "1", True, False)
                cboprootro.SelectedValue = Fila.Item("fkiIdPromotorOtro")
                nudOtropromotor.Value = Fila.Item("PorOtroPromotor")
                'Segundo promotor iva
                chkotropromotoriva.Checked = IIf(Fila.Item("OtroPromotorIva") = "1", True, False)
                cbootropromotoriva.SelectedValue = Fila.Item("fkiIdPromotorOtroIva")
                nudotropromotoriva.Value = Fila.Item("PorOtroPromotorIva")


                chkSumarComision.Checked = IIf(Fila.Item("sumarcomision") = "1", True, False)
                chkcalculos.Checked = IIf(Fila.Item("calculoscomision") = "1", True, False)
                'Promotor comision
                cboprocomision.SelectedValue = Fila.Item("fkiIdPromotorComision")
                nudpromotorcomision.Value = Fila.Item("PorPromotorComision")
                'Promotor comision fijo
                cbocomisionprofijo.SelectedValue = Fila.Item("fkiIdPromotorComisionFijo")
                nudcantidadcomision.Value = Fila.Item("CantidadPromoComisionFijo")

                'Promotor inicial comision
                nudpromotorinicial.Value = Fila.Item("PorPromotorInicialComision")

                'Resto

                chkresto.Checked = IIf(Fila.Item("RepartoRemanente") = "1", True, False)
                cbopromotorresto.SelectedValue = Fila.Item("fkiIdPromotorRemanente")
                nudpromotorresto.Value = Fila.Item("PorPromotorRemanente")


                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
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

            cbopromotor.SelectedIndex = 0
            cboprootro.SelectedIndex = 0
            cboprocomision.SelectedIndex = 0
            cbootropromotoriva.SelectedIndex = 0
            cbopromotorresto.SelectedValue = 0
            cbocomisionprofijo.SelectedIndex = 0



        Next
    End Sub

    Private Sub pnlProveedores_EnabledChanged(sender As Object, e As EventArgs) Handles pnlProveedores.EnabledChanged
        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = Not pnlProveedores.Enabled
    End Sub

    Private Sub chkOtro_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtro.CheckedChanged
        If chkOtro.Checked Then
            pnlOtro.Enabled = True
        Else
            pnlOtro.Enabled = False
        End If
    End Sub

    Private Sub chkcalculos_CheckedChanged(sender As Object, e As EventArgs) Handles chkcalculos.CheckedChanged
        If chkcalculos.Checked Then
            pnlcomision.Enabled = True
        Else
            pnlcomision.Enabled = False
        End If
    End Sub

    Private Sub chkSumarComision_CheckedChanged(sender As Object, e As EventArgs) Handles chkSumarComision.CheckedChanged
        If chkSumarComision.Checked Then
            chkcalculos.Checked = False
            chkcalculos.Enabled = False

        Else
            chkcalculos.Enabled = True
        End If
    End Sub

    Private Sub chkresto_CheckedChanged(sender As Object, e As EventArgs) Handles chkresto.CheckedChanged
        If chkresto.Checked Then
            pnlresto.Enabled = True
        Else
            pnlresto.Enabled = False
        End If
    End Sub

    Private Sub chkotropromotoriva_CheckedChanged(sender As Object, e As EventArgs) Handles chkotropromotoriva.CheckedChanged
        If chkotropromotoriva.Checked Then
            pnlotroiva.Enabled = True
        Else
            pnlotroiva.Enabled = False
        End If
    End Sub

    Private Sub nudOtropromotor_ValueChanged(sender As Object, e As EventArgs) Handles nudOtropromotor.ValueChanged

    End Sub

    Private Sub cmdgastos_Click(sender As Object, e As EventArgs) Handles cmdgastos.Click
        Dim Forma As New frmGastosFijosComision

        Try
            Forma.gIdCliente = cbocliente.SelectedValue

            Forma.ShowDialog()




        Catch ex As Exception

        End Try
    End Sub
End Class