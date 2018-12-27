namespace SertzHir.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonEntity_Updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.States", "state_code", c => c.String(maxLength: 2, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.States", "state_code", c => c.String());
        }
    }
}
