namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init121 : DbMigration
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
                        CategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UrlSlug = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 300),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        UrlSlug = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Comment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.UserId)
                .Index(t => t.PostId)
                .Index(t => t.Comment_Id);
            
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
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Content = c.Binary(),
                        UrlSlug = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.PostImage",
                c => new
                    {
                        Image_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Image_Id, t.Post_Id })
                .ForeignKey("dbo.Images", t => t.Image_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Image_Id)
                .Index(t => t.Post_Id);
            
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
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TagPost", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagPost", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.PostImage", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.PostImage", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.TagPost", new[] { "Tag_Id" });
            DropIndex("dbo.TagPost", new[] { "Post_Id" });
            DropIndex("dbo.PostImage", new[] { "Post_Id" });
            DropIndex("dbo.PostImage", new[] { "Image_Id" });
            DropIndex("dbo.Comments", new[] { "Comment_Id" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.TagPost");
            DropTable("dbo.PostImage");
            DropTable("dbo.Tags");
            DropTable("dbo.Images");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
