Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class activitygroup
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ActivityGroups",
                Function(c) New With
                    {
                        .ActivityId = c.Int(nullable := False),
                        .GroupId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.ActivityId, t.GroupId }) _
                .ForeignKey("dbo.Activities", Function(t) t.ActivityId, cascadeDelete := True) _
                .ForeignKey("dbo.Group", Function(t) t.GroupId, cascadeDelete := True) _
                .Index(Function(t) t.ActivityId) _
                .Index(Function(t) t.GroupId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.ActivityGroups", "GroupId", "dbo.Group")
            DropForeignKey("dbo.ActivityGroups", "ActivityId", "dbo.Activities")
            DropIndex("dbo.ActivityGroups", New String() { "GroupId" })
            DropIndex("dbo.ActivityGroups", New String() { "ActivityId" })
            DropTable("dbo.ActivityGroups")
        End Sub
    End Class
End Namespace
