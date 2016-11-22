
Imports System.Data.Entity.Migrations

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of ApplicationDbContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As ApplicationDbContext)
            If (Not context.Roles.Any()) Then
                context.Roles.Add(New Microsoft.AspNet.Identity.EntityFramework.IdentityRole("SiteAdmin"))
                context.Roles.Add(New Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Admin"))
                context.Roles.Add(New Microsoft.AspNet.Identity.EntityFramework.IdentityRole("StudentAdmin"))
                context.Roles.Add(New Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Student"))
            End If
        End Sub

    End Class

End Namespace
