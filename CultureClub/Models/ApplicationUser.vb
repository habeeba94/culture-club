Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class ApplicationUser
    Inherits IdentityUser

    <Required, StringLength(10)>
    Public Property FirstName As String

    <Required, StringLength(10)>
    Public Property LastName As String

    <StringLength(9, MinimumLength:=9)>
    Public Property UniversityId As String
    Public Property MajorId As Integer?

    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        userIdentity.AddClaim(New Claim(type := ClaimTypes.GivenName, value :=$"{FirstName} {LastName}"))
       
        Return userIdentity
    End Function

    <ForeignKey("MajorId")>
    Public Property Major As Major
End Class