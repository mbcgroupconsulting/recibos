Public Class frmAsignarCliente
    Public gidEmpresa As String
    Dim iIdClienteEmpresaContpaq As String
    Dim sql As String
    Dim existe As Boolean = False

    Private Sub frmAsignarCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MostrarCliente()
        'verificar si la nomina tiene clientes
        sql = "select * from IntClienteEmpresaContpaq where fkIdEmpresaC=" & gidEmpresa
        Dim rwCliente As DataRow() = nConsulta(sql)
        If rwCliente Is Nothing = False Then
            cboClientes.SelectedValue = rwCliente(0)("fkIdCliente")
            lblcliente.Text = "Cliente asignado actualmente: " & cboClientes.Text
            iIdClienteEmpresaContpaq = rwCliente(0)("iIdClienteEmpresaContpaq")
            existe = True
        End If


    End Sub

    Private Sub MostrarCliente()
        'Verificar si se tienen permisos

        Try
            Sql = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre "
            nCargaCBO(cboClientes, Sql, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdguardar_Click(sender As System.Object, e As System.EventArgs) Handles cmdguardar.Click
        Try

            If existe Then
                sql = "EXEC setIntClienteEmpresaContpaqActualizar " & iIdClienteEmpresaContpaq & "," & gidEmpresa
                sql &= "," & cboClientes.SelectedValue

            Else
                sql = "EXEC setIntClienteEmpresaContpaqInsertar   0," & gidEmpresa
                sql &= "," & cboClientes.SelectedValue
            End If

            If nExecute(sql) = False Then
                Exit Sub
            End If

            MessageBox.Show("Datos guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class