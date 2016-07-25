using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class ThakyContext : DbContext
    {
        public ThakyContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Page> Pages { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<VisitorOnline> VisitorOnline { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
    }
}