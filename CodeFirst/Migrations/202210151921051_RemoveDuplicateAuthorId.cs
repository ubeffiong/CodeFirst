namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDuplicateAuthorId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "Author_Id");
            RenameColumn(table: "dbo.Courses", name: "Author_Id1", newName: "Author_Id");
            RenameIndex(table: "dbo.Courses", name: "IX_Author_Id1", newName: "IX_Author_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Courses", name: "IX_Author_Id", newName: "IX_Author_Id1");
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "Author_Id1");
            AddColumn("dbo.Courses", "Author_Id", c => c.Int());
        }
    }
}
