Public Class FrameCertificate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim generatorService As New Generador

        Dim email As String = Request.QueryString("email")

        Dim background As Integer = Request.QueryString("background")

        Dim profileResponse As Profile = generatorService.getFabricJsScript(email, "IFrame", background, False, email, True, "")
      
        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "autocomplete", profileResponse.cScript, True)
    End Sub

End Class