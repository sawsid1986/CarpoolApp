namespace CarpoolApp.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TL.LOCATION",
                c => new
                    {
                        LOCATION_ID = c.Int(nullable: false, identity: true),
                        LOCATION_NAME = c.String(),
                        LOCATION_CITY = c.String(),
                        INSERTED_ON = c.DateTime(),
                        MODIFIED_ON = c.DateTime(),
                        IS_CURRENT = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LOCATION_ID);
            
            CreateTable(
                "TD.POST",
                c => new
                    {
                        POST_ID = c.Int(nullable: false, identity: true),
                        CAR_ID = c.Int(nullable: false),
                        DEPARTURE_TIME = c.DateTime(),
                        FROM_LOCATION_ID = c.Int(),
                        TO_LOCATION_ID = c.Int(),
                        FROM_LANDMARK = c.String(),
                        TO_LANDMAKR = c.String(),
                        NUMBER_OF_SEATS = c.Int(nullable: false),
                        POST_STATUS_ID = c.Int(nullable: false),
                        INSERTED_ON = c.DateTime(),
                        MODIFIED_ON = c.DateTime(),
                        IS_CURRENT = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.POST_ID);
            
            CreateTable(
                "TD.REQUEST",
                c => new
                    {
                        REQUEST_ID = c.Int(nullable: false, identity: true),
                        REQUESTER_NAME = c.String(),
                        DEPARTURE_TIME = c.DateTime(),
                        FROM_LOCATION_ID = c.Int(),
                        TO_LOCATION_ID = c.Int(),
                        FROM_LANDMARK = c.String(),
                        TO_LANDMAKR = c.String(),
                        NUMBER_OF_SEATS_REQUESTED = c.Int(nullable: false),
                        REQUEST_STATUS_ID = c.Int(nullable: false),
                        INSERTED_ON = c.DateTime(),
                        MODIFIED_ON = c.DateTime(),
                        IS_CURRENT = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.REQUEST_ID);
            
            CreateTable(
                "TL.CARPOOL_STATUS",
                c => new
                    {
                        STATUS_ID = c.Int(nullable: false, identity: true),
                        STATUS_NAME = c.String(),
                        INSERTED_ON = c.DateTime(),
                        MODIFIED_ON = c.DateTime(),
                        IS_CURRENT = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.STATUS_ID);
            
            CreateTable(
                "TD.VEHICLE",
                c => new
                    {
                        VEHICLE_ID = c.Int(nullable: false, identity: true),
                        VEHICLE_NAME = c.String(),
                        VEHICLE_REGISTRATION_NUMBER = c.String(),
                        VEHICLE_OWNER_NAME = c.String(),
                        INSERTED_ON = c.DateTime(),
                        MODIFIED_ON = c.DateTime(),
                        IS_CURRENT = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VEHICLE_ID);
            
        }
        
        public override void Down()
        {
            DropTable("TD.VEHICLE");
            DropTable("TL.CARPOOL_STATUS");
            DropTable("TD.REQUEST");
            DropTable("TD.POST");
            DropTable("TL.LOCATION");
        }
    }
}
