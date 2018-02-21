Imports System.Text.RegularExpressions
Imports ClosedXML.Excel

Public Class frmClientes
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdProveedor As String

    Private Sub Label14_Click(sender As System.Object, e As System.EventArgs) Handles Label14.Click

    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub tsbCancelar_Click(sender As System.Object, e As System.EventArgs)


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
            cbotipop.SelectedIndex = 0
            cbopromotor.SelectedIndex = 0
            cbopromotor2.SelectedIndex = 0
            cbopromotor3.SelectedIndex = 0
        Next
    End Sub

    Private Sub pnlProveedores_EnabledChanged(sender As Object, e As System.EventArgs) Handles pnlProveedores.EnabledChanged


        cmdnuevo.Enabled = Not pnlProveedores.Enabled
        cmdguardar.Enabled = pnlProveedores.Enabled
        cmdcancelar.Enabled = pnlProveedores.Enabled
        cmdbuscar.Enabled = Not pnlProveedores.Enabled
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs)



    End Sub

    Private Sub frmProveedores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MostrarEstados()
        MostrarPlazas()
        MostrarPromotores()
        MostrarPromotores2()
        MostrarPromotores3()

        MostrarSindicatos()

        cbotipop.SelectedIndex = 0
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
    End Sub

    Private Sub MostrarPlazas()
        SQL = "Select * from CatPlaza"
        nCargaCBO(cboplaza, SQL, "nombre", "iIdPlaza")
    End Sub
    Private Sub MostrarPromotores3()
        SQL = "Select * from promotor order by iIdPromotor"
        nCargaCBO(cbopromotor3, SQL, "nombrecom", "iIdPromotor")
    End Sub
    Private Sub MostrarPromotores2()
        SQL = "Select * from promotor order by iIdPromotor"
        nCargaCBO(cbopromotor2, SQL, "nombrecom", "iIdPromotor")
    End Sub
    Private Sub MostrarPromotores()
        SQL = "Select * from promotor order by iIdPromotor"
        nCargaCBO(cbopromotor, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub MostrarEstados()
        SQL = "Select * from Cat_Estados order by iIdEstado"
        nCargaCBO(cboestados, SQL, "cEstado", "iIdEstado")
    End Sub
    Private Sub MostrarSindicatos()
        SQL = "Select * from Cat_SindicatosAlta order by cNombre"
        nCargaCBO(cboSindicato, SQL, "cNombre", "iIdSindicato")
    End Sub

    Private Sub txtcp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcp.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcp_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcp.TextChanged

    End Sub

    Private Sub txtnumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress

    End Sub

    Private Sub txtnumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnumero.TextChanged

    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txttelefono2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub tsbBuscar_Click(sender As System.Object, e As System.EventArgs)


    End Sub
    Private Sub Mostrar_DatosProveedor(ByVal IdProveedor As String)
        SQL = "select * from clientes where iIdCliente = " & IdProveedor
        Dim aID As String()
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlProveedores.Enabled = True
                Dim Fila As DataRow = rwFilas(0)
                txtnombre.Text = Fila.Item("nombre")
                txtnombre2.Text = Fila.Item("nombrefiscal")
                txtrfc.Text = Fila.Item("RFC")
                txtcalle.Text = Fila.Item("calle")
                txtnumero.Text = Fila.Item("numero")
                txtint.Text = Fila.Item("numeroint")
                txtcolonia.Text = Fila.Item("colonia")
                txtlocalidad.Text = Fila.Item("localidad")
                txtmunicipio.Text = Fila.Item("municipio")
                txtcp.Text = Fila.Item("cp")
                cboestados.SelectedValue = Fila.Item("idestado")
                txttelefono.Text = Fila.Item("Telefono1")
                txttelefono2.Text = Fila.Item("Telefono2")
                txtcontacto.Text = Fila.Item("Contacto")
                txtemail.Text = Fila.Item("email")
                cbotipop.SelectedIndex = IIf(Fila.Item("iTipoPor") = 1, 0, 1)
                nupordinario.Value = Fila.Item("porcentaje")
                nupsindicato.Value = Fila.Item("porsindicato")
                nupflujo.Value = Fila.Item("porflujo")
                cbostatus.SelectedIndex = IIf(Fila.Item("iEstatus") = 1, 0, 1)
                txtactividad.Text = Fila.Item("actividad")
                cbotipocliente.SelectedIndex = Fila.Item("iTipocliente")
                cboplaza.SelectedValue = Fila.Item("iTipo")
                aID = Fila.Item("fkiIdPromotor").Split(",")
                cbopromotor.SelectedValue = IIf(aID(0) = "", 0, aID(0))
                cbopromotor2.SelectedValue = IIf(aID(1) = "", 0, aID(1))
                cbopromotor3.SelectedValue = IIf(aID(2) = "", 0, aID(2))

                cboSindicato.SelectedIndex = IIf(cboSindicato.SelectedIndex = "", 0, cboSindicato.SelectedIndex)




                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pnlProveedores_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlProveedores.Paint

    End Sub

    Private Sub cmdnuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdnuevo.Click
        pnlProveedores.Enabled = True
        blnNuevo = True
        cbostatus.Focus()
    End Sub

    Private Sub cmdguardar_Click(sender As System.Object, e As System.EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = ""
        Try
            'Validar
            If txtnombre.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el nombre del cliente"
            End If
            If txtnombre2.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el nombre fiscal"
            End If
            If txtrfc.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el rfc"
            End If
            If txtcalle.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique la calle"
            End If
            If txtnumero.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el número de la dirección del cliente"
            End If
            If txtcolonia.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique la colonia"
            End If
            If txtmunicipio.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el municipio"
            End If
            If txtcp.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el codigo postal"
            End If
            If cboestados.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Seleccione el estado al que pertenece"
            End If
            'If txttelefono.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Indique el telefono"
            'End If
            If txtcontacto.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el contacto de la empresa"
            End If
            If txtemail.Text.Trim.Length > 0 And Mensaje = "" Then
                If Not Regex.IsMatch(txtemail.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") Then
                    Mensaje = "El email no tiene una forma correcta de correo electrónico (usuario@dominio.com)."
                    Me.txtemail.Focus()
                End If
            End If
            
            If cbostatus.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el estatus del proveedor"
            End If
            If cbotipocliente.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el tipo de cliente"
            End If
            If cbotipop.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el tipo de porcentaje"
            End If
            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setclientesInsertar 0,'" & txtnombre.Text & "','" & txtnombre2.Text
                SQL &= "','" & txtrfc.Text
                SQL &= "','" & txtcalle.Text & "','" & txtnumero.Text
                SQL &= "','" & txtint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text
                SQL &= "','" & txtlocalidad.Text
                SQL &= "','" & txtmunicipio.Text & "','" & cboestados.SelectedValue & "','" & txttelefono.Text
                SQL &= "','" & txttelefono2.Text & "','" & txtcontacto.Text & "','" & txtemail.Text
                SQL &= "',''," & IIf(cbotipop.SelectedIndex = 0, 1, 0) & "," & nupordinario.Value & "," & nupsindicato.Value
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0) & "," & cboplaza.SelectedValue & "," & nupflujo.Value
                SQL &= ",'" & txtactividad.Text & "'," & cbotipocliente.SelectedIndex & ",'" & cbopromotor.SelectedValue & "," & cbopromotor2.SelectedValue & "," & cbopromotor3.SelectedValue & "," & cboSindicato.SelectedIndex & "'"
            Else
                'Actualizar

                SQL = "EXEC setclientesActualizar " & gIdProveedor & ",'" & txtnombre.Text & "','" & txtnombre2.Text
                SQL &= "','" & txtrfc.Text
                SQL &= "','" & txtcalle.Text & "','" & txtnumero.Text
                SQL &= "','" & txtint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text
                SQL &= "','" & txtlocalidad.Text
                SQL &= "','" & txtmunicipio.Text & "','" & cboestados.SelectedValue & "','" & txttelefono.Text
                SQL &= "','" & txttelefono2.Text & "','" & txtcontacto.Text & "','" & txtemail.Text
                SQL &= "',''," & IIf(cbotipop.SelectedIndex = 0, 1, 0) & "," & nupordinario.Value & "," & nupsindicato.Value
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0) & "," & cboplaza.SelectedValue & "," & nupflujo.Value
                SQL &= ",'" & txtactividad.Text & "'," & cbotipocliente.SelectedIndex & ",'" & cbopromotor.SelectedValue & "," & cbopromotor2.SelectedValue & "," & cbopromotor3.SelectedValue & "," & cboSindicato.SelectedIndex & "'"




            End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If
            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlProveedores.Enabled = False
            Limpiar(pnlProveedores)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancelar.Click
        pnlProveedores.Enabled = False
        Limpiar(pnlProveedores)
    End Sub

    Private Sub cmdbuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarCliente
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            gIdProveedor = Forma.gIdProveedor
            Mostrar_DatosProveedor(Forma.gIdProveedor)

        End If
    End Sub

    Private Sub cmdsalir_Click(sender As System.Object, e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub Label15_Click(sender As System.Object, e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub cbotipop_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbotipop.SelectedIndexChanged
        If cbotipop.SelectedIndex = 0 Then
            nupsindicato.Enabled = False
        Else
            nupsindicato.Enabled = True
        End If
    End Sub

    Private Sub Label12_Click(sender As System.Object, e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub cmdlista_Click(sender As Object, e As EventArgs) Handles cmdlista.Click
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim idtipo As Integer

        SQL = "select * from clientes inner join cat_estados "
        SQL &= " on clientes.idEstado = cat_estados.iIdEstado"
        SQL &= " where iEstatus = 1"
        SQL &= " order by nombre,nombrefiscal "
        Dim rwFilas As DataRow() = nConsulta(SQL)
        If rwFilas Is Nothing = False Then
            Dim libro As New ClosedXML.Excel.XLWorkbook
            Dim hoja As IXLWorksheet = libro.Worksheets.Add("Control")
            hoja.Column("A").Width = 30
            hoja.Column("B").Width = 50
            hoja.Column("C").Width = 50
            hoja.Column("D").Width = 15
            hoja.Column("E").Width = 15
            hoja.Column("F").Width = 5
            hoja.Column("G").Width = 10
            hoja.Column("H").Width = 15
            hoja.Column("I").Width = 5
            hoja.Column("J").Width = 20
            hoja.Column("K").Width = 20
            hoja.Column("L").Width = 15

            hoja.Cell(2, 2).Value = "Fecha: " & Date.Now.ToShortDateString()

            hoja.Cell(3, 2).Value = "LISTA DE CLIENTES ACTIVOS"
            'hoja.Cell(3, 2).Value = ":"
            'hoja.Cell(3, 3).Value = ""

            hoja.Range(4, 1, 4, 12).Style.Font.FontSize = 10
            hoja.Range(4, 1, 4, 12).Style.Font.SetBold(True)
            hoja.Range(4, 1, 4, 12).Style.Alignment.WrapText = True
            hoja.Range(4, 1, 4, 12).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja.Range(4, 1, 4, 12).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja.Range(4, 1, 4, 12).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja.Range(4, 1, 4, 12).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            'hoja.Cell(4, 1).Value = "Num"
            hoja.Cell(4, 1).Value = "Id"
            hoja.Cell(4, 2).Value = "Nombre"
            hoja.Cell(4, 3).Value = "Nombre Fiscal"
            hoja.Cell(4, 4).Value = "RFC"
            hoja.Cell(4, 5).Value = "Calle"
            hoja.Cell(4, 6).Value = "Número"
            hoja.Cell(4, 7).Value = "Número int"
            hoja.Cell(4, 8).Value = "Colonia"
            hoja.Cell(4, 9).Value = "CP"
            hoja.Cell(4, 10).Value = "Localidad"
            hoja.Cell(4, 11).Value = "Municipio"
            hoja.Cell(4, 12).Value = "Estado"



            filaExcel = 4
            For Each Fila In rwFilas
                filaExcel = filaExcel + 1
                hoja.Cell(filaExcel, 1).Value = Fila.Item("iIdCliente")
                hoja.Cell(filaExcel, 2).Value = Fila.Item("nombre")
                hoja.Cell(filaExcel, 3).Value = Fila.Item("nombrefiscal")
                hoja.Cell(filaExcel, 4).Value = Fila.Item("RFC")
                hoja.Cell(filaExcel, 5).Value = Fila.Item("calle")
                hoja.Cell(filaExcel, 6).Value = Fila.Item("numero")
                hoja.Cell(filaExcel, 7).Value = Fila.Item("numeroint")
                hoja.Cell(filaExcel, 8).Value = Fila.Item("colonia")
                hoja.Cell(filaExcel, 9).Value = Fila.Item("cp")
                hoja.Cell(filaExcel, 10).Value = Fila.Item("localidad")
                hoja.Cell(filaExcel, 11).Value = Fila.Item("municipio")
                hoja.Cell(filaExcel, 12).Value = Fila.Item("cEstado")



            Next

            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Lista de clientes"
            dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            dialogo.ShowDialog()
            libro.SaveAs(dialogo.FileName)
            'libro.SaveAs("c:\temp\control.xlsx")
            'libro.SaveAs(dialogo.FileName)
            'apExcel.Quit()
            libro = Nothing
        Else
            MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub cmdusuario_Click(sender As Object, e As EventArgs) Handles cmdusuario.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmUsuarioCliente
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "10") Then
                    If blnNuevo = False And gIdProveedor IsNot Nothing Then
                        Forma.gIdCliente = gIdProveedor
                        Forma.ShowDialog()

                    Else

                        MessageBox.Show("Se debe tener un cliente seleccionado para entrar a esta opción", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class