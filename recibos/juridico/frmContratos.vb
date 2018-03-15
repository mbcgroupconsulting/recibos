﻿Imports Microsoft.Office.Interop.Word 'control de office
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports ClosedXML.Excel
Imports System.IO
Imports System.Text

Public Class frmContratos
    Dim SQL As String
    Private Sub frmContratos_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        MostrarClientes()
        MostrarEmpresas()
        MostrarDireccion()
    End Sub

    Private Sub MostrarDireccion()
        SQL = "select * from empresa where iIdEmpresa = " & cboempresas.SelectedValue
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                'lblEmpresa.Text = "Empresa: " & Fila.Item("nombre")
                lbldireccion.Text = "Direccion: " & Fila.Item("calle") & " " & Fila.Item("numero") & " " & Fila.Item("numeroint") & " " & Fila.Item("colonia") & " "

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarClientes()

        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6") Then

                    SQL = "Select nombre,iIdCliente from clientes order by nombre"
                Else
                    SQL = "Select nombre,iIdCliente from clientes inner join UsuarioClientes "
                    SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente"
                    SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    SQL &= "  order by nombre "


                End If
                nCargaCBO(cboclientes, SQL, "nombre", "iIdCliente")
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub MostrarEmpresas()
        'Verificar si se tienen permisos
        SQL = "select * from usuarios where idUsuario = " & idUsuario
        Dim rwFilas As DataRow() = nConsulta(SQL)
        Dim Forma As New frmTipoEmpresa
        Try
            If rwFilas Is Nothing = False Then


                Dim Fila As DataRow = rwFilas(0)
                If (Fila.Item("fkIdPerfil") = "1" Or Fila.Item("fkIdPerfil") = "3" Or Fila.Item("fkIdPerfil") = "4" Or Fila.Item("fkIdPerfil") = "5" Or Fila.Item("fkIdPerfil") = "6") Then

                    SQL = "Select nombre,iIdEmpresa from empresa order by nombre"
                Else
                    SQL = "Select distinct(iIdEmpresa),empresa.nombre from ((clientes inner join UsuarioClientes  "
                    SQL &= " on clientes.iIdCliente=UsuarioClientes.fkiIdCliente) inner join"
                    SQL &= " IntClienteEmpresa on clientes.iIdCliente=IntClienteEmpresa.fkIdCliente)"
                    SQL &= " inner join empresa on IntClienteEmpresa.fkIdEmpresa= empresa.iIdEmpresa"
                    SQL &= " where UsuarioClientes.fkiIdEmpleado =" & idUsuario
                    SQL &= " order by nombre "


                End If
                nCargaCBO(cboempresas, SQL, "nombre", "iIdEmpresa")
            End If

        Catch ex As Exception

        End Try




    End Sub

    Private Sub cboempresas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MostrarSucursales()
    End Sub

    Private Sub MostrarSucursales()
        SQL = "Select * from empresa order by nombre"
        nCargaCBO(cbosucursales, SQL, "nombre", "iIdEmpresa")

    End Sub

    Private Sub cmdnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SQL = "select * from PuestosAlta where fkiIdEmpresa=" & cboempresas.SelectedValue

        Dim rwFilas As DataRow() = nConsulta(SQL)
        If (rwFilas Is Nothing) Then
            MessageBox.Show("Necesita agregar puesto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            SQL = "select * from DepartamentosAlta where fkiIdEmpresa=" & cboempresas.SelectedValue

            Dim dpto As DataRow() = nConsulta(SQL)
            If (dpto Is Nothing) Then
                MessageBox.Show("Necesita agregar Departamento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Else

                Dim forma As New frmAltaEmpleadoNew
                forma.gIdCliente = cboclientes.SelectedValue
                forma.gIdEmpresa = cboempresas.SelectedValue
                forma.ShowDialog()
            End If
        End If



    End Sub

    Private Sub pnlVentana_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlVentana.Paint

    End Sub

    Private Sub cboempresas_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboempresas.SelectedIndexChanged
        MostrarDireccion()
        '' lsvLista.Clear()
    End Sub

    Private Sub cmdcontrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontrato.Click
        Dim MSWord As New Word.Application
        Dim Documento As Word.Document
        Dim Ruta As String, strPWD As String
        Dim SQL As String

        Try
            Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\CPS.docx"


            FileCopy(Ruta, "C:\Temp\CPS_APE_Excedente.docx")
            Documento = MSWord.Documents.Open("C:\Temp\CPS_APE_Excedente.docx")


            SQL = " SELECT e.iIdEmpresa, e.nombrefiscal AS cNombreFiscalP, e.cRepresentanteP, e.RFC AS cRFCP, e.cCargoRepresentante AS cRepresentanteCargoP,"
            SQL &= " e.calle + ' '+e.numero +' '+ e.municipio As cDireccionP, e.idEstado  AS cEstadoP,"
            SQL &= "c.iIdCliente, c.nombrefiscal AS cNombreFiscalU, c.cRepresentanteLegal AS cRepresentanteU , c.RFC AS cRFCU, c.cCargoRepresentante  AS cRepresentanteCargoU,"
            SQL &= "c.calle +' '+ c.numero +' '+ c.municipio As cDireccionU, c.idEstado AS cEstadoU"
            SQL &= "  FROM empresa As e, clientes as c "
            SQL &= "WHERE e.iIdEmpresa=" & cboempresas.SelectedValue
            SQL &= "  AND c.iIdCliente =" & cboclientes.SelectedValue
            

            Dim rwEmpleado As DataRow() = nConsulta(SQL)

            If rwEmpleado Is Nothing = False Then

                Dim fEmpleado As DataRow = rwEmpleado(0)

                Documento.Bookmarks.Item("cNombreFiscalU").Range.Text = UCase(fEmpleado.Item("cNombreFiscalU"))
                Documento.Bookmarks.Item("cRepresentanteU").Range.Text = UCase(fEmpleado.Item("cRepresentanteU"))
                Documento.Bookmarks.Item("cNombreFiscalP").Range.Text = UCase(fEmpleado.Item("cNombreFiscalP"))
                Documento.Bookmarks.Item("cRepresentanteP").Range.Text = UCase(fEmpleado.Item("cRepresentanteP"))
                Documento.Bookmarks.Item("cDireccionP").Range.Text = UCase(fEmpleado.Item("cDireccionP"))
                Documento.Bookmarks.Item("cRFCU").Range.Text = UCase(fEmpleado.Item("cRFCU"))
                Documento.Bookmarks.Item("cDireccionU").Range.Text = UCase(fEmpleado.Item("cDireccionU"))
                Documento.Bookmarks.Item("cRFCP").Range.Text = UCase(fEmpleado.Item("cRFCP"))

                Dim estado As DataRow() = nConsulta("SELECT * from Cat_Estados WHERE iIdEstado=" & fEmpleado.Item("cEstadoP"))

                Documento.Bookmarks.Item("cEstadoP").Range.Text = UCase(estado(0).Item("cEstado"))
                Dim fec As String = dtpFirma.Value.ToLongDateString
                Dim ArrCadena As String() = fec.Split(",")

                Documento.Bookmarks.Item("cFechaLetra").Range.Text = ArrCadena(1).ToString.ToUpper
                Documento.Bookmarks.Item("cNombreFiscalU2").Range.Text = UCase(fEmpleado.Item("cNombreFiscalU"))
                Documento.Bookmarks.Item("cRepresentanteU2").Range.Text = UCase(fEmpleado.Item("cRepresentanteU"))
                Documento.Bookmarks.Item("cNombreFiscalP2").Range.Text = UCase(fEmpleado.Item("cNombreFiscalP"))
                Documento.Bookmarks.Item("cRepresentanteP2").Range.Text = UCase(fEmpleado.Item("cRepresentanteP"))

                ''If System.IO.File.Exists("\Archivos\logos\empresas\" & fEmpleado.Item("iIdEmpresa") & ".png") Then
                ' El archivo Existe!
                Documento.Bookmarks.Item("cLogo").Range.InlineShapes.AddPicture(System.Windows.Forms.Application.StartupPath & "\Archivos\logos\empresas\" & fEmpleado.Item("iIdEmpresa") & ".png", LinkToFile:=True, SaveWithDocument:=True)
                ''End If

                Documento.Bookmarks.Item("cLugarJurisdiccion").Range.Text = UCase(txtJurisdiccion.Text)
                Documento.Bookmarks.Item("cLugarFirma").Range.Text = UCase(txtLugarFirma.Text)


                Documento.Save()
                MSWord.Visible = True
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

        Try
            Ruta = System.Windows.Forms.Application.StartupPath & "\Archivos\CPS_Correlacionado.docx"


            FileCopy(Ruta, "C:\Temp\CPS_Correlacionado.docx")
            Documento = MSWord.Documents.Open("C:\Temp\CPS_Correlacionado.docx")


            SQL = "SELECT e.iIdEmpresa, e.nombrefiscal AS cNombreFiscalP, e.cRepresentanteP, e.RFC AS cRFCP, e.cCargoRepresentante AS cCargoRepresentanteU,"
            SQL &= "e.calle + ' '+e.numero +' '+ e.municipio As cDireccionP, e.idEstado  AS cEstadoP,"
            SQL &= "e.cInstrumentoPublico As cInstrumentoP, e.cVolumen As cVolumenP, e.dFechaConstitucion As dFechaConstitucionP, e.dFechaActa As dFechaActaP, e.cLugarRPP As cLugarRPPP,"
            SQL &= "e.cNotario As cNotarioP, e.cNotarioNumero As cNotarioNumeroP, e.cNotarioResidencia As cNotarioResidenciaP, e.cFolioMercantil As cFolioMercantilP,"
            SQL &= "c.iIdCliente, c.nombrefiscal AS cNombreFiscalU, c.cRepresentanteLegal AS cRepresentanteU , c.RFC AS cRFCU, c.cCargoRepresentante  AS cCargoRepresentanteP,"
            SQL &= "c.calle +' '+ c.numero +' '+ c.municipio As cDireccionU, c.idEstado AS cEstadoU,"
            SQL &= "c.cInstrumentoPublico As cInstrumentoU, c.cVolumen As cVolumenU, c.dFechaConstitucion As dFechaConstitucionU, c.dFechaActa As dFechaActaU, c.cLugarRPP As cLugarRPPU,"
            SQL &= "c.cNotario As cNotarioU, c.cNotarioNumero As cNotarioNumeroU, c.cNotarioResidencia As cNotarioResidenciaU, c.cFolioMercantil As cFolioMercantilU  "
            SQL &= "FROM empresa As e, clientes as c "
            SQL &= "WHERE e.iIdEmpresa=" & cboempresas.SelectedValue
            SQL &= "AND c.iIdCliente =" & cboclientes.SelectedValue


            Dim rwEmpleado As DataRow() = nConsulta(SQL)

            If rwEmpleado Is Nothing = False Then

                Dim fEmpleado As DataRow = rwEmpleado(0)

                Documento.Bookmarks.Item("cNombreFiscalU").Range.Text = UCase(fEmpleado.Item("cNombreFiscalU"))
                Documento.Bookmarks.Item("cRepresentanteU").Range.Text = UCase(fEmpleado.Item("cRepresentanteU"))
                Documento.Bookmarks.Item("cNombreFiscalP").Range.Text = UCase(fEmpleado.Item("cNombreFiscalP"))
                Documento.Bookmarks.Item("cRepresentanteP").Range.Text = UCase(fEmpleado.Item("cRepresentanteP"))
                
                Documento.Bookmarks.Item("cCargoRepresentanteP").Range.Text = UCase(fEmpleado.Item("cCargoRepresentanteP"))
                Documento.Bookmarks.Item("cCargoRepresentanteU").Range.Text = UCase(fEmpleado.Item("cCargoRepresentanteU"))
                Documento.Bookmarks.Item("cCargoRepresentanteP2").Range.Text = UCase(fEmpleado.Item("cCargoRepresentanteP"))
                Documento.Bookmarks.Item("cCargoRepresentanteU2").Range.Text = UCase(fEmpleado.Item("cCargoRepresentanteU"))

                Documento.Bookmarks.Item("cDireccionP").Range.Text = UCase(fEmpleado.Item("cDireccionP"))
                Documento.Bookmarks.Item("cRFCU").Range.Text = UCase(fEmpleado.Item("cRFCU"))
                Documento.Bookmarks.Item("cDireccionU").Range.Text = UCase(fEmpleado.Item("cDireccionU"))
                Documento.Bookmarks.Item("cRFCP").Range.Text = UCase(fEmpleado.Item("cRFCP"))

                Dim estado As DataRow() = nConsulta("SELECT * from Cat_Estados WHERE iIdEstado=" & fEmpleado.Item("cEstadoP"))

                Documento.Bookmarks.Item("cEstadoP").Range.Text = UCase(estado(0).Item("cEstado"))
                Dim fec As String = dtpFirma.Value.ToLongDateString
                Dim ArrCadena As String() = fec.Split(",")

                Documento.Bookmarks.Item("cFecha").Range.Text = ArrCadena(1).ToString.ToUpper
                Documento.Bookmarks.Item("cJurisdiccion").Range.Text = UCase(txtJurisdiccion.Text)
                Documento.Bookmarks.Item("cLugarFirma").Range.Text = UCase(txtLugarFirma.Text)

                Documento.Bookmarks.Item("cRepresentanteU2").Range.Text = UCase(fEmpleado.Item("cRepresentanteU"))
                Documento.Bookmarks.Item("cRepresentanteP2").Range.Text = UCase(fEmpleado.Item("cRepresentanteP"))
                
                Documento.Bookmarks.Item("cLogo").Range.InlineShapes.AddPicture(System.Windows.Forms.Application.StartupPath & "\Archivos\logos\empresas\" & fEmpleado.Item("iIdEmpresa") & ".png", LinkToFile:=True, SaveWithDocument:=True)

                Documento.Bookmarks.Item("dFechaConstitucionP").Range.Text = UCase(fEmpleado.Item("dFechaConstitucionP"))
                Documento.Bookmarks.Item("dFechaConstitucionU").Range.Text = UCase(fEmpleado.Item("dFechaConstitucionU"))
                Documento.Bookmarks.Item("cVolumenP").Range.Text = UCase(fEmpleado.Item("cVolumenP"))
                Documento.Bookmarks.Item("cVolumenU").Range.Text = UCase(fEmpleado.Item("cVolumenU"))
                Documento.Bookmarks.Item("cVolumenLetraP").Range.Text = UCase(SpellNumber2(CStr(fEmpleado.Item("cVolumenP"))))
                Documento.Bookmarks.Item("cVolumenLetraU").Range.Text = UCase(SpellNumber2(CStr(fEmpleado.Item("cVolumenU"))))


                Documento.Bookmarks.Item("cInstrumentoP").Range.Text = UCase(fEmpleado.Item("cInstrumentoP"))
                Documento.Bookmarks.Item("cInstrumentoU").Range.Text = UCase(fEmpleado.Item("cInstrumentoU"))
                Documento.Bookmarks.Item("cInstrumentoLetraP").Range.Text = UCase(SpellNumber2(CStr(fEmpleado.Item("cInstrumentoP")))).ToString
                Documento.Bookmarks.Item("cInstrumentoLetraU").Range.Text = UCase(SpellNumber2(CStr(fEmpleado.Item("cInstrumentoU"))))

                Documento.Bookmarks.Item("cNotarioP").Range.Text = UCase(fEmpleado.Item("cNotarioP"))
                Documento.Bookmarks.Item("cNotarioU").Range.Text = UCase(fEmpleado.Item("cNotarioU"))
                Documento.Bookmarks.Item("cNotarioNumeroP").Range.Text = UCase(fEmpleado.Item("cNotarioNumeroP"))
                Documento.Bookmarks.Item("cNotarioNumeroU").Range.Text = UCase(fEmpleado.Item("cNotarioNumeroU"))
                Documento.Bookmarks.Item("cNotarioNumeroLetraP").Range.Text = UCase(SpellNumber2(CStr(fEmpleado.Item("cNotarioNumeroP"))))
                Documento.Bookmarks.Item("cNotarioNumeroLetraU").Range.Text = UCase(SpellNumber2(CStr(fEmpleado.Item("cNotarioNumeroU"))))

                Documento.Bookmarks.Item("cNotarioResidenciaP").Range.Text = UCase(fEmpleado.Item("cNotarioResidenciaP"))
                Documento.Bookmarks.Item("cNotarioResidenciaU").Range.Text = UCase(fEmpleado.Item("cNotarioResidenciaU"))

                Documento.Bookmarks.Item("cFolioMercantilP").Range.Text = UCase(fEmpleado.Item("cFolioMercantilP"))
                Documento.Bookmarks.Item("cFolioMercantilU").Range.Text = UCase(fEmpleado.Item("cFolioMercantilU"))





                Documento.Save()
                MSWord.Visible = True
            End If


        Catch ex As Exception
            Documento.Close()

            MessageBox.Show(ex.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub
End Class