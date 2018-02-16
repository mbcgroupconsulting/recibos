Imports ClosedXML.Excel

Public Class frmListaGastos
    Dim SQL As String
    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()

    End Sub

    Private Sub frmListaGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
        MostrarEmpresa()
        MostrarTiposGastos()
    End Sub

    Private Sub MostrarTiposGastos()
        'Verificar si se tienen permisos
        Try
            SQL = "Select descripcion,iIdTipoGastos from TipoGastos where iEstatus=1 order by descripcion "
            nCargaCBO(cboTipogastos, SQL, "descripcion", "iIdTipoGastos")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click

        Dim Alter As Boolean = False
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio

        lsvLista.Items.Clear()
        lsvLista.Clear()
        If (tiempo.Days >= 0) Then
            If cboTipogastos.SelectedValue = 1 Or cboTipogastos.SelectedValue = 2 Or cboTipogastos.SelectedValue = 3 Then
                If chktodas.Checked = False Then
                    SQL = "select * from gastos inner join empresa on fkiIdEmpresa= iIdEmpresa"
                    SQL &= " where gastos.iEstatus=1 "
                    SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                    SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                    SQL &= "  And fkiIdTipoGastos=" & cboTipogastos.SelectedValue
                    SQL &= " order by fechapago,empresa.nombre"

                Else
                    SQL = "select * from gastos inner join empresa on fkiIdEmpresa= iIdEmpresa"
                    SQL &= " where gastos.iEstatus=1 "
                    SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                    SQL &= "  And fkiIdTipoGastos=" & cboTipogastos.SelectedValue
                    SQL &= " order by fechapago,empresa.nombre"

                End If

            ElseIf cboTipogastos.SelectedValue = 4 Or cboTipogastos.SelectedValue = 5 Or cboTipogastos.SelectedValue = 6 Or cboTipogastos.SelectedValue = 7 Then
                SQL = "select iIdGasto,Factura,fechaexp,proveedor, total, fechapago,descripcion as nombre from gastos inner join TipoGastos on fkiIdTipoGastos= iIdTipoGastos"
                SQL &= " where gastos.iEstatus=1 "
                SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                SQL &= "  And fkiIdTipoGastos=" & cboTipogastos.SelectedValue
                SQL &= " order by fechapago,nombre"
            End If


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



    End Sub

    Private Sub cmdexcel_Click(sender As Object, e As EventArgs) Handles cmdexcel.Click
        Try
            Dim filaExcel As Integer = 5
            Dim dialogo As New SaveFileDialog()
            Dim idtipo As Integer
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            If (tiempo.Days >= 0) Then
                If cboTipogastos.SelectedValue = 1 Or cboTipogastos.SelectedValue = 2 Or cboTipogastos.SelectedValue = 3 Then
                    If chktodas.Checked = False Then
                        SQL = "select * from gastos inner join empresa on fkiIdEmpresa= iIdEmpresa"
                        SQL &= " where gastos.iEstatus=1 "
                        SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                        SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                        SQL &= "  And fkiIdTipoGastos=" & cboTipogastos.SelectedValue
                        SQL &= " order by fechapago,empresa.nombre"

                    Else
                        SQL = "select * from gastos inner join empresa on fkiIdEmpresa= iIdEmpresa"
                        SQL &= " where gastos.iEstatus=1 "
                        SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                        SQL &= "  And fkiIdTipoGastos=" & cboTipogastos.SelectedValue
                        SQL &= " order by fechapago,empresa.nombre"

                    End If

                ElseIf cboTipogastos.SelectedValue = 4 Or cboTipogastos.SelectedValue = 5 Or cboTipogastos.SelectedValue = 6 Or cboTipogastos.SelectedValue = 7 Then
                    SQL = "select iIdGasto,Factura,fechaexp,proveedor, total, fechapago,descripcion as nombre from gastos inner join TipoGastos on fkiIdTipoGastos= iIdTipoGastos"
                    SQL &= " where gastos.iEstatus=1 "
                    SQL &= " And fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                    SQL &= "  And fkiIdTipoGastos=" & cboTipogastos.SelectedValue
                    SQL &= " order by fechapago,nombre"
                End If



                Dim sumatoria As Double
                sumatoria = 0

                Dim rwGastos As DataRow() = nConsulta(SQL)
                If rwGastos Is Nothing = False Then

                    Dim libro As New ClosedXML.Excel.XLWorkbook
                    Dim hoja As IXLWorksheet = libro.Worksheets.Add("Gastos")
                    hoja.Column("A").Width = 15
                    hoja.Column("B").Width = 15
                    hoja.Column("C").Width = 50
                    hoja.Column("D").Width = 30
                    hoja.Column("E").Width = 15
                    hoja.Column("F").Width = 50

                    hoja.Cell(2, 2).Value = "Fecha: " & Date.Now.ToShortDateString()

                    hoja.Cell(3, 2).Value = cboTipogastos.Text.ToUpper
                    'hoja.Cell(3, 2).Value = ":"
                    'hoja.Cell(3, 3).Value = ""

                    hoja.Range(4, 1, 4, 6).Style.Font.FontSize = 10
                    hoja.Range(4, 1, 4, 6).Style.Font.SetBold(True)
                    hoja.Range(4, 1, 4, 6).Style.Alignment.WrapText = True
                    hoja.Range(4, 1, 4, 6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    hoja.Range(4, 1, 4, 6).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    'hoja.Range(4, 1, 4, 18).Style.Fill.BackgroundColor = XLColor.BleuDeFrance
                    hoja.Range(4, 1, 4, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#538DD5")
                    hoja.Range(4, 1, 4, 6).Style.Font.FontColor = XLColor.FromHtml("#FFFFFF")

                    'hoja.Cell(4, 1).Value = "Num"
                    hoja.Cell(4, 1).Value = "Factura"
                    hoja.Cell(4, 2).Value = "Feccha Exp"
                    hoja.Cell(4, 3).Value = "Proveedor"
                    hoja.Cell(4, 4).Value = "Total"
                    hoja.Cell(4, 5).Value = "Fecha Pago"
                    hoja.Cell(4, 6).Value = "Empresa Plaza"




                    filaExcel = 4
                    For Each Fila In rwGastos
                        filaExcel = filaExcel + 1
                        hoja.Cell(filaExcel, 1).Value = Fila.Item("Factura")
                        hoja.Cell(filaExcel, 2).Value = Fila.Item("fechaexp")
                        hoja.Cell(filaExcel, 3).Value = Fila.Item("proveedor")
                        hoja.Cell(filaExcel, 4).Value = Fila.Item("total")
                        hoja.Cell(filaExcel, 5).Value = Fila.Item("fechapago")
                        hoja.Cell(filaExcel, 6).Value = Fila.Item("nombre")
                        hoja.Range(5, 4, 1500, 4).Style.NumberFormat.SetFormat("###,###,##0.#0")


                    Next

                    dialogo.DefaultExt = "*.xlsx"
                    dialogo.FileName = "Gastos"
                    dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                    dialogo.ShowDialog()
                    libro.SaveAs(dialogo.FileName)
                    'libro.SaveAs("c:\temp\control.xlsx")
                    'libro.SaveAs(dialogo.FileName)
                    'apExcel.Quit()
                    libro = Nothing
                    MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If



        Catch ex As Exception

        End Try
    End Sub
End Class