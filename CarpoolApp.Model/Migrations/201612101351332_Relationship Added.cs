namespace CarpoolApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipAdded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("TD.POST", "CAR_ID");
            CreateIndex("TD.POST", "FROM_LOCATION_ID");
            CreateIndex("TD.POST", "TO_LOCATION_ID");
            AddForeignKey("TD.POST", "CAR_ID", "TD.VEHICLE", "VEHICLE_ID", cascadeDelete: true);
            AddForeignKey("TD.POST", "FROM_LOCATION_ID", "TL.LOCATION", "LOCATION_ID");
            AddForeignKey("TD.POST", "TO_LOCATION_ID", "TL.LOCATION", "LOCATION_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("TD.POST", "TO_LOCATION_ID", "TL.LOCATION");
            DropForeignKey("TD.POST", "FROM_LOCATION_ID", "TL.LOCATION");
            DropForeignKey("TD.POST", "CAR_ID", "TD.VEHICLE");
            DropIndex("TD.POST", new[] { "TO_LOCATION_ID" });
            DropIndex("TD.POST", new[] { "FROM_LOCATION_ID" });
            DropIndex("TD.POST", new[] { "CAR_ID" });
        }
    }
}
