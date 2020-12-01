Public Class frmBuscarBanco
    Public gIdBanco As String
    Public SoloActivo As Boolean = False
    Public gIdEmpresa As String
    Public gIdCliente As String
    Dim blnNuevo As Boolean

    Private Sub frmBuscarBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarbancos()
        cargarbancosasociados()
        cargarbancosasociadosScotia()
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
    Private Sub cargarbancosasociadosScotia()
        Dim sql As String
        Try
            If cbBancos.SelectedValue = 13 Then

                sql = "select * from datosbanco where fkiidBanco =" & gIdBanco & " and fkiIdEmpresa=" & gIdEmpresa & " order by numcliente"
                nCargaCBO(cbocliente, sql, "numcliente", "iIdDatosBanco")

            End If

        Catch ex As Exception

        End Try
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
            lsvBancos.Columns(0).Width = 250
            lsvBancos.Columns.Add("Numero Cliente")
            lsvBancos.Columns(1).Width = 170
            lsvBancos.Columns.Add("Cuenta Cargo")
            lsvBancos.Columns(2).Width = 350
            lsvBancos.Columns.Add("Sucursal")
            lsvBancos.Columns(3).Width = 120
            lsvBancos.Columns.Add("Tipo")
            lsvBancos.Columns(4).Width = 270

            Dim rwBancosD As DataRow() = nConsulta(sql)
            If rwBancosD Is Nothing = False Then
                For Each Fila In rwBancosD
                    Dim rwBancos As DataRow() = nConsulta("SELECT * FROM Bancos WHERE iIdBanco=" & Fila.Item("fkiIdBanco"))

                    item = lsvBancos.Items.Add(rwBancos(0).Item("cBanco"))
                    item.SubItems.Add("" & Fila.Item("numcliente"))
                    item.SubItems.Add("" & Fila.Item("cuentacargo"))
                    item.SubItems.Add("" & Fila.Item("numsucursal"))
                    item.SubItems.Add("" & Fila.Item("Tipo"))
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
                SQL &= " numcliente=" & cbocliente.SelectedText & ","
                SQL &= " empresa= " & txtempresa.Text & ","
                SQL &= " descripcion= " & txtdescripcion.Text & ","
                SQL &= " cuentacargo= " & txtcuentacargo.Text & ","
                SQL &= " numsucursal= " & txtsucursal.Text & ","
                SQL &= " fkiIdEmpresa= " & gIdEmpresa & ","
                SQL &= " Tipo= " & txttipo.Text

            Else
                SQL = "EXEC setBuscarDatosInsertar 0,"
                SQL &= cbBancos.SelectedValue & ", "
                SQL &= cbocliente.SelectedValue & ","
                SQL &= "'" & txtempresa.Text & "', "
                SQL &= "'" & txtdescripcion.Text & "', "
                SQL &= "'" & txtcuentacargo.Text & "',"
                SQL &= "'" & txtsucursal.Text & "', "
                SQL &= "'" & txttipo.Text & "' "

            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If

            'Registrar modificaicones
            If blnNuevo Then
                SQL = "SELECT MAX(iIdDatosBanco) as id from  DatosBanco"
                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim Fila As DataRow = rwFilas(0)
                 

                Else


                    SQL = "EXEC setDatosBancoBajaAltaInsertar 0,"
                    SQL &= lsvBancos.Tag & ", "
                    SQL &= "'" & Usuario.Nombre & "', '"
                    SQL &= Date.Now & "',"
                    SQL &= "'" & txtempresa.Text & "'"
                End If
               
            End If



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
                id = lsvBancos.SelectedItems(0).Tag


                sql = "SELECT * FROM datosbanco where iIdDatosBanco = " & id

                Dim rwFilas As DataRow() = nConsulta(sql)
                If rwFilas Is Nothing = False Then
                    Select Case rwFilas(0).Item("iIdBanco")
                        Case 1

                        Case 4

                        Case 5

                        Case 13

                        Case 18

                        Case Else

                    End Select
                End If

                cbBancos.SelectedValue = id
                cbocliente.SelectedText = lsvBancos.SelectedItems(0).SubItems(1).Text
                txtcuentacargo.Text = lsvBancos.SelectedItems(0).SubItems(2).Text
                txtsucursal.Text = lsvBancos.SelectedItems(0).SubItems(3).Text
                txttipo.Text = lsvBancos.SelectedItems(0).SubItems(4).Text



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If lsvBancos.SelectedItems.Count > 0 Then
            gIdBanco = lsvBancos.SelectedItems(0).Tag
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub cbocliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbocliente.SelectedIndexChanged
        Dim sql As String
        Try
            sql = "select * from DatosBanco where iIdDatosBanco=" & cbocliente.SelectedValue
            Dim rwDatos As DataRow() = nConsulta(sql)

            If rwDatos Is Nothing = False Then
                txtempresa.Text = rwDatos(0)("empresa").ToString
                txttipo.Text = rwDatos(0)("descripcion").ToString
                txtcuentacargo.Text = rwDatos(0)("cuentacargo").ToString
                txtsucursal.Text = rwDatos(0)("numsucursal").ToString
            Else
                MessageBox.Show("No se encontraron datos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class