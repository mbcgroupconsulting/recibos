Public Class frmcolor
    Public gIdFacturaC As String
    Dim saldofactura As String
    Dim totalfactura As String
    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim SQL As String
        Dim abonos As Double
        Dim bandera As Boolean
        Dim nombresistema As String

        SQL = "Select * from usuarios where idUsuario = " & idUsuario
        Dim rwUsuario As DataRow() = nConsulta(SQL)
        nombresistema = ""
        If rwUsuario Is Nothing = False Then
            Dim Fila As DataRow = rwUsuario(0)
            nombresistema = Fila.Item("nombre")
        End If



        SQL = "select isnull(sum(importe),0) as importe from pagos where iEstatus=1 and fkiIdfactura=" & gIdFacturaC
        Dim rwFilas As DataRow() = nConsulta(SQL)
        abonos = 0

        If rwFilas Is Nothing = False Then
            abonos = Double.Parse(rwFilas(0).Item("importe"))
        End If

        bandera = False
        If cbocolor.SelectedIndex = 0 Then
            'If abonos = 0 Then
            '    bandera = True
            'ElseIf (Double.Parse(totalfactura) - abonos) <= 1 Or (abonos - Double.Parse(totalfactura)) <= 1 Then
            '    'Factura saldada

            '    MessageBox.Show("La factura ya fue abonada en sus totalidad, no le corresponde este color, favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            'ElseIf (Double.Parse(totalfactura) - abonos) > 1 Then
            '    'Factura con abonos pendientes

            '    MessageBox.Show("La factura ya fue abonada pero tiene saldo pendiente, no le corresponde este color, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            bandera = True
        ElseIf cbocolor.SelectedIndex = 1 Then
            If abonos = 0 Then
                bandera = True
            ElseIf (Double.Parse(totalfactura) - abonos) <= 1 Or (abonos - Double.Parse(totalfactura)) <= 1 Then
                'Factura saldada

                MessageBox.Show("La factura ya fue abonada en sus totalidad, no le corresponde este color, favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            ElseIf (Double.Parse(totalfactura) - abonos) > 1 Then
                'Factura con abonos pendientes

                MessageBox.Show("La factura ya fue abonada pero tiene saldo pendiente, no le corresponde este color, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        ElseIf cbocolor.SelectedIndex = 2 Then

            If abonos = 0 Then
                'Factura sin abonos
                Dim resultado As Integer = MessageBox.Show("Guardar la factura en color verde, significa que dicha factura esta pagada en su totalidad, por lo cual se hara de manera automatica un abono por la cantidad total de la factura y quedara saldada, ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)
                If resultado = DialogResult.Yes Then
                    'Hacer el detalle automatico
                    SQL = "EXEC setpagosInsertar  0," & gIdFacturaC
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & totalfactura
                    SQL &= ",'" & nombresistema
                    SQL &= "','Abono automatico'"
                    SQL &= ",'" & Date.Now.ToShortDateString()
                    SQL &= "',1"

                    If nExecute(SQL) = False Then
                        Exit Sub
                    End If

                    bandera = True
                    MessageBox.Show("Abono por el total de la factura realizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'EditarColores(lsvLista.SelectedItems(0).Tag)
                End If
            ElseIf (Double.Parse(totalfactura) - abonos) <= 1 Or (abonos - Double.Parse(totalfactura)) <= 1 Then
                'Factura saldada

                MessageBox.Show("La factura ya fue abonada en sus totalidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                bandera = True
            ElseIf (Double.Parse(totalfactura) - abonos) > 1 Then
                'Factura con abonos pendientes
                MessageBox.Show("La factura ya fue abonada pero tiene saldo pendiente, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        ElseIf cbocolor.SelectedIndex = 3 Then
            If abonos = 0 Then
                bandera = True
            ElseIf (Double.Parse(totalfactura) - abonos) <= 1 Or (abonos - Double.Parse(totalfactura)) <= 1 Then
                'Factura saldada

                MessageBox.Show("La factura ya fue abonada en sus totalidad, no le corresponde este color, favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            ElseIf (Double.Parse(totalfactura) - abonos) > 1 Then
                'Factura con abonos pendientes

                MessageBox.Show("La factura ya fue abonada pero tiene saldo pendiente, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf cbocolor.SelectedIndex = 4 Then
            If abonos = 0 Then
                'Factura sin abonos
                Dim resultado As Integer = MessageBox.Show("Guardar la factura en color verde, significa que dicha factura esta pagada en su totalidad, por lo cual se hara de manera automatica un abono por la cantidad total de la factura y quedara saldada, ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo)
                If resultado = DialogResult.Yes Then
                    'Hacer el detalle automatico
                    SQL = "EXEC setpagosInsertar  0," & gIdFacturaC
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & totalfactura
                    SQL &= ",'" & nombresistema
                    SQL &= "','Abono automatico'"
                    SQL &= ",'" & Date.Now.ToShortDateString()
                    SQL &= "',1"

                    If nExecute(SQL) = False Then
                        Exit Sub
                    End If

                    bandera = True
                    MessageBox.Show("Abono por el total de la factura realizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'EditarColores(lsvLista.SelectedItems(0).Tag)
                End If
            ElseIf (Double.Parse(totalfactura) - abonos) <= 1 Or (abonos - Double.Parse(totalfactura)) <= 1 Then
                'Factura saldada

                MessageBox.Show("La factura ya fue abonada en sus totalidad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                bandera = True
            ElseIf (Double.Parse(totalfactura) - abonos) > 1 Then
                'Factura con abonos pendientes
                MessageBox.Show("La factura ya fue abonada pero tiene saldo pendiente, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        ElseIf cbocolor.SelectedIndex = 6 Then
            If abonos = 0 Then
                MessageBox.Show("La factura no tiene ningun abono, por favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (Double.Parse(totalfactura) - abonos) <= 1 Or (abonos - Double.Parse(totalfactura)) <= 1 Then
                'Factura saldada

                MessageBox.Show("La factura ya fue abonada en sus totalidad, no le corresponde este color, favor de verificar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            ElseIf (Double.Parse(totalfactura) - abonos) > 1 Then
                'Factura con abonos pendientes

                bandera = True
            End If

        End If


        If bandera = True Then
            SQL = "update facturas set  color=" & cbocolor.SelectedIndex & " where iIdFactura=" & gIdFacturaC
            If nExecute(SQL) = False Then
                Exit Sub
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub cmdabonos_Click(sender As Object, e As EventArgs) Handles cmdabonos.Click
        Try
            Dim Forma As New frmAbono
            Forma.gIdFactura = gIdFacturaC
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

                'If cboempresa.SelectedIndex > -1 Then
                '    cargarlista()
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmcolor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargar color actual
        cargarcolor(gIdFacturaC)

    End Sub

    Private Sub cargarcolor(id As String)
        Dim SQL As String
        SQL = "select isnull(color,0) as color,total from facturas where iIdFactura = " & id
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                cbocolor.SelectedIndex = rwFilas(0).Item("color")
                totalfactura = rwFilas(0).Item("total")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdauto_Click(sender As Object, e As EventArgs)
        Dim sql As String
        Dim nombresistema As String
        Dim facturas As String
        Dim ids As String()
        Dim totalf As String

        Try
            sql = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwUsuario As DataRow() = nConsulta(sql)
            nombresistema = ""
            If rwUsuario Is Nothing = False Then
                Dim Fila As DataRow = rwUsuario(0)
                nombresistema = Fila.Item("nombre")
            End If

            facturas = "2418,2419,2420,2417,2354,2353,2385,2340,2357,2387,2421,2434,2437,2339,2383,2336,2388,2345,2350,2349,2346,2347,2348,2344,2351,2341,2342,2356,2358,2100,2436,2238,2337,2371,2384,2375,2376,2379,2381,2380,2378,2377,2382,2303,2300,2301,2041,2299"

            ids = facturas.Split(",")

            For x As Integer = 0 To ids.Length - 1

                sql = "select * from facturas where iIdFactura = " & ids(x)
                Dim rwFilas As DataRow() = nConsulta(sql)

                If rwFilas Is Nothing = False Then


                    totalf = rwFilas(0).Item("total")

                    sql = "select count(fkiIdFactura) as numero from pagos where fkiIdFactura = " & ids(x)
                    Dim rwpagos As DataRow() = nConsulta(sql)

                    If rwpagos Is Nothing = False Then

                        If rwpagos(0).Item("numero") = "0" Then
                            sql = "EXEC setpagosInsertar  0," & ids(x)
                            sql &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                            sql &= "'," & totalf
                            sql &= ",'" & nombresistema
                            sql &= "','Abono automatico'"
                            sql &= ",'" & Date.Now.ToShortDateString()
                            sql &= "',1"


                            If nExecute(sql) = False Then
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Esta factura ya tiene abonos, verifique, iIdFactura = " & ids(x), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If


                End If


            Next

            MessageBox.Show("Proceso terminado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
    End Sub
End Class