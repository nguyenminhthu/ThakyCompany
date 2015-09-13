using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class HomeController : Controller
    {
        private const int ABOUTUS_ID = 1;
        private const int AGENCY_ID = 2;
        private ThakyCompany.Models.ThakyContext context = new Models.ThakyContext();

        public ActionResult Index(int? id)
        {
            UpdateOnlineNumber();

            int pageId = ABOUTUS_ID;
            if (id != null)
            {
                pageId = AGENCY_ID;
            }

            var page = context.Pages.Where(x => x.ID == pageId).Select(x => x).FirstOrDefault();
            ViewBag.Title = "Cơ sở trà Thần Kỳ";
            return View(page);
        }

        private void UpdateOnlineNumber()
        {
            IEnumerable<VisitorOnline> todayOnline;
            DateTime nowDate = DateTime.Now.Date;
            todayOnline = context.VisitorOnline.Where(x => x.Date == nowDate);
            if (todayOnline == null || todayOnline.Count() == 0)
            {
                context.VisitorOnline.Add(new VisitorOnline() { Date = DateTime.Now.Date, Online = int.Parse(System.Web.HttpContext.Current.Application["Today"].ToString()) });
                context.SaveChanges();
                System.Web.HttpContext.Current.Application["Today"] = 1;
                System.Web.HttpContext.Current.Application["Online"] = 1;
            }
            else
            {
                VisitorOnline updateCounter = context.VisitorOnline.Where(x => x.ID == todayOnline.FirstOrDefault().ID).FirstOrDefault();
                if (updateCounter.Online < int.Parse(System.Web.HttpContext.Current.Application["Today"].ToString()))
                {
                    updateCounter.Online = int.Parse(System.Web.HttpContext.Current.Application["Today"].ToString());
                    context.Entry(updateCounter).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    System.Web.HttpContext.Current.Application["Today"] = updateCounter.Online;
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}