namespace ThakyCompany.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ThakyCompany.Models.ThakyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ThakyCompany.Models.ThakyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ProductCategory.AddOrUpdate(new Models.ProductCategory() { EnTitle = "Trà Chùm Ngây", ViTitle = "Trà Chùm Ngây" });
            context.ProductCategory.AddOrUpdate(new Models.ProductCategory() { EnTitle = "Bột Ngũ Cốc", ViTitle = "Bột Ngũ Cốc" });
            context.ProductCategory.AddOrUpdate(new Models.ProductCategory() { EnTitle = "Nông Sản Sấy", ViTitle = "Nông Sản Sấy" });
            context.ProductCategory.AddOrUpdate(new Models.ProductCategory() { EnTitle = "Thảo Dược Quý", ViTitle = "Thảo Dược Quý" });
            context.ProductCategory.AddOrUpdate(new Models.ProductCategory() { EnTitle = "Làm Đẹp", ViTitle = "Làm Đẹp" });
        }
    }
}
