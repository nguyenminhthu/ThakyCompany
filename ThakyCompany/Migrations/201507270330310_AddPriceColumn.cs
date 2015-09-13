namespace ThakyCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddPriceColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("Products", "Price", x => x.String(nullable: true), null);
        }

        public override void Down()
        {
            DropColumn("Products", "Price");
        }
    }
}