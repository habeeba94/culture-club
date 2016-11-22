Imports System.ComponentModel.DataAnnotations

Partial Public Class Major

    Public Sub New()
        Users = New HashSet(Of ApplicationUser)()
    End Sub

    Public Property Id As Integer

    <Required, StringLength(25)>
    Public Property Name As String

    <Required, StringLength(28)>
    Public Property Collage As String

    Protected Overridable Property Users As ICollection(Of ApplicationUser)

End Class