Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class UserGroup

    <Key, Column(Order := 1)>
    Public Property UserId As String

    <Key, Column(Order := 2)>
    Public Property GroupId As Integer

    <ForeignKey("UserId")>
    Protected Overridable Property User As ApplicationUser

    <ForeignKey("GroupId")>
    Protected Overridable Property Group As Group

End Class