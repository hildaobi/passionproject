namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "StudentId", "dbo.Students");
            DropIndex("dbo.Activities", new[] { "StudentId" });
            DropTable("dbo.Activities");
        }
    }
}
