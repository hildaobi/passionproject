namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            //DropTable("dbo.People");
        }
        
        public override void Down()
        {
          /*  CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                        PersonLastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);*/
            
        }
    }
}
