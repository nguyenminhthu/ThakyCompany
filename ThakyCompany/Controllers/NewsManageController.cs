using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace VeSinhNamHoa.Controllers
{
    public class NewsManageController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new ThakyCompany.Models.ThakyContext();

        //
        // GET: /News/
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            database.News.Select(x => x).ToList();
            return View(database.News.Select(x => x).OrderByDescending(x => x.PostDate).AsEnumerable());
        }

        //
        // GET: /News/Details/5
        //public ActionResult Details(int id)
        //{
        //    News news = _newsService.GetById(id);
        //    return View(news);
        //}

        //
        // GET: /News/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        //private const string IMAGE_FOLDER = "/Images/News/";

        //
        // POST: /News/Create
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(News entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.PostDate = DateTime.Now;
                    entity.UserName = User.Identity.Name;
                    database.News.Add(entity);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(entity);
                // TODO: Add insert logic here
            }
            catch
            {
                return View(entity);
            }
        }

        //
        // GET: /News/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            News news = database.News.Where(x => x.ID == id).FirstOrDefault();
            return View(news);
        }

        //
        // POST: /News/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(News entity)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    News updateNews = database.News.Where(x => x.ID == entity.ID).FirstOrDefault();
                    if (updateNews != null)
                    {
                        updateNews.Actived = entity.Actived;
                        updateNews.EnDetail = entity.EnDetail;
                        updateNews.EnTitle = entity.EnTitle;
                        updateNews.ViDetail = entity.ViDetail;
                        updateNews.ViTitle = entity.ViTitle;
                    }
                    database.Entry(updateNews).State = System.Data.Entity.EntityState.Modified;
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

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public JsonResult Delete(int id)
        {
            bool isSuccess = false;
            try
            {
                // TODO: Add delete logic here
                News news = database.News.Where(x => x.ID == id).FirstOrDefault();
                database.News.Remove(news);
                database.SaveChanges();
                isSuccess = true; ;
            }
            catch
            {
                isSuccess = false;
            }
            return Json(new { success = isSuccess });
        }
    }
}