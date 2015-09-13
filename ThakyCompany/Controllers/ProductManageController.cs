using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class ProductManageController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        //
        // GET: /ProductManage/
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            database.News.Select(x => x).ToList();
            return View(database.Products.Select(x => x).OrderByDescending(x => x.PostDate).AsEnumerable());
        }

        //
        // GET: /ProductManage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ProductManage/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        private const string IMAGE_FOLDER = "/Content/Images/Products/";

        //
        // POST: /ProductManage/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateInput(false)]
        public ActionResult Create(HttpPostedFileBase newsImage, Product entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string imageUrl = UpLoadImage(newsImage);

                    if (imageUrl != string.Empty)
                    {
                        imageUrl = imageUrl.Replace(IMAGE_FOLDER, string.Empty);
                        entity.Image = imageUrl;
                        entity.PostDate = DateTime.Now;
                        database.Products.Add(entity);
                        database.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                return View(entity);
                // TODO: Add insert logic here
            }
            catch
            {
                return View(entity);
            }
        }

        private string UpLoadImage(HttpPostedFileBase imageFile)
        {
            string fileFolder = string.Empty;
            if (imageFile != null)
            {
                string pic = System.IO.Path.GetFileName(imageFile.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath(IMAGE_FOLDER), pic);
                //if (System.IO.File.Exists(path))
                //{
                //    string extension = System.IO.Path.GetExtension(path);
                //    pic = pic.Replace(extension, "1" + extension);
                //    path = path.Replace(extension, "1" + extension);
                //}
                // file is uploaded
                imageFile.SaveAs(path);

                //// save the image path path to the database or you can send image
                //// directly to database
                //// in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    imageFile.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}
                fileFolder = IMAGE_FOLDER + pic;
            }
            return fileFolder;
        }

        //
        // GET: /ProductManage/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Product product = database.Products.Where(x => x.ID == id).FirstOrDefault();
            product.Image = IMAGE_FOLDER + product.Image;
            return View(product);
        }

        //
        // POST: /ProductManage/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateInput(false)]
        public ActionResult Edit(HttpPostedFileBase productImage, Product entity)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Product updateProduct = database.Products.Where(x => x.ID == entity.ID).FirstOrDefault();
                    if (updateProduct != null)
                    {
                        string imageUrl = UpLoadImage(productImage);
                        if (imageUrl != string.Empty)
                        {
                            imageUrl = imageUrl.Replace(IMAGE_FOLDER, string.Empty);
                            updateProduct.Image = imageUrl;
                        }
                        updateProduct.Actived = entity.Actived;
                        updateProduct.EnDetail = entity.EnDetail;
                        updateProduct.EnTitle = entity.EnTitle;
                        updateProduct.ViDetail = entity.ViDetail;
                        updateProduct.ViTitle = entity.ViTitle;
                        updateProduct.Price = entity.Price;
                    }
                    database.Entry(updateProduct).State = System.Data.Entity.EntityState.Modified;
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
                Product product = database.Products.Where(x => x.ID == id).FirstOrDefault();
                database.Products.Remove(product);
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