Imports System.ComponentModel.DataAnnotations

Partial Public Class Activity
    Public Sub New()
        Attendees = New HashSet(Of Attendee)()
    End Sub
    Public Property Id As Integer

    Public Property AdminId As String

    <Required>
    <StringLength(28)>
    Public Property Name As String

    <Required>
    <StringLength(300)>
    Public Property Description As String
    <DataType(DataType.Date)>
    Public Property StartDate As Date
    <DataType(DataType.Date)>
    Public Property EndDate As Date

    Protected Overridable Property Admin As ApplicationUser
    Protected Overridable Property Attendees As ICollection(Of Attendee)

End Class