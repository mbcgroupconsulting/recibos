Public Class frmAsignarEmpresa
    Public gidEmpresa As String
    Dim iIdEmpresaEmpresaContpaq As String
    Dim sql As String
    Dim existe As Boolean = False

    Private Sub frmAsignarEmpresa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MostrarEmpresa()
        'verificar si la nomina tiene clientes
        sql = "select * from IntEmpresaEmpresaContpaq where fkIdEmpresaC=" & gidEmpresa
        Dim rwCliente As DataRow() = nConsulta(sql)
        If rwCliente Is Nothing = False Then
            cboEmpresa.SelectedValue = rwCliente(0)("fkiIdEmpresa")
            lblempresa.Text = "Empresa asignada actualmente: " & cboEmpresa.Text
            iIdEmpresaEmpresaContpaq = rwCliente(0)("iIdEmpresaEmpresaContpaq")
            existe = True
        End If
    End Sub

    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos

        Try
            sql = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre "
            nCargaCBO(cboEmpresa, sql, "nombre", "iIdEmpresa")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdguardar_Click(sender As System.Object, e As System.EventArgs) Handles cmdguardar.Click
        Try

            If existe Then
                sql = "EXEC setIntEmpresaEmpresaContpaqActualizar " & iIdEmpresaEmpresaContpaq & "," & gidEmpresa
                sql &= "," & cboEmpresa.SelectedValue

            Else
                sql = "EXEC setIntEmpresaEmpresaContpaqInsertar   0," & gidEmpresa
                sql &= "," & cboEmpresa.SelectedValue
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