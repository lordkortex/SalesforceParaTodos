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

Public Class _Default
    Inherits System.Web.UI.Page

    Dim src As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim generatorService As New Generador

        Dim email As String = Request.QueryString("email")
        Dim indexBackground As String = Request.QueryString("indexBackground")

        Dim textoIframe As String = "&lt;iframe src=&quot;http://salesforce4all.com//FrameCertificate.aspx?email=XXXXXXXXXX&amp;background=6&quot; width=&quot;1200&quot; height=&quot;320&quot; scrolling=&quot;no&quot; style=&quot;overflow:hidden;&quot; frameborder=&quot;0&quot;&gt;&lt;/iframe&gt; "
        LiteralIframe.Text = textoIframe.Replace("XXXXXXXXXX", email)

        Dim salesforceSearchString As String = idSalesforce.Text 'Request.QueryString("salesforceSearchString")
        'Dim salesforcePage = "https://trailhead.salesforce.com/credentials/certification-detail-print?searchString=" + salesforceSearchString
        Dim salesforcePage = "http://salesforce4all.com/Qrpage.aspx?searchString=" + salesforceSearchString
        textQr.Text = salesforcePage

        textQr.Style.Add("display", "none")

        Try
            Dim folderPath As String = Server.MapPath("~/Images/12/")
            Dim path1 As String = folderPath & "Custom.png"
            Dim myfileinf As New FileInfo(path1)
            myfileinf.Delete()
        Catch ex As Exception

        End Try

        If Not Page.IsPostBack Then
       

        End If

        'If Not email Is Nothing And Not indexBackground Is Nothing Then
        '    Dim profileResponse As Profile = generatorService.getFabricJsScript(email, "", indexBackground)
        '    lblName.Text = profileResponse.cName
        '    lblCity.Text = profileResponse.cCity
        '    lblCountry.Text = profileResponse.cCountry
        '    lblState.Text = profileResponse.cState

        '    ScriptManager.RegisterStartupScript(Page, Me.GetType(), "autocomplete", profileResponse.cScript, True)
        'End If



    End Sub


    Protected Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        'Dim folderPath As String = Server.MapPath("~/Images/12/")

        'If Not Directory.Exists(folderPath) Then
        '    Directory.CreateDirectory(folderPath)
        'End If

        'FileUpload1.SaveAs(folderPath & Path.GetFileName(FileUpload1.FileName))
        'FileUpload1.SaveAs(folderPath & "Custom.png")





        Dim generatorService As New Generador
        Dim source As String = "direct"

        If Request.QueryString("source") IsNot Nothing Then
            source = Request.QueryString("source")
        End If

        LabelInputMessageValidation.Text = ""

        If email.Text = "" Then
            LabelInputMessageValidation.Text = "Email is requiered"
        End If

        If idSalesforce.Text = "" Then
            LabelInputMessageValidation.Text = "id Salesforce is requiered"
        End If

        If LabelInputMessageValidation.Text = "" Then

            Dim textoIframe As String = "&lt;iframe src=&quot;http://salesforce4all.com//FrameCertificate.aspx?email=XXXXXXXXXX&amp;background=6&quot; width=&quot;1200&quot; height=&quot;320&quot; scrolling=&quot;no&quot; style=&quot;overflow:hidden;&quot; frameborder=&quot;0&quot;&gt;&lt;/iframe&gt; "
            'LiteralIframe.Text = textoIframe.Replace("XXXXXXXXXX", idSalesforce.Text)
            LiteralIframe.Text = textoIframe.Replace("XXXXXXXXXX", idSalesforce.Text)


            Dim profileResponse As Profile = generatorService.getFabricJsScript(email.Text, source, imageSelected.SelectedIndex, False, idSalesforce.Text, False, TextBoxColor.Text)
            lblName.Text = profileResponse.cName
            lblCity.Text = profileResponse.cCity
            lblCountry.Text = profileResponse.cCountry
            lblState.Text = profileResponse.cState
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "autocomplete", profileResponse.cScript, True)
        Else
            Dim db As DataBase = New DataBase()
            Try
                db.insertHistorico(LabelInputMessageValidation.Text, "", "", "", "", email.Text, idSalesforce.Text, source)
            Catch ex As Exception
            End Try
        End If


      

    End Sub

   
    Protected Sub UploadFile(sender As Object, e As EventArgs) Handles btnUpload.Click

        LabelUpload.Text = ""

        If FileUpload1.FileName <> "" Then
            Dim folderPath As String = Server.MapPath("~/Images/12/")
            Dim folderPathUser As String = Server.MapPath("~/Images/12/user/")

            Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim extension As String = Path.GetExtension(filename)

            If extension = ".png" Or extension = ".jpg" Then
                'Check whether Directory (Folder) exists.
                If Not Directory.Exists(folderPath) Then
                    'If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath)
                End If

                Try
                    Dim folderPathDelete As String = Server.MapPath("~/Images/12/")
                    Dim path1 As String = folderPathDelete & "Custom.png"
                    Dim myfileinf As New FileInfo(path1)
                    myfileinf.Delete()
                Catch ex As Exception

                End Try

                'Save the File to the Directory (Folder).
                'FileUpload1.SaveAs(folderPathUser & Path.GetFileName(FileUpload1.FileName))
                FileUpload1.SaveAs(folderPathUser & Path.GetFileName(FileUpload1.FileName))
                FileUpload1.SaveAs(folderPath & "Custom.png")

                'src = "~/Images/12/" & Path.GetFileName(FileUpload1.FileName)
                'Display the Picture in Image control.
                'Image1.ImageUrl = "~/Images/12/" & Path.GetFileName(FileUpload1.FileName)
                'Image1.ImageUrl = "~/Images/12/Custom.png"
            Else
                LabelUpload.Text = "Extension file must be .png or .jpg"
            End If

        Else
            LabelUpload.Text = "You must select a file first."

        End If

    End Sub
End Class