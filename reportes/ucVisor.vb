Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ucVisor
    Dim gReporte As String
    Dim gSeleccion As String
    Dim gFiltros As String
    Dim gParametros As String
    Dim gConectado As Boolean = False
    Dim oReporte As ReportDocument = Nothing
    Dim gdsOrigen As DataSet

    Public Property crReporte As ReportDocument
        Get
            Return oReporte
        End Get
        Set(value As ReportDocument)
            oReporte = value
        End Set
    End Property

    Public Property DataSource As DataSet

        Get
            If gdsOrigen Is Nothing Then
                Return Nothing
            Else
                Return gdsOrigen.Copy
            End If

        End Get
        Set(ByVal value As DataSet)
            If value Is Nothing = False Then
                gdsOrigen = value.Copy
            Else
                gdsOrigen = Nothing
            End If
        End Set
    End Property

    Public Property Conectado As Boolean
        Get
            Return gConectado
        End Get
        Set(ByVal value As Boolean)
            gConectado = value
        End Set
    End Property


    Public Property Reporte As String
        Get
            Return gReporte
        End Get
        Set(ByVal value As String)
            gReporte = value
        End Set
    End Property

    Public Property Seleccion As String
        Get
            Return gSeleccion
        End Get
        Set(ByVal value As String)
            gSeleccion = value
        End Set
    End Property

    Public Property Filtros As String
        Get
            Return gFiltros
        End Get
        Set(ByVal value As String)
            gFiltros = value
        End Set
    End Property

    Public Property Parametros As String
        Get
            Return gParametros
        End Get
        Set(ByVal value As String)
            gParametros = value
        End Set
    End Property

    Public Sub ShowReport()
        If gdsOrigen Is Nothing Then
            MostrarReporte()
        Else
            MostrarReporteDS()
        End If
    End Sub


    Private Sub ucVisor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub MostrarReporteDS()

        Dim sRuta As String = Application.StartupPath & "\Reportes\" & gReporte & ".rpt"
        Dim crParametros As ParameterFields


        Dim Reporte As New CrystalDecisions.CrystalReports.Engine.ReportClass
        If IO.File.Exists(sRuta) Or oReporte Is Nothing = False Then
            Try

                If oReporte Is Nothing = False Then
                    Reporte = oReporte
                Else
                    Reporte.FileName = sRuta
                End If

                Reporte.SetDataSource(gdsOrigen)

                If gConectado Then
                    Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
                    Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
                    For Each tbCurrent In Reporte.Database.Tables
                        tliCurrent = tbCurrent.LogOnInfo
                        With tliCurrent.ConnectionInfo
                            .ServerName = IIf(Servidor.Central, Servidor.Nombre, Servidor.sIP)
                            .UserID = IIf(Servidor.Central, Servidor.User, Servidor.sUser)
                            .Password = IIf(Servidor.Central, Servidor.PWD, Servidor.sPWD)
                            .DatabaseName = IIf(Servidor.Central, Servidor.Base, Servidor.sBase)
                            .AllowCustomConnection = True
                        End With
                        tbCurrent.ApplyLogOnInfo(tliCurrent)
                    Next tbCurrent
                End If

                If gParametros <> "" Then
                    Dim Parametros() As String = gParametros.Split("|")
                    crParametros = New ParameterFields
                    For i As Integer = 0 To Parametros.Length - 1 Step 2
                        Dim crParam As New ParameterField, crDiscretValue As New ParameterDiscreteValue

                        crParam.Name = Parametros(i)
                        crParam.ParameterValueType = ParameterValueKind.StringParameter
                        crDiscretValue.Value = Parametros(i + 1)
                        crParam.CurrentValues.Add(crDiscretValue)
                        crParametros.Add(crParam)
                    Next
                    crvVisor.ParameterFieldInfo = crParametros
                End If

                Me.crvVisor.ReportSource = Reporte
                Me.crvVisor.Refresh()

            Catch ex As Exception
                ShowError(ex, Me.Text)
            End Try
        Else
            MessageBox.Show("No se encuentra el archivo de reporte:" & vbCrLf & sRuta, "Visor de reportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub MostrarReporte()
        Dim sRuta As String = Application.StartupPath & "\Reportes\" & gReporte & ".rpt"
        Dim crParametros As ParameterFields


        Dim Reporte As New CrystalDecisions.CrystalReports.Engine.ReportClass
        If IO.File.Exists(sRuta) Or oReporte Is Nothing Then
            Try
                If oReporte Is Nothing Then
                    Reporte.FileName = sRuta
                Else
                    Reporte = oReporte
                End If

                'CODIGO ANTERIOR DE ENRUTAMIENTO
                '_____________________________________________________________________________________________
                Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
                Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
                For Each tbCurrent In Reporte.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .ServerName = IIf(Servidor.Central, Servidor.Nombre, Servidor.sIP)
                        .UserID = IIf(Servidor.Central, Servidor.User, Servidor.sUser)
                        .Password = IIf(Servidor.Central, Servidor.PWD, Servidor.sPWD)
                        .DatabaseName = IIf(Servidor.Central, Servidor.Base, Servidor.sBase)
                        .AllowCustomConnection = True
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                '____________________________________________________________
                'CODIGO NUEVO
                '_______________________________________________
                'Reporte.DataSourceConnections.Item(0).SetConnection(Servidor.IP, Servidor.Base, False)
                'Reporte.DataSourceConnections.Item(0).SetLogon(Servidor.User, Servidor.PWD)
                '_______________________________________________
                Select Case gReporte
                    Case "rptColegiaturaTotalSF"
                        Reporte.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                        Reporte.PrintOptions.PaperSize = PaperSize.PaperLegal
                End Select


                If gFiltros <> "" Then
                    Dim aFiltro() As String = gFiltros.Split("|")
                    For i As Integer = 0 To aFiltro.Length - 1 Step 2
                        Reporte.SetParameterValue(aFiltro(i).ToString, aFiltro(i + 1))
                    Next
                End If

                If gParametros <> "" Then
                    Dim Parametros() As String = gParametros.Split("|")
                    crParametros = New ParameterFields
                    For i As Integer = 0 To Parametros.Length - 1 Step 2
                        Dim crParam As New ParameterField, crDiscretValue As New ParameterDiscreteValue

                        crParam.Name = Parametros(i)
                        crParam.ParameterValueType = ParameterValueKind.StringParameter
                        crDiscretValue.Value = Parametros(i + 1)
                        crParam.CurrentValues.Add(crDiscretValue)
                        crParametros.Add(crParam)
                    Next
                    crvVisor.ParameterFieldInfo = crParametros
                End If

            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error al generar el reporte: " & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try

            'crvVisor.ParameterFieldInfo.
            Reporte.RecordSelectionFormula = gSeleccion
            Me.crvVisor.ReportSource = Reporte
            Me.crvVisor.Refresh()

        End If
    End Sub

End Class
