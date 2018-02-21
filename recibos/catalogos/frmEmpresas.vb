Imports System.Text.RegularExpressions
Imports ClosedXML.Excel

Public Class frmEmpresas

    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim gIdEmpresa As String

    Private Sub cmdsalir_Click(sender As System.Object, e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdbuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdbuscar.Click
        Dim Forma As New frmBuscarEmpresa
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            gIdEmpresa = Forma.gIdEmpresa
            Mostrar_DatosProveedor(Forma.gIdEmpresa)

        End If
    End Sub

    Private Sub Mostrar_DatosProveedor(ByVal IdProveedor As String)
        SQL = "select * from empresa where iIdEmpresa = " & IdProveedor
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                pnlEmpresa.Enabled = True
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
                cbotipoempresa.SelectedValue = Fila.Item("fkiIdTipoEmpresa")
                txtpatronal.Text = Fila.Item("registropatronal")
                cbostatus.SelectedIndex = IIf(Fila.Item("iEstatus") = 1, 0, 1)
                cbomatriz.SelectedIndex = IIf(Fila.Item("iTipo") = 1, 0, 1)
                cbonivel.SelectedText = Fila.Item("Clasificacion")
                txtfraccion.Text = Fila.Item("fraccion")
                txtfactor.Text = Fila.Item("factor")

                txtRepresentanteP.Text = Fila.Item("cRepresentanteP")
                txtObjetoSocialP.Text = Fila.Item("cObjetoSocialP")
                blnNuevo = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancelar.Click
        pnlEmpresa.Enabled = False
        Limpiar(pnlEmpresa)
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
            If txttelefono.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Indique el telefono"
            End If
            'If txtcontacto.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Indique el contacto de la empresa"
            'End If

            'If txtpatronal.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Indique el registro patronal"
            'End If

            If txtemail.Text.Trim.Length > 0 And Mensaje = "" Then
                If Not Regex.IsMatch(txtemail.Text, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") Then
                    Mensaje = "El email no tiene una forma correcta de correo electrónico (usuario@dominio.com)."
                    Me.txtemail.Focus()
                End If
            End If

            If cbostatus.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el estatus del proveedor"
            End If

            If cbotipoempresa.SelectedIndex = -1 And Mensaje = "" Then
                Mensaje = "Indique el tipo de empresa"
            End If
            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setempresaInsertar 0,'" & txtnombre.Text & "','" & txtnombre2.Text
                SQL &= "','" & txtrfc.Text
                SQL &= "','" & txtcalle.Text & "','" & txtnumero.Text
                SQL &= "','" & txtint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text
                SQL &= "','" & txtlocalidad.Text
                SQL &= "','" & txtmunicipio.Text & "','" & cboestados.SelectedValue & "','" & txttelefono.Text
                SQL &= "','" & txttelefono2.Text & "','" & txtcontacto.Text & "','" & txtemail.Text
                SQL &= "','" & txtpatronal.Text & "'," & cbotipoempresa.SelectedValue
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0) & "," & IIf(cbomatriz.SelectedIndex = 0, 1, 0)
                SQL &= ",'" & cbonivel.Text & "','" & txtfraccion.Text & "','" & txtfactor.Text & "','" & txtRepresentanteP.Text & "','" & txtObjetoSocialP.Text & "'"
            Else
                'Actualizar

                SQL = "EXEC setempresaActualizar " & gIdEmpresa & ",'" & txtnombre.Text & "','" & txtnombre2.Text
                SQL &= "','" & txtrfc.Text
                SQL &= "','" & txtcalle.Text & "','" & txtnumero.Text
                SQL &= "','" & txtint.Text & "','" & txtcolonia.Text & "','" & txtcp.Text
                SQL &= "','" & txtlocalidad.Text
                SQL &= "','" & txtmunicipio.Text & "','" & cboestados.SelectedValue & "','" & txttelefono.Text
                SQL &= "','" & txttelefono2.Text & "','" & txtcontacto.Text & "','" & txtemail.Text
                SQL &= "','" & txtpatronal.Text & "'," & cbotipoempresa.SelectedValue
                SQL &= "," & IIf(cbostatus.SelectedIndex = 0, 1, 0) & "," & IIf(cbomatriz.SelectedIndex = 0, 1, 0)
                SQL &= ",'" & cbonivel.Text & "','" & txtfraccion.Text & "','" & txtfactor.Text & "','" & txtRepresentanteP.Text & "','" & txtObjetoSocialP.text & "'"


            End If
            If nExecute(SQL) = False Then
                Exit Sub
            End If
            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            pnlEmpresa.Enabled = False
            Limpiar(pnlEmpresa)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdnuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdnuevo.Click
        pnlEmpresa.Enabled = True
        blnNuevo = True
        cbostatus.Focus()
    End Sub

    Private Sub frmEmpresas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        MostrarTiposEmpresa()
        MostrarEstados()

        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
    End Sub

    Private Sub MostrarTiposEmpresa()
        SQL = "Select * from tipo_empresa order by iIdTipoEmpresa"
        nCargaCBO(cbotipoempresa, SQL, "NOmbre", "iIdTipoEmpresa")
    End Sub
    Private Sub MostrarEstados()
        SQL = "Select * from Cat_Estados order by iIdEstado"
        nCargaCBO(cboestados, SQL, "cEstado", "iIdEstado")
    End Sub
   

    Private Sub txtnumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        'SoloNumero.NumeroDec(e, sender)
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

        Next
    End Sub
    Private Sub pnlEmpresa_EnabledChanged(sender As Object, e As System.EventArgs) Handles pnlEmpresa.EnabledChanged
        cmdnuevo.Enabled = Not pnlEmpresa.Enabled
        cmdguardar.Enabled = pnlEmpresa.Enabled
        cmdcancelar.Enabled = pnlEmpresa.Enabled
        cmdsucursal.Enabled = IIf(blnNuevo <> True And (cmdnuevo.Enabled <> True), True, False)
        cmdbuscar.Enabled = Not pnlEmpresa.Enabled
    End Sub

    Private Sub txttelefono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txttelefono2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcp_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcp.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    

    

   
    Private Sub cmdsucursal_Click(sender As System.Object, e As System.EventArgs) Handles cmdsucursal.Click
        Dim Forma As New frmSucursal
        Forma.gIdEmpresa = gIdEmpresa
        Forma.nombre = txtnombre.Text
        Forma.ShowDialog()

    End Sub

    Private Sub txtnumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnumero.TextChanged

    End Sub

    Private Sub cmdlista_Click(sender As Object, e As EventArgs) Handles cmdlista.Click
        Dim filaExcel As Integer = 5
        Dim dialogo As New SaveFileDialog()
        Dim idtipo As Integer

        SQL = "select iIdEmpresa,empresa.nombre as nombre,nombrefiscal,RFC,calle,numero,numeroint,colonia,"
        SQL &= "cp,localidad,municipio,cestado,tipo_empresa.nombre as tipoempresa,itipo from (empresa inner join cat_estados "
        SQL &= " on empresa.idEstado = cat_estados.iIdEstado)"
        SQL &= " inner join tipo_empresa on fkiIdTipoEmpresa=iIdTipoEmpresa"
        SQL &= " where empresa.iEstatus = 1"
        SQL &= " order by empresa.nombre,nombrefiscal "
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

            hoja.Cell(3, 2).Value = "LISTA DE EMPRESAS ACTIVAS"
            'hoja.Cell(3, 2).Value = ":"
            'hoja.Cell(3, 3).Value = ""

            hoja.Range(4, 1, 4, 14).Style.Font.FontSize = 10
            hoja.Range(4, 1, 4, 14).Style.Font.SetBold(True)
            hoja.Range(4, 1, 4, 14).Style.Alignment.WrapText = True
            hoja.Range(4, 1, 4, 14).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            hoja.Range(4, 1, 4, 14).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
            'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
            hoja.Range(4, 1, 4, 14).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
            hoja.Range(4, 1, 4, 14).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

            'hoja.Cell(4, 1).Value = "Num"
            hoja.Cell(4, 1).Value = "Identificador"
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
            hoja.Cell(4, 13).Value = "Tipo"
            hoja.Cell(4, 14).Value = "Matriz/Sucursal"



            filaExcel = 4
            For Each Fila In rwFilas
                filaExcel = filaExcel + 1
                hoja.Cell(filaExcel, 1).Value = Fila.Item("iIdEmpresa")
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
                hoja.Cell(filaExcel, 13).Value = Fila.Item("tipoempresa")
                hoja.Cell(filaExcel, 14).Value = IIf(Fila.Item("iTipo") = 1, "Matriz", "Sucursal")


            Next

            dialogo.DefaultExt = "*.xlsx"
            dialogo.FileName = "Lista de empresas"
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
End Class