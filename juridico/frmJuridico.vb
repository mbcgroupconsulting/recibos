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
                If chkLotes.Checked And rbOficio.Checked Then
                    Empleados = txtlotes.Text.Split(",")
                    If Empleados.Length = 1 Then
                        MessageBox.Show("Solo existe un código de empleado por favor generarlo de la manera normal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Empleados.Length > 1 Then

                        FileCopy(Ruta2, "C:\Temp\oficioL.docx")
                        DocumentoL = MSWordL.Documents.Open("C:\Temp\oficioL.docx")

                        For i = 1 To Empleados.Length - 1

                            FileCopy(Ruta, "C:\Temp\oficio1.docx")
                            Documento = MSWord.Documents.Open("C:\Temp\oficio1.docx")

                            'Buscamos datos del empleado

                            SQL = "select * from empleados where iIdEmpleado = " & gIdEmpleado
                            Dim rwEmpleado As DataRow() = nConsulta(SQL)

                            If rwEmpleado Is Nothing = False Then

                                Dim fEmpleado As DataRow = rwEmpleado(0)



                                Documento.Bookmarks.Item("nombrecompleto").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                                Documento.Bookmarks.Item("imss").Range.Text = fEmpleado.Item("cIMSS")

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

                    Else
                        MessageBox.Show("No hay códigos de empleado, para generar el lote", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                Else
                    FileCopy(Ruta, "C:\Temp\oficio.docx")
                    Documento = MSWord.Documents.Open("C:\Temp\oficio.docx")

                    'Buscamos datos del empleado

                    SQL = "select * from empleados where iIdEmpleado = " & gIdEmpleado
                    Dim rwEmpleado As DataRow() = nConsulta(SQL)

                    If rwEmpleado Is Nothing = False Then

                        Dim fEmpleado As DataRow = rwEmpleado(0)



                        Documento.Bookmarks.Item("nombrecompleto").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                        Documento.Bookmarks.Item("imss").Range.Text = fEmpleado.Item("cIMSS")

                        Documento.Save()
                        MSWord.Visible = True

                    End If

                End If

                

            Else
                MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

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

                Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\" & Fila.Item("ContratoPrincipal") & ".docx"


                FileCopy(Ruta, "C:\Temp\contrato.docx")
                Documento = MSWord.Documents.Open("C:\Temp\contrato.docx")

                'Buscamos datos del empleado


                SQL = "select iIdEmpleado,cCodigoEmpleado,empleados.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
                SQL &= "cIMSS,cDescanso,cDireccion,cCiudadL,cCP,iSexo,puestos.cNombre as cPuesto,fSueldoBase,"
                SQL &= "cNacionalidad, fSueldoOrd, iOrigen,cDireccionP, cCiudadP, cCPP, iCategoria, cJornada, cHorario,"
                SQL &= "cHoras, cDescanso,nombrefiscal"
                SQL &= " from (empleados"
                SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto"
                SQL &= " where iIdEmpleado = " & gIdEmpleado
                Dim rwEmpleado As DataRow() = nConsulta(SQL)

                If rwEmpleado Is Nothing = False Then

                    Dim fEmpleado As DataRow = rwEmpleado(0)


                    Documento.Bookmarks.Item("cCodigoEmpleado").Range.Text = fEmpleado.Item("cCodigoEmpleado")
                    Documento.Bookmarks.Item("cCURP").Range.Text = fEmpleado.Item("cCURP")
                    Documento.Bookmarks.Item("cDescanso").Range.Text = fEmpleado.Item("cDescanso")
                    Documento.Bookmarks.Item("cDireccion").Range.Text = fEmpleado.Item("cDireccion") & ", " & fEmpleado.Item("cCiudadL") & ", " & fEmpleado.Item("cCP")
                    Documento.Bookmarks.Item("cDireccionP").Range.Text = fEmpleado.Item("cDireccionP") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCPP")
                    Documento.Bookmarks.Item("cDireccionP2").Range.Text = fEmpleado.Item("cDireccionP") & ", " & fEmpleado.Item("cCiudadP") & ", " & fEmpleado.Item("cCPP")
                    Documento.Bookmarks.Item("cFiscal").Range.Text = fEmpleado.Item("nombrefiscal")
                    Documento.Bookmarks.Item("cFiscal2").Range.Text = fEmpleado.Item("nombrefiscal")
                    Documento.Bookmarks.Item("cHoras").Range.Text = fEmpleado.Item("cHoras")
                    Documento.Bookmarks.Item("cNacionalidad").Range.Text = fEmpleado.Item("cNacionalidad")
                    Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo3").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo4").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo5").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cPuesto").Range.Text = fEmpleado.Item("cPuesto")
                    Documento.Bookmarks.Item("cPuesto2").Range.Text = fEmpleado.Item("cPuesto")
                    Documento.Bookmarks.Item("cRFC").Range.Text = fEmpleado.Item("cRFC")
                    Documento.Bookmarks.Item("fSalarioPeriodo").Range.Text = fEmpleado.Item("fSueldoOrd")
                    Documento.Bookmarks.Item("fSueldoBase").Range.Text = fEmpleado.Item("fSueldoBase")

                    Documento.Bookmarks.Item("iCategoria").Range.Text = IIf(fEmpleado.Item("iCategoria") = "0", "A", "B")
                    Documento.Bookmarks.Item("iSexo").Range.Text = IIf(fEmpleado.Item("iSexo") = "0", "FEMENINO", "MASCULINO")

                    Documento.Save()
                    MSWord.Visible = True

                End If

            Else
                MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

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


                SQL = "select iIdEmpleado,cCodigoEmpleado,empleados.cNombre,cApellidoP,cApellidoM,cRFC,cCURP,"
                SQL &= "cIMSS,cDescanso,cDireccion,cCiudadL,cCP,iSexo,dFechaNac,puestos.cNombre as cPuesto,fSueldoBase,"
                SQL &= "cNacionalidad, fSueldoOrd, iOrigen,cDireccionP, cCiudadP, cCPP, iCategoria, cJornada, cHorario,"
                SQL &= "cHoras, cDescanso,nombrefiscal"
                SQL &= " from (empleados"
                SQL &= " inner join empresa on fkiIdEmpresa= iIdEmpresa)"
                SQL &= " inner join puestos on fkiIdPuesto= iIdPuesto"
                SQL &= " where iIdEmpleado = " & gIdEmpleado
                Dim rwEmpleado As DataRow() = nConsulta(SQL)

                If rwEmpleado Is Nothing = False Then

                    Dim fEmpleado As DataRow = rwEmpleado(0)


                    Documento.Bookmarks.Item("año").Range.Text = Today.Year.ToString()
                    Documento.Bookmarks.Item("cDireccion").Range.Text = fEmpleado.Item("cDireccion") & ", " & fEmpleado.Item("cCiudadL") & ", " & fEmpleado.Item("cCP")
                    Documento.Bookmarks.Item("cIMSS").Range.Text = fEmpleado.Item("cIMSS")
                    Documento.Bookmarks.Item("cNacionalidad").Range.Text = fEmpleado.Item("cNacionalidad")
                    Documento.Bookmarks.Item("cNombreLargo").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cNombreLargo2").Range.Text = fEmpleado.Item("cNombre") & " " & fEmpleado.Item("cApellidoP") & " " & fEmpleado.Item("cApellidoM")
                    Documento.Bookmarks.Item("cPuesto").Range.Text = fEmpleado.Item("cPuesto")
                    Documento.Bookmarks.Item("cRFC").Range.Text = fEmpleado.Item("cRFC")
                    Documento.Bookmarks.Item("dia").Range.Text = Today.Day.ToString()

                    Dim fechanac As Date
                    fechanac = fEmpleado.Item("dFechaNac")
                    Dim edad As Integer = DateDiff(DateInterval.Year, fechanac, Date.Today)
                    Documento.Bookmarks.Item("edad").Range.Text = edad.ToString()
                    Documento.Bookmarks.Item("iOrigen").Range.Text = IIf(fEmpleado.Item("iOrigen") = "0", "SOLTERO", "CASADO")
                    Documento.Bookmarks.Item("mes").Range.Text = MonthName(Today.Month).ToUpper()
                    Documento.Bookmarks.Item("nombrefiscal").Range.Text = fEmpleado.Item("nombrefiscal")



                    Documento.Save()
                    MSWord.Visible = True

                End If


            Else
                MessageBox.Show("La empresa patrona no tiene asignados los contratos o documentos, consulte con el administrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

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

        End Try

    End Sub

    Private Sub frmJuridico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class