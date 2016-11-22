Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class Attendee
    Public Property Id As Integer

    Public Property ActivityId As Integer

    <Required, EmailAddress>
    Public Property Email As String

    <Phone, StringLength(13, MinimumLength:=10)>
    Public Property MobileNumber As String

    <StringLength(9, MinimumLength:=9)>
    Public Property UniversityId As String

    <ForeignKey("ActivityId")>
    Protected Overridable Property Activity As Activity
End Class