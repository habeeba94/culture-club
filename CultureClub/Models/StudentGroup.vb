Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class StudentGroup

    <Key, Column(Order:=1)>
    Public Property UserId As String

    <Key, Column(Order:=2)>
    Public Property GroupId As Integer

    <ForeignKey("UserId")>
    Public Overridable Property Student As Student

    <ForeignKey("GroupId")>
    Public Overridable Property Group As Group

End Class