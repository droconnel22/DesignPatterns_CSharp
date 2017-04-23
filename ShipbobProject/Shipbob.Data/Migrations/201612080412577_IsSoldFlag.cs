namespace Shipbob.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSoldFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "IsSold", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "IsSold");
        }
    }
}
