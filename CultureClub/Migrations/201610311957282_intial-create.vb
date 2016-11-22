Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class intialcreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Activities",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .AdminId = c.String(maxLength := 128),
                        .Name = c.String(nullable := False, maxLength := 10),
                        .Description = c.String(nullable := False, maxLength := 10),
                        .StartDate = c.DateTime(nullable := False),
                        .EndDate = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.AdminId) _
                .Index(Function(t) t.AdminId)
            
            CreateTable(
                "dbo.AspNetUsers",
                Function(c) New With
                    {
                        .Id = c.String(nullable := False, maxLength := 128),
                        .FirstName = c.String(nullable := False, maxLength := 10),
                        .LastName = c.String(nullable := False, maxLength := 10),
                        .UniversityId = c.String(maxLength := 9),
                        .MajorId = c.Int(),
                        .Email = c.String(maxLength := 256),
                        .EmailConfirmed = c.Boolean(nullable := False),
                        .PasswordHash = c.String(),
                        .SecurityStamp = c.String(),
                        .PhoneNumber = c.String(),
                        .PhoneNumberConfirmed = c.Boolean(nullable := False),
                        .TwoFactorEnabled = c.Boolean(nullable := False),
                        .LockoutEndDateUtc = c.DateTime(),
                        .LockoutEnabled = c.Boolean(nullable := False),
                        .AccessFailedCount = c.Int(nullable := False),
                        .UserName = c.String(nullable := False, maxLength := 256)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Majors", Function(t) t.MajorId) _
                .Index(Function(t) t.MajorId) _
                .Index(Function(t) t.UserName, unique := True, name := "UserNameIndex")
            
            CreateTable(
                "dbo.AspNetUserClaims",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .ClaimType = c.String(),
                        .ClaimValue = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId, cascadeDelete := True) _
                .Index(Function(t) t.UserId)
            
            CreateTable(
                "dbo.AspNetUserLogins",
                Function(c) New With
                    {
                        .LoginProvider = c.String(nullable := False, maxLength := 128),
                        .ProviderKey = c.String(nullable := False, maxLength := 128),
                        .UserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) New With { t.LoginProvider, t.ProviderKey, t.UserId }) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId, cascadeDelete := True) _
                .Index(Function(t) t.UserId)
            
            CreateTable(
                "dbo.Majors",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(nullable := False, maxLength := 10),
                        .Collage = c.String(nullable := False, maxLength := 10)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.AspNetUserRoles",
                Function(c) New With
                    {
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .RoleId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) New With { t.UserId, t.RoleId }) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId, cascadeDelete := True) _
                .ForeignKey("dbo.AspNetRoles", Function(t) t.RoleId, cascadeDelete := True) _
                .Index(Function(t) t.UserId) _
                .Index(Function(t) t.RoleId)
            
            CreateTable(
                "dbo.Attendees",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .ActivityId = c.Int(nullable := False),
                        .Email = c.String(nullable := False),
                        .MobileNumber = c.String(maxLength := 13),
                        .UniversityId = c.String(maxLength := 9)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Activities", Function(t) t.ActivityId, cascadeDelete := True) _
                .Index(Function(t) t.ActivityId)
            
            CreateTable(
                "dbo.Group",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(nullable := False, maxLength := 10),
                        .Description = c.String(nullable := False, maxLength := 10)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.AspNetRoles",
                Function(c) New With
                    {
                        .Id = c.String(nullable := False, maxLength := 128),
                        .Name = c.String(nullable := False, maxLength := 256)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .Index(Function(t) t.Name, unique := True, name := "RoleNameIndex")
            
            CreateTable(
                "dbo.UserGroups",
                Function(c) New With
                    {
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .GroupId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.UserId, t.GroupId }) _
                .ForeignKey("dbo.Group", Function(t) t.GroupId, cascadeDelete := True) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId, cascadeDelete := True) _
                .Index(Function(t) t.UserId) _
                .Index(Function(t) t.GroupId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Group")
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles")
            DropForeignKey("dbo.Attendees", "ActivityId", "dbo.Activities")
            DropForeignKey("dbo.Activities", "AdminId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUsers", "MajorId", "dbo.Majors")
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers")
            DropIndex("dbo.UserGroups", New String() { "GroupId" })
            DropIndex("dbo.UserGroups", New String() { "UserId" })
            DropIndex("dbo.AspNetRoles", "RoleNameIndex")
            DropIndex("dbo.Attendees", New String() { "ActivityId" })
            DropIndex("dbo.AspNetUserRoles", New String() { "RoleId" })
            DropIndex("dbo.AspNetUserRoles", New String() { "UserId" })
            DropIndex("dbo.AspNetUserLogins", New String() { "UserId" })
            DropIndex("dbo.AspNetUserClaims", New String() { "UserId" })
            DropIndex("dbo.AspNetUsers", "UserNameIndex")
            DropIndex("dbo.AspNetUsers", New String() { "MajorId" })
            DropIndex("dbo.Activities", New String() { "AdminId" })
            DropTable("dbo.UserGroups")
            DropTable("dbo.AspNetRoles")
            DropTable("dbo.Group")
            DropTable("dbo.Attendees")
            DropTable("dbo.AspNetUserRoles")
            DropTable("dbo.Majors")
            DropTable("dbo.AspNetUserLogins")
            DropTable("dbo.AspNetUserClaims")
            DropTable("dbo.AspNetUsers")
            DropTable("dbo.Activities")
        End Sub
    End Class
End Namespace
