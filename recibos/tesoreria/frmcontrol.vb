Imports Microsoft.Office.Interop

Imports System.IO
Imports System.Data
Imports System.Reflection
Public Class frmcontrol
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim blnOtraSA As Boolean
    Dim porcentajesa As Double
    Dim porcentajesin As Double
    Public gIdFactura As String
    Dim totalfactura As Double
    Dim gIdFacturasnomina As String
    Dim gidFacturasnomina2 As String
    Dim blnFechainicio As Boolean
    Dim DetCadena As String


    Private Sub frmcontrol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blnFechainicio = True
        blnNuevo = True
        blnOtraSA = False
        MostrarEmpresa()
        MostrarCliente()
        MostrarEmpresa2()
        MostrarEmpresa3()
        MostrarCliente2()
        Mostrartipoperiodos()
        MostrarPromotores()
        totalfactura = 0
        cargarlista()
        gIdFacturasnomina = ""
        gidFacturasnomina2 = ""

        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
    End Sub

    Private Sub MostrarEmpresa3()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where fkiIdTipoEmpresa=1 and iEstatus=1 order by nombre  "
            nCargaCBO(cbopatrona2, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MostrarEmpresa2()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdEmpresa from empresa where fkiIdTipoEmpresa=1 and iEstatus=1 order by nombre  "
            nCargaCBO(cboempresa2, SQL, "nombre", "iIdEmpresa")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MostrarCliente2()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre "
            nCargaCBO(cbocliente2, SQL, "nombre", "iIdCliente")
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
    Private Sub MostrarCliente()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre "
            nCargaCBO(cbocliente, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Mostrartipoperiodos()
        Try
            SQL = "Select * from tipos_periodos2 order by nombre "
            nCargaCBO(cbotipoperiodo, SQL, "nombre", "iIdTipoperiodo2")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MostrarPromotores()
        SQL = "Select * from promotor order by iIdPromotor"
        nCargaCBO(cbopromotor, SQL, "nombrecom", "iIdPromotor")
        nCargaCBO(cbopromotor2, SQL, "nombrecom", "iIdPromotor")
        nCargaCBO(cbopromotor3, SQL, "nombrecom", "iIdPromotor")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdfactura.Click
        Dim Forma As New frmfacturascontrol
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            gIdFactura = Forma.gIdFactura
            'CargarDatos(Forma.gIdFactura)
            'Calcularcomision()
            AgregarDatos(Forma.gIdFactura)
        End If
    End Sub

    Private Sub AgregarDatos(id As String)
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim item As ListViewItem
        Dim Alter As Boolean = False
        Dim ids As String()

        Try

            ids = id.Split(",")
            For x As Integer = 0 To ids.Length - 1
                SQL = "select empresa.nombre as empresa,clientes.nombre as cliente,numfactura,importe,iva,total,fkiIdEmpresa,fkiIdCliente,fecha "
                SQL &= "  from (facturas"
                SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                SQL &= " inner join clientes on fkiIdCliente= iIdCliente"
                SQL &= " where iIdFactura = " & ids(x)

                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then

                    Dim Fila As DataRow = rwFilas(0)



                    item = lsvfacturas.Items.Add("(" & Fila.Item("fkiIdEmpresa") & ")" & Fila.Item("empresa"))
                    item.SubItems.Add("(" & Fila.Item("fkiIdCliente") & ")" & Fila.Item("cliente"))
                    item.SubItems.Add(Fila.Item("numfactura"))
                    item.SubItems.Add(Fila.Item("importe"))
                    item.SubItems.Add(Fila.Item("iva"))
                    item.SubItems.Add(Fila.Item("total"))
                    item.SubItems.Add(Fila.Item("fecha"))
                    'totalfactura = totalfactura + txttotal.Text
                    txttotalf.Text = (Double.Parse(Fila.Item("total")) + Double.Parse(txttotalf.Text)).ToString()

                    item.Tag = ids(x)

                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter



                End If
            Next


        Catch ex As Exception

        End Try


    End Sub

    Private Sub CargarDatos(id As String)
        SQL = "select * from facturas where iIdFactura = " & id
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)


                txtimporte.Text = Fila.Item("importe")
                txtiva.Text = Fila.Item("iva")
                txttotal.Text = Fila.Item("total")
                txtfactura.Text = Fila.Item("numfactura")
                cboempresa.SelectedValue = Fila.Item("fkiIdEmpresa")
                cbocliente.SelectedValue = Fila.Item("fkiIdcliente")
                cbocliente.Enabled = False
                cboempresa.Enabled = False
                txtimporte.Enabled = False
                txtiva.Enabled = False
                txttotal.Enabled = False
                txtfactura.Enabled = False



            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click

        limpiarfacturas()




    End Sub

    Private Sub limpiar()
        Try
            blnNuevo = True
            cbopromotor.SelectedIndex = 0
            cbopromotor2.SelectedIndex = 0
            cbopromotor3.SelectedIndex = 0
            cbotipoperiodo.SelectedIndex = 0
            dtpfecha.Value = Date.Now

            txttotalf.Text = "0.00"
            Label9.Text = "%"
            Label12.Text = "%"
            txtsindicato.Text = ""
            txtsa.Text = ""
            txtcomisionsa.Text = ""
            txtcomisionsin.Text = ""
            txtcomentario.Text = ""
            txtcosto.Text = ""
            txtretencion.Text = ""
            lblporsa2.Text = "%"
            lblporsin2.Text = "%"
            txtsindicato2.Text = ""
            txtsa2.Text = ""
            txtcomisionsa2.Text = ""
            txtcomisionsin2.Text = ""
            txtcomentario2.Text = ""
            txtcosto2.Text = ""
            txtretencion2.Text = ""
            gIdFacturasnomina = ""
            gidFacturasnomina2 = ""
            chkflujo.Checked = False
            txtisr.Text = ""
            txtisr2.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Sub limpiarfacturas()
        Try
            cboempresa.SelectedIndex = 0

            txtimporte.Text = ""
            txtiva.Text = ""
            txttotal.Text = ""
            txtfactura.Text = ""
            txtimporte.Enabled = True
            txtiva.Enabled = True
            txttotal.Enabled = True
            txtfactura.Enabled = True
            cboempresa.Enabled = True
            cbocliente.Enabled = True
            cbocliente.SelectedIndex = 0
        Catch ex As Exception

        End Try



    End Sub

    Private Sub txtfactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfactura.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtiva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtiva.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtsa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsa.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txttotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotal.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub cmdagregar_Click(sender As Object, e As EventArgs) Handles cmdagregar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim item As ListViewItem
        Dim Alter As Boolean = False

        Try

            'Validar
            If txtfactura.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el numero de factura"
            End If
            If txtimporte.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el importe"
            End If
            If txtiva.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el iva"
            End If
            If txttotal.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el total"
            End If
            'If txtsa.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Por favor indique la dispersión por sa"
            'End If
            'If txtsindicato.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Por favor indique la dispersión por sindicato"
            'End If
            'If txtcosto.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Por favor indique el costo social"
            'End If
            'If txtretencion.Text.Trim.Length = 0 And Mensaje = "" Then
            '    Mensaje = "Por favor indique la retencion"
            'End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            item = lsvfacturas.Items.Add("(" & cboempresa.SelectedValue & ")" & cboempresa.Text)
            item.SubItems.Add("(" & cbocliente.SelectedValue & ")" & cbocliente.Text)
            item.SubItems.Add(txtfactura.Text)
            item.SubItems.Add(txtimporte.Text)
            item.SubItems.Add(txtiva.Text)
            item.SubItems.Add(txttotal.Text)
            item.SubItems.Add(Date.Now.ToShortDateString)
            'totalfactura = totalfactura + txttotal.Text
            txttotalf.Text = (Double.Parse(txttotal.Text) + Double.Parse(txttotalf.Text)).ToString()

            item.Tag = 0

            item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
            Alter = Not Alter


            'If blnNuevo Then
            '    'Insertar nuevo
            '    SQL = "EXEC setcontrolInsertar 0," & cboempresa.SelectedValue & "," & cbocliente.SelectedValue
            '    SQL &= "," & IIf(txtfactura.Text = "", 0, txtfactura.Text) & "," & gIdFactura & ",0," & cbotipoperiodo.SelectedValue
            '    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
            '    SQL &= "'," & IIf(txtimporte.Text = "", 0, txtimporte.Text)
            '    SQL &= "," & IIf(txtiva.Text = "", 0, txtiva.Text)
            '    SQL &= "," & IIf(txttotal.Text = "", 0, txttotal.Text)
            '    SQL &= "," & IIf(txtsa.Text = "", 0, txtsa.Text) & "," & porcentajesa & "," & txtcomisionsa.Text
            '    SQL &= "," & porcentajesin & "," & txtcomisionsin.Text
            '    SQL &= ",'" & Date.Now.ToShortDateString() & "'," & IIf(txtsindicato.Text = "", 0, txtsindicato.Text)
            '    SQL &= "," & IIf(txtcosto.Text = "", 0, txtcosto.Text) & "," & IIf(txtretencion.Text = "", 0, txtretencion.Text)



            'Else
            '    'Actualizar
            '    'SQL = "EXEC setcontrolActualizar " & gIdFactura & "," & cboempresa.SelectedValue & "," & cbocliente.SelectedValue
            '    'SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
            '    'SQL &= "'," & IIf(txtnumfactura.Text = "", 0, txtnumfactura.Text)
            '    'SQL &= "," & IIf(txtimporte.Text = "", 0, txtimporte.Text)
            '    'SQL &= "," & IIf(txtiva.Text = "", 0, txtiva.Text)
            '    'SQL &= "," & IIf(txttotal.Text = "", 0, txttotal.Text)
            '    'SQL &= ",'" & txtpago.Text & "','" & txtcomentario.Text & "'," & IIf(chkActivo.Checked, 1, 0)
            '    'SQL &= ",'" & UsuarioCreador & "','" & nombresistema
            '    'SQL &= "'," & IIf(cboestatus.SelectedIndex = 0, 1, 0)




            'End If

            'If nExecute(SQL) = False Then
            '    Exit Sub
            'End If

            'MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'cargarlista()
            limpiarfacturas()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarlista()
        Dim contador As Integer
        Dim SQL As String, Alter As Boolean = False
        Dim aID As String()
        Dim promotor As String = ""

        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        If (tiempo.Days >= 0) Then
            SQL = "Select iIdFacturasNomina, fkiIdEmpresa,empresa.nombre As nombreempresa  ,fkiIdcliente, "
            SQL &= "clientes.nombre As nombrecliente,fkiIdPromotor,fkiIdTipoperiodo,  tipos_periodos2.nombre as tipoperiodo,"
            SQL &= "fechapago, "
            SQL &= "dispersa, porsa, comisionsa, dispersindicato, FacturasNomina.porsindicato, comisionsin,costosocial,retencion"
            SQL &= " from((FacturasNomina inner Join empresa on FacturasNomina.fkiIdEmpresa= empresa.iIdEmpresa) "
            SQL &= " inner Join clientes On FacturasNomina.fkiIdcliente =  clientes.iIdCliente )"
            SQL &= " inner join tipos_periodos2 on FacturasNomina.fkiIdTipoperiodo = tipos_periodos2.iIdTipoperiodo2"
            SQL &= " where FacturasNomina.iEstatus=1 and fkiIdEmpresa =" & cboempresa2.SelectedValue
            SQL &= " and fechapago between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
            SQL &= " order by iIdFacturasNomina desc "

            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem



            lsvLista.Items.Clear()
            lsvLista.Clear()

            lsvLista.Columns.Add("Promotor")
            lsvLista.Columns(0).Width = 300
            lsvLista.Columns.Add("Periodo")
            lsvLista.Columns(1).Width = 100
            lsvLista.Columns.Add("Cliente")
            lsvLista.Columns(2).Width = 300
            lsvLista.Columns.Add("Empresa patrona")
            lsvLista.Columns(3).Width = 300
            lsvLista.Columns.Add("Dispersion SA")
            lsvLista.Columns(4).Width = 100
            lsvLista.Columns.Add("% SA")
            lsvLista.Columns(5).Width = 100
            lsvLista.Columns.Add("Comisión SA")
            lsvLista.Columns(6).Width = 100
            lsvLista.Columns.Add("Dispersion Sindicato")
            lsvLista.Columns(7).Width = 100
            lsvLista.Columns.Add("% Sindicato")
            lsvLista.Columns(8).Width = 100
            lsvLista.Columns.Add("Comisión Sindicato")
            lsvLista.Columns(9).Width = 100
            lsvLista.Columns.Add("Costo social")
            lsvLista.Columns(10).Width = 100
            lsvLista.Columns.Add("Retención IMSS")
            lsvLista.Columns(11).Width = 100


            contador = 0

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    contador = contador + 1

                    aID = Fila.Item("fkiIdPromotor").Split(",")
                    If aID.Length = 1 Then
                        promotor = obtenerpromotor(aID(0))

                    ElseIf aID.Length = 2 Then
                        promotor = obtenerpromotor(aID(0))
                        If aID(1) <> "" Then
                            promotor &= "," & obtenerpromotor(aID(1))
                        End If


                    ElseIf aID.Length = 3 Then
                        promotor = obtenerpromotor(aID(0))
                        If aID(1) <> "" Then
                            promotor &= "," & obtenerpromotor(aID(1))
                        End If

                        If aID(2) <> "" Then
                            promotor &= "," & obtenerpromotor(aID(2))
                        End If
                    End If

                    item = lsvLista.Items.Add(promotor)
                    item.SubItems.Add("" & Fila.Item("tipoperiodo"))
                    item.SubItems.Add("" & Fila.Item("nombrecliente"))
                    item.SubItems.Add("" & Fila.Item("nombreempresa"))
                    item.SubItems.Add("" & Fila.Item("dispersa"))
                    item.SubItems.Add("" & Fila.Item("porsa"))
                    item.SubItems.Add("" & Fila.Item("comisionsa"))
                    item.SubItems.Add("" & Fila.Item("dispersindicato"))
                    item.SubItems.Add("" & Fila.Item("porsindicato"))
                    item.SubItems.Add("" & Fila.Item("comisionsin"))
                    item.SubItems.Add("" & Fila.Item("costosocial"))
                    item.SubItems.Add("" & Fila.Item("retencion"))
                    item.Tag = Fila.Item("iIdFacturasNomina")
                    item.ToolTipText = Fila.Item("iIdFacturasNomina")
                    item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter

                Next
            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If




            If lsvLista.Items.Count > 0 Then
                lsvLista.Focus()
                lsvLista.Items(0).Selected = True
                MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'txtbuscar.Focus()
                'txtbuscar.SelectAll()
            End If
        Else
            MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
    Private Function obtenerpromotor(id As String) As String
        Dim nombre As String = ""

        Try
            SQL = "select * from promotor where iIdPromotor= " & id
            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombre = (Fila.Item("nombrecom"))

            End If

        Catch ex As Exception

        End Try
        Return nombre
    End Function

    Private Sub cbocliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocliente.SelectedIndexChanged



    End Sub

    Private Sub txtsa_TextChanged(sender As Object, e As EventArgs) Handles txtsa.TextChanged


    End Sub

    Private Sub txtsa_LostFocus(sender As Object, e As EventArgs) Handles txtsa.LostFocus
        'Calcular % sa y sindicato
        Calcularcomision()
        txtsa.Text = Format(CType(IIf(txtsa.Text = "", "0", txtsa.Text), Decimal), "###,###,##0.#0")
    End Sub
    Private Sub Calcularcomision()
        'If Double.Parse(txttotalf.Text) > 0 And txtsa.Text <> "" Then
        'If Double.Parse(IIf(txtsa.Text = "", 0, txtsa.Text)) > Double.Parse(txttotalf.Text) Then
        '    MessageBox.Show("La dispersion por nomina no puede ser mayor al total de la factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    txtcomisionsa.Text = Double.Parse(IIf(txtsa.Text = "", 0, txtsa.Text)) * (porcentajesa / 100)

        'End If
        'End If
        'If Double.Parse(txttotalf.Text) > 0 And txtsa2.Text <> "" Then
        'If Double.Parse(If(txtsa2.Text = "", 0, txtsa2.Text)) > Double.Parse(txttotalf.Text) Then
        '    MessageBox.Show("La dispersion por nomina no puede ser mayor al total de la factura", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else

        '    txtcomisionsa2.Text = Double.Parse(IIf(txtsa2.Text = "", 0, txtsa2.Text)) * (porcentajesa / 100)
        'End If
        'End If

        If txtsa.Text <> "" Then
            txtcomisionsa.Text = Double.Parse(IIf(txtsa.Text = "", 0, txtsa.Text)) * (porcentajesa / 100)
        End If
        If txtsa2.Text <> "" Then
            txtcomisionsa2.Text = Double.Parse(IIf(txtsa2.Text = "", 0, txtsa2.Text)) * (porcentajesa / 100)
        End If
        If txtsindicato.Text <> "" Then
            txtcomisionsin.Text = Double.Parse(txtsindicato.Text) * (porcentajesin / 100)
        End If
        If txtsindicato2.Text <> "" Then
            txtcomisionsin2.Text = Double.Parse(txtsindicato2.Text) * (porcentajesin / 100)
        End If
    End Sub

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs)
        Dim forma As New frmfiltro
        forma.ShowDialog()
        'Dim apExcel = New Microsoft.Office.Interop.Excel.Application
        'Dim libro = apExcel.Workbooks.Add
        'Dim dialogo As New SaveFileDialog()
        'Dim SQL As String, Alter As Boolean = False
        'Dim aID As String()
        'Dim promotor As String = ""
        'Dim filaExcel As Integer = 4

        'SQL = "Select iIdControl, fkiIdEmpresa,empresa.nombre As nombreempresa  ,fkiIdcliente, "
        'SQL &= "clientes.nombre As nombrecliente,fkiIdPromotor,fkiIdTipoperiodo2,  tipos_periodos2.nombre as tipoperiodo,"
        'SQL &= "fechapago, numfactura, importe, iva, total, "
        'SQL &= "dispernomina, porsa, comisionsa, control.porsindicato, comisionsin"
        'SQL &= " from((control inner Join empresa on control.fkiIdEmpresa= empresa.iIdEmpresa) "
        'SQL &= " inner Join clientes On control.fkiIdcliente =  clientes.iIdCliente )"
        'SQL &= " inner join tipos_periodos2 on control.fkiIdTipoperiodo2 = tipos_periodos2.iIdTipoperiodo2"
        'SQL &= " order by fkiIdPromotor,tipoperiodo,nombrecliente,nombreempresa "

        'Dim rwFilas As DataRow() = nConsulta(SQL)
        'If rwFilas Is Nothing = False Then

        '    libro.Sheets(1).cells(2, 2) = "Promotor"
        '    libro.Sheets(1).cells(2, 3) = "Periodo"
        '    libro.Sheets(1).cells(2, 4) = "Cliente"
        '    libro.Sheets(1).cells(2, 5) = "Empresa"
        '    libro.Sheets(1).cells(2, 6) = "Subtotal"
        '    libro.Sheets(1).cells(2, 7) = "Iva"
        '    libro.Sheets(1).cells(2, 8) = "Total"
        '    libro.Sheets(1).cells(2, 9) = "Dispersion Nomina"
        '    libro.Sheets(1).cells(2, 10) = "% SA"
        '    libro.Sheets(1).cells(2, 11) = "Comisión SA"
        '    libro.Sheets(1).cells(2, 12) = "% Sindicato"
        '    libro.Sheets(1).cells(2, 13) = "Comisión Sindicato"

        '    filaExcel = 3
        '    For Each Fila In rwFilas
        '        filaExcel = filaExcel + 1

        '        aID = Fila.Item("fkiIdPromotor").Split(",")
        '        If aID.Length = 1 Then
        '            promotor = obtenerpromotor(aID(0))

        '        ElseIf aID.Length = 2 Then
        '            promotor = obtenerpromotor(aID(0))
        '            promotor &= "," & obtenerpromotor(aID(1))

        '        ElseIf aID.Length = 3 Then
        '            promotor = obtenerpromotor(aID(0))
        '            promotor &= "," & obtenerpromotor(aID(1))
        '            promotor &= "," & obtenerpromotor(aID(2))
        '        End If

        '        libro.Sheets(1).cells(filaExcel, 2) = promotor
        '        libro.Sheets(1).cells(filaExcel, 3) = Fila.Item("tipoperiodo")
        '        libro.Sheets(1).cells(filaExcel, 4) = Fila.Item("nombrecliente")
        '        libro.Sheets(1).cells(filaExcel, 5) = Fila.Item("nombreempresa")
        '        libro.Sheets(1).cells(filaExcel, 6) = Fila.Item("importe")
        '        libro.Sheets(1).cells(filaExcel, 7) = Fila.Item("iva")
        '        libro.Sheets(1).cells(filaExcel, 8) = Fila.Item("total")
        '        libro.Sheets(1).cells(filaExcel, 9) = Fila.Item("dispernomina")
        '        libro.Sheets(1).cells(filaExcel, 10) = Fila.Item("porsa")
        '        libro.Sheets(1).cells(filaExcel, 11) = Fila.Item("comisionsa")
        '        libro.Sheets(1).cells(filaExcel, 12) = Fila.Item("porsindicato")
        '        libro.Sheets(1).cells(filaExcel, 13) = Fila.Item("comisionsin")




        '    Next

        '    dialogo.DefaultExt = "*.xlsx"
        '    dialogo.FileName = "Control tesoreria"
        '    dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
        '    dialogo.ShowDialog()

        '    libro.SaveAs(dialogo.FileName)
        '    apExcel.Quit()
        '    libro = Nothing
        'Else
        '    MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If




    End Sub

    Private Sub txtsindicato_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsindicato.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcosto.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtretencion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtretencion.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles cmdlimpiar.Click
        lsvfacturas.Items.Clear()

    End Sub

    Private Sub cbocliente2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocliente2.SelectedIndexChanged
        Try
            SQL = "select * from clientes where iIdCliente = " & cbocliente2.SelectedValue
            Dim aID As String()
            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                aID = Fila.Item("fkiIdPromotor").Split(",")
                If aID.Length = 1 Then
                    cbopromotor.SelectedValue = aID(0)
                    'IIf(aID(0) = "", cbopromotor.SelectedValue = 1, cbopromotor.SelectedValue = aID(0))
                ElseIf aID.Length = 2 Then
                    cbopromotor.SelectedValue = aID(0)
                    cbopromotor2.SelectedValue = aID(1)

                    'IIf(aID(0) = "", cbopromotor.SelectedValue = 1, cbopromotor.SelectedValue = aID(0))
                    'IIf(aID(1) = "", cbopromotor2.SelectedValue = 1, cbopromotor2.SelectedValue = aID(1))
                ElseIf aID.Length = 3 Then
                    cbopromotor.SelectedValue = aID(0)
                    cbopromotor2.SelectedValue = aID(1)
                    cbopromotor3.SelectedValue = aID(2)
                    'IIf(aID(0) = "", cbopromotor.SelectedValue = 1, cbopromotor.SelectedValue = aID(0))
                    'IIf(aID(1) = "", cbopromotor2.SelectedValue = 1, cbopromotor2.SelectedValue = aID(1))
                    'IIf(aID(2) = "", cbopromotor3.SelectedValue = 1, cbopromotor3.SelectedValue = aID(2))
                End If
                'cbopromotor.SelectedValue = aiD(0)
                'cbopromotor2.SelectedValue = aiD(1)
                'cbopromotor3.SelectedValue = aID(2)
                If (Fila.Item("iTipoPor") = "0") Then
                    Label9.Text = Fila.Item("porcentaje") & " %"
                    lblporsa2.Text = Fila.Item("porcentaje") & " %"
                    porcentajesa = Fila.Item("porcentaje")
                    Label12.Text = Fila.Item("porsindicato") & " %"
                    lblporsin2.Text = Fila.Item("porsindicato") & " %"
                    porcentajesin = Fila.Item("porsindicato")
                Else
                    Label9.Text = Fila.Item("porcentaje") & " %"
                    porcentajesa = Fila.Item("porcentaje")

                    Label12.Text = "0 %"
                    lblporsin2.Text = "0 %"
                    porcentajesin = 0


                End If
                Calcularcomision()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub dtpfecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpfecha.ValueChanged

    End Sub

    Private Sub lsvfacturas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvfacturas.SelectedIndexChanged

    End Sub

    Private Sub txttotalf_TextChanged(sender As Object, e As EventArgs) Handles txttotalf.TextChanged
        Calcularcomision()
    End Sub

    Private Sub cmdlista_Click(sender As Object, e As EventArgs) Handles cmdlista.Click
        Dim forma As New frmfiltro
        forma.ShowDialog()
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim numerodefacturas As String()
        Dim sa, sindicato, comisionsa, comisionsin, costo, retencion As String
        Dim sa2, sindicato2, comisionsa2, comisionsin2, costo2, retencion2 As String
        Dim isr, isr2 As String
        Dim IdFactura1 As String
        Dim idFactura2 As String
        Dim detFactura, sID As String
        IdFactura1 = ""
        idFactura2 = ""
        detFactura = ""
        sID = ""

        Dim Alter As Boolean = False

        Try

            'Validar
            If txtsa.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique la dispersión por patrona"
            End If
            If txtcosto.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el costo social"
            End If
            If txtsindicato.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique la dispersion por sindicato"
            End If
            If txtretencion.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique la retención de imss"
            End If



            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwUsuario As DataRow() = nConsulta(SQL)

            If rwUsuario Is Nothing = False Then
                Dim Fila As DataRow = rwUsuario(0)
                nombresistema = Fila.Item("nombre")
            End If
            DetCadena = ""

            sa = IIf(txtsa.Text = "", 0, (txtsa.Text.Replace(",", "")).Replace("$", "").Trim)
            comisionsa = IIf(txtcomisionsa.Text = "", 0, (txtcomisionsa.Text.Replace(",", "")).Replace("$", "").Trim)
            sindicato = IIf(txtsindicato.Text = "", 0, (txtsindicato.Text.Replace(",", "")).Replace("$", "").Trim)
            comisionsin = IIf(txtcomisionsin.Text = "", 0, (txtcomisionsin.Text.Replace(",", "")).Replace("$", "").Trim)
            costo = IIf(txtcosto.Text = "", 0, (txtcosto.Text.Replace(",", "")).Replace("$", "").Trim)
            retencion = IIf(txtretencion.Text = "", 0, (txtretencion.Text.Replace(",", "")).Replace("$", "").Trim)
            isr = IIf(txtisr.Text = "", 0, (txtisr.Text.Replace(",", "")).Replace("$", "").Trim)

            sa2 = IIf(txtsa2.Text = "", 0, (txtsa2.Text.Replace(",", "")).Replace("$", "").Trim)
            comisionsa2 = IIf(txtcomisionsa2.Text = "", 0, (txtcomisionsa2.Text.Replace(",", "")).Replace("$", "").Trim)
            sindicato2 = IIf(txtsindicato2.Text = "", 0, (txtsindicato2.Text.Replace(",", "")).Replace("$", "").Trim)
            comisionsin2 = IIf(txtcomisionsin2.Text = "", 0, (txtcomisionsin2.Text.Replace(",", "")).Replace("$", "").Trim)
            costo2 = IIf(txtcosto2.Text = "", 0, (txtcosto2.Text.Replace(",", "")).Replace("$", "").Trim)
            retencion2 = IIf(txtretencion2.Text = "", 0, (txtretencion2.Text.Replace(",", "")).Replace("$", "").Trim)
            isr2 = IIf(txtisr2.Text = "", 0, (txtisr2.Text.Replace(",", "")).Replace("$", "").Trim)

            If blnNuevo Then
                'Insertar nuevo


                SQL = "EXEC setFacturasNominaInsertar 0," & cboempresa2.SelectedValue & "," & cbocliente2.SelectedValue
                SQL &= "," & cbotipoperiodo.SelectedValue
                SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & sa
                SQL &= "," & porcentajesa
                SQL &= "," & comisionsa
                SQL &= "," & sindicato & "," & porcentajesin & "," & comisionsin
                SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                SQL &= "," & costo & "," & retencion
                SQL &= ",1,'" & nombresistema & "','" & txtcomentario.Text & "'," & IIf(chkflujo.Checked = True, 1, 0)
                SQL &= "," & isr

                If Execute(SQL, IdFactura1) = False Then

                    MessageBox.Show("Ocurrio un error setFacturasNominaInsertar 1 ," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

                For Each facturaitem As ListViewItem In lsvfacturas.Items
                    If facturaitem.Tag = "0" Then
                        SQL = "EXEC setDetNominaFacturaInsertar   0,0"
                        SQL &= "," & Mid(facturaitem.SubItems(0).Text, 2, (InStr(facturaitem.SubItems(0).Text, ")") - 2))
                        SQL &= "," & Mid(facturaitem.SubItems(1).Text, 2, InStr(facturaitem.SubItems(1).Text, ")") - 2)
                        SQL &= "," & facturaitem.SubItems(2).Text.Replace(",", "").Replace("$", "").Trim & "," & facturaitem.SubItems(3).Text.Replace(",", "").Replace("$", "").Trim
                        SQL &= "," & facturaitem.SubItems(4).Text.Replace(",", "").Replace("$", "").Trim & "," & facturaitem.SubItems(5).Text.Replace(",", "").Replace("$", "").Trim
                        SQL &= ",'','" & facturaitem.SubItems(6).Text.Replace(",", "").Replace("$", "").Trim & "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                        SQL &= "'," & IdFactura1 & ",1"

                        If Execute(SQL, detFactura) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        If DetCadena = "" Then
                            DetCadena = detFactura
                        Else
                            DetCadena &= "," & detFactura
                        End If

                    Else
                        SQL = "select * from facturas where iIdFactura=" & facturaitem.Tag
                        Dim rwFactura As DataRow() = nConsulta(SQL)
                        If rwFactura Is Nothing = False Then
                            Dim Factura As DataRow = rwFactura(0)
                            SQL = "EXEC setDetNominaFacturaInsertar   0," & Factura.Item("iIdFactura")
                            SQL &= "," & Factura.Item("fkiIdEmpresa") & "," & Factura.Item("fkiIdCliente")
                            SQL &= "," & Factura.Item("numfactura") & "," & Factura.Item("importe")
                            SQL &= "," & Factura.Item("iva") & "," & Factura.Item("total")
                            SQL &= ",'','" & Factura.Item("fecha") & "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                            SQL &= "'," & IdFactura1 & ",1"

                            If Execute(SQL, detFactura) = False Then
                                MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If DetCadena = "" Then
                                DetCadena = detFactura
                            Else
                                DetCadena &= "," & detFactura
                            End If



                        End If
                    End If


                Next
                'End If


                'guardamos la intermedia
                numerodefacturas = DetCadena.Split(",")
                For x As Integer = 0 To numerodefacturas.Length - 1
                    SQL = "EXEC setInterFacturasNominaInsertar 0," & numerodefacturas(x) & "," & IdFactura1
                    If nExecute(SQL) = False Then

                        MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Next





                If (txtsa2.Text <> "0.00" And txtsa2.Text <> "0" And txtsa2.Text <> "") Or (txtsindicato2.Text <> "0.00" And txtsindicato2.Text <> "0" And txtsindicato2.Text <> "") Then
                    SQL = "EXEC setFacturasNominaInsertar 0," & cbopatrona2.SelectedValue & "," & cbocliente2.SelectedValue
                    SQL &= "," & cbotipoperiodo.SelectedValue
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & sa2
                    SQL &= "," & porcentajesa 'ver de donde sale
                    SQL &= "," & comisionsa2
                    SQL &= "," & sindicato2 & "," & porcentajesin & "," & comisionsin2
                    SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                    SQL &= "," & costo2 & "," & retencion2
                    SQL &= ",1,'" & nombresistema & "','" & txtcomentario2.Text & "'," & IIf(chkflujo.Checked = True, 1, 0)
                    SQL &= "," & isr2

                    If Execute(SQL, idFactura2) = False Then
                        MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                    numerodefacturas = DetCadena.Split(",")
                    For x As Integer = 0 To numerodefacturas.Length - 1
                        SQL = "EXEC setInterFacturasNominaInsertar 0," & numerodefacturas(x) & "," & idFactura2
                        If nExecute(SQL) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Next




                End If



            Else
                'Actualizar
                SQL = "EXEC setFacturasNominaActualizar " & gIdFacturasnomina & "," & cboempresa2.SelectedValue & "," & cbocliente2.SelectedValue
                SQL &= "," & cbotipoperiodo.SelectedValue
                SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & sa
                SQL &= "," & porcentajesa
                SQL &= "," & comisionsa
                SQL &= "," & sindicato & "," & porcentajesin & "," & comisionsin
                SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                SQL &= "," & costo & "," & retencion
                SQL &= ",1,'" & nombresistema & "','" & txtcomentario.Text & "'," & IIf(chkflujo.Checked = True, 1, 0)
                SQL &= "," & isr

                If nExecute(SQL) = False Then

                    MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If (txtsa2.Text <> "0.00" And txtsa2.Text <> "0" And txtsa2.Text <> "") Or (txtsindicato2.Text <> "0.00" And txtsindicato2.Text <> "0" And txtsindicato2.Text <> "") Then
                    If gidFacturasnomina2 = "" Then
                        SQL = "EXEC setFacturasNominaInsertar 0," & cbopatrona2.SelectedValue & "," & cbocliente2.SelectedValue
                        SQL &= "," & cbotipoperiodo.SelectedValue
                        SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                        SQL &= "'," & sa2
                        SQL &= "," & porcentajesa 'ver de donde sale
                        SQL &= "," & comisionsa2
                        SQL &= "," & sindicato2 & "," & porcentajesin & "," & comisionsin2
                        SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                        SQL &= "," & costo2 & "," & retencion2
                        SQL &= ",1,'" & nombresistema & "','" & txtcomentario2.Text & "'," & IIf(chkflujo.Checked = True, 1, 0)
                        SQL &= "," & isr2
                        If Execute(SQL, idFactura2) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Else
                        SQL = "EXEC setFacturasNominaActualizar " & gidFacturasnomina2 & "," & cbopatrona2.SelectedValue & "," & cbocliente2.SelectedValue
                        SQL &= "," & cbotipoperiodo.SelectedValue
                        SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                        SQL &= "'," & sa2
                        SQL &= "," & porcentajesa
                        SQL &= "," & comisionsa2
                        SQL &= "," & sindicato2 & "," & porcentajesin & "," & comisionsin2
                        SQL &= ",'" & Date.Now.ToShortDateString() & "'"
                        SQL &= "," & costo2 & "," & retencion2
                        SQL &= ",1,'" & nombresistema & "','" & txtcomentario2.Text & "'," & IIf(chkflujo.Checked = True, 1, 0)
                        SQL &= "," & isr2

                        If nExecute(SQL) = False Then

                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If
                    End If




                End If





                SQL = "delete from DetNominaFactura where iIdDetNominaFactura in ("

                SQL &= "select Distinct(iIdDetNominaFactura) from (DetNominaFactura inner join"
                SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                SQL &= " where  iIdFacturasNomina =" & gIdFacturasnomina & "))"
                If nExecute(SQL) = False Then

                    MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                SQL = "delete from InterFacturasNomina where fkiIdFacturasNomina=" & gIdFacturasnomina
                If nExecute(SQL) = False Then

                    MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If gidFacturasnomina2 <> "" Then
                    SQL = "delete from InterFacturasNomina where fkiIdFacturasNomina=" & gidFacturasnomina2

                    If nExecute(SQL) = False Then

                        MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If





                For Each facturaitem As ListViewItem In lsvfacturas.Items
                    If facturaitem.Tag = "0" Then
                        SQL = "EXEC setDetNominaFacturaInsertar   0,0"
                        SQL &= "," & Mid(facturaitem.SubItems(0).Text, 2, (InStr(facturaitem.SubItems(0).Text, ")") - 2))
                        SQL &= "," & Mid(facturaitem.SubItems(1).Text, 2, InStr(facturaitem.SubItems(1).Text, ")") - 2)
                        SQL &= "," & facturaitem.SubItems(2).Text.Replace(",", "").Replace("$", "").Trim & "," & facturaitem.SubItems(3).Text.Replace(",", "").Replace("$", "").Trim
                        SQL &= "," & facturaitem.SubItems(4).Text.Replace(",", "").Replace("$", "").Trim & "," & facturaitem.SubItems(5).Text.Replace(",", "").Replace("$", "").Trim
                        SQL &= ",'','" & facturaitem.SubItems(6).Text.Replace(",", "").Replace("$", "").Trim & "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                        SQL &= "'," & gIdFacturasnomina & ",1"

                        If Execute(SQL, detFactura) = False Then
                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        If DetCadena = "" Then
                            DetCadena = detFactura
                        Else
                            DetCadena &= "," & detFactura
                        End If

                    Else
                        SQL = "select * from facturas where iIdFactura=" & facturaitem.Tag
                        Dim rwFactura As DataRow() = nConsulta(SQL)
                        If rwFactura Is Nothing = False Then
                            Dim Factura As DataRow = rwFactura(0)
                            SQL = "EXEC setDetNominaFacturaInsertar   0," & Factura.Item("iIdFactura")
                            SQL &= "," & Factura.Item("fkiIdEmpresa") & "," & Factura.Item("fkiIdCliente")
                            SQL &= "," & Factura.Item("numfactura") & "," & Factura.Item("importe")
                            SQL &= "," & Factura.Item("iva") & "," & Factura.Item("total")
                            SQL &= ",'','" & Factura.Item("fecha") & "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                            SQL &= "'," & gIdFacturasnomina & ",1"

                            If Execute(SQL, detFactura) = False Then
                                MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If DetCadena = "" Then
                                DetCadena = detFactura
                            Else
                                DetCadena &= "," & detFactura
                            End If



                        End If
                    End If


                Next

                'guardamos la intermedia
                numerodefacturas = DetCadena.Split(",")
                For x As Integer = 0 To numerodefacturas.Length - 1
                    SQL = "EXEC setInterFacturasNominaInsertar 0," & numerodefacturas(x) & "," & gIdFacturasnomina
                    If nExecute(SQL) = False Then

                        MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Next

                If (txtsa2.Text <> "0.00" And txtsa2.Text <> "0" And txtsa2.Text <> "") Or (txtsindicato2.Text <> "0.00" And txtsindicato2.Text <> "0" And txtsindicato2.Text <> "") Then
                    If gidFacturasnomina2 = "" Then
                        For x As Integer = 0 To numerodefacturas.Length - 1
                            SQL = "EXEC setInterFacturasNominaInsertar 0," & numerodefacturas(x) & "," & idFactura2
                            If nExecute(SQL) = False Then

                                MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        Next
                    Else
                        For x As Integer = 0 To numerodefacturas.Length - 1
                            SQL = "EXEC setInterFacturasNominaInsertar 0," & numerodefacturas(x) & "," & gidFacturasnomina2
                            If nExecute(SQL) = False Then

                                MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        Next
                    End If


                End If



            End If




            lsvfacturas.Items.Clear()
            limpiarfacturas()
            limpiar()

            DetCadena = ""
            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            cargarlista()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged
        'MessageBox.Show("indice seleccionado" & lsvLista.SelectedItems(0).SubItems(0).Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        EditarControl(lsvLista.SelectedItems(0).Tag)
    End Sub

    Private Sub EditarControl(id As String)

        Dim Alter As Boolean = False
        limpiar()
        limpiarfacturas()




        Try
            SQL = "select Distinct(iIdFacturasNomina) from (DetNominaFactura inner join"
            SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
            SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
            SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
            SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
            SQL &= " where  iIdFacturasNomina =" & id & ")"

            Dim rwIdPatronas As DataRow() = nConsulta(SQL)
            If rwIdPatronas Is Nothing = False Then

                For x As Integer = 0 To rwIdPatronas.Count - 1
                    SQL = "select * from FacturasNomina where  iIdFacturasNomina =" & rwIdPatronas(x).Item("iIdFacturasNomina")
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    If rwFilas Is Nothing = False Then
                        blnNuevo = False
                        Dim Fila As DataRow = rwFilas(0)

                        If x = 0 Then
                            cbocliente2.SelectedValue = Fila.Item("fkiIdcliente")
                            If Fila.Item("iFlujo") = 1 Then
                                chkflujo.Checked = True
                            Else
                                chkflujo.Checked = False
                            End If
                            cboempresa2.SelectedValue = Fila.Item("fkiIdEmpresa")
                            cbocliente2.SelectedValue = Fila.Item("fkiIdcliente")
                            cbotipoperiodo.SelectedValue = Fila.Item("fkiIdTipoPeriodo")
                            dtpfecha.Value = Fila.Item("fechapago")
                            txtsa.Text = Fila.Item("dispersa")
                            Label9.Text = Fila.Item("porsa") & " %"
                            txtcomisionsa.Text = Fila.Item("comisionsa")
                            txtsindicato.Text = Fila.Item("dispersindicato")
                            Label12.Text = Fila.Item("porsindicato") & " %"
                            txtcomisionsin.Text = Fila.Item("comisionsin")
                            txtcosto.Text = Fila.Item("costosocial")
                            txtretencion.Text = Fila.Item("retencion")
                            txtcomentario.Text = Fila.Item("observacion")
                            txtisr.Text = Fila.Item("isr")

                            gIdFacturasnomina = rwIdPatronas(x).Item("iIdFacturasNomina")


                            'Cargar detalle de facturas

                            ' cargar lista de facturas
                            lsvfacturas.Items.Clear()
                            SQL = "Select iIdDetNominaFactura,fkiIdFactura,numfactura,importe,iva,total,fechafac,empresa.nombre as empresa, "
                            SQL &= "clientes.nombre as cliente,DetNominaFactura.fkiIdEmpresa,DetNominaFactura.fkiIdCliente from (Detnominafactura inner join empresa on fkiIdEmpresa=iIdEmpresa) "
                            SQL &= " inner join clientes on fkiIdCliente = iIdCliente where  iIdDetNominaFactura in"
                            SQL &= "(select Distinct(iIdDetNominaFactura) "
                            SQL &= " from (DetNominaFactura"
                            SQL &= " inner join interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura) "
                            SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina "
                            SQL &= " where  iIdDetNominaFactura in "
                            SQL &= " (select fkIIdDetNominaFactura from FacturasNomina"
                            SQL &= " inner join InterFacturasNomina On iIdFacturasNomina= fkiIdFacturasNomina "
                            SQL &= " where  iIdFacturasNomina = " & id & "))"



                            Dim rwFactura As DataRow() = nConsulta(SQL)
                            Dim itemfactura As ListViewItem

                            If rwFactura Is Nothing = False Then
                                For Each Fila In rwFactura



                                    itemfactura = lsvfacturas.Items.Add("(" & Fila.Item("fkiIdEmpresa") & ")" & Fila.Item("empresa"))
                                    itemfactura.SubItems.Add("(" & Fila.Item("fkiIdCliente") & ")" & Fila.Item("cliente"))
                                    'VErificamos si la factura tiene numero
                                    SQL = "select * from Facturas where  iIdFactura =" & Fila.Item("fkiIdFactura")
                                    Dim rwIDFactura As DataRow() = nConsulta(SQL)
                                    If rwIDFactura Is Nothing = False Then
                                        itemfactura.SubItems.Add(rwIDFactura(0).Item("numfactura"))
                                    End If


                                    itemfactura.SubItems.Add(Fila.Item("importe"))
                                    itemfactura.SubItems.Add(Fila.Item("iva"))
                                    itemfactura.SubItems.Add(Fila.Item("total"))
                                    itemfactura.SubItems.Add(Fila.Item("fechafac"))
                                    'totalfactura = totalfactura + txttotal.Text
                                    txttotalf.Text = (Double.Parse(Fila.Item("total")) + Double.Parse(txttotalf.Text)).ToString()

                                    itemfactura.Tag = Fila.Item("fkiIdFactura")

                                    itemfactura.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                                    Alter = Not Alter


                                Next

                            End If

                        End If
                        If x = 1 Then
                            cbopatrona2.SelectedValue = Fila.Item("fkiIdEmpresa")
                            If Fila.Item("iFlujo") = 1 Then
                                chkflujo.Checked = True
                            Else
                                chkflujo.Checked = False
                            End If
                            cbopatrona2.SelectedValue = Fila.Item("fkiIdEmpresa")
                            'cbocliente2.SelectedValue = Fila.Item("fkiIdcliente")
                            'cbotipoperiodo.SelectedValue = Fila.Item("fkiIdTipoPeriodo")
                            'dtpfecha.Value = Fila.Item("fechapago")
                            txtsa2.Text = Fila.Item("dispersa")
                            lblporsa2.Text = Fila.Item("porsa") & " %"
                            txtcomisionsa2.Text = Fila.Item("comisionsa")
                            txtsindicato2.Text = Fila.Item("dispersindicato")
                            lblporsin2.Text = Fila.Item("porsindicato") & " %"
                            txtcomisionsin2.Text = Fila.Item("comisionsin")
                            txtcosto2.Text = Fila.Item("costosocial")
                            txtretencion2.Text = Fila.Item("retencion")
                            txtcomentario2.Text = Fila.Item("observacion")
                            txtisr2.Text = Fila.Item("isr")

                            gidFacturasnomina2 = rwIdPatronas(x).Item("iIdFacturasNomina")

                        End If


                    End If


                Next

                MessageBox.Show("Datos cargados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnNuevo = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        limpiar()
        limpiarfacturas()
        lsvfacturas.Items.Clear()
    End Sub

    Private Sub txtcomisionsin_TextChanged(sender As Object, e As EventArgs) Handles txtcomisionsin.TextChanged

    End Sub

    Private Sub txtcomisionsin_LostFocus(sender As Object, e As EventArgs) Handles txtcomisionsin.LostFocus

    End Sub

    Private Sub txtsindicato_TextChanged(sender As Object, e As EventArgs) Handles txtsindicato.TextChanged

    End Sub

    Private Sub txtsindicato_LostFocus(sender As Object, e As EventArgs) Handles txtsindicato.LostFocus
        Calcularcomision()
        txtsindicato.Text = Format(CType(IIf(txtsindicato.Text = "", "0", txtsindicato.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtcosto_TextChanged(sender As Object, e As EventArgs) Handles txtcosto.TextChanged

    End Sub

    Private Sub txtcosto_LostFocus(sender As Object, e As EventArgs) Handles txtcosto.LostFocus
        txtcosto.Text = Format(CType(IIf(txtcosto.Text = "", "0", txtcosto.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtretencion_TextChanged(sender As Object, e As EventArgs) Handles txtretencion.TextChanged

    End Sub

    Private Sub txtretencion_LostFocus(sender As Object, e As EventArgs) Handles txtretencion.LostFocus
        txtretencion.Text = Format(CType(IIf(txtretencion.Text = "", "0", txtretencion.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtimporte_TextChanged(sender As Object, e As EventArgs) Handles txtimporte.TextChanged

    End Sub

    Private Sub txtimporte_LostFocus(sender As Object, e As EventArgs) Handles txtimporte.LostFocus
        txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "0", txtimporte.Text), Decimal), "###,###,##0.#0")
        txtiva.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16
        txttotal.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) + (Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16)
        txtiva.Text = Format(CType(IIf(txtiva.Text = "", "0", txtiva.Text), Decimal), "###,###,##0.#0")
        txttotal.Text = Format(CType(IIf(txttotal.Text = "", "0", txttotal.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txttotal_TextChanged(sender As Object, e As EventArgs) Handles txttotal.TextChanged

    End Sub

    Private Sub txttotal_LostFocus(sender As Object, e As EventArgs) Handles txttotal.LostFocus
        txttotal.Text = Format(CType(IIf(txttotal.Text = "", "0", txttotal.Text), Decimal), "###,###,##0.#0")
        txtiva.Text = Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) - (Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) / 1.16)
        txtimporte.Text = Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) - (Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) - (Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) / 1.16))
        txtiva.Text = Format(CType(IIf(txtiva.Text = "", "0", txtiva.Text), Decimal), "###,###,##0.#0")
        txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "", txtimporte.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtsa2_TextChanged(sender As Object, e As EventArgs) Handles txtsa2.TextChanged

    End Sub

    Private Sub txtsa2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsa2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtsa2_LostFocus(sender As Object, e As EventArgs) Handles txtsa2.LostFocus
        Calcularcomision()
        txtsa2.Text = Format(CType(IIf(txtsa2.Text = "", "0", txtsa2.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtsindicato2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsindicato2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtsindicato2_LostFocus(sender As Object, e As EventArgs) Handles txtsindicato2.LostFocus
        Calcularcomision()
        txtsindicato2.Text = Format(CType(IIf(txtsindicato2.Text = "", "0", txtsindicato2.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtcosto2_LostFocus(sender As Object, e As EventArgs) Handles txtcosto2.LostFocus
        txtcosto2.Text = Format(CType(IIf(txtcosto2.Text = "", "0", txtcosto2.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtcosto2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcosto2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtretencion2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtretencion2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtretencion2_LostFocus(sender As Object, e As EventArgs) Handles txtretencion2.LostFocus
        txtretencion2.Text = Format(CType(IIf(txtretencion2.Text = "", "0", txtretencion2.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub cboempresa2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboempresa2.SelectedIndexChanged

        cargarlista()

    End Sub

    Private Sub cmborrar_Click(sender As Object, e As EventArgs) Handles cmborrar.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems

        Try
            If datos.Count = 1 Then
                Dim resultado As Integer = MessageBox.Show("¿Desea borrar los datos del cliente: " & datos(0).SubItems(2).Text & " relacionado con la empresa patrona: " & datos(0).SubItems(3).Text & "? (Este proceso no es reversible)", "Pregunta", MessageBoxButtons.YesNo)


                If resultado = DialogResult.Yes Then
                    'MessageBox.Show(datos(0).Tag, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SQL = "update FacturasNomina set iEstatus=0 where iIdFacturasNomina in "
                    SQL &= "(select Distinct(iIdFacturasNomina) from (DetNominaFactura inner join"
                    SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                    SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                    SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                    SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                    SQL &= " where  iIdFacturasNomina =" & datos(0).Tag & "))"
                    If nExecute(SQL) = False Then

                        MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    SQL = "update DetNominaFactura set iEstatus=0 where iIdDetnominafactura in "
                    SQL &= "(select Distinct(iIdDetnominafactura) from (DetNominaFactura inner join"
                    SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                    SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                    SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                    SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                    SQL &= " where  iIdFacturasNomina =" & datos(0).Tag & "))"

                    If nExecute(SQL) = False Then

                        MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    datos(0).Remove()
                    MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'lsvLista.SelectedItems(0).Remove()

                End If
            Else
                MessageBox.Show("No hay datos seleccionados para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub cmdborrarfactura_Click(sender As Object, e As EventArgs) Handles cmdborrarfactura.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvfacturas.SelectedItems
        If datos.Count = 1 Then
            Dim resultado As Integer = MessageBox.Show("¿Desea borrar la factura del cliente: " & datos(0).SubItems(1).Text & " con numero de factura: " & datos(0).SubItems(2).Text & "?", "Pregunta", MessageBoxButtons.YesNo)


            If resultado = DialogResult.Yes Then
                'MessageBox.Show(datos(0).Tag, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'SQL &= "update FacturasNomina set iEstatus=0 where iIdFacturasNomina in "
                'SQL &= "(select Distinct(iIdFacturasNomina) from (DetNominaFactura inner join"
                'SQL &= " interfacturasnomina on iIdDetnominafactura=fkiidDetNominaFactura)"
                'SQL &= " inner Join FacturasNomina on  interfacturasnomina.fkiIdFacturasNomina= iIdFacturasNomina"
                'SQL &= " where  iIdDetNominaFactura in (select fkIIdDetNominaFactura from FacturasNomina inner join InterFacturasNomina"
                'SQL &= " On iIdFacturasNomina= fkiIdFacturasNomina"
                'SQL &= " where  iIdFacturasNomina =" & datos(0).Tag & "))"
                'If nExecute(SQL) = False Then

                '    MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If
                datos(0).Remove()
                MessageBox.Show("Datos borrados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'lsvLista.SelectedItems(0).Remove()

            End If
        Else
            MessageBox.Show("No hay una factura seleccionada para borrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub chkflujo_CheckedChanged(sender As Object, e As EventArgs) Handles chkflujo.CheckedChanged
        Try
            SQL = "select * from clientes where iIdCliente = " & cbocliente2.SelectedValue
            Dim aID As String()
            Dim rwFilas As DataRow() = nConsulta(SQL)
            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                aID = Fila.Item("fkiIdPromotor").Split(",")
                If aID.Length = 1 Then
                    cbopromotor.SelectedValue = aID(0)
                    'IIf(aID(0) = "", cbopromotor.SelectedValue = 1, cbopromotor.SelectedValue = aID(0))
                ElseIf aID.Length = 2 Then
                    cbopromotor.SelectedValue = aID(0)
                    cbopromotor2.SelectedValue = aID(1)

                    'IIf(aID(0) = "", cbopromotor.SelectedValue = 1, cbopromotor.SelectedValue = aID(0))
                    'IIf(aID(1) = "", cbopromotor2.SelectedValue = 1, cbopromotor2.SelectedValue = aID(1))
                ElseIf aID.Length = 3 Then
                    cbopromotor.SelectedValue = aID(0)
                    cbopromotor2.SelectedValue = aID(1)
                    cbopromotor3.SelectedValue = aID(2)
                    'IIf(aID(0) = "", cbopromotor.SelectedValue = 1, cbopromotor.SelectedValue = aID(0))
                    'IIf(aID(1) = "", cbopromotor2.SelectedValue = 1, cbopromotor2.SelectedValue = aID(1))
                    'IIf(aID(2) = "", cbopromotor3.SelectedValue = 1, cbopromotor3.SelectedValue = aID(2))
                End If
                'cbopromotor.SelectedValue = aiD(0)
                'cbopromotor2.SelectedValue = aiD(1)
                'cbopromotor3.SelectedValue = aID(2)
                If chkflujo.Checked = True Then
                    Label9.Text = Fila.Item("porflujo") & " %"
                    lblporsa2.Text = Fila.Item("porflujo") & " %"
                    porcentajesa = Fila.Item("porflujo")
                    Label12.Text = Fila.Item("porflujo") & " %"
                    lblporsin2.Text = Fila.Item("porflujo") & " %"
                    porcentajesin = Fila.Item("porflujo")
                Else

                    If (Fila.Item("iTipoPor") = "0") Then
                        Label9.Text = Fila.Item("porcentaje") & " %"
                        lblporsa2.Text = Fila.Item("porcentaje") & " %"
                        porcentajesa = Fila.Item("porcentaje")
                        Label12.Text = Fila.Item("porsindicato") & " %"
                        lblporsin2.Text = Fila.Item("porsindicato") & " %"
                        porcentajesin = Fila.Item("porsindicato")
                    Else
                        Label9.Text = Fila.Item("porcentaje") & " %"
                        lblporsa2.Text = Fila.Item("porcentaje") & " %"
                        porcentajesa = Fila.Item("porcentaje")

                        Label12.Text = "0 %"
                        lblporsin2.Text = "0 %"
                        porcentajesin = 0


                    End If
                End If

                Calcularcomision()
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtisr_TextChanged(sender As Object, e As EventArgs) Handles txtisr.TextChanged

    End Sub

    Private Sub txtisr_MouseMove(sender As Object, e As MouseEventArgs) Handles txtisr.MouseMove

    End Sub

    Private Sub txtisr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtisr.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtisr_LostFocus(sender As Object, e As EventArgs) Handles txtisr.LostFocus
        txtisr.Text = Format(CType(IIf(txtisr.Text = "", "0", txtisr.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub txtisr2_TextChanged(sender As Object, e As EventArgs) Handles txtisr2.TextChanged

    End Sub

    Private Sub txtisr2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtisr2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtisr2_LostFocus(sender As Object, e As EventArgs) Handles txtisr2.LostFocus
        txtisr2.Text = Format(CType(IIf(txtisr2.Text = "", "0", txtisr2.Text), Decimal), "###,###,##0.#0")
    End Sub

    Private Sub dtpfechainicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechainicio.ValueChanged
        If blnFechainicio Then
            blnFechainicio = False
        Else
            cargarlista()
        End If

    End Sub

    Private Sub dtpfechafin_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechafin.ValueChanged
        cargarlista()
    End Sub
End Class