namespace Toolshed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToolReserves",
                c => new
                    {
                        ReserveId = c.String(nullable: false, maxLength: 128),
                        ReserveDate = c.String(),
                        UserName = c.String(),
                        ToolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReserveId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        ToolId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category = c.String(),
                        Description = c.String(),
                        Picture = c.String(),
                        Available = c.Boolean(nullable: false),
                        ToolshedUser_UserID = c.String(maxLength: 128),
                        ToolshedUser_UserID1 = c.String(maxLength: 128),
                        ToolshedUser_UserID2 = c.String(maxLength: 128),
                        Owner_UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ToolId)
                .ForeignKey("dbo.ToolshedUsers", t => t.ToolshedUser_UserID)
                .ForeignKey("dbo.ToolshedUsers", t => t.ToolshedUser_UserID1)
                .ForeignKey("dbo.ToolshedUsers", t => t.ToolshedUser_UserID2)
                .ForeignKey("dbo.ToolshedUsers", t => t.Owner_UserID)
                .Index(t => t.ToolshedUser_UserID)
                .Index(t => t.ToolshedUser_UserID1)
                .Index(t => t.ToolshedUser_UserID2)
                .Index(t => t.Owner_UserID);
            
            CreateTable(
                "dbo.ToolshedUsers",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 15),
                        Phone = c.String(),
                        Street = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tools", "Owner_UserID", "dbo.ToolshedUsers");
            DropForeignKey("dbo.Tools", "ToolshedUser_UserID2", "dbo.ToolshedUsers");
            DropForeignKey("dbo.Tools", "ToolshedUser_UserID1", "dbo.ToolshedUsers");
            DropForeignKey("dbo.Tools", "ToolshedUser_UserID", "dbo.ToolshedUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tools", new[] { "Owner_UserID" });
            DropIndex("dbo.Tools", new[] { "ToolshedUser_UserID2" });
            DropIndex("dbo.Tools", new[] { "ToolshedUser_UserID1" });
            DropIndex("dbo.Tools", new[] { "ToolshedUser_UserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ToolshedUsers");
            DropTable("dbo.Tools");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ToolReserves");
        }
    }
}
