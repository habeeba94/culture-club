Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Group")>
Partial Public Class Group
    Public Property Id As Integer

    <Required>
    <StringLength(25)>
    Public Property Name As String

    <Required>
    <StringLength(300)>
    Public Property Description As String
End Class