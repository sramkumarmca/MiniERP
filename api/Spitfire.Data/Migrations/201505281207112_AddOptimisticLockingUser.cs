namespace Spitfire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptimisticLockingUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Timestamp");
        }
    }
}
