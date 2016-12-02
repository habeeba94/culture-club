Imports System.Data.Entity
Imports Microsoft.AspNet.Identity.EntityFramework

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function

    Public Overridable Property Activities As DbSet(Of Activity)
    Public Overridable Property Attendees As DbSet(Of Attendee)
    Public Overridable Property UserGroups As DbSet(Of UserGroup)
    Public Overridable Property Groups As DbSet(Of Group)
    Public Overridable Property Majors As DbSet(Of Major)
    Public Overridable Property ActivityGroups As DbSet(Of ActivityGroup)
    Public Overridable Property Students As DbSet(Of Student)

End Class