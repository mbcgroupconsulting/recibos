Imports ClosedXML.Excel
Public Class frmPrincipal

    Dim SQL As String
    Private Sub frmPrincipal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If sender Is Nothing = False Then
            Dim Forma As Windows.Forms.Form = CType(sender, Windows.Forms.Form)
            Dim Nombre As String = Forma.Name
            If Nombre = "frmFacturar" Then
                chkCFDI.Visible = False
                AjustarBarra()
            ElseIf Nombre = "frmFacturaCBB" Then
                chkCBB.Visible = False
                AjustarBarra()
            End If
        End If
    End Sub

    Private Sub AjustarBarra()
        chkCFDI.Left = lblUsuario.Left + lblUsuario.Width + 10
        chkCBB.Left = lblUsuario.Left + lblUsuario.Width + IIf(chkCFDI.Visible, chkCFDI.Width + 5, 0) + 10
    End Sub

    Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("¿Desea salir del sistema?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblUsuario.Text = Usuario.Nombre
        clsConfiguracion.Actualizar()
    End Sub

    Private Sub CatálogoDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim Forma As New Vendedores
        'Forma.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)

        Try
            If rwFilas Is Nothing = False Then
                Dim forma As New frmImportarFlujoConConceptos


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") <> "2") Then
                    Dim PT As Point = Me.PointToScreen(CheckBox1.Location)

                    If CheckBox1.Checked Then
                        MenuInicio.Show(CheckBox1.Location.X, (CheckBox1.Location.Y + pnlBar.Location.Y) - ((CheckBox1.Height - 4) * MenuInicio.Items.Count))
                        CheckBox1.Checked = False
                    End If

                Else
                    MessageBox.Show("No tiene permisos" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try

        
    End Sub

    Private Sub frmPrincipal_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If sender Is Nothing = False Then
            Dim Forma As Windows.Forms.Form = CType(sender, Windows.Forms.Form)
            Dim Nombre As String = Forma.Name
            If Nombre = "frmFacturar" Then
                'RemoveHandler chkCFDI.CheckedChanged, AddressOf chkCFDI_CheckedChanged
                chkCFDI.Checked = Forma.WindowState <> FormWindowState.Minimized
                'frmFacturacionCFDI.Visible = frmFacturacionCFDI.WindowState <> FormWindowState.Minimized
                'AddHandler chkCFDI.CheckedChanged, AddressOf chkCFDI_CheckedChanged
            ElseIf Nombre = "frmFacturaCBB" Then
                'RemoveHandler chkCBB.CheckedChanged, AddressOf chkCBB_CheckedChanged
                chkCBB.Checked = Forma.WindowState <> FormWindowState.Minimized
                'frmFacturacionCBB.Visible = frmFacturacionCBB.WindowState <> FormWindowState.Minimized
                'AddHandler chkCBB.CheckedChanged, AddressOf chkCBB_CheckedChanged
            End If
        End If
    End Sub

    Private Sub lsvPanel_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvPanel.ItemActivate
        Try
            If lsvPanel.SelectedItems.Count <= 0 Then
                Exit Sub
            End If
            Select Case lsvPanel.SelectedItems(0).Text
                Case "Facturación CBB"
                    'If chkCBB.Visible = False Then
                    '    frmFacturacionCBB = New frmFacturaCBB
                    '    AddHandler frmFacturacionCBB.SizeChanged, AddressOf frmPrincipal_SizeChanged
                    '    AddHandler frmFacturacionCBB.FormClosed, AddressOf frmPrincipal_FormClosed
                    '    chkCBB.Checked = True
                    '    frmFacturacionCBB.Show(Me)
                    '    chkCBB.Visible = True
                    '    AjustarBarra()
                    'Else
                    '    chkCBB.Checked = True
                    'End If
                Case "Facturación CFDI"
                    'If chkCFDI.Visible = False Then
                    '    frmFacturacionCFDI = New frmFacturar
                    '    AddHandler frmFacturacionCFDI.SizeChanged, AddressOf frmPrincipal_SizeChanged
                    '    AddHandler frmFacturacionCFDI.FormClosed, AddressOf frmPrincipal_FormClosed
                    '    chkCFDI.Checked = True
                    '    frmFacturacionCFDI.WindowState = FormWindowState.Normal
                    '    frmFacturacionCFDI.Show(Me)
                    '    chkCFDI.Visible = True
                    '    AjustarBarra()
                    'Else
                    '    chkCFDI.Checked = True
                    'End If
                Case "Recibos Via Sindicato"
                    Dim forma As New frmImportarExcel
                    forma.ShowDialog()
                Case "Recibos Via Fiscal"
                    Dim forma As New frmRecibosFiscalVia
                    forma.ShowDialog()
                    'Dim Forma As New Vendedores
                    'Forma.ShowDialog()
                Case "Recibos Sindicato"
                    Dim forma As New frmRecibosSLupita
                    forma.ShowDialog()
                Case "Recibo TMM Fiscal"
                    Dim forma As New frmTMMFiscal


                    forma.ShowDialog()
                    'If ValidarPermiso("02,03,") Then
                    'Dim Forma As New frmPanelCTRL
                    'Forma.ShowDialog()
                Case "Guo Aguinaldo"
                    Dim forma As New frmAguinaldoGuo
                    forma.ShowDialog()
                Case "Importacion Guo"
                    Dim forma As New ImportacionGuo
                    forma.ShowDialog()
                Case "Altas Guo"
                    Dim forma As New ImportacionAltas
                    forma.ShowDialog()

                    'Dim Forma As New frmVentaS
                    'Forma.ShowDialog()
                    'End If
                Case "Importacion Flujos"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmImportarFlujoConConceptos


                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "8") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception

                    End Try
                Case "Fiscal TMMxT"

                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmTMMFiscalAuto


                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Case "Sindicato TMMxT"

                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmTMMSindicatoAuto

                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try

                Case "Exportar nomina TMM"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmExportarNominaTMM


                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Case "Exportar gastos viaje"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmExportarGastoViajeTMM



                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Case "Exportar anticipos nomina"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmExportarAnticipoTMM



                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Case "Asimilados Marinos"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmTMMAsimiladoAuto



                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Case "Simple Maecco Sindicato"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmMaeccoSimpleSindicato

                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Case "Bancomer nomina"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmComprobanteBancomer

                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Case "Citibanamex Nomina"
                    SQL = "select * from usuarios where idUsuario = " & idUsuario
                    Dim rwFilas As DataRow() = nConsulta(SQL)

                    Try
                        If rwFilas Is Nothing = False Then
                            Dim forma As New frmComprobanteBanamex

                            Dim Fila As DataRow = rwFilas(0)
                            If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                                forma.ShowDialog()
                            Else
                                MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            End If
                        End If

                    Catch ex As Exception
                    End Try
            End Select

        Catch ex As Exception
            ShowError(ex, Me.Text)
        End Try
    End Sub

   

    Private Sub lsvPanel_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvPanel.SizeChanged
        Dim sRuta As String
        sRuta = System.IO.Path.GetTempPath
        Try
            Me.lsvPanel.BackgroundImage = Me.PictureBox1.Image.GetThumbnailImage(Me.lsvPanel.ClientSize.Width, Me.lsvPanel.ClientSize.Height, Nothing, Nothing)
            Me.BackgroundImage = Me.PictureBox1.Image.GetThumbnailImage(Me.lsvPanel.ClientSize.Width, Me.lsvPanel.ClientSize.Height, Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pnlBar_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlBar.Paint
        Degradado(e, sender, Color.White, Color.Gray, Drawing2D.LinearGradientMode.Vertical)
    End Sub

    Private Sub lblUsuario_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblUsuario.SizeChanged
        AjustarBarra()
    End Sub

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub


    Private Sub CatalogosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatalogosToolStripMenuItem.Click


    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmClientes
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "8" Or Fila.Item("fkIdPerfil") = "9" Or Fila.Item("fkIdPerfil") = "10" Or Fila.Item("fkIdPerfil") = "6") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub EmpresasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresasToolStripMenuItem.Click
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmEmpresas
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6" Or Fila.Item("fkIdPerfil") = "8") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub TipoEmpresasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoEmpresasToolStripMenuItem.Click
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub AltaNominasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltaNominasToolStripMenuItem.Click

        'Dim Forma As New frmEmpleadosXCliente
        ' '' Dim Forma As New AltaNominaEmpleado
        'Forma.ShowDialog()

    End Sub

    Private Sub MenuInicio_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MenuInicio.Opening

    End Sub

    Private Sub ConciliacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConciliacionToolStripMenuItem.Click




    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturacionToolStripMenuItem.Click
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmcapturafactura

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "8" Or Fila.Item("fkIdPerfil") = "9") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub ImportarGastosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ImportarGastosToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmImportarGastos


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub MostrarGastosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MostrarGastosToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmListaGastos


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub VerEmpresasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VerEmpresasToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmEmpresasC


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1") Or (Fila.Item("fkIdPerfil") = "5") Or (Fila.Item("fkIdPerfil") = "3") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FlujoBToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FlujoBToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New flujob


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SubirAControlTesoreriaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SubirAControlTesoreriaToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New importacionflujob


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PlaneaciónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PlaneaciónToolStripMenuItem.Click

    End Sub

    Private Sub VerEmpresasToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VerEmpresasToolStripMenuItem1.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmEmpresasCIMSS


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SAToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SAToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmPlaneacionSA


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "9" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ASIMILADOSToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ASIMILADOSToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmPlaneacionAsi

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "9" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PromotoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromotoresToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmpromotor

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClientePromotorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClientePromotorToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmPromotorCliente

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComisionesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComisionesToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmComisiones

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AsociarClientesEmpresasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AsociarClientesEmpresasToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmIntClientesEmpresas

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "6") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgregarDatoContabilidadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AgregarDatoContabilidadToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmAgregarContabilidadk

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "9") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgregarDatosJuridicoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AgregarDatosJuridicoToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmAgregarImss

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgregarDatosNominasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AgregarDatosNominasToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmAgregarNominaK

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "9") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AsociarComisiónClienteFlujoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CalcularFlujoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub AsociarComisiónClienteFlujoCToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AsociarComisiónClienteFlujoCToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmComisionFlujosClientes


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalcularFlujoCToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CalcularFlujoCToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmCalculoFlujo


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DescargarReporteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DescargarReporteToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmReportexEmpresa


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AsociarComisiónClienteFlujoNominaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AsociarComisiónClienteFlujoNominaToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmComisionFlujosClientesNomina


        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarCalculoManualToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GuardarCalculoManualToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmIngresarDatosFlujoC



        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub




    Private Sub ImportarFlujosConceptosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarFlujosConceptosToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmImportarConceptosFlujo



        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "6") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarFlujosConceptosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MostrarFlujosConceptosToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmMostrarflujoconcepto



        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "6" Or Fila.Item("fkIdPerfil") = "8" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportesFlujosConceptosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ReportesFlujosConceptosToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmReporteConceptoJuridico

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "6" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NominaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NominaToolStripMenuItem.Click

    End Sub

    Private Sub MostrarEmpleadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarEmpleadosToolStripMenuItem.Click
        Dim Forma As New frmEmpleadosXCliente
        '' Dim Forma As New AltaNominaEmpleado
        Forma.ShowDialog()
    End Sub

    Private Sub ImportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem.Click
        Dim Forma As New frmImportarEmpleadosAlta
        '' Dim Forma As New AltaNominaEmpleado
        Forma.ShowDialog()
    End Sub

    Private Sub ConciliarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConciliarToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmFondeoPatrona

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "9") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SubirDatosBancoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SubirDatosBancoToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmSubirInfoBancosConciliacion

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarDatosBancoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MostrarDatosBancoToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmMostrarInfoBancosConciliacion

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Conciliar10ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Conciliar10ToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmconcilia

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "9") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub ControlTesoreriaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlTesoreriaToolStripMenuItem1.Click
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmcontrol

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "8" Or Fila.Item("Nombre") = "Petrus") Or Fila.Item("fkIdPerfil") = "9" Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContratToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContratToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmContratos

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)


                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "6") Then


                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FondeoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FondeoToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmFondeo

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CapturaDeChequesAsignadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CapturaDeChequesAsignadosToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmCapturaChequesAsignados

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub VerChequesAsginadosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VerChequesAsginadosToolStripMenuItem.Click
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmListarCheques

        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "4") Then

                    Forma.ShowDialog()
                Else
                    MessageBox.Show("No tiene permisos para esta ventana" & vbCrLf & "Comuniquese con el administrador del sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
