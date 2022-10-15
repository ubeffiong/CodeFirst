namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delectDuplicate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Author_Id", "dbo.Author");
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            AddColumn("dbo.Courses", "Author_Id1", c => c.Int());
            CreateIndex("dbo.Courses", "Author_Id1");
            AddForeignKey("dbo.Courses", "Author_Id1", "dbo.Author", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Author_Id1", "dbo.Author");
            DropIndex("dbo.Courses", new[] { "Author_Id1" });
            DropColumn("dbo.Courses", "Author_Id1");
            CreateIndex("dbo.Courses", "Author_Id");
            AddForeignKey("dbo.Courses", "Author_Id", "dbo.Author", "Id");
        }
    }
}
