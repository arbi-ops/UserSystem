namespace UserSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseWithActivityLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 256),
                        Action = c.String(nullable: false, maxLength: 128),
                        Entity = c.String(maxLength: 256),
                        TimestampUtc = c.DateTime(nullable: false),
                        IpAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActivityLogs");
        }
    }
}
