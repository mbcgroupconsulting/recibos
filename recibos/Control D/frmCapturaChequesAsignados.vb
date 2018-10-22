Public Class frmCapturaChequesAsignados
    Dim SQL As String
    Dim blnFechainicio As Boolean
    Dim blnNuevo As Boolean
    Dim blnlista As Boolean
    Public UsuarioCreador As String
    Public gIdCheque As String
    'Dim blnNuevo As Boolean

   
    Private Sub frmCapturaChequesAsignados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            blnNuevo = True
            blnlista = True
            blnFechainicio = True
            dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
            MostrarEmpresa()
            MostrarBancos()
            Limpiar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            blnlista = False
            SQL = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
            blnlista = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarBancos()
        Sql = "Select * from bancos order by cBanco"
        nCargaCBO(cbobanco, Sql, "cBanco", "iIdBanco")
        'cbobanco.SelectedIndex = 0
    End Sub

    Private Sub dtpfechainicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpfechainicio.ValueChanged
        If blnFechainicio Then
            blnFechainicio = False
        Else
            If cboempresa.SelectedIndex > -1 Then
                cargarlista()
            End If


        End If
    End Sub

    Private Sub cargarlista()
        Dim contador As Integer
        Dim SQL As String, Alter As Boolean = False

        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        If (tiempo.Days >= 0) Then
            SQL = "Select iIdGastoCheques, fkiIdEmpresa,empresa.nombre As nombreempresa  ,fkiIdBanco, bancos.cBanco, "
            SQL &= "FechaMov, FacturaCheques, persona,Monto,UsuarioC,UsuarioM "
            SQL &= " from ((GastosCheques "
            SQL &= "inner Join empresa on GastosCheques.fkiIdEmpresa= empresa.iIdEmpresa) "
            SQL &= "inner Join bancos On GastosCheques.fkiIdBanco =  bancos.iIdBanco) "
            SQL &= " where fkiIdEmpresa =" & cboempresa.SelectedValue & " And GastosCheques.iEstatus=1 "
            SQL &= " and FechaMov between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
            SQL &= " order by iIdGastoCheques desc "

            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem


            lsvLista.Items.Clear()
            lsvLista.Clear()
            lsvLista.Columns.Add("Fecha")
            lsvLista.Columns(0).Width = 100
            lsvLista.Columns.Add("Empresa")
            lsvLista.Columns(1).Width = 350
            lsvLista.Columns.Add("Banco")
            lsvLista.Columns(2).Width = 350
            lsvLista.Columns.Add("Num cheques")
            lsvLista.Columns(3).Width = 350
            lsvLista.Columns.Add("Monto")
            lsvLista.Columns(4).Width = 100
            lsvLista.Columns(4).TextAlign = HorizontalAlignment.Right
            lsvLista.Columns.Add("Persona Asignada")
            lsvLista.Columns(5).Width = 350
            lsvLista.Columns.Add("Capturo")
            lsvLista.Columns(6).Width = 350
            lsvLista.Columns.Add("Modifico")
            lsvLista.Columns(7).Width = 350

            contador = 0

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    contador = contador + 1

                    'item = lsvLista.Items.Add("")
                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)

                    
                    item = lsvLista.Items.Add(Fila.Item("FechaMov"))
                    item.SubItems.Add("" & Fila.Item("nombreempresa"))
                    item.SubItems.Add("" & Fila.Item("cBanco"))
                    item.SubItems.Add("" & Fila.Item("FacturaCheques"))
                    item.SubItems.Add("" & Fila.Item("Monto"))
                    item.SubItems.Add("" & Fila.Item("persona"))
                    item.SubItems.Add("" & Fila.Item("UsuarioC"))
                    item.SubItems.Add("" & Fila.Item("UsuarioM"))

                    item.Tag = Fila.Item("iIdGastoCheques")
                    Alter = Not Alter

                Next
            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If lsvLista.Items.Count > 0 Then
                'lsvLista.Focus()
                'lsvLista.Items(0).Selected = True
                MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'txtbuscar.Focus()
                'txtbuscar.SelectAll()
            End If

        Else
            MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




    End Sub

    Private Sub cboempresa_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboempresa.SelectedIndexChanged
        If blnNuevo And blnlista And cboempresa.SelectedIndex > -1 Then
            cargarlista()
        End If
    End Sub

    Private Sub cmdagregar_Click(sender As System.Object, e As System.EventArgs) Handles cmdagregar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim bandera As Boolean
        Dim tipoflujo As Integer
        Dim IdFactura1 As String
        IdFactura1 = ""

        Try

            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombresistema = Fila.Item("nombre")
            End If

            'Validar


            If txtpersona.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el nombre de la persona"
            End If
            If txtcheques.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor el numero de cheques"
            End If

            If cboempresa.SelectedIndex = -1 Then
                Mensaje = "Por favor seleccione una empresa"
            End If

            If cbobanco.SelectedIndex = -1 Then
                Mensaje = "Por favor seleccione un banco"
            End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            bandera = True

            



            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setGastosChequesInsertar 0," & cboempresa.SelectedValue & "," & cbobanco.SelectedValue
                SQL &= ",'" & IIf(txtcheques.Text = "", 0, txtcheques.Text)
                SQL &= "','" & IIf(txtpersona.Text = "", 0, txtpersona.Text)
                SQL &= "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "','" & Date.Now.ToShortDateString() & "'"
                SQL &= ",'" & nombresistema & "','" & nombresistema
                SQL &= "',1," & IIf(txtMonto.Text = "", "0.00", txtMonto.Text)


                If Execute(SQL, IdFactura1) = False Then
                    'MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(4).Text) & " Cliente:" & Trim(producto.SubItems(6).Text) & " Intermediaria/pagadora:" & Trim(producto.SubItems(9).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If



            Else
                'Actualizar
                SQL = "EXEC setGastosChequesActualizar " & gIdCheque & "," & cboempresa.SelectedValue & "," & cbobanco.SelectedValue
                SQL &= ",'" & IIf(txtcheques.Text = "", 0, txtcheques.Text)
                SQL &= "','" & IIf(txtpersona.Text = "", 0, txtpersona.Text)
                SQL &= "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "','" & Date.Now.ToShortDateString() & "'"
                SQL &= ",'" & UsuarioCreador & "','" & nombresistema
                SQL &= "',1," & IIf(txtMonto.Text = "", "0.00", txtMonto.Text)
                


                If nExecute(SQL) = False Then
                    Exit Sub
                End If


            End If


            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            limpiar2()
            blnNuevo = True
            If cboempresa.SelectedIndex > -1 Then
                cargarlista()
            End If
           



        Catch ex As Exception

        End Try
    End Sub

    Private Sub Limpiar()
        'cboempresa.SelectedIndex = 0
        cboempresa.SelectedIndex = -1
        cbobanco.SelectedIndex = -1
        dtpfecha.Value = Date.Now.ToShortDateString()
        blnNuevo = True
        txtpersona.Text = ""
        txtcheques.Text = ""
        txtMonto.Text = "0.00"
        
    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As System.EventArgs) Handles lsvLista.ItemActivate
        'SQL = "select * from usuarios where idUsuario = " & idUsuario
        'Dim rwFilas As DataRow() = nConsulta(SQL)


        Try
            EditarFactura(lsvLista.SelectedItems(0).Tag)
            'If rwFilas Is Nothing = False Then


            '    Dim Fila As DataRow = rwFilas(0)

            '    If (Fila.Item("fkIdPerfil") = "1") Then

            '        EditarFactura(lsvLista.SelectedItems(0).Tag)

            '    End If
            'End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub limpiar2()
        txtpersona.Text = ""
        txtcheques.Text = ""
        txtMonto.Text = "0.00"
    End Sub
    Private Sub EditarFactura(id As String)
        Limpiar2()
        SQL = "select * from GastosCheques where iIdGastoCheques = " & id
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                blnNuevo = False
                Dim Fila As DataRow = rwFilas(0)
                UsuarioCreador = Fila.Item("usuarioc")
                cboempresa.SelectedValue = Fila.Item("fkiIdEmpresa")
                cbobanco.SelectedValue = Fila.Item("fkiIdBanco")
                txtcheques.Text = Fila.Item("FacturaCheques")
                txtpersona.Text = Fila.Item("Persona")
                txtMonto.Text = Fila.Item("Monto")
                dtpfecha.Value = Fila.Item("FechaMov")

                
                gIdCheque = id
                If cboempresa.SelectedIndex > -1 Then
                    cargarlista()
                End If


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

    Private Sub cmdcancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdcancelar.Click
        Limpiar()
        If cboempresa.SelectedIndex > -1 Then
            cargarlista()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtMonto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub
End Class