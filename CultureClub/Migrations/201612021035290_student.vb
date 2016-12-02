Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class student
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.AspNetUsers", "MajorId", "dbo.Majors")
            AddColumn("dbo.AspNetUsers", "Discriminator", Function(c) c.String(nullable := False, maxLength := 128))
            AddForeignKey("dbo.AspNetUsers", "MajorId", "dbo.Majors", "Id", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.AspNetUsers", "MajorId", "dbo.Majors")
            DropColumn("dbo.AspNetUsers", "Discriminator")
            AddForeignKey("dbo.AspNetUsers", "MajorId", "dbo.Majors", "Id")
        End Sub
    End Class
End Namespace
