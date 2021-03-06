﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class EventManageController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new ThakyCompany.Models.ThakyContext();

        //
        // GET: /News/
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            database.Events.Select(x => x).ToList();
            return View(database.Events.Select(x => x).OrderByDescending(x => x.PostDate).AsEnumerable());
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
        public ActionResult Create(Event entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.PostDate = DateTime.Now;
                    database.Events.Add(entity);
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
            Event Event = database.Events.Where(x => x.ID == id).FirstOrDefault();
            return View(Event);
        }

        //
        // POST: /News/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Event entity)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Event updateEvents = database.Events.Where(x => x.ID == entity.ID).FirstOrDefault();
                    if (updateEvents != null)
                    {
                        updateEvents.Actived = entity.Actived;
                        updateEvents.EnDetail = entity.EnDetail;
                        updateEvents.EnTitle = entity.EnTitle;
                        updateEvents.ViDetail = entity.ViDetail;
                        updateEvents.ViTitle = entity.ViTitle;
                    }
                    database.Entry(updateEvents).State = System.Data.Entity.EntityState.Modified;
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
                Event Event = database.Events.Where(x => x.ID == id).FirstOrDefault();
                database.Events.Remove(Event);
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