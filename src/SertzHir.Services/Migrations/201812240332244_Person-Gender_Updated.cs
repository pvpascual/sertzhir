namespace SertzHir.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonGender_Updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "gender", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "gender");
        }
    }
}
