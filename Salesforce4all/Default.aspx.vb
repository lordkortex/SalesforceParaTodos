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


            Dim profileResponse As Profile = generatorService.getFabricJsScript(email.Text, source, imageSelected.SelectedIndex, False, idSalesforce.Text, False)
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

   
End Class