Public Class frmAnexarGastosConciliacion
    Dim SQL As String
    Dim blnNuevo As Boolean
    Public gDatosFactura As String
    Public giIdFactura As String
    Public giIdEmpresa As String
    Public gFechaInicial As String
    Public gFechaFinal As String

    Private Sub frmAnexarGastosConciliacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = gFechaInicial
        dtpfechafin.Value = gFechaFinal
        MostrarEmpresa()
        cboempresa.SelectedIndex = giIdEmpresa
    End Sub

    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdbuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdbuscar.Click
        Try
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            lsvLista.Items.Clear()
            lsvLista.Clear()
            If (tiempo.Days >= 0) Then
                SQL = "select * from gastos inner join empresa on fkiIdEmpresa= iIdEmpresa"
                SQL &= " where gastos.iEstatus=1 "
                SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                SQL &= "  And (fkiIdTipoGastos=1 or fkiIdTipoGastos=2 or fkiIdTipoGastos=3)"
                SQL &= " order by fechapago,empresa.nombre"


                Dim item As ListViewItem
                lsvLista.Columns.Add("Factura")
                lsvLista.Columns(0).Width = 170
                lsvLista.Columns.Add("Fecha Expedicón")
                lsvLista.Columns(1).Width = 170
                lsvLista.Columns.Add("Proveedor")
                lsvLista.Columns(2).Width = 300
                lsvLista.Columns.Add("Total")
                lsvLista.Columns(3).Width = 120
                lsvLista.Columns(3).TextAlign = 1
                lsvLista.Columns.Add("Fecha Pago")
                lsvLista.Columns(4).Width = 170
                lsvLista.Columns.Add("Empresa")
                lsvLista.Columns(5).Width = 300

                Dim sumatoria As Double
                sumatoria = 0

                lblTotal.Text = "Total:"
                Dim rwGastos As DataRow() = nConsulta(SQL)
                If rwGastos Is Nothing = False Then
                    For Each Fila In rwGastos




                        item = lsvLista.Items.Add("" & Fila.Item("Factura"))

                        item.SubItems.Add("" & Fila.Item("fechaexp"))
                        item.SubItems.Add("" & Fila.Item("proveedor"))
                        item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                        item.SubItems.Add("" & Fila.Item("fechapago"))
                        item.SubItems.Add("" & Fila.Item("nombre"))
                        item.Tag = Fila.Item("iIdGasto")
                        'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                        Alter = Not Alter
                        sumatoria = sumatoria + Double.Parse(Fila.Item("total"))

                    Next
                    lblTotal.Text = lblTotal.Text & " $" & Format(CType(sumatoria, Decimal), "###,###,##0.#0")
                    MessageBox.Show(rwGastos.Count & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub cmdagregar_Click(sender As System.Object, e As System.EventArgs) Handles cmdagregar.Click
        Try
            gDatosFactura = ""
            giIdFactura = ""
            Dim inicio As Boolean = True
            If lsvLista.CheckedItems.Count > 0 Then
                For Each producto As ListViewItem In lsvLista.CheckedItems
                    If inicio Then
                        gDatosFactura = producto.SubItems(0).Text & " " & producto.SubItems(2).Text
                        giIdFactura = producto.Tag
                        inicio = False
                    Else
                        gDatosFactura &= ", " & producto.SubItems(0).Text & " " & producto.SubItems(2).Text
                        giIdFactura &= "," & producto.Tag
                    End If
                Next
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Por favor seleccione al menos una factura.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class