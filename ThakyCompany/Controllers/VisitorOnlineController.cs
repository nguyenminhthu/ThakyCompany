using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThakyCompany.Controllers
{
    public class VisitorOnlineController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        public ActionResult ShowVisitorOnline()
        {
            ThakyCompany.Models.VisitorOnlineDto visitorOnline = new Models.VisitorOnlineDto();

            DateTime yesterday = DateTime.Now.AddDays(-1).Date;
            DateTime startDateOfWeek = DateTime.Now.AddDays(-7).Date;
            int curMonth = DateTime.Now.Month;

            visitorOnline.Online = int.Parse(System.Web.HttpContext.Current.Application["Online"].ToString());
            visitorOnline.Today = int.Parse(System.Web.HttpContext.Current.Application["Today"].ToString());
            if (database.VisitorOnline.Where(x => x.Date == yesterday).FirstOrDefault() != null)
            {
                visitorOnline.Yesterday = int.Parse(database.VisitorOnline.Where(x => x.Date == yesterday).FirstOrDefault().Online.ToString());
            }
            else
            {
                visitorOnline.Yesterday = 0;
            }

            visitorOnline.LastWeek = database.VisitorOnline.Where(x => x.Date >= startDateOfWeek).Sum(x => x.Online);
            if (database.VisitorOnline.Where(x => x.Date.Month == curMonth) != null)
            {
                visitorOnline.LastMonth = database.VisitorOnline.Where(x => x.Date.Month == curMonth).Sum(x => x.Online);
            }
            else
            {
                visitorOnline.LastMonth = 1;
            }
            visitorOnline.Total = database.VisitorOnline.Sum(x => x.Online);
            return PartialView("_VisitorOnline", visitorOnline);
        }
    }
}