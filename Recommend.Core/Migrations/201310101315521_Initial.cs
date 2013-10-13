namespace Recommend.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Email = c.String(),
                        CreatedOn = c.DateTime(defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recommendation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlaceId = c.Int(),
                        PhotoFile = c.Binary(),
                        Description = c.String(nullable: false),
                        When = c.DateTime(),
                        Link = c.String(),
                        CreatedOn = c.DateTime(defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Place", t => t.PlaceId)
                .Index(t => t.UserId)
                .Index(t => t.PlaceId);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false),
                        PhotoFile = c.Binary(),
                        Link = c.String(),
                        UserId = c.Int(nullable: false),
                        Location = c.Geography(nullable: false),
                        CreatedOn = c.DateTime(defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Place", new[] { "UserId" });
            DropIndex("dbo.Recommendation", new[] { "PlaceId" });
            DropIndex("dbo.Recommendation", new[] { "UserId" });
            DropForeignKey("dbo.Place", "UserId", "dbo.User");
            DropForeignKey("dbo.Recommendation", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Recommendation", "UserId", "dbo.User");
            DropTable("dbo.Place");
            DropTable("dbo.Recommendation");
            DropTable("dbo.User");
        }
    }
}
