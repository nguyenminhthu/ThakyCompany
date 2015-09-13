using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThakyCompany.Helper
{
    public static class VisitorHelper
    {
        public static void AddVisitorOnline(int onlineNumber)
        {
            using (ThakyCompany.Models.ThakyContext database = new Models.ThakyContext())
            {
                database.VisitorOnline.Add(new Models.VisitorOnline() { Date = DateTime.Now.AddDays(-1).Date, Online = onlineNumber });
                database.SaveChanges();
            }
        }

        public static void CountVisitor()
        {
            var application = HttpContext.Current.Application;
            application.Lock();
            if (application["visitors_online"] == null)
            {
                application["visitors_online"] = 0;
                application["Date"] = DateTime.Now.Date;
                application["today"] = 0;
            }
            if (DateTime.Parse(application["Date"].ToString()).Date == DateTime.Now.Date)
            {
                application["visitors_online"] = Convert.ToInt32(application["visitors_online"]) + 1;
                application["today"] = Convert.ToInt32(application["today"]) + 1;
            }
            else
            {
                AddVisitorOnline(int.Parse(application["today"].ToString()));
                application["visitors_online"] = 1;
                application["Date"] = DateTime.Now.Date;
                application["today"] = 1;
            }

            application.UnLock();
        }
    }
}