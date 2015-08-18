namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test100 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "Comment_Id", newName: "CommentId");
            RenameIndex(table: "dbo.Comments", name: "IX_Comment_Id", newName: "IX_CommentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_CommentId", newName: "IX_Comment_Id");
            RenameColumn(table: "dbo.Comments", name: "CommentId", newName: "Comment_Id");
        }
    }
}
