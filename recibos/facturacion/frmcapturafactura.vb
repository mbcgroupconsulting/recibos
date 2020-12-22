Imports System.Math

Public Class frmcapturafactura

    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim blnFechainicio As Boolean
    Dim blnbusqueda As Boolean
    Dim blnlista As Boolean
    Public gIdEmpresa As String
    Public UsuarioCreador As String
    Public gIdCliente As String
    Public gIdFactura As String
    Private Sub frmcapturafactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blnNuevo = True
        blnlista = True


        blnFechainicio = True
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year

        MostrarCliente()
        Limpiar()
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)


        Try
            If rwFilas Is Nothing = False Then



                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") <> "8" And Fila.Item("fkIdPerfil") <> "1" And Fila.Item("fkIdPerfil") <> "4") Then

                    txtnumfactura.Enabled = False
                    cboestatus.Enabled = False
                    chkflujob.Enabled = False


                End If
                If (Fila.Item("Nombre") = "Jannet") Then
                    pnlcolores.Enabled = True
                End If
            End If

            If Usuario.Perfil = 1 Then
                chkPatrona.Checked = True
            End If
            MostrarEmpresa()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub cargarlista()
        Dim contador As Integer
        Dim SQL As String, Alter As Boolean = False

        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value
        Dim tiempo As TimeSpan = fin - inicio
        If (tiempo.Days >= 0) Then
            SQL = "Select iIdFactura, fkiIdEmpresa,empresa.nombre As nombreempresa  ,fkiIdcliente, clientes.nombre As nombrecliente, "
            SQL &= "fecha,serief, numfactura, importe, iva,desnomina, total, pagoabono, comentario, facturas.iEstatus,  cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2, "
            SQL &= " isnull(totalabono,0) as totalabono,(total- isnull(totalabono,0)) as faltante "
            SQL &= " from ((facturas "
            SQL &= "inner Join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa) "
            SQL &= "inner Join clientes On facturas.fkiIdcliente =  clientes.iIdCliente) "
            SQL &= " left join (select fkiIdFactura, sum(pagos.importe) as totalabono from pagos where pagos.iEstatus=1"
            SQL &= " group by fkiIdFactura) as abonos on facturas.iIdFactura= abonos.fkiIdFactura"
            SQL &= " where fkiIdEmpresa =" & cboempresa.SelectedValue & " And facturas.iEstatus=1 "
            SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
            SQL &= " order by iIdFactura desc "

            Dim rwFilas As DataRow() = nConsulta(SQL)
            Dim item As ListViewItem


            lsvLista.Items.Clear()
            lsvLista.Clear()
            lsvLista.Columns.Add("Edo Pago")
            lsvLista.Columns(0).Width = 70
            lsvLista.Columns.Add("Tipo Fac")
            lsvLista.Columns(1).Width = 70
            lsvLista.Columns.Add("Serie F")
            lsvLista.Columns(2).Width = 60
            lsvLista.Columns.Add("Factura")
            lsvLista.Columns(3).Width = 70
            lsvLista.Columns(3).TextAlign = 1
            lsvLista.Columns.Add("Fecha")
            lsvLista.Columns(4).Width = 90
            lsvLista.Columns.Add("Cliente")
            lsvLista.Columns(5).Width = 300
            lsvLista.Columns.Add("Importe")
            lsvLista.Columns(6).Width = 100
            lsvLista.Columns(6).TextAlign = 1
            lsvLista.Columns.Add("Iva")
            lsvLista.Columns(7).Width = 100
            lsvLista.Columns(7).TextAlign = 1
            lsvLista.Columns.Add("Retención ISN")
            lsvLista.Columns(8).Width = 100
            lsvLista.Columns(8).TextAlign = 1
            lsvLista.Columns.Add("Total")
            lsvLista.Columns(9).Width = 100
            lsvLista.Columns(9).TextAlign = 1
            lsvLista.Columns.Add("Serie N")
            lsvLista.Columns(10).Width = 70
            lsvLista.Columns.Add("Nota")
            lsvLista.Columns(11).Width = 70
            lsvLista.Columns(11).TextAlign = 1
            lsvLista.Columns.Add("Pago/Abono")
            lsvLista.Columns(12).Width = 400
            lsvLista.Columns.Add("Periodo")
            lsvLista.Columns(13).Width = 400
            lsvLista.Columns.Add("Comentario")
            lsvLista.Columns(14).Width = 400
            lsvLista.Columns.Add("Estado")
            lsvLista.Columns(15).Width = 100
            lsvLista.Columns.Add("Elaborado")
            lsvLista.Columns(16).Width = 100
            lsvLista.Columns.Add("Modificado")
            lsvLista.Columns(17).Width = 100
            lsvLista.Columns.Add("Abonado")
            lsvLista.Columns(18).Width = 100
            lsvLista.Columns(18).TextAlign = 1
            lsvLista.Columns.Add("Faltante")
            lsvLista.Columns(19).Width = 100
            lsvLista.Columns(19).TextAlign = 1

            contador = 0

            If rwFilas Is Nothing = False Then
                For Each Fila In rwFilas
                    contador = contador + 1

                    item = lsvLista.Items.Add("")
                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)

                    item.UseItemStyleForSubItems = False
                    If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                        If Fila.Item("color") = "0" Then
                            item.SubItems.Item(0).BackColor = Color.White

                        ElseIf Fila.Item("color") = "1" Then
                            item.SubItems.Item(0).BackColor = Color.Yellow
                        ElseIf Fila.Item("color") = "2" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#00FF40")
                        ElseIf Fila.Item("color") = "3" Then
                            item.SubItems.Item(0).BackColor = Color.Red
                        ElseIf Fila.Item("color") = "4" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#FF00FF")
                        ElseIf Fila.Item("color") = "5" Then
                            item.SubItems.Item(0).BackColor = ColorTranslator.FromHtml("#01A9DB")
                        End If

                    End If

                    item.SubItems.Add("" & IIf(Fila.Item("tipofactura") = "0", "Nomina", "Flujo"))

                    If (Fila.Item("serief") = "0") Then
                        item.SubItems.Add("" & "A")
                    ElseIf Fila.Item("serief") = "1" Then
                        item.SubItems.Add("" & "B")
                    ElseIf Fila.Item("serief") = "2" Then
                        item.SubItems.Add("" & "C")
                    ElseIf Fila.Item("serief") = "3" Then
                        item.SubItems.Add("" & "D")
                    End If



                    item.SubItems.Add("" & Fila.Item("numfactura"))

                    item.SubItems.Add("" & Fila.Item("fecha"))
                    item.SubItems.Add("" & Fila.Item("nombrecliente"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("importe"), Decimal), "###,###,##0.#0"))

                    item.SubItems.Add("" & Format(CType(Fila.Item("iva"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("desnomina"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("total"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Fila.Item("serien"))
                    item.SubItems.Add("" & Fila.Item("numnota"))
                    item.SubItems.Add("" & Fila.Item("pagoabono"))
                    item.SubItems.Add("" & Fila.Item("comentario"))
                    item.SubItems.Add("" & Fila.Item("comentario2"))
                    item.SubItems.Add("" & IIf(Fila.Item("cancelada") = "0", "Cancelada", "Activa"))
                    'If (Fila.Item("cancelada") = "0") Then
                    '    item.SubItems.Item(0).BackColor = Color.Red
                    'End If
                    item.SubItems.Add("" & Fila.Item("usuarioc"))
                    item.SubItems.Add("" & Fila.Item("usuariom"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("totalabono"), Decimal), "###,###,##0.#0"))
                    item.SubItems.Add("" & Format(CType(Fila.Item("faltante"), Decimal), "###,###,##0.#0"))
                    item.Tag = Fila.Item("iIdFactura")

                    Alter = Not Alter

                Next
            Else
                MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If lsvLista.Items.Count > 0 Then
                'lsvLista.Focus()
                'lsvLista.Items(0).Selected = True
                MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'txtbuscar.Focus()
                'txtbuscar.SelectAll()
            End If

        Else
            MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




    End Sub
    Private Sub Limpiar()
        'cboempresa.SelectedIndex = 0
        cboempresa.SelectedIndex = -1
        cbocliente.SelectedIndex = -1
        dtpfecha.Value = Date.Now.ToShortDateString()
        cboestatus.SelectedIndex = 0
        cbopago.SelectedIndex = 0
        cboserie.SelectedIndex = 0
        txtnumfactura.Text = ""
        txtimporte.Text = ""
        txtiva.Text = ""
        txttotal.Text = ""
        txtpago.Text = ""
        txtcomentario.Text = ""
        txtperiodo.Text = ""
        chkActivo.Checked = True
        blnNuevo = True
        pnlnota.Enabled = False
        chknota.Checked = False
        cbocolor.SelectedIndex = -1
        cbotipofactura.SelectedIndex = 0
        chkflujob.Checked = False
        chkFlujoC.Checked = False
        chkFlujoNom.Checked = False
        txtnomina.Text = ""

        lblmodificado.Text = ""
        lblcapturado.Text = ""
    End Sub

    Private Sub limpiar2()
        txtnumfactura.Text = ""
        txtimporte.Text = ""
        txtiva.Text = ""
        txttotal.Text = ""
        txtpago.Text = ""
        txtperiodo.Text = ""
        txtcomentario.Text = ""
        cbocolor.SelectedIndex = -1
        cbotipofactura.SelectedIndex = 0
        lblmodificado.Text = ""
        lblcapturado.Text = ""
    End Sub
    Private Sub MostrarEmpresa()
        'Verificar si se tienen permisos
        blnbusqueda = True
        blnlista = False
        Try

            SQL = "Select nombre,iIdEmpresa from empresa where ("
            If chkintermediaria.Checked Then
                SQL &= " fkiIdTipoEmpresa=2 "
                blnbusqueda = False
            End If
            If chkiva.Checked Then
                If blnbusqueda Then
                    SQL &= " fkiIdTipoEmpresa=3 "
                    blnbusqueda = False
                Else

                    SQL &= " or fkiIdTipoEmpresa=3 "
                End If

            End If
            If chkPatrona.Checked Then
                If blnbusqueda Then
                    SQL &= " fkiIdTipoEmpresa=1 "
                    blnbusqueda = False
                Else

                    SQL &= " or fkiIdTipoEmpresa=1 "
                End If

            End If
            SQL &= ") and iEstatus=1"
            SQL &= " order by nombre  "

            nCargaCBO(cboempresa, SQL, "nombre", "iIdEmpresa")

            blnlista = True
            cboempresa.SelectedIndex = -1
            lsvLista.Items.Clear()
            'cargarlista()
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



    Private Sub txtnumfactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumfactura.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub



    Private Sub txtimporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtimporte.KeyPress
        SoloNumero.NumeroDec(e, sender)

    End Sub


    Private Sub txtiva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtiva.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub


    Private Sub txttotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotal.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtimporte_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtimporte.LostFocus
        Try
            txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "0", txtimporte.Text), Decimal), "###,###,##0.#0")
            txtiva.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16
            txttotal.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) + (Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16)
            txtiva.Text = Format(CType(IIf(txtiva.Text = "", "0", txtiva.Text), Decimal), "###,###,##0.#0")
            txttotal.Text = Format(CType(IIf(txttotal.Text = "", "0", txttotal.Text), Decimal), "###,###,##0.#0")
            If cboempresa.Text.Contains("OPERADORA") Or cboempresa.Text.Contains("NAVIGATOR") Or cboempresa.Text.Contains("XURTEP") Or cboempresa.Text.Contains("MAECCO") Then
                txtnomina.Text = Format(CType((Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.06), Decimal), "###,###,##0.#0")
            Else
                txtnomina.Text = "0.00"

            End If
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub txttotal_LostFocus(sender As Object, e As EventArgs) Handles txttotal.LostFocus
        'txttotal.Text = Format(CType(IIf(txttotal.Text = "", "0", txttotal.Text), Decimal), "###,###,##0.#0")
        'txtiva.Text = Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) - (Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) / 1.16)
        'txtimporte.Text = Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) - (Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) - (Double.Parse(IIf(txttotal.Text = "", "0", txttotal.Text)) / 1.16))
        'txtiva.Text = Format(CType(IIf(txtiva.Text = "", "0", txtiva.Text), Decimal), "###,###,##0.#0")
        'txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "", txtimporte.Text), Decimal), "###,###,##0.#0")
        'txtnomina.Text = "0.00"

    End Sub

    Private Sub cmdagregar_Click(sender As Object, e As EventArgs) Handles cmdagregar.Click
        Dim SQL As String, Mensaje As String = "", nombresistema As String = ""
        Dim bandera As Boolean
        Dim tipoflujo As Integer
        Dim IdFactura1 As String
        IdFactura1 = ""

        Try

            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombresistema = Fila.Item("nombre")
            End If

            'Validar


            If txtimporte.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el importe"
            End If
            If txttotal.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique total"
            End If

            If cboempresa.SelectedIndex = -1 Then
                Mensaje = "Por favor seleccione una empresa"
            End If

            If cboempresa.SelectedIndex = -1 Then
                Mensaje = "Por favor seleccione un cliente"
            End If

            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            bandera = True

            If cboestatus.SelectedIndex = 1 And blnNuevo = False Then
                'validar colores
                SQL = "select * from facturas where iIdFactura = " & gIdFactura
                Dim rwcolor As DataRow() = nConsulta(SQL)
                If rwcolor Is Nothing = False Then
                    If rwcolor(0).Item("color") = "0" Then

                        bandera = True
                        'Actualizamos el color a rojo
                        'SQL = "update facturas set  color=3 where iIdFactura=" & gIdFactura

                        'If nExecute(SQL) = False Then
                        '    Exit Sub
                        'End If

                    Else

                        If nombresistema = "Guadalupe" Then
                            bandera = True
                            cbocolor.SelectedIndex = 0
                        Else
                            bandera = False
                            MessageBox.Show("La factura ya tiene un color asignado no es posible guardar ningun cambio, veriquelo con nominas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If


                    End If
                End If
            End If

            If chkActivo.Checked = False And blnNuevo = False Then
                'validar colores
                SQL = "select isnull(color,0) as color from facturas where iIdFactura = " & gIdFactura
                Dim rwcolor As DataRow() = nConsulta(SQL)
                If rwcolor Is Nothing = False Then
                    If rwcolor(0).Item("color") = "0" Then

                        bandera = True

                    Else
                        bandera = False
                        MessageBox.Show("La factura ya tiene un color asignado no es posible guardar ningun cambio, veriquelo con nominas", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If

            'Validamos el numero para el tipo de flujo
            If chkflujob.Checked Then
                tipoflujo = 1
            ElseIf chkFlujoC.Checked And chkFlujoNom.Checked = False Then
                tipoflujo = 2
            ElseIf chkFlujoC.Checked And chkFlujoNom.Checked Then
                tipoflujo = 3
            Else
                tipoflujo = 0
            End If


            If bandera Then



                If blnNuevo Then
                    'Insertar nuevo
                    SQL = "EXEC setfacturasInsertar 0," & cboempresa.SelectedValue & "," & cbocliente.SelectedValue
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & IIf(txtnumfactura.Text = "", 0, txtnumfactura.Text)
                    SQL &= "," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txtiva.Text = "", 0, txtiva.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txttotal.Text = "", 0, txttotal.Text)).ToString.Replace(",", "")
                    SQL &= ",'" & txtpago.Text & "','" & txtperiodo.Text & "'," & IIf(chkActivo.Checked, 1, 0)
                    SQL &= ",'" & nombresistema & "','" & nombresistema
                    SQL &= "'," & IIf(cboestatus.SelectedIndex = 0, 1, 0) & "," & cbopago.SelectedIndex
                    SQL &= "," & cboserie.SelectedIndex & ",'" & txtserien.Text & "'," & IIf(txtnumnota.Text = "", 0, txtnumnota.Text) & "," & IIf(cbocolor.SelectedIndex = -1, "0", cbocolor.SelectedIndex)
                    SQL &= "," & cbotipofactura.SelectedIndex & ",'" & txtcomentario.Text & "','" & Date.Now.ToShortDateString() & "'"
                    SQL &= "," & tipoflujo
                    SQL &= "," & (IIf(txtnomina.Text = "", 0, txtnomina.Text)).ToString.Replace(",", "")
                    SQL &= ",0"


                    If Execute(SQL, IdFactura1) = False Then
                        'MessageBox.Show("Error en el registro con los siguiente datos: fecha:" & Trim(producto.SubItems(4).Text) & " Cliente:" & Trim(producto.SubItems(6).Text) & " Intermediaria/pagadora:" & Trim(producto.SubItems(9).Text) & ". El proceso concluira en ese registro. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If



                    'Validamos si es una factura tipo B y nueva y la agregamos a FacturaConcepto

                    If tipoflujo = 1 Then
                        'Agregamos una el concepto
                        SQL = "EXEC setFacturaConceptoInsertar 0," & IdFactura1
                        SQL &= ",'',''"
                        SQL &= ",'" & Date.Now.ToShortDateString()
                        SQL &= "','" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                        SQL &= "',-1"
                        SQL &= ",'" & cbocliente.Text
                        SQL &= "','F'"
                        SQL &= ",'" & cboempresa.Text
                        SQL &= "'," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txtiva.Text = "", 0, txtiva.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txttotal.Text = "", 0, txttotal.Text)).ToString.Replace(",", "")
                        SQL &= ",'" & nombresistema
                        SQL &= "',1,1"

                        If nExecute(SQL) = False Then
                            Exit Sub
                        End If

                        'Enviamos el correo

                        Enviar_Mail(GenerarCorreoFlujo("Factura Flujo-Externo", "Área Juridico", "Se agrego una factura, para flujo externo"), "l.aquino@mbcgroup.mx;z.reyes@mbcgroup;m.zarate@mbcgroup.mx", "Flujo Externo")

                    End If

                Else
                    'Actualizar
                    SQL = "EXEC setfacturasActualizar " & gIdFactura & "," & cboempresa.SelectedValue & "," & cbocliente.SelectedValue
                    SQL &= ",'" & Format(dtpfecha.Value.Date, "yyyy/dd/MM")
                    SQL &= "'," & IIf(txtnumfactura.Text = "", 0, txtnumfactura.Text)
                    SQL &= "," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txtiva.Text = "", 0, txtiva.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txttotal.Text = "", 0, txttotal.Text)).ToString.Replace(",", "")
                    SQL &= ",'" & txtpago.Text & "','" & txtperiodo.Text & "'," & IIf(chkActivo.Checked, 1, 0)
                    SQL &= ",'" & UsuarioCreador & "','" & nombresistema
                    SQL &= "'," & IIf(cboestatus.SelectedIndex = 0, 1, 0) & "," & cbopago.SelectedIndex
                    SQL &= "," & cboserie.SelectedIndex & ",'" & txtserien.Text & "'," & IIf(txtnumnota.Text = "", 0, txtnumnota.Text) & "," & IIf(cboestatus.SelectedIndex = 1, 3, IIf(cbocolor.SelectedIndex = -1, "0", cbocolor.SelectedIndex))
                    SQL &= "," & cbotipofactura.SelectedIndex & ",'" & txtcomentario.Text & "','" & Date.Now.ToShortDateString() & "'"
                    SQL &= "," & tipoflujo
                    SQL &= "," & (IIf(txtnomina.Text = "", 0, txtnomina.Text)).ToString.Replace(",", "")
                    SQL &= ",0"


                    If nExecute(SQL) = False Then
                        Exit Sub
                    End If


                End If


                MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar()
                If cboempresa.SelectedIndex > -1 Then
                    cargarlista()
                End If
            End If




        Catch ex As Exception

        End Try
    End Sub



    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate


        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)

                If (Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "1") Then
                    Dim resultado As Integer = MessageBox.Show("¿Editar solo colores?", "Pregunta", MessageBoxButtons.YesNo)
                    If resultado = DialogResult.Yes Then
                        EditarColores(lsvLista.SelectedItems(0).Tag)
                    ElseIf resultado = DialogResult.No Then
                        EditarFactura(lsvLista.SelectedItems(0).Tag)
                    End If
                Else

                    Dim resultado As Integer = MessageBox.Show("¿Desea agregar un abono?", "Pregunta", MessageBoxButtons.YesNo)
                    If resultado = DialogResult.Yes Then
                        EditarAbono(lsvLista.SelectedItems(0).Tag)
                    ElseIf resultado = DialogResult.No Then
                        'verificar si tiene color verde
                        SQL = "select * from facturas where iIdFactura=" & lsvLista.SelectedItems(0).Tag & " and (color=0 or color=1 or color is null)"
                        Dim rwFacturaModi As DataRow() = nConsulta(SQL)
                        If rwFacturaModi Is Nothing = False Then
                            EditarFactura(lsvLista.SelectedItems(0).Tag)
                        Else
                            If (Fila.Item("Nombre") = "Guadalupe") Then
                                MessageBox.Show("Esta factura ya tiene un color asignado para modificarla, solo es permitido para cancelaciones", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                EditarFactura(lsvLista.SelectedItems(0).Tag)

                            Else
                                MessageBox.Show("Esta factura ya tiene un color asignado para modificarla, es necesario quitar el color", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If

                        End If

                    End If

                    'EditarFactura(lsvLista.SelectedItems(0).Tag)
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EditarAbono(id As String)
        Try
            Dim Forma As New frmAbono
            Forma.gIdFactura = id
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

                'If cboempresa.SelectedIndex > -1 Then
                '    cargarlista()
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub EditarColores(id As String)

        Try
            Dim Forma As New frmcolor
            Forma.gIdFacturaC = id
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

                If cboempresa.SelectedIndex > -1 Then
                    cargarlista()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub EditarFactura(id As String)
        Limpiar2()
        SQL = "select * from facturas where iIdFactura = " & id
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then
                blnNuevo = False
                Dim Fila As DataRow = rwFilas(0)

                cboempresa.SelectedValue = Fila.Item("fkiIdEmpresa")
                cbocliente.SelectedValue = Fila.Item("fkiIdcliente")
                txtnumfactura.Text = Fila.Item("numfactura")
                cboestatus.SelectedIndex = IIf(Fila.Item("cancelada") = "0", 1, 0)
                dtpfecha.Value = Fila.Item("fecha")
                txtimporte.Text = Fila.Item("importe")
                txtiva.Text = Fila.Item("iva")
                txtnomina.Text = Fila.Item("desnomina")
                txttotal.Text = Fila.Item("total")
                txtpago.Text = Fila.Item("pagoabono")
                txtperiodo.Text = Fila.Item("comentario")
                txtcomentario.Text = Fila.Item("comentario2")
                UsuarioCreador = Fila.Item("usuarioc")
                cboserie.SelectedIndex = Fila.Item("serief")
                cbopago.SelectedIndex = Fila.Item("pagada")
                If Fila.Item("numnota") = "0" Then
                    chknota.Checked = False

                Else
                    chknota.Checked = True
                    txtserien.Text = Fila.Item("serien")
                    txtnumnota.Text = Fila.Item("numnota")
                End If
                'chkpagada.Checked = IIf(Fila.Item("pagada") = "1", True, False)
                txtimporte.Text = Format(CType(txtimporte.Text, Decimal), "###,###,##0.#0")
                txtiva.Text = Format(CType(txtiva.Text, Decimal), "###,###,##0.#0")
                txtnomina.Text = Format(CType(txtnomina.Text, Decimal), "###,###,##0.#0")
                txttotal.Text = Format(CType(txttotal.Text, Decimal), "###,###,##0.#0")
                If Not String.IsNullOrEmpty(Fila.Item("color").ToString()) Then
                    cbocolor.SelectedIndex = Fila.Item("color")
                End If
                cbotipofactura.SelectedIndex = Fila.Item("tipofactura")

                If Fila.Item("flujob") = "1" Then
                    chkflujob.Checked = True
                    chkFlujoC.Checked = False
                    chkFlujoNom.Checked = False
                ElseIf Fila.Item("flujob") = "2" Then
                    chkflujob.Checked = False
                    chkFlujoC.Checked = True
                    chkFlujoNom.Checked = False
                ElseIf Fila.Item("flujob") = "3" Then
                    chkflujob.Checked = False
                    chkFlujoC.Checked = True
                    chkFlujoNom.Checked = True

                Else
                    chkflujob.Checked = False
                    chkFlujoC.Checked = False
                    chkFlujoNom.Checked = False
                End If

                'chkflujob.Checked = IIf(Fila.Item("flujob") = "1", True, False)

                lblcapturado.Text = Fila.Item("usuarioc")
                lblmodificado.Text = Fila.Item("usuariom")
                gIdFactura = id
                If cboempresa.SelectedIndex > -1 Then
                    cargarlista()
                End If


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lsvLista_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboempresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboempresa.SelectedIndexChanged
        If blnNuevo And blnlista And cboempresa.SelectedIndex > -1 Then
            cargarlista()
        End If

    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        Limpiar()
        If cboempresa.SelectedIndex > -1 Then
            cargarlista()
        End If
    End Sub

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Dim Forma As New frmverfacturascontrol
        If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            'verificar si tiene color verde
            SQL = "select * from facturas where iIdFactura=" & lsvLista.SelectedItems(0).Tag & " and (color=0 or color=1)"
            Dim rwFacturaModi As DataRow() = nConsulta(SQL)
            If rwFacturaModi Is Nothing = False Then
                gIdFactura = Forma.gIdFactura
                EditarFactura(Forma.gIdFactura)
            Else
                MessageBox.Show("Esta factura ya tiene un color asignado para modificarla, es necesario quitar el color", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


        End If

    End Sub

    Private Sub lsvLista_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lsvLista.SelectedIndexChanged

    End Sub

  

    Private Sub chknota_CheckedChanged(sender As Object, e As EventArgs) Handles chknota.CheckedChanged
        If chknota.Checked Then
            pnlnota.Enabled = True
        Else
            pnlnota.Enabled = False
        End If
    End Sub

    Private Sub txtnumnota_DoubleClick(sender As Object, e As EventArgs) Handles txtnumnota.DoubleClick
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlCatalogo_Paint(sender As Object, e As PaintEventArgs) Handles pnlCatalogo.Paint

    End Sub

    Private Sub dtpfechafin_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechafin.ValueChanged
        If cboempresa.SelectedIndex > -1 Then
            cargarlista()
        End If
    End Sub

    Private Sub dtpfechainicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechainicio.ValueChanged
        If blnFechainicio Then
            blnFechainicio = False
        Else
            If cboempresa.SelectedIndex > -1 Then
                cargarlista()
            End If


        End If


    End Sub

    Private Sub chkintermediaria_CheckedChanged(sender As Object, e As EventArgs) Handles chkintermediaria.CheckedChanged
        'MostrarEmpresa()

    End Sub

    Private Sub chkiva_CheckedChanged(sender As Object, e As EventArgs) Handles chkiva.CheckedChanged
        'MostrarEmpresa()
    End Sub

    Private Sub chkPatrona_CheckedChanged(sender As Object, e As EventArgs) Handles chkPatrona.CheckedChanged
        'MostrarEmpresa()
    End Sub

    Private Sub chkintermediaria_CheckStateChanged(sender As Object, e As EventArgs) Handles chkintermediaria.CheckStateChanged

    End Sub

    Private Sub chkintermediaria_MouseClick(sender As Object, e As MouseEventArgs) Handles chkintermediaria.MouseClick
        MostrarEmpresa()
    End Sub

    Private Sub chkiva_MouseClick(sender As Object, e As MouseEventArgs) Handles chkiva.MouseClick
        MostrarEmpresa()
    End Sub

    Private Sub chkPatrona_MouseClick(sender As Object, e As MouseEventArgs) Handles chkPatrona.MouseClick
        MostrarEmpresa()
    End Sub

    Private Sub tsbAbono_Click(sender As Object, e As EventArgs) Handles tsbAbono.Click
        Try
            Dim Forma As New frmFacturaAbonos
            'Forma.gIdFactura = ""
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then

                'If cboempresa.SelectedIndex > -1 Then
                '    cargarlista()
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtnomina_TextChanged(sender As Object, e As EventArgs) Handles txtnomina.TextChanged

    End Sub

    Private Sub txtnomina_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnomina.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtnomina_LostFocus(sender As Object, e As EventArgs) Handles txtnomina.LostFocus
        'txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "0", txtimporte.Text), Decimal), "###,###,##0.#0")
        'txtiva.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16
        txttotal.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) + (Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16) - Double.Parse(IIf(txtnomina.Text = "", "0", txtnomina.Text))
        txtnomina.Text = Format(CType(IIf(txtnomina.Text = "", "0", txtnomina.Text), Decimal), "###,###,##0.#0")
        txttotal.Text = Format(CType(IIf(txttotal.Text = "", "0", txttotal.Text), Decimal), "###,###,##0.#0")

    End Sub

    Private Sub cmdDetFacturas_Click(sender As Object, e As EventArgs) Handles cmdDetFacturas.Click
        Try
            Dim Forma As New frmdetfactura

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkflujob_CheckedChanged(sender As Object, e As EventArgs) Handles chkflujob.CheckedChanged
        If chkflujob.Checked Then
            chkFlujoC.Checked = False


        End If
    End Sub

    Private Sub chkFlujoC_CheckedChanged(sender As Object, e As EventArgs) Handles chkFlujoC.CheckedChanged
        If chkFlujoC.Checked Then
            chkflujob.Checked = False

        End If
    End Sub

    Private Sub chkFlujoNom_CheckedChanged(sender As Object, e As EventArgs) Handles chkFlujoNom.CheckedChanged
        If chkFlujoNom.Checked Then
            chkflujob.Checked = False
            chkFlujoC.Checked = True
        End If
    End Sub
End Class