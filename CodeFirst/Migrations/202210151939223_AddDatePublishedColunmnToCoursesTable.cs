namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatePublishedColunmnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "Author_Id");
            RenameColumn(table: "dbo.Courses", name: "Author_Id1", newName: "Author_Id");
            RenameIndex(table: "dbo.Courses", name: "IX_Author_Id1", newName: "IX_Author_Id");
            AddColumn("dbo.Courses", "DatePublished", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "DatePublished");
            RenameIndex(table: "dbo.Courses", name: "IX_Author_Id", newName: "IX_Author_Id1");
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "Author_Id1");
            AddColumn("dbo.Courses", "Author_Id", c => c.Int());
        }
    }
}
