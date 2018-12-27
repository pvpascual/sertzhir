namespace SertzHir.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class States_Updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "state_code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "state_code", c => c.Int(nullable: false));
        }
    }
}
