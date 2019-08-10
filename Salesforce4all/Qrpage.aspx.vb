Public Class Qrpage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim searchString As String = Request.QueryString("searchString")
        Dim salesforcePage = "https://trailhead.salesforce.com/credentials/certification-detail-print?searchString=" + searchString
        Response.Redirect(salesforcePage)

    End Sub

End Class