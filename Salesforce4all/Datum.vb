<Serializable> _
Public Class Datum
    Public Property jsonResponse As String
End Class

Public Class RootObject
    Public Property status As String
    Public Property errorMessage As Object
    Public Property errorCode As Object
    Public Property data As List(Of Datum)
End Class


Public Class RelatedCertificationType
    Public Property Image As String
End Class

Public Class Record
    Public Property ExternalCertificationTypeName As String
    Public Property CertificationDate As String
    Public Property RelatedCertificationType As RelatedCertificationType
End Class

Public Class RelatedCertificationStatus
    Public Property totalSize As Integer
    Public Property records As List(Of Record)
End Class

Public Class DatumJson
    Public Property Name As String
    Public Property City As String
    Public Property State As String
    Public Property Country As String
    Public Property MappingKey As String
    Public Property RelatedCertificationStatus As RelatedCertificationStatus
End Class

Public Class RootObjectJson
    Public Property data As List(Of DatumJson)
End Class


