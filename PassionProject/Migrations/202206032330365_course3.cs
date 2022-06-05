namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Course_CourseCode", c => c.Int());
            CreateIndex("dbo.Courses", "Course_CourseCode");
            AddForeignKey("dbo.Courses", "Course_CourseCode", "dbo.Courses", "CourseCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Course_CourseCode", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "Course_CourseCode" });
            DropColumn("dbo.Courses", "Course_CourseCode");
        }
    }
}
