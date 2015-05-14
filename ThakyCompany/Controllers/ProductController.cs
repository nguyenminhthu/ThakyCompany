using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class ProductController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        public ActionResult LoadProductList()
        {
            List<ProductDto> productList = new List<ProductDto>();
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                foreach (var item in database.Products.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    productList.Add(new ProductDto() { ID = item.ID, Title = item.ViTitle, Detail = item.ViDetail, Image = item.Image });
                }
            }
            else
            {
                foreach (var item in database.Products.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    productList.Add(new ProductDto() { ID = item.ID, Title = item.EnTitle, Detail = item.EnDetail, Image = item.Image });
                }
            }
            return PartialView("_ProductMenu", productList);
        }

        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}