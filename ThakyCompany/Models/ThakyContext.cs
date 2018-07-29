using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class ThakyContext : DbContext
    {
        //string securityKey = "MoringaVina123!!";
        public ThakyContext(): base("DefaultConnection")
        {
            //string connect = Util.Utilities.Decrypt(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(), true, securityKey);
            //this.Database.Connection.ConnectionString = connect;
        }

        public DbSet<Page> Pages { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<VisitorOnline> VisitorOnline { get; set; }

        public DbSet<QuyTrinh> QuyTrinhs { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}