﻿Public Class frmEmpresasCIMSS
    Dim iBuscar As Integer
    Private Sub frmEmpresasCIMSS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim resultado As Integer = MessageBox.Show("¿Desea buscar actualizaciones de nuevas empresas y periodos en contpaq?, Este proceso puede tardar hasta dos minutos", "Pregunta", MessageBoxButtons.YesNo)
        If resultado = DialogResult.Yes Then
            ObtenerEmpresas()
            iBuscar = 1
        ElseIf resultado = DialogResult.No Then
            iBuscar = 0
        End If

        CargarEmpresas()
    End Sub

    Private Sub ObtenerEmpresas()
        Try
            Dim SQL As String
            Dim iBan As Integer
            'TransaccionContpaq = CONTPAQCONEXION.BeginTransaction
            ConectarContpaq("nomGenerales")
            mdoObjetos2.sBase = "nomGenerales"
            SQL = "select * from NOM10000 order by idEmpresa"
            Dim rwEmpresasC As DataRow() = nConsultaContpaq(SQL)
            If rwEmpresasC Is Nothing = False Then
                SQL = "select * from empresaC"
                Dim rwEmpresasMBC As DataRow() = nConsulta(SQL)
                If rwEmpresasMBC Is Nothing = False Then
                    For x As Integer = 0 To rwEmpresasC.Length - 1
                        iBan = 0
                        For y As Integer = 0 To rwEmpresasMBC.Length - 1
                            If rwEmpresasC(x)("RutaEmpresa").ToString() = rwEmpresasMBC(y)("ruta").ToString Then
                                iBan = 1
                                y = rwEmpresasMBC.Length
                            End If
                        Next
                        If iBan = 0 Then
                            SQL = "EXEC setEmpresaCInsertar  0,'" & rwEmpresasC(x)("NombreEmpresa")
                            SQL &= "','" & rwEmpresasC(x)("RutaEmpresa")
                            SQL &= "',1,0,0,1,'','',0,0"
                            If nExecute(SQL) = False Then
                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                'pnlProgreso.Visible = False
                                Exit Sub

                            End If
                        End If
                    Next
                Else
                    'insertamos todas las empresas
                    For x As Integer = 0 To rwEmpresasC.Length - 1
                        'Dim Fila As DataRow = rwGastos(0)
                        SQL = "EXEC setEmpresaCInsertar  0,'" & rwEmpresasC(x)("NombreEmpresa")
                        SQL &= "','" & rwEmpresasC(x)("RutaEmpresa")
                        SQL &= "',1,0,0,1,'','',0,0"
                        If nExecute(SQL) = False Then
                            MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'pnlProgreso.Visible = False
                            Exit Sub

                        End If
                    Next
                End If
            End If
            DesconectarContpaq()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarEmpresas()
        Try
            Dim Alter As Boolean = False
            Dim SQL As String
            Dim iBan As Integer


            lsvLista.Items.Clear()
            lsvLista.Clear()


            SQL = "select iIdEmpresaC,empresaC.nombre as empresac, ruta, empresa.nombre as empresa,"
            SQL &= "empresa.registropatronal,clientes.nombre as cliente "
            SQL &= " from (empresaC left join empresa on empresaC.fkiIdEmpresa=empresa.iIdEmpresa)"
            SQL &= " left join clientes on empresac.fkiIdCliente = clientes.iIdCliente"
            SQL &= " order by empresac.nombre"

            Dim item As ListViewItem
            lsvLista.Columns.Add("Nombre")
            lsvLista.Columns(0).Width = 250
            lsvLista.Columns.Add("Nombre Base")
            lsvLista.Columns(1).Width = 170
            lsvLista.Columns.Add("Empresa patrona")
            lsvLista.Columns(2).Width = 350
            lsvLista.Columns.Add("Registro Patronal")
            lsvLista.Columns(3).Width = 120
            lsvLista.Columns.Add("Cliente Asignado")
            lsvLista.Columns(4).Width = 270

            Dim rwEmpresaC As DataRow() = nConsulta(SQL)
            If rwEmpresaC Is Nothing = False Then
                For Each Fila In rwEmpresaC

                    If iBuscar = 1 Then
                        If Fila.Item("ruta") <> "" And Fila.Item("ruta") <> "ctCSyAP" Then
                            'importamos los tipos de periodo
                            ConectarContpaq(Fila.Item("ruta"))
                            SQL = "select * from nom10023"
                            Dim rwTiposPeriodoC As DataRow() = nConsultaContpaq(SQL)
                            If rwTiposPeriodoC Is Nothing = False Then

                                SQL = "select * from tipos_periodo where fkiIdEmpresa=" & Fila.Item("iIdEmpresaC")
                                Dim rwTiposPeriodo As DataRow() = nConsulta(SQL)
                                If rwTiposPeriodo Is Nothing = False Then

                                    For x As Integer = 0 To rwTiposPeriodoC.Length - 1
                                        iBan = 0
                                        For y As Integer = 0 To rwTiposPeriodo.Length - 1
                                            If rwTiposPeriodoC(x)("nombretipoperiodo").ToString() = rwTiposPeriodo(y)("cNombrePeriodo").ToString Then
                                                iBan = 1
                                                y = rwTiposPeriodo.Length
                                            End If
                                        Next
                                        If iBan = 0 And rwTiposPeriodoC(x)("nombretipoperiodo") <> "Periodo Extraordinario" Then
                                            SQL = "EXEC settipos_periodoInsertar 0,'" & rwTiposPeriodoC(x)("nombretipoperiodo")
                                            SQL &= "'," & rwTiposPeriodoC(x)("diasdelperiodo") & "," & rwTiposPeriodoC(x)("diasdepago")
                                            SQL &= "," & rwTiposPeriodoC(x)("ejercicio") & "," & Fila.Item("iIdEmpresaC")
                                            SQL &= ",1"
                                            If nExecute(SQL) = False Then
                                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                'pnlProgreso.Visible = False
                                                Exit Sub

                                            End If
                                        End If
                                    Next

                                Else
                                    For x As Integer = 0 To rwTiposPeriodoC.Length - 1

                                        If rwTiposPeriodoC(x)("nombretipoperiodo") <> "Periodo Extraordinario" Then
                                            SQL = "EXEC settipos_periodoInsertar 0,'" & rwTiposPeriodoC(x)("nombretipoperiodo")
                                            SQL &= "'," & rwTiposPeriodoC(x)("diasdelperiodo") & "," & rwTiposPeriodoC(x)("diasdepago")
                                            SQL &= "," & rwTiposPeriodoC(x)("ejercicio") & "," & Fila.Item("iIdEmpresaC")
                                            SQL &= ",1"
                                            If nExecute(SQL) = False Then
                                                MessageBox.Show("Ocurrio un error ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                'pnlProgreso.Visible = False
                                                Exit Sub

                                            End If
                                        End If

                                    Next

                                End If
                            End If

                            DesconectarContpaq()
                        End If
                    End If





                    'cargamos lista

                    item = lsvLista.Items.Add("" & Fila.Item("empresac"))

                    item.SubItems.Add("" & Fila.Item("ruta"))
                    item.SubItems.Add("" & Fila.Item("empresa"))
                    item.SubItems.Add("" & Fila.Item("registropatronal"))
                    item.SubItems.Add("" & Fila.Item("cliente"))

                    item.Tag = Fila.Item("iIdEmpresaC")
                    'item.BackColor = IIf(Alter, Color.WhiteSmoke, Color.White)
                    Alter = Not Alter
                Next
                MessageBox.Show(rwEmpresaC.Count & " Registros encontrados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No se encontraron datos en ese rango de fecha", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub lsvLista_ItemActivate(sender As Object, e As EventArgs) Handles lsvLista.ItemActivate
        Dim id As Long
        Dim idperiodo As Long
        Dim nombre As String
        Dim sql As String
        If lsvLista.SelectedItems.Count > 0 Then
            id = lsvLista.SelectedItems(0).Tag

            Dim Forma As New frmPeriodosIMSS
            Forma.gIEmpresa = id
            If Forma.ShowDialog = Windows.Forms.DialogResult.OK Then
                idperiodo = Forma.gIPeriodo
                nombre = Forma.gNombrePeriodo
                Dim Forma2 As New frmcontpaqimss
                Forma2.gIdEmpresa = id
                Forma2.gIdTipoPeriodo = idperiodo
                Forma2.gNombrePeriodo = nombre
                Forma2.ShowDialog()



            End If



        End If
    End Sub
End Class