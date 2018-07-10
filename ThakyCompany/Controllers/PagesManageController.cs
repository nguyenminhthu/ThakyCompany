using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class PagesManageController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new ThakyCompany.Models.ThakyContext();

        //
        // GET: /Pages/
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            database.Pages.Select(x => x).ToList();
            return View(database.Pages.Select(x => x).AsEnumerable());
        }

        //
        // GET: /Pages/Details/5
        //public ActionResult Details(int id)
        //{
        //    Pages Pages = _PagesService.GetById(id);
        //    return View(Pages);
        //}

        //
        // GET: /Pages/Create
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //private const string IMAGE_FOLDER = "/Images/Pages/";

        //
        // POST: /Pages/Create
        //[HttpPost]
        //[ValidateInput(false)]
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Create(Page entity)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            database.Pages.Add(entity);
        //            database.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(entity);
        //        // TODO: Add insert logic here
        //    }
        //    catch
        //    {
        //        return View(entity);
        //    }
        //}

        //
        // GET: /Pages/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Page page = database.Pages.Where(x => x.ID == id).FirstOrDefault();
            return View(page);
        }

        //
        // POST: /Pages/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Page entity)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Page updatePage = database.Pages.Where(x => x.ID == entity.ID).FirstOrDefault();
                    if (updatePage != null)
                    {
                        updatePage.EnDetail = entity.EnDetail;
                        updatePage.EnTitle = entity.EnTitle;
                        updatePage.ViDetail = entity.ViDetail;
                        updatePage.ViTitle = entity.ViTitle;
                    }
                    database.Entry(updatePage).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        //[HttpPost]
        //[Authorize(Roles = "Administrator")]
        //public JsonResult Delete(int id)
        //{
        //    bool isSuccess = false;
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        Pages Pages = database.Pages.Where(x => x.ID == id).FirstOrDefault();
        //        database.Pages.Remove(Pages);
        //        database.SaveChanges();
        //        isSuccess = true; ;
        //    }
        //    catch
        //    {
        //        isSuccess = false;
        //    }
        //    return Json(new { success = isSuccess });
        //}
    }
}