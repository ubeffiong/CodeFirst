namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColumnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Authors", newName: "Author");
            DropForeignKey("dbo.Courses", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            AddColumn("dbo.Courses", "Author_Id1", c => c.Int());
            AddColumn("dbo.Courses", "Category_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Author_Id1");
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Courses", "Author_Id1", "dbo.Author", "Id");
            Sql("UPDATE Courses SET Category_Id = 1");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Author_Id1", "dbo.Author");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropIndex("dbo.Courses", new[] { "Author_Id1" });
            DropColumn("dbo.Courses", "Category_Id");
            DropColumn("dbo.Courses", "Author_Id1");
            CreateIndex("dbo.Courses", "Author_Id");
            AddForeignKey("dbo.Courses", "Author_Id", "dbo.Authors", "Id");
            RenameTable(name: "dbo.Author", newName: "Authors");
        }
    }
}
