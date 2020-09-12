Imports System.Net
Imports System.IO
Imports System.Net.HttpWebResponse
Imports mshtml
Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web
Imports System
Imports System.Web.Script.Serialization


Public Class Generador

    Dim imagesCertifiedScript As String
    Dim idSalesforce As String
    Dim email As String
    Dim source As String
    Dim backgroundSelected As String
    Dim configurationPositionCertifiedScript As String
    Dim dictionaryImages As New Dictionary(Of String, String)
    Dim contadorCertificates As Integer = 0
    Dim listBadges As New List(Of String)

    Dim textCertificates As String = ""
    Dim textAccredited As String = ""

    Dim accreditedNumber As Integer = 0
    Dim certificatesNumber As Integer = 0

    Dim rowsImages As Integer = 0

    Public Function goToDrawZone() As Profile
        Dim profileResponse As New Profile()
        profileResponse.cScript = "window.location.href=""#drawGenerateButtonSection"";"
        Return profileResponse
    End Function

    Public Function goToDrawZoneUpload() As Profile
        Dim profileResponse As New Profile()
        profileResponse.cScript = "window.location.href=""#drawZoneUploadFile"";"
        Return profileResponse
    End Function


    Public Function getFabricJsScript(ByVal emailInput As String, ByVal sourceInput As String, ByVal imageBacgroundIndexInput As String, ByVal isFreeSelectedIndex As String, ByVal idSalesforceInput As String, ByVal isDatabaseQuery As Boolean, ByVal selectedColor As String) As Profile
        'Dim dbd As DataBase = New DataBase()
        'dbd.normalizarHeader()

        idSalesforce = idSalesforceInput
        email = emailInput
        source = sourceInput
        Dim profileResponse As New Profile()

        Dim db As DataBase = New DataBase()
        imagesCertifiedScript = ""
        configurationPositionCertifiedScript = ""

        Try
            'Este metodo se uso hasta el 08 12 de 2018 cuando salesforce cambio la politica de busqueda con captcha
            'getDataHeader(profileResponse)

            'Este metodo se uso hasta el 10 05 de 2019 cuando salesforce cambio el searchstring con un encriptado, y cambio la estuctura e respuestas de un Json embebido en un xml
            'getDataHeaderNuevo(profileResponse)

            'Este metodo se uso hasta el 18 02 de 2020 cuando salesforce cambio lo siguiente:
            '       Dio de baja https://certification.secure.force.com/certificationsite/services/apexrest/credential?searchString=ZysMP5a/eGy8r5UFoze802gEOsC+v8XkX+GnJQs8R3Iqz/SB19zi4xXRttIFqvCF
            '       Dio de baja http://certification.salesforce.com/verification-email?email=gpattersonm@gmail.com
            'getDataHeaderJsonV3(profileResponse)

            'System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            'getDataHeaderNamesHtmlV5(profileResponse)

            getDataHeaderJsonV4(profileResponse)
        Catch ex As Exception
            db.insertHistorico(ex.Message, "", "", "", "", email, idSalesforce, source)
        End Try

        Dim scriptSalesforce As String = ""
        scriptSalesforce += " var canvas;"
        scriptSalesforce += " var imgInstanceBack;"
        scriptSalesforce += " var shadowText1;"
        'scriptSalesforce += " var imgInstanceGrid;"
    
        scriptSalesforce += " function codeAddress() {"
        scriptSalesforce += configurationPositionCertifiedScript
        scriptSalesforce += "  /*canvas = new fabric.Canvas('c', {"
        scriptSalesforce += "           isDrawingMode: false"
        scriptSalesforce += "         });*/"

        scriptSalesforce += "var ContadorCertificates = " + contadorCertificates.ToString + ";"
        scriptSalesforce += "if( ContadorCertificates > 0) {document.getElementById(""drawZone"").setAttribute(""style"", ""display:block;""); } else  {document.getElementById(""drawZoneNoResuts"").setAttribute(""style"", ""display:block;""); }"

        'scriptSalesforce += "canvas = new fabric.Canvas('c');"

        scriptSalesforce += "  canvas = new fabric.Canvas('c', {"
        scriptSalesforce += "           preserveObjectStacking: true"
        scriptSalesforce += "         });"

        scriptSalesforce += " var imgElement;"
        scriptSalesforce += " var imgInstance;"

     
        scriptSalesforce += "var color = 'rgba(255,255,255,1)';"
        If isFreeSelectedIndex Then
            scriptSalesforce += "var imagenBack = document.getElementById(""imageSelected"").options[document.getElementById(""imageSelected"").selectedIndex].value;"
        Else
            scriptSalesforce += "var imagenBack = document.getElementById(""imageSelected"").options[" + imageBacgroundIndexInput + "].value;"

        End If

        If selectedColor <> "" Then
            scriptSalesforce += "color =  '" + selectedColor + "';"
        End If


        scriptSalesforce += "imgElement = document.getElementById(imagenBack);"
        scriptSalesforce += "imgInstanceBack = new fabric.Image(imgElement, {"
        scriptSalesforce += "  left: 0,"
        scriptSalesforce += "  top: 0"
        scriptSalesforce += "});"
        scriptSalesforce += "canvas.add(imgInstanceBack);"

        'scriptSalesforce += "imgElement = document.getElementById(""imagenGrid"");"
        'scriptSalesforce += "imgInstanceGrid = new fabric.Image(imgElement, {"
        'scriptSalesforce += "  left: 0,"
        'scriptSalesforce += "  top: 0"
        'scriptSalesforce += "});"
        'scriptSalesforce += "canvas.add(imgInstanceGrid);"


        scriptSalesforce += imagesCertifiedScript

        If certificatesNumber > 0 Then
            textCertificates = certificatesNumber.ToString + "x Salesforce Certified"
        End If
        If accreditedNumber > 0 Then
            If textCertificates = "" Then
                textAccredited = accreditedNumber.ToString + "x Salesforce Accredited"
            Else
                textAccredited = "/  " + accreditedNumber.ToString + "x Salesforce Accredited"
            End If
        End If

        'scriptSalesforce += "var shadowText1 = new fabric.Text(""" + ContadorCertificates.ToString + "x Salesforce Certified"", {"
        scriptSalesforce += " shadowText1 = new fabric.Text(""" + textCertificates.ToString + "  " + textAccredited.ToString + """, {"

        scriptSalesforce += "shadow:  'rgba(0,0,0,0.3) 15px 15px 15px',"
        scriptSalesforce += "fill:  color ,"
        scriptSalesforce += "fontFamily:  'Arial',"
        scriptSalesforce += "textAlign:  'center',"
        scriptSalesforce += "fontWeight:  'normal',"
        scriptSalesforce += "fontSize: 40,"

        If certificatesNumber > 0 And accreditedNumber > 0 Then
            scriptSalesforce += "left: 150,"
        Else
            scriptSalesforce += "left: 400,"
        End If

        scriptSalesforce += "top: 10"
        scriptSalesforce += "});"
        scriptSalesforce += " canvas.add(shadowText1);"

        scriptSalesforce += " canvas.renderAll();"

        scriptSalesforce += " window.location.href=""#drawZone"";"


        scriptSalesforce += " var objectToSendBack;"
        scriptSalesforce += " canvas.on('object:selected', function(event) {"
        scriptSalesforce += "       objectToSendBack = event.target;"
        scriptSalesforce += " });"

        scriptSalesforce += " var sendSelectedObjectBack = function() {"
        scriptSalesforce += "      canvas.sendToBack(objectToSendBack);"
        scriptSalesforce += " }"

        'scriptSalesforce += "var qrcode = new QRCode(document.getElementById('qrcode'), {width : 100,height : 100});"
        'scriptSalesforce += "qrcode.makeCode('https://trailhead.salesforce.com/credentials/certification-detail-print?searchString='" + idSalesforceInput + ");"
        'scriptSalesforce += "qrcode.makeCode(https://google.com);"

        scriptSalesforce += " }"
        scriptSalesforce += " function saveImg(){  "
        scriptSalesforce += " console.log('export image');"

        'scriptSalesforce += " canvas.remove(imgInstanceGrid);"

        scriptSalesforce += "if (!fabric.Canvas.supports('toDataURL')) {"
        scriptSalesforce += "       alert('This browser doesn\'t provide means to serialize canvas to an image');"
        scriptSalesforce += "} else {"
        scriptSalesforce += "       var ua = window.navigator.userAgent;"
        scriptSalesforce += "       if (ua.indexOf(""Chrome"") > 0) {"
        'scriptSalesforce += "          document.location.href = canvas.toDataURL(""image/png"").replace(""image/png"", ""image/octet-stream"");"
        scriptSalesforce += "           var link = document.createElement('a');"
        scriptSalesforce += "           link.download = ""SalesforceCertificateLogo.png"";"
        scriptSalesforce += "           link.href = canvas.toDataURL(""image/png"").replace(""image/png"", ""image/octet-stream"");;"
        scriptSalesforce += "           link.click();"
        scriptSalesforce += "       }else{"
        scriptSalesforce += "           window.open(canvas.toDataURL('png'));"
        'scriptSalesforce += "          var data = c.toDataURL(""image/png"");"
        'scriptSalesforce += "          return (data.indexOf(""data:image/png"") == 0);"
        scriptSalesforce += "}"
        scriptSalesforce += "}"
        scriptSalesforce += "}"


        'scriptSalesforce += "color =  document.getElementById(""chosen-value"").value;"
        'scriptSalesforce += "color = '#' + document.getElementById(""chosen-value"").value;"
        'scriptSalesforce += "color = '#00ff0a';"
        'scriptSalesforce += "color =  ""'"" + document.getElementById(""chosen-value"").value + ""'"" ;"
        'scriptSalesforce = "color =  ' document.getElementById(""chosen-value"").value ';"


        profileResponse.cScript = scriptSalesforce

        Return profileResponse

    End Function

    Public Function getDataHeaderJsonV4(ByRef profileResponse As Profile)
        Dim AuthorList As New List(Of Profile)()
        Dim tmpResponse As String = ""

        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim request As HttpWebRequest = HttpWebRequest.Create("https://drm.secure.force.com/services/apexrest/credential?searchString=" + idSalesforce)
        'Dim request As HttpWebRequest = HttpWebRequest.Create("https://www.idealista.com/inmueble/90408934/")
        'request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows Phone OS 7.5; Trident/5.0; IEMobile/9.0)"
        'request.KeepAlive = False
        request.Method = WebRequestMethods.Http.Get

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmpResponse = reader.ReadToEnd()
        'tmpResponse = "<response>
        '<GetResponse:data>
        '<GetResponse:jsonResponse>
        '{ "data" : [ { "Name" : "GARY PATTERSON", "City" : "Saratoga Springs", "State" : "US-UT", "Country" : "US", "MappingKey" : "jZTniBMAMhMPe37hzEhXIHToWcRwVhqWBbBeWYscg8tYnNviizrEqeg1u1YO8aJ1", "RelatedCertificationStatus" : { "totalSize" : 3, "records" : [ { "ExternalCertificationTypeName" : "Salesforce Certified Field Service Lightning Consultant", "CertificationDate" : "February 21, 2020", "RelatedCertificationType" : { "Image" : "https://drm--c.na114.content.force.com/servlet/servlet.ImageServer?id=0153k00000AH6io&oid=00DF0000000gZsu&lastMod=1571904711000" } }, { "ExternalCertificationTypeName" : "Salesforce Certified Service Cloud Consultant", "CertificationDate" : "October 29, 2019", "RelatedCertificationType" : { "Image" : "https://drm--c.na114.content.force.com/servlet/servlet.ImageServer?id=0153k00000AH6sA&oid=00DF0000000gZsu&lastMod=1571915344000" } }, { "ExternalCertificationTypeName" : "Salesforce Certified Administrator", "CertificationDate" : "May 29, 2019", "RelatedCertificationType" : { "Image" : "https://drm--c.na114.content.force.com/servlet/servlet.ImageServer?id=0153k00000AH6hb&oid=00DF0000000gZsu&lastMod=1571903578000" } } ] } } ] }
        '</GetResponse:jsonResponse>
        '</GetResponse:data>
        '</response>"
        response.Close()

        'Dim MyExpression1 As String = "<GetResponse:jsonResponse>(.*?)</GetResponse:jsonResponse>"
        'Dim Tables1 As MatchCollection = Regex.Matches(tmpResponse, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        'Crear el arreglo de usuarios encontrados
        'For Each matchTable In Tables1
        Dim serializer = New JavaScriptSerializer()
        Dim certificateResultWrapper As RootObject = serializer.Deserialize(Of RootObject)(tmpResponse)

        Dim db As DataBase = New DataBase()

        If certificateResultWrapper.errorCode Is Nothing And certificateResultWrapper.errorMessage Is Nothing And certificateResultWrapper.status = "success" Then

            Dim jsconResponse = certificateResultWrapper.data(0).jsonResponse
            Dim certificadoEncabezadoItem As RootObjectJson = serializer.Deserialize(Of RootObjectJson)(jsconResponse)
            Dim certificadoEncabezado As DatumJson = certificadoEncabezadoItem.data(0)

            Dim perfil As New Profile
            perfil.cName = certificadoEncabezado.Name
            perfil.cCity = certificadoEncabezado.City
            perfil.cState = certificadoEncabezado.State
            perfil.cCountry = certificadoEncabezado.Country

            Dim certificacionDetail As RelatedCertificationStatus = certificadoEncabezado.RelatedCertificationStatus
            Dim certificacionDetailRecord As List(Of Record) = certificacionDetail.records

            perfil.cCertificates = certificacionDetail.totalSize
            perfil.cLink = idSalesforce

            accreditedNumber = 0 'PENDIENTE
            certificatesNumber = certificacionDetail.totalSize
            contadorCertificates = certificacionDetail.totalSize

            'Borra de la base de datos el detalle de certificados
            db.deleteDetail(email)

            'Consultar si tenia un link anterior
            Dim dsCurrentRecord As DataSet = db.selectHeader(email)
            Dim dtCurrentRecord As DataTable = dsCurrentRecord.Tables(0)
            For Each row As DataRow In dtCurrentRecord.Rows
                perfil.cLink = row.Field(Of String)("link")
            Next

            Dim Sql As String = ""
            Dim contadorBadges = 0
            imagesCertifiedScript = ""
            For Each certificate In certificacionDetailRecord
                contadorBadges += 1
                imagesCertifiedScript += getImageFabricJSString(certificate.ExternalCertificationTypeName, contadorBadges)
                Sql += db.createSqlInsertDetail(email, certificate.ExternalCertificationTypeName, certificate.CertificationDate, certificate.RelatedCertificationType.Image, perfil.cLink)
            Next

            db.insertHeader(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)
            db.insertDetail(Sql, email)
            db.insertHistorico(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, idSalesforce, source)

            profileResponse = perfil
            configurationPositionCertifiedScript = getPositionScript(contadorCertificates)
        Else
            getDataHeaderDatabase(profileResponse)
        End If
        'Next



    End Function

    Public Function getDataHeaderHtml(ByRef profileResponse As Profile)
        Dim AuthorList As New List(Of Profile)()

        Dim tmpResponse As String = ""
        Dim sError As String = ""
        Dim strdownload As String = ""
        Dim strnombre As String = ""

        Dim certificateResultWrapper As New RootObject '= serializer.Deserialize(Of RootObject)(tmpResponse)

        'From 10-02-2020 Salesforce has down the site
        Dim certificadoEncabezado As DatumJson = getDataHeaderNamesHtmlV4(profileResponse)
        'From 10-02-2020 Salesforce has down the site
        Dim certificacionDetail As RelatedCertificationStatus = getDataHeaderCertificatesHtmlV4(profileResponse)

        certificateResultWrapper.status = "success"
        If certificacionDetail.totalSize = 0 Then
            certificateResultWrapper.status = "no data"
        End If

        Dim db As DataBase = New DataBase()

        If certificateResultWrapper.errorCode Is Nothing And certificateResultWrapper.errorMessage Is Nothing And certificateResultWrapper.status = "success" Then

            Dim perfil As New Profile

            perfil.cName = profileResponse.cEmail

            'perfil.cName = certificadoEncabezado.Name
            'perfil.cCity = certificadoEncabezado.City
            'perfil.cState = certificadoEncabezado.State
            'perfil.cCountry = certificadoEncabezado.Country

            perfil.cCertificates = certificacionDetail.totalSize
            perfil.cLink = idSalesforce

            accreditedNumber = 0 'PENDIENTE
            certificatesNumber = certificacionDetail.totalSize
            contadorCertificates = certificacionDetail.totalSize

            'Borra de la base de datos el detalle de certificados
            db.deleteDetail(email)

            Dim Sql As String = ""
            Dim contadorBadges = 0
            imagesCertifiedScript = ""
            For Each certificate In certificacionDetail.records
                contadorBadges += 1
                imagesCertifiedScript += getImageFabricJSString(certificate.ExternalCertificationTypeName, contadorBadges)
                Sql += db.createSqlInsertDetail(email, certificate.ExternalCertificationTypeName, certificate.CertificationDate, "", perfil.cLink)
                'Sql += db.createSqlInsertDetail(email, certificate.ExternalCertificationTypeName, certificate.CertificationDate, certificate.RelatedCertificationType.Image, perfil.cLink)
            Next

            db.insertHeader(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)
            db.insertDetail(Sql, email)
            db.insertHistorico(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)

            profileResponse = perfil
            configurationPositionCertifiedScript = getPositionScript(contadorCertificates)
        Else
            db.insertHistorico("No encontrado", "", "", "", "", email, idSalesforce, source)
        End If

    End Function

    Public Function getDataHeaderDatabase(ByRef profileResponse As Profile)
        Dim AuthorList As New List(Of Profile)()

        Dim tmpResponse As String = ""
        Dim sError As String = ""
        Dim strdownload As String = ""
        Dim strnombre As String = ""

        Dim certificateResultWrapper As New RootObject '= serializer.Deserialize(Of RootObject)(tmpResponse)
        'Dim certificadoEncabezadoItem As New RootObjectJson '= serializer.Deserialize(Of RootObjectJson)(jsconResponse)
        Dim certificadoEncabezado As New DatumJson '= certificadoEncabezadoItem.data(0)
        Dim certificacionDetail As New RelatedCertificationStatus '= certificadoEncabezado.RelatedCertificationStatus


        Dim db As DataBase = New DataBase()

        Dim dsUsuario As DataSet = New DataBase().selectHeader(email)
        Dim dtUsuario As DataTable = dsUsuario.Tables(0)

        For Each row As DataRow In dtUsuario.Rows
            certificadoEncabezado.Name = row.Field(Of String)("name")
            certificadoEncabezado.City = row.Field(Of String)("city")
            certificadoEncabezado.State = row.Field(Of String)("state")
            certificadoEncabezado.Country = row.Field(Of String)("country")
            certificacionDetail.totalSize = row.Field(Of Int32)("certificates")
        Next

        Dim dsUsuarioCertificates As DataSet = New DataBase().selectDetail(email)
        Dim dtUsuarioCertificates As DataTable = dsUsuarioCertificates.Tables(0)

        Dim certificacionDetailRecord As New List(Of Record) '= certificacionDetail.records

        For Each row As DataRow In dtUsuarioCertificates.Rows
            Dim recordItem As New Record
            recordItem.ExternalCertificationTypeName = row.Field(Of String)("certificate")
            certificacionDetailRecord.Add(recordItem)
        Next

        certificateResultWrapper.status = "success"
        If dtUsuario.Rows.Count = 0 Then
            certificateResultWrapper.status = "no data"
        End If


        If certificateResultWrapper.errorCode Is Nothing And certificateResultWrapper.errorMessage Is Nothing And certificateResultWrapper.status = "success" Then


            Dim perfil As New Profile
            perfil.cName = certificadoEncabezado.Name
            perfil.cCity = certificadoEncabezado.City
            perfil.cState = certificadoEncabezado.State
            perfil.cCountry = certificadoEncabezado.Country


            perfil.cCertificates = certificacionDetail.totalSize
            perfil.cLink = idSalesforce

            accreditedNumber = 0 'PENDIENTE
            certificatesNumber = certificacionDetail.totalSize
            contadorCertificates = certificacionDetail.totalSize

            'Borra de la base de datos el detalle de certificados
            'db.deleteDetail(email)

            Dim Sql As String = ""
            Dim contadorBadges = 0
            imagesCertifiedScript = ""
            For Each certificate In certificacionDetailRecord
                contadorBadges += 1
                imagesCertifiedScript += getImageFabricJSString(certificate.ExternalCertificationTypeName, contadorBadges)
                'Sql += db.createSqlInsertDetail(email, certificate.ExternalCertificationTypeName, certificate.CertificationDate, certificate.RelatedCertificationType.Image, perfil.cLink)
            Next

            'db.insertHeader(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)
            'db.insertDetail(Sql)
            db.insertHistorico(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)

            profileResponse = perfil
            configurationPositionCertifiedScript = getPositionScript(contadorCertificates)
        Else
            db.insertHistorico("No encontrado", "", "", "", "", email, idSalesforce, source)
        End If

    End Function

    Public Function getDataHeaderCertificatesHtmlV4(ByRef profileResponse As Profile) As RelatedCertificationStatus

        Dim certificacionDetail As New RelatedCertificationStatus
        certificacionDetail.records = New List(Of Record)

        Dim tmp As String = ""

        'From 18/02/2020 this ulr was shut down by salesforce
        Dim request As HttpWebRequest = HttpWebRequest.Create("http://certification.salesforce.com/certification-detail-print?conId=" + idSalesforce)

        request.Method = WebRequestMethods.Http.Get

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmp = reader.ReadToEnd()
        response.Close()

        Dim MyExpression1 = "<div class=""ver-search-results-line"">(.*?)</div>"
        Dim Tables1 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        Dim i As Integer = 0
        For Each matchTable In Tables1

            Dim certificateRecord As New Record

            Dim certificado = matchTable.value()

            Dim MyExpressionA = "<span id=""cert-name"" class=""credential""(.*?)</span>"
            Dim TablesA As MatchCollection = Regex.Matches(certificado, MyExpressionA, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            For Each matchTableA In TablesA
                certificateRecord.ExternalCertificationTypeName = matchTableA.value()
                certificateRecord.ExternalCertificationTypeName = getInnerText(certificateRecord.ExternalCertificationTypeName).Trim
            Next

            Dim MyExpressionB = "<span class=""date-certified"">(.*?)</span>"
            Dim TablesB As MatchCollection = Regex.Matches(certificado, MyExpressionB, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

            For Each matchTableB In TablesB
                certificateRecord.CertificationDate = matchTableB.value()
                certificateRecord.CertificationDate = getInnerText(certificateRecord.CertificationDate)
            Next

            certificacionDetail.records.Add(certificateRecord)
            i = i + 1
        Next

        certificacionDetail.totalSize = i

        Return certificacionDetail
    End Function

    Public Function getDataHeaderNamesHtmlV4(ByRef profileResponse As Profile) As DatumJson

        Dim certificadoEncabezado As New DatumJson

        Dim tmp As String = ""

        Dim request As HttpWebRequest = HttpWebRequest.Create("http://certification.salesforce.com/verification-email?init=1&email=" + email)

        request.Method = WebRequestMethods.Http.Get

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmp = reader.ReadToEnd()
        response.Close()

        Dim MyExpression1 As String = ""


        tmp = tmp.Replace("<span class=""name"">Name</span>", "")
        tmp = tmp.Replace("<span class=""city"">City</span>", "")
        tmp = tmp.Replace("<span class=""state"">State</span>", "")
        tmp = tmp.Replace("<span class=""country"">Country</span>", "")


        MyExpression1 = "<span class=""name"">(.*?)</span>"
        Dim Tables1 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables1
            certificadoEncabezado.Name = matchTable.value()
            certificadoEncabezado.Name = getInnerText(certificadoEncabezado.Name)
        Next

        MyExpression1 = "<span class=""city"">(.*?)</span>"
        Dim Tables2 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables2
            certificadoEncabezado.City = matchTable.value()
            certificadoEncabezado.City = getInnerText(certificadoEncabezado.City)
        Next

        MyExpression1 = "<span class=""state"">(.*?)</span>"
        Dim Tables3 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables3
            certificadoEncabezado.State = matchTable.value()
            certificadoEncabezado.State = getInnerText(certificadoEncabezado.State)
        Next

        MyExpression1 = "<span class=""country"">(.*?)</span>"
        Dim Tables4 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables4
            certificadoEncabezado.Country = matchTable.value()
            certificadoEncabezado.Country = getInnerText(certificadoEncabezado.Country)
        Next


        Return certificadoEncabezado
    End Function

    Public Function getDataHeaderNamesHtmlV5(ByRef profileResponse As Profile) As DatumJson

        Dim certificadoEncabezado As New DatumJson

        Dim tmp As String = ""

        Dim postData As String = String.Format("x={0}&P={1}", "usernamevalue", "passwordvalue")
        Dim request As HttpWebRequest = HttpWebRequest.Create("https://trailhead.salesforce.com/credentials/verification")
        request.Method = WebRequestMethods.Http.Post
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2"
        request.AllowWriteStreamBuffering = True
        request.ProtocolVersion = HttpVersion.Version11
        request.AllowAutoRedirect = True
        request.ContentType = "application/x-www-form-urlencoded"

        Dim byteArray As Byte() = Encoding.ASCII.GetBytes(postData)
        request.ContentLength = byteArray.Length
        Dim newStream As Stream = request.GetRequestStream()
        newStream.Write(byteArray, 0, byteArray.Length)
        newStream.Close()
        

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmp = reader.ReadToEnd()
        response.Close()

        Dim MyExpression1 As String = ""


        tmp = tmp.Replace("<span class=""name"">Name</span>", "")
        tmp = tmp.Replace("<span class=""city"">City</span>", "")
        tmp = tmp.Replace("<span class=""state"">State</span>", "")
        tmp = tmp.Replace("<span class=""country"">Country</span>", "")


        MyExpression1 = "<span class=""name"">(.*?)</span>"
        Dim Tables1 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables1
            certificadoEncabezado.Name = matchTable.value()
            certificadoEncabezado.Name = getInnerText(certificadoEncabezado.Name)
        Next

        MyExpression1 = "<span class=""city"">(.*?)</span>"
        Dim Tables2 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables2
            certificadoEncabezado.City = matchTable.value()
            certificadoEncabezado.City = getInnerText(certificadoEncabezado.City)
        Next

        MyExpression1 = "<span class=""state"">(.*?)</span>"
        Dim Tables3 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables3
            certificadoEncabezado.State = matchTable.value()
            certificadoEncabezado.State = getInnerText(certificadoEncabezado.State)
        Next

        MyExpression1 = "<span class=""country"">(.*?)</span>"
        Dim Tables4 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        For Each matchTable In Tables4
            certificadoEncabezado.Country = matchTable.value()
            certificadoEncabezado.Country = getInnerText(certificadoEncabezado.Country)
        Next


        Return certificadoEncabezado
    End Function

    Public Function getDataHeaderJsonV3(ByRef profileResponse As Profile)
        Dim AuthorList As New List(Of Profile)()
        Dim tmpResponse As String = ""

        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim request As HttpWebRequest = HttpWebRequest.Create("https://certification.secure.force.com/certificationsite/services/apexrest/credential?searchString=" + idSalesforce)
        request.Method = WebRequestMethods.Http.Get

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmpResponse = reader.ReadToEnd()
        'tmpResponse = "{   ""status"": ""success"",   ""errorMessage"": null,   ""errorCode"": null,   ""data"": [     {       ""jsonResponse"": """"     }   ] }"
        response.Close()

        Dim serializer = New JavaScriptSerializer()
        Dim certificateResultWrapper As RootObject = serializer.Deserialize(Of RootObject)(tmpResponse)

        Dim db As DataBase = New DataBase()

        If certificateResultWrapper.errorCode Is Nothing And certificateResultWrapper.errorMessage Is Nothing And certificateResultWrapper.status = "success" Then

            Dim jsconResponse = certificateResultWrapper.data(0).jsonResponse
            Dim certificadoEncabezadoItem As RootObjectJson = serializer.Deserialize(Of RootObjectJson)(jsconResponse)
            Dim certificadoEncabezado As DatumJson = certificadoEncabezadoItem.data(0)

            Dim perfil As New Profile
            perfil.cName = certificadoEncabezado.Name
            perfil.cCity = certificadoEncabezado.City
            perfil.cState = certificadoEncabezado.State
            perfil.cCountry = certificadoEncabezado.Country

            Dim certificacionDetail As RelatedCertificationStatus = certificadoEncabezado.RelatedCertificationStatus
            Dim certificacionDetailRecord As List(Of Record) = certificacionDetail.records

            perfil.cCertificates = certificacionDetail.totalSize
            perfil.cLink = idSalesforce

            accreditedNumber = 0 'PENDIENTE
            certificatesNumber = certificacionDetail.totalSize
            contadorCertificates = certificacionDetail.totalSize

            'Borra de la base de datos el detalle de certificados
            db.deleteDetail(email)

            'Consultar si tenia un link anterior
            Dim dsCurrentRecord As DataSet = db.selectHeader(email)
            Dim dtCurrentRecord As DataTable = dsCurrentRecord.Tables(0)
            For Each row As DataRow In dtCurrentRecord.Rows
                perfil.cLink = row.Field(Of String)("link")
            Next



            Dim Sql As String = ""
            Dim contadorBadges = 0
            imagesCertifiedScript = ""
            For Each certificate In certificacionDetailRecord
                contadorBadges += 1
                imagesCertifiedScript += getImageFabricJSString(certificate.ExternalCertificationTypeName, contadorBadges)
                Sql += db.createSqlInsertDetail(email, certificate.ExternalCertificationTypeName, certificate.CertificationDate, certificate.RelatedCertificationType.Image, perfil.cLink)
            Next

            db.insertHeader(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)
            db.insertDetail(Sql, email)
            db.insertHistorico(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, idSalesforce, source)

            profileResponse = perfil
            configurationPositionCertifiedScript = getPositionScript(contadorCertificates)
        Else
            getDataHeaderDatabase(profileResponse)
            getDataHeaderHtml(profileResponse)

        End If

    End Function

    Public Function getDataHeaderNuevoV2(ByRef profileResponse As Profile)
        Dim AuthorList As New List(Of Profile)()

        Dim name As String = ""
        Dim city As String = ""
        Dim state As String = ""
        Dim country As String = ""
        Dim link As String = ""

        Dim tmpResponse As String = ""
        Dim sError As String = ""
        Dim strdownload As String = ""
        Dim strnombre As String = ""

        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim request As HttpWebRequest = HttpWebRequest.Create("https://certification.secure.force.com/certificationsite/services/apexrest/credential?searchString=" + idSalesforce)
        request.Method = WebRequestMethods.Http.Get

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmpResponse = reader.ReadToEnd()
        response.Close()

        Dim serializer = New JavaScriptSerializer()
        Dim certificateResult As CertificateResponse = serializer.Deserialize(Of CertificateResponse)(tmpResponse)

        Dim db As DataBase = New DataBase()


        If certificateResult.errorCode Is Nothing And certificateResult.errorMessage Is Nothing And certificateResult.status = "success" Then

            Dim certificadoEncabezado As CertificateResponse.Datum = certificateResult.data(0)

            Dim perfil As New Profile
            perfil.cName = certificadoEncabezado.Full_Name__c
            perfil.cCity = certificadoEncabezado.MailingCity
            perfil.cState = certificadoEncabezado.MailingState
            perfil.cCountry = certificadoEncabezado.MailingCountry

            Dim certificacionDetail As CertificateResponse.CertificationStatusR = certificadoEncabezado.Certification_Status__r
            Dim certificacionDetailRecord As CertificateResponse.Record() = certificacionDetail.records

            perfil.cCertificates = certificacionDetail.totalSize
            perfil.cLink = certificateResult.data(0).Id

            accreditedNumber = 0 'PENDIENTE
            certificatesNumber = certificacionDetail.totalSize
            contadorCertificates = certificacionDetail.totalSize

            'Borra de la base de datos
            db.deleteDetail(perfil.cLink)

            Dim Sql As String = ""
            Dim contadorBadges = 0
            imagesCertifiedScript = ""
            For Each certificate In certificacionDetailRecord
                contadorBadges += 1
                imagesCertifiedScript += getImageFabricJSString(certificate.Certification_Type_Name__c, contadorBadges)
                Sql += db.createSqlInsertDetail(email, certificate.External_Certification_Type_Name__c, certificate.External_Original_Certification_Date__c, certificate.Id, certificate.Contact__c)
            Next


            db.insertDetail(Sql, email)

            db.insertHistorico(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)
            profileResponse = perfil


            configurationPositionCertifiedScript = getPositionScript(contadorCertificates)
        Else
            db.insertHistorico("No encontrado", "", "", "", "", email, idSalesforce, source)

        End If



    End Function

    Public Function getDataHeaderV1(ByRef profileResponse As Profile)

        Dim AuthorList As New List(Of Profile)()

        Dim name As String = ""
        Dim city As String = ""
        Dim state As String = ""
        Dim country As String = ""
        Dim link As String = ""

        Dim tmp As String = ""
        Dim sError As String = ""
        Dim strdownload As String = ""
        Dim strnombre As String = ""


        Dim request As HttpWebRequest = HttpWebRequest.Create("http://certification.salesforce.com/verification-email?init=1&email=" + email)
        'Dim request As HttpWebRequest = HttpWebRequest.Create("http://certification.salesforce.com/verification?init=1&fullname=" + Server.UrlEncode(email.Text))

        request.Method = WebRequestMethods.Http.Get

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmp = reader.ReadToEnd()
        response.Close()

        Dim MyExpression1 As String = ""

        'Mayank Srivastava

        tmp = tmp.Replace("<span class=""name"">Name</span>", "")
        tmp = tmp.Replace("<span class=""city"">City</span>", "")
        tmp = tmp.Replace("<span class=""state"">State</span>", "")
        tmp = tmp.Replace("<span class=""country"">Country</span>", "")


        MyExpression1 = "<span class=""name"">(.*?)</span>"
        Dim Tables1 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        'Crear el arreglo de usuarios encontrados
        For Each matchTable In Tables1
            Dim perfil As New Profile
            AuthorList.Add(perfil)
        Next

        If AuthorList.Count = 0 Then
            'lblMessage1.Text = "No Search Results"
            'lblMessage3.Text = "Your search for a certified professional has returned no results. Please confirm the full name or email address associated with this person's Salesforce.com Certification account and confirm they have selected to share their certification information."
        End If

        Dim i As Integer = 0
        For Each matchTable In Tables1
            name = matchTable.value()
            name = getInnerText(name)
            AuthorList.Item(i).cName = name
            i += 1
        Next

        MyExpression1 = "<span class=""city"">(.*?)</span>"
        Dim Tables2 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        i = 0
        For Each matchTable In Tables2
            city = matchTable.value()
            city = getInnerText(city)
            AuthorList.Item(i).cCity = city
            i += 1
        Next

        MyExpression1 = "<span class=""state"">(.*?)</span>"
        Dim Tables3 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        i = 0
        For Each matchTable In Tables3
            state = matchTable.value()
            state = getInnerText(state)
            AuthorList.Item(i).cState = state
            i += 1
        Next

        MyExpression1 = "<span class=""country"">(.*?)</span>"
        Dim Tables4 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        i = 0
        For Each matchTable In Tables4
            country = matchTable.value()
            country = getInnerText(country)
            AuthorList.Item(i).cCountry = country
            i += 1
        Next

        MyExpression1 = "<a href=[^>]*>View Accreditations</a>"
        Dim Tables5 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        'Dim primerInput As Boolean = True

        contadorCertificates = 0
        imagesCertifiedScript = ""


        i = 0
        For Each matchTable In Tables5
            accreditedNumber = 0
            certificatesNumber = 0

            Dim ValorColumnaDia As String = matchTable.value()
            Dim allInputs As IHTMLElementCollection = HacerLlamadoWebManual(ValorColumnaDia.ToString, "", "span")
            'If primerInput Then
            For Each item As IHTMLElement In allInputs
                Dim textAccredited As String = ""
                link = item.getAttribute("href").Replace("about:/", "")
                accreditedNumber = getCertificationDataDetail(link)

                Dim textCertificates As String = ""
                link = link.Replace("accreditation-detail", "certification-detail")
                certificatesNumber = getCertificationDataDetail(link)
            Next
            'primerInput = False
            'End If
            AuthorList.Item(i).cCertificates = contadorCertificates.ToString
            AuthorList.Item(i).cLink = link.ToString
            i += 1

        Next

        Dim contadorBadges = 0
        For Each classImage As String In listBadges
            contadorBadges += 1
            imagesCertifiedScript += getImageFabricJSString(classImage, contadorBadges)
        Next


        'certificates = getCertificationDataDetail(link)

        For Each perfil As Profile In AuthorList
            Dim db As DataBase = New DataBase()
            db.insertHistorico(perfil.cName, perfil.cCity, perfil.cState, perfil.cCountry, perfil.cCertificates, email, perfil.cLink, source)
            profileResponse = perfil
        Next

        If AuthorList.Count = 0 Then
            Dim db As DataBase = New DataBase()
            db.insertHistorico("", "", "", "", "", email, "", source)

        End If

        configurationPositionCertifiedScript = getPositionScript(contadorCertificates)
        'configurationPositionCertifiedScript = getPositionScript(total.Text)



    End Function

    Public Function getCertificationDataDetail(ByVal linkDetalle As String) As Integer


        Dim db As DataBase = New DataBase()
        Dim classImage As String = ""

        Dim tmp As String = ""
        Dim sError As String = ""
        Dim strdownload As String = ""
        Dim strnombre As String = ""

        'linkDetalle = linkDetalle.Replace("accreditation-detail", "certification-detail")

        Dim request As HttpWebRequest = HttpWebRequest.Create("http://certification.salesforce.com/" + linkDetalle)
        request.Method = WebRequestMethods.Http.Get

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim reader As New StreamReader(response.GetResponseStream())
        tmp = reader.ReadToEnd()
        response.Close()

        Dim MyExpression1 As String = ""

        MyExpression1 = "<div class=""ver-search-results-line"">(.*?)</div>"
        Dim Tables1 As MatchCollection = Regex.Matches(tmp, MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)

        'Elimina el detalle de ese link id
        db.deleteDetail(linkDetalle)

        'ContadorCertificates = 0
        For Each matchTable In Tables1
            contadorCertificates = contadorCertificates + 1
        Next

        Dim certificatesLocal As Integer = 0
        Dim sql As String = ""

        For Each matchTable In Tables1

            certificatesLocal += 1

            If certificatesLocal <= contadorCertificates Then

                Dim certificado As String = ""
                Dim certificadoFecha As String = ""

                MyExpression1 = "<span id=""cert-name""[^>]*>(.*?)</span>"
                Dim TablesCertificado As MatchCollection = Regex.Matches(matchTable.value(), MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                For Each matchTableCertificado In TablesCertificado
                    certificado = matchTableCertificado.value()
                    certificado = getInnerText(certificado)
                Next

                MyExpression1 = "<span class=""date-certified"">(.*?)</span>"
                Dim TablesCertificadoFecha As MatchCollection = Regex.Matches(matchTable.value(), MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                For Each matchTableCertificadoFecha In TablesCertificadoFecha
                    certificadoFecha = matchTableCertificadoFecha.value()
                    certificadoFecha = getInnerText(certificadoFecha)
                Next

                MyExpression1 = "<span class=""cert-badge[^>]*""></span>"
                Dim TablesCertificadoIamgen As MatchCollection = Regex.Matches(matchTable.value(), MyExpression1, RegexOptions.Multiline Or RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                For Each matchTableCertificadoImagen In TablesCertificadoIamgen
                    classImage = matchTableCertificadoImagen.value()
                    classImage = classImage.Replace("<span class=""", "").Replace("""></span>", "").Replace(" ", ".")
                    classImage = "." + classImage
                Next

                'imagesCertifiedScript += getImageFabricJSString(classImage, certificatesLocal)
                listBadges.Add(classImage)

                sql += db.createSqlInsertDetail(email, certificado, certificadoFecha, classImage, linkDetalle)

            End If
        Next

        If certificatesLocal > 0 Then
            db.insertDetail(sql, email)
        End If

        Return certificatesLocal



    End Function

    Public Function HacerLlamadoWebManual(ByVal innerHtmlTorneo As String, ByRef Serror As String, ByVal tag As String) As IHTMLElementCollection

        Dim htmlValoresItemsTorneo As String = "<html><body>" + innerHtmlTorneo.ToString + "</html></body>"

        Dim htmlDocument As IHTMLDocument2 = New HTMLDocument
        htmlDocument.write(htmlValoresItemsTorneo)
        htmlDocument.close()

        Dim allElements As IHTMLElementCollection = htmlDocument.body.all
        Dim allInputs As IHTMLElementCollection = allElements.tags("option")

        Return allElements

    End Function

    Public Function getInnerText(value As String) As String
        Dim allInputs As IHTMLElementCollection = HacerLlamadoWebManual(value.ToString, "", "span")
        For Each item As IHTMLElement In allInputs
            value = item.innerText
        Next

        Return value
    End Function

    Public Function getPositionScript(totalCertificates As Integer) As String

        Dim scriptSalesforce As String = ""


        'Dim ContadorCertificates As Integer = Convert.ToInt32(totalInput.Text.ToString)

        Select Case contadorCertificates

            'Select Case totalCertificates


            Case 1
                scriptSalesforce += "  var initialPositionXOriginal = 420;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 1;"
                scriptSalesforce += "  var scaleY = 1;"
                scriptSalesforce += "  var separation = 0;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 2
                scriptSalesforce += "  var initialPositionXOriginal = 250;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 120;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.8;"
                scriptSalesforce += "  var scaleY = 0.8;"
                scriptSalesforce += "  var separation = 400;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 3
                scriptSalesforce += "  var initialPositionXOriginal = 180;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 120;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.7;"
                scriptSalesforce += "  var scaleY = 0.7;"
                scriptSalesforce += "  var separation = 300;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 4
                scriptSalesforce += "  var initialPositionXOriginal = 40;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 120;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.6;"
                scriptSalesforce += "  var scaleY = 0.6;"
                scriptSalesforce += "  var separation = 300;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 5
                scriptSalesforce += "  var initialPositionXOriginal = 40;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 120;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.6;"
                scriptSalesforce += "  var scaleY = 0.6;"
                scriptSalesforce += "  var separation = 230;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 6
                scriptSalesforce += "  var initialPositionXOriginal = 30;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 130;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.5;"
                scriptSalesforce += "  var scaleY = 0.5;"
                scriptSalesforce += "  var separation = 190;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 7
                scriptSalesforce += "  var initialPositionXOriginal = 30;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.5;"
                scriptSalesforce += "  var scaleY = 0.5;"
                scriptSalesforce += "  var separation = 240;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 8
                scriptSalesforce += "  var initialPositionXOriginal = 30;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.5;"
                scriptSalesforce += "  var scaleY = 0.5;"
                scriptSalesforce += "  var separation = 240;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 9
                scriptSalesforce += "  var initialPositionXOriginal = 30;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.5;"
                scriptSalesforce += "  var scaleY = 0.5;"
                scriptSalesforce += "  var separation = 240;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 10
                scriptSalesforce += "  var initialPositionXOriginal = 30;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.5;"
                scriptSalesforce += "  var scaleY = 0.5;"
                scriptSalesforce += "  var separation = 240;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 11
                scriptSalesforce += "  var separation = 200;"
                scriptSalesforce += "  var initialPositionXOriginal = 120;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.45;"
                scriptSalesforce += "  var scaleY = 0.45;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 12
                scriptSalesforce += "  var separation = 200;"
                scriptSalesforce += "  var initialPositionXOriginal = 20;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.45;"
                scriptSalesforce += "  var scaleY = 0.45;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 13
                scriptSalesforce += "  var separation = 160;"
                scriptSalesforce += "  var initialPositionXOriginal = 120;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.4;"
                scriptSalesforce += "  var scaleY = 0.4;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 14
                scriptSalesforce += "  var separation = 160;"
                scriptSalesforce += "  var initialPositionXOriginal = 50;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.4;"
                scriptSalesforce += "  var scaleY = 0.4;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 15
                scriptSalesforce += "  var separation = 140;"
                scriptSalesforce += "  var initialPositionXOriginal = 100;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.38;"
                scriptSalesforce += "  var scaleY = 0.38;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"
            Case 16
                scriptSalesforce += "  var separation = 140;"
                scriptSalesforce += "  var initialPositionXOriginal = 50;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 90;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.38;"
                scriptSalesforce += "  var scaleY = 0.38;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"

            Case 17 To 24
                scriptSalesforce += "  var separation = 140;"
                scriptSalesforce += "  var initialPositionXOriginal = 50;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 70;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.38;"
                scriptSalesforce += "  var scaleY = 0.38;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"

            Case 25 To 30
                scriptSalesforce += "  var separation = 130;"
                scriptSalesforce += "  var initialPositionXOriginal = 25;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 60;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.34;"
                scriptSalesforce += "  var scaleY = 0.34;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"

            Case 31 To 35
                scriptSalesforce += "  var separation = 115;"
                scriptSalesforce += "  var initialPositionXOriginal = 27;"
                scriptSalesforce += "  var initialPositionX = initialPositionXOriginal;"
                scriptSalesforce += "  var initialPositionYOriginal = 55;"
                scriptSalesforce += "  var initialPositionY = initialPositionYOriginal;"
                scriptSalesforce += "  var scaleX = 0.30;"
                scriptSalesforce += "  var scaleY = 0.30;"
                scriptSalesforce += "  var total = " + contadorCertificates.ToString + ";"
                scriptSalesforce += "  var incrementoPosicionY = 0;"

        End Select




        Return scriptSalesforce


    End Function

    Public Function getImageFabricJSString(ByVal imagen As String, ByVal contador As Integer) As String
        Dim scriptSalesforce As String = ""


        scriptSalesforce += "imgElement = document.getElementById('" + imagen + "');"
        scriptSalesforce += "imgInstance = new fabric.Image(imgElement, {"
        scriptSalesforce += "  scaleY: scaleY,"
        scriptSalesforce += "  scaleX: scaleX,"

        scriptSalesforce += "  left: initialPositionX,"
        scriptSalesforce += "  top: initialPositionY"


        scriptSalesforce += " });"

        scriptSalesforce += "canvas.add(imgInstance);"
        scriptSalesforce += "initialPositionX +=  separation ;"

        ' Dim total As Integer = Convert.ToInt32(totalInput.Text.ToString)

        'Select Case ContadorCertificates
        Select Case contadorCertificates
            Case 7
                If contador Mod 5 = 0 Then
                    'scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    'scriptSalesforce += "       initialPositionX = initialPositionXOriginal + 320;"

                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal;"
                    scriptSalesforce += "       separation = 960;"
                    rowsImages += 1
                End If
            Case 8
                If contador Mod 5 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal + separation;"
                End If
            Case 9
                If contador Mod 5 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal + separation/2;"
                End If
            Case 10
                If contador Mod 5 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal;"
                End If
            Case 11
                'If contador Mod 5 = 0 Then
                If contador = 5 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal - 100;"
                End If
            Case 12
                If contador Mod 6 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal;"
                End If
            Case 13
                'If contador Mod 6 = 0 Then
                If contador = 6 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal - initialPositionXOriginal/1.7;"
                End If
            Case 14
                If contador Mod 7 = 0 Then
                    'If contador = 7 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal ;"
                End If
            Case 15
                'If contador Mod 7 = 0 Then
                If contador = 7 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal - initialPositionXOriginal/2;"
                End If
            Case 16
                If contador Mod 8 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 120;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal;"
                End If
            Case 17 To 24
                If contador Mod 8 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 80;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal;"
                End If
            Case 25 To 30
                If contador Mod 9 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 80;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal;"
                End If
            Case 31 To 35
                If contador Mod 10 = 0 Then
                    scriptSalesforce += "       initialPositionY  = initialPositionY + 65;"
                    scriptSalesforce += "       initialPositionX = initialPositionXOriginal;"
                End If

        End Select


        Return scriptSalesforce

    End Function



End Class
