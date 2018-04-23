namespace CarpoolApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestedByAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("TD.POST", "POST_CREATED_BY", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("TD.POST", "POST_CREATED_BY");
        }
    }
}
