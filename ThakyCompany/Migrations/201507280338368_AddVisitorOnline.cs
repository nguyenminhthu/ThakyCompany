namespace ThakyCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddVisitorOnline : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.VisitorOnlines",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Online = c.Int(nullable: false)
                }).PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            DropTable("dbo.VisitorOnlines");
        }
    }
}