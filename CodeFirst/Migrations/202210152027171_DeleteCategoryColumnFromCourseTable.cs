namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoryColumnFromCourseTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Level", c => c.Int(nullable: false));
        }
    }
}
