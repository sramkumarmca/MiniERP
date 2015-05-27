namespace Spitfire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true, name: "IX_UserName");

        }

        public override void Down()
        {
            DropIndex("dbo.Users", "IX_UserName");
            DropTable("dbo.Users");
        }
    }
}
