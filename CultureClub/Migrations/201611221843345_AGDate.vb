Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AGDate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.ActivityGroups", "JoinDate", Function(c) c.DateTime(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.ActivityGroups", "JoinDate")
        End Sub
    End Class
End Namespace
