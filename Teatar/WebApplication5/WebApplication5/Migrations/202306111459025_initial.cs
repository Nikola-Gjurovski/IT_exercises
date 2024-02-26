namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Pol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Pretstavas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActorId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        code = c.String(maxLength: 6),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.ActorId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Teatars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.TeatarPretstavas",
                c => new
                    {
                        Teatar_Id = c.Int(nullable: false),
                        Pretstava_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teatar_Id, t.Pretstava_Id })
                .ForeignKey("dbo.Teatars", t => t.Teatar_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pretstavas", t => t.Pretstava_Id, cascadeDelete: true)
                .Index(t => t.Teatar_Id)
                .Index(t => t.Pretstava_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TeatarPretstavas", "Pretstava_Id", "dbo.Pretstavas");
            DropForeignKey("dbo.TeatarPretstavas", "Teatar_Id", "dbo.Teatars");
            DropForeignKey("dbo.Pretstavas", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Pretstavas", "ActorId", "dbo.Actors");
            DropIndex("dbo.TeatarPretstavas", new[] { "Pretstava_Id" });
            DropIndex("dbo.TeatarPretstavas", new[] { "Teatar_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pretstavas", new[] { "GenreId" });
            DropIndex("dbo.Pretstavas", new[] { "ActorId" });
            DropTable("dbo.TeatarPretstavas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teatars");
            DropTable("dbo.Genres");
            DropTable("dbo.Pretstavas");
            DropTable("dbo.Actors");
        }
    }
}
