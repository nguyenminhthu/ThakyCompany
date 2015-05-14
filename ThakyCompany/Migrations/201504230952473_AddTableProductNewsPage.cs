namespace ThakyCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableProductNewsPage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostDate = c.DateTime(nullable: false),
                        Actived = c.Boolean(nullable: false),
                        UserName = c.String(),
                        EnTitle = c.String(),
                        EnDetail = c.String(),
                        ViTitle = c.String(),
                        ViDetail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EnTitle = c.String(),
                        EnDetail = c.String(),
                        ViTitle = c.String(),
                        ViDetail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Actived = c.Boolean(nullable: false),
                        EnTitle = c.String(),
                        EnDetail = c.String(),
                        ViTitle = c.String(),
                        ViDetail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Pages");
            DropTable("dbo.News");
        }
    }
}
