Public Class Desarrollo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim generatorService As New Generador

        Dim email As String = Request.QueryString("email")
        Dim indexBackground As String = Request.QueryString("indexBackground")

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

    End Sub


End Class