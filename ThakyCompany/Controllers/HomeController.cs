using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThakyCompany.Controllers
{
    public class HomeController : Controller
    {
        private const int ABOUTUS_ID = 1;
        private const int AGENCY_ID = 2;

        public ActionResult Index(int? id)
        {
            int pageId = ABOUTUS_ID;
            if (id != null)
            {
                pageId = AGENCY_ID;
            }
            ThakyCompany.Models.ThakyContext context = new Models.ThakyContext();
            var page = context.Pages.Where(x => x.ID == pageId).Select(x => x).FirstOrDefault();
            return View(page);
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