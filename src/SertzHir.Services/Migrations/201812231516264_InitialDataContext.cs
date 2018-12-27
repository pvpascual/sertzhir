namespace SertzHir.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        person_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                        dob = c.DateTime(nullable: false),
                        state_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.person_id)
                .ForeignKey("dbo.States", t => t.state_id, cascadeDelete: true)
                .Index(t => t.state_id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        state_id = c.Int(nullable: false, identity: true),
                        state_code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.state_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "state_id", "dbo.States");
            DropIndex("dbo.People", new[] { "state_id" });
            DropTable("dbo.States");
            DropTable("dbo.People");
        }
    }
}
