namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseCode = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}
