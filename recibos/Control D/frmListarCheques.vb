Imports ClosedXML.Excel

Public Class frmListarCheques
    Dim SQL As String

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Close()
    End Sub

    Private Sub frmListarCheques_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
        MostrarEmpresa()

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
        Dim Alter As Boolean = False
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        SQL = ""
        lsvLista.Items.Clear()
        lsvLista.Clear()
        If (tiempo.Days >= 0) Then

            If chktodas.Checked = False Then
                SQL = "select * from (GastosCheques inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                SQL &= " inner Join bancos On GastosCheques.fkiIdBanco =  bancos.iIdBanco "
                SQL &= " where GastosCheques.iEstatus=1 "
                SQL &= " And FechaMov between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                SQL &= " order by FechaMov,empresa.nombre"

            Else
                SQL = "select * from (GastosCheques inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                SQL &= " inner Join bancos On GastosCheques.fkiIdBanco =  bancos.iIdBanco "
                SQL &= " where GastosCheques.iEstatus=1 "
                SQL &= " And FechaMov between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                SQL &= " order by FechaMov,empresa.nombre"

            End If

        

        Dim item As ListViewItem
            lsvLista.Columns.Add("Fecha")
            lsvLista.Columns(0).Width = 100
            lsvLista.Columns.Add("Empresa")
            lsvLista.Columns(1).Width = 350
            lsvLista.Columns.Add("Banco")
            lsvLista.Columns(2).Width = 350
            lsvLista.Columns.Add("Num Cheques")
            lsvLista.Columns(3).Width = 350
            lsvLista.Columns.Add("Monto")
            lsvLista.Columns(4).Width = 100
            lsvLista.Columns(3).TextAlign = 1
            lsvLista.Columns.Add("Persona Asignada")
            lsvLista.Columns(5).Width = 350
            lsvLista.Columns.Add("Capturo")
            lsvLista.Columns(6).Width = 350
            lsvLista.Columns.Add("Modifico")
            lsvLista.Columns(7).Width = 350

        Dim sumatoria As Double
        sumatoria = 0

        lblTotal.Text = "Total:"
        Dim rwGastos As DataRow() = nConsulta(SQL)
        If rwGastos Is Nothing = False Then
            For Each Fila In rwGastos




                    item = lsvLista.Items.Add("" & Fila.Item("FechaMov"))

                    item.SubItems.Add("" & Fila.Item("nombre"))
                    item.SubItems.Add("" & Fila.Item("cBanco"))
                    item.SubItems.Add("" & Fila.Item("FacturaCheques"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("Monto"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Fila.Item("persona"))
                    item.SubItems.Add("" & Fila.Item("UsuarioC"))
                    item.SubItems.Add("" & Fila.Item("UsuarioM"))
                    item.Tag = Fila.Item("iIdGastoCheques")
                'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter
                    sumatoria = sumatoria + Double.Parse(Fila.Item("Monto"))

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

    Private Sub cmdexcel_Click(sender As System.Object, e As System.EventArgs) Handles cmdexcel.Click
        Try
            Dim filaExcel As Integer = 5
            Dim dialogo As New SaveFileDialog()
            Dim idtipo As Integer
            Dim Alter As Boolean = False
            Dim inicio As DateTime = dtpfechainicio.Value
            Dim fin As DateTime = dtpfechafin.Value
            Dim tiempo As TimeSpan = fin - inicio

            If (tiempo.Days >= 0) Then
                If chktodas.Checked = False Then
                    SQL = "select * from (GastosCheques inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                    SQL &= " inner Join bancos On GastosCheques.fkiIdBanco =  bancos.iIdBanco "
                    SQL &= " where GastosCheques.iEstatus=1 "
                    SQL &= " And FechaMov between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                    SQL &= " and fkiIdEmpresa= " & cboempresa.SelectedValue
                    SQL &= " order by FechaMov,empresa.nombre"

                Else
                    SQL = "select * from (GastosCheques inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                    SQL &= " inner Join bancos On GastosCheques.fkiIdBanco =  bancos.iIdBanco "
                    SQL &= " where GastosCheques.iEstatus=1 "
                    SQL &= " And FechaMov between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "' "
                    SQL &= " order by FechaMov,empresa.nombre"

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

                    hoja.Cell(3, 2).Value = ""
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
                        hoja.Cell(filaExcel, 1).Value = Fila.Item("nombre")
                        hoja.Cell(filaExcel, 2).Value = Fila.Item("cBanco")
                        hoja.Cell(filaExcel, 3).Value = Fila.Item("FacturaCheques")
                        hoja.Cell(filaExcel, 4).Value = Fila.Item("Monto")
                        hoja.Cell(filaExcel, 5).Value = Fila.Item("persona")
                        hoja.Cell(filaExcel, 6).Value = Fila.Item("UsuarioC")
                        hoja.Cell(filaExcel, 7).Value = Fila.Item("UsuarioM")
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