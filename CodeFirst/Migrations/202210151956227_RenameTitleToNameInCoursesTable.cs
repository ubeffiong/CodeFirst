namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Courses", "Author_Id", "dbo.Author");
            //DropIndex("dbo.Courses", new[] { "Author_Id" });
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            Sql("UPDATE Courses SET Name = Title");
            //AddColumn("dbo.Courses", "Author_Id", c => c.Int());
            //CreateIndex("dbo.Courses", "Author_Id");
            //AddForeignKey("dbo.Courses", "Author_Id", "dbo.Author", "Id");
            DropColumn("dbo.Courses", "Title");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            Sql("UPDATE Courses SET Title = Name");
           //DropForeignKey("dbo.Courses", "Author_Id1", "dbo.Author");
            //DropIndex("dbo.Courses", new[] { "Author_Id1" });
            //DropColumn("dbo.Courses", "Author_Id1");
            DropColumn("dbo.Courses", "Name");
            //CreateIndex("dbo.Courses", "Author_Id");
            //AddForeignKey("dbo.Courses", "Author_Id", "dbo.Author", "Id");
        }
    }
}
