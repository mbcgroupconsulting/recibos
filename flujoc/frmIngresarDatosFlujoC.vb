Imports ClosedXML.Excel


Public Class frmIngresarDatosFlujoC
    Dim SQL As String
    Dim iIdFactura As String

    Private Sub frmIngresarDatosFlujoC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfechainicio.Value = "01/" & Date.Now.Month & "/" & Date.Now.Year
        MostrarCliente()


    End Sub

    Private Sub MostrarCliente()
        'Verificar si se tienen permisos
        Try
            SQL = "Select nombre,iIdCliente from clientes where iEstatus=1 order by nombre "
            nCargaCBO(cboclientes, SQL, "nombre", "iIdCliente")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim contador As Integer
        lsvLista.Items.Clear()
        lsvLista.Clear()
        Dim Alter As Boolean = False
        Dim inicio As DateTime = dtpfechainicio.Value
        Dim fin As DateTime = dtpfechafin.Value

        SQL = "select iIdFactura, fkiIdEmpresa,empresa.nombre as nombreempresa  ,fkiIdcliente, clientes.nombre as nombrecliente,"
        SQL &= "fecha,serief, ISNULL(numfactura,0) as numfactura,importe,iva,desnomina,total,pagoabono,comentario,facturas.cancelada,pagada,serien,numnota,color,usuarioc,usuariom,tipofactura,comentario2,flujob"
        SQL &= " from (facturas"
        SQL &= " inner join empresa on facturas.fkiIdEmpresa= empresa.iIdEmpresa)"
        SQL &= " inner join clientes on facturas.fkiIdcliente =  clientes.iIdCliente"
        SQL &= " where fkiIdcliente =" & cboclientes.SelectedValue & " and facturas.iEstatus=1 And facturas.cancelada=1"
        SQL &= " and fecha between '" & inicio.ToShortDateString & "' and '" & fin.ToShortDateString() & "'"
        SQL &= " and (flujob=2 or flujob=3)"


        SQL &= " order by nombreempresa,fecha,nombrecliente,iIdFactura asc"

        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim item As ListViewItem
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
        lsvLista.Columns.Add("Empresa")
        lsvLista.Columns(5).Width = 300
        lsvLista.Columns.Add("Cliente")
        lsvLista.Columns(6).Width = 300
        lsvLista.Columns.Add("Importe")
        lsvLista.Columns(7).Width = 100
        lsvLista.Columns(7).TextAlign = 1
        lsvLista.Columns.Add("Iva")
        lsvLista.Columns(8).Width = 100
        lsvLista.Columns(8).TextAlign = 1
        lsvLista.Columns.Add("Retención ISN")
        lsvLista.Columns(9).Width = 100
        lsvLista.Columns(9).TextAlign = 1
        lsvLista.Columns.Add("Total")
        lsvLista.Columns(10).Width = 100
        lsvLista.Columns(10).TextAlign = 1
        lsvLista.Columns.Add("Serie N")
        lsvLista.Columns(11).Width = 70
        lsvLista.Columns.Add("Nota")
        lsvLista.Columns(12).Width = 70
        lsvLista.Columns(12).TextAlign = 1
        lsvLista.Columns.Add("Pago/Abono")
        lsvLista.Columns(13).Width = 400
        lsvLista.Columns.Add("Periodo")
        lsvLista.Columns(14).Width = 400
        lsvLista.Columns.Add("Comentario")
        lsvLista.Columns(15).Width = 400
        lsvLista.Columns.Add("Estado")
        lsvLista.Columns(16).Width = 100
        lsvLista.Columns.Add("Elaborado")
        lsvLista.Columns(17).Width = 100
        lsvLista.Columns.Add("Modificado")
        lsvLista.Columns(18).Width = 100
        lsvLista.Columns.Add("Tipo")
        lsvLista.Columns(19).Width = 50



        contador = 0

        If rwFilas Is Nothing = False Then
            For Each Fila In rwFilas
                contador = contador + 1
                item = lsvLista.Items.Add("")
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
                item.SubItems.Add("" & Fila.Item("nombreempresa"))
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
                item.SubItems.Add("" & Fila.Item("flujob"))
                item.Tag = Fila.Item("iIdFactura")
                'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                Alter = Not Alter

            Next
        Else
            MessageBox.Show("No hay datos a mostrar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If lsvLista.Items.Count > 0 Then
            lsvLista.Focus()
            lsvLista.Items(0).Selected = True
            MessageBox.Show(contador & " registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'fin chktodas
    End Sub

    Private Sub cmdcalcular_Click(sender As Object, e As EventArgs) Handles cmdcalcular.Click
        Dim datos As ListView.SelectedListViewItemCollection = lsvLista.SelectedItems
        If datos.Count = 1 Then

            If Integer.Parse(datos(0).SubItems(19).Text) = 2 Then
                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & cboclientes.SelectedValue & " and tipo=1"
            Else
                SQL = "select * from ComisionClienteFlujo where fkiIdCliente=" & cboclientes.SelectedValue & " and tipo=2"
            End If






            Dim rwComisionClienteFlujo As DataRow() = nConsulta(SQL)

            If rwComisionClienteFlujo Is Nothing = False Then

                iIdFactura = datos(0).Tag

                txtcomision.Text = rwComisionClienteFlujo(0).Item("porcobrado") & IIf(Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1, " + IVA", "")

                If Integer.Parse(rwComisionClienteFlujo(0).Item("masiva")) = 1 Then
                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                        'promotor
                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                            txtpromotor1.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                        Else
                            txtpromotor1.Text = "0.00"
                        End If

                        'promotor2
                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                            txtpromotor2.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                        Else
                            txtpromotor2.Text = "0.00"
                        End If

                        'promotor3
                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                            txtpromotor3.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                        Else
                            txtpromotor3.Text = "0.00"
                        End If

                        'promotor4
                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                            txtpromotor4.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                        Else
                            txtpromotor4.Text = "0.00"
                        End If
                    Else
                        'promotor
                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                            txtpromotor1.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                        Else
                            txtpromotor1.Text = "0.00"
                        End If

                        'promotor2
                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                            txtpromotor2.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                        Else
                            txtpromotor2.Text = "0.00"
                        End If

                        'promotor3
                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                            txtpromotor3.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                        Else
                            txtpromotor3.Text = "0.00"
                        End If

                        'promotor4
                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                            txtpromotor4.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                        Else
                            txtpromotor4.Text = "0.00"
                        End If

                    End If




                    'retorno cliente

                    txtrcliente.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) / ((Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100) + 1), 2)

                    txtcalculo.Text = Math.Round(Double.Parse(txtrcliente.Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                    txt11.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * 0.01, 2)

                    txt12.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * 0.01, 2)

                    txtsumar.Text = Math.Round(Double.Parse(txtpromotor1.Text) + Double.Parse(txtpromotor2.Text) + Double.Parse(txtpromotor3.Text) + Double.Parse(txtpromotor4.Text) + Double.Parse(txtrcliente.Text), 2)

                    txtutilidad.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) - Double.Parse(txtsumar.Text) - Double.Parse(txt11.Text) - Double.Parse(txt12.Text), 2)

                Else
                    txtcalculo.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcobrado")) / 100), 2)

                    If Integer.Parse(rwComisionClienteFlujo(0).Item("sobresubtotal")) = 1 Then
                        'promotor
                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                            txtpromotor1.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                        Else
                            txtpromotor1.Text = "0.00"
                        End If

                        'promotor2
                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                            txtpromotor2.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                        Else
                            txtpromotor2.Text = "0.00"
                        End If

                        'promotor3
                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                            txtpromotor3.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                        Else
                            txtpromotor3.Text = "0.00"
                        End If

                        'promotor4
                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                            txtpromotor4.Text = Math.Round(Double.Parse(datos(0).SubItems(7).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                        Else
                            txtpromotor4.Text = "0.00"
                        End If
                    Else
                        'promotor
                        If rwComisionClienteFlujo(0).Item("promotor1") = "1" Then
                            txtpromotor1.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje1")) / 100), 2)
                        Else
                            txtpromotor1.Text = "0.00"
                        End If

                        'promotor2
                        If rwComisionClienteFlujo(0).Item("promotor2") = "1" Then
                            txtpromotor2.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje2")) / 100), 2)
                        Else
                            txtpromotor2.Text = "0.00"
                        End If

                        'promotor3
                        If rwComisionClienteFlujo(0).Item("promotor3") = "1" Then
                            txtpromotor3.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje3")) / 100), 2)
                        Else
                            txtpromotor3.Text = "0.00"
                        End If

                        'promotor4
                        If rwComisionClienteFlujo(0).Item("promotor4") = "1" Then
                            txtpromotor4.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * (Double.Parse(rwComisionClienteFlujo(0).Item("porcentaje4")) / 100), 2)
                        Else
                            txtpromotor4.Text = "0.00"
                        End If

                    End If


                    'retorno cliente
                    txtrcliente.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) - Double.Parse(txtcalculo.Text), 2)

                    txt11.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * 0.01, 2)

                    txt12.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) * 0.01, 2)

                    txtsumar.Text = Math.Round(Double.Parse(txtpromotor1.Text) + Double.Parse(txtpromotor2.Text) + Double.Parse(txtpromotor3.Text) + Double.Parse(txtpromotor4.Text) + Double.Parse(txtrcliente.Text), 2)

                    txtutilidad.Text = Math.Round(Double.Parse(datos(0).SubItems(10).Text) - Double.Parse(txtsumar.Text) - Double.Parse(txt11.Text) - Double.Parse(txt12.Text), 2)

                End If


            Else
                MessageBox.Show("No existe la comisión cobrada al cliente, para esta factura de " & IIf(Integer.Parse(datos(0).SubItems(19).Text) = 1, "Flujo", "Flujo-Nomina"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                iIdFactura = "0"
            End If


        Else
            MessageBox.Show("No hay una factura seleccionada para calcular", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Dim Mensaje As String = "", nombresistema As String = ""
        Dim bandera As Boolean
        Dim tipoflujo As Integer

        Try



            'Validar


            If txtcalculo.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique el calculo"
            End If
            If txtpromotor1.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique promotor1"
            End If

            If txtpromotor2.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique promotor2"
            End If
            If txtpromotor3.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique promotor3"
            End If
            If txtpromotor4.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique promotor4"
            End If
            If txtrcliente.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique retornocliente"
            End If
            If txt11.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique monto 1%"
            End If
            If txt12.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique monto 1%"
            End If
            If txtsumar.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique la suma de los retornos"
            End If
            If txtutilidad.Text.Trim.Length = 0 And Mensaje = "" Then
                Mensaje = "Por favor indique la utilidad"
            End If



            If Mensaje <> "" Then
                MessageBox.Show(Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            bandera = True




            If iIdFactura <> "0" Then

                'buscamos la factura si ya esta guardada

                SQL = "select * from CalculoFlujoCManual where fkiIdFactura=" & iIdFactura


                Dim rwFilas As DataRow() = nConsulta(SQL)

                If rwFilas Is Nothing = False Then
                    Dim Fila As DataRow = rwFilas(0)
                    Dim resultado As Integer = MessageBox.Show("¿La factura calculada ya ha sido guardado con anterioridad, ¿desea sobreescribir?", "Pregunta", MessageBoxButtons.YesNo)
                    If resultado = DialogResult.Yes Then
                        'Borramos y volvemos a guardar

                        SQL = "delete from CalculoFlujoCManual where fkiIdFactura=" & iIdFactura


                        If nExecute(SQL) = False Then

                            MessageBox.Show("Ocurrio un error," & SQL, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        SQL = "EXEC setCalculoFlujoCManualInsertar  0," & iIdFactura & ",'" & txtcomision.Text
                        SQL &= "'," & IIf(txtcalculo.Text = "", 0, txtcalculo.Text)
                        SQL &= "," & IIf(txtpromotor1.Text = "", 0, txtpromotor1.Text)
                        SQL &= "," & (IIf(txtpromotor2.Text = "", 0, txtpromotor2.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txtpromotor3.Text = "", 0, txtpromotor3.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txtpromotor4.Text = "", 0, txtpromotor4.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txtrcliente.Text = "", 0, txtrcliente.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txt11.Text = "", 0, txt11.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txt12.Text = "", 0, txt12.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txtsumar.Text = "", 0, txtsumar.Text)).ToString.Replace(",", "")
                        SQL &= "," & (IIf(txtutilidad.Text = "", 0, txtutilidad.Text)).ToString.Replace(",", "")



                        If nExecute(SQL) = False Then
                            Exit Sub
                        End If

                        MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Limpiar()


                    ElseIf resultado = DialogResult.No Then
                        Exit Sub
                    End If
                Else
                    'Insertar nuevo
                    SQL = "EXEC setCalculoFlujoCManualInsertar 0," & iIdFactura & ",'" & txtcomision.Text
                    SQL &= "'," & IIf(txtcalculo.Text = "", 0, txtcalculo.Text)
                    SQL &= "," & IIf(txtpromotor1.Text = "", 0, txtpromotor1.Text)
                    SQL &= "," & (IIf(txtpromotor2.Text = "", 0, txtpromotor2.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txtpromotor3.Text = "", 0, txtpromotor3.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txtpromotor4.Text = "", 0, txtpromotor4.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txtrcliente.Text = "", 0, txtrcliente.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txt11.Text = "", 0, txt11.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txt12.Text = "", 0, txt12.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txtsumar.Text = "", 0, txtsumar.Text)).ToString.Replace(",", "")
                    SQL &= "," & (IIf(txtutilidad.Text = "", 0, txtutilidad.Text)).ToString.Replace(",", "")



                    If nExecute(SQL) = False Then
                        Exit Sub
                    End If

                    MessageBox.Show("Datos Guardados correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                End If




            Else
                MessageBox.Show("No hay calculo previo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If




        Catch ex As Exception

        End Try
    End Sub

    Private Sub Limpiar()
        'cboempresa.SelectedIndex = 0

        txtcomision.Text = ""
        txtcalculo.Text = ""
        txtpromotor1.Text = ""
        txtpromotor2.Text = ""
        txtpromotor3.Text = ""
        txtpromotor4.Text = ""
        txtrcliente.Text = ""
        txtsumar.Text = ""
        txtutilidad.Text = ""



    End Sub

    Private Sub txtcomision_TextChanged(sender As Object, e As EventArgs) Handles txtcomision.TextChanged

    End Sub

    Private Sub txtcomision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcomision.KeyPress
        'SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtcalculo_TextChanged(sender As Object, e As EventArgs) Handles txtcalculo.TextChanged

    End Sub

    Private Sub txtcalculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcalculo.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtpromotor1_TextChanged(sender As Object, e As EventArgs) Handles txtpromotor1.TextChanged

    End Sub

    Private Sub txtpromotor1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpromotor1.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtpromotor2_TextChanged(sender As Object, e As EventArgs) Handles txtpromotor2.TextChanged

    End Sub

    Private Sub txtpromotor2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpromotor2.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtpromotor3_TextChanged(sender As Object, e As EventArgs) Handles txtpromotor3.TextChanged

    End Sub

    Private Sub txtpromotor3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpromotor3.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtpromotor4_TextChanged(sender As Object, e As EventArgs) Handles txtpromotor4.TextChanged

    End Sub

    Private Sub txtpromotor4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpromotor4.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtrcliente_TextChanged(sender As Object, e As EventArgs) Handles txtrcliente.TextChanged

    End Sub

    Private Sub txtrcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrcliente.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txt11_TextChanged(sender As Object, e As EventArgs) Handles txt11.TextChanged

    End Sub

    Private Sub txt11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt11.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txt12_TextChanged(sender As Object, e As EventArgs) Handles txt12.TextChanged

    End Sub

    Private Sub txt12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt12.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtsumar_TextChanged(sender As Object, e As EventArgs) Handles txtsumar.TextChanged

    End Sub

    Private Sub txtsumar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsumar.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub

    Private Sub txtutilidad_TextChanged(sender As Object, e As EventArgs) Handles txtutilidad.TextChanged

    End Sub

    Private Sub txtutilidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtutilidad.KeyPress
        SoloNumero.NumeroDec(e, sender)
    End Sub
End Class