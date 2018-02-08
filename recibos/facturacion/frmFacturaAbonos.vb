Public Class frmFacturaAbonos
    Dim SQL As String
    Dim blnNuevo As Boolean
    Dim blnNuevoAbono As Boolean
    Dim blnOtraSA As Boolean
    Dim porcentajesa As Double
    Dim porcentajesin As Double
    Public gIdFactura As String
    Dim totalfactura As Double
    Dim gIdFacturasnomina As String
    Dim gidFacturasnomina2 As String

    Dim DetCadena As String
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

            'item = lsvfacturas.Items.Add("(" & cboempresa.SelectedValue & ")" & cboempresa.Text)
            'item.SubItems.Add("(" & cbocliente.SelectedValue & ")" & cbocliente.Text)
            'item.SubItems.Add(txtfactura.Text)
            'item.SubItems.Add(txtimporte.Text)
            'item.SubItems.Add(txtiva.Text)
            'item.SubItems.Add(txttotal.Text)
            'item.SubItems.Add(Date.Now.ToShortDateString)
            ''totalfactura = totalfactura + txttotal.Text


            'item.Tag = 0

            'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
            'Alter = Not Alter

            SQL = "Select * from usuarios where idUsuario = " & idUsuario
            Dim rwFilas As DataRow() = nConsulta(SQL)

            If rwFilas Is Nothing = False Then
                Dim Fila As DataRow = rwFilas(0)
                nombresistema = Fila.Item("nombre")
            End If


            If blnNuevo Then
                'Insertar nuevo
                SQL = "EXEC setfacturasInsertar 0," & cboempresa.SelectedValue & "," & cbocliente.SelectedValue
                SQL &= ",'" & Format(dtpfechafactura.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & IIf(txtfactura.Text = "", 0, txtfactura.Text)
                SQL &= "," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                SQL &= "," & (IIf(txtiva.Text = "", 0, txtiva.Text)).ToString.Replace(",", "")
                SQL &= "," & (IIf(txttotal.Text = "", 0, txttotal.Text)).ToString.Replace(",", "")
                SQL &= ",'','',1"
                SQL &= ",'" & nombresistema & "','" & nombresistema
                SQL &= "',1,0"
                SQL &= ",0,'',0,0,"
                SQL &= ",0,'','" & Date.Now.ToShortDateString() & "'"
                SQL &= ",100"

            Else
                'Actualizar
                SQL = "EXEC setfacturasActualizar " & gIdFactura & "," & cboempresa.SelectedValue & "," & cbocliente.SelectedValue
                SQL &= ",'" & Format(dtpfechafactura.Value.Date, "yyyy/dd/MM")
                SQL &= "'," & IIf(txtfactura.Text = "", 0, txtfactura.Text)
                SQL &= "," & (IIf(txtimporte.Text = "", 0, txtimporte.Text)).ToString.Replace(",", "")
                SQL &= "," & (IIf(txtiva.Text = "", 0, txtiva.Text)).ToString.Replace(",", "")
                SQL &= "," & (IIf(txttotal.Text = "", 0, txttotal.Text)).ToString.Replace(",", "")
                SQL &= ",'','',1"
                SQL &= ",'" & nombresistema & "','" & nombresistema
                SQL &= "',1,0"
                SQL &= ",0,'',0,0,"
                SQL &= ",0,'','" & Date.Now.ToShortDateString() & "'"
                SQL &= ",100"


            End If

            If nExecute(SQL) = False Then
                Exit Sub
            End If

            MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            cargarlista()
            limpiarfacturas()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarlista()
        Dim contador As Integer
        Dim SQL As String, Alter As Boolean = False



        SQL = "Select iIdFactura, fkiIdEmpresa,empresa.nombre As nombreempresa  ,fkiIdcliente, clientes.nombre As nombrecliente, "

        SQL &= "fecha,serief, numfactura, importe, iva, total, pagoabono, comentario, facturas.iEstatus,  cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2 "
        SQL &= "from(facturas "
        SQL &= "inner Join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa) "
        SQL &= "inner Join clientes On facturas.fkiIdcliente =  clientes.iIdCliente "
        SQL &= "where And facturas.iEstatus=1 and flujob=100"
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
            lsvLista.Columns.Add("Total")
            lsvLista.Columns(8).Width = 100
            lsvLista.Columns(8).TextAlign = 1
            lsvLista.Columns.Add("Serie N")
            lsvLista.Columns(9).Width = 70
            lsvLista.Columns.Add("Nota")
            lsvLista.Columns(10).Width = 70
            lsvLista.Columns(10).TextAlign = 1
            lsvLista.Columns.Add("Pago/Abono")
            lsvLista.Columns(11).Width = 400
            lsvLista.Columns.Add("Periodo")
            lsvLista.Columns(12).Width = 400
            lsvLista.Columns.Add("Comentario")
            lsvLista.Columns(13).Width = 400
            lsvLista.Columns.Add("Estado")
            lsvLista.Columns(14).Width = 100
            lsvLista.Columns.Add("Elaborado")
            lsvLista.Columns(15).Width = 100
            lsvLista.Columns.Add("Modificado")
            lsvLista.Columns(16).Width = 100


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






    End Sub
    Private Sub limpiarfacturas()
        Try
            cboempresa.SelectedIndex = 0
            dtpfechafactura.Value = Date.Now.ToShortDateString()

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

    Private Sub frmFacturaAbonos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blnNuevo = True
        blnOtraSA = False
        MostrarEmpresa()
        MostrarCliente()



        totalfactura = 0
        'cargarlista()
        gIdFacturasnomina = ""
        gidFacturasnomina2 = ""
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

    Private Sub txtfactura_TextChanged(sender As Object, e As EventArgs) Handles txtfactura.TextChanged

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

    Private Sub txttotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotal.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        limpiarfacturas()
    End Sub

    Private Sub txtimporte_LostFocus(sender As Object, e As EventArgs) Handles txtimporte.LostFocus
        txtimporte.Text = Format(CType(IIf(txtimporte.Text = "", "0", txtimporte.Text), Decimal), "###,###,##0.#0")
        txtiva.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16
        txttotal.Text = Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) + (Double.Parse(IIf(txtimporte.Text = "", "0", txtimporte.Text)) * 0.16)
        txtiva.Text = Format(CType(IIf(txtiva.Text = "", "0", txtiva.Text), Decimal), "###,###,##0.#0")
        txttotal.Text = Format(CType(IIf(txttotal.Text = "", "0", txttotal.Text), Decimal), "###,###,##0.#0")
    End Sub
End Class