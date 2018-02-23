Imports Microsoft.Office.Interop.Word 'control de office
Imports Microsoft.Office.Interop.Excel
Imports System.IO 'sistema de archivos
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.SqlClient
Public Class frmJuridico
    Public gIdEmpresa As String
    Public gIdCliente As String
    Public gIdEmpleado As String

    Private Sub cmdoficio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoficio.Click
        Dim MSWord As New Word.Application
        Dim MSWordL As New Word.Application
        Dim Documento As Word.Document
        Dim DocumentoL As Word.Document
        Dim Ruta As String, strPWD As String
        Dim Ruta2 As String
        Dim Empleados As String()
        Dim SQL As String

        'Verificar que archivo le corresponde a la empresa

        SQL = "select * from Contratos where fkiIdEmpresa=" & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        'Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)

                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\" & Fila.Item("Oficio") & ".docx"
                Ruta2 = System.Windows.Forms.Application.StartupPath & "\Archivos\oficio1L.docx"
                'If chkLotes.Checked And rbOficio.Checked Then
                '    Empleados = txtlotes.Text.Split(",")
                '    If Empleados.Length = 1 Then
                '        MessageBox.Show("Solo existe un código de empleado por favor generarlo de la manera normal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    ElseIf Empleados.Length > 1 Then

                FileCopy(Ruta2, "C:\Temp\oficioL.docx")
                DocumentoL = MSWordL.Documents.Open("C:\Temp\oficioL.docx")

                For i = 1 To Empleados.Length - 1

                    FileCopy(Ruta, "C:\Temp\oficio1.docx")
                    Documento = MSWord.Documents.Open("C:\Temp\oficio1.docx")

                    'Buscamos datos del empleado

                    SQL = "select * from empleadosAlta where iIdEmpleadoAlta = " & gIdEmpleado
                    Dim rwEmpleado As DataRow() = nConsulta(SQL)

                    If rwEmpleado Is Nothing = False Then

                        Dim fEmpleado As DataRow = rwEmpleado(0)



                        Documento.Bookmarks.Item("nombrecompleto").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                        Documento.Bookmarks.Item("imss").Range.Text = fEmpleado.Item("cIMSS")
                        Documento.Bookmarks.Item("nombrecompleto2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")

                        Documento.Save()


                        Dim rango As Word.Range
                        rango = Documento.Range()
                        rango.Select()
                        Documento.Select()

                        'MSWord.Visible = True
                        DocumentoL.Range.Text = rango.Text
                        Documento.Close()
                    End If
                Next
                MSWordL.Visible = True

                'Else
                '    MessageBox.Show("No hay códigos de empleado, para generar el lote", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

                '    Else
                'FileCopy(Ruta, "C:\Temp\oficio.docx")
                'Documento = MSWord.Documents.Open("C:\Temp\oficio.docx")

                ''Buscamos datos del empleado

                '    SQL = "select * from empleadosAlta where iIdEmpleadoAlta = " & gIdEmpleado
                '    Dim rwEmpleado As DataRow() = nConsulta(SQL)

                '    If rwEmpleado Is Nothing = False Then

                '        Dim fEmpleado As DataRow = rwEmpleado(0)



                '        Documento.Bookmarks.Item("nombrecompleto").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                '        Documento.Bookmarks.Item("imss").Range.Text = fEmpleado.Item("cIMSS")

                '        Documento.Save()
                '        MSWord.Visible = True

                '    End If

                'End If



            Else
                MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            Documento.Close()
        End Try


    End Sub

    Private Sub cmdsimple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsimple.Click
        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String

        'Verificar que archivo le corresponde a la empresa

        SQL = "select * from Contratos where fkiIdEmpresa=" & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        'Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)

                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\" & Fila.Item("OficioSimple") & ".docx"


                FileCopy(Ruta, "C:\Temp\simple.docx")
                Documento = MSWord.Documents.Open("C:\Temp\simple.docx")

                'Documento.Bookmarks.Item("nombre").Range.Text = txtnombre.Text
                ''Documento.Bookmarks.Item("apellido").Range.Text = txtapellido.Text
                'Documento.Bookmarks.Item("direccion").Range.Text = txtdireccion.Text
                'Documento.Bookmarks.Item("correo").Range.Text = txtcorreo.Text()
                'Documento.Bookmarks.Item("telefono").Range.Text = txttelefono.Text

                Documento.Save()
                MSWord.Visible = True

            Else
                MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Documento.Close()
        End Try

    End Sub

    Private Sub cmdcontrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontrato.Click
        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String

        'Verificar que archivo le corresponde a la empresa

        SQL = "select * from Contratos where fkiIdEmpresa=" & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        'Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)

                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\" & Fila.Item("ContratoPrincipal") & ".doc"


                FileCopy(Ruta, "C:\Temp\contrato.doc")
                Documento = MSWord.Documents.Open("C:\Temp\contrato.doc")

                'Buscamos datos del empleado


                SQL = "select iIdEmpleadoAlta,cCodigoEmpleado,empleadosAlta.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
                SQL &= "cIMSS,cDescanso,cCalleNumero,cCiudadP,cCP,iSexo,iEstadoCivil, dFechaNac,puestos.cNombre as cPuesto,fSueldoBase,"
                SQL &= "cNacionalidad,empleadosAlta.cFuncionesPuesto, fSueldoOrd, iOrigen,empresa.calle +' '+ empresa.numero AS cDireccionP, empresa.localidad as cCiudadP, empresa.cp as cCPP, iCategoria, cJornada, cHorario,"
                SQL &= "cHoras, cDescanso, cFechaPago, cFormaPago, cLugarPago,  cLugarFirmaContrato,empleadosAlta.cLugarPrestacion,"
                SQL &= "empresa.nombrefiscal, empresa.RFC AS cRFCP, empresa.cRepresentanteP, empresa.cObjetoSocialP,  Cat_SindicatosAlta.cNombre AS cNombreSindicato"
                SQL &= " from ((empleadosAlta"
                SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto)"
                SQL &= " inner join (clientes inner join Cat_SindicatosAlta on fkiIdSindicato= iIdSindicato) on fkiIdCliente=iIdCliente"
                SQL &= " where iIdEmpleadoAlta = " & gIdEmpleado
                Dim rwEmpleado As DataRow() = nConsulta(SQL)

                If rwEmpleado Is Nothing = False Then

                    Dim fEmpleado As DataRow = rwEmpleado(0)


                    ''Documento.Bookmarks.Item("cCodigoEmpleado").Range.Text = fEmpleado.Item("cCodigoEmpleado")
                    Documento.Bookmarks.Item("cCURP").Range.Text = fEmpleado.Item("cCURP")
                    Documento.Bookmarks.Item("cCURP2").Range.Text = fEmpleado.Item("cCURP")
                    Documento.Bookmarks.Item("cDescanso").Range.Text = fEmpleado.Item("cDescanso")
                    Documento.Bookmarks.Item("cDireccion").Range.Text = fEmpleado.Item("cCalleNumero") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCP")
                    Documento.Bookmarks.Item("cDireccion2").Range.Text = fEmpleado.Item("cCalleNumero") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCP")
                    Documento.Bookmarks.Item("cDireccionP").Range.Text = fEmpleado.Item("cDireccionP") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCPP")
                    Documento.Bookmarks.Item("cDireccionP2").Range.Text = fEmpleado.Item("cDireccionP") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCPP")
                    Documento.Bookmarks.Item("cFiscal").Range.Text = fEmpleado.Item("nombrefiscal")
                    Documento.Bookmarks.Item("cFiscal2").Range.Text = fEmpleado.Item("nombrefiscal")
                    Documento.Bookmarks.Item("cFiscal3").Range.Text = fEmpleado.Item("nombrefiscal")
                    Documento.Bookmarks.Item("cHoras").Range.Text = fEmpleado.Item("cHoras")
                    Documento.Bookmarks.Item("cHoras2").Range.Text = fEmpleado.Item("cHoras")
                    Documento.Bookmarks.Item("cNacionalidad").Range.Text = fEmpleado.Item("cNacionalidad")
                    Documento.Bookmarks.Item("cNacionalidad2").Range.Text = fEmpleado.Item("cNacionalidad")
                    Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo3").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo4").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo5").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo6").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cPuesto").Range.Text = fEmpleado.Item("cPuesto")
                    Documento.Bookmarks.Item("cPuesto2").Range.Text = fEmpleado.Item("cPuesto")
                    Documento.Bookmarks.Item("cRFC").Range.Text = fEmpleado.Item("cRFC")
                    Documento.Bookmarks.Item("cRFC2").Range.Text = fEmpleado.Item("cRFC")
                   
                    Documento.Bookmarks.Item("iCategoria").Range.Text = IIf(fEmpleado.Item("iCategoria") = "0", "A", "B")
                    Documento.Bookmarks.Item("iSexo").Range.Text = IIf(fEmpleado.Item("iSexo") = "0", "FEMENINO", "MASCULINO")
                    Documento.Bookmarks.Item("iSexo2").Range.Text = IIf(fEmpleado.Item("iSexo") = "0", "FEMENINO", "MASCULINO")


                    Documento.Bookmarks.Item("cLugarPrestacion").Range.Text = fEmpleado.Item("cLugarPrestacion")
                    Documento.Bookmarks.Item("cLugarPrestacion2").Range.Text = fEmpleado.Item("cLugarPrestacion")
                    Documento.Bookmarks.Item("cLugarPrestacion3").Range.Text = fEmpleado.Item("cLugarPrestacion")
                    Documento.Bookmarks.Item("cRFCP").Range.Text = fEmpleado.Item("cRFCP")
                    Documento.Bookmarks.Item("cRFCP2").Range.Text = fEmpleado.Item("cRFCP")
                    If IsDBNull(fEmpleado.Item("cRepresentanteP")) = False Or IsDBNull(fEmpleado.Item("cObjetoSocialP")) Then
                        Documento.Bookmarks.Item("cRepresentanteP").Range.Text = fEmpleado.Item("cRepresentanteP")
                        Documento.Bookmarks.Item("cRepresentanteP2").Range.Text = fEmpleado.Item("cRepresentanteP")
                        Documento.Bookmarks.Item("cObjetoSocialP").Range.Text = fEmpleado.Item("cObjetoSocialP")
                        Documento.Bookmarks.Item("cObjetoSocialP2").Range.Text = fEmpleado.Item("cObjetoSocialP")

                    Else
                        MessageBox.Show("Falta agregar Representante Patrona y/u Objeto Social", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                       Documento.Bookmarks.Item("cFuncionesPuesto").Range.Text = fEmpleado.Item("cFuncionesPuesto")
                        Documento.Bookmarks.Item("cFuncionesPuesto2").Range.Text = fEmpleado.Item("cFuncionesPuesto")
                        Documento.Bookmarks.Item("cHorario").Range.Text = fEmpleado.Item("cHorario")
                        Documento.Bookmarks.Item("cFormaPago").Range.Text = fEmpleado.Item("cFormaPago")
                        Documento.Bookmarks.Item("iEstadoCivil").Range.Text = IIf(fEmpleado.Item("iEstadoCivil") = "0", "SOLTERO", "CASADO")
                        Dim fechanac As Date
                        fechanac = fEmpleado.Item("dFechaNac")
                        Dim edad As Integer = DateDiff(DateInterval.Year, fechanac, Date.Today)
                        Documento.Bookmarks.Item("cEdad").Range.Text = edad
                        Documento.Bookmarks.Item("cLugarPago").Range.Text = fEmpleado.Item("cLugarPago")
                        Documento.Bookmarks.Item("cFechaPago").Range.Text = fEmpleado.Item("cFechaPago")
                        Documento.Bookmarks.Item("cLugarFirmaContrato").Range.Text = fEmpleado.Item("cLugarFirmaContrato")
                        Documento.Bookmarks.Item("cLugarFirmaContrato2").Range.Text = fEmpleado.Item("cLugarFirmaContrato").ToLower()
                        Documento.Bookmarks.Item("cLugarFirmaContrato3").Range.Text = fEmpleado.Item("cLugarFirmaContrato").ToLower()
                        Documento.Bookmarks.Item("dFecha").Range.Text = DateTime.Now.ToString("dd/MM/yyyy")
                        Documento.Bookmarks.Item("dFecha2").Range.Text = DateTime.Now.ToString("dd/MM/yyyy")
                        Documento.Bookmarks.Item("dFecha3").Range.Text = DateTime.Now.ToString("dd/MM/yyyy")
                        Documento.Bookmarks.Item("cNombreSindicato").Range.Text = fEmpleado.Item("cNombreSindicato")
                        Documento.Bookmarks.Item("cNombreSindicato2").Range.Text = fEmpleado.Item("cNombreSindicato")

                        ''Documento.Bookmarks.Item("fSalarioPeriodo").Range.Text = fEmpleado.Item("fSueldoOrd")
                        Documento.Bookmarks.Item("fSueldoBase").Range.Text = fEmpleado.Item("fSueldoBase")


                        Dim cJornada As DataRow() = nConsulta("SELECT * FROM Cat_TipoJornadaAlta where iIdTipoJornadaAlta=" & fEmpleado.Item("cJornada"))

                        ''If cJornada Is Nothing = False Then
                        Documento.Bookmarks.Item("cSalarioPeriodoTipo").Range.Text = cJornada(0).Item("Descripcion")
                        Dim periodo As Integer
                        Select Case cJornada(0).Item("iIdTipoJornadaAlta")
                            Case 1
                                periodo = 1
                            Case 2
                                periodo = 7
                            Case 3
                                periodo = 14
                            Case 4
                                periodo = 15
                            Case 5
                                periodo = 30
                            Case 6
                                periodo = 60
                            Case Else
                                periodo = 1
                        End Select
                        Documento.Bookmarks.Item("fSalarioPeriodo").Range.Text = CStr(periodo * fEmpleado.Item("fSueldoBase"))
                        Documento.Bookmarks.Item("cSalarioPeriodoLetra").Range.Text = SpellNumber(CStr(periodo * fEmpleado.Item("fSueldoBase")))

                        Documento.Save()
                        MSWord.Visible = True

                    End If

                Else
                    MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

        Catch ex As Exception

            Documento.Close()

            MessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub cmdingreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdingreso.Click
        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String

        'Verificar que archivo le corresponde a la empresa

        SQL = "select * from Contratos where fkiIdEmpresa=" & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        'Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)

                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\" & Fila.Item("SolicitudIngreso") & ".docx"


                FileCopy(Ruta, "C:\Temp\SolicitudI.docx")
                Documento = MSWord.Documents.Open("C:\Temp\SolicitudI.docx")

                'Buscamos datos del empleado


                SQL = "select iIdEmpleadoAlta,cCodigoEmpleado,empleadosAlta.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
                SQL &= "cIMSS,cDescanso,cCalleNumero,cCiudadP,cCP,iSexo,dFechaNac,puestos.cNombre as cPuesto,fSueldoBase,"
                SQL &= "cNacionalidad, fSueldoOrd, iOrigen, empresa.calle + empresa.numero + empresa.numeroint + empresa.localidad AS cDireccionP, cCiudadP, cCPP, iCategoria, cJornada, cHorario,"
                SQL &= "cHoras, cDescanso, empresa.nombrefiscal, empresa.RFC AS cRFCP, empresa.cRepresentanteP, empresa.cObjetoSocialP,  Cat_SindicatosAlta.cNombre AS cNombreSindicato, Cat_SindicatosAlta.iIdSindicato "
                SQL &= " from ((empleadosAlta"
                SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto)"
                SQL &= " inner join (clientes inner join Cat_SindicatosAlta on fkiIdSindicato= iIdSindicato) on fkiIdCliente=iIdCliente"
                SQL &= " where iIdEmpleadoAlta = " & gIdEmpleado
                Dim rwEmpleado As DataRow() = nConsulta(SQL)

                If rwEmpleado Is Nothing = False Then

                    Dim fEmpleado As DataRow = rwEmpleado(0)


                    Documento.Bookmarks.Item("año").Range.Text = Today.Year.ToString()
                    Documento.Bookmarks.Item("cDireccion").Range.Text = fEmpleado.Item("cCalleNumero") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCP")
                    Documento.Bookmarks.Item("cIMSS").Range.Text = fEmpleado.Item("cIMSS")
                    Documento.Bookmarks.Item("cNacionalidad").Range.Text = fEmpleado.Item("cNacionalidad")
                    Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    ''Documento.Bookmarks.Item("cPuesto").Range.Text = fEmpleado.Item("cPuesto")
                    Documento.Bookmarks.Item("cRFC").Range.Text = fEmpleado.Item("cRFC")
                    Documento.Bookmarks.Item("dia").Range.Text = Today.Day.ToString()

                    ''Documento.Bookmarks.Item("cDireccion").Range.Text = fEmpleado.Item("cDireccionP")
                    ''Documento.Bookmarks.Item("cRFC").Range.Text = fEmpleado.Item("cRFC")

                    Dim fechanac As Date
                    fechanac = fEmpleado.Item("dFechaNac")
                    Dim edad As Integer = DateDiff(DateInterval.Year, fechanac, Date.Today)
                    Documento.Bookmarks.Item("edad").Range.Text = edad.ToString()
                    Documento.Bookmarks.Item("iOrigen").Range.Text = IIf(fEmpleado.Item("iOrigen") = "0", "SOLTERO", "CASADO")
                    Documento.Bookmarks.Item("mes").Range.Text = MonthName(Today.Month).ToUpper()
                    Documento.Bookmarks.Item("nombrefiscal").Range.Text = fEmpleado.Item("nombrefiscal")
                    Documento.Bookmarks.Item("cLugar").Range.Text = "OAXACA DE JUAREZ, OAXACA"

                    Documento.Bookmarks.Item("cNombreSindicato").Range.Text = fEmpleado.Item("cNombreSindicato")

                    If fEmpleado.Item("iIdSindicato") = 1 Then
                        Documento.Bookmarks.Item("cLogoSindicato").Range.InlineShapes.AddPicture(System.Windows.Forms.Application.StartupPath & "\Archivos\logos\7enero.png", LinkToFile:=True, SaveWithDocument:=True)
                        Documento.Bookmarks.Item("cLogoSindicato2").Range.InlineShapes.AddPicture(System.Windows.Forms.Application.StartupPath & "\Archivos\logos\croc.jpg", LinkToFile:=True, SaveWithDocument:=True)

                    ElseIf fEmpleado.Item("iIdSindicato") = 2 Then
                        Documento.Bookmarks.Item("cLogoSindicato").Range.InlineShapes.AddPicture(System.Windows.Forms.Application.StartupPath & "\Archivos\logos\ctm.png", LinkToFile:=True, SaveWithDocument:=True)


                    End If


                    Documento.Save()
                    MSWord.Visible = True

                End If


            Else
                MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Documento.Close()
            MessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmdempleo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdempleo.Click
        Dim MSExcel As New Excel.Application
        Dim Documento As Excel.Workbook
        Dim Ruta As String, strPWD As String
        Dim SQL As String

        'Verificar que archivo le corresponde a la empresa

        SQL = "select * from Contratos where fkiIdEmpresa=" & gIdEmpresa
        Dim rwFilas As DataRow() = nConsulta(SQL)
        'Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then

                Dim Fila As DataRow = rwFilas(0)

                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\" & Fila.Item("SolicitudEmpleo") & ".xls"


                FileCopy(Ruta, "C:\Temp\empleo.xls")
                Documento = MSExcel.Application.Workbooks.Open("C:\Temp\empleo.xls")

                'Documento.Bookmarks.Item("nombre").Range.Text = txtnombre.Text
                ''Documento.Bookmarks.Item("apellido").Range.Text = txtapellido.Text
                'Documento.Bookmarks.Item("direccion").Range.Text = txtdireccion.Text
                'Documento.Bookmarks.Item("correo").Range.Text = txtcorreo.Text()
                'Documento.Bookmarks.Item("telefono").Range.Text = txttelefono.Text

                Documento.Save()
                MSExcel.Visible = True

            Else
                MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Documento.Close()
        End Try

    End Sub

    Private Sub btnAnexos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexos.Click
        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String
        Try
            SQL = "select iIdEmpleadoAlta,cCodigoEmpleado,empleadosAlta.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
            SQL &= "cIMSS,cDescanso,cCalleNumero,cCiudadP,cCP,iSexo,iEstadoCivil, dFechaNac,puestos.cNombre as cPuesto,fSueldoBase,"
            SQL &= "cNacionalidad,empleadosAlta.cFuncionesPuesto, fSueldoOrd, iOrigen,empresa.calle +' '+ empresa.numero AS cDireccionP, empresa.localidad as cCiudadP, empresa.cp as cCPP, iCategoria, cJornada, cHorario,"
            SQL &= "cHoras, cDescanso, cFechaPago, cFormaPago, cLugarPago, cLugarFirmaContrato,empleadosAlta.cLugarPrestacion,"
            SQL &= "empresa.nombrefiscal, empresa.RFC AS cRFCP, empresa.cRepresentanteP, empresa.cObjetoSocialP,  Cat_SindicatosAlta.cNombre AS cNombreSindicato"
            SQL &= " from ((empleadosAlta"
            SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
            SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto)"
            SQL &= " inner join (clientes inner join Cat_SindicatosAlta on fkiIdSindicato= iIdSindicato) on fkiIdCliente=iIdCliente"
            SQL &= " where iIdEmpleadoAlta = " & gIdEmpleado
            Dim rwEmpleado As DataRow() = nConsulta(SQL)

            If rwEmpleado Is Nothing = False Then
                Dim fEmpleado As DataRow = rwEmpleado(0)

                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\anexoI.docx"

                FileCopy(Ruta, "C:\Temp\AnexoI.docx")
                Documento = MSWord.Documents.Open("C:\Temp\AnexoI.docx")

                Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                Documento.Bookmarks.Item("cPuesto").Range.Text = fEmpleado.Item("cPuesto")
                Documento.Bookmarks.Item("cNombreFiscal").Range.Text = fEmpleado.Item("nombrefiscal")
                Documento.Bookmarks.Item("cNombreFiscal2").Range.Text = fEmpleado.Item("nombrefiscal")
                '' Documento.Bookmarks.Item("cLugar").Range.Text = "OAXACA DE JUAREZ, OAXACA"
                If IsDBNull(fEmpleado.Item("cRepresentanteP")) = False Then
                    Documento.Bookmarks.Item("cRepresentanteP").Range.Text = fEmpleado.Item("cRepresentanteP")
                    Documento.Bookmarks.Item("cRepresentanteP2").Range.Text = fEmpleado.Item("cRepresentanteP")
                    Documento.Bookmarks.Item("cRepresentanteP3").Range.Text = fEmpleado.Item("cRepresentanteP")

                Else
                    MessageBox.Show("Falta agregar Representante Patrona", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
                
                Documento.Bookmarks.Item("cDireccionP").Range.Text = fEmpleado.Item("cDireccionP") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCPP")
                Documento.Bookmarks.Item("cFecha").Range.Text = DateTime.Now.ToString("dd/MM/yyyy")
                Documento.Bookmarks.Item("cLugarFirma").Range.Text = fEmpleado.Item("cLugarFirmaContrato")
                Documento.Bookmarks.Item("cLugarFirma2").Range.Text = fEmpleado.Item("cLugarFirmaContrato")
                Documento.Save()
                MSWord.Visible = True

            End If


        Catch ex As Exception
            Documento.Close()
            MessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try


        'Buscamos datos del empleado

    End Sub
   
  
    
   
   
    Private Sub btnAnexo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexo2.Click
        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String
        Try
            SQL = "select iIdEmpleadoAlta,cCodigoEmpleado,empleadosAlta.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
            SQL &= "cIMSS,cDescanso,cCalleNumero,cCiudadP,cCP,iSexo,iEstadoCivil, dFechaNac,puestos.cNombre as cPuesto,fSueldoBase,"
            SQL &= "cNacionalidad,empleadosAlta.cFuncionesPuesto, fSueldoOrd, iOrigen,empresa.calle +' '+ empresa.numero AS cDireccionP, empresa.localidad as cCiudadP, empresa.cp as cCPP, iCategoria, cJornada, cHorario,"
            SQL &= "cHoras, cDescanso, cFechaPago, cFormaPago, cLugarPago, cLugarFirmaContrato,empleadosAlta.cLugarPrestacion,"
            SQL &= "empresa.nombrefiscal, empresa.RFC AS cRFCP, empresa.cRepresentanteP, empresa.cObjetoSocialP,  Cat_SindicatosAlta.cNombre AS cNombreSindicato"
            SQL &= " from ((empleadosAlta"
            SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
            SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto)"
            SQL &= " inner join (clientes inner join Cat_SindicatosAlta on fkiIdSindicato= iIdSindicato) on fkiIdCliente=iIdCliente"
            SQL &= " where iIdEmpleadoAlta = " & gIdEmpleado
            Dim rwEmpleado As DataRow() = nConsulta(SQL)

            If rwEmpleado Is Nothing = False Then
                Dim fEmpleado As DataRow = rwEmpleado(0)
                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\anexoII.docx"

                FileCopy(Ruta, "C:\Temp\AnexoII.docx")
                Documento = MSWord.Documents.Open("C:\Temp\AnexoII.docx")

                Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                Documento.Bookmarks.Item("cCURP").Range.Text = fEmpleado.Item("cCURP")
                Documento.Bookmarks.Item("cRFC").Range.Text = fEmpleado.Item("cRFC")
                Dim fechanac As Date
                fechanac = fEmpleado.Item("dFechaNac")
                Dim edad As Integer = DateDiff(DateInterval.Year, fechanac, Date.Today)
                Documento.Bookmarks.Item("cEdad").Range.Text = edad
                Documento.Bookmarks.Item("cFecha").Range.Text = DateTime.Now.ToString("dd/MM/yyyy")
                Documento.Bookmarks.Item("cLugarFirma").Range.Text = fEmpleado.Item("cLugarFirmaContrato")
                Documento.Bookmarks.Item("cNacionalidad").Range.Text = fEmpleado.Item("cNacionalidad")
                Documento.Bookmarks.Item("cNombreFiscal").Range.Text = fEmpleado.Item("nombrefiscal")

                Documento.Save()
                MSWord.Visible = True
            End If

        Catch ex As Exception
            Documento.Close()
            MessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try

    End Sub

    Private Sub btnAnexo3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexo3.Click
        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String
        Try
            SQL = "select iIdEmpleadoAlta,cCodigoEmpleado,empleadosAlta.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
            SQL &= "cIMSS,cDescanso,cCalleNumero,cCiudadP,cCP,iSexo,iEstadoCivil, dFechaNac,puestos.cNombre as cPuesto,fSueldoBase,"
            SQL &= "cNacionalidad,empleadosAlta.cFuncionesPuesto, fSueldoOrd, iOrigen,empresa.calle +' '+ empresa.numero AS cDireccionP, empresa.localidad as cCiudadP, empresa.cp as cCPP, iCategoria, cJornada, cHorario,"
            SQL &= "cHoras, cDescanso, cFechaPago, cFormaPago, cLugarPago, cLugarFirmaContrato,empleadosAlta.cLugarPrestacion,"
            SQL &= "empresa.nombrefiscal, empresa.RFC AS cRFCP, empresa.cRepresentanteP, empresa.cObjetoSocialP,  Cat_SindicatosAlta.cNombre AS cNombreSindicato"
            SQL &= " from ((empleadosAlta"
            SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
            SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto)"
            SQL &= " inner join (clientes inner join Cat_SindicatosAlta on fkiIdSindicato= iIdSindicato) on fkiIdCliente=iIdCliente"
            SQL &= " where iIdEmpleadoAlta = " & gIdEmpleado
            Dim rwEmpleado As DataRow() = nConsulta(SQL)

            If rwEmpleado Is Nothing = False Then
                Dim fEmpleado As DataRow = rwEmpleado(0)
                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\anexoIII.docx"

                FileCopy(Ruta, "C:\Temp\AnexoIII.docx")
                Documento = MSWord.Documents.Open("C:\Temp\AnexoIII.docx")

                Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                Documento.Bookmarks.Item("cNombreFiscal").Range.Text = fEmpleado.Item("nombrefiscal")
                Documento.Bookmarks.Item("cNombreFiscal2").Range.Text = fEmpleado.Item("nombrefiscal")
                Documento.Bookmarks.Item("cFecha").Range.Text = DateTime.Now.ToString("dd/MM/yyyy")
                Documento.Bookmarks.Item("cLugarFirma").Range.Text = fEmpleado.Item("cLugarFirmaContrato")

                Documento.Save()
                MSWord.Visible = True

            End If

        Catch ex As Exception
            Documento.Close()
            MessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub btnAnexo4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexo4.Click

        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String
        Try
            SQL = "select iIdEmpleadoAlta,cCodigoEmpleado,empleadosAlta.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
            SQL &= "cIMSS,cDescanso,cCalleNumero,cCiudadP,cCP,iSexo,iEstadoCivil, dFechaNac,puestos.cNombre as cPuesto,fSueldoBase,"
            SQL &= "cNacionalidad,empleadosAlta.cFuncionesPuesto, fSueldoOrd, iOrigen,empresa.iIdEmpresa ,empresa.calle +' '+ empresa.numero AS cDireccionP, empresa.localidad as cCiudadP, empresa.cp as cCPP, iCategoria, cJornada, cHorario,"
            SQL &= "cHoras, cDescanso, cFechaPago, cFormaPago, cLugarPago, cLugarFirmaContrato,empleadosAlta.cLugarPrestacion, dFechaPatrona,"
            SQL &= "empresa.nombrefiscal, empresa.RFC AS cRFCP, empresa.cRepresentanteP, empresa.cObjetoSocialP,  Cat_SindicatosAlta.cNombre AS cNombreSindicato"
            SQL &= " from ((empleadosAlta"
            SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
            SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto)"
            SQL &= " inner join (clientes inner join Cat_SindicatosAlta on fkiIdSindicato= iIdSindicato) on fkiIdCliente=iIdCliente"
            SQL &= " where iIdEmpleadoAlta = " & gIdEmpleado
            Dim rwEmpleado As DataRow() = nConsulta(SQL)

            If rwEmpleado Is Nothing = False Then
                Dim fEmpleado As DataRow = rwEmpleado(0)
                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\anexoIV.docx"

                FileCopy(Ruta, "C:\Temp\AnexoIV.docx")
                Documento = MSWord.Documents.Open("C:\Temp\AnexoIV.docx")

                Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                'Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                Documento.Bookmarks.Item("cNombreFiscal").Range.Text = fEmpleado.Item("nombrefiscal")
                Documento.Bookmarks.Item("cNombreFiscal2").Range.Text = fEmpleado.Item("nombrefiscal")
                Documento.Bookmarks.Item("cFecha").Range.Text = DateTime.Now.ToString("dd/MM/yyyy")
                Documento.Bookmarks.Item("cLugarFirma").Range.Text = fEmpleado.Item("cLugarFirmaContrato")
                Documento.Bookmarks.Item("dFechaIngreso").Range.Text = fEmpleado.Item("dFechaPatrona")

                If File.Exists(System.Windows.Forms.Application.StartupPath & "\Archivos\logos\empresas\" & fEmpleado.Item("iIdEmpresa") & ".png") Then
                    Documento.Bookmarks.Item("cLogo").Range.InlineShapes.AddPicture(System.Windows.Forms.Application.StartupPath & "\Archivos\logos\empresas\" & fEmpleado.Item("iIdEmpresa") & ".png", LinkToFile:=True, SaveWithDocument:=True)

                End If
                
                Documento.Save()
                MSWord.Visible = True
            End If

        Catch ex As Exception
            Documento.Close()
            MessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub
End Class