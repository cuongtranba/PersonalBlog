namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 50),
                        UrlSlug = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        ShortDescription = c.String(maxLength: 150),
                        Description = c.String(),
                        Meta = c.String(maxLength: 50),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        UrlSlug = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        UrlSlug = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Profile = c.String(maxLength: 150),
                        DOB = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UrlSlug = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagPost",
                c => new
                    {
                        Post_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.Tag_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TagPost", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagPost", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.TagPost", new[] { "Tag_Id" });
            DropIndex("dbo.TagPost", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            DropTable("dbo.TagPost");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
