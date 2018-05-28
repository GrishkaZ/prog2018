namespace RemontWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Remmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBBreakages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    BreakageType = c.Int(nullable: false),
                    DbRemonrModel_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbRideRequests", t => t.DbRemonrModel_Id)
                .Index(t => t.DbRemonrModel_Id);

            CreateTable(
                "dbo.DbRemontModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Days = c.Int(),
                    Filled = c.DateTime(nullable: false),
                    FullName = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Currency = c.Int(nullable: false),
                    BrokenDevice = c.Int(nullable: false),
                    BuySomeDetailsYourself = c.Boolean(nullable: false),
                    AdditionalRequests = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.DBBreakages", "DbRemonrModel_Id", "dbo.DbRemontModels");
            DropIndex("dbo.DBBreakages", new[] { "DbRemonrModelt_Id" });
            DropTable("dbo.DbRemontModels");
            DropTable("dbo.DBBreakages");
        }
    }
}
