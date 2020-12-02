Public Class frmBuscarBanco
    Public gIdBanco As String
    Public SoloActivo As Boolean = False
    Public gIdEmpresa As String
    Public gIdCliente As String
    Dim blnNuevo As Boolean

    Private Sub frmBuscarBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbancos()
        cargarbancosasociados()
        TabIndex()

        blnNuevo = True
    End Sub
    Private Sub cargarbancos()
        Dim sql As String
        Try
            sql = "select * from bancos order by cbanco"
            nCargaCBO(cbBancos, sql, "cBanco", "iIdBanco")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub tabIndex()
        cbBancos.TabIndex = 1
        txtcliente.TabIndex = 2
        txtempresa.TabIndex = 3
        txttipo.TabIndex = 4
        txtcuentacargo.TabIndex = 5
        txtsucursal.TabIndex = 6
        txtdescripcion.TabIndex = 7
        btnAsignar.TabIndex = 8
    End Sub
 
    Private Sub cargarbancosasociados()
        Dim sql As String
        Dim Alter As Boolean = False
        ' Dim SQL As String
        Dim iBan As Integer
        lsvBancos.Items.Clear()
        lsvBancos.Clear()

        Try
            sql = "SELECT * FROM datosbanco"
            sql &= " WHERE fkiIdEmpresa=" & gIdEmpresa
            sql &= " order by  numcliente, fkiIdBanco"

            Dim item As ListViewItem
            lsvBancos.Columns.Add("Banco")
            lsvBancos.Columns(0).Width = 200
            lsvBancos.Columns.Add("Numero Cliente")
            lsvBancos.Columns(1).Width = 170
            lsvBancos.Columns.Add("Cuenta Cargo")
            lsvBancos.Columns(2).Width = 170
            lsvBancos.Columns.Add("Sucursal")
            lsvBancos.Columns(3).Width = 100
            lsvBancos.Columns.Add("Empresa")
            lsvBancos.Columns(4).Width = 200
            lsvBancos.Columns.Add("Tipo")
            lsvBancos.Columns(5).Width = 200
            lsvBancos.Columns.Add("Descripcion")
            lsvBancos.Columns(6).Width = 200

            Dim rwBancosD As DataRow() = nConsulta(sql)
            If rwBancosD Is Nothing = False Then
                For Each Fila In rwBancosD
                    Dim rwBancos As DataRow() = nConsulta("SELECT * FROM Bancos WHERE iIdBanco=" & Fila.Item("fkiIdBanco"))

                    item = lsvBancos.Items.Add(rwBancos(0).Item("cBanco"))
                    item.SubItems.Add("" & Fila.Item("numcliente"))
                    item.SubItems.Add("" & Fila.Item("cuentacargo"))
                    item.SubItems.Add("" & Fila.Item("numsucursal"))
                    item.SubItems.Add("" & Fila.Item("empresa"))
                    item.SubItems.Add("" & Fila.Item("Tipo"))
                    item.SubItems.Add("" & Fila.Item("descripcion"))
                    item.Tag = Fila.Item("iIdDatosBanco")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter
                    blnNuevo = False
                Next
            Else
                blnNuevo = True
            End If

            If lsvBancos.Items.Count > 0 Then
                lsvBancos.Focus()
                lsvBancos.Items(0).Selected = True
            Else
                txtbuscar.Focus()
                txtbuscar.SelectAll()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'cancelar
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub

    'Asignar/Modificar Datos Banco
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click

        Dim SQL As String, Alter As Boolean = False
        Try
            If blnNuevo = False Then

                SQL = "UPDATE DatosBanco SET "
                SQL &= "fkiIdBanco=" & cbBancos.SelectedValue & ","
                SQL &= " numcliente= '" & txtcliente.Text & "',"
                SQL &= " empresa= '" & txtempresa.Text & "',"
                SQL &= " descripcion= '" & txtdescripcion.Text & "',"
                SQL &= " cuentacargo= '" & txtcuentacargo.Text & "',"
                SQL &= " numsucursal= '" & txtsucursal.Text & "',"
                SQL &= " fkiIdEmpresa= " & gIdEmpresa & ","
                SQL &= " Tipo= '" & txttipo.Text & "'"
                SQL &= " WHERE iIdDatosBanco=" & lsvBancos.SelectedItems(0).Tag
            Else
                SQL = "EXEC setDatosBancoInsertar 0,"
                SQL &= cbBancos.SelectedValue & ", "
                SQL &= "'" & txtcliente.Text & "',"
                SQL &= "'" & txtempresa.Text & "', "
                SQL &= "'" & txtdescripcion.Text & "', "
                SQL &= "'" & txtcuentacargo.Text & "',"
                SQL &= "'" & txtsucursal.Text & "', "
                SQL &= gIdEmpresa & ", "
                SQL &= "'" & txttipo.Text & "' "

            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If

            'Se Registra

            SQL = "EXEC setDatosBancoBajaAltaInsertar 0,"
            SQL &= lsvBancos.SelectedItems(0).Tag & ", "
            SQL &= "'" & Usuario.Nombre & "', '"
            SQL &= Date.Today.ToShortDateString() & "',"
            SQL &= "' Empresa: " & txtempresa.Text & " ',"
            SQL &= gIdEmpresa


            If SQL <> "" Then
                If nExecute(SQL) = False Then
                    Exit Sub
                End If
            End If

            cargarbancosasociados()
            limpiar()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub lsvEmpresas_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvBancos.ItemActivate

        Try
            Dim id As Long
            Dim idperiodo As Long
            Dim nombre As String
            Dim sql As String
            If lsvBancos.SelectedItems.Count > 0 Then
                id = lsvBancos.SelectedItems(0).Tag ' id datos banco


                sql = "SELECT * FROM Bancos where cbanco = '" & lsvBancos.SelectedItems(0).SubItems(0).Text & "'"

                Dim rwBancos As DataRow() = nConsulta(sql)

                cbBancos.SelectedValue = rwBancos(0).Item("iIdBanco")
                txtcliente.Text = lsvBancos.SelectedItems(0).SubItems(1).Text
                txtcuentacargo.Text = lsvBancos.SelectedItems(0).SubItems(2).Text
                txtsucursal.Text = lsvBancos.SelectedItems(0).SubItems(3).Text
                txtempresa.Text = lsvBancos.SelectedItems(0).SubItems(4).Text
                txttipo.Text = lsvBancos.SelectedItems(0).SubItems(5).Text
                txtdescripcion.Text = lsvBancos.SelectedItems(0).SubItems(6).Text

                blnNuevo = False


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub limpiar()

        cbBancos.SelectedIndex = 0
        txtcliente.Text = ""
        txtcliente.Text = ""
        txtempresa.Text = ""
        txttipo.Text = ""
        txtcuentacargo.Text = ""
        txtsucursal.Text = ""
        txtdescripcion.Text = ""
        txtcliente.Focus()
    End Sub

End Class