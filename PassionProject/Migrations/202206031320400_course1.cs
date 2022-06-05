namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Coursecode", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "Coursecode");
            AddForeignKey("dbo.Activities", "Coursecode", "dbo.Courses", "CourseCode", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "Coursecode", "dbo.Courses");
            DropIndex("dbo.Activities", new[] { "Coursecode" });
            DropColumn("dbo.Activities", "Coursecode");
        }
    }
}
