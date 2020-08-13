Public Class frmAsignarCliente
    Public gidEmpresa As String
    Dim iIdClienteEmpresaContpaq As String
    Dim sql As String
    Dim existe As Boolean = False

    Private Sub frmAsignarCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MostrarCliente()
        cboSubsidio.SelectedIndex = 0

        'verificar si la nomina tiene clientes
        sql = "select * from IntClienteEmpresaContpaq where fkIdEmpresaC=" & gidEmpresa
        Dim rwCliente As DataRow() = nConsulta(sql)
        If rwCliente Is Nothing = False Then
            cboClientes.SelectedValue = rwCliente(0)("fkIdCliente")
            lblcliente.Text = "Cliente asignado actualmente: " & cboClientes.Text
            iIdClienteEmpresaContpaq = rwCliente(0)("iIdClienteEmpresaContpaq")
            cboSubsidio.SelectedIndex = rwCliente(0)("TipoSubsidio")
            If rwCliente(0)("CalculoSubsidio") = "0" Then
                rdbNada.Checked = True
            ElseIf rwCliente(0)("CalculoSubsidio") = "1" Then
                rdbSumar.Checked = True
            ElseIf rwCliente(0)("CalculoSubsidio") = "2" Then
                rdbRestar.Checked = True
            End If
            chkSubsidio.Checked = IIf(rwCliente(0)("SubsidioReporte") = "1", True, False)
            chkCalcularOrdinario.Checked = IIf(rwCliente(0)("CalcularOrdinario") = "1", True, False)
            chkOrdinarioAbsoluto.Checked = IIf(rwCliente(0)("OrdinarioAbsoluto") = "1", True, False)

            chkNeto.Checked = IIf(rwCliente(0)("CSAneto") = "1", True, False)
            chkInfonavit.Checked = IIf(rwCliente(0)("CSAinfonavit") = "1", True, False)
            chkFonacot.Checked = IIf(rwCliente(0)("CSAFonacot") = "1", True, False)
            chkPension.Checked = IIf(rwCliente(0)("CSApensionA") = "1", True, False)

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
            Dim valor As Integer
            If existe Then
                sql = "EXEC setIntClienteEmpresaContpaqActualizar " & iIdClienteEmpresaContpaq & "," & gidEmpresa
                sql &= "," & cboClientes.SelectedValue
                sql &= "," & cboSubsidio.SelectedIndex

                If rdbNada.Checked Then
                    valor = 0
                ElseIf rdbSumar.Checked Then
                    valor = 1
                ElseIf rdbRestar.Checked = True Then
                    valor = 2
                End If

                sql &= "," & valor
                sql &= "," & IIf(chkSubsidio.Checked, 1, 0)
                sql &= "," & IIf(chkCalcularOrdinario.Checked, 1, 0)
                sql &= "," & IIf(chkOrdinarioAbsoluto.Checked, 1, 0)
                'Calculo comision sa
                sql &= "," & IIf(chkNeto.Checked, 1, 0)
                sql &= "," & IIf(chkInfonavit.Checked, 1, 0)
                sql &= "," & IIf(chkFonacot.Checked, 1, 0)
                sql &= "," & IIf(chkPension.Checked, 1, 0)

            Else
                sql = "EXEC setIntClienteEmpresaContpaqInsertar   0," & gidEmpresa
                sql &= "," & cboClientes.SelectedValue
                sql &= "," & cboSubsidio.SelectedIndex
                If rdbNada.Checked Then
                    valor = 0
                ElseIf rdbSumar.Checked Then
                    valor = 1
                ElseIf rdbRestar.Checked = True Then
                    valor = 2
                End If

                sql &= "," & valor
                sql &= "," & IIf(chkSubsidio.Checked, 1, 0)
                sql &= "," & IIf(chkCalcularOrdinario.Checked, 1, 0)
                sql &= "," & IIf(chkOrdinarioAbsoluto.Checked, 1, 0)

                'Calculo comision sa
                sql &= "," & IIf(chkNeto.Checked, 1, 0)
                sql &= "," & IIf(chkInfonavit.Checked, 1, 0)
                sql &= "," & IIf(chkFonacot.Checked, 1, 0)
                sql &= "," & IIf(chkPension.Checked, 1, 0)

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