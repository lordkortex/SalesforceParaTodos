Public Class CertificateResponse

    Public Property status As String
    Public Property errorMessage As Object
    Public Property errorCode As Object
    Public Property data As Datum()

    Public Class Attributes
        Public Property type As String
        Public Property url As String
    End Class

    Public Class Record
        Public Property attributes As Attributes
        Public Property Contact__c As String
        Public Property Id As String
        Public Property Certification_Type_Name__c As String
        Public Property External_Certification_Type_Name__c As String
        Public Property External_Original_Certification_Date__c As String
    End Class

    Public Class CertificationStatusR
        Public Property totalSize As Integer
        Public Property done As Boolean
        Public Property records As Record()
    End Class

    Public Class Datum
        Public Property attributes As Attributes
        Public Property Full_Name__c As String
        Public Property MailingCity As String
        Public Property MailingState As String
        Public Property MailingCountry As String
        Public Property Id As String
        Public Property Certification_Status__r As CertificationStatusR
    End Class


End Class
