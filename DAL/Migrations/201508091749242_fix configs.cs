namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixconfigs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Posts", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Posts", name: "IX_User_Id", newName: "IX_UserId");
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
            
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.PostImage", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.PostImage", "Image_Id", "dbo.Images");
            DropIndex("dbo.PostImage", new[] { "Post_Id" });
            DropIndex("dbo.PostImage", new[] { "Image_Id" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int());
            DropTable("dbo.PostImage");
            DropTable("dbo.Images");
            RenameIndex(table: "dbo.Posts", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Posts", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Posts", "Category_Id");
            AddForeignKey("dbo.Posts", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
