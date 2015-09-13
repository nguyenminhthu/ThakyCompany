using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThakyCompany.Controllers
{
    public class QuanLyController : Controller
    {
        //
        // GET: /QuanLy/
        public ActionResult Index()
        {
            return RedirectToAction("Index", "ProductManage");
        }
    }
}