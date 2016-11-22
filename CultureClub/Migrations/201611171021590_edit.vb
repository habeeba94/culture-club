Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class edit
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Activities", "Name", Function(c) c.String(nullable := False, maxLength := 28))
            AlterColumn("dbo.Activities", "Description", Function(c) c.String(nullable := False, maxLength := 300))
            AlterColumn("dbo.Majors", "Name", Function(c) c.String(nullable := False, maxLength := 25))
            AlterColumn("dbo.Majors", "Collage", Function(c) c.String(nullable := False, maxLength := 28))
            AlterColumn("dbo.Group", "Name", Function(c) c.String(nullable := False, maxLength := 25))
            AlterColumn("dbo.Group", "Description", Function(c) c.String(nullable := False, maxLength := 300))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Group", "Description", Function(c) c.String(nullable := False, maxLength := 10))
            AlterColumn("dbo.Group", "Name", Function(c) c.String(nullable := False, maxLength := 10))
            AlterColumn("dbo.Majors", "Collage", Function(c) c.String(nullable := False, maxLength := 10))
            AlterColumn("dbo.Majors", "Name", Function(c) c.String(nullable := False, maxLength := 10))
            AlterColumn("dbo.Activities", "Description", Function(c) c.String(nullable := False, maxLength := 10))
            AlterColumn("dbo.Activities", "Name", Function(c) c.String(nullable := False, maxLength := 10))
        End Sub
    End Class
End Namespace
