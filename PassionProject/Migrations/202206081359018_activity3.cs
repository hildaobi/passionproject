namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activity3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Activities", new[] { "Coursecode" });
            DropPrimaryKey("dbo.Activities");
            AlterColumn("dbo.Activities", "ActivityId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Activities", "ActivityId");
            CreateIndex("dbo.Activities", "CourseCode");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Activities", new[] { "CourseCode" });
            DropPrimaryKey("dbo.Activities");
            AlterColumn("dbo.Activities", "ActivityId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Activities", "ActivityId");
            CreateIndex("dbo.Activities", "Coursecode");
        }
    }
}
