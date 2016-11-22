Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Partial Public Class ActivityGroup

    <Key, Column(Order:=1)>
    Public Property ActivityId As Integer

    <Key, Column(Order:=2)>
    Public Property GroupId As Integer

    <ForeignKey("ActivityId")>
    Public Overridable Property Activity As Activity

    <ForeignKey("GroupId")>
    Public Overridable Property Group As Group
    <DataType(DataType.Date)>
    Public Property JoinDate As Date
End Class