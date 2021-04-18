Public Class Artisans
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim source As String = "Artisans"

        If Not IsPostBack Then
            Dim generatorService As New Generador
            Dim emailQuery As String = Request.QueryString("contactEmail")

            If emailQuery IsNot Nothing Then
                If emailQuery.Contains("@") Then
                    email.Text = emailQuery
                End If
            End If

            Dim idSalesforceQuery As String = Request.QueryString("email")
            If idSalesforceQuery Is Nothing Then
                idSalesforceQuery = emailQuery
                idSalesforce.Text = idSalesforceQuery
            End If


            Dim textoIframe As String = "&lt;iframe src=&quot;http://salesforce4all.com//FrameCertificate.aspx?email=XXXXXXXXXX&amp;background=6&quot; width=&quot;1200&quot; height=&quot;320&quot; scrolling=&quot;no&quot; style=&quot;overflow:hidden;&quot; frameborder=&quot;0&quot;&gt;&lt;/iframe&gt; "
            LiteralIframe.Text = textoIframe.Replace("XXXXXXXXXX", idSalesforceQuery)


            Dim profileResponse As Profile = generatorService.getFabricJsScript(emailQuery, source, imageSelected.SelectedIndex, True, idSalesforceQuery, True, "", Nothing)
            lblName.Text = profileResponse.cName
            lblCity.Text = profileResponse.cCity
            lblCountry.Text = profileResponse.cCountry
            lblState.Text = profileResponse.cState

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "autocomplete", profileResponse.cScript, True)
        Else
            Dim generatorService As New Generador
            LabelInputMessageValidation.Text = ""

            If email.Text = "" Then
                LabelInputMessageValidation.Text = "Email is requiered"
            End If

            If idSalesforce.Text = "" Then
                LabelInputMessageValidation.Text = "id Salesforce is requiered"
            End If

            If LabelInputMessageValidation.Text = "" Then
                Dim textoIframe As String = "&lt;iframe src=&quot;http://salesforce4all.com//FrameCertificate.aspx?email=XXXXXXXXXX&amp;background=6&quot; width=&quot;1200&quot; height=&quot;320&quot; scrolling=&quot;no&quot; style=&quot;overflow:hidden;&quot; frameborder=&quot;0&quot;&gt;&lt;/iframe&gt; "
                LiteralIframe.Text = textoIframe.Replace("XXXXXXXXXX", email.Text)


                Dim profileResponse As Profile = generatorService.getFabricJsScript(email.Text, source, imageSelected.SelectedIndex, False, idSalesforce.Text, False, "", Nothing)
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


        End If


    End Sub

  
    Protected Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Dim generatorService As New Generador

        Dim source As String = ""

        If Request.QueryString("source") IsNot Nothing Then
            source = Request.QueryString("source")
        End If

        'Dim email As String = Request.QueryString("email")

        Dim profileResponse As Profile = generatorService.getFabricJsScript(email.Text, source, imageSelected.SelectedIndex, False, idSalesforce.Text, False, "", Nothing)
        lblName.Text = profileResponse.cName
        lblCity.Text = profileResponse.cCity
        lblCountry.Text = profileResponse.cCountry
        lblState.Text = profileResponse.cState

        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "autocomplete", profileResponse.cScript, True)

    End Sub
End Class